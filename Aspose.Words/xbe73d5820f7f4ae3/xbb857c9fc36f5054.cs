using System;
using System.Text.RegularExpressions;
using Aspose.Words;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x28925c9b27b37a46;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;
using xfbd1009a0cbb9842;
using xfce5b6a304778b89;

namespace xbe73d5820f7f4ae3;

internal class xbb857c9fc36f5054
{
	private const int x98fbed6cd92562c1 = 3;

	private const double x7bdcb85b862e28ea = 20.0;

	public const double xa69b3db0ad6aea00 = 0.05;

	private const double xd99d81b53cde8cdd = 72.0;

	private const double x623644ea2fdab3f7 = 2.54;

	private const double x6610dd6aa57b6216 = 0.035277777777777776;

	private const double x120efb27e7b67d2c = 1440.0;

	internal const int xb5a99fa9616a578f = 31;

	internal const char x08b0bc3c07c24798 = '\u2061';

	internal const int xb6e16c89c2cfa185 = 500000;

	private static readonly char[] xf12627fc5d74f9bb = new char[36]
	{
		'\0', '\u0001', '\u0002', '\u0003', '\u0004', '\u0005', '\u0006', '\a', '\b', '\t',
		'\n', '\v', '\f', '\r', '\u000e', '\u000f', '\u0010', '\u0011', '\u0012', '\u0013',
		'\u0014', '\u0015', '\u0016', '\u0017', '\u0018', '\u0019', '\u001a', '\u001b', '\u001c', '\u001d',
		'\u001e', '\u001f', '"', '<', '>', '|'
	};

	private static readonly Regex xe3c82b990808b1fd = new Regex("[^_A-Za-zÀ-ÖØ-öø-ÿĀ-ıĴ-ľŁ-ňŊ-žƀ-ǃǍ-ǰǴ-ǵǺ-ȗɐ-ʨʻ-ˁΆΈ-ΊΌΎ-ΡΣ-ώϐ-ϖϚϜϞϠϢ-ϳЁ-ЌЎ-яё-ќў-ҁҐ-ӄӇ-ӈӋ-ӌӐ-ӫӮ-ӵӸ-ӹԱ-Ֆՙա-ֆא-תװ-ײء-غف-يٱ-ڷں-ھۀ-ێې-ۓەۥ-ۦअ-हऽक़-ॡঅ-ঌএ-ঐও-নপ-রলশ-হড়-ঢ়য়-ৡৰ-ৱਅ-ਊਏ-ਐਓ-ਨਪ-ਰਲ-ਲ਼ਵ-ਸ਼ਸ-ਹਖ਼-ੜਫ਼ੲ-ੴઅ-ઋઍએ-ઑઓ-નપ-રલ-ળવ-હઽૠଅ-ଌଏ-ଐଓ-ନପ-ରଲ-ଳଶ-ହଽଡ଼-ଢ଼ୟ-ୡஅ-ஊஎ-ஐஒ-கங-சஜஞ-டண-தந-பம-வஷ-ஹఅ-ఌఎ-ఐఒ-నప-ళవ-హౠ-ౡಅ-ಌಎ-ಐಒ-ನಪ-ಳವ-ಹೞೠ-ೡഅ-ഌഎ-ഐഒ-നപ-ഹൠ-ൡก-ฮะา-ำเ-ๅກ-ຂຄງ-ຈຊຍດ-ທນ-ຟມ-ຣລວສ-ຫອ-ຮະາ-ຳຽເ-ໄཀ-ཇཉ-ཀྵႠ-Ⴥა-ჶᄀᄂ-ᄃᄅ-ᄇᄉᄋ-ᄌᄎ-ᄒᄼᄾᅀᅌᅎᅐᅔ-ᅕᅙᅟ-ᅡᅣᅥᅧᅩᅭ-ᅮᅲ-ᅳᅵᆞᆨᆫᆮ-ᆯᆷ-ᆸᆺᆼ-ᇂᇫᇰᇹḀ-ẛẠ-ỹἀ-ἕἘ-Ἕἠ-ὅὈ-Ὅὐ-ὗὙὛὝὟ-ώᾀ-ᾴᾶ-ᾼιῂ-ῄῆ-ῌῐ-ΐῖ-Ίῠ-Ῥῲ-ῴῶ-ῼΩK-Å℮ↀ-ↂぁ-ゔァ-ヺㄅ-ㄬ가-힣一-龥〇〡-〩]");

	private static readonly Regex xc90bd0b6bcc527ad = new Regex("[^\\.\\-_A-Za-zÀ-ÖØ-öø-ÿĀ-ıĴ-ľŁ-ňŊ-žƀ-ǃǍ-ǰǴ-ǵǺ-ȗɐ-ʨʻ-ˁΆΈ-ΊΌΎ-ΡΣ-ώϐ-ϖϚϜϞϠϢ-ϳЁ-ЌЎ-яё-ќў-ҁҐ-ӄӇ-ӈӋ-ӌӐ-ӫӮ-ӵӸ-ӹԱ-Ֆՙա-ֆא-תװ-ײء-غف-يٱ-ڷں-ھۀ-ێې-ۓەۥ-ۦअ-हऽक़-ॡঅ-ঌএ-ঐও-নপ-রলশ-হড়-ঢ়য়-ৡৰ-ৱਅ-ਊਏ-ਐਓ-ਨਪ-ਰਲ-ਲ਼ਵ-ਸ਼ਸ-ਹਖ਼-ੜਫ਼ੲ-ੴઅ-ઋઍએ-ઑઓ-નપ-રલ-ળવ-હઽૠଅ-ଌଏ-ଐଓ-ନପ-ରଲ-ଳଶ-ହଽଡ଼-ଢ଼ୟ-ୡஅ-ஊஎ-ஐஒ-கங-சஜஞ-டண-தந-பம-வஷ-ஹఅ-ఌఎ-ఐఒ-నప-ళవ-హౠ-ౡಅ-ಌಎ-ಐಒ-ನಪ-ಳವ-ಹೞೠ-ೡഅ-ഌഎ-ഐഒ-നപ-ഹൠ-ൡก-ฮะา-ำเ-ๅກ-ຂຄງ-ຈຊຍດ-ທນ-ຟມ-ຣລວສ-ຫອ-ຮະາ-ຳຽເ-ໄཀ-ཇཉ-ཀྵႠ-Ⴥა-ჶᄀᄂ-ᄃᄅ-ᄇᄉᄋ-ᄌᄎ-ᄒᄼᄾᅀᅌᅎᅐᅔ-ᅕᅙᅟ-ᅡᅣᅥᅧᅩᅭ-ᅮᅲ-ᅳᅵᆞᆨᆫᆮ-ᆯᆷ-ᆸᆺᆼ-ᇂᇫᇰᇹḀ-ẛẠ-ỹἀ-ἕἘ-Ἕἠ-ὅὈ-Ὅὐ-ὗὙὛὝὟ-ώᾀ-ᾴᾶ-ᾼιῂ-ῄῆ-ῌῐ-ΐῖ-Ίῠ-Ῥῲ-ῴῶ-ῼΩK-Å℮ↀ-ↂぁ-ゔァ-ヺㄅ-ㄬ가-힣一-龥〇〡-〩0-9٠-٩۰-۹०-९০-৯੦-੯૦-૯୦-୯௧-௯౦-౯೦-೯൦-൯๐-๙໐-໙༠-༩\u0300-\u0345\u0360-\u0361\u0483-\u0486\u0591-\u05a1\u05a3-\u05b9\u05bb-\u05bd\u05bf\u05c1-\u05c2\u05c4\u064b-\u0652\u0670\u06d6-\u06dc\u06dd-\u06df\u06e0-\u06e4\u06e7-\u06e8\u06ea-\u06ed\u0901-\u0903\u093c\u093e-\u094c\u094d\u0951-\u0954\u0962-\u0963\u0981-\u0983\u09bc\u09be\u09bf\u09c0-\u09c4\u09c7-\u09c8\u09cb-\u09cd\u09d7\u09e2-\u09e3\u0a02\u0a3c\u0a3e\u0a3f\u0a40-\u0a42\u0a47-\u0a48\u0a4b-\u0a4d\u0a70-\u0a71\u0a81-\u0a83\u0abc\u0abe-\u0ac5\u0ac7-\u0ac9\u0acb-\u0acd\u0b01-\u0b03\u0b3c\u0b3e-\u0b43\u0b47-\u0b48\u0b4b-\u0b4d\u0b56-\u0b57\u0b82-ஃ\u0bbe-\u0bc2\u0bc6-\u0bc8\u0bca-\u0bcd\u0bd7\u0c01-\u0c03\u0c3e-\u0c44\u0c46-\u0c48\u0c4a-\u0c4d\u0c55-\u0c56\u0c82-\u0c83\u0cbe-\u0cc4\u0cc6-\u0cc8\u0cca-\u0ccd\u0cd5-\u0cd6\u0d02-\u0d03\u0d3e-\u0d43\u0d46-\u0d48\u0d4a-\u0d4d\u0d57\u0e31\u0e34-\u0e3a\u0e47-\u0e4e\u0eb1\u0eb4-\u0eb9\u0ebb-\u0ebc\u0ec8-\u0ecd\u0f18-\u0f19\u0f35\u0f37\u0f39\u0f3e\u0f3f\u0f71-\u0f84\u0f86-ྋ\u0f90-\u0f95\u0f97\u0f99-\u0fad\u0fb1-\u0fb7\u0fb9\u20d0-\u20dc\u20e1\u302a-\u302f\u3099\u309a·ːˑ·ـๆໆ々〱-〵ゝ-ゞー-ヾ]");

