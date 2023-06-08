using System;
using System.Collections;
using System.Text.RegularExpressions;
using Aspose.Words;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x583d72a986201ed7;

internal class x6ae49747a15f10a4 : x829e0857a06af038
{
	internal x6ae49747a15f10a4()
		: base(isBullet: false, isLevelsSupported: true, NumberStyle.Arabic)
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
		Regex regex = new Regex("^[1-9]\\d*(\\.|\\s)");
		ArrayList arrayList = new ArrayList();
		int num = 0;
		string text = xb41faee6912a2313;
		Match match;
		do
		{
			match = regex.Match(text);
			if (!match.Success)
			{
				break;
			}
			string value = match.Value.Substring(0, match.Value.Length - 1);
			num += match.Value.Length;
			arrayList.Add(value);
			text = text.Remove(0, match.Length);
		}
		while (!x0d299f323d241756.x263d579af1d0d43f(match.Value, " ", x8b05b1454697839b: true));
		if (arrayList.Count == 0)
		{
			return null;
		}
		string[] array = new string[arrayList.Count];
		for (int i = 0; i < arrayList.Count; i++)
		{
			array[i] = (string)arrayList[i];
		}
		return new xd0213f18a88e2027(array, xb41faee6912a2313.Substring(0, num).Trim());
	}

	internal override string x54f56e2c447eeea2(int x66bbd7ed8c65740d)
	{
		string text = "";
		for (int i = 0; i <= x66bbd7ed8c65740d; i++)
		{
			text = text + Convert.ToChar(i) + ".";
		}
		return text;
	}
}
