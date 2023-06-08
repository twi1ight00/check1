using Aspose;

namespace xe8730a664ff488a4;

[JavaDelete("Using java zip instead.")]
internal class x3c933dd351cac3e2 : xacfc697a3fda7a96
{
	private int _x964e9e38fb90a331;

	public int x83f08641b719ef01 => _x964e9e38fb90a331;

	internal x3c933dd351cac3e2(string archiveName, bool before, int entriesTotal, int entriesSaved, x990d54f34b2b5118 entry)
		: base(archiveName, before ? xebcb692fc67da2dc.x0dba1a762d142e87 : xebcb692fc67da2dc.xcac1b9af04b0e040)
	{
		base.xc26905cb3cd68e4f = entriesTotal;
		base.x0daee7c95d8427c1 = entry;
		_x964e9e38fb90a331 = entriesSaved;
	}

	internal x3c933dd351cac3e2()
	{
	}

	internal x3c933dd351cac3e2(string archiveName, xebcb692fc67da2dc flavor)
		: base(archiveName, flavor)
	{
	}

	internal static x3c933dd351cac3e2 x810c3600b79742ed(string xa870ff4b6375ac41, x990d54f34b2b5118 xa85f9dbcec37a9e8, long x2c753a2e97e475c8, long xe8ff41b62490d441)
	{
		x3c933dd351cac3e2 x3c933dd351cac3e3 = new x3c933dd351cac3e2(xa870ff4b6375ac41, xebcb692fc67da2dc.x0ea4c93d39dbc2cf);
		x3c933dd351cac3e3.xe1c4539b73a8edbd = xa870ff4b6375ac41;
		x3c933dd351cac3e3.x0daee7c95d8427c1 = xa85f9dbcec37a9e8;
		x3c933dd351cac3e3.x043e8be240f283da = x2c753a2e97e475c8;
		x3c933dd351cac3e3.x8af5333be34a291b = xe8ff41b62490d441;
		return x3c933dd351cac3e3;
	}

	internal static x3c933dd351cac3e2 x33ea497bc266278e(string xa870ff4b6375ac41)
	{
		return new x3c933dd351cac3e2(xa870ff4b6375ac41, xebcb692fc67da2dc.xc542121d0acfae7e);
	}

	internal static x3c933dd351cac3e2 x8720d4da1213e1b9(string xa870ff4b6375ac41)
	{
		return new x3c933dd351cac3e2(xa870ff4b6375ac41, xebcb692fc67da2dc.x1bbc48e400d804ee);
	}
}
