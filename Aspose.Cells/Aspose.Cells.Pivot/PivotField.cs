using System.Collections;
using System.Runtime.CompilerServices;
using ns16;
using ns45;

namespace Aspose.Cells.Pivot;

/// <summary>
///       Represents a field in a PivotTable report.
///       </summary>
public class PivotField
{
	internal PivotFieldCollection pivotFieldCollection_0;

	internal Class1173 class1173_0;

	internal Class1174 class1174_0;

	internal PivotItemCollection pivotItemCollection_0;

	internal Class1171 class1171_0;

	internal int int_0;

	internal Class1161 class1161_0;

	internal Class1159 class1159_0;

	internal Class1170 class1170_0;

	internal PivotField pivotField_0;

	internal PivotTable pivotTable_0;

	internal PivotFieldType pivotFieldType_0;

	internal bool bool_0;

	internal bool bool_1;

	internal bool bool_2;

	internal bool bool_3;

	internal bool bool_4;

	internal string string_0 = "{2946ED86-A175-432a-8AC1-64E0C546D7DE}";

	internal int int_1;

	internal bool bool_5;

	private bool bool_6;

	/// <summary>
	///       Gets the pivot items of the pivot field
	///       </summary>
	public PivotItemCollection PivotItems => pivotItemCollection_0;

	/// <summary>
	///       Gets the group range of the pivot field
	///       </summary>
	public SxRng Range
	{
		get
		{
			if (class1161_0 != null)
			{
				return class1161_0.sxRng_0;
			}
			return null;
		}
	}

	/// <summary>
	///       Indicates whether the specified PivotTable field is calculated field.
	///       </summary>
	public bool IsCalculatedField
	{
		get
		{
			if (pivotField_0 != null && pivotField_0.class1161_0 != null)
			{
				return pivotField_0.class1161_0.method_18();
			}
			return false;
		}
	}

	/// <summary>
	///       Represents the PivotField index in the base PivotFields.
	///       </summary>
	public int BaseIndex
	{
		get
		{
			return pivotField_0.Index;
		}
		set
		{
			pivotField_0.Index = value;
		}
	}

	/// <summary>
	///       Represents the PivotField index in the PivotFields.
	///       </summary>
	public int Position
	{
		get
		{
			PivotFieldCollection pivotFieldCollection = pivotFieldCollection_0.pivotTable_0.Fields(pivotFieldType_0);
			return pivotFieldCollection.method_7(this);
		}
	}

	/// <summary>
	///       Represents the PivotField name.
	///       </summary>
	public string Name
	{
		get
		{
			if (method_6())
			{
				return pivotTable_0.class1175_0.string_1;
			}
			if (pivotField_0.class1161_0 != null)
			{
				return pivotField_0.class1161_0.string_0;
			}
			return null;
		}
	}

	/// <summary>
	///       Represents the PivotField display name.
	///       </summary>
	public string DisplayName
	{
		get
		{
			if (method_6())
			{
				return pivotTable_0.class1175_0.string_1;
			}
			if (method_8())
			{
				return class1159_0.Name;
			}
			return class1173_0.string_0;
		}
		set
		{
			if (method_6())
			{
				pivotTable_0.class1175_0.string_1 = value;
			}
			else if (method_8())
			{
				class1159_0.Name = value;
			}
			else
			{
				class1173_0.string_0 = value;
			}
		}
	}

	/// <summary>
	///       Indicates whether the specified field shows automatic subtotals. Default is true.
	///       </summary>
	public bool IsAutoSubtotals
	{
		get
		{
			if (method_6())
			{
				return true;
			}
			if (method_9())
			{
				return false;
			}
			return class1173_0.ushort_0 == 1;
		}
		set
		{
			method_12();
			if (method_8())
			{
				throw new CellsException(ExceptionType.PivotTable, "Subtotals are only valid for nondata fields");
			}
			if (value)
			{
				class1173_0.ushort_0 = 1;
			}
			else if (class1173_0.ushort_0 == 1)
			{
				class1173_0.ushort_0 = 0;
			}
			pivotFieldCollection_0.pivotTable_0.bool_1 = false;
		}
	}

	/// <summary>
	///       Indicates whether the specified field can be dragged to the column position.
	///       The default value is true.
	///       </summary>
	public bool DragToColumn
	{
		get
		{
			if (method_6())
			{
				return true;
			}
			return pivotField_0.class1174_0.method_0(4);
		}
		set
		{
			if (!method_6())
			{
				pivotField_0.class1174_0.method_1(value, 4);
			}
		}
	}

