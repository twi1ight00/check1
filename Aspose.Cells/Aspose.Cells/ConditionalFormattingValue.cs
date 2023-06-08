using System;
using System.Runtime.CompilerServices;
using ns12;
using ns2;

namespace Aspose.Cells;

/// <summary>
///       Describes the values of the interpolation points in a gradient scale, dataBar or iconSet.
///       </summary>
public class ConditionalFormattingValue
{
	private byte[] byte_0;

	internal double double_0 = double.MinValue;

	internal double double_1 = double.MaxValue;

	private object object_0;

	private FormatConditionValueType formatConditionValueType_0;

	private bool bool_0 = true;

	private FormatCondition formatCondition_0;

	/// <summary>
	///       Get or set the value of this conditional formatting value object.
	///       It should be used in conjunction with Type. 
	///       </summary>
	/// <remarks>
	///       If the value is string  and start with "=", it will be processed as a formula,
	///       otherwise we will process it as a simple value. 
	///       </remarks>
	public object Value
	{
		get
		{
			if (object_0 != null)
			{
				return object_0;
			}
			method_2();
			return object_0;
		}
		set
		{
			object_0 = value;
			byte_0 = null;
		}
	}

	/// <summary>
	///       Get or set the type of this conditional formatting value object.
	///       Setting the type to FormatConditionValueType.Min or FormatConditionValueType.Max 
	///       will auto set "Value" to null.
	///       </summary>
	public FormatConditionValueType Type
	{
		get
		{
			return formatConditionValueType_0;
		}
		set
		{
			formatConditionValueType_0 = value;
			if (value == FormatConditionValueType.Max || value == FormatConditionValueType.Min)
			{
				object_0 = null;
			}
		}
	}

	/// <summary>
	///       Get or set the Greater Than Or Equal flag. 
	///       Use only for icon sets, determines whether this threshold value uses 
	///       the greater than or equal to operator. 
	///       'false' indicates 'greater than' is used instead of 'greater than or equal to'.
	///       Default value is true.
	///       </summary>
	public bool IsGTE
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

	internal bool IsFormula
	{
		get
		{
			if (byte_0 != null)
			{
				return !Class1674.smethod_2(formatCondition_0.Worksheets, byte_0, -1, bool_0: false);
			}
			if (object_0 != null && object_0 is string)
			{
				return ((string)object_0).StartsWith("=");
			}
			return false;
		}
	}

	internal void Copy(ConditionalFormattingValue conditionalFormattingValue_0, WorksheetCollection worksheetCollection_0, WorksheetCollection worksheetCollection_1, CopyOptions copyOptions_0, int int_0, int int_1)
	{
		object_0 = conditionalFormattingValue_0.object_0;
		bool_0 = conditionalFormattingValue_0.bool_0;
		formatConditionValueType_0 = conditionalFormattingValue_0.formatConditionValueType_0;
		if (conditionalFormattingValue_0.byte_0 != null)
		{
			byte_0 = Class1379.Copy(worksheetCollection_0, worksheetCollection_1, conditionalFormattingValue_0.byte_0, -1, int_0, int_1);
			if (copyOptions_0 != null && !copyOptions_0.bool_0 && copyOptions_0.hashtable_1 != null)
			{
				Class1674.smethod_17(byte_0, -1, byte_0.Length, copyOptions_0.hashtable_1, worksheetCollection_1);
			}
		}
	}

	internal ConditionalFormattingValue(FormatCondition formatCondition_1)
	{
		formatCondition_0 = formatCondition_1;
	}

	internal ConditionalFormattingValue(FormatCondition formatCondition_1, FormatConditionValueType formatConditionValueType_1, object object_1)
	{
		formatCondition_0 = formatCondition_1;
		Value = object_1;
		formatConditionValueType_0 = formatConditionValueType_1;
	}

	internal void method_0(double double_2)
	{
		object_0 = double_2;
	}

	internal void method_1()
	{
		if (object_0 == null)
		{
			return;
		}
		if (object_0 is string && ((string)object_0).StartsWith("="))
		{
			string string_ = (string)object_0;
			int[] array = formatCondition_0.formatConditionCollection_0.method_9();
			if (array != null)
			{
				int int_ = array[0];
				int int_2 = array[1];
				byte_0 = formatCondition_0.Worksheets.Formula.method_3(string_, int_, int_2, Enum226.const_0, Enum227.const_1, bool_0: true, bool_1: true);
			}
		}
		else
		{
			byte_0 = Class1674.smethod_0(formatCondition_0.Worksheets, object_0);
		}
	}

	internal void method_2()
	{
		if (byte_0 == null)
		{
			return;
		}
		if (formatCondition_0.Worksheets.Workbook.method_24())
		{
			if (byte_0.Length == 4)
			{
				return;
			}
		}
		else if (byte_0.Length == 2)
		{
			return;
		}
		object_0 = Class1674.smethod_1(formatCondition_0.Worksheets, byte_0, -1);
		if (object_0 == null)
		{
			int[] array = formatCondition_0.formatConditionCollection_0.method_9();
			if (array != null)
			{
				int int_ = array[0];
				int int_2 = array[1];
				object_0 = formatCondition_0.Worksheets.method_4().method_3(-1, byte_0, int_, int_2, bool_0: true);
			}
		}
	}

	[SpecialName]
	internal string method_3()
	{
		if (byte_0 == null)
		{
			if (object_0 == null)
			{
				return null;
			}
			if (object_0 is string)
			{
				string text = (string)object_0;
				if (text.StartsWith("="))
				{
					return text.Substring(1);
				}
				return text;
			}
			return object_0.ToString();
		}
		int[] array = formatCondition_0.formatConditionCollection_0.method_9();
		if (array == null)
		{
			array = new int[2];
		}
		int int_ = array[0];
		int int_2 = array[1];
		string text2 = formatCondition_0.Worksheets.method_4().method_3(-1, byte_0, int_, int_2, bool_0: true);
		return text2.Substring(1);
	}

	[SpecialName]
	internal void method_4(string string_0)
	{
		string string_ = "=" + string_0;
		int[] array = formatCondition_0.formatConditionCollection_0.method_9();
		if (array == null)
		{
			array = new int[2];
		}
		int int_ = array[0];
		int int_2 = array[1];
		method_7(formatCondition_0.Worksheets.Formula.method_3(string_, int_, int_2, Enum226.const_0, Enum227.const_1, bool_0: true, bool_1: true));
	}

	[SpecialName]
	internal double method_5()
	{
		if (object_0 == null)
		{
			return 0.0;
		}
		if (object_0 is int)
		{
			return (int)object_0;
		}
		if (object_0 is double)
		{
			return (double)object_0;
		}
		if (object_0 is DateTime)
		{
			return CellsHelper.GetDoubleFromDateTime((DateTime)object_0, formatCondition_0.Worksheets.Workbook.Settings.Date1904);
		}
		return 0.0;
	}

	[SpecialName]
	internal byte[] method_6()
	{
		if (byte_0 == null)
		{
			method_1();
		}
		return byte_0;
	}

	[SpecialName]
	internal void method_7(byte[] byte_1)
	{
		byte_0 = byte_1;
		object_0 = Class1674.smethod_1(formatCondition_0.Worksheets, byte_1, -1);
	}

	internal void method_8(bool bool_1, int int_0, int int_1)
	{
		if (byte_0 != null)
		{
			byte_0 = Class415.smethod_0(bool_1, byte_0, -1, int_0, int_1, bool_1: true);
		}
	}
}
