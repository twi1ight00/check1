using System;
using ns100;
using ns108;
using ns113;
using ns118;
using ns126;
using ns132;
using ns133;
using ns134;
using ns153;
using ns154;
using ns99;

namespace ns116;

internal class Class4462 : Class4460
{
	private Class4441 class4441_0;

	private Class4552 class4552_0 = new Class4552();

	private Class4409 class4409_0;

	private Class4444 class4444_0;

	private double[] double_0;

	private double[] double_1;

	private Random random_0;

	private int int_0;

	private Class4708 class4708_0;

	private static Class4716 class4716_0;

	private Class4480 class4480_0;

	public Class4480 Glyph => class4480_0;

	public Class4462(Interface116 interpreterContext, Class4409 font, Class4444 activeSubfont, Class4480 glyph)
		: base(interpreterContext)
	{
		class4409_0 = font;
		class4444_0 = activeSubfont;
		class4480_0 = glyph;
		method_0();
	}

	public void method_0()
	{
		base.GraphStateStack.Current.Position = new Class4600(0.0, 0.0);
		class4441_0 = new Class4441(class4480_0);
		double_0 = new double[48];
		double_1 = new double[32];
		int_0 = 0;
		class4708_0 = new Class4708(base.OperandStack);
	}

	static Class4462()
	{
		class4716_0 = new Class4716();
		class4716_0.method_0();
	}

	public override void vmethod_0(string commandName)
	{
		switch (commandName)
		{
		case "hstem":
			method_25();
			break;
		case "vstem":
			method_26();
			break;
		case "vmoveto":
			method_6();
			break;
		case "rlineto":
			method_7();
			break;
		case "hlineto":
			method_9();
			break;
		case "vlineto":
			method_10();
			break;
		case "rrcurveto":
			method_12();
			break;
		case "callsubr":
			method_52();
			break;
		case "return":
			method_54();
			break;
		case "endchar":
			method_1();
			break;
		case "hstemhm":
			method_27();
			break;
		case "hintmask":
			method_29();
			break;
		case "cntrmask":
			method_30();
			break;
		case "rmoveto":
			method_3();
			break;
		case "hmoveto":
			method_4();
			break;
		case "vstemhm":
			method_28();
			break;
		case "rcurveline":
			method_17();
			break;
		case "rlinecurve":
			method_18();
			break;
		case "vvcurveto":
			method_20();
			break;
		case "hhcurveto":
			method_14();
			break;
		case "callgsubr":
			method_53();
			break;
		case "vhcurveto":
			method_19();
			break;
		case "hvcurveto":
			method_15();
			break;
		case "and":
			method_47();
			break;
		case "or":
			method_48();
			break;
		case "not":
			method_49();
			break;
		case "abs":
			method_32();
			break;
		case "add":
			method_33();
			break;
		case "sub":
			method_34();
			break;
		case "div":
			method_35();
			break;
		case "neg":
			method_36();
			break;
		case "eq":
			method_50();
			break;
		case "drop":
			method_40();
			break;
		case "put":
			method_45();
			break;
		case "get":
			method_46();
			break;
		case "ifelse":
			method_51();
			break;
		case "random":
			method_37();
			break;
		case "mul":
			method_38();
			break;
		case "sqrt":
			method_39();
			break;
		case "dup":
			method_44();
			break;
		case "exch":
			method_41();
			break;
		case "index":
			method_42();
			break;
		case "roll":
			method_43();
			break;
		case "hflex":
			method_22();
			break;
		case "flex":
			method_21();
			break;
		case "hflex1":
			method_23();
			break;
		case "flex1":
			method_24();
			break;
		case "pickupyourfreakingmask":
			method_31();
			break;
		}
	}

	public void method_1()
	{
		method_56();
		if (base.OperandStack.Count >= 4)
		{
			method_2();
		}
		if (base.OperandStack.Count == 1)
		{
			method_5(base.OperandStack.method_3());
		}
		class4441_0.method_2();
	}

