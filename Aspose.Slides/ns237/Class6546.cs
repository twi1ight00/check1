using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using ns224;
using ns233;
using ns235;
using ns265;

namespace ns237;

internal class Class6546 : Class6511
{
	private readonly float float_0;

	private readonly float float_1;

	private readonly Class6514 class6514_0;

	private readonly Class6196 class6196_0;

	private readonly Class6684 class6684_0;

	private readonly Class6677 class6677_0;

	private Class6682 class6682_0;

	public float Width => float_0;

	public float Height => float_1;

	private Class6682 AnnotationRefs
	{
		get
		{
			if (class6682_0 == null)
			{
				class6682_0 = new Class6682();
			}
			return class6682_0;
		}
	}

	public Class6546(Class6672 context, float width, float height)
		: base(context)
	{
		float_0 = width;
		float_1 = height;
		class6514_0 = new Class6514(class6672_0);
		class6196_0 = new Class6196(class6514_0);
		class6684_0 = new Class6684(class6672_0, class6514_0);
		class6677_0 = new Class6677(class6672_0, class6672_0.Resources, class6514_0);
		class6672_0.GraphicStateWriter.ResetGraphicState();
		class6672_0.GraphicStateWriter.method_2(new Class6002(1f, 0f, 0f, -1f, 0f, float_1), class6514_0);
		Class6673 dest = method_20(PointF.Empty);
		class6672_0.Annotations.method_2(base.Context.Pages.Count + 1, dest);
	}

	public void method_1()
	{
		class6684_0.method_3();
	}

	public void method_2(Class6213 canvas)
	{
		class6684_0.method_3();
		method_15(canvas, isForce: false);
	}

	public void method_3(Class6213 canvas)
	{
		method_16(canvas, isForce: false);
		if (canvas.Hyperlink != null)
		{
			method_17(canvas.Hyperlink);
		}
	}

	public void method_4(Class6219 glyphs)
	{
		method_15(glyphs, isForce: false);
		class6684_0.method_0(glyphs);
		if (glyphs.Hyperlink != null)
		{
			method_17(glyphs.Hyperlink);
		}
		method_16(glyphs, isForce: false);
	}

	public void method_5(Class6217 path)
	{
		class6684_0.method_3();
		if (path.Pen != null && !base.Context.SupportedFeatures.method_0(path.Pen, out var error) && base.Context.Options.ErrorHandler != null && !base.Context.Options.ErrorHandler.imethod_0(error))
		{
			throw error;
		}
		method_15(path, Class6224.smethod_3(path));
		if (path.Brush != null)
		{
			class6677_0.method_1(path.Brush, isStroking: false);
		}
		if (path.Pen == null)
		{
			return;
		}
		try
		{
			class6677_0.method_0(path.Pen);
		}
		catch (Exception59 error2)
		{
			if (base.Context.Options.ErrorHandler == null || !base.Context.Options.ErrorHandler.imethod_0(error2))
			{
				throw;
			}
		}
	}

	public void method_6(Class6217 path)
	{
		class6514_0.method_4(smethod_0(path));
		if (path.Hyperlink != null)
		{
			method_17(path.Hyperlink);
		}
		method_16(path, Class6224.smethod_3(path));
	}

