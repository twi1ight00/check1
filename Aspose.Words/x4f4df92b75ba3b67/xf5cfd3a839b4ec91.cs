using System.Drawing;
using Aspose;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;

namespace x4f4df92b75ba3b67;

internal abstract class xf5cfd3a839b4ec91 : x264ba3b7aca691be
{
	private const bool xfcdeaeef848326c6 = true;

	private readonly string xc61ff88f1f98652d;

	private readonly PointF xe9df964a546f7680 = PointF.Empty;

	private readonly bool x92229b967f4da3b9 = true;

	private RectangleF x18847e4f94b14ff7 = RectangleF.Empty;

	protected readonly xd6b2a42851fedfba x0a1aee6bd4aee6ae;

	private int x37a205e842241db9;

	protected static readonly string x4d7648648a11f443 = "/DV";

	protected static readonly string x2f83359518b6600c = "/AP";

	protected static readonly string x4b6072d29bc4fcc0 = "/AS";

	protected static readonly string x22c40f2843e791e9 = "/N";

	protected static readonly string x3b6357dc4bfa7820 = "/DA";

	protected static readonly string xae6334bc0e6275cb = "1 g ";

	protected static readonly string x43426c25e17f1fcc = "0 g ";

	protected static readonly string x927626bbc41899d0 = " re f ";

	protected static readonly string x49a3b5016b66cfd5 = " m ";

	protected static readonly string x931898f64633e130 = " l s ";

	internal PointF xc22eade24b085d91 => xe9df964a546f7680;

	internal string x759aa16c2016a289 => xc61ff88f1f98652d;

	internal RectangleF x2727839aafc09868
	{
		get
		{
			return x18847e4f94b14ff7;
		}
		set
		{
			x18847e4f94b14ff7 = value;
		}
	}

	internal xd6b2a42851fedfba x839aef5610889ada => x0a1aee6bd4aee6ae;

	protected xf5cfd3a839b4ec91(xd6b2a42851fedfba hostPage, xfa6279ffd07aa4c9 source)
		: base(hostPage.x28fcdc775a1d069c)
	{
		xc61ff88f1f98652d = hostPage.x28fcdc775a1d069c.x5b7a4ff36ab1fa9d(source.x759aa16c2016a289, base.xea1e81378298fa81);
		xe9df964a546f7680 = source.xc22eade24b085d91;
		x92229b967f4da3b9 = source.xca1781db5d80e987;
		x18847e4f94b14ff7 = source.BoundingBox;
		x0a1aee6bd4aee6ae = hostPage;
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		writer.x1c638d277561c422(xbfbb1719d4106af2());
		writer.x7a67b9beb30292d6(this);
		writer.xafb7e6f79ed43681();
		writer.xa4dc0ad8886e23a2("/Type", "/Annot");
		writer.xa4dc0ad8886e23a2("/Subtype", "/Widget");
		writer.xa4dc0ad8886e23a2("/P", x0a1aee6bd4aee6ae.x899a2110a8a35fda);
		writer.xa4dc0ad8886e23a2("/FT", xb4f4824af7c55e3a.x80a6a30ceb87fc8d(GetFieldType()));
		writer.xa4dc0ad8886e23a2("/F", 4);
		RectangleF xbcea506a33cf = new RectangleF(x18847e4f94b14ff7.X, x0a1aee6bd4aee6ae.xb0f146032f47c24e - x18847e4f94b14ff7.Y, x18847e4f94b14ff7.Width, x18847e4f94b14ff7.Height);
		writer.xa4dc0ad8886e23a2("/Rect", xbcea506a33cf);
		x37a205e842241db9 |= GetFieldSpecificBitFlag();
		if (xdc6101eb92c2906b())
		{
			writer.xa4dc0ad8886e23a2("/Ff", x37a205e842241db9);
		}
		writer.x94aba205302527e1("/T", xc61ff88f1f98652d);
		WriteFieldSpecificDictionaryEntries(writer);
		writer.x693a8d6d020474f2();
		writer.x5155d7b9dab28280();
		WriteFieldSpecificObjects(writer);
	}

	protected abstract x4f47636462fbf23a GetFieldType();

	protected virtual int GetFieldSpecificBitFlag()
	{
		if (!x92229b967f4da3b9)
		{
			return 1;
		}
		return 0;
	}

	[JavaThrows(true)]
	protected abstract void WriteFieldSpecificDictionaryEntries(x4f40d990d5bf81a6 writer);

	[JavaThrows(true)]
	protected abstract void WriteFieldSpecificObjects(x4f40d990d5bf81a6 writer);

	protected string x1183e679f352c392(xe39d06eee35dd23d x26094932cf7a9139, x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		xba2f911354958a68 xba2f911354958a69 = x8cedcaa9a62c6e39.x3a60bb04bce53320.x9059a3203c8fc855(x26094932cf7a9139);
		return $"{x002f85d924697e32(x6c50a99faab7d741)} /{xba2f911354958a69.xd160355ae2167ae9} {xcd769e39c0788209.x355581fe14891d82(x26094932cf7a9139.x53531537bb3331e6)} Tf ";
	}

