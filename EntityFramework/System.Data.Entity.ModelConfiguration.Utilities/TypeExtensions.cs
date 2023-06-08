using System.Collections.Generic;
using System.Data.Entity.Edm;
using System.Data.Metadata.Edm;
using System.Data.Objects.DataClasses;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Utilities;

internal static class TypeExtensions
{
	private static readonly Dictionary<Type, EdmPrimitiveType> _primitiveTypesMap;

	static TypeExtensions()
	{
		_primitiveTypesMap = new Dictionary<Type, EdmPrimitiveType>();
		foreach (PrimitiveType edmPrimitiveType in PrimitiveType.GetEdmPrimitiveTypes())
		{
			if (EdmPrimitiveType.TryGetByName(edmPrimitiveType.Name, out var primitiveType))
			{
				_primitiveTypesMap.Add(edmPrimitiveType.ClrEquivalentType, primitiveType);
			}
		}
	}

	public static bool IsCollection(this Type type)
	{
		return type.IsCollection(out type);
	}

	public static bool IsCollection(this Type type, out Type elementType)
	{
		elementType = type;
		Type type2 = type.GetInterfaces().Union(new Type[1] { type }).FirstOrDefault((Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ICollection<>));
		if (type2 != null)
		{
			elementType = type2.GetGenericArguments().Single();
			return true;
		}
		return false;
	}

	public static Type GetTargetType(this Type type)
	{
		if (!type.IsCollection(out var elementType))
		{
			return type;
		}
		return elementType;
	}

	public static bool TryUnwrapNullableType(this Type type, out Type underlyingType)
	{
		underlyingType = Nullable.GetUnderlyingType(type) ?? type;
		return underlyingType != type;
	}

	/// <summary>
	///     Returns true if a variable of this type can be assigned a null value
	/// </summary>
	/// <param name="type"></param>
	/// <returns>
	///     True if a reference type or a nullable value type,
	///     false otherwise
	/// </returns>
	public static bool IsNullable(this Type type)
	{
		if (type.IsValueType)
		{
			return Nullable.GetUnderlyingType(type) != null;
		}
		return true;
	}

	public static bool IsValidStructuralType(this Type type)
	{
		if (!type.IsGenericType && !type.IsValueType && !type.IsPrimitive && !type.IsInterface && !type.IsArray && !(type == typeof(string)))
		{
			return type.IsValidStructuralPropertyType();
		}
		return false;
	}

	public static bool IsValidStructuralPropertyType(this Type type)
	{
		if (!type.IsGenericTypeDefinition && !type.IsEnum && !type.IsNested && !type.IsPointer && !(type == typeof(object)) && !typeof(ComplexObject).IsAssignableFrom(type) && !typeof(EntityObject).IsAssignableFrom(type) && !typeof(StructuralObject).IsAssignableFrom(type) && !typeof(EntityKey).IsAssignableFrom(type))
		{
			return !typeof(EntityReference).IsAssignableFrom(type);
		}
		return false;
	}

	public static bool IsPrimitiveType(this Type type, out EdmPrimitiveType primitiveType)
	{
		return _primitiveTypesMap.TryGetValue(type, out primitiveType);
	}
}
