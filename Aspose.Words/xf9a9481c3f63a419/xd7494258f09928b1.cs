using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using Aspose;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xeb665d1aeef09d64;

namespace xf9a9481c3f63a419;

[JavaManual("Manual porting by design.")]
internal class xd7494258f09928b1 : IDisposable
{
	private PrivateFontCollection x3092c79aa91daec1;

	public xd7494258f09928b1()
	{
		x3092c79aa91daec1 = new PrivateFontCollection();
	}

	public void Dispose()
	{
		if (x3092c79aa91daec1 != null)
		{
			x3092c79aa91daec1.Dispose();
			x3092c79aa91daec1 = null;
		}
		GC.SuppressFinalize(this);
	}

	public FontFamily x12c77118432cdb0a(xe39d06eee35dd23d x26094932cf7a9139)
	{
		xb903a6eec2b2ddab(x26094932cf7a9139.x29f65b3e7616f6b3.x6b73aa01aa019d3a);
		return xc00c77516e0f3d4a(x26094932cf7a9139.x6054c4379c01a50d);
	}

	private void xb903a6eec2b2ddab(x25998da3963930e9 x0db5e88527e18b81)
	{
		if (x0db5e88527e18b81 is xda6c010448467ed0)
		{
			x3092c79aa91daec1.AddFontFile(((xda6c010448467ed0)x0db5e88527e18b81).xa39af5a82860a9a3);
		}
		else if (x0db5e88527e18b81 is x6033a882faba96b0)
		{
			xd78a1a64ba668c04((x6033a882faba96b0)x0db5e88527e18b81);
		}
	}

	private void xd78a1a64ba668c04(x6033a882faba96b0 x0db5e88527e18b81)
	{
		byte[] x6b73aa01aa019d3a = x0db5e88527e18b81.x6b73aa01aa019d3a;
		GCHandle gCHandle = GCHandle.Alloc(x6b73aa01aa019d3a, GCHandleType.Pinned);
		try
		{
			x3092c79aa91daec1.AddMemoryFont(gCHandle.AddrOfPinnedObject(), x6b73aa01aa019d3a.Length);
		}
		finally
		{
			gCHandle.Free();
		}
	}

	private FontFamily xc00c77516e0f3d4a(string xa79a9f649c74f4a4)
	{
		FontFamily[] families = x3092c79aa91daec1.Families;
		foreach (FontFamily fontFamily in families)
		{
			if (x0d299f323d241756.x90637a473b1ceaaa(fontFamily.Name, xa79a9f649c74f4a4))
			{
				return fontFamily;
			}
		}
		return null;
	}
}
