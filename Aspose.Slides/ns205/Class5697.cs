using ns176;
using ns184;
using ns187;

namespace ns205;

internal class Class5697
{
	private Class5746 class5746_0;

	private bool bool_0;

	private bool bool_1;

	private int int_0;

	public Class5697(Class5046 spaceprop, Interface172 context)
	{
		class5746_0 = smethod_0(spaceprop, context);
		bool_0 = spaceprop.method_14().imethod_0() == 32;
		Class5024 @class = spaceprop.method_13();
		if (@class.vmethod_9() != null)
		{
			int_0 = (int)@class.vmethod_9();
			bool_1 = false;
		}
		else
		{
			bool_1 = @class.imethod_0() == 53;
			int_0 = 0;
		}
	}

	private static Class5746 smethod_0(Class5046 spaceprop, Interface172 context)
	{
		int min = spaceprop.method_8(context).vmethod_0().imethod_6(context);
		int opt = spaceprop.method_10(context).vmethod_0().imethod_6(context);
		int max = spaceprop.method_9(context).vmethod_0().imethod_6(context);
		return Class5746.smethod_0(min, opt, max);
	}

	public Class5697(Class5746 space, bool conditional, bool forcing, int precedence)
	{
		class5746_0 = space;
		bool_0 = conditional;
		bool_1 = forcing;
		int_0 = precedence;
	}

	public static Class5697 smethod_1(Class5024 wordSpacing, Class5697 letterSpacing, Class5729 fs)
	{
		if (wordSpacing.imethod_0() == 97)
		{
			int num = fs.method_16(' ');
			Class5746 @class = Class5746.smethod_0(-num / 3, 0, num / 2);
			return new Class5697(@class.method_6(letterSpacing.method_3().method_15(2)), conditional: true, forcing: true, 0);
		}
		return new Class5697(wordSpacing.vmethod_5(), null);
	}

	public static Class5697 smethod_2(Class5024 letterSpacing)
	{
		if (letterSpacing.imethod_0() == 97)
		{
			return new Class5697(Class5746.class5746_0, conditional: true, forcing: true, 0);
		}
		return new Class5697(letterSpacing.vmethod_5(), null);
	}

	public bool method_0()
	{
		return bool_0;
	}

	public bool method_1()
	{
		return bool_1;
	}

	public int method_2()
	{
		return int_0;
	}

	public Class5746 method_3()
	{
		return class5746_0;
	}

	public override string ToString()
	{
		return "SpaceVal: " + method_3().ToString();
	}
}
