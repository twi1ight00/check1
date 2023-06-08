using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using ns3;
using ns34;

namespace ns33;

internal class Class841 : IDisposable, Interface26
{
	private Class821 class821_0;

	private Class822 class822_0;

	private Class840 class840_0;

	private int int_0;

	private Enum65 enum65_0;

	private Enum71 enum71_0 = Enum71.const_1;

	private object object_0;

	private bool bool_0;

	public Interface8 Area => class822_0;

	public Interface25 Border => class840_0;

	public int MarkerSize
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public Enum65 MarkerStyle
	{
		get
		{
			if (enum71_0 == Enum71.const_0)
			{
				return Enum65.const_5;
			}
			return enum65_0;
		}
		set
		{
			enum65_0 = value;
		}
	}

	internal bool IsVisible
	{
		get
		{
			if (MarkerStyle == Enum65.const_5)
			{
				return false;
			}
			return true;
		}
	}

	internal Class841(Class821 class821_1, object object_1)
	{
		class821_0 = class821_1;
		object_0 = object_1;
		method_0();
	}

	private void method_0()
	{
		class822_0 = new Class822(class821_0, object_0, Enum52.const_5);
		class840_0 = new Class840(class821_0, Enum57.const_7);
		float num = class821_0.imethod_0()?.imethod_51() ?? 96f;
		int_0 = Struct63.smethod_5(7f * num / 72f);
	}

	[SpecialName]
	internal Class822 method_1()
	{
		return class822_0;
	}

	[SpecialName]
	internal Class840 method_2()
	{
		return class840_0;
	}

	internal bool method_3(Class841 class841_0)
	{
		if (IsVisible == class841_0.IsVisible && IsVisible)
		{
			if (MarkerStyle != class841_0.MarkerStyle)
			{
				return false;
			}
			if (!method_1().method_3(class841_0.method_1()))
			{
				return false;
			}
			if (!method_2().method_4(class841_0.method_2()))
			{
				return false;
			}
			if (MarkerStyle != class841_0.MarkerStyle)
			{
				return false;
			}
			if (MarkerSize != class841_0.MarkerSize)
			{
				return false;
			}
		}
		return true;
	}

	internal void method_4(Enum65 enum65_1)
	{
		if (MarkerStyle == Enum65.const_0)
		{
			MarkerStyle = enum65_1;
		}
	}

	internal void method_5(int int_1)
	{
		if (MarkerStyle == Enum65.const_0)
		{
			float num = class821_0.imethod_0()?.imethod_51() ?? 96f;
			int_0 = Struct63.smethod_5((float)int_1 * num / 72f);
		}
	}

	internal void method_6(float float_0, float float_1)
	{
		method_7(float_0, float_1, MarkerSize);
	}

	internal void method_7(float float_0, float float_1, float float_2)
	{
		if (MarkerStyle != Enum65.const_5)
		{
			new RectangleF(float_0 - float_2 / 2f, float_1 - float_2 / 2f, float_2, float_2);
			class821_0.imethod_0();
			int num = Struct63.smethod_5(float_2 / 2f);
			GraphicsPath graphicsPath = new GraphicsPath();
			switch (MarkerStyle)
			{
			case Enum65.const_3:
			{
				PointF[] array = new PointF[4];
				array[0].X = float_0 - (float)num;
				array[0].Y = float_1;
				array[1].X = float_0;
				array[1].Y = float_1 - (float)num;
				array[2].X = float_0 + (float)num;
				array[2].Y = float_1;
				array[3].X = float_0;
				array[3].Y = float_1 + (float)num;
				graphicsPath.AddPolygon(array);
				method_1().method_9(graphicsPath);
				class840_0.method_11(graphicsPath);
				break;
			}
			case Enum65.const_7:
				float_0 -= (float)num;
				float_1 -= (float)num;
				graphicsPath.AddRectangle(new RectangleF(float_0, float_1, 2 * num, 2 * num));
				method_1().method_9(graphicsPath);
				class840_0.method_11(graphicsPath);
				break;
			case Enum65.const_9:
			{
				PointF[] array2 = new PointF[3];
				array2[0].X = float_0 - (float)num;
				array2[0].Y = float_1 + (float)num;
				array2[1].X = float_0;
				array2[1].Y = float_1 - (float)num;
				array2[2].X = float_0 + (float)num;
				array2[2].Y = float_1 + (float)num;
				graphicsPath.AddPolygon(array2);
				method_1().method_9(graphicsPath);
				class840_0.method_11(graphicsPath);
				break;
			}
			case Enum65.const_10:
				float_0 -= (float)num;
				float_1 -= (float)num;
				method_1().method_8(new RectangleF(float_0, float_1, num * 2, num * 2));
				class840_0.method_8(new PointF(float_0, float_1), new PointF(float_0 + (float)(num * 2), float_1 + (float)(num * 2)));
				class840_0.method_8(new PointF(float_0, float_1 + (float)(num * 2)), new PointF(float_0 + (float)(num * 2), float_1));
				break;
			case Enum65.const_8:
				float_0 -= (float)num;
				float_1 -= (float)num;
				method_1().method_8(new RectangleF(float_0, float_1, num * 2, num * 2));
				class840_0.method_7(float_0, float_1, float_0 + (float)(num * 2), float_1 + (float)(num * 2));
				class840_0.method_7(float_0, float_1 + (float)(num * 2), float_0 + (float)(num * 2), float_1);
				class840_0.method_7(float_0 + (float)num, float_1, float_0 + (float)num, float_1 + (float)(num * 2));
				break;
			case Enum65.const_1:
				float_0 -= (float)num;
				float_1 -= (float)num;
				graphicsPath.AddEllipse(float_0, float_1, num * 2, num * 2);
				method_1().method_9(graphicsPath);
				class840_0.method_11(graphicsPath);
				break;
			case Enum65.const_6:
				float_0 -= (float)num;
				float_1 -= (float)num;
				method_1().method_8(new RectangleF(float_0, float_1, num * 2, num * 2));
				class840_0.method_7(float_0, float_1 + (float)num, float_0 + (float)(num * 2), float_1 + (float)num);
				class840_0.method_7(float_0 + (float)num, float_1, float_0 + (float)num, float_1 + (float)(num * 2));
				break;
			case Enum65.const_4:
			{
				int num2 = Struct63.smethod_5(float_2 / 2f);
				int num3 = Struct63.smethod_5(float_2 / 4f);
				float_1 = ((num3 >= 2) ? (float_1 - (float)(num3 / 2)) : ((float)(int)((double)(float_1 - (float)(num3 / 2)) + 0.5)));
				method_1().method_8(new RectangleF(float_0, float_1, num2, num3));
				class840_0.method_10(new RectangleF(float_0, float_1, num2, num3));
				break;
			}
			case Enum65.const_2:
			{
				int num2 = Struct63.smethod_5(float_2);
				int num3 = Struct63.smethod_5(float_2 / 4f);
				float_0 -= (float)(num2 / 2);
				float_1 -= (float)(num3 / 2);
				method_1().method_8(new RectangleF(float_0, float_1, num2, num3));
				class840_0.method_10(new RectangleF(float_0, float_1, num2, num3));
				break;
			}
			}
		}
	}

	~Class841()
	{
		Dispose(bool_1: false);
	}

	public void Dispose()
	{
		Dispose(bool_1: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_1)
	{
		if (!bool_0)
		{
			if (bool_1 && class822_0 != null)
			{
				class822_0.Dispose();
			}
			bool_0 = true;
		}
	}
}
