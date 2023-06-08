using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using ns16;
using ns25;
using ns56;

namespace ns17;

internal class Class905
{
	public static void smethod_0(IAxis axis, Class2053 axisElementData, Class892 chartPartDeserializationContext)
	{
		if (axisElementData == null)
		{
			return;
		}
		Class1341 deserializationContext = chartPartDeserializationContext.SlideDeserializationContext.DeserializationContext;
		smethod_1(axis, axisElementData, deserializationContext);
		if (axisElementData.Scaling.Max != null)
		{
			axis.IsAutomaticMaxValue = false;
			axis.MaxValue = axisElementData.Scaling.Max.Val;
		}
		if (axisElementData.Scaling.Min != null)
		{
			axis.IsAutomaticMinValue = false;
			axis.MinValue = axisElementData.Scaling.Min.Val;
		}
		if (axisElementData.Scaling.LogBase != null)
		{
			axis.IsLogarithmic = true;
			axis.LogBase = axisElementData.Scaling.LogBase.Val;
		}
		if (axisElementData.Scaling.Orientation != null)
		{
			axis.IsPlotOrderReversed = axisElementData.Scaling.Orientation.Val == Enum321.const_1;
		}
		axis.IsVisible = axisElementData.Delete == null || !axisElementData.Delete.Val;
		axis.Position = axisElementData.AxPos.Val;
		Class909.smethod_0(axis.MajorGridLinesFormat, axisElementData.MajorGridlines, deserializationContext);
		Class909.smethod_0(axis.MinorGridLinesFormat, axisElementData.MinorGridlines, deserializationContext);
		Class914.smethod_0(axis.Title, axisElementData.Title, deserializationContext);
		axis.HasTitle = axisElementData.Title != null;
		if (axisElementData.NumFmt != null)
		{
			axis.IsNumberFormatLinkedToSource = axisElementData.NumFmt.SourceLinked != NullableBool.False;
			axis.NumberFormat = axisElementData.NumFmt.FormatCode;
		}
		if (axisElementData.MajorTickMark != null)
		{
			axis.MajorTickMark = axisElementData.MajorTickMark.Val;
		}
		if (axisElementData.MinorTickMark != null)
		{
			axis.MinorTickMark = axisElementData.MinorTickMark.Val;
		}
		if (axisElementData.TickLblPos != null)
		{
			axis.TickLabelPosition = axisElementData.TickLblPos.Val;
		}
		Class904.smethod_0(axis.Format, axisElementData.SpPr, deserializationContext);
		Class916.smethod_0(axis.TextFormat, axisElementData.TxPr, deserializationContext);
		Class2106 plotAreaElementData = chartPartDeserializationContext.PlotAreaElementData;
		Class2605[] axisList = plotAreaElementData.AxisList;
		foreach (Class2605 @class in axisList)
		{
			Class2053 class2 = (Class2053)@class.Object;
			if (class2.AxId.Val == axisElementData.CrossAx.Val && class2.Crossing != null)
			{
				switch (class2.Crossing.Name)
				{
				case "crossesAt":
				{
					Class2070 class4 = (Class2070)class2.Crossing.Object;
					axis.CrossType = CrossesType.Custom;
					axis.CrossAt = (float)class4.Val;
					break;
				}
				case "crosses":
				{
					Class2061 class3 = (Class2061)class2.Crossing.Object;
					axis.CrossType = class3.Val;
					break;
				}
				default:
					throw new Exception("Unknown element \"" + class2.Crossing.Name + "\"");
				}
			}
		}
		((Axis)axis).PPTXUnsupportedProps.CrossAxId = axisElementData.CrossAx.Val;
		if (axisElementData.BaseTimeUnit != null)
		{
			axis.BaseUnitScale = axisElementData.BaseTimeUnit.Val;
		}
		if (axisElementData.MajorUnit != null)
		{
			axis.IsAutomaticMajorUnit = axisElementData.MajorUnit.Val == 0.0;
			axis.MajorUnit = axisElementData.MajorUnit.Val;
		}
		if (axisElementData.MajorTimeUnit != null)
		{
			axis.MajorUnitScale = axisElementData.MajorTimeUnit.Val;
		}
		if (axisElementData.MinorUnit != null)
		{
			axis.IsAutomaticMinorUnit = axisElementData.MinorUnit.Val == 0.0;
			axis.MinorUnit = axisElementData.MinorUnit.Val;
		}
		if (axisElementData.MinorTimeUnit != null)
		{
			axis.MinorUnitScale = axisElementData.MinorTimeUnit.Val;
		}
		if (axisElementData.TickLblSkip != null)
		{
			axis.TickLabelSpacing = axisElementData.TickLblSkip.Val;
			axis.IsAutomaticTickLabelSpacing = false;
		}
	}

