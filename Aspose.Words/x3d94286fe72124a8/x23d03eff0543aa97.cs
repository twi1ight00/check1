using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose;
using Aspose.Words.Drawing;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x3d94286fe72124a8;

[JavaManual("Autoport later. Autoportable versions of GraphicsPath and font measuring/rendering are needed.")]
internal class x23d03eff0543aa97
{
	internal static xb8e7e788f6d59708 xe406325e56f74b46(xa37343ccb8cd8c70 x0f7b23d1c393aed9)
	{
		TextPath textPath = x0f7b23d1c393aed9.xa9993ed2e0c64574.TextPath;
		xb8e7e788f6d59708 xa1eafe7821eb4aab = x0f7b23d1c393aed9.xa1eafe7821eb4aab;
		x31c19fcb724dfaf5 xa0640346645809ad = x0f7b23d1c393aed9.xa0640346645809ad;
		x845d6a068e0b03c5 x8dc20c37aa4b28ef = x0f7b23d1c393aed9.x8dc20c37aa4b28ef;
		SizeF sizeInPoints = x0f7b23d1c393aed9.xa9993ed2e0c64574.SizeInPoints;
		float height = sizeInPoints.Height;
		SizeF x3f12b0f26570dac;
		GraphicsPath graphicsPath = x84638d920745443f(textPath, height, out x3f12b0f26570dac);
		if (graphicsPath.PointCount == 0)
		{
			return null;
		}
		xab391c46ff9a0a38 xe125219852864557;
		if (xa1eafe7821eb4aab.xd44988f225497f3a == 1 && textPath.FitShape)
		{
			xab391c46ff9a0a38 xab391c46ff9a0a = (xab391c46ff9a0a38)((xbaec545ec01f92ca)xa1eafe7821eb4aab).get_xe6d4b1b411ed94b5(0);
			if (xab391c46ff9a0a.xd44988f225497f3a == 2)
			{
				try
				{
					xe125219852864557 = x007016c171ee776d(graphicsPath, (x1cab6af0a41b70e2)((xbaec545ec01f92ca)xab391c46ff9a0a).get_xe6d4b1b411ed94b5(0), (x1cab6af0a41b70e2)((xbaec545ec01f92ca)xab391c46ff9a0a).get_xe6d4b1b411ed94b5(1), textPath.Trim, height, x3f12b0f26570dac);
					return x09d3a7e8edcf215b(xe125219852864557, xa0640346645809ad, x8dc20c37aa4b28ef);
				}
				catch (x5ba85f4e196ffeb3)
				{
					x0f7b23d1c393aed9.xf69ca7a9bb4a4a51.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x13efdeb5b4f0d186, x3959df40367ac8a3.xe42bd130f1e95570, "WordArt unsupported path type encountered.");
				}
			}
		}
		xe125219852864557 = x735be997b203d521(x0f7b23d1c393aed9, graphicsPath, sizeInPoints);
		return x09d3a7e8edcf215b(xe125219852864557, xa0640346645809ad, x8dc20c37aa4b28ef);
	}

	private static xab391c46ff9a0a38 x735be997b203d521(xa37343ccb8cd8c70 x0f7b23d1c393aed9, GraphicsPath x80a2bffce1e66dcd, SizeF x6e2d45096e69e5bf)
	{
		x0f7b23d1c393aed9.xf69ca7a9bb4a4a51.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x3d55d2f5d9d21184, x3959df40367ac8a3.xe42bd130f1e95570, "WordArt unsupported rendering mode.");
		x1cab6af0a41b70e2 x1cab6af0a41b70e = new x1cab6af0a41b70e2();
		x1cab6af0a41b70e.xd6b6ed77479ef68c(new x60c040f35bb272aa(new PointF[2]
		{
			PointF.Empty,
			new PointF(x6e2d45096e69e5bf.Width, 0f)
		}));
		x1cab6af0a41b70e2 x1cab6af0a41b70e2 = new x1cab6af0a41b70e2();
		x1cab6af0a41b70e2.xd6b6ed77479ef68c(new x60c040f35bb272aa(new PointF[2]
		{
			new PointF(0f, x6e2d45096e69e5bf.Height),
			new PointF(x6e2d45096e69e5bf.Width, x6e2d45096e69e5bf.Height)
		}));
		return x007016c171ee776d(x80a2bffce1e66dcd, x1cab6af0a41b70e, x1cab6af0a41b70e2, x30886d8c7a431a18: true, x6e2d45096e69e5bf.Height, SizeF.Empty);
	}

	private static xb8e7e788f6d59708 x09d3a7e8edcf215b(xab391c46ff9a0a38 xe125219852864557, x31c19fcb724dfaf5 x90279591611601bc, x845d6a068e0b03c5 xd8f1949f8950238a)
	{
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		xe125219852864557.x9e5d5f9128c69a8f = x90279591611601bc;
		xe125219852864557.x60465f602599d327 = xd8f1949f8950238a;
		xb8e7e788f6d.xd6b6ed77479ef68c(xe125219852864557);
		return xb8e7e788f6d;
	}

	private static GraphicsPath x84638d920745443f(TextPath x37169c88a38f2f9b, float x4d5aabc7a55b12ba, out SizeF x3f12b0f26570dac9)
	{
		if (x4d5aabc7a55b12ba <= 0f)
		{
			x3f12b0f26570dac9 = new SizeF(0f, 0f);
			return new GraphicsPath();
		}
		int xdf2a58420a175f = x659bc4263aa7ef66(x37169c88a38f2f9b.Bold, x37169c88a38f2f9b.Italic, x37169c88a38f2f9b.StrikeThrough, x37169c88a38f2f9b.Underline);
		using Font font = x425a68c71e891281.xae317a9630af3402(x37169c88a38f2f9b.FontFamily, x4d5aabc7a55b12ba, (FontStyle)xdf2a58420a175f);
		xdf2a58420a175f = (int)font.Style;
		StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
		stringFormat.LineAlignment = StringAlignment.Far;
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddString(x37169c88a38f2f9b.Text, font.FontFamily, xdf2a58420a175f, x4d5aabc7a55b12ba, new PointF(0f, x4d5aabc7a55b12ba), stringFormat);
		x3f12b0f26570dac9 = x0a8f2a18d3b53839(x37169c88a38f2f9b.Text, font, stringFormat);
		return graphicsPath;
	}

	private static int x659bc4263aa7ef66(bool xfb7d9aaaa3bb766b, bool xe8c0bbd4d5297920, bool x6e03bdff5854a926, bool x98e3d870f2952584)
	{
		int num = 0;
		if (xfb7d9aaaa3bb766b)
		{
			num |= 1;
		}
		if (xe8c0bbd4d5297920)
		{
			num |= 2;
		}
		if (x98e3d870f2952584)
		{
			num |= 4;
		}
		return num;
	}

	private static xab391c46ff9a0a38 x39e5504ca6fcb828(GraphicsPath xe125219852864557)
	{
		return new xab391c46ff9a0a38();
	}

	private static SizeF x0a8f2a18d3b53839(string xb41faee6912a2313, Font x26094932cf7a9139, StringFormat x5786461d089b10a0)
	{
		Bitmap bitmap = new Bitmap(1, 1);
		Graphics graphics = xaf1d5886bde15736.x2c0e2b36cc23e6ca(bitmap);
		PointF empty = PointF.Empty;
		SizeF sizeF = graphics.MeasureString(xb41faee6912a2313, x26094932cf7a9139, empty, x5786461d089b10a0);
		float width = (float)x4574ea26106f0edb.x9adffc4de2e5ac97(sizeF.Width / graphics.DpiX);
		float height = (float)x4574ea26106f0edb.x9adffc4de2e5ac97(sizeF.Height / graphics.DpiY);
		graphics.Dispose();
		bitmap.Dispose();
		return new SizeF(width, height);
	}

	private static xab391c46ff9a0a38 x007016c171ee776d(GraphicsPath x80a2bffce1e66dcd, x1cab6af0a41b70e2 x01cc44b88be5d87d, x1cab6af0a41b70e2 xd7719da73608be48, bool x30886d8c7a431a18, float x7b4eec7cd3321e38, SizeF x3f12b0f26570dac9)
	{
		float num;
		float num2;
		float width;
		float num3;
		if (x30886d8c7a431a18)
		{
			RectangleF bounds = x80a2bffce1e66dcd.GetBounds();
			num = bounds.Left;
			num2 = bounds.Top;
			width = bounds.Width;
			num3 = bounds.Height;
		}
		else
		{
			num = 0f;
			num2 = 0f;
			width = x3f12b0f26570dac9.Width;
			num3 = x7b4eec7cd3321e38;
		}
		PointF[] pathPoints = x80a2bffce1e66dcd.PathPoints;
		x631336145a8f7171 x631336145a8f7172 = new x631336145a8f7171();
		for (int i = 0; i < pathPoints.Length; i++)
		{
			PointF pointF = pathPoints[i];
			float num4 = pointF.X - num;
			float num5 = pointF.Y - num2;
			float num6 = num4 / width;
			float num7 = num5 / num3;
			if (num6 > 1f)
			{
				num6 = 1f;
			}
			if (num7 > 1f)
			{
				num7 = 1f;
			}
			PointF x10aaa7cdfa38f = x631336145a8f7172.x1ea772e6d628a391(x01cc44b88be5d87d, num6);
			PointF xca09b6c2b5b = x631336145a8f7172.x1ea772e6d628a391(xd7719da73608be48, num6);
			float num8 = x631336145a8f7171.xfde8a66a3e6995b3(x10aaa7cdfa38f, xca09b6c2b5b);
			PointF pointF2 = x631336145a8f7171.x86329abe226ef8ef(x10aaa7cdfa38f, xca09b6c2b5b, num8 * num7);
			pathPoints[i] = pointF2;
		}
		return x7acdaa1b170a3a5a(pathPoints, x80a2bffce1e66dcd.PathTypes);
	}

	private static xab391c46ff9a0a38 x7acdaa1b170a3a5a(PointF[] x6fa2570084b2ad39, byte[] x8f76a1a9d286e18b)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38();
		x1cab6af0a41b70e2 x1cab6af0a41b70e = null;
		PointF[] array = new PointF[4]
		{
			PointF.Empty,
			PointF.Empty,
			PointF.Empty,
			PointF.Empty
		};
		PointF pointF = PointF.Empty;
		int num = 0;
		x60c040f35bb272aa x60c040f35bb272aa = null;
		for (int i = 0; i < x6fa2570084b2ad39.Length; i++)
		{
			float x = x6fa2570084b2ad39[i].X;
			float y = x6fa2570084b2ad39[i].Y;
			if (x8f76a1a9d286e18b[i] == 0)
			{
				x1cab6af0a41b70e = new x1cab6af0a41b70e2();
				x1cab6af0a41b70e.x5e6c52cb3256cc85 = true;
				x60c040f35bb272aa = null;
				pointF = new PointF(x, y);
				continue;
			}
			if ((x8f76a1a9d286e18b[i] & 3) == 3)
			{
				x60c040f35bb272aa = null;
				if (num == 0)
				{
					array = new PointF[4]
					{
						PointF.Empty,
						PointF.Empty,
						PointF.Empty,
						PointF.Empty
					};
					array[0] = pointF;
				}
				num++;
				ref PointF reference = ref array[num];
				reference = new PointF(x, y);
				if (num == 3)
				{
					num = 0;
					x1cab6af0a41b70e.xd6b6ed77479ef68c(new x519b1bd0625473ff(array));
					pointF = array[3];
				}
			}
			else if ((x8f76a1a9d286e18b[i] & 1) == 1)
			{
				if (x60c040f35bb272aa == null)
				{
					x60c040f35bb272aa = new x60c040f35bb272aa();
					x1cab6af0a41b70e.xd6b6ed77479ef68c(x60c040f35bb272aa);
					x60c040f35bb272aa.x4d7474e8f1849803.Add(pointF);
				}
				pointF = new PointF(x, y);
				x60c040f35bb272aa.x4d7474e8f1849803.Add(pointF);
			}
			if ((x8f76a1a9d286e18b[i] & 0x80) == 128)
			{
				xab391c46ff9a0a.xd6b6ed77479ef68c(x1cab6af0a41b70e);
				x1cab6af0a41b70e = new x1cab6af0a41b70e2();
				x1cab6af0a41b70e.x5e6c52cb3256cc85 = true;
				x60c040f35bb272aa = null;
				num = 0;
			}
		}
		return xab391c46ff9a0a;
	}
}
