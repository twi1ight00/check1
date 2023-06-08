using System.Configuration;

namespace System.Data.Entity.Internal.ConfigFile;

/// <summary>
/// Represents a parameter to be passed to a method
/// </summary>
internal class ParameterElement : ConfigurationElement
{
	private const string _valueKey = "value";

	private const string _typeKey = "type";

	internal int Key { get; private set; }

	[ConfigurationProperty("value", IsRequired = true)]
	public string ValueString
	{
		get
		{
			return (string)base["value"];
		}
		set
		{
			base["value"] = value;
		}
	}

	[ConfigurationProperty("type", DefaultValue = "System.String")]
	public string TypeName
	{
		get
		{
			return (string)base["type"];
		}
		set
		{
			base["type"] = value;
		}
	}

	public ParameterElement(int key)
	{
		Key = key;
	}

	public object GetTypedParameterValue()
	{
		bool throwOnError = true;
		Type type = Type.GetType(TypeName, throwOnError);
		return Convert.ChangeType(ValueString, type);
	}
}
