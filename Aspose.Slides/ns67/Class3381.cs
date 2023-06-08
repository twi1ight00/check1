using System;
using System.Collections.Generic;
using System.Drawing;

namespace ns67;

internal class Class3381 : ICloneable
{
	private double double_0;

	private List<Class3378> list_0;

	public double Length => double_0;

	public Class3381(Class3062 path)
	{
		list_0 = new List<Class3378>();
		PointF[] pathPoints = path.PathPoints;
		Enum458[] pathTypes = path.PathTypes;
		if (pathTypes.Length > 1)
		{
			Struct159 start = method_5(pathPoints[0]);
			for (int i = 1; i < pathTypes.Length; i++)
			{
				Class3378 @class;
				if ((pathTypes[i] & Enum458.flag_2) == Enum458.flag_2)
				{
					@class = new Class3380(start, method_5(pathPoints[i]), method_5(pathPoints[i + 1]), method_5(pathPoints[i + 2]));
					i += 2;
				}
				else
				{
					@class = new Class3379(start, method_5(pathPoints[i]));
				}
				list_0.Add(@class);
				double_0 += @class.Length;
				if (i < pathTypes.Length)
				{
					start = method_5(pathPoints[i]);
				}
			}
			list_0.TrimExcess();
			return;
		}
		throw new ArgumentException("Path is empty", "path");
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3381 method_0()
	{
		List<Class3378> list = new List<Class3378>(list_0.Count);
		foreach (Class3378 item in list_0)
		{
			list.Add(item.vmethod_0());
		}
		return new Class3381(double_0, list);
	}

	public Class3381 method_1(double distance)
	{
		if (distance == 0.0)
		{
			return this;
		}
		List<Class3378> list = new List<Class3378>(list_0.Count);
		double num = 0.0;
		foreach (Class3378 item in list_0)
		{
			Class3378 @class = item.vmethod_1(distance);
			list.Add(@class);
			num += @class.Length;
		}
		return new Class3381(num, list);
	}

	public Struct159 method_2(double percent)
	{
		if (percent < 0.0)
		{
			throw new ArgumentException("Offset can not be less than zero", "offset");
		}
		double offset = double_0 * percent;
		double percent2;
		Class3378 @class = method_4(offset, out percent2);
		return @class.vmethod_2(percent2);
	}

	public Struct158 method_3(double percent, double length, bool isOutside)
	{
		if (percent < 0.0)
		{
			throw new ArgumentException("Offset can not be less than zero", "offset");
		}
		if (length < 0.0)
		{
			throw new ArgumentException("Length can not be less than zero", "length");
		}
		double offset = double_0 * percent;
		double percent2;
		Class3378 @class = method_4(offset, out percent2);
		return @class.vmethod_3(percent2, length, isOutside);
	}

	private Class3378 method_4(double offset, out double percent)
	{
		Class3378 @class = null;
		double num = 0.0;
		for (int i = 0; i < list_0.Count; i++)
		{
			num += list_0[i].Length;
			if (!(offset > num))
			{
				@class = list_0[i];
				break;
			}
		}
		if (@class == null)
		{
			@class = list_0[list_0.Count - 1];
		}
		percent = ((@class.Length != 0.0) ? ((@class.Length - (num - offset)) / @class.Length) : 0.0);
		return @class;
	}

	private Class3381(double length, List<Class3378> parts)
	{
		double_0 = length;
		list_0 = parts;
	}

	private Struct159 method_5(PointF point)
	{
		return new Struct159(point.X, point.Y);
	}
}
