using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Aspose;
using x38a89dee67fc7a16;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using x85732faf56f7825d;

namespace xf9a9481c3f63a419;

[JavaManual("Manual porting by design.")]
internal class x6fb77f4cc018ceba
{
	private x6fb77f4cc018ceba()
	{
	}

	public static Brush x495baeffa83ca947(x845d6a068e0b03c5 xd8f1949f8950238a)
	{
		return xd8f1949f8950238a.x4bc21f84846f912d switch
		{
			x0b257a9fb413b6c3.xb8751dec55f64252 => xf450254daa20a6cc((xc020fa2f5133cba8)xd8f1949f8950238a), 
			x0b257a9fb413b6c3.x1b1f1b9a5f55b7ee => xc1aa3923590e6ae3((x5bdb4ba66c23277c)xd8f1949f8950238a), 
			x0b257a9fb413b6c3.x7b6a6d281546db99 => xa903f8f328b4c169((x5e9754e56a4f759f)xd8f1949f8950238a), 
			x0b257a9fb413b6c3.x37b6ad6b01d0c641 => xb9d757f2231cc2a8((x5f55370cc09dd787)xd8f1949f8950238a), 
			x0b257a9fb413b6c3.x73039d25e580af15 => x7f3743a5bb962d40((xa587dcb499c221cc)xd8f1949f8950238a), 
			_ => throw new InvalidOperationException("Unknown brush type."), 
		};
	}

	private static Brush x7f3743a5bb962d40(xa587dcb499c221cc xd8f1949f8950238a)
	{
		x5250236f9cf73045 x5250236f9cf = new x5250236f9cf73045();
		xd8f1949f8950238a.x632b457a1248cdb1.Accept(x5250236f9cf);
		using GraphicsPath path = x5250236f9cf.x588bacbaa0ed1589;
		PathGradientBrush pathGradientBrush = new PathGradientBrush(path);
		pathGradientBrush.CenterPoint = xd8f1949f8950238a.xf9d280c0b1a71761;
		if (xd8f1949f8950238a.xcd610bdad90237c0 != null)
		{
			pathGradientBrush.CenterColor = xd8f1949f8950238a.xcd610bdad90237c0.xc7656a130b2889c7();
		}
		pathGradientBrush.MultiplyTransform(x2f9dbabfc5e5ed3e.xc675a307f114fa9b(xd8f1949f8950238a.xaccac17571a8d9fa));
		pathGradientBrush.WrapMode = xd8f1949f8950238a.x349ff0df1e641b4e;
		if (xd8f1949f8950238a.xcc7b76ceb682651c != null)
		{
			pathGradientBrush.InterpolationColors = xc4f217c28cbd991f(xd8f1949f8950238a, x2cc1096fbe0e689e: true);
		}
		xd68622d922cb79cc(xd8f1949f8950238a, pathGradientBrush);
		return pathGradientBrush;
	}

	private static void xd68622d922cb79cc(xa587dcb499c221cc xd8f1949f8950238a, PathGradientBrush x2afd73f06f320bb8)
	{
		if (xd8f1949f8950238a.xbd123a0db502b2b7 != null)
		{
			Color[] array = new Color[xd8f1949f8950238a.xbd123a0db502b2b7.Length];
			for (int i = 0; i < xd8f1949f8950238a.xbd123a0db502b2b7.Length; i++)
			{
				ref Color reference = ref array[i];
				reference = xd8f1949f8950238a.xbd123a0db502b2b7[i].xc7656a130b2889c7();
			}
			x2afd73f06f320bb8.SurroundColors = array;
		}
	}

