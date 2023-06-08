using ns171;
using ns175;
using ns178;
using ns183;
using ns192;

namespace ns189;

internal abstract class Class5103 : Class5096
{
	private Class5634 class5634_0;

	private string string_3;

	public Class5103(Class5088 parent)
		: base(parent)
	{
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			method_11(loc, nsURI, localName);
		}
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		string_3 = pList.method_6(Enum679.const_294).vmethod_13();
		if (string.IsNullOrEmpty(string_3))
		{
			method_15("retrieve-class-name");
		}
		class5634_0 = pList.method_2();
	}

	private Class5634 method_50(Class5094 fo, Class5634 parenT)
	{
		return vmethod_4().method_1().imethod_0(fo, parenT);
	}

	private void method_51(Class5088 child, Class5088 newParent, Class5108 marker, Class5634 parentPropertyList)
	{
		if (child == null)
		{
			return;
		}
		Class5088 @class = child.vmethod_0(newParent, removeChildren: true);
		if (child is Class5094)
		{
			Class5634 class2 = method_50((Class5094)@class, parentPropertyList);
			Class5108.Class5636 attlist = marker.method_50(child);
			@class.vmethod_6(child.vmethod_21(), method_1(), attlist, class2);
			Class5094.smethod_10(@class, newParent);
			switch ((Enum679)@class.vmethod_24())
			{
			case Enum679.const_72:
			{
				Class5156 class4 = (Class5156)child;
				method_52(new Class5495(class4.method_57()), @class, marker, class2);
				method_51(class4.method_60(), @class, marker, class2);
				method_51(class4.method_61(), @class, marker, class2);
				method_52((Interface208)child.vmethod_15(), @class, marker, class2);
				break;
			}
			default:
				method_52((Interface208)child.vmethod_15(), @class, marker, class2);
				break;
			case Enum679.const_42:
			{
				Class5160 class3 = (Class5160)child;
				method_51(class3.method_53(), @class, marker, class2);
				method_51(class3.method_54(), @class, marker, class2);
				break;
			}
			}
		}
		else if (child is Class5172)
		{
			Class5172 class5 = (Class5172)@class;
			class5.vmethod_2(parentPropertyList);
			Class5094.smethod_10(@class, newParent);
		}
		else if (child is Class5089)
		{
			Class5094.smethod_10(@class, newParent);
		}
		@class.vmethod_14();
	}

	private void method_52(Interface208 parentIter, Class5088 newParent, Class5108 marker, Class5634 parentPropertyList)
	{
		if (parentIter != null)
		{
			while (parentIter.imethod_0())
			{
				Class5088 child = (Class5088)parentIter.imethod_1();
				method_51(child, newParent, marker, parentPropertyList);
			}
		}
	}

	private void method_53(Class5108 marker)
	{
		method_52((Interface208)marker.vmethod_15(), this, marker, class5634_0);
		Class5096.smethod_11(this, null);
	}

	public void method_54(Class5108 marker)
	{
		if (class5088_2 != null)
		{
			class5088_4 = null;
			class5088_2 = null;
		}
		if (marker.vmethod_15() != null)
		{
			try
			{
				method_53(marker);
			}
			catch (Exception53 fe)
			{
				method_5().imethod_15(this, marker.method_51(), fe, method_1());
			}
		}
	}

	public string method_55()
	{
		return string_3;
	}
}
