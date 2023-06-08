using System;
using Aspose;

namespace xe8730a664ff488a4;

[JavaDelete("Using java zip instead.")]
internal struct x7540eedf8f68f598
{
	private bool x2026ecfd6600cd0e;

	internal long xbcea506a33cf9111;

	public bool x2d5c1249b31d3c86 => x2026ecfd6600cd0e;

	public long xd2f68ee6f47e9dfb
	{
		get
		{
			if (!x2d5c1249b31d3c86)
			{
				throw new InvalidOperationException("NullableInt64 doesn't have a value.");
			}
			return xbcea506a33cf9111;
		}
	}

	public x7540eedf8f68f598(long value)
	{
		xbcea506a33cf9111 = value;
		x2026ecfd6600cd0e = true;
	}

	public long xdefaa8a449d64f38()
	{
		return xbcea506a33cf9111;
	}

	public long xdefaa8a449d64f38(long xc6e85c82d0d89508)
	{
		if (!x2d5c1249b31d3c86)
		{
			return xc6e85c82d0d89508;
		}
		return xbcea506a33cf9111;
	}

	public override bool Equals(object other)
	{
		if (!x2d5c1249b31d3c86)
		{
			return other == null;
		}
		if (other == null)
		{
			return false;
		}
		return xbcea506a33cf9111.Equals(other);
	}

	public override int GetHashCode()
	{
		if (!x2d5c1249b31d3c86)
		{
			return 0;
		}
		return xbcea506a33cf9111.GetHashCode();
	}

	public override string ToString()
	{
		if (!x2d5c1249b31d3c86)
		{
			return "";
		}
		return xbcea506a33cf9111.ToString();
	}
}
