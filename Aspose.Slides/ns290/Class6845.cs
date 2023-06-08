using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace ns290;

internal class Class6845 : Class6844
{
	private const string string_1 = "{3}({2})[{4}]:{0}{1}";

	private IList<Class6844> ilist_0;

	private float float_3;

	private float float_4;

	public IList<Class6844> InnerBoxes
	{
		get
		{
			return ilist_0;
		}
		set
		{
			ilist_0 = value;
		}
	}

	public float MaxWidth
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	public float MinWidth
	{
		get
		{
			return float_4;
		}
		set
		{
			float_4 = value;
		}
	}

	public Class6845(Class6844 parent)
		: base(parent)
	{
		ilist_0 = new List<Class6844>();
	}

	public override void vmethod_0(Interface332 visitor, bool boxType, ref Hashtable pageSet)
	{
		visitor.imethod_0(this, boxType, ref pageSet);
		for (int i = 0; i < InnerBoxes.Count; i++)
		{
			Class6844 @class = InnerBoxes[i];
			@class.vmethod_0(visitor, boxType, ref pageSet);
		}
		visitor.imethod_1(this, boxType, ref pageSet);
	}

	public override object Clone()
	{
		Class6845 @class = new Class6845(base.Parent);
		@class.Tag = base.Tag;
		@class.Style = Style;
		@class.float_1 = float_1;
		@class.float_0 = float_0;
		@class.float_2 = float_2;
		@class.Link = base.Link;
		return @class;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "{3}({2})[{4}]:{0}{1}", OuterBound.Location, OuterBound.Size, Style.Display, base.Tag, InnerBoxes.Count);
	}
}
