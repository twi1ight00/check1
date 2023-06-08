using Aspose.Slides;
using Aspose.Slides.Charts;
using ns16;
using ns25;
using ns56;

namespace ns17;

internal class Class917
{
	public static void smethod_0(IDataLabel dataLabel, Class2067 dLblElementData, Class1341 deserializationContext)
	{
		if (dLblElementData != null)
		{
			smethod_1(dataLabel, dLblElementData, deserializationContext);
			if (dLblElementData.Delete != null && ((Class2339)dLblElementData.Delete.Object).Val)
			{
				dataLabel.Hide();
			}
			if (dLblElementData.NumFmt != null)
			{
				dataLabel.DataLabelFormat.NumberFormat = dLblElementData.NumFmt.FormatCode;
				dataLabel.DataLabelFormat.IsNumberFormatLinkedToSource = dLblElementData.NumFmt.SourceLinked == NullableBool.True;
			}
			if (dLblElementData.SpPr != null)
			{
				Class921.smethod_0(dataLabel.DataLabelFormat.Format, dLblElementData.SpPr, deserializationContext);
			}
			if (dLblElementData.DLblPos != null)
			{
				dataLabel.DataLabelFormat.Position = dLblElementData.DLblPos.Val;
			}
			if (dLblElementData.ShowLegendKey != null)
			{
				dataLabel.DataLabelFormat.ShowLegendKey = dLblElementData.ShowLegendKey.Val;
			}
			if (dLblElementData.ShowVal != null)
			{
				dataLabel.DataLabelFormat.ShowValue = dLblElementData.ShowVal.Val;
			}
			if (dLblElementData.ShowCatName != null)
			{
				dataLabel.DataLabelFormat.ShowCategoryName = dLblElementData.ShowCatName.Val;
			}
			if (dLblElementData.ShowSerName != null)
			{
				dataLabel.DataLabelFormat.ShowSeriesName = dLblElementData.ShowSerName.Val;
			}
			if (dLblElementData.ShowPercent != null)
			{
				dataLabel.DataLabelFormat.ShowPercentage = dLblElementData.ShowPercent.Val;
			}
			if (dLblElementData.ShowBubbleSize != null)
			{
				dataLabel.DataLabelFormat.ShowBubbleSize = dLblElementData.ShowBubbleSize.Val;
			}
			if (dLblElementData.Separator != null)
			{
				dataLabel.DataLabelFormat.Separator = dLblElementData.Separator;
			}
		}
	}

	private static void smethod_1(IDataLabel dataLabel, Class2067 dLblElementData, Class1341 deserializationContext)
	{
		Class315 pPTXUnsupportedProps = ((DataLabel)dataLabel).PPTXUnsupportedProps;
		if (dLblElementData.Layout != null)
		{
			Class922.smethod_0(pPTXUnsupportedProps, dLblElementData.Layout);
		}
		Class925.smethod_0(dataLabel, dLblElementData.Tx, dLblElementData.TxPr, deserializationContext);
		pPTXUnsupportedProps.ExtensionList = dLblElementData.ExtLst;
	}

