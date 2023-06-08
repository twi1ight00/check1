using ns284;
using ns305;
using ns306;

namespace ns287;

internal class Class7040 : Class6983
{
	public int RowIndex
	{
		get
		{
			Class6993 @class = method_49<Class6993>();
			if (@class != null)
			{
				return method_51(@class.Rows);
			}
			return -1;
		}
	}

	public int SectionRowIndex
	{
		get
		{
			Class7041 @class = method_49<Class7041>();
			if (@class != null)
			{
				return method_51(@class.Rows);
			}
			return -1;
		}
	}

	public Class7082 Cells => new Class7082(this);

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

	public string Ch
	{
		get
		{
			return method_45("char", string.Empty);
		}
		set
		{
			method_21("char", value);
		}
	}

	public string ChOff
	{
		get
		{
			return method_45("charoff", string.Empty);
		}
		set
		{
			method_21("charoff", value);
		}
	}

	public string VAlign
	{
		get
		{
			return method_45("valign", string.Empty);
		}
		set
		{
			method_21("valign", value);
		}
	}

	protected internal Class7040(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public Class6982 method_53(int index)
	{
		Class7082 cells = Cells;
		if (index < -1 || index > cells.Length)
		{
			Exception73.smethod_0(Enum968.const_0);
		}
		Class6982 newChild = base.OwnerDocument.CreateElement("TD") as Class6982;
		if (index != -1 && index != cells.Length)
		{
			return method_0(newChild, cells[index]) as Class6982;
		}
		return vmethod_1(newChild) as Class6982;
	}

	public void method_54(int index)
	{
		Class7082 cells = Cells;
		if (index < -1 || index >= cells.Length)
		{
			Exception73.smethod_0(Enum968.const_0);
		}
		Class6983 @class = ((index != -1) ? cells[index] : cells[cells.Length - 1]) as Class6983;
		Class6983 parentElement = @class.ParentElement;
		parentElement.method_2(@class);
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_30(this);
		method_48(visitor);
		visitor.imethod_31(this);
	}
}
