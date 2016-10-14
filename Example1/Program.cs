using gedcomx_csharp_lite;
using Gx.Conclusion;
using Gx.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
	class Program
	{
		static void Main(string[] args)
		{
			var ft = new FamilySearchSDK("sdktester", "1234sdkpass", "WCQY-7J1Q-GKVV-7DNM-SQ5M-9Q5H-JX3H-CMJK");

			// Create a Person
			var wrapper = new Gx.Gedcomx();
			wrapper.AddPerson(TestBacking.GetCreateMalePerson());

			// Now post two of them to family search asynchronously
			var postTask = ft.Post("/platform/tree/persons", JsonConvert.SerializeObject(wrapper));
			var postTask2 = ft.Post("/platform/tree/persons", JsonConvert.SerializeObject(wrapper));
			Task.WaitAll(postTask, postTask2);
			var postResult = postTask.Result;
			var postResult2 = postTask2.Result;

			// Or if only one and you want synchronous results
			var postResults3 = ft.Post("/platform/tree/persons", JsonConvert.SerializeObject(wrapper)).Result;

			// Now get the new person.
			string[] personId = postResult.Headers.Location.ToString().Split('/');
			var response = ft.Get("/platform/tree/persons/" + personId.Last()).Result;

			// By presuming we have single element.
			Console.WriteLine(response.persons[0].id + response.persons[0].display.name);

			// By looping over the first.
			foreach (var p in response.persons)
			{
				Console.WriteLine(p.id + " " + p.display.name);
			}

			Console.ReadLine();
		}
	}
}
