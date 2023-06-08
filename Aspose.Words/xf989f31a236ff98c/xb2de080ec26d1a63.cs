using System.IO;
using Aspose.Words.Markup;
using x1495530f35d79681;
using x6c95d9cf46ff5f25;

namespace xf989f31a236ff98c;

internal class xb2de080ec26d1a63
{
	private xb2de080ec26d1a63()
	{
	}

	internal static void x6210059f049f0d48(CustomXmlPart x8e12b4cb5e54b506, x3c74b3c4f21844f9 xd07ce4b74c5774a7)
	{
		xd07ce4b74c5774a7.x9b9ed0109b743e3b("ds:datastoreItem");
		xd07ce4b74c5774a7.xff520a0047c27122("ds:itemID", x8e12b4cb5e54b506.Id);
		xd07ce4b74c5774a7.xff520a0047c27122("xmlns:ds", "http://schemas.openxmlformats.org/officeDocument/2006/customXml");
		xd07ce4b74c5774a7.x2307058321cdb62f("ds:schemaRefs");
		foreach (string schema in x8e12b4cb5e54b506.Schemas)
		{
			xd07ce4b74c5774a7.x2307058321cdb62f("ds:schemaRef");
			xd07ce4b74c5774a7.xff520a0047c27122("ds:uri", schema);
			xd07ce4b74c5774a7.x2dfde153f4ef96d0("ds:schemaRef");
		}
		xd07ce4b74c5774a7.x2dfde153f4ef96d0("ds:schemaRefs");
		xd07ce4b74c5774a7.xa0dfc102c691b11f();
	}

	internal static void x06b0e25aa6ad68a9(Stream xcf18e5243f8d5fd3, CustomXmlPart x8e12b4cb5e54b506)
	{
		if (xcf18e5243f8d5fd3.Length == 0)
		{
			return;
		}
		x3c85359e1389ad43 x3c85359e1389ad = new x3c85359e1389ad43(xcf18e5243f8d5fd3);
		while (x3c85359e1389ad.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3c85359e1389ad.xa66385d80d4d296f) != null && xa66385d80d4d296f == "itemID")
			{
				x8e12b4cb5e54b506.Id = x3c85359e1389ad.xd2f68ee6f47e9dfb;
			}
		}
		x3c85359e1389ad.x99f8cdb2827fa686();
		while (x3c85359e1389ad.x152cbadbfa8061b1("datastoreItem"))
		{
			string xa66385d80d4d296f2;
			if ((xa66385d80d4d296f2 = x3c85359e1389ad.xa66385d80d4d296f) != null && xa66385d80d4d296f2 == "schemaRefs")
			{
				x516ac928adc10e28(x3c85359e1389ad, x8e12b4cb5e54b506);
			}
			else
			{
				x3c85359e1389ad.IgnoreElement();
			}
		}
	}

	private static void x516ac928adc10e28(x3c85359e1389ad43 x97bf2eeabd4abc7b, CustomXmlPart x8e12b4cb5e54b506)
	{
		while (x97bf2eeabd4abc7b.x152cbadbfa8061b1("schemaRefs"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x97bf2eeabd4abc7b.xa66385d80d4d296f) != null && xa66385d80d4d296f == "schemaRef")
			{
				xeeecf1fcd42b07dc(x97bf2eeabd4abc7b, x8e12b4cb5e54b506);
			}
			else
			{
				x97bf2eeabd4abc7b.IgnoreElement();
			}
		}
	}

	private static void xeeecf1fcd42b07dc(x3c85359e1389ad43 x97bf2eeabd4abc7b, CustomXmlPart x8e12b4cb5e54b506)
	{
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x97bf2eeabd4abc7b.xa66385d80d4d296f) != null && xa66385d80d4d296f == "uri")
			{
				x8e12b4cb5e54b506.Schemas.Add(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb);
			}
		}
	}
}
