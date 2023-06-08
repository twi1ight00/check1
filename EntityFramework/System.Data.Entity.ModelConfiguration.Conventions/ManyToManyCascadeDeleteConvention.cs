using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to add a cascade delete to the join table from both tables involved in a many to many relationship.
/// </summary>
public sealed class ManyToManyCascadeDeleteConvention : IDbMappingConvention, IConvention
{
	internal ManyToManyCascadeDeleteConvention()
	{
	}

	void IDbMappingConvention.Apply(DbDatabaseMapping databaseMapping)
	{
		(from asm in databaseMapping.EntityContainerMappings.SelectMany((DbEntityContainerMapping ecm) => ecm.AssociationSetMappings)
			where asm.AssociationSet.ElementType.IsManyToMany() && !asm.AssociationSet.ElementType.IsSelfReferencing()
			select asm).SelectMany((DbAssociationSetMapping asm) => asm.Table.ForeignKeyConstraints).Each((DbForeignKeyConstraintMetadata fk) => fk.DeleteAction = DbOperationAction.Cascade);
	}
}