	public void method_2()
	{
		int num = (int)base.OperandStack.method_3();
		int num2 = (int)base.OperandStack.method_3();
		double num3 = base.OperandStack.method_3();
		double num4 = base.OperandStack.method_3();
		if (class4409_0.SeacSequence.Contains(num) || class4409_0.SeacSequence.Contains(num2))
		{
			return;
		}
		class4409_0.SeacSequence.Add(num);
		class4409_0.SeacSequence.Add(num2);
		try
		{
			Class4506 id = new Class4507(class4716_0[(ushort)num]);
			Class4480 @class = class4409_0.imethod_0(id);
			Class4506 id2 = new Class4507(class4716_0[(ushort)num2]);
			Class4480 class2 = class4409_0.imethod_0(id2);
			double dx = 0.0;
			double dy = 0.0;
			if (class2 != null)
			{
				dx = Glyph.LeftSidebearingX + num4;
				dy = Glyph.LeftSidebearingY + num3;
			}
			if (@class != null)
			{
				class4441_0.method_8(@class.Path, dx, dy);
			}
			if (class2 != null)
			{
				class4441_0.method_7(class2.Path);
			}
		}
		finally
		{
			class4409_0.SeacSequence.Remove(num);
			class4409_0.SeacSequence.Remove(num2);
		}
	}

