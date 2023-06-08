using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using AutoMapper.Impl;
using AutoMapper.Internal;

namespace AutoMapper;

public class TypeMapFactory : ITypeMapFactory
{
	private class NameSnippet
	{
		public string First { get; set; }

		public string Second { get; set; }
	}

	private static readonly IDictionaryFactory DictionaryFactory = PlatformAdapter.Resolve<IDictionaryFactory>();

	private static readonly AutoMapper.Internal.IDictionary<Type, TypeInfo> _typeInfos = DictionaryFactory.CreateDictionary<Type, TypeInfo>();

	public TypeMap CreateTypeMap(Type sourceType, Type destinationType, IMappingOptions options, MemberList memberList)
	{
		TypeInfo typeInfo = GetTypeInfo(sourceType, options.SourceExtensionMethods);
		TypeInfo typeInfo2 = GetTypeInfo(destinationType, new MethodInfo[0]);
		TypeMap typeMap = new TypeMap(typeInfo, typeInfo2, memberList);
		foreach (MemberInfo publicWriteAccessor in typeInfo2.GetPublicWriteAccessors())
		{
			LinkedList<MemberInfo> linkedList = new LinkedList<MemberInfo>();
			if (MapDestinationPropertyToSource(linkedList, typeInfo, publicWriteAccessor.Name, options))
			{
				IEnumerable<IMemberGetter> source = linkedList.Select((MemberInfo mi) => mi.ToMemberGetter());
				IMemberAccessor destProperty = publicWriteAccessor.ToMemberAccessor();
				typeMap.AddPropertyMap(destProperty, source.Cast<IValueResolver>());
			}
		}
		if (!destinationType.IsAbstract && destinationType.IsClass)
		{
			foreach (ConstructorInfo item in from ci in typeInfo2.GetConstructors()
				orderby ci.GetParameters().Length descending
				select ci)
			{
				if (MapDestinationCtorToSource(typeMap, item, typeInfo, options))
				{
					break;
				}
			}
		}
		return typeMap;
	}

	private bool MapDestinationCtorToSource(TypeMap typeMap, ConstructorInfo destCtor, TypeInfo sourceTypeInfo, IMappingOptions options)
	{
		List<ConstructorParameterMap> list = new List<ConstructorParameterMap>();
		ParameterInfo[] parameters = destCtor.GetParameters();
		if (parameters.Length == 0 || !options.ConstructorMappingEnabled)
		{
			return false;
		}
		ParameterInfo[] array = parameters;
		foreach (ParameterInfo parameterInfo in array)
		{
			LinkedList<MemberInfo> linkedList = new LinkedList<MemberInfo>();
			if (!MapDestinationPropertyToSource(linkedList, sourceTypeInfo, parameterInfo.Name, options))
			{
				return false;
			}
			IEnumerable<IMemberGetter> source = linkedList.Select((MemberInfo mi) => mi.ToMemberGetter());
			ConstructorParameterMap item = new ConstructorParameterMap(parameterInfo, source.ToArray());
			list.Add(item);
		}
		typeMap.AddConstructorMap(destCtor, list);
		return true;
	}

	private static TypeInfo GetTypeInfo(Type type, IEnumerable<MethodInfo> extensionMethodsToSearch)
	{
		return _typeInfos.GetOrAdd(type, (Type t) => new TypeInfo(type, extensionMethodsToSearch));
	}

	private bool MapDestinationPropertyToSource(LinkedList<MemberInfo> resolvers, TypeInfo sourceType, string nameToSearch, IMappingOptions mappingOptions)
	{
		if (string.IsNullOrEmpty(nameToSearch))
		{
			return true;
		}
		IEnumerable<MemberInfo> publicReadAccessors = sourceType.GetPublicReadAccessors();
		IEnumerable<MethodInfo> publicNoArgMethods = sourceType.GetPublicNoArgMethods();
		IEnumerable<MethodInfo> publicNoArgExtensionMethods = sourceType.GetPublicNoArgExtensionMethods();
		MemberInfo memberInfo = FindTypeMember(publicReadAccessors, publicNoArgMethods, publicNoArgExtensionMethods, nameToSearch, mappingOptions);
		bool flag = (object)memberInfo != null;
		if (flag)
		{
			resolvers.AddLast(memberInfo);
		}
		else
		{
			string[] array = (from Match m in mappingOptions.DestinationMemberNamingConvention.SplittingExpression.Matches(nameToSearch)
				select m.Value).ToArray();
			for (int i = 1; i <= array.Length; i++)
			{
				if (flag)
				{
					break;
				}
				NameSnippet nameSnippet = CreateNameSnippet(array, i, mappingOptions);
				MemberInfo memberInfo2 = FindTypeMember(publicReadAccessors, publicNoArgMethods, publicNoArgExtensionMethods, nameSnippet.First, mappingOptions);
				if ((object)memberInfo2 != null)
				{
					resolvers.AddLast(memberInfo2);
					flag = MapDestinationPropertyToSource(resolvers, GetTypeInfo(memberInfo2.GetMemberType(), mappingOptions.SourceExtensionMethods), nameSnippet.Second, mappingOptions);
					if (!flag)
					{
						resolvers.RemoveLast();
					}
				}
			}
		}
		return flag;
	}

