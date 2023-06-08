using System;
using System.Collections;
using Aspose.Words;
using Aspose.Words.Markup;
using Aspose.Words.Properties;
using x6c95d9cf46ff5f25;

namespace x556d8f9846e43329;

internal class x1cf55bf1c1c040ec
{
	private static readonly Hashtable x6c5de3a2457ca7d0;

	private static readonly Hashtable x65ef1927db6b8083;

	private static readonly Hashtable x038ad58db9e1ef6e;

	private static readonly Hashtable xf5d8183a59385c8b;

	internal static object x66d300ae30bf6a9d(string xbcea506a33cf9111)
	{
		return x682712679dbc585a.xadb8a11581ae0f33(x6c5de3a2457ca7d0, xbcea506a33cf9111);
	}

	internal static string x4d0cb3d370d3a24f(LineStyle xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xadb8a11581ae0f33(x65ef1927db6b8083, xbcea506a33cf9111);
	}

	internal static object x882e9e26d2730a0c(string xbcea506a33cf9111)
	{
		return x682712679dbc585a.xadb8a11581ae0f33(x038ad58db9e1ef6e, xbcea506a33cf9111);
	}

	internal static string x9d5dacaca504e09d(PropertyType xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xadb8a11581ae0f33(xf5d8183a59385c8b, xbcea506a33cf9111);
	}

	internal static object xcfb37a90aa504061(string xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case "\\header":
		case "\\headerl":
			return HeaderFooterType.HeaderPrimary;
		case "\\footer":
		case "\\footerl":
			return HeaderFooterType.FooterPrimary;
		case "\\headerr":
			return HeaderFooterType.HeaderEven;
		case "\\headerf":
			return HeaderFooterType.HeaderFirst;
		case "\\footerr":
			return HeaderFooterType.FooterEven;
		case "\\footerf":
			return HeaderFooterType.FooterFirst;
		default:
			return null;
		}
	}

	internal static string xb85473ec132a8393(HeaderFooterType xbcea506a33cf9111, bool x394ace2d6bb001b5)
	{
		switch (xbcea506a33cf9111)
		{
		case HeaderFooterType.FooterPrimary:
			if (!x394ace2d6bb001b5)
			{
				return "\\footer";
			}
			return "\\footerr";
		case HeaderFooterType.HeaderEven:
			return "\\headerl";
		case HeaderFooterType.HeaderFirst:
			return "\\headerf";
		case HeaderFooterType.FooterEven:
			return "\\footerl";
		case HeaderFooterType.FooterFirst:
			return "\\footerf";
		default:
			if (!x394ace2d6bb001b5)
			{
				return "\\header";
			}
			return "\\headerr";
		}
	}

	internal static string x58e028bc9916ae9f(MarkupLevel xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			MarkupLevel.Unknown => "\\xmlsdttunknown", 
			MarkupLevel.Inline => "\\xmlsdttregular", 
			MarkupLevel.Block => "\\xmlsdttpara", 
			MarkupLevel.Cell => "\\xmlsdttcell", 
			MarkupLevel.Row => "\\xmlsdttrow", 
			_ => throw new InvalidOperationException("Unexpected markup level."), 
		};
	}

	static x1cf55bf1c1c040ec()
	{
		x6c5de3a2457ca7d0 = new Hashtable();
		x65ef1927db6b8083 = new Hashtable();
		x038ad58db9e1ef6e = new Hashtable();
		xf5d8183a59385c8b = new Hashtable();
		x682712679dbc585a.x70fa1602ceccddee(new object[52]
		{
			"\\brdrs",
			LineStyle.Single,
			"\\brdrth",
			LineStyle.Thick,
			"\\brdrdb",
			LineStyle.Double,
			"\\brdrdot",
			LineStyle.Dot,
			"\\brdrdash",
			LineStyle.DashLargeGap,
			"\\brdrhair",
			LineStyle.Hairline,
			"\\brdrinset",
			LineStyle.Inset,
			"\\brdrdashsm",
			LineStyle.DashSmallGap,
			"\\brdrdashd",
			LineStyle.DotDash,
			"\\brdrdashdd",
			LineStyle.DotDotDash,
			"\\brdroutset",
			LineStyle.Outset,
			"\\brdrtriple",
			LineStyle.Triple,
			"\\brdrtnthsg",
			LineStyle.ThinThickSmallGap,
			"\\brdrthtnsg",
			LineStyle.ThickThinSmallGap,
			"\\brdrtnthtnsg",
			LineStyle.ThinThickThinSmallGap,
			"\\brdrtnthmg",
			LineStyle.ThinThickMediumGap,
			"\\brdrthtnmg",
			LineStyle.ThickThinMediumGap,
			"\\brdrtnthtnmg",
			LineStyle.ThinThickThinMediumGap,
			"\\brdrtnthlg",
			LineStyle.ThinThickLargeGap,
			"\\brdrthtnlg",
			LineStyle.ThickThinLargeGap,
			"\\brdrtnthtnlg",
			LineStyle.ThinThickThinLargeGap,
			"\\brdrwavy",
			LineStyle.Wave,
			"\\brdrwavydb",
			LineStyle.DoubleWave,
			"\\brdrdashdotstr",
			LineStyle.DashDotStroker,
			"\\brdremboss",
			LineStyle.Emboss3D,
			"\\brdrengrave",
			LineStyle.Engrave3D
		}, x6c5de3a2457ca7d0, x65ef1927db6b8083);
		x682712679dbc585a.x70fa1602ceccddee(new object[10]
		{
			"3",
			PropertyType.Number,
			"5",
			PropertyType.Double,
			"64",
			PropertyType.DateTime,
			"11",
			PropertyType.Boolean,
			"30",
			PropertyType.String
		}, x038ad58db9e1ef6e, xf5d8183a59385c8b);
	}
}
