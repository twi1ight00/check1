using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Linq;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to move primary key properties to appear first.
/// </summary>
public sealed class DeclaredPropertyOrderingConvention : IEdmConvention<EdmEntityType>, IConvention
{
	private const BindingFlags DefaultBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

	internal DeclaredPropertyOrderingConvention()
	{
	}

	void IEdmConvention<EdmEntityType>.Apply(EdmEntityType entityType, EdmModel model)
	{
		entityType.GetClrType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Reverse()
			.Each(delegate(PropertyInfo p)
			{
				EdmProperty edmProperty = entityType.DeclaredProperties.Where((EdmProperty ep) => ep.Name == p.Name).SingleOrDefault();
				if (edmProperty != null)
				{
					entityType.DeclaredProperties.Remove(edmProperty);
					entityType.DeclaredProperties.Insert(0, edmProperty);
				}
			});
		entityType.DeclaredKeyProperties.Reverse().Each(delegate(EdmProperty p)
		{
			entityType.DeclaredProperties.Remove(p);
			entityType.DeclaredProperties.Insert(0, p);
		});
	}
}
