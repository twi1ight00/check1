using System;
using System.IO;
using ns171;
using ns175;
using ns176;
using ns178;
using ns183;
using ns187;

namespace ns189;

internal class Class5110 : Class5109
{
	private string string_5;

	private string string_6;

	private int int_7;

	private int int_8;

	private Interface182 interface182_6;

	public Class5110(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		string_5 = pList.method_6(Enum679.const_319).vmethod_13();
		string_6 = Class5409.smethod_0(string_5);
		Class5738 @class = method_2();
		Class5253 class2 = @class.method_0().method_14();
		Class5741 class3 = null;
		try
		{
			class3 = class2.method_0(string_6, @class.method_35());
		}
		catch (IOException)
		{
			Console.Out.WriteLine("Error: can't load image " + string_6);
		}
		if (class3 != null)
		{
			int_7 = class3.method_2().method_8();
			int_8 = class3.method_2().method_9();
			int num = class3.method_2().method_5();
			if (num != 0)
			{
				interface182_6 = Class5036.smethod_2(-num);
			}
		}
	}

	internal override void vmethod_10()
	{
		base.vmethod_10();
		vmethod_3().vmethod_50(this);
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			method_11(loc, nsURI, localName);
		}
	}

	public string method_57()
	{
		return string_5;
	}

	public string method_58()
	{
		return string_6;
	}

	public override string vmethod_21()
	{
		return "external-graphic";
	}

	public override int vmethod_24()
	{
		return 14;
	}

	public override int vmethod_32()
	{
		return int_7;
	}

	public override int vmethod_33()
	{
		return int_8;
	}

	public override Interface182 vmethod_34()
	{
		return interface182_6;
	}
}
