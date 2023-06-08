using System;
using System.Collections;
using System.Text;
using Aspose.Words.Saving;

namespace x59d6a4fc5007b7a4;

internal class x45e2219c0e324605
{
	private static readonly Hashtable x1a773b1f73ad3010;

	private static readonly Hashtable x5042f34344d5063a;

	internal static bool x5987bcde09b106d1(NumeralFormat x01d59ab59d3bce7c, bool xe68b7760102eb0fd, int x4e8144106c5bf176)
	{
		x838b2dfd1391264c x838b2dfd1391264c2 = x7ddb5ac1df856225(x01d59ab59d3bce7c, xe68b7760102eb0fd, x4e8144106c5bf176);
		if ((x838b2dfd1391264c2 & x838b2dfd1391264c.x18f02ac63e62140a) != x838b2dfd1391264c.x18f02ac63e62140a)
		{
			return (x838b2dfd1391264c2 & x838b2dfd1391264c.x790e93630c6f4ece) == x838b2dfd1391264c.x790e93630c6f4ece;
		}
		return true;
	}

	internal static string x550781f8db1cf5f2(string xb41faee6912a2313, NumeralFormat x01d59ab59d3bce7c, bool xe68b7760102eb0fd, int x4e8144106c5bf176)
	{
		x838b2dfd1391264c x594135906c55045c = x7ddb5ac1df856225(x01d59ab59d3bce7c, xe68b7760102eb0fd, x4e8144106c5bf176);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < xb41faee6912a2313.Length; i++)
		{
			char value = (x34a37b5a89c466fd.x2a3e4106546123a1(xb41faee6912a2313[i]) ? x66230c19a83ea53d(xb41faee6912a2313[i], x594135906c55045c) : xb41faee6912a2313[i]);
			stringBuilder.Append(value);
		}
		return stringBuilder.ToString();
	}

	private static x838b2dfd1391264c x7ddb5ac1df856225(NumeralFormat x01d59ab59d3bce7c, bool xe68b7760102eb0fd, int x4e8144106c5bf176)
	{
		switch (x01d59ab59d3bce7c)
		{
		case NumeralFormat.European:
			return x838b2dfd1391264c.xf6c17f648b65c793;
		case NumeralFormat.ArabicIndic:
			if (x4e8144106c5bf176 != 1037)
			{
				return x838b2dfd1391264c.x18f02ac63e62140a;
			}
			break;
		}
		if (x01d59ab59d3bce7c == NumeralFormat.EasternArabicIndic && x4e8144106c5bf176 != 1037)
		{
			return x838b2dfd1391264c.x790e93630c6f4ece;
		}
		if (x01d59ab59d3bce7c == NumeralFormat.Context && xe68b7760102eb0fd)
		{
			return x769ea5e930af2cbc.xc4d57f5507cfa842(x4e8144106c5bf176);
		}
		return x838b2dfd1391264c.xf6c17f648b65c793;
	}

	private static char x66230c19a83ea53d(char x3ed992d2d48f96dd, x838b2dfd1391264c x594135906c55045c)
	{
		Hashtable hashtable;
		if ((x594135906c55045c & x838b2dfd1391264c.x790e93630c6f4ece) == x838b2dfd1391264c.x790e93630c6f4ece || (x594135906c55045c & x838b2dfd1391264c.x69d0c314232cf917) == x838b2dfd1391264c.x69d0c314232cf917)
		{
			hashtable = x5042f34344d5063a;
		}
		else
		{
			if ((x594135906c55045c & x838b2dfd1391264c.x18f02ac63e62140a) != x838b2dfd1391264c.x18f02ac63e62140a)
			{
				throw new ArgumentException("Unknown script");
			}
			hashtable = x1a773b1f73ad3010;
		}
		if (hashtable.ContainsKey(x3ed992d2d48f96dd))
		{
			return (char)hashtable[x3ed992d2d48f96dd];
		}
		return x3ed992d2d48f96dd;
	}

	static x45e2219c0e324605()
	{
		x1a773b1f73ad3010 = new Hashtable();
		x5042f34344d5063a = new Hashtable();
		x1a773b1f73ad3010['0'] = '٠';
		x1a773b1f73ad3010['1'] = '١';
		x1a773b1f73ad3010['2'] = '٢';
		x1a773b1f73ad3010['3'] = '٣';
		x1a773b1f73ad3010['4'] = '٤';
		x1a773b1f73ad3010['5'] = '٥';
		x1a773b1f73ad3010['6'] = '٦';
		x1a773b1f73ad3010['7'] = '٧';
		x1a773b1f73ad3010['8'] = '٨';
		x1a773b1f73ad3010['9'] = '٩';
		x5042f34344d5063a['0'] = '۰';
		x5042f34344d5063a['1'] = '۱';
		x5042f34344d5063a['2'] = '۲';
		x5042f34344d5063a['3'] = '۳';
		x5042f34344d5063a['4'] = '۴';
		x5042f34344d5063a['5'] = '۵';
		x5042f34344d5063a['6'] = '۶';
		x5042f34344d5063a['7'] = '۷';
		x5042f34344d5063a['8'] = '۸';
		x5042f34344d5063a['9'] = '۹';
	}
}