	/// <summary>
	///        Indicates whether the specified field can be dragged to the hide position.
	///        The default value is true.
	///       </summary>
	public bool DragToHide
	{
		get
		{
			if (method_6())
			{
				return true;
			}
			return pivotField_0.class1174_0.method_0(16);
		}
		set
		{
			if (!method_6())
			{
				pivotField_0.class1174_0.method_1(value, 16);
			}
		}
	}

	/// <summary>
	///       Indicates whether the specified field can be dragged to the row position.
	///       The default value is true. 
	///       </summary>
	public bool DragToRow
	{
		get
		{
			if (method_6())
			{
				return true;
			}
			return pivotField_0.class1174_0.method_0(2);
		}
		set
		{
			if (!method_6())
			{
				pivotField_0.class1174_0.method_1(value, 2);
			}
		}
	}

	/// <summary>
	///       Indicates whether the specified field can be dragged to the page position.
	///        The default value is true.  
	///       </summary>
	public bool DragToPage
	{
		get
		{
			if (method_6())
			{
				return false;
			}
			return pivotField_0.class1174_0.method_0(8);
		}
		set
		{
			if (!method_6())
			{
				pivotField_0.class1174_0.method_1(value, 8);
			}
		}
	}

	/// <summary>
	///       Indicates whether the specified field can be dragged to the data position.
	///        The default value is true.  
	///       </summary>
	public bool DragToData
	{
		get
		{
			if (method_6())
			{
				return true;
			}
			return !pivotField_0.class1174_0.method_0(32);
		}
		set
		{
			pivotField_0.class1174_0.method_1(!value, 32);
		}
	}

	/// <summary>
	///       indicates whether the field can have multiple items
	///       selected in the page field
	///       The default value is false. 
	///       </summary>
	public bool IsMultipleItemSelectionAllowed
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
	///       indicates whether the field can repeat items labels
	///       The default value is false. 
	///       </summary>
	public bool IsRepeatItemLabels
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	/// <summary>
	///       indicates whether the field can include new items in manual filter
	///       The default value is false. 
	///       </summary>
	public bool IsIncludeNewItemsInFilter
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	/// <summary>
	///       indicates whether the field can insert page breaks between items
	///       insert page break after each item
	///       The default value is false. 
	///       </summary>
	public bool IsInsertPageBreaksBetweenItems
	{
		get
		{
			return pivotField_0.class1174_0.method_0(16384);
		}
		set
		{
			pivotField_0.class1174_0.method_1(value, 16384);
		}
	}

	/// <summary>
	///       Indicates whether all items in the PivotTable report are displayed, 
	///       even if they don't contain summary data.
	///       show items with no data
	///       The default value is false. 
	///       </summary>
	public bool ShowAllItems
	{
		get
		{
			if (method_6())
			{
				return true;
			}
			return pivotField_0.class1174_0.method_0(1);
		}
		set
		{
			if (!method_6())
			{
				pivotField_0.class1174_0.method_1(value, 1);
			}
		}
	}

	/// <summary>
	///       Indicates whether the specified PivotTable field is automatically sorted.
	///       </summary>
	public bool IsAutoSort
	{
		get
		{
			if (method_6())
			{
				return true;
			}
			switch (pivotFieldType_0)
			{
			default:
				return false;
			case PivotFieldType.Row:
			case PivotFieldType.Column:
			case PivotFieldType.Page:
				return class1174_0.method_0(512);
			}
		}
		set
		{
			if (!method_6())
			{
				switch (pivotFieldType_0)
				{
				case PivotFieldType.Row:
				case PivotFieldType.Column:
				case PivotFieldType.Page:
					class1174_0.method_1(value, 512);
					break;
				}
				pivotFieldCollection_0.pivotTable_0.bool_1 = false;
			}
		}
	}

	/// <summary>
	///       Indicates whether the specified PivotTable field is autosorted ascending.
	///       </summary>
	public bool IsAscendSort
	{
		get
		{
			if (method_6())
			{
				return true;
			}
			if (!IsAutoSort)
			{
				return true;
			}
			return class1174_0.method_0(1024);
		}
		set
		{
			method_12();
			if (IsAutoSort)
			{
				class1174_0.method_1(value, 1024);
			}
			pivotFieldCollection_0.pivotTable_0.bool_1 = false;
		}
	}

