using System;
using System.Collections;
using Aspose.Cells;
using ns2;
using ns59;

namespace ns27;

internal class Class621 : Class538
{
	private ArrayList arrayList_0;

	private int int_0;

	internal Class621()
	{
		method_2(90);
	}

	internal int method_4(Class1117 class1117_0, ArrayList arrayList_1)
	{
		if (!class1117_0.method_3())
		{
			return 0;
		}
		int num = ((Class1116)arrayList_1[0]).int_0;
		int num2 = ((Class1116)arrayList_1[arrayList_1.Count - 1]).int_0;
		int num3 = num2 - num + 1;
		num3 *= 9;
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			Class1116 @class = (Class1116)arrayList_1[i];
			if (@class.method_0() == Enum179.const_2)
			{
				num3 -= 9;
				string text = @class.object_0.ToString();
				num3 = ((!Class1677.smethod_30(text)) ? (num3 + (4 + text.Length * 2)) : (num3 + (4 + text.Length)));
			}
		}
		return num3 + 4;
	}

	private Class538 method_5(Class538 class538_0, ref int int_1)
	{
		class538_0.method_0((short)int_1);
		int_0 -= int_1;
		int_1 = 0;
		Class619 @class = new Class619();
		byte[] array = null;
		array = ((int_0 >= 8224) ? new byte[8224] : new byte[int_0]);
		@class.method_3(array);
		arrayList_0.Add(@class);
		return @class;
	}

	internal void method_6(Class1117 class1117_0)
	{
		ArrayList arrayList = class1117_0.method_7();
		int_0 = method_4(class1117_0, arrayList);
		if (int_0 > 8224)
		{
			byte[] array = (byte_0 = new byte[8224]);
			Class538 @class = this;
			arrayList_0 = new ArrayList();
			int int_ = 4;
			byte_0[0] = (byte)class1117_0.EndColumn;
			byte_0[1] = (byte)class1117_0.StartColumn;
			Array.Copy(BitConverter.GetBytes((ushort)class1117_0.Index), 0, byte_0, 2, 2);
			for (int i = 0; i < arrayList.Count; i++)
			{
				Class1116 class2 = (Class1116)arrayList[i];
				if (class2.method_0() == Enum179.const_2)
				{
					if (int_ + 4 > array.Length)
					{
						@class = method_5(@class, ref int_);
						array = @class.Data;
					}
					string text = class2.object_0.ToString();
					byte[] array2 = Class1677.smethod_15(text);
					array[int_] = 2;
					Array.Copy(BitConverter.GetBytes((ushort)text.Length), 0, array, int_ + 1, 2);
					array[int_ + 3] = 0;
					if (array2 == null)
					{
						continue;
					}
					int_ += 3;
					int num = 0;
					int num2 = array.Length - int_;
					int num3 = array2.Length - 0 + 1;
					bool flag = array2.Length == text.Length;
					if (num2 >= num3)
					{
						if (flag)
						{
							array[int_] = 1;
						}
						int_++;
						Array.Copy(array2, 0, array, int_, array2.Length);
						int_ += array2.Length;
						continue;
					}
					while (num2 < num3)
					{
						array[int_] = (byte)((!flag) ? 1u : 0u);
						int_++;
						num2--;
						if (flag && num2 % 2 != 0)
						{
							num2--;
						}
						Array.Copy(array2, num, array, int_, num2);
						num += num2;
						int_ += num2;
						int_0++;
						@class = method_5(@class, ref int_);
						array = @class.Data;
						int_ = 0;
						num2 = array.Length - 0;
						num3 = array2.Length - num + 1;
					}
					array[int_] = (byte)((!flag) ? 1u : 0u);
					Array.Copy(array2, num, array, int_, num3);
					num += num3;
					int_ += num3;
				}
				else if (int_ + 9 > array.Length)
				{
					@class = method_5(@class, ref int_);
					array = @class.Data;
				}
				if (class2.object_0 == null)
				{
					int_ += 9;
					continue;
				}
				switch (class2.method_0())
				{
				case Enum179.const_0:
					int_ += 9;
					break;
				case Enum179.const_1:
					array[int_] = 1;
					Array.Copy(BitConverter.GetBytes(class2.DoubleValue), 0, array, int_ + 1, 8);
					int_ += 9;
					break;
				default:
					if (class2.object_0 is ErrorType)
					{
						array[int_] = 16;
						method_7((ErrorType)class2.object_0, array, int_);
						int_ += 9;
					}
					break;
				case Enum179.const_3:
					byte_0[int_] = 16;
					method_7(class2.method_1(), byte_0, int_);
					int_ += 9;
					break;
				case Enum179.const_4:
					array[int_] = 4;
					if (class2.BoolValue)
					{
						array[int_ + 1] = 1;
					}
					int_ += 9;
					break;
				}
			}
			return;
		}
		method_0((short)int_0);
		byte_0 = new byte[int_0];
		int num4 = 4;
		byte_0[0] = (byte)class1117_0.EndColumn;
		byte_0[1] = (byte)class1117_0.StartColumn;
		int num5 = byte_0[1] - 1;
		Array.Copy(BitConverter.GetBytes((ushort)class1117_0.Index), 0, byte_0, 2, 2);
		for (int j = 0; j < arrayList.Count; j++)
		{
			Class1116 class3 = (Class1116)arrayList[j];
			if (num5 + 1 != class3.int_0)
			{
				num4 += (class3.int_0 - num5 - 1) * 9;
			}
			num5 = class3.int_0;
			if (class3.object_0 == null)
			{
				num4 += 9;
				continue;
			}
			switch (class3.method_0())
			{
			case Enum179.const_0:
				num4 += 9;
				continue;
			case Enum179.const_1:
				byte_0[num4] = 1;
				Array.Copy(BitConverter.GetBytes(class3.DoubleValue), 0, byte_0, num4 + 1, 8);
				num4 += 9;
				continue;
			case Enum179.const_3:
				byte_0[num4] = 16;
				method_7(class3.method_1(), byte_0, num4);
				num4 += 9;
				continue;
			case Enum179.const_4:
				byte_0[num4] = 4;
				if (class3.BoolValue)
				{
					byte_0[num4 + 1] = 1;
				}
				num4 += 9;
				continue;
			}
			string text2 = class3.object_0.ToString();
			bool isError = false;
			ErrorType errorType = Class1673.smethod_3(text2, out isError);
			if (isError && errorType != ErrorType.Recursive)
			{
				byte_0[num4] = 16;
				method_7(errorType, byte_0, num4);
				num4 += 9;
				continue;
			}
			byte_0[num4] = 2;
			byte[] array3 = Class1677.smethod_15(text2);
			if (array3 == null)
			{
				byte_0[num4 + 3] = 0;
				num4 += 4;
				continue;
			}
			if (array3.Length == text2.Length)
			{
				Array.Copy(BitConverter.GetBytes((ushort)text2.Length), 0, byte_0, num4 + 1, 2);
				byte_0[num4 + 3] = 0;
				Array.Copy(array3, 0, byte_0, num4 + 4, array3.Length);
			}
			else
			{
				Array.Copy(BitConverter.GetBytes((ushort)text2.Length), 0, byte_0, num4 + 1, 2);
				byte_0[num4 + 3] = 1;
				Array.Copy(array3, 0, byte_0, num4 + 4, array3.Length);
			}
			num4 += 4 + array3.Length;
		}
	}

	private void method_7(ErrorType errorType_0, byte[] byte_1, int int_1)
	{
		switch (errorType_0)
		{
		case ErrorType.Div:
			byte_0[int_1 + 1] = 7;
			break;
		case ErrorType.NA:
			byte_0[int_1 + 1] = 42;
			break;
		case ErrorType.Name:
			byte_0[int_1 + 1] = 29;
			break;
		case ErrorType.Null:
			byte_0[int_1 + 1] = 0;
			break;
		case ErrorType.Number:
			byte_0[int_1 + 1] = 36;
			break;
		case ErrorType.Ref:
			byte_0[int_1 + 1] = 23;
			break;
		case ErrorType.Value:
			byte_0[int_1 + 1] = 15;
			break;
		case ErrorType.Invalid:
		case ErrorType.Recursive:
			break;
		}
	}

	internal override void vmethod_0(Class1725 class1725_0)
	{
		class1725_0.method_7(method_1());
		class1725_0.method_7(base.Length);
		class1725_0.method_3(byte_0);
		if (arrayList_0 != null)
		{
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				Class619 @class = (Class619)arrayList_0[i];
				@class.vmethod_0(class1725_0);
			}
		}
	}
}