	private static string x002f85d924697e32(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		x28d5285d743f03f5 x28d5285d743f03f6 = x28d5285d743f03f5.x17b1961e76a1bb2b(x6c50a99faab7d741);
		if (x28d5285d743f03f6 != x28d5285d743f03f5.x529d0bc70de5de1f)
		{
			return $"{xcd769e39c0788209.x33f484a2a7742f9e(x6c50a99faab7d741)} g";
		}
		return $"{xcd769e39c0788209.x9aa2167736c37c5a(x6c50a99faab7d741)} rg";
	}

	protected static void x47cfb90fdeb56514(xcd769e39c0788209 xbdfb620b7167944b, RectangleF xda73fcb97c77d998)
	{
		xbdfb620b7167944b.x6210059f049f0d48(x43426c25e17f1fcc);
		xbdfb620b7167944b.x6210059f049f0d48(xda73fcb97c77d998.Left);
		xbdfb620b7167944b.xe7b920de107da0c7();
		xbdfb620b7167944b.x6210059f049f0d48(xda73fcb97c77d998.Top);
		xbdfb620b7167944b.xe7b920de107da0c7();
		xbdfb620b7167944b.x6210059f049f0d48(xda73fcb97c77d998.Right);
		xbdfb620b7167944b.xe7b920de107da0c7();
		xbdfb620b7167944b.x6210059f049f0d48(xda73fcb97c77d998.Bottom);
		xbdfb620b7167944b.x6210059f049f0d48(x927626bbc41899d0);
		xbdfb620b7167944b.x6210059f049f0d48(xae6334bc0e6275cb);
		xbdfb620b7167944b.x6210059f049f0d48(xda73fcb97c77d998.Left + 1f);
		xbdfb620b7167944b.xe7b920de107da0c7();
		xbdfb620b7167944b.x6210059f049f0d48(xda73fcb97c77d998.Top + 1f);
		xbdfb620b7167944b.xe7b920de107da0c7();
		xbdfb620b7167944b.x6210059f049f0d48(xda73fcb97c77d998.Right - 2f);
		xbdfb620b7167944b.xe7b920de107da0c7();
		xbdfb620b7167944b.x6210059f049f0d48(xda73fcb97c77d998.Bottom - 2f);
		xbdfb620b7167944b.x6210059f049f0d48(x927626bbc41899d0);
	}

	protected static void xc135895eb632d865(xcd769e39c0788209 xbdfb620b7167944b)
	{
		xbdfb620b7167944b.x6210059f049f0d48(" /Tx BMC\r\n  q\r\n   BT\r\n    ");
	}

	protected static void x972b7e15e64526e4(xcd769e39c0788209 xbdfb620b7167944b)
	{
		xbdfb620b7167944b.x6210059f049f0d48("\r\n   ET\r\n  Q\r\n EMC");
	}

	protected static void xab68d26edfba16ac(xcd769e39c0788209 xbdfb620b7167944b, x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		xbdfb620b7167944b.x241b3c2e8c3aaa86(x002f85d924697e32(x6c50a99faab7d741));
	}

	protected xba2f911354958a68 xa36a62f286dd4144(xcd769e39c0788209 xbdfb620b7167944b, xe39d06eee35dd23d xdb7ac4b077f80c83)
	{
		xbdfb620b7167944b.x6210059f049f0d48("/");
		xba2f911354958a68 xba2f911354958a69 = x8cedcaa9a62c6e39.x3a60bb04bce53320.x9059a3203c8fc855(xdb7ac4b077f80c83);
		xbdfb620b7167944b.x6210059f049f0d48(xba2f911354958a69.xd160355ae2167ae9);
		xbdfb620b7167944b.xe7b920de107da0c7();
		xbdfb620b7167944b.x6210059f049f0d48(xdb7ac4b077f80c83.x53531537bb3331e6);
		xbdfb620b7167944b.x6210059f049f0d48(" Tf ");
		return xba2f911354958a69;
	}

	protected static void x39605bb716707926(xcd769e39c0788209 xbdfb620b7167944b, float x4df6b231609e712f)
	{
		xbdfb620b7167944b.x6210059f049f0d48("1 0 0 1 2 ");
		xbdfb620b7167944b.x6210059f049f0d48(x4df6b231609e712f);
		xbdfb620b7167944b.x6210059f049f0d48(" Tm ");
	}

	protected static void x6bf9042ca9bedd31(xcd769e39c0788209 xbdfb620b7167944b, float x08db3aeabb253cb1, float x1e218ceaee1bb583)
	{
		xbdfb620b7167944b.xe7b920de107da0c7();
		xbdfb620b7167944b.x6210059f049f0d48(x08db3aeabb253cb1);
		xbdfb620b7167944b.xe7b920de107da0c7();
		xbdfb620b7167944b.x6210059f049f0d48(x1e218ceaee1bb583);
		xbdfb620b7167944b.x6210059f049f0d48(" Td ");
	}

	protected static void xd0e5bb3ded9994f0(xcd769e39c0788209 xbdfb620b7167944b, string xb41faee6912a2313, xba2f911354958a68 x26094932cf7a9139)
	{
		x26094932cf7a9139.WriteText(xb41faee6912a2313, xbdfb620b7167944b);
		xbdfb620b7167944b.x6210059f049f0d48(" Tj ");
	}

	private bool xdc6101eb92c2906b()
	{
		return x37a205e842241db9 != 0;
	}
}
