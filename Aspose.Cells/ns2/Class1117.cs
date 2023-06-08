using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;
using Aspose.Cells;

namespace ns2;

internal class Class1117
{
	internal byte[] byte_0;

	internal int Index => BitConverter.ToInt32(byte_0, 4);

	internal int EndColumn => BitConverter.ToUInt16(byte_0, 8);

	internal int StartColumn
	{
		get
		{
			if (!method_3())
			{
				return 0;
			}
			int num = 10;
			if ((byte_0[10] & 8u) != 0)
			{
				return BitConverter.ToInt16(byte_0, num + 1);
			}
			return 0;
		}
	}

	internal void Copy(Class1117 class1117_0)
	{
		byte_0 = new byte[class1117_0.byte_0.Length];
		Array.Copy(class1117_0.byte_0, byte_0, byte_0.Length);
	}

	internal Class1117(int int_0)
	{
		byte_0 = new byte[80];
		byte_0[0] = 6;
		Array.Copy(BitConverter.GetBytes(int_0), 0, byte_0, 4, 4);
	}

	[SpecialName]
	internal void method_0(int int_0)
	{
		Array.Copy(BitConverter.GetBytes(int_0), 0, byte_0, 8, 2);
	}

	private void method_1()
	{
		if (byte_0[8] == byte.MaxValue)
		{
			byte_0[8] = 0;
			byte_0[9]++;
		}
		else
		{
			byte_0[8]++;
		}
	}

	[SpecialName]
	internal int method_2()
	{
		return BitConverter.ToInt32(byte_0, 0) + 4;
	}

	[SpecialName]
	internal bool method_3()
	{
		return method_2() > 10;
	}

	internal object method_4(int int_0, int int_1)
	{
		int num = 1;
		if ((byte_0[int_1] & 8u) != 0)
		{
			num += 2;
		}
		object result = null;
		switch (byte_0[int_1] & 7)
		{
		case 1:
			result = BitConverter.ToDouble(byte_0, int_1 + num);
			break;
		case 2:
			result = Class937.smethod_1(byte_0, int_1 + num);
			break;
		case 3:
			result = smethod_1((byte)((byte_0[int_1] & 0xF0) >> 4));
			break;
		case 4:
			result = (byte_0[int_1] & 0xF0) != 0;
			break;
		}
		return result;
	}

	internal Class1116 method_5(int int_0, int int_1)
	{
		int num = 1;
		if ((byte_0[int_1] & 8u) != 0)
		{
			num += 2;
		}
		object object_ = null;
		switch (byte_0[int_1] & 7)
		{
		case 1:
			object_ = BitConverter.ToDouble(byte_0, int_1 + num);
			break;
		case 2:
		{
			int num2 = BitConverter.ToUInt16(byte_0, int_1 + num);
			if (num2 == 0)
			{
				object_ = "";
			}
			else if (byte_0[int_1 + num + 2] == 0)
			{
				byte[] array = new byte[num2 * 2];
				int_1 = int_1 + num + 3;
				for (int i = 0; i < num2; i++)
				{
					array[i * 2] = byte_0[int_1 + i];
				}
				object_ = Encoding.Unicode.GetString(array, 0, num2 * 2);
			}
			else
			{
				object_ = Encoding.Unicode.GetString(byte_0, int_1 + num + 3, num2 * 2);
			}
			break;
		}
		case 3:
			object_ = smethod_1((byte)((byte_0[int_1] & 0xF0) >> 4));
			break;
		case 4:
			object_ = (byte_0[int_1] & 0xF0) != 0;
			break;
		}
		return new Class1116(int_0, object_);
	}

	internal bool method_6(int columnIndex, out int arrayIndex, out bool isContinue)
	{
		int num = 10;
		int num2 = method_2();
		int num3 = 0;
		int int_ = -1;
		int num4 = -1;
		arrayIndex = num2;
		isContinue = false;
		while (true)
		{
			if (num < num2)
			{
				num3 = method_12(num, ref int_);
				if (int_ != columnIndex)
				{
					if (int_ > columnIndex)
					{
						break;
					}
					num4 = int_;
					num += num3;
					continue;
				}
				arrayIndex = num;
				isContinue = (byte_0[num] & 8) == 0;
				return true;
			}
			isContinue = columnIndex - num4 == 1;
			return false;
		}
		arrayIndex = num;
		isContinue = int_ - num4 == 1;
		return false;
	}

	internal ArrayList method_7()
	{
		int i = 10;
		int num = method_2();
		int num2 = 0;
		int int_ = -1;
		ArrayList arrayList = new ArrayList();
		for (; i < num; i += num2)
		{
			num2 = method_12(i, ref int_);
			arrayList.Add(method_5(int_, i));
		}
		return arrayList;
	}

