using System;
using Aspose.Words.Markup;
using x1495530f35d79681;
using x53eb9320ebbb8395;
using x6c95d9cf46ff5f25;
using x909757d9fd2dd6ae;
using x9db5f2e5af3d596e;
using xda075892eccab2ad;
using xf9a9481c3f63a419;

namespace x79490184cecf12a1;

internal class x1d1a299a51dcf8a0
{
	private xedb0eb766e25e0c9 x4561d71d08d75334;

	private readonly MarkupLevel xaabccab0c06d038b;

	internal static x1d1a299a51dcf8a0 x2becda0634f612cd()
	{
		return new x1d1a299a51dcf8a0(MarkupLevel.Inline);
	}

	internal static x1d1a299a51dcf8a0 x944488b699acab30()
	{
		return new x1d1a299a51dcf8a0(MarkupLevel.Block);
	}

	internal static x1d1a299a51dcf8a0 x84ad5c48cfed7861(xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		x1d1a299a51dcf8a0 x1d1a299a51dcf8a = new x1d1a299a51dcf8a0(MarkupLevel.Row);
		x1d1a299a51dcf8a.x4561d71d08d75334 = xe193ceb565ecaa0a;
		return x1d1a299a51dcf8a;
	}

	internal static x1d1a299a51dcf8a0 x902349bf5ac3a6fc(xedb0eb766e25e0c9 x0d9383c33dfa78ca)
	{
		x1d1a299a51dcf8a0 x1d1a299a51dcf8a = new x1d1a299a51dcf8a0(MarkupLevel.Cell);
		x1d1a299a51dcf8a.x4561d71d08d75334 = x0d9383c33dfa78ca;
		return x1d1a299a51dcf8a;
	}

	private x1d1a299a51dcf8a0(MarkupLevel level)
	{
		xaabccab0c06d038b = level;
	}

