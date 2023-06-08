using System;
using System.Collections;
using System.Text;
using ns178;
using ns183;
using ns187;
using ns189;
using ns191;
using ns195;

namespace ns171;

internal abstract class Class5094 : Class5088
{
	internal class Class5620 : Interface163, Interface168, Interface208
	{
		private const int int_0 = 0;

		private const int int_1 = 1;

		private const int int_2 = 2;

		private Class5088 class5088_0;

		private Class5094 class5094_0;

		private int int_3;

		private int int_4;

		internal Class5620(Class5094 parent)
		{
			class5094_0 = parent;
			class5088_0 = parent.class5088_2;
			int_3 = 0;
			int_4 = 0;
		}

		public Class5094 imethod_9()
		{
			return class5094_0;
		}

		public object imethod_1()
		{
			if (class5088_0 != null)
			{
				if (int_3 != 0)
				{
					if (class5088_0.class5088_1 == null || class5088_0.class5088_1[1] == null)
					{
						throw new Exception("Element was not found");
					}
					class5088_0 = class5088_0.class5088_1[1];
				}
				int_3++;
				int_4 |= 3;
				return class5088_0;
			}
			throw new Exception("Element was not found");
		}

		public object imethod_3()
		{
			if (class5088_0.class5088_1 == null || class5088_0.class5088_1[0] == null)
			{
				throw new Exception("Element was not found");
			}
			int_3--;
			class5088_0 = class5088_0.class5088_1[0];
			int_4 |= 3;
			return class5088_0;
		}

		public void imethod_7(object o)
		{
			if ((int_4 & 1) == 1)
			{
				Class5088 @class = (Class5088)o;
				if (class5088_0 == class5094_0.class5088_2)
				{
					class5094_0.class5088_2 = @class;
				}
				else
				{
					Class5088.smethod_7(class5088_0.class5088_1[0], @class);
				}
				if (class5088_0.class5088_1 != null && class5088_0.class5088_1[1] != null)
				{
					Class5088.smethod_7(@class, class5088_0.class5088_1[1]);
				}
				if (class5088_0 == class5094_0.class5088_3)
				{
					class5094_0.class5088_3 = @class;
				}
				return;
			}
			throw new InvalidOperationException();
		}

		public void imethod_8(object o)
		{
			Class5088 @class = (Class5088)o;
			if (int_3 == -1)
			{
				if (class5088_0 != null)
				{
					Class5088.smethod_7(@class, class5088_0);
				}
				class5094_0.class5088_2 = @class;
				int_3 = 0;
				class5088_0 = @class;
				if (class5094_0.class5088_3 == null)
				{
					class5094_0.class5088_3 = @class;
				}
			}
			else
			{
				if (class5088_0.class5088_1 != null && class5088_0.class5088_1[1] != null)
				{
					Class5088.smethod_7((Class5088)o, class5088_0.class5088_1[1]);
				}
				Class5088.smethod_7(class5088_0, (Class5088)o);
				if (class5088_0 == class5094_0.class5088_3)
				{
					class5094_0.class5088_3 = @class;
				}
			}
			_ = int_4;
			int_4 = 0;
		}

		public bool imethod_0()
		{
			if (class5088_0 != null)
			{
				if (int_3 != 0)
				{
					if (class5088_0.class5088_1 != null)
					{
						return class5088_0.class5088_1[1] != null;
					}
					return false;
				}
				return true;
			}
			return false;
		}

		public bool imethod_2()
		{
			if (int_3 == 0)
			{
				if (class5088_0.class5088_1 != null)
				{
					return class5088_0.class5088_1[0] != null;
				}
				return false;
			}
			return true;
		}

		public int imethod_4()
		{
			return int_3 + 1;
		}

		public int imethod_5()
		{
			return int_3 - 1;
		}

		public void imethod_6()
		{
			if ((int_4 & 2) == 2)
			{
				class5094_0.vmethod_13(class5088_0);
				if (int_3 == 0)
				{
					class5088_0 = class5094_0.class5088_2;
				}
				else if (class5088_0.class5088_1 != null && class5088_0.class5088_1[0] != null)
				{
					class5088_0 = class5088_0.class5088_1[0];
					int_3--;
				}
				else
				{
					class5088_0 = null;
				}
				_ = int_4;
				int_4 = 0;
				return;
			}
			throw new InvalidOperationException();
		}

