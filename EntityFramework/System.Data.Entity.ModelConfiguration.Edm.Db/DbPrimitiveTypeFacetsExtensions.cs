using System.Data.Entity.Edm.Db;

namespace System.Data.Entity.ModelConfiguration.Edm.Db;

internal static class DbPrimitiveTypeFacetsExtensions
{
	public static DbPrimitiveTypeFacets Clone(this DbPrimitiveTypeFacets toClone)
	{
		DbPrimitiveTypeFacets dbPrimitiveTypeFacets = new DbPrimitiveTypeFacets();
		dbPrimitiveTypeFacets.CopyFrom(toClone);
		return dbPrimitiveTypeFacets;
	}

	public static void CopyFrom(this DbPrimitiveTypeFacets facets, DbPrimitiveTypeFacets other)
	{
		facets.IsFixedLength = other.IsFixedLength;
		facets.IsMaxLength = other.IsMaxLength;
		facets.IsUnicode = other.IsUnicode;
		facets.MaxLength = other.MaxLength;
		facets.Precision = other.Precision;
		facets.Scale = other.Scale;
	}
}