	public void method_3()
	{
		method_56();
		if (class4708_0.method_1())
		{
			double dy = base.OperandStack.method_3();
			double dx = base.OperandStack.method_3();
			if (base.OperandStack.Count == 1)
			{
				method_5(base.OperandStack.method_3());
			}
			Class4605 command = Class4701.smethod_0(this, dx, dy);
			class4441_0.method_4(command);
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
		base.OperandStack.Clear();
	}

	public void method_4()
	{
		method_56();
		if (class4708_0.method_0())
		{
			double dx = base.OperandStack.method_3();
			if (base.OperandStack.Count == 1)
			{
				method_5(base.OperandStack.method_3());
			}
			Class4605 command = Class4701.smethod_0(this, dx, 0.0);
			class4441_0.method_4(command);
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
		base.OperandStack.Clear();
	}

	private void method_5(double pSObject)
	{
		double widthVectorX = class4444_0.PrivateFontDictionary.double_1 + pSObject;
		class4441_0.method_1(widthVectorX, 0.0);
	}

	public void method_6()
	{
		method_56();
		if (class4708_0.method_0())
		{
			double dy = base.OperandStack.method_3();
			if (base.OperandStack.Count == 1)
			{
				method_5(base.OperandStack.method_3());
			}
			Class4605 command = Class4701.smethod_0(this, 0.0, dy);
			class4441_0.method_4(command);
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
		base.OperandStack.Clear();
	}

	public void method_7()
	{
		method_8(0);
		base.OperandStack.Clear();
	}

	public void method_8(int untilOpCount)
	{
		int num = method_55();
		int num2 = 0;
		while (num2 < num - untilOpCount)
		{
			double dx = double_0[num2++];
			double dy = double_0[num2++];
			Class4603 command = Class4701.smethod_2(this, dx, dy);
			class4441_0.method_3(command);
		}
		if (untilOpCount <= 0)
		{
			return;
		}
		for (int num3 = untilOpCount; num3 > 0; num3--)
		{
			if (num - num3 >= 0)
			{
				base.OperandStack.method_0(double_0[num - num3]);
			}
		}
	}

	public void method_9()
	{
		method_11(isDx: true);
		base.OperandStack.Clear();
	}

	public void method_10()
	{
		method_11(isDx: false);
		base.OperandStack.Clear();
	}

	private void method_11(bool isDx)
	{
		int num = method_55();
		int num2 = 0;
		while (num2 < num)
		{
			double num3 = double_0[num2++];
			Class4603 command = ((!isDx) ? Class4701.smethod_2(this, 0.0, num3) : Class4701.smethod_2(this, num3, 0.0));
			class4441_0.method_3(command);
			isDx = !isDx;
		}
	}

	public void method_12()
	{
		method_13(0);
		base.OperandStack.Clear();
	}

	public void method_13(int untilOpCount)
	{
		int num = method_55();
		int num2 = 0;
		while (num2 < num - untilOpCount)
		{
			double dx = double_0[num2++];
			double dy = double_0[num2++];
			double dx2 = double_0[num2++];
			double dy2 = double_0[num2++];
			double dx3 = double_0[num2++];
			double dy3 = double_0[num2++];
			Class4602 command = Class4701.smethod_3(this, dx, dy, dx2, dy2, dx3, dy3);
			class4441_0.method_5(command);
		}
		if (untilOpCount <= 0)
		{
			return;
		}
		for (int num3 = untilOpCount; num3 > 0; num3--)
		{
			if (num - num3 >= 0)
			{
				base.OperandStack.method_0(double_0[num - num3]);
			}
		}
	}

	public void method_14()
	{
		int num = method_55();
		int num2 = 0;
		while (num2 < num)
		{
			double dy = 0.0;
			double dy2 = 0.0;
			if (num2 == 0 && num % 4 > 0)
			{
				dy = double_0[num2++];
			}
			double dx = double_0[num2++];
			double dx2 = double_0[num2++];
			double dy3 = double_0[num2++];
			double dx3 = double_0[num2++];
			Class4602 command = Class4701.smethod_3(this, dx, dy, dx2, dy3, dx3, dy2);
			class4441_0.method_5(command);
		}
		base.OperandStack.Clear();
	}

	public void method_15()
	{
		method_16(isHV: true);
		base.OperandStack.Clear();
	}

	public void method_16(bool isHV)
	{
		if (base.OperandStack.Count == 6)
		{
			double[] array = new double[5];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = base.OperandStack.method_3();
			}
			base.OperandStack.method_3();
			for (int j = 0; j < array.Length; j++)
			{
				base.OperandStack.method_0(array[j]);
			}
		}
		int num = method_55();
		int num2 = 0;
		while (num2 < num)
		{
			double dx;
			double dy;
			double dy2;
			double dx2;
			double dy3;
			double dx3;
			if (isHV ? ((byte)(num2 / 4 % 2) != 0) : (num2 / 4 % 2 == 0))
			{
				dx = 0.0;
				dy = 0.0;
				dy2 = double_0[num2++];
				dx2 = double_0[num2++];
				dy3 = double_0[num2++];
				dx3 = double_0[num2++];
				if (num2 == num - 1 && num % 4 > 0)
				{
					dy = double_0[num2++];
				}
			}
			else
			{
				dy2 = 0.0;
				dx3 = 0.0;
				dx = double_0[num2++];
				dx2 = double_0[num2++];
				dy3 = double_0[num2++];
				dy = double_0[num2++];
				if (num2 == num - 1 && num % 4 > 0)
				{
					dx3 = double_0[num2++];
				}
			}
			Class4602 command = Class4701.smethod_3(this, dx, dy2, dx2, dy3, dx3, dy);
			class4441_0.method_5(command);
		}
	}

	public void method_17()
	{
		method_13(2);
		method_8(0);
		base.OperandStack.Clear();
	}

	public void method_18()
	{
		method_8(6);
		method_13(0);
		base.OperandStack.Clear();
	}

	public void method_19()
	{
		method_16(isHV: false);
		base.OperandStack.Clear();
	}

	public void method_20()
	{
		int num = method_55();
		int num2 = 0;
		while (num2 < num)
		{
			double dx = 0.0;
			double dx2 = 0.0;
			if (num2 == 0 && num % 4 > 0)
			{
				dx = double_0[num2++];
			}
			double dy = double_0[num2++];
			double dx3 = double_0[num2++];
			double dy2 = double_0[num2++];
			double dy3 = double_0[num2++];
			Class4602 command = Class4701.smethod_3(this, dx, dy, dx3, dy2, dx2, dy3);
			class4441_0.method_5(command);
		}
		base.OperandStack.Clear();
	}

	public void method_21()
	{
		if (class4708_0.method_2(13))
		{
			base.OperandStack.method_3();
			double dy = base.OperandStack.method_3();
			double dx = base.OperandStack.method_3();
			double dy2 = base.OperandStack.method_3();
			double dx2 = base.OperandStack.method_3();
			double dy3 = base.OperandStack.method_3();
			double dx3 = base.OperandStack.method_3();
			double dy4 = base.OperandStack.method_3();
			double dx4 = base.OperandStack.method_3();
			double dy5 = base.OperandStack.method_3();
			double dx5 = base.OperandStack.method_3();
			double dy6 = base.OperandStack.method_3();
			double dx6 = base.OperandStack.method_3();
			Class4602 command = Class4701.smethod_3(this, dx6, dy6, dx5, dy5, dx4, dy4);
			class4441_0.method_5(command);
			command = Class4701.smethod_3(this, dx3, dy3, dx2, dy2, dx, dy);
			class4441_0.method_5(command);
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
		base.OperandStack.Clear();
	}

	public void method_22()
	{
		if (class4708_0.method_2(7))
		{
			double dy = 0.0;
			double dx = base.OperandStack.method_3();
			double dy2 = 0.0;
			double dx2 = base.OperandStack.method_3();
			double dy3 = 0.0;
			double dx3 = base.OperandStack.method_3();
			double dy4 = 0.0;
			double dx4 = base.OperandStack.method_3();
			double dy5 = base.OperandStack.method_3();
			double dx5 = base.OperandStack.method_3();
			double dy6 = 0.0;
			double dx6 = base.OperandStack.method_3();
			Class4602 command = Class4701.smethod_3(this, dx6, dy6, dx5, dy5, dx4, dy4);
			class4441_0.method_5(command);
			command = Class4701.smethod_3(this, dx3, dy3, dx2, dy2, dx, dy);
			class4441_0.method_5(command);
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
		base.OperandStack.Clear();
	}

	public void method_23()
	{
		if (class4708_0.method_2(9))
		{
			double dy = 0.0;
			double dx = base.OperandStack.method_3();
			double dy2 = base.OperandStack.method_3();
			double dx2 = base.OperandStack.method_3();
			double dy3 = 0.0;
			double dx3 = base.OperandStack.method_3();
			double dy4 = 0.0;
			double dx4 = base.OperandStack.method_3();
			double dy5 = base.OperandStack.method_3();
			double dx5 = base.OperandStack.method_3();
			double dy6 = base.OperandStack.method_3();
			double dx6 = base.OperandStack.method_3();
			Class4602 command = Class4701.smethod_3(this, dx6, dy6, dx5, dy5, dx4, dy4);
			class4441_0.method_5(command);
			command = Class4701.smethod_3(this, dx3, dy3, dx2, dy2, dx, dy);
			class4441_0.method_5(command);
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
		base.OperandStack.Clear();
	}

	public void method_24()
	{
		double num = base.OperandStack.method_3();
		if (class4708_0.method_2(10))
		{
			double dy = 0.0;
			double dx = 0.0;
			double num2 = base.OperandStack.method_3();
			double num3 = base.OperandStack.method_3();
			double num4 = base.OperandStack.method_3();
			double num5 = base.OperandStack.method_3();
			double num6 = base.OperandStack.method_3();
			double num7 = base.OperandStack.method_3();
			double num8 = base.OperandStack.method_3();
			double num9 = base.OperandStack.method_3();
			double num10 = base.OperandStack.method_3();
			double num11 = base.OperandStack.method_3();
			double value = num11 + num9 + num7 + num5 + num3;
			double value2 = num10 + num8 + num6 + num4 + num2;
			if (Math.Abs(value) > Math.Abs(value2))
			{
				dx = num;
			}
			else
			{
				dy = num;
			}
			Class4602 command = Class4701.smethod_3(this, num11, num10, num9, num8, num7, num6);
			class4441_0.method_5(command);
			command = Class4701.smethod_3(this, num5, num4, num3, num2, dx, dy);
			class4441_0.method_5(command);
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
		base.OperandStack.Clear();
	}

	public void method_25()
	{
		if (class4708_0.method_1())
		{
			base.OperandStack.method_3();
			base.OperandStack.method_3();
			while (base.OperandStack.Count >= 2)
			{
				base.OperandStack.method_3();
				base.OperandStack.method_3();
			}
		}
		if (base.OperandStack.Count == 1)
		{
			method_5(base.OperandStack.method_3());
		}
		base.OperandStack.Clear();
	}

	public void method_26()
	{
		if (class4708_0.method_1())
		{
			base.OperandStack.method_3();
			base.OperandStack.method_3();
			while (base.OperandStack.Count >= 2)
			{
				base.OperandStack.method_3();
				base.OperandStack.method_3();
			}
		}
		if (base.OperandStack.Count == 1)
		{
			method_5(base.OperandStack.method_3());
		}
		base.OperandStack.Clear();
	}

	public void method_27()
	{
		if (class4708_0.method_1())
		{
			base.OperandStack.method_3();
			base.OperandStack.method_3();
			int_0++;
			while (base.OperandStack.Count >= 2)
			{
				base.OperandStack.method_3();
				base.OperandStack.method_3();
				int_0++;
			}
		}
		if (base.OperandStack.Count == 1)
		{
			method_5(base.OperandStack.method_3());
		}
		base.OperandStack.Clear();
	}

	public void method_28()
	{
		if (class4708_0.method_1())
		{
			base.OperandStack.method_3();
			base.OperandStack.method_3();
			int_0++;
			while (base.OperandStack.Count >= 2)
			{
				base.OperandStack.method_3();
				base.OperandStack.method_3();
				int_0++;
			}
		}
		if (base.OperandStack.Count == 1)
		{
			method_5(base.OperandStack.method_3());
		}
		base.OperandStack.Clear();
	}

	public void method_29()
	{
		while (base.OperandStack.Count > 1)
		{
			base.OperandStack.method_3();
			base.OperandStack.method_3();
			int_0++;
		}
		if (base.OperandStack.Count == 1)
		{
			method_5(base.OperandStack.method_3());
		}
		base.OperandStack.Clear();
		base.OperandStack.method_0(int_0 + 7 >> 3);
	}

	public void method_30()
	{
		while (base.OperandStack.Count > 1)
		{
			base.OperandStack.method_3();
			base.OperandStack.method_3();
			int_0++;
		}
		if (base.OperandStack.Count == 1)
		{
			method_5(base.OperandStack.method_3());
		}
		base.OperandStack.Clear();
		base.OperandStack.method_0(int_0 + 7 >> 3);
	}

	public void method_31()
	{
		base.OperandStack.Clear();
	}

	public void method_32()
	{
		if (class4708_0.method_0())
		{
			double num = base.OperandStack.method_3();
			base.OperandStack.method_0(Class4599.smethod_1(num));
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
	}

	public void method_33()
	{
		if (class4708_0.method_1())
		{
			double num = base.OperandStack.method_3();
			double num2 = base.OperandStack.method_3();
			double operand = Class4599.Add(num2, num);
			base.OperandStack.method_0(operand);
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
	}

	public void method_34()
	{
		if (class4708_0.method_1())
		{
			double num = base.OperandStack.method_3();
			double num2 = base.OperandStack.method_3();
			double operand = Class4599.smethod_0(num2, num);
			base.OperandStack.method_0(operand);
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
	}

	public void method_35()
	{
		if (class4708_0.method_1())
		{
			double num = base.OperandStack.method_3();
			double num2 = base.OperandStack.method_3();
			double operand = Class4599.smethod_3(num2, num);
			base.OperandStack.method_0(operand);
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
	}

	public void method_36()
	{
		if (class4708_0.method_0())
		{
			double num = base.OperandStack.method_3();
			double operand = Class4599.smethod_2(num);
			base.OperandStack.method_0(operand);
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
	}

	public void method_37()
	{
		if (random_0 == null)
		{
			random_0 = new Random();
		}
		double num;
		for (num = 0.0; num == 0.0; num = random_0.NextDouble())
		{
		}
		base.OperandStack.method_0(num);
	}

	public void method_38()
	{
		if (class4708_0.method_1())
		{
			double num = base.OperandStack.method_3();
			double num2 = base.OperandStack.method_3();
			double operand = Class4599.smethod_4(num2, num);
			base.OperandStack.method_0(operand);
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
	}

	public void method_39()
	{
		if (class4708_0.method_0())
		{
			double num = base.OperandStack.method_3();
			double operand = Class4599.smethod_5(num);
			base.OperandStack.method_0(operand);
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
	}

	public void method_40()
	{
		base.OperandStack.method_3();
	}

	public void method_41()
	{
		double operand = base.OperandStack.method_3();
		double operand2 = base.OperandStack.method_3();
		base.OperandStack.method_0(operand);
		base.OperandStack.method_0(operand2);
	}

	public void method_42()
	{
		long num = (long)base.OperandStack.method_3();
		if (num < base.OperandStack.Count)
		{
			int num2 = method_55();
			double operand = double_0[(int)(num2 - 1 - num)];
			double[] array = double_0;
			foreach (double operand2 in array)
			{
				base.OperandStack.method_0(operand2);
			}
			base.OperandStack.method_0(operand);
		}
		else
		{
			base.OperandStack.method_0(0.0);
		}
	}

	public void method_43()
	{
		long num = (long)base.OperandStack.method_3();
		long num2 = (long)base.OperandStack.method_3();
		if (num2 <= 0L)
		{
			return;
		}
		int num3 = method_55();
		long num4 = num3 - 1 - num2;
		for (long num5 = 0L; num5 < num4; num5++)
		{
			base.OperandStack.method_0(double_0[(int)num5]);
		}
		if (num < 0L)
		{
			for (long num6 = num4 + (int)Math.Abs(num) + 1L; num6 < num3; num6++)
			{
				base.OperandStack.method_0(double_0[(int)num6]);
			}
			for (long num7 = num4 + 1L; num7 < num4 + (int)Math.Abs(num) + 1L; num7++)
			{
				base.OperandStack.method_0(double_0[(int)num7]);
			}
		}
		else
		{
			for (long num8 = num3 - 1 - num; num8 < num3; num8++)
			{
				base.OperandStack.method_0(double_0[(int)num8]);
			}
			for (long num9 = num4 + 1L; num9 < num3 - 1 - num; num9++)
			{
				base.OperandStack.method_0(double_0[(int)num9]);
			}
		}
	}

	public void method_44()
	{
		double operand = base.OperandStack.method_3();
		base.OperandStack.method_0(operand);
		base.OperandStack.method_0(operand);
	}

	public void method_45()
	{
		if (class4708_0.method_0())
		{
			int num = (int)base.OperandStack.method_3();
			double num2 = base.OperandStack.method_3();
			double_1[num] = num2;
		}
	}

	public void method_46()
	{
		if (class4708_0.method_0())
		{
			int num = (int)base.OperandStack.method_3();
			base.OperandStack.method_0(double_1[num]);
		}
	}

	public void method_47()
	{
		if (class4708_0.method_1())
		{
			double num = base.OperandStack.method_3();
			double num2 = base.OperandStack.method_3();
			if (num2 != 0.0 && num != 0.0)
			{
				base.OperandStack.method_0(1.0);
			}
			else
			{
				base.OperandStack.method_0(0.0);
			}
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
	}

	public void method_48()
	{
		if (class4708_0.method_1())
		{
			double num = base.OperandStack.method_3();
			double num2 = base.OperandStack.method_3();
			if (num2 == 0.0 && num == 0.0)
			{
				base.OperandStack.method_0(0.0);
			}
			else
			{
				base.OperandStack.method_0(1.0);
			}
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
	}

	public void method_49()
	{
		if (class4708_0.method_0())
		{
			double num = base.OperandStack.method_3();
			if (num != 0.0)
			{
				base.OperandStack.method_0(0.0);
			}
			else
			{
				base.OperandStack.method_0(1.0);
			}
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
	}

	public void method_50()
	{
		if (class4708_0.method_1())
		{
			double num = base.OperandStack.method_3();
			double num2 = base.OperandStack.method_3();
			if (num2 == num)
			{
				base.OperandStack.method_0(1.0);
			}
			else
			{
				base.OperandStack.method_0(0.0);
			}
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
	}

	public void method_51()
	{
		if (class4708_0.method_2(4))
		{
			double num = base.OperandStack.method_3();
			double num2 = base.OperandStack.method_3();
			double operand = base.OperandStack.method_3();
			double operand2 = base.OperandStack.method_3();
			if (num2 <= num)
			{
				base.OperandStack.method_0(operand2);
			}
			else
			{
				base.OperandStack.method_0(operand);
			}
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
	}

	public void method_52()
	{
		if (!class4708_0.method_0())
		{
			return;
		}
		int num = (int)base.OperandStack.method_3();
		num += class4444_0.CustomParams.LocalSubrsBias;
		if (num < class4444_0.LocalSubrsIndex.ObjectsCount)
		{
			try
			{
				class4444_0.LocalSubrsIndex.method_0(num, out var offset, out var length);
				class4552_0.method_1(class4444_0.LocalSubrsIndex.IndexData, offset, length);
				imethod_0(class4552_0);
			}
			finally
			{
				class4552_0.method_2();
			}
		}
	}

	public void method_53()
	{
		if (!class4708_0.method_0())
		{
			return;
		}
		int num = (int)base.OperandStack.method_3();
		num += class4409_0.Internals.CustomParams.GlobalSubrsBias;
		if (num < class4409_0.Internals.GlobalSubrsIndex.ObjectsCount)
		{
			try
			{
				class4409_0.Internals.GlobalSubrsIndex.method_0(num, out var offset, out var length);
				class4552_0.method_1(class4409_0.Internals.GlobalSubrsIndex.IndexData, offset, length);
				imethod_0(class4552_0);
			}
			finally
			{
				class4552_0.method_2();
			}
		}
	}

	public void method_54()
	{
	}

	private int method_55()
	{
		int count = base.OperandStack.Count;
		while (base.OperandStack.Count > 0)
		{
			double_0[base.OperandStack.Count - 1] = base.OperandStack.method_3();
		}
		return count;
	}

	public void method_56()
	{
		Class4601 @class = Class4701.smethod_4(this);
		if (@class != null)
		{
			class4441_0.method_6(@class);
		}
	}
}
