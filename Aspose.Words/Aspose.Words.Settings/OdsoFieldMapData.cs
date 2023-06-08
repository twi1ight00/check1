using System;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace Aspose.Words.Settings;

public class OdsoFieldMapData
{
	private int xccf74072a27d1bed;

	private bool x5b18199450f311aa;

	private x448900fcb384c333 xab1aa9a55818b87b = x448900fcb384c333.x2cee983cddd1e041;

	private string x9e105212df12667a = "";

	private string xc61ff88f1f98652d = "";

	private OdsoFieldMappingType xf263b01e2956834c = OdsoFieldMappingType.Null;

	public int Column
	{
		get
		{
			return xccf74072a27d1bed;
		}
		set
		{
			if (!x396403486c793a6b(value))
			{
				throw new ArgumentOutOfRangeException("value");
			}
			xccf74072a27d1bed = value;
		}
	}

	internal bool x3fe67f230278a6df
	{
		get
		{
			return x5b18199450f311aa;
		}
		set
		{
			x5b18199450f311aa = value;
		}
	}

	internal x448900fcb384c333 x448900fcb384c333
	{
		get
		{
			return xab1aa9a55818b87b;
		}
		set
		{
			xab1aa9a55818b87b = value;
		}
	}

	public string MappedName
	{
		get
		{
			return x9e105212df12667a;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x9e105212df12667a = value;
		}
	}

	public string Name
	{
		get
		{
			return xc61ff88f1f98652d;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			xc61ff88f1f98652d = value;
		}
	}

	public OdsoFieldMappingType Type
	{
		get
		{
			return xf263b01e2956834c;
		}
		set
		{
			xf263b01e2956834c = value;
		}
	}

	public OdsoFieldMapData Clone()
	{
		return (OdsoFieldMapData)MemberwiseClone();
	}

	internal void xc68740e2faa12e13(int xbcea506a33cf9111)
	{
		if (x396403486c793a6b(xbcea506a33cf9111))
		{
			xccf74072a27d1bed = xbcea506a33cf9111;
		}
	}

	private static bool x396403486c793a6b(int xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 >= 0;
	}
}
