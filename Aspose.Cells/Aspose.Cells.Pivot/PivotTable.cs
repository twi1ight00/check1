using System;
using System.Collections;
using System.Globalization;
using System.Runtime.CompilerServices;
using Aspose.Cells.Charts;
using Aspose.Cells.Tables;
using ns12;
using ns16;
using ns2;
using ns28;
using ns45;
using ns59;

namespace Aspose.Cells.Pivot;

/// <summary>
///       Summary description for PivotTable.
///       </summary>
public class PivotTable
{
	internal PivotTableCollection pivotTableCollection_0;

	internal Class1175 class1175_0;

	internal Class1160 class1160_0;

	internal Class1141 class1141_0;

	internal Class1176 class1176_0;

	internal PivotField pivotField_0;

	internal ArrayList arrayList_0;

	internal ArrayList arrayList_1;

	internal int int_0;

	internal int int_1;

	internal int int_2;

	internal int int_3;

	internal int int_4;

	internal int int_5;

	internal int int_6;

	internal bool bool_0;

	internal bool bool_1;

	internal bool bool_2;

	internal bool bool_3;

	internal bool bool_4;

	internal bool bool_5;

	internal int int_7;

	internal bool bool_6;

	internal int int_8;

	internal int int_9 = -1;

	internal bool bool_7;

	internal bool bool_8;

	internal bool bool_9 = true;

	internal bool bool_10 = true;

	internal bool bool_11 = true;

	internal bool bool_12 = true;

	internal bool bool_13;

	internal bool bool_14;

	internal bool bool_15;

	internal bool bool_16;

	internal bool bool_17;

	internal bool bool_18;

	internal string string_0;

	internal string string_1;

	internal string string_2 = "{962EF5D1-5CA2-4c93-8EF4-DBF5C05439D2}";

	internal string string_3;

	internal int int_10;

	internal ArrayList arrayList_2;

	internal Class1172 class1172_0;

	internal int int_11;

	internal Class1140 class1140_0;

	internal Style[,] style_0;

	internal Style[,] style_1;

	internal bool bool_19 = true;

	internal Class1164 class1164_0;

	internal bool bool_20;

	internal PivotFilterCollection pivotFilterCollection_0;

	internal PivotFormatConditionCollection pivotFormatConditionCollection_0;

	internal PivotField pivotField_1;

	private object object_0;

	private bool bool_21 = true;

	private bool bool_22 = true;

	private string string_4;

	private string string_5;

	internal int int_12 = -1;

	private byte byte_0 = 19;

	/// <summary>
	///       Gets and sets the pivottable style name.
	///       </summary>
	public string PivotTableStyleName
	{
		get
		{
			if (object_0 == null)
			{
				return null;
			}
			if (object_0 is string)
			{
				return (string)object_0;
			}
			if (object_0 is TableStyle)
			{
				return ((TableStyle)object_0).Name;
			}
			return Class1156.smethod_10((PivotTableStyleType)object_0);
		}
		set
		{
			bool_19 = true;
			PivotTableStyleType pivotTableStyleType = Class1156.smethod_11(value);
			if (pivotTableStyleType != PivotTableStyleType.Custom && pivotTableStyleType != 0)
			{
				object_0 = pivotTableStyleType;
			}
			else
			{
				object_0 = value;
			}
		}
	}

	/// <summary>
	///       Gets and sets the built-in pivot table style.
	///       </summary>
	public PivotTableStyleType PivotTableStyleType
	{
		get
		{
			if (object_0 == null)
			{
				return PivotTableStyleType.None;
			}
			if (object_0 is string)
			{
				return PivotTableStyleType.Custom;
			}
			return (PivotTableStyleType)object_0;
		}
		set
		{
			bool_19 = true;
			object_0 = value;
		}
	}

	/// <summary>
	///       Returns a PivotFields object that are currently shown as column fields.
	///       </summary>
	public PivotFieldCollection ColumnFields => class1175_0.pivotFieldCollection_3;

	/// <summary>
	///       Returns a PivotFields object that are currently shown as row fields.
	///       </summary>
	public PivotFieldCollection RowFields => class1175_0.pivotFieldCollection_2;

	/// <summary>
	///       Returns a PivotFields object that are currently shown as page fields.
	///       </summary>
	public PivotFieldCollection PageFields => class1175_0.pivotFieldCollection_4;

	/// <summary>
	///       Gets a PivotField object that represents all the data fields in a PivotTable.
	///       Read-only.It would be init only when there are two or more data fields in the DataPiovtFiels.
	///       It only use to add DataPivotField to the PivotTable row/column area . Default is in row area.
	///       </summary>
	public PivotFieldCollection DataFields => class1175_0.pivotFieldCollection_1;

	/// <summary>
	///       Gets a PivotField object that represents all the data fields in a PivotTable.
	///       Read-only.It would be init only when there are two or more data fields in the DataPiovtFiels.
	///       It only use to add DataPivotField to the PivotTable row/column area . Default is in row area.
	///       </summary>
	public PivotField DataField => pivotField_0;

	/// <summary>
	///       Returns a PivotFields object that includes all fields in the PivotTable report
	///       </summary>
	public PivotFieldCollection BaseFields => class1175_0.pivotFieldCollection_0;

	/// <summary>
	///       Returns a PivotFilterCollection object.
	///       </summary>
	public PivotFilterCollection PivotFilters => pivotFilterCollection_0;

	/// <summary>
	///       Returns a CellArea object that represents the range 
	///       that contains the column area in the PivotTable report. Read-only.
	///       </summary>
	public CellArea ColumnRange
	{
		get
		{
			if (!bool_1)
			{
				method_11();
			}
			CellArea result = default(CellArea);
			result.StartRow = int_0;
			result.EndRow = int_5 - 1;
			result.StartColumn = int_6;
			result.EndColumn = int_3;
			return result;
		}
	}

	/// <summary>
	///       Returns a CellArea object that represents the range 
	///       that contains the row area in the PivotTable report. Read-only.
	///       </summary>
	public CellArea RowRange
	{
		get
		{
			if (!bool_1)
			{
				method_11();
			}
			CellArea result = default(CellArea);
			if (RowFields.Count == 0)
			{
				result.StartRow = int_5;
			}
			else
			{
				result.StartRow = int_4;
			}
			result.StartColumn = int_2;
			if (int_6 > int_2)
			{
				result.EndColumn = int_6 - 1;
			}
			else
			{
				result.EndColumn = int_6;
			}
			result.EndRow = int_1;
			return result;
		}
	}

	/// <summary>
	///       Returns a CellArea object that represents the range that contains the data area 
	///       in the list between the header row and the insert row. Read-only.
	///       </summary>
	public CellArea DataBodyRange
	{
		get
		{
			CellArea columnRange = ColumnRange;
			CellArea rowRange = RowRange;
			CellArea result = default(CellArea);
			result.StartRow = columnRange.EndRow + 1;
			result.StartColumn = columnRange.StartColumn;
			result.EndRow = rowRange.EndRow;
			result.EndColumn = columnRange.EndColumn;
			return result;
		}
	}

	/// <summary>
	///       Returns a CellArea object that represents the range containing the entire PivotTable report,
	///       but doesn't include page fields. Read-only.
	///       </summary>
	public CellArea TableRange1
	{
		get
		{
			CellArea result = default(CellArea);
			if (method_1())
			{
				byte[] value = (byte[])arrayList_2[0];
				result.StartRow = BitConverter.ToUInt16(value, 4);
				result.EndRow = BitConverter.ToUInt16(value, 6);
				result.StartColumn = BitConverter.ToUInt16(value, 8);
				result.EndColumn = BitConverter.ToUInt16(value, 12);
				return result;
			}
			if (RefreshDataFlag && class1141_0.class1144_0 != null)
			{
				Class1149 @class = new Class1149(this);
				@class.method_7();
			}
			result.StartRow = int_0;
			result.StartColumn = int_2;
			result.EndRow = int_1;
			result.EndColumn = int_3;
			return result;
		}
	}

	/// <summary>
	///       Returns a CellArea object that represents the range containing the entire PivotTable report,
	///       includes page fields. Read-only.
	///       </summary>
	public CellArea TableRange2
	{
		get
		{
			int num = ((class1175_0.pivotFieldCollection_4.Count == 0) ? 2 : (class1175_0.pivotFieldCollection_4.Count + 1));
			int num2 = int_0 - num;
			num2 = ((num2 > 0) ? num2 : 0);
			CellArea tableRange = TableRange1;
			tableRange.StartRow = num2;
			return tableRange;
		}
	}

	/// <summary>
	///       Indicates whether the PivotTable report shows grand totals for columns.
	///       </summary>
	public bool ColumnGrand
	{
		get
		{
			return class1175_0.method_2(1);
		}
		set
		{
			class1175_0.method_1(value, 1);
		}
	}

