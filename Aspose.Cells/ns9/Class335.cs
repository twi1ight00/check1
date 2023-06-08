using System;
using ns10;
using ns2;

namespace ns9;

internal class Class335 : Class316
{
	internal Class335()
	{
		int_0 = 360;
	}

	internal void method_6(Class1718 class1718_0)
	{
		int num = 2;
		if (class1718_0.Type == Enum194.const_0)
		{
			num += 12;
			num += 4;
			byte_0 = new byte[num];
			byte[] sourceArray = new byte[4] { 255, 255, 255, 255 };
			Array.Copy(BitConverter.GetBytes((short)0), 0, byte_0, 0, 2);
			int destinationIndex = 2;
			Class1217.smethod_7(byte_0, ref destinationIndex, "rId1");
			Array.Copy(sourceArray, 0, byte_0, destinationIndex, 4);
		}
		else if (class1718_0.Type == Enum194.const_3)
		{
			class1718_0.method_20(out var progId, out var fileName);
			num += 8 + fileName.Length * 2 + progId.Length * 2;
			byte_0 = new byte[num];
			Array.Copy(BitConverter.GetBytes((short)1), 0, byte_0, 0, 2);
			int num2 = 2;
			Class1217.smethod_7(byte_0, ref num2, fileName);
			Class1217.smethod_7(byte_0, ref num2, progId);
		}
		else
		{
			class1718_0.method_22(out var progId2, out var _);
			num += 16 + progId2.Length * 2;
			byte_0 = new byte[num];
			Array.Copy(BitConverter.GetBytes((short)2), 0, byte_0, 0, 2);
			int num3 = 2;
			Class1217.smethod_7(byte_0, ref num3, "rId1");
			Class1217.smethod_7(byte_0, ref num3, progId2);
		}
	}
}
