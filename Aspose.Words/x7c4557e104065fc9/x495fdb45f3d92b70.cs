using System;
using System.Text;
using System.Text.RegularExpressions;
using Aspose.Words;
using Aspose.Words.Lists;
using Aspose.Words.Tables;
using x011d489fb9df7027;
using x2697283ff424107e;
using x28925c9b27b37a46;
using x5794c252ba25e723;
using x643046e3f004c49f;
using x6c95d9cf46ff5f25;
using xbe73d5820f7f4ae3;
using xda075892eccab2ad;
using xf9a9481c3f63a419;

namespace x7c4557e104065fc9;

internal class x495fdb45f3d92b70
{
	private const int x04dd27f5a18ab27f = 1;

	private const int xfd2350c24819fd74 = 7;

	private const int xd0c5fc818022ac14 = 1;

	private const int x5b70346de38f2ea6 = 2;

	private const int x1c37f4e6a0a80a15 = 3;

	private const int xd92eda13d9ccf924 = 4;

	private const int x2caceb74f713c6e7 = 5;

	private const int xab3a41f541660f9d = 6;

	private const int x844dd56c8db80bcb = 7;

	private static readonly double[] x2a6af07d4984be29 = new double[7] { 7.5, 10.0, 12.0, 13.5, 18.0, 24.0, 36.0 };

	private static readonly Regex x6ed28255fafb7d1e = new Regex("^(?:(?:#([0-9a-f]{3}(?:[0-9a-f]{3})?))|(?:rgb\\(\\s*([-+]?\\d+(?:\\.\\d*)?)(%)?\\s*,\\s*([-+]?\\d+(?:\\.\\d*)?)(%)?\\s*,\\s*([-+]?\\d+(?:\\.\\d*)?)(%)?\\s*\\)))$", RegexOptions.Compiled);

	internal static string xf0c7bb08a8616ee4(string x50a18ad2656e7181, bool x4ff8b171363c7c38)
	{
		StringBuilder stringBuilder = new StringBuilder(x50a18ad2656e7181.Length);
		bool flag = x4ff8b171363c7c38;
		bool flag2 = true;
		for (int i = 0; i < x50a18ad2656e7181.Length; i++)
		{
			if (xce9c5b0a9b7b658c.x6c589c7857d7d8d9(x50a18ad2656e7181[i]))
			{
				if (!flag && flag2)
				{
					stringBuilder.Append(' ');
				}
				flag2 = false;
			}
			else
			{
				stringBuilder.Append(x50a18ad2656e7181[i]);
				flag = false;
				flag2 = true;
			}
		}
		return stringBuilder.ToString();
	}

	internal static bool x9ecc47300149e587(string x50a18ad2656e7181)
	{
		int num = x50a18ad2656e7181.Length;
		while (--num >= 0)
		{
			if (!xce9c5b0a9b7b658c.x6c589c7857d7d8d9(x50a18ad2656e7181[num]))
			{
				return false;
			}
		}
		return true;
	}

	internal static double xb42d95ae44c48104(int x5c021e387157a637)
	{
		x5c021e387157a637 = Math.Min(x5c021e387157a637, 7);
		x5c021e387157a637 = Math.Max(x5c021e387157a637, 1);
		return x2a6af07d4984be29[x5c021e387157a637 - 1];
	}

	internal static string x115c740da8ad8584(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		return $"#{x6c50a99faab7d741.xc613adc4330033f3:X2}{x6c50a99faab7d741.x26463655896fd90a:X2}{x6c50a99faab7d741.x8e8f6cc6a0756b05:X2}";
	}

	internal static ParagraphAlignment xa9a738046a9a4faa(string x7717e14a55110734)
	{
		return x7717e14a55110734.ToLower() switch
		{
			"left" => ParagraphAlignment.Left, 
			"right" => ParagraphAlignment.Right, 
			"center" => ParagraphAlignment.Center, 
			"justify" => ParagraphAlignment.Justify, 
			_ => ParagraphAlignment.Left, 
		};
	}

	internal static TableAlignment xa4258984257f6241(string x7717e14a55110734)
	{
		return x7717e14a55110734.ToLower() switch
		{
			"left" => TableAlignment.Left, 
			"right" => TableAlignment.Right, 
			"center" => TableAlignment.Center, 
			_ => TableAlignment.Left, 
		};
	}