		public Class5088 imethod_13()
		{
			while (class5088_0 != null && class5088_0.class5088_1 != null && class5088_0.class5088_1[1] != null)
			{
				class5088_0 = class5088_0.class5088_1[1];
				int_3++;
			}
			return class5088_0;
		}

		public Class5088 imethod_12()
		{
			class5088_0 = class5094_0.class5088_2;
			int_3 = 0;
			return class5088_0;
		}

		public Class5088 imethod_10()
		{
			return (Class5088)imethod_1();
		}

		public Class5088 imethod_11()
		{
			return (Class5088)imethod_3();
		}
	}

	private static Class5052[] class5052_0;

	internal Class5088 class5088_2;

	protected Class5088 class5088_3;

	private ArrayList arrayList_0;

	private Hashtable hashtable_0;

	private bool bool_0;

	private Hashtable hashtable_1;

	private int int_0 = -1;

	private string string_2;

	static Class5094()
	{
		class5052_0 = Class5735.smethod_2();
	}

	public Class5094(Class5088 parent)
		: base(parent)
	{
		if (parent == null || !(parent is Class5094))
		{
			return;
		}
		if (((Class5094)parent).method_26())
		{
			bool_0 = true;
			return;
		}
		int num = vmethod_24();
		if (num == 15 || num == 24 || num == 25)
		{
			bool_0 = true;
		}
	}

	public override Class5088 vmethod_0(Class5088 parenT, bool removeChildren)
	{
		Class5094 @class = (Class5094)base.vmethod_0(parenT, removeChildren);
		if (removeChildren)
		{
			@class.class5088_2 = null;
		}
		return @class;
	}

	public static Class5052 smethod_9(int propId)
	{
		return class5052_0[propId];
	}

	public override void vmethod_6(string elementName, Interface243 locator, Interface236 attlist, Class5634 pList)
	{
		method_0(locator);
		pList.vmethod_3(attlist);
		if (!vmethod_5() || "marker".Equals(elementName))
		{
			vmethod_2(pList);
		}
	}

	internal override Class5634 vmethod_7(Class5634 parent, Class4866 foEventHandler)
	{
		return vmethod_4().method_1().imethod_0(this, parent);
	}

	public override void vmethod_2(Class5634 pList)
	{
		string_2 = pList.method_6(Enum679.const_209).vmethod_13();
	}

	internal override void vmethod_10()
	{
		if (string_2 != null)
		{
			method_25(string_2);
		}
	}

	private void method_25(string id)
	{
		if (!vmethod_5() && id.Length != 0)
		{
			Hashtable hashtable = vmethod_4().method_0();
			if (!hashtable.ContainsKey(id))
			{
				hashtable.Add(id, id);
			}
			else
			{
				method_5().imethod_5(this, method_17(), id, canRecover: true, interface243_0);
			}
		}
	}

	private bool method_26()
	{
		return bool_0;
	}

	internal override void vmethod_12(Class5088 child)
	{
		if (child.vmethod_24() == 44)
		{
			method_30((Class5108)child);
			return;
		}
		Interface239 @interface = child.method_19();
		if (@interface != null)
		{
			method_43(@interface);
		}
		else if (class5088_2 == null)
		{
			class5088_2 = child;
			class5088_3 = child;
		}
		else if (class5088_3 == null)
		{
			Class5088 @class = class5088_2;
			while (@class.class5088_1 != null && @class.class5088_1[1] != null)
			{
				@class = @class.class5088_1[1];
			}
			Class5088.smethod_7(@class, child);
		}
		else
		{
			Class5088.smethod_7(class5088_3, child);
			class5088_3 = child;
		}
	}

	protected static void smethod_10(Class5088 child, Class5088 parent)
	{
		parent.vmethod_12(child);
	}

