using x6c95d9cf46ff5f25;

namespace Aspose.Words.Markup;

public class CustomXmlProperty
{
	private readonly string xc61ff88f1f98652d = "";

	private string x85672ef2a158d360 = "";

	private string x4574aea041dd835f = "";

	public string Name => xc61ff88f1f98652d;

	public string Uri
	{
		get
		{
			return x85672ef2a158d360;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "uri");
			x85672ef2a158d360 = value;
		}
	}

	public string Value
	{
		get
		{
			return x4574aea041dd835f;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x4574aea041dd835f = value;
		}
	}

	public CustomXmlProperty(string name, string uri, string value)
	{
		x0d299f323d241756.x0aaaea7864a53f26(name, "name");
		xc61ff88f1f98652d = name;
		Uri = uri;
		Value = value;
	}

	internal CustomXmlProperty x8b61531c8ea35b85()
	{
		return (CustomXmlProperty)MemberwiseClone();
	}
}
