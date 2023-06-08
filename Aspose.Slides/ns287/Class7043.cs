using ns284;
using ns305;
using ns84;

namespace ns287;

internal class Class7043 : Class6983
{
	public bool Compact
	{
		get
		{
			return method_34("compact");
		}
		set
		{
			method_52("compact", value);
		}
	}

	public string Type
	{
		get
		{
			return method_45("type", string.Empty);
		}
		set
		{
			method_21("type", value);
		}
	}

	protected internal Class7043(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		if (base.StyleDeclarationInternal.Position != Enum633.const_2 || base.StyleDeclarationInternal.Left.Value.Value != -9999f)
		{
			if (base.StyleDeclarationInternal.Display.Value != 0 && method_53())
			{
				visitor.imethod_20(this);
				method_48(visitor);
				visitor.imethod_21(this);
			}
			else
			{
				visitor.imethod_11(this);
				method_48(visitor);
				visitor.imethod_12(this);
			}
		}
	}

	private bool method_53()
	{
		Class6976 @class = base.FirstChild;
		while (true)
		{
			if (@class != null)
			{
				if (@class is Class6983 class2 && class2.StyleDeclarationInternal.Display.Value == Enum630.const_2 && class2.StyleDeclarationInternal.Float == Enum627.const_2)
				{
					break;
				}
				@class = @class.NextSibling;
				continue;
			}
			return false;
		}
		return true;
	}
}
