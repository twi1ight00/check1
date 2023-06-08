using System.Collections;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Fonts;
using Aspose.Words.Tables;
using x011d489fb9df7027;
using x28925c9b27b37a46;
using x452f379ec5921195;
using x6c95d9cf46ff5f25;
using x79578da6a8a3ae37;

namespace xda075892eccab2ad;

internal class x72a0c846678ecaf9
{
	private static readonly Hashtable xe49c14b143611f35;

	private static readonly Hashtable xff3ebdfb873687f6;

	private static readonly Hashtable x43c04799f6fc46cd;

	private static readonly Hashtable x0c95dc2292557611;

	private static readonly Hashtable x0d20ae342e6ff37a;

	private static readonly Hashtable xc2a9433dcc285e3e;

	private static readonly Hashtable x7631e7053fead5d7;

	private static readonly Hashtable x700a0c1ac37c805c;

	private static readonly Hashtable x7660b2bbd0607e4f;

	private static readonly Hashtable x238eae4ac21bd0fb;

	private static readonly Hashtable xd3151b42e7d14c37;

	private static readonly Hashtable xf057f9c02feec50d;

	private static readonly Hashtable xae1872c5eb9882c8;

	private static readonly Hashtable xb12f6b492f47f35e;

	private static readonly Hashtable x93437a6c9d28ea77;

	private static readonly Hashtable x54e5870f9de97f85;

	private static readonly Hashtable x6ed3560115064f44;

	private static readonly Hashtable x3f0c300c9b8f8c84;

	private static readonly Hashtable x6fc25d5ad0e01d83;

	private static readonly Hashtable x57e6d9d1690ffa72;

