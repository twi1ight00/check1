using System;
using System.Runtime.CompilerServices;
using ns22;

namespace ns18;

internal class Class942 : Class941
{
	private Class1201 class1201_0;

	private Class939 class939_0;

	private bool bool_1;

	private Class940 class940_0;

	internal Class942(Class1440 class1440_1, Class1201 class1201_1)
		: this(class1440_1, class1201_1, bool_2: false)
	{
	}

	internal Class942(Class1440 class1440_1, Class1201 class1201_1, bool bool_2)
		: base(class1440_1)
	{
		class1201_0 = class1201_1;
		bool_1 = bool_2;
	}

	internal override void vmethod_3(Class1447 class1447_0)
	{
		class1447_0.method_11("/Type", "/XObject");
		class1447_0.method_11("/Subtype", "/Image");
		class1447_0.method_16("/Width", class1201_0.Width);
		class1447_0.method_16("/Height", class1201_0.Height);
		method_18(class1447_0);
		class1447_0.method_16("/BitsPerComponent", method_22());
		if (class1201_0.vmethod_2())
		{
			class940_0 = new Class940(class1440_0, class1201_0.method_1(), class1201_0.Width, class1201_0.Height);
			class1447_0.method_11("/SMask", class940_0.method_1());
		}
	}

	public override void vmethod_1(Class1447 class1447_0)
	{
		if (method_23())
		{
			method_19();
		}
		else
		{
			byte[] array = (bool_1 ? class1201_0.method_1() : class1201_0.method_0());
			Write(array, 0, array.Length);
		}
		base.vmethod_1(class1447_0);
		if (class939_0 != null)
		{
			class939_0.vmethod_1(class1447_0);
		}
		if (class940_0 != null)
		{
			class940_0.vmethod_1(class1447_0);
		}
	}

	private void method_18(Class1447 class1447_0)
	{
		Class1439 @class = method_21();
		if (@class != Class1439.smethod_2())
		{
			class1447_0.method_11("/ColorSpace", $"/{@class.method_0()}");
			return;
		}
		method_20();
		class1447_0.method_11("/ColorSpace", $"[/{@class.method_0()}/DeviceRGB {class1201_0.method_2().Length - 1} {class939_0.method_1()}]");
	}

	[Attribute0(true)]
	private void method_19()
	{
		switch (class1440_0.method_1().method_1())
		{
		default:
			throw new Exception("Unknown image compression.");
		case Enum208.const_4:
			Class1402.smethod_0(class1201_0.Image, method_4(), class1440_0.method_1().method_3());
			break;
		case Enum208.const_5:
			Class1402.smethod_1(class1201_0.Image, method_4(), Enum201.const_3, bool_0: false);
			break;
		case Enum208.const_6:
			Class1402.smethod_1(class1201_0.Image, method_4(), Enum201.const_4, bool_0: false);
			break;
		}
	}

	private void method_20()
	{
		class939_0 = new Class939(class1440_0);
		for (int i = 0; i < class1201_0.method_2().Length; i++)
		{
			class939_0.WriteByte(class1201_0.method_2()[i].R);
			class939_0.WriteByte(class1201_0.method_2()[i].G);
			class939_0.WriteByte(class1201_0.method_2()[i].B);
		}
	}

	internal static void smethod_0(Class939 class939_1, Class1201 class1201_1)
	{
		class939_1.method_8("BI");
		class939_1.Write("/W {0}", class1201_1.Width);
		class939_1.Write("/H {0}", class1201_1.Height);
		class939_1.Write("/CS/{0}", class1201_1.vmethod_1().method_1());
		class939_1.method_9("/BPC {0}", class1201_1.vmethod_0());
		class939_1.Write("ID ");
		class939_1.Write(class1201_1.method_0(), 0, class1201_1.method_0().Length);
		class939_1.Write("\r\n");
		class939_1.method_8("EI");
	}

	private Class1439 method_21()
	{
		if (bool_1)
		{
			return Class1439.smethod_0();
		}
		if (class1440_0.method_1().method_6() == Enum205.const_6)
		{
			return Class1439.smethod_0();
		}
		if (method_23())
		{
			return Class1439.smethod_1();
		}
		return class1201_0.vmethod_1();
	}

	private int method_22()
	{
		if (bool_1)
		{
			return 8;
		}
		if (class1440_0.method_1().method_6() == Enum205.const_6)
		{
			return 1;
		}
		return class1201_0.vmethod_0();
	}

	[SpecialName]
	protected override bool vmethod_4()
	{
		return true;
	}

	[SpecialName]
	private bool method_23()
	{
		if (!bool_1 && class1440_0.method_1().method_4())
		{
			return class1201_0.Image != null;
		}
		return false;
	}
}
