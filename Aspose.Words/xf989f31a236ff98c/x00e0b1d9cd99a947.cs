using System.Drawing;
using Aspose;
using Aspose.Words;
using Aspose.Words.Drawing;
using x1c8faa688b1f0b0c;
using x28925c9b27b37a46;
using x3d94286fe72124a8;
using x5794c252ba25e723;
using x59d6a4fc5007b7a4;
using x6c95d9cf46ff5f25;
using x85732faf56f7825d;
using xf9a9481c3f63a419;

namespace xf989f31a236ff98c;

internal class x00e0b1d9cd99a947
{
	private readonly ShapeBase x317be79405176667;

	private readonly PointF x7deed1c9a0187a72 = PointF.Empty;

	private readonly bool x912ee37509b04eb8;

	private readonly xcca9b9b2025d882d xd2c63cd3bf88860d;

	internal x00e0b1d9cd99a947(ShapeBase shape, PointF newResolution, bool hasChildStories, xcca9b9b2025d882d sizeParams)
	{
		x317be79405176667 = shape;
		x7deed1c9a0187a72 = newResolution;
		x912ee37509b04eb8 = hasChildStories;
		xd2c63cd3bf88860d = sizeParams;
	}

	internal x3cd5d648729cd9b6 x063e61b390371e67()
	{
		return x063e61b390371e67(x317be79405176667, x7deed1c9a0187a72, x912ee37509b04eb8, xd2c63cd3bf88860d);
	}

	[JavaConvertCheckedExceptions]
	internal static x3cd5d648729cd9b6 x063e61b390371e67(ShapeBase x5770cdefd8931aa9, PointF xf73214c4b02b3840, bool x57772795c05e364c, xcca9b9b2025d882d x17af85f5c27e974d)
	{
		int width = x4574ea26106f0edb.x4bec21b1de9d1b5b(x17af85f5c27e974d.xdc1bf80853046136, xf73214c4b02b3840.X);
		int height = x4574ea26106f0edb.x4bec21b1de9d1b5b(x17af85f5c27e974d.xb0f146032f47c24e, xf73214c4b02b3840.Y);
		xb8e7e788f6d59708 xb8e7e788f6d = xf51bb9981f8d7796(x5770cdefd8931aa9, x57772795c05e364c, x17af85f5c27e974d);
		x3cd5d648729cd9b6 x3cd5d648729cd9b = new x3cd5d648729cd9b6(width, height, xf73214c4b02b3840.X, xf73214c4b02b3840.Y);
		using x3dacf8cbb5aec9f0 x3dacf8cbb5aec9f = new x3dacf8cbb5aec9f0(x3cd5d648729cd9b);
		x3dacf8cbb5aec9f.x24670816c6fb8451();
		x3a15c7024016ce52 x3a15c7024016ce = new x3a15c7024016ce52();
		double num;
		double num2;
		if (x5770cdefd8931aa9.WrapType == WrapType.Inline)
		{
			num = x17af85f5c27e974d.xb2d2dfd6ea1a3481;
			num2 = x17af85f5c27e974d.xd797697fceef84f3;
		}
		else
		{
			num = x17af85f5c27e974d.xc8ade15cdad91446;
			num2 = x17af85f5c27e974d.xeeb8cbdf228a17cc;
		}
		if (num != 0.0 || num2 != 0.0)
		{
			if (xb8e7e788f6d.x52dde376accdec7d == null)
			{
				xb8e7e788f6d.x52dde376accdec7d = new x54366fa5f75a02f7();
			}
			xb8e7e788f6d.x52dde376accdec7d.xce92de628aa023cf((float)num, (float)num2);
		}
		x3a15c7024016ce.xe406325e56f74b46(xb8e7e788f6d, x3dacf8cbb5aec9f.x0c16bcbc7d053d08());
		return x3cd5d648729cd9b;
	}

	private static xb8e7e788f6d59708 xf51bb9981f8d7796(ShapeBase x5770cdefd8931aa9, bool x57772795c05e364c, xcca9b9b2025d882d x17af85f5c27e974d)
	{
		if (x57772795c05e364c)
		{
			Document document = new Document();
			ShapeBase shapeBase = (ShapeBase)document.ImportNode(x5770cdefd8931aa9, isImportChildren: true, ImportFormatMode.KeepSourceFormatting);
			shapeBase.WrapType = WrapType.None;
			shapeBase.RelativeHorizontalPosition = RelativeHorizontalPosition.Page;
			shapeBase.HorizontalAlignment = HorizontalAlignment.None;
			shapeBase.Left = x17af85f5c27e974d.xc8ade15cdad91446;
			shapeBase.RelativeVerticalPosition = RelativeVerticalPosition.Page;
			shapeBase.VerticalAlignment = VerticalAlignment.None;
			shapeBase.Top = x17af85f5c27e974d.xeeb8cbdf228a17cc;
			shapeBase.x96e55b5d052d1279 = false;
			shapeBase.xeedad81aaed42a76.x96e55b5d052d1279 = x9b28b1f7f0cc963f.x12642456c7bf0815;
			document.FirstSection.Body.FirstParagraph.AppendChild(shapeBase);
			xcde671c53995c411 xcde671c53995c = document.xcde671c53995c411;
			x4fdf549af9de6b97 xda5bf54deb817e = xcde671c53995c.x64cf48da0043a586(shapeBase);
			xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
			xb8e7e788f6d.xd6b6ed77479ef68c(xda5bf54deb817e);
			return xb8e7e788f6d;
		}
		Document document2 = x5770cdefd8931aa9.x357c90b33d6bb8e6();
		x54b98d0096d7251a warningCallback = new xfadb51c1fcf6d0ba(document2.xdeb77ea37ad74c56);
		xc958d22004253850 xc958d22004253850 = new xc958d22004253850(null, warningCallback, document2.x0b16d2d2ced2de05, document2.xdeb77ea37ad74c56.x4e89abab59063fe9);
		return xc958d22004253850.xe406325e56f74b46(new x7721ad963b03c6eb(x5770cdefd8931aa9));
	}
}
