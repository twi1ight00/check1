using Aspose.Words.Markup;

namespace xa8550ea6ae4a81a5;

internal class x393a4ff0932c3ba7
{
	private x393a4ff0932c3ba7()
	{
	}

	internal static void xd29409f2ba9889e2(SmartTag xdc6161a296532e34, x8f3af96aa56f1e32 xd07ce4b74c5774a7)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("w:smartTag");
		xd07ce4b74c5774a7.x943f6be3acf634db("w:uri", xdc6161a296532e34.Uri);
		xd07ce4b74c5774a7.x943f6be3acf634db("w:element", xdc6161a296532e34.Element);
		x54f1841d86cf5b35(xdc6161a296532e34.Properties, xd07ce4b74c5774a7);
	}

	private static void x54f1841d86cf5b35(CustomXmlPropertyCollection xa5ea04da0b735c3b, x8f3af96aa56f1e32 xd07ce4b74c5774a7)
	{
		if (xa5ea04da0b735c3b.Count == 0)
		{
			return;
		}
		xd07ce4b74c5774a7.x2307058321cdb62f("w:smartTagPr");
		foreach (CustomXmlProperty item in xa5ea04da0b735c3b)
		{
			xd07ce4b74c5774a7.x2307058321cdb62f("w:attr");
			xd07ce4b74c5774a7.x943f6be3acf634db("w:uri", item.Uri);
			xd07ce4b74c5774a7.x943f6be3acf634db("w:name", item.Name);
			xd07ce4b74c5774a7.x943f6be3acf634db("w:val", item.Value);
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		}
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	internal static void x685b1e5a342b26d7(SmartTag xdc6161a296532e34, x8f3af96aa56f1e32 xd07ce4b74c5774a7)
	{
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}
}
