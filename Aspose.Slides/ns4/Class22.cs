using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Theme;
using ns16;

namespace ns4;

internal static class Class22
{
	public static ColorFormat smethod_0(IPresentationComponent parent)
	{
		if (parent == null)
		{
			return null;
		}
		if (!(parent is TextFrame) && !(parent is Paragraph) && !(parent is Portion) && !(parent is Field))
		{
			if (parent is Cell)
			{
				return smethod_1((Cell)parent);
			}
			if (parent is GeometryShape)
			{
				return smethod_2((IGeometryShape)parent);
			}
			if (parent is SmartArtShape)
			{
				return smethod_2((IGeometryShape)parent);
			}
			if (parent is IFormattedTextContainer)
			{
				return null;
			}
			if (!(parent is IChartComponent) && !(parent is FormatScheme) && !(parent is MasterSlide) && !(parent is Presentation) && !(parent is Control) && !(parent is OleObjectFrame) && !(parent is GroupShape))
			{
				if (parent is SmartArt)
				{
					return null;
				}
				if (parent is Table)
				{
					return null;
				}
				if (parent is Background)
				{
					return smethod_3((Background)parent);
				}
				return null;
			}
			return null;
		}
		TextFrame textFrame;
		if (parent is TextFrame)
		{
			textFrame = (TextFrame)parent;
		}
		else
		{
			Paragraph paragraph;
			if (parent is Paragraph)
			{
				paragraph = (Paragraph)parent;
			}
			else
			{
				Portion portion = null;
				if (parent is Portion)
				{
					portion = (Portion)parent;
				}
				else if (parent is Field)
				{
					portion = ((Field)parent).Parent;
				}
				paragraph = portion.paragraph_0;
			}
			textFrame = null;
			if (paragraph != null)
			{
				ParagraphCollection paragraphCollection_ = paragraph.paragraphCollection_0;
				if (paragraphCollection_ != null)
				{
					textFrame = paragraphCollection_.Parent;
				}
			}
		}
		if (textFrame == null)
		{
			return null;
		}
		if (textFrame.islideComponent_0 is AutoShape)
		{
			return smethod_2((AutoShape)textFrame.islideComponent_0);
		}
		if (textFrame.islideComponent_0 is Cell)
		{
			return smethod_1((Cell)textFrame.islideComponent_0);
		}
		if (textFrame.islideComponent_0 is IOverridableText)
		{
			return null;
		}
		return null;
	}

	private static ColorFormat smethod_1(Cell cell)
	{
		if (cell.FillStyleCachePVITemp.Source != Enum273.const_2)
		{
			return null;
		}
		return (ColorFormat)cell.FillStyleCachePVITemp.StyleColor;
	}

	private static ColorFormat smethod_2(IGeometryShape geometryShape)
	{
		if (geometryShape.ShapeStyle == null)
		{
			return null;
		}
		return (ColorFormat)geometryShape.ShapeStyle.FillColor;
	}

	private static ColorFormat smethod_3(Background background)
	{
		if (background.Type != 0)
		{
			return null;
		}
		return (ColorFormat)background.StyleColor;
	}
}
