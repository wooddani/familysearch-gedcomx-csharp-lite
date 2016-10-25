using gedcomx_csharp_lite;
using Gx.Common;
using Gx.Conclusion;
using Gx.Fs.Tree;
using Gx.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Example1
{
	class Program
	{
		public static JsonSerializerSettings jsettings = new JsonSerializerSettings
		{
			NullValueHandling = NullValueHandling.Ignore // Trims the extra content not needed in this case making things even faster with less content.
		};

		static void Main(string[] args)
		{
			var ft = new FamilySearchSDK("sdktester", "1234sdkpass", "WCQY-7J1Q-GKVV-7DNM-SQ5M-9Q5H-JX3H-CMJK");

			// Create a Person
			var gedcomx = new Gx.Gedcomx();
			gedcomx.AddPerson(TestBacking.GetCreateMalePerson());

			// Now post two of them to family search asynchronously
			var postTask = ft.Post("/platform/tree/persons", JsonConvert.SerializeObject(gedcomx), MediaType.GEDCOMX_JSON_MEDIA_TYPE);
			var postTask2 = ft.Post("/platform/tree/persons", JsonConvert.SerializeObject(gedcomx), MediaType.GEDCOMX_JSON_MEDIA_TYPE);
			Task.WaitAll(postTask, postTask2);
			var postResultSon = postTask.Result;
			var postResultFather = postTask2.Result;

			// Or if only one and you want synchronous results
			var postResults3 = ft.Post("/platform/tree/persons", JsonConvert.SerializeObject(gedcomx), MediaType.GEDCOMX_JSON_MEDIA_TYPE).Result;

			// Now get the new person.
			string[] personId = postResultSon.Headers.Location.ToString().Split('/');
			var response = ft.Get("/platform/tree/persons/" + personId.Last()).Result;

			// By presuming we have single element.
			Console.WriteLine(response.persons[0].id + " - " + response.persons[0].display.name);



			// Set parentage
			List<ChildAndParentsRelationship> relationships = new List<ChildAndParentsRelationship>();
			relationships.Add(new ChildAndParentsRelationship()
			{
				Father = new ResourceReference(postResultFather.Headers.Location.ToString()),
				Child = new ResourceReference(postResultSon.Headers.Location.ToString())
			});
			// use an array wrapper as we have to name the array.
			var content = JsonConvert.SerializeObject(new { childAndParentsRelationships = relationships }, jsettings);

			var rel = ft.Post("/platform/tree/relationships", content, MediaType.FS_JSON_MEDIA_TYPE);
			var results = rel.Result;

			// Now read the relationship back. (the Son)
			var anc = ft.Get("/platform/tree/ancestry?person=" + personId.Last()).Result;
			Console.WriteLine($"For {personId.Last()} then have these ancestors");
			foreach (var a in anc.persons)
			{
				Console.WriteLine(a.id + " - " + a.display.name);
			}


			// Now search!
			//platform/tree/search?q=motherGivenName%3AClarissa~%20fatherSurname%3AHeaton~%20motherSurname%3AHoyt~%20surname%3AHeaton~%20givenName%3AIsrael~%20fatherGivenName%3AJonathan~
			var encoded = Uri.EscapeDataString("motherGivenName:Clarissa~ fatherSurname:Heaton~ motherSurname:Hoyt~ surname:Heaton~ givenName:Israel~ fatherGivenName:Jonathan~");
			var searchResult = ft.Get("/platform/tree/search?q=" + encoded, MediaType.ATOM_GEDCOMX_JSON_MEDIA_TYPE).Result;

			Console.WriteLine($"Found close hits {searchResult.searchInfo[0].closeHits} with {searchResult.searchInfo[0].totalHits} total");

			var stopCount = 1000;
			var totalFetched = 0;
			while (searchResult != null &&
				(totalFetched <= Convert.ToInt32(searchResult.results) || totalFetched > stopCount))
			{
				totalFetched = (searchResult.index + searchResult.entries.Count);
				foreach (var e in searchResult.entries)
				{
					var p = e.content.gedcomx.persons[0];
					Console.WriteLine($"{p.id} - {p.display.name} birthDate {p.display.birthDate} birthPlace {p.display.birthPlace}");
				}

				// Advance & get the next search results if there.
				if (searchResult.results > (searchResult.index + searchResult.entries.Count))
				{
					Console.WriteLine($"fetching another. total={totalFetched}");
					searchResult = ft.Get(searchResult.links.next.href.Value, MediaType.ATOM_GEDCOMX_JSON_MEDIA_TYPE).Result;
				}
			}

			Console.WriteLine("Press Enter to Exit");
			Console.ReadLine();
		}
	}
}
