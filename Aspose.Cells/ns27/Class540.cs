using System;
using Aspose.Cells;
using ns2;

namespace ns27;

internal class Class540 : Class538
{
	internal Class540()
	{
		method_2(2171);
	}

	internal void method_4(Class995 class995_0)
	{
		FormatCondition formatCondition_ = class995_0.formatCondition_0;
		int num = 18;
		num = 18 + 8;
		if (class995_0.class1685_0 != null)
		{
			num += class995_0.method_2();
		}
		num += 17;
		method_0((short)num);
		byte_0 = new byte[num];
		byte_0[0] = 123;
		byte_0[1] = 8;
		int num2 = 12;
		num2 = 12 + 4;
		Array.Copy(BitConverter.GetBytes((short)class995_0.int_1), 0, byte_0, 16, 2);
		num2 = 16 + 2;
		Array.Copy(BitConverter.GetBytes((short)class995_0.int_0), 0, byte_0, 18, 2);
		num2 = 18 + 2;
		byte_0[20] = Class580.smethod_0((formatCondition_.Type == FormatConditionType.CellValue) ? formatCondition_.Operator : OperatorType.None);
		num2++;
		byte_0[num2] = (byte)Class579.smethod_1(formatCondition_);
		num2++;
		Array.Copy(BitConverter.GetBytes((ushort)formatCondition_.Priority), 0, byte_0, num2, 2);
		num2 += 2;
		byte_0[num2] = 1;
		if (formatCondition_.StopIfTrue)
		{
			byte_0[num2] |= 2;
		}
		num2++;
		if (class995_0.class1685_0 != null)
		{
			byte_0[num2] = 1;
			num2++;
			num2 = Class579.smethod_0(class995_0.class578_0, class995_0.class1685_0, byte_0, num2);
		}
		else
		{
			num2++;
		}
		num2 = Class579.smethod_2(formatCondition_, byte_0, num2);
	}

	internal void method_5(int int_0)
	{
		method_0(18);
		byte_0 = new byte[base.Length];
		byte_0[0] = 123;
		byte_0[1] = 8;
		byte_0[12] = 1;
		Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, byte_0, 16, 2);
	}
}
