using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper.Internal;

namespace AutoMapper;

/// <summary>
/// Contains cached reflection information for easy retrieval
/// </summary>
public class TypeInfo
{
	private readonly MemberInfo[] _publicGetters;

	private readonly MemberInfo[] _publicAccessors;

	private readonly MethodInfo[] _publicGetMethods;

	private readonly ConstructorInfo[] _constructors;

	private readonly MethodInfo[] _extensionMethods;

	public Type Type { get; private set; }

	public TypeInfo(Type type)
		: this(type, new MethodInfo[0])
	{
	}

	public TypeInfo(Type type, IEnumerable<MethodInfo> sourceExtensionMethodSearch)
	{
		Type = type;
		IEnumerable<MemberInfo> allPublicReadableMembers = GetAllPublicReadableMembers();
		IEnumerable<MemberInfo> allPublicWritableMembers = GetAllPublicWritableMembers();
		_publicGetters = BuildPublicReadAccessors(allPublicReadableMembers);
		_publicAccessors = BuildPublicAccessors(allPublicWritableMembers);
		_publicGetMethods = BuildPublicNoArgMethods();
		_constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		_extensionMethods = BuildPublicNoArgExtensionMethods(sourceExtensionMethodSearch);
	}

	public IEnumerable<ConstructorInfo> GetConstructors()
	{
		return _constructors;
	}

	public IEnumerable<MemberInfo> GetPublicReadAccessors()
	{
		return _publicGetters;
	}

	public IEnumerable<MemberInfo> GetPublicWriteAccessors()
	{
		return _publicAccessors;
	}

	public IEnumerable<MethodInfo> GetPublicNoArgMethods()
	{
		return _publicGetMethods;
	}

	public IEnumerable<MethodInfo> GetPublicNoArgExtensionMethods()
	{
		return _extensionMethods;
	}

	private MethodInfo[] BuildPublicNoArgExtensionMethods(IEnumerable<MethodInfo> sourceExtensionMethodSearch)
	{
		MethodInfo[] source = sourceExtensionMethodSearch.ToArray();
		List<MethodInfo> list = source.Where((MethodInfo method) => (object)method.GetParameters()[0].ParameterType == Type).ToList();
		List<Type> list2 = (from t in Type.GetInterfaces()
			where t.IsGenericType
			select t).ToList();
		if (Type.IsInterface && Type.IsGenericType)
		{
			list2.Add(Type);
		}
		foreach (MethodInfo method2 in source.Where((MethodInfo method) => method.IsGenericMethodDefinition))
		{
			Type parameterType = method2.GetParameters()[0].ParameterType;
			IEnumerable<Type> source2 = list2.Where((Type t) => t.GetGenericTypeDefinition().GetGenericArguments().Length == parameterType.GetGenericArguments().Length);
			Func<Type, bool> predicate = (Type t) => method2.MakeGenericMethod(t.GetGenericArguments()).GetParameters()[0].ParameterType.IsAssignableFrom(t);
			Type type = source2.FirstOrDefault(predicate);
			if ((object)type != null)
			{
				list.Add(method2.MakeGenericMethod(type.GetGenericArguments()));
			}
		}
		return list.ToArray();
	}

	private MemberInfo[] BuildPublicReadAccessors(IEnumerable<MemberInfo> allMembers)
	{
		IEnumerable<MemberInfo> source = (from x in allMembers.OfType<PropertyInfo>()
			group x by x.Name into x
			select x.First()).OfType<MemberInfo>().Concat(allMembers.Where((MemberInfo x) => x is FieldInfo));
		return source.ToArray();
	}

	private MemberInfo[] BuildPublicAccessors(IEnumerable<MemberInfo> allMembers)
	{
		IEnumerable<MemberInfo> source = (from x in allMembers.OfType<PropertyInfo>()
			group x by x.Name into x
			select (!x.Any((PropertyInfo y) => y.CanWrite && y.CanRead)) ? x.First() : x.First((PropertyInfo y) => y.CanWrite && y.CanRead) into pi
			where pi.CanWrite || pi.PropertyType.IsListOrDictionaryType()
			select pi).OfType<MemberInfo>().Concat(allMembers.Where((MemberInfo x) => x is FieldInfo));
		return source.ToArray();
	}

	private IEnumerable<MemberInfo> GetAllPublicReadableMembers()
	{
		return GetAllPublicMembers(PropertyReadable, BindingFlags.Instance | BindingFlags.Public);
	}

	private IEnumerable<MemberInfo> GetAllPublicWritableMembers()
	{
		return GetAllPublicMembers(PropertyWritable, BindingFlags.Instance | BindingFlags.Public);
	}

	private bool PropertyReadable(PropertyInfo propertyInfo)
	{
		return propertyInfo.CanRead;
	}

	private bool PropertyWritable(PropertyInfo propertyInfo)
	{
		bool result = (object)typeof(string) != propertyInfo.PropertyType && typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType);
		if (!propertyInfo.CanWrite)
		{
			return result;
		}
		return true;
	}

	private IEnumerable<MemberInfo> GetAllPublicMembers(Func<PropertyInfo, bool> propertyAvailableFor, BindingFlags bindingAttr)
	{
		List<Type> list = new List<Type>();
		Type type = Type;
		while ((object)type != null)
		{
			list.Add(type);
			type = type.BaseType;
		}
		if (Type.IsInterface)
		{
			list.AddRange(Type.GetInterfaces());
		}
		return list.Where((Type x) => (object)x != null).SelectMany((Type x) => from m in x.GetMembers(bindingAttr | BindingFlags.DeclaredOnly)
			where m is FieldInfo || (m is PropertyInfo && propertyAvailableFor((PropertyInfo)m) && !((PropertyInfo)m).GetIndexParameters().Any())
			select m);
	}

	private MethodInfo[] BuildPublicNoArgMethods()
	{
		return (from m in Type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
			where (object)m.ReturnType != typeof(void) && m.GetParameters().Length == 0
			select m).ToArray();
	}
}
