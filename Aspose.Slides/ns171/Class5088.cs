using System;
using System.Collections;
using System.Text;
using ns174;
using ns175;
using ns178;
using ns182;
using ns183;
using ns190;
using ns191;
using ns194;
using ns195;

namespace ns171;

internal abstract class Class5088
{
	internal class Class5173 : Class5174.Interface167
	{
		public object imethod_0(Hashtable @params)
		{
			object obj = @params["source"];
			if (obj is Class5634)
			{
				Class5634 @class = (Class5634)obj;
				obj = @class.method_0();
			}
			if (obj is Class5088)
			{
				Class5088 class2 = (Class5088)obj;
				return class2.vmethod_18();
			}
			return null;
		}

		public object imethod_1()
		{
			return "gatherContextInfo";
		}
	}

	internal interface Interface163 : Interface168
	{
		Class5094 imethod_9();

		Class5088 imethod_10();

		Class5088 imethod_11();

		Class5088 imethod_12();

		Class5088 imethod_13();
	}

	protected const string string_0 = "http://www.w3.org/1999/XSL/Format";

	protected const string string_1 = "http://xmlgraphics.apache.org/fop/extensions";

	internal Class5088 class5088_0;

	internal Class5088[] class5088_1;

	internal Interface243 interface243_0;

	protected Class5088(Class5088 parent)
	{
		class5088_0 = parent;
	}

	public virtual Class5088 vmethod_0(Class5088 cloneparent, bool removeChildren)
	{
		Class5088 @class = (Class5088)vmethod_1();
		@class.class5088_0 = cloneparent;
		@class.class5088_1 = null;
		return @class;
	}

	protected virtual object vmethod_1()
	{
		return MemberwiseClone();
	}

	public virtual void vmethod_2(Class5634 propertyList)
	{
	}

	public void method_0(Interface243 locatoR)
	{
		if (locatoR != null)
		{
			interface243_0 = new Class5745(locatoR);
		}
	}

	public Interface243 method_1()
	{
		return interface243_0;
	}

	public virtual Class4866 vmethod_3()
	{
		return class5088_0.vmethod_3();
	}

	public virtual Class5737 vmethod_4()
	{
		return class5088_0.vmethod_4();
	}

	protected virtual bool vmethod_5()
	{
		return vmethod_4().method_5();
	}

	public Class5738 method_2()
	{
		return vmethod_3().vmethod_0();
	}

	public virtual void vmethod_6(string elementName, Interface243 locator, Interface236 attlist, Class5634 pList)
	{
	}

	internal virtual Class5634 vmethod_7(Class5634 pList, Class4866 foEventHandler)
	{
		return null;
	}

	internal virtual void vmethod_8(Interface243 loc, string namespaceURI, string localName)
	{
	}

	internal static void smethod_0(Class5088 fo, Interface243 loc, string namespaceURI, string localName)
	{
		fo.vmethod_8(loc, namespaceURI, localName);
	}

	protected void method_3(char[] data, int start, int end, Class5634 pList, Interface243 locator)
	{
	}

	internal virtual void vmethod_9(char[] data, int start, int length, Class5634 pList, Interface243 locator)
	{
		method_3(data, start, start + length, pList, locator);
	}

	internal virtual void vmethod_10()
	{
	}

	internal virtual void vmethod_11()
	{
		vmethod_14();
	}

	internal virtual void vmethod_12(Class5088 child)
	{
	}

	public virtual void vmethod_13(Class5088 child)
	{
	}

	public virtual void vmethod_14()
	{
	}

	public Class5088 method_4()
	{
		return class5088_0;
	}

	public virtual Interface163 vmethod_15()
	{
		return null;
	}

	public virtual Interface163 vmethod_16(Class5088 childNode)
	{
		return null;
	}

	public virtual Class5656 vmethod_17()
	{
		return new Class5657('\0');
	}

	public static string smethod_1(string namespaceURI)
	{
		if (namespaceURI.Equals("http://www.w3.org/1999/XSL/Format"))
		{
			return "fo";
		}
		if (namespaceURI.Equals("http://xmlgraphics.apache.org/fop/extensions"))
		{
			return "fox";
		}
		if (namespaceURI.Equals(Class5182.string_2))
		{
			return "foi";
		}
		if (namespaceURI.Equals(Class5181.string_2))
		{
			return "svg";
		}
		return null;
	}