	public static void smethod_2(IDataLabel dataLabel, Class2067.Delegate1914 addDLbl, uint idx, IDataLabelFormat dataLabelFormat, Class1346 serializationContext)
	{
		if (!smethod_3(dataLabel, dataLabelFormat))
		{
			return;
		}
		Class2067 @class = addDLbl();
		Class315 pPTXUnsupportedProps = ((DataLabel)dataLabel).PPTXUnsupportedProps;
		@class.Idx.Val = idx;
		if ((dataLabel.DataLabelFormat.NumberFormat != "" || !dataLabel.DataLabelFormat.IsNumberFormatLinkedToSource) && (dataLabel.DataLabelFormat.NumberFormat != ((DataLabel)dataLabel).ParentSeries.Labels.DefaultDataLabelFormat.NumberFormat || dataLabel.DataLabelFormat.IsNumberFormatLinkedToSource != ((DataLabel)dataLabel).ParentSeries.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource))
		{
			@class.delegate2009_0().FormatCode = dataLabel.DataLabelFormat.NumberFormat;
			@class.NumFmt.SourceLinked = (dataLabel.DataLabelFormat.IsNumberFormatLinkedToSource ? NullableBool.True : NullableBool.False);
		}
		Class921.smethod_1(dataLabel.DataLabelFormat.Format, @class.delegate1630_0, serializationContext);
		if (dataLabel.DataLabelFormat.Position != LegendDataLabelPosition.NotDefined)
		{
			@class.delegate1917_0().Val = dataLabel.DataLabelFormat.Position;
		}
		@class.delegate2763_0().Val = dataLabel.DataLabelFormat.ShowLegendKey;
		@class.delegate2763_1().Val = dataLabel.DataLabelFormat.ShowValue;
		@class.delegate2763_2().Val = dataLabel.DataLabelFormat.ShowCategoryName;
		@class.delegate2763_3().Val = dataLabel.DataLabelFormat.ShowSeriesName;
		@class.delegate2763_4().Val = dataLabel.DataLabelFormat.ShowPercentage;
		@class.delegate2763_5().Val = dataLabel.DataLabelFormat.ShowBubbleSize;
		if (dataLabel.DataLabelFormat.Separator != "")
		{
			@class.Separator = dataLabel.DataLabelFormat.Separator;
		}
		Class922.smethod_1(pPTXUnsupportedProps, @class.delegate1955_0);
		if (dataLabel.TextFrameForOverriding != null)
		{
			foreach (IParagraph paragraph in dataLabel.TextFrameForOverriding.Paragraphs)
			{
				((ParagraphFormat)paragraph.ParagraphFormat).PPTXUnsupportedProps.SaveAsEmptyElement = true;
			}
		}
		Class925.smethod_1(dataLabel, @class.delegate2133_0, @class.delegate1705_0, serializationContext);
		if (@class.NumFmt == null && @class.SpPr == null && @class.DLblPos == null && @class.Separator == null && @class.Layout == null && @class.Tx == null && !dataLabel.IsVisible)
		{
			@class.delegate2773_0("delete");
			@class.delegate2764_0(null);
			@class.delegate2764_1(null);
			@class.delegate2764_2(null);
			@class.delegate2764_3(null);
			@class.delegate2764_4(null);
			@class.delegate2764_5(null);
		}
		@class.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
	}

	internal static bool smethod_3(IDataLabel dataLabel, IDataLabelFormat dataLabelFormat)
	{
		Class315 pPTXUnsupportedProps = ((DataLabel)dataLabel).PPTXUnsupportedProps;
		if (dataLabel.DataLabelFormat.Format.Effect.Equals(dataLabelFormat.Format.Effect) && dataLabel.DataLabelFormat.Format.Effect3D.Equals(dataLabelFormat.Format.Effect3D) && dataLabel.DataLabelFormat.Format.Fill.Equals(dataLabelFormat.Format.Fill) && dataLabel.DataLabelFormat.Format.Line.Equals(dataLabelFormat.Format.Line) && !Class922.smethod_2(pPTXUnsupportedProps) && dataLabel.DataLabelFormat.IsNumberFormatLinkedToSource == dataLabelFormat.IsNumberFormatLinkedToSource && !(dataLabel.DataLabelFormat.NumberFormat != dataLabelFormat.NumberFormat) && dataLabel.DataLabelFormat.Position == dataLabelFormat.Position && !(dataLabel.DataLabelFormat.Separator != dataLabelFormat.Separator) && dataLabel.DataLabelFormat.ShowBubbleSize == dataLabelFormat.ShowBubbleSize && dataLabel.DataLabelFormat.ShowCategoryName == dataLabelFormat.ShowCategoryName && dataLabel.DataLabelFormat.ShowLegendKey == dataLabelFormat.ShowLegendKey && dataLabel.DataLabelFormat.ShowPercentage == dataLabelFormat.ShowPercentage && dataLabel.DataLabelFormat.ShowSeriesName == dataLabelFormat.ShowSeriesName && dataLabel.DataLabelFormat.ShowValue == dataLabelFormat.ShowValue && !Class916.smethod_10(dataLabel.TextFormat))
		{
			return Class925.smethod_2(dataLabel);
		}
		return true;
	}
}
