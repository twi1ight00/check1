using ns284;
using ns305;
using ns306;

namespace ns287;

internal class Class7041 : Class6983
{
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

	public Class7078 Rows => new Class7079(this, method_26("TR"));

	protected internal Class7041(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public Class6982 method_53(int index)
	{
		Class7078 rows = Rows;
		if (index < -1 || index > rows.Length)
		{
			Exception73.smethod_0(Enum968.const_0);
		}
		Class6982 newChild = base.OwnerDocument.CreateElement("TR") as Class6982;
		if (index != -1 && index != rows.Length)
		{
			return method_0(newChild, rows[index]) as Class6982;
		}
		return vmethod_1(newChild) as Class6982;
	}

	public void method_54(int index)
	{
		Class7078 rows = Rows;
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
		if (base.TagName == "TBODY")
		{
			visitor.imethod_36(this);
			method_48(visitor);
			visitor.imethod_37(this);
		}
		else if (base.TagName == "THEAD")
		{
			visitor.imethod_38(this);
			method_48(visitor);
			visitor.imethod_39(this);
		}
		else if (base.TagName == "TFOOT")
		{
			visitor.imethod_40(this);
			method_48(visitor);
			visitor.imethod_41(this);
		}
	}
}
