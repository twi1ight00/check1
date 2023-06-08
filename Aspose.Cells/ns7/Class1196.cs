using System;
using System.Runtime.CompilerServices;
using Aspose.Cells;

namespace ns7;

internal class Class1196
{
	internal object object_0;

	internal int int_0;

	internal string string_0;

	internal bool bool_0 = true;

	internal bool bool_1;

	internal bool bool_2;

	internal CellValueType cellValueType_0;

	internal string StringValue
	{
		get
		{
			if (object_0 == null)
			{
				return "";
			}
			return object_0.ToString();
		}
	}

	internal Class1196()
	{
	}

	internal Class1196(object object_1, int int_1, string string_1)
	{
		object_0 = object_1;
		int_0 = int_1;
		string_0 = string_1;
		if (object_1 == null)
		{
			cellValueType_0 = CellValueType.IsNull;
			bool_1 = true;
			return;
		}
		bool_1 = false;
		switch (Type.GetTypeCode(object_1.GetType()))
		{
		case TypeCode.DateTime:
			cellValueType_0 = CellValueType.IsDateTime;
			break;
		case TypeCode.String:
			cellValueType_0 = CellValueType.IsString;
			break;
		case TypeCode.Int32:
		case TypeCode.Double:
			cellValueType_0 = CellValueType.IsNumeric;
			break;
		case TypeCode.Boolean:
			cellValueType_0 = CellValueType.IsBool;
			break;
		}
	}

	[SpecialName]
	internal string method_0()
	{
		string result = "0";
		if (object_0 == null)
		{
			result = "0";
		}
		else
		{
			if (cellValueType_0 == CellValueType.IsBool)
			{
				if ((bool)object_0)
				{
					return "1";
				}
				return "0";
			}
			if (cellValueType_0 == CellValueType.IsDateTime)
			{
				result = object_0.ToString();
			}
			else if (cellValueType_0 == CellValueType.IsNumeric)
			{
				result = object_0.ToString();
			}
		}
		return result;
	}
}
