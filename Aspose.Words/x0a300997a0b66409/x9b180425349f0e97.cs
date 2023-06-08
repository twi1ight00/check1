using System.Collections;
using Aspose.Words.Lists;
using x6c95d9cf46ff5f25;
using xd2754ae26d400653;

namespace x0a300997a0b66409;

internal class x9b180425349f0e97
{
	private static Hashtable x490eeedc094f56e8;

	private static Hashtable xa349d49739314cf8;

	private static Hashtable x9189e363682945c8;

	private static Hashtable x2caa1188c38d660e;

	private static Hashtable x89544011f68b3540;

	private static Hashtable x29c7d0ce2d49c50a;

	internal static ListLevelAlignment x4f2808bdcd309b20(string xbcea506a33cf9111)
	{
		return (ListLevelAlignment)x682712679dbc585a.xce92de628aa023cf(x490eeedc094f56e8, xbcea506a33cf9111, ListLevelAlignment.Left);
	}

	internal static string x2d34925176627bf2(ListLevelAlignment xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(xa349d49739314cf8, xbcea506a33cf9111, "");
	}

	internal static ListTrailingCharacter xdbbf86845de5168c(string xbcea506a33cf9111)
	{
		return (ListTrailingCharacter)x682712679dbc585a.xce92de628aa023cf(x9189e363682945c8, xbcea506a33cf9111, ListTrailingCharacter.Tab);
	}

	internal static string xa01b2bd227f7b4da(ListTrailingCharacter xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x2caa1188c38d660e, xbcea506a33cf9111, "");
	}

	internal static x902c8ac86fbaf048 x5097c5508e9b2327(string xbcea506a33cf9111)
	{
		return (x902c8ac86fbaf048)x682712679dbc585a.xce92de628aa023cf(x89544011f68b3540, xbcea506a33cf9111, x902c8ac86fbaf048.x598f41525926b38a);
	}

	internal static string xead78d0a9a85d806(x902c8ac86fbaf048 xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x29c7d0ce2d49c50a, xbcea506a33cf9111, "");
	}

	static x9b180425349f0e97()
	{
		x490eeedc094f56e8 = new Hashtable();
		xa349d49739314cf8 = new Hashtable();
		x9189e363682945c8 = new Hashtable();
		x2caa1188c38d660e = new Hashtable();
		x89544011f68b3540 = new Hashtable();
		x29c7d0ce2d49c50a = new Hashtable();
		x682712679dbc585a.x70fa1602ceccddee(new object[6]
		{
			"SingleLevel",
			x902c8ac86fbaf048.xabed123f43874357,
			"Multilevel",
			x902c8ac86fbaf048.x7e86ac926e2dc940,
			"HybridMultilevel",
			x902c8ac86fbaf048.x598f41525926b38a
		}, x89544011f68b3540, x29c7d0ce2d49c50a);
		x682712679dbc585a.x70fa1602ceccddee(new object[6]
		{
			"Tab",
			ListTrailingCharacter.Tab,
			"Space",
			ListTrailingCharacter.Space,
			"Nothing",
			ListTrailingCharacter.Nothing
		}, x9189e363682945c8, x2caa1188c38d660e);
		x682712679dbc585a.x70fa1602ceccddee(new object[6]
		{
			"left",
			ListLevelAlignment.Left,
			"center",
			ListLevelAlignment.Center,
			"right",
			ListLevelAlignment.Right
		}, x490eeedc094f56e8, xa349d49739314cf8);
	}
}
