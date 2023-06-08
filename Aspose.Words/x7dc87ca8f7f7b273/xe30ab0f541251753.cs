using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using x1c8faa688b1f0b0c;
using x38a89dee67fc7a16;
using x5794c252ba25e723;
using x66dd9eaee57cfba4;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x7dc87ca8f7f7b273;

internal class xe30ab0f541251753 : xc7a77b17ac8b122b
{
	private SizeF x6b42455c528c54af;

	private readonly x3c74b3c4f21844f9 xc4cc21b78abf1fcf;

	private readonly xed9035f57046e423 x24cf489dc5492c87;

	private readonly Stack x100c1e4bd6e3d9e2 = new Stack();

	private readonly x4ff8ecf10eb0714f x623c83a0867aace8 = new x4ff8ecf10eb0714f();

	public SizeF x840f0682785efa25 => x6b42455c528c54af;

	public xe30ab0f541251753(xd878af0d0717b77a context)
		: base(context)
	{
		xc4cc21b78abf1fcf = new x3c74b3c4f21844f9(new MemoryStream(), context.x73979cef1002ed01.x953b08b2c4ae3d24);
		x24cf489dc5492c87 = new xed9035f57046e423(context, xc4cc21b78abf1fcf);
	}

	public void xa1cc26fee27f9d36()
	{
		string @string = Encoding.UTF8.GetString(x0d299f323d241756.xa0aed4cd3b3d5d92(xc4cc21b78abf1fcf.x5222f4285e37d66b.BaseStream));
		@string = @string.Substring(@string.IndexOf('<'));
		xc4cc21b78abf1fcf.x5222f4285e37d66b.BaseStream.Close();
		base.x5aa326f374b3d0ef.xd52401bdf5aacef6(@string);
	}

	public void x804b2039ae4e9b33(xc67adcdbca121a26 xbbe2f7d7c86e0379)
	{
		x6b42455c528c54af = xbbe2f7d7c86e0379.x437e3b626c0fdd43;
		if (base.x28fcdc775a1d069c.x73979cef1002ed01.xc2e1b0b1bf7219c5)
		{
			xc4cc21b78abf1fcf.x2307058321cdb62f("rect");
			xc4cc21b78abf1fcf.xff520a0047c27122("x", "0");
			xc4cc21b78abf1fcf.xff520a0047c27122("y", "0");
			xc4cc21b78abf1fcf.xff520a0047c27122("width", xca004f56614e2431.x37804260a70f74eb(xbbe2f7d7c86e0379.xdc1bf80853046136));
			xc4cc21b78abf1fcf.xff520a0047c27122("height", xca004f56614e2431.x37804260a70f74eb(xbbe2f7d7c86e0379.xb0f146032f47c24e));
			xc4cc21b78abf1fcf.xff520a0047c27122("style", "fill: #ffffff; stroke: #000000; stroke-width: 1");
			xc4cc21b78abf1fcf.x2dfde153f4ef96d0();
		}
	}

	public void xa0cf4a18229be519()
	{
		xc4cc21b78abf1fcf.x5222f4285e37d66b.Flush();
	}

