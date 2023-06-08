using System;
using System.Runtime.CompilerServices;
using ns22;

namespace ns18;

internal abstract class Class938
{
	protected Class1440 class1440_0;

	protected string string_0;

	private int int_0;

	internal Class938(Class1440 class1440_1)
	{
		class1440_0 = class1440_1;
		int_0 = class1440_1.method_0();
		if (method_2())
		{
			string_0 = vmethod_2();
		}
	}

	[SpecialName]
	internal int method_0()
	{
		return int_0;
	}

	[SpecialName]
	internal string method_1()
	{
		return string.Format(int_0 + " 0 R");
	}

	[SpecialName]
	internal bool method_2()
	{
		return vmethod_0() != Enum209.const_0;
	}

	[SpecialName]
	internal string method_3()
	{
		return string_0;
	}

	[SpecialName]
	internal virtual Enum209 vmethod_0()
	{
		return Enum209.const_0;
	}

	[Attribute0(true)]
	public abstract void vmethod_1(Class1447 class1447_0);

	[Attribute0(true)]
	internal virtual string vmethod_2()
	{
		if (!method_2())
		{
			throw new Exception("Tried to generate a resource name not being a resource.");
		}
		return Class1451.smethod_1(vmethod_0()) + (class1440_0.method_2().method_0(vmethod_0()) + 1);
	}
}
