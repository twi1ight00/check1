using System.Collections.Generic;
using ns284;
using ns305;
using ns306;

namespace ns287;

internal class Class6993 : Class6983
{
	private Class7040 class7040_0;

	private Class7041 class7041_0;

	public Class7037 Caption
	{
		get
		{
			return method_50<Class7037>();
		}
		set
		{
		}
	}

	public Class7041 THead
	{
		get
		{
			return method_53("THEAD");
		}
		set
		{
		}
	}

	public Class7041 TFoot
	{
		get
		{
			return method_53("TFOOT");
		}
		set
		{
		}
	}

	public Class7083 Rows
	{
		get
		{
			return new Class7083(this, method_26("TR"));
		}
		set
		{
		}
	}

	internal Class7040 FirstRow
	{
		get
		{
			if (class7040_0 == null)
			{
				IEnumerator<Class6976> enumerator = Rows.GetEnumerator();
				if (enumerator.MoveNext())
				{
					class7040_0 = enumerator.Current as Class7040;
				}
			}
			return class7040_0;
		}
	}

	public Class7078 TBodies
	{
		get
		{
			return new Class7080(this, "TBODY");
		}
		set
		{
		}
	}

	internal Class7041 Body
	{
		get
		{
			if (class7041_0 == null)
			{
				Class7078 tBodies = TBodies;
				if (tBodies.Length != 0)
				{
					class7041_0 = tBodies[tBodies.Length - 1] as Class7041;
				}
			}
			return class7041_0;
		}
	}

	public string Align
	{
		get
		{
			return method_45("align", string.Empty);
		}
		set
		{
			method_21("align", value);
		}
	}

	public string BgColor
	{
		get
		{
			return method_45("bgcolor", string.Empty);
		}
		set
		{
			method_21("bgcolor", value);
		}
	}

	public string Border
	{
		get
		{
			return method_45("border", string.Empty);
		}
		set
		{
			method_21("border", value);
		}
	}

	public string CellPadding
	{
		get
		{
			return method_45("cellpadding", string.Empty);
		}
		set
		{
			method_21("cellpadding", value);
		}
	}

	public string CellSpacing
	{
		get
		{
			return method_45("cellspacing", string.Empty);
		}
		set
		{
			method_21("cellspacing", value);
		}
	}

	public string Frame
	{
		get
		{
			return method_45("frame", string.Empty);
		}
		set
		{
			method_21("frame", value);
		}
	}

	public string Rules
	{
		get
		{
			return method_45("rules", string.Empty);
		}
		set
		{
			method_21("rules", value);
		}
	}

	public string Summary
	{
		get
		{
			return method_45("summary", string.Empty);
		}
		set
		{
			method_21("summary", value);
		}
	}

	public string Width
	{
		get
		{
			return method_45("width", string.Empty);
		}
		set
		{
			method_21("width", value);
		}
	}

	protected internal Class6993(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	private Class7041 method_53(string sectionName)
	{
		Class7080 @class = new Class7080(this, sectionName);
		if (@class.Length > 0)
		{
			return @class[0] as Class7041;
		}
		return null;
	}

	public Class6982 method_54()
	{
		Class6982 tHead = THead;
		if (tHead != null)
		{
			return tHead;
		}
		Class6982 newChild = base.OwnerDocument.CreateElement("THEAD") as Class6982;
		Class6982 caption = Caption;
		if (caption != null)
		{
			return vmethod_0(newChild, caption) as Class6982;
		}
		return method_0(newChild, base.FirstElementChild) as Class6982;
	}

	public void method_55()
	{
		method_60(THead);
	}

	public Class6982 method_56()
	{
		return TFoot ?? (vmethod_1(base.OwnerDocument.CreateElement("TFOOT")) as Class6982);
	}

	public void method_57()
	{
		method_60(TFoot);
	}

	public Class6982 method_58()
	{
		return Caption ?? (method_0(base.OwnerDocument.CreateElement("CAPTION"), base.FirstElementChild) as Class6982);
	}

	public void method_59()
	{
		method_60(Caption);
	}

	private void method_60(Class6982 element)
	{
		if (element != null)
		{
			method_2(element);
		}
	}

	public Class6982 method_61(int index)
	{
		Class7083 rows = Rows;
		if (index < -1 || index > rows.Length)
		{
			Exception73.smethod_0(Enum968.const_0);
		}
		Class6983 @class = ((rows.Length <= index || index == -1) ? null : (rows[index] as Class6983));
		Class6983 class2 = @class?.method_49<Class7041>();
		Class7078 tBodies = TBodies;
		Class6983 newChild;
		if (tBodies.Length == 0)
		{
			Class6983 class3 = (Class6983)(((object)THead) ?? ((object)Caption));
			newChild = base.OwnerDocument.CreateElement("TBODY") as Class6983;
			newChild = ((class3 == null) ? (method_0(newChild, base.FirstElementChild) as Class6983) : (vmethod_0(newChild, class3) as Class6983));
		}
		else
		{
			newChild = class2 ?? (tBodies[tBodies.Length - 1] as Class6983);
		}
		Class6981 newChild2 = base.OwnerDocument.CreateElement("TR");
		if (class2 == newChild && index != -1)
		{
			return newChild.method_0(newChild2, @class) as Class6982;
		}
		return newChild.vmethod_1(newChild2) as Class6982;
	}

	public void method_62(int index)
	{
		Class7083 rows = Rows;
		if (index < -1 || index >= rows.Length)
		{
			Exception73.smethod_0(Enum968.const_0);
		}
		Class6983 @class = ((index != -1) ? rows[index] : rows[rows.Length - 1]) as Class6983;
		Class6983 parentElement = @class.ParentElement;
		parentElement.method_2(@class);
	}

	public override void vmethod_5(Interface325 visitor)
	{
		Interface325 @interface = visitor.imethod_28(this);
		foreach (Class7041 tBody in TBodies)
		{
			tBody.vmethod_5(@interface);
		}
		@interface.imethod_29(this);
	}
}
