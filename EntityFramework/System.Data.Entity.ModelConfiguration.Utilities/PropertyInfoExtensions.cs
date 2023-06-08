using System.Collections.Generic;
using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Linq;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Utilities;

internal static class PropertyInfoExtensions
{
	public static bool IsSameAs(this PropertyInfo propertyInfo, PropertyInfo otherPropertyInfo)
	{
		if (!(propertyInfo == otherPropertyInfo))
		{
			if (propertyInfo.Name == otherPropertyInfo.Name)
			{
				return propertyInfo.DeclaringType == otherPropertyInfo.DeclaringType;
			}
			return false;
		}
		return true;
	}

	public static bool ContainsSame(this IEnumerable<PropertyInfo> enumerable, PropertyInfo propertyInfo)
	{
		return enumerable.Any((PropertyInfo member) => propertyInfo.IsSameAs(member));
	}

	public static bool IsValidStructuralProperty(this PropertyInfo propertyInfo)
	{
		if (propertyInfo.CanRead && (propertyInfo.CanWrite || propertyInfo.PropertyType.IsCollection()) && !propertyInfo.GetGetMethod(nonPublic: true).IsAbstract)
		{
			return propertyInfo.PropertyType.IsValidStructuralPropertyType();
		}
		return false;
	}

	public static bool IsValidEdmPrimitiveProperty(this PropertyInfo propertyInfo)
	{
		Type underlyingType = propertyInfo.PropertyType;
		underlyingType.TryUnwrapNullableType(out underlyingType);
		EdmPrimitiveType primitiveType;
		return underlyingType.IsPrimitiveType(out primitiveType);
	}

	public static EdmProperty AsEdmPrimitiveProperty(this PropertyInfo propertyInfo)
	{
		Type underlyingType = propertyInfo.PropertyType;
		bool value = underlyingType.TryUnwrapNullableType(out underlyingType) || !underlyingType.IsValueType;
		if (underlyingType.IsPrimitiveType(out var primitiveType))
		{
			EdmProperty edmProperty = new EdmProperty();
			edmProperty.Name = propertyInfo.Name;
			EdmProperty edmProperty2 = edmProperty.AsPrimitive();
			edmProperty2.PropertyType.EdmType = primitiveType;
			edmProperty2.PropertyType.IsNullable = value;
			return edmProperty2;
		}
		return null;
	}
}