	private static readonly Regex x0ab03dd91c659e42 = new Regex("_[0-9A-Fa-f]{1,4}_");

	private static readonly char[] x12241a8a239bd885 = new char[2] { '\\', '/' };

	private static double xc0c2b1fbb0239ad3 = 1.0;

	public static double xcbe65b21f4ea2cf5
	{
		get
		{
			return xc0c2b1fbb0239ad3;
		}
		set
		{
			xc0c2b1fbb0239ad3 = value;
		}
	}

	internal static int x01c5989f49b62737(int x3ddf36d606250c6f)
	{
		return (int)((double)x3ddf36d606250c6f * xcbe65b21f4ea2cf5);
	}

	internal static void x943cf6ea563cd0a9(int x9b0739496f8b5475, int x4d5aabc7a55b12ba)
	{
		int num = ((x9b0739496f8b5475 < x4d5aabc7a55b12ba) ? x9b0739496f8b5475 : x4d5aabc7a55b12ba);
		if (num == 0)
		{
			xc0c2b1fbb0239ad3 = 1.0;
		}
		else
		{
			xc0c2b1fbb0239ad3 = 1000000 / num;
		}
	}

	internal static bool x67ec5097b5f33a4e(int x9b0739496f8b5475, int x4d5aabc7a55b12ba)
	{
		if (x9b0739496f8b5475 > 0 && x4d5aabc7a55b12ba > 0)
		{
			if (x9b0739496f8b5475 >= 500000)
			{
				return x4d5aabc7a55b12ba < 500000;
			}
			return true;
		}
		return false;
	}

	internal static string xed668dab87818d34(int xbcea506a33cf9111)
	{
		double num = x4574ea26106f0edb.x97ab502db0c0e5c2(xbcea506a33cf9111) + (double)((xbcea506a33cf9111 < 0) ? 180 : 0);
		return xca004f56614e2431.xcadee4aea45827c2(num % 360.0 * 10.0);
	}

	internal static string xbbf121f4b9daf886(int xbcea506a33cf9111)
	{
		return xca004f56614e2431.xcadee4aea45827c2(x4574ea26106f0edb.x97ab502db0c0e5c2(xbcea506a33cf9111));
	}

	internal static int x0de3a17de401c0aa(string xbcea506a33cf9111)
	{
		return x4574ea26106f0edb.x091b250f00534aae(xca004f56614e2431.xec25d08a2af152f0(xbcea506a33cf9111));
	}

