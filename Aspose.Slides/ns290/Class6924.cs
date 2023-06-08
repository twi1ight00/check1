using System;
using System.Collections;
using ns284;
using ns287;
using ns301;
using ns303;
using ns305;
using ns84;

namespace ns290;

internal class Class6924 : Interface325
{
	private readonly Interface343 interface343_0;

	private readonly Interface360 interface360_0;

	private Class6844 class6844_0;

	public Class6924(Interface343 boxModelBuilder, Interface360 textParser)
	{
		Class6892.smethod_0(boxModelBuilder, "boxModelBuilder");
		Class6892.smethod_0(textParser, "textParser");
		interface343_0 = boxModelBuilder;
		interface360_0 = textParser;
	}

	public void imethod_0(Class7033 element)
	{
	}

	public void imethod_1(Class7033 element)
	{
	}

	public void imethod_2(Class7032 element)
	{
	}

	public void imethod_3(Class6983 element)
	{
		switch (element.StyleDeclarationInternal.Display.Value)
		{
		default:
			throw new NotImplementedException();
		case Enum630.const_0:
			imethod_7(element);
			break;
		case Enum630.const_1:
			imethod_5(element);
			break;
		}
	}

	public void imethod_4(Class6983 element)
	{
		switch (element.StyleDeclarationInternal.Display.Value)
		{
		default:
			throw new NotImplementedException();
		case Enum630.const_0:
			imethod_8(element);
			break;
		case Enum630.const_1:
			imethod_6(element);
			break;
		}
	}

	public void imethod_5(Class6983 element)
	{
	}

	public void imethod_6(Class6983 element)
	{
	}

	public void imethod_7(Class6983 element)
	{
	}

	public void imethod_8(Class6983 element)
	{
	}

	public void imethod_9(Class7015 page)
	{
	}

	public void imethod_10(Class7015 page)
	{
	}

	public void imethod_11(Class6983 htmlElement)
	{
		Class6892.smethod_0(htmlElement, "htmlElement");
		interface343_0.imethod_2(htmlElement.Style, htmlElement.TagName);
	}

	public void imethod_12(Class6983 htmlElement)
	{
		Class6892.smethod_0(htmlElement, "htmlElement");
		interface343_0.imethod_3(htmlElement.Style, htmlElement.TagName);
	}

	public void imethod_13(Class7014 htmlHr)
	{
		Class6892.smethod_0(htmlHr, "htmlHr");
		interface343_0.imethod_2(htmlHr.Style, htmlHr.TagName);
		interface343_0.imethod_3(htmlHr.Style, htmlHr.TagName);
	}

	public void imethod_14(Class7002 htmlBr)
	{
		Class6892.smethod_0(htmlBr, "htmlBr");
		interface343_0.imethod_6(htmlBr.TagName);
	}

	public void imethod_15(Class6983 htmlWbr)
	{
		Class6892.smethod_0(htmlWbr, "htmlWbr");
		interface343_0.imethod_6(htmlWbr.TagName);
	}

	public void imethod_16(Class6989 time)
	{
	}

	public void method_0(Class6995 htmlTime)
	{
		Class6892.smethod_0(htmlTime, "htmlTime");
		interface343_0.imethod_6(htmlTime.TagName);
	}

	public void imethod_17(Class7001 body)
	{
		Class6892.smethod_0(body, "body");
		interface343_0.imethod_0(body.Style, body.TagName);
	}

	public void imethod_18(Class7001 body)
	{
		Class6892.smethod_0(body, "body");
		class6844_0 = interface343_0.imethod_1();
	}

	public void imethod_19(Class6980 text)
	{
		Class6892.smethod_0(text, "text");
		if (text.Data.Trim().Length == 0 && (text.PreviousSibling == null || text.NextSibling == null) && text.ParentNode != null && text.ParentNode.NodeType == Enum969.const_0)
		{
			Enum952 display = ((Class6983)text.ParentNode).Style.Display;
			if (display != 0 && display != Enum952.const_4)
			{
				return;
			}
		}
		IList words = interface360_0.imethod_0(text.Data);
		interface343_0.imethod_5(words);
	}

