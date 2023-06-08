using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ns67;

internal sealed class Class3450 : ICloneable
{
	private const int int_0 = 12700;

	private readonly List<Class3451> list_0;

	private readonly Class3433 class3433_0;

	private Class3387 class3387_0;

	private Class3389 class3389_0;

	private Class3062[] class3062_0;

	private RectangleF[] rectangleF_0;

	public Class3387 Properties => class3387_0;

	public Class3389 ListStyle
	{
		get
		{
			return class3389_0;
		}
		set
		{
			if (value != class3389_0)
			{
				class3389_0 = value?.method_0();
			}
		}
	}

	public Class3451[] Paragraphs => list_0.ToArray();

	internal Class3062[] PredefinedPaths => class3062_0;

	internal RectangleF[] PredefinedPathCoordinates => rectangleF_0;

	public object Clone()
	{
		return method_0();
	}

	public Class3450 method_0()
	{
		Class3450 @class = new Class3450(class3433_0);
		@class.class3387_0 = class3387_0.method_0();
		@class.ListStyle = class3389_0;
		foreach (Class3451 item in list_0)
		{
			@class.list_0.Add(item.method_0());
		}
		return @class;
	}

	public void method_1(Class3451 paragraph)
	{
		if (paragraph == null)
		{
			throw new ArgumentNullException("paragraph");
		}
		list_0.Add(paragraph);
	}

	public GraphicsPath[] method_2(out RectangleF bounds)
	{
		Class3069[] array = method_4(class3433_0.method_2(), 3116.0);
		GraphicsPath[] array2 = new GraphicsPath[array.Length];
		bounds = default(RectangleF);
		if (array.Length > 0)
		{
			float num = float.MaxValue;
			float num2 = float.MaxValue;
			float num3 = float.MinValue;
			float num4 = float.MinValue;
			for (int i = 0; i < array.Length; i++)
			{
				Class3069 @class = array[i];
				Class3031[] array3 = @class.ContourList.method_0();
				GraphicsPath graphicsPath = (array2[i] = new GraphicsPath());
				Class3031[] array4 = array3;
				foreach (Class3031 class2 in array4)
				{
					if (class2.PointsCount <= 0)
					{
						continue;
					}
					PointF[] array5 = new PointF[class2.PointsCount];
					for (int k = 0; k < class2.PointsCount; k++)
					{
						Struct159 @struct = class2[k];
						float num5 = (float)(@struct.X / 12700.0);
						float num6 = (float)(@struct.Y / 12700.0);
						if (num > num5)
						{
							num = num5;
						}
						if (num2 > num6)
						{
							num2 = num6;
						}
						if (num3 < num5)
						{
							num3 = num5;
						}
						if (num4 < num6)
						{
							num4 = num6;
						}
						ref PointF reference = ref array5[k];
						reference = new PointF(num5, num6);
					}
					graphicsPath.AddPolygon(array5);
				}
			}
			bounds = new RectangleF(num, num2, Math.Abs(num3 - num), Math.Abs(num4 - num2));
		}
		return array2;
	}

	public void method_3(IList<GraphicsPath> charPaths, IList<RectangleF> charBounds)
	{
		if (charPaths.Count != charBounds.Count)
		{
			throw new ArgumentException("Count of charPaths list must be equals count of charBounds list");
		}
		class3062_0 = new Class3062[charPaths.Count];
		rectangleF_0 = new RectangleF[charBounds.Count];
		for (int i = 0; i < charPaths.Count; i++)
		{
			Class3062 @class = new Class3062(charPaths[i], 12700f);
			class3062_0[i] = @class;
			RectangleF rectangleF = charBounds[i];
			ref RectangleF reference = ref rectangleF_0[i];
			reference = new RectangleF(rectangleF.X * 12700f, rectangleF.Y * 12700f, rectangleF.Width * 12700f, rectangleF.Height * 12700f);
		}
	}

	internal Class3069[] method_4(Class3448 bounds, double flatness)
	{
		Class3070 @class = new Class3070(this, bounds, flatness);
		return @class.method_0();
	}

	internal Class3450(Class3433 container)
	{
		if (container == null)
		{
			throw new ArgumentNullException();
		}
		class3387_0 = new Class3387();
		class3433_0 = container;
		list_0 = new List<Class3451>();
	}
}
