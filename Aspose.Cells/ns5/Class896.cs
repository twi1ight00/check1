using System.Runtime.CompilerServices;

namespace ns5;

internal class Class896
{
	private string string_0 = "";

	private string string_1 = "";

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private int int_0 = 9;

	private Enum106 enum106_0;

	private Enum102 enum102_0;

	internal string Text
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	internal string FontName
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	internal bool FontBold
	{
		set
		{
			bool_0 = value;
		}
	}

	internal bool FontItalic
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

	internal bool RotatedChars
	{
		set
		{
			bool_2 = value;
		}
	}

	internal int FontSize
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	internal Enum102 PresetShape
	{
		set
		{
			enum102_0 = value;
		}
	}

	[SpecialName]
	internal void method_0(Enum106 enum106_1)
	{
		enum106_0 = enum106_1;
	}
}