	public void imethod_20(Class7043 ul)
	{
		Class6892.smethod_0(ul, "ul");
		interface343_0.imethod_2(ul.Style, ul.TagName);
	}

	public void imethod_21(Class7043 ul)
	{
		interface343_0.imethod_3(ul.Style, ul.TagName);
	}

	public void imethod_22(Class7021 li)
	{
		interface343_0.imethod_2(li.Style, li.TagName);
	}

	public void imethod_23(Class7021 li)
	{
		interface343_0.imethod_3(li.Style, li.TagName);
	}

	public void imethod_24(Class7027 ol)
	{
		interface343_0.imethod_2(ol.Style, ol.TagName);
	}

	public void imethod_25(Class7027 ol)
	{
		interface343_0.imethod_3(ol.Style, ol.TagName);
	}

	public void imethod_26(Class6988 figure)
	{
		interface343_0.imethod_2(figure.Style, figure.TagName);
	}

	public void imethod_27(Class6988 figure)
	{
		interface343_0.imethod_3(figure.Style, figure.TagName);
	}

	public Interface325 imethod_28(Class6983 table)
	{
		interface343_0.imethod_2(table.Style, table.TagName);
		return this;
	}

	public void imethod_29(Class6983 table)
	{
		interface343_0.imethod_3(table.Style, table.TagName);
	}

	public void imethod_30(Class6983 tr)
	{
		interface343_0.imethod_2(tr.Style, tr.TagName);
	}

	public void imethod_31(Class6983 tr)
	{
		interface343_0.imethod_3(tr.Style, tr.TagName);
	}

	public void imethod_32(Class6983 td)
	{
		if (td is Class7038 @class)
		{
			td.Style.Colspan = @class.ColSpan;
			td.Style.Rowspan = @class.RowSpan;
		}
		interface343_0.imethod_2(td.Style, td.TagName);
	}

	public void imethod_33(Class6983 td)
	{
		interface343_0.imethod_3(td.Style, td.TagName);
	}

	public void imethod_34(Class6983 th)
	{
		if (th is Class7038 @class)
		{
			th.Style.Colspan = @class.ColSpan;
			th.Style.Rowspan = @class.RowSpan;
		}
		interface343_0.imethod_2(th.Style, th.TagName);
	}

	public void imethod_35(Class6983 th)
	{
		interface343_0.imethod_3(th.Style, th.TagName);
	}

	public void imethod_36(Class6983 tbody)
	{
	}

	public void imethod_37(Class6983 tbody)
	{
	}

	public void imethod_38(Class6983 thead)
	{
	}

	public void imethod_39(Class6983 thead)
	{
	}

	public void imethod_40(Class6983 tfoot)
	{
	}

	public void imethod_41(Class6983 tfoot)
	{
	}

	public void imethod_42(Class7039 col)
	{
	}

	public void imethod_43(Class7039 col)
	{
	}

	public void imethod_44(Class7037 caption)
	{
	}

	public void imethod_45(Class7037 caption)
	{
	}

	public void imethod_46(Class7017 img)
	{
		Class6892.smethod_0(img, "img");
		interface343_0.imethod_2(img.Style, img.TagName);
		interface343_0.imethod_3(img.Style, img.TagName);
	}

	public void imethod_47(Class6985 video)
	{
		Class6892.smethod_0(video, "video");
		interface343_0.imethod_2(video.Style, video.TagName);
		interface343_0.imethod_3(video.Style, video.TagName);
	}

	public void imethod_48(Class6984 audio)
	{
		Class6892.smethod_0(audio, "audio");
		interface343_0.imethod_2(audio.Style, audio.TagName);
		interface343_0.imethod_3(audio.Style, audio.TagName);
	}

	public void imethod_49(Class6986 svg)
	{
	}

	public void imethod_50(Class6987 embed)
	{
	}

	public void imethod_51(Class6994 obj)
	{
	}

	public bool imethod_52(Class6994 obj)
	{
		return false;
	}

