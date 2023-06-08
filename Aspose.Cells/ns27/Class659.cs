using System;
using Aspose.Cells;
using ns2;

namespace ns27;

internal class Class659 : Class538
{
	internal Class659(Name name_0)
	{
		method_2(24);
		string text = name_0.Text;
		method_0(14);
		if (name_0.method_2() != null)
		{
			method_0((short)(base.Length + (short)(name_0.method_2().Length - 2)));
		}
		if (name_0.Type == Enum184.const_0)
		{
			method_0((short)(base.Length + 2));
		}
		else
		{
			method_0((short)(base.Length + (short)(Class1677.smethod_30(name_0.Text) ? (1 + name_0.Text.Length) : (1 + name_0.Text.Length * 2))));
		}
		if (name_0.method_4() != null)
		{
			method_0((short)(base.Length + (short)(Class1677.smethod_30(name_0.method_4()) ? (1 + name_0.method_4().Length) : (1 + name_0.method_4().Length * 2))));
		}
		if (name_0.method_6() != null)
		{
			method_0((short)(base.Length + (short)(Class1677.smethod_30(name_0.method_6()) ? (1 + name_0.method_6().Length) : (1 + name_0.method_6().Length * 2))));
		}
		if (name_0.method_8() != null)
		{
			method_0((short)(base.Length + (short)(Class1677.smethod_30(name_0.method_8()) ? (1 + name_0.method_8().Length) : (1 + name_0.method_8().Length * 2))));
		}
		if (name_0.method_10() != null)
		{
			method_0((short)(base.Length + (short)(Class1677.smethod_30(name_0.method_10()) ? (1 + name_0.method_10().Length) : (1 + name_0.method_10().Length * 2))));
		}
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes(name_0.method_0()), byte_0, 2);
		byte_0[2] = name_0.method_12();
		if (name_0.Type == Enum184.const_0)
		{
			byte_0[3] = 1;
		}
		else
		{
			byte_0[3] = (byte)name_0.Text.Length;
		}
		if (name_0.method_2() != null)
		{
			Array.Copy(name_0.method_2(), 0, byte_0, 4, 2);
		}
		Array.Copy(BitConverter.GetBytes(name_0.SheetIndex), 0, byte_0, 8, 2);
		byte_0[10] = (byte)((name_0.method_4() != null) ? ((uint)name_0.method_4().Length) : 0u);
		byte_0[11] = (byte)((name_0.method_6() != null) ? ((uint)name_0.method_6().Length) : 0u);
		byte_0[12] = (byte)((name_0.method_8() != null) ? ((uint)name_0.method_8().Length) : 0u);
		byte_0[13] = (byte)((name_0.method_10() != null) ? ((uint)name_0.method_10().Length) : 0u);
		int num = 14;
		if (name_0.Type == Enum184.const_0)
		{
			byte_0[15] = name_0.method_25();
			num = 16;
		}
		else
		{
			text = name_0.Text;
			if (text != "")
			{
				byte[] array = Class1677.smethod_15(text);
				byte_0[num++] = (byte)((array.Length != text.Length) ? 1u : 0u);
				Array.Copy(array, 0, byte_0, num, array.Length);
				num += array.Length;
			}
			else
			{
				byte_0[num++] = 0;
			}
		}
		if (name_0.method_2() != null)
		{
			Array.Copy(name_0.method_2(), 2, byte_0, num, name_0.method_2().Length - 2);
			num += name_0.method_2().Length - 2;
		}
		if (name_0.method_4() != null)
		{
			text = name_0.method_4();
			byte[] array2 = Class1677.smethod_15(text);
			byte_0[num++] = (byte)((array2.Length != text.Length) ? 1u : 0u);
			Array.Copy(array2, 0, byte_0, num, array2.Length);
			num += array2.Length;
		}
		if (name_0.method_6() != null)
		{
			text = name_0.method_6();
			byte[] array3 = Class1677.smethod_15(text);
			byte_0[num++] = (byte)((array3.Length != text.Length) ? 1u : 0u);
			Array.Copy(array3, 0, byte_0, num, array3.Length);
			num += array3.Length;
		}
		if (name_0.method_8() != null)
		{
			text = name_0.method_8();
			byte[] array4 = Class1677.smethod_15(text);
			byte_0[num++] = (byte)((array4.Length != text.Length) ? 1u : 0u);
			Array.Copy(array4, 0, byte_0, num, array4.Length);
			num += array4.Length;
		}
		if (name_0.method_10() != null)
		{
			text = name_0.method_10();
			byte[] array5 = Class1677.smethod_15(text);
			byte_0[num++] = (byte)((array5.Length != text.Length) ? 1u : 0u);
			Array.Copy(array5, 0, byte_0, num, array5.Length);
			num += array5.Length;
		}
	}
}