	internal double[] method_8(int int_0, int int_1)
	{
		double[] array = new double[int_1 - int_0 + 1];
		int i = 10;
		int num = method_2();
		int num2 = 0;
		int int_2 = -1;
		for (; i < num; i += num2)
		{
			num2 = method_12(i, ref int_2);
			if (int_2 > int_1)
			{
				break;
			}
			if (int_2 >= int_0)
			{
				object obj = method_4(int_2, i);
				if (obj is double)
				{
					array[int_2 - int_0] = (double)obj;
				}
			}
		}
		return array;
	}

	internal object[] method_9(int int_0, int int_1)
	{
		object[] array = new object[int_1 - int_0 + 1];
		int i = 10;
		int num = method_2();
		int num2 = 0;
		int int_2 = -1;
		for (; i < num; i += num2)
		{
			num2 = method_12(i, ref int_2);
			if (int_2 > int_1)
			{
				break;
			}
			if (int_2 >= int_0)
			{
				array[int_2 - int_0] = method_4(int_2, i);
			}
		}
		return array;
	}

	internal object method_10(int int_0)
	{
		if (method_6(int_0, out var arrayIndex, out var _))
		{
			return method_5(int_0, arrayIndex).object_0;
		}
		return null;
	}

	private object method_11(object value, out Enum179 type)
	{
		type = Enum179.const_0;
		if (value == null)
		{
			return type;
		}
		if (value is ErrorType)
		{
			type = Enum179.const_3;
			return value;
		}
		switch (Type.GetTypeCode(value.GetType()))
		{
		case TypeCode.Double:
			type = Enum179.const_1;
			break;
		case TypeCode.DateTime:
			type = Enum179.const_1;
			value = CellsHelper.GetDoubleFromDateTime((DateTime)value, date1904: false);
			break;
		case TypeCode.String:
		{
			type = Enum179.const_2;
			bool isError = false;
			ErrorType errorType = Class1673.smethod_3((string)value, out isError);
			if (isError)
			{
				value = errorType;
				type = Enum179.const_3;
			}
			break;
		}
		case TypeCode.Boolean:
			type = Enum179.const_4;
			break;
		}
		return value;
	}

	internal void Add(int int_0, object object_0)
	{
		int int_ = 0;
		if (method_6(int_0, out var arrayIndex, out var isContinue))
		{
			int_ = method_13(arrayIndex);
		}
		else
		{
			method_0(int_0);
		}
		Enum179 type = Enum179.const_0;
		object_0 = method_11(object_0, out type);
		int int_2 = method_14(isContinue, type, object_0);
		method_16(arrayIndex, int_, int_2);
		byte_0[arrayIndex] = (byte)type;
		int num = 1;
		if (!isContinue)
		{
			byte_0[arrayIndex] |= 8;
			Array.Copy(BitConverter.GetBytes(int_0), 0, byte_0, arrayIndex + num, 2);
			num += 2;
		}
		switch (type)
		{
		case Enum179.const_1:
			Array.Copy(BitConverter.GetBytes((double)object_0), 0, byte_0, arrayIndex + num, 8);
			break;
		case Enum179.const_2:
		{
			string text = (string)object_0;
			Array.Copy(BitConverter.GetBytes(text.Length), 0, byte_0, arrayIndex + num, 2);
			num += 2;
			byte[] array = Class1677.smethod_15(text);
			if (array != null)
			{
				if (array.Length != text.Length)
				{
					byte_0[arrayIndex + num] = 1;
				}
				Array.Copy(array, 0, byte_0, arrayIndex + num + 1, array.Length);
			}
			break;
		}
		case Enum179.const_0:
			break;
		case Enum179.const_3:
			byte_0[arrayIndex] &= 15;
			byte_0[arrayIndex] |= (byte)(smethod_0((ErrorType)object_0) << 4);
			break;
		case Enum179.const_4:
			if ((bool)object_0)
			{
				byte_0[arrayIndex] |= 16;
			}
			else
			{
				byte_0[arrayIndex] &= 15;
			}
			break;
		}
	}

	internal int method_12(int int_0, ref int int_1)
	{
		int num = 1;
		if ((byte_0[int_0] & 8u) != 0)
		{
			int_1 = BitConverter.ToInt16(byte_0, int_0 + num);
			num += 2;
		}
		else
		{
			int_1++;
		}
		switch (byte_0[int_0] & 7)
		{
		case 1:
			num += 8;
			break;
		case 2:
		{
			int num2 = BitConverter.ToUInt16(byte_0, int_0 + num);
			if (byte_0[int_0 + num + 2] == 1)
			{
				num2 *= 2;
			}
			num += 3 + num2;
			break;
		}
		}
		return num;
	}

	internal int method_13(int int_0)
	{
		int num = 1;
		if ((byte_0[int_0] & 8u) != 0)
		{
			num += 2;
		}
		switch (byte_0[int_0] & 7)
		{
		case 1:
			num += 8;
			break;
		case 2:
		{
			int num2 = BitConverter.ToUInt16(byte_0, int_0 + num);
			if (byte_0[int_0 + num + 2] == 1)
			{
				num2 *= 2;
			}
			num += 3 + num2;
			break;
		}
		}
		return num;
	}

