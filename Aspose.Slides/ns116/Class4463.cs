using ns108;
using ns118;
using ns153;

namespace ns116;

internal class Class4463 : Class4460
{
	private Class4708 class4708_0;

	private Class4447 class4447_0;

	public Class4463(Interface116 interpreterContext, Class4447 privateDictionary)
		: base(interpreterContext)
	{
		class4447_0 = privateDictionary;
		class4708_0 = new Class4708(base.OperandStack);
		method_0();
	}

	private void method_0()
	{
	}

	public override void vmethod_0(string commandName)
	{
		switch (commandName)
		{
		case "BlueValues":
			method_1();
			break;
		case "OtherBlues":
			method_2();
			break;
		case "FamilyBlues":
			method_3();
			break;
		case "FamilyOtherBlues":
			method_4();
			break;
		case "StdHW":
			method_5();
			break;
		case "StdVW":
			method_6();
			break;
		case "Subrs":
			method_7();
			break;
		case "defaultWidthX":
			method_8();
			break;
		case "nominalWidthX":
			method_9();
			break;
		case "BlueScale":
			method_10();
			break;
		case "BlueShift":
			method_11();
			break;
		case "BlueFuzz":
			method_12();
			break;
		case "StemSnapH":
			method_13();
			break;
		case "StemSnapV":
			method_14();
			break;
		case "ForceBold":
			method_15();
			break;
		case "LanguageGroup":
			method_16();
			break;
		case "ExpansionFactor":
			method_17();
			break;
		case "initialRandomSeed":
			method_18();
			break;
		}
	}

	public void method_1()
	{
		base.OperandStack.Clear();
	}

	public void method_2()
	{
		base.OperandStack.Clear();
	}

	public void method_3()
	{
		base.OperandStack.Clear();
	}

	public void method_4()
	{
		base.OperandStack.Clear();
	}

	public void method_5()
	{
		base.OperandStack.Clear();
	}

	public void method_6()
	{
		base.OperandStack.Clear();
	}

	public void method_7()
	{
		if (class4708_0.method_0())
		{
			double num = base.OperandStack.method_3();
			class4447_0.long_0 = (long)num;
		}
		base.OperandStack.Clear();
	}

	public void method_8()
	{
		if (class4708_0.method_0())
		{
			double double_ = base.OperandStack.method_3();
			class4447_0.double_0 = double_;
		}
	}

	public void method_9()
	{
		if (class4708_0.method_0())
		{
			double double_ = base.OperandStack.method_3();
			class4447_0.double_1 = double_;
		}
	}

	public void method_10()
	{
		base.OperandStack.Clear();
	}

	public void method_11()
	{
		base.OperandStack.Clear();
	}

	public void method_12()
	{
		base.OperandStack.Clear();
	}

	public void method_13()
	{
		base.OperandStack.Clear();
	}

	public void method_14()
	{
		base.OperandStack.Clear();
	}

	public void method_15()
	{
		base.OperandStack.Clear();
	}

	public void method_16()
	{
		base.OperandStack.Clear();
	}

	public void method_17()
	{
		base.OperandStack.Clear();
	}

	public void method_18()
	{
		base.OperandStack.Clear();
	}
}
