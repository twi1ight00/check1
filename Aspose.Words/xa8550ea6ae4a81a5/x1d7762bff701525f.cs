using System.Text.RegularExpressions;
using Aspose.Words;
using x1a3e96f4b89a7a77;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xda075892eccab2ad;
using xf9a9481c3f63a419;

namespace xa8550ea6ae4a81a5;

internal class x1d7762bff701525f
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

	private readonly xaf66e8c590b2b553 x9b287b671d592594;

	private FootnoteType x534a3e9da6413d26;

	private static readonly Regex x57b70f3452f46c2c = new Regex("(\u0002)|(\u0003)|(\u0004)|(\u0005)|(\t)|(\r)|(\f|\v|\u000e)|(\u001e)|(\u001f)|([^\u0002\u0003\u0004\u0005\t\r\f\v\u000e\u001e\u001f]*)", RegexOptions.Compiled | RegexOptions.Singleline);

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

	internal x1d7762bff701525f(xaf66e8c590b2b553 writer)
	{
		x9b287b671d592594 = writer;
	}

	internal void x16474cfd0fac275f(Inline x31545d7c306a55e4)
	{
		string text = x31545d7c306a55e4.GetText();
		if (!x0d299f323d241756.x5959bccb67bbf051(text) || text[0] == '\u0001')
		{
			return;
		}
		if (Run.xe190c8f083575592(text) && x31545d7c306a55e4.xeedad81aaed42a76.x263d579af1d0d43f(230))
		{
			for (int i = 0; i < text.Length; i++)
			{
				x32c9a0cbee7be23c(x31545d7c306a55e4);
				x8f3af96aa56f1e32 xca93abf9292cd4f = x9b287b671d592594.xca93abf9292cd4f1;
				xca93abf9292cd4f.xc049ea80ee267201("w:sym", "w:font", x31545d7c306a55e4.xeedad81aaed42a76.x51cf23ce6e71b84c, "w:char", xca004f56614e2431.x7c1a0f9da8274fe8(text[i]));
				xf0de1bdc2a5440b2(x31545d7c306a55e4.xeedad81aaed42a76);
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
				x3bfd5395f6e50823(value, x31545d7c306a55e4.IsDeleteRevision);
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
				x9b287b671d592594.xca93abf9292cd4f1.xf68f9c3818e1f4b1("w:separator");
				continue;
			}
			value = item.Groups[3].Value;
			if (x0d299f323d241756.x5959bccb67bbf051(value))
			{
				x9b287b671d592594.xca93abf9292cd4f1.xf68f9c3818e1f4b1("w:continuationSeparator");
				continue;
			}
			value = item.Groups[4].Value;
			if (x0d299f323d241756.x5959bccb67bbf051(value))
			{
				x9b287b671d592594.xca93abf9292cd4f1.xf68f9c3818e1f4b1("w:annotationRef");
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
				x9b287b671d592594.xca93abf9292cd4f1.xf68f9c3818e1f4b1("w:cr");
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
					xf0de1bdc2a5440b2(x31545d7c306a55e4.xeedad81aaed42a76);
					x32c9a0cbee7be23c(x31545d7c306a55e4);
				}
				x9b287b671d592594.xca93abf9292cd4f1.xf68f9c3818e1f4b1("w:softHyphen");
				continue;
			}
			value = item.Groups[8].Value;
			if (x0d299f323d241756.x5959bccb67bbf051(value))
			{
				if (!text.StartsWith(ControlChar.x6d39aeda91fde741))
				{
					xf0de1bdc2a5440b2(x31545d7c306a55e4.xeedad81aaed42a76);
					x32c9a0cbee7be23c(x31545d7c306a55e4);
				}
				x9b287b671d592594.xca93abf9292cd4f1.xf68f9c3818e1f4b1("w:noBreakHyphen");
			}
		}
		xf0de1bdc2a5440b2(x31545d7c306a55e4.xeedad81aaed42a76);
	}

	private void x32c9a0cbee7be23c(Inline x31545d7c306a55e4)
	{
		x32c9a0cbee7be23c(x31545d7c306a55e4.xeedad81aaed42a76, x31545d7c306a55e4, x566ab42519f5da4a: true);
	}

	internal void x32c9a0cbee7be23c(xeedad81aaed42a76 x789564759d365819, xf5ecf429e74b1c04 x1a84eefd5d3e114a, bool x566ab42519f5da4a)
	{
		x8f3af96aa56f1e32 xca93abf9292cd4f = x9b287b671d592594.xca93abf9292cd4f1;
		if (x789564759d365819.xba4e1d8a3e3316c8)
		{
			xca93abf9292cd4f.xd0c5f01ab55153ce(x789564759d365819.x18bb4aa7903ffced, x9b287b671d592594.x28ee4b8b8f777b55());
		}
		if (x789564759d365819.x0392c0938d22c790)
		{
			xca93abf9292cd4f.xd0c5f01ab55153ce(x789564759d365819.x83da691dd3d974a6, x9b287b671d592594.x28ee4b8b8f777b55());
		}
		xca93abf9292cd4f.x2307058321cdb62f(xca93abf9292cd4f.xac094da7bd5cf4c8 ? "m:r" : "w:r");
		if (x566ab42519f5da4a)
		{
			xca93abf9292cd4f.x943f6be3acf634db("w:rsidRPr", xc1b08afa36bf580c.x0d28bf60e577f9e5(x789564759d365819.xf7866f89640a29a3(30)));
			if (x789564759d365819.xbc5dc59d0d9b620d(40))
			{
				string text = xc1b08afa36bf580c.x0d28bf60e577f9e5(x789564759d365819.xf7866f89640a29a3(40));
				if (text != xca93abf9292cd4f.xb673df6aa8c79149)
				{
					xca93abf9292cd4f.x943f6be3acf634db("w:rsidR", text);
				}
			}
		}
		xc70f986e9535e88a.xcb4a900bb4787522(x789564759d365819, x1a84eefd5d3e114a, x8f19af4759cf8cd4: false, x9b287b671d592594);
	}

	internal void xf0de1bdc2a5440b2(xeedad81aaed42a76 x789564759d365819)
	{
		x8f3af96aa56f1e32 xca93abf9292cd4f = x9b287b671d592594.xca93abf9292cd4f1;
		xca93abf9292cd4f.x2dfde153f4ef96d0();
		if (x789564759d365819.x0392c0938d22c790)
		{
			xca93abf9292cd4f.x44d8d13f25d44840();
		}
		if (x789564759d365819.xba4e1d8a3e3316c8)
		{
			xca93abf9292cd4f.x44d8d13f25d44840();
		}
	}

	private void x579a77a9b1500f31()
	{
		string x121383aa = ((x534a3e9da6413d26 == FootnoteType.Footnote) ? "w:footnoteRef" : "w:endnoteRef");
		x9b287b671d592594.xca93abf9292cd4f1.xf68f9c3818e1f4b1(x121383aa);
	}

	private void x3bfd5395f6e50823(string xb41faee6912a2313, bool x781c624c0dab1bdb)
	{
		x8f3af96aa56f1e32 xca93abf9292cd4f = x9b287b671d592594.xca93abf9292cd4f1;
		string x121383aa = (x9b287b671d592594.x4a86e66e43e7143c ? (x781c624c0dab1bdb ? "w:delInstrText" : "w:instrText") : ((!x781c624c0dab1bdb || xca93abf9292cd4f.xac094da7bd5cf4c8) ? (xca93abf9292cd4f.xac094da7bd5cf4c8 ? "m:t" : "w:t") : "w:delText"));
		xca93abf9292cd4f.x2307058321cdb62f(x121383aa);
		if (xb41faee6912a2313[0] == ' ' || xb41faee6912a2313[xb41faee6912a2313.Length - 1] == ' ')
		{
			xca93abf9292cd4f.xff520a0047c27122("xml:space", "preserve");
		}
		xca93abf9292cd4f.x3d1be38abe5723e3(xb41faee6912a2313);
		xca93abf9292cd4f.x2dfde153f4ef96d0();
	}

	private void xe72b72a917296a39()
	{
		x9b287b671d592594.xca93abf9292cd4f1.xf68f9c3818e1f4b1("w:tab");
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
			x9b287b671d592594.xca93abf9292cd4f1.xf68f9c3818e1f4b1("w:br");
			return;
		}
		x9b287b671d592594.xca93abf9292cd4f1.xc049ea80ee267201("w:br", "w:type", xf2a0216b53787578.x832f3daadc37ea45(xb45de92d01a0ec1f, x5fbb1a9c98604ef5: true), "w:clear", text);
	}
}
