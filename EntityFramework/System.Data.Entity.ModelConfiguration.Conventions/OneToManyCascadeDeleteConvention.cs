using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Edm;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to enable cascade delete for any required relationships.
/// </summary>
public sealed class OneToManyCascadeDeleteConvention : IEdmConvention<EdmAssociationType>, IConvention
{
	internal OneToManyCascadeDeleteConvention()
	{
	}

	void IEdmConvention<EdmAssociationType>.Apply(EdmAssociationType associationType, EdmModel model)
	{
		if (!associationType.IsSelfReferencing() && !associationType.HasDeleteAction())
		{
			EdmAssociationEnd edmAssociationEnd = null;
			if (associationType.IsRequiredToMany())
			{
				edmAssociationEnd = associationType.SourceEnd;
			}
			else if (associationType.IsManyToRequired())
			{
				edmAssociationEnd = associationType.TargetEnd;
			}
			if (edmAssociationEnd != null)
			{
				edmAssociationEnd.DeleteAction = EdmOperationAction.Cascade;
			}
		}
	}
}