	private static MemberInfo FindTypeMember(IEnumerable<MemberInfo> modelProperties, IEnumerable<MethodInfo> getMethods, IEnumerable<MethodInfo> getExtensionMethods, string nameToSearch, IMappingOptions mappingOptions)
	{
		MemberInfo memberInfo = modelProperties.FirstOrDefault((MemberInfo prop) => NameMatches(prop.Name, nameToSearch, mappingOptions));
		if ((object)memberInfo != null)
		{
			return memberInfo;
		}
		MethodInfo methodInfo = getMethods.FirstOrDefault((MethodInfo m) => NameMatches(m.Name, nameToSearch, mappingOptions));
		if ((object)methodInfo != null)
		{
			return methodInfo;
		}
		methodInfo = getExtensionMethods.FirstOrDefault((MethodInfo m) => NameMatches(m.Name, nameToSearch, mappingOptions));
		if ((object)methodInfo != null)
		{
			return methodInfo;
		}
		return null;
	}

	private static bool NameMatches(string memberName, string nameToMatch, IMappingOptions mappingOptions)
	{
		IEnumerable<string> source = PossibleNames(memberName, mappingOptions.Aliases, mappingOptions.Prefixes, mappingOptions.Postfixes);
		IEnumerable<string> possibleDestNames = PossibleNames(nameToMatch, mappingOptions.Aliases, mappingOptions.DestinationPrefixes, mappingOptions.DestinationPostfixes);
		var source2 = from sourceName in source
			from destName in possibleDestNames
			select new { sourceName, destName };
		return source2.Any(pair => string.Compare(pair.sourceName, pair.destName, StringComparison.OrdinalIgnoreCase) == 0);
	}

	private static IEnumerable<string> PossibleNames(string memberName, IEnumerable<AliasedMember> aliases, IEnumerable<string> prefixes, IEnumerable<string> postfixes)
	{
		if (string.IsNullOrEmpty(memberName))
		{
			yield break;
		}
		yield return memberName;
		foreach (AliasedMember alias2 in aliases.Where((AliasedMember alias) => string.Equals(memberName, alias.Member, StringComparison.Ordinal)))
		{
			yield return alias2.Alias;
		}
		foreach (string prefix2 in prefixes.Where((string prefix) => memberName.StartsWith(prefix, StringComparison.Ordinal)))
		{
			string withoutPrefix = memberName.Substring(prefix2.Length);
			yield return withoutPrefix;
			foreach (string postfix3 in postfixes.Where((string postfix) => withoutPrefix.EndsWith(postfix, StringComparison.Ordinal)))
			{
				yield return withoutPrefix.Remove(withoutPrefix.Length - postfix3.Length);
			}
		}
		foreach (string postfix2 in postfixes.Where((string postfix) => memberName.EndsWith(postfix, StringComparison.Ordinal)))
		{
			yield return memberName.Remove(memberName.Length - postfix2.Length);
		}
	}

	private NameSnippet CreateNameSnippet(IEnumerable<string> matches, int i, IMappingOptions mappingOptions)
	{
		NameSnippet nameSnippet = new NameSnippet();
		nameSnippet.First = string.Join(mappingOptions.SourceMemberNamingConvention.SeparatorCharacter, matches.Take(i).ToArray());
		nameSnippet.Second = string.Join(mappingOptions.SourceMemberNamingConvention.SeparatorCharacter, matches.Skip(i).ToArray());
		return nameSnippet;
	}
}
