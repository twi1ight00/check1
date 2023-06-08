using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Words;
using x1c8faa688b1f0b0c;
using x28925c9b27b37a46;
using x5794c252ba25e723;
using x6a42c37b95e9caa1;

namespace x99ec507695f2d4ff;

internal class x3bc42b548f62bdca
{
	private x3bc42b548f62bdca()
	{
	}

	internal static xab391c46ff9a0a38 xa4520be1beb8f046(RectangleF x2b9a737426626c14, Shading x12b7f8e5698b30a6)
	{
		if (x2b9a737426626c14.IsEmpty || !x12b7f8e5698b30a6.xa853df7acdb217c8)
		{
			return null;
		}
		xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.x7c89cd07f845b8e1(x2b9a737426626c14);
		xab391c46ff9a0a.x60465f602599d327 = xc7772fb8a479ad90(x12b7f8e5698b30a6);
		return xab391c46ff9a0a;
	}

	internal static void xa4520be1beb8f046(RectangleF x26545669838eb36e, Shading x12b7f8e5698b30a6, xe6a5f3ec802a6d51 x0f7b23d1c393aed9)
	{
		x4fdf549af9de6b97 x4fdf549af9de6b = xa4520be1beb8f046(x26545669838eb36e, x12b7f8e5698b30a6);
		if (x4fdf549af9de6b != null)
		{
			x0f7b23d1c393aed9.x1fa9148f6731ff24(x4fdf549af9de6b);
		}
	}

	internal static void x8718948f6419ddd0(RectangleF x26545669838eb36e, xe6a5f3ec802a6d51 x0f7b23d1c393aed9)
	{
		x50d1d9409206b81b(x26545669838eb36e, new xc020fa2f5133cba8(x26d9ecb4bdf0456d.xfaad9cc1bd5f71bd), x0f7b23d1c393aed9);
	}

	private static void x50d1d9409206b81b(RectangleF x26545669838eb36e, x845d6a068e0b03c5 xd8f1949f8950238a, xe6a5f3ec802a6d51 x0f7b23d1c393aed9)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.x7c89cd07f845b8e1(x26545669838eb36e);
		xab391c46ff9a0a.x60465f602599d327 = xd8f1949f8950238a;
		x0f7b23d1c393aed9.x1fa9148f6731ff24(xab391c46ff9a0a);
	}

	private static x845d6a068e0b03c5 xc7772fb8a479ad90(Shading x12b7f8e5698b30a6)
	{
		x26d9ecb4bdf0456d x26d9ecb4bdf0456d = x9df536d98415d2d0.x893d2de060ba9359(x12b7f8e5698b30a6.x0e18178ac4b2272f);
		x26d9ecb4bdf0456d x26d9ecb4bdf0456d2 = x9df536d98415d2d0.x20fbec1cd9812891(x12b7f8e5698b30a6.xc290f60df004e384);
		TextureIndex texture = x12b7f8e5698b30a6.Texture;
		if (x26d9ecb4bdf0456d.x7149c962c02931b3 && (texture == TextureIndex.TextureNil || texture == TextureIndex.TextureNone))
		{
			return null;
		}
		if (xb7dbd7bb3ed97d5b.x36694757e8d7e52b(texture))
		{
			return new x5bdb4ba66c23277c(xf1f060414f2fd034(texture), x26d9ecb4bdf0456d2, x26d9ecb4bdf0456d);
		}
		double x607a3f96d060de = xb7dbd7bb3ed97d5b.x73ef7a6dac3d681b(x12b7f8e5698b30a6.Texture);
		return new xc020fa2f5133cba8(xb7dbd7bb3ed97d5b.x87e2b03b45effe52(x26d9ecb4bdf0456d2, x26d9ecb4bdf0456d, x607a3f96d060de));
	}

	private static HatchStyle xf1f060414f2fd034(TextureIndex xc0c4c459c6ccbd00)
	{
		return xc0c4c459c6ccbd00 switch
		{
			TextureIndex.TextureCross => HatchStyle.SmallGrid, 
			TextureIndex.TextureDarkCross => HatchStyle.SmallCheckerBoard, 
			TextureIndex.TextureDarkDiagonalCross => HatchStyle.Trellis, 
			TextureIndex.TextureDarkDiagonalDown => HatchStyle.DarkDownwardDiagonal, 
			TextureIndex.TextureDarkDiagonalUp => HatchStyle.DarkUpwardDiagonal, 
			TextureIndex.TextureDarkHorizontal => HatchStyle.DarkHorizontal, 
			TextureIndex.TextureDarkVertical => HatchStyle.DarkVertical, 
			TextureIndex.TextureDiagonalCross => HatchStyle.OutlinedDiamond, 
			TextureIndex.TextureDiagonalDown => HatchStyle.LightDownwardDiagonal, 
			TextureIndex.TextureDiagonalUp => HatchStyle.LightUpwardDiagonal, 
			TextureIndex.TextureHorizontal => HatchStyle.LightHorizontal, 
			TextureIndex.TextureVertical => HatchStyle.LightVertical, 
			_ => HatchStyle.Horizontal, 
		};
	}
}