	private static void smethod_1(IAxis axis, Class2053 axisElementData, Class1341 deserializationContext)
	{
		Class307 pPTXUnsupportedProps = ((Axis)axis).PPTXUnsupportedProps;
		if (axisElementData.DispUnits != null)
		{
			switch (axisElementData.DispUnits.DisplayUnit.Name)
			{
			case "builtInUnit":
			{
				Class2052 class2 = (Class2052)axisElementData.DispUnits.DisplayUnit.Object;
				axis.DisplayUnit = class2.Val;
				break;
			}
			case "custUnit":
			{
				Class2070 @class = (Class2070)axisElementData.DispUnits.DisplayUnit.Object;
				axis.DisplayUnit = DisplayUnitType.CustomValue;
				pPTXUnsupportedProps.DisplayUnitCustomValue = @class.Val;
				break;
			}
			default:
				throw new Exception("Unknown element \"" + axisElementData.DispUnits.DisplayUnit.Name + "\"");
			}
			Class920.smethod_0(((Axis)axis).DisplayUnitLabel, axisElementData.DispUnits.DispUnitsLbl, deserializationContext);
			pPTXUnsupportedProps.ExtensionListOfDispUnits = axisElementData.DispUnits.ExtLst;
		}
		pPTXUnsupportedProps.ExtensionListOfScaling = axisElementData.Scaling.ExtLst;
		if (axisElementData.Auto != null)
		{
			pPTXUnsupportedProps.Auto = axisElementData.Auto.Val;
		}
		if (axisElementData is Class2054)
		{
			pPTXUnsupportedProps.CategoryAxisType = Enum267.const_1;
		}
		else if (axisElementData is Class2055)
		{
			pPTXUnsupportedProps.CategoryAxisType = Enum267.const_2;
		}
		if (axisElementData.LblAlgn != null)
		{
			pPTXUnsupportedProps.LabelAlignment = axisElementData.LblAlgn.Val;
		}
		if (axisElementData.LblOffset != null)
		{
			pPTXUnsupportedProps.LabelOffset = axisElementData.LblOffset.Val;
		}
		if (axisElementData.TickMarkSkip != null)
		{
			pPTXUnsupportedProps.TickMarksToSkip = axisElementData.TickMarkSkip.Val;
		}
		if (axisElementData.NoMultiLvlLbl != null)
		{
			pPTXUnsupportedProps.NoMultiLevelLabels = axisElementData.NoMultiLvlLbl.Val;
		}
		if (axisElementData.CrossBetween != null)
		{
			pPTXUnsupportedProps.CrossBetween = axisElementData.CrossBetween.Val;
		}
		pPTXUnsupportedProps.AxisId = axisElementData.AxId.Val;
		pPTXUnsupportedProps.ExtensionList = axisElementData.ExtLst;
	}

