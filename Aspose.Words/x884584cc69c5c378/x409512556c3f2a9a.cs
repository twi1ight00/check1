using System;
using System.Drawing;
using System.IO;
using System.Text;
using Aspose.Words;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xa604c4d210ae0581;

namespace x884584cc69c5c378;

internal class x409512556c3f2a9a
{
	internal const int xa230444f4711f2cc = 68;

	internal const int x659232b8b6a0c76b = 1000;

	internal int xf280755e03a40325;

	internal int xd6696a1209486da5;

	internal x37604adeead3e2b5 xd7349b4fe5e74804;

	private int xf5519517e7282b34;

	private int x76096e1f3bef3f76;

	private int x8b368e3901d7e60c;

	internal xd372c62feb02ff45 x11973ad34d8be202;

	private int xf3c006205b66ef7b;

	private int xfa6ea744155689ad;

	private int x77b193b0c5b926ef;

	private int xdf0cf91496cdbd62;

	private int x1c04732f63de1934;

	private int x71d244b6916f28a3;

	private int xca94f756b08d1cdc;

	private int x5bac491e3ece48e1;

	private int xd8267e571f6d1fc1;

	private int x0c6b05bf8cf85977;

	private int x676dfed17227e913;

	private int xb0e559b84dd894a4;

	private int x9d0c3ba83d6141b8;

	private bool x2b4315ee2d70cc84;

	private bool xbbea97dbf0fbd3ee;

	private bool x726f04901be5090c;

	private bool x8da079b2e47e094c;

	private int x5c1479d50c3706b8;

	private Border xd6620b0e1246ad2a = new Border();

	private Border xf73cc7f38537c2b7 = new Border();

	private Border x64750eb70ee7300d = new Border();

	private Border x9d89a3496dc35374 = new Border();

	private int xcf2c030d81af0438;

	private int x47c37ae99998c35d;

	private int xdba72a854689476e;

	private int x06857957e1e54e75;

	private int xe9d9b2de9b686edd;

	internal static bool x492f529cee830a40;

	internal bool x22ab5dfa6f12e902
	{
		get
		{
			if (xca94f756b08d1cdc == 0 && x5bac491e3ece48e1 == 0)
			{
				return false;
			}
			return true;
		}
	}

	internal x409512556c3f2a9a()
	{
		xd6696a1209486da5 = 68;
		x06857957e1e54e75 = 1000;
		xe9d9b2de9b686edd = 1000;
	}

