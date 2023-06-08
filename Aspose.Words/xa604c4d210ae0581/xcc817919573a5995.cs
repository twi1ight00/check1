using System.IO;
using Aspose.Words;
using Aspose.Words.Tables;
using x6f978ba1e7522832;
using x9db5f2e5af3d596e;

namespace xa604c4d210ae0581;

internal class xcc817919573a5995
{
	internal const int xa230444f4711f2cc = 20;

	internal static void x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75, xf8cef531dae89ea3 x51dd02ffcbaa972d)
	{
		int num = xe134235b3526fa75.ReadInt16();
		bool flag = (num & 1) != 0;
		bool flag2 = (num & 2) != 0;
		CellMerge cellMerge = (flag ? CellMerge.First : (flag2 ? CellMerge.Previous : CellMerge.None));
		x51dd02ffcbaa972d.xae20093bed1e48a8(3040, cellMerge);
		x51dd02ffcbaa972d.xae20093bed1e48a8(3050, (TextOrientation)((num & 0x1C) >> 2));
		bool flag3 = (num & 0x20) != 0;
		CellMerge cellMerge2 = ((((uint)num & 0x40u) != 0) ? CellMerge.First : (flag3 ? CellMerge.Previous : CellMerge.None));
		x51dd02ffcbaa972d.xae20093bed1e48a8(3030, cellMerge2);
		x51dd02ffcbaa972d.xae20093bed1e48a8(3060, (CellVerticalAlignment)((num & 0x180) >> 7));
		PreferredWidthType preferredWidthType = (PreferredWidthType)((num & 0xE00) >> 9);
		int x5b1c8ddab0846b = xe134235b3526fa75.ReadInt16();
		if (preferredWidthType != 0)
		{
			x51dd02ffcbaa972d.xae20093bed1e48a8(3020, PreferredWidth.x6b44e3efc21fd5b4(preferredWidthType, x5b1c8ddab0846b));
		}
		x51dd02ffcbaa972d.xae20093bed1e48a8(3190, (num & 0x1000) != 0);
		x51dd02ffcbaa972d.xae20093bed1e48a8(3180, (num & 0x2000) == 0);
		x204e881194ee5797(xe134235b3526fa75, x51dd02ffcbaa972d, 3110);
		x204e881194ee5797(xe134235b3526fa75, x51dd02ffcbaa972d, 3120);
		x204e881194ee5797(xe134235b3526fa75, x51dd02ffcbaa972d, 3130);
		x204e881194ee5797(xe134235b3526fa75, x51dd02ffcbaa972d, 3140);
	}

	internal static void x6210059f049f0d48(xf8cef531dae89ea3 x51dd02ffcbaa972d, BinaryWriter xbdfb620b7167944b)
	{
		int num = 0;
		num |= ((x51dd02ffcbaa972d.x338a5e6ab7c5595e == CellMerge.First) ? 1 : 0);
		num |= ((x51dd02ffcbaa972d.x338a5e6ab7c5595e == CellMerge.Previous) ? 2 : 0);
		num |= (int)x51dd02ffcbaa972d.x2c5926113e101674 << 2;
		num |= ((x51dd02ffcbaa972d.x1a1dda35b3ae703d != 0) ? 32 : 0);
		num |= ((x51dd02ffcbaa972d.x1a1dda35b3ae703d == CellMerge.First) ? 64 : 0);
		num |= (int)x51dd02ffcbaa972d.xf6ce0e8106e6a1d8 << 7;
		num |= (int)x51dd02ffcbaa972d.xce5b83b714f11fba.Type << 9;
		num |= (x51dd02ffcbaa972d.xfeaa4e4323026cd8 ? 4096 : 0);
		num |= ((!x51dd02ffcbaa972d.x4aed3ad39c0fe5b4) ? 8192 : 0);
		xbdfb620b7167944b.Write((short)num);
		xbdfb620b7167944b.Write((short)x51dd02ffcbaa972d.xce5b83b714f11fba.x7680505e84ce0354);
		x4d2a08efa110f18f(x51dd02ffcbaa972d, 3110, xbdfb620b7167944b);
		x4d2a08efa110f18f(x51dd02ffcbaa972d, 3120, xbdfb620b7167944b);
		x4d2a08efa110f18f(x51dd02ffcbaa972d, 3130, xbdfb620b7167944b);
		x4d2a08efa110f18f(x51dd02ffcbaa972d, 3140, xbdfb620b7167944b);
	}

	private static void x204e881194ee5797(BinaryReader xe134235b3526fa75, xf8cef531dae89ea3 x51dd02ffcbaa972d, int xba08ce632055a1d9)
	{
		Border border = x1df55585ec1be056.x002fafae3e338912(xe134235b3526fa75, null);
		if (border == null)
		{
			x51dd02ffcbaa972d.xae20093bed1e48a8(xba08ce632055a1d9, new Border());
		}
		else if (border.LineStyle != 0)
		{
			x51dd02ffcbaa972d.xae20093bed1e48a8(xba08ce632055a1d9, border);
		}
	}

	private static void x4d2a08efa110f18f(xf8cef531dae89ea3 x51dd02ffcbaa972d, int xba08ce632055a1d9, BinaryWriter xbdfb620b7167944b)
	{
		Border border = (Border)x51dd02ffcbaa972d.xf7866f89640a29a3(xba08ce632055a1d9);
		if (border == null || border.xa157de8185757b11)
		{
			xbdfb620b7167944b.Write(0u);
		}
		else if (border.LineStyle == LineStyle.None)
		{
			xbdfb620b7167944b.Write(uint.MaxValue);
		}
		else
		{
			x1df55585ec1be056.x2beefb7099c2c239(border, xbdfb620b7167944b, x10e248b4013349b1: false);
		}
	}

	internal static void x76f56033ed683860(x354e9ebad65eecc8 xbdfb620b7167944b, x875aca5784596b73 x28180b3c3774af93, x8f1cf61f24a43e61 x2356aaca890347a5, object x13ebc58426767551)
	{
		x76f56033ed683860(xbdfb620b7167944b, x28180b3c3774af93, 0, 1, x2356aaca890347a5, x13ebc58426767551);
	}

	internal static void x76f56033ed683860(x354e9ebad65eecc8 xbdfb620b7167944b, x875aca5784596b73 x28180b3c3774af93, int x62584df2cb5d40dd, int xd0af4642d624ddbd, x8f1cf61f24a43e61 x2356aaca890347a5, object x13ebc58426767551)
	{
		if (x13ebc58426767551 != null)
		{
			xbdfb620b7167944b.x3a52c4e37999b16e(x28180b3c3774af93);
			xbdfb620b7167944b.Write((byte)6);
			xbdfb620b7167944b.Write((byte)x62584df2cb5d40dd);
			xbdfb620b7167944b.Write((byte)xd0af4642d624ddbd);
			xbdfb620b7167944b.Write((byte)x2356aaca890347a5);
			xbdfb620b7167944b.Write((byte)3);
			int num = (int)x13ebc58426767551;
			xbdfb620b7167944b.Write((short)num);
		}
	}
}
