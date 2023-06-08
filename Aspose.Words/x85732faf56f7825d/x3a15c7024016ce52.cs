using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Aspose;
using x13f1efc79617a47b;
using x1c8faa688b1f0b0c;
using x38a89dee67fc7a16;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xf84f8427dc22d095;
using xf9a9481c3f63a419;

namespace x85732faf56f7825d;

[JavaManual("Manual by design.")]
internal class x3a15c7024016ce52 : xf51865b83a7a0b3b
{
	private Graphics x5655a9d7a2d95414;

	private readonly x5250236f9cf73045 x336289835451ba12 = new x5250236f9cf73045();

	private readonly Stack x4c7702a58aee3895 = new Stack();

	private readonly Stack xfb2bff2aedf0953a = new Stack();

	private static readonly StringFormat xa0cc64dbee26ee05;

	private xd7494258f09928b1 x44c05b9fd5bea2a6;

	private readonly x54b98d0096d7251a xa056586c1f99e199;

	public x3a15c7024016ce52()
		: this(null)
	{
	}

	public x3a15c7024016ce52(x54b98d0096d7251a warningCallback)
	{
		xa056586c1f99e199 = ((warningCallback != null) ? warningCallback : x8694a2e0856b3478.x9834ddb0e0bd5996);
	}

	public void xe406325e56f74b46(x4fdf549af9de6b97 xda5bf54deb817e37, Graphics x41347a961b838962)
	{
		if (xda5bf54deb817e37 == null)
		{
			throw new ArgumentNullException("node");
		}
		if (x41347a961b838962 == null)
		{
			throw new ArgumentNullException("graphics");
		}
		GraphicsUnit pageUnit = x41347a961b838962.PageUnit;
		x41347a961b838962.PageUnit = GraphicsUnit.Point;
		float pageScale = x41347a961b838962.PageScale;
		x41347a961b838962.PageScale = 1f;
		x5655a9d7a2d95414 = x41347a961b838962;
		using (x44c05b9fd5bea2a6 = new xd7494258f09928b1())
		{
			xda5bf54deb817e37.Accept(this);
		}
		x41347a961b838962.PageScale = pageScale;
		x41347a961b838962.PageUnit = pageUnit;
	}

	public SizeF x231ed5305a7bb3ea(x4fdf549af9de6b97 xdb732bbde4502b4e, SizeF xa03db8a5ee939042, Graphics x41347a961b838962, float x08db3aeabb253cb1, float x1e218ceaee1bb583, float x9bdeb785c5aca5b5)
	{
		if (xdb732bbde4502b4e == null)
		{
			throw new ArgumentNullException("aps");
		}
		if (x41347a961b838962 == null)
		{
			throw new ArgumentNullException("graphics");
		}
		if (x9bdeb785c5aca5b5 <= 0f)
		{
			throw new ArgumentOutOfRangeException("scale");
		}
		Matrix matrix = x206418821030fd55(x41347a961b838962, x08db3aeabb253cb1, x1e218ceaee1bb583);
		matrix.Scale(x9bdeb785c5aca5b5, x9bdeb785c5aca5b5, MatrixOrder.Prepend);
		Matrix transform = x41347a961b838962.Transform;
		x41347a961b838962.Transform = matrix;
		xe406325e56f74b46(xdb732bbde4502b4e, x41347a961b838962);
		x41347a961b838962.Transform = transform;
		PointF pointF = x3f7c1d6a9ea87f70(xa03db8a5ee939042.ToPointF(), x41347a961b838962);
		return new SizeF(pointF.X * x9bdeb785c5aca5b5, pointF.Y * x9bdeb785c5aca5b5);
	}

