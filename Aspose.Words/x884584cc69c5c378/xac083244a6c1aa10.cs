using System.IO;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x1a62aaf14e3c5909;
using x6c95d9cf46ff5f25;
using xa604c4d210ae0581;

namespace x884584cc69c5c378;

internal class xac083244a6c1aa10 : xf67718a36ff889c3
{
	internal const int xa230444f4711f2cc = 26;

	internal int x1f6ee650d037e627;

	internal int xcd87185ed7051274;

	internal int x876e863ea564ec39;

	internal int x2ca5ed0dff31679b;

	internal int xe7b5a65034b65c45;

	internal bool x459220daf9bf6487;

	internal RelativeHorizontalPosition x823e25358d6b230a;

	internal RelativeVerticalPosition x1c9f5e684be25395;

	internal WrapType xd7593ea4dbfcfad6;

	internal WrapSide x91e425b5781b0267;

	internal bool x0e8065866600566f;

	internal bool x3dbea441ce4f2582;

	internal bool x33fd5625aa1786b7;

	internal int x5db45988d4e40802;

	internal static bool x492f529cee830a40;

	internal xac083244a6c1aa10(BinaryReader reader)
	{
		x1f6ee650d037e627 = reader.ReadInt32();
		xcd87185ed7051274 = reader.ReadInt32();
		x876e863ea564ec39 = reader.ReadInt32();
		x2ca5ed0dff31679b = reader.ReadInt32();
		xe7b5a65034b65c45 = reader.ReadInt32();
		int num = reader.ReadUInt16();
		x459220daf9bf6487 = (num & 1) != 0;
		x823e25358d6b230a = (RelativeHorizontalPosition)((num & 6) >> 1);
		x1c9f5e684be25395 = (RelativeVerticalPosition)((num & 0x18) >> 3);
		xd7593ea4dbfcfad6 = (WrapType)((num & 0x1E0) >> 5);
		x91e425b5781b0267 = (WrapSide)((num & 0x1E00) >> 9);
		x0e8065866600566f = (num & 0x2000) != 0;
		x3dbea441ce4f2582 = (num & 0x4000) != 0;
		x33fd5625aa1786b7 = (num & 0x8000) != 0;
		x5db45988d4e40802 = reader.ReadInt32();
		_ = x492f529cee830a40;
	}

	internal xac083244a6c1aa10(ShapeBase shape)
	{
		x1f6ee650d037e627 = shape.xea1e81378298fa81;
		x459220daf9bf6487 = false;
		x0e8065866600566f = false;
		x5a479118db43fa5e x5a479118db43fa5e = x5a479118db43fa5e.xf648b77e8172fa16(shape);
		if (shape.WrapType != 0)
		{
			x823e25358d6b230a = shape.RelativeHorizontalPosition;
			if (x823e25358d6b230a > RelativeHorizontalPosition.Column)
			{
				x823e25358d6b230a = RelativeHorizontalPosition.Column;
			}
			x1c9f5e684be25395 = shape.RelativeVerticalPosition;
			if (x1c9f5e684be25395 > RelativeVerticalPosition.Paragraph)
			{
				x1c9f5e684be25395 = RelativeVerticalPosition.Paragraph;
			}
			xd7593ea4dbfcfad6 = shape.WrapType;
			x91e425b5781b0267 = shape.WrapSide;
			x3dbea441ce4f2582 = shape.BehindText;
			x33fd5625aa1786b7 = shape.AnchorLocked;
		}
		else
		{
			x5a479118db43fa5e.x72d92bd1aff02e37 = 0.0;
			x5a479118db43fa5e.xe360b1885d8d4a41 = 0.0;
			x823e25358d6b230a = RelativeHorizontalPosition.Column;
			x1c9f5e684be25395 = RelativeVerticalPosition.Paragraph;
			xd7593ea4dbfcfad6 = WrapType.None;
			x91e425b5781b0267 = WrapSide.Both;
			x3dbea441ce4f2582 = false;
			x33fd5625aa1786b7 = true;
		}
		xcd87185ed7051274 = x4574ea26106f0edb.x88bf16f2386d633e(x5a479118db43fa5e.x72d92bd1aff02e37);
		x876e863ea564ec39 = x4574ea26106f0edb.x88bf16f2386d633e(x5a479118db43fa5e.xe360b1885d8d4a41);
		x2ca5ed0dff31679b = x4574ea26106f0edb.x88bf16f2386d633e(x5a479118db43fa5e.x72d92bd1aff02e37 + x5a479118db43fa5e.xdc1bf80853046136);
		xe7b5a65034b65c45 = x4574ea26106f0edb.x88bf16f2386d633e(x5a479118db43fa5e.xe360b1885d8d4a41 + x5a479118db43fa5e.xb0f146032f47c24e);
		x5db45988d4e40802 = 0;
	}

	private void x85313d56ab6f266e(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write(x1f6ee650d037e627);
		xbdfb620b7167944b.Write(xcd87185ed7051274);
		xbdfb620b7167944b.Write(x876e863ea564ec39);
		xbdfb620b7167944b.Write(x2ca5ed0dff31679b);
		xbdfb620b7167944b.Write(xe7b5a65034b65c45);
		int num = 0;
		num |= (x459220daf9bf6487 ? 1 : 0);
		num |= (int)x823e25358d6b230a << 1;
		num |= (int)x1c9f5e684be25395 << 3;
		num |= (int)xd7593ea4dbfcfad6 << 5;
		num |= (int)x91e425b5781b0267 << 9;
		num |= (x0e8065866600566f ? 8192 : 0);
		num |= (x3dbea441ce4f2582 ? 16384 : 0);
		num |= (x33fd5625aa1786b7 ? 32768 : 0);
		xbdfb620b7167944b.Write((ushort)num);
		xbdfb620b7167944b.Write(x5db45988d4e40802);
	}

	void xf67718a36ff889c3.x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x85313d56ab6f266e
		this.x85313d56ab6f266e(xbdfb620b7167944b);
	}

	internal void x865b320f557323c1(ShapeBase x5770cdefd8931aa9, bool xc85a4e261cc10edf)
	{
		x5a479118db43fa5e.x45e7e197dcc9dd27(x5770cdefd8931aa9, xcd87185ed7051274, x2ca5ed0dff31679b, x876e863ea564ec39, xe7b5a65034b65c45);
		xf7125312c7ee115c xf7125312c7ee115c = x5770cdefd8931aa9.xf7125312c7ee115c;
		x81244a5ff6114047(xf7125312c7ee115c, 4097, xd7593ea4dbfcfad6);
		x81244a5ff6114047(xf7125312c7ee115c, 4098, x91e425b5781b0267);
		x81244a5ff6114047(xf7125312c7ee115c, 4099, x33fd5625aa1786b7);
		x81244a5ff6114047(xf7125312c7ee115c, 954, x3dbea441ce4f2582);
		if (!xc85a4e261cc10edf)
		{
			x81244a5ff6114047(xf7125312c7ee115c, 912, x823e25358d6b230a);
			x81244a5ff6114047(xf7125312c7ee115c, 914, x1c9f5e684be25395);
		}
	}

	private static void x81244a5ff6114047(xf7125312c7ee115c xe9707cb1ec88db49, int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		if (!xe9707cb1ec88db49.xbc5dc59d0d9b620d(xba08ce632055a1d9))
		{
			xe9707cb1ec88db49.xae20093bed1e48a8(xba08ce632055a1d9, xbcea506a33cf9111);
		}
	}
}
