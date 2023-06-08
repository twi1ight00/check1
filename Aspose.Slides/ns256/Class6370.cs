namespace ns256;

internal class Class6370
{
	private Interface289 interface289_0;

	private string string_0;

	public string Name
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

	public Interface289 Formula
	{
		get
		{
			return interface289_0;
		}
		set
		{
			interface289_0 = value;
		}
	}

	public Class6370(string name, Interface289 formula)
	{
		string_0 = name;
		interface289_0 = formula;
	}
}
