using ns284;
using ns305;

namespace ns287;

internal class Class7015 : Class6983
{
	public string Version
	{
		get
		{
			return method_45("version", string.Empty);
		}
		set
		{
			method_21("version", value);
		}
	}

	protected internal Class7015(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_9(this);
		Class7047 @class = (Class7047)base.OwnerDocument;
		foreach (Class6999 item in method_47("BASE"))
		{
			item.vmethod_5(visitor);
		}
		if (@class.Body != null)
		{
			@class.Body.vmethod_5(visitor);
		}
		else if (@class.FrameSet != null)
		{
			@class.FrameSet.vmethod_5(visitor);
		}
		visitor.imethod_10(this);
	}
}
