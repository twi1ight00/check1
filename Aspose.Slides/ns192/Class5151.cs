using System.Collections;
using ns171;
using ns178;
using ns187;

namespace ns192;

internal abstract class Class5151 : Class5150
{
	private Class5703 class5703_0;

	protected bool bool_1;

	protected bool bool_2;

	private bool bool_3 = true;

	private bool bool_4;

	private bool bool_5 = true;

	private ArrayList arrayList_2 = new ArrayList();

	public Class5151(Class5088 parent)
		: base(parent)
	{
	}

	protected override object vmethod_1()
	{
		Class5151 @class = (Class5151)base.vmethod_1();
		@class.arrayList_2 = new ArrayList(arrayList_2);
		return @class;
	}

	public override void vmethod_2(Class5634 pList)
	{
		class5703_0 = pList.method_17();
		base.vmethod_2(pList);
	}

	public override void vmethod_6(string elementName, Interface243 locatoR, Interface236 attlist, Class5634 pList)
	{
		base.vmethod_6(elementName, locatoR, attlist, pList);
		if (vmethod_5())
		{
			return;
		}
		Class5156 @class = vmethod_32();
		if (@class.method_55())
		{
			int num = @class.method_59();
			arrayList_1 = new ArrayList(num);
			for (int i = 0; i < num; i++)
			{
				arrayList_1.Add(null);
			}
		}
		else
		{
			arrayList_1 = new ArrayList();
		}
		class5714_0 = new Class5714();
	}

	public override void vmethod_14()
	{
		if (!vmethod_5())
		{
			arrayList_1 = null;
			class5714_0 = null;
		}
		if (!bool_1 && !bool_2)
		{
			method_14("marker* (table-row+|table-cell+)", canRecover: true);
			method_4().vmethod_13(this);
		}
		else
		{
			method_53();
		}
	}

	internal override Class5151 vmethod_34()
	{
		return this;
	}

	protected void method_53()
	{
		if (!vmethod_5())
		{
			Class5627 @class = vmethod_32().method_77();
			if (bool_1)
			{
				@class.vmethod_2();
			}
			else if (!bool_5)
			{
				@class.vmethod_3(this);
			}
			try
			{
				@class.vmethod_5();
			}
			catch (Exception54 exception)
			{
				exception.method_0(interface243_0);
				throw exception;
			}
		}
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if (!"http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			return;
		}
		if (localName.Equals("marker"))
		{
			if (bool_1 || bool_2)
			{
				method_9(loc, "fo:marker", "(table-row+|table-cell+)");
			}
		}
		else if (localName.Equals("table-row"))
		{
			bool_1 = true;
			if (bool_2)
			{
				Interface245 @interface = Class5754.smethod_0(method_2().method_48());
				@interface.imethod_2(this, method_17(), method_1());
			}
		}
		else if (localName.Equals("table-cell"))
		{
			bool_2 = true;
			if (bool_1)
			{
				Interface245 interface2 = Class5754.smethod_0(method_2().method_48());
				interface2.imethod_2(this, method_17(), method_1());
			}
		}
		else
		{
			method_11(loc, nsURI, localName);
		}
	}

	internal override void vmethod_12(Class5088 child)
	{
		if (!vmethod_5())
		{
			switch ((Enum679)child.vmethod_24())
			{
			case Enum679.const_80:
				if (!bool_4)
				{
					vmethod_32().method_77().vmethod_4(this);
				}
				else
				{
					class5714_0.method_2(arrayList_1);
					vmethod_32().method_77().vmethod_2();
				}
				bool_4 = true;
				vmethod_32().method_77().vmethod_1((Class5155)child);
				break;
			case Enum679.const_76:
			{
				if (!bool_4)
				{
					vmethod_32().method_77().vmethod_4(this);
				}
				bool_4 = true;
				Class5157 @class = (Class5157)child;
				method_51(@class, bool_3);
				bool_5 = @class.method_59();
				if (bool_5)
				{
					bool_3 = false;
					class5714_0.method_2(arrayList_1);
					vmethod_32().method_77().vmethod_3(this);
				}
				break;
			}
			}
		}
		base.vmethod_12(child);
	}

	internal void method_54(ArrayList rowGroup)
	{
		arrayList_2.Add(rowGroup);
	}

	public ArrayList method_55()
	{
		return arrayList_2;
	}

	public override Class5703 vmethod_33()
	{
		return class5703_0;
	}

	public bool method_56(Class5155 obj)
	{
		if (class5088_2 != null)
		{
			return class5088_2 == obj;
		}
		return true;
	}

	internal void method_57()
	{
		if (bool_4)
		{
			bool_3 = false;
			if (!bool_5)
			{
				class5714_0.method_2(arrayList_1);
				vmethod_32().method_77().vmethod_3(this);
			}
		}
	}
}