	internal static x3650f9b73dc5111b x80665af7f89d2124(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"flatBorders" => x3650f9b73dc5111b.xefd793a3562fa636, 
			"noBorder" => x3650f9b73dc5111b.x4d0b9d4447ba7566, 
			_ => x3650f9b73dc5111b.xe74f26d8f4cfb63f, 
		};
	}

	internal static string x8b9ec7eefd64375b(x3650f9b73dc5111b xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			x3650f9b73dc5111b.xefd793a3562fa636 => "flatBorders", 
			x3650f9b73dc5111b.x4d0b9d4447ba7566 => "noBorder", 
			_ => "", 
		};
	}

	internal static x9826cda6c042c8ed xbb21b4da4a6e1630(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"cols" => x9826cda6c042c8ed.x3bce7c87328df8da, 
			"rows" => x9826cda6c042c8ed.x61c108cc44ef385a, 
			_ => x9826cda6c042c8ed.x4d0b9d4447ba7566, 
		};
	}

	internal static string x703423b6c1c23036(x9826cda6c042c8ed xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			x9826cda6c042c8ed.x3bce7c87328df8da => "cols", 
			x9826cda6c042c8ed.x61c108cc44ef385a => "rows", 
			_ => "", 
		};
	}

	internal static x1b1ec609e70eb086 xd1c99b969f2441fd(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"band1Horz" => x1b1ec609e70eb086.x1c2c1355ae6bd833, 
			"band1Vert" => x1b1ec609e70eb086.xa4e228fcd9490f45, 
			"band2Horz" => x1b1ec609e70eb086.x37435c29a5649292, 
			"band2Vert" => x1b1ec609e70eb086.xbea9812efdcba147, 
			"firstCol" => x1b1ec609e70eb086.xb8e3e9a641be95c5, 
			"firstRow" => x1b1ec609e70eb086.x5d6d04c35215bc51, 
			"lastCol" => x1b1ec609e70eb086.xf59d22dcfa267bc1, 
			"lastRow" => x1b1ec609e70eb086.xbc3a1ad7f75a88f9, 
			"neCell" => x1b1ec609e70eb086.xb43f8d5efcee0261, 
			"nwCell" => x1b1ec609e70eb086.x95249c3688e883c5, 
			"seCell" => x1b1ec609e70eb086.x6cecca56ca9d6ef2, 
			"swCell" => x1b1ec609e70eb086.x34f4bcb41a1eddcb, 
			"wholeTable" => x1b1ec609e70eb086.xb0c74a540a258df5, 
			_ => x1b1ec609e70eb086.x4d0b9d4447ba7566, 
		};
	}

	internal static string x1cc48fed2015ead6(x1b1ec609e70eb086 xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			x1b1ec609e70eb086.x1c2c1355ae6bd833 => "band1Horz", 
			x1b1ec609e70eb086.xa4e228fcd9490f45 => "band1Vert", 
			x1b1ec609e70eb086.x37435c29a5649292 => "band2Horz", 
			x1b1ec609e70eb086.xbea9812efdcba147 => "band2Vert", 
			x1b1ec609e70eb086.xb8e3e9a641be95c5 => "firstCol", 
			x1b1ec609e70eb086.x5d6d04c35215bc51 => "firstRow", 
			x1b1ec609e70eb086.xf59d22dcfa267bc1 => "lastCol", 
			x1b1ec609e70eb086.xbc3a1ad7f75a88f9 => "lastRow", 
			x1b1ec609e70eb086.xb43f8d5efcee0261 => "neCell", 
			x1b1ec609e70eb086.x95249c3688e883c5 => "nwCell", 
			x1b1ec609e70eb086.x6cecca56ca9d6ef2 => "seCell", 
			x1b1ec609e70eb086.x34f4bcb41a1eddcb => "swCell", 
			x1b1ec609e70eb086.xb0c74a540a258df5 => "wholeTable", 
			_ => "wholeTable", 
		};
	}

	internal static FontPitch x7ddd0b36cb2e685a(string xbcea506a33cf9111)
	{
		return (FontPitch)x682712679dbc585a.xce92de628aa023cf(xe49c14b143611f35, xbcea506a33cf9111, FontPitch.Default);
	}

	internal static string x24861a95aca39ef5(FontPitch xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(xff3ebdfb873687f6, xbcea506a33cf9111, "");
	}

	internal static xc51d0ca9388f31bd x4f0b2ccd78a77d6c(string xbcea506a33cf9111)
	{
		return (xc51d0ca9388f31bd)x682712679dbc585a.xce92de628aa023cf(x43c04799f6fc46cd, xbcea506a33cf9111, xc51d0ca9388f31bd.xa65184d44a47025b);
	}

	internal static string xeb27a86ee5c9f6a0(xc51d0ca9388f31bd xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x0c95dc2292557611, xbcea506a33cf9111, "");
	}

	internal static x8307b3d797c38a81 x6ab7e7d63afae45f(string xbcea506a33cf9111)
	{
		return (x8307b3d797c38a81)x682712679dbc585a.xce92de628aa023cf(x0d20ae342e6ff37a, xbcea506a33cf9111, x8307b3d797c38a81.xa65184d44a47025b);
	}

	internal static string xe1e700ad465a4394(x8307b3d797c38a81 xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(xc2a9433dcc285e3e, xbcea506a33cf9111, "");
	}

	internal static RelativeVerticalPosition xb26f8f5e78b630a9(string xbcea506a33cf9111, bool x48f1c6fc66ceb233)
	{
		return (RelativeVerticalPosition)x682712679dbc585a.xce92de628aa023cf(x7631e7053fead5d7, xbcea506a33cf9111, (!x48f1c6fc66ceb233) ? RelativeVerticalPosition.Paragraph : RelativeVerticalPosition.Margin);
	}

	internal static string xd28acd82ad3fd5e3(RelativeVerticalPosition xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x700a0c1ac37c805c, xbcea506a33cf9111, "");
	}

	internal static RelativeHorizontalPosition xcf7be470fced425c(string xbcea506a33cf9111)
	{
		return (RelativeHorizontalPosition)x682712679dbc585a.xce92de628aa023cf(x7660b2bbd0607e4f, xbcea506a33cf9111, RelativeHorizontalPosition.Column);
	}

	internal static string x14e082375ba0c07c(RelativeHorizontalPosition xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x238eae4ac21bd0fb, xbcea506a33cf9111, "");
	}

	internal static HorizontalAlignment x15b3d0aaa5b4546f(string xbcea506a33cf9111)
	{
		return (HorizontalAlignment)x682712679dbc585a.xce92de628aa023cf(xd3151b42e7d14c37, xbcea506a33cf9111, HorizontalAlignment.None);
	}

	internal static string x9617344359c63dd2(HorizontalAlignment xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(xf057f9c02feec50d, xbcea506a33cf9111, "");
	}

	internal static VerticalAlignment x130a3ebac2306cbd(string xbcea506a33cf9111)
	{
		return (VerticalAlignment)x682712679dbc585a.xce92de628aa023cf(xae1872c5eb9882c8, xbcea506a33cf9111, VerticalAlignment.None);
	}

	internal static string xf7b3d51063ad99cc(VerticalAlignment xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(xb12f6b492f47f35e, xbcea506a33cf9111, "");
	}

	internal static StyleIdentifier x3b3cea4656a2e16d(string xbcea506a33cf9111)
	{
		return (StyleIdentifier)x682712679dbc585a.xce92de628aa023cf(x93437a6c9d28ea77, xbcea506a33cf9111, StyleIdentifier.User);
	}

	internal static string x27d6a5b617edc9db(StyleIdentifier xe98722bc47ad3bb3, string xc6e85c82d0d89508)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x54e5870f9de97f85, xe98722bc47ad3bb3, xc6e85c82d0d89508);
	}

	internal static string xebaf9df1cc1ad15a(string xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x6ed3560115064f44, xbcea506a33cf9111, xbcea506a33cf9111);
	}

	internal static string x9f0d5871d8820eaa(string xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x3f0c300c9b8f8c84, xbcea506a33cf9111, xbcea506a33cf9111);
	}

	internal static x6cb5c57047e5f82d xe9e387051394a2ba(string xbcea506a33cf9111)
	{
		return (x6cb5c57047e5f82d)x682712679dbc585a.xce92de628aa023cf(x6fc25d5ad0e01d83, xbcea506a33cf9111, x6cb5c57047e5f82d.xc56403b89ed080af);
	}

	internal static string x485cb0bb4326c4bb(x6cb5c57047e5f82d xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x57e6d9d1690ffa72, xbcea506a33cf9111, "");
	}

	internal static PreferredWidthType xa0f6fd8a38cb6638(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"pct" => PreferredWidthType.Percent, 
			"dxa" => PreferredWidthType.Points, 
			"auto" => PreferredWidthType.Auto, 
			_ => PreferredWidthType.Auto, 
		};
	}

	internal static string xf2767340c03bd9ec(PreferredWidthType xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			PreferredWidthType.Percent => "pct", 
			PreferredWidthType.Points => "dxa", 
			PreferredWidthType.Auto => "auto", 
			_ => "", 
		};
	}

	internal static TextureIndex x1d3745571808912d(string xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case "clear":
			return TextureIndex.TextureNone;
		case "nil":
			return TextureIndex.TextureNil;
		case "solid":
			return TextureIndex.TextureSolid;
		case "horzStripe":
		case "horz-stripe":
			return TextureIndex.TextureDarkHorizontal;
		case "vertStripe":
		case "vert-stripe":
			return TextureIndex.TextureDarkVertical;
		case "reverseDiagStripe":
		case "reverse-diag-stripe":
			return TextureIndex.TextureDarkDiagonalDown;
		case "diagStripe":
		case "diag-stripe":
			return TextureIndex.TextureDarkDiagonalUp;
		case "horzCross":
		case "horz-cross":
			return TextureIndex.TextureDarkCross;
		case "diagCross":
		case "diag-cross":
			return TextureIndex.TextureDarkDiagonalCross;
		case "thinHorzStripe":
		case "thin-horz-stripe":
			return TextureIndex.TextureHorizontal;
		case "thinVertStripe":
		case "thin-vert-stripe":
			return TextureIndex.TextureVertical;
		case "thinReverseDiagStripe":
		case "thin-reverse-diag-stripe":
			return TextureIndex.TextureDiagonalDown;
		case "thinDiagStripe":
		case "thin-diag-stripe":
			return TextureIndex.TextureDiagonalUp;
		case "thinHorzCross":
		case "thin-horz-cross":
			return TextureIndex.TextureCross;
		case "thinDiagCross":
		case "thin-diag-cross":
			return TextureIndex.TextureDiagonalCross;
		case "pct5":
		case "pct-5":
			return TextureIndex.Texture5Percent;
		case "pct10":
		case "pct-10":
			return TextureIndex.Texture10Percent;
		case "pct12":
		case "pct-12":
			return TextureIndex.Texture12Pt5Percent;
		case "pct15":
		case "pct-15":
			return TextureIndex.Texture15Percent;
		case "pct20":
		case "pct-20":
			return TextureIndex.Texture20Percent;
		case "pct25":
		case "pct-25":
			return TextureIndex.Texture25Percent;
		case "pct30":
		case "pct-30":
			return TextureIndex.Texture30Percent;
		case "pct35":
		case "pct-35":
			return TextureIndex.Texture35Percent;
		case "pct37":
		case "pct-37":
			return TextureIndex.Texture37Pt5Percent;
		case "pct40":
		case "pct-40":
			return TextureIndex.Texture40Percent;
		case "pct45":
		case "pct-45":
			return TextureIndex.Texture45Percent;
		case "pct50":
		case "pct-50":
			return TextureIndex.Texture50Percent;
		case "pct55":
		case "pct-55":
			return TextureIndex.Texture55Percent;
		case "pct60":
		case "pct-60":
			return TextureIndex.Texture60Percent;
		case "pct62":
		case "pct-62":
			return TextureIndex.Texture62Pt5Percent;
		case "pct65":
		case "pct-65":
			return TextureIndex.Texture65Percent;
		case "pct70":
		case "pct-70":
			return TextureIndex.Texture70Percent;
		case "pct75":
		case "pct-75":
			return TextureIndex.Texture75Percent;
		case "pct80":
		case "pct-80":
			return TextureIndex.Texture80Percent;
		case "pct85":
		case "pct-85":
			return TextureIndex.Texture85Percent;
		case "pct87":
		case "pct-87":
			return TextureIndex.Texture87Pt5Percent;
		case "pct90":
		case "pct-90":
			return TextureIndex.Texture90Percent;
		case "pct95":
		case "pct-95":
			return TextureIndex.Texture95Percent;
		default:
			return TextureIndex.TextureNone;
		}
	}

	internal static string xb621a7efbad8540c(TextureIndex xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		switch (xbcea506a33cf9111)
		{
		case TextureIndex.TextureNone:
			return "clear";
		case TextureIndex.TextureNil:
			return "nil";
		case TextureIndex.TextureSolid:
			return "solid";
		case TextureIndex.TextureDarkHorizontal:
			if (!x5fbb1a9c98604ef5)
			{
				return "horz-stripe";
			}
			return "horzStripe";
		case TextureIndex.TextureDarkVertical:
			if (!x5fbb1a9c98604ef5)
			{
				return "vert-stripe";
			}
			return "vertStripe";
		case TextureIndex.TextureDarkDiagonalDown:
			if (!x5fbb1a9c98604ef5)
			{
				return "reverse-diag-stripe";
			}
			return "reverseDiagStripe";
		case TextureIndex.TextureDarkDiagonalUp:
			if (!x5fbb1a9c98604ef5)
			{
				return "diag-stripe";
			}
			return "diagStripe";
		case TextureIndex.TextureDarkCross:
			if (!x5fbb1a9c98604ef5)
			{
				return "horz-cross";
			}
			return "horzCross";
		case TextureIndex.TextureDarkDiagonalCross:
			if (!x5fbb1a9c98604ef5)
			{
				return "diag-cross";
			}
			return "diagCross";
		case TextureIndex.TextureHorizontal:
			if (!x5fbb1a9c98604ef5)
			{
				return "thin-horz-stripe";
			}
			return "thinHorzStripe";
		case TextureIndex.TextureVertical:
			if (!x5fbb1a9c98604ef5)
			{
				return "thin-vert-stripe";
			}
			return "thinVertStripe";
		case TextureIndex.TextureDiagonalDown:
			if (!x5fbb1a9c98604ef5)
			{
				return "thin-reverse-diag-stripe";
			}
			return "thinReverseDiagStripe";
		case TextureIndex.TextureDiagonalUp:
			if (!x5fbb1a9c98604ef5)
			{
				return "thin-diag-stripe";
			}
			return "thinDiagStripe";
		case TextureIndex.TextureCross:
			if (!x5fbb1a9c98604ef5)
			{
				return "thin-horz-cross";
			}
			return "thinHorzCross";
		case TextureIndex.TextureDiagonalCross:
			if (!x5fbb1a9c98604ef5)
			{
				return "thin-diag-cross";
			}
			return "thinDiagCross";
		case TextureIndex.Texture5Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-5";
			}
			return "pct5";
		case TextureIndex.Texture10Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-10";
			}
			return "pct10";
		case TextureIndex.Texture12Pt5Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-12";
			}
			return "pct12";
		case TextureIndex.Texture15Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-15";
			}
			return "pct15";
		case TextureIndex.Texture20Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-20";
			}
			return "pct20";
		case TextureIndex.Texture25Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-25";
			}
			return "pct25";
		case TextureIndex.Texture30Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-30";
			}
			return "pct30";
		case TextureIndex.Texture35Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-35";
			}
			return "pct35";
		case TextureIndex.Texture37Pt5Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-37";
			}
			return "pct37";
		case TextureIndex.Texture40Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-40";
			}
			return "pct40";
		case TextureIndex.Texture45Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-45";
			}
			return "pct45";
		case TextureIndex.Texture50Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-50";
			}
			return "pct50";
		case TextureIndex.Texture55Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-55";
			}
			return "pct55";
		case TextureIndex.Texture60Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-60";
			}
			return "pct60";
		case TextureIndex.Texture62Pt5Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-62";
			}
			return "pct62";
		case TextureIndex.Texture65Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-65";
			}
			return "pct65";
		case TextureIndex.Texture70Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-70";
			}
			return "pct70";
		case TextureIndex.Texture75Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-75";
			}
			return "pct75";
		case TextureIndex.Texture80Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-80";
			}
			return "pct80";
		case TextureIndex.Texture85Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-85";
			}
			return "pct85";
		case TextureIndex.Texture87Pt5Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-87";
			}
			return "pct87";
		case TextureIndex.Texture90Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-90";
			}
			return "pct90";
		case TextureIndex.Texture95Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-95";
			}
			return "pct95";
		case TextureIndex.Texture2Pt5Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-5";
			}
			return "pct5";
		case TextureIndex.Texture7Pt5Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-10";
			}
			return "pct10";
		case TextureIndex.Texture17Pt5Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-20";
			}
			return "pct20";
		case TextureIndex.Texture22Pt5Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-25";
			}
			return "pct25";
		case TextureIndex.Texture27Pt5Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-30";
			}
			return "pct30";
		case TextureIndex.Texture32Pt5Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-35";
			}
			return "pct35";
		case TextureIndex.Texture42Pt5Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-40";
			}
			return "pct40";
		case TextureIndex.Texture47Pt5Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-45";
			}
			return "pct45";
		case TextureIndex.Texture52Pt5Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-50";
			}
			return "pct50";
		case TextureIndex.Texture57Pt5Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-55";
			}
			return "pct55";
		case TextureIndex.Texture67Pt5Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-65";
			}
			return "pct65";
		case TextureIndex.Texture72Pt5Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-70";
			}
			return "pct70";
		case TextureIndex.Texture77Pt5Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-80";
			}
			return "pct80";
		case TextureIndex.Texture82Pt5Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-85";
			}
			return "pct85";
		case TextureIndex.Texture92Pt5Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-90";
			}
			return "pct90";
		case TextureIndex.Texture97Pt5Percent:
			if (!x5fbb1a9c98604ef5)
			{
				return "pct-95";
			}
			return "pct95";
		default:
			return "nil";
		}
	}

	internal static TextOrientation xa07e8cf04ba73040(string xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case "lr":
		case "btLr":
		case "bt-lr":
			return TextOrientation.Upward;
		case "tb":
		case "lrTb":
		case "lr-tb":
			return TextOrientation.Horizontal;
		case "tbV":
		case "lrTbV":
		case "lr-tb-v":
			return TextOrientation.HorizontalRotatedFarEast;
		case "rlV":
		case "tbRlV":
		case "tb-rl-v":
			return TextOrientation.VerticalFarEast;
		case "rl":
		case "tbRl":
		case "tb-rl":
			return TextOrientation.Downward;
		default:
			return TextOrientation.Horizontal;
		}
	}

	internal static string x5d29ab24a0be9aab(TextOrientation xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		switch (xbcea506a33cf9111)
		{
		case TextOrientation.Upward:
			if (!x5fbb1a9c98604ef5)
			{
				return "bt-lr";
			}
			return "btLr";
		case TextOrientation.Horizontal:
			if (!x5fbb1a9c98604ef5)
			{
				return "lr-tb";
			}
			return "lrTb";
		case TextOrientation.HorizontalRotatedFarEast:
			if (!x5fbb1a9c98604ef5)
			{
				return "lr-tb-v";
			}
			return "lrTbV";
		case TextOrientation.VerticalFarEast:
			if (!x5fbb1a9c98604ef5)
			{
				return "tb-rl-v";
			}
			return "tbRlV";
		case TextOrientation.Downward:
			if (!x5fbb1a9c98604ef5)
			{
				return "tb-rl";
			}
			return "tbRl";
		default:
			return "";
		}
	}

	internal static x9b603ddcf603293d x4ad35d0edf2d7b05(int xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			0 => x9b603ddcf603293d.x759aa16c2016a289, 
			1 => x9b603ddcf603293d.xb9715d2f06b63cf0, 
			2 => x9b603ddcf603293d.xc2d4efc42998d87b, 
			3 => x9b603ddcf603293d.x4c48a782e25bce54, 
			4 => x9b603ddcf603293d.xba0a9112ba3a76bf, 
			_ => x9b603ddcf603293d.xb9715d2f06b63cf0, 
		};
	}

	internal static int x217d731357ff3072(x9b603ddcf603293d xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			x9b603ddcf603293d.x759aa16c2016a289 => 0, 
			x9b603ddcf603293d.xc2d4efc42998d87b => 2, 
			x9b603ddcf603293d.x4c48a782e25bce54 => 3, 
			x9b603ddcf603293d.xba0a9112ba3a76bf => 4, 
			_ => 1, 
		};
	}

	static x72a0c846678ecaf9()
	{
		xe49c14b143611f35 = new Hashtable();
		xff3ebdfb873687f6 = new Hashtable();
		x43c04799f6fc46cd = new Hashtable();
		x0c95dc2292557611 = new Hashtable();
		x0d20ae342e6ff37a = new Hashtable();
		xc2a9433dcc285e3e = new Hashtable();
		x7631e7053fead5d7 = new Hashtable();
		x700a0c1ac37c805c = new Hashtable();
		x7660b2bbd0607e4f = new Hashtable();
		x238eae4ac21bd0fb = new Hashtable();
		xd3151b42e7d14c37 = new Hashtable();
		xf057f9c02feec50d = new Hashtable();
		xae1872c5eb9882c8 = new Hashtable();
		xb12f6b492f47f35e = new Hashtable();
		x93437a6c9d28ea77 = new Hashtable();
		x54e5870f9de97f85 = new Hashtable();
		x6ed3560115064f44 = new Hashtable();
		x3f0c300c9b8f8c84 = new Hashtable();
		x6fc25d5ad0e01d83 = new Hashtable();
		x57e6d9d1690ffa72 = new Hashtable();
		x682712679dbc585a.x70fa1602ceccddee(new object[6]
		{
			"default",
			FontPitch.Default,
			"fixed",
			FontPitch.Fixed,
			"variable",
			FontPitch.Variable
		}, xe49c14b143611f35, xff3ebdfb873687f6);
		x682712679dbc585a.x70fa1602ceccddee(new object[12]
		{
			"margin",
			xc51d0ca9388f31bd.x6545d1f2c1b77773,
			"page",
			xc51d0ca9388f31bd.xa65184d44a47025b,
			"outer-margin-area",
			xc51d0ca9388f31bd.x83872bdc36afd363,
			"inner-margin-area",
			xc51d0ca9388f31bd.xb4c1522a4ff754c9,
			"top-margin-area",
			xc51d0ca9388f31bd.xc07fe3840d9e6d76,
			"bottom-margin-area",
			xc51d0ca9388f31bd.x65011a5ae8c64a43
		}, x43c04799f6fc46cd, x0c95dc2292557611);
		x682712679dbc585a.x70fa1602ceccddee(new object[12]
		{
			"margin",
			x8307b3d797c38a81.x6545d1f2c1b77773,
			"page",
			x8307b3d797c38a81.xa65184d44a47025b,
			"outer-margin-area",
			x8307b3d797c38a81.x83872bdc36afd363,
			"inner-margin-area",
			x8307b3d797c38a81.xb4c1522a4ff754c9,
			"left-margin-area",
			x8307b3d797c38a81.xc8a7b7ce5c5279ee,
			"right-margin-area",
			x8307b3d797c38a81.x3fa6fa3075fd558f
		}, x0d20ae342e6ff37a, xc2a9433dcc285e3e);
		x682712679dbc585a.x70fa1602ceccddee(new object[16]
		{
			"margin",
			RelativeVerticalPosition.Margin,
			"page",
			RelativeVerticalPosition.Page,
			"text",
			RelativeVerticalPosition.Paragraph,
			"line",
			RelativeVerticalPosition.Line,
			"outer-margin-area",
			RelativeVerticalPosition.OutsideMargin,
			"inner-margin-area",
			RelativeVerticalPosition.InsideMargin,
			"top-margin-area",
			RelativeVerticalPosition.TopMargin,
			"bottom-margin-area",
			RelativeVerticalPosition.BottomMargin
		}, x7631e7053fead5d7, x700a0c1ac37c805c);
		x682712679dbc585a.x70fa1602ceccddee(new object[16]
		{
			"margin",
			RelativeHorizontalPosition.Margin,
			"page",
			RelativeHorizontalPosition.Page,
			"text",
			RelativeHorizontalPosition.Column,
			"char",
			RelativeHorizontalPosition.Character,
			"outer-margin-area",
			RelativeHorizontalPosition.OutsideMargin,
			"inner-margin-area",
			RelativeHorizontalPosition.InsideMargin,
			"left-margin-area",
			RelativeHorizontalPosition.LeftMargin,
			"right-margin-area",
			RelativeHorizontalPosition.RightMargin
		}, x7660b2bbd0607e4f, x238eae4ac21bd0fb);
		x682712679dbc585a.x70fa1602ceccddee(new object[12]
		{
			"absolute",
			HorizontalAlignment.None,
			"left",
			HorizontalAlignment.Left,
			"center",
			HorizontalAlignment.Center,
			"right",
			HorizontalAlignment.Right,
			"inside",
			HorizontalAlignment.Inside,
			"outside",
			HorizontalAlignment.Outside
		}, xd3151b42e7d14c37, xf057f9c02feec50d);
		x682712679dbc585a.x70fa1602ceccddee(new object[12]
		{
			"absolute",
			VerticalAlignment.None,
			"top",
			VerticalAlignment.Top,
			"center",
			VerticalAlignment.Center,
			"bottom",
			VerticalAlignment.Bottom,
			"inside",
			VerticalAlignment.Inside,
			"outside",
			VerticalAlignment.Outside
		}, xae1872c5eb9882c8, xb12f6b492f47f35e);
		x682712679dbc585a.x70fa1602ceccddee(new object[534]
		{
			"Book Title",
			StyleIdentifier.BookTitle,
			"annotation reference",
			StyleIdentifier.CommentReference,
			"Default Paragraph Font",
			StyleIdentifier.DefaultParagraphFont,
			"Emphasis",
			StyleIdentifier.Emphasis,
			"endnote reference",
			StyleIdentifier.EndnoteReference,
			"FollowedHyperlink",
			StyleIdentifier.FollowedHyperlink,
			"footnote reference",
			StyleIdentifier.FootnoteReference,
			"HTML Acronym",
			StyleIdentifier.HtmlAcronym,
			"HTML Cite",
			StyleIdentifier.HtmlCite,
			"HTML Code",
			StyleIdentifier.HtmlCode,
			"HTML Definition",
			StyleIdentifier.HtmlDefinition,
			"HTML Keyboard",
			StyleIdentifier.HtmlKeyboard,
			"HTML Sample",
			StyleIdentifier.HtmlSample,
			"HTML Typewriter",
			StyleIdentifier.HtmlTypewriter,
			"HTML Variable",
			StyleIdentifier.HtmlVariable,
			"Hyperlink",
			StyleIdentifier.Hyperlink,
			"Intense Emphasis",
			StyleIdentifier.IntenseEmphasis,
			"Intense Reference",
			StyleIdentifier.IntenseReference,
			"line number",
			StyleIdentifier.LineNumber,
			"page number",
			StyleIdentifier.PageNumber,
			"Placeholder Text",
			StyleIdentifier.PlaceholderText,
			"Strong",
			StyleIdentifier.Strong,
			"Subtle Emphasis",
			StyleIdentifier.SubtleEmphasis,
			"Subtle Reference",
			StyleIdentifier.SubtleReference,
			"Balloon Text",
			StyleIdentifier.BalloonText,
			"Body Text",
			StyleIdentifier.BodyText,
			"Body Text 2",
			StyleIdentifier.BodyText2,
			"Body Text 3",
			StyleIdentifier.BodyText3,
			"Body Text First Indent",
			StyleIdentifier.BodyText1I,
			"Body Text First Indent 2",
			StyleIdentifier.BodyText1I2,
			"Body Text Indent",
			StyleIdentifier.BodyTextInd,
			"Body Text Indent 2",
			StyleIdentifier.BodyTextInd2,
			"Body Text Indent 3",
			StyleIdentifier.BodyTextInd3,
			"Closing",
			StyleIdentifier.Closing,
			"annotation subject",
			StyleIdentifier.CommentSubject,
			"annotation text",
			StyleIdentifier.CommentText,
			"Date",
			StyleIdentifier.Date,
			"Document Map",
			StyleIdentifier.DocumentMap,
			"E-mail Signature",
			StyleIdentifier.EmailSignature,
			"endnote text",
			StyleIdentifier.EndnoteText,
			"footer",
			StyleIdentifier.Footer,
			"footnote text",
			StyleIdentifier.FootnoteText,
			"header",
			StyleIdentifier.Header,
			"heading 1",
			StyleIdentifier.Heading1,
			"heading 2",
			StyleIdentifier.Heading2,
			"heading 3",
			StyleIdentifier.Heading3,
			"heading 4",
			StyleIdentifier.Heading4,
			"heading 5",
			StyleIdentifier.Heading5,
			"heading 6",
			StyleIdentifier.Heading6,
			"heading 7",
			StyleIdentifier.Heading7,
			"heading 8",
			StyleIdentifier.Heading8,
			"heading 9",
			StyleIdentifier.Heading9,
			"HTML Address",
			StyleIdentifier.HtmlAddress,
			"HTML Bottom of Form",
			StyleIdentifier.HtmlBottomOfForm,
			"HTML Preformatted",
			StyleIdentifier.HtmlPreformatted,
			"HTML Top of Form",
			StyleIdentifier.HtmlTopOfForm,
			"Intense Quote",
			StyleIdentifier.IntenseQuote,
			"macro",
			StyleIdentifier.Macro,
			"Message Header",
			StyleIdentifier.MessageHeader,
			"note heading",
			StyleIdentifier.NoteHeading,
			"Plain Text",
			StyleIdentifier.PlainText,
			"Quote",
			StyleIdentifier.Quote,
			"Salutation",
			StyleIdentifier.Salutation,
			"Signature",
			StyleIdentifier.Signature,
			"Subtitle",
			StyleIdentifier.Subtitle,
			"Title",
			StyleIdentifier.Title,
			"Bibliography",
			StyleIdentifier.Bibliography,
			"Block Text",
			StyleIdentifier.BlockText,
			"caption",
			StyleIdentifier.Caption,
			"envelope address",
			StyleIdentifier.EnvelopeAddress,
			"envelope return",
			StyleIdentifier.EnvelopeReturn,
			"index 1",
			StyleIdentifier.Index1,
			"index 2",
			StyleIdentifier.Index2,
			"index 3",
			StyleIdentifier.Index3,
			"index 4",
			StyleIdentifier.Index4,
			"index 5",
			StyleIdentifier.Index5,
			"index 6",
			StyleIdentifier.Index6,
			"index 7",
			StyleIdentifier.Index7,
			"index 8",
			StyleIdentifier.Index8,
			"index 9",
			StyleIdentifier.Index9,
			"index heading",
			StyleIdentifier.IndexHeading,
			"List",
			StyleIdentifier.List,
			"List 2",
			StyleIdentifier.List2,
			"List 3",
			StyleIdentifier.List3,
			"List 4",
			StyleIdentifier.List4,
			"List 5",
			StyleIdentifier.List5,
			"List Bullet",
			StyleIdentifier.ListBullet,
			"List Bullet 2",
			StyleIdentifier.ListBullet2,
			"List Bullet 3",
			StyleIdentifier.ListBullet3,
			"List Bullet 4",
			StyleIdentifier.ListBullet4,
			"List Bullet 5",
			StyleIdentifier.ListBullet5,
			"List Continue",
			StyleIdentifier.ListContinue,
			"List Continue 2",
			StyleIdentifier.ListContinue2,
			"List Continue 3",
			StyleIdentifier.ListContinue3,
			"List Continue 4",
			StyleIdentifier.ListContinue4,
			"List Continue 5",
			StyleIdentifier.ListContinue5,
			"List Number",
			StyleIdentifier.ListNumber,
			"List Number 2",
			StyleIdentifier.ListNumber2,
			"List Number 3",
			StyleIdentifier.ListNumber3,
			"List Number 4",
			StyleIdentifier.ListNumber4,
			"List Number 5",
			StyleIdentifier.ListNumber5,
			"List Paragraph",
			StyleIdentifier.ListParagraph,
			"No Spacing",
			StyleIdentifier.NoSpacing,
			"Normal",
			StyleIdentifier.Normal,
			"Normal (Web)",
			StyleIdentifier.NormalWeb,
			"Normal Indent",
			StyleIdentifier.NormalIndent,
			"Revision",
			StyleIdentifier.Revision,
			"table of authorities",
			StyleIdentifier.TableOfAuthorities,
			"table of figures",
			StyleIdentifier.TableOfFigures,
			"toa heading",
			StyleIdentifier.ToaHeading,
			"toc 1",
			StyleIdentifier.Toc1,
			"toc 2",
			StyleIdentifier.Toc2,
			"toc 3",
			StyleIdentifier.Toc3,
			"toc 4",
			StyleIdentifier.Toc4,
			"toc 5",
			StyleIdentifier.Toc5,
			"toc 6",
			StyleIdentifier.Toc6,
			"toc 7",
			StyleIdentifier.Toc7,
			"toc 8",
			StyleIdentifier.Toc8,
			"toc 9",
			StyleIdentifier.Toc9,
			"TOC Heading",
			StyleIdentifier.TocHeading,
			"Outline List 1",
			StyleIdentifier.OutlineList1,
			"Outline List 2",
			StyleIdentifier.OutlineList2,
			"Outline List 3",
			StyleIdentifier.OutlineList3,
			"No List",
			StyleIdentifier.NoList,
			"Colorful Grid",
			StyleIdentifier.ColorfulGrid,
			"Colorful Grid Accent 1",
			StyleIdentifier.ColorfulGridAccent1,
			"Colorful Grid Accent 2",
			StyleIdentifier.ColorfulGridAccent2,
			"Colorful Grid Accent 3",
			StyleIdentifier.ColorfulGridAccent3,
			"Colorful Grid Accent 4",
			StyleIdentifier.ColorfulGridAccent4,
			"Colorful Grid Accent 5",
			StyleIdentifier.ColorfulGridAccent5,
			"Colorful Grid Accent 6",
			StyleIdentifier.ColorfulGridAccent6,
			"Colorful List",
			StyleIdentifier.ColorfulList,
			"Colorful List Accent 1",
			StyleIdentifier.ColorfulListAccent1,
			"Colorful List Accent 2",
			StyleIdentifier.ColorfulListAccent2,
			"Colorful List Accent 3",
			StyleIdentifier.ColorfulListAccent3,
			"Colorful List Accent 4",
			StyleIdentifier.ColorfulListAccent4,
			"Colorful List Accent 5",
			StyleIdentifier.ColorfulListAccent5,
			"Colorful List Accent 6",
			StyleIdentifier.ColorfulListAccent6,
			"Colorful Shading",
			StyleIdentifier.ColorfulShading,
			"Colorful Shading Accent 1",
			StyleIdentifier.ColorfulShadingAccent1,
			"Colorful Shading Accent 2",
			StyleIdentifier.ColorfulShadingAccent2,
			"Colorful Shading Accent 3",
			StyleIdentifier.ColorfulShadingAccent3,
			"Colorful Shading Accent 4",
			StyleIdentifier.ColorfulShadingAccent4,
			"Colorful Shading Accent 5",
			StyleIdentifier.ColorfulShadingAccent5,
			"Colorful Shading Accent 6",
			StyleIdentifier.ColorfulShadingAccent6,
			"Dark List",
			StyleIdentifier.DarkList,
			"Dark List Accent 1",
			StyleIdentifier.DarkListAccent1,
			"Dark List Accent 2",
			StyleIdentifier.DarkListAccent2,
			"Dark List Accent 3",
			StyleIdentifier.DarkListAccent3,
			"Dark List Accent 4",
			StyleIdentifier.DarkListAccent4,
			"Dark List Accent 5",
			StyleIdentifier.DarkListAccent5,
			"Dark List Accent 6",
			StyleIdentifier.DarkListAccent6,
			"Light Grid",
			StyleIdentifier.LightGrid,
			"Light Grid Accent 1",
			StyleIdentifier.LightGridAccent1,
			"Light Grid Accent 2",
			StyleIdentifier.LightGridAccent2,
			"Light Grid Accent 3",
			StyleIdentifier.LightGridAccent3,
			"Light Grid Accent 4",
			StyleIdentifier.LightGridAccent4,
			"Light Grid Accent 5",
			StyleIdentifier.LightGridAccent5,
			"Light Grid Accent 6",
			StyleIdentifier.LightGridAccent6,
			"Light List",
			StyleIdentifier.LightList,
			"Light List Accent 1",
			StyleIdentifier.LightListAccent1,
			"Light List Accent 2",
			StyleIdentifier.LightListAccent2,
			"Light List Accent 3",
			StyleIdentifier.LightListAccent3,
			"Light List Accent 4",
			StyleIdentifier.LightListAccent4,
			"Light List Accent 5",
			StyleIdentifier.LightListAccent5,
			"Light List Accent 6",
			StyleIdentifier.LightListAccent6,
			"Light Shading",
			StyleIdentifier.LightShading,
			"Light Shading Accent 1",
			StyleIdentifier.LightShadingAccent1,
			"Light Shading Accent 2",
			StyleIdentifier.LightShadingAccent2,
			"Light Shading Accent 3",
			StyleIdentifier.LightShadingAccent3,
			"Light Shading Accent 4",
			StyleIdentifier.LightShadingAccent4,
			"Light Shading Accent 5",
			StyleIdentifier.LightShadingAccent5,
			"Light Shading Accent 6",
			StyleIdentifier.LightShadingAccent6,
			"Medium Grid 1",
			StyleIdentifier.MediumGrid1,
			"Medium Grid 1 Accent 1",
			StyleIdentifier.MediumGrid1Accent1,
			"Medium Grid 1 Accent 2",
			StyleIdentifier.MediumGrid1Accent2,
			"Medium Grid 1 Accent 3",
			StyleIdentifier.MediumGrid1Accent3,
			"Medium Grid 1 Accent 4",
			StyleIdentifier.MediumGrid1Accent4,
			"Medium Grid 1 Accent 5",
			StyleIdentifier.MediumGrid1Accent5,
			"Medium Grid 1 Accent 6",
			StyleIdentifier.MediumGrid1Accent6,
			"Medium Grid 2",
			StyleIdentifier.MediumGrid2,
			"Medium Grid 2 Accent 1",
			StyleIdentifier.MediumGrid2Accent1,
			"Medium Grid 2 Accent 2",
			StyleIdentifier.MediumGrid2Accent2,
			"Medium Grid 2 Accent 3",
			StyleIdentifier.MediumGrid2Accent3,
			"Medium Grid 2 Accent 4",
			StyleIdentifier.MediumGrid2Accent4,
			"Medium Grid 2 Accent 5",
			StyleIdentifier.MediumGrid2Accent5,
			"Medium Grid 2 Accent 6",
			StyleIdentifier.MediumGrid2Accent6,
			"Medium Grid 3",
			StyleIdentifier.MediumGrid3,
			"Medium Grid 3 Accent 1",
			StyleIdentifier.MediumGrid3Accent1,
			"Medium Grid 3 Accent 2",
			StyleIdentifier.MediumGrid3Accent2,
			"Medium Grid 3 Accent 3",
			StyleIdentifier.MediumGrid3Accent3,
			"Medium Grid 3 Accent 4",
			StyleIdentifier.MediumGrid3Accent4,
			"Medium Grid 3 Accent 5",
			StyleIdentifier.MediumGrid3Accent5,
			"Medium Grid 3 Accent 6",
			StyleIdentifier.MediumGrid3Accent6,
			"Medium List 1",
			StyleIdentifier.MediumList1,
			"Medium List 1 Accent 1",
			StyleIdentifier.MediumList1Accent1,
			"Medium List 1 Accent 2",
			StyleIdentifier.MediumList1Accent2,
			"Medium List 1 Accent 3",
			StyleIdentifier.MediumList1Accent3,
			"Medium List 1 Accent 4",
			StyleIdentifier.MediumList1Accent4,
			"Medium List 1 Accent 5",
			StyleIdentifier.MediumList1Accent5,
			"Medium List 1 Accent 6",
			StyleIdentifier.MediumList1Accent6,
			"Medium List 2",
			StyleIdentifier.MediumList2,
			"Medium List 2 Accent 1",
			StyleIdentifier.MediumList2Accent1,
			"Medium List 2 Accent 2",
			StyleIdentifier.MediumList2Accent2,
			"Medium List 2 Accent 3",
			StyleIdentifier.MediumList2Accent3,
			"Medium List 2 Accent 4",
			StyleIdentifier.MediumList2Accent4,
			"Medium List 2 Accent 5",
			StyleIdentifier.MediumList2Accent5,
			"Medium List 2 Accent 6",
			StyleIdentifier.MediumList2Accent6,
			"Medium Shading 1",
			StyleIdentifier.MediumShading1,
			"Medium Shading 1 Accent 1",
			StyleIdentifier.MediumShading1Accent1,
			"Medium Shading 1 Accent 2",
			StyleIdentifier.MediumShading1Accent2,
			"Medium Shading 1 Accent 3",
			StyleIdentifier.MediumShading1Accent3,
			"Medium Shading 1 Accent 4",
			StyleIdentifier.MediumShading1Accent4,
			"Medium Shading 1 Accent 5",
			StyleIdentifier.MediumShading1Accent5,
			"Medium Shading 1 Accent 6",
			StyleIdentifier.MediumShading1Accent6,
			"Medium Shading 2",
			StyleIdentifier.MediumShading2,
			"Medium Shading 2 Accent 1",
			StyleIdentifier.MediumShading2Accent1,
			"Medium Shading 2 Accent 2",
			StyleIdentifier.MediumShading2Accent2,
			"Medium Shading 2 Accent 3",
			StyleIdentifier.MediumShading2Accent3,
			"Medium Shading 2 Accent 4",
			StyleIdentifier.MediumShading2Accent4,
			"Medium Shading 2 Accent 5",
			StyleIdentifier.MediumShading2Accent5,
			"Medium Shading 2 Accent 6",
			StyleIdentifier.MediumShading2Accent6,
			"Table 3D effects 1",
			StyleIdentifier.Table3DEffects1,
			"Table 3D effects 2",
			StyleIdentifier.Table3DEffects2,
			"Table 3D effects 3",
			StyleIdentifier.Table3DEffects3,
			"Table Classic 1",
			StyleIdentifier.TableClassic1,
			"Table Classic 2",
			StyleIdentifier.TableClassic2,
			"Table Classic 3",
			StyleIdentifier.TableClassic3,
			"Table Classic 4",
			StyleIdentifier.TableClassic4,
			"Table Colorful 1",
			StyleIdentifier.TableColorful1,
			"Table Colorful 2",
			StyleIdentifier.TableColorful2,
			"Table Colorful 3",
			StyleIdentifier.TableColorful3,
			"Table Columns 1",
			StyleIdentifier.TableColumns1,
			"Table Columns 2",
			StyleIdentifier.TableColumns2,
			"Table Columns 3",
			StyleIdentifier.TableColumns3,
			"Table Columns 4",
			StyleIdentifier.TableColumns4,
			"Table Columns 5",
			StyleIdentifier.TableColumns5,
			"Table Contemporary",
			StyleIdentifier.TableContemporary,
			"Table Elegant",
			StyleIdentifier.TableElegant,
			"Table Grid",
			StyleIdentifier.TableGrid,
			"Table Grid 1",
			StyleIdentifier.TableGrid1,
			"Table Grid 2",
			StyleIdentifier.TableGrid2,
			"Table Grid 3",
			StyleIdentifier.TableGrid3,
			"Table Grid 4",
			StyleIdentifier.TableGrid4,
			"Table Grid 5",
			StyleIdentifier.TableGrid5,
			"Table Grid 6",
			StyleIdentifier.TableGrid6,
			"Table Grid 7",
			StyleIdentifier.TableGrid7,
			"Table Grid 8",
			StyleIdentifier.TableGrid8,
			"Table List 1",
			StyleIdentifier.TableList1,
			"Table List 2",
			StyleIdentifier.TableList2,
			"Table List 3",
			StyleIdentifier.TableList3,
			"Table List 4",
			StyleIdentifier.TableList4,
			"Table List 5",
			StyleIdentifier.TableList5,
			"Table List 6",
			StyleIdentifier.TableList6,
			"Table List 7",
			StyleIdentifier.TableList7,
			"Table List 8",
			StyleIdentifier.TableList8,
			"Normal Table",
			StyleIdentifier.TableNormal,
			"Table Professional",
			StyleIdentifier.TableProfessional,
			"Table Simple 1",
			StyleIdentifier.TableSimple1,
			"Table Simple 2",
			StyleIdentifier.TableSimple2,
			"Table Simple 3",
			StyleIdentifier.TableSimple3,
			"Table Subtle 1",
			StyleIdentifier.TableSubtle1,
			"Table Subtle 2",
			StyleIdentifier.TableSubtle2,
			"Table Theme",
			StyleIdentifier.TableTheme,
			"Table Web 1",
			StyleIdentifier.TableWeb1,
			"Table Web 2",
			StyleIdentifier.TableWeb2,
			"Table Web 3",
			StyleIdentifier.TableWeb3
		}, x93437a6c9d28ea77, x54e5870f9de97f85);
		x682712679dbc585a.x70fa1602ceccddee(new object[102]
		{
			"annotation reference", "Comment Reference", "endnote reference", "Endnote Reference", "footnote reference", "Footnote Reference", "line number", "Line Number", "page number", "Page Number",
			"annotation subject", "Comment Subject", "annotation text", "Comment Text", "caption", "Caption", "endnote text", "Endnote Text", "envelope address", "Envelope Address",
			"envelope return", "Envelope Return", "footer", "Footer", "footnote text", "Footnote Text", "header", "Header", "heading 1", "Heading 1",
			"heading 2", "Heading 2", "heading 3", "Heading 3", "heading 4", "Heading 4", "heading 5", "Heading 5", "heading 6", "Heading 6",
			"heading 7", "Heading 7", "heading 8", "Heading 8", "heading 9", "Heading 9", "index 1", "Index 1", "index 2", "Index 2",
			"index 3", "Index 3", "index 4", "Index 4", "index 5", "Index 5", "index 6", "Index 6", "index 7", "Index 7",
			"index 8", "Index 8", "index 9", "Index 9", "index heading", "Index Heading", "macro", "Macro", "note heading", "Note Heading",
			"table of authorities", "Table of Authorities", "table of figures", "Table of Figures", "toa heading", "TOA Heading", "toc 1", "TOC 1", "toc 2", "TOC 2",
			"toc 3", "TOC 3", "toc 4", "TOC 4", "toc 5", "TOC 5", "toc 6", "TOC 6", "toc 7", "TOC 7",
			"toc 8", "TOC 8", "toc 9", "TOC 9", "Outline List 1", "1 / a / i", "Outline List 2", "1 / 1.1 / 1.1.1", "Outline List 3", "Article / Section",
			"Normal Table", "Table Normal"
		}, x6ed3560115064f44, x3f0c300c9b8f8c84);
		x682712679dbc585a.x70fa1602ceccddee(new object[22]
		{
			"1024x768",
			x6cb5c57047e5f82d.x9bfa98d2fd9492eb,
			"1152x882",
			x6cb5c57047e5f82d.xf5e03b08016e1774,
			"1152x900",
			x6cb5c57047e5f82d.x2d82eba67039056c,
			"1280x1024",
			x6cb5c57047e5f82d.x6d57044d1b931101,
			"1600x1200",
			x6cb5c57047e5f82d.xc2672a038fec6581,
			"1800x1440",
			x6cb5c57047e5f82d.x6c9eee545608f9a1,
			"1920x1200",
			x6cb5c57047e5f82d.x2ac6bb1cfe912286,
			"544x376",
			x6cb5c57047e5f82d.x97f71ae82f8ccd6e,
			"640x480",
			x6cb5c57047e5f82d.xc2be30fb37e3f948,
			"720x512",
			x6cb5c57047e5f82d.x9c923c25acc8c200,
			"800x600",
			x6cb5c57047e5f82d.xc56403b89ed080af
		}, x6fc25d5ad0e01d83, x57e6d9d1690ffa72);
	}
}