	/// <summary>
	///       Represents auto sort field index. 
	///       -1 means PivotField itself,others means the position of the data fields.
	///       </summary>
	public int AutoSortField
	{
		get
		{
			if (method_6())
			{
				return -1;
			}
			switch (pivotFieldType_0)
			{
			default:
				return -1;
			case PivotFieldType.Row:
			case PivotFieldType.Column:
			case PivotFieldType.Page:
				return class1174_0.method_3();
			}
		}
		set
		{
			method_12();
			switch (pivotFieldType_0)
			{
			case PivotFieldType.Row:
			case PivotFieldType.Column:
			case PivotFieldType.Page:
				if (IsAutoSort)
				{
					class1174_0.short_1 = (short)value;
					pivotFieldCollection_0.pivotTable_0.bool_1 = false;
				}
				break;
			case (PivotFieldType)3:
				break;
			}
		}
	}

	/// <summary>
	///       Indicates whether the specified PivotTable field is automatically shown,only valid for excel 2003.
	///       </summary>
	public bool IsAutoShow
	{
		get
		{
			if (!method_6() && !method_4())
			{
				return class1174_0.method_0(2048);
			}
			return false;
		}
		set
		{
			method_12();
			if (!method_4())
			{
				class1174_0.method_1(value, 2048);
			}
			pivotFieldCollection_0.pivotTable_0.bool_1 = false;
		}
	}

	/// <summary>
	///       Indicates whether the specified PivotTable field is autoshown ascending.
	///       </summary>
	public bool IsAscendShow
	{
		get
		{
			if (IsAutoShow)
			{
				return class1174_0.method_0(4096);
			}
			return true;
		}
		set
		{
			method_12();
			if (IsAutoShow)
			{
				class1174_0.method_1(value, 4096);
			}
			pivotFieldCollection_0.pivotTable_0.bool_1 = false;
		}
	}

	/// <summary>
	///       Represent the number of top or bottom items
	///       that are automatically shown in the specified PivotTable field.
	///       </summary>
	public int AutoShowCount
	{
		get
		{
			if (!method_6() && !method_4())
			{
				if (int_0 > 0)
				{
					return int_0;
				}
				return class1174_0.byte_1;
			}
			return 10;
		}
		set
		{
			method_12();
			if (IsAutoShow)
			{
				class1174_0.byte_1 = (byte)value;
				pivotFieldCollection_0.pivotTable_0.bool_1 = false;
			}
		}
	}

	/// <summary>
	///       Represents auto show field index. -1 means PivotField itself.
	///       It should be the index of the data fields.
	///       </summary>
	public int AutoShowField
	{
		get
		{
			if (!method_6() && !method_4())
			{
				return class1174_0.method_2();
			}
			return -1;
		}
		set
		{
			method_12();
			if (!method_4() && IsAutoShow)
			{
				class1174_0.short_2 = (short)value;
			}
		}
	}

	/// <summary>
	///       Represents the function used to summarize the PivotTable data field.
	///       </summary>
	public ConsolidationFunction Function
	{
		get
		{
			if (method_6())
			{
				return ConsolidationFunction.Sum;
			}
			if (method_4())
			{
				return class1159_0.consolidationFunction_0;
			}
			return ConsolidationFunction.Sum;
		}
		set
		{
			method_12();
			if (method_4())
			{
				class1159_0.consolidationFunction_0 = value;
			}
			pivotFieldCollection_0.pivotTable_0.bool_1 = false;
		}
	}

	/// <summary>
	///       Represents how to display the values contained in a data field.
	///       </summary>
	/// <see cref="T:Aspose.Cells.Pivot.PivotFieldDataDisplayFormat" />
	public PivotFieldDataDisplayFormat DataDisplayFormat
	{
		get
		{
			if (method_6())
			{
				return PivotFieldDataDisplayFormat.Normal;
			}
			if (method_4())
			{
				return class1159_0.pivotFieldDataDisplayFormat_0;
			}
			return PivotFieldDataDisplayFormat.Normal;
		}
		set
		{
			method_12();
			if (method_4())
			{
				pivotFieldCollection_0.pivotTable_0.bool_1 = false;
				class1159_0.pivotFieldDataDisplayFormat_0 = value;
				switch (value)
				{
				case PivotFieldDataDisplayFormat.Normal:
					class1159_0.int_0 = 0;
					class1159_0.int_1 = 0;
					break;
				case PivotFieldDataDisplayFormat.PercentageDifferenceFrom:
				case PivotFieldDataDisplayFormat.PercentageOfRow:
				case PivotFieldDataDisplayFormat.PercentageOfColumn:
				case PivotFieldDataDisplayFormat.PercentageOfTotal:
					class1159_0.short_0 = 10;
					break;
				case PivotFieldDataDisplayFormat.RunningTotalIn:
				case PivotFieldDataDisplayFormat.Index:
					class1159_0.short_0 = 10;
					class1159_0.int_1 = 32763;
					break;
				case PivotFieldDataDisplayFormat.DifferenceFrom:
				case PivotFieldDataDisplayFormat.PercentageOf:
					break;
				}
			}
		}
	}

