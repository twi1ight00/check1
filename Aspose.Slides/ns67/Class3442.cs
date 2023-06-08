using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace ns67;

internal sealed class Class3442 : ICloneable
{
	private readonly List<Class3443> list_0;

	private readonly bool bool_0;

	private readonly Enum492 enum492_0;

	private readonly double double_0;

	private bool bool_1;

	private Struct159 struct159_0;

	private readonly bool bool_2;

	private readonly double double_1;

	public bool ExtrusionOk => bool_0;

	public Enum492 FillMode => enum492_0;

	public double Height => double_0;

	public bool IsClosed => bool_1;

	public bool IsEmpty => 0 == list_0.Count;

	public Struct159 StartingPoint
	{
		get
		{
			return struct159_0;
		}
		set
		{
			struct159_0 = value;
		}
	}

	public bool Stroke => bool_2;

	public double Width => double_1;

	public Class3442(double width, double height, Enum492 fillMode, bool extrusionOk, bool stroke)
	{
		double_1 = width;
		double_0 = height;
		enum492_0 = fillMode;
		bool_0 = extrusionOk;
		bool_2 = stroke;
		list_0 = new List<Class3443>();
		struct159_0 = default(Struct159);
	}

	public void method_0(double heightRadius, double widthRadius, double startAngle, double swingAngle)
	{
		method_8(new Class3444(widthRadius, heightRadius, startAngle, swingAngle));
	}

	internal Class3062 method_1()
	{
		Class3062 @class = new Class3062(System.Drawing.Drawing2D.FillMode.Alternate);
		Struct159 startingPoint = struct159_0;
		foreach (Class3443 item in list_0)
		{
			startingPoint = item.vmethod_1(@class, startingPoint);
		}
		return @class;
	}

	public object Clone()
	{
		return method_2();
	}

	public Class3442 method_2()
	{
		Class3442 @class = method_6();
		@class.bool_1 = bool_1;
		foreach (Class3443 item in list_0)
		{
			@class.list_0.Add(item.vmethod_0());
		}
		return @class;
	}

	public void method_3(Struct159 firstControlPoint, Struct159 secondControlPoint, Struct159 endingPoint)
	{
		method_8(new Class3445(firstControlPoint, secondControlPoint, endingPoint));
	}

	public void Close()
	{
		bool_1 = true;
	}

	public void method_4(double x, double y)
	{
		method_8(new Class3446(x, y));
	}

	public void method_5(double x, double y)
	{
		StartingPoint = new Struct159(x, y);
	}

	public Class3442 method_6()
	{
		Class3442 @class = new Class3442(double_1, double_0, enum492_0, bool_0, bool_2);
		@class.struct159_0 = struct159_0;
		return @class;
	}

	public void method_7(Struct159 firstControlPoint, Struct159 endingPoint)
	{
		method_8(new Class3447(firstControlPoint, endingPoint));
	}

	private void method_8(Class3443 element)
	{
		list_0.Add(element);
	}
}
