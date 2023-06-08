using System;
using System.Collections.Generic;
using System.Drawing;

namespace ns67;

internal class Class3279 : Class3090, ICloneable
{
	private readonly List<Class3340> list_0;

	private Class3457 class3457_0;

	public Class3457 TextRectangle
	{
		get
		{
			if (class3457_0 == null)
			{
				return new Class3457(base.Transform2D.Offset, base.Transform2D.Extents);
			}
			return class3457_0;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			class3457_0 = value.method_0();
		}
	}

	public Class3279(Class3448 transform2D)
		: base(transform2D)
	{
		list_0 = new List<Class3340>();
	}

	public object Clone()
	{
		return method_1();
	}

	public Class3279 method_1()
	{
		Class3279 @class = new Class3279(base.Transform2D);
		@class.class3457_0 = class3457_0.method_0();
		foreach (Class3340 item in list_0)
		{
			@class.list_0.Add(item.method_2());
		}
		return @class;
	}

	public void method_2(double width, double height, Enum492 fillMode, bool extrusionOk, bool stroke)
	{
		Class3340 item = new Class3340(width, height, fillMode, extrusionOk, stroke);
		list_0.Add(item);
	}

	public void method_3(double x, double y)
	{
		Class3340 @class = method_11();
		@class.method_7(x, y);
	}

	public void method_4(double x, double y)
	{
		method_11().method_6(x, y);
	}

	public void method_5(double heightRadius, double widthRadius, double startAngle, double swingAngle)
	{
		method_11().method_0(heightRadius, widthRadius, startAngle, swingAngle);
	}

	public void method_6(Struct159 firstControlPoint, Struct159 secondControlPoint, Struct159 endingPoint)
	{
		method_11().method_3(firstControlPoint, secondControlPoint, endingPoint);
	}

	public void method_7(Struct159 firstControlPoint, Struct159 endingPoint)
	{
		method_11().method_8(firstControlPoint, endingPoint);
	}

	public void method_8()
	{
		method_11().Close();
	}

	internal Class3030[] method_9(double flatness)
	{
		List<Class3030> list = new List<Class3030>();
		foreach (Class3340 item in list_0)
		{
			List<Class3442> list2 = item.method_5();
			Class3030 @class = new Class3030();
			foreach (Class3442 item2 in list2)
			{
				Class3062 class2 = item2.method_1();
				class2.method_2();
				class2.method_17(item2.Width / 2.0, item2.Height / 2.0);
				double dx = base.Transform2D.Extents.Cx / item2.Width;
				double dy = base.Transform2D.Extents.Cy / item2.Height;
				if (Math.Abs(item2.Width) < 1E-06)
				{
					if (!(Math.Abs(item2.Width - base.Transform2D.Extents.Cx) < 1E-06))
					{
						throw new DivideByZeroException();
					}
					dx = 1.0;
				}
				if (Math.Abs(item2.Height) < 1E-06)
				{
					if (!(Math.Abs(item2.Height - base.Transform2D.Extents.Cy) < 1E-06))
					{
						throw new DivideByZeroException();
					}
					dy = 1.0;
				}
				class2.method_15(dx, dy, append: false);
				class2.method_14((0.0 - base.Transform2D.Extents.Cx) / 2.0, (0.0 - base.Transform2D.Extents.Cy) / 2.0, append: false);
				class2.method_16(base.Transform2D.HorizontalFlip, base.Transform2D.VerticalFlip);
				class2.SetRotation(base.Transform2D.Rotation / 60000.0, append: false);
				class2.method_12();
				class2.method_13();
				PointF[] pathPoints = class2.PathPoints;
				Class3031 class3 = new Class3031(item2.FillMode, item2.Stroke);
				for (int i = 0; i < pathPoints.Length; i++)
				{
					class3.method_0(new Struct159(pathPoints[i].X, pathPoints[i].Y));
				}
				if (item2.IsClosed)
				{
					class3.Close();
				}
				@class.Add(class3);
			}
			list.Add(@class);
		}
		return list.ToArray();
	}

	internal void method_10(Class3340 path)
	{
		list_0.Add(path);
	}

	private Class3340 method_11()
	{
		if (list_0.Count == 0)
		{
			throw new ApplicationException("A Path object has not been added.");
		}
		return list_0[list_0.Count - 1];
	}
}
