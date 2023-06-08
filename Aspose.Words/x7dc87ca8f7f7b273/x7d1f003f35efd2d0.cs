using System;
using System.IO;
using x38a89dee67fc7a16;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x7dc87ca8f7f7b273;

internal class x7d1f003f35efd2d0 : xc7a77b17ac8b122b
{
	private string xcf4dfce2fb15e740;

	private xfe2ff3c162b47c70 xedcf13d9a3fd42bd;

	private byte[] xd08494dce3b2b550;

	private xa2745adfabe0c674 xbfcb11d1f4e5d8ba;

	internal string xaa2bf8c845776543 => xcf4dfce2fb15e740;

	private string x1cdb46ecf83a213d => $"{xcf4dfce2fb15e740}.{xb9015fe823e7e228.xac88cb4f794761a9(xedcf13d9a3fd42bd)}";

	public x7d1f003f35efd2d0(string imageId, byte[] imageBytes, xd878af0d0717b77a context)
		: base(context)
	{
		xcf4dfce2fb15e740 = imageId;
		xd08494dce3b2b550 = imageBytes;
		xedcf13d9a3fd42bd = xdd1b8f14cc8ba86d.x22bfb60fc9ca9282(imageBytes);
		xbfcb11d1f4e5d8ba = xdd1b8f14cc8ba86d.x16a7fb03c627ebfb(imageBytes);
	}

	internal void x5664f05a403c3b73()
	{
		if (!base.x28fcdc775a1d069c.x73979cef1002ed01.x016e5a0032b3cd7b)
		{
			if (!Directory.Exists(base.x28fcdc775a1d069c.x73979cef1002ed01.xda77249ca2dc4984))
			{
				Directory.CreateDirectory(base.x28fcdc775a1d069c.x73979cef1002ed01.xda77249ca2dc4984);
			}
			string path = Path.Combine(base.x28fcdc775a1d069c.x73979cef1002ed01.xda77249ca2dc4984, x1cdb46ecf83a213d);
			using FileStream fileStream = new FileStream(path, FileMode.Create);
			fileStream.Write(xd08494dce3b2b550, 0, xd08494dce3b2b550.Length);
		}
		string xbcea506a33cf = (base.x28fcdc775a1d069c.x73979cef1002ed01.x016e5a0032b3cd7b ? $"data:{xb9015fe823e7e228.x0ad80fdc3fba643e(xedcf13d9a3fd42bd)};base64,{Convert.ToBase64String(xd08494dce3b2b550)}" : x42c33a84572527a4(x1cdb46ecf83a213d));
		base.x5aa326f374b3d0ef.x2307058321cdb62f("image");
		base.x5aa326f374b3d0ef.xff520a0047c27122("id", xcf4dfce2fb15e740);
		base.x5aa326f374b3d0ef.xff520a0047c27122("xlink:href", xbcea506a33cf);
		base.x5aa326f374b3d0ef.xff520a0047c27122("width", xca004f56614e2431.x37804260a70f74eb(xbfcb11d1f4e5d8ba.xdc1bf80853046136));
		base.x5aa326f374b3d0ef.xff520a0047c27122("height", xca004f56614e2431.x37804260a70f74eb(xbfcb11d1f4e5d8ba.xb0f146032f47c24e));
		base.x5aa326f374b3d0ef.x2dfde153f4ef96d0();
	}

	private string x42c33a84572527a4(string xafe2f3653ee64ebc)
	{
		if (!x0d4d45882065c63e.xe06270bc72b12369(xafe2f3653ee64ebc))
		{
			return x0d4d45882065c63e.xda76dc634eb9b4f6(base.x28fcdc775a1d069c.x73979cef1002ed01.x95e7cce59d14bdff, Path.GetFileName(xafe2f3653ee64ebc));
		}
		return xafe2f3653ee64ebc;
	}
}
