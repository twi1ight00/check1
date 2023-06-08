using System;

namespace ns253;

internal class Class6440 : Class6437
{
	private Guid guid_0 = Guid.Empty;

	private Class6435 class6435_0;

	private string string_0;

	private string string_1;

	public Class6435 ParagraphProperties
	{
		get
		{
			if (class6435_0 == null)
			{
				class6435_0 = new Class6435();
			}
			return class6435_0;
		}
	}

	public Guid Id
	{
		get
		{
			return guid_0;
		}
		set
		{
			guid_0 = value;
		}
	}

	public string Type
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

	public string Text
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
}
