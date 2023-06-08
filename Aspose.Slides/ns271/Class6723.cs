namespace ns271;

internal class Class6723
{
	private string string_0;

	private string string_1;

	private Class6654 class6654_0;

	private bool bool_0;

	internal string FamilyName
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

	internal string FullName
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

	internal Class6654 Data
	{
		get
		{
			return class6654_0;
		}
		set
		{
			class6654_0 = value;
		}
	}

	internal bool IsTtc
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

	internal Class6723(string familyName, string fullName)
	{
		string_0 = familyName;
		string_1 = fullName;
	}
}
