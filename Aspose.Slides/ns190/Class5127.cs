using System.Collections;
using ns171;
using ns176;
using ns178;
using ns182;
using ns205;

namespace ns190;

internal class Class5127 : Class5125, Interface231
{
	private string string_7;

	private string string_8;

	private string string_9;

	private Interface181 interface181_2;

	private Class5678 class5678_0;

	private Hashtable hashtable_2;

	private Class5171 class5171_0;

	private Class5169 class5169_0;

	private Class5099 class5099_0;

	private Class5128 class5128_0;

	public Class5127(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		string_7 = pList.method_6(Enum679.const_82).vmethod_13();
		string_8 = pList.method_6(Enum679.const_221).vmethod_13();
		string_9 = pList.method_6(Enum679.const_241).vmethod_13();
		interface181_2 = pList.method_6(Enum679.const_284).vmethod_10();
		class5678_0 = new Class5678(Class5445.smethod_1(pList.method_6(Enum679.const_354).imethod_0()));
		if (string.IsNullOrEmpty(string_9))
		{
			method_15("master-reference");
		}
	}

	internal override void vmethod_10()
	{
		base.vmethod_10();
		hashtable_2 = new Hashtable();
		class5171_0 = vmethod_20().method_57().method_52(string_9);
		if (class5171_0 == null)
		{
			class5169_0 = vmethod_20().method_57().method_54(string_9);
			if (class5169_0 == null)
			{
				method_5().imethod_19(this, method_17(), string_9, method_1());
			}
		}
		vmethod_3().vmethod_6(this);
	}

	internal override void vmethod_11()
	{
		if (class5128_0 == null)
		{
			method_13("(title?,static-content*,flow)");
		}
		vmethod_3().vmethod_7(this);
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if (!"http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			return;
		}
		if ("title".Equals(localName))
		{
			if (class5099_0 != null)
			{
				method_8(loc, "fo:title");
			}
			else if (hashtable_2.Count != 0)
			{
				method_9(loc, "fo:title", "fo:static-content");
			}
			else if (class5128_0 != null)
			{
				method_9(loc, "fo:title", "fo:flow");
			}
		}
		else if ("static-content".Equals(localName))
		{
			if (class5128_0 != null)
			{
				method_9(loc, "fo:static-content", "fo:flow");
			}
		}
		else if ("flow".Equals(localName))
		{
			if (class5128_0 != null)
			{
				method_8(loc, "fo:flow");
			}
		}
		else
		{
			method_11(loc, nsURI, localName);
		}
	}

	internal override void vmethod_12(Class5088 child)
	{
		switch ((Enum679)child.vmethod_24())
		{
		case Enum679.const_81:
			class5099_0 = (Class5099)child;
			break;
		default:
			base.vmethod_12(child);
			break;
		case Enum679.const_71:
			method_53((Class5129)child);
			hashtable_2.Add(((Class5128)child).method_48(), (Class5128)child);
			break;
		case Enum679.const_17:
			class5128_0 = (Class5128)child;
			method_53(class5128_0);
			break;
		}
	}

	private void method_53(Class5128 flow)
	{
		string text = flow.method_48();
		if (method_57(text))
		{
			method_5().imethod_17(this, flow.method_17(), text, flow.method_1());
		}
		if (!vmethod_20().method_57().method_55(text) && !text.Equals("xsl-before-float-separator") && !text.Equals("xsl-footnote-separator"))
		{
			method_5().imethod_18(this, flow.method_17(), text, flow.method_1());
		}
	}

	public Class5129 method_54(string name)
	{
		return (Class5129)hashtable_2[name];
	}

	public Class5099 method_55()
	{
		return class5099_0;
	}

	public Class5128 method_56()
	{
		return class5128_0;
	}

	public bool method_57(string flowName)
	{
		return hashtable_2.ContainsKey(flowName);
	}

	public Hashtable method_58()
	{
		return hashtable_2;
	}

	public Class5171 method_59(int page, bool isFirstPage, bool isLastPage, bool isBlank)
	{
		if (class5169_0 == null)
		{
			return class5171_0;
		}
		bool isOddPage = page % 2 == 1;
		return class5169_0.method_55(isOddPage, isFirstPage, isLastPage, isBlank, method_56().method_48());
	}

	public bool method_60()
	{
		if (class5169_0 != null)
		{
			return class5169_0.method_52();
		}
		return true;
	}

	public bool method_61()
	{
		if (class5169_0 != null)
		{
			return class5169_0.method_53();
		}
		return false;
	}

	public bool method_62()
	{
		if (class5169_0 != null)
		{
			return class5169_0.method_54();
		}
		return false;
	}

	public string method_63()
	{
		return string_9;
	}

	public override string vmethod_21()
	{
		return "page-sequence";
	}

	public override int vmethod_24()
	{
		return 53;
	}

	public string method_64()
	{
		return string_7;
	}

	public string method_65()
	{
		return string_8;
	}

	public override int vmethod_32()
	{
		if (interface181_2 != null)
		{
			return interface181_2.imethod_5();
		}
		return 0;
	}

	public Class5444 imethod_0()
	{
		if (class5678_0 != null)
		{
			return class5678_0.imethod_0();
		}
		return Class5444.class5444_0;
	}

	public Class5444 imethod_3()
	{
		if (class5678_0 != null)
		{
			return class5678_0.imethod_3();
		}
		return Class5444.class5444_2;
	}

	public Class5444 imethod_4()
	{
		if (class5678_0 != null)
		{
			return class5678_0.imethod_4();
		}
		return Class5444.class5444_0;
	}

	public Class5444 imethod_5()
	{
		if (class5678_0 != null)
		{
			return class5678_0.imethod_5();
		}
		return Class5444.class5444_2;
	}

	public Class5444 imethod_6()
	{
		if (class5678_0 != null)
		{
			return class5678_0.imethod_6();
		}
		return Class5444.class5444_2;
	}

	public Class5445 imethod_7()
	{
		if (class5678_0 != null)
		{
			return class5678_0.imethod_7();
		}
		return Class5445.class5445_0;
	}

	protected override Stack vmethod_27(Stack ranges, Class5727 currentRange)
	{
		Hashtable hashtable = method_58();
		if (hashtable != null)
		{
			foreach (Class5088 value in hashtable.Values)
			{
				if (value is Class5129)
				{
					ranges = ((Class5129)value).method_21(ranges);
				}
			}
		}
		Class5128 class2 = method_56();
		if (class2 != null)
		{
			ranges = class2.method_21(ranges);
		}
		return ranges;
	}

	public void method_66()
	{
		class5128_0 = null;
		hashtable_2.Clear();
	}
}
