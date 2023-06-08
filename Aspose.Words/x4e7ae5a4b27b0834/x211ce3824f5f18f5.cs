using System;
using System.Collections;

namespace x4e7ae5a4b27b0834;

internal class x211ce3824f5f18f5
{
	private readonly byte[] xf671eea08814489a;

	private int x57d3c0a64c1df452;

	private ArrayList x990b9fd06575b0cf = new ArrayList();

	private readonly Hashtable x802c86ffb5402a2c = new Hashtable();

	public Hashtable x57bfe153dea0dabb => x802c86ffb5402a2c;

	public bool x779fe2de941a42cc => x57d3c0a64c1df452 >= xf671eea08814489a.Length;

	public x211ce3824f5f18f5(byte[] binaryDictData)
	{
		xf671eea08814489a = binaryDictData;
	}

	public byte x672ed37ee25c078c()
	{
		if (x57d3c0a64c1df452 >= xf671eea08814489a.Length)
		{
			throw new InvalidOperationException("Invalid CFF DICT data.");
		}
		return xf671eea08814489a[x57d3c0a64c1df452++];
	}

	public void xa4de9ee8a5ef1b1b(int x137ffa3012d6a67d)
	{
		x990b9fd06575b0cf.Add(x137ffa3012d6a67d);
	}

	public void x9f95c541c346e6f8(double x137ffa3012d6a67d)
	{
		x990b9fd06575b0cf.Add(x137ffa3012d6a67d);
	}

	public void x3d11dfe63c9c8329(int xba08ce632055a1d9)
	{
		x802c86ffb5402a2c.Add(xba08ce632055a1d9, x990b9fd06575b0cf);
		x990b9fd06575b0cf = new ArrayList();
	}
}
