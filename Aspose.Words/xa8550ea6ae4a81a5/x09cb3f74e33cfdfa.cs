using Aspose.Words.Markup;
using x6c95d9cf46ff5f25;

namespace xa8550ea6ae4a81a5;

internal class x09cb3f74e33cfdfa
{
	private x09cb3f74e33cfdfa()
	{
	}

	internal static void xd29409f2ba9889e2(CustomXmlMarkup xd1822434fe24a007, x8f3af96aa56f1e32 xd07ce4b74c5774a7)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("w:customXml");
		xd07ce4b74c5774a7.x943f6be3acf634db("w:uri", xd1822434fe24a007.Uri);
		xd07ce4b74c5774a7.x943f6be3acf634db("w:element", xd1822434fe24a007.Element);
		x54f1841d86cf5b35(xd1822434fe24a007, xd07ce4b74c5774a7);
	}

	private static void x54f1841d86cf5b35(CustomXmlMarkup xd1822434fe24a007, x8f3af96aa56f1e32 xd07ce4b74c5774a7)
	{
		if (xd1822434fe24a007.Properties.Count == 0 && !x0d299f323d241756.x5959bccb67bbf051(xd1822434fe24a007.Placeholder))
		{
			return;
		}
		xd07ce4b74c5774a7.x2307058321cdb62f("w:customXmlPr");
		xd07ce4b74c5774a7.x547195bcc386fe66("w:placeholder", xd1822434fe24a007.Placeholder);
		CustomXmlPropertyCollection properties = xd1822434fe24a007.Properties;
		foreach (CustomXmlProperty item in properties)
		{
			xd07ce4b74c5774a7.x2307058321cdb62f("w:attr");
			xd07ce4b74c5774a7.x943f6be3acf634db("w:uri", item.Uri);
			xd07ce4b74c5774a7.x943f6be3acf634db("w:name", item.Name);
			xd07ce4b74c5774a7.xff520a0047c27122("w:val", item.Value);
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		}
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	internal static void x685b1e5a342b26d7(x8f3af96aa56f1e32 xd07ce4b74c5774a7)
	{
		xd07ce4b74c5774a7.x2dfde153f4ef96d0("w:customXml");
	}
}
