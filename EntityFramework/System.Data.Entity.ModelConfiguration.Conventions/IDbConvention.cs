using System.Data.Entity.Edm.Db;
using System.Diagnostics.CodeAnalysis;

namespace System.Data.Entity.ModelConfiguration.Conventions;

[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
internal interface IDbConvention<TDbDataModelItem> : IConvention where TDbDataModelItem : DbDataModelItem
{
	void Apply(TDbDataModelItem dbDataModelItem, DbDatabaseMetadata database);
}
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
internal interface IDbConvention : IConvention
{
	void Apply(DbDatabaseMetadata database);
}
