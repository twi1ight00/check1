using System;
using Aspose.Cells;

namespace ns12;

internal class Class1340
{
	internal static object smethod_0(object object_0)
	{
		if (object_0 == null)
		{
			return 1.0;
		}
		if (object_0 is ErrorType)
		{
			return 16.0;
		}
		switch (Type.GetTypeCode(object_0.GetType()))
		{
		case TypeCode.Double:
			return 1.0;
		case TypeCode.DateTime:
			return 1.0;
		default:
			if (object_0 is Array)
			{
				return 64.0;
			}
			return 1.0;
		case TypeCode.String:
			return 2.0;
		case TypeCode.Int32:
			return 1.0;
		case TypeCode.Boolean:
			return 4.0;
		}
	}

	internal static object smethod_1(object object_0, bool bool_0)
	{
		if (object_0 == null)
		{
			return 0.0;
		}
		if (object_0 is ErrorType)
		{
			return object_0;
		}
		switch (Type.GetTypeCode(object_0.GetType()))
		{
		case TypeCode.Double:
			return object_0;
		case TypeCode.DateTime:
			return CellsHelper.GetDoubleFromDateTime((DateTime)object_0, bool_0);
		default:
			if (object_0 is Array)
			{
				return smethod_2((Array)object_0, bool_0);
			}
			return 0.0;
		case TypeCode.String:
			return 0.0;
		case TypeCode.Int32:
			return (double)(int)object_0;
		case TypeCode.Boolean:
			if ((bool)object_0)
			{
				return 1.0;
			}
			return 0.0;
		}
	}

	internal static object smethod_2(Array array_0, bool bool_0)
	{
		object value = array_0.GetValue(0);
		object[][] array = new object[array_0.Length][];
		if (value is Array)
		{
			int length = ((Array)value).Length;
			for (int i = 0; i < array_0.Length; i++)
			{
				array[i] = new object[length];
				value = array_0.GetValue(i);
				if (value == null)
				{
					for (int j = 0; j < length; j++)
					{
						array[i][j] = 0.0;
					}
					continue;
				}
				Array array2 = (Array)value;
				for (int k = 0; k < length; k++)
				{
					array[i][k] = smethod_1(array2.GetValue(k), bool_0);
				}
			}
		}
		else
		{
			for (int l = 0; l < array_0.Length; l++)
			{
				array[l] = new object[1];
				array[l][0] = smethod_1(array_0.GetValue(l), bool_0);
			}
		}
		return array;
	}

	internal static object smethod_3(object object_0)
	{
		if (object_0 == null)
		{
			return ErrorType.NA;
		}
		if (object_0 is ErrorType)
		{
			switch ((ErrorType)object_0)
			{
			case ErrorType.Div:
				return 2.0;
			case ErrorType.NA:
				return 7.0;
			case ErrorType.Name:
				return 5.0;
			case ErrorType.Null:
				return 1.0;
			case ErrorType.Number:
				return 6.0;
			case ErrorType.Ref:
				return 4.0;
			case ErrorType.Value:
				return 3.0;
			}
		}
		return ErrorType.NA;
	}

	internal static object smethod_4(object object_0, bool bool_0)
	{
		object_0 = Class1660.smethod_26(object_0, bool_0);
		if (object_0 is ErrorType)
		{
			return object_0;
		}
		int num = (int)(double)object_0;
		return num % 2 != 0;
	}

	internal static object smethod_5(object object_0, bool bool_0)
	{
		object_0 = Class1660.smethod_26(object_0, bool_0);
		if (object_0 is ErrorType)
		{
			return object_0;
		}
		int num = (int)(double)object_0;
		return num % 2 == 0;
	}

	internal static object smethod_6(object object_0)
	{
		if (object_0 == null)
		{
			return false;
		}
		if (object_0 is Array)
		{
			Array array = (Array)object_0;
			object[][] array2 = new object[array.Length][];
			for (int i = 0; i < array.Length; i++)
			{
				if (array.GetValue(i) == null)
				{
					continue;
				}
				Array array3 = (Array)array.GetValue(i);
				array2[i] = new object[array3.Length];
				for (int j = 0; j < array3.Length; j++)
				{
					if (array3.GetValue(j) == null)
					{
						array2[i][j] = true;
						continue;
					}
					TypeCode typeCode = Type.GetTypeCode(array3.GetValue(j).GetType());
					if (typeCode == TypeCode.String)
					{
						array2[i][j] = false;
					}
					else
					{
						array2[i][j] = true;
					}
				}
			}
			return array2;
		}
		TypeCode typeCode2 = Type.GetTypeCode(object_0.GetType());
		if (typeCode2 == TypeCode.String)
		{
			return false;
		}
		return true;
	}

	internal static object smethod_7(object object_0)
	{
		if (object_0 == null)
		{
			return false;
		}
		if (object_0 is Array)
		{
			Array array = (Array)object_0;
			object[][] array2 = new object[array.Length][];
			for (int i = 0; i < array.Length; i++)
			{
				if (array.GetValue(i) == null)
				{
					continue;
				}
				Array array3 = (Array)array.GetValue(i);
				array2[i] = new object[array3.Length];
				for (int j = 0; j < array3.Length; j++)
				{
					if (array3.GetValue(j) == null)
					{
						array2[i][j] = false;
						continue;
					}
					TypeCode typeCode = Type.GetTypeCode(array3.GetValue(j).GetType());
					if (typeCode == TypeCode.String)
					{
						array2[i][j] = true;
					}
					else
					{
						array2[i][j] = false;
					}
				}
			}
			return array2;
		}
		TypeCode typeCode2 = Type.GetTypeCode(object_0.GetType());
		if (typeCode2 == TypeCode.String)
		{
			return true;
		}
		return false;
	}
}
