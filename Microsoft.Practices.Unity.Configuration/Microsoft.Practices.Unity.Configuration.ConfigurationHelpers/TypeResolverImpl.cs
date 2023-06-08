using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using Microsoft.Practices.Unity.Configuration.Properties;

namespace Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

/// <summary>
/// A helper class that implements the actual logic for resolving a shorthand
/// type name (alias or raw type name) into an actual type object.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Impl")]
public class TypeResolverImpl
{
	private readonly Dictionary<string, string> aliases;

	private readonly List<string> namespaces;

	private readonly List<string> assemblies;

	private static readonly Dictionary<string, Type> defaultAliases = new Dictionary<string, Type>
	{
		{
			"sbyte",
			typeof(sbyte)
		},
		{
			"short",
			typeof(short)
		},
		{
			"int",
			typeof(int)
		},
		{
			"integer",
			typeof(int)
		},
		{
			"long",
			typeof(long)
		},
		{
			"byte",
			typeof(byte)
		},
		{
			"ushort",
			typeof(ushort)
		},
		{
			"uint",
			typeof(uint)
		},
		{
			"ulong",
			typeof(ulong)
		},
		{
			"float",
			typeof(float)
		},
		{
			"single",
			typeof(float)
		},
		{
			"double",
			typeof(double)
		},
		{
			"decimal",
			typeof(decimal)
		},
		{
			"char",
			typeof(char)
		},
		{
			"bool",
			typeof(bool)
		},
		{
			"object",
			typeof(object)
		},
		{
			"string",
			typeof(string)
		},
		{
			"datetime",
			typeof(DateTime)
		},
		{
			"DateTime",
			typeof(DateTime)
		},
		{
			"date",
			typeof(DateTime)
		},
		{
			"singleton",
			typeof(ContainerControlledLifetimeManager)
		},
		{
			"ContainerControlledLifetimeManager",
			typeof(ContainerControlledLifetimeManager)
		},
		{
			"transient",
			typeof(TransientLifetimeManager)
		},
		{
			"TransientLifetimeManager",
			typeof(TransientLifetimeManager)
		},
		{
			"perthread",
			typeof(PerThreadLifetimeManager)
		},
		{
			"PerThreadLifetimeManager",
			typeof(PerThreadLifetimeManager)
		},
		{
			"external",
			typeof(ExternallyControlledLifetimeManager)
		},
		{
			"ExternallyControlledLifetimeManager",
			typeof(ExternallyControlledLifetimeManager)
		},
		{
			"hierarchical",
			typeof(HierarchicalLifetimeManager)
		},
		{
			"HierarchicalLifetimeManager",
			typeof(HierarchicalLifetimeManager)
		},
		{
			"resolve",
			typeof(PerResolveLifetimeManager)
		},
		{
			"perresolve",
			typeof(PerResolveLifetimeManager)
		},
		{
			"PerResolveLifetimeManager",
			typeof(PerResolveLifetimeManager)
		}
	};

	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.Unity.Configuration.ConfigurationHelpers.TypeResolverImpl" /> that uses the given
	/// sequence of alias, typename pairs to resolve types.
	/// </summary>
	/// <param name="aliasesSequence">Type aliases from the configuration file.</param>
	/// <param name="assemblies">Assembly names to search.</param>
	/// <param name="namespaces">Namespaces to search.</param>
	[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
	public TypeResolverImpl(IEnumerable<KeyValuePair<string, string>> aliasesSequence, IEnumerable<string> namespaces, IEnumerable<string> assemblies)
	{
		aliases = new Dictionary<string, string>();
		foreach (KeyValuePair<string, string> item in aliasesSequence)
		{
			aliases.Add(item.Key, item.Value);
		}
		this.namespaces = new List<string>(namespaces);
		this.assemblies = new List<string>(assemblies);
		this.assemblies.Add(typeof(object).Assembly.FullName);
		this.assemblies.Add(typeof(Uri).Assembly.FullName);
	}

	/// <summary>
	/// Resolves a type alias or type fullname to a concrete type.
	/// </summary>
	/// <param name="typeNameOrAlias">Alias or name to resolve.</param>
	/// <param name="throwIfResolveFails">if true and the alias does not
	/// resolve, throw an <see cref="T:System.InvalidOperationException" />, otherwise 
	/// return null on failure.</param>
	/// <returns>The type object or null if resolve fails and 
	/// <paramref name="throwIfResolveFails" /> is false.</returns>
	public Type ResolveType(string typeNameOrAlias, bool throwIfResolveFails)
	{
		Type type = ResolveTypeInternal(typeNameOrAlias) ?? ResolveGenericTypeShorthand(typeNameOrAlias);
		if (type == null && throwIfResolveFails)
		{
			throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.CouldNotResolveType, typeNameOrAlias));
		}
		return type;
	}

	private Type ResolveTypeInternal(string typeNameOrAlias)
	{
		return ResolveTypeDirectly(typeNameOrAlias) ?? ResolveAlias(typeNameOrAlias) ?? ResolveDefaultAlias(typeNameOrAlias) ?? ResolveTypeThroughSearch(typeNameOrAlias);
	}

	/// <summary>
	/// Resolve a type alias or type full name to a concrete type.
	/// If <paramref name="typeNameOrAlias" /> is null or empty, return the
	/// given <paramref name="defaultValue" /> instead.
	/// </summary>
	/// <param name="typeNameOrAlias">Type alias or full name to resolve.</param>
	/// <param name="defaultValue">Value to return if typeName is null or empty.</param>
	/// <param name="throwIfResolveFails">if true and the alias does not
	/// resolve, throw an <see cref="T:System.InvalidOperationException" />, otherwise 
	/// return null on failure.</param>
	/// <returns>
	/// <para>If <paramref name="typeNameOrAlias" /> is null or an empty string,
	/// then return <paramref name="defaultValue" />.</para>
	/// <para>Otherwise, return the resolved type object. If the resolution fails
	/// and <paramref name="throwIfResolveFails" /> is false, then return null.</para>
	/// </returns>
	public Type ResolveTypeWithDefault(string typeNameOrAlias, Type defaultValue, bool throwIfResolveFails)
	{
		if (string.IsNullOrEmpty(typeNameOrAlias))
		{
			return defaultValue;
		}
		return ResolveType(typeNameOrAlias, throwIfResolveFails);
	}

	private static Type ResolveTypeDirectly(string typeNameOrAlias)
	{
		return Type.GetType(typeNameOrAlias);
	}

	private Type ResolveAlias(string typeNameOrAlias)
	{
		string text = aliases.GetOrNull(typeNameOrAlias) ?? aliases.GetOrNull(RemoveGenericWart(typeNameOrAlias));
		if (text != null)
		{
			return Type.GetType(text);
		}
		return null;
	}

	private static Type ResolveDefaultAlias(string typeNameOrAlias)
	{
		if (defaultAliases.TryGetValue(typeNameOrAlias, out var value) || defaultAliases.TryGetValue(RemoveGenericWart(typeNameOrAlias), out value))
		{
			return value;
		}
		return null;
	}

	private static string RemoveGenericWart(string typeNameOrAlias)
	{
		string result = typeNameOrAlias;
		int num = typeNameOrAlias.IndexOf('`');
		if (num != -1)
		{
			result = typeNameOrAlias.Substring(0, num);
		}
		return result;
	}

	private Type ResolveTypeThroughSearch(string typeNameOrAlias)
	{
		if (namespaces.Count == 0)
		{
			return SearchAssemblies(typeNameOrAlias);
		}
		return SearchAssembliesAndNamespaces(typeNameOrAlias);
	}

	private Type ResolveGenericTypeShorthand(string typeNameOrAlias)
	{
		Type type = null;
		TypeNameInfo typeNameInfo = TypeNameParser.Parse(typeNameOrAlias);
		if (typeNameInfo != null && typeNameInfo.IsGenericType)
		{
			type = ResolveTypeInternal(typeNameInfo.FullName);
			if (type == null)
			{
				return null;
			}
			List<Type> list = new List<Type>(typeNameInfo.NumGenericParameters);
			if (typeNameInfo.GenericParameters[0] != null)
			{
				foreach (TypeNameInfo genericParameter in typeNameInfo.GenericParameters)
				{
					Type type2 = ResolveType(genericParameter.FullName, throwIfResolveFails: false);
					if (type2 == null)
					{
						return null;
					}
					list.Add(type2);
				}
				if (list.Count > 0)
				{
					type = type.MakeGenericType(list.ToArray());
				}
			}
		}
		return type;
	}

	private Type SearchAssembliesAndNamespaces(string typeNameOrAlias)
	{
		foreach (string assembly in assemblies)
		{
			foreach (string @namespace in namespaces)
			{
				try
				{
					Type type = Type.GetType(MakeTypeName(@namespace, typeNameOrAlias, assembly));
					if (type != null)
					{
						return type;
					}
				}
				catch (FileLoadException)
				{
				}
			}
		}
		return null;
	}

	private Type SearchAssemblies(string typeNameOrAlias)
	{
		foreach (string assembly in assemblies)
		{
			try
			{
				Type type = Type.GetType(MakeAssemblyQualifiedName(typeNameOrAlias, assembly));
				if (type != null)
				{
					return type;
				}
			}
			catch (FileLoadException)
			{
			}
		}
		return null;
	}

	private static string MakeTypeName(string ns, string typename, string assembly)
	{
		return MakeAssemblyQualifiedName(ns + "." + typename, assembly);
	}

	private static string MakeAssemblyQualifiedName(string typename, string assembly)
	{
		return typename + ", " + assembly;
	}
}
