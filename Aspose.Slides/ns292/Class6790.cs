using System;

namespace ns292;

internal class Class6790
{
	private const string string_0 = "stl_";

	private string string_1;

	public string ClassNamePrefix
	{
		get
		{
			return string_1;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value", "CSS Class Name can't be a null.");
			}
			if (value.Length == 0)
			{
				throw new ArgumentException("CSS Class Name can't be an empty.", value);
			}
			string_1 = value;
		}
	}

	internal Class6790()
	{
		string_1 = "stl_";
	}
}
