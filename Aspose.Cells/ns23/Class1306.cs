using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Cells.Charts;
using ns19;
using ns7;

namespace ns23;

internal class Class1306 : IDisposable
{
	private SparklineGroup sparklineGroup_0;

	private Bitmap bitmap_0;

	private Interface42 interface42_0;

	private Enum21 enum21_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private float float_0;

	private float float_1;

	private float float_2;

	private ArrayList arrayList_0;

	private float[] float_3;

	private bool bool_0;

	private float float_4;

	internal Class1306(SparklineGroup sparklineGroup_1, Class1310[] class1310_0, int int_4, int int_5, Bitmap bitmap_1, Interface42 interface42_1)
	{
		int num = class1310_0.Length;
		sparklineGroup_0 = sparklineGroup_1;
		int_0 = int_4 - Convert.ToInt32((double)int_4 * 0.3 - (double)int_4 * 0.3 / (double)num * (double)(num - 1));
		int_1 = int_5 - 8;
		int_2 = int_5;
		int_3 = int_4;
		arrayList_0 = new ArrayList();
		float_3 = new float[num];
		bitmap_0 = bitmap_1;
		float_2 = (float)int_3 * 0.7f / (float)num;
		float_0 = (float)int_3 * 0.3f / (float)num;
		float_1 = Convert.ToSingle(((float)int_3 * 0.3f - (float)int_3 * 0.3f / (float)num * (float)(num - 1)) / 2f);
		interface42_0 = interface42_1;
		method_0(class1310_0);
	}

