using System.Drawing;
using System.Runtime.CompilerServices;
using ns16;

namespace Aspose.Cells;

/// <summary>
///       Describe the DataBar conditional formatting rule. 
///       This conditional formatting rule displays a gradated
///       data bar in the range of cells.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///       //Instantiating a Workbook object
///       Workbook workbook = new Workbook();
///
///       Worksheet sheet = workbook.Worksheets[0];
///
///       //Adds an empty conditional formatting
///       int index = sheet.ConditionalFormattings.Add();
///
///       FormatConditions fcs = sheet.ConditionalFormattings[index];
///
///       //Sets the conditional format range.
///       CellArea ca = new CellArea();
///
///       ca.StartRow = 0;
///
///       ca.EndRow = 2;
///
///       ca.StartColumn = 0;
///
///       ca.EndColumn = 0;
///
///       fcs.AddArea(ca);
///
///       //Adds condition.
///       int idx = fcs.AddCondtion(FormatConditionType.DataBar);
///
///       fcs.AddArea(ca);
///
///       FormatCondition cond = fcs[idx];
///
///       //Get Databar
///       DataBar dataBar = cond.DataBar;
///
///       dataBar.Color = Color.Orange;
///
///       //Set Databar properties
///       dataBar.MinCfvo.Type = FormatConditionValueType.Percentile;
///
///       dataBar.MinCfvo.Value = 30;
///
///       dataBar.ShowValue = false;
///
///       //Put Cell Values
///       Aspose.Cells.Cell cell1 = sheet.Cells["A1"];
///
///       cell1.PutValue(10);
///
///       Aspose.Cells.Cell cell2 = sheet.Cells["A2"];
///
///       cell2.PutValue(120);
///
///       Aspose.Cells.Cell cell3 = sheet.Cells["A3"];
///
///       cell3.PutValue(260);
///
///       //Saving the Excel file
///       workbook.Save("D:\\book1.xlsx");
///
///       [VB.NET]
///
///       'Instantiating a Workbook object
///       Dim workbook As New Workbook()
///
///       Dim sheet As Worksheet = workbook.Worksheets(0)
///
///       'Adds an empty conditional formatting
///       Dim index As Integer = sheet.ConditionalFormattings.Add()
///
///       Dim fcs As FormatConditions = sheet.ConditionalFormattings(index)
///
///       'Sets the conditional format range.
///       Dim ca As New CellArea()
///
///       ca.StartRow = 0
///
///       ca.EndRow = 2
///
///       ca.StartColumn = 0
///
///       ca.EndColumn = 0
///
///       fcs.AddArea(ca)
///
///       'Adds condition.
///       Dim idx As Integer = fcs.AddCondtion(FormatConditionType.DataBar)
///
///       fcs.AddArea(ca)
///
///       Dim cond As FormatCondition = fcs(idx)
///
///       'Get Databar
///       Dim dataBar As DataBar = cond.DataBar
///
///       dataBar.Color = Color.Orange
///
///       'Set Databar properties
///       dataBar.MinCfvo.Type = FormatConditionValueType.Percentile
///
///       dataBar.MinCfvo.Value = 30
///
///       dataBar.ShowValue = False
///
///       'Put Cell Values
///       Dim cell1 As Aspose.Cells.Cell = sheet.Cells("A1")
///
///       cell1.PutValue(10)
///
///       Dim cell2 As Aspose.Cells.Cell = sheet.Cells("A2")
///
///       cell2.PutValue(120)
///
///       Dim cell3 As Aspose.Cells.Cell = sheet.Cells("A3")
///
///       cell3.PutValue(260)
///
///       'Saving the Excel file
///       workbook.Save("D:\book1.xlsx")
///
///       </code>
/// </example>
public class DataBar
{
	internal ConditionalFormattingValue conditionalFormattingValue_0;

	internal ConditionalFormattingValue conditionalFormattingValue_1;

	private InternalColor internalColor_0;

	private InternalColor internalColor_1;

	private DataBarBorder dataBarBorder_0;

	private NegativeBarFormat negativeBarFormat_0;

	private int int_0 = 10;

