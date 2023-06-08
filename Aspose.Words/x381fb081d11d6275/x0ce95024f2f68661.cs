using System.Drawing;
using Aspose.Words;
using Aspose.Words.Drawing;
using xce0136f05681c5e9;
using xf989f31a236ff98c;

namespace x381fb081d11d6275;

internal class x0ce95024f2f68661
{
	private readonly x611b52a649966359 x38c4187576184787;

	private readonly x05df33911093beb0 x230c333abfdbfccd;

	private readonly xcd1c64d43058619d xa93fd26e0d062c89;

	private xcd1c64d43058619d x98969efe002e6c55;

	private readonly x8aa64ac02744cab2 x2e332fe05d532827;

	private Paragraph x85a3413b4fcfe2d8;

	internal x0ce95024f2f68661(x611b52a649966359 coreWriter, x05df33911093beb0 hyperlinkWriter, xcd1c64d43058619d saveImageOptions, x8aa64ac02744cab2 imageResourceWriter)
	{
		x38c4187576184787 = coreWriter;
		x230c333abfdbfccd = hyperlinkWriter;
		xa93fd26e0d062c89 = saveImageOptions;
		x2e332fe05d532827 = imageResourceWriter;
	}

	internal void x1a2622a1866b8f97(ShapeBase x8739b0dd3627f37e, Shape x5770cdefd8931aa9)
	{
		bool flag = x8739b0dd3627f37e.xbfc952aeef7fd0d5 && x230c333abfdbfccd.x4e44079093b28b81(x8739b0dd3627f37e.HRef, x8739b0dd3627f37e.Target, xe389b456117f37b2: false);
		if (x8739b0dd3627f37e.WrapType == WrapType.None)
		{
			Paragraph paragraph = (Paragraph)x8739b0dd3627f37e.xdfa6ecc6f742f086;
			if (paragraph.Runs.Count == 0 && (x85a3413b4fcfe2d8 == null || x85a3413b4fcfe2d8 != paragraph))
			{
				x38c4187576184787.x7b60b74ac6a53b3f(paragraph.ParagraphFormat.Style.Font, xf544375d86767c28: false);
				x85a3413b4fcfe2d8 = paragraph;
			}
		}
		ShapeBase shapeBase = x8739b0dd3627f37e;
		Shape x5770cdefd8931aa10 = x5770cdefd8931aa9;
		if (x5770cdefd8931aa9 != null && x202941c978357b4f.x4d1876e41eb40120(x5770cdefd8931aa9))
		{
			ImageData imageData = x5770cdefd8931aa9.ImageData;
			if (imageData != null)
			{
				x8739b0dd3627f37e = (x5770cdefd8931aa9 = (Shape)x5770cdefd8931aa9.Clone(isCloneChildren: false));
				x5770cdefd8931aa9.ImageData.Borders.ClearFormatting();
				x5770cdefd8931aa9.Stroke.On = false;
			}
		}
		SizeF sizeInPoints = x8739b0dd3627f37e.SizeInPoints;
		string xafe2f3653ee64ebc = ((x5770cdefd8931aa9 != null) ? x2e332fe05d532827.x69e367df6bceb25b(shapeBase, x5770cdefd8931aa9, xa93fd26e0d062c89, sizeInPoints) : x2e332fe05d532827.xfb1931cb210293d9(shapeBase, x8739b0dd3627f37e, xa93fd26e0d062c89, sizeInPoints));
		x38c4187576184787.x27335b788ad093c5(x5770cdefd8931aa10, shapeBase, flag, x2e332fe05d532827.xf5e402c3e2321905(xafe2f3653ee64ebc), x2e332fe05d532827.xdbc86bd624bac965.xdc1bf80853046136, x2e332fe05d532827.xdbc86bd624bac965.xb0f146032f47c24e, x8739b0dd3627f37e.AlternativeText);
		if (flag)
		{
			x230c333abfdbfccd.x1210e8a0b401d5a2();
		}
	}

	internal string x4831706ba6f80d0b(Shape x8085693583c13e4f, double x5d7e66e9c97b3a9a)
	{
		float num = (float)x5d7e66e9c97b3a9a;
		SizeF sizeInPoints = x8085693583c13e4f.SizeInPoints;
		float num2 = num / sizeInPoints.Height;
		float width = sizeInPoints.Width * num2;
		SizeF x0ceec69a97f = new SizeF(width, num);
		if (x98969efe002e6c55 == null)
		{
			x98969efe002e6c55 = xa93fd26e0d062c89.x8b61531c8ea35b85();
			x98969efe002e6c55.x9411afdd2481f8e3 = true;
		}
		string xafe2f3653ee64ebc = x2e332fe05d532827.x69e367df6bceb25b(x8085693583c13e4f, x8085693583c13e4f, x98969efe002e6c55, x0ceec69a97f);
		return x2e332fe05d532827.xf5e402c3e2321905(xafe2f3653ee64ebc);
	}
}
