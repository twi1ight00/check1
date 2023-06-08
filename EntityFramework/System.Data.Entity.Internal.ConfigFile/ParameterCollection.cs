using System.Configuration;
using System.Linq;

namespace System.Data.Entity.Internal.ConfigFile;

/// <summary>
/// Represents a series of parameters to pass to a method
/// </summary>
internal class ParameterCollection : ConfigurationElementCollection
{
	private const string _parameterKey = "parameter";

	private int _nextKey;

	public override ConfigurationElementCollectionType CollectionType => ConfigurationElementCollectionType.BasicMap;

	protected override string ElementName => "parameter";

	protected override ConfigurationElement CreateNewElement()
	{
		ParameterElement result = new ParameterElement(_nextKey);
		_nextKey++;
		return result;
	}

	protected override object GetElementKey(ConfigurationElement element)
	{
		return ((ParameterElement)element).Key;
	}

	public object[] GetTypedParameterValues()
	{
		return (from ParameterElement e in this
			select e.GetTypedParameterValue()).ToArray();
	}

	/// <summary>
	/// Adds a new parameter to the collection
	/// Used for unit testing
	/// </summary>
	internal ParameterElement NewElement()
	{
		ConfigurationElement configurationElement = CreateNewElement();
		base.BaseAdd(configurationElement);
		return (ParameterElement)configurationElement;
	}
}
