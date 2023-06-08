using System;
using Aspose.Cells;
using ns10;

namespace ns9;

internal class Class374 : Class316
{
	internal Class374()
	{
		int_0 = 39;
	}

	internal void method_6(Name name_0)
	{
		int num = 9;
		string text = name_0.Text;
		num = ((text == null) ? (num + 4) : (num + (text.Length * 2 + 4)));
		byte[] array = name_0.method_2();
		byte[] array2 = null;
		if (array != null)
		{
			array2 = new byte[array.Length];
			if (array2 != null)
			{
				Array.Copy(array, 0, array2, 0, array.Length);
				num += array2.Length;
			}
		}
		else
		{
			num += 8;
		}
		num = ((name_0.Comment == null) ? (num + 4) : (num + (name_0.Comment.Length * 2 + 4)));
		if (name_0.method_21() && !name_0.method_20())
		{
			num = ((name_0.method_4() == null) ? (num + 4) : (num + (name_0.method_4().Length * 2 + 4)));
			num = ((name_0.method_6() == null) ? (num + 4) : (num + (name_0.method_6().Length * 2 + 4)));
			num = ((name_0.method_8() == null) ? (num + 4) : (num + (name_0.method_8().Length * 2 + 4)));
			num = ((name_0.method_10() == null) ? (num + 4) : (num + (name_0.method_10().Length * 2 + 4)));
		}
		byte_0 = new byte[num];
		Array.Copy(BitConverter.GetBytes((int)name_0.method_0()), 0, byte_0, 0, 4);
		byte_0[4] = name_0.method_12();
		Array.Copy(BitConverter.GetBytes(name_0.SheetIndex - 1), 0, byte_0, 5, 4);
		int num2 = 9;
		byte[] sourceArray = new byte[4] { 255, 255, 255, 255 };
		if (text != null)
		{
			Class1217.smethod_7(byte_0, ref num2, text);
		}
		else
		{
			Array.Copy(sourceArray, 0, byte_0, num2, 4);
			num2 += 4;
		}
		if (array2 != null)
		{
			Array.Copy(array2, 0, byte_0, num2, array2.Length);
			num2 += array2.Length;
		}
		else
		{
			num2 += 8;
		}
		if (name_0.Comment != null)
		{
			Class1217.smethod_7(byte_0, ref num2, name_0.Comment);
		}
		else
		{
			Array.Copy(sourceArray, 0, byte_0, num2, 4);
			num2 += 4;
		}
		if (name_0.method_21() && !name_0.method_20())
		{
			if (name_0.method_4() != null)
			{
				Class1217.smethod_7(byte_0, ref num2, name_0.method_4());
			}
			else
			{
				Array.Copy(sourceArray, 0, byte_0, num2, 4);
				num2 += 4;
			}
			if (name_0.method_6() != null)
			{
				Class1217.smethod_7(byte_0, ref num2, name_0.method_6());
			}
			else
			{
				Array.Copy(sourceArray, 0, byte_0, num2, 4);
				num2 += 4;
			}
			if (name_0.method_8() != null)
			{
				Class1217.smethod_7(byte_0, ref num2, name_0.method_8());
			}
			else
			{
				Array.Copy(sourceArray, 0, byte_0, num2, 4);
				num2 += 4;
			}
			if (name_0.method_10() != null)
			{
				Class1217.smethod_7(byte_0, ref num2, name_0.method_10());
				return;
			}
			Array.Copy(sourceArray, 0, byte_0, num2, 4);
			num2 += 4;
		}
	}
}
