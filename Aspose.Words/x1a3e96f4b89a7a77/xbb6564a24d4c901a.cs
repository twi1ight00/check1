using System.Collections;
using System.Text.RegularExpressions;
using Aspose.Words;
using x38d3ef1c1d247e82;
using x6c95d9cf46ff5f25;
using xda075892eccab2ad;

namespace x1a3e96f4b89a7a77;

internal class xbb6564a24d4c901a
{
	private readonly Hashtable x5e77a33ce4ff263c;

	private readonly Hashtable x11412c0d603dd458;

	private readonly x94c83b1ca7961561 x9163dbcb586b7163;

	private static readonly Regex x8394bc85c69b8faa = new Regex("[^-a-zA-Z0-9]*", RegexOptions.Compiled | RegexOptions.Singleline);

	internal xbb6564a24d4c901a(StyleCollection styles)
	{
		int count = styles.Count;
		x5e77a33ce4ff263c = new Hashtable(count);
		x11412c0d603dd458 = new Hashtable();
		x9163dbcb586b7163 = x94c83b1ca7961561.x964c8ab59da5fc93();
		for (int i = 0; i < count; i++)
		{
			x6c8494b42e236f7b(styles[i]);
		}
	}

	private void x6c8494b42e236f7b(Style x44ecfea61c937b8e)
	{
		string xbcea506a33cf;
		if (x44ecfea61c937b8e.BuiltIn)
		{
			xbcea506a33cf = x72a0c846678ecaf9.x27d6a5b617edc9db(x44ecfea61c937b8e.StyleIdentifier, x44ecfea61c937b8e.Name);
			xbcea506a33cf = x72a0c846678ecaf9.xebaf9df1cc1ad15a(xbcea506a33cf);
		}
		else
		{
			xbcea506a33cf = x44ecfea61c937b8e.Name;
		}
		int x8301ab10c226b0c = x44ecfea61c937b8e.x8301ab10c226b0c2;
		string text = xd7cbc6fc86cfbce9("a", xbcea506a33cf);
		x5e77a33ce4ff263c.Add(x8301ab10c226b0c, text);
		string text2 = x44ecfea61c937b8e.Styles.x4c0f9b9b517a1ec4(x44ecfea61c937b8e, xe9f84f829511a789: false);
		if (x0d299f323d241756.x5959bccb67bbf051(text2))
		{
			string[] array = text2.Split(',');
			int num = array.Length;
			while (--num >= 0)
			{
				array[num] = xd7cbc6fc86cfbce9(text, array[num]);
			}
			x11412c0d603dd458.Add(x8301ab10c226b0c, array);
		}
	}

	private string xd7cbc6fc86cfbce9(string xc9535a007dd89198, string xbd5a2e7a4ff749c9)
	{
		string text = x8394bc85c69b8faa.Replace(xbd5a2e7a4ff749c9, string.Empty);
		if (text == string.Empty)
		{
			text = xc9535a007dd89198;
		}
		text = xe1d5d012d2674f05(text);
		x9163dbcb586b7163.xd6b6ed77479ef68c(text);
		return text;
	}

	private string xe1d5d012d2674f05(string x1bd44401d685915c)
	{
		x0d299f323d241756.x48501aec8e48c869(x1bd44401d685915c, "styleId");
		string text = x1bd44401d685915c;
		int num = 0;
		while (x9163dbcb586b7163.x263d579af1d0d43f(text))
		{
			text = x1bd44401d685915c + num;
			num++;
		}
		return text;
	}

	internal string x7af082eaf8e0caa4(int xddd12ddd8b1e4a90)
	{
		return (string)x5e77a33ce4ff263c[xddd12ddd8b1e4a90];
	}

	internal string[] xb6b0362f2c000366(int xddd12ddd8b1e4a90)
	{
		return (string[])x11412c0d603dd458[xddd12ddd8b1e4a90];
	}
}
