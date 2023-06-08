using System.Globalization;

namespace ns302;

internal class Class6901
{
	internal int int_0;

	internal int int_1;

	internal int int_2;

	internal int int_3;

	internal int int_4;

	internal int int_5;

	internal int int_6;

	internal Class6905 class6905_0;

	internal string string_0;

	internal string string_1;

	public string Name
	{
		get
		{
			if (string_0 == null)
			{
				string_0 = class6905_0.stringBuilder_0.ToString(int_3, int_4).ToLower(CultureInfo.InvariantCulture);
			}
			return string_0;
		}
	}

	public string Value
	{
		get
		{
			if (string_1 == null)
			{
				string_1 = class6905_0.stringBuilder_0.ToString(int_5, int_6);
			}
			return string_1;
		}
	}

	public int Line => int_0;

	public int LinePosition => int_1;

	public int StreamPosition => int_2;

	internal Class6901(Class6905 ownerdocument)
	{
		class6905_0 = ownerdocument;
	}
}
