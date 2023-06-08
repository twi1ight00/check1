using System;
using System.Drawing;
using x5794c252ba25e723;

namespace x4f4df92b75ba3b67;

internal class x12723596215025ca : x02cd5c9c8d54330e
{
	private const string x7ad00e74ffee452a = "/Shading";

	private const string xc2c08cbbb4f9d915 = "/Coords";

	private const string xdef2f0f0d81e64a2 = "/ColorSpace";

	private const string x5d7b838eac33be3f = "/ShadingType";

	private const string x9e8d0366db01ddcf = "/Function";

	private const string xad695005a1229750 = "/Extend";

	private const int xabdce98c942ec97b = 2;

	private readonly x5f55370cc09dd787 xa31c8fed8093bc20;

	private readonly xbbf64dacc941f5e3 x36041e68292e37f3;

	private bool x84e1e50a3421c070;

	private bool x175139f73e294baa;

	private static readonly float[] xc50927cbe946fd2f = new float[2] { 0f, 1f };

	private static readonly float[] xf129fddcfaa75c15 = new float[2] { 0f, 1f };

	protected override int PatternType => 2;

	protected override x54366fa5f75a02f7 BrushTransform => xa31c8fed8093bc20.xaccac17571a8d9fa;

	internal x12723596215025ca(x4882ae789be6e2ef context, x5f55370cc09dd787 brush)
		: base(context)
	{
		xa31c8fed8093bc20 = brush;
		x36041e68292e37f3 = x4dac7b0712beae74();
	}

	internal override void x0a2e1f2c2da67e52(x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		base.x0a2e1f2c2da67e52(xbdfb620b7167944b);
		xbdfb620b7167944b.x6210059f049f0d48("/Shading");
		xbdfb620b7167944b.xafb7e6f79ed43681();
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/ShadingType", 2);
		PointF[] array = xb13f159c4a881354();
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Extend", new bool[2] { x84e1e50a3421c070, x175139f73e294baa });
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/ColorSpace", x28d5285d743f03f5.x529d0bc70de5de1f.x0155217fb8bbda6a);
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Coords", new float[4]
		{
			array[0].X,
			array[0].Y,
			array[1].X,
			array[1].Y
		});
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Function", x36041e68292e37f3.x899a2110a8a35fda);
		xbdfb620b7167944b.x693a8d6d020474f2();
		xcf7a6694b0b373cb(xbdfb620b7167944b);
	}

	private PointF[] xb13f159c4a881354()
	{
		float left = xa31c8fed8093bc20.x404d528fe2f10961.Left;
		float right = xa31c8fed8093bc20.x404d528fe2f10961.Right;
		float num = (xa31c8fed8093bc20.x404d528fe2f10961.Bottom - xa31c8fed8093bc20.x404d528fe2f10961.Top) / 2f;
		float y = num;
		x175139f73e294baa = true;
		x84e1e50a3421c070 = true;
		return new PointF[2]
		{
			new PointF(left, num),
			new PointF(right, y)
		};
	}

	private xbbf64dacc941f5e3 x4dac7b0712beae74()
	{
		int num;
		float[][] array;
		if (xa31c8fed8093bc20.xcc7b76ceb682651c == null)
		{
			float[] x76dec2960c4aa9cc = xa31c8fed8093bc20.x76dec2960c4aa9cc;
			if (x76dec2960c4aa9cc == null)
			{
				x76dec2960c4aa9cc = xc50927cbe946fd2f;
			}
			float[] xa086f258e4907f = xa31c8fed8093bc20.xa086f258e4907f49;
			if (xa086f258e4907f == null)
			{
				xa086f258e4907f = xf129fddcfaa75c15;
			}
			num = x76dec2960c4aa9cc.Length + 1;
			array = new float[num][];
			for (int i = 0; i < num; i++)
			{
				array[i] = new float[4];
			}
			array[num - 1][0] = 1f;
			for (int j = 0; j < 3; j++)
			{
				array[num - 1][j + 1] = x2047cb490d46eb96(xa31c8fed8093bc20.xf3874816968aabd7, j);
			}
			for (int k = 0; k < num - 1; k++)
			{
				float num2 = x76dec2960c4aa9cc[k];
				if (num2 <= 1f)
				{
					array[k][0] = num2;
				}
				for (int l = 0; l < 3; l++)
				{
					float num3 = xa086f258e4907f[k] * x2047cb490d46eb96(xa31c8fed8093bc20.xf3874816968aabd7, l);
					float num4 = 1f - xa086f258e4907f[k];
					float num5 = x2047cb490d46eb96(xa31c8fed8093bc20.x7d2dc175c2f289c5, l);
					array[k][l + 1] = num3 + num4 * num5;
				}
			}
		}
		else
		{
			num = xa31c8fed8093bc20.xcc7b76ceb682651c.Length;
			array = new float[num][];
			for (int m = 0; m < num; m++)
			{
				array[m] = new float[4];
			}
			for (int n = 0; n < num; n++)
			{
				array[n][0] = xa31c8fed8093bc20.xcc7b76ceb682651c[n].xbe1e23e7d5b43370;
				for (int num6 = 0; num6 < 3; num6++)
				{
					x26d9ecb4bdf0456d x9b41425268471380 = xa31c8fed8093bc20.xcc7b76ceb682651c[n].x9b41425268471380;
					array[n][num6 + 1] = x2047cb490d46eb96(x9b41425268471380, num6);
				}
			}
		}
		return xe5f255046018d578.x1b45e56db81ccf88(x8cedcaa9a62c6e39, array, num, 1, 3);
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		writer.x7a67b9beb30292d6(this);
		writer.xafb7e6f79ed43681();
		x0a2e1f2c2da67e52(writer);
		writer.x693a8d6d020474f2();
		writer.x5155d7b9dab28280();
		x36041e68292e37f3.WriteToPdf(writer);
	}

	private static float x2047cb490d46eb96(x26d9ecb4bdf0456d x6c50a99faab7d741, int xc0c4c459c6ccbd00)
	{
		return (float)((double)(xc0c4c459c6ccbd00 switch
		{
			0 => x6c50a99faab7d741.xc613adc4330033f3, 
			1 => x6c50a99faab7d741.x26463655896fd90a, 
			2 => x6c50a99faab7d741.x8e8f6cc6a0756b05, 
			_ => throw new ArgumentOutOfRangeException(), 
		}) / 255.0);
	}
}
