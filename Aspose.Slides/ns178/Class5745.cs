namespace ns178;

internal class Class5745 : Interface243
{
	private int int_0;

	private int int_1;

	public int LineNumber
	{
		set
		{
			int_0 = value;
		}
	}

	public int ColumnNumber
	{
		set
		{
			int_1 = value;
		}
	}

	public Class5745()
	{
		int_0 = 0;
		int_1 = 0;
	}

	public Class5745(Interface243 locator)
	{
		int_0 = locator.imethod_0();
		int_1 = locator.imethod_1();
	}

	public int imethod_0()
	{
		return int_0;
	}

	public int imethod_1()
	{
		return int_1;
	}

	public string imethod_2()
	{
		return string.Empty;
	}

	public string imethod_3()
	{
		return string.Empty;
	}
}
