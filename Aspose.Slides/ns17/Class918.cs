using Aspose.Slides;
using Aspose.Slides.Charts;
using ns16;
using ns25;
using ns56;

namespace ns17;

internal class Class918
{
	public static void smethod_0(IDataLabelCollection dataLabels, Class2069 dLblsElementData, Class1341 deserializationContext)
	{
		if (dLblsElementData == null)
		{
			return;
		}
		Class321 pPTXUnsupportedProps = ((DataLabelCollection)dataLabels).PPTXUnsupportedProps;
		if (dLblsElementData.Delete != null && ((Class2339)dLblsElementData.Delete.Object).Val)
		{
			dataLabels.Hide();
		}
		if (dLblsElementData.NumFmt != null)
		{
			dataLabels.DefaultDataLabelFormat.NumberFormat = dLblsElementData.NumFmt.FormatCode;
			dataLabels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = dLblsElementData.NumFmt.SourceLinked == NullableBool.True;
		}
		if (dLblsElementData.SpPr != null)
		{
			Class921.smethod_0(dataLabels.DefaultDataLabelFormat.Format, dLblsElementData.SpPr, deserializationContext);
		}
		if (dLblsElementData.TxPr != null)
		{
			Class916.smethod_0(dataLabels.DefaultDataLabelFormat.TextFormat, dLblsElementData.TxPr, deserializationContext);
		}
		if (dLblsElementData.DLblPos != null)
		{
			dataLabels.DefaultDataLabelFormat.Position = dLblsElementData.DLblPos.Val;
		}
		if (dLblsElementData.ShowLegendKey != null)
		{
			dataLabels.DefaultDataLabelFormat.ShowLegendKey = dLblsElementData.ShowLegendKey.Val;
		}
		if (dLblsElementData.ShowVal != null)
		{
			dataLabels.DefaultDataLabelFormat.ShowValue = dLblsElementData.ShowVal.Val;
		}
		if (dLblsElementData.ShowCatName != null)
		{
			dataLabels.DefaultDataLabelFormat.ShowCategoryName = dLblsElementData.ShowCatName.Val;
		}
		if (dLblsElementData.ShowSerName != null)
		{
			dataLabels.DefaultDataLabelFormat.ShowSeriesName = dLblsElementData.ShowSerName.Val;
		}
		if (dLblsElementData.ShowPercent != null)
		{
			dataLabels.DefaultDataLabelFormat.ShowPercentage = dLblsElementData.ShowPercent.Val;
		}
		if (dLblsElementData.ShowBubbleSize != null)
		{
			dataLabels.DefaultDataLabelFormat.ShowBubbleSize = dLblsElementData.ShowBubbleSize.Val;
		}
		if (dLblsElementData.ShowLeaderLines != null)
		{
			dataLabels.DefaultDataLabelFormat.ShowLeaderLines = dLblsElementData.ShowLeaderLines.Val;
		}
		if (dLblsElementData.LeaderLines != null)
		{
			Class921.smethod_0(pPTXUnsupportedProps.LeaderLinesFormat, dLblsElementData.LeaderLines.SpPr, deserializationContext);
		}
		if (dLblsElementData.Separator != null)
		{
			dataLabels.DefaultDataLabelFormat.Separator = dLblsElementData.Separator;
		}
		pPTXUnsupportedProps.ExtensionList = dLblsElementData.ExtLst;
		if (dLblsElementData.DLblList != null)
		{
			Class2067[] dLblList = dLblsElementData.DLblList;
			foreach (Class2067 @class in dLblList)
			{
				IDataLabel label = dataLabels.ParentSeries.DataPoints.GetOrCreateDataPointByIdx(@class.Idx.Val).Label;
				Class917.smethod_0(label, @class, deserializationContext);
			}
		}
	}

