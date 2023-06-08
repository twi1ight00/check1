using System;
using System.Text.RegularExpressions;
using Aspose.Words;

namespace x583d72a986201ed7;

internal abstract class x288f5fefdfbc87bb : x829e0857a06af038
{
	private readonly char x893867a18e71fd68;

	private readonly bool x57349543f9c7e043;

	protected x288f5fefdfbc87bb(char bulletChar, bool onlySpaceSeparateBullet)
		: base(isBullet: true, isLevelsSupported: false, NumberStyle.Bullet)
	{
		x893867a18e71fd68 = bulletChar;
		x57349543f9c7e043 = onlySpaceSeparateBullet;
	}

	protected x288f5fefdfbc87bb(char bulletChar)
		: this(bulletChar, onlySpaceSeparateBullet: false)
	{
	}

	internal override xd0213f18a88e2027 x22bdad7984a6b53a(string xb41faee6912a2313)
	{
		string arg = (x57349543f9c7e043 ? "\\s" : "(\\w|\\s)");
		Regex regex = new Regex($"^\\u{(int)x893867a18e71fd68:X4}{arg}");
		Match match = regex.Match(xb41faee6912a2313);
		if (match.Success)
		{
			string[] array = new string[1] { Convert.ToString(x893867a18e71fd68) };
			return new xd0213f18a88e2027(array, array[0]);
		}
		return null;
	}

	internal override bool xb983789489a1157b(string xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111.Length == 1)
		{
			return xbcea506a33cf9111[0] == x893867a18e71fd68;
		}
		return false;
	}

	internal override string x181ceabdeeb62d2d(string x0a98315ddae9f889)
	{
		return Convert.ToString(x893867a18e71fd68);
	}

	internal override string x54f56e2c447eeea2(int x66bbd7ed8c65740d)
	{
		return Convert.ToString(x893867a18e71fd68);
	}
}