	/// <summary>
	///       Represents the base field for a custom calculation.
	///       </summary>
	public int BaseField
	{
		get
		{
			if (method_6())
			{
				return 0;
			}
			if (method_4())
			{
				return class1159_0.int_0;
			}
			return 0;
		}
		set
		{
			method_12();
			if (method_4())
			{
				switch (class1159_0.pivotFieldDataDisplayFormat_0)
				{
				case PivotFieldDataDisplayFormat.DifferenceFrom:
				case PivotFieldDataDisplayFormat.PercentageOf:
				case PivotFieldDataDisplayFormat.PercentageDifferenceFrom:
				case PivotFieldDataDisplayFormat.RunningTotalIn:
					_ = pivotFieldCollection_0.pivotTable_0.BaseFields[value];
					class1159_0.int_0 = value;
					break;
				}
				pivotFieldCollection_0.pivotTable_0.bool_1 = false;
			}
		}
	}

	public PivotItemPosition BaseItemPosition
	{
		get
		{
			if (method_6())
			{
				return PivotItemPosition.Previous;
			}
			if (method_4())
			{
				return class1159_0.int_1 switch
				{
					32763 => PivotItemPosition.Previous, 
					32764 => PivotItemPosition.Next, 
					_ => PivotItemPosition.Previous, 
				};
			}
			return PivotItemPosition.Previous;
		}
		set
		{
			method_12();
			if (method_4())
			{
				class1159_0.int_1 = (short)value;
				pivotFieldCollection_0.pivotTable_0.bool_1 = false;
			}
		}
	}

	/// <summary>
	///        Represents the item in the base field for a custom calculation.
	///        Valid only for data fields. 
	///       </summary>
	public int BaseItem
	{
		get
		{
			if (method_6())
			{
				return 0;
			}
			if (method_4())
			{
				return class1159_0.int_1;
			}
			return 0;
		}
		set
		{
			method_12();
			if (method_4())
			{
				switch (class1159_0.pivotFieldDataDisplayFormat_0)
				{
				case PivotFieldDataDisplayFormat.DifferenceFrom:
				case PivotFieldDataDisplayFormat.PercentageOf:
				case PivotFieldDataDisplayFormat.PercentageDifferenceFrom:
					_ = pivotFieldCollection_0.pivotTable_0.BaseFields[class1159_0.int_0].pivotItemCollection_0[value];
					class1159_0.int_1 = (short)value;
					break;
				}
				pivotFieldCollection_0.pivotTable_0.bool_1 = false;
			}
		}
	}

	/// <summary>
	///       Represents the current page item showing for the page field (valid only for page fields). 
	///       </summary>
	public short CurrentPageItem
	{
		get
		{
			if (pivotField_0.class1170_0 != null)
			{
				return pivotField_0.class1170_0.short_0;
			}
			return 32765;
		}
		set
		{
			if (pivotField_0.class1170_0 != null)
			{
				pivotField_0.class1170_0.short_0 = value;
				pivotFieldCollection_0.pivotTable_0.bool_1 = false;
			}
		}
	}

	/// <summary>
	///       Represents the built-in display format of numbers and dates.
	///       </summary>
	public int Number
	{
		get
		{
			if (method_6())
			{
				return 0;
			}
			if (method_8())
			{
				return class1159_0.short_0;
			}
			return class1174_0.short_0;
		}
		set
		{
			method_12();
			if (method_8())
			{
				class1159_0.NumberFormat = null;
				class1159_0.short_0 = (short)value;
			}
			else
			{
				class1174_0.NumberFormat = null;
				class1174_0.short_0 = (short)value;
			}
			pivotFieldCollection_0.pivotTable_0.bool_1 = false;
		}
	}

	/// <summary>
	///       Indicates whether inserting blank line after each item.
	///       </summary>
	public bool InsertBlankRow
	{
		get
		{
			if (method_6())
			{
				return true;
			}
			return (class1174_0.byte_0 & 0x40) != 0;
		}
		set
		{
			if (!method_6())
			{
				if (value)
				{
					class1174_0.byte_0 |= 64;
				}
				else
				{
					class1174_0.byte_0 &= 191;
				}
			}
		}
	}

