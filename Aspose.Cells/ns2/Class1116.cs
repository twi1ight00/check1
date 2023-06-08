using System;
using System.Runtime.CompilerServices;
using Aspose.Cells;

namespace ns2;

internal class Class1116
{
	internal int int_0;

	internal object object_0;

	internal CellValueType Type
	{
		get
		{
			if (object_0 == null)
			{
				return CellValueType.IsNull;
			}
			if (object_0 is ErrorType)
			{
				return CellValueType.IsError;
			}
			switch (System.Type.GetTypeCode(object_0.GetType()))
			{
			case TypeCode.Boolean:
				return CellValueType.IsBool;
			default:
				return CellValueType.IsString;
			case TypeCode.String:
				if (Class1673.smethod_8((string)object_0))
				{
					return CellValueType.IsError;
				}
				return CellValueType.IsString;
			case TypeCode.Int32:
			case TypeCode.Double:
				return CellValueType.IsNumeric;
			}
		}
	}

	internal double DoubleValue => (double)object_0;

	internal bool BoolValue => (bool)object_0;

	[SpecialName]
	internal Enum179 method_0()
	{
		if (object_0 == null)
		{
			return Enum179.const_0;
		}
		if (object_0 is ErrorType)
		{
			return Enum179.const_3;
		}
		switch (System.Type.GetTypeCode(object_0.GetType()))
		{
		default:
			return Enum179.const_2;
		case TypeCode.String:
			if (Class1673.smethod_8((string)object_0))
			{
				return Enum179.const_3;
			}
			return Enum179.const_2;
		case TypeCode.Double:
			return Enum179.const_1;
		case TypeCode.Boolean:
			return Enum179.const_4;
		}
	}

	internal Class1116(int int_1, object object_1)
	{
		int_0 = int_1;
		object_0 = object_1;
	}

	[SpecialName]
	internal ErrorType method_1()
	{
		bool isError;
		if (object_0 is string)
		{
			return Class1673.smethod_3((string)object_0, out isError);
		}
		return (ErrorType)object_0;
	}
}
