using ns171;
using ns174;
using ns176;
using ns178;
using ns187;

namespace ns189;

internal class Class5098 : Class5097, Interface223
{
	private Interface182 interface182_0;

	private int int_1;

	private Interface182 interface182_1;

	private int int_2;

	private Interface244 interface244_0;

	private string string_3;

	private string string_4;

	private int int_3;

	private int int_4;

	private bool bool_1;

	public Class5098(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		interface182_0 = pList.method_6(Enum679.const_4).vmethod_0();
		int_1 = pList.method_6(Enum679.const_5).imethod_0();
		interface182_1 = pList.method_6(Enum679.const_16).vmethod_0();
		int_2 = pList.method_6(Enum679.const_175).imethod_0();
		string_3 = pList.method_6(Enum679.const_181).vmethod_13();
		string_4 = pList.method_6(Enum679.const_215).vmethod_13();
		int_3 = pList.method_6(Enum679.const_306).imethod_0();
		int_4 = pList.method_5(266).imethod_0();
		if (string_4.Length > 0)
		{
			string_3 = null;
		}
		else if (string_3.Length == 0)
		{
			method_5().imethod_14(this, method_17(), interface243_0);
		}
	}

	public int method_57()
	{
		return int_4;
	}

	internal override void vmethod_10()
	{
		base.vmethod_10();
		vmethod_3().vmethod_48(this);
	}

	internal override void vmethod_11()
	{
		base.vmethod_11();
		vmethod_3().vmethod_49(this);
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if (!"http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			return;
		}
		if (localName.Equals("marker"))
		{
			if (bool_1)
			{
				method_9(loc, "fo:marker", "(#PCDATA|%inline;|%block;)");
			}
		}
		else if (!method_35(nsURI, localName))
		{
			method_11(loc, nsURI, localName);
		}
		else
		{
			bool_1 = true;
		}
	}

	public Interface182 method_58()
	{
		return interface182_0;
	}

	public int method_59()
	{
		return int_1;
	}

	public Interface182 method_60()
	{
		return interface182_1;
	}

	public int method_61()
	{
		return int_2;
	}

	public override void vmethod_29(Interface244 structureTreeElement)
	{
		interface244_0 = structureTreeElement;
	}

	public Interface244 imethod_1()
	{
		return interface244_0;
	}

	public string method_62()
	{
		return string_4;
	}

	public string method_63()
	{
		return string_3;
	}

	public bool method_64()
	{
		if (string_4 != null)
		{
			return string_4.Length > 0;
		}
		return false;
	}

	public bool method_65()
	{
		if (string_3 != null)
		{
			return string_3.Length > 0;
		}
		return false;
	}

	public int method_66()
	{
		return int_3;
	}

	public override string vmethod_21()
	{
		return "basic-link";
	}

	public override int vmethod_24()
	{
		return 1;
	}
}