	internal x409512556c3f2a9a(BinaryReader reader)
		: this()
	{
		_ = reader.BaseStream.Position;
		xf280755e03a40325 = reader.ReadInt32();
		xd6696a1209486da5 = reader.ReadUInt16();
		xd7349b4fe5e74804 = (x37604adeead3e2b5)reader.ReadUInt16();
		xf5519517e7282b34 = reader.ReadUInt16();
		x76096e1f3bef3f76 = reader.ReadUInt16();
		x8b368e3901d7e60c = reader.ReadUInt16();
		x11973ad34d8be202 = (xd372c62feb02ff45)reader.ReadUInt16();
		xf3c006205b66ef7b = reader.ReadUInt16();
		xfa6ea744155689ad = reader.ReadUInt16();
		x77b193b0c5b926ef = reader.ReadUInt16();
		xdf0cf91496cdbd62 = reader.ReadUInt16();
		x1c04732f63de1934 = reader.ReadUInt16();
		x71d244b6916f28a3 = reader.ReadUInt16();
		xca94f756b08d1cdc = reader.ReadUInt16();
		x5bac491e3ece48e1 = reader.ReadUInt16();
		x06857957e1e54e75 = reader.ReadUInt16();
		xe9d9b2de9b686edd = reader.ReadUInt16();
		xd8267e571f6d1fc1 = reader.ReadInt16();
		x0c6b05bf8cf85977 = reader.ReadInt16();
		x676dfed17227e913 = reader.ReadInt16();
		xb0e559b84dd894a4 = reader.ReadInt16();
		int num = reader.ReadUInt16();
		x9d0c3ba83d6141b8 = num & 0xF;
		x2b4315ee2d70cc84 = (num & 0x10) != 0;
		xbbea97dbf0fbd3ee = (num & 0x20) != 0;
		x726f04901be5090c = (num & 0x40) != 0;
		x8da079b2e47e094c = (num & 0x80) != 0;
		x5c1479d50c3706b8 = (num & 0xFF00) >> 8;
		x1df55585ec1be056.x002fafae3e338912(reader, xd6620b0e1246ad2a);
		x1df55585ec1be056.x002fafae3e338912(reader, xf73cc7f38537c2b7);
		x1df55585ec1be056.x002fafae3e338912(reader, x64750eb70ee7300d);
		x1df55585ec1be056.x002fafae3e338912(reader, x9d89a3496dc35374);
		xcf2c030d81af0438 = reader.ReadInt16();
		x47c37ae99998c35d = reader.ReadInt16();
		xdba72a854689476e = reader.ReadInt16();
		if (x492f529cee830a40)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("\nRead PICF:");
			stringBuilder.AppendFormat("\n mfpMm:{0}, mfpXExt:{1}, mfpYExt:{2}, mfpHMF:{3}", xd7349b4fe5e74804, xf5519517e7282b34, x76096e1f3bef3f76, x8b368e3901d7e60c);
			stringBuilder.AppendFormat("\n bmType:{0}, bmWidth:{1}, bmHeight:{2}, bmWidthBytes:{3}, bmPlanes:{4}, bmBitsPixel:{5}, bmBits:{6}", x11973ad34d8be202, xf3c006205b66ef7b, xfa6ea744155689ad, x77b193b0c5b926ef, xdf0cf91496cdbd62, x1c04732f63de1934, x71d244b6916f28a3);
			stringBuilder.AppendFormat("\n dxaGoal:{0}, dyaGoal:{1}, mx:{2}, my:{3}", xca94f756b08d1cdc, x5bac491e3ece48e1, x06857957e1e54e75, xe9d9b2de9b686edd);
			stringBuilder.AppendFormat("\n dxaCropLeft:{0}, dyaCropTop:{1}, dxaCropRight:{2}, dyaCropBottom:{3}", xca94f756b08d1cdc, x5bac491e3ece48e1, x676dfed17227e913, xb0e559b84dd894a4);
			stringBuilder.AppendFormat("\n dxaOrigin:{0}, dyaOrigin:{1}, cProps:{2}", xcf2c030d81af0438, x47c37ae99998c35d, xdba72a854689476e);
		}
	}

	internal static SizeF x71b0f13c06d08cd9(SizeF x0ceec69a97f73617, double xcb83cdf6822fc99d)
	{
		SizeF result = x0ceec69a97f73617;
		switch ((int)x777e7bc0eab9eb24(xcb83cdf6822fc99d))
		{
		case 90:
		case 270:
			result = new SizeF(x0ceec69a97f73617.Height, x0ceec69a97f73617.Width);
			break;
		}
		return result;
	}

	private static double x777e7bc0eab9eb24(double x9fe66646ce47372a)
	{
		double num = x9fe66646ce47372a % 360.0;
		if (!(num < 0.0))
		{
			return num;
		}
		return 360.0 + num;
	}

	internal x409512556c3f2a9a(ShapeBase shape)
		: this()
	{
		if (shape.IsHorizontalRule)
		{
			xd7349b4fe5e74804 = x37604adeead3e2b5.xbf10b131db29ad53;
			x11973ad34d8be202 = ((shape.ShapeType == ShapeType.Image) ? xd372c62feb02ff45.xffc166cbab8d054a : xd372c62feb02ff45.xa798ad628c510224);
		}
		else if (shape.IsWordArt)
		{
			xd7349b4fe5e74804 = x37604adeead3e2b5.xbf10b131db29ad53;
			x11973ad34d8be202 = xd372c62feb02ff45.x17d36b1e7e8ddf63;
		}
		else
		{
			switch (shape.ShapeType)
			{
			case ShapeType.Image:
			{
				Shape shape2 = (Shape)shape;
				xd7349b4fe5e74804 = (shape2.ImageData.IsLinkOnly ? x37604adeead3e2b5.x7634dd95e10c7658 : x37604adeead3e2b5.xbf10b131db29ad53);
				x11973ad34d8be202 = xd372c62feb02ff45.xbe1f71187c4fb582;
				break;
			}
			case ShapeType.OleObject:
			case ShapeType.OleControl:
				xd7349b4fe5e74804 = x37604adeead3e2b5.xbf10b131db29ad53;
				x11973ad34d8be202 = xd372c62feb02ff45.x7de9d535566b3b3f;
				break;
			default:
				xd7349b4fe5e74804 = x37604adeead3e2b5.xbf10b131db29ad53;
				x11973ad34d8be202 = xd372c62feb02ff45.x39fe35bdfe73f135;
				break;
			}
		}
		if (shape.IsTopLevel)
		{
			xca94f756b08d1cdc = x4574ea26106f0edb.x88bf16f2386d633e(shape.Width);
			x5bac491e3ece48e1 = x4574ea26106f0edb.x88bf16f2386d633e(shape.Height);
		}
		else
		{
			xca94f756b08d1cdc = (int)shape.Width;
			x5bac491e3ece48e1 = (int)shape.Height;
		}
		xf7125312c7ee115c xf7125312c7ee115c = shape.xf7125312c7ee115c;
		xd6620b0e1246ad2a = (Border)xf7125312c7ee115c.xfe91eeeafcb3026a(4106);
		xf73cc7f38537c2b7 = (Border)xf7125312c7ee115c.xfe91eeeafcb3026a(4107);
		x64750eb70ee7300d = (Border)xf7125312c7ee115c.xfe91eeeafcb3026a(4108);
		x9d89a3496dc35374 = (Border)xf7125312c7ee115c.xfe91eeeafcb3026a(4109);
		SizeF sizeF = x71b0f13c06d08cd9(shape.x437e3b626c0fdd43, shape.Rotation);
		x06857957e1e54e75 = (int)Math.Round((double)sizeF.Width / shape.Width * 1000.0);
		xe9d9b2de9b686edd = (int)Math.Round((double)sizeF.Height / shape.Height * 1000.0);
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write(xf280755e03a40325);
		xbdfb620b7167944b.Write((ushort)xd6696a1209486da5);
		xbdfb620b7167944b.Write((ushort)xd7349b4fe5e74804);
		xbdfb620b7167944b.Write((ushort)xf5519517e7282b34);
		xbdfb620b7167944b.Write((ushort)x76096e1f3bef3f76);
		xbdfb620b7167944b.Write((ushort)x8b368e3901d7e60c);
		xbdfb620b7167944b.Write((ushort)x11973ad34d8be202);
		xbdfb620b7167944b.Write((ushort)xf3c006205b66ef7b);
		xbdfb620b7167944b.Write((ushort)xfa6ea744155689ad);
		xbdfb620b7167944b.Write((ushort)x77b193b0c5b926ef);
		xbdfb620b7167944b.Write((ushort)xdf0cf91496cdbd62);
		xbdfb620b7167944b.Write((ushort)x1c04732f63de1934);
		xbdfb620b7167944b.Write((ushort)x71d244b6916f28a3);
		xbdfb620b7167944b.Write((ushort)xca94f756b08d1cdc);
		xbdfb620b7167944b.Write((ushort)x5bac491e3ece48e1);
		xbdfb620b7167944b.Write((ushort)x06857957e1e54e75);
		xbdfb620b7167944b.Write((ushort)xe9d9b2de9b686edd);
		xbdfb620b7167944b.Write((short)xd8267e571f6d1fc1);
		xbdfb620b7167944b.Write((short)x0c6b05bf8cf85977);
		xbdfb620b7167944b.Write((short)x676dfed17227e913);
		xbdfb620b7167944b.Write((short)xb0e559b84dd894a4);
		int num = 0;
		num |= x9d0c3ba83d6141b8;
		num |= (x2b4315ee2d70cc84 ? 16 : 0);
		num |= (xbbea97dbf0fbd3ee ? 32 : 0);
		num |= (x726f04901be5090c ? 64 : 0);
		num |= (x8da079b2e47e094c ? 128 : 0);
		num |= x5c1479d50c3706b8 << 8;
		xbdfb620b7167944b.Write((ushort)num);
		x1df55585ec1be056.x2beefb7099c2c239(xd6620b0e1246ad2a, xbdfb620b7167944b, x10e248b4013349b1: false);
		x1df55585ec1be056.x2beefb7099c2c239(xf73cc7f38537c2b7, xbdfb620b7167944b, x10e248b4013349b1: false);
		x1df55585ec1be056.x2beefb7099c2c239(x64750eb70ee7300d, xbdfb620b7167944b, x10e248b4013349b1: false);
		x1df55585ec1be056.x2beefb7099c2c239(x9d89a3496dc35374, xbdfb620b7167944b, x10e248b4013349b1: false);
		xbdfb620b7167944b.Write((short)xcf2c030d81af0438);
		xbdfb620b7167944b.Write((short)x47c37ae99998c35d);
		xbdfb620b7167944b.Write((short)xdba72a854689476e);
	}

	internal void x865b320f557323c1(ShapeBase x5770cdefd8931aa9)
	{
		SizeF sizeF = x71b0f13c06d08cd9(new SizeF(xca94f756b08d1cdc, x5bac491e3ece48e1), x5770cdefd8931aa9.Rotation);
		double num = sizeF.Width / (float)xca94f756b08d1cdc * 1000f;
		double num2 = sizeF.Height / (float)x5bac491e3ece48e1 * 1000f;
		double num3 = (double)x06857957e1e54e75 / num;
		double num4 = (double)xe9d9b2de9b686edd / num2;
		num3 = (x15e971129fd80714.x5ab3b42bd288ad29(num3) ? 1.0 : num3);
		num4 = (x15e971129fd80714.x5ab3b42bd288ad29(num4) ? 1.0 : num4);
		double xf6495da3f9ed2d9c = (double)xca94f756b08d1cdc * num3;
		double xf6495da3f9ed2d9c2 = (double)x5bac491e3ece48e1 * num4;
		x5770cdefd8931aa9.x404ab2fc377ad1ed(x4574ea26106f0edb.x0e1fdb362561ddb2(xf6495da3f9ed2d9c2));
		x5770cdefd8931aa9.xf524ccc95fe8e714(x4574ea26106f0edb.x0e1fdb362561ddb2(xf6495da3f9ed2d9c));
		x5770cdefd8931aa9.x4ad54dc2280f4b6f();
		xfc5bb3f769cce998(xf73cc7f38537c2b7, x5770cdefd8931aa9, 4107, 924);
		xfc5bb3f769cce998(xd6620b0e1246ad2a, x5770cdefd8931aa9, 4106, 923);
		xfc5bb3f769cce998(x9d89a3496dc35374, x5770cdefd8931aa9, 4109, 926);
		xfc5bb3f769cce998(x64750eb70ee7300d, x5770cdefd8931aa9, 4108, 925);
	}

	private static void xfc5bb3f769cce998(Border x14cf9593b86ecbaa, ShapeBase x5770cdefd8931aa9, int x802e3e5ee7a67f98, int xbec3668789aad87e)
	{
		xf7125312c7ee115c xf7125312c7ee115c = x5770cdefd8931aa9.xf7125312c7ee115c;
		if (xf7125312c7ee115c.xbc5dc59d0d9b620d(xbec3668789aad87e))
		{
			x14cf9593b86ecbaa.x63b1a7c31a962459 = (x26d9ecb4bdf0456d)xf7125312c7ee115c.xf7866f89640a29a3(xbec3668789aad87e);
			xf7125312c7ee115c.x52b190e626f65140(xbec3668789aad87e);
		}
		xf7125312c7ee115c.xae20093bed1e48a8(x802e3e5ee7a67f98, x14cf9593b86ecbaa);
	}
}
