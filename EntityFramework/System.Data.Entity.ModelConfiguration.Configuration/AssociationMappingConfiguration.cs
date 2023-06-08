using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Db.Mapping;

namespace System.Data.Entity.ModelConfiguration.Configuration;

/// <summary>
///     Base class for performing configuration of a relationship.
///     This configuration functionality is available via the Code First Fluent API, see <see cref="T:System.Data.Entity.DbModelBuilder" />.
/// </summary>
public abstract class AssociationMappingConfiguration
{
	internal abstract void Configure(DbAssociationSetMapping associationSetMapping, DbDatabaseMetadata database);

	internal abstract AssociationMappingConfiguration Clone();
}
