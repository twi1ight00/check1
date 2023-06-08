using System.Globalization;

namespace ns302;

internal class Class6910 : Class6908
{
	private const string string_24 = "<!--{0} -->";

	private string string_25;

	public override string InnerHtml
	{
		get
		{
			if (string_25 == null)
			{
				return base.InnerHtml;
			}
			return string_25;
		}
	}

	public override string OuterHtml
	{
		get
		{
			if (string_25 == null)
			{
				return base.OuterHtml;
			}
			return string.Format(CultureInfo.InvariantCulture, "<!--{0} -->", new object[1] { string_25 });
		}
	}

	public string Comment
	{
		get
		{
			if (string_25 == null)
			{
				return base.InnerHtml;
			}
			return string_25;
		}
	}

	internal Class6910(Class6905 ownerdocument, int index)
		: base(Enum944.const_2, ownerdocument, index)
	{
	}
}
