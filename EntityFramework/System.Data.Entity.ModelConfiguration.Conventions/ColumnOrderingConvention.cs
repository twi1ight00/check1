using System.Collections.Generic;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.ModelConfiguration.Edm.Db;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to apply column ordering specified via <see cref="T:System.ComponentModel.DataAnnotations.ColumnAttribute" /> or the <see cref="T:System.Data.Entity.DbModelBuilder" /> API.
/// </summary>
internal sealed class ColumnOrderingConvention : IDbConvention<DbTableMetadata>, IConvention
{
	void IDbConvention<DbTableMetadata>.Apply(DbTableMetadata table, DbDatabaseMetadata database)
	{
		table.Columns = OrderColumns(table.Columns);
		table.ForeignKeyConstraints.Each((DbForeignKeyConstraintMetadata fk) => fk.DependentColumns = OrderColumns(fk.DependentColumns));
	}

	private IList<DbTableColumnMetadata> OrderColumns(IList<DbTableColumnMetadata> columns)
	{
		var source = columns.Select((DbTableColumnMetadata c) => new
		{
			Column = c,
			Order = (c.GetOrder() ?? int.MaxValue)
		});
		return (from c in source
			orderby c.Order
			select c.Column).ToList();
	}
}