	private int int_1 = 90;

	private bool bool_0 = true;

	internal Workbook workbook_0;

	private FormatCondition formatCondition_0;

	private DataBarAxisPosition dataBarAxisPosition_0;

	private DataBarFillType dataBarFillType_0;

	private TextDirectionType textDirectionType_0;

	public Color AxisColor
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

	public DataBarAxisPosition AxisPosition
	{
		get
		{
			return dataBarAxisPosition_0;
		}
		set
		{
			dataBarAxisPosition_0 = value;
		}
	}

	public DataBarFillType BarFillType
	{
		get
		{
			return dataBarFillType_0;
		}
		set
		{
			dataBarFillType_0 = value;
		}
	}

	public TextDirectionType Direction
	{
		get
		{
			return textDirectionType_0;
		}
		set
		{
			textDirectionType_0 = value;
		}
	}

	public DataBarBorder BarBorder => dataBarBorder_0;

	public NegativeBarFormat NegativeBarFormat => negativeBarFormat_0;

	/// <summary>
	///       Get or set this DataBar's min value object.
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
	///       Get or set this DataBar's max value object.
	///       Cannot set null or CFValueObject with type FormatConditionValueType.Min to it.
	///       </summary>
	public ConditionalFormattingValue MaxCfvo
	{
		get
		{
			if (conditionalFormattingValue_1 == null)
			{
				conditionalFormattingValue_1 = new ConditionalFormattingValue(formatCondition_0, FormatConditionValueType.Max, null);
			}
			return conditionalFormattingValue_1;
		}
	}

	/// <summary>
	///       Get or set this DataBar's Color.
	///       </summary>
	public Color Color
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

	public int MinLength
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public int MaxLength
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	/// <summary>
	///       Get or set the flag indicating whether to show the values of the cells on which this data bar is applied.
	///       Default value is true.
	///       </summary>
	public bool ShowValue
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	[SpecialName]
	internal InternalColor method_0()
	{
		return internalColor_1;
	}

	[SpecialName]
	internal void method_1(InternalColor internalColor_2)
	{
		internalColor_1 = internalColor_2;
	}

	internal DataBar(Workbook workbook_1, FormatCondition formatCondition_1)
	{
		formatCondition_0 = formatCondition_1;
		workbook_0 = workbook_1;
		internalColor_0 = new InternalColor(bool_0: false);
		internalColor_1 = new InternalColor(bool_0: false);
		dataBarBorder_0 = new DataBarBorder(this);
		negativeBarFormat_0 = new NegativeBarFormat(this);
		InternalColor internalColor = new InternalColor(bool_0: false);
		BarBorder.method_1(internalColor);
		BarBorder.Type = DataBarBorderType.DataBarBorderNone;
		InternalColor internalColor2 = new InternalColor(bool_0: false);
		internalColor2.SetColor(ColorType.RGB, 0);
		method_1(internalColor2);
		AxisPosition = DataBarAxisPosition.DataBarAxisAutomatic;
		InternalColor internalColor3 = new InternalColor(bool_0: false);
		internalColor3.SetColor(ColorType.RGB, 0);
		NegativeBarFormat.method_1(internalColor3);
		NegativeBarFormat.BorderColorType = DataBarNegativeColorType.DataBarSameAsPositive;
		InternalColor internalColor4 = new InternalColor(bool_0: false);
		internalColor4.SetColor(ColorType.RGB, 16711680);
		NegativeBarFormat.method_3(internalColor4);
		NegativeBarFormat.ColorType = DataBarNegativeColorType.DataBarColor;
		BarFillType = DataBarFillType.DataBarFillSolid;
		Direction = TextDirectionType.Context;
	}