	/// <summary>
	///       when ShowInOutlineForm is true, then display subtotals at the top of the list of items instead of at the bottom
	///       </summary>
	public bool ShowSubtotalAtTop
	{
		get
		{
			if (method_6())
			{
				return true;
			}
			return (class1174_0.byte_0 & 0x80) != 0;
		}
		set
		{
			if (!method_6())
			{
				if (value)
				{
					class1174_0.byte_0 |= 128;
				}
				else
				{
					class1174_0.byte_0 &= 127;
				}
			}
		}
	}

	/// <summary>
	///       Indicates whether layout this field in outline form on the Pivot Table view
	///       </summary>
	public bool ShowInOutlineForm
	{
		get
		{
			if (method_6())
			{
				return true;
			}
			return (class1174_0.byte_0 & 0x20) != 0;
		}
		set
		{
			if (!method_6())
			{
				if (value)
				{
					class1174_0.byte_0 |= 32;
				}
				else
				{
					class1174_0.byte_0 &= 223;
				}
			}
		}
	}

	/// <summary>
	///       Represents the custom display format of numbers and dates.
	///       </summary>
	public string NumberFormat
	{
		get
		{
			string text = "";
			text = (method_6() ? "" : ((!method_8()) ? class1174_0.NumberFormat : class1159_0.NumberFormat));
			if (text == null)
			{
				text = "";
			}
			return text;
		}
		set
		{
			method_12();
			if (method_8())
			{
				class1159_0.short_0 = 0;
				class1159_0.NumberFormat = value;
			}
			else
			{
				class1174_0.short_0 = 0;
				class1174_0.NumberFormat = value;
			}
			pivotFieldCollection_0.pivotTable_0.bool_1 = false;
		}
	}

	/// <summary>
	///       Get all base items;
	///       </summary>
	public string[] Items
	{
		get
		{
			int count = pivotItemCollection_0.Count;
			string[] array = new string[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = pivotItemCollection_0[i].Name;
				if (array[i] == null)
				{
					array[i] = "(blank)";
				}
			}
			return array;
		}
	}

	public string[] OriginalItems
	{
		get
		{
			if (class1161_0 != null && class1161_0.arrayList_0 != null)
			{
				if (class1161_0.arrayList_0.Count == 0)
				{
					if (class1161_0.method_27())
					{
						return null;
					}
					if (class1161_0.method_0().class1144_0 != null)
					{
						class1161_0.method_0().class1144_0.method_1(class1161_0);
					}
					if (class1161_0.method_27())
					{
						return null;
					}
				}
				int count = class1161_0.arrayList_0.Count;
				string[] array = new string[count];
				for (int i = 0; i < count; i++)
				{
					object object_ = ((Class1158)class1161_0.arrayList_0[i]).object_0;
					if (object_ == null)
					{
						array[i] = "(blank)";
					}
					else
					{
						array[i] = object_.ToString();
					}
				}
				return array;
			}
			return null;
		}
	}

	/// <summary>
	///       Gets the base item count of this pivot field.
	///       </summary>
	public int ItemCount => pivotItemCollection_0.Count;

	/// <summary>
	/// </summary>
	public bool ShowCompact
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	internal int Index
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
	///       Gets the pivot filter of the pivot field by type
	///       </summary>
	public PivotFilter GetPivotFilterByType(PivotFilterType type)
	{
		new ArrayList();
		int num = 0;
		PivotFilter pivotFilter;
		while (true)
		{
			if (num < pivotTable_0.PivotFilters.Count)
			{
				pivotFilter = pivotTable_0.PivotFilters[num];
				if (pivotFilter.pivotFilterType_0 == type && int_1 == pivotFilter.int_0)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return pivotFilter;
	}

	/// <summary>
	///       Gets the pivot filters of the pivot field 
	///       </summary>
	public ArrayList GetPivotFilters()
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < pivotTable_0.PivotFilters.Count; i++)
		{
			PivotFilter pivotFilter = pivotTable_0.PivotFilters[i];
			if (int_1 == pivotFilter.int_0)
			{
				arrayList.Add(pivotFilter);
			}
		}
		return arrayList;
	}