	internal static TableAlignment xd55b823b4c121cee(xa3fc7dcdc8182ff6 x36c843bef78b260f)
	{
		xedac08b4826d3056 xedac08b4826d = x36c843bef78b260f.get_xe6d4b1b411ed94b5("margin-left");
		xedac08b4826d3056 xedac08b4826d2 = x36c843bef78b260f.get_xe6d4b1b411ed94b5("margin-right");
		xedac08b4826d3056 xedac08b4826d3 = x36c843bef78b260f.get_xe6d4b1b411ed94b5("margin");
		if (xedac08b4826d3 != null)
		{
			x60b7a505461a80e7 x60b7a505461a80e = new x60b7a505461a80e7(xedac08b4826d3);
			xedac08b4826d = x60b7a505461a80e.x72d92bd1aff02e37;
			xedac08b4826d2 = x60b7a505461a80e.x419ba17a5322627b;
		}
		if (xedac08b4826d != null && x0d299f323d241756.x90637a473b1ceaaa(xedac08b4826d.x48112399d54b30c7(), "auto"))
		{
			if (xedac08b4826d2 == null || !x0d299f323d241756.x90637a473b1ceaaa(xedac08b4826d2.x48112399d54b30c7(), "auto"))
			{
				return TableAlignment.Right;
			}
			return TableAlignment.Center;
		}
		return TableAlignment.Left;
	}

	internal static string x7f90501c33a75aa6(ParagraphAlignment x4ec4022180cbf8f4)
	{
		return x4ec4022180cbf8f4 switch
		{
			ParagraphAlignment.Left => "left", 
			ParagraphAlignment.Right => "right", 
			ParagraphAlignment.Center => "center", 
			ParagraphAlignment.Justify => "justify", 
			ParagraphAlignment.Distributed => "justify", 
			_ => "left", 
		};
	}

	internal static string xf8b46c270d89b1c8(TableAlignment x4ec4022180cbf8f4)
	{
		return x4ec4022180cbf8f4 switch
		{
			TableAlignment.Left => "left", 
			TableAlignment.Right => "right", 
			TableAlignment.Center => "center", 
			_ => "left", 
		};
	}

	internal static CellVerticalAlignment xc6376d756fb42f0f(string x4235f7f18d1924ab)
	{
		return x4235f7f18d1924ab.ToLower() switch
		{
			"top" => CellVerticalAlignment.Top, 
			"middle" => CellVerticalAlignment.Center, 
			"bottom" => CellVerticalAlignment.Bottom, 
			_ => CellVerticalAlignment.Center, 
		};
	}

	internal static string x4c48d7d9054ce462(CellVerticalAlignment x4ec4022180cbf8f4)
	{
		return x4ec4022180cbf8f4 switch
		{
			CellVerticalAlignment.Top => "top", 
			CellVerticalAlignment.Center => "middle", 
			CellVerticalAlignment.Bottom => "bottom", 
			_ => "middle", 
		};
	}

	internal static x206d87dc07f8c9e2 x76725d46a0c3cb9a(string x7717e14a55110734)
	{
		return x7717e14a55110734.ToLower() switch
		{
			"left" => x206d87dc07f8c9e2.x72d92bd1aff02e37, 
			"center" => x206d87dc07f8c9e2.x58d2ccae3c5cfd08, 
			"right" => x206d87dc07f8c9e2.x419ba17a5322627b, 
			_ => x206d87dc07f8c9e2.x58d2ccae3c5cfd08, 
		};
	}

	internal static string x083645b9ab54da6f(x206d87dc07f8c9e2 x7717e14a55110734)
	{
		return x7717e14a55110734 switch
		{
			x206d87dc07f8c9e2.x72d92bd1aff02e37 => "left", 
			x206d87dc07f8c9e2.x58d2ccae3c5cfd08 => "center", 
			x206d87dc07f8c9e2.x419ba17a5322627b => "right", 
			_ => "center", 
		};
	}

	internal static bool x1cd02f5b4489bb3e(x9d6b37cac59aa2e2 xda5bf54deb817e37, ref CellVerticalAlignment xc7e4cc9c69af8ff1)
	{
		if (xda5bf54deb817e37 != null)
		{
			string text = xda5bf54deb817e37.x75658b3f8be4005c("valign", "");
			if (x0d299f323d241756.x5959bccb67bbf051(text))
			{
				xc7e4cc9c69af8ff1 = xc6376d756fb42f0f(text);
				return true;
			}
		}
		return false;
	}