	public static void smethod_2(IAxis axis, Class2053 axisElementData, Class1346 serializationContext)
	{
		if (axis == null)
		{
			return;
		}
		axisElementData.Scaling.delegate2025_0().Val = (axis.IsPlotOrderReversed ? Enum321.const_1 : Enum321.const_2);
		if (!axis.IsAutomaticMaxValue)
		{
			axisElementData.Scaling.delegate1923_0().Val = axis.MaxValue;
		}
		if (!axis.IsAutomaticMinValue)
		{
			axisElementData.Scaling.delegate1923_1().Val = axis.MinValue;
		}
		if (axis.IsLogarithmic)
		{
			axisElementData.Scaling.delegate1982_0().Val = axis.LogBase;
		}
		axisElementData.delegate2763_0().Val = !axis.IsVisible;
		axisElementData.AxPos.Val = axis.Position;
		if (axis.ShowMajorGridLines)
		{
			Class909.smethod_1(axis.MajorGridLinesFormat, axisElementData.delegate1889_0(), serializationContext);
		}
		if (axis.ShowMinorGridLines)
		{
			Class909.smethod_1(axis.MinorGridLinesFormat, axisElementData.delegate1889_1(), serializationContext);
		}
		if (axis.HasTitle)
		{
			Class914.smethod_1(axis.Title, axisElementData.delegate2115_0, serializationContext);
		}
		if (axis.NumberFormat.Trim() != "")
		{
			Class2097 @class = axisElementData.delegate2009_0();
			@class.SourceLinked = (axis.IsNumberFormatLinkedToSource ? NullableBool.True : NullableBool.False);
			@class.FormatCode = axis.NumberFormat;
		}
		if (axis.MajorTickMark != 0)
		{
			axisElementData.delegate2109_0().Val = axis.MajorTickMark;
		}
		if (axis.MinorTickMark != 0)
		{
			axisElementData.delegate2109_1().Val = axis.MinorTickMark;
		}
		if (axis.TickLabelPosition != TickLabelPositionType.NextTo)
		{
			axisElementData.delegate2106_0().Val = axis.TickLabelPosition;
		}
		if (axisElementData.delegate2078_0 != null && !axis.IsAutomaticTickLabelSpacing)
		{
			axisElementData.delegate2078_0().Val = (ushort)axis.TickLabelSpacing;
		}
		Class904.smethod_2(axis.Format, axisElementData.delegate1630_0, serializationContext);
		Class916.smethod_5(axis.TextFormat, axisElementData.delegate1705_0, serializationContext);
		if (axisElementData is Class2055)
		{
			Class2055 class2 = (Class2055)axisElementData;
			if (!axis.IsAutomaticMajorUnit)
			{
				if (axis.MajorUnitScale != 0)
				{
					class2.delegate2112_1().Val = axis.MajorUnitScale;
				}
				class2.delegate1859_0().Val = axis.MajorUnit;
			}
			if (!axis.IsAutomaticMinorUnit)
			{
				if (axis.MinorUnitScale != 0)
				{
					class2.delegate2112_2().Val = axis.MinorUnitScale;
				}
				class2.delegate1859_1().Val = axis.MinorUnit;
			}
			if (axis.BaseUnitScale != 0)
			{
				class2.delegate2112_0().Val = axis.BaseUnitScale;
			}
		}
		if (axisElementData is Class2057)
		{
			Class2057 class3 = (Class2057)axisElementData;
			if (!axis.IsAutomaticMajorUnit)
			{
				class3.delegate1859_0().Val = axis.MajorUnit;
			}
			if (!axis.IsAutomaticMinorUnit)
			{
				class3.delegate1859_1().Val = axis.MinorUnit;
			}
		}
		smethod_3(axis, axisElementData, serializationContext);
	}

	private static void smethod_3(IAxis axis, Class2053 axisElementData, Class1346 serializationContext)
	{
		Class307 pPTXUnsupportedProps = ((Axis)axis).PPTXUnsupportedProps;
		axisElementData.CrossAx.Val = pPTXUnsupportedProps.CrossAxId;
		if (axisElementData is Class2057)
		{
			Class2057 @class = (Class2057)axisElementData;
			if (axis.DisplayUnit != 0)
			{
				@class.delegate1908_0();
				if (axis.DisplayUnit == DisplayUnitType.CustomValue)
				{
					Class2070 class2 = (Class2070)@class.DispUnits.delegate2773_0("custUnit").Object;
					class2.Val = pPTXUnsupportedProps.DisplayUnitCustomValue;
				}
				else
				{
					Class2052 class3 = (Class2052)@class.DispUnits.delegate2773_0("builtInUnit").Object;
					class3.Val = axis.DisplayUnit;
				}
				Class920.smethod_1(((Axis)axis).DisplayUnitLabel, @class.DispUnits.delegate1911_0, serializationContext);
				@class.DispUnits.delegate1535_0(pPTXUnsupportedProps.ExtensionListOfDispUnits);
			}
			if (pPTXUnsupportedProps.CrossBetween != Enum268.const_0)
			{
				@class.delegate1892_0().Val = pPTXUnsupportedProps.CrossBetween;
			}
		}
		else if (axisElementData is Class2054)
		{
			Class2054 class4 = (Class2054)axisElementData;
			if (pPTXUnsupportedProps.LabelAlignment != Enum269.const_0)
			{
				class4.delegate1964_0().Val = pPTXUnsupportedProps.LabelAlignment;
			}
			class4.delegate1967_0().Val = pPTXUnsupportedProps.LabelOffset;
			class4.delegate2763_2().Val = pPTXUnsupportedProps.NoMultiLevelLabels;
		}
		else if (axisElementData is Class2055)
		{
			Class2055 class5 = (Class2055)axisElementData;
			class5.delegate1967_0().Val = pPTXUnsupportedProps.LabelOffset;
		}
		if (axisElementData.delegate2763_1 != null)
		{
			axisElementData.delegate2763_1().Val = pPTXUnsupportedProps.Auto;
			axisElementData.Auto.Val = false;
		}
		if (axisElementData.delegate2078_1 != null && pPTXUnsupportedProps.TickMarksToSkip != 0)
		{
			axisElementData.delegate2078_1().Val = pPTXUnsupportedProps.TickMarksToSkip;
		}
		axisElementData.AxId.Val = pPTXUnsupportedProps.AxisId;
		axisElementData.Scaling.delegate1535_0(pPTXUnsupportedProps.ExtensionListOfScaling);
		axisElementData.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
	}
}
