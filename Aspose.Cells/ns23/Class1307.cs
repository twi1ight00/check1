using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Cells.Charts;
using ns19;
using ns7;

namespace ns23;

internal class Class1307 : IDisposable
{
	private SparklineGroup sparklineGroup_0;

	private Class1310[] class1310_0;

	private Bitmap bitmap_0;

	private Interface42 interface42_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private float float_0;

	private float float_1;

	private ArrayList arrayList_0;

	private float[] float_2;

	private bool bool_0;

	private Enum21 enum21_0;

	private float float_3;

	private float float_4;

	internal Class1307(SparklineGroup sparklineGroup_1, Class1310[] class1310_1, int int_4, int int_5, Bitmap bitmap_1, Interface42 interface42_1)
	{
		sparklineGroup_0 = sparklineGroup_1;
		class1310_0 = class1310_1;
		int_0 = int_4 - Convert.ToInt32((double)int_4 * 0.3 - (double)int_4 * 0.3 / (double)class1310_1.Length * (double)(class1310_1.Length - 1));
		int_1 = int_5 - 8;
		int_2 = int_5;
		int_3 = int_4;
		arrayList_0 = new ArrayList();
		float_2 = new float[class1310_1.Length];
		bitmap_0 = bitmap_1;
		interface42_0 = interface42_1;
		method_0(class1310_1);
	}

	private void method_0(Class1310[] class1310_1)
	{
		int num = class1310_1.Length;
		enum21_0 = Struct86.smethod_1(class1310_1);
		Class1310 @class = null;
		int num2 = int_3 / num;
		for (int i = 0; i < num; i++)
		{
			@class = class1310_1[i];
			if (@class.ToString() == "IsString")
			{
				float_2[i] = 0f;
			}
			else
			{
				float_2[i] = Convert.ToSingle(@class.object_0);
			}
		}
		Struct86.Sort(float_2);
		switch (enum21_0)
		{
		case Enum21.const_0:
		{
			float_3 = float_2[0] - float_2[float_2.Length - 1];
			float_4 = float_2[float_2.Length - 1];
			if (num <= 0)
			{
				break;
			}
			for (int l = 1; l <= num; l++)
			{
				Class1308 class4 = new Class1308();
				if (Struct86.smethod_0(class1310_1[l - 1]))
				{
					class4.float_0 = Convert.ToSingle(num2 * l - num2 / 2);
					class4.float_1 = Convert.ToSingle(class1310_1[l - 1].object_0) - float_2[num - 1];
					arrayList_0.Add(class4);
				}
				else
				{
					class4.float_0 = Convert.ToSingle(num2 * l - num2 / 2);
					class4.float_1 = 1f;
					arrayList_0.Add(class4);
				}
			}
			break;
		}
		case Enum21.const_2:
		{
			float_3 = float_2[float_2.Length - 1] - float_2[0];
			float_4 = float_2[0];
			if (num <= 0)
			{
				break;
			}
			for (int k = 1; k <= num; k++)
			{
				Class1308 class3 = new Class1308();
				if (Struct86.smethod_0(class1310_1[k - 1]))
				{
					class3.float_0 = Convert.ToSingle(num2 * k - num2 / 2);
					class3.float_1 = Convert.ToSingle(class1310_1[k - 1].object_0) - float_2[0];
					arrayList_0.Add(class3);
				}
				else
				{
					class3.float_0 = Convert.ToSingle(num2 * k - num2 / 2);
					class3.float_1 = 1f;
					arrayList_0.Add(class3);
				}
			}
			break;
		}
		case Enum21.const_1:
		{
			float_3 = float_2[0] - float_2[num - 1];
			float_4 = float_2[num - 1];
			if (num <= 0)
			{
				break;
			}
			for (int j = 1; j <= num; j++)
			{
				Class1308 class2 = new Class1308();
				if (Struct86.smethod_0(class1310_1[j - 1]))
				{
					class2.float_0 = Convert.ToSingle(num2 * j - num2 / 2);
					class2.float_1 = Convert.ToSingle(class1310_1[j - 1].object_0) - float_2[num - 1];
					arrayList_0.Add(class2);
				}
				else
				{
					class2.float_0 = Convert.ToSingle(num2 * j - num2 / 2);
					class2.float_1 = 1f;
					arrayList_0.Add(class2);
				}
			}
			break;
		}
		}
	}

