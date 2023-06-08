using System.Collections.Generic;
using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.ModelConfiguration.Edm.Common;
using System.Data.Entity.ModelConfiguration.Utilities;

namespace System.Data.Entity.ModelConfiguration.Edm;

internal static class EdmPropertyExtensions
{
	public static DbStoreGeneratedPattern? GetStoreGeneratedPattern(this EdmProperty property)
	{
		return (DbStoreGeneratedPattern?)property.Annotations.GetAnnotation("StoreGeneratedPattern");
	}

	public static void SetStoreGeneratedPattern(this EdmProperty property, DbStoreGeneratedPattern storeGeneratedPattern)
	{
		property.Annotations.SetAnnotation("StoreGeneratedPattern", storeGeneratedPattern);
	}

	public static object GetConfiguration(this EdmProperty property)
	{
		return property.Annotations.GetConfiguration();
	}

	public static void SetConfiguration(this EdmProperty property, object configuration)
	{
		property.Annotations.SetConfiguration(configuration);
	}

	public static EdmProperty AsPrimitive(this EdmProperty property)
	{
		property.PropertyType = new EdmTypeReference
		{
			PrimitiveTypeFacets = new EdmPrimitiveTypeFacets()
		};
		return property;
	}

	public static EdmProperty AsComplex(this EdmProperty property, EdmComplexType complexType)
	{
		property.PropertyType = new EdmTypeReference
		{
			EdmType = complexType,
			IsNullable = false
		};
		return property;
	}

	public static List<EdmPropertyPath> ToPropertyPathList(this EdmProperty property)
	{
		return property.ToPropertyPathList(new List<EdmProperty>());
	}

	public static List<EdmPropertyPath> ToPropertyPathList(this EdmProperty property, List<EdmProperty> currentPath)
	{
		List<EdmPropertyPath> list = new List<EdmPropertyPath>();
		IncludePropertyPath(list, currentPath, property);
		return list;
	}

	private static void IncludePropertyPath(List<EdmPropertyPath> propertyPaths, List<EdmProperty> currentPath, EdmProperty property)
	{
		currentPath.Add(property);
		if (property.PropertyType.IsPrimitiveType)
		{
			propertyPaths.Add(new EdmPropertyPath(currentPath));
		}
		else if (property.PropertyType.IsComplexType)
		{
			foreach (EdmProperty property2 in property.PropertyType.ComplexType.Properties)
			{
				IncludePropertyPath(propertyPaths, currentPath, property2);
			}
		}
		currentPath.Remove(property);
	}
}