	public void xfb4a02d17cf55f9b(xb8e7e788f6d59708 x08ce8f4769eb3234)
	{
		xb67b015f1a2f38a7(x08ce8f4769eb3234.xc9bcfb2d9630b0c7, x08ce8f4769eb3234);
		string text = x73c9eed6a5cacaa4(x08ce8f4769eb3234.x0e1bf8242ad10272);
		xc4cc21b78abf1fcf.x2307058321cdb62f("g");
		if (x08ce8f4769eb3234.x52dde376accdec7d != null)
		{
			xc4cc21b78abf1fcf.xff520a0047c27122("transform", x3ee81b8db87b7dc2.x8ba7763bb24dc716(x08ce8f4769eb3234.x52dde376accdec7d));
		}
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			xc4cc21b78abf1fcf.xff520a0047c27122("clip-path", $"url(#{text})");
		}
	}

	public void xd23c6c9fd3a6fa74(xb8e7e788f6d59708 x08ce8f4769eb3234)
	{
		xc4cc21b78abf1fcf.x2dfde153f4ef96d0();
		xbfa3ad37f5032b4f(x08ce8f4769eb3234);
	}

	public void x9e85ecf25cca82ee(xab391c46ff9a0a38 xe125219852864557)
	{
		string text = x73c9eed6a5cacaa4(xe125219852864557.x0e1bf8242ad10272);
		string xbcea506a33cf = x24cf489dc5492c87.x3a53bab86bc1dfad(xe125219852864557.x60465f602599d327);
		string xbcea506a33cf2 = ((xe125219852864557.x9e5d5f9128c69a8f != null) ? x24cf489dc5492c87.x3a53bab86bc1dfad(xe125219852864557.x9e5d5f9128c69a8f.x60465f602599d327) : "none");
		xc4cc21b78abf1fcf.x2307058321cdb62f("path");
		xc4cc21b78abf1fcf.xff520a0047c27122("d", x623c83a0867aace8.x38b39e52c8321dc8(xe125219852864557));
		if (xe125219852864557.x52dde376accdec7d != null)
		{
			xc4cc21b78abf1fcf.xff520a0047c27122("transform", x3ee81b8db87b7dc2.x8ba7763bb24dc716(xe125219852864557.x52dde376accdec7d));
		}
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			xc4cc21b78abf1fcf.xff520a0047c27122("clip-path", $"url(#{text})");
		}
		if (xe125219852864557.x9e5d5f9128c69a8f != null)
		{
			xc4cc21b78abf1fcf.xff520a0047c27122("stroke-width", xca004f56614e2431.x37804260a70f74eb(xe125219852864557.x9e5d5f9128c69a8f.xdc1bf80853046136));
			xc4cc21b78abf1fcf.x487ee90e3fcccc21("stroke-linecap", x3ee81b8db87b7dc2.x0f5673aedffb2dd7(xe125219852864557.x9e5d5f9128c69a8f.xec7c14446b693774), "butt");
			xc4cc21b78abf1fcf.x487ee90e3fcccc21("stroke-linejoin", x3ee81b8db87b7dc2.x9e3d00bac32f57a2(xe125219852864557.x9e5d5f9128c69a8f.x03a8df074279275f), "miter");
			xc4cc21b78abf1fcf.x487ee90e3fcccc21("stroke-miterlimit", xca004f56614e2431.x37804260a70f74eb(xe125219852864557.x9e5d5f9128c69a8f.x3372c2e5fab45e9a), "4");
			if (xe125219852864557.x9e5d5f9128c69a8f.x60465f602599d327 != null)
			{
				xc4cc21b78abf1fcf.xff520a0047c27122("stroke", xbcea506a33cf2);
				float x37cf7043760b312e = xed9035f57046e423.x27312094a1062219(xe125219852864557.x9e5d5f9128c69a8f.x60465f602599d327);
				xc4cc21b78abf1fcf.x487ee90e3fcccc21("stroke-opacity", xca004f56614e2431.x37804260a70f74eb(x37cf7043760b312e), "1");
			}
			if (xe125219852864557.x9e5d5f9128c69a8f.xca08e8eb525b8a1a != 0)
			{
				xc4cc21b78abf1fcf.xff520a0047c27122("stroke-dashoffset", xca004f56614e2431.x37804260a70f74eb(xe125219852864557.x9e5d5f9128c69a8f.xc19b368b60309472));
				xc4cc21b78abf1fcf.xff520a0047c27122("stroke-dasharray", x3ee81b8db87b7dc2.x8f172b45504f0a43(xe125219852864557.x9e5d5f9128c69a8f.x358988d12e56bf69, xe125219852864557.x9e5d5f9128c69a8f.xdc1bf80853046136));
			}
		}
		xc4cc21b78abf1fcf.xff520a0047c27122("fill", xbcea506a33cf);
		float x37cf7043760b312e2 = xed9035f57046e423.x27312094a1062219(xe125219852864557.x60465f602599d327);
		xc4cc21b78abf1fcf.x487ee90e3fcccc21("fill-opacity", xca004f56614e2431.x37804260a70f74eb(x37cf7043760b312e2), "1");
		xc4cc21b78abf1fcf.xff520a0047c27122("fill-rule", "evenodd");
	}

	public void x8e20e5f3afd31049()
	{
		xc4cc21b78abf1fcf.x2dfde153f4ef96d0();
	}

	internal void xb0eb947f93ab7675(x72c34b8dbaec3734 xe058541ca798c059)
	{
		xb67b015f1a2f38a7(xe058541ca798c059.xc9bcfb2d9630b0c7, xe058541ca798c059);
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		xa2745adfabe0c674 xa2745adfabe0c = xdd1b8f14cc8ba86d.x16a7fb03c627ebfb(xe058541ca798c059.xcc18177a965e0313);
		x54366fa5f75a02f.x5152a5707921c783(xe058541ca798c059.x437e3b626c0fdd43.Width / (float)xa2745adfabe0c.xdc1bf80853046136, xe058541ca798c059.x437e3b626c0fdd43.Height / (float)xa2745adfabe0c.xb0f146032f47c24e, MatrixOrder.Append);
		x54366fa5f75a02f.xce92de628aa023cf(xe058541ca798c059.xc22eade24b085d91.X, xe058541ca798c059.xc22eade24b085d91.Y, MatrixOrder.Append);
		xc4cc21b78abf1fcf.x2307058321cdb62f("use");
		xc4cc21b78abf1fcf.xff520a0047c27122("xlink:href", $"#{base.x28fcdc775a1d069c.x9728de41bb77ce76(xe058541ca798c059.xcc18177a965e0313, xe058541ca798c059.x4d7261a5f7f6e09c)}");
		xc4cc21b78abf1fcf.xff520a0047c27122("width", xca004f56614e2431.x37804260a70f74eb(xe058541ca798c059.x437e3b626c0fdd43.Width));
		xc4cc21b78abf1fcf.xff520a0047c27122("height", xca004f56614e2431.x37804260a70f74eb(xe058541ca798c059.x437e3b626c0fdd43.Height));
		xc4cc21b78abf1fcf.xff520a0047c27122("transform", x3ee81b8db87b7dc2.x8ba7763bb24dc716(x54366fa5f75a02f));
		xc4cc21b78abf1fcf.x2dfde153f4ef96d0();
		xbfa3ad37f5032b4f(xe058541ca798c059);
	}

	public void xd6b2549ca8b77560(xcc8c7739d82c63ba x199c511544621683)
	{
		xb67b015f1a2f38a7(x199c511544621683.xc9bcfb2d9630b0c7, x199c511544621683);
		string x9235160b4390be = x73c9eed6a5cacaa4(x199c511544621683.x0e1bf8242ad10272);
		switch (base.x28fcdc775a1d069c.x73979cef1002ed01.xd6830e3399cd5355)
		{
		case xa1f9fc75a377297a.x40590fcd18085b57:
			x636457dda93ec7a1(x199c511544621683, x80d9b32250b76064: false, x9235160b4390be);
			break;
		case xa1f9fc75a377297a.xdbd20e87a6636992:
			x636457dda93ec7a1(x199c511544621683, x80d9b32250b76064: true, x9235160b4390be);
			break;
		case xa1f9fc75a377297a.x516adb49f27e286e:
			x1710164f61c6905c(x199c511544621683, x9235160b4390be);
			break;
		default:
			x636457dda93ec7a1(x199c511544621683, x80d9b32250b76064: false, x9235160b4390be);
			break;
		}
		xbfa3ad37f5032b4f(x199c511544621683);
	}

	private void x636457dda93ec7a1(xcc8c7739d82c63ba x199c511544621683, bool x80d9b32250b76064, string x9235160b4390be48)
	{
		if (x80d9b32250b76064)
		{
			x312d56bccab33f07(x199c511544621683);
		}
		xc4cc21b78abf1fcf.x2307058321cdb62f("text");
		xc4cc21b78abf1fcf.xff520a0047c27122("x", xca004f56614e2431.x37804260a70f74eb(x199c511544621683.xc22eade24b085d91.X));
		xc4cc21b78abf1fcf.xff520a0047c27122("y", xca004f56614e2431.x37804260a70f74eb(x199c511544621683.xc22eade24b085d91.Y));
		xc4cc21b78abf1fcf.xff520a0047c27122("font-family", x199c511544621683.xc2d4efc42998d87b.x6054c4379c01a50d);
		xc4cc21b78abf1fcf.xff520a0047c27122("font-weight", x3ee81b8db87b7dc2.x917c5a6cdc05561e(x199c511544621683.xc2d4efc42998d87b.xfe2178c1f916f36c));
		xc4cc21b78abf1fcf.xff520a0047c27122("font-style", x3ee81b8db87b7dc2.x32b37ded42f44b0e(x199c511544621683.xc2d4efc42998d87b.xfe2178c1f916f36c));
		xc4cc21b78abf1fcf.xff520a0047c27122("font-size", xca004f56614e2431.x37804260a70f74eb(x199c511544621683.xc2d4efc42998d87b.x53531537bb3331e6));
		xc4cc21b78abf1fcf.xff520a0047c27122("fill", x3ee81b8db87b7dc2.xfafbf12cd38285b5(x199c511544621683.x9b41425268471380));
		if (x199c511544621683.x52dde376accdec7d != null)
		{
			xc4cc21b78abf1fcf.xff520a0047c27122("transform", x3ee81b8db87b7dc2.x8ba7763bb24dc716(x199c511544621683.x52dde376accdec7d));
		}
		if (x0d299f323d241756.x5959bccb67bbf051(x9235160b4390be48))
		{
			xc4cc21b78abf1fcf.xff520a0047c27122("clip-path", $"url(#{x9235160b4390be48})");
		}
		xc4cc21b78abf1fcf.x3d1be38abe5723e3(x199c511544621683.Text);
		xc4cc21b78abf1fcf.x2dfde153f4ef96d0();
	}

	private void x1710164f61c6905c(xcc8c7739d82c63ba x199c511544621683, string x9235160b4390be48)
	{
		float num = x199c511544621683.xc2d4efc42998d87b.x53531537bb3331e6 / 20480f;
		x312d56bccab33f07(x199c511544621683);
		xc4cc21b78abf1fcf.x2307058321cdb62f("g");
		xc4cc21b78abf1fcf.xff520a0047c27122("fill", x3ee81b8db87b7dc2.xfafbf12cd38285b5(x199c511544621683.x9b41425268471380));
		if (x0d299f323d241756.x5959bccb67bbf051(x9235160b4390be48))
		{
			xc4cc21b78abf1fcf.xff520a0047c27122("clip-path", $"url(#{x9235160b4390be48})");
		}
		x54366fa5f75a02f7 x54366fa5f75a02f = ((x199c511544621683.x52dde376accdec7d != null) ? x199c511544621683.x52dde376accdec7d : new x54366fa5f75a02f7());
		x54366fa5f75a02f.x5152a5707921c783(num, num, MatrixOrder.Append);
		x54366fa5f75a02f.xce92de628aa023cf(x199c511544621683.xc22eade24b085d91.X, x199c511544621683.xc22eade24b085d91.Y, MatrixOrder.Append);
		if (x199c511544621683.xc2d4efc42998d87b.xda4c813a32b9109b)
		{
			x54366fa5f75a02f.x490e30087768649f(x199c511544621683.xa9563a23c5ad1dd4());
		}
		xc4cc21b78abf1fcf.xff520a0047c27122("transform", x3ee81b8db87b7dc2.x8ba7763bb24dc716(x54366fa5f75a02f));
		if (x199c511544621683.xc2d4efc42998d87b.x30c7b3201d032345)
		{
			xc4cc21b78abf1fcf.xff520a0047c27122("stroke", x3ee81b8db87b7dc2.xfafbf12cd38285b5(x199c511544621683.x9b41425268471380));
			xc4cc21b78abf1fcf.xff520a0047c27122("stroke-width", xca004f56614e2431.x37804260a70f74eb(819.19995f));
		}
		string arg = base.x28fcdc775a1d069c.x4a59854a1bae262a(x199c511544621683.xc2d4efc42998d87b.x29f65b3e7616f6b3);
		float num2 = 0f;
		foreach (int item in new x115139807e6482f7(x199c511544621683.Text))
		{
			xc4cc21b78abf1fcf.x2307058321cdb62f("use");
			xc4cc21b78abf1fcf.xff520a0047c27122("x", xca004f56614e2431.x37804260a70f74eb(num2));
			xc4cc21b78abf1fcf.xff520a0047c27122("xlink:href", $"#{arg}c{item}");
			xc4cc21b78abf1fcf.x2dfde153f4ef96d0();
			num2 += (float)x3363b5fd92e52a33.x29e43e97a14c50f5(x199c511544621683.xc2d4efc42998d87b.x29f65b3e7616f6b3.x1e6da4134d115607.x12f49b36ab885c48(item).xf58adb71a3d2dade, x199c511544621683.xc2d4efc42998d87b.x29f65b3e7616f6b3);
		}
		xc4cc21b78abf1fcf.x2dfde153f4ef96d0();
	}

	private void x312d56bccab33f07(xcc8c7739d82c63ba x199c511544621683)
	{
		xcd986872cf3bcf68 xcd986872cf3bcf = base.x28fcdc775a1d069c.x5fa376febd884803(x199c511544621683.xc2d4efc42998d87b.x29f65b3e7616f6b3);
		foreach (int item in new x115139807e6482f7(x199c511544621683.Text))
		{
			xcd986872cf3bcf.x3452aa488cc9006d(item);
		}
	}

	private void xb67b015f1a2f38a7(xa702b771604efc86 xe0abc8f59346647b, x4fdf549af9de6b97 x83f48c42d3ca03a8)
	{
		if (xe0abc8f59346647b != null)
		{
			xc4cc21b78abf1fcf.x2307058321cdb62f("a");
			xc4cc21b78abf1fcf.xff520a0047c27122("href", xe0abc8f59346647b.x42f4c234c9358072);
			x100c1e4bd6e3d9e2.Push(x83f48c42d3ca03a8);
		}
	}

	private void xbfa3ad37f5032b4f(x4fdf549af9de6b97 x83f48c42d3ca03a8)
	{
		if (x100c1e4bd6e3d9e2.Count > 0 && x100c1e4bd6e3d9e2.Peek() == x83f48c42d3ca03a8)
		{
			xc4cc21b78abf1fcf.x2dfde153f4ef96d0();
			x100c1e4bd6e3d9e2.Pop();
		}
	}

	private string x73c9eed6a5cacaa4(xab391c46ff9a0a38 xd1cff1e8f8666dbe)
	{
		if (xd1cff1e8f8666dbe == null)
		{
			return null;
		}
		string text = $"clip{base.x28fcdc775a1d069c.x8e81c5a80377d905()}";
		xc4cc21b78abf1fcf.x2307058321cdb62f("clipPath");
		xc4cc21b78abf1fcf.xff520a0047c27122("id", text);
		x9e85ecf25cca82ee(xd1cff1e8f8666dbe);
		x8e20e5f3afd31049();
		xc4cc21b78abf1fcf.x2dfde153f4ef96d0();
		return text;
	}
}