	private static Brush xb9d757f2231cc2a8(x5f55370cc09dd787 xd8f1949f8950238a)
	{
		LinearGradientBrush linearGradientBrush = new LinearGradientBrush(xd8f1949f8950238a.x404d528fe2f10961, xd8f1949f8950238a.x7d2dc175c2f289c5.xc7656a130b2889c7(), xd8f1949f8950238a.xf3874816968aabd7.xc7656a130b2889c7(), 0f, xd8f1949f8950238a.xbeaac435f753b9e3);
		linearGradientBrush.MultiplyTransform(x2f9dbabfc5e5ed3e.xc675a307f114fa9b(xd8f1949f8950238a.xaccac17571a8d9fa));
		linearGradientBrush.WrapMode = xd8f1949f8950238a.x349ff0df1e641b4e;
		if (xd8f1949f8950238a.xa086f258e4907f49 != null)
		{
			linearGradientBrush.Blend = xdf6fbfe00be729e6(xd8f1949f8950238a);
		}
		if (xd8f1949f8950238a.xcc7b76ceb682651c != null)
		{
			linearGradientBrush.InterpolationColors = xc4f217c28cbd991f(xd8f1949f8950238a, x2cc1096fbe0e689e: false);
		}
		return linearGradientBrush;
	}

	private static ColorBlend xc4f217c28cbd991f(xf022bb98711420db xd8f1949f8950238a, bool x2cc1096fbe0e689e)
	{
		Color[] array = new Color[xd8f1949f8950238a.xcc7b76ceb682651c.Length];
		float[] array2 = new float[xd8f1949f8950238a.xcc7b76ceb682651c.Length];
		for (int i = 0; i < xd8f1949f8950238a.xcc7b76ceb682651c.Length; i++)
		{
			ref Color reference = ref array[i];
			reference = xd8f1949f8950238a.xcc7b76ceb682651c[i].x9b41425268471380.xc7656a130b2889c7();
			array2[i] = xd8f1949f8950238a.xcc7b76ceb682651c[i].xbe1e23e7d5b43370;
		}
		ColorBlend colorBlend = new ColorBlend();
		colorBlend.Colors = array;
		colorBlend.Positions = array2;
		return colorBlend;
	}

	private static Blend xdf6fbfe00be729e6(xf022bb98711420db xd8f1949f8950238a)
	{
		Blend blend = new Blend();
		blend.Factors = xd8f1949f8950238a.xa086f258e4907f49;
		blend.Positions = xd8f1949f8950238a.x76dec2960c4aa9cc;
		return blend;
	}

	private static Brush xa903f8f328b4c169(x5e9754e56a4f759f xd8f1949f8950238a)
	{
		ImageAttributes imageAttributes = new ImageAttributes();
		x83b40174091609cc(xd8f1949f8950238a, imageAttributes);
		xd0780bfc7027baa6(xd8f1949f8950238a, imageAttributes);
		Image image = Image.FromStream(new MemoryStream(xd8f1949f8950238a.xcc18177a965e0313));
		RectangleF rectangleF = x65e26cb08c95839d(xd8f1949f8950238a, image);
		TextureBrush textureBrush;
		try
		{
			textureBrush = new TextureBrush(image, rectangleF, imageAttributes);
		}
		catch (Exception)
		{
			textureBrush = x121bb8d08bced493(image, rectangleF, imageAttributes);
		}
		textureBrush.Transform = x2f9dbabfc5e5ed3e.xc675a307f114fa9b(xd8f1949f8950238a.xaccac17571a8d9fa);
		textureBrush.WrapMode = xd8f1949f8950238a.x349ff0df1e641b4e;
		return textureBrush;
	}

	private static TextureBrush x121bb8d08bced493(Image xe058541ca798c059, RectangleF x9b41b285ab728c73, ImageAttributes xdd5fd51358b7d5b6)
	{
		Bitmap bitmap = new Bitmap(xe058541ca798c059.Width, xe058541ca798c059.Height);
		bitmap.SetResolution(xe058541ca798c059.HorizontalResolution, xe058541ca798c059.VerticalResolution);
		using (Graphics graphics = Graphics.FromImage(bitmap))
		{
			graphics.DrawImage(xe058541ca798c059, 0, 0, xe058541ca798c059.Width, xe058541ca798c059.Height);
		}
		return new TextureBrush(bitmap, x9b41b285ab728c73, xdd5fd51358b7d5b6);
	}

