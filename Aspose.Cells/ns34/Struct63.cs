using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Aspose.Cells.Render;
using ns19;
using ns22;
using ns3;
using ns33;
using ns47;

namespace ns34;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct63
{
	internal static int int_0 = 80;

	internal static int int_1 = 10;

	internal static int int_2 = 4;

	internal static int int_3 = 5;

	internal static float float_0 = 0.2f;

	internal static void smethod_0(Interface42 interface42_0, Class834 class834_0, ChartType_Chart chartType_Chart_0, Rectangle rectangle_0)
	{
		if (smethod_18(rectangle_0) || class834_0 == null)
		{
			return;
		}
		for (int i = 0; i < class834_0.ilist_2.Count; i++)
		{
			Struct42 @struct = (Struct42)class834_0.ilist_2[i];
			PointF pointF_ = @struct.pointF_0;
			float num = @struct.float_0;
			float float_ = @struct.float_1;
			if (pointF_.IsEmpty || class834_0.DisplayType == Enum68.const_2)
			{
				continue;
			}
			int num2 = 3;
			bool flag = class834_0.vmethod_0();
			if (Struct47.smethod_10(chartType_Chart_0))
			{
				flag = false;
			}
			float num3 = pointF_.X;
			float num4 = pointF_.Y;
			if (flag)
			{
				if (num3 < (float)rectangle_0.Left || num3 > (float)rectangle_0.Right)
				{
					continue;
				}
				if (num4 < (float)rectangle_0.Top)
				{
					num4 = rectangle_0.Top;
				}
				if (num4 > (float)rectangle_0.Bottom)
				{
					num4 = rectangle_0.Bottom;
				}
				if (class834_0.DisplayType == Enum68.const_0 || class834_0.DisplayType == Enum68.const_3)
				{
					float x = pointF_.X;
					float num5 = pointF_.Y - float_;
					if (num5 < (float)rectangle_0.Top)
					{
						num5 = rectangle_0.Top;
					}
					if (num5 > (float)rectangle_0.Bottom)
					{
						num5 = rectangle_0.Bottom;
					}
					if (float_ != 0f)
					{
						class834_0.method_1().method_7(num3, num4, x, num5);
					}
					if (class834_0.ShowMarkerTTop && pointF_.Y - float_ >= (float)rectangle_0.Top && pointF_.Y - float_ <= (float)rectangle_0.Bottom)
					{
						class834_0.method_1().method_7(pointF_.X - (float)num2, pointF_.Y - float_, pointF_.X + (float)num2, pointF_.Y - float_);
					}
				}
				if (class834_0.DisplayType == Enum68.const_0 || class834_0.DisplayType == Enum68.const_1)
				{
					float x = pointF_.X;
					float num5 = pointF_.Y + num;
					if (num5 < (float)rectangle_0.Top)
					{
						num5 = rectangle_0.Top;
					}
					if (num5 > (float)rectangle_0.Bottom)
					{
						num5 = rectangle_0.Bottom;
					}
					if (num != 0f)
					{
						class834_0.method_1().method_7(num3, num4, x, num5);
					}
					if (class834_0.ShowMarkerTTop && pointF_.Y + num >= (float)rectangle_0.Top && pointF_.Y + num <= (float)rectangle_0.Bottom)
					{
						class834_0.method_1().method_7(pointF_.X - (float)num2, pointF_.Y + num, pointF_.X + (float)num2, pointF_.Y + num);
					}
				}
				continue;
			}
			if (num3 < (float)rectangle_0.Left)
			{
				num3 = rectangle_0.Left;
			}
			if (num3 > (float)rectangle_0.Right)
			{
				num3 = rectangle_0.Right;
			}
			if (num4 < (float)rectangle_0.Top || num4 > (float)rectangle_0.Bottom)
			{
				continue;
			}
			if (class834_0.DisplayType == Enum68.const_0 || class834_0.DisplayType == Enum68.const_3)
			{
				float x = pointF_.X + float_;
				float num5 = pointF_.Y;
				if (x < (float)rectangle_0.Left)
				{
					x = rectangle_0.Left;
				}
				if (x > (float)rectangle_0.Right)
				{
					x = rectangle_0.Right;
				}
				if (float_ != 0f)
				{
					class834_0.method_1().method_7(num3, num4, x, num5);
				}
				if (class834_0.ShowMarkerTTop && pointF_.X + float_ >= (float)rectangle_0.Left && pointF_.X + float_ <= (float)rectangle_0.Right)
				{
					class834_0.method_1().method_7(pointF_.X + float_, pointF_.Y - (float)num2, pointF_.X + float_, pointF_.Y + (float)num2);
				}
			}
			if (class834_0.DisplayType == Enum68.const_0 || class834_0.DisplayType == Enum68.const_1)
			{
				float x = pointF_.X - num;
				float num5 = pointF_.Y;
				if (x < (float)rectangle_0.Left)
				{
					x = rectangle_0.Left;
				}
				if (x > (float)rectangle_0.Right)
				{
					x = rectangle_0.Right;
				}
				if (num != 0f)
				{
					class834_0.method_1().method_7(num3, num4, x, num5);
				}
				if (class834_0.ShowMarkerTTop && pointF_.X - num >= (float)rectangle_0.Left && pointF_.X - num <= (float)rectangle_0.Right)
				{
					class834_0.method_1().method_7(pointF_.X - num, pointF_.Y - (float)num2, pointF_.X - num, pointF_.Y + (float)num2);
				}
			}
		}
	}