	internal PivotField(PivotTable pivotTable_1, PivotFieldCollection pivotFieldCollection_1)
	{
		pivotTable_0 = pivotTable_1;
		pivotFieldCollection_0 = pivotTable_1.BaseFields;
		pivotItemCollection_0 = new PivotItemCollection(this);
		pivotFieldType_0 = PivotFieldType.Row;
		for (int i = 0; i < 2 && i < pivotFieldCollection_1.Count; i++)
		{
			PivotItem pivotItem = new PivotItem(pivotItemCollection_0);
			pivotItemCollection_0.Add(pivotItem);
			pivotItem.Index = i;
			pivotItem.pivotField_0 = pivotFieldCollection_1[i];
		}
		pivotField_0 = this;
	}

	internal PivotField(PivotFieldCollection pivotFieldCollection_1)
	{
		pivotFieldCollection_0 = pivotFieldCollection_1;
		class1159_0 = new Class1159();
		class1173_0 = new Class1173(this);
		class1174_0 = new Class1174(this);
		pivotItemCollection_0 = new PivotItemCollection(this);
		pivotField_0 = this;
	}

	internal PivotField(PivotFieldCollection pivotFieldCollection_1, PivotField pivotField_1)
	{
		pivotFieldCollection_0 = pivotFieldCollection_1;
		pivotField_0 = pivotField_1;
		class1159_0 = new Class1159(this);
		pivotFieldType_0 = PivotFieldType.Data;
	}

	internal PivotField()
	{
		pivotItemCollection_0 = new PivotItemCollection(this);
	}

	internal void Copy(PivotField pivotField_1)
	{
		if (class1173_0 != null)
		{
			class1173_0.Copy(pivotField_1.class1173_0);
		}
		if (class1174_0 != null)
		{
			class1174_0.Copy(pivotField_1.class1174_0);
		}
		if (class1159_0 != null)
		{
			class1159_0.Copy(pivotField_1.class1159_0);
		}
		if (class1170_0 != null)
		{
			class1170_0.Copy(pivotField_1.class1170_0);
		}
		ShowCompact = pivotField_1.ShowCompact;
		bool_1 = pivotField_1.bool_1;
		bool_5 = pivotField_1.bool_5;
		if (pivotItemCollection_0 != null && pivotField_1.pivotItemCollection_0 != null)
		{
			pivotItemCollection_0.arrayList_0 = new ArrayList(pivotField_1.pivotItemCollection_0.Count);
			for (int i = 0; i < pivotField_1.pivotItemCollection_0.Count; i++)
			{
				pivotItemCollection_0.Add(pivotField_1.pivotItemCollection_0[i]);
			}
		}
	}

	/// <summary>
	///       Init the pivot items of the pivot field
	///       </summary>
	public void InitPivotItems()
	{
		if (pivotItemCollection_0.Count == 0 && class1161_0 != null && class1161_0.arrayList_0 != null)
		{
			int count = class1161_0.arrayList_0.Count;
			for (int i = 0; i < count; i++)
			{
				PivotItem pivotItem = new PivotItem(pivotItemCollection_0);
				pivotItemCollection_0.Add(pivotItem);
				pivotItem.Index = i;
			}
		}
	}

	internal void method_0()
	{
		if (pivotItemCollection_0.Count == 0 && class1161_0 != null && class1161_0.sxRng_0.arrayList_0 != null)
		{
			int count = class1161_0.sxRng_0.arrayList_0.Count;
			for (int i = 0; i < count; i++)
			{
				PivotItem pivotItem = new PivotItem(pivotItemCollection_0);
				pivotItemCollection_0.Add(pivotItem);
				pivotItem.Index = i;
			}
		}
	}

	internal void method_1()
	{
		pivotItemCollection_0 = new PivotItemCollection(this);
	}

	internal void method_2()
	{
		if (pivotItemCollection_0.Count > 0)
		{
			for (int i = 0; i < pivotItemCollection_0.Count; i++)
			{
				PivotItem pivotItem = pivotItemCollection_0[i];
				pivotItem.object_0 = pivotItem.Value;
			}
		}
	}

	[SpecialName]
	internal bool method_3()
	{
		return pivotField_0.class1161_0.method_5();
	}

	[SpecialName]
	internal bool method_4()
	{
		return pivotField_0.bool_5;
	}

	[SpecialName]
	internal void method_5(bool bool_7)
	{
		pivotField_0.bool_5 = bool_7;
	}

	/// <summary>
	///       Get the formula string of the specified calculated field .
	///       </summary>
	public string GetCalculatedFieldFormula()
	{
		if (pivotField_0 != null && pivotField_0.class1161_0 != null)
		{
			return Class1618.smethod_93(pivotField_0.class1161_0.string_1);
		}
		return null;
	}

