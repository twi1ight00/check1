using System;
using System.Collections;
using System.Collections.Generic;
using AutoMapper.Internal;

namespace AutoMapper.Mappers;

/// <summary>
/// Instantiates objects
/// </summary>
public static class ObjectCreator
{
	private static readonly IDelegateFactory DelegateFactory = PlatformAdapter.Resolve<IDelegateFactory>();

	public static Array CreateArray(Type elementType, int length)
	{
		return Array.CreateInstance(elementType, length);
	}

	public static IList CreateList(Type elementType)
	{
		Type type = typeof(List<>).MakeGenericType(elementType);
		return (IList)CreateObject(type);
	}

	public static object CreateDictionary(Type dictionaryType, Type keyType, Type valueType)
	{
		Type type = (dictionaryType.IsInterface ? typeof(Dictionary<, >).MakeGenericType(keyType, valueType) : dictionaryType);
		return CreateObject(type);
	}

	public static object CreateDefaultValue(Type type)
	{
		if (!type.IsValueType)
		{
			return null;
		}
		return CreateObject(type);
	}

	public static object CreateNonNullValue(Type type)
	{
		if (type.IsValueType)
		{
			return CreateObject(type);
		}
		if ((object)type == typeof(string))
		{
			return string.Empty;
		}
		return Activator.CreateInstance(type);
	}

	public static object CreateObject(Type type)
	{
		if (!type.IsArray)
		{
			return DelegateFactory.CreateCtor(type)();
		}
		return CreateArray(type.GetElementType(), 0);
	}
}
