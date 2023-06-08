namespace xe5b37aee2c2a4d4e;

internal class x38058b386e92a0ef : x52642f91ccdeeb35
{
	internal const char x7bc27edc06d8aefd = '\u0302';

	internal override x3e68720d12325f49 x3e68720d12325f49 => x3e68720d12325f49.x9b63794dfed849a8;

	internal char x067d56aec20cdd99
	{
		get
		{
			return (char)xfe91eeeafcb3026a(15040);
		}
		set
		{
			char c = x14aad2b9760be9e9(value);
			xae20093bed1e48a8(15040, c, c != '\u0302');
		}
	}

	private static char x14aad2b9760be9e9(char xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 < '\u0300')
		{
			return '\u0300';
		}
		if (xbcea506a33cf9111 > '\u036f' && xbcea506a33cf9111 < '\u20d0')
		{
			return (xbcea506a33cf9111 < 'ሟ') ? '\u036f' : '\u20d0';
		}
		if (xbcea506a33cf9111 > '\u20ef')
		{
			return '\u20ef';
		}
		return xbcea506a33cf9111;
	}
}
