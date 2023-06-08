using System;
using System.IO;
using ns172;
using ns175;
using ns178;
using ns183;
using ns190;
using ns195;

namespace ns171;

internal class Class4931 : Class4927
{
	private class Class5601 : Interface219
	{
		public Class5634 imethod_0(Class5094 fobj, Class5634 parentPropertyList)
		{
			return new Class5635(fobj, parentPropertyList);
		}
	}

	internal class Class4932 : Class4927
	{
		protected Class5088 class5088_0;

		protected Class5634 class5634_0;

		private int int_0;

		private Class4931 class4931_0;

		internal Class4932(Class4931 owner)
		{
			class4931_0 = owner;
		}

		public override void imethod_6(string namespaceURI, string localName, string rawName, Interface236 attlist)
		{
			Class5634 @class = null;
			if (class4931_0.class5170_0 == null)
			{
				class4931_0.bool_1 = false;
				if (!namespaceURI.Equals("http://www.w3.org/1999/XSL/Format") || !localName.Equals("root"))
				{
					Interface191 @interface = Class5455.smethod_0(class4931_0.class5738_0.method_48());
					@interface.imethod_23(this, Class5088.smethod_2(namespaceURI, localName), class4931_0.method_1());
				}
			}
			else if (class5088_0.vmethod_23().Equals("http://www.w3.org/1999/XSL/Format") || class5088_0.vmethod_23().Equals("http://xmlgraphics.apache.org/fop/extensions"))
			{
				class5088_0.vmethod_8(class4931_0.interface243_0, namespaceURI, localName);
			}
			Class5180.Class5185 class2 = method_0(namespaceURI, localName);
			Class5088 class3 = class2.vmethod_0(class5088_0);
			if (class4931_0.class5170_0 == null)
			{
				class4931_0.class5170_0 = (Class5170)class3;
				class4931_0.class5170_0.method_51(class4931_0.class5737_0);
				class4931_0.class5170_0.method_50(class4931_0.class4866_0);
			}
			@class = class3.vmethod_7(class5634_0, class4931_0.class4866_0);
			class3.vmethod_6(localName, class4931_0.method_1(), attlist, @class);
			if (class3.vmethod_24() == 44)
			{
				if (class4931_0.class5737_0.method_5())
				{
					int_0++;
				}
				else
				{
					class4931_0.class5737_0.method_4(inMarker: true);
				}
			}
			if (class3.vmethod_24() == 53)
			{
				class4931_0.class5737_0.method_3().method_1();
			}
			Interface220 interface2 = class3.vmethod_25();
			if (interface2 != null)
			{
				Interface153 interface3 = interface2.imethod_1();
				if (interface3 is Interface221 && class3 is Interface169)
				{
					((Interface221)interface3).imethod_1((Interface169)class3);
				}
				interface3.imethod_1();
				interface3.imethod_6(namespaceURI, localName, rawName, attlist);
				class4931_0.int_0 = 1;
				class4931_0.interface153_0 = interface3;
			}
			if (class5088_0 != null)
			{
				class5088_0.vmethod_12(class3);
			}
			class5088_0 = class3;
			if (@class != null && !class4931_0.class5737_0.method_5())
			{
				class5634_0 = @class;
			}
			if (class5088_0.vmethod_24() != 10)
			{
				class5088_0.vmethod_10();
			}
		}

		public override void imethod_7(string uri, string localName, string rawName)
		{
			if (class5088_0 == null)
			{
				throw new Exception51("endElement() called for " + rawName + " where there is no current element.");
			}
			if (class5088_0.vmethod_21().Equals(localName) && class5088_0.vmethod_23().Equals(uri))
			{
				if (class5088_0.vmethod_24() != 10)
				{
					class5088_0.vmethod_11();
				}
				if (class5634_0 != null && class5634_0.method_0() == class5088_0 && !class4931_0.class5737_0.method_5())
				{
					class5634_0 = class5634_0.method_2();
				}
				if (class5088_0.vmethod_24() == 44)
				{
					if (int_0 == 0)
					{
						class4931_0.class5737_0.method_4(inMarker: false);
					}
					else
					{
						int_0--;
					}
				}
				class5088_0.method_4();
				class5088_0 = class5088_0.method_4();
				return;
			}
			throw new Exception51("Mismatch: " + class5088_0.vmethod_21() + " (" + class5088_0.vmethod_23() + ") vs. " + localName + " (" + uri + ")");
		}

