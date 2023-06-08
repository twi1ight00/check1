using System;
using ns292;
using ns301;

namespace ns291;

internal abstract class Class6858
{
	[Flags]
	public enum Enum927
	{
		flag_0 = 0,
		flag_1 = 1,
		flag_2 = 2,
		flag_3 = 4
	}

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5 = true;

	private readonly Enum926 enum926_0;

	private Class6796 class6796_0;

	private Class6787 class6787_0;

	private Enum923 enum923_0;

	private Class6790 class6790_0;

	private bool bool_6;

	private bool bool_7;

	private Enum927 enum927_0;

	public Enum927 FontFaceTypes
	{
		get
		{
			return enum927_0;
		}
		set
		{
			enum927_0 = value;
		}
	}

	public bool CompensateRoundingErrors
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	public Enum926 DocumentType => enum926_0;

	public bool RemoveTopBottomMargin
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

	public bool UseWoffFonts
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	public bool FixedLayout
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

	public bool CompressSvgGraphics
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

	public bool DocumentPerPageGeneration
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

	public bool DrawPageBorders
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

	public Class6796 PageStyleOptions
	{
		get
		{
			return class6796_0;
		}
		set
		{
			Class6892.smethod_0(value, "value");
			class6796_0 = value;
		}
	}

	public bool RecognizeUnderlineAndStrikeout
	{
		get
		{
			return bool_7;
		}
		set
		{
			bool_7 = value;
		}
	}

	public Class6787 StreamingOptions
	{
		get
		{
			return class6787_0;
		}
		set
		{
			Class6892.smethod_0(value, "value");
			class6787_0 = value;
		}
	}

	public Enum923 PageBackgroundImageType
	{
		get
		{
			return enum923_0;
		}
		set
		{
			enum923_0 = value;
		}
	}

	public Class6790 CSSWriterOptions => class6790_0;

	protected Class6858(Enum926 documentType)
	{
		bool_1 = true;
		enum926_0 = documentType;
		class6796_0 = new Class6796();
		bool_4 = false;
		class6787_0 = new Class6787();
		enum923_0 = Enum923.const_4;
		class6790_0 = new Class6790();
	}
}
