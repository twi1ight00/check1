using System.Text.RegularExpressions;
using Aspose.Words;
using x1a3e96f4b89a7a77;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xda075892eccab2ad;
using xf9a9481c3f63a419;

namespace xbe829a00a7a86dc3;

internal class xf141024760662983
{
	private const int xef0cf8e8188b06df = 1;

	private const int x81301242c2763349 = 2;

	private const int xedf15498d615d731 = 3;

	private const int xccc21895562b4e4b = 4;

	private const int x97a5243d2a5420a3 = 5;

	private const int xf6c39cc90e3847c4 = 6;

	private const int x2858c1bbbdd4f8cf = 7;

	private const int xc661aad5be98cc9c = 8;

	private const int x924d15159b43639f = 9;

	private const int x9c1c389c23de2c41 = 10;

	private bool xf486629d2973656f;

	private bool x50ad65210fe18e68;

	private bool xdc0073c6bfe0e9e1;

	private FootnoteType x534a3e9da6413d26;

	private readonly x4f037d20d40d8390 x9b287b671d592594;

	private readonly xf7173b82df2a4de7 x800085dd555f7711;

	private static readonly Regex x57b70f3452f46c2c = new Regex("(\u0002)|(\u0003)|(\u0004)|(\u0005)|(\t)|(\r)|(\f|\v|\u000e)|(\u001e)|(\u001f)|([^\u0002\u0003\u0004\u0005\t\r\f\v\u000e\u001e\u001f]*)", RegexOptions.Compiled | RegexOptions.Singleline);

	internal bool x4a86e66e43e7143c
	{
		get
		{
			return xf486629d2973656f;
		}
		set
		{
			xf486629d2973656f = value;
		}
	}

	internal FootnoteType xd7b3f218029cb4b8
	{
		get
		{
			return x534a3e9da6413d26;
		}
		set
		{
			x534a3e9da6413d26 = value;
		}
	}

	internal xf141024760662983(x4f037d20d40d8390 writer)
	{
		x9b287b671d592594 = writer;
		x800085dd555f7711 = (xf7173b82df2a4de7)writer.xe1410f585439c7d4;
	}

	internal void x486167d7a74e8e88(Run xb0e5d73738e62f9e)
	{
		x16474cfd0fac275f(xb0e5d73738e62f9e);
	}

	internal void x1ad30cf176eb522c(SpecialChar x150eb30055afb74d)
	{
		x16474cfd0fac275f(x150eb30055afb74d);
	}

	private void x16474cfd0fac275f(Inline x31545d7c306a55e4)
	{
		string text = x31545d7c306a55e4.GetText();
		if (!x0d299f323d241756.x5959bccb67bbf051(text) || text[0] == '\u0001')
		{
			return;
		}
		bool flag = xebb9db61691ea142.x1adf194ca8126a4d(text[0]);
		bool flag2 = x31545d7c306a55e4.xeedad81aaed42a76.x263d579af1d0d43f(230);
		if (flag && flag2)
		{
			for (int i = 0; i < text.Length; i++)
			{
				x32c9a0cbee7be23c(x31545d7c306a55e4);
				x800085dd555f7711.xc049ea80ee267201("w:sym", "w:font", x31545d7c306a55e4.xeedad81aaed42a76.xd08cbc518cf39317, "w:char", xca004f56614e2431.x7c1a0f9da8274fe8(text[i]));
				xf0de1bdc2a5440b2();
			}
			return;
		}
		x32c9a0cbee7be23c(x31545d7c306a55e4);
		MatchCollection matchCollection = x57b70f3452f46c2c.Matches(text);
		foreach (Match item in matchCollection)
		{
			string value = item.Groups[10].Value;
			if (x0d299f323d241756.x5959bccb67bbf051(value))
			{
				x3bfd5395f6e50823(value);
				continue;
			}
			value = item.Groups[1].Value;
			if (x0d299f323d241756.x5959bccb67bbf051(value))
			{
				x579a77a9b1500f31();
				continue;
			}
			value = item.Groups[2].Value;
			if (x0d299f323d241756.x5959bccb67bbf051(value))
			{
				x800085dd555f7711.xf68f9c3818e1f4b1("w:separator");
				continue;
			}
			value = item.Groups[3].Value;
			if (x0d299f323d241756.x5959bccb67bbf051(value))
			{
				x800085dd555f7711.xf68f9c3818e1f4b1("w:continuationSeparator");
				continue;
			}
			value = item.Groups[4].Value;
			if (x0d299f323d241756.x5959bccb67bbf051(value))
			{
				x800085dd555f7711.xf68f9c3818e1f4b1("w:annotationRef");
				continue;
			}
			value = item.Groups[5].Value;
			if (x0d299f323d241756.x5959bccb67bbf051(value))
			{
				xe72b72a917296a39();
				continue;
			}
			value = item.Groups[6].Value;
			if (x0d299f323d241756.x5959bccb67bbf051(value))
			{
				x800085dd555f7711.xf68f9c3818e1f4b1("w:cr");
				continue;
			}
			value = item.Groups[7].Value;
			if (x0d299f323d241756.x5959bccb67bbf051(value))
			{
				x331ee46cdcdcdf0f(value[0], x31545d7c306a55e4.xeedad81aaed42a76.xb298f2d4a3b9607a);
				continue;
			}
			value = item.Groups[9].Value;
			if (x0d299f323d241756.x5959bccb67bbf051(value))
			{
				if (!text.StartsWith(ControlChar.xa105f6e68b723c97))
				{
					xf0de1bdc2a5440b2();
					x32c9a0cbee7be23c(x31545d7c306a55e4);
				}
				x800085dd555f7711.xf68f9c3818e1f4b1("w:softHyphen");
				continue;
			}
			value = item.Groups[8].Value;
			if (x0d299f323d241756.x5959bccb67bbf051(value))
			{
				if (!text.StartsWith(ControlChar.x6d39aeda91fde741))
				{
					xf0de1bdc2a5440b2();
					x32c9a0cbee7be23c(x31545d7c306a55e4);
				}
				x800085dd555f7711.xf68f9c3818e1f4b1("w:noBreakHyphen");
			}
		}
		xf0de1bdc2a5440b2();
	}

