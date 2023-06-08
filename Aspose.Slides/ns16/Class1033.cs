using System;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using ns18;
using ns26;
using ns53;
using ns55;

namespace ns16;

internal class Class1033
{
	private static Class524 class524_0;

	private static Class527 class527_0;

	private static Class530 class530_0;

	private static Class526 class526_0;

	public void method_0(ISmartArt smartArt, SmartArtLayoutType layoutType)
	{
		Class1184 @class = new Class1184();
		Class1341 deserializationContext = new Class1341(smartArt.Presentation);
		Class290 pPTXUnsupportedProps = ((SmartArt)smartArt).PPTXUnsupportedProps;
		Class523 class2 = class524_0[layoutType];
		if (class2 == null)
		{
			throw new Exception("SmartArt data model not implement.");
		}
		pPTXUnsupportedProps.DataModelElementData = null;
		Class1342 part = @class.method_5("/ppt/diagrams/tempDataPart.xml", null, new Class1231(), Encoding.UTF8.GetBytes(class2.string_0));
		Class1202 class3 = new Class1202(part, deserializationContext);
		class3.method_5(pPTXUnsupportedProps);
	}

	public void method_1(ISmartArt smartArt, SmartArtLayoutType layoutType)
	{
		Class1184 @class = new Class1184();
		Class1341 deserializationContext = new Class1341(smartArt.Presentation);
		Class290 pPTXUnsupportedProps = ((SmartArt)smartArt).PPTXUnsupportedProps;
		string text = class527_0[layoutType];
		if (text == null)
		{
			throw new PptxException($"SmartArt layout model for type {layoutType} is not implement");
		}
		string s = string.Format(text, "a", "r", "dgm");
		pPTXUnsupportedProps.LayoutDefElementData = null;
		Class1342 part = @class.method_5("/ppt/diagrams/tempLayoutPart.xml", null, new Class1232(), Encoding.UTF8.GetBytes(s));
		Class1204 class2 = new Class1204(part, deserializationContext);
		class2.method_5(pPTXUnsupportedProps);
	}

	public void method_2(ISmartArt smartArt, SmartArtQuickStyleType quickStyleType)
	{
		Class1184 @class = new Class1184();
		Class1341 deserializationContext = new Class1341(smartArt.Presentation);
		Class290 pPTXUnsupportedProps = ((SmartArt)smartArt).PPTXUnsupportedProps;
		Class529 class2 = class530_0[quickStyleType];
		string s = string.Format(class2.string_2, "a", "r", "dgm");
		pPTXUnsupportedProps.DocNodePtElementData.PrSet.QsTypeId = class2.string_1;
		pPTXUnsupportedProps.DocNodePtElementData.PrSet.QsCatId = class2.string_0;
		pPTXUnsupportedProps.StyleDefElementData = null;
		Class1342 part = @class.method_5("/ppt/diagrams/tempQuickStylePart.xml", null, new Class1233(), Encoding.UTF8.GetBytes(s));
		Class1205 class3 = new Class1205(part, deserializationContext);
		class3.method_5(pPTXUnsupportedProps);
	}

	public void method_3(ISmartArt smartArt, SmartArtColorType colorType)
	{
		Class1184 @class = new Class1184();
		Class1341 deserializationContext = new Class1341(smartArt.Presentation);
		Class290 pPTXUnsupportedProps = ((SmartArt)smartArt).PPTXUnsupportedProps;
		Class525 class2 = class526_0[colorType];
		string s = string.Format(class2.string_2, "a", "r", "dgm");
		pPTXUnsupportedProps.DocNodePtElementData.PrSet.CsTypeId = class2.string_1;
		pPTXUnsupportedProps.DocNodePtElementData.PrSet.CsCatId = class2.string_0;
		pPTXUnsupportedProps.ColorsDefElementData = null;
		Class1342 part = @class.method_5("/ppt/diagrams/tempColorsPart.xml", null, new Class1230(), Encoding.UTF8.GetBytes(s));
		Class1201 class3 = new Class1201(part, deserializationContext);
		class3.method_5(pPTXUnsupportedProps);
	}

	public static SmartArtLayoutType smethod_0(string id)
	{
		return class527_0.method_0(id);
	}

	public static SmartArtQuickStyleType smethod_1(string id)
	{
		Class529 @class = class530_0.method_0(id);
		if (@class == null)
		{
			@class = class530_0[0];
		}
		return @class.Type;
	}

	public static string smethod_2(SmartArtQuickStyleType quickStyleType)
	{
		Class529 @class = class530_0[quickStyleType];
		if (@class == null)
		{
			@class = class530_0[0];
		}
		return @class.string_1;
	}

	public static SmartArtColorType smethod_3(string id)
	{
		Class525 @class = class526_0.method_0(id);
		if (@class == null)
		{
			@class = class526_0[0];
		}
		return @class.Type;
	}

	public static string smethod_4(SmartArtColorType colorType)
	{
		Class525 @class = class526_0[colorType];
		if (@class == null)
		{
			@class = class526_0[0];
		}
		return @class.string_1;
	}

	static Class1033()
	{
		class524_0 = new Class524();
		class527_0 = new Class527();
		class530_0 = new Class530();
		class526_0 = new Class526();
	}
}