	internal Bitmap method_1()
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		switch (enum21_0)
		{
		case Enum21.const_0:
			interface42_0.imethod_49(0f, 0f);
			num = (float)int_1 - Math.Abs((float)int_1 * float_2[float_2.Length - 1] / float_3) + 4f;
			break;
		case Enum21.const_2:
			interface42_0.imethod_49(0f, 0f);
			num = Math.Abs((float)int_1 * float_2[float_2.Length - 1] / float_3) + 4f;
			break;
		case Enum21.const_1:
			interface42_0.imethod_45(180f);
			interface42_0.imethod_49(0f, 0f);
			interface42_0.imethod_46(-1f, 1f);
			interface42_0.imethod_49(0f, -int_2);
			num = Math.Abs((float)int_1 * float_2[float_2.Length - 1] / float_3) + 4f;
			break;
		}
		Class1308 @class = new Class1308();
		@class.float_0 = ((Class1308)arrayList_0[0]).float_0;
		@class.float_1 = ((Class1308)arrayList_0[0]).float_1;
		foreach (Class1308 item in arrayList_0)
		{
			Pen pen = new Pen(Color.FromArgb(255, sparklineGroup_0.SeriesColor.Color));
			switch (enum21_0)
			{
			case Enum21.const_0:
			{
				float num5 = @class.float_0 - float_0;
				float num6 = (float)int_1 - ((float)int_1 * (@class.float_1 - float_1) * (1f / float_3) - 4f);
				float num7 = item.float_0 - float_0;
				float num8 = (float)int_1 - ((float)int_1 * (item.float_1 - float_1) * (1f / float_3) - 4f);
				num2 = num7 - 1f;
				num3 = num8 - 2f;
				num4 = 3f;
				interface42_0.imethod_16(pen, num5, num6, num7, num8);
				if (sparklineGroup_0.ShowMarkers)
				{
					Color color7 = Color.FromArgb(255, sparklineGroup_0.MarkersColor.Color);
					interface42_0.imethod_32(new SolidBrush(color7), num2, num3, num4, num4);
				}
				if (sparklineGroup_0.ShowFirstPoint && item.Equals(arrayList_0[0]))
				{
					Color color8 = Color.FromArgb(255, sparklineGroup_0.FirstPointColor.Color);
					interface42_0.imethod_32(new SolidBrush(color8), num2, num3, num4, num4);
				}
				if (sparklineGroup_0.ShowLastPoint && item.Equals(arrayList_0[arrayList_0.Count - 1]))
				{
					Color color9 = Color.FromArgb(255, sparklineGroup_0.LastPointColor.Color);
					interface42_0.imethod_32(new SolidBrush(color9), num2, num3, num4, num4);
				}
				if (sparklineGroup_0.ShowHighPoint && Convert.ToSingle(float_2[0] - float_4) == item.float_1)
				{
					Color color10 = Color.FromArgb(255, sparklineGroup_0.HighPointColor.Color);
					interface42_0.imethod_32(new SolidBrush(color10), num2, num3, num4, num4);
				}
				if (sparklineGroup_0.ShowLowPoint && Convert.ToSingle(float_2[float_2.Length - 1] - float_4) == item.float_1)
				{
					Color color11 = Color.FromArgb(255, sparklineGroup_0.LowPointColor.Color);
					interface42_0.imethod_32(new SolidBrush(color11), num2, num3, num4, num4);
				}
				if (sparklineGroup_0.ShowNegativePoints && item.float_1 < 0f)
				{
					Color color12 = Color.FromArgb(255, sparklineGroup_0.NegativePointsColor.Color);
					interface42_0.imethod_32(new SolidBrush(color12), num2, num3, num4, num4);
				}
				break;
			}
			case Enum21.const_2:
			{
				float num5 = @class.float_0 - float_0;
				float num6 = (float)int_1 * (@class.float_1 - float_1) / float_3 + 4f;
				float num7 = item.float_0 - float_0;
				float num8 = (float)int_1 * (item.float_1 - float_1) / float_3 + 4f;
				interface42_0.imethod_16(pen, num5, num6, num7, num8);
				num2 = num7 - 1f;
				num3 = num8 - 2f;
				num4 = 3f;
				if (sparklineGroup_0.ShowMarkers)
				{
					Color color13 = Color.FromArgb(255, sparklineGroup_0.MarkersColor.Color);
					interface42_0.imethod_32(new SolidBrush(color13), num2, num3, num4, num4);
				}
				if (sparklineGroup_0.ShowNegativePoints && item.float_1 < 0f)
				{
					Color color14 = Color.FromArgb(255, sparklineGroup_0.NegativePointsColor.Color);
					interface42_0.imethod_32(new SolidBrush(color14), num2, num3, num4, num4);
				}
				if (sparklineGroup_0.ShowFirstPoint && item.Equals(arrayList_0[0]))
				{
					Color color15 = Color.FromArgb(255, sparklineGroup_0.FirstPointColor.Color);
					interface42_0.imethod_32(new SolidBrush(color15), num2, num3, num4, num4);
				}
				if (sparklineGroup_0.ShowHighPoint && Convert.ToInt32(float_2[float_2.Length - 1] - float_4) == Convert.ToInt32(item.float_1))
				{
					Color color16 = Color.FromArgb(255, sparklineGroup_0.HighPointColor.Color);
					interface42_0.imethod_32(new SolidBrush(color16), num2, num3, num4, num4);
				}
				if (sparklineGroup_0.ShowLastPoint && item.Equals(arrayList_0[arrayList_0.Count - 1]))
				{
					Color color17 = Color.FromArgb(255, sparklineGroup_0.LastPointColor.Color);
					interface42_0.imethod_32(new SolidBrush(color17), num2, num3, num4, num4);
				}
				if (sparklineGroup_0.ShowLowPoint && Convert.ToInt32(float_2[0] - float_4) == Convert.ToInt32(item.float_1))
				{
					Color color18 = Color.FromArgb(255, sparklineGroup_0.LowPointColor.Color);
					interface42_0.imethod_32(new SolidBrush(color18), num2, num3, num4, num4);
				}
				break;
			}
			case Enum21.const_1:
			{
				float num5 = @class.float_0 - float_0;
				float num6 = (float)int_1 * (@class.float_1 - float_1) * (1f / float_3) + 4f;
				float num7 = item.float_0 - float_0;
				float num8 = (float)int_1 * (item.float_1 - float_1) * (1f / float_3) + 4f;
				num2 = num7 - 1f;
				num3 = num8 - 2f;
				num4 = 3f;
				interface42_0.imethod_16(pen, num5, num6, num7, num8);
				if (sparklineGroup_0.ShowMarkers)
				{
					Color color = Color.FromArgb(255, sparklineGroup_0.MarkersColor.Color);
					interface42_0.imethod_32(new SolidBrush(color), num2, num3, num4, num4);
				}
				if (sparklineGroup_0.ShowFirstPoint && item.Equals(arrayList_0[0]))
				{
					Color color2 = Color.FromArgb(255, sparklineGroup_0.FirstPointColor.Color);
					interface42_0.imethod_32(new SolidBrush(color2), num2, num3, num4, num4);
				}
				if (sparklineGroup_0.ShowLastPoint && item.Equals(arrayList_0[arrayList_0.Count - 1]))
				{
					Color color3 = Color.FromArgb(255, sparklineGroup_0.LastPointColor.Color);
					interface42_0.imethod_32(new SolidBrush(color3), num2, num3, num4, num4);
				}
				if (sparklineGroup_0.ShowHighPoint && Convert.ToInt32(float_2[0] - float_4) == Convert.ToInt32(item.float_1))
				{
					Color color4 = Color.FromArgb(255, sparklineGroup_0.HighPointColor.Color);
					interface42_0.imethod_32(new SolidBrush(color4), num2, num3, num4, num4);
				}
				if (sparklineGroup_0.ShowLowPoint && Convert.ToInt32(float_2[float_2.Length - 1] - float_4) == Convert.ToInt32(item.float_1))
				{
					Color color5 = Color.FromArgb(255, sparklineGroup_0.LowPointColor.Color);
					interface42_0.imethod_32(new SolidBrush(color5), num2, num3, num4, num4);
				}
				if (sparklineGroup_0.ShowNegativePoints && item.float_1 < 0f)
				{
					Color color6 = Color.FromArgb(255, sparklineGroup_0.NegativePointsColor.Color);
					interface42_0.imethod_32(new SolidBrush(color6), num2, num3, num4, num4);
				}
				break;
			}
			}
			pen.Dispose();
			@class = item;
		}
		if (sparklineGroup_0.ShowHorizontalAxis && enum21_0 == Enum21.const_0)
		{
			Pen pen2 = new Pen(Color.FromArgb(255, sparklineGroup_0.HorizontalAxisColor.Color), 0.5f);
			interface42_0.imethod_16(pen2, 0f, num, int_3, num);
			pen2.Dispose();
		}
		_ = sparklineGroup_0.PlotRightToLeft;
		return bitmap_0;
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
			if (bool_1)
			{
				bitmap_0.Dispose();
				interface42_0.Dispose();
			}
			bool_0 = true;
		}
	}

	~Class1307()
	{
		Dispose(bool_1: false);
	}
}
