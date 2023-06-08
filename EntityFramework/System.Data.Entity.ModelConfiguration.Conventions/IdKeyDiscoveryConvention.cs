using System.Collections.Generic;
using System.Data.Entity.Edm;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to detect primary key properties. 
///     Recognized naming patterns in order of precedence are:
///     1. 'Id'
///     2. [type name]Id
///     Primary key detection is case insensitive.
/// </summary>
public sealed class IdKeyDiscoveryConvention : IEdmConvention<EdmEntityType>, IConvention
{
	private sealed class IdKeyDiscoveryConventionImpl : KeyDiscoveryConvention
	{
		private const string Id = "Id";

		protected override EdmProperty MatchKeyProperty(EdmEntityType entityType, IEnumerable<EdmProperty> primitiveProperties)
		{
			return primitiveProperties.SingleOrDefault((EdmProperty p) => "Id".Equals(p.Name, StringComparison.OrdinalIgnoreCase)) ?? primitiveProperties.SingleOrDefault((EdmProperty p) => (entityType.Name + "Id").Equals(p.Name, StringComparison.OrdinalIgnoreCase));
		}
	}

	private readonly IEdmConvention<EdmEntityType> _impl = new IdKeyDiscoveryConventionImpl();

	internal IdKeyDiscoveryConvention()
	{
	}

	void IEdmConvention<EdmEntityType>.Apply(EdmEntityType entityType, EdmModel model)
	{
		_impl.Apply(entityType, model);
	}
}