	internal static bool x365021ddf20e0498(x9d6b37cac59aa2e2 xda5bf54deb817e37, ref ParagraphAlignment x7717e14a55110734)
	{
		if (xda5bf54deb817e37 != null)
		{
			string text = xda5bf54deb817e37.x75658b3f8be4005c("align", "");
			if (x0d299f323d241756.x5959bccb67bbf051(text))
			{
				x7717e14a55110734 = xa9a738046a9a4faa(text);
				return true;
			}
		}
		return false;
	}

	internal static bool x722b70a5a6410b8c(x9d6b37cac59aa2e2 xda5bf54deb817e37, string xb591dc602a67d872, ref x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		if (xda5bf54deb817e37 != null)
		{
			string xbcea506a33cf = xda5bf54deb817e37.x75658b3f8be4005c(xb591dc602a67d872, "");
			if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf))
			{
				x6c50a99faab7d741 = x722b70a5a6410b8c(xbcea506a33cf);
				return !x6c50a99faab7d741.x7149c962c02931b3;
			}
		}
		return false;
	}

	internal static x26d9ecb4bdf0456d x722b70a5a6410b8c(string xbcea506a33cf9111)
	{
		xbcea506a33cf9111 = xbcea506a33cf9111.ToLower();
		Match match = x6ed28255fafb7d1e.Match(xbcea506a33cf9111);
		if (match.Success)
		{
			Group group = match.Groups[1];
			if (group.Success)
			{
				string value = group.Value;
				if (value.Length == 6)
				{
					return new x26d9ecb4bdf0456d(-16777216 + xca004f56614e2431.xadcf75bfc0bf31e3(value));
				}
				int num = x0d299f323d241756.xe3ec68422266caf1(value[0]);
				int num2 = x0d299f323d241756.xe3ec68422266caf1(value[1]);
				int num3 = x0d299f323d241756.xe3ec68422266caf1(value[2]);
				return new x26d9ecb4bdf0456d(num * 17, num2 * 17, num3 * 17);
			}
			int r = xf13b2d782628dbb6(match.Groups[2].Value, match.Groups[3].Success);
			int g = xf13b2d782628dbb6(match.Groups[4].Value, match.Groups[5].Success);
			int b = xf13b2d782628dbb6(match.Groups[6].Value, match.Groups[7].Success);
			return new x26d9ecb4bdf0456d(r, g, b);
		}
		if (xbcea506a33cf9111.EndsWith("grey"))
		{
			xbcea506a33cf9111 = xbcea506a33cf9111.Substring(0, xbcea506a33cf9111.Length - "grey".Length) + "gray";
		}
		return xe27aaa947ea63911.x4fc015c0cc57fa75(xbcea506a33cf9111);
	}

	private static int xf13b2d782628dbb6(string x37cf7043760b312e, bool x7680b8fbb55e05b8)
	{
		double xbcea506a33cf = xca004f56614e2431.xec25d08a2af152f0(x37cf7043760b312e) * (x7680b8fbb55e05b8 ? 2.55 : 1.0);
		return x15e971129fd80714.x43fcc3f62534530b(x15e971129fd80714.xe193c76ba76a5afc(xbcea506a33cf, 0.0, 255.0));
	}

	internal static string xff194a3741776ee2(ListLevel x66bbd7ed8c65740d)
	{
		string text = x75e0857b98f68f5f(x66bbd7ed8c65740d);
		if (text != null)
		{
			return text;
		}
		return x66bbd7ed8c65740d.NumberStyle switch
		{
			NumberStyle.LowercaseLetter => "a", 
			NumberStyle.LowercaseRoman => "i", 
			NumberStyle.UppercaseLetter => "A", 
			NumberStyle.UppercaseRoman => "I", 
			_ => "1", 
		};
	}

	internal static string x75e0857b98f68f5f(ListLevel x66bbd7ed8c65740d)
	{
		switch (x66bbd7ed8c65740d.NumberFormat)
		{
		case "\uf0b7":
			return "disc";
		case "o":
			return "circle";
		case "\uf0a7":
			return "square";
		default:
		{
			NumberStyle numberStyle = x66bbd7ed8c65740d.NumberStyle;
			if (numberStyle == NumberStyle.Bullet || numberStyle == NumberStyle.None)
			{
				return xc948ae21e4aca55a(x66bbd7ed8c65740d.x008c23e8f687bbd3);
			}
			return null;
		}
		}
	}

	internal static bool x903af03e39bcd255(ListLevel x66bbd7ed8c65740d, bool xbaa77e237937c5db)
	{
		if (xbaa77e237937c5db && (x66bbd7ed8c65740d.x008c23e8f687bbd3 != 0 || x66bbd7ed8c65740d.StartAt != 1))
		{
			return false;
		}
		bool flag = false;
		string numberFormat = x66bbd7ed8c65740d.NumberFormat;
		if (numberFormat.Length == 1)
		{
			char c = numberFormat[0];
			flag = c == '\uf0b7' || c == 'o' || c == '\uf0a7';
		}
		if (!flag)
		{
			switch (x66bbd7ed8c65740d.NumberStyle)
			{
			case NumberStyle.Arabic:
			case NumberStyle.UppercaseRoman:
			case NumberStyle.LowercaseRoman:
			case NumberStyle.UppercaseLetter:
			case NumberStyle.LowercaseLetter:
				flag = numberFormat.Length == 2 && numberFormat[0] == x66bbd7ed8c65740d.x008c23e8f687bbd3 && numberFormat[1] == '.';
				break;
			}
		}
		return flag;
	}

	internal static bool x451aaae1babb8e57(x1a78664fa10a3755 x062aae8c9613eeaa)
	{
		int x8301ab10c226b0c = x062aae8c9613eeaa.x8301ab10c226b0c2;
		if (x8301ab10c226b0c >= 1)
		{
			return x8301ab10c226b0c <= 6;
		}
		return false;
	}

	internal static PreferredWidth x844d4319ee50b6d6(string xe4115acdf4fbfccc)
	{
		if (xe4115acdf4fbfccc.EndsWith("%"))
		{
			double num = xca004f56614e2431.xf5ece46c5d72e3b9(xe4115acdf4fbfccc.Substring(0, xe4115acdf4fbfccc.Length - 1));
			if (!double.IsNaN(num) && num >= 0.0)
			{
				return PreferredWidth.xb4e521ca3a7fd077(num);
			}
		}
		else
		{
			double num2 = xca004f56614e2431.xf5ece46c5d72e3b9(xe4115acdf4fbfccc);
			if (!double.IsNaN(num2) && num2 >= 0.0)
			{
				return PreferredWidth.xb6bb25492776965a(ConvertUtil.PixelToPoint(num2));
			}
		}
		return null;
	}

	internal static bool x3732023a3d3acbf8(string x25352bd290aed0d5, bool xf0e1f8c39ee2c6f7)
	{
		return x25352bd290aed0d5.ToLower() switch
		{
			"rtl" => true, 
			"ltr" => false, 
			_ => xf0e1f8c39ee2c6f7, 
		};
	}

	internal static bool xfd054898a6589135(Node xb6a159a84cb992d6, Node xde860fba55c41d76)
	{
		if (xb6a159a84cb992d6 == null || xde860fba55c41d76 == null)
		{
			return false;
		}
		if (xb6a159a84cb992d6 == xde860fba55c41d76)
		{
			return true;
		}
		return xde860fba55c41d76.xd5b26cfce8730b50(xb6a159a84cb992d6);
	}

	internal static int xe7d40c349fabe0ed(string x0ef28b7990128ffc)
	{
		int num = x0eb9a864413f34de.x1fd658c8428b3dd6(x0ef28b7990128ffc);
		if (num == 127)
		{
			num = xf2a0216b53787578.xae88295ea6bfc819(x0ef28b7990128ffc.ToUpper(), x5fbb1a9c98604ef5: false);
		}
		return num;
	}

	internal static byte[] x67ec207e977a9cea(string x4a3f0a05c02f235f)
	{
		if (!x4a3f0a05c02f235f.StartsWith("data:"))
		{
			return null;
		}
		int num = x4a3f0a05c02f235f.IndexOf("base64,");
		if (num < 0)
		{
			return null;
		}
		string s = x4a3f0a05c02f235f.Substring(num + "base64,".Length);
		return Convert.FromBase64String(s);
	}

	internal static string xc948ae21e4aca55a(int xa63471462057f6dd)
	{
		return (xa63471462057f6dd % 3) switch
		{
			0 => "disc", 
			1 => "circle", 
			2 => "square", 
			_ => null, 
		};
	}
}
