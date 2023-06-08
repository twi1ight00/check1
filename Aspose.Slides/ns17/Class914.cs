using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using ns16;
using ns25;
using ns56;

namespace ns17;

internal class Class914
{
	public static void smethod_0(IChartTitle title, Class2128 titleElementData, Class1341 deserializationContext)
	{
		if (titleElementData == null)
		{
			return;
		}
		Class314 pPTXUnsupportedProps = ((ChartTitle)title).PPTXUnsupportedProps;
		bool flag = false;
		string string_ = ((DocumentProperties)deserializationContext.Presentation.DocumentProperties).string_15;
		if (!string.IsNullOrEmpty(string_))
		{
			string[] array = string_.Split('.');
			if (array.Length > 0)
			{
				try
				{
					int num = int.Parse(array[0]);
					if (num <= 12)
					{
						flag = true;
					}
				}
				catch (FormatException)
				{
				}
			}
		}
		title.Overlay = ((titleElementData.Overlay == null) ? (!flag) : titleElementData.Overlay.Val);
		Class921.smethod_0(title.Format, titleElementData.SpPr, deserializationContext);
		Class922.smethod_0(pPTXUnsupportedProps, titleElementData.Layout);
		Class925.smethod_0(title, titleElementData.Tx, titleElementData.TxPr, deserializationContext);
		pPTXUnsupportedProps.ExtensionList = titleElementData.ExtLst;
	}

	public static void smethod_1(IChartTitle title, Class2128.Delegate2115 addTitle, Class1346 serializationContext)
	{
		Class2128 @class = addTitle();
		Class314 pPTXUnsupportedProps = ((ChartTitle)title).PPTXUnsupportedProps;
		@class.delegate2763_0().Val = title.Overlay;
		Class921.smethod_1(title.Format, @class.delegate1630_0, serializationContext);
		Class922.smethod_1(pPTXUnsupportedProps, @class.delegate1955_0);
		if (title.TextFrameForOverriding != null)
		{
			foreach (IParagraph paragraph in title.TextFrameForOverriding.Paragraphs)
			{
				((ParagraphFormat)paragraph.ParagraphFormat).PPTXUnsupportedProps.SaveAsEmptyElement = true;
			}
		}
		Class925.smethod_1(title, @class.delegate2133_0, @class.delegate1705_0, serializationContext);
		@class.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
	}
}