	private void method_0(Class1310[] class1310_0)
	{
		enum21_0 = Struct86.smethod_1(class1310_0);
		int num = class1310_0.Length;
		Class1310 @class = null;
		for (int i = 0; i < num; i++)
		{
			@class = class1310_0[i];
			if (@class.ToString() == "IsString")
			{
				float_3[i] = 0f;
			}
			else
			{
				float_3[i] = Convert.ToSingle(@class.object_0);
			}
		}
		Struct86.Sort(float_3);
		switch (enum21_0)
		{
		case Enum21.const_0:
		{
			float_4 = Convert.ToInt32(float_3[0]);
			if (num <= 0)
			{
				break;
			}
			for (int l = 1; l <= num; l++)
			{
				Class1308 class4 = new Class1308();
				if (Struct86.smethod_0(class1310_0[l - 1]))
				{
					class4.float_0 = float_1 + (float_0 + float_2) * (float)(l - 1);
					class4.float_1 = Convert.ToSingle(class1310_0[l - 1].object_0);
					arrayList_0.Add(class4);
				}
				else
				{
					class4.float_0 = float_1 + (float_0 + float_2) * (float)(l - 1);
					class4.float_1 = 1f;
					arrayList_0.Add(class4);
				}
			}
			break;
		}
		case Enum21.const_2:
		{
			if (num <= 0)
			{
				break;
			}
			for (int k = 1; k <= num; k++)
			{
				Class1308 class3 = new Class1308();
				if (Struct86.smethod_0(class1310_0[k - 1]))
				{
					class3.float_0 = float_1 + (float_0 + float_2) * (float)(k - 1);
					class3.float_1 = Convert.ToSingle(class1310_0[k - 1].object_0);
					arrayList_0.Add(class3);
				}
				else
				{
					class3.float_0 = float_1 + (float_0 + float_2) * (float)(k - 1);
					class3.float_1 = 1f;
					arrayList_0.Add(class3);
				}
			}
			break;
		}
		case Enum21.const_1:
		{
			if (num <= 0)
			{
				break;
			}
			for (int j = 1; j <= num; j++)
			{
				Class1308 class2 = new Class1308();
				if (Struct86.smethod_0(class1310_0[j - 1]))
				{
					class2.float_0 = float_1 + (float_0 + float_2) * (float)(j - 1);
					class2.float_1 = Convert.ToSingle(class1310_0[j - 1].object_0);
					arrayList_0.Add(class2);
				}
				else
				{
					class2.float_0 = float_1 + (float_0 + float_2) * (float)(j - 1);
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
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		switch (enum21_0)
		{
		case Enum21.const_0:
			interface42_0.imethod_45(180f);
			interface42_0.imethod_49(0f, 0f);
			interface42_0.imethod_46(-1f, 1f);
			interface42_0.imethod_49(0f, -int_2);
			break;
		case Enum21.const_2:
			interface42_0.imethod_45(180f);
			interface42_0.imethod_49(0f, 0f);
			interface42_0.imethod_46(-1f, 1f);
			interface42_0.imethod_49(0f, -int_2);
			break;
		}
		foreach (Class1308 item in arrayList_0)
		{
			float num3 = item.float_0;
			num = int_1 / 2;
			switch (enum21_0)
			{
			case Enum21.const_0:
				num2 = Math.Abs(num) + 4f;
				if (sparklineGroup_0.ShowMarkers)
				{
					Color color7 = Color.FromArgb(255, sparklineGroup_0.MarkersColor.Color);
					if (item.float_1 > 0f)
					{
						interface42_0.imethod_38(new SolidBrush(color7), num3, num2, float_2, num);
					}
					else if (item.float_1 == 0f)
					{
						interface42_0.imethod_38(new SolidBrush(color7), num3, num2, float_2, item.float_1);
					}
					else
					{
						interface42_0.imethod_38(new SolidBrush(color7), num3, num2 - num, float_2, num);
					}
				}
				if (item.float_1 > 0f)
				{
					interface42_0.imethod_38(new SolidBrush(Color.FromArgb(255, sparklineGroup_0.SeriesColor.Color)), num3, num2, float_2, num);
				}
				else if (item.float_1 == 0f)
				{
					interface42_0.imethod_38(new SolidBrush(Color.FromArgb(255, sparklineGroup_0.SeriesColor.Color)), num3, num2, float_2, item.float_1);
				}
				else
				{
					interface42_0.imethod_38(new SolidBrush(Color.FromArgb(255, sparklineGroup_0.SeriesColor.Color)), num3, num2 - num, float_2, num);
				}
				if (sparklineGroup_0.ShowFirstPoint && item.Equals(arrayList_0[0]))
				{
					Color color8 = Color.FromArgb(255, sparklineGroup_0.FirstPointColor.Color);
					if (item.float_1 > 0f)
					{
						interface42_0.imethod_38(new SolidBrush(color8), num3, num2, float_2, num);
					}
					else if (item.float_1 == 0f)
					{
						interface42_0.imethod_38(new SolidBrush(color8), num3, num2, float_2, item.float_1);
					}
					else
					{
						interface42_0.imethod_38(new SolidBrush(color8), num3, num2 - num, float_2, num);
					}
				}
				if (sparklineGroup_0.ShowLastPoint && item.Equals(arrayList_0[arrayList_0.Count - 1]))
				{
					Color color9 = Color.FromArgb(255, sparklineGroup_0.LastPointColor.Color);
					if (item.float_1 > 0f)
					{
						interface42_0.imethod_38(new SolidBrush(color9), num3, num2, float_2, num);
					}
					else if (item.float_1 == 0f)
					{
						interface42_0.imethod_38(new SolidBrush(color9), num3, num2, float_2, item.float_1);
					}
					else
					{
						interface42_0.imethod_38(new SolidBrush(color9), num3, num2 - num, float_2, num);
					}
				}
				if (sparklineGroup_0.ShowHighPoint && Convert.ToInt32(float_3[0]) == Convert.ToInt32(item.float_1))
				{
					Color color10 = Color.FromArgb(255, sparklineGroup_0.HighPointColor.Color);
					if (item.float_1 > 0f)
					{
						interface42_0.imethod_38(new SolidBrush(color10), num3, num2, float_2, num);
					}
					else if (item.float_1 == 0f)
					{
						interface42_0.imethod_38(new SolidBrush(color10), num3, num2, float_2, item.float_1);
					}
					else
					{
						interface42_0.imethod_38(new SolidBrush(color10), num3, num2 - num, float_2, num);
					}
				}
				if (sparklineGroup_0.ShowLowPoint && Convert.ToInt32(float_3[float_3.Length - 1]) == Convert.ToInt32(item.float_1))
				{
					Color color11 = Color.FromArgb(255, sparklineGroup_0.LowPointColor.Color);
					if (item.float_1 > 0f)
					{
						interface42_0.imethod_38(new SolidBrush(color11), num3, num2, float_2, num);
					}
					else if (item.float_1 == 0f)
					{
						interface42_0.imethod_38(new SolidBrush(color11), num3, num2, float_2, item.float_1);
					}
					else
					{
						interface42_0.imethod_38(new SolidBrush(color11), num3, num2 - num, float_2, num);
					}
				}
				if (sparklineGroup_0.ShowNegativePoints && item.float_1 < 0f)
				{
					Color color12 = Color.FromArgb(255, sparklineGroup_0.NegativePointsColor.Color);
					if (item.float_1 > 0f)
					{
						interface42_0.imethod_38(new SolidBrush(color12), num3, num2, float_2, num);
					}
					else if (item.float_1 == 0f)
					{
						interface42_0.imethod_38(new SolidBrush(color12), num3, num2, float_2, item.float_1);
					}
					else
					{
						interface42_0.imethod_38(new SolidBrush(color12), num3, num2 - num, float_2, num);
					}
				}
				break;
			case Enum21.const_2:
				if (sparklineGroup_0.ShowMarkers)
				{
					Color color13 = Color.FromArgb(255, sparklineGroup_0.MarkersColor.Color);
					interface42_0.imethod_38(new SolidBrush(color13), num3, 5f, float_2, num);
				}
				interface42_0.imethod_38(new SolidBrush(Color.FromArgb(255, sparklineGroup_0.SeriesColor.Color)), num3, 5f, float_2, num);
				if (sparklineGroup_0.ShowNegativePoints && item.float_1 < 0f)
				{
					Color color14 = Color.FromArgb(255, sparklineGroup_0.NegativePointsColor.Color);
					interface42_0.imethod_38(new SolidBrush(color14), num3, 5f, float_2, num);
				}
				if (sparklineGroup_0.ShowFirstPoint && item.Equals(arrayList_0[0]))
				{
					Color color15 = Color.FromArgb(255, sparklineGroup_0.FirstPointColor.Color);
					interface42_0.imethod_38(new SolidBrush(color15), num3, 5f, float_2, num);
				}
				if (sparklineGroup_0.ShowLastPoint && item.Equals(arrayList_0[arrayList_0.Count - 1]))
				{
					Color color16 = Color.FromArgb(255, sparklineGroup_0.LastPointColor.Color);
					interface42_0.imethod_38(new SolidBrush(color16), num3, 5f, float_2, num);
				}
				if (sparklineGroup_0.ShowHighPoint && Convert.ToInt32(float_3[float_3.Length - 1]) == Convert.ToInt32(item.float_1))
				{
					Color color17 = Color.FromArgb(255, sparklineGroup_0.HighPointColor.Color);
					interface42_0.imethod_38(new SolidBrush(color17), num3, 5f, float_2, num);
				}
				if (sparklineGroup_0.ShowLowPoint && Convert.ToInt32(float_3[0]) == Convert.ToInt32(item.float_1))
				{
					Color color18 = Color.FromArgb(255, sparklineGroup_0.LowPointColor.Color);
					interface42_0.imethod_38(new SolidBrush(color18), num3, 5f, float_2, num);
				}
				break;
			case Enum21.const_1:
			{
				float num4 = 4.5f;
				if (sparklineGroup_0.ShowMarkers)
				{
					Color color = Color.FromArgb(255, sparklineGroup_0.MarkersColor.Color);
					if (item.float_1 > 0f)
					{
						interface42_0.imethod_38(new SolidBrush(color), num3, num4, float_2, num);
					}
					else
					{
						interface42_0.imethod_38(new SolidBrush(color), num3, num4, float_2, item.float_1);
					}
				}
				if (item.float_1 > 0f)
				{
					interface42_0.imethod_38(new SolidBrush(Color.FromArgb(255, sparklineGroup_0.SeriesColor.Color)), num3, num4, float_2, num);
				}
				else
				{
					interface42_0.imethod_38(new SolidBrush(Color.FromArgb(255, sparklineGroup_0.SeriesColor.Color)), num3, num4, float_2, item.float_1);
				}
				if (sparklineGroup_0.ShowFirstPoint && item.Equals(arrayList_0[0]))
				{
					Color color2 = Color.FromArgb(255, sparklineGroup_0.FirstPointColor.Color);
					if (item.float_1 > 0f)
					{
						interface42_0.imethod_38(new SolidBrush(color2), num3, num4, float_2, num);
					}
					else
					{
						interface42_0.imethod_38(new SolidBrush(color2), num3, num4, float_2, item.float_1);
					}
				}
				if (sparklineGroup_0.ShowLastPoint && item.Equals(arrayList_0[arrayList_0.Count - 1]))
				{
					Color color3 = Color.FromArgb(255, sparklineGroup_0.LastPointColor.Color);
					if (item.float_1 > 0f)
					{
						interface42_0.imethod_38(new SolidBrush(color3), num3, num4, float_2, num);
					}
					else
					{
						interface42_0.imethod_38(new SolidBrush(color3), num3, num4, float_2, item.float_1);
					}
				}
				if (sparklineGroup_0.ShowHighPoint && Convert.ToInt32(float_3[0]) == Convert.ToInt32(item.float_1))
				{
					Color color4 = Color.FromArgb(255, sparklineGroup_0.HighPointColor.Color);
					if (item.float_1 > 0f)
					{
						interface42_0.imethod_38(new SolidBrush(color4), num3, num4, float_2, num);
					}
					else
					{
						interface42_0.imethod_38(new SolidBrush(color4), num3, num4, float_2, item.float_1);
					}
				}
				if (sparklineGroup_0.ShowLowPoint && Convert.ToInt32(float_3[float_3.Length - 1]) == Convert.ToInt32(item.float_1))
				{
					Color color5 = Color.FromArgb(255, sparklineGroup_0.LowPointColor.Color);
					if (item.float_1 > 0f)
					{
						interface42_0.imethod_38(new SolidBrush(color5), num3, num4, float_2, num);
					}
					else
					{
						interface42_0.imethod_38(new SolidBrush(color5), num3, num4, float_2, item.float_1);
					}
				}
				if (sparklineGroup_0.ShowNegativePoints && item.float_1 < 0f)
				{
					Color color6 = Color.FromArgb(255, sparklineGroup_0.NegativePointsColor.Color);
					if (item.float_1 > 0f)
					{
						interface42_0.imethod_38(new SolidBrush(color6), num3, num4, float_2, num);
					}
					else
					{
						interface42_0.imethod_38(new SolidBrush(color6), num3, num4, float_2, item.float_1);
					}
				}
				break;
			}
			}
		}
		if (sparklineGroup_0.ShowHorizontalAxis)
		{
			Pen pen = new Pen(Color.FromArgb(255, sparklineGroup_0.HorizontalAxisColor.Color), 0.5f);
			interface42_0.imethod_16(pen, 0f, (float)(int_1 / 2) + 4f, int_3, (float)(int_1 / 2) + 4f);
			pen.Dispose();
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

	~Class1306()
	{
		Dispose(bool_1: false);
	}
}
