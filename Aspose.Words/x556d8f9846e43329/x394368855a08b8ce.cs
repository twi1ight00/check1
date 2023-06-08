using System.Collections;
using Aspose.Words;
using x2845e7a1a7dc898b;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace x556d8f9846e43329;

internal class x394368855a08b8ce
{
	private static Hashtable x7f6445867bb97b1c;

	private static Hashtable xbe4df92cd3d0a724;

	private static Hashtable x56f4cb80c2072679;

	private static Hashtable x3a0c4d45aadcf22d;

	internal static object xbc7564cadceec1c0(string x5b1c8ddab0846b39, object x747c4305eacc59f2, bool xe35465df41d6171f)
	{
		object obj = x682712679dbc585a.xadb8a11581ae0f33(x7f6445867bb97b1c, x5b1c8ddab0846b39);
		if (obj != null && !xe35465df41d6171f)
		{
			Underline underline = (Underline)obj;
			obj = ((underline != Underline.Single && (x747c4305eacc59f2 == null || (Underline)x747c4305eacc59f2 != underline)) ? null : ((object)Underline.None));
		}
		return obj;
	}

	internal static string x8f47b77a97eefb62(Underline xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xadb8a11581ae0f33(xbe4df92cd3d0a724, xbcea506a33cf9111);
	}

	internal static object x2e021ec350b917d6(string xbcea506a33cf9111)
	{
		return x682712679dbc585a.xadb8a11581ae0f33(x56f4cb80c2072679, xbcea506a33cf9111);
	}

	internal static string xac5a7a97f8b14aea(TextureIndex xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xadb8a11581ae0f33(x3a0c4d45aadcf22d, xbcea506a33cf9111);
	}

	internal static string x4aee1264f35da812(x4a2f68a519ee2183 xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			x4a2f68a519ee2183.xcc4f8cd12606a197 => "\\acccircle", 
			x4a2f68a519ee2183.x729684579d564d8e => "\\acccomma", 
			x4a2f68a519ee2183.x3cb6807e93737c2d => "\\accdot", 
			x4a2f68a519ee2183.xe2ef50de35a099e5 => "\\accunderdot", 
			_ => "", 
		};
	}

	internal static string x84544ae95693fd62(xf80d6ac0b6a56f39 x76cfa3dae9eed735)
	{
		if (x76cfa3dae9eed735.x61c108cc44ef385a)
		{
			return $"\\horzvert{(x76cfa3dae9eed735.x8983dff00ce7e17a ? 1 : 0)}";
		}
		return $"\\twoinone{(int)x76cfa3dae9eed735.x69ec038defa753a8}";
	}

	internal static x4a2f68a519ee2183 xb17c9eac2ec5751b(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"\\acccircle" => x4a2f68a519ee2183.xcc4f8cd12606a197, 
			"\\acccomma" => x4a2f68a519ee2183.x729684579d564d8e, 
			"\\accdot" => x4a2f68a519ee2183.x3cb6807e93737c2d, 
			"\\accunderdot" => x4a2f68a519ee2183.xe2ef50de35a099e5, 
			_ => x4a2f68a519ee2183.x4d0b9d4447ba7566, 
		};
	}

	private x394368855a08b8ce()
	{
	}

	static x394368855a08b8ce()
	{
		x7f6445867bb97b1c = new Hashtable();
		xbe4df92cd3d0a724 = new Hashtable();
		x56f4cb80c2072679 = new Hashtable();
		x3a0c4d45aadcf22d = new Hashtable();
		x682712679dbc585a.x70fa1602ceccddee(new object[36]
		{
			"\\ulnone",
			Underline.None,
			"\\ul",
			Underline.Single,
			"\\ulw",
			Underline.Words,
			"\\uld",
			Underline.Dotted,
			"\\uldash",
			Underline.Dash,
			"\\uldashd",
			Underline.DotDash,
			"\\uldashdd",
			Underline.DotDotDash,
			"\\uldb",
			Underline.Double,
			"\\ulhwave",
			Underline.WavyHeavy,
			"\\ulldash",
			Underline.DashLong,
			"\\ulth",
			Underline.Thick,
			"\\ulthd",
			Underline.DottedHeavy,
			"\\ulthdash",
			Underline.DashHeavy,
			"\\ulthdashd",
			Underline.DotDashHeavy,
			"\\ulthdashdd",
			Underline.DotDotDashHeavy,
			"\\ulthldash",
			Underline.DashLongHeavy,
			"\\ululdbwave",
			Underline.WavyDouble,
			"\\ulwave",
			Underline.Wavy
		}, x7f6445867bb97b1c, xbe4df92cd3d0a724);
		x682712679dbc585a.x70fa1602ceccddee(new object[24]
		{
			"\\chbghoriz",
			TextureIndex.TextureHorizontal,
			"\\chbgvert",
			TextureIndex.TextureVertical,
			"\\chbgfdiag",
			TextureIndex.TextureDiagonalDown,
			"\\chbgbdiag",
			TextureIndex.TextureDiagonalUp,
			"\\chbgcross",
			TextureIndex.TextureCross,
			"\\chbgdcross",
			TextureIndex.TextureDiagonalCross,
			"\\chbgdkhoriz",
			TextureIndex.TextureDarkHorizontal,
			"\\chbgdkvert",
			TextureIndex.TextureDarkVertical,
			"\\chbgdkfdiag",
			TextureIndex.TextureDarkDiagonalDown,
			"\\chbgdkbdiag",
			TextureIndex.TextureDarkDiagonalUp,
			"\\chbgdkcross",
			TextureIndex.TextureDarkCross,
			"\\chbgdkdcross",
			TextureIndex.TextureDarkDiagonalCross
		}, x56f4cb80c2072679, x3a0c4d45aadcf22d);
	}
}
