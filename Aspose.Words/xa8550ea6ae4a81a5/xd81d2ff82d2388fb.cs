using System;
using Aspose.Words.Markup;
using x1a3e96f4b89a7a77;
using x53eb9320ebbb8395;
using x6c95d9cf46ff5f25;
using x909757d9fd2dd6ae;
using xda075892eccab2ad;
using xf9a9481c3f63a419;

namespace xa8550ea6ae4a81a5;

internal class xd81d2ff82d2388fb
{
	private xd81d2ff82d2388fb()
	{
	}

	internal static void xd29409f2ba9889e2(StructuredDocumentTag xabd8f8a3b7f099d3, xaf66e8c590b2b553 xbdfb620b7167944b)
	{
		x8f3af96aa56f1e32 xca93abf9292cd4f = xbdfb620b7167944b.xca93abf9292cd4f1;
		xca93abf9292cd4f.x2307058321cdb62f("w:sdt");
		x94d3b16c2c3c189d(xabd8f8a3b7f099d3, xbdfb620b7167944b);
		x42b0a4eb14e56f98(xabd8f8a3b7f099d3, xbdfb620b7167944b);
		xca93abf9292cd4f.x2307058321cdb62f("w:sdtContent");
	}

	internal static void x685b1e5a342b26d7(x8f3af96aa56f1e32 xd07ce4b74c5774a7)
	{
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private static void x94d3b16c2c3c189d(StructuredDocumentTag xabd8f8a3b7f099d3, xaf66e8c590b2b553 xbdfb620b7167944b)
	{
		x8f3af96aa56f1e32 xca93abf9292cd4f = xbdfb620b7167944b.xca93abf9292cd4f1;
		xca93abf9292cd4f.x2307058321cdb62f("w:sdtPr");
		if (xabd8f8a3b7f099d3.xde86b50786169450.xd44988f225497f3a != 0)
		{
			xc70f986e9535e88a.xcb4a900bb4787522(xabd8f8a3b7f099d3.xde86b50786169450, null, x8f19af4759cf8cd4: false, xbdfb620b7167944b);
		}
		xca93abf9292cd4f.x547195bcc386fe66("w:alias", xabd8f8a3b7f099d3.Title);
		xca93abf9292cd4f.x547195bcc386fe66("w:tag", xabd8f8a3b7f099d3.Tag);
		xca93abf9292cd4f.x547195bcc386fe66("w:id", xabd8f8a3b7f099d3.Id);
		xed92c0eace754ea8 xed92c0eace754ea = xaee6219c3e09f538(xabd8f8a3b7f099d3.LockContentControl, xabd8f8a3b7f099d3.LockContents);
		if (xed92c0eace754ea != 0)
		{
			xca93abf9292cd4f.x547195bcc386fe66("w:lock", xc62574be95c1c918.x23c31cfdbc6aba34(xed92c0eace754ea));
		}
		xdfbec8d15f6a4c10(xca93abf9292cd4f, xabd8f8a3b7f099d3);
		if (xabd8f8a3b7f099d3.IsShowingPlaceholderText)
		{
			xca93abf9292cd4f.xf68f9c3818e1f4b1("w:showingPlcHdr");
		}
		x0a0efcef93fe457a(xca93abf9292cd4f, xabd8f8a3b7f099d3);
		x17ca07944339d7c6(xabd8f8a3b7f099d3.x96381e70e1c51c6d, xca93abf9292cd4f);
		if (xabd8f8a3b7f099d3.x377ed475ed97f896)
		{
			xca93abf9292cd4f.x547195bcc386fe66("w:label", xabd8f8a3b7f099d3.xe9605a4bea014f21);
		}
		if (xabd8f8a3b7f099d3.x55d53b8223729bb7 != 0)
		{
			xca93abf9292cd4f.x547195bcc386fe66("tabIndex", xabd8f8a3b7f099d3.x55d53b8223729bb7);
		}
		if (xabd8f8a3b7f099d3.IsTemporary)
		{
			xca93abf9292cd4f.xf68f9c3818e1f4b1("w:temporary");
		}
		xca93abf9292cd4f.x2dfde153f4ef96d0();
	}

	private static void xdfbec8d15f6a4c10(x8f3af96aa56f1e32 xd07ce4b74c5774a7, StructuredDocumentTag xabd8f8a3b7f099d3)
	{
		if (xabd8f8a3b7f099d3.Placeholder != null && x0d299f323d241756.x5959bccb67bbf051(xabd8f8a3b7f099d3.PlaceholderName))
		{
			xd07ce4b74c5774a7.x2307058321cdb62f("w:placeholder");
			xd07ce4b74c5774a7.x547195bcc386fe66("w:docPart", xabd8f8a3b7f099d3.PlaceholderName);
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		}
	}

	private static void x0a0efcef93fe457a(x8f3af96aa56f1e32 xd07ce4b74c5774a7, StructuredDocumentTag xabd8f8a3b7f099d3)
	{
		if (xabd8f8a3b7f099d3.x748c99c08cdf7cb1 != null)
		{
			xd07ce4b74c5774a7.x2307058321cdb62f("w:dataBinding");
			xd07ce4b74c5774a7.x943f6be3acf634db("w:xpath", xabd8f8a3b7f099d3.x748c99c08cdf7cb1.x8d815cb9b264fc20);
			xd07ce4b74c5774a7.x943f6be3acf634db("w:storeItemID", xabd8f8a3b7f099d3.x748c99c08cdf7cb1.x949db66894158be8);
			xd07ce4b74c5774a7.x943f6be3acf634db("w:prefixMappings", xabd8f8a3b7f099d3.x748c99c08cdf7cb1.x9035cee51805f20b);
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		}
	}

	private static void x17ca07944339d7c6(xce81d6edccc8b285 xcbee72a255016cca, x8f3af96aa56f1e32 xd07ce4b74c5774a7)
	{
		switch (xcbee72a255016cca.x3146d638ec378671)
		{
		case SdtType.Bibliography:
			xd07ce4b74c5774a7.xf68f9c3818e1f4b1("w:bibliography");
			break;
		case SdtType.Citation:
			xd07ce4b74c5774a7.xf68f9c3818e1f4b1("w:citation");
			break;
		case SdtType.Equation:
			xd07ce4b74c5774a7.xf68f9c3818e1f4b1("w:equation");
			break;
		case SdtType.DropDownList:
		case SdtType.ComboBox:
			x90245b12e0d17fc5((xcbee72a255016cca.x3146d638ec378671 == SdtType.DropDownList) ? "w:dropDownList" : "w:comboBox", ((x0fc5347a41e2da70)xcbee72a255016cca).x883eea81d91d4029, xd07ce4b74c5774a7);
			break;
		case SdtType.Date:
			x4a2644d18c3915dc((xb195c94e6015d34a)xcbee72a255016cca, xd07ce4b74c5774a7);
			break;
		case SdtType.BuildingBlockGallery:
			x7d56f9a1694a8b51("w:docPartList", (x6e0d00b0fad00507)xcbee72a255016cca, xd07ce4b74c5774a7);
			break;
		case SdtType.DocPartObj:
			x7d56f9a1694a8b51("w:docPartObj", (x6e0d00b0fad00507)xcbee72a255016cca, xd07ce4b74c5774a7);
			break;
		case SdtType.Group:
			xd07ce4b74c5774a7.xf68f9c3818e1f4b1("w:group");
			break;
		case SdtType.Picture:
			xd07ce4b74c5774a7.xf68f9c3818e1f4b1("w:picture");
			break;
		case SdtType.RichText:
		case SdtType.PlainText:
		{
			x4687977089abc632 x4687977089abc = (x4687977089abc632)xcbee72a255016cca;
			x636457dda93ec7a1(xd07ce4b74c5774a7, x4687977089abc.x3146d638ec378671 == SdtType.RichText, x4687977089abc.xe3ccff5629a1e888);
			break;
		}
		case SdtType.Checkbox:
			xf3523cfc0fcde3a8((x89fc29ef17cb9762)xcbee72a255016cca, xd07ce4b74c5774a7);
			break;
		default:
			throw new InvalidOperationException("Please report exception.");
		case SdtType.None:
			break;
		}
	}

	private static void xf3523cfc0fcde3a8(x89fc29ef17cb9762 x133e9194ab7c3b09, x8f3af96aa56f1e32 xd07ce4b74c5774a7)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("w14:checkbox");
		xd07ce4b74c5774a7.xc049ea80ee267201("w14:checked", "w14:val", x133e9194ab7c3b09.x24d4d51879f7605e ? 1 : 0);
		xd07ce4b74c5774a7.xc049ea80ee267201("w14:checkedState", "w14:val", $"{x133e9194ab7c3b09.x52faab23f386ced2.x32dcc9d3ca30726c:x4}", "w14:font", x133e9194ab7c3b09.x52faab23f386ced2.x707c2bded9e130c2);
		xd07ce4b74c5774a7.xc049ea80ee267201("w14:uncheckedState", "w14:val", $"{x133e9194ab7c3b09.x68437ae19961129c.x32dcc9d3ca30726c:x4}", "w14:font", x133e9194ab7c3b09.x68437ae19961129c.x707c2bded9e130c2);
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private static void x636457dda93ec7a1(x8f3af96aa56f1e32 xd07ce4b74c5774a7, bool x1f7e7855dd957251, bool xb3140c548114e96c)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f(x1f7e7855dd957251 ? "w:richText" : "w:text");
		xd07ce4b74c5774a7.x0ea3ef8dd3ae2f3f("w:multiLine", xb3140c548114e96c);
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private static void x90245b12e0d17fc5(string x91ef5ae2997ab6c4, SdtListItemCollection xf671230c49fb86ad, x8f3af96aa56f1e32 xd07ce4b74c5774a7)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f(x91ef5ae2997ab6c4);
		if (xf671230c49fb86ad.SelectedValue != null)
		{
			xd07ce4b74c5774a7.x943f6be3acf634db("w:lastValue", xf671230c49fb86ad.SelectedValue.Value);
		}
		for (int i = 0; i < xf671230c49fb86ad.Count; i++)
		{
			xd07ce4b74c5774a7.x2307058321cdb62f("w:listItem");
			SdtListItem sdtListItem = xf671230c49fb86ad[i];
			xd07ce4b74c5774a7.x943f6be3acf634db("w:value", sdtListItem.Value);
			xd07ce4b74c5774a7.x943f6be3acf634db("w:displayText", sdtListItem.DisplayText);
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		}
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private static void x4a2644d18c3915dc(xb195c94e6015d34a xccf8b068badcb542, x8f3af96aa56f1e32 xd07ce4b74c5774a7)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("w:date");
		if (xccf8b068badcb542.x6bcf08208cc26627 != DateTime.MinValue)
		{
			xd07ce4b74c5774a7.x943f6be3acf634db("w:fullDate", xca004f56614e2431.x6efbf9d15154c80d(xccf8b068badcb542.x6bcf08208cc26627));
		}
		xd07ce4b74c5774a7.x547195bcc386fe66("w:dateFormat", xccf8b068badcb542.xacc0cf2788d5c15a);
		if (xccf8b068badcb542.xc6c1e6f7d84e1707 != -1)
		{
			xd07ce4b74c5774a7.x547195bcc386fe66("w:lid", xf2a0216b53787578.xd16e1d14e9bd81a9(xccf8b068badcb542.xc6c1e6f7d84e1707, x5fbb1a9c98604ef5: true));
		}
		xd07ce4b74c5774a7.x547195bcc386fe66("w:storeMappedDataAs", xc62574be95c1c918.x0f5d755dbfc52c1a(xccf8b068badcb542.x234f6481bd6906d3));
		xd07ce4b74c5774a7.x547195bcc386fe66("w:calendar", xc62574be95c1c918.xb171fd851955b5db(xccf8b068badcb542.x85e0792106b8352f));
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private static void x7d56f9a1694a8b51(string x91ef5ae2997ab6c4, x6e0d00b0fad00507 x8d25d0e5ce612068, x8f3af96aa56f1e32 xd07ce4b74c5774a7)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f(x91ef5ae2997ab6c4);
		xd07ce4b74c5774a7.x547195bcc386fe66("w:docPartCategory", x8d25d0e5ce612068.x1c33ce3f46fa62fa);
		xd07ce4b74c5774a7.x547195bcc386fe66("w:docPartGallery", x8d25d0e5ce612068.x6be6ad959e27836b);
		if (x8d25d0e5ce612068.xd6057427f65f21f6)
		{
			xd07ce4b74c5774a7.xf68f9c3818e1f4b1("w:docPartUnique");
		}
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private static void x42b0a4eb14e56f98(StructuredDocumentTag xabd8f8a3b7f099d3, xaf66e8c590b2b553 xbdfb620b7167944b)
	{
		if (xabd8f8a3b7f099d3.xa29d931f51e74fb3.xd44988f225497f3a != 0)
		{
			x8f3af96aa56f1e32 xca93abf9292cd4f = xbdfb620b7167944b.xca93abf9292cd4f1;
			xca93abf9292cd4f.x2307058321cdb62f("w:sdtEndPr");
			xc70f986e9535e88a.xcb4a900bb4787522(xabd8f8a3b7f099d3.xa29d931f51e74fb3, null, x8f19af4759cf8cd4: false, xbdfb620b7167944b);
			xca93abf9292cd4f.x2dfde153f4ef96d0();
		}
	}

	private static xed92c0eace754ea8 xaee6219c3e09f538(bool xfb76574aecf6acd1, bool x9f5bd2ec2dfc5241)
	{
		if (xfb76574aecf6acd1 && x9f5bd2ec2dfc5241)
		{
			return xed92c0eace754ea8.xc2ab81b8dd700ffa;
		}
		if (xfb76574aecf6acd1)
		{
			return xed92c0eace754ea8.x7ac4b04ce84a953d;
		}
		if (x9f5bd2ec2dfc5241)
		{
			return xed92c0eace754ea8.x33eef8a5371b8ebb;
		}
		return xed92c0eace754ea8.x3f5233cee263582a;
	}
}