		public override void imethod_8(char[] data, int start, int length)
		{
			if (class5088_0 != null)
			{
				class5088_0.vmethod_9(data, start, length, class5634_0, class4931_0.method_1());
			}
		}

		public override void imethod_2()
		{
			class5088_0 = null;
		}

		private Class5180.Class5185 method_0(string namespaceURI, string localName)
		{
			Class5180.Class5185 @class = class4931_0.class5599_0.method_2(namespaceURI, localName, class4931_0.interface243_0);
			if (@class is Class5092.Class5190)
			{
				Interface191 @interface = Class5455.smethod_0(class4931_0.class5738_0.method_48());
				string elementName = ((class5088_0 != null) ? class5088_0.method_17() : ("{" + namespaceURI + "}" + localName));
				@interface.imethod_25(this, elementName, new Class5619(namespaceURI, localName), class4931_0.method_1());
			}
			return @class;
		}
	}

	protected Class5599 class5599_0;

	protected Class5170 class5170_0;

	protected Class4932 class4932_0;

	protected Interface153 interface153_0;

	private Class5737 class5737_0;

	private Class4866 class4866_0;

	private Interface243 interface243_0;

	private Class5738 class5738_0;

	private bool bool_0;

	private bool bool_1 = true;

	private int int_0;

	internal void method_0(string srcDir)
	{
		if (class5738_0 != null)
		{
			class5738_0.SrcDir = srcDir;
		}
	}

	public Class4931(string outputFormat, Class5738 foUserAgent, Stream stream)
	{
		class5738_0 = foUserAgent;
		class5599_0 = class5738_0.method_0().method_13();
		class4866_0 = foUserAgent.method_44().method_14(foUserAgent, outputFormat, stream);
		if (class5738_0.method_54())
		{
			class4866_0 = new Class4870(foUserAgent.method_56(), class4866_0);
		}
		class5737_0 = new Class5737();
		class5737_0.method_2(new Class5601());
	}

	public override void imethod_0(Interface243 locatoR)
	{
		interface243_0 = locatoR;
	}

	protected Interface243 method_1()
	{
		if (!class5738_0.method_47())
		{
			return null;
		}
		return interface243_0;
	}

	public override void imethod_8(char[] data, int start, int length)
	{
		interface153_0.imethod_8(data, start, length);
	}

	public override void imethod_1()
	{
		if (bool_0)
		{
			throw new InvalidOperationException("FOTreeBuilder (and the Fop class) cannot be reused. Please instantiate a new instance.");
		}
		bool_0 = true;
		bool_1 = true;
		class5170_0 = null;
		class4866_0.vmethod_2();
		class4932_0 = new Class4932(this);
		class4932_0.imethod_1();
		interface153_0 = class4932_0;
	}

	public override void imethod_2()
	{
		interface153_0.imethod_2();
		if (class5170_0 == null && bool_1)
		{
			Interface191 @interface = Class5455.smethod_0(class5738_0.method_48());
			@interface.imethod_24(this);
		}
		class5170_0 = null;
		class4866_0.vmethod_3();
	}

	public override void imethod_6(string namespaceURI, string localName, string rawName, Interface236 attlist)
	{
		int_0++;
		interface153_0.imethod_6(namespaceURI, localName, rawName, attlist);
	}

	public override void imethod_7(string uri, string localName, string rawName)
	{
		interface153_0.imethod_7(uri, localName, rawName);
		int_0--;
		if (int_0 == 0 && interface153_0 != class4932_0)
		{
			interface153_0.imethod_2();
			interface153_0 = class4932_0;
			interface153_0.imethod_7(uri, localName, rawName);
		}
	}

	public override void imethod_11(Exception56 e)
	{
	}

	public override void imethod_12(Exception56 e)
	{
	}

	public override void imethod_13(Exception56 e)
	{
		throw e;
	}

	public Class4866 method_2()
	{
		return class4866_0;
	}

	public Class5493 method_3()
	{
		return method_2().vmethod_66();
	}
}