	private static string smethod_0(Class6217 path)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (path.Brush != null && path.Pen != null)
		{
			stringBuilder.Append(path.IsLastFigureClosed ? "b" : "B");
			if (path.FillMode == FillMode.Alternate)
			{
				stringBuilder.Append("*");
			}
		}
		else if (path.Brush != null)
		{
			stringBuilder.Append("f");
			if (path.FillMode == FillMode.Alternate)
			{
				stringBuilder.Append("*");
			}
		}
		else if (path.Pen != null)
		{
			stringBuilder.Append(path.IsLastFigureClosed ? "s" : "S");
		}
		return stringBuilder.ToString();
	}

	public void method_7(Class6218 pathFigure)
	{
		class6196_0.vmethod_7(pathFigure);
	}

	public void method_8(Class6218 pathFigure)
	{
		class6196_0.vmethod_8(pathFigure);
	}

	public void method_9(Class6223 segment)
	{
		class6196_0.vmethod_9(segment);
	}

	public void method_10(Class6222 segment)
	{
		class6196_0.vmethod_10(segment);
	}

	public void method_11(Class6220 imageNode)
	{
		class6684_0.method_3();
		RectangleF rectangleF = imageNode.Bounds;
		if (!Class6145.smethod_0(imageNode.Crop))
		{
			rectangleF = imageNode.Crop.method_2(rectangleF);
		}
		class6677_0.method_3(imageNode.ImageBytes, imageNode.Crop, rectangleF, imageNode.ChromaKey, isReverseRows: true);
		if (imageNode.Hyperlink != null)
		{
			method_17(imageNode.Hyperlink);
		}
	}

	internal void method_12(Class6535 field)
	{
		AnnotationRefs.Add(field.IndirectReference);
	}

	internal void method_13(Class6532 signatureAnnotation)
	{
		AnnotationRefs.Add(signatureAnnotation.IndirectReference);
	}

	public override void vmethod_0(Class6679 writer)
	{
		method_14(writer);
		class6514_0.vmethod_0(writer);
	}

	private void method_14(Class6679 writer)
	{
		writer.method_29(this);
		writer.method_6();
		writer.method_8("/Type", "/Page");
		writer.method_8("/Parent", class6672_0.Pages.IndirectReference);
		writer.method_8("/Contents", class6514_0.IndirectReference);
		writer.method_16("/MediaBox", new RectangleF(0f, 0f, float_0, float_1));
		if (!class6672_0.PdfaCompliant)
		{
			writer.method_8("/Group", "<</Type/Group/S/Transparency/CS/DeviceRGB>>");
		}
		if (class6682_0 != null)
		{
			writer.Write("/Annots");
			class6682_0.method_0(writer);
		}
		writer.method_7();
		writer.method_30();
	}

	private void method_15(Interface261 node, bool isForce)
	{
		if (isForce || Class6224.smethod_0(node))
		{
			class6684_0.method_3();
			class6672_0.GraphicStateWriter.method_0(class6514_0);
			if (Class6224.smethod_1(node))
			{
				class6672_0.GraphicStateWriter.method_2(node.RenderTransform, class6514_0);
			}
			if (Class6224.smethod_2(node))
			{
				Class6196 visitor = new Class6196(class6514_0);
				node.Clip.vmethod_0(visitor);
				class6514_0.method_4("W n");
			}
		}
	}

	private void method_16(Interface261 node, bool isForce)
	{
		if (isForce || Class6224.smethod_0(node))
		{
			class6684_0.method_3();
			class6672_0.GraphicStateWriter.method_1(class6514_0);
		}
	}

	private void method_17(Class6270 hyperlink)
	{
		Class6539 @class = new Class6539(class6672_0, class6672_0.GraphicStateWriter.method_14(hyperlink.ActiveRect), Class6504.smethod_0(hyperlink));
		AnnotationRefs.Add(@class.IndirectReference);
		class6672_0.Annotations.method_0(@class);
	}

	public void method_18(Class6211 bookmark)
	{
		Class6673 dest = method_20(bookmark.Origin);
		class6672_0.Annotations.method_1(bookmark.Name, dest);
		int bookmarksOutlineLevel = class6672_0.Options.BookmarksOutlineLevel;
		if (bookmarksOutlineLevel > 0 && !bookmark.IsHiddenFromOutline)
		{
			class6672_0.Outline.method_0(bookmark.Name, bookmarksOutlineLevel, dest);
		}
	}

	public void method_19(Class6221 outlineItem)
	{
		Class6673 dest = method_20(outlineItem.Origin);
		int headingsOutlineLevels = class6672_0.Options.HeadingsOutlineLevels;
		if (outlineItem.Level < headingsOutlineLevels)
		{
			class6672_0.Outline.method_0(outlineItem.Title, outlineItem.Level, dest);
		}
	}

	private Class6673 method_20(PointF origin)
	{
		return new Class6673(base.IndirectReference, class6672_0.GraphicStateWriter.method_15(origin));
	}
}
