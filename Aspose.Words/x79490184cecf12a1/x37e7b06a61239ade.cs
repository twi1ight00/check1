using System;
using Aspose.Words.Markup;
using x1495530f35d79681;
using x6c95d9cf46ff5f25;
using x9db5f2e5af3d596e;

namespace x79490184cecf12a1;

internal class x37e7b06a61239ade
{
	private readonly MarkupLevel xaabccab0c06d038b;

	private xedb0eb766e25e0c9 x4561d71d08d75334;

	private x37e7b06a61239ade(MarkupLevel level)
	{
		xaabccab0c06d038b = level;
	}

	internal static x37e7b06a61239ade xf5b9bcd152ae8e99()
	{
		return new x37e7b06a61239ade(MarkupLevel.Inline);
	}

	internal static x37e7b06a61239ade x104a769b370c68e5()
	{
		return new x37e7b06a61239ade(MarkupLevel.Block);
	}

	internal static x37e7b06a61239ade x50eb8de80d3129d6(xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		x37e7b06a61239ade x37e7b06a61239ade2 = new x37e7b06a61239ade(MarkupLevel.Row);
		x37e7b06a61239ade2.x4561d71d08d75334 = xe193ceb565ecaa0a;
		return x37e7b06a61239ade2;
	}

	internal static x37e7b06a61239ade x1631b9aabbade1ad(xedb0eb766e25e0c9 x0d9383c33dfa78ca)
	{
		x37e7b06a61239ade x37e7b06a61239ade2 = new x37e7b06a61239ade(MarkupLevel.Cell);
		x37e7b06a61239ade2.x4561d71d08d75334 = x0d9383c33dfa78ca;
		return x37e7b06a61239ade2;
	}

	internal void x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		CustomXmlMarkup customXmlMarkup = new CustomXmlMarkup(xe134235b3526fa75.x2c8c6741422a1298, xaabccab0c06d038b);
		xe134235b3526fa75.x25bdcca0c7a07e03(customXmlMarkup);
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "element":
				customXmlMarkup.Element = x3bcd232d01c.xd2f68ee6f47e9dfb;
				break;
			case "uri":
				customXmlMarkup.Uri = x3bcd232d01c.xd2f68ee6f47e9dfb;
				break;
			}
		}
		x3bcd232d01c.x99f8cdb2827fa686();
		while (x3bcd232d01c.x152cbadbfa8061b1("customXml"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "customXmlPr")
			{
				x2a4059582b29dd64(x3bcd232d01c, customXmlMarkup);
			}
			else
			{
				xfd78dc59c1a674dd(xe134235b3526fa75);
			}
		}
		xe134235b3526fa75.xee59bcd855a217ab(customXmlMarkup, x3bcd232d01c.x413affb5b90b6470);
	}

	private void xfd78dc59c1a674dd(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		switch (xaabccab0c06d038b)
		{
		case MarkupLevel.Inline:
			x5ab4843b5e9c9f8d.x152cbadbfa8061b1(xe134235b3526fa75);
			break;
		case MarkupLevel.Block:
			xce4dd62ad1252b05.x152cbadbfa8061b1(xe134235b3526fa75);
			break;
		case MarkupLevel.Row:
			x22063a019e9be4a2.x152cbadbfa8061b1(xe134235b3526fa75, x4561d71d08d75334);
			break;
		case MarkupLevel.Cell:
			x81e625161048fd10.x152cbadbfa8061b1(xe134235b3526fa75, x4561d71d08d75334);
			break;
		default:
			throw new InvalidOperationException("Unexpected custom XML markup level.");
		}
	}

	private static void x2a4059582b29dd64(x3c85359e1389ad43 xd19f1b93a822ffb3, CustomXmlMarkup x2f992229ae4fc9a1)
	{
		while (xd19f1b93a822ffb3.x152cbadbfa8061b1("customXmlPr"))
		{
			switch (xd19f1b93a822ffb3.xa66385d80d4d296f)
			{
			case "attr":
				xf4c2bd3135c22758(xd19f1b93a822ffb3, x2f992229ae4fc9a1);
				break;
			case "placeholder":
			{
				string text = xd19f1b93a822ffb3.xbbfc54380705e01e();
				if (x0d299f323d241756.x5959bccb67bbf051(text))
				{
					x2f992229ae4fc9a1.Placeholder = text;
				}
				break;
			}
			default:
				xd19f1b93a822ffb3.IgnoreElement();
				break;
			}
		}
	}

	private static void xf4c2bd3135c22758(xc1dcd6189d01216e xd19f1b93a822ffb3, CustomXmlMarkup x2f992229ae4fc9a1)
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
			x2f992229ae4fc9a1.Properties.x1cd8943d02c5342f(new CustomXmlProperty(text, uri, value));
		}
	}
}