	public override void vmethod_13(Class5088 child)
	{
		Class5088 @class = null;
		if (child.class5088_1 != null)
		{
			@class = child.class5088_1[1];
		}
		if (child == class5088_2)
		{
			class5088_2 = @class;
			if (class5088_2 != null)
			{
				class5088_2.class5088_1[0] = null;
			}
		}
		else
		{
			Class5088 class2 = child.class5088_1[0];
			class2.class5088_1[1] = @class;
			if (@class != null)
			{
				@class.class5088_1[0] = class2;
			}
		}
		if (child == class5088_3)
		{
			if (child.class5088_1 != null)
			{
				class5088_3 = child.class5088_1[0];
			}
			else
			{
				class5088_3 = null;
			}
		}
	}

	public Class5094 method_27()
	{
		Class5088 @class = class5088_0;
		while (@class != null && !(@class is Class5094))
		{
			@class = @class.class5088_0;
		}
		return (Class5094)@class;
	}

	public virtual bool vmethod_30()
	{
		return false;
	}

	public override Interface163 vmethod_15()
	{
		if (method_28())
		{
			return new Class5620(this);
		}
		return null;
	}

	public bool method_28()
	{
		return class5088_2 != null;
	}

	public override Interface163 vmethod_16(Class5088 childNode)
	{
		Interface163 @interface = vmethod_15();
		if (@interface != null)
		{
			if (class5088_2 == childNode)
			{
				return @interface;
			}
			while (@interface.imethod_0() && @interface.imethod_10().class5088_1[1] != childNode)
			{
			}
			if (@interface.imethod_0())
			{
				return @interface;
			}
			return null;
		}
		return null;
	}

	private void method_29(Class5088 node)
	{
	}

	protected void method_30(Class5108 marker)
	{
		string text = marker.method_51();
		if (class5088_2 != null)
		{
			Interface208 @interface = (Interface208)vmethod_15();
			while (@interface.imethod_0())
			{
				Class5088 @class = (Class5088)@interface.imethod_1();
				if (!(@class is Class5094) && (!(@class is Class5172) || !((Class5172)@class).method_26()))
				{
					if (@class is Class5172)
					{
						@interface.imethod_6();
						method_29(@class);
					}
					continue;
				}
				method_5().imethod_9(this, method_17(), text, interface243_0);
				return;
			}
		}
		if (hashtable_1 == null)
		{
			hashtable_1 = new Hashtable();
		}
		if (!hashtable_1.ContainsKey(text))
		{
			hashtable_1.Add(text, marker);
		}
		else
		{
			method_5().imethod_10(this, method_17(), text, interface243_0);
		}
	}

	public bool method_31()
	{
		if (hashtable_1 != null)
		{
			return hashtable_1.Count != 0;
		}
		return false;
	}

	public Hashtable method_32()
	{
		return hashtable_1;
	}

