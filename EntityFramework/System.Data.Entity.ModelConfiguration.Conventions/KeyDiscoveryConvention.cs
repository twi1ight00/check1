using System.Collections.Generic;
using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Diagnostics.CodeAnalysis;

namespace System.Data.Entity.ModelConfiguration.Conventions;

internal abstract class KeyDiscoveryConvention : IEdmConvention<EdmEntityType>, IConvention
{
	void IEdmConvention<EdmEntityType>.Apply(EdmEntityType entityType, EdmModel model)
	{
		if (entityType.DeclaredKeyProperties.Count <= 0 && entityType.BaseType == null)
		{
			EdmProperty edmProperty = MatchKeyProperty(entityType, entityType.GetDeclaredPrimitiveProperties());
			if (edmProperty != null)
			{
				edmProperty.PropertyType.IsNullable = false;
				entityType.DeclaredKeyProperties.Add(edmProperty);
			}
		}
	}

	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "edm")]
	protected abstract EdmProperty MatchKeyProperty(EdmEntityType entityType, IEnumerable<EdmProperty> primitiveProperties);
}