	public float xc8a427e6e672c1ed(x4fdf549af9de6b97 xdb732bbde4502b4e, SizeF xa03db8a5ee939042, Graphics x41347a961b838962, float x08db3aeabb253cb1, float x1e218ceaee1bb583, float x9b0739496f8b5475, float x4d5aabc7a55b12ba)
	{
		if (xdb732bbde4502b4e == null)
		{
			throw new ArgumentNullException("aps");
		}
		if (x41347a961b838962 == null)
		{
			throw new ArgumentNullException("graphics");
		}
		if (x9b0739496f8b5475 <= 0f)
		{
			throw new ArgumentOutOfRangeException("width");
		}
		if (x4d5aabc7a55b12ba <= 0f)
		{
			throw new ArgumentOutOfRangeException("height");
		}
		Matrix matrix = x206418821030fd55(x41347a961b838962, x08db3aeabb253cb1, x1e218ceaee1bb583);
		PointF pointF = x3b8060e736fc01f0(new PointF(x9b0739496f8b5475, x4d5aabc7a55b12ba), x41347a961b838962);
		float val = pointF.X / xa03db8a5ee939042.Width;
		float val2 = pointF.Y / xa03db8a5ee939042.Height;
		float num = Math.Min(val, val2);
		matrix.Scale(num, num, MatrixOrder.Prepend);
		Matrix transform = x41347a961b838962.Transform;
		x41347a961b838962.Transform = matrix;
		xe406325e56f74b46(xdb732bbde4502b4e, x41347a961b838962);
		x41347a961b838962.Transform = transform;
		return num;
	}

	private static Matrix x206418821030fd55(Graphics x41347a961b838962, float x08db3aeabb253cb1, float x1e218ceaee1bb583)
	{
		Matrix transform = x41347a961b838962.Transform;
		PointF pointF = x3b8060e736fc01f0(new PointF(transform.OffsetX, transform.OffsetY), x41347a961b838962);
		float[] elements = transform.Elements;
		Matrix matrix = new Matrix(elements[0], elements[1], elements[2], elements[3], pointF.X, pointF.Y);
		PointF pointF2 = x3b8060e736fc01f0(new PointF(x08db3aeabb253cb1, x1e218ceaee1bb583), x41347a961b838962);
		matrix.Translate(pointF2.X, pointF2.Y, MatrixOrder.Prepend);
		return matrix;
	}

