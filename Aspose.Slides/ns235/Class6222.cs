using System.Drawing;
using ns224;

namespace ns235;

internal class Class6222 : Class6204, Interface262, Interface263
{
	private Struct219 struct219_0;

	private Class5998 class5998_0 = Class5998.class5998_7;

	public Struct219 Curve
	{
		get
		{
			return struct219_0;
		}
		set
		{
			struct219_0 = value;
		}
	}

	public Class5998 CurveColor
	{
		get
		{
			return class5998_0;
		}
		set
		{
			class5998_0 = value;
		}
	}

	public Class6222()
	{
	}

	public Class6222(Class5998 color)
	{
		class5998_0 = color;
	}

	public Class6222(Struct219 bezier)
	{
		struct219_0 = bezier;
	}

	public Class6222(Struct219 bezier, Class5998 color)
		: this(bezier)
	{
		class5998_0 = color;
	}

	public Class6222(PointF cubP0, PointF cubP1, PointF cubP2, PointF cubP3)
	{
		struct219_0 = default(Struct219);
		struct219_0.StartPoint = cubP0;
		struct219_0.ControlPoint1 = cubP1;
		struct219_0.ControlPoint2 = cubP2;
		struct219_0.EndPoint = cubP3;
	}

	public Class6222(PointF cubP0, PointF cubP1, PointF cubP2, PointF cubP3, Class5998 color)
		: this(cubP0, cubP1, cubP2, cubP3)
	{
		class5998_0 = color;
	}

	public Class6222(PointF[] points)
		: this(points[0], points[1], points[2], points[3])
	{
	}

	public Class6222(PointF[] points, Class5998 color)
		: this(points[0], points[1], points[2], points[3], color)
	{
	}

	public Class6222(PointF quadP0, PointF quadP1, PointF quadP2)
	{
		struct219_0 = new Struct219(quadP0, quadP1, quadP2);
	}

	public Class6222(PointF quadP0, PointF quadP1, PointF quadP2, Class5998 color)
		: this(quadP0, quadP1, quadP2)
	{
		class5998_0 = color;
	}

	public override void vmethod_0(Class6176 visitor)
	{
		visitor.vmethod_10(this);
	}

	public void imethod_0(Class6002 matrix)
	{
		PointF[] array = new PointF[4] { struct219_0.StartPoint, struct219_0.ControlPoint1, struct219_0.ControlPoint2, struct219_0.EndPoint };
		matrix.method_3(array);
		struct219_0.StartPoint = array[0];
		struct219_0.ControlPoint1 = array[1];
		struct219_0.ControlPoint2 = array[2];
		struct219_0.EndPoint = array[3];
	}

	public Class6204 Clone()
	{
		Struct219 bezier = default(Struct219);
		bezier.StartPoint = new PointF(struct219_0.StartPoint.X, struct219_0.StartPoint.Y);
		bezier.EndPoint = new PointF(struct219_0.EndPoint.X, struct219_0.EndPoint.Y);
		bezier.ControlPoint1 = new PointF(struct219_0.ControlPoint1.X, struct219_0.ControlPoint1.Y);
		bezier.ControlPoint2 = new PointF(struct219_0.ControlPoint2.X, struct219_0.ControlPoint2.Y);
		Class6222 @class = new Class6222(bezier, class5998_0);
		@class.struct219_0 = bezier;
		return @class;
	}
}
