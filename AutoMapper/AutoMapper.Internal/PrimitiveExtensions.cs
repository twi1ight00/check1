using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AutoMapper.Internal;

public static class PrimitiveExtensions
{
	public static string ToNullSafeString(this object value)
	{
		return value?.ToString();
	}

	public static bool IsNullableType(this Type type)
	{
		if (type.IsGenericType)
		{
			return type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
		}
		return false;
	}

	public static Type GetTypeOfNullable(this Type type)
	{
		return type.GetGenericArguments()[0];
	}

	public static bool IsCollectionType(this Type type)
	{
		if (type.IsGenericType && (object)type.GetGenericTypeDefinition() == typeof(ICollection<>))
		{
			return true;
		}
		IEnumerable<Type> source = from t in type.GetInterfaces()
			where t.IsGenericType
			select t;
		IEnumerable<Type> source2 = source.Select((Type t) => t.GetGenericTypeDefinition());
		return source2.Any((Type t) => (object)t == typeof(ICollection<>));
	}

	public static bool IsEnumerableType(this Type type)
	{
		return type.GetInterfaces().Contains(typeof(IEnumerable));
	}

	public static bool IsListType(this Type type)
	{
		return type.GetInterfaces().Contains(typeof(IList));
	}

	public static bool IsListOrDictionaryType(this Type type)
	{
		if (!type.IsListType())
		{
			return type.IsDictionaryType();
		}
		return true;
	}

	public static bool IsDictionaryType(this Type type)
	{
		if (type.IsGenericType && (object)type.GetGenericTypeDefinition() == typeof(System.Collections.Generic.IDictionary<, >))
		{
			return true;
		}
		IEnumerable<Type> source = from t in type.GetInterfaces()
			where t.IsGenericType
			select t;
		IEnumerable<Type> source2 = source.Select((Type t) => t.GetGenericTypeDefinition());
		return source2.Any((Type t) => (object)t == typeof(System.Collections.Generic.IDictionary<, >));
	}

	public static Type GetDictionaryType(this Type type)
	{
		if (type.IsGenericType && (object)type.GetGenericTypeDefinition() == typeof(System.Collections.Generic.IDictionary<, >))
		{
			return type;
		}
		IEnumerable<Type> source = from t in type.GetInterfaces()
			where t.IsGenericType && (object)t.GetGenericTypeDefinition() == typeof(System.Collections.Generic.IDictionary<, >)
			select t;
		return source.FirstOrDefault();
	}
}
