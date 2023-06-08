using System.Collections;
using System.Text;
using ns171;
using ns178;
using ns187;

namespace ns189;

internal class Class5108 : Class5096
{
	internal class Class5636 : Class5634, Interface236
	{
		private Class5689[] class5689_0;

		public Class5636(Class5094 fobj, Class5634 parentPropertyList)
			: base(fobj, null)
		{
		}

		public override void vmethod_3(Interface236 attributes)
		{
			class5689_0 = new Class5689[attributes.imethod_0()];
			int num = attributes.imethod_0();
			while (--num >= 0)
			{
				string @namespace = attributes.imethod_3(num);
				string qname = attributes.imethod_1(num);
				string name = attributes.imethod_2(num);
				string value = attributes.imethod_4(num);
				class5689_0[num] = Class5689.smethod_0(@namespace, qname, name, value);
			}
		}

		public override void vmethod_1(int propId, Class5024 value)
		{
		}

		public override Class5024 vmethod_0(int propId)
		{
			return null;
		}

		public int imethod_0()
		{
			if (class5689_0 == null)
			{
				return 0;
			}
			return class5689_0.Length;
		}

		public string imethod_3(int index)
		{
			if (class5689_0 != null && index < class5689_0.Length && index >= 0 && class5689_0[index] != null)
			{
				return class5689_0[index].string_0;
			}
			return null;
		}

		public string imethod_2(int index)
		{
			if (class5689_0 != null && index < class5689_0.Length && index >= 0 && class5689_0[index] != null)
			{
				return class5689_0[index].string_2;
			}
			return null;
		}

		public string imethod_1(int index)
		{
			if (class5689_0 != null && index < class5689_0.Length && index >= 0 && class5689_0[index] != null)
			{
				return class5689_0[index].string_1;
			}
			return null;
		}

		public string method_28(int index)
		{
			return "CDATA";
		}

		public string imethod_4(int index)
		{
			if (class5689_0 != null && index < class5689_0.Length && index >= 0 && class5689_0[index] != null)
			{
				return class5689_0[index].string_3;
			}
			return null;
		}

		public int method_29(string name, string @namespace)
		{
			int result = -1;
			if (class5689_0 != null && name != null && @namespace != null)
			{
				int num = class5689_0.Length;
				while (--num >= 0 && (class5689_0[num] == null || !@namespace.Equals(class5689_0[num].string_0) || !name.Equals(class5689_0[num].string_2)))
				{
				}
			}
			return result;
		}

		public int method_30(string qname)
		{
			int result = -1;
			if (class5689_0 != null && qname != null)
			{
				int num = class5689_0.Length;
				while (--num >= 0 && (class5689_0[num] == null || !qname.Equals(class5689_0[num].string_1)))
				{
				}
			}
			return result;
		}

		public string method_31(string name, string @namespace)
		{
			return "CDATA";
		}

		public string method_32(string qname)
		{
			return "CDATA";
		}

		public string method_33(string name, string @namespace)
		{
			int num = method_29(name, @namespace);
			if (num > 0)
			{
				return imethod_4(num);
			}
			return null;
		}

		public string imethod_5(string qname)
		{
			int num = method_30(qname);
			if (num > 0)
			{
				return imethod_4(num);
			}
			return null;
		}
	}

	internal class Class5688 : Interface219
	{
		private Class5108 class5108_0;

		internal Class5688(Class5108 marker)
		{
			class5108_0 = marker;
		}

		public Class5634 imethod_0(Class5094 fobj, Class5634 parentPropertyList)
		{
			Class5634 @class = new Class5636(fobj, parentPropertyList);
			class5108_0.hashtable_2.Add(fobj, @class);
			return @class;
		}
	}

	internal class Class5689
	{
		private static Class5749 class5749_0 = new Class5749();

		internal string string_0;

		internal string string_1;

		internal string string_2;

		internal string string_3;

		private Class5689(string @namespace, string qname, string name, string value)
		{
			string_0 = @namespace;
			string_1 = qname;
			string_2 = ((name == null) ? qname : name);
			string_3 = value;
		}

		internal static Class5689 smethod_0(string @namespace, string qname, string name, string value)
		{
			return (Class5689)class5749_0.method_0(new Class5689(@namespace, qname, name, value));
		}

		public override int GetHashCode()
		{
			int num = 17;
			num = 629 + ((string_0 != null) ? string_0.GetHashCode() : 0);
			num = 37 * num + ((string_1 != null) ? string_1.GetHashCode() : 0);
			num = 37 * num + ((string_2 != null) ? string_2.GetHashCode() : 0);
			return 37 * num + ((string_3 != null) ? string_3.GetHashCode() : 0);
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			if (obj is Class5689)
			{
				Class5689 @class = (Class5689)obj;
				if ((!(@class.string_0 == string_0) && (@class.string_0 == null || !@class.string_0.Equals(string_0))) || (!(@class.string_1 == string_1) && (@class.string_1 == null || !@class.string_1.Equals(string_1))) || (!(@class.string_2 == string_2) && (@class.string_2 == null || !@class.string_2.Equals(string_2))))
				{
					return false;
				}
				if (!(@class.string_3 == string_3))
				{
					if (@class.string_3 != null)
					{
						return @class.string_3.Equals(string_3);
					}
					return false;
				}
				return true;
			}
			return false;
		}
	}

	private string string_3;

	private Interface219 interface219_0;

	private Hashtable hashtable_2 = new Hashtable();

	public Class5108(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		if (method_37(16) < 0)
		{
			method_12(interface243_0, method_4().method_17(), "http://www.w3.org/1999/XSL/Format", vmethod_21(), "rule.markerDescendantOfFlow");
		}
		string_3 = pList.method_6(Enum679.const_239).vmethod_13();
		if (string.IsNullOrEmpty(string_3))
		{
			method_15("marker-class-name");
		}
	}

	internal Class5636 method_50(Class5088 foNode)
	{
		return (Class5636)hashtable_2[foNode];
	}

	internal override void vmethod_10()
	{
		Class5737 @class = vmethod_4();
		interface219_0 = @class.method_1();
		@class.method_2(new Class5688(this));
	}

	internal override void vmethod_11()
	{
		base.vmethod_11();
		vmethod_4().method_2(interface219_0);
		interface219_0 = null;
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI) && !method_35(nsURI, localName))
		{
			method_11(loc, nsURI, localName);
		}
	}

	protected override bool vmethod_5()
	{
		return true;
	}

	public string method_51()
	{
		return string_3;
	}

	public override string vmethod_21()
	{
		return "marker";
	}

	public override int vmethod_24()
	{
		return 44;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(base.ToString());
		stringBuilder.Append(" {").Append(method_51()).Append("}");
		return stringBuilder.ToString();
	}
}
