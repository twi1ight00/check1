using ns33;

namespace Aspose.Slides;

public sealed class PortionFormat : BasePortionFormat, IBasePortionFormat, IHyperlinkContainer, IPortionFormat
{
	private string string_2;

	private Hyperlink hyperlink_0;

	private Hyperlink hyperlink_1;

	private readonly IHyperlinkManager ihyperlinkManager_0;

	public string BookmarkId
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
			method_5();
		}
	}

	public IHyperlink HyperlinkClick
	{
		get
		{
			return hyperlink_0;
		}
		set
		{
			hyperlink_0 = (Hyperlink)value;
			method_5();
		}
	}

	public IHyperlink HyperlinkMouseOver
	{
		get
		{
			return hyperlink_1;
		}
		set
		{
			hyperlink_1 = (Hyperlink)value;
			method_5();
		}
	}

	public IHyperlinkManager HyperlinkManager => ihyperlinkManager_0;

	public bool SmartTagClean
	{
		get
		{
			return (base.Attributes & 0x80000) != 0;
		}
		set
		{
			if (value)
			{
				base.Attributes |= 524288;
			}
			else
			{
				base.Attributes &= -524289;
			}
			method_5();
		}
	}

	public IBasePortionFormat AsIBasePortionFormat => this;

	IHyperlinkContainer IPortionFormat.AsIHyperlinkContainer => this;

	internal PortionFormat(Portion parentPortion)
		: base(parentPortion)
	{
		ihyperlinkManager_0 = new HyperlinkManager(this);
	}

	internal PortionFormat(PortionFormat props)
		: base(props.Parent)
	{
		ihyperlinkManager_0 = new HyperlinkManager(this);
		base.ParentParagraphFormat = props.ParentParagraphFormat;
		vmethod_1(props);
	}

	internal PortionFormat(ParagraphFormat parentParagraphFormat)
		: base(parentParagraphFormat?.ipresentationComponent_0)
	{
		ihyperlinkManager_0 = new HyperlinkManager(this);
		base.ParentParagraphFormat = parentParagraphFormat;
	}

	public override bool Equals(object obj)
	{
		if (obj is PortionFormat portionFormat)
		{
			if (!base.Equals(obj) || BookmarkId != portionFormat.BookmarkId || !Class1165.smethod_2(HyperlinkClick, portionFormat.HyperlinkClick) || !Class1165.smethod_2(HyperlinkMouseOver, portionFormat.HyperlinkMouseOver))
			{
				return false;
			}
		}
		else if (obj is BasePortionFormat obj2)
		{
			return base.Equals((object)obj2);
		}
		return true;
	}
}