	protected override string vmethod_18()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (vmethod_21() != null)
		{
			stringBuilder.Append(method_17());
			stringBuilder.Append(", ");
		}
		if (method_39())
		{
			stringBuilder.Append("id=").Append(vmethod_31());
			return stringBuilder.ToString();
		}
		string text = vmethod_19();
		if (text != null)
		{
			stringBuilder.Append("\"");
			if (text.Length < 32)
			{
				stringBuilder.Append(text);
			}
			else
			{
				stringBuilder.Append(Class5479.smethod_0(text, 0, 32));
				stringBuilder.Append("...");
			}
			stringBuilder.Append("\"");
			return stringBuilder.ToString();
		}
		return null;
	}

	internal override string vmethod_19()
	{
		if (method_1() != null)
		{
			return base.vmethod_19();
		}
		Interface168 @interface = vmethod_15();
		if (@interface == null)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		while (@interface.imethod_0())
		{
			Class5088 @class = (Class5088)@interface.imethod_1();
			string text = @class.vmethod_19();
			if (text != null)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append(text);
			}
		}
		if (stringBuilder.Length <= 0)
		{
			return null;
		}
		return stringBuilder.ToString();
	}

	protected bool method_33(string nsURI, string lName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			if (!"block".Equals(lName) && !"table".Equals(lName) && !"table-and-caption".Equals(lName) && !"block-container".Equals(lName) && !"list-block".Equals(lName) && !"float".Equals(lName))
			{
				return method_36(nsURI, lName);
			}
			return true;
		}
		return false;
	}

	protected bool method_34(string nsURI, string lName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			if (!"bidi-override".Equals(lName) && !"character".Equals(lName) && !"external-graphic".Equals(lName) && !"instream-foreign-object".Equals(lName) && !"inline".Equals(lName) && !"inline-container".Equals(lName) && !"leader".Equals(lName) && !"page-number".Equals(lName) && !"page-number-citation".Equals(lName) && !"page-number-citation-last".Equals(lName) && !"basic-link".Equals(lName) && (!"multi-toggle".Equals(lName) || (vmethod_24() != 45 && method_37(45) <= 0)) && (!"footnote".Equals(lName) || bool_0))
			{
				return method_36(nsURI, lName);
			}
			return true;
		}
		return false;
	}

	protected bool method_35(string nsURI, string lName)
	{
		if (!method_33(nsURI, lName))
		{
			return method_34(nsURI, lName);
		}
		return true;
	}

	protected bool method_36(string nsURI, string lName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			if (!"multi-switch".Equals(lName) && !"multi-properties".Equals(lName) && !"wrapper".Equals(lName) && (bool_0 || !"float".Equals(lName)) && !"retrieve-marker".Equals(lName))
			{
				return "retrieve-table-marker".Equals(lName);
			}
			return true;
		}
		return false;
	}

	protected int method_37(int ancestorID)
	{
		int num = 1;
		Class5088 @class = method_4();
		while (true)
		{
			if (@class != null)
			{
				if (@class.vmethod_24() == ancestorID)
				{
					break;
				}
				num++;
				@class = @class.method_4();
				continue;
			}
			return -1;
		}
		return num;
	}

	public void method_38()
	{
		class5088_2 = null;
	}

	public virtual string vmethod_31()
	{
		return string_2;
	}

	public bool method_39()
	{
		if (string_2 != null)
		{
			return string_2.Length > 0;
		}
		return false;
	}

	public override string vmethod_23()
	{
		return "http://www.w3.org/1999/XSL/Format";
	}

	public override string vmethod_22()
	{
		return "fo";
	}

	public override bool vmethod_28()
	{
		string nsURI = vmethod_23();
		string lName = vmethod_21();
		if (!method_36(nsURI, lName))
		{
			return method_33(nsURI, lName);
		}
		return false;
	}

	public void method_40(int bidiLevel)
	{
		if (bidiLevel < 0 || (int_0 >= 0 && bidiLevel >= int_0))
		{
			return;
		}
		int_0 = bidiLevel;
		if (class5088_0 != null)
		{
			Class5094 @class = (Class5094)class5088_0;
			int num = @class.method_41();
			if (num < 0 || bidiLevel < num)
			{
				@class.method_40(bidiLevel);
			}
		}
	}

	public int method_41()
	{
		return int_0;
	}

	public int method_42()
	{
		Class5088 @class = this;
		int num;
		while (true)
		{
			if (@class != null)
			{
				if (@class is Class5094)
				{
					num = ((Class5094)@class).method_41();
					if (num >= 0)
					{
						break;
					}
				}
				@class = @class.method_4();
				continue;
			}
			return -1;
		}
		return num;
	}

	private void method_43(Interface239 attachment)
	{
		if (attachment == null)
		{
			throw new NullReferenceException("Parameter attachment must not be null");
		}
		if (arrayList_0 == null)
		{
			arrayList_0 = new ArrayList();
		}
		arrayList_0.Add(attachment);
	}

	public ArrayList method_44()
	{
		if (arrayList_0 == null)
		{
			return new ArrayList();
		}
		return arrayList_0;
	}

	public bool method_45()
	{
		return arrayList_0 != null;
	}

	public void method_46(Class5619 attributeName, string value)
	{
		if (attributeName == null)
		{
			throw new NullReferenceException("Parameter attributeName must not be null");
		}
		if (hashtable_0 == null)
		{
			hashtable_0 = new Hashtable();
		}
		hashtable_0.Add(attributeName, value);
	}

	public Hashtable method_47()
	{
		if (hashtable_0 == null)
		{
			return new Hashtable();
		}
		return hashtable_0;
	}

	public override string ToString()
	{
		return base.ToString() + "[@id=" + string_2 + "]";
	}
}
