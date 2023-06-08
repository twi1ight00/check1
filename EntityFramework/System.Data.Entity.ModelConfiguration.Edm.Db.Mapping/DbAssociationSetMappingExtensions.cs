using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Edm.Common;

namespace System.Data.Entity.ModelConfiguration.Edm.Db.Mapping;

internal static class DbAssociationSetMappingExtensions
{
	public static DbAssociationSetMapping Initialize(this DbAssociationSetMapping associationSetMapping)
	{
		associationSetMapping.SourceEndMapping = new DbAssociationEndMapping();
		associationSetMapping.TargetEndMapping = new DbAssociationEndMapping();
		return associationSetMapping;
	}

	public static object GetConfiguration(this DbAssociationSetMapping associationSetMapping)
	{
		return associationSetMapping.Annotations.GetConfiguration();
	}

	public static void SetConfiguration(this DbAssociationSetMapping associationSetMapping, object configuration)
	{
		associationSetMapping.Annotations.SetConfiguration(configuration);
	}
}