	private static PointF x3b8060e736fc01f0(PointF x2f7096dac971d6ec, Graphics x215b699370f39c10)
	{
		switch (x215b699370f39c10.PageUnit)
		{
		case GraphicsUnit.Inch:
			x2f7096dac971d6ec.X = (float)x4574ea26106f0edb.x9adffc4de2e5ac97(x2f7096dac971d6ec.X);
			x2f7096dac971d6ec.Y = (float)x4574ea26106f0edb.x9adffc4de2e5ac97(x2f7096dac971d6ec.Y);
			break;
		case GraphicsUnit.Millimeter:
			x2f7096dac971d6ec.X = (float)x4574ea26106f0edb.x5612f4c9f83f95d3(x2f7096dac971d6ec.X);
			x2f7096dac971d6ec.Y = (float)x4574ea26106f0edb.x5612f4c9f83f95d3(x2f7096dac971d6ec.Y);
			break;
		case GraphicsUnit.Pixel:
			x2f7096dac971d6ec.X = (float)x4574ea26106f0edb.xad2dd08366e0faf5(x2f7096dac971d6ec.X, x215b699370f39c10.DpiX);
			x2f7096dac971d6ec.Y = (float)x4574ea26106f0edb.xad2dd08366e0faf5(x2f7096dac971d6ec.Y, x215b699370f39c10.DpiY);
			break;
		case GraphicsUnit.Display:
			if (x215b699370f39c10.DpiX >= 300f && x215b699370f39c10.DpiY >= 300f)
			{
				x2f7096dac971d6ec.X = (float)x4574ea26106f0edb.xad2dd08366e0faf5(x2f7096dac971d6ec.X, 100.0);
				x2f7096dac971d6ec.Y = (float)x4574ea26106f0edb.xad2dd08366e0faf5(x2f7096dac971d6ec.Y, 100.0);
			}
			else
			{
				x2f7096dac971d6ec.X = (float)x4574ea26106f0edb.xad2dd08366e0faf5(x2f7096dac971d6ec.X, x215b699370f39c10.DpiX);
				x2f7096dac971d6ec.Y = (float)x4574ea26106f0edb.xad2dd08366e0faf5(x2f7096dac971d6ec.Y, x215b699370f39c10.DpiY);
			}
			break;
		case GraphicsUnit.Document:
			x2f7096dac971d6ec.X = (float)x4574ea26106f0edb.xad2dd08366e0faf5(x2f7096dac971d6ec.X, 300.0);
			x2f7096dac971d6ec.Y = (float)x4574ea26106f0edb.xad2dd08366e0faf5(x2f7096dac971d6ec.Y, 300.0);
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("honknpelhpllhpcmfpjmkpanoohnnjonbofojomofndpbokpgnbaenialmpaingbcinbeneckmlccmcdkmjdbiae", 785690002)));
		case GraphicsUnit.World:
		case GraphicsUnit.Point:
			break;
		}
		return new PointF(x2f7096dac971d6ec.X * x215b699370f39c10.PageScale, x2f7096dac971d6ec.Y * x215b699370f39c10.PageScale);
	}

	private static PointF x3f7c1d6a9ea87f70(PointF x2f7096dac971d6ec, Graphics x41347a961b838962)
	{
		PointF pointF = x3b8060e736fc01f0(new PointF(1f, 1f), x41347a961b838962);
		return new PointF(x2f7096dac971d6ec.X / pointF.X, x2f7096dac971d6ec.Y / pointF.Y);
	}

	public override void VisitGlyphs(xcc8c7739d82c63ba glyphs)
	{
		if (glyphs.xc2d4efc42998d87b.x53531537bb3331e6 < 0.1f)
		{
			return;
		}
		xe9278749b95ded0e(glyphs);
		PointF pointF = x3bfe1541371809a8(glyphs);
		if (glyphs.xc2d4efc42998d87b.xda4c813a32b9109b)
		{
			using Matrix matrix = x2f9dbabfc5e5ed3e.xc675a307f114fa9b(glyphs.xa9563a23c5ad1dd4());
			x5655a9d7a2d95414.MultiplyTransform(matrix, MatrixOrder.Prepend);
		}
		if (glyphs.x9b41425268471380 != x26d9ecb4bdf0456d.x45260ad4b94166f2)
		{
			xc020fa2f5133cba8 xd8f1949f8950238a = new xc020fa2f5133cba8(glyphs.x9b41425268471380);
			using Brush brush = x6fb77f4cc018ceba.x495baeffa83ca947(xd8f1949f8950238a);
			using Font font = x425a68c71e891281.x2afffb4ad6317b20(glyphs.xc2d4efc42998d87b, x44c05b9fd5bea2a6);
			x5655a9d7a2d95414.DrawString(glyphs.x3af5c144cbdd1fc1, font, brush, pointF, xa0cc64dbee26ee05);
		}
		if (glyphs.xf09329ffe2ab2695 != x26d9ecb4bdf0456d.x45260ad4b94166f2)
		{
			using GraphicsPath graphicsPath = new GraphicsPath();
			using (Font font2 = x425a68c71e891281.x2afffb4ad6317b20(glyphs.xc2d4efc42998d87b, x44c05b9fd5bea2a6))
			{
				graphicsPath.AddString(glyphs.Text, font2.FontFamily, (int)font2.Style, glyphs.xc2d4efc42998d87b.x53531537bb3331e6, pointF, xa0cc64dbee26ee05);
			}
			x31c19fcb724dfaf5 x94f6590bafb8c2ff = new x31c19fcb724dfaf5(glyphs.xf09329ffe2ab2695);
			using Pen pen = xf7979838286d056a.x81a1520efea3239d(x94f6590bafb8c2ff);
			x5655a9d7a2d95414.DrawPath(pen, graphicsPath);
		}
		xe8496f7fdf4361f2(glyphs);
		if (glyphs.xc2d4efc42998d87b.x29f65b3e7616f6b3.xba2310b1d8e576ad)
		{
			xbbf9a1ead81dd3a1(x6d058fdf61831c39.x73d48b73a1b487ac, "GDI+ doesn't support OpenType fonts with PostScript outlines. '{0}' font has been substituted.", glyphs.xc2d4efc42998d87b.x29f65b3e7616f6b3.x6054c4379c01a50d);
		}
	}

	private PointF x3bfe1541371809a8(xcc8c7739d82c63ba x199c511544621683)
	{
		PointF result = new PointF(x199c511544621683.x72d92bd1aff02e37, x199c511544621683.xe360b1885d8d4a41);
		if (x199c511544621683.xc2d4efc42998d87b.x6054c4379c01a50d == "Cambria Math")
		{
			result.Y = 0f - (x199c511544621683.xc2d4efc42998d87b.x53531537bb3331e6 + x199c511544621683.xc2d4efc42998d87b.xd9ac1486133b5a4e * 2f - x199c511544621683.xc2d4efc42998d87b.x6b0006bdae665f50);
		}
		return result;
	}

	public override void VisitCanvasStart(xb8e7e788f6d59708 canvas)
	{
		xb67059efb664b0fb(canvas);
	}

	public override void VisitCanvasEnd(xb8e7e788f6d59708 canvas)
	{
		xed3b7dc19a70aa4a(canvas);
	}

	public override void VisitPathStart(xab391c46ff9a0a38 path)
	{
		xb67059efb664b0fb(path);
		x336289835451ba12.VisitPathStart(path);
	}

	public override void VisitPathEnd(xab391c46ff9a0a38 path)
	{
		x336289835451ba12.VisitPathEnd(path);
		using (GraphicsPath path2 = x336289835451ba12.x588bacbaa0ed1589)
		{
			if (path.x60465f602599d327 != null)
			{
				using Brush brush = x6fb77f4cc018ceba.x495baeffa83ca947(path.x60465f602599d327);
				x5655a9d7a2d95414.FillPath(brush, path2);
			}
			if (path.x9e5d5f9128c69a8f != null)
			{
				using Pen pen = xf7979838286d056a.x81a1520efea3239d(path.x9e5d5f9128c69a8f);
				x5655a9d7a2d95414.DrawPath(pen, path2);
			}
		}
		xed3b7dc19a70aa4a(path);
	}

	public override void VisitPathFigureStart(x1cab6af0a41b70e2 pathFigure)
	{
		x336289835451ba12.VisitPathFigureStart(pathFigure);
	}

	public override void VisitPathFigureEnd(x1cab6af0a41b70e2 pathFigure)
	{
		x336289835451ba12.VisitPathFigureEnd(pathFigure);
	}

	public override void VisitPolyLineSegment(x60c040f35bb272aa segment)
	{
		x336289835451ba12.VisitPolyLineSegment(segment);
	}

	public override void VisitBezierSegment(x519b1bd0625473ff segment)
	{
		x336289835451ba12.VisitBezierSegment(segment);
	}

	public override void VisitImage(x72c34b8dbaec3734 imageNode)
	{
		try
		{
			x558cc83610335d8b(imageNode);
		}
		catch
		{
			x558cc83610335d8b(x72c34b8dbaec3734.xd18a213c26688d63(imageNode));
		}
	}

	private void x558cc83610335d8b(x72c34b8dbaec3734 xaf3288ddace2264d)
	{
		xf796701adb7bc194.x550781f8db1cf5f2(xaf3288ddace2264d, xaf3288ddace2264d.x819589f292a61f6b);
		using Image image = Image.FromStream(new MemoryStream(xaf3288ddace2264d.xcc18177a965e0313));
		x02df97c06afacbf3 x4d7261a5f7f6e09c = xaf3288ddace2264d.x4d7261a5f7f6e09c;
		ImageAttributes imageAttributes = null;
		if (xaf3288ddace2264d.x1fa52d87045f9b01 != null)
		{
			imageAttributes = new ImageAttributes();
			imageAttributes.SetColorKey(xaf3288ddace2264d.x1fa52d87045f9b01.xdf863a776b239667.xc7656a130b2889c7(), xaf3288ddace2264d.x1fa52d87045f9b01.xb07c4db017102b70.xc7656a130b2889c7());
		}
		GraphicsUnit pageUnit = GraphicsUnit.Pixel;
		RectangleF rectangleF = image.GetBounds(ref pageUnit);
		RectangleF x6ae4612a8469678e = xaf3288ddace2264d.x6ae4612a8469678e;
		PointF[] destPoints = new PointF[3]
		{
			x6ae4612a8469678e.Location,
			new PointF(x6ae4612a8469678e.X + x6ae4612a8469678e.Width, x6ae4612a8469678e.Y),
			new PointF(x6ae4612a8469678e.X, x6ae4612a8469678e.Y + x6ae4612a8469678e.Height)
		};
		if (!x02df97c06afacbf3.x1c140bd1078ddda1(x4d7261a5f7f6e09c))
		{
			rectangleF = x4d7261a5f7f6e09c.xb46e282eca4aff93(rectangleF);
		}
		x5655a9d7a2d95414.DrawImage(image, destPoints, rectangleF, pageUnit, imageAttributes);
	}

	private void xb67059efb664b0fb(x0c06161ccb9341e4 xda5bf54deb817e37)
	{
		xb67059efb664b0fb(xda5bf54deb817e37, x8d3fa2cc884e0af4.x24e2ebfada9bb90d(xda5bf54deb817e37), x8d3fa2cc884e0af4.x2f7838697f3bd577(xda5bf54deb817e37));
	}

	private void xe9278749b95ded0e(xcc8c7739d82c63ba xda5bf54deb817e37)
	{
		xb67059efb664b0fb(xda5bf54deb817e37, xd5b992e9dac79475: true, x8d3fa2cc884e0af4.x2f7838697f3bd577(xda5bf54deb817e37));
	}

	private void xe8496f7fdf4361f2(xcc8c7739d82c63ba xda5bf54deb817e37)
	{
		xed3b7dc19a70aa4a(x983292247ac51229: true, x8d3fa2cc884e0af4.x2f7838697f3bd577(xda5bf54deb817e37));
	}

	private void xb67059efb664b0fb(x0c06161ccb9341e4 xda5bf54deb817e37, bool xd5b992e9dac79475, bool xc99d4eeb5b2737e3)
	{
		if (xd5b992e9dac79475)
		{
			x4c7702a58aee3895.Push(x5655a9d7a2d95414.Transform.Clone());
			x54366fa5f75a02f7 xb38c108353fa4c7d = ((xda5bf54deb817e37.x52dde376accdec7d == null) ? new x54366fa5f75a02f7() : xda5bf54deb817e37.x52dde376accdec7d);
			using Matrix matrix = x2f9dbabfc5e5ed3e.xc675a307f114fa9b(xb38c108353fa4c7d);
			x5655a9d7a2d95414.MultiplyTransform(matrix, MatrixOrder.Prepend);
		}
		if (xc99d4eeb5b2737e3)
		{
			xfb2bff2aedf0953a.Push(x5655a9d7a2d95414.Clip.Clone());
			xda5bf54deb817e37.x0e1bf8242ad10272.Accept(x336289835451ba12);
			using GraphicsPath path = x336289835451ba12.x588bacbaa0ed1589;
			x5655a9d7a2d95414.SetClip(path, CombineMode.Intersect);
		}
	}

	private void xed3b7dc19a70aa4a(x0c06161ccb9341e4 xda5bf54deb817e37)
	{
		xed3b7dc19a70aa4a(x8d3fa2cc884e0af4.x24e2ebfada9bb90d(xda5bf54deb817e37), x8d3fa2cc884e0af4.x2f7838697f3bd577(xda5bf54deb817e37));
	}

	private void xed3b7dc19a70aa4a(bool x983292247ac51229, bool x99ac591ccf7098e5)
	{
		if (x99ac591ccf7098e5)
		{
			x5655a9d7a2d95414.Clip = (Region)xfb2bff2aedf0953a.Pop();
		}
		if (x983292247ac51229)
		{
			x5655a9d7a2d95414.Transform = (Matrix)x4c7702a58aee3895.Pop();
		}
	}

	private void xbbf9a1ead81dd3a1(x6d058fdf61831c39 x9f91de645a9fe01a, string x801e3dc356f2347f, string xf6fec61b61cb58a0)
	{
		xa056586c1f99e199.xbbf9a1ead81dd3a1(x9f91de645a9fe01a, x3959df40367ac8a3.xa460a0b649265441, x801e3dc356f2347f, xf6fec61b61cb58a0);
	}

	static x3a15c7024016ce52()
	{
		xa0cc64dbee26ee05 = new StringFormat(StringFormat.GenericTypographic);
		xa0cc64dbee26ee05.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
	}
}
