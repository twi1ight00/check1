using System.Drawing;
using System.Runtime.CompilerServices;
using ns16;

namespace Aspose.Cells;

/// <summary>
///       Describe the ColorScale conditional formatting rule. 
///       This conditional formatting rule creates a gradated color scale on the cells.
///       </summary>
public class ColorScale
{
	internal ConditionalFormattingValue conditionalFormattingValue_0;

	internal ConditionalFormattingValue conditionalFormattingValue_1;

	internal ConditionalFormattingValue conditionalFormattingValue_2;

	internal InternalColor internalColor_0;

	internal InternalColor internalColor_1;

	internal InternalColor internalColor_2;

	private Workbook workbook_0;

	private FormatCondition formatCondition_0;

	/// <summary>
	///       Get or set this ColorScale's min value object.
	///       Cannot set null or CFValueObject with type FormatConditionValueType.Max to it.
	///       </summary>
	public ConditionalFormattingValue MinCfvo
	{
		get
		{
			if (conditionalFormattingValue_0 == null)
			{
				conditionalFormattingValue_0 = new ConditionalFormattingValue(formatCondition_0, FormatConditionValueType.Min, null);
			}
			return conditionalFormattingValue_0;
		}
	}

	/// <summary>
	///       Get or set this ColorScale's mid value object.
	///       Cannot set CFValueObject with type FormatConditionValueType.Max or FormatConditionValueType.Min to it.
	///       </summary>
	public ConditionalFormattingValue MidCfvo
	{
		get
		{
			if (conditionalFormattingValue_1 == null)
			{
				conditionalFormattingValue_1 = new ConditionalFormattingValue(formatCondition_0, FormatConditionValueType.Percentile, null);
			}
			return conditionalFormattingValue_1;
		}
	}

	/// <summary>
	///       Get or set this ColorScale's max value object.
	///       Cannot set null or CFValueObject with type FormatConditionValueType.Min to it.
	///       </summary>
	public ConditionalFormattingValue MaxCfvo
	{
		get
		{
			if (conditionalFormattingValue_2 == null)
			{
				conditionalFormattingValue_2 = new ConditionalFormattingValue(formatCondition_0, FormatConditionValueType.Max, null);
			}
			return conditionalFormattingValue_2;
		}
	}

	/// <summary>
	///       Get or set the min value object's corresponding color.
	///       </summary>
	public Color MinColor
	{
		get
		{
			return internalColor_0.method_6(workbook_0);
		}
		set
		{
			internalColor_0.SetColor(ColorType.RGB, value.ToArgb());
		}
	}

	/// <summary>
	///       Get or set the mid value object's corresponding color.
	///       </summary>
	public Color MidColor
	{
		get
		{
			return internalColor_1.method_6(workbook_0);
		}
		set
		{
			internalColor_1.SetColor(ColorType.RGB, value.ToArgb());
		}
	}

	/// <summary>
	///       Get or set the max value object's corresponding color.
	///       </summary>
	public Color MaxColor
	{
		get
		{
			return internalColor_2.method_6(workbook_0);
		}
		set
		{
			internalColor_2.SetColor(ColorType.RGB, value.ToArgb());
		}
	}

	internal ColorScale(Workbook workbook_1, FormatCondition formatCondition_1)
	{
		workbook_0 = workbook_1;
		formatCondition_0 = formatCondition_1;
		internalColor_2 = new InternalColor(bool_0: false);
		internalColor_1 = new InternalColor(bool_0: false);
		internalColor_0 = new InternalColor(bool_0: false);
	}

	internal void Copy(ColorScale colorScale_0, CopyOptions copyOptions_0, int int_0, int int_1)
	{
		if (colorScale_0.conditionalFormattingValue_2 != null)
		{
			conditionalFormattingValue_2 = new ConditionalFormattingValue(formatCondition_0);
			conditionalFormattingValue_2.Copy(colorScale_0.conditionalFormattingValue_2, colorScale_0.workbook_0.Worksheets, workbook_0.Worksheets, copyOptions_0, int_0, int_1);
		}
		if (colorScale_0.conditionalFormattingValue_1 != null)
		{
			conditionalFormattingValue_1 = new ConditionalFormattingValue(formatCondition_0);
			conditionalFormattingValue_1.Copy(colorScale_0.conditionalFormattingValue_1, colorScale_0.workbook_0.Worksheets, workbook_0.Worksheets, copyOptions_0, int_0, int_1);
		}
		if (colorScale_0.conditionalFormattingValue_0 != null)
		{
			conditionalFormattingValue_0 = new ConditionalFormattingValue(formatCondition_0);
			conditionalFormattingValue_0.Copy(colorScale_0.conditionalFormattingValue_0, colorScale_0.workbook_0.Worksheets, workbook_0.Worksheets, copyOptions_0, int_0, int_1);
		}
		internalColor_1.method_19(colorScale_0.internalColor_1);
		internalColor_0.method_19(colorScale_0.internalColor_0);
		internalColor_2.method_19(colorScale_0.internalColor_2);
	}

	internal static ColorScale smethod_0(Workbook workbook_1, FormatCondition formatCondition_1)
	{
		ColorScale colorScale = new ColorScale(workbook_1, formatCondition_1);
		colorScale.conditionalFormattingValue_0 = new ConditionalFormattingValue(formatCondition_1, FormatConditionValueType.Min, null);
		colorScale.conditionalFormattingValue_1 = new ConditionalFormattingValue(formatCondition_1, FormatConditionValueType.Percentile, 50);
		colorScale.conditionalFormattingValue_2 = new ConditionalFormattingValue(formatCondition_1, FormatConditionValueType.Max, null);
		InternalColor internalColor = new InternalColor(bool_0: false);
		internalColor.SetColor(ColorType.RGB, Class1618.smethod_62("FFF8696B"));
		colorScale.method_1().method_19(internalColor);
		internalColor.SetColor(ColorType.RGB, Class1618.smethod_62("FFFFEB84"));
		colorScale.method_3().method_19(internalColor);
		internalColor.SetColor(ColorType.RGB, Class1618.smethod_62("FF63BE7B"));
		colorScale.method_5().method_19(internalColor);
		colorScale.workbook_0 = workbook_1;
		return colorScale;
	}

	internal bool method_0()
	{
		if (conditionalFormattingValue_1 != null)
		{
			if (conditionalFormattingValue_1.method_6() == null)
			{
				return conditionalFormattingValue_1.Value != null;
			}
			return true;
		}
		return false;
	}

	[SpecialName]
	internal InternalColor method_1()
	{
		return internalColor_0;
	}

	[SpecialName]
	internal void method_2(InternalColor internalColor_3)
	{
		internalColor_0 = internalColor_3;
	}

	[SpecialName]
	internal InternalColor method_3()
	{
		return internalColor_1;
	}

	[SpecialName]
	internal void method_4(InternalColor internalColor_3)
	{
		internalColor_1 = internalColor_3;
	}

	[SpecialName]
	internal InternalColor method_5()
	{
		return internalColor_2;
	}

	[SpecialName]
	internal void method_6(InternalColor internalColor_3)
	{
		internalColor_2 = internalColor_3;
	}
}