	public static string smethod_2(string namespaceURI, string localName)
	{
		string text = smethod_1(namespaceURI);
		if (text != null)
		{
			return text + ":" + localName;
		}
		return "(Namespace URI: \"" + namespaceURI + "\", Local Name: \"" + localName + "\")";
	}

	internal Interface191 method_5()
	{
		return Class5455.smethod_0(method_2().method_48());
	}

	protected void method_6(Interface243 loc, string nsURI, string lName)
	{
		method_7(loc, new Class5619(nsURI, lName));
	}

	protected void method_7(Interface243 loc, Class5619 offendingNode)
	{
		method_5().imethod_0(this, method_17(), offendingNode, loc);
	}

	protected void method_8(Interface243 loc, string offendingNode)
	{
		method_7(loc, new Class5619("http://www.w3.org/1999/XSL/Format", offendingNode));
	}

	protected void method_9(Interface243 loc, string tooLateNode, string tooEarlyNode)
	{
		method_10(loc, tooLateNode, tooEarlyNode, canRecover: false);
	}

	protected void method_10(Interface243 loc, string tooLateNode, string tooEarlyNode, bool canRecover)
	{
		method_5().imethod_1(this, method_17(), tooLateNode, tooEarlyNode, canRecover, loc);
	}

	protected void method_11(Interface243 loc, string nsURI, string lName)
	{
		method_12(loc, method_17(), nsURI, lName, null);
	}

	protected void method_12(Interface243 loc, string parentName, string nsURI, string lName, string ruleViolated)
	{
		string text = smethod_1(nsURI);
		Class5619 offendingNode = ((text == null) ? new Class5619(nsURI, lName) : new Class5619(nsURI, text, lName));
		method_5().imethod_2(this, parentName, offendingNode, ruleViolated, loc);
	}

	protected void method_13(string contentModel)
	{
		method_5().imethod_3(this, method_17(), contentModel, canRecover: false, interface243_0);
	}

	protected void method_14(string contentModel, bool canRecover)
	{
		method_5().imethod_3(this, method_17(), contentModel, canRecover, interface243_0);
	}

	protected void method_15(string propertyName)
	{
		method_5().imethod_4(this, method_17(), propertyName, interface243_0);
	}

	internal static string smethod_3(Interface243 loc)
	{
		return "Error(" + smethod_5(loc) + "): ";
	}

	protected static string smethod_4(Interface243 loc)
	{
		return "Warning(" + smethod_5(loc) + "): ";
	}

	public static string smethod_5(Interface243 loc)
	{
		if (loc == null)
		{
			return "Unknown location";
		}
		return loc.imethod_0() + "/" + loc.imethod_1();
	}

	public static string smethod_6(string text, Class5088 node)
	{
		if (node != null)
		{
			StringBuilder stringBuilder = new StringBuilder(text);
			stringBuilder.Append(" (").Append(node.method_16()).Append(")");
			return stringBuilder.ToString();
		}
		return text;
	}

