using System;
using ns10;
using ns16;

namespace ns9;

internal class Class317 : Class316
{
	internal Class317(Class1538 class1538_0)
	{
		int_0 = 639;
		int num = 14;
		byte[] array = null;
		if (class1538_0.oleObject_0.IsLink)
		{
			array = class1538_0.oleObject_0.method_93();
		}
		num = ((class1538_0.oleObject_0.ProgID == null || class1538_0.oleObject_0.ProgID.Length <= 0) ? (num + 4) : (num + (4 + class1538_0.oleObject_0.ProgID.Length * 2)));
		byte_0 = new byte[(!class1538_0.oleObject_0.IsLink) ? (num + (4 + class1538_0.string_1.Length * 2)) : (num + array.Length)];
		Array.Copy(BitConverter.GetBytes((!class1538_0.oleObject_0.DisplayAsIcon) ? 1 : 0), 0, byte_0, 0, 4);
		Array.Copy(BitConverter.GetBytes(class1538_0.oleObject_0.method_95() ? 1 : 0), 0, byte_0, 4, 4);
		Array.Copy(BitConverter.GetBytes(Class1618.smethod_87(class1538_0.string_0)), 0, byte_0, 8, 4);
		byte b = 0;
		if (class1538_0.oleObject_0.IsLink)
		{
			b = (byte)(b | 1u);
		}
		byte_0[12] = b;
		int num2 = 14;
		if (class1538_0.oleObject_0.ProgID != null && class1538_0.oleObject_0.ProgID.Length > 0)
		{
			Class1217.smethod_7(byte_0, ref num2, class1538_0.oleObject_0.ProgID);
		}
		else
		{
			num2 += 4;
		}
		if (class1538_0.oleObject_0.IsLink)
		{
			Array.Copy(array, 0, byte_0, num2, array.Length);
		}
		else
		{
			Class1217.smethod_7(byte_0, ref num2, class1538_0.string_1);
		}
	}
}
