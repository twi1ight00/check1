using System;
using ns287;
using ns301;

namespace ns284;

internal class Class6957 : Interface356
{
	private string string_0;

	private Enum947 enum947_0;

	private string string_1;

	private string string_2;

	private string string_3;

	public string Href
	{
		get
		{
			return string_3;
		}
		private set
		{
			string_3 = value;
		}
	}

	public Enum947 Type
	{
		get
		{
			return enum947_0;
		}
		private set
		{
			enum947_0 = value;
		}
	}

	public string Html5Type
	{
		get
		{
			return string_1;
		}
		private set
		{
			string_1 = value;
		}
	}

	public string Html5Media
	{
		get
		{
			return string_2;
		}
		private set
		{
			string_2 = value;
		}
	}

	public string Anchor
	{
		get
		{
			return string_0;
		}
		private set
		{
			string_0 = value;
		}
	}

	public Class6957(Class6996 htmlA)
	{
		if (!Class6973.smethod_0(htmlA.Href))
		{
			Type = (htmlA.Href.StartsWith("#", StringComparison.Ordinal) ? Enum947.const_1 : Enum947.const_2);
			Href = htmlA.Href;
		}
		else if (!Class6973.smethod_0(htmlA.Name))
		{
			Type = Enum947.const_0;
			Anchor = htmlA.Name;
		}
		if (htmlA.Attributes.Contains("type"))
		{
			Html5Type = htmlA.Type;
		}
		if (htmlA.Attributes.Contains("media"))
		{
			Html5Media = htmlA.method_20("media");
		}
	}
}