	internal void Copy(DataBar dataBar_0, CopyOptions copyOptions_0, int int_2, int int_3)
	{
		int_0 = dataBar_0.int_0;
		bool_0 = dataBar_0.bool_0;
		int_1 = dataBar_0.int_1;
		if (dataBar_0.conditionalFormattingValue_1 != null)
		{
			conditionalFormattingValue_1 = new ConditionalFormattingValue(formatCondition_0);
			conditionalFormattingValue_1.Copy(dataBar_0.conditionalFormattingValue_1, dataBar_0.workbook_0.Worksheets, workbook_0.Worksheets, copyOptions_0, int_2, int_3);
		}
		if (dataBar_0.conditionalFormattingValue_0 != null)
		{
			conditionalFormattingValue_0 = new ConditionalFormattingValue(formatCondition_0);
			conditionalFormattingValue_0.Copy(dataBar_0.conditionalFormattingValue_0, dataBar_0.workbook_0.Worksheets, workbook_0.Worksheets, copyOptions_0, int_2, int_3);
		}
		internalColor_0.method_19(dataBar_0.internalColor_0);
		internalColor_1.method_19(dataBar_0.internalColor_1);
		dataBarAxisPosition_0 = dataBar_0.dataBarAxisPosition_0;
		dataBarFillType_0 = dataBar_0.dataBarFillType_0;
		textDirectionType_0 = dataBar_0.textDirectionType_0;
		if (dataBar_0.dataBarBorder_0 != null)
		{
			dataBarBorder_0 = new DataBarBorder(this);
			dataBarBorder_0.Copy(dataBar_0.dataBarBorder_0);
		}
		if (dataBar_0.negativeBarFormat_0 != null)
		{
			negativeBarFormat_0 = new NegativeBarFormat(this);
			negativeBarFormat_0.Copy(dataBar_0.negativeBarFormat_0);
		}
	}

	internal static DataBar smethod_0(Workbook workbook_1, FormatCondition formatCondition_1)
	{
		DataBar dataBar = new DataBar(workbook_1, formatCondition_1);
		dataBar.conditionalFormattingValue_0 = new ConditionalFormattingValue(formatCondition_1, FormatConditionValueType.AutomaticMin, null);
		dataBar.conditionalFormattingValue_1 = new ConditionalFormattingValue(formatCondition_1, FormatConditionValueType.AutomaticMax, null);
		InternalColor internalColor = new InternalColor(bool_0: false);
		internalColor.SetColor(ColorType.RGB, Class1618.smethod_62("FF638EC6"));
		dataBar.method_5(internalColor);
		dataBar.workbook_0 = workbook_1;
		InternalColor internalColor2 = new InternalColor(bool_0: false);
		dataBar.BarBorder.method_1(internalColor2);
		dataBar.BarBorder.Type = DataBarBorderType.DataBarBorderNone;
		InternalColor internalColor3 = new InternalColor(bool_0: false);
		internalColor3.SetColor(ColorType.RGB, 0);
		dataBar.method_1(internalColor3);
		dataBar.AxisPosition = DataBarAxisPosition.DataBarAxisAutomatic;
		InternalColor internalColor4 = new InternalColor(bool_0: false);
		internalColor4.SetColor(ColorType.RGB, 0);
		dataBar.NegativeBarFormat.method_1(internalColor4);
		dataBar.NegativeBarFormat.BorderColorType = DataBarNegativeColorType.DataBarSameAsPositive;
		InternalColor internalColor5 = new InternalColor(bool_0: false);
		internalColor5.SetColor(ColorType.RGB, 16711680);
		dataBar.NegativeBarFormat.method_3(internalColor5);
		dataBar.NegativeBarFormat.ColorType = DataBarNegativeColorType.DataBarColor;
		dataBar.BarFillType = DataBarFillType.DataBarFillSolid;
		dataBar.Direction = TextDirectionType.Context;
		return dataBar;
	}

	internal void method_2(ConditionalFormattingValue conditionalFormattingValue_2)
	{
		conditionalFormattingValue_1 = conditionalFormattingValue_2;
	}

	internal void method_3(ConditionalFormattingValue conditionalFormattingValue_2)
	{
		conditionalFormattingValue_0 = conditionalFormattingValue_2;
	}

	[SpecialName]
	internal InternalColor method_4()
	{
		return internalColor_0;
	}

	[SpecialName]
	internal void method_5(InternalColor internalColor_2)
	{
		internalColor_0 = internalColor_2;
	}
}
