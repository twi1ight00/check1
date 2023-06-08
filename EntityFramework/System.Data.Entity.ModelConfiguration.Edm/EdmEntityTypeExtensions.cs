using System.Collections.Generic;
using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Edm.Common;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Edm;

internal static class EdmEntityTypeExtensions
{
	public static EdmEntityType GetRootType(this EdmEntityType entityType)
	{
		EdmEntityType edmEntityType = entityType;
		while (edmEntityType.BaseType != null)
		{
			edmEntityType = edmEntityType.BaseType;
		}
		return edmEntityType;
	}

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static bool IsAncestorOf(this EdmEntityType ancestor, EdmEntityType entityType)
	{
		while (entityType != null)
		{
			if (entityType.BaseType == ancestor)
			{
				return true;
			}
			entityType = entityType.BaseType;
		}
		return false;
	}

	public static IEnumerable<EdmProperty> KeyProperties(this EdmEntityType entityType)
	{
		return entityType.GetRootType().DeclaredKeyProperties;
	}

	public static object GetConfiguration(this EdmEntityType entityType)
	{
		return entityType.Annotations.GetConfiguration();
	}

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static void SetConfiguration(this EdmEntityType entityType, object configuration)
	{
		entityType.Annotations.SetConfiguration(configuration);
	}

	public static Type GetClrType(this EdmEntityType entityType)
	{
		return entityType.Annotations.GetClrType();
	}

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static void SetClrType(this EdmEntityType entityType, Type type)
	{
		entityType.Annotations.SetClrType(type);
	}

	public static IEnumerable<EdmEntityType> TypeHierarchyIterator(this EdmEntityType entityType, EdmModel model)
	{
		yield return entityType;
		IEnumerable<EdmEntityType> derivedEntityTypes = model.GetDerivedTypes(entityType);
		if (derivedEntityTypes == null)
		{
			yield break;
		}
		foreach (EdmEntityType derivedEntityType in derivedEntityTypes)
		{
			foreach (EdmEntityType item in derivedEntityType.TypeHierarchyIterator(model))
			{
				yield return item;
			}
		}
	}

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static EdmProperty AddPrimitiveProperty(this EdmEntityType entityType, string name)
	{
		EdmProperty edmProperty = new EdmProperty().AsPrimitive();
		edmProperty.Name = name;
		entityType.DeclaredProperties.Add(edmProperty);
		return edmProperty;
	}

	public static EdmProperty AddComplexProperty(this EdmEntityType entityType, string name, EdmComplexType complexType)
	{
		EdmProperty edmProperty = new EdmProperty();
		edmProperty.Name = name;
		EdmProperty edmProperty2 = edmProperty.AsComplex(complexType);
		entityType.DeclaredProperties.Add(edmProperty2);
		return edmProperty2;
	}

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static EdmProperty GetDeclaredPrimitiveProperty(this EdmEntityType entityType, string name)
	{
		return entityType.GetDeclaredPrimitiveProperties().SingleOrDefault((EdmProperty p) => p.Name == name);
	}

	public static EdmProperty GetDeclaredPrimitiveProperty(this EdmEntityType entityType, PropertyInfo propertyInfo)
	{
		return entityType.GetDeclaredPrimitiveProperties().SingleOrDefault((EdmProperty p) => p.GetClrPropertyInfo().IsSameAs(propertyInfo));
	}

	public static IEnumerable<EdmProperty> GetDeclaredPrimitiveProperties(this EdmEntityType entityType)
	{
		return entityType.DeclaredProperties.Where((EdmProperty p) => p.PropertyType.IsPrimitiveType);
	}

	public static EdmNavigationProperty AddNavigationProperty(this EdmEntityType entityType, string name, EdmAssociationType associationType)
	{
		EdmNavigationProperty edmNavigationProperty = new EdmNavigationProperty();
		edmNavigationProperty.Name = name;
		edmNavigationProperty.Association = associationType;
		edmNavigationProperty.ResultEnd = associationType.TargetEnd;
		EdmNavigationProperty edmNavigationProperty2 = edmNavigationProperty;
		entityType.DeclaredNavigationProperties.Add(edmNavigationProperty2);
		return edmNavigationProperty2;
	}

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static EdmNavigationProperty GetNavigationProperty(this EdmEntityType entityType, string name)
	{
		return entityType.NavigationProperties.SingleOrDefault((EdmNavigationProperty np) => np.Name == name);
	}

	public static EdmNavigationProperty GetNavigationProperty(this EdmEntityType entityType, PropertyInfo propertyInfo)
	{
		return entityType.NavigationProperties.SingleOrDefault((EdmNavigationProperty np) => np.GetClrPropertyInfo().IsSameAs(propertyInfo));
	}

	public static bool IsRootOfSet(this EdmEntityType entityType, IEnumerable<EdmEntityType> set)
	{
		return set.All((EdmEntityType et) => et == entityType || entityType.IsAncestorOf(et) || !et.IsAncestorOf(entityType));
	}
}
