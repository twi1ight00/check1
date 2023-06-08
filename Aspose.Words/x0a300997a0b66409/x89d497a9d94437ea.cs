using System.Collections;
using Aspose.Words;
using Aspose.Words.Settings;
using x6c95d9cf46ff5f25;
using x79578da6a8a3ae37;

namespace x0a300997a0b66409;

internal class x89d497a9d94437ea
{
	private static Hashtable xd448cc87a7fd5f4a;

	private static Hashtable xb4ac99115db4483d;

	private static Hashtable x5ceac6000e47eaf7;

	private static Hashtable x088a8e2f69bd4889;

	private static Hashtable x4fc00ef03df7d3e1;

	private static Hashtable x5696d8a456bcec30;

	private static Hashtable x19fb2aee8a8e862d;

	private static Hashtable xa4bfbe6d70a86658;

	internal static ProtectionType x924cf962f9ca08ab(string xbcea506a33cf9111)
	{
		return (ProtectionType)x682712679dbc585a.xce92de628aa023cf(xd448cc87a7fd5f4a, xbcea506a33cf9111, ProtectionType.NoProtection);
	}

	internal static string xc1e87f93efd4bfbb(ProtectionType xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(xb4ac99115db4483d, xbcea506a33cf9111, "none");
	}

	internal static xd659df342ea4c461 x37efba73cc74bfe4(string xbcea506a33cf9111)
	{
		return (xd659df342ea4c461)x682712679dbc585a.xce92de628aa023cf(x5ceac6000e47eaf7, xbcea506a33cf9111, xd659df342ea4c461.x603eb9b9783cfb2d);
	}

	internal static string x7c8ee007a210373d(xd659df342ea4c461 xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x088a8e2f69bd4889, xbcea506a33cf9111, "DontCompress");
	}

	internal static xf1ca9e6f44822582 xb3bc16f5a250d53f(string xbcea506a33cf9111)
	{
		string text;
		if ((text = xbcea506a33cf9111) != null && text == "clean")
		{
			return xf1ca9e6f44822582.xfed52103abb3a632;
		}
		return xf1ca9e6f44822582.x4d0b9d4447ba7566;
	}

	internal static string x82ba73c90bb53986(xf1ca9e6f44822582 xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 == xf1ca9e6f44822582.xfed52103abb3a632)
		{
			return "clean";
		}
		return "";
	}

	internal static ViewType x903e5db17e0ddc09(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"normal" => ViewType.Normal, 
			"print" => ViewType.PageLayout, 
			"outline" => ViewType.Outline, 
			"master-pages" => ViewType.Outline, 
			"web" => ViewType.Web, 
			_ => ViewType.PageLayout, 
		};
	}

	internal static string x761be663dee8597e(ViewType xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			ViewType.Normal => "normal", 
			ViewType.PageLayout => "print", 
			ViewType.Outline => "master-pages", 
			ViewType.Web => "web", 
			_ => "print", 
		};
	}

	internal static ZoomType x8712e5965cc3ffea(string xbcea506a33cf9111)
	{
		return (ZoomType)x682712679dbc585a.xce92de628aa023cf(x4fc00ef03df7d3e1, xbcea506a33cf9111, ZoomType.Custom);
	}

	internal static string xd9c235163fb5784d(ZoomType xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x5696d8a456bcec30, xbcea506a33cf9111, "none");
	}

	internal static x760e7af47aae1b61 xdd5621a8d8f118c2(string xbcea506a33cf9111)
	{
		return (x760e7af47aae1b61)x682712679dbc585a.xce92de628aa023cf(x19fb2aee8a8e862d, xbcea506a33cf9111, x760e7af47aae1b61.xe9e531d1a6725226);
	}

	internal static string xc92579e54c49e568(x760e7af47aae1b61 xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(xa4bfbe6d70a86658, xbcea506a33cf9111, "");
	}

	static x89d497a9d94437ea()
	{
		xd448cc87a7fd5f4a = new Hashtable();
		xb4ac99115db4483d = new Hashtable();
		x5ceac6000e47eaf7 = new Hashtable();
		x088a8e2f69bd4889 = new Hashtable();
		x4fc00ef03df7d3e1 = new Hashtable();
		x5696d8a456bcec30 = new Hashtable();
		x19fb2aee8a8e862d = new Hashtable();
		xa4bfbe6d70a86658 = new Hashtable();
		x682712679dbc585a.x70fa1602ceccddee(new object[8]
		{
			"none",
			ZoomType.Custom,
			"full-page",
			ZoomType.FullPage,
			"best-fit",
			ZoomType.PageWidth,
			"text-fit",
			ZoomType.TextFit
		}, x4fc00ef03df7d3e1, x5696d8a456bcec30);
		x682712679dbc585a.x70fa1602ceccddee(new object[4]
		{
			"letter",
			x760e7af47aae1b61.x295beb097a304089,
			"e-mail",
			x760e7af47aae1b61.xdc30cee9941e0dbd
		}, x19fb2aee8a8e862d, xa4bfbe6d70a86658);
		x682712679dbc585a.x70fa1602ceccddee(new object[6]
		{
			"CompressPunctuation",
			xd659df342ea4c461.x5cc037c990a58282,
			"CompressPunctuationAndJapaneseKana",
			xd659df342ea4c461.x6eb3a1b98105c108,
			"DontCompress",
			xd659df342ea4c461.x603eb9b9783cfb2d
		}, x5ceac6000e47eaf7, x088a8e2f69bd4889);
		x682712679dbc585a.x70fa1602ceccddee(new object[10]
		{
			"tracked-changes",
			ProtectionType.AllowOnlyRevisions,
			"comments",
			ProtectionType.AllowOnlyComments,
			"forms",
			ProtectionType.AllowOnlyFormFields,
			"read-only",
			ProtectionType.ReadOnly,
			"none",
			ProtectionType.NoProtection
		}, xd448cc87a7fd5f4a, xb4ac99115db4483d);
	}
}