	public void imethod_53(Class6994 obj)
	{
	}

	public void imethod_54(Class7016 iframe)
	{
	}

	public void imethod_55(Class7010 frame)
	{
	}

	public void imethod_56(Class7011 frameset)
	{
	}

	public void imethod_57(Class7011 frameset)
	{
	}

	public void imethod_58(Class6996 htmlA)
	{
		Interface356 hyperlink = new Class6957(htmlA);
		interface343_0.imethod_4(htmlA.Style, htmlA.Name, hyperlink);
	}

	public void imethod_59(Class6989 htmlTime)
	{
		interface343_0.imethod_2(htmlTime.Style, htmlTime.TagName);
	}

	public void imethod_60(Class6996 htmlA)
	{
		interface343_0.imethod_3(htmlA.Style, htmlA.TagName);
	}

	public void imethod_61(Class6989 htmlTime)
	{
		interface343_0.imethod_3(htmlTime.Style, htmlTime.TagName);
	}

	public void imethod_62(Class7034 script)
	{
	}

	public Interface325 imethod_63(Class7035 htmlSelect)
	{
		return null;
	}

	public void imethod_64(Class7035 htmlSelect, Interface325 optionsVisitor)
	{
	}

	public void imethod_65(Class7007 htmlFieldSet)
	{
	}

	public void imethod_66(Class7007 htmlFieldSet)
	{
	}

	public void imethod_67(Class7029 htmlOption)
	{
	}

	public void imethod_68(Class7029 htmlOption)
	{
	}

	public void imethod_69(Class7003 htmlButton)
	{
	}

	public void imethod_70(Class6995 button)
	{
	}

	public void imethod_71(Class6995 htmlCheckbox)
	{
	}

	public void imethod_72(Class6995 html5Range)
	{
	}

	public void imethod_73(Class6995 html5Tel)
	{
	}

	public void imethod_74(Class6995 html5Search)
	{
	}

	public void imethod_75(Class6995 html5Url)
	{
	}

	public void imethod_76(Class6995 html5Email)
	{
	}

	public void imethod_77(Class6995 html5Meter)
	{
	}

	public void imethod_78(Class6995 html5Progress)
	{
	}

	public void imethod_79(Class6995 html5Datetime)
	{
	}

	public void imethod_80(Class6995 html5Date)
	{
	}

	public void imethod_81(Class6995 html5Month)
	{
	}

	public void imethod_82(Class6995 html5Week)
	{
	}

	public void imethod_83(Class6995 html5Time)
	{
	}

	public void imethod_84(Class6995 html5DatetimeLocal)
	{
	}

	public void imethod_85(Class6995 html5Number)
	{
	}

	public void imethod_86(Class6995 html5Color)
	{
	}

	public void imethod_87(Class6995 htmlTextField)
	{
	}

	public void imethod_88(Class6995 htmlRadio)
	{
	}

	public Interface325 imethod_89(Class7042 htmlTextarea)
	{
		return null;
	}

	public void imethod_90(Class7042 htmlTextarea, Interface325 textareaVisitor)
	{
	}

	public void imethod_91(Class7006 htmlDl)
	{
	}

	public void imethod_92(Class7006 htmlDl)
	{
	}

	public void imethod_93(Class6983 htmlDd)
	{
	}

	public void imethod_94(Class6983 htmlDd)
	{
	}

	public void imethod_95(Class6983 htmlDt)
	{
	}

	public void imethod_96(Class6983 htmlDt)
	{
	}

	public void imethod_97(Class7024 htmlMenu)
	{
	}

	public void imethod_98(Class7024 htmlMenu)
	{
	}

	public void imethod_99(Class7004 htmlDir)
	{
	}

	public void imethod_100(Class7004 htmlDir)
	{
	}

	public void imethod_101(Class6999 baseElement)
	{
	}

	public object imethod_102()
	{
		return class6844_0;
	}

	public Class6844 method_1(Class7015 page)
	{
		page.vmethod_5(this);
		return class6844_0;
	}
}