	internal int method_14(bool bool_0, Enum179 enum179_0, object object_0)
	{
		int num = 1;
		if (!bool_0)
		{
			num += 2;
		}
		switch (enum179_0)
		{
		case Enum179.const_1:
			num += 8;
			break;
		case Enum179.const_2:
		{
			byte[] array = Class1677.smethod_15((string)object_0);
			num += 3;
			if (array != null)
			{
				num += array.Length;
			}
			break;
		}
		}
		return num;
	}

	internal void method_15(int int_0, int int_1, Enum179 enum179_0, byte[] byte_1, int int_2)
	{
		int num = 1;
		if (int_1 - int_0 != 1)
		{
			num += 2;
		}
		switch (enum179_0)
		{
		case Enum179.const_1:
			num += 8;
			break;
		case Enum179.const_2:
		{
			int num2 = BitConverter.ToUInt16(byte_1, int_2);
			num = ((byte_1[int_2 + 2] != 0) ? (num + (3 + num2 + num2)) : (num + (3 + num2)));
			break;
		}
		}
		int num3 = method_2();
		method_16(num3, 0, num);
		byte_0[num3] = (byte)enum179_0;
		int num4 = 1;
		if (int_1 - int_0 != 1)
		{
			byte_0[num3] |= 8;
			Array.Copy(BitConverter.GetBytes(int_1), 0, byte_0, num3 + num4, 2);
			method_0(int_1);
			num4 += 2;
		}
		else if (int_1 != 0)
		{
			method_1();
		}
		switch (enum179_0)
		{
		case Enum179.const_1:
			Array.Copy(byte_1, int_2, byte_0, num3 + num4, 8);
			break;
		case Enum179.const_2:
		{
			int num5 = BitConverter.ToUInt16(byte_1, int_2);
			Array.Copy(length: (byte_1[int_2 + 2] != 0) ? (3 + num5 + num5) : (3 + num5), sourceArray: byte_1, sourceIndex: int_2, destinationArray: byte_0, destinationIndex: num3 + num4);
			break;
		}
		case Enum179.const_3:
			byte_0[num3] |= (byte)(smethod_0(Class1673.smethod_5(byte_1[int_2])) << 4);
			break;
		case Enum179.const_4:
			if (byte_1[int_2] == 1)
			{
				byte_0[num3] |= 16;
			}
			break;
		case Enum179.const_0:
			break;
		}
	}

	internal void method_16(int int_0, int int_1, int int_2)
	{
		int num = int_2 - int_1;
		if (num == 0)
		{
			return;
		}
		int num2 = method_2();
		int num3 = num2 + num;
		Array.Copy(BitConverter.GetBytes(num3 - 4), 0, byte_0, 0, 4);
		if (num3 > byte_0.Length)
		{
			if (num3 < byte_0.Length * 2)
			{
				num3 = byte_0.Length * 2;
			}
			byte[] destinationArray = new byte[num3];
			int num4 = int_0 + int_1;
			Array.Copy(byte_0, 0, destinationArray, 0, int_0);
			if (num4 < num2)
			{
				Array.Copy(byte_0, num4, destinationArray, int_0 + int_2, num2 - num4);
			}
			byte_0 = destinationArray;
		}
		else if (num3 > 80 && num3 < byte_0.Length / 3)
		{
			num3 = byte_0.Length / 2;
			byte[] destinationArray2 = new byte[num3];
			int num5 = int_0 + int_1;
			Array.Copy(byte_0, 0, destinationArray2, 0, int_0);
			if (num5 < num2)
			{
				Array.Copy(byte_0, num5, destinationArray2, int_0 + int_2, num2 - num5);
			}
			byte_0 = destinationArray2;
		}
		else
		{
			Array.Copy(byte_0, int_0 + int_1, byte_0, int_0 + int_2, num2 - (int_0 + int_1));
		}
	}

	internal static byte smethod_0(ErrorType errorType_0)
	{
		return errorType_0 switch
		{
			ErrorType.Div => 1, 
			ErrorType.Invalid => 8, 
			ErrorType.NA => 6, 
			ErrorType.Name => 4, 
			ErrorType.Null => 0, 
			ErrorType.Number => 5, 
			ErrorType.Ref => 3, 
			ErrorType.Recursive => 7, 
			ErrorType.Value => 2, 
			_ => 0, 
		};
	}

	internal static ErrorType smethod_1(byte byte_1)
	{
		return byte_1 switch
		{
			0 => ErrorType.Null, 
			1 => ErrorType.Div, 
			2 => ErrorType.Value, 
			3 => ErrorType.Ref, 
			4 => ErrorType.Name, 
			5 => ErrorType.Number, 
			6 => ErrorType.NA, 
			7 => ErrorType.Recursive, 
			8 => ErrorType.Invalid, 
			_ => ErrorType.Invalid, 
		};
	}
}
