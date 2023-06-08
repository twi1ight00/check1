using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using ns16;
using ns25;
using ns56;

namespace ns17;

internal class Class923
{
	public static void smethod_0(IChart chart, Class2085 legendElementData, Class1341 deserializationContext)
	{
		if (legendElementData == null)
		{
			chart.HasLegend = false;
			return;
		}
		chart.HasLegend = true;
		ILegend legend = chart.Legend;
		smethod_1(legend, legendElementData);
		if (legendElementData.Overlay != null)
		{
			legend.Overlay = legendElementData.Overlay.Val;
		}
		else
		{
			bool flag = false;
			if (chart.Slide is Slide slide)
			{
				string string_ = ((DocumentProperties)slide.Presentation.DocumentProperties).string_15;
				if (string_ != null && string_ != string.Empty)
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
			}
			legend.Overlay = ((!flag) ? true : false);
		}
		if (legendElementData.LegendPos != null)
		{
			legend.Position = legendElementData.LegendPos.Val;
		}
		Class921.smethod_0(legend.Format, legendElementData.SpPr, deserializationContext);
		Class916.smethod_0(legend.TextFormat, legendElementData.TxPr, deserializationContext);
		Class2086[] legendEntryList = legendElementData.LegendEntryList;
		foreach (Class2086 @class in legendEntryList)
		{
			if (@class.Idx.Val < legend.Entries.Count)
			{
				ILegendEntryProperties legendEntryProperties = legend.Entries[(int)@class.Idx.Val];
				if (@class.Delete != null)
				{
					legendEntryProperties.Hide = ((Class2339)@class.Delete.Object).Val;
				}
				else
				{
					Class916.smethod_0(legendEntryProperties.TextFormat, @class.TxPr, deserializationContext);
				}
				((LegendEntryProperties)legendEntryProperties).PPTXUnsupportedProps.ExtensionList = @class.ExtLst;
			}
		}
	}

	private static void smethod_1(ILegend legend, Class2085 legendElementData)
	{
		Class317 pPTXUnsupportedProps = ((Legend)legend).PPTXUnsupportedProps;
		Class922.smethod_0(pPTXUnsupportedProps, legendElementData.Layout);
		pPTXUnsupportedProps.ExtensionList = legendElementData.ExtLst;
	}

	public static void smethod_2(IChart chart, Class2085.Delegate1970 addLegend, Class1346 serializationContext)
	{
		if (!chart.HasLegend)
		{
			return;
		}
		ILegend legend = chart.Legend;
		Class2085 @class = addLegend();
		@class.delegate2763_0().Val = legend.Overlay;
		@class.delegate1976_0().Val = legend.Position;
		Class921.smethod_1(legend.Format, @class.delegate1630_0, serializationContext);
		Class916.smethod_5(legend.TextFormat, @class.delegate1705_0, serializationContext);
		for (int i = 0; i < legend.Entries.Count; i++)
		{
			ILegendEntryProperties legendEntryProperties = legend.Entries[i];
			if (legendEntryProperties.Hide || Class916.smethod_10(legendEntryProperties.TextFormat) || ((LegendEntryProperties)legendEntryProperties).PPTXUnsupportedProps.ExtensionList != null)
			{
				Class2086 class2 = @class.delegate1973_0();
				class2.Idx.Val = (uint)i;
				if (legendEntryProperties.Hide)
				{
					class2.delegate2773_0("delete");
				}
				else
				{
					Class916.smethod_5(legendEntryProperties.TextFormat, class2.delegate1705_0, serializationContext);
				}
				class2.delegate1535_0(((LegendEntryProperties)legendEntryProperties).PPTXUnsupportedProps.ExtensionList);
			}
		}
		smethod_3(legend, @class);
	}

	private static void smethod_3(ILegend legend, Class2085 legendElementData)
	{
		Class317 pPTXUnsupportedProps = ((Legend)legend).PPTXUnsupportedProps;
		Class922.smethod_1(pPTXUnsupportedProps, legendElementData.delegate1955_0);
		pPTXUnsupportedProps.ExtensionList = legendElementData.ExtLst;
	}
}
