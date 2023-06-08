using System;
using System.Collections;
using System.Text;
using ns18;

namespace ns47;

internal class Class1069 : Class1067
{
	internal int int_0;

	internal int int_1;

	internal short short_0;

	internal short short_1;

	internal int int_2;

	internal int int_3;

	internal int int_4;

	internal int int_5;

	internal int int_6;

	internal int int_7;

	internal int[] int_8;

	internal ArrayList arrayList_0;

	internal Class1069(Class1393 class1393_0)
	{
		int_0 = class1393_0.method_1();
		int_1 = class1393_0.method_1();
		short_0 = class1393_0.method_3();
		short_1 = class1393_0.method_3();
		int_2 = class1393_0.method_1();
		int_3 = class1393_0.method_1();
		int_4 = class1393_0.method_1();
		int_5 = class1393_0.method_1();
		int_6 = class1393_0.method_1();
		switch (int_0)
		{
		default:
			throw new InvalidOperationException("Unexpected PostScript table version.");
		case 131072:
		{
			int_7 = class1393_0.method_4();
			int_8 = new int[int_7];
			int num = 0;
			for (int i = 0; i < int_8.Length; i++)
			{
				ushort num2 = class1393_0.method_4();
				int_8[i] = num2;
				if (num2 <= 32767)
				{
					num = Math.Max(num2, num);
				}
			}
			int num3 = num - 258 + 1;
			num3 = ((num3 >= 0) ? num3 : 0);
			arrayList_0 = new ArrayList(num3);
			for (int j = 0; j < num3; j++)
			{
				arrayList_0.Add(smethod_0(class1393_0));
			}
			break;
		}
		case 65536:
		case 196608:
			break;
		}
	}

	internal override void Write(Class1394 class1394_0)
	{
		class1394_0.method_1(int_0);
		class1394_0.method_1(int_1);
		class1394_0.method_3(short_0);
		class1394_0.method_3(short_1);
		class1394_0.method_1(int_2);
		class1394_0.method_1(int_3);
		class1394_0.method_1(int_4);
		class1394_0.method_1(int_5);
		class1394_0.method_1(int_6);
		switch (int_0)
		{
		default:
			throw new InvalidOperationException("Unexpected PostScript table version.");
		case 131072:
		{
			class1394_0.method_3(int_7);
			int[] array = int_8;
			foreach (int num in array)
			{
				class1394_0.method_3(num);
			}
			for (int j = 0; j < arrayList_0.Count; j++)
			{
				smethod_1((string)arrayList_0[j], class1394_0);
			}
			break;
		}
		case 65536:
		case 196608:
			break;
		}
	}

	internal void method_1(Class1398 class1398_0)
	{
		int_3 = 0;
		int_4 = 0;
		int_5 = 0;
		int_6 = 0;
		switch (int_0)
		{
		default:
			throw new InvalidOperationException("Unexpected PostScript table version.");
		case 131072:
			method_2(class1398_0);
			break;
		case 65536:
		case 196608:
			break;
		}
	}

	private void method_2(Class1398 class1398_0)
	{
		int[] array = new int[class1398_0.Count];
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < class1398_0.Count; i++)
		{
			int num = class1398_0.method_3(i);
			int num2 = (int)class1398_0.GetByIndex(i);
			int num3 = int_8[num];
			if (num3 >= 258 && num3 <= 32767)
			{
				string value = (string)arrayList_0[num3 - 258];
				int num4 = arrayList.Add(value);
				array[num2] = (ushort)(num4 + 258);
			}
			else
			{
				array[num2] = (ushort)num3;
			}
		}
		int_7 = (ushort)class1398_0.Count;
		int_8 = array;
		arrayList_0 = arrayList;
	}

	private static string smethod_0(Class1393 class1393_0)
	{
		int num = class1393_0.ReadByte();
		byte[] bytes = class1393_0.method_5(num);
		Encoding aSCII = Encoding.ASCII;
		return aSCII.GetString(bytes);
	}

	private static void smethod_1(string string_0, Class1394 class1394_0)
	{
		if (string_0.Length > 255)
		{
			throw new InvalidOperationException("The PostScript glyph name is too long.");
		}
		Encoding aSCII = Encoding.ASCII;
		byte[] bytes = aSCII.GetBytes(string_0);
		class1394_0.WriteByte((byte)bytes.Length);
		class1394_0.method_5(bytes, 0, bytes.Length);
	}
}
