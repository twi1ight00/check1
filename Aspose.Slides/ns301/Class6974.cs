using System.Globalization;

namespace ns301;

internal sealed class Class6974
{
	private Class6974()
	{
	}

	public static object smethod_0(string value)
	{
		if (value != null && value.Trim().Length != 0)
		{
			try
			{
				return float.Parse(value, NumberStyles.Any, CultureInfo.InvariantCulture);
			}
			catch
			{
				return null;
			}
		}
		return null;
	}
}
