using System.Collections.Generic;
using System.Drawing;
using ns235;
using ns256;
using ns259;

namespace ns255;

internal class Class6366
{
	private readonly List<Class6409> list_0 = new List<Class6409>();

	private Class6372 class6372_0 = new Class6372();

	private string string_0;

	public Class6372 Guides => class6372_0;

	public string PresetName
	{
		get
		{
			if (string_0 == null)
			{
				return string.Empty;
			}
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	internal List<Class6409> Paths => list_0;

	internal Class6217 method_0(Interface296 context)
	{
		Guides.method_2(context.ShapeWidth, context.ShapeHeight);
		Class6217 @class = new Class6217();
		foreach (Class6409 path in Paths)
		{
			path.method_0(@class, context);
		}
		if (@class.Count == 0)
		{
			return null;
		}
		return @class;
	}

	internal void method_1(Class6409 path)
	{
		if (path != null)
		{
			list_0.Add(path);
		}
	}

	internal Class6213 method_2(Interface296 context)
	{
		Guides.method_2(context.ShapeWidth, context.ShapeHeight);
		Class6213 @class = new Class6213();
		foreach (Class6409 path in Paths)
		{
			Class6217 class2 = path.method_2(context);
			if (class2 != null)
			{
				@class.Add(class2);
			}
		}
		method_3(@class, context);
		return @class;
	}

	private void method_3(Class6213 canvas, Interface296 context)
	{
		if (!context.IsPictureRenderingMode || PresetName != "rect" || canvas.Count != 1)
		{
			return;
		}
		Class6217 @class = (Class6217)canvas[0];
		if (@class.Count == 1)
		{
			Class6218 class2 = (Class6218)@class[0];
			if (class2.Count == 3)
			{
				float num = @class.Pen.Width / 2f;
				smethod_0(class2, 0, 0f - num, 0f - num, num, 0f - num);
				smethod_0(class2, 1, num, 0f - num, num, num);
				smethod_0(class2, 2, num, num, 0f - num, num);
			}
		}
	}

	private static void smethod_0(Class6218 figure, int figureIndex, float dx1, float dy1, float dx2, float dy2)
	{
		if (figure[figureIndex] is Class6223 @class)
		{
			smethod_1(@class.Points, 0, dx1, dy1);
			smethod_1(@class.Points, 1, dx2, dy2);
		}
	}

	private static void smethod_1(List<PointF> points, int index, float dx, float dy)
	{
		PointF pointF = points[index];
		points[index] = new PointF(pointF.X + dx, pointF.Y + dy);
	}
}
