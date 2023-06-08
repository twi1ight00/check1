using System.Text.RegularExpressions;
using Aspose.Words;
using xf9a9481c3f63a419;

namespace x583d72a986201ed7;

internal class xfcd94753d9b2d2ef : x829e0857a06af038
{
	internal xfcd94753d9b2d2ef()
		: base(isBullet: false, isLevelsSupported: false, NumberStyle.Arabic)
	{
	}

	internal override bool xb983789489a1157b(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 == "1";
	}

	internal override string x181ceabdeeb62d2d(string x0a98315ddae9f889)
	{
		int num = xca004f56614e2431.x912616ee70b2d94d(x0a98315ddae9f889);
		if (num != int.MinValue)
		{
			return (num + 1).ToString();
		}
		return "";
	}

	internal override xd0213f18a88e2027 x22bdad7984a6b53a(string xb41faee6912a2313)
	{
		Regex regex = new Regex("^[1-9]\\d*\\)");
		Match match = regex.Match(xb41faee6912a2313);
		if (!match.Success)
		{
			return null;
		}
		string text = match.Value.Substring(0, match.Value.Length - 1);
		return new xd0213f18a88e2027(new string[1] { text }, match.Value);
	}

	internal override string x54f56e2c447eeea2(int x66bbd7ed8c65740d)
	{
		return "\0)";
	}
}
