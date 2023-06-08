using System;
using System.Collections;
using System.IO;
using Aspose;
using x6c95d9cf46ff5f25;

namespace x4e7ae5a4b27b0834;

internal abstract class x3a5e4dec5f70539d
{
	protected readonly xc1d5d8a4d3290c43 x1ea60bde2b5d0d28;

	protected readonly xcb3ed34a3eba8ce2 x10b0407bbb8c5595;

	protected readonly x74fb8c43cb3523a2 xcb6243f33fefc8cf;

	protected readonly xcb3ed34a3eba8ce2 x847e0c79580546e9;

	protected readonly xcb3ed34a3eba8ce2 xf77d029f36995cdf;

	protected xcb3ed34a3eba8ce2 xafebd1e80ffb55bd;

	protected readonly xb67de7dfc17262be x6439f7732092858b;

	private static readonly byte[] x44d3e21115b53dd2 = new byte[1] { 14 };

	protected x3a5e4dec5f70539d(xc1d5d8a4d3290c43 header, xcb3ed34a3eba8ce2 nameIndex, x74fb8c43cb3523a2 topDict, xcb3ed34a3eba8ce2 stringIndex, xcb3ed34a3eba8ce2 globalSubrIndex, xcb3ed34a3eba8ce2 charStringIndex, xb67de7dfc17262be charset)
	{
		x1ea60bde2b5d0d28 = header;
		x10b0407bbb8c5595 = nameIndex;
		xcb6243f33fefc8cf = topDict;
		x847e0c79580546e9 = stringIndex;
		xf77d029f36995cdf = globalSubrIndex;
		xafebd1e80ffb55bd = charStringIndex;
		x6439f7732092858b = charset;
	}

	public static x3a5e4dec5f70539d x06b0e25aa6ad68a9(xa8866d7566da0aa2 x4c7b3ec871749b3b)
	{
		xe2451c6b5635cb1b xe2451c6b5635cb1b2 = new xe2451c6b5635cb1b(x4c7b3ec871749b3b);
		xc1d5d8a4d3290c43 header = xc1d5d8a4d3290c43.x06b0e25aa6ad68a9(xe2451c6b5635cb1b2);
		xcb3ed34a3eba8ce2 xcb3ed34a3eba8ce3 = xe2451c6b5635cb1b2.x53d922d8067784fb();
		if (xcb3ed34a3eba8ce3.x743de5a8c8cce84c != 1)
		{
			throw new InvalidOperationException("CFF data with multiple fonts is not supported.");
		}
		xcb3ed34a3eba8ce2 xcb3ed34a3eba8ce4 = xe2451c6b5635cb1b2.x53d922d8067784fb();
		if (xcb3ed34a3eba8ce4.x743de5a8c8cce84c != 1)
		{
			throw new InvalidOperationException("CFF data with multiple fonts is not supported.");
		}
		x74fb8c43cb3523a2 x74fb8c43cb3523a3 = x31c94dab5abeafcb.x1f490eac106aee12(xcb3ed34a3eba8ce4.xe84e6ff66aac2a0e(0));
		xcb3ed34a3eba8ce2 stringIndex = xe2451c6b5635cb1b2.x53d922d8067784fb();
		xcb3ed34a3eba8ce2 globalSubrIndex = xe2451c6b5635cb1b2.x53d922d8067784fb();
		if (x74fb8c43cb3523a3.x01833cfe9a0d0851 == 0)
		{
			throw new InvalidOperationException("Invalid CFF data.");
		}
		xe2451c6b5635cb1b2.xcaa93d37b4fef121(x74fb8c43cb3523a3.x01833cfe9a0d0851);
		xcb3ed34a3eba8ce2 xcb3ed34a3eba8ce5 = xe2451c6b5635cb1b2.x53d922d8067784fb();
		xb67de7dfc17262be charset = null;
		if (x74fb8c43cb3523a3.x6c82f2cb74c578e3 != 0)
		{
			xe2451c6b5635cb1b2.xcaa93d37b4fef121(x74fb8c43cb3523a3.x6c82f2cb74c578e3);
			charset = xb67de7dfc17262be.x06b0e25aa6ad68a9(xe2451c6b5635cb1b2, xcb3ed34a3eba8ce5.x743de5a8c8cce84c);
		}
		if (x74fb8c43cb3523a3.x2290b7de491ba59a)
		{
			return new xa580567aec85031c(xe2451c6b5635cb1b2, header, xcb3ed34a3eba8ce3, x74fb8c43cb3523a3, stringIndex, globalSubrIndex, xcb3ed34a3eba8ce5, charset);
		}
		return new x0da944b70fbbd699(xe2451c6b5635cb1b2, header, xcb3ed34a3eba8ce3, x74fb8c43cb3523a3, stringIndex, globalSubrIndex, xcb3ed34a3eba8ce5, charset);
	}

	public virtual void Subset(x09ce2c02826e31a6 usedGlyphs)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < xafebd1e80ffb55bd.x743de5a8c8cce84c; i++)
		{
			arrayList.Add(usedGlyphs.xbc5dc59d0d9b620d(i) ? xafebd1e80ffb55bd.xe84e6ff66aac2a0e(i) : x44d3e21115b53dd2);
		}
		xafebd1e80ffb55bd = new xcb3ed34a3eba8ce2(arrayList);
	}

	public byte[] xbdc1ba5a08db0865()
	{
		using MemoryStream memoryStream = new MemoryStream();
		x8d81a984b7f0332e(memoryStream);
		return memoryStream.ToArray();
	}

	public void x8d81a984b7f0332e(Stream xcf18e5243f8d5fd3)
	{
		x73087173962e3778 binaryWriter = new x73087173962e3778(xcf18e5243f8d5fd3);
		WriteToStream(binaryWriter);
	}

	[JavaThrows(true)]
	public abstract void WriteToStream(x73087173962e3778 binaryWriter);

	protected void x17ac0ca5dbf357a8(xc0e60c4cd8683899 xbdfb620b7167944b)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(xcb6243f33fefc8cf.xbdc1ba5a08db0865());
		xcb3ed34a3eba8ce2 xcb3ed34a3eba8ce3 = new xcb3ed34a3eba8ce2(arrayList);
		xcb3ed34a3eba8ce3.x6210059f049f0d48(xbdfb620b7167944b);
	}
}
