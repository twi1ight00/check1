using System.Collections.Generic;
using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to configure integer primary keys to be identity.
/// </summary>
public sealed class StoreGeneratedIdentityKeyConvention : IEdmConvention<EdmEntityType>, IConvention
{
	private static readonly IEnumerable<EdmPrimitiveTypeKind> _applicableTypes = new EdmPrimitiveTypeKind[3]
	{
		EdmPrimitiveTypeKind.Int16,
		EdmPrimitiveTypeKind.Int32,
		EdmPrimitiveTypeKind.Int64
	};

	internal StoreGeneratedIdentityKeyConvention()
	{
	}

	void IEdmConvention<EdmEntityType>.Apply(EdmEntityType entityType, EdmModel model)
	{
		if (entityType.DeclaredKeyProperties.Count == 1 && !(from p in entityType.DeclaredProperties
			let sgp = p.GetStoreGeneratedPattern()
			where sgp.HasValue && sgp == DbStoreGeneratedPattern.Identity
			select sgp).Any())
		{
			EdmProperty property = entityType.DeclaredKeyProperties.Single();
			if (!property.GetStoreGeneratedPattern().HasValue && property.PropertyType.PrimitiveType != null && _applicableTypes.Contains(property.PropertyType.PrimitiveType.PrimitiveTypeKind) && model.GetAssociationTypes().Count((EdmAssociationType a) => a.Constraint != null && a.Constraint.DependentProperties.Contains(property)) == 0)
			{
				property.SetStoreGeneratedPattern(DbStoreGeneratedPattern.Identity);
			}
		}
	}
}