	public string method_16()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (vmethod_21() != null)
		{
			stringBuilder.Append(method_17());
			stringBuilder.Append(", ");
		}
		if (interface243_0 != null)
		{
			stringBuilder.Append("location: ");
			stringBuilder.Append(smethod_5(interface243_0));
		}
		else
		{
			string text = vmethod_19();
			if (text != null)
			{
				stringBuilder.Append("\"");
				stringBuilder.Append(text);
				stringBuilder.Append("\"");
			}
			else
			{
				stringBuilder.Append("no context info available");
			}
		}
		if (stringBuilder.Length > 80)
		{
			stringBuilder.Length = 80;
		}
		return stringBuilder.ToString();
	}

	protected virtual string vmethod_18()
	{
		string text = vmethod_19();
		if (text != null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (vmethod_21() != null)
			{
				stringBuilder.Append(method_17());
				stringBuilder.Append(", ");
			}
			stringBuilder.Append("\"");
			stringBuilder.Append(text);
			stringBuilder.Append("\"");
			return stringBuilder.ToString();
		}
		return null;
	}

	internal virtual string vmethod_19()
	{
		return null;
	}

	public virtual Class5170 vmethod_20()
	{
		return class5088_0.vmethod_20();
	}

	public string method_17()
	{
		return method_18(vmethod_22());
	}

	public string method_18(string prefix)
	{
		if (prefix != null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(prefix).Append(':').Append(vmethod_21());
			return stringBuilder.ToString();
		}
		return vmethod_21();
	}

	public abstract string vmethod_21();

	public abstract string vmethod_22();

	public virtual string vmethod_23()
	{
		return null;
	}

	public virtual int vmethod_24()
	{
		return 0;
	}

	public Interface239 method_19()
	{
		return null;
	}

	public virtual Interface220 vmethod_25()
	{
		return null;
	}

	protected bool method_20()
	{
		switch ((Enum679)vmethod_24())
		{
		default:
			return false;
		case Enum679.const_2:
		case Enum679.const_3:
		case Enum679.const_4:
		case Enum679.const_5:
		case Enum679.const_17:
		case Enum679.const_36:
		case Enum679.const_37:
		case Enum679.const_41:
		case Enum679.const_42:
		case Enum679.const_43:
		case Enum679.const_44:
		case Enum679.const_72:
		case Enum679.const_73:
		case Enum679.const_74:
		case Enum679.const_75:
		case Enum679.const_76:
		case Enum679.const_78:
		case Enum679.const_79:
		case Enum679.const_82:
			return true;
		}
	}

	protected static void smethod_7(Class5088 precedingSibling, Class5088 followingSibling)
	{
		if (precedingSibling.class5088_1 == null)
		{
			precedingSibling.class5088_1 = new Class5088[2];
		}
		if (followingSibling.class5088_1 == null)
		{
			followingSibling.class5088_1 = new Class5088[2];
		}
		precedingSibling.class5088_1[1] = followingSibling;
		followingSibling.class5088_1[0] = precedingSibling;
	}

	public virtual bool vmethod_26(int boundary)
	{
		return true;
	}

	public Stack method_21(Stack ranges)
	{
		if (method_23())
		{
			method_22(ranges);
		}
		Class5727 currentRange = ((ranges.Count <= 0) ? null : ((Class5727)ranges.Peek()));
		ranges = vmethod_27(ranges, currentRange);
		if (method_24())
		{
			method_22(ranges);
		}
		return ranges;
	}

	protected virtual Stack vmethod_27(Stack ranges, Class5727 currentRange)
	{
		Interface208 @interface = (Interface208)vmethod_15();
		while (@interface != null && @interface.imethod_0())
		{
			ranges = ((Class5088)@interface.imethod_1()).method_21(ranges);
		}
		return ranges;
	}

	public virtual bool vmethod_28()
	{
		return false;
	}

	private Class5727 method_22(Stack ranges)
	{
		Class5727 @class = null;
		Class5727 class2 = null;
		if (ranges.Count == 0)
		{
			if (vmethod_28())
			{
				class2 = new Class5727(this);
			}
		}
		else
		{
			@class = (Class5727)ranges.Peek();
			if (@class != null && (!@class.method_3() || !smethod_8(@class.method_0(), this)))
			{
				class2 = new Class5727(this);
			}
		}
		if (class2 != null)
		{
			ranges.Push(class2);
		}
		else
		{
			class2 = @class;
		}
		return class2;
	}

	private bool method_23()
	{
		return vmethod_26(13);
	}

	private bool method_24()
	{
		return vmethod_26(3);
	}

	private static bool smethod_8(Class5088 n1, Class5088 n2)
	{
		Class5088 @class = n2;
		while (true)
		{
			if (@class != null)
			{
				if (@class == n1)
				{
					break;
				}
				@class = @class.method_4();
				continue;
			}
			return false;
		}
		return true;
	}

	public virtual void vmethod_29(Interface244 structureTreeElement)
	{
		throw new NotSupportedException();
	}
}
