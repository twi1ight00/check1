using System.Configuration;
using System.Data.Entity.Resources;

namespace System.Data.Entity.Internal.ConfigFile;

/// <summary>
/// Represents the configuration for a series of contexts
/// </summary>
internal class ContextCollection : ConfigurationElementCollection
{
	private const string _contextKey = "context";

	public override ConfigurationElementCollectionType CollectionType => ConfigurationElementCollectionType.BasicMap;

	protected override string ElementName => "context";

	protected override ConfigurationElement CreateNewElement()
	{
		return new ContextElement();
	}

	protected override object GetElementKey(ConfigurationElement element)
	{
		return ((ContextElement)element).ContextTypeName;
	}

	protected override void BaseAdd(ConfigurationElement element)
	{
		object elementKey = GetElementKey(element);
		if (BaseGet(elementKey) != null)
		{
			throw Error.ContextConfiguredMultipleTimes(elementKey);
		}
		base.BaseAdd(element);
	}

	protected override void BaseAdd(int index, ConfigurationElement element)
	{
		object elementKey = GetElementKey(element);
		if (BaseGet(elementKey) != null)
		{
			throw Error.ContextConfiguredMultipleTimes(elementKey);
		}
		base.BaseAdd(index, element);
	}

	/// <summary>
	/// Adds a new context to the collection
	/// Used for unit testing
	/// </summary>
	internal ContextElement NewElement(string contextTypeName)
	{
		ContextElement contextElement = (ContextElement)CreateNewElement();
		base.BaseAdd(contextElement);
		contextElement.ContextTypeName = contextTypeName;
		return contextElement;
	}
}