	private void x32c9a0cbee7be23c(Inline x31545d7c306a55e4)
	{
		x32c9a0cbee7be23c(x31545d7c306a55e4.xeedad81aaed42a76, x31545d7c306a55e4, x8f19af4759cf8cd4: false);
	}

	internal bool x32c9a0cbee7be23c(xeedad81aaed42a76 x789564759d365819, xf5ecf429e74b1c04 x1a84eefd5d3e114a, bool x8f19af4759cf8cd4)
	{
		x50ad65210fe18e68 = x789564759d365819.xba4e1d8a3e3316c8;
		xdc0073c6bfe0e9e1 = x789564759d365819.x0392c0938d22c790;
		x800085dd555f7711.x2307058321cdb62f(x800085dd555f7711.xac094da7bd5cf4c8 ? "m:r" : "w:r");
		return xc70f986e9535e88a.xcb4a900bb4787522(x789564759d365819, x1a84eefd5d3e114a, x8f19af4759cf8cd4, x9b287b671d592594);
	}

	internal void xf0de1bdc2a5440b2()
	{
		x800085dd555f7711.x2dfde153f4ef96d0(x800085dd555f7711.xac094da7bd5cf4c8 ? "m:r" : "w:r");
		if (x50ad65210fe18e68)
		{
			x50ad65210fe18e68 = false;
		}
		if (xdc0073c6bfe0e9e1)
		{
			xdc0073c6bfe0e9e1 = false;
		}
	}

	private void x579a77a9b1500f31()
	{
		string x121383aa = ((x534a3e9da6413d26 == FootnoteType.Footnote) ? "w:footnoteRef" : "w:endnoteRef");
		x800085dd555f7711.xf68f9c3818e1f4b1(x121383aa);
	}

	private void x3bfd5395f6e50823(string xb41faee6912a2313)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xb41faee6912a2313))
		{
			string x121383aa = (xf486629d2973656f ? ((!xdc0073c6bfe0e9e1) ? "w:instrText" : "w:delInstrText") : ((!xdc0073c6bfe0e9e1) ? (x800085dd555f7711.xac094da7bd5cf4c8 ? "m:t" : "w:t") : "w:delText"));
			x800085dd555f7711.x6b73ce92fd8e3f2c(x121383aa, xb41faee6912a2313);
		}
	}

	private void xe72b72a917296a39()
	{
		x800085dd555f7711.xf68f9c3818e1f4b1("w:tab");
	}

	private void x331ee46cdcdcdf0f(char xb45de92d01a0ec1f, xb298f2d4a3b9607a xdf016623ed23eee0)
	{
		string text = null;
		if (xb45de92d01a0ec1f == '\v' && xdf016623ed23eee0 != 0)
		{
			text = xf2a0216b53787578.x3eeaa9c8690f9db0(xdf016623ed23eee0);
		}
		if (xb45de92d01a0ec1f == '\v' && xdf016623ed23eee0 == xb298f2d4a3b9607a.x4d0b9d4447ba7566)
		{
			x800085dd555f7711.xf68f9c3818e1f4b1("w:br");
			return;
		}
		x800085dd555f7711.xc049ea80ee267201("w:br", "w:type", xf2a0216b53787578.x832f3daadc37ea45(xb45de92d01a0ec1f, x5fbb1a9c98604ef5: false), "w:clear", text);
	}
}
