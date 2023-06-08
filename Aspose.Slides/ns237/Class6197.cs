using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using ns224;
using ns234;
using ns235;
using ns264;

namespace ns237;

internal class Class6197 : Class6176
{
	private readonly Class6674 class6674_0;

	private readonly Class6482 class6482_0 = new Class6482();

	private bool bool_0 = true;

	public Class6674 PdfDocument => class6674_0;

	public Class6197(Stream stream)
		: this(stream, new Class6680())
	{
	}

	public Class6197(Stream stream, Class6680 options)
		: this(new Class6674(stream, options))
	{
	}

	public Class6197(Class6674 pdfDoc)
	{
		class6674_0 = pdfDoc;
	}

	public void method_0(Class6204 node)
	{
		try
		{
			node.vmethod_0(this);
		}
		catch (Exception58)
		{
		}
	}

	public void method_1()
	{
		class6674_0.method_0();
	}

	public override void vmethod_0(Class6216 page)
	{
		class6674_0.method_2(page.Size);
	}

	public override void vmethod_1(Class6216 page)
	{
		class6674_0.method_3();
	}

	public override void vmethod_2(Class6213 canvas)
	{
		class6674_0.Page.method_2(canvas);
	}

	public override void vmethod_3(Class6213 canvas)
	{
		class6674_0.Page.method_3(canvas);
	}

	public override void vmethod_4(Class6219 glyphs)
	{
		if ((glyphs.Brush != null && glyphs.Brush.BrushType != 0) || (glyphs.Outline != null && glyphs.Outline.Brush != null && glyphs.Outline.Brush.BrushType != 0))
		{
			Class6217 @class = Class6217.smethod_6(glyphs.Text, glyphs.Font, glyphs.Brush, glyphs.Outline);
			@class.Clip = glyphs.Clip;
			@class.RenderTransform = glyphs.RenderTransform;
			if (@class.RenderTransform == null)
			{
				@class.RenderTransform = new Class6002();
			}
			@class.RenderTransform.method_7(glyphs.Location.X, glyphs.Location.Y, MatrixOrder.Append);
			@class.Hyperlink = glyphs.Hyperlink;
			@class.Id = glyphs.Id;
			@class.vmethod_0(this);
		}
		else
		{
			class6674_0.Page.method_4(glyphs);
		}
	}

	public override void vmethod_5(Class6217 path)
	{
		if (!bool_0)
		{
			return;
		}
		bool_0 = method_2(path);
		if (!bool_0)
		{
			return;
		}
		if (class6674_0.Context.PdfaCompliant)
		{
			Class6003 pen = path.Pen;
			if (pen != null)
			{
				if (pen.Width == 0f)
				{
					path.Pen = null;
				}
				Enum746 brushType = pen.Brush.BrushType;
				if (brushType == Enum746.const_0 && ((Class5997)pen.Brush).Color.A == 0)
				{
					path.Pen = null;
				}
			}
			new Class6191().method_6(path);
		}
		class6674_0.Page.method_5(path);
	}

	public override void vmethod_6(Class6217 path)
	{
		if (bool_0)
		{
			class6674_0.Page.method_6(path);
		}
		bool_0 = true;
	}

	public override void vmethod_7(Class6218 pathFigure)
	{
		if (bool_0)
		{
			class6674_0.Page.method_7(pathFigure);
		}
	}

	public override void vmethod_8(Class6218 pathFigure)
	{
		if (bool_0)
		{
			class6674_0.Page.method_8(pathFigure);
		}
	}

	public override void vmethod_9(Class6223 segment)
	{
		if (bool_0)
		{
			class6674_0.Page.method_9(segment);
		}
	}

	public override void vmethod_10(Class6222 segment)
	{
		if (bool_0)
		{
			class6674_0.Page.method_10(segment);
		}
	}

	public override void vmethod_11(Class6220 image)
	{
		if (class6674_0.Context.PdfaCompliant && smethod_0(image))
		{
			image = new Class6191().method_9(image);
		}
		image = image.method_0(this, class6482_0, scaleForPdf: true, PdfDocument.Context.Options.RenderMetafileAsBitmap);
		if (image != null)
		{
			class6674_0.Page.method_11(image);
		}
	}

	private static bool smethod_0(Class6220 image)
	{
		using Class6150 @class = new Class6150(image.ImageBytes);
		if (!Image.IsAlphaPixelFormat(@class.method_2().PixelFormat))
		{
			return false;
		}
		return @class.method_15(isConvertTo1Bpp: false, isAllowTransparencyToColorHack: false).HasTransparentPixels;
	}

	public override void vmethod_12(Class6211 bookmark)
	{
		class6674_0.Page.method_18(bookmark);
	}

	public override void vmethod_13(Class6221 outlineItem)
	{
		class6674_0.Page.method_19(outlineItem);
	}

	public override void vmethod_14(Class6210 field)
	{
		class6674_0.AcroForm.Add(field, class6674_0.Page);
	}

	public override void vmethod_16(Class6209 field)
	{
		class6674_0.AcroForm.Add(field, class6674_0.Page);
	}

	public override void vmethod_15(Class6207 field)
	{
		class6674_0.AcroForm.Add(field, class6674_0.Page);
	}

	private bool method_2(Class6217 path)
	{
		if (class6674_0.Context.PdfaCompliant && class6674_0.Context.Options.ComplianceOptions.ErrorAction == Enum870.const_1 && path.Pen != null && path.Brush == null)
		{
			Class6003 pen = path.Pen;
			if (pen.Width == 0f)
			{
				return false;
			}
			Enum746 brushType = pen.Brush.BrushType;
			if (brushType == Enum746.const_0 && ((Class5997)pen.Brush).Color.A == 0)
			{
				return false;
			}
		}
		return true;
	}
}
