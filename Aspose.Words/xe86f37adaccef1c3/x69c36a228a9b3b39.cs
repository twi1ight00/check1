namespace xe86f37adaccef1c3;

internal class x69c36a228a9b3b39
{
	private const char xc6fa35b02c9a1de9 = '.';

	private x69c36a228a9b3b39()
	{
	}

	internal static bool x5f21ccf084377ea8(xa11a4c48b53f49a6 xef1769c4fe6ae4ca, string x66ac3558868cc255, out object x5fc53c4ffd3eb8c9)
	{
		return xef1769c4fe6ae4ca.x3f88a25febd23896(xef1769c4fe6ae4ca.x74b8d10dd9d29ac2(x66ac3558868cc255), out x5fc53c4ffd3eb8c9);
	}

	internal static bool xda36a3450e67c2d7(xa11a4c48b53f49a6 xef1769c4fe6ae4ca, int x8e9b5f316bf9cf3d)
	{
		if (x8e9b5f316bf9cf3d >= 0)
		{
			return x8e9b5f316bf9cf3d < xef1769c4fe6ae4ca.x8d29312d6fdcad86;
		}
		return false;
	}

	internal static bool xe19ff57f82f3515e(xa11a4c48b53f49a6 xef1769c4fe6ae4ca)
	{
		return xef1769c4fe6ae4ca is x77c422f73b569bd1;
	}

	internal static int x85f795c533a8433f(string x66ac3558868cc255)
	{
		return x66ac3558868cc255.IndexOf('.');
	}

	internal static int x9d4069700729134e(string x66ac3558868cc255)
	{
		return x66ac3558868cc255.LastIndexOf('.');
	}

	internal static string x08b8822c2b320c6a(string x66ac3558868cc255, int x8524f833bcefcc56)
	{
		if (x8524f833bcefcc56 != -1)
		{
			return x66ac3558868cc255.Substring(0, x8524f833bcefcc56);
		}
		return string.Empty;
	}

	internal static string x7a72474f72a62daf(string x66ac3558868cc255, int x8524f833bcefcc56)
	{
		if (x8524f833bcefcc56 != -1)
		{
			return x66ac3558868cc255.Substring(x8524f833bcefcc56 + 1);
		}
		return x66ac3558868cc255;
	}
}