	internal static void smethod_1(Class823 class823_0, ArrayList arrayList_0, Class842 class842_0)
	{
		if (class823_0.CategoryType != Enum64.const_2 || arrayList_0.Count <= 0 || class842_0.Count <= 0 || (class823_0.imethod_5() && class823_0.imethod_3()))
		{
			return;
		}
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			double num = Struct47.smethod_73(((Class825)arrayList_0[i]).imethod_0(), class823_0.Chart.vmethod_0());
			if (!class823_0.imethod_5() && num > class823_0.MaxValue)
			{
				smethod_2(class842_0, i);
				arrayList_0.RemoveAt(i);
				i--;
			}
			if (!class823_0.imethod_3() && num < class823_0.MinValue)
			{
				smethod_2(class842_0, i);
				arrayList_0.RemoveAt(i);
				i--;
			}
		}
	}

	[Attribute0(true)]
	private static void smethod_2(Class842 class842_0, int int_4)
	{
		for (int i = 0; i < class842_0.Count; i++)
		{
			Class844 @class = class842_0.method_9(i);
			Class830 class2 = @class.method_9();
			if (class2.Count - 1 > int_4)
			{
				class2.RemoveAt(int_4);
			}
		}
	}

	internal static int smethod_3(double double_0)
	{
		return (int)Math.Ceiling(double_0);
	}

	internal static int smethod_4(double double_0)
	{
		return (int)Math.Floor(double_0);
	}

	internal static int smethod_5(double double_0)
	{
		return (int)(double_0 + 0.5);
	}

	internal static void smethod_6(Class823 class823_0, Class823 class823_1, Class842 class842_0, Class844 class844_0)
	{
		if (class844_0.method_29() || class844_0.method_31())
		{
			return;
		}
		if (class823_0.IsLogarithmic && class844_0.method_36())
		{
			for (int i = 0; i < class842_0.Count; i++)
			{
				for (int j = 0; j < class842_0[i].Points.Count; j++)
				{
					Class831 @class = class842_0.method_9(i).method_9().method_1(j);
					if (@class != null)
					{
						if (@class.XValue > 0.0)
						{
							@class.XValue = Math.Log(@class.XValue, class823_0.LogBase);
						}
						else
						{
							@class.imethod_1(bool_11: true);
						}
					}
				}
			}
		}
		if (!class823_1.IsLogarithmic)
		{
			return;
		}
		for (int k = 0; k < class842_0.Count; k++)
		{
			for (int l = 0; l < class842_0[k].Points.Count; l++)
			{
				Class831 class2 = class842_0.method_9(k).method_9().method_1(l);
				if (class2 != null)
				{
					if (class2.YValue > 0.0)
					{
						class2.YValue = Math.Log(class2.YValue, class823_1.LogBase);
					}
					else
					{
						class2.imethod_1(bool_11: true);
					}
				}
			}
		}
	}

	internal static int smethod_7(double double_0)
	{
		char c = Convert.ToChar(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
		int num = 1;
		string text = "";
		string text2 = double_0.ToString();
		int num2 = text2.IndexOf("E");
		int num3 = text2.IndexOf("e");
		if (num2 > 0 || num3 > 0)
		{
			string[] array = ((num2 <= 0) ? text2.Split('e') : text2.Split('E'));
			if (array[0][0] == '-')
			{
				array[0] = array[0].Substring(1);
			}
			int num4 = array[0].IndexOf(c);
			int num5 = Math.Abs(Convert.ToInt32(array[1]));
			if (num4 > 0)
			{
				text = array[0].Substring(0, num4) + array[0].Substring(num4 + 1);
				if (array[1][0] == '-')
				{
					int num6 = num5 - (num4 - 1);
					if (num6 > 0)
					{
						while (num6 > 0)
						{
							text = "0" + text;
							num6--;
						}
						text = text[0].ToString() + c + text.Substring(1);
					}
					else if (num6 < 0)
					{
						text = text.Substring(0, num4 + num6) + c + text.Substring(num4 + num6);
					}
				}
				else
				{
					while (num5 > 0)
					{
						text += "0";
						num5--;
					}
				}
			}
			else
			{
				text = array[0];
				if (array[1][0] == '-')
				{
					int num7 = num5 - (text.Length - 1);
					if (num7 > 0)
					{
						while (num7 > 0)
						{
							text = "0" + text;
							num7--;
						}
						text = text[0].ToString() + c + text.Substring(1);
					}
					else if (num7 < 0)
					{
						text = text.Substring(0, text.Length + num7) + c + text.Substring(text.Length + num7);
					}
				}
				else
				{
					while (num5 > 0)
					{
						text += "0";
						num5--;
					}
				}
			}
			text2 = text;
		}
		int num8 = text2.IndexOf(c, 0);
		if (num8 > 0)
		{
			for (int i = num8 + 1; i < text2.Length; i++)
			{
				num++;
			}
		}
		return num;
	}

	internal static int smethod_8(double[] double_0)
	{
		int num = 0;
		for (int i = 0; i < double_0.Length; i++)
		{
			int num2 = smethod_7(double_0[i]);
			if (num2 > num)
			{
				num = num2;
			}
		}
		return num;
	}

	internal static double smethod_9(double double_0, double double_1)
	{
		int num = smethod_7(double_0);
		int num2 = smethod_7(double_1);
		int int_ = ((num > num2) ? num : num2);
		return smethod_10(double_0 - double_1, int_);
	}

	internal static double smethod_10(double double_0, int int_4)
	{
		if (int_4 > 15)
		{
			double value = double_0 * Math.Pow(10.0, int_4 - 15 - 1);
			double num = Math.Round(value, 15);
			return num * Math.Pow(10.0, 16 - int_4);
		}
		return Math.Round(double_0, int_4);
	}

	internal static double smethod_11(double double_0, double double_1)
	{
		int num = smethod_7(double_0);
		int num2 = smethod_7(double_1);
		int int_ = ((num > num2) ? num : num2);
		return smethod_10(double_0 + double_1, int_);
	}

	internal static int smethod_12(double double_0)
	{
		double num = Math.Log10(double_0);
		bool flag = true;
		if (num < 0.0)
		{
			flag = false;
		}
		num = Math.Abs(num);
		int num2 = smethod_4(num);
		if ((double)num2 != num)
		{
			num2++;
		}
		if (!flag)
		{
			num2 = -num2;
		}
		return num2;
	}

	internal static PointF[] smethod_13(ArrayList arrayList_0)
	{
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			if (arrayList_0[i] == null)
			{
				arrayList_0.RemoveAt(i);
				i--;
			}
		}
		PointF[] array = new PointF[arrayList_0.Count];
		for (int j = 0; j < arrayList_0.Count; j++)
		{
			ref PointF reference = ref array[j];
			reference = (PointF)arrayList_0[j];
		}
		return array;
	}

	internal static bool smethod_14(ref double pointVal, out double valTotal, IList displaySeries, int displayOrder, int pointIndex, double maxValue, double minValue)
	{
		valTotal = 0.0;
		if (pointVal >= 0.0)
		{
			if ((pointVal > 0.0 && maxValue <= 0.0) || (pointVal == 0.0 && maxValue < 0.0))
			{
				pointVal = 0.0;
				valTotal = 0.0;
				return false;
			}
			for (int i = 0; i < displayOrder; i++)
			{
				Class831 @class = ((Class844)displaySeries[i]).method_9().method_1(pointIndex);
				if (@class == null)
				{
					continue;
				}
				double yValue = @class.YValue;
				if (yValue >= 0.0)
				{
					if (!(valTotal + yValue <= maxValue))
					{
						valTotal = maxValue;
						pointVal = 0.0;
						return false;
					}
					valTotal += yValue;
				}
			}
			if (pointVal + valTotal <= maxValue)
			{
				valTotal += pointVal;
			}
			else
			{
				pointVal = maxValue - valTotal;
				valTotal = maxValue;
			}
		}
		else
		{
			if ((pointVal < 0.0 && minValue >= 0.0) || (pointVal == 0.0 && minValue > 0.0))
			{
				pointVal = 0.0;
				valTotal = 0.0;
				return false;
			}
			for (int j = 0; j < displayOrder; j++)
			{
				Class831 class2 = ((Class844)displaySeries[j]).method_9().method_1(pointIndex);
				if (class2 == null)
				{
					continue;
				}
				double yValue2 = class2.YValue;
				if (yValue2 < 0.0)
				{
					if (!(valTotal + yValue2 >= minValue))
					{
						valTotal = minValue;
						pointVal = 0.0;
						return false;
					}
					valTotal += yValue2;
				}
			}
			if (pointVal + valTotal >= minValue)
			{
				valTotal += pointVal;
			}
			else
			{
				pointVal = minValue - valTotal;
				valTotal = minValue;
			}
		}
		return true;
	}

	internal static double smethod_15(IList ilist_0, int int_4)
	{
		double num = 0.0;
		for (int i = 0; i < ilist_0.Count; i++)
		{
			Class831 @class = ((Class844)ilist_0[i]).method_9().method_1(int_4);
			if (@class != null)
			{
				double yValue = @class.YValue;
				num += Math.Abs(yValue);
			}
		}
		return num;
	}

	internal static bool smethod_16(ref double pointVal, out double valTotal, IList displaySeries, int displayOrder, int pointIndex, Class823 valueAxis, double valTotalAll)
	{
		double maxValue = valueAxis.MaxValue * valTotalAll / 100.0;
		double minValue = valueAxis.MinValue * valTotalAll / 100.0;
		return smethod_14(ref pointVal, out valTotal, displaySeries, displayOrder, pointIndex, maxValue, minValue);
	}

	internal static void smethod_17(ref Rectangle rectangle_0)
	{
		if (rectangle_0.Width > rectangle_0.Height)
		{
			rectangle_0.X += (rectangle_0.Width - rectangle_0.Height) / 2;
			rectangle_0.Width = rectangle_0.Height;
		}
		else if (rectangle_0.Height > rectangle_0.Width)
		{
			rectangle_0.Y += (rectangle_0.Height - rectangle_0.Width) / 2;
			rectangle_0.Height = rectangle_0.Width;
		}
	}

	internal static bool smethod_18(Rectangle rectangle_0)
	{
		if (rectangle_0.Width > 0 && rectangle_0.Height > 0)
		{
			return false;
		}
		return true;
	}

	internal static SizeF smethod_19(Size size_0)
	{
		return new SizeF(size_0.Width, size_0.Height);
	}

	internal static RectangleF smethod_20(RectangleF rectangleF_0)
	{
		return new RectangleF(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height);
	}

	internal static Rectangle smethod_21(Rectangle rectangle_0)
	{
		return new Rectangle(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
	}

	internal static DateTime GetDateTimeFromDouble(double double_0, bool bool_0)
	{
		if (double_0 > 2958465.99)
		{
			return DateTime.MaxValue;
		}
		if (bool_0)
		{
			double_0 += 1462.0;
		}
		if (double_0 < 60.0)
		{
			double_0 += 1.0;
		}
		return DateTime.FromOADate(double_0);
	}

	internal static double GetDoubleFromDateTime(DateTime dateTime_0, bool bool_0)
	{
		if (bool_0)
		{
			double totalDays = (dateTime_0 - new DateTime(1904, 1, 1)).TotalDays;
			if (totalDays < 0.0)
			{
				return -1.0;
			}
			return totalDays;
		}
		DateTime dateTime = new DateTime(1900, 3, 1);
		DateTime dateTime2 = ((!((dateTime_0 - dateTime).TotalDays > 0.0)) ? new DateTime(1899, 12, 31) : new DateTime(1899, 12, 30));
		DateTime dateTime3 = new DateTime(9999, 12, 31, 23, 59, 59, 999);
		if ((dateTime3 - dateTime_0).TotalDays < 0.0)
		{
			return -1.0;
		}
		TimeSpan timeSpan = dateTime_0 - dateTime2;
		if (timeSpan.TotalDays < 0.0)
		{
			return -1.0;
		}
		double num = timeSpan.TotalDays;
		if (dateTime_0.Year == 1900 && dateTime_0.Month == 3 && dateTime_0.Day == 1)
		{
			num += 1.0;
		}
		return num;
	}

	internal static int smethod_22(object object_0, int int_4)
	{
		string text = object_0.ToString();
		Regex regex = new Regex("^-?\\d+$");
		if (text == "")
		{
			return int_4;
		}
		if (regex.IsMatch(text))
		{
			return int.Parse(text);
		}
		return int_4;
	}

	internal static Font smethod_23(string string_0, float float_1, FontStyle fontStyle_0)
	{
		try
		{
			return new Font(string_0, float_1, fontStyle_0);
		}
		catch
		{
			Class1460 @class = Class1181.smethod_7(string_0, fontStyle_0);
			return new Font(string_0, float_1, @class.Style);
		}
	}

	internal static Font smethod_24(Font font_0)
	{
		return smethod_23(font_0.Name, font_0.Size, font_0.Style);
	}
}
