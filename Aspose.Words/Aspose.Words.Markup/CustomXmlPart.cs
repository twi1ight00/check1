using x6c95d9cf46ff5f25;

namespace Aspose.Words.Markup;

public class CustomXmlPart
{
	private string x60adf410a9cceab0 = "";

	private CustomXmlSchemaCollection x2e4987eee1ba0330 = new CustomXmlSchemaCollection();

	private byte[] x73f065a6b420cfe1 = xcd4bd3abd72ff2da.x2b0797e1bb4e840a;

	public string Id
	{
		get
		{
			return x60adf410a9cceab0;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "id");
			x60adf410a9cceab0 = value;
		}
	}

	public CustomXmlSchemaCollection Schemas => x2e4987eee1ba0330;

	public byte[] Data
	{
		get
		{
			return x73f065a6b420cfe1;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "data");
			x73f065a6b420cfe1 = value;
		}
	}

	public CustomXmlPart Clone()
	{
		CustomXmlPart customXmlPart = (CustomXmlPart)MemberwiseClone();
		customXmlPart.x2e4987eee1ba0330 = x2e4987eee1ba0330.Clone();
		return customXmlPart;
	}
}
