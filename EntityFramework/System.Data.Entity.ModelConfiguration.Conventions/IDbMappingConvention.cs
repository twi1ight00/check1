using System.Data.Entity.Edm.Db.Mapping;
using System.Diagnostics.CodeAnalysis;

namespace System.Data.Entity.ModelConfiguration.Conventions;

[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
internal interface IDbMappingConvention : IConvention
{
	void Apply(DbDatabaseMapping databaseMapping);
}
