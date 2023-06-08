using System.Data.Entity.Edm.Db;

namespace System.Data.Entity.Edm.Serialization.Xml.Internal.Ssdl;

internal static class DbModelSsdlHelper
{
	private const string selfRefRoleNameSuffix = "Self";

	/// <summary>
	///     Return role name pair
	/// </summary>
	/// <param name="firstTable"> </param>
	/// <param name="secondTable"> </param>
	/// <returns> </returns>
	internal static string[] GetRoleNamePair(DbTableMetadata firstTable, DbTableMetadata secondTable)
	{
		return new string[2]
		{
			firstTable.Name,
			(firstTable != secondTable) ? secondTable.Name : (secondTable.Name + "Self")
		};
	}
}
