using System;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using ns22;
using ns47;

namespace ns18;

internal abstract class Class954 : Class938
{
	protected string string_1;

	protected FontStyle fontStyle_0;

	internal Class1460 class1460_0;

	protected string string_2;

	protected Class954(Class1440 class1440_1, string string_3, FontStyle fontStyle_1, bool bool_0)
		: base(class1440_1)
	{
		string_1 = string_3;
		fontStyle_0 = fontStyle_1;
		class1460_0 = Class1462.smethod_3(string_3, fontStyle_1, bool_0: false);
		if (!bool_0)
		{
			class1460_0.Style = fontStyle_1;
			class1460_0.method_6(string_3);
		}
		if (class1460_0 == null)
		{
			throw new Exception(string_3 + Convert.ToString(fontStyle_1));
		}
		vmethod_5();
	}

	[Attribute0(true)]
	public virtual void vmethod_3(Stream stream_0)
	{
	}

	[Attribute0(true)]
	internal abstract string vmethod_4();

	public static Class954 smethod_0(Class1440 class1440_1, string string_3, FontStyle fontStyle_1, bool bool_0)
	{
		if (bool_0)
		{
			return new Class956(class1440_1, string_3, fontStyle_1);
		}
		return new Class955(class1440_1, string_3, fontStyle_1);
	}

	protected abstract void vmethod_5();

	protected int method_4(int int_1)
	{
		return int_1 * 1000 / class1460_0.method_9();
	}

	[SpecialName]
	public bool method_5()
	{
		if ((fontStyle_0 & FontStyle.Italic) != 0)
		{
			return (class1460_0.Style & FontStyle.Italic) == 0;
		}
		return false;
	}

	[SpecialName]
	public bool method_6()
	{
		if ((fontStyle_0 & FontStyle.Bold) != 0)
		{
			return (class1460_0.Style & FontStyle.Bold) == 0;
		}
		return false;
	}

	[SpecialName]
	public string method_7()
	{
		return string_2;
	}

	[SpecialName]
	public int method_8()
	{
		return -method_4(class1460_0.method_13());
	}

	[SpecialName]
	public int method_9()
	{
		return method_4(class1460_0.method_11());
	}

	[SpecialName]
	public int method_10()
	{
		return method_4(class1460_0.method_35());
	}

	[SpecialName]
	public int method_11()
	{
		int num = 0;
		num = 0 | 0x20;
		num = 0x20 | (((class1460_0.Style & FontStyle.Italic) != 0) ? 64 : 0);
		return num | (((class1460_0.Style & FontStyle.Bold) != 0) ? 262144 : 0);
	}

	[SpecialName]
	public RectangleF method_12()
	{
		return new RectangleF(method_4(class1460_0.method_25()), method_4(class1460_0.method_29()), method_4(class1460_0.method_31() - class1460_0.method_25()), method_4(class1460_0.method_33() - class1460_0.method_29()));
	}

	[SpecialName]
	public float method_13()
	{
		return class1460_0.method_37();
	}

	[SpecialName]
	internal override Enum209 vmethod_0()
	{
		return Enum209.const_1;
	}

	[SpecialName]
	internal abstract bool vmethod_6();
}