	[SpecialName]
	internal bool method_6()
	{
		if (int_1 != -2)
		{
			return int_1 == 65534;
		}
		return true;
	}

	internal void method_7(int int_2)
	{
		pivotField_0.Index = int_2;
	}

	[SpecialName]
	internal bool method_8()
	{
		if (pivotFieldCollection_0 != null)
		{
			return pivotFieldCollection_0.pivotFieldType_0 == PivotFieldType.Data;
		}
		return false;
	}

	/// <summary>
	///       Sets whether the specified field shows that subtotals.
	///       </summary>
	/// <param name="subtotalType">subtotals type.</param>
	/// <param name="shown">whether the specified field shows that subtotals.</param>
	/// <see cref="T:Aspose.Cells.Pivot.PivotFieldSubtotalType" />
	public void SetSubtotals(PivotFieldSubtotalType subtotalType, bool shown)
	{
		method_12();
		if (method_4() && pivotFieldType_0 == PivotFieldType.Data)
		{
			throw new CellsException(ExceptionType.PivotTable, "Subtotals are only valid for nondata fields");
		}
		pivotFieldCollection_0.pivotTable_0.bool_1 = false;
		switch (subtotalType)
		{
		case PivotFieldSubtotalType.None:
			if (shown)
			{
				class1173_0.ushort_0 = (ushort)subtotalType;
			}
			else if (GetSubtotals(PivotFieldSubtotalType.None))
			{
				class1173_0.ushort_0 = 1;
			}
			return;
		case PivotFieldSubtotalType.Automatic:
			if (IsAutoSubtotals != shown)
			{
				if (shown)
				{
					class1173_0.ushort_0 = (ushort)subtotalType;
				}
				else
				{
					class1173_0.ushort_0 = 0;
				}
			}
			return;
		}
		if (GetSubtotals(subtotalType) != shown)
		{
			if (IsAutoSubtotals)
			{
				class1173_0.ushort_0 &= 254;
			}
			ushort num = (ushort)subtotalType;
			class1173_0.ushort_0 &= (ushort)(~num);
			class1173_0.ushort_0 |= (ushort)(shown ? num : 0);
		}
	}

	/// <summary>
	///       Gets whether the specified field shows that subtotals.
	///       </summary>
	/// <param name="subtotalType">subtotals type.</param>
	/// <returns>whether the specified field shows that subtotals.</returns>
	public bool GetSubtotals(PivotFieldSubtotalType subtotalType)
	{
		if (!method_6() && (!method_4() || pivotFieldType_0 != PivotFieldType.Data))
		{
			return subtotalType switch
			{
				PivotFieldSubtotalType.None => class1173_0.ushort_0 == 0, 
				PivotFieldSubtotalType.Automatic => class1173_0.ushort_0 == 1, 
				_ => (class1173_0.ushort_0 & (ushort)subtotalType) != 0, 
			};
		}
		return false;
	}

	[SpecialName]
	internal bool method_9()
	{
		if (!method_6() && (!method_4() || pivotFieldType_0 != PivotFieldType.Data))
		{
			return class1173_0.ushort_0 == 0;
		}
		return true;
	}

	internal void method_10(int int_2)
	{
		if (method_8())
		{
			class1159_0.short_0 = (short)int_2;
		}
		else
		{
			class1174_0.short_0 = (short)int_2;
		}
	}

	/// <summary>
	///       Indicates whether the specific PivotItem is hidden.
	///       </summary>
	/// <param name="index">the index of the pivotItem in the pivotField.</param>
	/// <returns>whether the specific PivotItem is hidden</returns>
	public bool IsHiddenItem(int index)
	{
		if (method_4())
		{
			return false;
		}
		if (pivotItemCollection_0.Count == 0)
		{
			return false;
		}
		return pivotItemCollection_0[index].IsHidden;
	}

	/// <summary>
	///        Sets whether the specific PivotItem in a data field is hidden.
	///       </summary>
	/// <param name="index">the index of the pivotItem in the pivotField.</param>
	/// <param name="isHidden">whether the specific PivotItem is hidden</param>
	public void HideItem(int index, bool isHidden)
	{
		if (method_8())
		{
			throw new CellsException(ExceptionType.PivotTable, "You can't hide/unhide one of the ");
		}
		pivotItemCollection_0[index].IsHidden = isHidden;
	}

