using System;

namespace ns288;

internal static class Class6915
{
	public static Interface331 smethod_0(string parserName)
	{
		if (parserName.Equals("DISPLAY", StringComparison.OrdinalIgnoreCase))
		{
			return new Class6914();
		}
		if (parserName.Equals("align", StringComparison.OrdinalIgnoreCase))
		{
			return new Class6823();
		}
		if (parserName.Equals("text-align", StringComparison.OrdinalIgnoreCase))
		{
			return new Class6835();
		}
		if (parserName.Equals("vertical-align", StringComparison.OrdinalIgnoreCase))
		{
			return new Class6837();
		}
		if (parserName.Equals("direction", StringComparison.OrdinalIgnoreCase))
		{
			return new Class6828();
		}
		if (parserName.Equals("list-style-type", StringComparison.OrdinalIgnoreCase))
		{
			return new Class6832();
		}
		if (parserName.Equals("list-style-position", StringComparison.OrdinalIgnoreCase))
		{
			return new Class6831();
		}
		if (parserName.Equals("table-layout", StringComparison.OrdinalIgnoreCase))
		{
			return new Class6834();
		}
		if (parserName.Equals("text-transform", StringComparison.OrdinalIgnoreCase))
		{
			return new Class6836();
		}
		if (parserName.Equals("position", StringComparison.OrdinalIgnoreCase))
		{
			return new Class6833();
		}
		if (parserName.Equals("float", StringComparison.OrdinalIgnoreCase))
		{
			return new Class6830();
		}
		if (parserName.Equals("border-collapse", StringComparison.OrdinalIgnoreCase))
		{
			return new Class6824();
		}
		if (parserName.Equals("empty-cells", StringComparison.OrdinalIgnoreCase))
		{
			return new Class6829();
		}
		if (parserName.Equals("clear", StringComparison.OrdinalIgnoreCase))
		{
			return new Class6825();
		}
		if (parserName.Equals("white-space", StringComparison.OrdinalIgnoreCase))
		{
			return new Class6838();
		}
		return null;
	}
}
