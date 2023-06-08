using Aspose.Words;
using Aspose.Words.Markup;
using x1495530f35d79681;
using x6c95d9cf46ff5f25;

namespace x79490184cecf12a1;

internal class x59dc375fefb756b0
{
	private x59dc375fefb756b0()
	{
	}

	internal static void x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		SmartTag smartTag = new SmartTag(xe134235b3526fa75.x2c8c6741422a1298);
		xe134235b3526fa75.x490834a62c46f14d(smartTag);
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "element":
				smartTag.Element = x3bcd232d01c.xd2f68ee6f47e9dfb;
				break;
			case "uri":
				smartTag.Uri = x3bcd232d01c.xd2f68ee6f47e9dfb;
				break;
			}
		}
		x3bcd232d01c.x99f8cdb2827fa686();
		while (x3bcd232d01c.x152cbadbfa8061b1("smartTag"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "smartTagPr")
			{
				x25d64ec28cc14a2a(x3bcd232d01c, smartTag);
			}
			else
			{
				x5ab4843b5e9c9f8d.x152cbadbfa8061b1(xe134235b3526fa75);
			}
		}
		xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.SmartTag);
	}

	private static void x25d64ec28cc14a2a(xc1dcd6189d01216e xd19f1b93a822ffb3, SmartTag xdc6161a296532e34)
	{
		while (xd19f1b93a822ffb3.x152cbadbfa8061b1("smartTagPr"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xd19f1b93a822ffb3.xa66385d80d4d296f) != null && xa66385d80d4d296f == "attr")
			{
				xf4c2bd3135c22758(xd19f1b93a822ffb3, xdc6161a296532e34);
			}
			else
			{
				xd19f1b93a822ffb3.IgnoreElement();
			}
		}
	}

	private static void xf4c2bd3135c22758(xc1dcd6189d01216e xd19f1b93a822ffb3, SmartTag xdc6161a296532e34)
	{
		string text = "";
		string uri = "";
		string value = "";
		while (xd19f1b93a822ffb3.x1ac1960adc8c4c39())
		{
			switch (xd19f1b93a822ffb3.xa66385d80d4d296f)
			{
			case "name":
				text = xd19f1b93a822ffb3.xd2f68ee6f47e9dfb;
				break;
			case "uri":
				uri = xd19f1b93a822ffb3.xd2f68ee6f47e9dfb;
				break;
			case "val":
				value = xd19f1b93a822ffb3.xd2f68ee6f47e9dfb;
				break;
			}
		}
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			xdc6161a296532e34.Properties.x1cd8943d02c5342f(new CustomXmlProperty(text, uri, value));
		}
	}
}
