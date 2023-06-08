using System;
using System.Text;
using System.Text.RegularExpressions;
using x13f1efc79617a47b;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xda075892eccab2ad;
using xf9a9481c3f63a419;

namespace x7c7a1dceb600404e;

internal class xd76179d16486fd56
{
	private const int xadadf9e32a0e0872 = 2;

	private const int x1069158c2f4bf6e7 = 3;

	private const int x56de861235008355 = 4;

	private const int x1ef94d98a56631fa = 5;

	private const int x668f5cade2724745 = 6;

	private const int x1fc7c508ff252a73 = 8;

	private const int x7a641efe5ee374b5 = 10;

	private const int xaed122e9ce5363d7 = 12;

	private static readonly Regex x7d5ad23bc02dae7f = new Regex("^((([a-z]+) ([a-z]+)\\((\\d+)\\))|([0-9a-f]{6})|(([a-z]+).*)|(#([0-9a-f]{6}).*)|(#([0-9a-f]{3}).*))$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

	private xd76179d16486fd56()
	{
	}

	internal static x26d9ecb4bdf0456d xe74389aafc9d4795(string x6c50a99faab7d741)
	{
		Match match = x7d5ad23bc02dae7f.Match(x6c50a99faab7d741);
		string value = match.Groups[2].Value;
		string value2 = match.Groups[8].Value;
		string value3 = match.Groups[6].Value;
		string value4 = match.Groups[10].Value;
		string value5 = match.Groups[12].Value;
		if (x0d299f323d241756.x5959bccb67bbf051(value))
		{
			int a = 239;
			int r = match.Groups[3].Value switch
			{
				"fill" => 240, 
				"lineOrFill" => 241, 
				"line" => 242, 
				"shadow" => 243, 
				_ => throw new InvalidOperationException(x53e8d00ae6524da8(x6c50a99faab7d741)), 
			};
			int g = match.Groups[4].Value switch
			{
				"darken" => 1, 
				"lighten" => 2, 
				"add" => 3, 
				_ => throw new InvalidOperationException(x53e8d00ae6524da8(x6c50a99faab7d741)), 
			};
			int b = xca004f56614e2431.xa93402510be8434e(match.Groups[5].Value);
			return new x26d9ecb4bdf0456d(a, r, g, b);
		}
		if (x0d299f323d241756.x5959bccb67bbf051(value2))
		{
			return value2 switch
			{
				"window" => new x26d9ecb4bdf0456d(239, 17, 0, 0), 
				"windowText" => x26d9ecb4bdf0456d.x89fffa2751fdecbe, 
				"this" => x26d9ecb4bdf0456d.x45260ad4b94166f2, 
				_ => x79650abd153dd39a.x2841a83dd2caf0da(value2), 
			};
		}
		if (x0d299f323d241756.x5959bccb67bbf051(value3))
		{
			return xc1b08afa36bf580c.x5e71f16a78faf353(value3);
		}
		if (x0d299f323d241756.x5959bccb67bbf051(value4))
		{
			return xc1b08afa36bf580c.x5e71f16a78faf353(value4);
		}
		if (x0d299f323d241756.x5959bccb67bbf051(value5))
		{
			StringBuilder stringBuilder = new StringBuilder(6);
			foreach (char value6 in value5)
			{
				stringBuilder.Append(value6);
				stringBuilder.Append(value6);
			}
			return xc1b08afa36bf580c.x5e71f16a78faf353(stringBuilder.ToString());
		}
		throw new InvalidOperationException(x53e8d00ae6524da8(x6c50a99faab7d741));
	}

	internal static string xbe7cce711e45fa32(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		return xbe7cce711e45fa32(x6c50a99faab7d741, x0dae4143cd874639: true, xeaf65170fc9ee55f: false);
	}

	internal static string xbe7cce711e45fa32(x26d9ecb4bdf0456d x6c50a99faab7d741, bool x0dae4143cd874639, bool xeaf65170fc9ee55f)
	{
		if (x6c50a99faab7d741.x7149c962c02931b3)
		{
			return "this";
		}
		if (x6c50a99faab7d741.xda71bf6f7c07c3bc == 239)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (x6c50a99faab7d741.xc613adc4330033f3 >= 240)
			{
				switch (x6c50a99faab7d741.xc613adc4330033f3)
				{
				case 240:
					stringBuilder.Append("fill ");
					break;
				case 241:
					stringBuilder.Append("lineOrFill ");
					break;
				case 242:
					stringBuilder.Append("line ");
					break;
				case 243:
					stringBuilder.Append("shadow ");
					break;
				case 244:
					return null;
				case 247:
					return null;
				default:
					throw new InvalidOperationException(x22903ac145555e73(x6c50a99faab7d741));
				}
				switch (x6c50a99faab7d741.x26463655896fd90a)
				{
				case 1:
					stringBuilder.Append("darken");
					break;
				case 2:
					stringBuilder.Append("lighten");
					break;
				case 3:
					stringBuilder.Append("add");
					break;
				default:
					throw new InvalidOperationException(x22903ac145555e73(x6c50a99faab7d741));
				}
				stringBuilder.AppendFormat("({0})", x6c50a99faab7d741.x8e8f6cc6a0756b05);
			}
			else
			{
				switch (x6c50a99faab7d741.xc613adc4330033f3)
				{
				case 17:
					break;
				case 1:
					return null;
				default:
					throw new InvalidOperationException(x22903ac145555e73(x6c50a99faab7d741));
				}
				stringBuilder.Append("window");
			}
			return stringBuilder.ToString();
		}
		string text = x79650abd153dd39a.x88b4fed52f891602(x6c50a99faab7d741);
		if (text != "")
		{
			return text;
		}
		if (x0dae4143cd874639 && x6c50a99faab7d741.xda71bf6f7c07c3bc == 255 && xa4c1d565ceb0256a(x6c50a99faab7d741.xc613adc4330033f3) && xa4c1d565ceb0256a(x6c50a99faab7d741.x26463655896fd90a) && xa4c1d565ceb0256a(x6c50a99faab7d741.x8e8f6cc6a0756b05))
		{
			return $"#{x3c75de25500355d8(x6c50a99faab7d741.xc613adc4330033f3)}{x3c75de25500355d8(x6c50a99faab7d741.x26463655896fd90a)}{x3c75de25500355d8(x6c50a99faab7d741.x8e8f6cc6a0756b05)}";
		}
		string text2 = $"#{x44c82bce5d22047c(x6c50a99faab7d741.xc613adc4330033f3)}{x44c82bce5d22047c(x6c50a99faab7d741.x26463655896fd90a)}{x44c82bce5d22047c(x6c50a99faab7d741.x8e8f6cc6a0756b05)}";
		if (xeaf65170fc9ee55f)
		{
			return text2.ToUpper();
		}
		return text2;
	}

