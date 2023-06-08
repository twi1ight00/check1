using System.Collections.Generic;

namespace Aspose.Slides.Util;

public static class SlideUtil
{
	public static IShape FindShape(IPresentation pres, string altText)
	{
		int num = 0;
		IShape shape;
		while (true)
		{
			if (num < pres.Masters.Count)
			{
				shape = FindShape(pres.Masters[num], altText);
				if (shape != null)
				{
					break;
				}
				num++;
				continue;
			}
			int num2 = 0;
			IShape shape2;
			while (true)
			{
				if (num2 < pres.Slides.Count)
				{
					shape2 = FindShape(pres.Slides[num2], altText);
					if (shape2 != null)
					{
						break;
					}
					num2++;
					continue;
				}
				return null;
			}
			return shape2;
		}
		return shape;
	}

	public static IShape FindShape(IBaseSlide slide, string altText)
	{
		return FindShape(slide.Shapes, altText);
	}

	private static IShape FindShape(IShapeCollection shapes, string altText)
	{
		int num = 0;
		IShape shape2;
		while (true)
		{
			if (num < shapes.Count)
			{
				IShape shape = shapes[num];
				if (shape.AlternativeText.CompareTo(altText) != 0)
				{
					if (shape is GroupShape)
					{
						shape2 = FindShape(((GroupShape)shape).Shapes, altText);
						if (shape2 != null)
						{
							break;
						}
					}
					num++;
					continue;
				}
				return shape;
			}
			return null;
		}
		return shape2;
	}

	internal static IShape FindShape(IShapeCollection shapes, uint shapeId)
	{
		int num = 0;
		IShape shape2;
		while (true)
		{
			if (num < shapes.Count)
			{
				Shape shape = (Shape)shapes[num];
				if (shape.ShapeId != shapeId)
				{
					if (shape is GroupShape)
					{
						shape2 = FindShape(((IGroupShape)shape).Shapes, shapeId);
						if (shape2 != null)
						{
							break;
						}
					}
					num++;
					continue;
				}
				return shape;
			}
			return null;
		}
		return shape2;
	}

	private static void GetAllTextFrames(IShapeCollection shapes, List<ITextFrame> tframes)
	{
		for (int i = 0; i < shapes.Count; i++)
		{
			if (shapes[i] is IGroupShape)
			{
				GetAllTextFrames(((IGroupShape)shapes[i]).Shapes, tframes);
			}
			else if (shapes[i] is IAutoShape autoShape)
			{
				ITextFrame textFrame = autoShape.TextFrame;
				if (textFrame != null)
				{
					tframes.Add(textFrame);
				}
			}
			else
			{
				if (!(shapes[i] is ITable table))
				{
					continue;
				}
				for (int j = 0; j < table.Rows.Count; j++)
				{
					for (int k = 0; k < table.Columns.Count; k++)
					{
						Cell cell = ((Row)table.Rows[j]).vmethod_3(k);
						if (cell.TextFrame != null)
						{
							tframes.Add(cell.TextFrame);
						}
					}
				}
			}
		}
	}

	public static ITextFrame[] GetAllTextBoxes(IBaseSlide slide)
	{
		List<ITextFrame> list = new List<ITextFrame>();
		GetAllTextFrames(slide.Shapes, list);
		return list.ToArray();
	}

	public static ITextFrame[] GetAllTextFrames(IPresentation pres, bool withMasters)
	{
		List<ITextFrame> list = new List<ITextFrame>();
		if (withMasters)
		{
			for (int i = 0; i < pres.Masters.Count; i++)
			{
				GetAllTextFrames(pres.Masters[i].Shapes, list);
			}
		}
		for (int j = 0; j < pres.Slides.Count; j++)
		{
			GetAllTextFrames(pres.Slides[j].Shapes, list);
		}
		return list.ToArray();
	}
}
