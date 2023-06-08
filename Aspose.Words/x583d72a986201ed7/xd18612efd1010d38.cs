using System;
using Aspose.Words;

namespace x583d72a986201ed7;

internal class xd18612efd1010d38 : x829e0857a06af038
{
	private readonly string[] x0a416894e5c435ea;

	private readonly char x8298d7f8d08be8ed;

	internal xd18612efd1010d38(char[] letterSet, char separator, NumberStyle numberStyle)
		: base(isBullet: false, isLevelsSupported: false, numberStyle)
	{
		if (letterSet == null)
		{
			throw new ArgumentNullException("letterSet");
		}
		x0a416894e5c435ea = new string[letterSet.Length];
		for (int i = 0; i < letterSet.Length; i++)
		{
			x0a416894e5c435ea[i] = Convert.ToString(letterSet[i]);
		}
		x8298d7f8d08be8ed = separator;
	}

	internal override bool xb983789489a1157b(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 == x0a416894e5c435ea[0];
	}

	internal override string x181ceabdeeb62d2d(string x0a98315ddae9f889)
	{
		int num = x7020fb136ea43db6(x0a98315ddae9f889);
		if (num == -1 || num == x0a416894e5c435ea.Length - 1)
		{
			return "";
		}
		return x0a416894e5c435ea[num + 1];
	}

	internal override xd0213f18a88e2027 x22bdad7984a6b53a(string xb41faee6912a2313)
	{
		string[] array = x0a416894e5c435ea;
		foreach (string text in array)
		{
			if (xb41faee6912a2313.IndexOf(text + x8298d7f8d08be8ed) == 0)
			{
				return new xd0213f18a88e2027(text, xb41faee6912a2313.Substring(0, text.Length + 1));
			}
		}
		return null;
	}

	internal override string x54f56e2c447eeea2(int x66bbd7ed8c65740d)
	{
		return "\0" + x8298d7f8d08be8ed;
	}

	private int x7020fb136ea43db6(string x78b0a0bc28459535)
	{
		for (int i = 0; i < x0a416894e5c435ea.Length; i++)
		{
			if (x0a416894e5c435ea[i] == x78b0a0bc28459535)
			{
				return i;
			}
		}
		return -1;
	}
}
