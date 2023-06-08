namespace ns28;

internal class Class471
{
	protected string string_0;

	protected string string_1;

	protected string string_2;

	protected string string_3;

	protected string string_4;

	protected string string_5;

	protected string string_6;

	protected string string_7;

	protected string string_8;

	protected string string_9;

	protected string string_10;

	protected string string_11;

	protected string string_12;

	protected string string_13;

	private string string_14 = "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0";

	public string FontVariant
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

	public string TextTransform
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

	public string Color
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public string FontFamily
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

	public string FontSize
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	public string LetterSpacing
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	public string Language
	{
		get
		{
			return string_6;
		}
		set
		{
			string_6 = value;
		}
	}

	public string LanguageAsian
	{
		get
		{
			return string_7;
		}
		set
		{
			string_7 = value;
		}
	}

	public string LanguageComplex
	{
		get
		{
			return string_8;
		}
		set
		{
			string_8 = value;
		}
	}

	public string Country
	{
		get
		{
			return string_9;
		}
		set
		{
			string_9 = value;
		}
	}

	public string FontStyle
	{
		get
		{
			return string_10;
		}
		set
		{
			string_10 = value;
		}
	}

	public string TextShadow
	{
		get
		{
			return string_11;
		}
		set
		{
			string_11 = value;
		}
	}

	public string FontWeight
	{
		get
		{
			return string_12;
		}
		set
		{
			string_12 = value;
		}
	}

	public string BackgroundColor
	{
		get
		{
			return string_13;
		}
		set
		{
			string_13 = value;
		}
	}

	public Class471()
	{
	}

	public Class471(Class369 source)
	{
		if (source != null)
		{
			method_0(source);
		}
	}

	internal void method_0(Class369 source)
	{
		string_0 = source.method_0("font-variant", string_14, "");
		string_1 = source.method_0("text-transform", string_14, "");
		string_2 = source.method_0("color", string_14, "");
		string_3 = source.method_0("font-family", string_14, "");
		string_4 = source.method_0("font-size", string_14, "");
		string_5 = source.method_0("letter-spacing", string_14, "");
		string_6 = source.method_0("language", string_14, "");
		string_7 = source.method_0("language-asian", string_14, "");
		string_8 = source.method_0("language-complex", string_14, "");
		string_9 = source.method_0("country", string_14, "");
		string_10 = source.method_0("font-style", string_14, "");
		string_11 = source.method_0("text-shadow", string_14, "");
		string_12 = source.method_0("font-weight", string_14, "");
		string_13 = source.method_0("background-color", string_14, "");
	}
}
