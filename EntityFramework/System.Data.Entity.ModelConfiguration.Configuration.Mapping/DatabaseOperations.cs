using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.ModelConfiguration.Edm.Db;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Globalization;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Configuration.Mapping;

internal class DatabaseOperations
{
	public static void AddTypeConstraint(EdmEntityType entityType, DbTableMetadata principalTable, DbTableMetadata dependentTable, bool isSplitting)
	{
		DbForeignKeyConstraintMetadata foreignKeyConstraintMetadata = new DbForeignKeyConstraintMetadata
		{
			Name = string.Format(CultureInfo.InvariantCulture, "{0}_TypeConstraint_From_{1}_To_{2}", new object[3] { entityType.Name, principalTable.Name, dependentTable.Name }),
			PrincipalTable = principalTable
		};
		if (isSplitting)
		{
			foreignKeyConstraintMetadata.SetIsSplitConstraint();
		}
		else
		{
			foreignKeyConstraintMetadata.SetIsTypeConstraint();
		}
		dependentTable.Columns.Where((DbTableColumnMetadata c) => c.IsPrimaryKeyColumn).Each(delegate(DbTableColumnMetadata c)
		{
			foreignKeyConstraintMetadata.DependentColumns.Add(c);
		});
		dependentTable.ForeignKeyConstraints.Add(foreignKeyConstraintMetadata);
	}
}
