using System.Collections;
using System.Globalization;
using ns301;

namespace ns290;

internal class Class6855 : Class6844
{
	private const string string_1 = "{0}[{1}]";

	private const string string_2 = "WordBox";

	private bool bool_0;

	private string string_3;

	private bool bool_1;

	public bool IsSpaceBox
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public string WordUndecoded
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public string WordDecoded
	{
		get
		{
			string s = string_3;
			return Class6968.smethod_0(s);
		}
		set
		{
			string_3 = value;
		}
	}

	public bool IsUnicode
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public Class6855(Class6844 parent)
		: base(parent)
	{
		base.Tag = "WordBox";
	}

	public override void vmethod_0(Interface332 visitor, bool boxType, ref Hashtable pageSet)
	{
		visitor.imethod_2(this, boxType, ref pageSet);
	}

	public override object Clone()
	{
		Class6855 @class = new Class6855(base.Parent);
		@class.WordUndecoded = WordUndecoded;
		@class.IsSpaceBox = IsSpaceBox;
		return @class;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "{0}[{1}]", new object[2] { base.Tag, string_3 });
	}
}
