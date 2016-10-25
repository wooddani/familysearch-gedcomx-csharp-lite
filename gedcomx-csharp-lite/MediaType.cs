using System;

namespace gedcomx_csharp_lite
{
	/// <summary>
	/// A collection of accept or content types to use in REST API requests.
	/// </summary>
	public enum MediaType
	{
		GEDCOMX_JSON_MEDIA_TYPE,
		GEDCOMX_RECORDSET_JSON_MEDIA_TYPE,
		ATOM_GEDCOMX_JSON_MEDIA_TYPE,
		APPLICATION_JSON_TYPE,
		FS_JSON_MEDIA_TYPE
	}
}
