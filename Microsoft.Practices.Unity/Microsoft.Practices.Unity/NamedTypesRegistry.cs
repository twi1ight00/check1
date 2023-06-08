using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Practices.Unity;

internal class NamedTypesRegistry
{
	private readonly Dictionary<Type, List<string>> registeredKeys;

	private readonly NamedTypesRegistry parent;

	public IEnumerable<Type> RegisteredTypes => registeredKeys.Keys;

	public NamedTypesRegistry()
		: this(null)
	{
	}

	public NamedTypesRegistry(NamedTypesRegistry parent)
	{
		this.parent = parent;
		registeredKeys = new Dictionary<Type, List<string>>();
	}

	public void RegisterType(Type t, string name)
	{
		if (!registeredKeys.ContainsKey(t))
		{
			registeredKeys[t] = new List<string>();
		}
		RemoveMatchingKeys(t, name);
		registeredKeys[t].Add(name);
	}

	public IEnumerable<string> GetKeys(Type t)
	{
		IEnumerable<string> enumerable = Enumerable.Empty<string>();
		if (parent != null)
		{
			enumerable = enumerable.Concat(parent.GetKeys(t));
		}
		if (registeredKeys.ContainsKey(t))
		{
			enumerable = enumerable.Concat(registeredKeys[t]);
		}
		return enumerable;
	}

	public void Clear()
	{
		registeredKeys.Clear();
	}

	private void RemoveMatchingKeys(Type t, string name)
	{
		IEnumerable<string> source = registeredKeys[t].Where((string registeredName) => registeredName != name);
		registeredKeys[t] = source.ToList();
	}
}
