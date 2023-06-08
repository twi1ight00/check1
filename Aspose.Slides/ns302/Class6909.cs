namespace ns302;

internal class Class6909 : Class6908
{
	private string string_24;

	public override string InnerHtml => OuterHtml;

	public override string OuterHtml
	{
		get
		{
			if (string_24 == null)
			{
				return base.OuterHtml;
			}
			return string_24;
		}
	}

	public string Text
	{
		get
		{
			if (string_24 == null)
			{
				return base.OuterHtml;
			}
			return string_24;
		}
		set
		{
			string_24 = value;
		}
	}

	internal Class6909(Class6905 ownerdocument, int index)
		: base(Enum944.const_3, ownerdocument, index)
	{
	}
}
