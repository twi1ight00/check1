using System;
using Aspose.Cells.Tables;
using ns2;

namespace ns27;

internal class Class589 : Class538
{
	internal Class589()
	{
		method_2(2167);
	}

	internal int method_4(ListObject listObject_0)
	{
		int num = 54;
		if (listObject_0.style_1 != null)
		{
			Class578 class578_ = new Class578(listObject_0.method_42());
			num += Class691.smethod_0(class578_, listObject_0.method_43(listObject_0.method_42()));
		}
		if (listObject_0.style_2 != null)
		{
			Class578 class578_2 = new Class578(listObject_0.method_44());
			num += Class691.smethod_0(class578_2, listObject_0.method_43(listObject_0.method_44()));
		}
		if (listObject_0.style_3 != null)
		{
			Class578 class578_3 = new Class578(listObject_0.method_45());
			num += Class691.smethod_0(class578_3, listObject_0.method_43(listObject_0.method_45()));
		}
		return num;
	}

	internal void method_5(ListObject listObject_0)
	{
		method_0((short)method_4(listObject_0));
		byte_0 = new byte[base.Length];
		byte_0[0] = 119;
		byte_0[1] = 8;
		Array.Copy(BitConverter.GetBytes(listObject_0.method_0()), 0, byte_0, 14, 4);
		Array.Copy(BitConverter.GetBytes(uint.MaxValue), 0, byte_0, 22, 4);
		Array.Copy(BitConverter.GetBytes(uint.MaxValue), 0, byte_0, 30, 4);
		Array.Copy(BitConverter.GetBytes(uint.MaxValue), 0, byte_0, 38, 4);
		Class578 class578_ = null;
		Class578 class578_2 = null;
		Class578 class578_3 = null;
		if (listObject_0.style_1 != null)
		{
			class578_ = new Class578(listObject_0.method_42());
			byte_0[18] = (byte)Class691.smethod_0(class578_, listObject_0.method_43(listObject_0.method_42()));
		}
		if (listObject_0.style_2 != null)
		{
			class578_3 = new Class578(listObject_0.method_44());
			byte_0[26] = (byte)Class691.smethod_0(class578_3, listObject_0.method_43(listObject_0.method_44()));
		}
		if (listObject_0.style_3 != null)
		{
			class578_2 = new Class578(listObject_0.method_45());
			byte_0[34] = (byte)Class691.smethod_0(class578_2, listObject_0.method_43(listObject_0.method_45()));
		}
		int int_ = 54;
		if (listObject_0.style_1 != null)
		{
			int_ = Class691.smethod_1(class578_, listObject_0.method_43(listObject_0.method_42()), byte_0, int_);
		}
		if (listObject_0.style_2 != null)
		{
			int_ = Class691.smethod_1(class578_3, listObject_0.method_43(listObject_0.method_44()), byte_0, int_);
		}
		if (listObject_0.style_3 != null)
		{
			int_ = Class691.smethod_1(class578_2, listObject_0.method_43(listObject_0.method_45()), byte_0, int_);
		}
	}

	internal void method_6(ListObject listObject_0)
	{
		string displayName = listObject_0.DisplayName;
		string comment = listObject_0.Comment;
		method_0(24);
		byte[] array = null;
		if (displayName != null && displayName != "")
		{
			array = Class1677.smethod_15(displayName);
			method_0((short)(base.Length + (short)array.Length));
		}
		byte[] array2 = null;
		if (comment != null && comment != "")
		{
			array2 = Class1677.smethod_15(comment);
			method_0((short)(base.Length + (short)array2.Length));
		}
		byte_0 = new byte[base.Length];
		byte_0[0] = 119;
		byte_0[1] = 8;
		int num = 12;
		byte_0[12] = 2;
		Array.Copy(BitConverter.GetBytes(listObject_0.method_0()), 0, byte_0, 12 + 2, 4);
		num = 12 + 6;
		if (displayName != null && displayName != "")
		{
			Array.Copy(BitConverter.GetBytes((ushort)displayName.Length), 0, byte_0, num, 2);
			if (displayName.Length == array.Length)
			{
				byte_0[num + 2] = 0;
			}
			else
			{
				byte_0[num + 2] = 1;
			}
			Array.Copy(array, 0, byte_0, num + 3, array.Length);
			num += 3 + array.Length;
		}
		else
		{
			num += 3;
		}
		if (comment != null && comment != "")
		{
			Array.Copy(BitConverter.GetBytes((ushort)comment.Length), 0, byte_0, num, 2);
			if (comment.Length == array2.Length)
			{
				byte_0[num + 2] = 0;
			}
			else
			{
				byte_0[num + 2] = 1;
			}
			Array.Copy(array2, 0, byte_0, num + 3, array2.Length);
			num += 3 + array2.Length;
		}
		else
		{
			num += 3;
		}
	}

	internal void method_7(ListObject listObject_0)
	{
		string text = listObject_0.TableStyleName;
		if (text == null || text.Length == 0)
		{
			text = "TableStyleMedium9";
		}
		byte[] array = Class1677.smethod_15(text);
		method_0((short)(5 + array.Length + 18));
		byte_0 = new byte[base.Length];
		byte_0[0] = 119;
		byte_0[1] = 8;
		int num = 12;
		byte_0[12] = 1;
		Array.Copy(BitConverter.GetBytes(listObject_0.method_0()), 0, byte_0, 12 + 2, 4);
		num = 12 + 6;
		byte_0[18] = listObject_0.method_38();
		num = 18 + 2;
		Array.Copy(BitConverter.GetBytes((ushort)text.Length), 0, byte_0, 20, 2);
		num = 20 + 2;
		if (text.Length == array.Length)
		{
			byte_0[num++] = 0;
		}
		else
		{
			byte_0[num++] = 1;
		}
		Array.Copy(array, 0, byte_0, num, array.Length);
	}
}
