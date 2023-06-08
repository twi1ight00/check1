using System.Data.Entity.Edm.Db.Mapping;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Edm.Db.Mapping;

internal static class DbEdmPropertyMappingExtensions
{
	public static void SyncNullabilityCSSpace(this DbEdmPropertyMapping propertyMapping)
	{
		bool? isNullable = propertyMapping.PropertyPath.Last().PropertyType.IsNullable;
		if (isNullable.HasValue)
		{
			propertyMapping.Column.IsNullable = isNullable.Value;
		}
	}
}
