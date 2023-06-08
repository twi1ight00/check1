using Aspose.Words.Fonts;
using x6c95d9cf46ff5f25;

namespace x639ad3f66698fe1b;

internal class x411372dbde676721
{
	private x411372dbde676721()
	{
	}

	internal static void x6210059f049f0d48(x21f0d20d41203be1 x0f7b23d1c393aed9)
	{
		xbfd162a6d47f59a4 xe1410f585439c7d = x0f7b23d1c393aed9.xe1410f585439c7d4;
		xe1410f585439c7d.x32378e1a3c5fdbcd();
		xe1410f585439c7d.xee60bff2900a72f2("\\fonttbl");
		FontInfoCollection fontInfos = x0f7b23d1c393aed9.x2c8c6741422a1298.FontInfos;
		for (int i = 0; i < fontInfos.Count; i++)
		{
			xe1410f585439c7d.x25d0efbd7848eeb3();
			xe1410f585439c7d.xa07aa514e9082b3a();
			FontInfo fontInfo = fontInfos[i];
			xe1410f585439c7d.x4d14ee33f46b5913("\\f", i);
			x16276ffa046c4080(xe1410f585439c7d, fontInfo);
			int num = 0;
			int num2 = xe4b3641e8e4ef359.x7e0944f4a3af6926(fontInfo.Charset, 1252);
			if (num2 == 932 || !x3de388916768234b(fontInfo.Name))
			{
				num = fontInfo.Charset;
			}
			xe1410f585439c7d.x4d14ee33f46b5913("\\fcharset", (fontInfo.Charset == 2 || x09d499c483428bd1.xadc83cc585a89881(fontInfo.Name)) ? 2 : num);
			xe2941f6436421fb8(xe1410f585439c7d, fontInfo);
			xe870b376d8d8c124(xe1410f585439c7d, fontInfo);
			string name = fontInfo.Name;
			string xbcea506a33cf = fontInfo.AltName;
			if (!x3de388916768234b(fontInfo.Name) && x3de388916768234b(fontInfo.AltName))
			{
				xbcea506a33cf = fontInfo.Name;
			}
			if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf))
			{
				xe1410f585439c7d.xf55384516c165731("\\*\\falt", xbcea506a33cf);
			}
			xe1410f585439c7d.x50f5dc167b3269a7(name);
			xe1410f585439c7d.x80fb22e7844d1324();
			xe1410f585439c7d.x4ecc66ceff7a75c0();
		}
		xe1410f585439c7d.xc8a13a52db0580ae();
		xe1410f585439c7d.x25d0efbd7848eeb3();
	}

	private static bool x3de388916768234b(string xf6987a1745781d6f)
	{
		for (int i = 0; i < xf6987a1745781d6f.Length; i++)
		{
			if (' ' > xf6987a1745781d6f[i] || xf6987a1745781d6f[i] >= '\u0080')
			{
				return false;
			}
		}
		return true;
	}

	private static void x16276ffa046c4080(xbfd162a6d47f59a4 xd07ce4b74c5774a7, FontInfo xfa5e135bae569bda)
	{
		switch (xfa5e135bae569bda.Family)
		{
		case FontFamily.Roman:
			xd07ce4b74c5774a7.x4d14ee33f46b5913("\\froman");
			break;
		case FontFamily.Swiss:
			xd07ce4b74c5774a7.x4d14ee33f46b5913("\\fswiss");
			break;
		case FontFamily.Modern:
			xd07ce4b74c5774a7.x4d14ee33f46b5913("\\fmodern");
			break;
		case FontFamily.Script:
			xd07ce4b74c5774a7.x4d14ee33f46b5913("\\fscript");
			break;
		case FontFamily.Decorative:
			xd07ce4b74c5774a7.x4d14ee33f46b5913("\\fdecor");
			break;
		default:
			xd07ce4b74c5774a7.x4d14ee33f46b5913("\\fnil");
			break;
		}
	}

	private static void xe2941f6436421fb8(xbfd162a6d47f59a4 xd07ce4b74c5774a7, FontInfo xfa5e135bae569bda)
	{
		switch (xfa5e135bae569bda.Pitch)
		{
		case FontPitch.Fixed:
			xd07ce4b74c5774a7.x4d14ee33f46b5913("\\fprq1");
			break;
		case FontPitch.Variable:
			xd07ce4b74c5774a7.x4d14ee33f46b5913("\\fprq2");
			break;
		case FontPitch.Default:
			break;
		}
	}

	private static void xe870b376d8d8c124(xbfd162a6d47f59a4 xd07ce4b74c5774a7, FontInfo xfa5e135bae569bda)
	{
		if (xfa5e135bae569bda.Panose != null)
		{
			xd07ce4b74c5774a7.xee60bff2900a72f2("\\*\\panose");
			xd07ce4b74c5774a7.xf7f536bd531211e3(xfa5e135bae569bda.Panose);
			xd07ce4b74c5774a7.xc8a13a52db0580ae();
		}
	}
}
