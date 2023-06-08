using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using ns22;

namespace ns3;

internal class Class857 : Interface35
{
	private Enum73 enum73_0;

	private float float_0;

	private Class858 class858_0;

	private Enum72 enum72_0;

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

	public Interface36 GradientStops => class858_0;

	public Enum73 FillType => enum73_0;

	public Enum72 DirectionType => enum72_0;

	[SpecialName]
	public void imethod_0(Enum73 enum73_1)
	{
		enum73_0 = enum73_1;
	}

	[SpecialName]
	internal Class858 method_0()
	{
		return class858_0;
	}

	[SpecialName]
	public void imethod_1(Enum72 enum72_1)
	{
		enum72_0 = enum72_1;
	}

	internal Class857()
	{
		enum73_0 = Enum73.const_0;
		float_0 = 0f;
		class858_0 = new Class858();
		enum72_0 = Enum72.const_4;
	}

	internal Brush method_1(GraphicsPath graphicsPath_0, Pen pen_0, bool bool_0, float float_1)
	{
		if (pen_0 != null)
		{
			graphicsPath_0.Widen(pen_0);
		}
		RectangleF rectangleF = Class1181.smethod_1(graphicsPath_0);
		if (!(rectangleF.Width <= 0f) && rectangleF.Height > 0f)
		{
			ColorBlend interpolationColors = method_2(float_1);
			if (FillType == Enum73.const_0)
			{
				LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangleF, Color.Red, Color.Green, Angle);
				linearGradientBrush.InterpolationColors = interpolationColors;
				return linearGradientBrush;
			}
			if (FillType == Enum73.const_1)
			{
				GraphicsPath path = method_3(rectangleF);
				PathGradientBrush pathGradientBrush = new PathGradientBrush(path);
				pathGradientBrush.InterpolationColors = interpolationColors;
				return pathGradientBrush;
			}
			if (FillType == Enum73.const_2)
			{
				GraphicsPath path2 = method_3(rectangleF);
				PathGradientBrush pathGradientBrush2 = new PathGradientBrush(path2);
				pathGradientBrush2.InterpolationColors = interpolationColors;
				return pathGradientBrush2;
			}
			PathGradientBrush pathGradientBrush3 = new PathGradientBrush(graphicsPath_0);
			pathGradientBrush3.InterpolationColors = interpolationColors;
			return pathGradientBrush3;
		}
		return new SolidBrush(Color.Empty);
	}

	private ColorBlend method_2(float float_1)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < class858_0.Count; i++)
		{
			arrayList.Add(class858_0[i]);
		}
		Class859 comparer = new Class859();
		arrayList.Sort(comparer);
		int count = arrayList.Count;
		ArrayList arrayList2 = new ArrayList();
		ArrayList arrayList3 = new ArrayList();
		for (int j = 0; j < count; j++)
		{
			Interface37 @interface = (Interface37)arrayList[j];
			Color color = Color.FromArgb(@interface.Color.A, (int)((float)(int)@interface.Color.R * float_1), (int)((float)(int)@interface.Color.G * float_1), (int)((float)(int)@interface.Color.B * float_1));
			float num = @interface.Position / 100f;
			arrayList2.Add(color);
			arrayList3.Add(num);
			if (j == 0 && num != 0f)
			{
				arrayList2.Insert(0, color);
				arrayList3.Insert(0, 0);
			}
			if (j == count - 1 && num != 1f)
			{
				arrayList2.Add(color);
				arrayList3.Add(1);
			}
		}
		Color[] array = new Color[arrayList2.Count];
		float[] array2 = new float[arrayList3.Count];
		bool flag = ((FillType != 0) ? true : false);
		for (int k = 0; k < arrayList2.Count; k++)
		{
			int index = k;
			if (flag)
			{
				index = arrayList2.Count - 1 - k;
			}
			Color color2 = (Color)arrayList2[index];
			float num2 = (float)Convert.ToDouble(arrayList3[index]);
			num2 = (flag ? (1f - num2) : num2);
			array[k] = color2;
			array2[k] = num2;
		}
		ColorBlend colorBlend = new ColorBlend();
		colorBlend.Colors = array;
		colorBlend.Positions = array2;
		return colorBlend;
	}

	private GraphicsPath method_3(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		if (DirectionType == Enum72.const_4)
		{
			if (FillType == Enum73.const_1)
			{
				graphicsPath.AddRectangle(rectangleF_0);
			}
			else
			{
				float num = (float)Math.Sqrt(rectangleF_0.Width / 2f * rectangleF_0.Width / 2f + rectangleF_0.Height / 2f * rectangleF_0.Height / 2f);
				PointF pointF = new PointF(rectangleF_0.Left + rectangleF_0.Width / 2f, rectangleF_0.Top + rectangleF_0.Height / 2f);
				graphicsPath.AddEllipse(pointF.X - num, pointF.Y - num, 2f * num, 2f * num);
			}
		}
		else
		{
			PointF empty = PointF.Empty;
			empty = ((DirectionType == Enum72.const_2) ? new PointF(rectangleF_0.Left, rectangleF_0.Bottom) : ((DirectionType == Enum72.const_3) ? new PointF(rectangleF_0.Right, rectangleF_0.Bottom) : ((DirectionType != 0) ? new PointF(rectangleF_0.Right, rectangleF_0.Top) : new PointF(rectangleF_0.Left, rectangleF_0.Top))));
			if (FillType == Enum73.const_1)
			{
				RectangleF empty2 = RectangleF.Empty;
				empty2.X = empty.X - rectangleF_0.Width;
				empty2.Y = empty.Y - rectangleF_0.Height;
				empty2.Width = 2f * rectangleF_0.Width;
				empty2.Height = 2f * rectangleF_0.Height;
				graphicsPath.AddRectangle(empty2);
			}
			else
			{
				float num2 = (float)Math.Sqrt(rectangleF_0.Width * rectangleF_0.Width + rectangleF_0.Height * rectangleF_0.Height);
				graphicsPath.AddEllipse(empty.X - num2, empty.Y - num2, 2f * num2, 2f * num2);
			}
		}
		return graphicsPath;
	}

	internal bool method_4(Class857 class857_0)
	{
		if (class857_0 != null)
		{
			if (FillType != class857_0.FillType)
			{
				return false;
			}
			if (Angle != class857_0.Angle)
			{
				return false;
			}
			if (DirectionType != class857_0.DirectionType)
			{
				return false;
			}
			if (FillType != class857_0.FillType)
			{
				return false;
			}
			if (!method_0().method_1(class857_0.method_0()))
			{
				return false;
			}
			return true;
		}
		return false;
	}
}