	internal static int xba31f88211ebd926(string xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111.EndsWith("grad"))
		{
			return x4574ea26106f0edb.x091b250f00534aae(xca004f56614e2431.xec25d08a2af152f0(xbcea506a33cf9111.Replace("grad", "")) * 0.9);
		}
		if (xbcea506a33cf9111.EndsWith("rad"))
		{
			return x4574ea26106f0edb.x091b250f00534aae(xca004f56614e2431.xec25d08a2af152f0(xbcea506a33cf9111.Replace("rad", "")) * 180.0 / Math.PI);
		}
		if (xbcea506a33cf9111.EndsWith("deg"))
		{
			return x0de3a17de401c0aa(xbcea506a33cf9111.Replace("deg", ""));
		}
		return x0de3a17de401c0aa(xbcea506a33cf9111);
	}

	internal static string xa605a684cfdf1a39(x84bbacdc1fc0efd2 xd4449dd234838d4a)
	{
		if (xd4449dd234838d4a.xea9485ec61071863 == LineSpacingRule.Multiple)
		{
			return $"{xca004f56614e2431.xcaaeec2e96b2cecc(Math.Round(x4574ea26106f0edb.x984bdd10255a33a5(xd4449dd234838d4a.xd2f68ee6f47e9dfb) * 100.0))}%";
		}
		return xf7c347cb12d2a63f(xd4449dd234838d4a.xd2f68ee6f47e9dfb);
	}

	internal static string x193fd22ffbc988d7(string xaf83c07388415ce8, string x5f9c2fff5fcaeab9)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xaf83c07388415ce8))
		{
			int num = xaf83c07388415ce8.IndexOf(x5f9c2fff5fcaeab9);
			if (num != -1)
			{
				num = xaf83c07388415ce8.IndexOf(x5f9c2fff5fcaeab9) + x5f9c2fff5fcaeab9.Length;
				int num2 = xaf83c07388415ce8.IndexOf("\\", num);
				num2 = ((num2 != -1) ? num2 : xaf83c07388415ce8.Length);
				return xaf83c07388415ce8.Substring(num, num2 - num).Trim(' ');
			}
		}
		return "";
	}

	internal static string x647b56f7b5fd15df(string xaf83c07388415ce8)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xaf83c07388415ce8))
		{
			int num = xaf83c07388415ce8.IndexOf("SEQ");
			if (num != -1)
			{
				xaf83c07388415ce8 = xaf83c07388415ce8.Substring(num + 3).Trim(' ');
				int num2 = xaf83c07388415ce8.IndexOf("\\");
				return xaf83c07388415ce8[..((num2 != -1) ? num2 : xaf83c07388415ce8.Length)].Trim(' ');
			}
		}
		return "";
	}

	internal static string x63b8eaab6cf477b8(string xaf83c07388415ce8)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xaf83c07388415ce8))
		{
			int num = xaf83c07388415ce8.IndexOf("DOCPROPERTY");
			if (num != -1)
			{
				xaf83c07388415ce8 = xaf83c07388415ce8.Substring(num + 11);
				int num2 = xaf83c07388415ce8.IndexOf("\\");
				return xaf83c07388415ce8[..((num2 != -1) ? num2 : xaf83c07388415ce8.Length)].Trim(' ');
			}
		}
		return "";
	}

	internal static string xddab5435c09fa2e9(string xaf83c07388415ce8)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xaf83c07388415ce8))
		{
			int num = xaf83c07388415ce8.IndexOf("SET ");
			if (num != -1)
			{
				xaf83c07388415ce8 = xaf83c07388415ce8.Substring(num + 4).Trim(' ');
				int num2 = xaf83c07388415ce8.IndexOf("\"");
				if (num2 == -1)
				{
					num2 = xaf83c07388415ce8.IndexOf(" ");
				}
				return xaf83c07388415ce8[..((num2 != -1) ? num2 : xaf83c07388415ce8.Length)].Trim(' ').Trim('"');
			}
		}
		return "";
	}

	internal static string x52eb04ee57ce90fb(string xaf83c07388415ce8, string x35ee15efb8ad0ef3)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xaf83c07388415ce8))
		{
			int num = xaf83c07388415ce8.IndexOf(x35ee15efb8ad0ef3);
			if (num != -1)
			{
				num += x35ee15efb8ad0ef3.Length;
				num = ((xaf83c07388415ce8.IndexOf("\"", num) == -1) ? xaf83c07388415ce8.IndexOf(" ", num) : xaf83c07388415ce8.IndexOf("\"", num));
				if (num != -1)
				{
					num++;
					int num2 = xaf83c07388415ce8.IndexOf("\"", num);
					if (num2 == -1)
					{
						num2 = xaf83c07388415ce8.IndexOf(" ", num);
					}
					num2 = ((num2 != -1) ? num2 : xaf83c07388415ce8.Length);
					int length = num2 - num;
					return xaf83c07388415ce8.Substring(num, length);
				}
			}
		}
		return "";
	}

	internal static string x804cfca39e340742(string xaf83c07388415ce8)
	{
		if (xaf83c07388415ce8.IndexOf("\\*") == -1)
		{
			return null;
		}
		if (xaf83c07388415ce8.IndexOf("ROMAN") != -1)
		{
			return "I";
		}
		if (xaf83c07388415ce8.IndexOf("roman") != -1)
		{
			return "i";
		}
		if (xaf83c07388415ce8.IndexOf("ALPHABETIC") != -1)
		{
			return "A";
		}
		if (xaf83c07388415ce8.IndexOf("alphabetic") != -1)
		{
			return "a";
		}
		return null;
	}

	internal static string xfc7542210cd3a6d0(string x462e8a703d817fb4)
	{
		return x462e8a703d817fb4 switch
		{
			"I" => " \\* ROMAN", 
			"i" => " \\* roman", 
			"A" => " \\* ALPHABETIC", 
			"a" => " \\* alphabetic", 
			_ => null, 
		};
	}

	internal static string x38937d073af5b8ce(string xaf83c07388415ce8)
	{
		if (xaf83c07388415ce8.IndexOf(" \\p ") != -1)
		{
			return "full";
		}
		return "name-and-extension";
	}

	internal static string x1df4eb4d918afe39(string x5cae0492911d7291)
	{
		string text;
		switch (x5cae0492911d7291)
		{
		case "path":
		case "full":
			text = "p";
			break;
		default:
			text = null;
			break;
		}
		if (text == null)
		{
			return "FILENAME";
		}
		return $"FILENAME \\* \\{text} \\*";
	}

	internal static string xe4dd84dcf5c200e3(string xaf83c07388415ce8)
	{
		int num = xaf83c07388415ce8.IndexOf("\\@");
		if (num != -1)
		{
			num = xaf83c07388415ce8.IndexOf("\"", num) + 1;
			if (num != -1)
			{
				int num2 = xaf83c07388415ce8.IndexOf("\"", num);
				if (num2 != -1)
				{
					return xaf83c07388415ce8.Substring(num, num2 - num);
				}
			}
		}
		return null;
	}

	internal static string xdea0334fd6e45e77(int xda7470de00544675)
	{
		double num = ImageData.x7186d4360cc84539(x4574ea26106f0edb.x97ab502db0c0e5c2(xda7470de00544675));
		return x6331f63fc81621fc((num - 0.5) * 2.0);
	}

	internal static int x668697ef5336f8da(string xe0823d4917f61c6e)
	{
		return x4574ea26106f0edb.x091b250f00534aae(ImageData.x9db0f77f74058bc0(xdd9ea485d8a07268(xe0823d4917f61c6e) / 2.0 + 0.5));
	}

	internal static string x21d48ebe1add36d7(int x528613f12ef1826d)
	{
		return x6331f63fc81621fc(x4574ea26106f0edb.x97ab502db0c0e5c2(x528613f12ef1826d * 2));
	}

	internal static int x88b59025a8c57163(string x77e9e292b17e383d)
	{
		return x4574ea26106f0edb.x091b250f00534aae(xdd9ea485d8a07268(x77e9e292b17e383d) / 2.0);
	}

	internal static string x663fc381a64fb64e(int xbcea506a33cf9111)
	{
		return x6331f63fc81621fc(x4574ea26106f0edb.x97ab502db0c0e5c2(xbcea506a33cf9111));
	}

	internal static int x5ea2f04c5aa3dba5(string xbcea506a33cf9111)
	{
		return x4574ea26106f0edb.x091b250f00534aae(xdd9ea485d8a07268(xbcea506a33cf9111));
	}

	private static string x6331f63fc81621fc(double xbcea506a33cf9111)
	{
		return xca004f56614e2431.xcaaeec2e96b2cecc(Math.Round(xbcea506a33cf9111 * 100.0)) + "%";
	}

	private static double xdd9ea485d8a07268(string xbcea506a33cf9111)
	{
		return xca004f56614e2431.xec25d08a2af152f0(xbcea506a33cf9111.Replace("%", "")) / 100.0;
	}

	internal static string xf586fbfc0fd54b15(int xf25c307f755b14b5, double x78ea5def0e155983)
	{
		return x34bdf37bc4f6368b(x177d5a45097c761a(xf25c307f755b14b5, x78ea5def0e155983));
	}

	private static double x177d5a45097c761a(int xf25c307f755b14b5, double x78ea5def0e155983)
	{
		return x658344ad68429ed9(xf25c307f755b14b5) - x6a2cd7b6d4dbe0bb(x78ea5def0e155983);
	}

	internal static int x286c839093f58b61(double x3677e5532eb051a7)
	{
		return x15e971129fd80714.x43fcc3f62534530b(x3677e5532eb051a7 * 1440.0 / 2.54);
	}

	private static int x2ed99fbbe2cc9f6e(double x4c0995e14230cac8)
	{
		return x15e971129fd80714.x43fcc3f62534530b(x4c0995e14230cac8 * 1440.0);
	}

	internal static string xf7c347cb12d2a63f(object x8fe80494f08d9930)
	{
		return x34bdf37bc4f6368b(x658344ad68429ed9((int)x8fe80494f08d9930));
	}

	internal static int x30490843b282206a(string x301bce9417b7598c)
	{
		if (!xd1ddac1c3a154564(x301bce9417b7598c))
		{
			return 0;
		}
		double num = xc93d98c550d1261e(x301bce9417b7598c);
		return xed77df7e9d43a06a(x301bce9417b7598c) switch
		{
			"in" => x2ed99fbbe2cc9f6e(num), 
			"pt" => x4574ea26106f0edb.x88bf16f2386d633e(num), 
			"cm" => x286c839093f58b61(num), 
			_ => x286c839093f58b61(num / 10.0), 
		};
	}

	internal static double x85ddf5f63df4b542(string x301bce9417b7598c)
	{
		if (!xd1ddac1c3a154564(x301bce9417b7598c))
		{
			return 0.0;
		}
		double num = xc93d98c550d1261e(x301bce9417b7598c);
		return xed77df7e9d43a06a(x301bce9417b7598c) switch
		{
			"in" => num * 2.54, 
			"pt" => num * 0.035277777777777776, 
			"cm" => num, 
			_ => num / 10.0, 
		};
	}

	internal static bool xd1ddac1c3a154564(string x301bce9417b7598c)
	{
		if (!x301bce9417b7598c.EndsWith("cm") && !x301bce9417b7598c.EndsWith("in") && !x301bce9417b7598c.EndsWith("mm"))
		{
			return x301bce9417b7598c.EndsWith("pt");
		}
		return true;
	}

	internal static string xed77df7e9d43a06a(string x301bce9417b7598c)
	{
		return x301bce9417b7598c.Substring(x301bce9417b7598c.Length - 2, 2);
	}

	internal static double xc93d98c550d1261e(string x301bce9417b7598c)
	{
		return xca004f56614e2431.xec25d08a2af152f0(x301bce9417b7598c.Substring(0, x301bce9417b7598c.Length - 2));
	}

	internal static double xc42baa2576960ea5(string x301bce9417b7598c)
	{
		if (!xd1ddac1c3a154564(x301bce9417b7598c))
		{
			return 0.0;
		}
		double num = xc93d98c550d1261e(x301bce9417b7598c);
		return xed77df7e9d43a06a(x301bce9417b7598c) switch
		{
			"in" => x4574ea26106f0edb.x9adffc4de2e5ac97(num), 
			"mm" => x4574ea26106f0edb.x5612f4c9f83f95d3(num), 
			"pt" => num, 
			_ => x7ee6ab51d3d84831(num), 
		};
	}

	internal static string x96d7e563211411f6(double x7452baaa0eb3ce15)
	{
		return x34bdf37bc4f6368b(x6a2cd7b6d4dbe0bb(x7452baaa0eb3ce15));
	}

	internal static double x6a2cd7b6d4dbe0bb(double x7452baaa0eb3ce15)
	{
		return Math.Round(x7452baaa0eb3ce15 * 2.54 / 72.0, 3);
	}

	internal static double x658344ad68429ed9(int x8fe80494f08d9930)
	{
		return Math.Round((double)x8fe80494f08d9930 * 2.54 / 1440.0, 3);
	}

	internal static double x7ee6ab51d3d84831(double x3677e5532eb051a7)
	{
		return x3677e5532eb051a7 * 72.0 / 2.54;
	}

	internal static int x88bf16f2386d633e(double x6fa2570084b2ad39)
	{
		return x15e971129fd80714.x43fcc3f62534530b(x6fa2570084b2ad39 * 20.0);
	}

	internal static double x0e1fdb362561ddb2(int xf6495da3f9ed2d9c)
	{
		return (double)xf6495da3f9ed2d9c * 0.05;
	}

	internal static int x65e9699e8d18e38e(double x3677e5532eb051a7)
	{
		return x4574ea26106f0edb.x274b3224606757b0(x286c839093f58b61(x3677e5532eb051a7));
	}

	internal static int x1afdf740c9c6af9e(string xb7df0eda23e8e091)
	{
		if (x20cfc521944513f8(xb7df0eda23e8e091))
		{
			return x4574ea26106f0edb.x88bf16f2386d633e(x4574ea26106f0edb.xefebf4e0a5cd9e91(1.0));
		}
		if (xb7df0eda23e8e091.EndsWith("%"))
		{
			return x4574ea26106f0edb.x88bf16f2386d633e(x4574ea26106f0edb.xefebf4e0a5cd9e91(xca004f56614e2431.xec25d08a2af152f0(xb7df0eda23e8e091.Replace("%", "")) / 100.0));
		}
		return x30490843b282206a(xb7df0eda23e8e091);
	}

	internal static string x34bdf37bc4f6368b(double x3677e5532eb051a7)
	{
		return $"{xca004f56614e2431.xcaaeec2e96b2cecc(Math.Round(x3677e5532eb051a7, 3))}cm";
	}

	internal static int xdea5d4100fe5f461(string xbcea506a33cf9111)
	{
		return x4574ea26106f0edb.x3aa08882c9feaf96(xc42baa2576960ea5(xbcea506a33cf9111));
	}

	internal static string xacaf194810069dc6(int xbcea506a33cf9111)
	{
		return x96d7e563211411f6(x4574ea26106f0edb.xa23e6b6c3169521d(xbcea506a33cf9111));
	}

	internal static string x6ce75fc371bd36a0(int xf25c307f755b14b5, Border x14cf9593b86ecbaa)
	{
		double num = x658344ad68429ed9(xf25c307f755b14b5);
		double num2 = 0.0;
		double num3 = 0.0;
		if (x14cf9593b86ecbaa != null)
		{
			num2 = x177d5a45097c761a(xf25c307f755b14b5, x14cf9593b86ecbaa.x1f2d5df87a5c4f81);
			num3 = x6a2cd7b6d4dbe0bb(x14cf9593b86ecbaa.LineWidth);
		}
		return x34bdf37bc4f6368b(num - num2 - num3);
	}

	internal static string x7006e2fd50829e4a(Border x14cf9593b86ecbaa, bool x2b818897b65c872e)
	{
		if (x14cf9593b86ecbaa == null || !x14cf9593b86ecbaa.IsVisible)
		{
			if (!x2b818897b65c872e)
			{
				return "none";
			}
			return null;
		}
		x26d9ecb4bdf0456d x26d9ecb4bdf0456d = x14cf9593b86ecbaa.x63b1a7c31a962459;
		if (x26d9ecb4bdf0456d.x7149c962c02931b3)
		{
			x26d9ecb4bdf0456d = x26d9ecb4bdf0456d.x89fffa2751fdecbe;
		}
		string text = x5de8b3baf75f4df6(x26d9ecb4bdf0456d);
		return string.Format("{0}{1}{2} {3}", text, (text != "") ? " " : "", x14cf9593b86ecbaa.xbca512cb9f5a451a ? "0.002cm" : x96d7e563211411f6(x74060b9a671b9ca3(x14cf9593b86ecbaa.LineStyle, x14cf9593b86ecbaa.xab266ea415f07c09)), x0eb9a864413f34de.x6e755b88613727d8(x14cf9593b86ecbaa.LineStyle));
	}

	internal static double x74060b9a671b9ca3(LineStyle x26516bbd7ae94699, int xa61fb2408a8e1af1)
	{
		double num = x4574ea26106f0edb.x30719d7103d96aa2(xa61fb2408a8e1af1);
		switch (x26516bbd7ae94699)
		{
		case LineStyle.Double:
			return num * 3.0;
		case LineStyle.Triple:
			return num * 5.0;
		case LineStyle.ThinThickSmallGap:
		case LineStyle.ThickThinSmallGap:
			return num * 2.5;
		case LineStyle.ThinThickMediumGap:
		case LineStyle.ThickThinMediumGap:
			return num * 2.0;
		case LineStyle.ThinThickLargeGap:
		case LineStyle.ThickThinLargeGap:
			return num * 3.25;
		case LineStyle.ThinThickThinSmallGap:
			return num * 1.5;
		case LineStyle.ThinThickThinMediumGap:
			return num * 3.0;
		case LineStyle.ThinThickThinLargeGap:
			return num * 3.0;
		case LineStyle.Emboss3D:
		case LineStyle.Engrave3D:
			return num * 1.5;
		case LineStyle.Wave:
			return num * 3.0;
		case LineStyle.DoubleWave:
			return num * 5.0;
		default:
			return num;
		}
	}

	internal static int xb6d2cca5c1ea6936(Border x14cf9593b86ecbaa, double x4935b962725f7750)
	{
		double x3677e5532eb051a;
		switch (x14cf9593b86ecbaa.LineStyle)
		{
		case LineStyle.Double:
			x3677e5532eb051a = x4935b962725f7750 / 3.0;
			break;
		case LineStyle.Triple:
			x3677e5532eb051a = x4935b962725f7750 / 5.0;
			break;
		case LineStyle.ThinThickSmallGap:
		case LineStyle.ThickThinSmallGap:
			x3677e5532eb051a = x4935b962725f7750 / 2.5;
			break;
		case LineStyle.ThinThickMediumGap:
		case LineStyle.ThickThinMediumGap:
			x3677e5532eb051a = x4935b962725f7750 / 2.0;
			break;
		case LineStyle.ThinThickLargeGap:
		case LineStyle.ThickThinLargeGap:
			x3677e5532eb051a = x4935b962725f7750 / 3.25;
			break;
		case LineStyle.ThinThickThinSmallGap:
			x3677e5532eb051a = x4935b962725f7750 / 1.5;
			break;
		case LineStyle.ThinThickThinMediumGap:
			x3677e5532eb051a = x4935b962725f7750 / 3.0;
			break;
		case LineStyle.ThinThickThinLargeGap:
			x3677e5532eb051a = x4935b962725f7750 / 3.0;
			break;
		case LineStyle.Emboss3D:
		case LineStyle.Engrave3D:
			x3677e5532eb051a = x4935b962725f7750 / 1.5;
			break;
		case LineStyle.Wave:
			x3677e5532eb051a = x4935b962725f7750 / 3.0;
			break;
		case LineStyle.DoubleWave:
			x3677e5532eb051a = x4935b962725f7750 / 5.0;
			break;
		default:
			x3677e5532eb051a = x4935b962725f7750;
			break;
		}
		return xf4847d1e065c74fb(x7ee6ab51d3d84831(x3677e5532eb051a));
	}

	private static int xf4847d1e065c74fb(double x7452baaa0eb3ce15)
	{
		int num = x15e971129fd80714.x43fcc3f62534530b(x7452baaa0eb3ce15 * 8.0);
		if (num == 0 && x7452baaa0eb3ce15 > 0.0)
		{
			return 1;
		}
		return num;
	}

	internal static Shading x56cdf34322e60e51(string x824bfb65f06865bd, Shading x12b7f8e5698b30a6)
	{
		if (x12b7f8e5698b30a6 == null)
		{
			x12b7f8e5698b30a6 = new Shading();
		}
		if (x824bfb65f06865bd == "transparent")
		{
			x12b7f8e5698b30a6.x0e18178ac4b2272f = x26d9ecb4bdf0456d.x45260ad4b94166f2;
		}
		else
		{
			x12b7f8e5698b30a6.x0e18178ac4b2272f = xd9a94ec83011098f(x824bfb65f06865bd);
		}
		return x12b7f8e5698b30a6;
	}

	internal static xcb29cf976b7ec398 xf689386ff4e793c3(xf7125312c7ee115c xa5e8b8b5991a4e1d, ArrowType x56e30755bce7e00e, bool xa59013d234619c58)
	{
		ArrowLength arrowLength = ArrowLength.Medium;
		if (xa5e8b8b5991a4e1d.x263d579af1d0d43f(xa59013d234619c58 ? 467 : 469))
		{
			arrowLength = (ArrowLength)xa5e8b8b5991a4e1d.xf7866f89640a29a3(xa59013d234619c58 ? 467 : 469);
		}
		return $"{x0eb9a864413f34de.xb17e0945d9acb370(x56e30755bce7e00e)}{arrowLength}" switch
		{
			"ArrowShortNarrow" => x889519bd1447f99f("msArrowEnd_20_1", "msArrowEnd 1", "0 0 140 140", "m70 0 70 140h-140z"), 
			"ArrowMediumNarrow" => x889519bd1447f99f("msArrowEnd_20_2", "msArrowEnd 2", "0 0 140 210", "m70 0 70 210h-140z"), 
			"ArrowLongNarrow" => x889519bd1447f99f("msArrowEnd_20_3", "msArrowEnd 3", "0 0 140 350", "m70 0 70 350h-140z"), 
			"ArrowShortMedium" => x889519bd1447f99f("msArrowEnd_20_4", "msArrowEnd 4", "0 0 210 140", "m105 0 105 140h-210z"), 
			"ArrowMediumMedium" => x889519bd1447f99f("msArrowEnd_20_5", "msArrowEnd 5", "0 0 210 210", "m105 0 105 210h-210z"), 
			"ArrowLongMedium" => x889519bd1447f99f("msArrowEnd_20_6", "msArrowEnd 6", "0 0 210 350", "m105 0 105 350h-210z"), 
			"ArrowShortWide" => x889519bd1447f99f("msArrowEnd_20_7", "msArrowEnd 7", "0 0 350 140", "m175 0 175 140h-350z"), 
			"ArrowMediumWide" => x889519bd1447f99f("msArrowEnd_20_8", "msArrowEnd 8", "0 0 350 210", "m175 0 175 210h-350z"), 
			"ArrowLongWide" => x889519bd1447f99f("msArrowEnd_20_9", "msArrowEnd 9", "0 0 350 350", "m175 0 175 350h-350z"), 
			"DiamondShortMedium" => x889519bd1447f99f("msArrowDiamondEnd_20_1", "msArrowDiamondEnd 1", "0 0 140 140", "m70 0 70 70-70 70-70-70z"), 
			"DiamondMediumMedium" => x889519bd1447f99f("msArrowDiamondEnd_20_2", "msArrowDiamondEnd 2", "0 0 140 210", "m70 0 70 105-70 105-70-105z"), 
			"DiamondLongNarrow" => x889519bd1447f99f("msArrowDiamondEnd_20_3", "msArrowDiamondEnd 3", "0 0 140 350", "m70 0 70 175-70 175-70-175z"), 
			"DiamondShortNarrow" => x889519bd1447f99f("msArrowDiamondEnd_20_4", "msArrowDiamondEnd 4", "0 0 210 140", "m105 0 105 70-105 70-105-70z"), 
			"DiamondMediumNarrow" => x889519bd1447f99f("msArrowDiamondEnd_20_5", "msArrowDiamondEnd 5", "0 0 210 210", "m105 0 105 105-105 105-105-105z"), 
			"DiamondMediumWide" => x889519bd1447f99f("msArrowDiamondEnd_20_6", "msArrowDiamondEnd 6", "0 0 210 350", "m105 0 105 175-105 175-105-175z"), 
			"DiamondShortWide" => x889519bd1447f99f("msArrowDiamondEnd_20_7", "msArrowDiamondEnd 7", "0 0 350 140", "m175 0 175 70-175 70-175-70z"), 
			"DiamondLongMedium" => x889519bd1447f99f("msArrowDiamondEnd_20_8", "msArrowDiamondEnd 8", "0 0 350 210", "m175 0 175 105-175 105-175-105z"), 
			"DiamondLongWide" => x889519bd1447f99f("msArrowDiamondEnd_20_9", "msArrowDiamondEnd 9", "0 0 350 350", "m175 0 175 175-175 175-175-175z"), 
			"OpenShortMedium" => x889519bd1447f99f("msArrowOpenEnd_20_1", "msArrowOpenEnd 1", "0 0 245 245", "m123 0 122 223-37 22-85-157-86 157-37-22z"), 
			"OpenMediumMedium" => x889519bd1447f99f("msArrowOpenEnd_20_2", "msArrowOpenEnd 2", "0 0 245 315", "m123 0 122 287-37 28-85-202-86 202-37-28z"), 
			"OpenLongNarrow" => x889519bd1447f99f("msArrowOpenEnd_20_3", "msArrowOpenEnd 3", "0 0 245 420", "m123 0 122 382-37 38-85-269-86 269-37-38z"), 
			"OpenShortNarrow" => x889519bd1447f99f("msArrowOpenEnd_20_4", "msArrowOpenEnd 4", "0 0 315 245", "m158 0 157 223-47 22-110-157-111 157-47-22z"), 
			"OpenMediumNarrow" => x889519bd1447f99f("msArrowOpenEnd_20_5", "msArrowOpenEnd 5", "0 0 315 315", "m158 0 157 287-47 28-110-202-111 202-47-28z"), 
			"OpenMediumWide" => x889519bd1447f99f("msArrowOpenEnd_20_6", "msArrowOpenEnd 6", "0 0 315 420", "m158 0 157 382-47 38-110-269-111 269-47-38z"), 
			"OpenShortWide" => x889519bd1447f99f("msArrowOpenEnd_20_7", "msArrowOpenEnd 7", "0 0 420 245", "m210 0 210 223-63 22-147-157-147 157-63-22z"), 
			"OpenLongMedium" => x889519bd1447f99f("msArrowOpenEnd_20_8", "msArrowOpenEnd 8", "0 0 420 315", "m210 0 210 287-63 28-147-202-147 202-63-28z"), 
			"OpenLongWide" => x889519bd1447f99f("msArrowOpenEnd_20_9", "msArrowOpenEnd 9", "0 0 420 420", "m210 0 210 382-63 38-147-269-147 269-63-38z"), 
			"OvalShortMedium" => x889519bd1447f99f("msArrowOvalEnd_20_1", "msArrowOvalEnd 1", "0 0 140 140", "m140 0c0-38-32-70-70-70s-70 32-70 70 32 70 70 70 70-32 70-70z"), 
			"OvalMediumMedium" => x889519bd1447f99f("msArrowOvalEnd_20_2", "msArrowOvalEnd 2", "0 0 140 210", "m140 0c0-57-32-105-70-105s-70 48-70 105 32 105 70 105 70-48 70-105z"), 
			"OvalLongNarrow" => x889519bd1447f99f("msArrowOvalEnd_20_3", "msArrowOvalEnd 3", "0 0 140 350", "m140 0c0-96-32-175-70-175s-70 79-70 175 32 175 70 175 70-79 70-175z"), 
			"OvalShortNarrow" => x889519bd1447f99f("msArrowOvalEnd_20_4", "msArrowOvalEnd 4", "0 0 210 140", "m210 0c0-38-48-70-105-70s-105 32-105 70 48 70 105 70 105-32 105-70z"), 
			"OvalMediumNarrow" => x889519bd1447f99f("msArrowOvalEnd_20_5", "msArrowOvalEnd 5", "0 0 210 210", "m210 0c0-57-48-105-105-105s-105 48-105 105 48 105 105 105 105-48 105-105z"), 
			"OvalMediumWide" => x889519bd1447f99f("msArrowOvalEnd_20_6", "msArrowOvalEnd 6", "0 0 210 350", "m210 0c0-96-48-175-105-175s-105 79-105 175 48 175 105 175 105-79 105-175z"), 
			"OvalShortWide" => x889519bd1447f99f("msArrowOvalEnd_20_7", "msArrowOvalEnd 7", "0 0 350 140", "m350 0c0-38-79-70-175-70s-175 32-175 70 79 70 175 70 175-32 175-70z"), 
			"OvalLongMedium" => x889519bd1447f99f("msArrowOvalEnd_20_8", "msArrowOvalEnd 8", "0 0 350 210", "m350 0c0-57-79-105-175-105s-175 48-175 105 79 105 175 105 175-48 175-105z"), 
			"OvalLongWide" => x889519bd1447f99f("msArrowOvalEnd_20_9", "msArrowOvalEnd 9", "0 0 350 350", "m350 0c0-96-79-175-175-175s-175 79-175 175 79 175 175 175 175-79 175-175z"), 
			"BlockShortMedium" => x889519bd1447f99f("msArrowStealthEnd_20_1", "msArrowStealthEnd 1", "0 0 140 140", "m70 0 70 140-70-56-70 56z"), 
			"BlockMediumMedium" => x889519bd1447f99f("msArrowStealthEnd_20_2", "msArrowStealthEnd 2", "0 0 140 210", "m70 0 70 210-70-84-70 84z"), 
			"BlockLongNarrow" => x889519bd1447f99f("msArrowStealthEnd_20_3", "msArrowStealthEnd 3", "0 0 140 350", "m70 0 70 350-70-140-70 140z"), 
			"BlockShortNarrow" => x889519bd1447f99f("msArrowStealthEnd_20_4", "msArrowStealthEnd 4", "0 0 210 140", "m105 0 105 140-105-56-105 56z"), 
			"BlockMediumNarrow" => x889519bd1447f99f("msArrowStealthEnd_20_5", "msArrowStealthEnd 5", "0 0 210 210", "m105 0 105 210-105-84-105 84z"), 
			"BlockMediumWide" => x889519bd1447f99f("msArrowStealthEnd_20_6", "msArrowStealthEnd 6", "0 0 210 350", "m105 0 105 350-105-140-105 140z"), 
			"BlockShortWide" => x889519bd1447f99f("msArrowStealthEnd_20_7", "msArrowStealthEnd 7", "0 0 350 140", "m175 0 175 140-175-56-175 56z"), 
			"BlockLongMedium" => x889519bd1447f99f("msArrowStealthEnd_20_8", "msArrowStealthEnd 8", "0 0 350 210", "m175 0 175 210-175-84-175 84z"), 
			"BlockLongWide" => x889519bd1447f99f("msArrowStealthEnd_20_9", "msArrowStealthEnd 9", "0 0 350 350", "m175 0 175 350-175-140-175 140z"), 
			_ => x889519bd1447f99f("msArrowEnd_20_5", "msArrowEnd 5", "0 0 210 210", "m105 0 105 210h-210z"), 
		};
	}

	private static xcb29cf976b7ec398 x889519bd1447f99f(string xc15bd84e01929885, string xf0d47d7698b4e263, string x6cb4ed673808ab00, string x73f821c71fe1e676)
	{
		xcb29cf976b7ec398 xcb29cf976b7ec399 = new xcb29cf976b7ec398();
		xcb29cf976b7ec399.x759aa16c2016a289 = xc15bd84e01929885;
		xcb29cf976b7ec399.xba89ca2127612c56 = xf0d47d7698b4e263;
		xcb29cf976b7ec399.x8251b2a60565655e = x6cb4ed673808ab00;
		xcb29cf976b7ec399.x5d593cee9d844848 = x73f821c71fe1e676;
		return xcb29cf976b7ec399;
	}

	internal static string x0adb99a291d3313b(object x5c021e387157a637)
	{
		return $"{xca004f56614e2431.xcaaeec2e96b2cecc((double)(int)x5c021e387157a637 / 2.0)}pt";
	}

	internal static void x2331ecbb921f8120(string x5c021e387157a637, x5668c8829b7abcee x79cf302e32e8599c, xeedad81aaed42a76 x789564759d365819, int x6cc530a2cd983862)
	{
		if (x5c021e387157a637.EndsWith("%"))
		{
			x79cf302e32e8599c.x87e47b848b0093cb = xca004f56614e2431.xec25d08a2af152f0(x5c021e387157a637.Replace("%", ""));
		}
		else
		{
			x789564759d365819.xae20093bed1e48a8(x6cc530a2cd983862, x2331ecbb921f8120(x5c021e387157a637));
		}
	}

	internal static bool x20cfc521944513f8(string x5c021e387157a637)
	{
		try
		{
			xca004f56614e2431.xa93402510be8434e(x5c021e387157a637);
		}
		catch
		{
			return false;
		}
		return true;
	}

	internal static int x2331ecbb921f8120(string x5c021e387157a637)
	{
		if (x20cfc521944513f8(x5c021e387157a637))
		{
			x5c021e387157a637 = $"{x5c021e387157a637}pt";
		}
		if (!xd1ddac1c3a154564(x5c021e387157a637))
		{
			return 0;
		}
		double num = xc93d98c550d1261e(x5c021e387157a637);
		return x4574ea26106f0edb.x3f26fa43a4a41e70(xed77df7e9d43a06a(x5c021e387157a637) switch
		{
			"in" => x4574ea26106f0edb.x9adffc4de2e5ac97(num), 
			"pt" => num, 
			"cm" => x7ee6ab51d3d84831(num), 
			_ => x7ee6ab51d3d84831(num / 10.0), 
		});
	}

	internal static x9b28b1f7f0cc963f x77391c255918b2ef(string x5b42b2dce99a42d0)
	{
		if (!(x5b42b2dce99a42d0 == "italic"))
		{
			return x9b28b1f7f0cc963f.x12642456c7bf0815;
		}
		return x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc;
	}

	internal static x9b28b1f7f0cc963f x04c8efb539cf6f17(string xeefece3e53a04752)
	{
		switch (xeefece3e53a04752)
		{
		case "normal":
			return x9b28b1f7f0cc963f.x12642456c7bf0815;
		case "bold":
		case "100":
		case "200":
		case "300":
		case "400":
		case "500":
		case "600":
		case "700":
		case "800":
		case "900":
			return x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc;
		default:
			return x9b28b1f7f0cc963f.x12642456c7bf0815;
		}
	}

	internal static string xd7cd108060df249c(object x13d4cb8d1bd20347, object x5c021e387157a637)
	{
		int num = x15e971129fd80714.x43fcc3f62534530b((double)(int)x13d4cb8d1bd20347 * 100.0 / (double)(int)x5c021e387157a637);
		if (Math.Abs(num) > 100)
		{
			num = Math.Sign(num) * 100;
		}
		return $"{xca004f56614e2431.xcaaeec2e96b2cecc(num)}% 100%";
	}

	internal static int x07425727e27d8547(string xf86f6035b568b2d7, int x5c021e387157a637)
	{
		if (!xf86f6035b568b2d7.StartsWith("super") && !xf86f6035b568b2d7.StartsWith("sub"))
		{
			int num = xf86f6035b568b2d7.IndexOf("%");
			if (num != -1)
			{
				int num2 = x15e971129fd80714.x43fcc3f62534530b(xca004f56614e2431.xec25d08a2af152f0(xf86f6035b568b2d7.Substring(0, num)));
				return x15e971129fd80714.x43fcc3f62534530b((double)(num2 * x5c021e387157a637) / 100.0);
			}
		}
		return 0;
	}

	internal static string x5de8b3baf75f4df6(x26d9ecb4bdf0456d x6c50a99faab7d741, bool xb825d0cb9a874ff8)
	{
		if (xb825d0cb9a874ff8 && x6c50a99faab7d741.x7149c962c02931b3)
		{
			x6c50a99faab7d741 = x26d9ecb4bdf0456d.x89fffa2751fdecbe;
		}
		else
		{
			if (x6c50a99faab7d741 == x26d9ecb4bdf0456d.x66d844daa6e9f181)
			{
				return "transparent";
			}
			if (x6c50a99faab7d741.x7149c962c02931b3)
			{
				return "";
			}
		}
		if (x6c50a99faab7d741 == new x26d9ecb4bdf0456d(239, 240, 2, 0))
		{
			return "#ffffff";
		}
		return string.Format("#{0}{1}{2}{3}", (x6c50a99faab7d741.xda71bf6f7c07c3bc == 255 || x6c50a99faab7d741.xda71bf6f7c07c3bc == 0) ? "" : xca004f56614e2431.x06423d8cf62a0672(x6c50a99faab7d741.xda71bf6f7c07c3bc), xca004f56614e2431.x06423d8cf62a0672(x6c50a99faab7d741.xc613adc4330033f3), xca004f56614e2431.x06423d8cf62a0672(x6c50a99faab7d741.x26463655896fd90a), xca004f56614e2431.x06423d8cf62a0672(x6c50a99faab7d741.x8e8f6cc6a0756b05));
	}

	internal static string x5de8b3baf75f4df6(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		return x5de8b3baf75f4df6(x6c50a99faab7d741, xb825d0cb9a874ff8: true);
	}

	internal static x26d9ecb4bdf0456d xd9a94ec83011098f(string x6c50a99faab7d741)
	{
		if (x6c50a99faab7d741 == "transparent")
		{
			return x26d9ecb4bdf0456d.x66d844daa6e9f181;
		}
		if (x6c50a99faab7d741[0] == '#')
		{
			x6c50a99faab7d741 = x6c50a99faab7d741.TrimStart('#');
			if (x6c50a99faab7d741.Length == 6)
			{
				return new x26d9ecb4bdf0456d(xca004f56614e2431.xadcf75bfc0bf31e3(x6c50a99faab7d741.Substring(0, 2)), xca004f56614e2431.xadcf75bfc0bf31e3(x6c50a99faab7d741.Substring(2, 2)), xca004f56614e2431.xadcf75bfc0bf31e3(x6c50a99faab7d741.Substring(4, 2)));
			}
			if (x6c50a99faab7d741.Length == 8)
			{
				return new x26d9ecb4bdf0456d(xca004f56614e2431.xadcf75bfc0bf31e3(x6c50a99faab7d741.Substring(0, 2)), xca004f56614e2431.xadcf75bfc0bf31e3(x6c50a99faab7d741.Substring(2, 2)), xca004f56614e2431.xadcf75bfc0bf31e3(x6c50a99faab7d741.Substring(4, 2)), xca004f56614e2431.xadcf75bfc0bf31e3(x6c50a99faab7d741.Substring(6, 2)));
			}
		}
		return x26d9ecb4bdf0456d.x45260ad4b94166f2;
	}

	private static int x0b133b860e555abb(string xa29120d2bc63c158, bool x5e11f203809125d6)
	{
		double num = ((!xa29120d2bc63c158.EndsWith("%")) ? xca004f56614e2431.xec25d08a2af152f0(xa29120d2bc63c158) : (xca004f56614e2431.xec25d08a2af152f0(xa29120d2bc63c158.Replace("%", "")) / 100.0));
		return x4574ea26106f0edb.x091b250f00534aae(x5e11f203809125d6 ? (1.0 - num) : num);
	}

	internal static int x0b133b860e555abb(string xa29120d2bc63c158)
	{
		return x0b133b860e555abb(xa29120d2bc63c158, x5e11f203809125d6: false);
	}

	internal static int x17816a52864a361a(string x68b308ce2cea4e99)
	{
		return x0b133b860e555abb(x68b308ce2cea4e99, x5e11f203809125d6: true);
	}

	private static string xa2f3595b63dc1e85(int x1965e484c4a7c6c6, bool x5e11f203809125d6)
	{
		double num = Math.Round(x4574ea26106f0edb.x97ab502db0c0e5c2(x1965e484c4a7c6c6) * 100.0);
		return $"{xca004f56614e2431.xcaaeec2e96b2cecc(x5e11f203809125d6 ? (100.0 - num) : num)}%";
	}

	internal static string xa2f3595b63dc1e85(int x1965e484c4a7c6c6)
	{
		return xa2f3595b63dc1e85(x1965e484c4a7c6c6, x5e11f203809125d6: false);
	}

	internal static string xb1d5730bd3bfab62(int x3cfacdd7929d8569)
	{
		return xa2f3595b63dc1e85(x3cfacdd7929d8569, x5e11f203809125d6: true);
	}

	internal static string x0ad4dcbc0b50ce41(Shading x12b7f8e5698b30a6)
	{
		x26d9ecb4bdf0456d xc290f60df004e = x12b7f8e5698b30a6.xc290f60df004e384;
		x26d9ecb4bdf0456d x0e18178ac4b2272f = x12b7f8e5698b30a6.x0e18178ac4b2272f;
		if (x12b7f8e5698b30a6.Texture == TextureIndex.TextureNone || x12b7f8e5698b30a6.Texture == TextureIndex.TextureNil)
		{
			if (x0e18178ac4b2272f.x7149c962c02931b3 || x0e18178ac4b2272f == x26d9ecb4bdf0456d.x66d844daa6e9f181)
			{
				return null;
			}
			return x5de8b3baf75f4df6(x0e18178ac4b2272f);
		}
		double x4afa7e85b5b4d = x0eb9a864413f34de.x196175fd1cffa22a(x12b7f8e5698b30a6.Texture);
		string text = ((xc290f60df004e.xda71bf6f7c07c3bc == 255 || xc290f60df004e.xda71bf6f7c07c3bc == 0) ? "" : xe22d8d33711c2bb0(xc290f60df004e.xda71bf6f7c07c3bc, x0e18178ac4b2272f.xda71bf6f7c07c3bc, x4afa7e85b5b4d));
		string text2 = xe22d8d33711c2bb0(xc290f60df004e.xc613adc4330033f3, x0e18178ac4b2272f.xc613adc4330033f3, x4afa7e85b5b4d);
		string text3 = xe22d8d33711c2bb0(xc290f60df004e.x26463655896fd90a, x0e18178ac4b2272f.x26463655896fd90a, x4afa7e85b5b4d);
		string text4 = xe22d8d33711c2bb0(xc290f60df004e.x8e8f6cc6a0756b05, x0e18178ac4b2272f.x8e8f6cc6a0756b05, x4afa7e85b5b4d);
		return $"#{text}{text2}{text3}{text4}";
	}

	private static string xe22d8d33711c2bb0(int x33e0f55c571af858, int x0684a36d99dbda75, double x4afa7e85b5b4d006)
	{
		if (x4afa7e85b5b4d006 == 1.0)
		{
			return xca004f56614e2431.x06423d8cf62a0672(x33e0f55c571af858);
		}
		if (x33e0f55c571af858 == 0 && x0684a36d99dbda75 == 0)
		{
			return xca004f56614e2431.x06423d8cf62a0672((byte)(255.0 - 255.0 * x4afa7e85b5b4d006));
		}
		if (x33e0f55c571af858 == 255)
		{
			return xca004f56614e2431.x06423d8cf62a0672(x0684a36d99dbda75);
		}
		int num = Math.Max(x33e0f55c571af858, x0684a36d99dbda75);
		int num2 = Math.Abs(x33e0f55c571af858 - x0684a36d99dbda75);
		int x37cf7043760b312e = (byte)((double)num - (double)num2 * x4afa7e85b5b4d006);
		return xca004f56614e2431.x06423d8cf62a0672(x37cf7043760b312e);
	}

	internal static string xee517197210970c0(x9b28b1f7f0cc963f xbcea506a33cf9111, xf5ecf429e74b1c04 x1a84eefd5d3e114a, int xba08ce632055a1d9, string x5e8c9e782f8bb063)
	{
		return xee517197210970c0(xbcea506a33cf9111, x1a84eefd5d3e114a, xba08ce632055a1d9, x5e8c9e782f8bb063, null);
	}

	internal static string xee517197210970c0(x9b28b1f7f0cc963f xbcea506a33cf9111, xf5ecf429e74b1c04 x1a84eefd5d3e114a, int xba08ce632055a1d9, string x5e8c9e782f8bb063, string x008bfe55890ebed6)
	{
		object obj = xbcea506a33cf9111.xcc8077a1fcb56a8f(x1a84eefd5d3e114a, xba08ce632055a1d9);
		if (obj != null)
		{
			if (!(bool)obj)
			{
				return x008bfe55890ebed6;
			}
			return x5e8c9e782f8bb063;
		}
		return null;
	}

	internal static string x94045081801bb82d(string xc15bd84e01929885)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(xc15bd84e01929885))
		{
			return xc15bd84e01929885;
		}
		string text = xc15bd84e01929885;
		MatchCollection matchCollection = x0ab03dd91c659e42.Matches(xc15bd84e01929885);
		foreach (Match item in matchCollection)
		{
			string value = item.Value;
			if (x0d299f323d241756.x5959bccb67bbf051(value))
			{
				text = text.Replace(value, ((char)xca004f56614e2431.xadcf75bfc0bf31e3(value.Trim('_'))).ToString());
			}
		}
		return text;
	}

	internal static string x127fca996f5c76e4(string xc15bd84e01929885)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(xc15bd84e01929885))
		{
			return xc15bd84e01929885;
		}
		string text = xc15bd84e01929885;
		string input = xc15bd84e01929885.Substring(0, 1);
		MatchCollection matchCollection = xe3c82b990808b1fd.Matches(input);
		if (matchCollection.Count > 0)
		{
			Match match = matchCollection[0];
			string arg = xca004f56614e2431.x3f49ddc503802c37(match.Value[0]);
			text = $"{$"_{arg}_"}{xc15bd84e01929885.Substring(1)}";
		}
		string input2 = xc15bd84e01929885.Substring(1);
		foreach (Match item in xc90bd0b6bcc527ad.Matches(input2))
		{
			string arg2 = xca004f56614e2431.x3f49ddc503802c37(item.Value[0]);
			text = text.Replace(item.Value, $"_{arg2}_");
		}
		return text;
	}

	internal static string xdd08ed399f8774b0(string x4d57df2e22f74063, string x50fc2dc03ef1fe05, bool xf4959543150451ad)
	{
		string text = x4d57df2e22f74063;
		if (!xf4959543150451ad)
		{
			text = xdfac57ec3a49a3fc.x1f490eac106aee12(x4d57df2e22f74063).x58c712b0d1d1c39b;
		}
		if (x0d4d45882065c63e.xbf8774d82d777b9e(text))
		{
			return text;
		}
		if (!x4b413b4af656793d(text))
		{
			return "";
		}
		if (!x0d4d45882065c63e.xe06270bc72b12369(text))
		{
			text = text.TrimStart(x12241a8a239bd885);
			text = x0d4d45882065c63e.xed9f2ad1e95ded9e(x50fc2dc03ef1fe05, text);
			text = $"file:///{text}";
		}
		else
		{
			text = x0d4d45882065c63e.x8644581dcf469731(text);
		}
		return text.Replace("\\", "/");
	}

	internal static bool x0214605434693fc1(string xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 != "none")
		{
			return x30490843b282206a(xbcea506a33cf9111.Split(' ')[1]) > 0;
		}
		return false;
	}

	internal static string x573fbc1b32ee4645(string x8531f04c495363f6)
	{
		return x8531f04c495363f6.Replace("file:///", "");
	}

	private static bool x4b413b4af656793d(string xe125219852864557)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xe125219852864557))
		{
			return xe125219852864557.IndexOfAny(xf12627fc5d74f9bb) == -1;
		}
		return false;
	}
}
