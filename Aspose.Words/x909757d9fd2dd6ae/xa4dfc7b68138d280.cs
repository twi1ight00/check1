using System.Collections;
using Aspose.Words;
using Aspose.Words.Settings;
using x6c95d9cf46ff5f25;
using x79578da6a8a3ae37;
using xda075892eccab2ad;
using xe5b37aee2c2a4d4e;
using xf9a9481c3f63a419;

namespace x909757d9fd2dd6ae;

internal class xa4dfc7b68138d280
{
	private static readonly Hashtable xd448cc87a7fd5f4a;

	private static readonly Hashtable xb4ac99115db4483d;

	private static readonly Hashtable x5ceac6000e47eaf7;

	private static readonly Hashtable x088a8e2f69bd4889;

	private static readonly Hashtable x4fc00ef03df7d3e1;

	private static readonly Hashtable x5696d8a456bcec30;

	private static readonly Hashtable x19fb2aee8a8e862d;

	private static readonly Hashtable xa4bfbe6d70a86658;

	private static readonly Hashtable xa900d43b4d5f16f4;

	private static readonly Hashtable xaea004c3a0d97159;

	private static readonly Hashtable xe652151ad2789951;

	private static readonly Hashtable x033082ebd333726a;

	private static readonly Hashtable x8698ab4972531338;

	private static readonly Hashtable xa35b60b9268f26c3;

	private static readonly Hashtable x3ae7b4d017f53714;

	private static readonly Hashtable x0f1f97e2b9c34689;

	internal static ProtectionType x519727c4405dc705(string xbcea506a33cf9111)
	{
		return (ProtectionType)x682712679dbc585a.xce92de628aa023cf(xd448cc87a7fd5f4a, xbcea506a33cf9111, ProtectionType.NoProtection);
	}

	internal static string x9c430209bfce7a17(ProtectionType xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(xb4ac99115db4483d, xbcea506a33cf9111, "none");
	}

	internal static xd659df342ea4c461 x6b50e51a56595797(string xbcea506a33cf9111)
	{
		return (xd659df342ea4c461)x682712679dbc585a.xce92de628aa023cf(x5ceac6000e47eaf7, xbcea506a33cf9111, xd659df342ea4c461.x603eb9b9783cfb2d);
	}

