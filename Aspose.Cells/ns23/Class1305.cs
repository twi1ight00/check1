using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Cells.Charts;
using ns19;
using ns7;

namespace ns23;

internal class Class1305 : IDisposable
{
	private SparklineGroup sparklineGroup_0;

	private Bitmap bitmap_0;

	private Interface42 interface42_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private ArrayList arrayList_0;

	private float[] float_0;

	private bool bool_0;

	private Enum21 enum21_0;

	private float float_1;

	private float float_2;

	internal Class1305(SparklineGroup sparklineGroup_1, Class1310[] class1310_0, int int_4, int int_5, Bitmap bitmap_1, Interface42 interface42_1)
	{
		sparklineGroup_0 = sparklineGroup_1;
		int_0 = int_4 - Convert.ToInt32((double)int_4 * 0.3 - (double)int_4 * 0.3 / (double)class1310_0.Length * (double)(class1310_0.Length - 1));
		int_1 = int_5 - 8;
		int_2 = int_5;
		int_3 = int_4;
		arrayList_0 = new ArrayList();
		float_0 = new float[class1310_0.Length];
		bitmap_0 = bitmap_1;
		interface42_0 = interface42_1;
		method_0(class1310_0);
	}

	private void method_0(Class1310[] class1310_0)
	{
		int num = class1310_0.Length;
		enum21_0 = Struct86.smethod_1(class1310_0);
		int num2 = int_3 / num;
		Class1310 @class = null;
		for (int i = 0; i < num; i++)
		{
			@class = class1310_0[i];
			if (@class.ToString() == "IsString")
			{
				float_0[i] = 0f;
			}
			else
			{
				float_0[i] = Convert.ToSingle(@class.object_0);
			}
		}
		Struct86.Sort(float_0);
		switch (enum21_0)
		{
		case Enum21.const_0:
		{
			float_1 = float_0[0] - float_0[float_0.Length - 1];
			if (num <= 0)
			{
				break;
			}
			for (int l = 1; l <= num; l++)
			{
				Class1308 class4 = new Class1308();
				if (Struct86.smethod_0(class1310_0[l - 1]))
				{
					class4.float_0 = Convert.ToSingle(num2 * l - num2 / 2);
					class4.float_1 = Convert.ToSingle(class1310_0[l - 1].object_0);
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
			float_1 = Convert.ToInt32(float_0[float_0.Length - 1] - float_0[0]);
			float_2 = float_0[0];
			if (num <= 0)
			{
				break;
			}
			for (int k = 1; k <= num; k++)
			{
				Class1308 class3 = new Class1308();
				if (Struct86.smethod_0(class1310_0[k - 1]))
				{
					class3.float_0 = Convert.ToSingle(num2 * k - num2 / 2);
					class3.float_1 = Convert.ToSingle(class1310_0[k - 1].object_0) - float_0[0];
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
			float_1 = float_0[0] - float_0[num - 1];
			float_2 = float_0[num - 1];
			if (num <= 0)
			{
				break;
			}
			for (int j = 1; j <= num; j++)
			{
				Class1308 class2 = new Class1308();
				if (Struct86.smethod_0(class1310_0[j - 1]))
				{
					class2.float_0 = Convert.ToSingle(num2 * j - num2 / 2);
					class2.float_1 = Convert.ToSingle(class1310_0[j - 1].object_0) - float_0[num - 1];
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
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		switch (enum21_0)
		{
		case Enum21.const_0:
			interface42_0.imethod_45(180f);
			interface42_0.imethod_49(0f, 0f);
			interface42_0.imethod_46(-1f, 1f);
			interface42_0.imethod_49(0f, -int_2);
			num = Math.Abs((float)int_1 * float_0[float_0.Length - 1] / float_1) + 4f;
			break;
		case Enum21.const_2:
			interface42_0.imethod_49(0f, 0f);
			num = Math.Abs((float)int_1 * float_0[float_0.Length - 1] / float_1) + 4f;
			break;
		case Enum21.const_1:
			interface42_0.imethod_45(180f);
			interface42_0.imethod_49(0f, 0f);
			interface42_0.imethod_46(-1f, 1f);
			interface42_0.imethod_49(0f, -int_2);
			num = Math.Abs((float)int_1 * float_0[float_0.Length - 1] / float_1) + 4f;
			break;
		}
		new Class1308();
		float num2 = Convert.ToSingle(((double)int_3 * 0.3 - (double)int_3 * 0.3 / (double)arrayList_0.Count * (double)(arrayList_0.Count - 1)) / 2.0);
		float num3 = Convert.ToSingle((double)int_3 * 0.7 / (double)arrayList_0.Count);
		float num4 = Convert.ToSingle((double)int_3 * 0.3 / (double)arrayList_0.Count);
		int num5 = 0;
		foreach (Class1308 item in arrayList_0)
		{
			float num6 = num2 + (num4 + num3) * (float)num5;
			switch (enum21_0)
			{
			case Enum21.const_0:
			{
				float float_ = Math.Abs((float)int_1 * (item.float_1 / float_1));
				if (sparklineGroup_0.ShowMarkers)
				{
					Color color7 = Color.FromArgb(255, sparklineGroup_0.MarkersColor.Color);
					if (item.float_1 >= 0f)
					{
						interface42_0.imethod_38(new SolidBrush(color7), num6, num, num3, float_);
					}
					else
					{
						float_ = Math.Abs((float)int_1 * item.float_1 / float_1);
						if (float_ < 0f)
						{
							float_ += 1f;
						}
						interface42_0.imethod_38(new SolidBrush(color7), num6, num - float_, num3, Math.Abs(float_));
					}
				}
				if (item.float_1 >= 0f)
				{
					interface42_0.imethod_38(new SolidBrush(Color.FromArgb(255, sparklineGroup_0.SeriesColor.Color)), num6, num, num3, float_);
				}
				else
				{
					float_ = Math.Abs((float)int_1 * item.float_1 / float_1);
					if (float_ < 0f)
					{
						float_ += 1f;
					}
					interface42_0.imethod_38(new SolidBrush(Color.FromArgb(255, sparklineGroup_0.SeriesColor.Color)), num6, num - float_, num3, Math.Abs(float_));
				}
				if (sparklineGroup_0.ShowFirstPoint && item.Equals(arrayList_0[0]))
				{
					Color color8 = Color.FromArgb(255, sparklineGroup_0.FirstPointColor.Color);
					if (item.float_1 >= 0f)
					{
						interface42_0.imethod_38(new SolidBrush(color8), num6, num, num3, float_);
					}
					else
					{
						float_ = Math.Abs((float)int_1 * item.float_1 / float_1);
						if (float_ < 0f)
						{
							float_ += 1f;
						}
						interface42_0.imethod_38(new SolidBrush(color8), num6, num - float_, num3, Math.Abs(float_));
					}
				}
				if (sparklineGroup_0.ShowLastPoint && item.Equals(arrayList_0[arrayList_0.Count - 1]))
				{
					Color color9 = Color.FromArgb(255, sparklineGroup_0.LastPointColor.Color);
					if (item.float_1 >= 0f)
					{
						interface42_0.imethod_38(new SolidBrush(color9), num6, num, num3, float_);
					}
					else
					{
						float_ = Math.Abs((float)int_1 * item.float_1 / float_1);
						if (float_ < 0f)
						{
							float_ += 1f;
						}
						interface42_0.imethod_38(new SolidBrush(color9), num6, num - float_, num3, Math.Abs(float_));
					}
				}
				if (sparklineGroup_0.ShowHighPoint && Convert.ToSingle(float_0[0]) == (float)Convert.ToInt32(item.float_1))
				{
					Color color10 = Color.FromArgb(255, sparklineGroup_0.HighPointColor.Color);
					if (item.float_1 >= 0f)
					{
						interface42_0.imethod_38(new SolidBrush(color10), num6, num, num3, float_);
					}
					else
					{
						float_ = Math.Abs((float)int_1 * item.float_1 / float_1);
						if (float_ < 0f)
						{
							float_ += 1f;
						}
						interface42_0.imethod_38(new SolidBrush(color10), num6, num - float_, num3, Math.Abs(float_));
					}
				}
				if (sparklineGroup_0.ShowLowPoint && Convert.ToSingle(float_0[float_0.Length - 1]) == (float)Convert.ToInt32(item.float_1))
				{
					Color color11 = Color.FromArgb(255, sparklineGroup_0.LowPointColor.Color);
					if (item.float_1 >= 0f)
					{
						interface42_0.imethod_38(new SolidBrush(color11), num6, num, num3, float_);
					}
					else
					{
						float_ = Math.Abs((float)int_1 * item.float_1 / float_1);
						if (float_ < 0f)
						{
							float_ += 1f;
						}
						interface42_0.imethod_38(new SolidBrush(color11), num6, num - float_, num3, Math.Abs(float_));
					}
				}
				if (!sparklineGroup_0.ShowNegativePoints || !(item.float_1 < 0f))
				{
					break;
				}
				Color color12 = Color.FromArgb(255, sparklineGroup_0.NegativePointsColor.Color);
				if (item.float_1 >= 0f)
				{
					interface42_0.imethod_38(new SolidBrush(color12), num6, num, num3, float_);
					break;
				}
				float_ = Math.Abs((float)int_1 * item.float_1 / float_1);
				if (float_ < 0f)
				{
					float_ += 1f;
				}
				interface42_0.imethod_38(new SolidBrush(color12), num6, num - float_, num3, Math.Abs(float_));
				break;
			}
			case Enum21.const_2:
			{
				float float_ = Math.Abs((float)int_1 * item.float_1 / float_1 + 1f);
				if (sparklineGroup_0.ShowMarkers)
				{
					Color color13 = Color.FromArgb(255, sparklineGroup_0.MarkersColor.Color);
					interface42_0.imethod_38(new SolidBrush(color13), num6, 4f, num3, float_);
				}
				interface42_0.imethod_38(new SolidBrush(Color.FromArgb(255, sparklineGroup_0.SeriesColor.Color)), num6, 4f, num3, float_);
				if (sparklineGroup_0.ShowNegativePoints && item.float_1 < 0f)
				{
					Color color14 = Color.FromArgb(255, sparklineGroup_0.NegativePointsColor.Color);
					interface42_0.imethod_38(new SolidBrush(color14), num6, 4f, num3, float_);
				}
				if (sparklineGroup_0.ShowFirstPoint && item.Equals(arrayList_0[0]))
				{
					Color color15 = Color.FromArgb(255, sparklineGroup_0.FirstPointColor.Color);
					interface42_0.imethod_38(new SolidBrush(color15), num6, 4f, num3, float_);
				}
				if (sparklineGroup_0.ShowHighPoint && Convert.ToInt32(float_0[0] - float_2) == Convert.ToInt32(item.float_1))
				{
					Color color16 = Color.FromArgb(255, sparklineGroup_0.HighPointColor.Color);
					interface42_0.imethod_38(new SolidBrush(color16), num6, 4f, num3, float_);
				}
				if (sparklineGroup_0.ShowLastPoint && item.Equals(arrayList_0[arrayList_0.Count - 1]))
				{
					Color color17 = Color.FromArgb(255, sparklineGroup_0.LastPointColor.Color);
					interface42_0.imethod_38(new SolidBrush(color17), num6, 4f, num3, float_);
				}
				if (sparklineGroup_0.ShowLowPoint && Convert.ToInt32(float_0[float_0.Length - 1] - float_2) == Convert.ToInt32(item.float_1))
				{
					Color color18 = Color.FromArgb(255, sparklineGroup_0.LowPointColor.Color);
					interface42_0.imethod_38(new SolidBrush(color18), num6, 4f, num3, float_);
				}
				break;
			}
			case Enum21.const_1:
			{
				float float_ = Math.Abs((float)int_1 * item.float_1 / float_1 + 1f);
				if (sparklineGroup_0.ShowMarkers)
				{
					Color color = Color.FromArgb(255, sparklineGroup_0.MarkersColor.Color);
					interface42_0.imethod_38(new SolidBrush(color), num6, 0f, num3, float_);
				}
				interface42_0.imethod_38(new SolidBrush(Color.FromArgb(255, sparklineGroup_0.SeriesColor.Color)), num6, 4f, num3, float_);
				if (sparklineGroup_0.ShowFirstPoint && item.Equals(arrayList_0[0]))
				{
					Color color2 = Color.FromArgb(255, sparklineGroup_0.FirstPointColor.Color);
					interface42_0.imethod_38(new SolidBrush(color2), num6, 4f, num3, float_);
				}
				if (sparklineGroup_0.ShowLastPoint && item.Equals(arrayList_0[arrayList_0.Count - 1]))
				{
					Color color3 = Color.FromArgb(255, sparklineGroup_0.LastPointColor.Color);
					interface42_0.imethod_38(new SolidBrush(color3), num6, 4f, num3, float_);
				}
				if (sparklineGroup_0.ShowHighPoint && Convert.ToInt32(float_0[0] - float_2) == Convert.ToInt32(item.float_1))
				{
					Color color4 = Color.FromArgb(255, sparklineGroup_0.HighPointColor.Color);
					interface42_0.imethod_38(new SolidBrush(color4), num6, 4f, num3, float_);
				}
				if (sparklineGroup_0.ShowLowPoint && Convert.ToInt32(float_0[float_0.Length - 1] - float_2) == Convert.ToInt32(item.float_1))
				{
					Color color5 = Color.FromArgb(255, sparklineGroup_0.LowPointColor.Color);
					interface42_0.imethod_38(new SolidBrush(color5), num6, 4f, num3, float_);
				}
				if (sparklineGroup_0.ShowNegativePoints && item.float_1 < 0f)
				{
					Color color6 = Color.FromArgb(255, sparklineGroup_0.NegativePointsColor.Color);
					interface42_0.imethod_38(new SolidBrush(color6), num6, 4f, num3, float_);
				}
				break;
			}
			}
			num5++;
		}
		if (sparklineGroup_0.ShowHorizontalAxis && enum21_0 == Enum21.const_0)
		{
			Pen pen = new Pen(Color.FromArgb(255, sparklineGroup_0.HorizontalAxisColor.Color), 0.5f);
			interface42_0.imethod_16(pen, 0f, num, int_3, num);
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

	~Class1305()
	{
		Dispose(bool_1: false);
	}
}