	/// <summary>
	///       Indicates whether the specific PivotItem is hidden detail.
	///       </summary>
	/// <param name="index">the index of the pivotItem in the pivotField.</param>
	/// <returns>whether the specific PivotItem is hidden detail</returns>
	public bool IsHiddenItemDetail(int index)
	{
		if (method_4())
		{
			return false;
		}
		if (pivotItemCollection_0.Count == 0)
		{
			return false;
		}
		return pivotItemCollection_0[index].method_0();
	}

	/// <summary>
	///        Sets whether the specific PivotItem in a pivot field is hidden detail.
	///       </summary>
	/// <param name="index">the index of the pivotItem in the pivotField.</param>
	/// <param name="isHiddenDetail">whether the specific PivotItem is hidden</param>
	public void HideItemDetail(int index, bool isHiddenDetail)
	{
		if (method_8())
		{
			throw new CellsException(ExceptionType.PivotTable, "You can't hide/unhide detail one of the item");
		}
		pivotItemCollection_0[index].method_1(isHiddenDetail);
	}

	/// <summary>
	///        Sets whether the PivotItems in a pivot field is hidden detail.That is collapse/expand this field.
	///       </summary>
	/// <param name="isHiddenDetail">whether the PivotItems is hidden</param>
	public void HideDetail(bool isHiddenDetail)
	{
		if (method_8())
		{
			throw new CellsException(ExceptionType.PivotTable, "You can't hide/unhide data field's detail");
		}
		for (int i = 0; i < pivotItemCollection_0.Count; i++)
		{
			pivotItemCollection_0[i].method_1(isHiddenDetail);
		}
	}

	/// <summary>
	///        Sets whether the specific PivotItem in a data field is hidden.
	///       </summary>
	/// <param name="itemValue">the value of the pivotItem in the pivotField.</param>
	/// <param name="isHidden">whether the specific PivotItem is hidden</param>
	public void HideItem(string itemValue, bool isHidden)
	{
		if (method_8())
		{
			throw new CellsException(ExceptionType.PivotTable, "You can't hide/unhide one of the ");
		}
		PivotItem pivotItem = pivotItemCollection_0[itemValue];
		if (pivotItem != null)
		{
			pivotItem.IsHidden = isHidden;
		}
	}

	/// <summary>
	///       Add a calculated item to the pivot field.
	///       </summary>
	/// <param name="name">The item's name.</param>
	/// <param name="formula">The item's formula</param>
	/// <remarks>
	///       Only supports to add calculated item to Row/Column field.
	///       </remarks>
	public void AddCalculatedItem(string name, string formula)
	{
		PivotFieldType pivotFieldType = pivotFieldType_0;
		if (pivotFieldType != PivotFieldType.Page && pivotFieldType != PivotFieldType.Data)
		{
			Class1148 @class = null;
			PivotField pivotField = pivotField_0;
			pivotField = ((pivotField_0 != null) ? pivotField_0 : this);
			Class1141 class1141_ = pivotField.pivotFieldCollection_0.pivotTable_0.class1141_0;
			if (pivotField.class1161_0.arrayList_0 == null)
			{
				pivotField.class1161_0.arrayList_0 = new ArrayList();
			}
			@class = new Class1148(class1141_, this, name, formula, pivotFieldType_0, pivotField.class1161_0.arrayList_0.Count);
			Class1158 class2 = new Class1158();
			class2.bool_0 = true;
			class2.object_0 = name;
			pivotField.class1161_0.arrayList_0.Add(class2);
			class1141_.method_1(Index);
			if (class1141_.class988_0 == null)
			{
				class1141_.class988_0 = new Class988();
			}
			class1141_.class988_0.Add(@class);
			@class.SetFormula(BaseIndex, formula);
			if (pivotField_0 != null && pivotItemCollection_0 != null)
			{
				PivotItem pivotItem = new PivotItem(pivotItemCollection_0);
				pivotItem.Index = pivotItemCollection_0.Count;
				pivotItemCollection_0.Add(pivotItem);
				pivotItem.method_2(bool_3: true);
			}
		}
	}

	[SpecialName]
	internal bool method_11()
	{
		if (pivotItemCollection_0 != null)
		{
			for (int i = 0; i < pivotItemCollection_0.Count; i++)
			{
				PivotItem pivotItem = pivotItemCollection_0[i];
				if (pivotItem.IsFormula)
				{
					return true;
				}
			}
		}
		return false;
	}

	private void method_12()
	{
		if (method_6())
		{
			throw new CellsException(ExceptionType.PivotTable, "You can't operate the field ");
		}
	}
}