	private static void x83b40174091609cc(x5e9754e56a4f759f xd8f1949f8950238a, ImageAttributes xdd5fd51358b7d5b6)
	{
		if (xd8f1949f8950238a.xe25bcbc1e660bc36 != null)
		{
			ColorMap[] array = new ColorMap[xd8f1949f8950238a.xe25bcbc1e660bc36.Length / 2];
			for (int i = 0; i < array.Length; i++)
			{
				ColorMap colorMap = new ColorMap();
				colorMap.OldColor = xd8f1949f8950238a.xe25bcbc1e660bc36[i * 2].xc7656a130b2889c7();
				colorMap.NewColor = xd8f1949f8950238a.xe25bcbc1e660bc36[i * 2 + 1].xc7656a130b2889c7();
				array[i] = colorMap;
			}
			xdd5fd51358b7d5b6.SetRemapTable(array);
		}
	}

	private static void xd0780bfc7027baa6(x5e9754e56a4f759f xd8f1949f8950238a, ImageAttributes xdd5fd51358b7d5b6)
	{
		if (xd8f1949f8950238a.xd163a712710650fc == float.MinValue)
		{
			return;
		}
		ColorMatrix colorMatrix = new ColorMatrix();
		xfe2ff3c162b47c70 xfe2ff3c162b47c = xdd1b8f14cc8ba86d.x22bfb60fc9ca9282(xd8f1949f8950238a.xcc18177a965e0313);
		if (xfe2ff3c162b47c == xfe2ff3c162b47c70.x8e716ec1cb703e9f)
		{
			for (int i = 0; i < 4; i++)
			{
				colorMatrix[i, i] = xd8f1949f8950238a.xd163a712710650fc;
			}
		}
		else
		{
			colorMatrix[3, 3] = xd8f1949f8950238a.xd163a712710650fc;
		}
		xdd5fd51358b7d5b6.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
	}

	private static RectangleF x65e26cb08c95839d(x5e9754e56a4f759f xd8f1949f8950238a, Image xe058541ca798c059)
	{
		if (!(xd8f1949f8950238a.x42eb8f4390d1e7ba == RectangleF.Empty))
		{
			return xd8f1949f8950238a.x42eb8f4390d1e7ba;
		}
		return new RectangleF(0f, 0f, xe058541ca798c059.Width, xe058541ca798c059.Height);
	}

	private static Brush xc1aa3923590e6ae3(x5bdb4ba66c23277c xd8f1949f8950238a)
	{
		return new HatchBrush(xd8f1949f8950238a.xaf9d27b89edd7fea, xd8f1949f8950238a.x8fdbd80e8da6b0e6.xc7656a130b2889c7(), xd8f1949f8950238a.x83729c7ebf48ae24.xc7656a130b2889c7());
	}

	private static Brush xf450254daa20a6cc(xc020fa2f5133cba8 xd8f1949f8950238a)
	{
		return new SolidBrush(xd8f1949f8950238a.x9b41425268471380.xc7656a130b2889c7());
	}

	public static x5e9754e56a4f759f xa903f8f328b4c169(xa587dcb499c221cc xd8f1949f8950238a)
	{
		using PathGradientBrush pathGradientBrush = (PathGradientBrush)x495baeffa83ca947(xd8f1949f8950238a);
		RectangleF rectangle = pathGradientBrush.Rectangle;
		using Bitmap bitmap = new Bitmap(100, 100);
		bitmap.SetResolution(96f, 96f);
		x54366fa5f75a02f7 x54366fa5f75a02f = x54366fa5f75a02f7.x6698fc0971e66ffb(rectangle, new RectangleF(0f, 0f, bitmap.Width, bitmap.Height));
		using (Graphics graphics = Graphics.FromImage(bitmap))
		{
			graphics.PageUnit = GraphicsUnit.Pixel;
			graphics.Transform = x2f9dbabfc5e5ed3e.xc675a307f114fa9b(x54366fa5f75a02f);
			graphics.FillRectangle(pathGradientBrush, rectangle);
		}
		byte[] imageBytes;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			bitmap.Save(memoryStream, ImageFormat.Png);
			imageBytes = x0d299f323d241756.xa0aed4cd3b3d5d92(memoryStream);
		}
		x5e9754e56a4f759f x5e9754e56a4f759f = new x5e9754e56a4f759f(imageBytes);
		x5e9754e56a4f759f.xaccac17571a8d9fa = x54366fa5f75a02f.x437786253537a519();
		return x5e9754e56a4f759f;
	}
}
