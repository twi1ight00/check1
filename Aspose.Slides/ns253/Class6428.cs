namespace ns253;

internal abstract class Class6428
{
	private string string_0 = string.Empty;

	private int int_0;

	private int int_1;

	private string string_1 = string.Empty;

	public string TextTypeface
	{
		get
		{
			if (string_1 == null)
			{
				string_1 = string.Empty;
			}
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public int SimilarFontFamily
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public string PanoseSetting
	{
		get
		{
			if (string_0 == null)
			{
				string_0 = string.Empty;
			}
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public int SimilarCharacterSet
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
}
