using System.Collections;
using ns284;

namespace ns290;

internal class Class6856 : Class6855
{
	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	public bool IsNewLine
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool IsTab
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public bool IsBr
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public Class6856(Class6844 parent)
		: base(parent)
	{
		Style.Display = Enum952.const_0;
	}

	public override void vmethod_0(Interface332 visitor, bool boxType, ref Hashtable pageSet)
	{
	}

	public override object Clone()
	{
		Class6856 @class = new Class6856(base.Parent);
		@class.IsNewLine = IsNewLine;
		@class.IsSpaceBox = base.IsSpaceBox;
		@class.IsTab = IsTab;
		@class.WordUndecoded = base.WordUndecoded;
		@class.Size = base.Size;
		@class.Style = Style;
		return @class;
	}
}