	/// <summary>
	///       Indicates whether the PivotTable report displays classic pivottable layout.
	///       (enables dragging fields in the grid)
	///       </summary>
	public bool IsGridDropZones
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
			if (value)
			{
				bool_3 = true;
				bool_4 = true;
			}
		}
	}

	/// <summary>
	///        Indicates whether the PivotTable report shows grand totals for rows.
	///       </summary>
	public bool RowGrand
	{
		get
		{
			return class1175_0.method_2(2);
		}
		set
		{
			class1175_0.method_1(value, 2);
		}
	}

	/// <summary>
	///       Indicates whether the PivotTable report displays a custom string
	///       in cells that contain null values.
	///       </summary>
	public bool DisplayNullString
	{
		get
		{
			return class1160_0.method_1(64);
		}
		set
		{
			class1160_0.method_0(value, 64);
		}
	}

	/// <summary>
	///       Gets the string displayed in cells that contain null values 
	///       when the DisplayNullString property is true.The default value is an empty string.
	///       </summary>
	public string NullString
	{
		get
		{
			if (class1160_0.string_1 == null)
			{
				return "";
			}
			return class1160_0.string_1;
		}
		set
		{
			class1160_0.string_1 = value;
		}
	}

	/// <summary>
	///       Indicates whether the PivotTable report displays a custom string in cells that contain errors.
	///       </summary>
	public bool DisplayErrorString
	{
		get
		{
			return class1160_0.method_1(32);
		}
		set
		{
			class1160_0.method_0(value, 32);
		}
	}

	/// <summary>
	///       Gets the string displayed in cells that contain errors 
	///       when the DisplayErrorString property is true.The default value is an empty string.
	///       </summary>
	public string ErrorString
	{
		get
		{
			if (class1160_0.string_0 == null)
			{
				return "";
			}
			return class1160_0.string_0;
		}
		set
		{
			class1160_0.string_0 = value;
		}
	}

	public bool IsAutoFormat
	{
		get
		{
			return class1175_0.method_2(8);
		}
		set
		{
			class1175_0.method_1(value, 8);
			if (!value)
			{
				AutoFormatType = PivotTableAutoFormatType.Classic;
			}
		}
	}

	/// <summary>
	///       Gets the PivotTable auto format type.
	///       </summary>
	/// <see cref="T:Aspose.Cells.Pivot.PivotTableAutoFormatType" />
	public PivotTableAutoFormatType AutoFormatType
	{
		get
		{
			return class1176_0.AutoFormatType;
		}
		set
		{
			bool_1 = false;
			class1176_0.AutoFormatType = value;
			for (int i = 0; i < BaseFields.Count; i++)
			{
				Class1174 class1174_ = BaseFields[i].class1174_0;
				switch (value)
				{
				case PivotTableAutoFormatType.Report4:
				case PivotTableAutoFormatType.Report5:
				case PivotTableAutoFormatType.Report7:
					class1174_.byte_0 = 32;
					if (RowFields.Count > 1)
					{
						for (int k = 0; k < RowFields.Count - 1; k++)
						{
							RowFields[k].InsertBlankRow = true;
						}
					}
					break;
				case PivotTableAutoFormatType.Report2:
				case PivotTableAutoFormatType.Report8:
					class1174_.byte_0 = 32;
					if (RowFields.Count > 1)
					{
						RowFields[0].InsertBlankRow = true;
					}
					break;
				case PivotTableAutoFormatType.Report1:
				case PivotTableAutoFormatType.Report3:
				case PivotTableAutoFormatType.Report9:
					class1174_.byte_0 = 160;
					if (RowFields.Count > 1)
					{
						RowFields[0].InsertBlankRow = true;
					}
					break;
				case PivotTableAutoFormatType.Report6:
				case PivotTableAutoFormatType.Report10:
					class1174_.byte_0 = 160;
					if (RowFields.Count > 1)
					{
						for (int j = 0; j < RowFields.Count - 1; j++)
						{
							RowFields[j].InsertBlankRow = true;
						}
					}
					break;
				case PivotTableAutoFormatType.Table1:
				case PivotTableAutoFormatType.Table2:
				case PivotTableAutoFormatType.Table3:
				case PivotTableAutoFormatType.Table4:
				case PivotTableAutoFormatType.Table5:
				case PivotTableAutoFormatType.Table7:
					class1174_.byte_0 = 0;
					if (RowFields.Count > 1)
					{
						RowFields[0].InsertBlankRow = true;
					}
					break;
				}
			}
		}
	}

	/// <summary>
	///       Indicates whether to add blank rows.
	///       This property only applies for the PivotTable auto format types which needs to add blank rows.
	///       </summary>
	public bool HasBlankRows
	{
		get
		{
			return bool_21;
		}
		set
		{
			bool_21 = value;
			for (int i = 0; i < RowFields.Count; i++)
			{
				RowFields[i].InsertBlankRow = value;
			}
		}
	}

	/// <summary>
	///       Indicates whether the specified PivotTable report's outer-row item, column item, subtotal,
	///       and grand total labels use merged cells.
	///       </summary>
	public bool MergeLabels
	{
		get
		{
			return class1160_0.method_1(16);
		}
		set
		{
			class1160_0.method_0(value, 16);
		}
	}

	/// <summary>
	///       Indicates whether formatting is preserved when the PivotTable is refreshed or recalculated.
	///       </summary>
	public bool PreserveFormatting
	{
		get
		{
			return class1160_0.method_1(8);
		}
		set
		{
			class1160_0.method_0(value, 8);
		}
	}

	/// <summary>
	///       Gets whether expand/collapse buttons is shown.
	///       </summary>
	public bool ShowDrill
	{
		get
		{
			return bool_12;
		}
		set
		{
			bool_12 = value;
		}
	}

	/// <summary>
	///       Gets whether drilldown is enabled.
	///       </summary>
	public bool EnableDrilldown
	{
		get
		{
			return class1160_0.method_1(2);
		}
		set
		{
			class1160_0.method_0(value, 2);
		}
	}

	/// <summary>
	///       Indicates whether the PivotTable Field dialog box is available
	///       when the user double-clicks the PivotTable field.
	///       </summary>
	public bool EnableFieldDialog
	{
		get
		{
			return class1160_0.method_1(4);
		}
		set
		{
			class1160_0.method_0(value, 4);
		}
	}

	/// <summary>
	///       Gets whether enable the field list for the PivotTable.
	///       </summary>
	public bool EnableFieldList
	{
		get
		{
			return bool_22;
		}
		set
		{
			bool_22 = value;
		}
	}

	/// <summary>
	///       Indicates whether the PivotTable Wizard is available.
	///       </summary>
	public bool EnableWizard
	{
		get
		{
			return class1160_0.method_1(1);
		}
		set
		{
			class1160_0.method_0(value, 1);
		}
	}

	/// <summary>
	///        Indicates whether hidden page field items in the PivotTable report
	///        are included in row and column subtotals, block totals, and grand totals. 
	///        The default value is False.
	///       </summary>
	public bool SubtotalHiddenPageItems
	{
		get
		{
			return class1160_0.method_1(128);
		}
		set
		{
			class1160_0.method_0(value, 128);
		}
	}

	public string GrandTotalName
	{
		get
		{
			if (class1176_0.string_0 == null)
			{
				return "Grand Total";
			}
			return class1176_0.string_0;
		}
		set
		{
			class1176_0.string_0 = value;
		}
	}

	/// <summary>
	///       Indicates whether the PivotTable report is recalculated only at the user's request.
	///       </summary>
	public bool ManualUpdate
	{
		get
		{
			return class1160_0.method_3(64);
		}
		set
		{
			class1160_0.method_2(value, 64);
		}
	}

	/// <summary>
	///       Specifies a boolean value that indicates whether the fields of a PivotTable can have multiple filters set on them.
	///       </summary>
	public bool IsMultipleFieldFilters
	{
		get
		{
			return bool_9;
		}
		set
		{
			bool_9 = value;
		}
	}

	/// <summary>
	///       Specifies a boolean value that indicates whether the fields of a PivotTable can have multiple filters set on them.
	///       </summary>
	public PivotMissingItemLimitType MissingItemsLimit
	{
		get
		{
			if (class1141_0 != null)
			{
				if (class1141_0.int_9 > 32500)
				{
					return PivotMissingItemLimitType.Max;
				}
				if (class1141_0.int_9 == 0)
				{
					return PivotMissingItemLimitType.None;
				}
				return PivotMissingItemLimitType.Automatic;
			}
			return PivotMissingItemLimitType.Automatic;
		}
		set
		{
			if (class1141_0 != null)
			{
				switch (value)
				{
				default:
					class1141_0.int_9 = -1;
					break;
				case PivotMissingItemLimitType.Max:
					class1141_0.int_9 = 1048576;
					break;
				case PivotMissingItemLimitType.None:
					class1141_0.int_9 = 0;
					break;
				}
			}
		}
	}

	/// <summary>
	///       Specifies a boolean value that indicates whether the user is allowed to edit the cells in the data area of the pivottable.
	///       Enable cell editing in the values area
	///       </summary>
	public bool EnableDataValueEditing
	{
		get
		{
			return bool_18;
		}
		set
		{
			bool_18 = value;
		}
	}

	/// <summary>
	///       Specifies a boolean value that indicates whether tooltips should be displayed for PivotTable data cells.
	///       </summary>
	public bool ShowDataTips
	{
		get
		{
			return bool_10;
		}
		set
		{
			bool_10 = value;
		}
	}

	/// <summary>
	///        Specifies a boolean value that indicates whether member property information should be omitted from PivotTable tooltips.
	///       </summary>
	public bool ShowMemberPropertyTips
	{
		get
		{
			return bool_11;
		}
		set
		{
			bool_11 = value;
		}
	}

	/// <summary>
	///        Specifies a boolean value that indicates whether show values row.
	///        show the values row
	///       </summary>
	public bool ShowValuesRow
	{
		get
		{
			return !bool_13;
		}
		set
		{
			bool_13 = !value;
		}
	}

	/// <summary>
	///       Specifies a boolean value that indicates whether to include empty columns in the table
	///       </summary>
	public bool ShowEmptyCol
	{
		get
		{
			return bool_14;
		}
		set
		{
			bool_14 = value;
		}
	}

	/// <summary>
	///       Specifies a boolean value that indicates whether to include empty rows in the table.
	///       </summary>
	public bool ShowEmptyRow
	{
		get
		{
			return bool_15;
		}
		set
		{
			bool_15 = value;
		}
	}

	/// <summary>
	///       Specifies a boolean value that indicates whether fields in the PivotTable are sorted in non-default order in the field list. 
	///       </summary>
	public bool FieldListSortAscending
	{
		get
		{
			return bool_16;
		}
		set
		{
			bool_16 = value;
		}
	}

	/// <summary>
	///       Specifies a boolean value that indicates whether drill indicators should be printed.
	///       print expand/collapse buttons when displayed on pivottable.
	///       </summary>
	public bool PrintDrill
	{
		get
		{
			return bool_17;
		}
		set
		{
			bool_17 = value;
		}
	}

	/// <summary>
	///        Gets the title of the alttext
	///       </summary>
	public string AltTextTitle
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	/// <summary>
	///        Gets the description of the alt text
	///       </summary>
	public string AltTextDescription
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	/// <summary>
	///        Gets the name of the PivotTable
	///       </summary>
	public string Name
	{
		get
		{
			return class1175_0.string_0;
		}
		set
		{
			class1175_0.string_0 = value;
		}
	}

	/// <summary>
	///        Gets the Column Header Caption of the PivotTable.
	///       </summary>
	public string ColumnHeaderCaption
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	/// <summary>
	///        Specifies the indentation increment for compact axis and can be used to set the Report Layout to Compact Form.
	///       </summary>
	public int Indent
	{
		get
		{
			if (int_9 == 127)
			{
				return 0;
			}
			return int_9 + 1;
		}
		set
		{
			if (value == 0)
			{
				int_9 = 127;
			}
			else
			{
				int_9 = value - 1;
			}
		}
	}

	/// <summary>
	///        Gets the Row Header Caption of the PivotTable.
	///       </summary>
	public string RowHeaderCaption
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	/// <summary>
	///        Indicates whether row header caption is shown in the PivotTable report
	///        Indicates whether Display field captions and filter drop downs
	///       </summary>
	public bool ShowRowHeaderCaption
	{
		get
		{
			return bool_7;
		}
		set
		{
			bool_7 = value;
		}
	}

	/// <summary>
	///       Indicates whether consider built-in custom list when sort data
	///       </summary>
	public bool CustomListSort
	{
		get
		{
			return bool_8;
		}
		set
		{
			bool_8 = value;
		}
	}

	public PivotFormatConditionCollection PivotFormatConditions
	{
		get
		{
			if (pivotFormatConditionCollection_0 == null)
			{
				pivotFormatConditionCollection_0 = new PivotFormatConditionCollection(this, pivotTableCollection_0.worksheet_0);
			}
			return pivotFormatConditionCollection_0;
		}
	}

	/// <summary>
	///       Gets the order in which page fields are added to the PivotTable report's layout.
	///       </summary>
	public PrintOrderType PageFieldOrder
	{
		get
		{
			return (byte)(class1160_0.ushort_0 & 1) switch
			{
				0 => PrintOrderType.DownThenOver, 
				1 => PrintOrderType.OverThenDown, 
				_ => PrintOrderType.DownThenOver, 
			};
		}
		set
		{
			switch (value)
			{
			case PrintOrderType.DownThenOver:
				class1160_0.ushort_0 &= 65534;
				break;
			case PrintOrderType.OverThenDown:
				class1160_0.ushort_0 |= 1;
				break;
			}
		}
	}

	/// <summary>
	///       Gets the number of page fields in each column or row in the PivotTable report.
	///       </summary>
	public int PageFieldWrapCount
	{
		get
		{
			return (class1160_0.ushort_0 & 0x1E) >> 1;
		}
		set
		{
			class1160_0.ushort_0 &= (ushort)65505;
			class1160_0.ushort_0 |= (ushort)(value << 1);
		}
	}

	/// <summary>
	///       Gets a string saved with the PivotTable report.
	///       </summary>
	public string Tag
	{
		get
		{
			return class1160_0.string_2;
		}
		set
		{
			class1160_0.string_2 = value;
		}
	}

	/// <summary>
	///       Indicates whether data for the PivotTable report is saved with the workbook.
	///       </summary>
	public bool SaveData
	{
		get
		{
			return class1141_0.method_15(1);
		}
		set
		{
			class1141_0.method_14(value, 1);
		}
	}

	/// <summary>
	///       Indicates whether Refresh Data when Opening File.
	///       </summary>
	public bool RefreshDataOnOpeningFile
	{
		get
		{
			if (class1141_0 != null)
			{
				return class1141_0.method_12();
			}
			return false;
		}
		set
		{
			if (class1141_0 != null)
			{
				class1141_0.method_13(value);
			}
		}
	}

	/// <summary>
	///       Indicates whether Refresh Data or not.
	///       </summary>
	public bool RefreshDataFlag
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

	public string[] DataSource
	{
		get
		{
			return GetSource();
		}
		set
		{
			ChangeDataSource(value);
		}
	}

	/// <summary>
	///       A bit that specifies whether pivot item captions on the row axis 
	///       are repeated on each printed page for pivot fields in tabular form.
	///       </summary>
	public bool ItemPrintTitles
	{
		get
		{
			return class1176_0.method_0(32);
		}
		set
		{
			class1176_0.method_1(value, 32);
		}
	}

	/// <summary>
	///       Indicates whether the print titles for the worksheet are set based
	///       on the PivotTable report. The default value is false.
	///       </summary>
	public bool PrintTitles
	{
		get
		{
			return class1176_0.method_0(2);
		}
		set
		{
			CellArea columnRange = ColumnRange;
			CellArea rowRange = RowRange;
			PageSetup pageSetup = pivotTableCollection_0.worksheet_0.PageSetup;
			string text = "$" + (columnRange.StartRow + 1) + ":$" + (rowRange.StartRow + 1);
			string printTitleColumns = "$" + CellsHelper.ColumnIndexToName(rowRange.StartColumn) + ":$" + CellsHelper.ColumnIndexToName(rowRange.StartColumn);
			if (value)
			{
				if (pageSetup.PrintTitleRows == null || pageSetup.PrintTitleRows.Equals(""))
				{
					pageSetup.PrintTitleRows = text;
					pageSetup.PrintTitleColumns = printTitleColumns;
				}
			}
			else if (PrintTitles && pageSetup.PrintTitleRows != null && pageSetup.PrintTitleRows.Equals(text))
			{
				pageSetup.PrintTitleRows = null;
				pageSetup.PrintTitleColumns = null;
			}
			class1176_0.method_1(value, 2);
		}
	}

	/// <summary>
	///       Indicates whether items in the row and column areas are visible
	///       when the data area of the PivotTable is empty. The default value is true.
	///       </summary>
	public bool DisplayImmediateItems
	{
		get
		{
			return class1140_0.DisplayImmediateItems;
		}
		set
		{
			class1140_0.DisplayImmediateItems = value;
		}
	}

	/// <summary>
	///        Indicates whether the PivotTable is selected.
	///       </summary>
	public bool IsSelected
	{
		get
		{
			return class1172_0.IsSelected;
		}
		set
		{
			if (value)
			{
				foreach (PivotTable item in pivotTableCollection_0)
				{
					if (item == this)
					{
						item.class1172_0.IsSelected = true;
					}
					else
					{
						item.class1172_0.IsSelected = false;
					}
				}
				return;
			}
			class1172_0.IsSelected = value;
		}
	}

	/// <summary>
	///       Inidicates whether the row header in the pivot table should have the style applied.
	///       </summary>
	public bool ShowPivotStyleRowHeader
	{
		get
		{
			return (byte_0 & 1) != 0;
		}
		set
		{
			if (value)
			{
				byte_0 |= 1;
			}
			else
			{
				byte_0 &= 254;
			}
		}
	}

	/// <summary>
	///       Indicates whether the column header in the pivot table should have the style applied.
	///       </summary>
	public bool ShowPivotStyleColumnHeader
	{
		get
		{
			return (byte_0 & 2) != 0;
		}
		set
		{
			if (value)
			{
				byte_0 |= 2;
			}
			else
			{
				byte_0 &= 253;
			}
		}
	}

	/// <summary>
	///       Indicates whether row stripe formatting is applied.
	///       </summary>
	public bool ShowPivotStyleRowStripes
	{
		get
		{
			return (byte_0 & 4) != 0;
		}
		set
		{
			if (value)
			{
				byte_0 |= 4;
			}
			else
			{
				byte_0 &= 251;
			}
		}
	}

	/// <summary>
	///       Indicates whether column stripe formatting is applied.
	///       </summary>
	public bool ShowPivotStyleColumnStripes
	{
		get
		{
			return (byte_0 & 8) != 0;
		}
		set
		{
			if (value)
			{
				byte_0 |= 8;
			}
			else
			{
				byte_0 &= 247;
			}
		}
	}

	/// <summary>
	///       Indicates whether column stripe formatting is applied.
	///       </summary>
	public bool ShowPivotStyleLastColumn
	{
		get
		{
			return (byte_0 & 0x10) != 0;
		}
		set
		{
			if (value)
			{
				byte_0 |= 16;
			}
			else
			{
				byte_0 &= 239;
			}
		}
	}

	internal void method_0()
	{
		Class1149 @class = new Class1149(this);
		@class.method_9();
	}

	[SpecialName]
	internal bool method_1()
	{
		return arrayList_2 != null;
	}

	private void method_2()
	{
		int_1 = int_0 + 13;
		int_3 = (short)(int_2 + 6);
		int_4 = (int_5 = int_0 + 1);
		int_6 = int_2 + 1;
	}

	internal void method_3(CellArea cellArea_0)
	{
		ArrayList arrayList = (ArrayList)class1175_0.pivotFieldCollection_0.arrayList_0.Clone();
		int count = arrayList.Count;
		PivotFieldCollection pivotFieldCollection = new PivotFieldCollection(this, class1141_0);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < pivotFieldCollection.Count; i++)
		{
			arrayList2.Add(pivotFieldCollection[i].Name);
		}
		for (int j = 0; j < count; j++)
		{
			bool flag = false;
			for (int k = 0; k < pivotFieldCollection.Count; k++)
			{
				if (pivotFieldCollection[k].Name.Equals(((PivotField)arrayList[j]).Name))
				{
					flag = true;
					arrayList2.Remove(pivotFieldCollection[k].Name);
					break;
				}
			}
			PivotField pivotField = (PivotField)arrayList[j];
			if (pivotField.IsCalculatedField || (pivotField.Range != null && pivotField.Range.arrayList_0.Count > 0))
			{
				flag = true;
			}
			if (flag)
			{
				continue;
			}
			PivotField pivotField2 = (PivotField)arrayList[j];
			class1175_0.pivotFieldCollection_0.arrayList_0.Remove(pivotField2);
			switch (pivotField2.pivotFieldType_0)
			{
			case PivotFieldType.Data:
				class1175_0.pivotFieldCollection_1.arrayList_0.Remove(pivotField2);
				continue;
			case PivotFieldType.Row:
				class1175_0.pivotFieldCollection_2.arrayList_0.Remove(pivotField2);
				continue;
			case PivotFieldType.Column:
				class1175_0.pivotFieldCollection_3.arrayList_0.Remove(pivotField2);
				continue;
			case PivotFieldType.Page:
				class1175_0.pivotFieldCollection_4.arrayList_0.Remove(pivotField2);
				continue;
			}
			if (!pivotField2.method_4())
			{
				continue;
			}
			for (int l = 0; l < class1175_0.pivotFieldCollection_1.arrayList_0.Count; l++)
			{
				if (((PivotField)class1175_0.pivotFieldCollection_1.arrayList_0[l]).pivotField_0.Equals(pivotField2))
				{
					class1175_0.pivotFieldCollection_1.arrayList_0.RemoveAt(l);
				}
			}
		}
		if (arrayList2.Count > 0)
		{
			foreach (string item in arrayList2)
			{
				PivotField pivotField3 = pivotFieldCollection[item];
				class1175_0.pivotFieldCollection_0.arrayList_0.Insert(pivotField3.int_1, pivotField3);
			}
		}
		for (int m = 0; m < class1175_0.pivotFieldCollection_0.arrayList_0.Count; m++)
		{
			PivotField pivotField4 = (PivotField)class1175_0.pivotFieldCollection_0.arrayList_0[m];
			pivotField4.Index = m;
		}
	}

	internal void method_4()
	{
		if (class1141_0 == null)
		{
			return;
		}
		for (int i = 0; i < class1141_0.arrayList_0.Count; i++)
		{
			object obj = null;
			bool flag = false;
			PivotField pivotField = BaseFields[i];
			if (pivotField.IsCalculatedField || pivotField.Range != null)
			{
				continue;
			}
			int num = 0;
			int num2 = -1;
			bool flag2 = false;
			if (pivotField.pivotFieldType_0 == PivotFieldType.Page)
			{
				num = pivotField.CurrentPageItem;
				if (num >= 0 && num < pivotField.PivotItems.Count)
				{
					obj = pivotField.PivotItems[num].Value;
					flag = true;
				}
			}
			pivotField.method_2();
			ArrayList arrayList = (ArrayList)pivotField.PivotItems.arrayList_0.Clone();
			pivotField.class1161_0 = (Class1161)class1141_0.arrayList_0[i];
			if (pivotField.pivotItemCollection_0 == null || pivotField.pivotItemCollection_0.Count <= 0)
			{
				continue;
			}
			Hashtable hashtable = new Hashtable();
			if (pivotField.class1161_0.arrayList_0 == null)
			{
				continue;
			}
			int count = pivotField.class1161_0.arrayList_0.Count;
			for (int j = 0; j < pivotField.class1161_0.arrayList_0.Count; j++)
			{
				object obj2 = ((Class1158)pivotField.class1161_0.arrayList_0[j]).object_0;
				if (obj2 != null)
				{
					hashtable.Add(obj2, j);
				}
				else
				{
					num2 = j;
				}
			}
			ArrayList arrayList2 = new ArrayList();
			for (int k = 0; k < pivotField.pivotItemCollection_0.Count; k++)
			{
				PivotItem pivotItem = pivotField.pivotItemCollection_0[k];
				if (pivotItem.IsFormula)
				{
					pivotField.pivotItemCollection_0.RemoveAt(k--);
					hashtable.Remove(pivotItem.object_0);
					arrayList2.Add(pivotItem);
				}
				else if (pivotItem.object_0 == null)
				{
					if (pivotField.class1161_0.method_29())
					{
						if (pivotItem.Index < count)
						{
							pivotField.pivotItemCollection_0.RemoveAt(k--);
						}
					}
					else
					{
						pivotField.pivotItemCollection_0.RemoveAt(k--);
					}
				}
				else if (hashtable.ContainsKey(pivotItem.object_0))
				{
					pivotField.pivotItemCollection_0.RemoveAt(k--);
				}
				else
				{
					pivotField.pivotItemCollection_0.RemoveAt(k--);
				}
			}
			if (hashtable.Count > 0)
			{
				ArrayList arrayList3 = new ArrayList(hashtable.Values);
				arrayList3.Sort();
				foreach (int item in arrayList3)
				{
					IDictionaryEnumerator enumerator2 = hashtable.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						if ((int)enumerator2.Value != item)
						{
							continue;
						}
						if (pivotField.pivotItemCollection_0.Count >= count)
						{
							break;
						}
						PivotItem pivotItem2 = new PivotItem(pivotField.pivotItemCollection_0);
						pivotField.pivotItemCollection_0.Add(pivotItem2);
						if (num2 == -1)
						{
							pivotItem2.Index = pivotField.pivotItemCollection_0.Count - 1;
						}
						else if (pivotField.pivotItemCollection_0.Count == num2 + 1)
						{
							pivotItem2.Index = num2;
							PivotItem pivotItem3 = new PivotItem(pivotField.pivotItemCollection_0);
							pivotField.pivotItemCollection_0.Add(pivotItem3);
							pivotItem3.Index = pivotField.pivotItemCollection_0.Count - 1;
							flag2 = true;
						}
						else
						{
							pivotItem2.Index = pivotField.pivotItemCollection_0.Count - 1;
						}
						foreach (PivotItem item2 in arrayList)
						{
							if (item2.Value == pivotItem2.Value)
							{
								pivotItem2.ushort_1 = item2.ushort_1;
							}
						}
						break;
					}
				}
			}
			if (pivotField.class1161_0.method_29() && !flag2 && num2 < count)
			{
				PivotItem pivotItem5 = new PivotItem(pivotField.pivotItemCollection_0);
				pivotField.pivotItemCollection_0.Add(pivotItem5);
				pivotItem5.Index = num2;
				foreach (PivotItem item3 in arrayList)
				{
					if (item3.Value == null)
					{
						pivotItem5.ushort_1 = item3.ushort_1;
					}
				}
			}
			if (arrayList2.Count > 0)
			{
				foreach (PivotItem item4 in arrayList2)
				{
					pivotField.pivotItemCollection_0.Add(item4);
				}
			}
			if (!flag)
			{
				continue;
			}
			for (int l = 0; l < pivotField.pivotItemCollection_0.Count; l++)
			{
				PivotItem pivotItem7 = pivotField.pivotItemCollection_0[l];
				if (obj.Equals(pivotItem7.Value))
				{
					pivotField.CurrentPageItem = (short)l;
					break;
				}
			}
		}
	}

	internal PivotTable(PivotTableCollection pivotTableCollection_1, Class1141 class1141_1, int int_13, short short_0, string string_6)
	{
		pivotTableCollection_0 = pivotTableCollection_1;
		int_0 = int_13;
		int_2 = short_0;
		method_2();
		bool_1 = true;
		bool_7 = true;
		bool_8 = true;
		class1176_0 = new Class1176(this);
		class1141_0 = class1141_1;
		class1141_1.int_5++;
		class1175_0 = new Class1175(this, string_6);
		class1160_0 = new Class1160(this);
		class1172_0 = new Class1172(string_6);
		class1140_0 = new Class1140();
		class1140_0.method_1(this);
		class1164_0 = new Class1164(this);
		pivotFilterCollection_0 = new PivotFilterCollection(this);
		if (class1141_1.pivotTableSourceType_0 == PivotTableSourceType.Consilidation)
		{
			AddFieldToArea(PivotFieldType.Row, 0);
			AddFieldToArea(PivotFieldType.Column, 1);
			AddFieldToArea(PivotFieldType.Data, 2);
			for (int i = 3; i < BaseFields.Count; i++)
			{
				AddFieldToArea(PivotFieldType.Page, i);
			}
		}
	}

	internal ArrayList method_5(int int_13)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			int[] array = (int[])arrayList_0[i];
			if (array[0] == int_13)
			{
				arrayList.Add(i + int_5);
			}
		}
		return arrayList;
	}

	internal int method_6(PivotField pivotField_2)
	{
		if (pivotField_2.pivotFieldType_0 == PivotFieldType.Column)
		{
			for (int i = 0; i < ColumnFields.Count; i++)
			{
				PivotField pivotField = ColumnFields[i];
				if (pivotField.Equals(pivotField_2))
				{
					return i + int_0 + 1;
				}
			}
		}
		else if (pivotField_2.pivotFieldType_0 == PivotFieldType.Row)
		{
			for (int j = 0; j < RowFields.Count; j++)
			{
				PivotField pivotField2 = RowFields[j];
				if (pivotField2.Equals(pivotField_2))
				{
					return j;
				}
			}
		}
		else
		{
			for (int k = 0; k < DataFields.Count; k++)
			{
				PivotField pivotField3 = DataFields[k];
				if (pivotField3.Equals(pivotField_2))
				{
					return k;
				}
			}
		}
		return -1;
	}

	internal ArrayList method_7(object object_1, bool bool_23)
	{
		ArrayList arrayList = new ArrayList();
		CellArea cellArea = default(CellArea);
		cellArea = ((!bool_23) ? RowRange : ColumnRange);
		for (int i = cellArea.StartRow; i <= cellArea.EndRow; i++)
		{
			for (int j = cellArea.StartColumn; j <= cellArea.EndColumn; j++)
			{
				Cell cell = pivotTableCollection_0.worksheet_0.Cells[i, j];
				object obj = Class1662.Compare(cell.method_59(), object_1, "=", bool_0: false);
				if ((obj is bool) & (bool)obj)
				{
					arrayList.Add(new int[2] { i, j });
				}
			}
		}
		return arrayList;
	}

	internal int method_8(int int_13)
	{
		int num = 0;
		while (true)
		{
			if (num < arrayList_0.Count)
			{
				Class1165 @class = new Class1165((int[])arrayList_0[num]);
				if (@class.method_3() && @class.method_5() == int_13)
				{
					break;
				}
				num++;
				continue;
			}
			return 0;
		}
		return num;
	}

	internal int method_9(int int_13, int int_14)
	{
		int[] array = (int[])arrayList_0[int_13 - int_5];
		int num = array[int_14 + 4];
		int num2 = 0;
		while (true)
		{
			if (num2 < arrayList_0.Count)
			{
				Class1165 @class = new Class1165((int[])arrayList_0[num2]);
				if (@class.method_2() && @class.int_2[int_14] == num)
				{
					break;
				}
				num2++;
				continue;
			}
			return 0;
		}
		return num2 + int_5;
	}

	internal PivotTable(PivotTableCollection pivotTableCollection_1)
	{
		pivotTableCollection_0 = pivotTableCollection_1;
		bool_1 = true;
		class1176_0 = new Class1176(this);
		class1175_0 = new Class1175(this);
		class1160_0 = new Class1160(this);
		class1172_0 = new Class1172();
		class1140_0 = new Class1140();
		bool_7 = true;
		bool_8 = true;
		class1164_0 = new Class1164(this);
		pivotFilterCollection_0 = new PivotFilterCollection(this);
	}

	[SpecialName]
	internal TableStyle method_10()
	{
		if (object_0 == null)
		{
			return pivotTableCollection_0.worksheet_0.method_2().TableStyles.method_5(PivotTableStyleType.None);
		}
		if (object_0 is string)
		{
			return pivotTableCollection_0.worksheet_0.method_2().TableStyles[(string)object_0];
		}
		if (object_0 is PivotTableStyleType)
		{
			return pivotTableCollection_0.worksheet_0.method_2().TableStyles.method_5((PivotTableStyleType)object_0);
		}
		if (object_0 is TableStyle)
		{
			return (TableStyle)object_0;
		}
		return pivotTableCollection_0.worksheet_0.method_2().TableStyles.method_5(PivotTableStyleType.PivotTableStyleMedium9);
	}

	public void CopyStyle(PivotTable pivotTable)
	{
		WorksheetCollection worksheets = pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
		if (pivotTable.class1164_0.Count == 0 || pivotTable.object_0 != null)
		{
			int index = worksheets.TableStyles.Add(pivotTable.method_10().Name);
			TableStyle tableStyle = worksheets.TableStyles[index];
			tableStyle.Copy(pivotTable.method_10());
			PivotTableStyleName = tableStyle.Name;
			object_0 = tableStyle;
		}
	}

	internal void Copy(PivotTable pivotTable_0)
	{
		if (pivotTable_0.arrayList_2 != null)
		{
			arrayList_2 = new ArrayList();
			{
				foreach (byte[] item in pivotTable_0.arrayList_2)
				{
					byte[] array2 = new byte[item.Length];
					Array.Copy(item, array2, array2.Length);
					arrayList_2.Add(array2);
				}
				return;
			}
		}
		int_0 = pivotTable_0.int_0;
		int_2 = pivotTable_0.int_2;
		int_1 = pivotTable_0.int_1;
		int_3 = pivotTable_0.int_3;
		int_6 = pivotTable_0.int_6;
		int_5 = pivotTable_0.int_5;
		int_4 = pivotTable_0.int_4;
		bool_2 = pivotTable_0.bool_2;
		if (bool_1)
		{
			if (pivotTable_0.arrayList_0 != null)
			{
				arrayList_0 = new ArrayList(pivotTable_0.arrayList_0.Count);
				foreach (int[] item2 in pivotTable_0.arrayList_0)
				{
					int[] array4 = new int[item2.Length];
					Array.Copy(item2, array4, array4.Length);
					arrayList_0.Add(array4);
				}
			}
			if (pivotTable_0.arrayList_1 != null)
			{
				arrayList_1 = new ArrayList(pivotTable_0.arrayList_1.Count);
				foreach (int[] item3 in pivotTable_0.arrayList_1)
				{
					int[] array6 = new int[item3.Length];
					Array.Copy(item3, array6, array6.Length);
					arrayList_1.Add(array6);
				}
			}
		}
		class1176_0 = new Class1176(this);
		class1176_0.Copy(pivotTable_0.class1176_0);
		PivotTableStyleName = pivotTable_0.PivotTableStyleName;
		int_9 = pivotTable_0.int_9;
		bool_3 = pivotTable_0.bool_3;
		bool_4 = pivotTable_0.bool_4;
		bool_14 = pivotTable_0.bool_14;
		bool_15 = pivotTable_0.bool_15;
		bool_13 = pivotTable_0.bool_13;
		bool_12 = pivotTable_0.bool_12;
		bool_7 = pivotTable_0.bool_7;
		string_5 = pivotTable_0.string_5;
		string_4 = pivotTable_0.string_4;
		Worksheet worksheet_ = pivotTableCollection_0.worksheet_0;
		class1141_0 = worksheet_.method_2().method_89().Add(pivotTable_0.class1141_0, worksheet_);
		class1175_0 = new Class1175(this, pivotTable_0.Name);
		class1175_0.method_0(pivotTable_0.class1175_0.pivotFieldCollection_0.Count);
		if (BaseFields.Count > 0)
		{
			class1175_0.Copy(pivotTable_0.class1175_0);
		}
		class1160_0 = new Class1160(this);
		class1160_0.Copy(pivotTable_0.class1160_0);
		class1172_0 = new Class1172();
		class1172_0.Copy(pivotTable_0.class1172_0);
		class1140_0.Copy(pivotTable_0.class1140_0);
		bool_1 = pivotTable_0.bool_1;
	}

	internal void method_11()
	{
		bool_1 = true;
		Class1149 @class = new Class1149(this);
		if (class1141_0 != null && class1141_0.class1144_0 != null)
		{
			@class.method_7();
		}
	}

	/// <summary>
	///       Removes a field from specific field area
	///       </summary>
	/// <param name="fieldType">The fields area type.</param>
	/// <param name="fieldName">The name in the base fields.</param>
	/// <see cref="M:Aspose.Cells.Pivot.PivotTable.RemoveField(Aspose.Cells.Pivot.PivotFieldType,Aspose.Cells.Pivot.PivotField)" />
	public void RemoveField(PivotFieldType fieldType, string fieldName)
	{
		if (DataField != null && fieldName == DataField.Name)
		{
			RemoveField(fieldType, DataField);
			return;
		}
		int num = 0;
		while (true)
		{
			if (num < BaseFields.Count)
			{
				if (BaseFields[num].Name == fieldName)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		RemoveField(fieldType, BaseFields[num]);
	}

	/// <summary>
	///       Removes a field from specific field area
	///       </summary>
	/// <param name="fieldType">The fields area type.</param>
	/// <param name="baseFieldIndex">The field index in the base fields.</param>
	/// <see cref="M:Aspose.Cells.Pivot.PivotTable.RemoveField(Aspose.Cells.Pivot.PivotFieldType,Aspose.Cells.Pivot.PivotField)" />
	public void RemoveField(PivotFieldType fieldType, int baseFieldIndex)
	{
		RemoveField(fieldType, BaseFields[baseFieldIndex]);
	}

	/// <summary>
	///       Remove field from specific field area
	///       </summary>
	/// <param name="fieldType">the fields area type.It could be one of the following
	///                 values: <table border="1"><tr><td>PivotFieldType.Row</td></tr><tr><td>PivotFieldType.Column</td></tr><tr><td>PivotFieldType.Data</td></tr><tr><td>PivotFieldType.Page</td></tr></table></param>
	/// <param name="pivotField">the field in the base fields.</param>
	public void RemoveField(PivotFieldType fieldType, PivotField pivotField)
	{
		if (fieldType != 0)
		{
			if (pivotField.IsCalculatedField && fieldType != PivotFieldType.Data)
			{
				throw new ArgumentException("You could not del calculated field.");
			}
			Fields(fieldType).Remove(pivotField);
		}
	}

	/// <summary>
	///       Adds the field to the specific area.
	///       </summary>
	/// <param name="fieldType">The fields area type.</param>
	/// <param name="fieldName">The name in the base fields.</param>
	/// <returns>The field position in the specific fields.If there is no field named as it, return -1.</returns>
	/// <see cref="M:Aspose.Cells.Pivot.PivotTable.AddFieldToArea(Aspose.Cells.Pivot.PivotFieldType,Aspose.Cells.Pivot.PivotField)" />
	public int AddFieldToArea(PivotFieldType fieldType, string fieldName)
	{
		int num = 0;
		while (true)
		{
			if (num < BaseFields.Count)
			{
				if (BaseFields[num].Name == fieldName)
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return AddFieldToArea(fieldType, BaseFields[num]);
	}

	/// <summary>
	///       Adds the field to the specific area.
	///       </summary>
	/// <param name="fieldType">The fields area type.</param>
	/// <param name="baseFieldIndex">The field index in the base fields.</param>
	/// <returns>The field position in the specific fields.</returns>
	/// <see cref="M:Aspose.Cells.Pivot.PivotTable.AddFieldToArea(Aspose.Cells.Pivot.PivotFieldType,Aspose.Cells.Pivot.PivotField)" />
	public int AddFieldToArea(PivotFieldType fieldType, int baseFieldIndex)
	{
		return AddFieldToArea(fieldType, BaseFields[baseFieldIndex]);
	}

	/// <summary>
	///       Adds the field to the specific area.
	///       </summary>
	/// <param name="fieldType">the fields area type.It could be one of the following
	///                 values: <table border="1"><tr><td>PivotFieldType.Row</td></tr><tr><td>PivotFieldType.Column</td></tr><tr><td>PivotFieldType.Data</td></tr><tr><td>PivotFieldType.Page</td></tr></table></param>
	/// <param name="pivotField">the field in the base fields.</param>
	/// <returns>the field position in the specific fields.</returns>
	public int AddFieldToArea(PivotFieldType fieldType, PivotField pivotField)
	{
		if (fieldType != 0)
		{
			if (pivotField.IsCalculatedField && fieldType != PivotFieldType.Data)
			{
				throw new ArgumentException("You could not drag calculated field to this area.");
			}
			return Fields(fieldType).Add(pivotField);
		}
		return -1;
	}

	/// <summary>
	///       Adds a calclulated field to pivot field.
	///       </summary>
	/// <param name="name">The name of the calculated field</param>
	/// <param name="formula">The formula of the calculated field.</param>
	/// <param name="dragToDataArea">True,drag this field to data area immediately</param>
	public void AddCalculatedField(string name, string formula, bool dragToDataArea)
	{
		class1141_0.AddCalculatedField(name, formula);
		if (dragToDataArea)
		{
			AddFieldToArea(PivotFieldType.Data, class1175_0.pivotFieldCollection_0.Count - 1);
		}
	}

	/// <summary>
	///       Adds a calclulated field to pivot field and drag it to data area.
	///       </summary>
	/// <param name="name">The name of the calculated field</param>
	/// <param name="formula">The formula of the calculated field.</param>
	public void AddCalculatedField(string name, string formula)
	{
		AddCalculatedField(name, formula, dragToDataArea: true);
	}

	/// <summary>
	///       Gets the specific fields by the field type.
	///       </summary>
	/// <param name="fieldType">the field type.</param>
	/// <returns>the specific fields</returns>
	public PivotFieldCollection Fields(PivotFieldType fieldType)
	{
		return fieldType switch
		{
			PivotFieldType.Undefined => BaseFields, 
			PivotFieldType.Row => RowFields, 
			PivotFieldType.Column => ColumnFields, 
			PivotFieldType.Page => PageFields, 
			PivotFieldType.Data => DataFields, 
			_ => throw new ArgumentException("Invalid pivot field type"), 
		};
	}

	[SpecialName]
	internal int method_12()
	{
		if (arrayList_0 != null)
		{
			return arrayList_0.Count;
		}
		return 0;
	}

	[SpecialName]
	internal int method_13()
	{
		if (arrayList_1 != null)
		{
			return arrayList_1.Count;
		}
		return 0;
	}

	/// <summary>
	///        Moves the PivotTable to a different location in the worksheet.
	///       </summary>
	/// <param name="row">row index.</param>
	/// <param name="column">column index.</param>
	public void Move(int row, int column)
	{
		Class1677.smethod_24(row);
		Class1677.smethod_25(column);
		int num = row - int_0;
		short num2 = (short)(column - int_2);
		int_0 = row;
		int_2 = (short)column;
		int_5 += num;
		int_4 += num;
		int_6 += num2;
		int_3 += num2;
		int_1 += num;
	}

	/// <summary>
	///       Moves the PivotTable to a different location in the worksheet.
	///       </summary>
	/// <param name="destCellName">the dest cell name.</param>
	public void Move(string destCellName)
	{
		int row = 0;
		int column = 0;
		CellsHelper.CellNameToIndex(destCellName, out row, out column);
		Move(row, column);
	}

	private void method_14(Class1139 class1139_0, string string_6)
	{
		if (class1139_0 == null)
		{
			return;
		}
		if (string_6.IndexOf("=") != -1 && string_6.IndexOf("!") == -1)
		{
			if (class1139_0.range_0 != null)
			{
				class1139_0.range_0 = pivotTableCollection_0.worksheet_0.Workbook.Worksheets.Names[string_6.Substring(1)].GetRange();
			}
			class1139_0.string_0 = string_6.Substring(1);
			class1139_0.range_1 = class1139_0.range_0;
			class1139_0.worksheet_0 = class1139_0.range_0.Worksheet;
			return;
		}
		string sheetName = "";
		int num = string_6.IndexOf("!");
		int num2 = string_6.IndexOf("=");
		if (num != -1)
		{
			sheetName = ((num2 == -1) ? string_6.Substring(0, num) : string_6.Substring(1, num - 1));
		}
		Worksheet worksheet = pivotTableCollection_0.worksheet_0.Workbook.Worksheets[sheetName];
		if (worksheet != null)
		{
			class1139_0.worksheet_0 = (class1139_0.range_1 = (class1139_0.range_0 = worksheet.Cells.CreateRange(string_6))).Worksheet;
		}
	}

	public void ChangeDataSource(string[] source)
	{
		bool flag = false;
		for (int i = 0; i < source.Length; i++)
		{
			string text = source[i];
			if (text == null)
			{
				continue;
			}
			WorksheetCollection worksheets = pivotTableCollection_0.worksheet_0.Workbook.Worksheets;
			for (int j = 0; j < worksheets.Count; j++)
			{
				Worksheet worksheet = worksheets[j];
				for (int k = 0; k < worksheet.PivotTables.Count; k++)
				{
					PivotTable pivotTable = worksheet.PivotTables[k];
					if (pivotTable != this && pivotTable.class1141_0 == class1141_0)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				if (class1141_0.class1139_0 != null)
				{
					if (i < class1141_0.class1139_0.Length)
					{
						Class1139 class1139_ = class1141_0.class1139_0[i];
						method_14(class1139_, text);
					}
				}
				else if (text.IndexOf("=") != -1 && text.IndexOf("!") == -1)
				{
					class1141_0.string_3 = text.Substring(1);
				}
				continue;
			}
			class1141_0.class1142_0.int_0++;
			Class1141 @class = new Class1141(class1141_0.class1142_0, class1141_0.class1142_0.int_0, pivotTableCollection_0.worksheet_0);
			@class.Copy(class1141_0);
			class1141_0 = @class;
			class1141_0.class1142_0.Add(@class);
			if (class1141_0.class1139_0 != null)
			{
				if (i < class1141_0.class1139_0.Length)
				{
					Class1139 class1139_2 = class1141_0.class1139_0[i];
					method_14(class1139_2, text);
				}
			}
			else if (text.IndexOf("=") != -1 && text.IndexOf("!") == -1)
			{
				class1141_0.string_3 = text.Substring(1);
			}
		}
	}

	/// <summary>
	///       Get pivottable's source data.
	///       </summary>
	public string[] GetSource()
	{
		if (class1141_0 == null)
		{
			return null;
		}
		if (class1141_0.pivotTableSourceType_0 != PivotTableSourceType.ListDatabase && class1141_0.pivotTableSourceType_0 != PivotTableSourceType.Consilidation)
		{
			return null;
		}
		if (class1141_0.class1139_0 != null)
		{
			return class1141_0.method_22();
		}
		return null;
	}

	/// <summary>
	///       Refreshes pivottable's data and setting from it's data source.
	///       </summary>
	/// <remarks>
	///       We will gather data from data source to a pivot cache ,then calcualte the data in the cache to the cells.
	///       This method is only used to gather all data to a pivot cache.
	///       </remarks>
	public void RefreshData()
	{
		if (class1141_0 == null)
		{
			throw new CellsException(ExceptionType.UnsupportedFeature, "this data source is not supported.");
		}
		if (class1141_0.pivotTableSourceType_0 != PivotTableSourceType.ListDatabase)
		{
			throw new CellsException(ExceptionType.UnsupportedFeature, "this data source is not supported.");
		}
		if (class1141_0.class1139_0 != null)
		{
			for (int i = 0; i < class1141_0.class1139_0.Length; i++)
			{
				Range range_ = class1141_0.class1139_0[i].range_1;
				class1141_0.method_8(class1141_0.class1139_0[i].GetSource());
				ArrayList arrayList = new ArrayList();
				if (class1141_0.arrayList_0 != null)
				{
					class1141_0.method_5(arrayList);
				}
				if ((range_ != null && !class1141_0.class1139_0[i].range_0.Area.Equals(range_.Area)) || BaseFields.Count != class1141_0.int_1 + arrayList.Count)
				{
					method_3(class1141_0.class1139_0[i].range_0.Area);
				}
			}
			method_4();
			int count = class1164_0.Count;
			ArrayList arrayList2 = new ArrayList();
			for (int j = 0; j < count; j++)
			{
				Class1163 @class = class1164_0[j];
				if (@class.class1171_0.arrayList_0.Count <= 0)
				{
					continue;
				}
				for (int k = 0; k < @class.class1171_0.arrayList_0.Count; k++)
				{
					Class1162 class2 = (Class1162)@class.class1171_0.arrayList_0[k];
					if (class2 != null)
					{
						ushort num = class2.method_1();
						if (num != 65534 && @class.class1171_0.arrayList_0.Count > 0 && class2.arrayList_0.Count > 0 && BaseFields[num].class1161_0 != null && BaseFields[num].class1161_0.arrayList_0.Count > 1)
						{
							arrayList2.Add(class1164_0[j]);
							break;
						}
					}
				}
			}
			{
				foreach (Class1163 item in arrayList2)
				{
					class1164_0.Remove(item);
				}
				return;
			}
		}
		throw new CellsException(ExceptionType.UnsupportedFeature, "this name or range is not supported.");
	}

	/// <summary>
	///       Calculates pivottable's data to cells.
	///       </summary>
	/// <remarks>
	///       Cell.Value in the pivot range could not return the correct result if the method is not been called.
	///       This method caclulates data with an inner pivot cache,not original data source.
	///       So if the data source is changed, please call RefreshData() method first.         
	///       </remarks>
	public void CalculateData()
	{
		Class1149 @class = new Class1149(this);
		@class.CalculateData();
	}

	internal void method_15(Chart chart_0, string string_6)
	{
		Class1149 @class = new Class1149(this);
		@class.method_3(chart_0, string_6);
	}

	/// <summary>
	///        Calculates pivottable's range.
	///        </summary>
	/// <remarks> 
	///        If this method is not been called,maybe the pivottable range is not corrected.
	///       </remarks>
	public void CalculateRange()
	{
		Class1149 @class = new Class1149(this);
		@class.method_7();
	}

	/// <summary>
	///       Format all the cell in the pivottable area
	///       </summary>
	/// <param name="style">Style which is to format</param>
	public void FormatAll(Style style)
	{
		Class1149 @class = new Class1149(this);
		@class.FormatAll(style);
	}

	/// <summary>
	///       Format the cell in the pivottable area
	///       </summary>
	/// <param name="row">RowIndex of the cell</param>
	/// <param name="column">Column index of the cell</param>
	/// <param name="style">Style which is to format the cell</param>
	public void Format(int row, int column, Style style)
	{
		Class1149 @class = new Class1149(this);
		@class.Format(row, column, style);
	}

	internal bool InsertRows(int int_13, int int_14)
	{
		if (int_14 < 0 && int_13 <= int_0 && int_13 - int_14 - 1 >= int_1)
		{
			return true;
		}
		if (int_13 <= int_0)
		{
			int_0 += int_14;
			int_4 += int_14;
			int_5 += int_14;
			int_1 += int_14;
		}
		else if (int_13 <= int_1)
		{
			throw new ArgumentException("The row index should not be inside the pivottable report");
		}
		return false;
	}

	internal bool InsertColumns(int int_13, int int_14)
	{
		if (int_14 < 0 && int_13 <= int_2 && int_13 - int_14 - 1 >= int_3)
		{
			return true;
		}
		if (int_13 <= int_2)
		{
			int_2 += int_14;
			int_6 += int_14;
			int_3 += int_14;
		}
		else if (int_13 <= int_1)
		{
			throw new ArgumentException("The column index should not be inside the pivottable report");
		}
		return false;
	}

	internal bool InsertRange(CellArea cellArea_0, int int_13, ShiftType shiftType_0)
	{
		switch (shiftType_0)
		{
		case ShiftType.Down:
			if (cellArea_0.StartColumn <= int_2 && cellArea_0.EndColumn >= int_3)
			{
				return InsertRows(cellArea_0.StartRow, int_13);
			}
			break;
		case ShiftType.Left:
			if (cellArea_0.StartRow <= int_0 && cellArea_0.EndRow >= int_1)
			{
				return InsertColumns(cellArea_0.StartColumn, -int_13);
			}
			break;
		case ShiftType.Right:
			if (cellArea_0.StartRow <= int_0 && cellArea_0.EndRow >= int_1)
			{
				return InsertColumns(cellArea_0.StartColumn, int_13);
			}
			break;
		case ShiftType.Up:
			if (cellArea_0.StartColumn <= int_2 && cellArea_0.EndColumn >= int_3)
			{
				return InsertRows(cellArea_0.StartRow, -int_13);
			}
			break;
		}
		return false;
	}

	/// <summary>
	///       Sets auto field group by the PivotTable.
	///       </summary>
	/// <param name="baseFieldIndex">The row or column field index in the base fields</param>
	public void SetAutoGroupField(int baseFieldIndex)
	{
		PivotField pivotField = BaseFields[baseFieldIndex];
		if (pivotField == null || (pivotField.pivotFieldType_0 != PivotFieldType.Row && pivotField.pivotFieldType_0 != PivotFieldType.Column))
		{
			throw new ArgumentException("Invalid pivot field index");
		}
		SetAutoGroupField(pivotField);
	}

	/// <summary>
	///       Sets auto field group by the PivotTable.
	///       </summary>
	/// <param name="pivotField">The row or column field in the specific fields</param>
	public void SetAutoGroupField(PivotField pivotField)
	{
		if (pivotField != null && (pivotField.pivotFieldType_0 == PivotFieldType.Row || pivotField.pivotFieldType_0 == PivotFieldType.Column))
		{
			Class1161 class1161_ = pivotField.class1161_0;
			class1161_.sxRng_0 = new SxRng(class1161_);
			class1161_.ushort_0 |= 16;
			SxRng sxRng_ = class1161_.sxRng_0;
			sxRng_.bool_0 = true;
			sxRng_.bool_1 = true;
			sxRng_.int_0 = pivotField.int_1;
			if (class1161_.method_23())
			{
				string[] array = class1161_.method_37();
				sxRng_.double_2 = 1.0;
				sxRng_.double_0 = Class1618.smethod_85(array[0]);
				sxRng_.double_1 = Class1618.smethod_85(array[1]);
				sxRng_.arrayList_0 = new ArrayList();
				if (class1161_.method_29())
				{
					Class1158 @class = new Class1158();
					@class.object_0 = null;
					sxRng_.arrayList_0.Add(@class);
				}
				object[] array2 = class1161_.method_38(sxRng_);
				object[] array3 = array2;
				foreach (object obj in array3)
				{
					Class1158 class2 = new Class1158();
					class2.object_0 = obj;
					sxRng_.arrayList_0.Add(class2);
				}
				pivotField.method_1();
				pivotField.method_0();
			}
			else if (class1161_.method_22())
			{
				string[] array4 = class1161_.method_37();
				sxRng_.pivotGroupByType_0 = PivotGroupByType.Months;
				try
				{
					sxRng_.dateTime_0 = DateTime.Parse(array4[0]);
					sxRng_.dateTime_1 = DateTime.Parse(array4[1]);
				}
				catch (Exception)
				{
				}
				sxRng_.double_2 = 1.0;
				sxRng_.arrayList_0 = new ArrayList();
				object[] array5 = class1161_.method_38(sxRng_);
				foreach (object obj2 in array5)
				{
					Class1158 class3 = new Class1158();
					class3.object_0 = obj2;
					sxRng_.arrayList_0.Add(class3);
				}
				pivotField.method_1();
				pivotField.method_0();
			}
			return;
		}
		throw new ArgumentException("Invalid pivot field.");
	}

	/// <summary>
	///       Sets manual field group by the PivotTable.
	///       </summary>
	/// <param name="baseFieldIndex">The row or column field index in the base fields</param>
	/// <param name="startVal">Specifies the starting value for numeric grouping.</param>
	/// <param name="endVal">Specifies the ending value for numeric grouping. </param>
	/// <param name="groupByList">Specifies the grouping type list. Specified by PivotTableGroupType</param>
	/// <param name="intervalNum">Specifies the interval number group by  numeric grouping.</param>
	public void SetManualGroupField(int baseFieldIndex, double startVal, double endVal, ArrayList groupByList, double intervalNum)
	{
		PivotField pivotField = BaseFields[baseFieldIndex];
		if (pivotField == null || (pivotField.pivotFieldType_0 != PivotFieldType.Row && pivotField.pivotFieldType_0 != PivotFieldType.Column))
		{
			throw new ArgumentException("Invalid pivot field index.");
		}
		SetManualGroupField(pivotField, startVal, endVal, groupByList, intervalNum);
	}

	/// <summary>
	///       Sets manual field group by the PivotTable.
	///       </summary>
	/// <param name="pivotField">The row or column field in the base fields</param>
	/// <param name="startVal">Specifies the starting value for numeric grouping.</param>
	/// <param name="endVal">Specifies the ending value for numeric grouping. </param>
	/// <param name="groupByList">Specifies the grouping type list. Specified by PivotTableGroupType</param>
	/// <param name="intervalNum">Specifies the interval number group by numeric grouping.</param>
	public void SetManualGroupField(PivotField pivotField, double startVal, double endVal, ArrayList groupByList, double intervalNum)
	{
		if (pivotField != null && (pivotField.pivotFieldType_0 == PivotFieldType.Row || pivotField.pivotFieldType_0 == PivotFieldType.Column))
		{
			if (groupByList != null)
			{
				Class1161 class1161_ = pivotField.class1161_0;
				class1161_.method_21(bool_2: true);
				class1161_.sxRng_0 = new SxRng(class1161_);
				SxRng sxRng_ = class1161_.sxRng_0;
				sxRng_.bool_1 = false;
				sxRng_.bool_0 = false;
				sxRng_.int_0 = pivotField.int_1;
				if (!(endVal >= startVal))
				{
					throw new ArgumentException("The start value must not be greater than the end value.");
				}
				if (groupByList.Count != 1 || (PivotGroupByType)groupByList[0] != 0 || !(intervalNum > 0.0))
				{
					throw new ArgumentException("Invalid parameters for numeric grouping.");
				}
				sxRng_.double_0 = startVal;
				sxRng_.double_1 = endVal;
				sxRng_.double_2 = intervalNum;
				sxRng_.pivotGroupByType_0 = PivotGroupByType.RangeOfValues;
				sxRng_.arrayList_0 = new ArrayList();
				object[] array = class1161_.method_39(startVal.ToString(), endVal.ToString(), groupByList, intervalNum, PivotGroupByType.RangeOfValues);
				object[] array2 = array;
				foreach (object obj in array2)
				{
					Class1158 @class = new Class1158();
					@class.object_0 = obj;
					sxRng_.arrayList_0.Add(@class);
				}
				pivotField.method_1();
				pivotField.method_0();
			}
			return;
		}
		throw new ArgumentException("Invalid pivot field.");
	}

	/// <summary>
	///       Sets manual field group by the PivotTable.
	///       </summary>
	/// <param name="baseFieldIndex">The row or column field index in the base fields</param>
	/// <param name="startVal">Specifies the starting value for date grouping. </param>
	/// <param name="endVal">Specifies the ending value for date grouping.</param>
	/// <param name="groupByList">Specifies the grouping type list. Specified by PivotTableGroupType</param>
	/// <param name="intervalNum">Specifies the interval number group by in days grouping.The number of days must be positive integer of nonzero</param>
	public void SetManualGroupField(int baseFieldIndex, DateTime startVal, DateTime endVal, ArrayList groupByList, int intervalNum)
	{
		PivotField pivotField = BaseFields[baseFieldIndex];
		if (pivotField == null || (pivotField.pivotFieldType_0 != PivotFieldType.Row && pivotField.pivotFieldType_0 != PivotFieldType.Column))
		{
			throw new ArgumentException("Invalid pivot field index.");
		}
		SetManualGroupField(pivotField, startVal, endVal, groupByList, intervalNum);
	}

	/// <summary>
	///       Sets manual field group by the PivotTable.
	///       </summary>
	/// <param name="pivotField">The row or column field in the base fields</param>
	/// <param name="startVal">Specifies the starting value for date grouping.</param>
	/// <param name="endVal">Specifies the ending value for date grouping.</param>
	/// <param name="groupByList">Specifies the grouping type list. Specified by PivotTableGroupType</param>
	/// <param name="intervalNum">Specifies the interval number group by in days grouping.The number of days must be positive integer of nonzero</param>
	public void SetManualGroupField(PivotField pivotField, DateTime startVal, DateTime endVal, ArrayList groupByList, int intervalNum)
	{
		if (pivotField != null && (pivotField.pivotFieldType_0 == PivotFieldType.Row || pivotField.pivotFieldType_0 == PivotFieldType.Column))
		{
			if (groupByList == null)
			{
				return;
			}
			Class1161 class1161_ = pivotField.class1161_0;
			class1161_.method_21(bool_2: true);
			class1161_.sxRng_0 = new SxRng(class1161_);
			SxRng sxRng_ = class1161_.sxRng_0;
			sxRng_.bool_1 = false;
			sxRng_.bool_0 = false;
			sxRng_.int_0 = pivotField.int_1;
			string text = startVal.ToString("yyyy-MM-dd\\THH:mm:ss.fff", CultureInfo.InvariantCulture);
			string text2 = endVal.ToString("yyyy-MM-dd\\THH:mm:ss.fff", CultureInfo.InvariantCulture);
			if (text2.CompareTo(text) >= 0)
			{
				try
				{
					pivotField.class1161_0.sxRng_0.dateTime_0 = DateTime.Parse(text);
					pivotField.class1161_0.sxRng_0.dateTime_1 = DateTime.Parse(text2);
				}
				catch (Exception)
				{
				}
				if (groupByList.Contains(PivotGroupByType.RangeOfValues))
				{
					groupByList.Remove(PivotGroupByType.RangeOfValues);
				}
				groupByList.Sort();
				if (groupByList.Count == 1 && (PivotGroupByType)groupByList[0] == PivotGroupByType.Days)
				{
					if (intervalNum > 0 && intervalNum < 32768)
					{
						pivotField.class1161_0.sxRng_0.double_2 = intervalNum;
						sxRng_.pivotGroupByType_0 = PivotGroupByType.Days;
						sxRng_.arrayList_0 = new ArrayList();
						pivotField.pivotItemCollection_0 = new PivotItemCollection(pivotField);
						object[] array = class1161_.method_39(text, text2, groupByList, intervalNum, PivotGroupByType.Days);
						object[] array2 = array;
						foreach (object obj in array2)
						{
							Class1158 @class = new Class1158();
							@class.object_0 = obj;
							sxRng_.arrayList_0.Add(@class);
						}
						pivotField.method_1();
						pivotField.method_0();
						return;
					}
					throw new ArgumentException("The number of days must be positive integer of nonzero, between 1 and 32767.");
				}
				PivotGroupByType pivotGroupByType_ = (sxRng_.pivotGroupByType_0 = (PivotGroupByType)groupByList[0]);
				sxRng_.arrayList_0 = new ArrayList();
				pivotField.pivotItemCollection_0 = new PivotItemCollection(pivotField);
				object[] array3 = class1161_.method_39(text, text2, groupByList, 0.0, pivotGroupByType_);
				object[] array4 = array3;
				foreach (object obj2 in array4)
				{
					Class1158 class2 = new Class1158();
					class2.object_0 = obj2;
					sxRng_.arrayList_0.Add(class2);
				}
				pivotField.method_1();
				pivotField.method_0();
				for (int k = 1; k < groupByList.Count; k++)
				{
					PivotField pivotField2 = new PivotField(BaseFields);
					BaseFields.method_4(pivotField2);
					pivotField2.int_1 = BaseFields.Count - 1;
					pivotField2.ShowInOutlineForm = true;
					pivotField2.ShowCompact = true;
					pivotField2.ShowSubtotalAtTop = true;
					if (pivotField.pivotFieldType_0 == PivotFieldType.Row)
					{
						RowFields.Add(pivotField2, 0);
					}
					else
					{
						ColumnFields.Add(pivotField2, 0);
					}
					pivotField2.IsAutoSubtotals = false;
					pivotField2.pivotFieldType_0 = pivotField.pivotFieldType_0;
					Class1161 class3 = new Class1161(class1141_0);
					class3.method_21(bool_2: true);
					pivotField2.class1161_0 = class3;
					pivotGroupByType_ = (PivotGroupByType)groupByList[k];
					SxRng sxRng = (class3.sxRng_0 = new SxRng(class3));
					sxRng.pivotGroupByType_0 = pivotGroupByType_;
					sxRng.int_0 = pivotField.int_1;
					try
					{
						sxRng.dateTime_0 = DateTime.Parse(text);
						sxRng.dateTime_1 = DateTime.Parse(text2);
					}
					catch (Exception)
					{
					}
					sxRng.double_2 = 1.0;
					string text3 = Class1156.smethod_3(pivotGroupByType_);
					class3.string_0 = text3.Replace(text3[0], (char)(text3[0] - 32));
					class3.bool_0 = true;
					sxRng.arrayList_0 = new ArrayList();
					array3 = class3.method_39(text, text2, groupByList, 0.0, pivotGroupByType_);
					object[] array5 = array3;
					foreach (object obj3 in array5)
					{
						Class1158 class4 = new Class1158();
						class4.object_0 = obj3;
						sxRng.arrayList_0.Add(class4);
					}
					class3.arrayList_0 = null;
					pivotField2.method_0();
					class1141_0.arrayList_0.Add(class3);
				}
				return;
			}
			throw new ArgumentException("The start value must not be greater than the end value.");
		}
		throw new ArgumentException("Invalid pivot field.");
	}

	/// <summary>
	///       Sets ungroup by the PivotTable
	///       </summary>
	/// <param name="baseFieldIndex">The row or column field index in the base fields</param>
	public void SetUngroup(int baseFieldIndex)
	{
		PivotField pivotField = BaseFields[baseFieldIndex];
		if (pivotField == null || (pivotField.pivotFieldType_0 != PivotFieldType.Row && pivotField.pivotFieldType_0 != PivotFieldType.Column))
		{
			throw new ArgumentException("Invalid pivot field index.");
		}
		SetUngroup(pivotField);
	}

	/// <summary>
	///       Sets ungroup by the PivotTable
	///       </summary>
	/// <param name="pivotField">The row or column field in the base fields</param>
	public void SetUngroup(PivotField pivotField)
	{
		if (pivotField == null || (pivotField.pivotFieldType_0 != PivotFieldType.Row && pivotField.pivotFieldType_0 != PivotFieldType.Column))
		{
			throw new ArgumentException("Invalid pivot field.");
		}
		pivotField.class1161_0.sxRng_0 = null;
		pivotField.class1161_0.method_21(bool_2: false);
		pivotField.method_1();
		pivotField.InitPivotItems();
	}

	private void method_16(ArrayList arrayList_3, Class1725 class1725_0)
	{
		foreach (byte[] item in arrayList_3)
		{
			class1725_0.method_3(item);
		}
	}

	internal void Write(Class1725 class1725_0)
	{
		if (arrayList_2 != null)
		{
			method_16(arrayList_2, class1725_0);
			return;
		}
		Class576 @class = new Class576(class1175_0);
		@class.vmethod_0(class1725_0);
		method_17(class1725_0);
		method_18(class1725_0);
		Class567 class2 = new Class567();
		class2.method_4(arrayList_0);
		class2.vmethod_0(class1725_0);
		class2.method_4(arrayList_1);
		class2.vmethod_0(class1725_0);
		class1160_0.short_0 = (short)class1164_0.Count;
		Class559 class3 = new Class559(class1160_0);
		class3.vmethod_0(class1725_0);
		if (class1160_0.arrayList_0 != null)
		{
			method_16(class1160_0.arrayList_0, class1725_0);
		}
		for (int i = 0; i < class1164_0.Count; i++)
		{
			Class1163 class4 = class1164_0[i];
			if (class4.byte_0 == 1 && class4.int_0 == -1)
			{
				continue;
			}
			Class554 class5 = new Class554(class4);
			Style style = class4.method_1();
			Class553 class6 = new Class553(style);
			class5.method_5(class6.Length);
			class5.vmethod_0(class1725_0);
			Class1171 class1171_ = class4.class1171_0;
			Class572 class7 = new Class572(class1171_);
			class7.vmethod_0(class1725_0);
			for (int j = 0; j < class1171_.arrayList_0.Count; j++)
			{
				Class1162 class8 = (Class1162)class1171_.arrayList_0[j];
				Class562 class9 = new Class562(class8);
				class9.vmethod_0(class1725_0);
				if (class8.arrayList_0.Count > 0)
				{
					Class565 class10 = new Class565(class8.arrayList_0);
					class10.vmethod_0(class1725_0);
				}
			}
			class6.vmethod_0(class1725_0);
		}
		try
		{
			Class555 class11 = new Class555();
			class11.method_4(class1172_0);
			class11.vmethod_0(class1725_0);
		}
		catch (Exception)
		{
		}
		Class575 class12 = new Class575(class1176_0);
		class12.vmethod_0(class1725_0);
		if (class1140_0.Count > 0)
		{
			PivotField pivotField = null;
			for (int k = 0; k < class1140_0.Count; k++)
			{
				byte[] array = class1140_0[k];
				if (array[0] == 0)
				{
					if (array[1] == 30)
					{
						Class1157.smethod_5(class1725_0, 0, 30, this, null, null);
					}
					else if (array[1] == 2)
					{
						Class1157.smethod_5(class1725_0, 0, 2, this, null, null);
					}
					else
					{
						Class1157.smethod_0(class1725_0, class1140_0[k]);
					}
				}
				else if (array[0] == 23)
				{
					if (array[1] == 0)
					{
						int num = 8;
						int num2 = BitConverter.ToInt16(array, 8);
						if (num2 > 0)
						{
							num += 2;
							string name = Class1156.smethod_8(ref num, num2, array);
							pivotField = BaseFields[name];
						}
						Class1157.smethod_0(class1725_0, class1140_0[k]);
					}
					else if (array[1] == 25)
					{
						Class1157.smethod_5(class1725_0, 23, 25, this, null, pivotField);
					}
					else
					{
						Class1157.smethod_0(class1725_0, class1140_0[k]);
					}
				}
				else
				{
					Class1157.smethod_0(class1725_0, class1140_0[k]);
				}
			}
		}
		else
		{
			Class1157.smethod_3(class1725_0, this);
		}
	}

	internal void method_17(Class1725 class1725_0)
	{
		foreach (PivotField item in BaseFields.arrayList_0)
		{
			Class574 @class = new Class574();
			@class.method_4(item.class1173_0);
			@class.vmethod_0(class1725_0);
			if (item.pivotItemCollection_0 != null && item.pivotItemCollection_0.Count != 0)
			{
				item.pivotItemCollection_0.Write(class1725_0);
			}
			Class573 class2 = new Class573();
			class2.method_4(item.class1174_0);
			class2.vmethod_0(class1725_0);
		}
	}

	internal void method_18(Class1725 class1725_0)
	{
		PivotFieldCollection pivotFieldCollection_ = class1175_0.pivotFieldCollection_2;
		PivotFieldCollection pivotFieldCollection_2 = class1175_0.pivotFieldCollection_3;
		PivotFieldCollection pivotFieldCollection_3 = class1175_0.pivotFieldCollection_4;
		PivotFieldCollection pivotFieldCollection_4 = class1175_0.pivotFieldCollection_1;
		int count = pivotFieldCollection_.Count;
		int count2 = pivotFieldCollection_2.Count;
		Class566 @class = new Class566();
		if (count != 0)
		{
			@class.method_4(pivotFieldCollection_);
			@class.vmethod_0(class1725_0);
		}
		if (count2 != 0)
		{
			@class.method_4(pivotFieldCollection_2);
			@class.vmethod_0(class1725_0);
		}
		if (pivotFieldCollection_3.Count != 0)
		{
			Class570 class2 = new Class570();
			class2.method_4(pivotFieldCollection_3);
			class2.vmethod_0(class1725_0);
		}
		if (pivotFieldCollection_4.Count != 0)
		{
			Class558 class3 = new Class558();
			for (int i = 0; i < pivotFieldCollection_4.Count; i++)
			{
				class3.method_4(pivotFieldCollection_4[i].class1159_0);
				class3.vmethod_0(class1725_0);
			}
		}
	}
}
