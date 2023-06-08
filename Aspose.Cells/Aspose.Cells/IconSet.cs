using ns16;

namespace Aspose.Cells;

/// <summary>
///       Describe the IconSet conditional formatting rule. 
///       This conditional formatting rule applies icons to cells
///       according to their values.
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
///       int idx = fcs.AddCondtion(FormatConditionType.IconSet);
///
///       fcs.AddArea(ca);
///
///       FormatCondition cond = fcs[idx];
///
///       //Get Icon Set
///       IconSet iconSet = cond.IconSet;
///
///       //Set Icon Type
///       iconSet.Type = IconSetType.Arrows3;
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
///       Dim idx As Integer = fcs.AddCondtion(FormatConditionType.IconSet)
///
///       fcs.AddArea(ca)
///
///       Dim cond As FormatCondition = fcs(idx)
///
///       'Get Icon Set
///       Dim iconSet As IconSet = cond.IconSet
///
///       'Set Icon Type
///       iconSet.Type = IconSetType.Arrows3
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
///       </code>
/// </example>
public class IconSet
{
	private IconSetType iconSetType_0 = IconSetType.TrafficLights31;

	private bool bool_0 = true;

	private bool bool_1;

	private bool bool_2 = true;

	internal ConditionalFormattingIconCollection conditionalFormattingIconCollection_0;

	private ConditionalFormattingValueCollection conditionalFormattingValueCollection_0;

	private FormatCondition formatCondition_0;

	public ConditionalFormattingIconCollection CfIcons
	{
		get
		{
			if (conditionalFormattingIconCollection_0 == null)
			{
				int count = conditionalFormattingValueCollection_0.Count;
				method_0(count);
			}
			return conditionalFormattingIconCollection_0;
		}
	}

	/// <summary>
	///       Get the CFValueObjects instance.
	///       </summary>
	public ConditionalFormattingValueCollection Cfvos => conditionalFormattingValueCollection_0;

	/// <summary>
	///       Get or Set the icon set type to display.
	///       Setting the type will auto check if the current Cfvos's count is
	///       accord with the new type. If not accord, old Cfvos will be cleaned and 
	///       default Cfvos will be added.
	///       </summary>
	public IconSetType Type
	{
		get
		{
			if (IsCustom)
			{
				return IconSetType.CustomSet;
			}
			return iconSetType_0;
		}
		set
		{
			iconSetType_0 = value;
			conditionalFormattingIconCollection_0 = null;
			int num = Class1618.smethod_144(iconSetType_0);
			int count = conditionalFormattingValueCollection_0.Count;
			try
			{
				if (count != num)
				{
					conditionalFormattingValueCollection_0.Clear();
					method_1(num);
				}
			}
			catch
			{
			}
		}
	}

	public bool IsCustom
	{
		get
		{
			if (conditionalFormattingIconCollection_0 != null)
			{
				return conditionalFormattingIconCollection_0.Count != 0;
			}
			return false;
		}
	}

	/// <summary>
	///       Get or set the flag indicating whether to show the values of the cells on which this icon set is applied.
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

	/// <summary>
	///       Get or set the flag indicating whether to reverses the default order of the icons in this icon set.
	///       Default value is false.
	///       </summary>
	public bool Reverse
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	internal IconSet(FormatCondition formatCondition_1)
	{
		formatCondition_0 = formatCondition_1;
		conditionalFormattingValueCollection_0 = new ConditionalFormattingValueCollection(formatCondition_1);
		conditionalFormattingValueCollection_0.bool_0 = true;
	}

	private void method_0(int int_0)
	{
		conditionalFormattingIconCollection_0 = new ConditionalFormattingIconCollection();
		for (int i = 0; i < int_0; i++)
		{
			ConditionalFormattingIcon cficon = new ConditionalFormattingIcon(iconSetType_0, i);
			conditionalFormattingIconCollection_0.Add(cficon);
		}
	}

	internal void Copy(IconSet iconSet_0, CopyOptions copyOptions_0, int int_0, int int_1)
	{
		bool_0 = iconSet_0.bool_0;
		bool_2 = iconSet_0.bool_2;
		bool_1 = iconSet_0.bool_1;
		iconSetType_0 = iconSet_0.iconSetType_0;
		conditionalFormattingValueCollection_0.Copy(iconSet_0.conditionalFormattingValueCollection_0, copyOptions_0, int_0, int_1);
		if (iconSet_0.conditionalFormattingIconCollection_0 != null && iconSet_0.conditionalFormattingIconCollection_0.Count > 0)
		{
			conditionalFormattingIconCollection_0 = new ConditionalFormattingIconCollection();
			conditionalFormattingIconCollection_0.Copy(iconSet_0.conditionalFormattingIconCollection_0);
		}
	}

	internal static IconSet smethod_0(FormatCondition formatCondition_1)
	{
		IconSet iconSet = new IconSet(formatCondition_1);
		iconSet.Type = IconSetType.TrafficLights31;
		return iconSet;
	}

	private void method_1(int int_0)
	{
		switch (int_0)
		{
		case 3:
			conditionalFormattingValueCollection_0.Add(new ConditionalFormattingValue(formatCondition_0, FormatConditionValueType.Percent, 0));
			conditionalFormattingValueCollection_0.Add(new ConditionalFormattingValue(formatCondition_0, FormatConditionValueType.Percent, 33));
			conditionalFormattingValueCollection_0.Add(new ConditionalFormattingValue(formatCondition_0, FormatConditionValueType.Percent, 67));
			break;
		case 4:
			conditionalFormattingValueCollection_0.Add(new ConditionalFormattingValue(formatCondition_0, FormatConditionValueType.Percent, 0));
			conditionalFormattingValueCollection_0.Add(new ConditionalFormattingValue(formatCondition_0, FormatConditionValueType.Percent, 25));
			conditionalFormattingValueCollection_0.Add(new ConditionalFormattingValue(formatCondition_0, FormatConditionValueType.Percent, 50));
			conditionalFormattingValueCollection_0.Add(new ConditionalFormattingValue(formatCondition_0, FormatConditionValueType.Percent, 75));
			break;
		case 5:
			conditionalFormattingValueCollection_0.Add(new ConditionalFormattingValue(formatCondition_0, FormatConditionValueType.Percent, 0));
			conditionalFormattingValueCollection_0.Add(new ConditionalFormattingValue(formatCondition_0, FormatConditionValueType.Percent, 20));
			conditionalFormattingValueCollection_0.Add(new ConditionalFormattingValue(formatCondition_0, FormatConditionValueType.Percent, 40));
			conditionalFormattingValueCollection_0.Add(new ConditionalFormattingValue(formatCondition_0, FormatConditionValueType.Percent, 60));
			conditionalFormattingValueCollection_0.Add(new ConditionalFormattingValue(formatCondition_0, FormatConditionValueType.Percent, 80));
			break;
		}
	}

	internal void method_2(IconSetType iconSetType_1)
	{
		iconSetType_0 = iconSetType_1;
	}
}