	internal static string xb9ea59e7325a3274(xd659df342ea4c461 xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x088a8e2f69bd4889, xbcea506a33cf9111, "DontCompress");
	}

	internal static xf1ca9e6f44822582 xb306b6511dc6b3ee(string xbcea506a33cf9111)
	{
		string text;
		if ((text = xbcea506a33cf9111) != null && text == "clean")
		{
			return xf1ca9e6f44822582.xfed52103abb3a632;
		}
		return xf1ca9e6f44822582.x4d0b9d4447ba7566;
	}

	internal static string xc757cd724326150c(xf1ca9e6f44822582 xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 == xf1ca9e6f44822582.xfed52103abb3a632)
		{
			return "clean";
		}
		return "";
	}

	internal static ViewType x21236a732c36a512(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"normal" => ViewType.Normal, 
			"print" => ViewType.PageLayout, 
			"outline" => ViewType.Outline, 
			"masterPages" => ViewType.Outline, 
			"web" => ViewType.Web, 
			_ => ViewType.PageLayout, 
		};
	}

	internal static string x4d2a8d0f8179f841(ViewType xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			ViewType.Normal => "normal", 
			ViewType.Outline => "masterPages", 
			ViewType.Web => "web", 
			_ => "", 
		};
	}

	internal static x9b603ddcf603293d x1d97d790ffd781e0(string xbcea506a33cf9111)
	{
		if (char.IsDigit(xbcea506a33cf9111[0]))
		{
			return x72a0c846678ecaf9.x4ad35d0edf2d7b05(xca004f56614e2431.x59884ab46dd0d856(xbcea506a33cf9111));
		}
		return (x9b603ddcf603293d)x682712679dbc585a.xce92de628aa023cf(xe652151ad2789951, xbcea506a33cf9111, x9b603ddcf603293d.xb9715d2f06b63cf0);
	}

	internal static string xd78c1a1745d31309(x9b603ddcf603293d xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x033082ebd333726a, xbcea506a33cf9111, "default");
	}

	internal static ZoomType xbfac763c15626116(string xbcea506a33cf9111)
	{
		return (ZoomType)x682712679dbc585a.xce92de628aa023cf(x4fc00ef03df7d3e1, xbcea506a33cf9111, ZoomType.Custom);
	}

	internal static string x1d3e524d37a3622b(ZoomType xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x5696d8a456bcec30, xbcea506a33cf9111, "none");
	}

	internal static x760e7af47aae1b61 x71012ae2de47dadf(string xbcea506a33cf9111)
	{
		return (x760e7af47aae1b61)x682712679dbc585a.xce92de628aa023cf(x19fb2aee8a8e862d, xbcea506a33cf9111, x760e7af47aae1b61.xe9e531d1a6725226);
	}

	internal static string xff824401db63a8b6(x760e7af47aae1b61 xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(xa4bfbe6d70a86658, xbcea506a33cf9111, "");
	}

	internal static x7868d665e9cfc8d9 x6566c52aa91f9be8(string xbcea506a33cf9111)
	{
		return (x7868d665e9cfc8d9)x682712679dbc585a.xce92de628aa023cf(xa900d43b4d5f16f4, xbcea506a33cf9111, x7868d665e9cfc8d9.x4d0b9d4447ba7566);
	}

	internal static string x6d6fc64932e93418(x7868d665e9cfc8d9 xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(xaea004c3a0d97159, xbcea506a33cf9111, "");
	}

	internal static x8cc5e7c82a5cfe7a xfaab545f73c7515b(string xbcea506a33cf9111)
	{
		return (x8cc5e7c82a5cfe7a)x682712679dbc585a.xce92de628aa023cf(x8698ab4972531338, xbcea506a33cf9111, x8cc5e7c82a5cfe7a.x0364c07ad4dcfe0c);
	}

	internal static string x9b8ba7d8c123f5a5(x8cc5e7c82a5cfe7a xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(xa35b60b9268f26c3, xbcea506a33cf9111, "");
	}

	internal static x64749a01847a82ed xafb68785d2e34ba8(string xbcea506a33cf9111)
	{
		return (x64749a01847a82ed)x682712679dbc585a.xce92de628aa023cf(x3ae7b4d017f53714, xbcea506a33cf9111, x64749a01847a82ed.xb3be3c6719f0f91f);
	}

	internal static string x02d4047d9d9ecda0(x64749a01847a82ed xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x0f1f97e2b9c34689, xbcea506a33cf9111, "");
	}

	static xa4dfc7b68138d280()
	{
		xd448cc87a7fd5f4a = new Hashtable();
		xb4ac99115db4483d = new Hashtable();
		x5ceac6000e47eaf7 = new Hashtable();
		x088a8e2f69bd4889 = new Hashtable();
		x4fc00ef03df7d3e1 = new Hashtable();
		x5696d8a456bcec30 = new Hashtable();
		x19fb2aee8a8e862d = new Hashtable();
		xa4bfbe6d70a86658 = new Hashtable();
		xa900d43b4d5f16f4 = new Hashtable();
		xaea004c3a0d97159 = new Hashtable();
		xe652151ad2789951 = new Hashtable();
		x033082ebd333726a = new Hashtable();
		x8698ab4972531338 = new Hashtable();
		xa35b60b9268f26c3 = new Hashtable();
		x3ae7b4d017f53714 = new Hashtable();
		x0f1f97e2b9c34689 = new Hashtable();
		x682712679dbc585a.x70fa1602ceccddee(new object[8]
		{
			"none",
			ZoomType.Custom,
			"fullPage",
			ZoomType.FullPage,
			"bestFit",
			ZoomType.PageWidth,
			"textFit",
			ZoomType.TextFit
		}, x4fc00ef03df7d3e1, x5696d8a456bcec30);
		x682712679dbc585a.x70fa1602ceccddee(new object[4]
		{
			"letter",
			x760e7af47aae1b61.x295beb097a304089,
			"eMail",
			x760e7af47aae1b61.xdc30cee9941e0dbd
		}, x19fb2aee8a8e862d, xa4bfbe6d70a86658);
		x682712679dbc585a.x70fa1602ceccddee(new object[6]
		{
			"compressPunctuation",
			xd659df342ea4c461.x5cc037c990a58282,
			"compressPunctuationAndJapaneseKana",
			xd659df342ea4c461.x6eb3a1b98105c108,
			"doNotCompress",
			xd659df342ea4c461.x603eb9b9783cfb2d
		}, x5ceac6000e47eaf7, x088a8e2f69bd4889);
		x682712679dbc585a.x70fa1602ceccddee(new object[10]
		{
			"trackedChanges",
			ProtectionType.AllowOnlyRevisions,
			"comments",
			ProtectionType.AllowOnlyComments,
			"forms",
			ProtectionType.AllowOnlyFormFields,
			"readOnly",
			ProtectionType.ReadOnly,
			"none",
			ProtectionType.NoProtection
		}, xd448cc87a7fd5f4a, xb4ac99115db4483d);
		x682712679dbc585a.x70fa1602ceccddee(new object[8]
		{
			"W3C XHTML+CSS1",
			x7868d665e9cfc8d9.x59f4b5b2a5aea8d7,
			"W3C HTML4+CSS1",
			x7868d665e9cfc8d9.x0c99950ff83f4986,
			"W3C XHTML+CSS2",
			x7868d665e9cfc8d9.x176b443e90cbdeab,
			"W3C HTML4+CSS2",
			x7868d665e9cfc8d9.x7c62ce1198a46cc8
		}, xa900d43b4d5f16f4, xaea004c3a0d97159);
		x682712679dbc585a.x70fa1602ceccddee(new object[12]
		{
			"basedOn",
			x9b603ddcf603293d.x4c48a782e25bce54,
			"font",
			x9b603ddcf603293d.xc2d4efc42998d87b,
			"name",
			x9b603ddcf603293d.x759aa16c2016a289,
			"priority",
			x9b603ddcf603293d.xc6f44b0fac42607a,
			"type",
			x9b603ddcf603293d.xba0a9112ba3a76bf,
			"default",
			x9b603ddcf603293d.xb9715d2f06b63cf0
		}, xe652151ad2789951, x033082ebd333726a);
		x682712679dbc585a.x70fa1602ceccddee(new object[6]
		{
			"after",
			x8cc5e7c82a5cfe7a.x851fcfc17df82b1b,
			"before",
			x8cc5e7c82a5cfe7a.x0364c07ad4dcfe0c,
			"repeat",
			x8cc5e7c82a5cfe7a.x40c48cf928530839
		}, x8698ab4972531338, xa35b60b9268f26c3);
		x682712679dbc585a.x70fa1602ceccddee(new object[6]
		{
			"+-",
			x64749a01847a82ed.x0e52cf7c17c8af46,
			"-+",
			x64749a01847a82ed.xaba3a2827436a4b3,
			"--",
			x64749a01847a82ed.xb3be3c6719f0f91f
		}, x3ae7b4d017f53714, x0f1f97e2b9c34689);
	}
}