	private static string x22903ac145555e73(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		return string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("oaohecfiobmiobdjmbkjbcbkfbikemokeaglnanlhaemhalmhacnclindaaofahojpnoloepdklpfocalojannabgohbjoobpnfccomcanddknkdkmbegmiephpeamgfomnfimegmllgolcheljhkgaiojhidloidlfjckmjiidkeikkffblhjilhkplmjgmijnmijenhjlnaecokejokdapcjhpeeopoifamdma", 417365433)), x6c50a99faab7d741.ToString());
	}

	private static string x53e8d00ae6524da8(string x6c50a99faab7d741)
	{
		return string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kkeeamleklcfkljfilagnlhgblogagfhakmhjkdidkkidkbjdkijoepjpjgkbknkfjelhillpdcmbijmhianjhhncionfifolhmoohdpmgkpghbaggiacgpalbgbmfnbkgeceglcifcdkfjdafaegahekdoepeffpemfoddgeckgacbhbphhhdphidgiidniedejedljddckmnikgopkgnglocolaoemkcmmincn", 1935098965)), x6c50a99faab7d741);
	}

	private static string x44c82bce5d22047c(int x2819ac37ce9513c7)
	{
		return xca004f56614e2431.x06423d8cf62a0672(x2819ac37ce9513c7);
	}

	private static string x3c75de25500355d8(int x2819ac37ce9513c7)
	{
		return xca004f56614e2431.xad97b43ecf64e377(x2819ac37ce9513c7 % 16);
	}

	private static bool xa4c1d565ceb0256a(int x2819ac37ce9513c7)
	{
		return x2819ac37ce9513c7 / 16 == x2819ac37ce9513c7 % 16;
	}
}
