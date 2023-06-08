using ns102;
using ns118;
using ns126;
using ns132;
using ns133;
using ns134;
using ns153;
using ns154;
using ns158;
using ns159;
using ns160;
using ns99;

namespace ns117;

internal class Class4464 : Class4460
{
	private Class4737 class4737_0;

	private Class4733 class4733_0;

	private Class4732 class4732_0;

	private Class4552 class4552_0;

	private Class4413 class4413_0;

	private Class4708 class4708_0;

	private static Class4716 class4716_0;

	private Class4480 class4480_0;

	public Class4480 Glyph => class4480_0;

	public Class4464(Interface116 interpreterContext, Class4413 font, Class4480 glyph)
		: base(interpreterContext)
	{
		class4552_0 = new Class4552();
		class4413_0 = font;
		class4480_0 = glyph;
		class4708_0 = new Class4708(base.OperandStack);
		method_0();
	}

	static Class4464()
	{
		class4716_0 = new Class4716();
		class4716_0.method_0();
	}

	public override void vmethod_0(string commandName)
	{
		switch (commandName)
		{
		case "hstem":
			method_16();
			break;
		case "vstem":
			method_18();
			break;
		case "vmoveto":
			method_14();
			break;
		case "rlineto":
			method_9();
			break;
		case "hlineto":
			method_6();
			break;
		case "vlineto":
			method_13();
			break;
		case "rrcurveto":
			method_11();
			break;
		case "closepath":
			method_5();
			break;
		case "callsubr":
			method_22();
			break;
		case "return":
			method_24();
			break;
		case "hsbw":
			method_2();
			break;
		case "endchar":
			method_1();
			break;
		case "rmoveto":
			method_10();
			break;
		case "hmoveto":
			method_7();
			break;
		case "vhcurveto":
			method_12();
			break;
		case "hvcurveto":
			method_8();
			break;
		case "dotsection":
			method_15();
			break;
		case "vstem3":
			method_19();
			break;
		case "hstem3":
			method_17();
			break;
		case "seac":
			method_3();
			break;
		case "sbw":
			method_4();
			break;
		case "div":
			method_20();
			break;
		case "callothersubr":
			method_21();
			break;
		case "pop":
			method_23();
			break;
		case "setcurrentpoint":
			method_25();
			break;
		}
	}

	private void method_0()
	{
		class4737_0 = new Class4737(class4480_0);
		class4733_0 = new Class4733(this);
		class4732_0 = new Class4732();
		if (!class4413_0.RenderingContext.GlobalHints.method_0(typeof(Class4734)))
		{
			Class4734 hint = new Class4734(class4413_0.Type1FontDictionary.Private.BlueValues, class4413_0.Type1FontDictionary.Private.OtherBlues, class4413_0.Type1FontDictionary.Private.BlueScale, class4413_0.Type1FontDictionary.Private.BlueShift);
			class4413_0.RenderingContext.GlobalHints.Add(hint);
		}
	}

	public void method_1()
	{
		class4737_0.method_2();
	}

