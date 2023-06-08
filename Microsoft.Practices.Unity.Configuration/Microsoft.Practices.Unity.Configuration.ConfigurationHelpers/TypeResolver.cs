using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

/// <summary>
/// Type that manage access to a set of type aliases and implements
/// the logic for converting aliases to their actual types.
/// </summary>
public static class TypeResolver
{
	[ThreadStatic]
	private static TypeResolverImpl impl;

	/// <summary>
	/// Set the set of aliases to use for resolution.
	/// </summary>
	/// <param name="section">Configuration section containing the various
	/// type aliases, namespaces and assemblies.</param>
	public static void SetAliases(UnityConfigurationSection section)
	{
		impl = new TypeResolverImpl(section.TypeAliases.Select((AliasElement e) => new KeyValuePair<string, string>(e.Alias, e.TypeName)), section.Namespaces.Select((NamespaceElement e) => e.Name), section.Assemblies.Select((AssemblyElement e) => e.Name));
	}

	/// <summary>
	/// Resolves a type alias or type fullname to a concrete type.
	/// </summary>
	/// <param name="typeNameOrAlias">Type alias or type fullname</param>
	/// <returns>Type object or null if resolve fails.</returns>
	/// <exception cref="T:System.InvalidOperationException">Thrown if alias lookup fails.</exception>
	public static Type ResolveType(string typeNameOrAlias)
	{
		return impl.ResolveType(typeNameOrAlias, throwIfResolveFails: true);
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
	public static Type ResolveType(string typeNameOrAlias, bool throwIfResolveFails)
	{
		return impl.ResolveType(typeNameOrAlias, throwIfResolveFails);
	}

	/// <summary>
	/// Resolve a type alias or type full name to a concrete type.
	/// If <paramref name="typeNameOrAlias" /> is null or empty, return the
	/// given <paramref name="defaultValue" /> instead.
	/// </summary>
	/// <param name="typeNameOrAlias">Type alias or full name to resolve.</param>
	/// <param name="defaultValue">Value to return if typeName is null or empty.</param>
	/// <returns>The concrete <see cref="T:System.Type" />.</returns>
	/// <exception cref="T:System.InvalidOperationException">Thrown if alias lookup fails.</exception>
	public static Type ResolveTypeWithDefault(string typeNameOrAlias, Type defaultValue)
	{
		return impl.ResolveTypeWithDefault(typeNameOrAlias, defaultValue, throwIfResolveFails: true);
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
	/// <returns>The concrete <see cref="T:System.Type" />.</returns>
	/// <exception cref="T:System.InvalidOperationException">Thrown if alias lookup fails and
	/// <paramref name="throwIfResolveFails" /> is true.</exception>
	public static Type ResolveTypeWithDefault(string typeNameOrAlias, Type defaultValue, bool throwIfResolveFails)
	{
		return impl.ResolveTypeWithDefault(typeNameOrAlias, defaultValue, throwIfResolveFails);
	}
}