	internal void x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		StructuredDocumentTag structuredDocumentTag = new StructuredDocumentTag(xe134235b3526fa75.x2c8c6741422a1298, xaabccab0c06d038b);
		xe134235b3526fa75.x25bdcca0c7a07e03(structuredDocumentTag);
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("sdt"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "sdtContent":
				x5523b731e6be608b(xe134235b3526fa75);
				continue;
			case "sdtPr":
				x97890cad4857a3bb(xe134235b3526fa75, structuredDocumentTag);
				continue;
			case "sdtEndPr":
				xaf6f8868def6f3d7(xe134235b3526fa75, structuredDocumentTag, x3bcd232d01c);
				continue;
			}
			if (xaabccab0c06d038b == MarkupLevel.Block)
			{
				xce4dd62ad1252b05.x152cbadbfa8061b1(xe134235b3526fa75);
			}
		}
		xe134235b3526fa75.xee59bcd855a217ab(structuredDocumentTag, x3bcd232d01c.x413affb5b90b6470);
	}

	private static void xaf6f8868def6f3d7(xdfce7f4f687956d7 xe134235b3526fa75, StructuredDocumentTag xabd8f8a3b7f099d3, x3c85359e1389ad43 x97bf2eeabd4abc7b)
	{
		while (x97bf2eeabd4abc7b.x152cbadbfa8061b1("sdtEndPr"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x97bf2eeabd4abc7b.xa66385d80d4d296f) != null && xa66385d80d4d296f == "rPr")
			{
				x419d718f5b3e63d8.x06b0e25aa6ad68a9(xe134235b3526fa75, xabd8f8a3b7f099d3.xa29d931f51e74fb3);
			}
			else
			{
				x97bf2eeabd4abc7b.IgnoreElement();
			}
		}
	}

	private static void x97890cad4857a3bb(xdfce7f4f687956d7 xe134235b3526fa75, StructuredDocumentTag xabd8f8a3b7f099d3)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("sdtPr"))
		{
			if (x3bcd232d01c.x91d35d7dc070c876 == "http://schemas.microsoft.com/office/word/2010/wordml" && x3bcd232d01c.xa66385d80d4d296f == "checkbox")
			{
				x89fc29ef17cb9762 x133e9194ab7c3b = (x89fc29ef17cb9762)(xabd8f8a3b7f099d3.x96381e70e1c51c6d = new x89fc29ef17cb9762());
				x90d7f741a171952f(xe134235b3526fa75, x133e9194ab7c3b);
			}
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "alias":
				xabd8f8a3b7f099d3.Title = x3bcd232d01c.xbbfc54380705e01e();
				break;
			case "bibliography":
				xabd8f8a3b7f099d3.x96381e70e1c51c6d = new x31d115a3e356ccee();
				break;
			case "citation":
				xabd8f8a3b7f099d3.x96381e70e1c51c6d = new x0ea89f0fb11c3828();
				break;
			case "comboBox":
			{
				x0fc5347a41e2da70 x0de8ac94006744232 = (x0fc5347a41e2da70)(xabd8f8a3b7f099d3.x96381e70e1c51c6d = new x1ea8d6b9e917c175());
				x863ececc8deb16ca(xe134235b3526fa75, x0de8ac94006744232);
				break;
			}
			case "dataBinding":
				x19c018e85be33cef(xe134235b3526fa75, xabd8f8a3b7f099d3);
				break;
			case "date":
				xf1a5675dddec7694(xe134235b3526fa75, xabd8f8a3b7f099d3);
				break;
			case "docPartList":
			{
				x6e0d00b0fad00507 x8d25d0e5ce2 = (x6e0d00b0fad00507)(xabd8f8a3b7f099d3.x96381e70e1c51c6d = new x86a25242dc4d43f0());
				xe34229f607bb01a0(xe134235b3526fa75, x8d25d0e5ce2);
				break;
			}
			case "docPartObj":
			{
				x6e0d00b0fad00507 x8d25d0e5ce = (x6e0d00b0fad00507)(xabd8f8a3b7f099d3.x96381e70e1c51c6d = new x9caaad74a375d4ea());
				xe34229f607bb01a0(xe134235b3526fa75, x8d25d0e5ce);
				break;
			}
			case "dropDownList":
			{
				x0fc5347a41e2da70 x0de8ac9400674423 = (x0fc5347a41e2da70)(xabd8f8a3b7f099d3.x96381e70e1c51c6d = new xb59ded127e0eafce());
				x863ececc8deb16ca(xe134235b3526fa75, x0de8ac9400674423);
				break;
			}
			case "equation":
				xabd8f8a3b7f099d3.x96381e70e1c51c6d = new x0d83bc67133fbb4d();
				break;
			case "group":
				xabd8f8a3b7f099d3.x96381e70e1c51c6d = new xf8b4c2a1a627a484();
				break;
			case "id":
				xabd8f8a3b7f099d3.xbf02a69b0d230435(x3bcd232d01c.xb8ac33c25776194c());
				break;
			case "label":
				xabd8f8a3b7f099d3.xe9605a4bea014f21 = x3bcd232d01c.xb8ac33c25776194c();
				break;
			case "lock":
				x0d4284f0e9151619(x3bcd232d01c, xabd8f8a3b7f099d3);
				break;
			case "picture":
				xabd8f8a3b7f099d3.x96381e70e1c51c6d = new x5f69b4c1ace6e16f();
				break;
			case "placeholder":
				x8be71483c39e78fd(xe134235b3526fa75, xabd8f8a3b7f099d3);
				break;
			case "richText":
				xc3a6fb8513d320a3(xe134235b3526fa75, xabd8f8a3b7f099d3, x1f7e7855dd957251: true);
				break;
			case "rPr":
				x419d718f5b3e63d8.x06b0e25aa6ad68a9(xe134235b3526fa75, xabd8f8a3b7f099d3.xde86b50786169450);
				break;
			case "showingPlcHdr":
				xabd8f8a3b7f099d3.IsShowingPlaceholderText = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "tabIndex":
				xabd8f8a3b7f099d3.x55d53b8223729bb7 = x3bcd232d01c.xb8ac33c25776194c();
				break;
			case "tag":
				xabd8f8a3b7f099d3.Tag = x3bcd232d01c.xbbfc54380705e01e();
				break;
			case "temporary":
				xabd8f8a3b7f099d3.IsTemporary = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "text":
				xc3a6fb8513d320a3(xe134235b3526fa75, xabd8f8a3b7f099d3, x1f7e7855dd957251: false);
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
		if (xabd8f8a3b7f099d3.SdtType == SdtType.None)
		{
			xabd8f8a3b7f099d3.x96381e70e1c51c6d = new x4687977089abc632(isRichText: true);
		}
	}

	private static void x0d4284f0e9151619(x3c85359e1389ad43 x97bf2eeabd4abc7b, StructuredDocumentTag xabd8f8a3b7f099d3)
	{
		xed92c0eace754ea8 xed92c0eace754ea = xc62574be95c1c918.xf955a7b0097396a2(x97bf2eeabd4abc7b.xbbfc54380705e01e());
		xabd8f8a3b7f099d3.LockContentControl = xed92c0eace754ea == xed92c0eace754ea8.x7ac4b04ce84a953d || xed92c0eace754ea == xed92c0eace754ea8.xc2ab81b8dd700ffa;
		xabd8f8a3b7f099d3.LockContents = xed92c0eace754ea == xed92c0eace754ea8.x33eef8a5371b8ebb || xed92c0eace754ea == xed92c0eace754ea8.xc2ab81b8dd700ffa;
	}

	private void x5523b731e6be608b(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		switch (xaabccab0c06d038b)
		{
		case MarkupLevel.Inline:
			x5ab4843b5e9c9f8d.x6a5b9e9e63b563c8(xe134235b3526fa75);
			break;
		case MarkupLevel.Block:
			xce4dd62ad1252b05.x6a5b9e9e63b563c8(xe134235b3526fa75);
			break;
		case MarkupLevel.Row:
			x22063a019e9be4a2.x6a5b9e9e63b563c8(xe134235b3526fa75, x4561d71d08d75334);
			break;
		case MarkupLevel.Cell:
			x81e625161048fd10.x6a5b9e9e63b563c8(xe134235b3526fa75, x4561d71d08d75334);
			break;
		default:
			throw new InvalidOperationException("Please report exception.");
		}
	}

	private static void x90d7f741a171952f(xdfce7f4f687956d7 xe134235b3526fa75, x89fc29ef17cb9762 x133e9194ab7c3b09)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("checkbox"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "checked":
				x133e9194ab7c3b09.x24d4d51879f7605e = x3bcd232d01c.xb8ac33c25776194c() != 0;
				break;
			case "checkedState":
			case "uncheckedState":
			{
				string fontName = x3bcd232d01c.xd68abcd61e368af9("font", "");
				int characterCode = xca004f56614e2431.xadcf75bfc0bf31e3(x3bcd232d01c.xbbfc54380705e01e());
				if (x3bcd232d01c.xa66385d80d4d296f == "checkedState")
				{
					x133e9194ab7c3b09.x52faab23f386ced2 = new xcf27d12b52d704e9(fontName, characterCode);
				}
				else
				{
					x133e9194ab7c3b09.x68437ae19961129c = new xcf27d12b52d704e9(fontName, characterCode);
				}
				break;
			}
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	private static void x863ececc8deb16ca(xdfce7f4f687956d7 xe134235b3526fa75, x0fc5347a41e2da70 x0de8ac9400674423)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		string text = "";
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "lastValue")
			{
				text = x3bcd232d01c.xd2f68ee6f47e9dfb;
			}
		}
		x3bcd232d01c.x99f8cdb2827fa686();
		string xa66385d80d4d296f2 = x3bcd232d01c.xa66385d80d4d296f;
		while (x3bcd232d01c.x152cbadbfa8061b1(xa66385d80d4d296f2))
		{
			string xa66385d80d4d296f3;
			if ((xa66385d80d4d296f3 = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f3 == "listItem")
			{
				x895be302a6cc29f2(xe134235b3526fa75, x0de8ac9400674423);
			}
			else
			{
				x3bcd232d01c.IgnoreElement();
			}
		}
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			x45d0a2ac6996cd6d(text, x0de8ac9400674423.x883eea81d91d4029);
		}
	}

	private static void x45d0a2ac6996cd6d(string xe30527db26b042a8, SdtListItemCollection x88c51072705a9de3)
	{
		for (int i = 0; i < x88c51072705a9de3.Count; i++)
		{
			if (x88c51072705a9de3[i].Value == xe30527db26b042a8)
			{
				x88c51072705a9de3.SelectedValue = x88c51072705a9de3[i];
				break;
			}
		}
	}

	private static void x895be302a6cc29f2(xdfce7f4f687956d7 xe134235b3526fa75, x0fc5347a41e2da70 x0de8ac9400674423)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		string displayText = "";
		string text = "";
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "displayText":
				displayText = x3bcd232d01c.xd2f68ee6f47e9dfb;
				break;
			case "value":
				text = x3bcd232d01c.xd2f68ee6f47e9dfb;
				break;
			}
		}
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			x0de8ac9400674423.x883eea81d91d4029.Add(new SdtListItem(displayText, text));
		}
	}

	private static void x19c018e85be33cef(xdfce7f4f687956d7 xe134235b3526fa75, StructuredDocumentTag xabd8f8a3b7f099d3)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		string text = "";
		string text2 = "";
		string text3 = "";
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "prefixMappings":
				text = x3bcd232d01c.xd2f68ee6f47e9dfb;
				break;
			case "storeItemID":
				text2 = x3bcd232d01c.xd2f68ee6f47e9dfb;
				break;
			case "xpath":
				text3 = x3bcd232d01c.xd2f68ee6f47e9dfb;
				break;
			}
		}
		if (x0d299f323d241756.x5959bccb67bbf051(text3) && x0d299f323d241756.x5959bccb67bbf051(text2))
		{
			xabd8f8a3b7f099d3.x748c99c08cdf7cb1 = (x0d299f323d241756.x5959bccb67bbf051(text) ? new x3be06ee5a3bb124b(text, text3, text2) : new x3be06ee5a3bb124b(text3, text2));
		}
	}

	private static void xf1a5675dddec7694(xdfce7f4f687956d7 xe134235b3526fa75, StructuredDocumentTag xabd8f8a3b7f099d3)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		xb195c94e6015d34a xb195c94e6015d34a = (xb195c94e6015d34a)(xabd8f8a3b7f099d3.x96381e70e1c51c6d = new xb195c94e6015d34a());
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "fullDate")
			{
				xb195c94e6015d34a.x6bcf08208cc26627 = xca004f56614e2431.x70982613fd6240f9(x3bcd232d01c.xd2f68ee6f47e9dfb);
			}
		}
		x3bcd232d01c.x99f8cdb2827fa686();
		string xa66385d80d4d296f2 = x3bcd232d01c.xa66385d80d4d296f;
		while (x3bcd232d01c.x152cbadbfa8061b1(xa66385d80d4d296f2))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "calendar":
				xb195c94e6015d34a.x85e0792106b8352f = xc62574be95c1c918.x5a1cbe2e27ce9bf7(x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "dateFormat":
				xb195c94e6015d34a.xacc0cf2788d5c15a = x3bcd232d01c.xbbfc54380705e01e();
				break;
			case "lid":
				xb195c94e6015d34a.xc6c1e6f7d84e1707 = xf2a0216b53787578.xae88295ea6bfc819(x3bcd232d01c.xbbfc54380705e01e(), x5fbb1a9c98604ef5: true);
				break;
			case "storeMappedDataAs":
				xb195c94e6015d34a.x234f6481bd6906d3 = xc62574be95c1c918.x8a8775f0dde3331a(x3bcd232d01c.xbbfc54380705e01e());
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	private static void xe34229f607bb01a0(xdfce7f4f687956d7 xe134235b3526fa75, x6e0d00b0fad00507 x8d25d0e5ce612068)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		string xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f;
		while (x3bcd232d01c.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "docPartCategory":
				x8d25d0e5ce612068.x1c33ce3f46fa62fa = x3bcd232d01c.xbbfc54380705e01e();
				break;
			case "docPartGallery":
				x8d25d0e5ce612068.x6be6ad959e27836b = x3bcd232d01c.xbbfc54380705e01e();
				break;
			case "docPartUnique":
				x8d25d0e5ce612068.xd6057427f65f21f6 = x3bcd232d01c.xe04906126da94dd1();
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	private static void x8be71483c39e78fd(xdfce7f4f687956d7 xe134235b3526fa75, StructuredDocumentTag xffe521cc76054baf)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("placeholder"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "docPart")
			{
				xffe521cc76054baf.x0d96312ab6b79c72(x3bcd232d01c.xbbfc54380705e01e());
			}
			else
			{
				x3bcd232d01c.IgnoreElement();
			}
		}
	}

	private static void xc3a6fb8513d320a3(xdfce7f4f687956d7 xe134235b3526fa75, StructuredDocumentTag xabd8f8a3b7f099d3, bool x1f7e7855dd957251)
	{
		x4687977089abc632 x4687977089abc = (x4687977089abc632)(xabd8f8a3b7f099d3.x96381e70e1c51c6d = new x4687977089abc632(x1f7e7855dd957251));
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "multiLine")
			{
				x4687977089abc.xe3ccff5629a1e888 = x3bcd232d01c.xc3be6b142c6aca84;
			}
		}
	}
}