	public void method_2()
	{
		if (class4708_0.method_1())
		{
			double widthVectorX = base.OperandStack.method_3();
			double num = base.OperandStack.method_3();
			double x = num;
			method_0();
			base.GraphStateStack.Current.Position = new Class4600(x, 0.0);
			class4737_0.method_0(num, 0.0);
			class4737_0.method_1(widthVectorX, 0.0);
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
	}

	public void method_3()
	{
		double num = base.OperandStack.method_3();
		double num2 = base.OperandStack.method_3();
		double num3 = base.OperandStack.method_3();
		double num4 = base.OperandStack.method_3();
		double num5 = base.OperandStack.method_3();
		if (class4413_0.SeacSequence.Contains(num) || class4413_0.SeacSequence.Contains(num2))
		{
			return;
		}
		class4413_0.SeacSequence.Add(num);
		class4413_0.SeacSequence.Add(num2);
		try
		{
			Class4506 id = new Class4507(class4716_0[(ushort)num]);
			Class4480 @class = class4413_0.imethod_0(id);
			Class4506 id2 = new Class4507(class4716_0[(ushort)num2]);
			Class4480 class2 = class4413_0.imethod_0(id2);
			double dx = 0.0;
			double dy = 0.0;
			if (class2 != null)
			{
				dx = Glyph.LeftSidebearingX + num4 - num5;
				dy = Glyph.LeftSidebearingY + num3;
			}
			if (@class != null)
			{
				class4737_0.method_12(@class.Path, dx, dy);
			}
			if (class2 != null)
			{
				class4737_0.method_11(class2.Path);
			}
		}
		finally
		{
			class4413_0.SeacSequence.Remove(num);
			class4413_0.SeacSequence.Remove(num2);
		}
	}

	public void method_4()
	{
		if (class4708_0.method_2(4))
		{
			double widthVectorY = base.OperandStack.method_3();
			double widthVectorX = base.OperandStack.method_3();
			double num = base.OperandStack.method_3();
			double num2 = base.OperandStack.method_3();
			double num3 = num2;
			double num4 = num;
			method_0();
			base.GraphStateStack.Current.Position = new Class4600(num3, num4);
			class4737_0.method_0(num3, num4);
			class4737_0.method_1(widthVectorX, widthVectorY);
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
	}

	public void method_5()
	{
		Class4601 command = Class4701.smethod_4(this);
		class4737_0.method_10(command);
	}

	public void method_6()
	{
		if (class4708_0.method_0())
		{
			double dx = base.OperandStack.method_3();
			Class4603 command = Class4701.smethod_2(this, dx, 0.0);
			class4737_0.method_7(command);
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
	}

	public void method_7()
	{
		if (class4708_0.method_0())
		{
			double dx = base.OperandStack.method_3();
			if (!class4733_0.IsRecording)
			{
				Class4605 command = Class4701.smethod_0(this, dx, 0.0);
				class4737_0.method_8(command);
			}
			else
			{
				class4733_0.method_2(dx, 0.0);
			}
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
	}

	public void method_8()
	{
		if (class4708_0.method_2(4))
		{
			double dy = base.OperandStack.method_3();
			double dy2 = base.OperandStack.method_3();
			double dx = base.OperandStack.method_3();
			double dx2 = base.OperandStack.method_3();
			Class4602 command = Class4701.smethod_3(this, dx2, 0.0, dx, dy2, 0.0, dy);
			class4737_0.method_9(command);
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
	}

	public void method_9()
	{
		if (class4708_0.method_1())
		{
			double dy = base.OperandStack.method_3();
			double dx = base.OperandStack.method_3();
			Class4603 command = Class4701.smethod_2(this, dx, dy);
			class4737_0.method_7(command);
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
	}

	public void method_10()
	{
		if (class4708_0.method_1())
		{
			double dy = base.OperandStack.method_3();
			double dx = base.OperandStack.method_3();
			if (!class4733_0.IsRecording)
			{
				Class4605 command = Class4701.smethod_0(this, dx, dy);
				class4737_0.method_8(command);
			}
			else
			{
				class4733_0.method_2(dx, dy);
			}
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
	}

	public void method_11()
	{
		if (class4708_0.method_2(6))
		{
			double dy = base.OperandStack.method_3();
			double dx = base.OperandStack.method_3();
			double dy2 = base.OperandStack.method_3();
			double dx2 = base.OperandStack.method_3();
			double dy3 = base.OperandStack.method_3();
			double dx3 = base.OperandStack.method_3();
			Class4602 command = Class4701.smethod_3(this, dx3, dy3, dx2, dy2, dx, dy);
			class4737_0.method_9(command);
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
	}

	public void method_12()
	{
		if (class4708_0.method_2(4))
		{
			double dx = base.OperandStack.method_3();
			double dy = base.OperandStack.method_3();
			double dx2 = base.OperandStack.method_3();
			double dy2 = base.OperandStack.method_3();
			Class4602 command = Class4701.smethod_3(this, 0.0, dy2, dx2, dy, dx, 0.0);
			class4737_0.method_9(command);
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
	}

	public void method_13()
	{
		if (class4708_0.method_0())
		{
			double dy = base.OperandStack.method_3();
			Class4603 command = Class4701.smethod_2(this, 0.0, dy);
			class4737_0.method_7(command);
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
	}

	public void method_14()
	{
		if (class4708_0.method_0())
		{
			double dy = base.OperandStack.method_3();
			Class4605 command = Class4701.smethod_0(this, 0.0, dy);
			class4737_0.method_8(command);
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
	}

	public void method_15()
	{
	}

	public void method_16()
	{
		if (class4708_0.method_1())
		{
			double dy = base.OperandStack.method_3();
			double y = base.OperandStack.method_3();
			class4737_0.method_4(y, dy);
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
	}

	public void method_17()
	{
		base.OperandStack.method_3();
		base.OperandStack.method_3();
		base.OperandStack.method_3();
		base.OperandStack.method_3();
		base.OperandStack.method_3();
		base.OperandStack.method_3();
	}

	public void method_18()
	{
		if (class4708_0.method_1())
		{
			double dx = base.OperandStack.method_3();
			double x = base.OperandStack.method_3();
			class4737_0.method_5(x, dx);
		}
		else
		{
			base.ErrorHandler.imethod_0("PostScript error. Wrong operands for operator (see a stack for operator name).");
		}
	}

	public void method_19()
	{
		base.OperandStack.method_3();
		base.OperandStack.method_3();
		base.OperandStack.method_3();
		base.OperandStack.method_3();
		base.OperandStack.method_3();
		base.OperandStack.method_3();
	}

	public void method_20()
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

	public void method_21()
	{
		if (!class4708_0.method_1())
		{
			return;
		}
		double num = base.OperandStack.method_3();
		int num2 = (int)num;
		double num3 = base.OperandStack.method_3();
		switch (num2)
		{
		case 3:
			class4737_0.method_6();
			break;
		case 1:
			class4733_0.method_0();
			break;
		case 0:
		{
			class4733_0.method_1();
			Class4602[] resultCurves = class4733_0.ResultCurves;
			foreach (Class4602 command in resultCurves)
			{
				class4737_0.method_9(command);
			}
			break;
		}
		case 12:
		case 13:
		{
			int num4 = (int)num3;
			for (int i = 0; i < num4; i++)
			{
				class4732_0.method_2(base.OperandStack.method_3());
			}
			if (num2 == 13)
			{
				class4732_0.method_1();
				class4737_0.method_3(class4732_0.ResultHorizontalGroups, class4732_0.ResultVerticalGroups);
			}
			break;
		}
		}
	}

	public void method_22()
	{
		double num = base.OperandStack.method_3();
		int num2 = (int)num;
		if (num2 < base.Subroutines.class4723_0.Length)
		{
			try
			{
				class4552_0.method_0(base.Subroutines.class4723_0[num2].PsProgram);
				imethod_0(class4552_0);
			}
			finally
			{
				class4552_0.method_2();
			}
		}
	}

	public void method_23()
	{
		double operand = base.OperandStack.method_3();
		base.OperandStack.method_0(operand);
	}

	public void method_24()
	{
	}

	public void method_25()
	{
		base.OperandStack.method_3();
		base.OperandStack.method_3();
	}
}
