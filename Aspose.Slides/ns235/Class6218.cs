using System.Drawing;
using ns224;

namespace ns235;

internal class Class6218 : Class6212
{
	private bool bool_0;

	public bool IsClosed
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public override void vmethod_0(Class6176 visitor)
	{
		visitor.vmethod_7(this);
		base.vmethod_0(visitor);
		visitor.vmethod_8(this);
	}

	public static Class6218 smethod_0(PointF[] points, bool isClosed)
	{
		Class6218 @class = new Class6218();
		@class.IsClosed = isClosed;
		@class.method_1(points);
		return @class;
	}

	public static Class6218 smethod_1(PointF start, PointF end)
	{
		Class6218 @class = new Class6218();
		@class.method_2(start, end);
		return @class;
	}

	public static Class6218 smethod_2(RectangleF rect)
	{
		Class6218 @class = new Class6218();
		@class.IsClosed = true;
		@class.method_3(rect);
		return @class;
	}

	public static Class6218 smethod_3(PointF[] points)
	{
		Class6218 @class = new Class6218();
		@class.IsClosed = false;
		@class.method_4(points);
		return @class;
	}

	public void method_1(PointF[] points)
	{
		Class6223 node = new Class6223(points);
		Add(node);
	}

	public void method_2(PointF start, PointF end)
	{
		Class6223 @class = new Class6223();
		@class.Points.Add(start);
		@class.Points.Add(end);
		Add(@class);
	}

	public void method_3(RectangleF rect)
	{
		Class6223 @class = new Class6223();
		@class.Points.Add(new PointF(rect.Left, rect.Top));
		@class.Points.Add(new PointF(rect.Right, rect.Top));
		@class.Points.Add(new PointF(rect.Right, rect.Bottom));
		@class.Points.Add(new PointF(rect.Left, rect.Bottom));
		Add(@class);
	}

	public void method_4(PointF[] points)
	{
		int num = points.Length;
		for (int i = 0; i < num - 3; i += 3)
		{
			Add(new Class6222(points[i], points[i + 1], points[i + 2], points[i + 3]));
		}
	}

	public void method_5(Class6173 arc)
	{
		Struct219[] array = arc.method_2();
		Struct219[] array2 = array;
		foreach (Struct219 bezier in array2)
		{
			Class6222 node = new Class6222(bezier);
			Add(node);
		}
	}

	public void method_6(Class6002 matrix)
	{
		for (int i = 0; i < base.Count; i++)
		{
			Interface262 @interface = (Interface262)base[i];
			@interface.imethod_0(matrix);
		}
	}

	public Class6218 Clone()
	{
		Class6218 @class = new Class6218();
		@class.bool_0 = bool_0;
		for (int i = 0; i < base.Count; i++)
		{
			Interface263 @interface = (Interface263)base[i];
			@class.Add(@interface.Clone());
		}
		return @class;
	}
}
