using System.Collections;
using Aspose.Words.Lists;
using x6c95d9cf46ff5f25;
using xd2754ae26d400653;

namespace x909757d9fd2dd6ae;

internal class x4a909034643add70
{
	private static readonly Hashtable x490eeedc094f56e8;

	private static readonly Hashtable xa349d49739314cf8;

	private static readonly Hashtable x9189e363682945c8;

	private static readonly Hashtable x2caa1188c38d660e;

	private static readonly Hashtable x89544011f68b3540;

	private static readonly Hashtable x29c7d0ce2d49c50a;

	internal static ListLevelAlignment x7fb9f8881a674951(string xbcea506a33cf9111)
	{
		return (ListLevelAlignment)x682712679dbc585a.xce92de628aa023cf(x490eeedc094f56e8, xbcea506a33cf9111, ListLevelAlignment.Left);
	}

	internal static string x9ad35d4738b8b3a0(ListLevelAlignment xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(xa349d49739314cf8, xbcea506a33cf9111, "");
	}

	internal static ListTrailingCharacter xe7988d6d8f3f1ebb(string xbcea506a33cf9111)
	{
		return (ListTrailingCharacter)x682712679dbc585a.xce92de628aa023cf(x9189e363682945c8, xbcea506a33cf9111, ListTrailingCharacter.Tab);
	}

	internal static string xa59cf2a9649328d2(ListTrailingCharacter xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x2caa1188c38d660e, xbcea506a33cf9111, "");
	}

	internal static x902c8ac86fbaf048 xa7195da66e758014(string xbcea506a33cf9111)
	{
		return (x902c8ac86fbaf048)x682712679dbc585a.xce92de628aa023cf(x89544011f68b3540, xbcea506a33cf9111, x902c8ac86fbaf048.x598f41525926b38a);
	}

	internal static string xc042c81bbc46cc9d(x902c8ac86fbaf048 xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x29c7d0ce2d49c50a, xbcea506a33cf9111, "");
	}

	static x4a909034643add70()
	{
		x490eeedc094f56e8 = new Hashtable();
		xa349d49739314cf8 = new Hashtable();
		x9189e363682945c8 = new Hashtable();
		x2caa1188c38d660e = new Hashtable();
		x89544011f68b3540 = new Hashtable();
		x29c7d0ce2d49c50a = new Hashtable();
		x682712679dbc585a.x70fa1602ceccddee(new object[6]
		{
			"singleLevel",
			x902c8ac86fbaf048.xabed123f43874357,
			"multilevel",
			x902c8ac86fbaf048.x7e86ac926e2dc940,
			"hybridMultilevel",
			x902c8ac86fbaf048.x598f41525926b38a
		}, x89544011f68b3540, x29c7d0ce2d49c50a);
		x682712679dbc585a.x70fa1602ceccddee(new object[6]
		{
			"tab",
			ListTrailingCharacter.Tab,
			"space",
			ListTrailingCharacter.Space,
			"nothing",
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
