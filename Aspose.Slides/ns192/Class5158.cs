using System.Collections;
using System.Text;
using ns171;
using ns176;
using ns178;
using ns187;
using ns197;
using ns205;

namespace ns192;

internal class Class5158 : Class5149
{
	private Class5703 class5703_0;

	private int int_1;

	private Interface182 interface182_0;

	private Class5746 class5746_0;

	private int int_2;

	private int int_3;

	private bool bool_1;

	private Class5634 class5634_0;

	internal int int_4;

	internal Hashtable hashtable_2 = new Hashtable();

	internal int int_5;

	public Class5158(Class5088 parent)
		: this(parent, @implicit: false)
	{
	}

	public Class5158(Class5088 parent, bool @implicit)
		: base(parent)
	{
		bool_1 = @implicit;
	}

	public override void vmethod_2(Class5634 pLisT)
	{
		class5703_0 = pLisT.method_17();
		int_1 = pLisT.method_5(76).vmethod_10().imethod_5();
		interface182_0 = pLisT.method_5(77).vmethod_0();
		int_2 = pLisT.method_5(164).vmethod_10().imethod_5();
		int_3 = pLisT.method_5(165).vmethod_10().imethod_5();
		base.vmethod_2(pLisT);
		if (int_2 <= 0)
		{
			Interface245 @interface = Class5754.smethod_0(method_2().method_48());
			@interface.imethod_6(this, "number-columns-repeated", int_2, method_1());
		}
		if (int_3 <= 0)
		{
			Interface245 interface2 = Class5754.smethod_0(method_2().method_48());
			interface2.imethod_6(this, "number-columns-spanned", int_3, method_1());
		}
		if (interface182_0.imethod_0() == 9)
		{
			if (!bool_1 && !vmethod_32().method_56())
			{
				Interface245 interface3 = Class5754.smethod_0(method_2().method_48());
				interface3.imethod_7(this, method_1());
			}
			interface182_0 = new Class5038(1.0, this);
		}
		if (!bool_1)
		{
			class5634_0 = pLisT;
		}
	}

	internal override void vmethod_10()
	{
		base.vmethod_10();
		vmethod_3().vmethod_24(this);
	}

	internal void method_51(Class5711 collapsingBorderModel)
	{
		class5711_0 = collapsingBorderModel;
		method_49();
	}

	internal override void vmethod_11()
	{
		vmethod_3().vmethod_25(this);
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			method_11(loc, nsURI, localName);
		}
	}

	public override Class5703 vmethod_33()
	{
		return class5703_0;
	}

	public Interface182 method_52()
	{
		return interface182_0;
	}

	public Class5746 method_53()
	{
		return class5746_0;
	}

	public void method_54(Class5746 ipdRange)
	{
		class5746_0 = ipdRange;
	}

	public void method_55(Interface182 columnWidth)
	{
		interface182_0 = columnWidth;
	}

	public int method_56()
	{
		return int_1;
	}

	internal void method_57(int columnNumber)
	{
		int_1 = columnNumber;
	}

	public int method_58()
	{
		return int_2;
	}

	public int method_59()
	{
		return int_3;
	}

	public override string vmethod_21()
	{
		return "table-column";
	}

	public override int vmethod_24()
	{
		return 76;
	}

	public bool method_60()
	{
		return bool_1;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("fo:table-column");
		stringBuilder.Append(" column-number=").Append(method_56());
		if (method_58() > 1)
		{
			stringBuilder.Append(" number-columns-repeated=").Append(method_58());
		}
		if (method_59() > 1)
		{
			stringBuilder.Append(" number-columns-spanned=").Append(method_59());
		}
		stringBuilder.Append(" column-width=").Append(((Class5024)method_52()).vmethod_13());
		return stringBuilder.ToString();
	}

	public Class5024 method_61(int propId)
	{
		return class5634_0.method_5(propId);
	}

	internal void method_62()
	{
		class5634_0 = null;
	}

	public bool method_63()
	{
		return method_52() is Class5038;
	}
}
