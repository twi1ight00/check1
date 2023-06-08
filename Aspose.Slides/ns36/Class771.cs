using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using ns40;

namespace ns36;

internal class Class771 : Interface26
{
	private Enum152 enum152_0;

	private float float_0;

	private Class772 class772_0;

	private GradientDirection gradientDirection_0;

	public Enum152 FillType
	{
		get
		{
			return enum152_0;
		}
		set
		{
			enum152_0 = value;
		}
	}

	public float Angle
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	internal Class772 GradientStopsInternal => class772_0;

	public Interface27 GradientStops => class772_0;

	public GradientDirection DirectionType
	{
		get
		{
			return gradientDirection_0;
		}
		set
		{
			gradientDirection_0 = value;
		}
	}

	internal Class771()
	{
		enum152_0 = Enum152.const_0;
		float_0 = 0f;
		class772_0 = new Class772();
		gradientDirection_0 = GradientDirection.FromCenter;
	}

	internal Brush method_0(GraphicsPath path, Pen pathPen, bool isColorReserved, float colorGene)
	{
		if (pathPen != null)
		{
			path.Widen(pathPen);
		}
		RectangleF rectangleF = Class790.smethod_0(path);
		if (!(rectangleF.Width <= 0f) && rectangleF.Height > 0f)
		{
			ColorBlend interpolationColors = method_1(colorGene);
			if (FillType == Enum152.const_0)
			{
				LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangleF, Color.Red, Color.Green, Angle);
				linearGradientBrush.InterpolationColors = interpolationColors;
				return linearGradientBrush;
			}
			if (FillType == Enum152.const_1)
			{
				GraphicsPath path2 = method_2(rectangleF);
				PathGradientBrush pathGradientBrush = new PathGradientBrush(path2);
				pathGradientBrush.InterpolationColors = interpolationColors;
				return pathGradientBrush;
			}
			if (FillType == Enum152.const_2)
			{
				GraphicsPath path3 = method_2(rectangleF);
				PathGradientBrush pathGradientBrush2 = new PathGradientBrush(path3);
				pathGradientBrush2.InterpolationColors = interpolationColors;
				return pathGradientBrush2;
			}
			PathGradientBrush pathGradientBrush3 = new PathGradientBrush(path);
			pathGradientBrush3.InterpolationColors = interpolationColors;
			return pathGradientBrush3;
		}
		return new SolidBrush(Color.Empty);
	}

	private ColorBlend method_1(float colorGene)
	{
		List<Interface28> list = new List<Interface28>();
		for (int i = 0; i < class772_0.Count; i++)
		{
			list.Add(class772_0[i]);
		}
		Class773 comparer = new Class773();
		list.Sort(comparer);
		int count = list.Count;
		List<Color> list2 = new List<Color>();
		List<float> list3 = new List<float>();
		for (int j = 0; j < count; j++)
		{
			Interface28 @interface = list[j];
			Color item = Color.FromArgb(@interface.Color.A, (int)((float)(int)@interface.Color.R * colorGene), (int)((float)(int)@interface.Color.G * colorGene), (int)((float)(int)@interface.Color.B * colorGene));
			float num = @interface.Position / 100f;
			list2.Add(item);
			list3.Add(num);
			if (j == 0 && num != 0f)
			{
				list2.Insert(0, item);
				list3.Insert(0, 0f);
			}
			if (j == count - 1 && num != 1f)
			{
				list2.Add(item);
				list3.Add(1f);
			}
		}
		Color[] array = new Color[list2.Count];
		float[] array2 = new float[list3.Count];
		bool flag = ((FillType != 0) ? true : false);
		for (int k = 0; k < list2.Count; k++)
		{
			int index = k;
			if (flag)
			{
				index = list2.Count - 1 - k;
			}
			Color color = list2[index];
			float num2 = (float)Convert.ToDouble(list3[index]);
			num2 = (flag ? (1f - num2) : num2);
			array[k] = color;
			array2[k] = num2;
		}
		ColorBlend colorBlend = new ColorBlend();
		colorBlend.Colors = array;
		colorBlend.Positions = array2;
		return colorBlend;
	}

	private GraphicsPath method_2(RectangleF originalRect)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		if (DirectionType == GradientDirection.FromCenter)
		{
			if (FillType == Enum152.const_1)
			{
				graphicsPath.AddRectangle(originalRect);
			}
			else
			{
				float num = (float)Math.Sqrt(originalRect.Width / 2f * originalRect.Width / 2f + originalRect.Height / 2f * originalRect.Height / 2f);
				PointF pointF = new PointF(originalRect.Left + originalRect.Width / 2f, originalRect.Top + originalRect.Height / 2f);
				graphicsPath.AddEllipse(pointF.X - num, pointF.Y - num, 2f * num, 2f * num);
			}
		}
		else
		{
			PointF empty = PointF.Empty;
			empty = ((DirectionType == GradientDirection.FromCorner1) ? new PointF(originalRect.Left, originalRect.Bottom) : ((DirectionType == GradientDirection.FromCorner2) ? new PointF(originalRect.Right, originalRect.Bottom) : ((DirectionType != GradientDirection.FromCorner3) ? new PointF(originalRect.Right, originalRect.Top) : new PointF(originalRect.Left, originalRect.Top))));
			if (FillType == Enum152.const_1)
			{
				RectangleF empty2 = RectangleF.Empty;
				empty2.X = empty.X - originalRect.Width;
				empty2.Y = empty.Y - originalRect.Height;
				empty2.Width = 2f * originalRect.Width;
				empty2.Height = 2f * originalRect.Height;
				graphicsPath.AddRectangle(empty2);
			}
			else
			{
				float num2 = (float)Math.Sqrt(originalRect.Width * originalRect.Width + originalRect.Height * originalRect.Height);
				graphicsPath.AddEllipse(empty.X - num2, empty.Y - num2, 2f * num2, 2f * num2);
			}
		}
		return graphicsPath;
	}

	internal bool method_3(Class771 other)
	{
		if (other != null)
		{
			if (FillType != other.FillType)
			{
				return false;
			}
			if (Angle != other.Angle)
			{
				return false;
			}
			if (DirectionType != other.DirectionType)
			{
				return false;
			}
			if (FillType != other.FillType)
			{
				return false;
			}
			if (!GradientStopsInternal.method_1(other.GradientStopsInternal))
			{
				return false;
			}
			return true;
		}
		return false;
	}
}
