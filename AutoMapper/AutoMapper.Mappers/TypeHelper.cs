using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper.Internal;

namespace AutoMapper.Mappers;

public static class TypeHelper
{
	public static Type GetElementType(Type enumerableType)
	{
		return GetElementType(enumerableType, null);
	}

	public static Type GetElementType(Type enumerableType, IEnumerable enumerable)
	{
		if (enumerableType.HasElementType)
		{
			return enumerableType.GetElementType();
		}
		if (enumerableType.IsGenericType && enumerableType.GetGenericTypeDefinition().Equals(typeof(IEnumerable<>)))
		{
			return enumerableType.GetGenericArguments()[0];
		}
		Type iEnumerableType = GetIEnumerableType(enumerableType);
		if ((object)iEnumerableType != null)
		{
			return iEnumerableType.GetGenericArguments()[0];
		}
		if (typeof(IEnumerable).IsAssignableFrom(enumerableType))
		{
			if (enumerable != null)
			{
				object obj = enumerable.Cast<object>().FirstOrDefault();
				if (obj != null)
				{
					return obj.GetType();
				}
			}
			return typeof(object);
		}
		throw new ArgumentException($"Unable to find the element type for type '{enumerableType}'.", "enumerableType");
	}

	public static Type GetEnumerationType(Type enumType)
	{
		if (enumType.IsNullableType())
		{
			enumType = enumType.GetGenericArguments()[0];
		}
		if (!enumType.IsEnum)
		{
			return null;
		}
		return enumType;
	}

	private static Type GetIEnumerableType(Type enumerableType)
	{
		try
		{
			return enumerableType.GetInterfaces().FirstOrDefault((Type t) => t.Name == "IEnumerable`1");
		}
		catch (AmbiguousMatchException)
		{
			if ((object)enumerableType.BaseType != typeof(object))
			{
				return GetIEnumerableType(enumerableType.BaseType);
			}
			return null;
		}
	}
}
