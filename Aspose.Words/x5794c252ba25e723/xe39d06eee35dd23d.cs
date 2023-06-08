using System;
using System.Drawing;
using x66dd9eaee57cfba4;
using x6c95d9cf46ff5f25;

namespace x5794c252ba25e723;

internal class xe39d06eee35dd23d
{
	public const float xa20d46fe779187d5 = 0.34906584f;

	private readonly x6b1a899052c71a60 xac88ab1ad8edf588;

	private float x776db2be475f2013;

	private readonly FontStyle x5d9fbd9603e9dee5;

	private readonly float xe56c9d7c46cb4194;

	private readonly float x041fabed1c053b53;

	private readonly float xb05c3fbba5415005;

	public x6b1a899052c71a60 x29f65b3e7616f6b3 => xac88ab1ad8edf588;

	public FontStyle xfe2178c1f916f36c => x5d9fbd9603e9dee5;

	public bool xa143daf3bef8b339 => (x5d9fbd9603e9dee5 & FontStyle.Bold) != 0;

	public bool xb65ca9637cc40782 => (x5d9fbd9603e9dee5 & FontStyle.Italic) != 0;

	public bool x30c7b3201d032345
	{
		get
		{
			if (xa143daf3bef8b339)
			{
				return !xac88ab1ad8edf588.xa143daf3bef8b339;
			}
			return false;
		}
	}

	public bool xda4c813a32b9109b
	{
		get
		{
			if (xb65ca9637cc40782)
			{
				return !xac88ab1ad8edf588.xb65ca9637cc40782;
			}
			return false;
		}
	}

	public string x6054c4379c01a50d => xac88ab1ad8edf588.x6054c4379c01a50d;

	public float x53531537bb3331e6
	{
		get
		{
			return x776db2be475f2013;
		}
		set
		{
			x776db2be475f2013 = value;
		}
	}

	public float xd9ac1486133b5a4e => xe56c9d7c46cb4194;

	public float x6b0006bdae665f50 => x041fabed1c053b53;

	public float xad4d3652239d8aaa => xe56c9d7c46cb4194 + x041fabed1c053b53;

	public int x2e2459728eaf2cdd => x4574ea26106f0edb.x8d50b8a62ba1cd84(xe56c9d7c46cb4194);

	public int x5b4efc81d968cb1e => x4574ea26106f0edb.x8d50b8a62ba1cd84(x041fabed1c053b53);

	public int x4df650f2b5858aa1 => x2e2459728eaf2cdd + x5b4efc81d968cb1e;

	public int x31a274b2303f0ca3 => x72bffa11f855e2cc - x4df650f2b5858aa1;

	public int x72bffa11f855e2cc => x4574ea26106f0edb.x8d50b8a62ba1cd84(xb05c3fbba5415005);

	public float x8a25c402b95f9dea => xb05c3fbba5415005;

	public xe39d06eee35dd23d(float sizePoints, FontStyle style, x6b1a899052c71a60 trueTypeFont)
	{
		if (trueTypeFont == null)
		{
			throw new ArgumentNullException("trueTypeFont");
		}
		xac88ab1ad8edf588 = trueTypeFont;
		x776db2be475f2013 = sizePoints;
		x5d9fbd9603e9dee5 = style;
		xe56c9d7c46cb4194 = xac88ab1ad8edf588.x9ca5cd40518c72a9(xac88ab1ad8edf588.x3f80ed349f729542, x776db2be475f2013);
		x041fabed1c053b53 = xac88ab1ad8edf588.x9ca5cd40518c72a9(xac88ab1ad8edf588.xc9f7bec53c29c691, x776db2be475f2013);
		xb05c3fbba5415005 = xac88ab1ad8edf588.x9ca5cd40518c72a9(xac88ab1ad8edf588.x84bbacdc1fc0efd2, x776db2be475f2013);
	}

	public float x30e45ef93fedb4ba(int x3c4da2980d043c95)
	{
		return xac88ab1ad8edf588.x30e45ef93fedb4ba(x3c4da2980d043c95, x776db2be475f2013);
	}

	public float xee2b4ba51feab3ca(string xb41faee6912a2313)
	{
		return xac88ab1ad8edf588.xee2b4ba51feab3ca(xb41faee6912a2313, x776db2be475f2013);
	}

	public SizeF x6e21842ebf5f70df(string xb41faee6912a2313)
	{
		return new SizeF(xee2b4ba51feab3ca(xb41faee6912a2313), xad4d3652239d8aaa);
	}

	public int xbd8bafb15a2ab581(int x3c4da2980d043c95)
	{
		return x4574ea26106f0edb.x8d50b8a62ba1cd84(x30e45ef93fedb4ba(x3c4da2980d043c95));
	}

	public int x8e6657c75f309f30(string xb41faee6912a2313)
	{
		return x4574ea26106f0edb.x8d50b8a62ba1cd84(xee2b4ba51feab3ca(xb41faee6912a2313));
	}

	public static bool x6a6bee62104c093d(string x9e9070c6c983bbc0)
	{
		return x0d299f323d241756.x90637a473b1ceaaa(x9e9070c6c983bbc0, "Microsoft Sans Serif");
	}

	public float x041cf8431814083a(int xa447fc54e41dfe06, int xfc2074a859a5db8c)
	{
		return xac88ab1ad8edf588.x041cf8431814083a(xa447fc54e41dfe06, xfc2074a859a5db8c, x776db2be475f2013);
	}
}
