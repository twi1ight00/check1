using System;
using System.Collections.Generic;

namespace ns67;

internal sealed class Class3340 : ICloneable
{
	private Class3442 class3442_0;

	private readonly bool bool_0;

	private readonly Enum492 enum492_0;

	private readonly double double_0;

	private readonly List<Class3442> list_0;

	private readonly bool bool_1;

	private readonly double double_1;

	public bool ExtrusionOk => bool_0;

	public Enum492 FillMode => enum492_0;

	public double Height => double_0;

	public bool IsEmpty
	{
		get
		{
			foreach (Class3442 item in list_0)
			{
				if (item.IsEmpty)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool Stroke => bool_1;

	public double Width => double_1;

	public Class3340(double width, double height, Enum492 fillMode, bool extrusionOk, bool stroke)
	{
		list_0 = new List<Class3442>();
		double_1 = width;
		double_0 = height;
		enum492_0 = fillMode;
		bool_0 = extrusionOk;
		bool_1 = stroke;
	}

	public void method_0(double heightRadius, double widthRadius, double startAngle, double swingAngle)
	{
		method_10().method_0(heightRadius, widthRadius, startAngle, swingAngle);
	}

	internal List<Class3062> method_1()
	{
		List<Class3062> list = new List<Class3062>();
		foreach (Class3442 item2 in list_0)
		{
			Class3062 item = item2.method_1();
			list.Add(item);
		}
		return list;
	}

	public object Clone()
	{
		return method_2();
	}

	public Class3340 method_2()
	{
		Class3340 @class = new Class3340(double_1, double_0, enum492_0, bool_0, bool_1);
		foreach (Class3442 item in list_0)
		{
			@class.method_9(item.method_2());
		}
		return @class;
	}

	public void method_3(Struct159 firstControlPoint, Struct159 secondControlPoint, Struct159 endingPoint)
	{
		method_10().method_3(firstControlPoint, secondControlPoint, endingPoint);
	}

	public void method_4()
	{
		class3442_0 = new Class3442(double_1, double_0, enum492_0, bool_0, bool_1);
		method_9(class3442_0);
	}

	public void Close()
	{
		method_10().Close();
	}

	public List<Class3442> method_5()
	{
		List<Class3442> list = new List<Class3442>();
		foreach (Class3442 item in list_0)
		{
			list.Add(item.method_2());
		}
		return list;
	}

	public void method_6(double x, double y)
	{
		method_10().method_4(x, y);
	}

	public void method_7(double x, double y)
	{
		Class3442 @class = method_10();
		if (!@class.IsEmpty)
		{
			class3442_0 = null;
		}
		method_10().method_5(x, y);
	}

	public void method_8(Struct159 firstControlPoint, Struct159 endingPoint)
	{
		method_10().method_7(firstControlPoint, endingPoint);
	}

	private void method_9(Class3442 path)
	{
		list_0.Add(path);
	}

	private Class3442 method_10()
	{
		if (class3442_0 == null || class3442_0.IsClosed)
		{
			class3442_0 = new Class3442(double_1, double_0, enum492_0, bool_0, bool_1);
			method_9(class3442_0);
		}
		return class3442_0;
	}
}
