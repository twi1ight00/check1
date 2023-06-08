using System;
using System.Drawing;
using ns67;
using ns69;

namespace ns68;

internal sealed class Class3006
{
	public static Class3007 smethod_0(Class2994[] threeEdges, Class3019 backBuffer, Point crossI)
	{
		Class2992 @class = Class2990.smethod_0(threeEdges[0], threeEdges[1]);
		Class2992 class2 = Class2990.smethod_0(threeEdges[1], threeEdges[2]);
		Class2992 class3 = Class2990.smethod_0(threeEdges[0], threeEdges[2]);
		Class3007 class4;
		if (@class != null && class2 != null && class3 != null)
		{
			Struct159 intersect2;
			Struct159 intersect3;
			if (Class3037.smethod_14(@class.A, @class.B, class2.A, class2.B, out var intersect) != 1)
			{
				class4 = smethod_2(backBuffer, crossI);
			}
			else if (Class3037.smethod_14(class2.A, class2.B, class3.A, class3.B, out intersect2) != 1)
			{
				class4 = smethod_2(backBuffer, crossI);
			}
			else if (Class3037.smethod_14(@class.A, @class.B, class3.A, class3.B, out intersect3) != 1)
			{
				class4 = smethod_2(backBuffer, crossI);
			}
			else
			{
				class4 = smethod_1(intersect, intersect2, intersect3);
				if (class4 == null)
				{
					return null;
				}
			}
		}
		else
		{
			class4 = smethod_2(backBuffer, crossI);
		}
		double num = backBuffer.NormalizedBackBufferCoordinateSystem.method_3(class4.X);
		double num2 = backBuffer.NormalizedBackBufferCoordinateSystem.method_4(class4.Y);
		double num3 = Math.Max(Math.Abs((double)crossI.X - num), Math.Abs((double)crossI.Y - num2));
		if (num3 > 5.0)
		{
			class4 = smethod_2(backBuffer, crossI);
		}
		return class4;
	}

	private static Class3007 smethod_1(Struct159 intrsct1, Struct159 intrsct2, Struct159 intrsct3)
	{
		Struct159 @struct = new Struct159(intrsct2.X - intrsct1.X, intrsct2.Y - intrsct1.Y);
		Struct159 struct2 = new Struct159(intrsct3.X - intrsct2.X, intrsct3.Y - intrsct2.Y);
		Struct159 struct3 = new Struct159(intrsct3.X - intrsct1.X, intrsct3.Y - intrsct1.Y);
		double num = Math.Sqrt(@struct.X * @struct.X + @struct.Y * @struct.Y);
		double num2 = Math.Sqrt(struct2.X * struct2.X + struct2.Y * struct2.Y);
		double num3 = Math.Sqrt(struct3.X * struct3.X + struct3.Y * struct3.Y);
		if (num < 1E-07)
		{
			return new Class3007(intrsct1.X, intrsct1.Y);
		}
		if (num2 < 1E-07)
		{
			return new Class3007(intrsct2.X, intrsct2.Y);
		}
		if (num3 < 1E-07)
		{
			return new Class3007(intrsct3.X, intrsct3.Y);
		}
		double num4 = Math.Abs((@struct.X * struct3.X + @struct.Y * struct3.Y) / (num * num3));
		double num5 = Math.Abs(((0.0 - @struct.X) * struct2.X + (0.0 - @struct.Y) * struct2.Y) / (num * num2));
		double num6 = Math.Abs(((0.0 - struct2.X) * (0.0 - struct3.X) + (0.0 - struct2.Y) * (0.0 - struct3.Y)) / (num2 * num3));
		if (num4 < num5 && num4 < num6)
		{
			return new Class3007(intrsct1.X, intrsct1.Y);
		}
		if (num5 < num4 && num5 < num6)
		{
			return new Class3007(intrsct2.X, intrsct2.Y);
		}
		if (num6 < num4 && num6 < num5)
		{
			return new Class3007(intrsct3.X, intrsct3.Y);
		}
		return null;
	}

	private static Class3007 smethod_2(Class3019 backBuffer, Point crossI)
	{
		Class3007 @class = new Class3007(backBuffer.NormalizedBackBufferCoordinateSystem.method_1(crossI.X), backBuffer.NormalizedBackBufferCoordinateSystem.method_2(crossI.Y));
		@class.bool_0 = false;
		return @class;
	}
}