	public static void smethod_1(IDataLabelCollection dataLabels, Class2069.Delegate1920 addDLbls, Class1346 serializationContext)
	{
		if (addDLbls != null && smethod_2(dataLabels))
		{
			Class2069 @class = addDLbls();
			Class321 pPTXUnsupportedProps = ((DataLabelCollection)dataLabels).PPTXUnsupportedProps;
			IDataLabelFormat defaultDataLabelFormat = dataLabels.DefaultDataLabelFormat;
			@class.delegate2763_0().Val = defaultDataLabelFormat.ShowLegendKey;
			@class.delegate2763_1().Val = defaultDataLabelFormat.ShowValue;
			@class.delegate2763_2().Val = defaultDataLabelFormat.ShowCategoryName;
			@class.delegate2763_3().Val = defaultDataLabelFormat.ShowSeriesName;
			@class.delegate2763_4().Val = defaultDataLabelFormat.ShowPercentage;
			@class.delegate2763_5().Val = defaultDataLabelFormat.ShowBubbleSize;
			@class.delegate2763_6().Val = defaultDataLabelFormat.ShowLeaderLines;
			if (Class921.smethod_2(pPTXUnsupportedProps.LeaderLinesFormat))
			{
				Class921.smethod_1(pPTXUnsupportedProps.LeaderLinesFormat, @class.delegate1889_0().delegate1630_0, serializationContext);
			}
			if (defaultDataLabelFormat.Separator != "")
			{
				@class.Separator = defaultDataLabelFormat.Separator;
			}
			if (defaultDataLabelFormat.Position != LegendDataLabelPosition.NotDefined)
			{
				@class.delegate1917_0().Val = defaultDataLabelFormat.Position;
			}
			Class921.smethod_1(dataLabels.DefaultDataLabelFormat.Format, @class.delegate1630_0, serializationContext);
			Class916.smethod_5(dataLabels.DefaultDataLabelFormat.TextFormat, @class.delegate1705_0, serializationContext);
			if (defaultDataLabelFormat.NumberFormat != "")
			{
				Class2097 class2 = @class.delegate2009_0();
				class2.FormatCode = defaultDataLabelFormat.NumberFormat;
				class2.SourceLinked = (defaultDataLabelFormat.IsNumberFormatLinkedToSource ? NullableBool.True : NullableBool.False);
			}
			if (@class.Separator == null && @class.DLblPos == null && @class.SpPr == null && @class.TxPr == null && @class.NumFmt == null && !dataLabels.IsVisible)
			{
				Class2339 class3 = (Class2339)@class.delegate2773_0("delete").Object;
				class3.Val = true;
				@class.delegate2764_0(null);
				@class.delegate2764_1(null);
				@class.delegate2764_2(null);
				@class.delegate2764_3(null);
				@class.delegate2764_4(null);
				@class.delegate2764_5(null);
				@class.delegate2764_6(null);
			}
			@class.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
			for (int i = 0; i < dataLabels.Count; i++)
			{
				Class917.smethod_2(dataLabels[i], @class.delegate1914_0, (uint)i, dataLabels.DefaultDataLabelFormat, serializationContext);
			}
		}
	}

	internal static bool smethod_2(IDataLabelCollection dataLabels)
	{
		bool flag = false;
		foreach (IDataLabel dataLabel in dataLabels)
		{
			if (Class917.smethod_3(dataLabel, dataLabels.DefaultDataLabelFormat))
			{
				flag = true;
				break;
			}
		}
		IDataLabelFormat defaultDataLabelFormat = dataLabels.DefaultDataLabelFormat;
		if (!flag && !defaultDataLabelFormat.ShowBubbleSize && !defaultDataLabelFormat.ShowCategoryName && !defaultDataLabelFormat.ShowLegendKey && !defaultDataLabelFormat.ShowPercentage && !defaultDataLabelFormat.ShowSeriesName && !defaultDataLabelFormat.ShowValue)
		{
			return defaultDataLabelFormat.ShowLeaderLines;
		}
		return true;
	}
}
