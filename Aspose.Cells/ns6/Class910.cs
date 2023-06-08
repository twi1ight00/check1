using System.Collections;
using System.Drawing;
using System.Text.RegularExpressions;
using ns19;

namespace ns6;

internal class Class910
{
	private Interface42 interface42_0;

	private RectangleF rectangleF_0;

	private Class908 class908_0;

	private Font font_0;

	private float float_0;

	private float float_1;

	private float float_2;

	private ArrayList arrayList_0;

	public Class910(RectangleF rectangleF_1, Class908 class908_1, ArrayList arrayList_1, Font font_1)
		: this(rectangleF_1, class908_1, arrayList_1, font_1, 1f, 1f)
	{
	}

	public Class910(RectangleF rectangleF_1, Class908 class908_1, ArrayList arrayList_1, Font font_1, float float_3, float float_4)
	{
		rectangleF_0 = rectangleF_1;
		class908_0 = class908_1;
		arrayList_0 = arrayList_1;
		font_0 = font_1;
		float_1 = float_3;
		float_2 = float_4;
	}

	public void method_0(Interface42 interface42_1)
	{
		interface42_0 = interface42_1;
		float_0 = interface42_0.imethod_39("A", font_0).Height * float_2;
		if (!method_1() || arrayList_0 == null || arrayList_0.Count <= 0)
		{
			return;
		}
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = class908_0.TextHorizontalAlignment;
		stringFormat.LineAlignment = class908_0.TextVerticalAlignment;
		method_2(arrayList_0);
		if (class908_0.TextVerticalAlignment == StringAlignment.Near)
		{
			if (class908_0.TextHorizontalAlignment == StringAlignment.Near)
			{
				method_5(arrayList_0);
				method_7(arrayList_0);
			}
			else if (class908_0.TextHorizontalAlignment == StringAlignment.Center)
			{
				method_5(arrayList_0);
				method_6(arrayList_0, bool_0: true);
				method_7(arrayList_0);
			}
			else
			{
				method_5(arrayList_0);
				method_6(arrayList_0, bool_0: false);
				method_7(arrayList_0);
			}
		}
		else if (class908_0.TextVerticalAlignment == StringAlignment.Far)
		{
			if (class908_0.TextHorizontalAlignment == StringAlignment.Near)
			{
				method_5(arrayList_0);
				method_8(arrayList_0, bool_0: false);
				method_7(arrayList_0);
			}
			else if (class908_0.TextHorizontalAlignment == StringAlignment.Center)
			{
				method_5(arrayList_0);
				method_6(arrayList_0, bool_0: true);
				method_8(arrayList_0, bool_0: false);
				method_7(arrayList_0);
			}
			else
			{
				method_5(arrayList_0);
				method_6(arrayList_0, bool_0: false);
				method_8(arrayList_0, bool_0: false);
				method_7(arrayList_0);
			}
		}
		else if (class908_0.TextHorizontalAlignment == StringAlignment.Near)
		{
			method_5(arrayList_0);
			method_8(arrayList_0, bool_0: true);
			method_7(arrayList_0);
		}
		else if (class908_0.TextHorizontalAlignment == StringAlignment.Center)
		{
			method_5(arrayList_0);
			method_6(arrayList_0, bool_0: true);
			method_8(arrayList_0, bool_0: true);
			method_7(arrayList_0);
		}
		else
		{
			method_5(arrayList_0);
			method_6(arrayList_0, bool_0: false);
			method_8(arrayList_0, bool_0: true);
			method_7(arrayList_0);
		}
		RectangleF rectangleF = new RectangleF(rectangleF_0.X - 4f, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height);
		interface42_0.imethod_48(rectangleF);
		foreach (Class909 item in arrayList_0)
		{
			if (item.enum125_0 == Enum125.const_2)
			{
				Font font = item.Font;
				int num = method_9(font);
				float num2 = num * font.FontFamily.GetCellAscent(font.Style) / font.FontFamily.GetEmHeight(font.Style);
				float num3 = num * font.FontFamily.GetCellDescent(font.Style) / font.FontFamily.GetEmHeight(font.Style);
				float num4 = num * font.FontFamily.GetLineSpacing(font.Style) / font.FontFamily.GetEmHeight(font.Style);
				item.rectangleF_0.X -= num4 - num2 - num3;
				StringFormat stringFormat_ = new StringFormat(StringFormat.GenericTypographic);
				interface42_0.imethod_26(item.Text, item.Font, new SolidBrush(item.FontColor), item.rectangleF_0.Location, stringFormat_);
			}
		}
		interface42_0.ResetClip();
	}

	private bool method_1()
	{
		if (!(rectangleF_0.Width <= 0f) && rectangleF_0.Height > 0f)
		{
			return true;
		}
		return false;
	}

	private void method_2(ArrayList arrayList_1)
	{
		Regex regex = new Regex("\\n");
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			Class909 @class = (Class909)arrayList_1[i];
			string[] array = regex.Split(@class.Text);
			if (array.Length <= 1)
			{
				continue;
			}
			for (int j = 0; j < array.Length; j++)
			{
				if (array[j] != "")
				{
					Class909 value = new Class909(array[j], @class.Font, @class.FontColor, Enum125.const_2);
					arrayList_1.Insert(i, value);
					i++;
				}
				else if (array[j] == "" && j == array.Length - 1)
				{
					break;
				}
				if (j != array.Length - 1)
				{
					Class909 value = new Class909("", @class.Font, @class.FontColor, Enum125.const_0);
					arrayList_1.Insert(i, value);
					i++;
				}
			}
			arrayList_1.RemoveAt(i);
			i--;
		}
		Regex regex2 = new Regex("(\\s){1,}");
		for (int k = 0; k < arrayList_1.Count; k++)
		{
			Class909 class2 = (Class909)arrayList_1[k];
			MatchCollection matchCollection = regex2.Matches(class2.Text);
			if (matchCollection.Count <= 0)
			{
				continue;
			}
			int num = 0;
			for (int l = 0; l < matchCollection.Count; l++)
			{
				Class909 value2;
				if (matchCollection[l].Index > num)
				{
					string string_ = class2.Text.Substring(num, matchCollection[l].Index - num);
					value2 = new Class909(string_, class2.Font, class2.FontColor, Enum125.const_2);
					arrayList_1.Insert(k, value2);
					k++;
				}
				value2 = new Class909(matchCollection[l].Value, class2.Font, class2.FontColor, Enum125.const_1);
				arrayList_1.Insert(k, value2);
				k++;
				num = matchCollection[l].Index + matchCollection[l].Value.Length;
				if (l == matchCollection.Count - 1 && num <= class2.Text.Length - 1)
				{
					string string_2 = class2.Text.Substring(num, class2.Text.Length - num);
					value2 = new Class909(string_2, class2.Font, class2.FontColor, Enum125.const_2);
					arrayList_1.Insert(k, value2);
					k++;
				}
			}
			arrayList_1.RemoveAt(k);
			k--;
		}
		StringFormat stringFormat = new StringFormat();
		stringFormat.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
		for (int m = 0; m < arrayList_1.Count; m++)
		{
			Class909 class3 = (Class909)arrayList_1[m];
			if (class3.enum125_0 != 0)
			{
				SizeF sizeF_ = method_4(class3.Text, class3.Font);
				sizeF_.Width *= float_1;
				sizeF_.Height *= float_2;
				class3.sizeF_0 = sizeF_;
			}
			else
			{
				SizeF sizeF_2 = method_4("A", class3.Font);
				sizeF_2.Width *= float_1;
				sizeF_2.Height *= float_2;
				class3.sizeF_0 = sizeF_2;
			}
		}
	}

	private string[] method_3(string string_0, float float_3, Font font_1)
	{
		if (string_0 != null && string_0.Length >= 1)
		{
			string[] array = new string[2];
			if (string_0.Length == 1)
			{
				return new string[2] { string_0, "" };
			}
			for (int i = 1; i <= string_0.Length; i++)
			{
				string string_ = string_0.Substring(0, i);
				if (!(method_4(string_, font_1).Width <= float_3))
				{
					array[0] = string_0.Substring(0, i - 1);
					array[1] = string_0.Substring((i - 2 > 0) ? (i - 2) : (i - 1));
					break;
				}
			}
			return array;
		}
		return new string[2] { "", "" };
	}

	private SizeF method_4(string string_0, Font font_1)
	{
		return Struct72.smethod_8(interface42_0, string_0, font_1, new SizeF(2.1474836E+09f, 2.1474836E+09f));
	}

	private void method_5(ArrayList arrayList_1)
	{
		PointF location = rectangleF_0.Location;
		float num = float.MinValue;
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			Class909 @class = (Class909)arrayList_1[i];
			float num2 = rectangleF_0.Right - location.X;
			if (@class.enum125_0 == Enum125.const_0)
			{
				@class.rectangleF_0 = new RectangleF(rectangleF_0.X, location.Y, rectangleF_0.Width, @class.sizeF_0.Height);
				location.X = rectangleF_0.Location.X;
				location.Y += ((num == float.MinValue) ? @class.sizeF_0.Height : num);
				num = float.MinValue;
			}
			else if (@class.enum125_0 == Enum125.const_1)
			{
				if (@class.sizeF_0.Width < num2)
				{
					@class.rectangleF_0.Location = location;
					@class.rectangleF_0.Size = @class.sizeF_0;
					location.X += @class.sizeF_0.Width;
					continue;
				}
				@class.sizeF_0.Width = num2;
				@class.rectangleF_0.Location = location;
				@class.rectangleF_0.Size = @class.sizeF_0;
				location.X = rectangleF_0.X;
				location.Y += ((num == float.MinValue) ? float_0 : num);
				num = float.MinValue;
			}
			else
			{
				if (@class.enum125_0 != Enum125.const_2)
				{
					continue;
				}
				Class909 class2 = null;
				Class909 class3 = null;
				if (i > 0)
				{
					class2 = (Class909)arrayList_1[i - 1];
				}
				if (i + 1 < arrayList_1.Count)
				{
					class3 = (Class909)arrayList_1[i + 1];
				}
				if (class2 != null && class2.enum125_0 == Enum125.const_1)
				{
					if (@class.sizeF_0.Width <= num2)
					{
						float num3 = @class.sizeF_0.Width;
						int j;
						for (j = i + 1; j < arrayList_1.Count; j++)
						{
							if (class3.enum125_0 != Enum125.const_2)
							{
								break;
							}
							class3 = (Class909)arrayList_1[j];
							if (class3.enum125_0 != Enum125.const_2 || method_10(class3.Text))
							{
								break;
							}
							num3 += class3.sizeF_0.Width;
							if (num3 > num2)
							{
								break;
							}
						}
						if (num3 < num2)
						{
							for (; i < j; i++)
							{
								class3 = (Class909)arrayList_1[i];
								class3.rectangleF_0.Location = location;
								class3.rectangleF_0.Size = class3.sizeF_0;
								if (num < class3.sizeF_0.Height)
								{
									num = class3.sizeF_0.Height;
								}
								location.X += class3.sizeF_0.Width;
							}
							i--;
						}
						else if (num3 == num2)
						{
							for (; i < j; i++)
							{
								class3 = (Class909)arrayList_1[i];
								class3.rectangleF_0.Location = location;
								class3.rectangleF_0.Size = class3.sizeF_0;
								if (num < class3.sizeF_0.Height)
								{
									num = class3.sizeF_0.Height;
								}
								location.X += class3.sizeF_0.Width;
							}
							i--;
							location.Y += class3.sizeF_0.Height;
							num = float.MinValue;
						}
						else if (location.X == rectangleF_0.X)
						{
							for (; i < j; i++)
							{
								class3 = (Class909)arrayList_1[i];
								num2 -= class3.sizeF_0.Width;
								if (num2 < 0f)
								{
									if (location.X != rectangleF_0.X)
									{
										location.X = rectangleF_0.X;
										location.Y += ((num == float.MinValue) ? float_0 : num);
										num = float.MinValue;
										break;
									}
									string[] array = method_3(class3.Text, rectangleF_0.Width, class3.Font);
									Class909 class4 = new Class909(array[0], class3.Font, class3.FontColor, Enum125.const_2);
									class4.rectangleF_0 = new RectangleF(location, new SizeF(num2, class3.sizeF_0.Height));
									class4.sizeF_0 = class4.rectangleF_0.Size;
									arrayList_1.Insert(i, class4);
									class3.Text = array[1];
									class3.sizeF_0 = method_4(class3.Text, class3.Font);
									if (num < class3.sizeF_0.Height)
									{
										num = class3.sizeF_0.Height;
									}
									location.X = rectangleF_0.X;
									location.Y += ((num == float.MinValue) ? float_0 : num);
									num = float.MinValue;
								}
								class3.rectangleF_0.Location = location;
								class3.rectangleF_0.Size = class3.sizeF_0;
								if (num < class3.sizeF_0.Height)
								{
									num = class3.sizeF_0.Height;
								}
								location.X += class3.sizeF_0.Width;
							}
						}
						else
						{
							location.X = rectangleF_0.X;
							location.Y += ((num == float.MinValue) ? float_0 : num);
							num = float.MinValue;
							i--;
						}
					}
					else
					{
						location.X = rectangleF_0.X;
						location.Y += ((num == float.MinValue) ? float_0 : num);
						num = @class.sizeF_0.Height;
						num2 = rectangleF_0.Right - location.X;
						if (@class.sizeF_0.Width < num2)
						{
							@class.rectangleF_0.Location = location;
							@class.rectangleF_0.Size = @class.sizeF_0;
							location.X += @class.sizeF_0.Width;
						}
						else if (@class.sizeF_0.Width == num2)
						{
							@class.rectangleF_0.Location = location;
							@class.rectangleF_0.Size = @class.sizeF_0;
							location.X = rectangleF_0.X;
							location.Y += ((num == float.MinValue) ? float_0 : num);
							num = float.MinValue;
						}
						else
						{
							@class.rectangleF_0.Location = location;
							@class.rectangleF_0.Size = @class.sizeF_0;
							location.X = rectangleF_0.X;
							location.Y += ((num == float.MinValue) ? float_0 : num);
							num = float.MinValue;
						}
					}
				}
				else if (@class.sizeF_0.Width < num2)
				{
					@class.rectangleF_0.Location = location;
					@class.rectangleF_0.Size = @class.sizeF_0;
					if (num < @class.sizeF_0.Height)
					{
						num = @class.sizeF_0.Height;
					}
					location.X += @class.sizeF_0.Width;
				}
				else if (@class.sizeF_0.Width == num2)
				{
					@class.rectangleF_0.Location = location;
					@class.rectangleF_0.Size = @class.sizeF_0;
					if (num < @class.sizeF_0.Height)
					{
						num = @class.sizeF_0.Height;
					}
					location.X += @class.sizeF_0.Width;
					location.Y += ((num == float.MinValue) ? float_0 : num);
					num = float.MinValue;
				}
				else
				{
					string[] array2 = method_3(@class.Text, num2, @class.Font);
					Class909 class5 = new Class909(array2[0], @class.Font, @class.FontColor, Enum125.const_2);
					class5.rectangleF_0 = new RectangleF(location, new SizeF(num2, @class.sizeF_0.Height));
					class5.sizeF_0 = class5.rectangleF_0.Size;
					arrayList_1.Insert(i, class5);
					@class.Text = array2[1];
					@class.sizeF_0 = method_4(@class.Text, @class.Font);
					if (num < @class.sizeF_0.Height)
					{
						num = @class.sizeF_0.Height;
					}
					location.X = rectangleF_0.X;
					location.Y += ((num == float.MinValue) ? float_0 : num);
					num = float.MinValue;
				}
			}
		}
	}

	private void method_6(ArrayList arrayList_1, bool bool_0)
	{
		int num = 0;
		float num2 = float.MaxValue;
		float num3 = 0f;
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			Class909 @class = (Class909)arrayList_1[i];
			if (@class.enum125_0 == Enum125.const_0)
			{
				continue;
			}
			if (@class.rectangleF_0.Y > num2)
			{
				for (int num4 = i - 1; num4 > num; num4--)
				{
					Class909 class2 = (Class909)arrayList_1[num4];
					if (class2.enum125_0 == Enum125.const_2)
					{
						break;
					}
					if (class2.enum125_0 == Enum125.const_1)
					{
						num3 -= class2.sizeF_0.Width;
					}
				}
				float num5 = 0f;
				num5 = ((!bool_0) ? (rectangleF_0.Width - num3) : ((rectangleF_0.Width - num3) / 2f));
				for (int j = num; j < i; j++)
				{
					Class909 class3 = (Class909)arrayList_1[j];
					if (class3.enum125_0 == Enum125.const_2)
					{
						class3.rectangleF_0.X += num5;
					}
				}
				num3 = 0f;
				num = i;
			}
			num3 += @class.sizeF_0.Width;
			num2 = @class.rectangleF_0.Y;
		}
		for (int num6 = arrayList_1.Count - 1; num6 > num; num6--)
		{
			Class909 class4 = (Class909)arrayList_1[num6];
			if (class4.enum125_0 == Enum125.const_2)
			{
				break;
			}
			if (class4.enum125_0 == Enum125.const_1)
			{
				num3 -= class4.sizeF_0.Width;
			}
		}
		float num7 = 0f;
		num7 = ((!bool_0) ? (rectangleF_0.Width - num3) : ((rectangleF_0.Width - num3) / 2f));
		for (int k = num; k < arrayList_1.Count; k++)
		{
			Class909 class5 = (Class909)arrayList_1[k];
			if (class5.enum125_0 == Enum125.const_2)
			{
				class5.rectangleF_0.X += num7;
			}
		}
	}

	private void method_7(ArrayList arrayList_1)
	{
		int num = 0;
		float num2 = float.MaxValue;
		float num3 = float.MinValue;
		float num4 = float.MaxValue;
		Class909 @class = null;
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			Class909 class2 = (Class909)arrayList_1[i];
			if (class2.enum125_0 != Enum125.const_2)
			{
				continue;
			}
			if (class2.rectangleF_0.Y > num4)
			{
				if (num2 != num3)
				{
					Font font = @class.Font;
					float num5 = method_9(font);
					float num6 = num5 * (float)font.FontFamily.GetCellAscent(font.Style) / (float)font.FontFamily.GetEmHeight(font.Style);
					float num7 = num5 * (float)font.FontFamily.GetCellDescent(font.Style) / (float)font.FontFamily.GetEmHeight(font.Style);
					float num8 = num5 * (float)font.FontFamily.GetLineSpacing(font.Style) / (float)font.FontFamily.GetEmHeight(font.Style);
					float num9 = num8 - num6 - num7;
					for (int j = num; j < i; j++)
					{
						Class909 class3 = (Class909)arrayList_1[j];
						if (class3.enum125_0 == Enum125.const_2 && class3 != @class)
						{
							Font font2 = class3.Font;
							float num10 = method_9(font2);
							_ = num10 * (float)font2.FontFamily.GetCellDescent(font2.Style) / (float)font2.FontFamily.GetEmHeight(font2.Style);
							float num11 = num10 * (float)font2.FontFamily.GetCellAscent(font2.Style) / (float)font2.FontFamily.GetEmHeight(font2.Style);
							_ = num10 * (float)font2.FontFamily.GetLineSpacing(font2.Style) / (float)font2.FontFamily.GetEmHeight(font2.Style);
							class3.rectangleF_0.Y += (num6 - num11 - num9) * float_2;
						}
					}
				}
				num = i;
				num2 = float.MaxValue;
				num3 = float.MinValue;
			}
			num4 = class2.rectangleF_0.Y;
			if (class2.sizeF_0.Height < num2)
			{
				num2 = class2.sizeF_0.Height;
			}
			if (class2.sizeF_0.Height > num3)
			{
				num3 = class2.sizeF_0.Height;
				@class = class2;
			}
		}
		if (num2 == num3 || num2 == float.MaxValue || num3 == float.MinValue || @class == null)
		{
			return;
		}
		Font font3 = @class.Font;
		float num12 = method_9(font3);
		float num13 = num12 * (float)font3.FontFamily.GetCellAscent(font3.Style) / (float)font3.FontFamily.GetEmHeight(font3.Style);
		float num14 = num12 * (float)font3.FontFamily.GetCellDescent(font3.Style) / (float)font3.FontFamily.GetEmHeight(font3.Style);
		float num15 = num12 * (float)font3.FontFamily.GetLineSpacing(font3.Style) / (float)font3.FontFamily.GetEmHeight(font3.Style);
		float num16 = num15 - num13 - num14;
		for (int k = num; k < arrayList_1.Count; k++)
		{
			Class909 class4 = (Class909)arrayList_1[k];
			if (class4.enum125_0 == Enum125.const_2 && class4 != @class)
			{
				Font font4 = class4.Font;
				float num17 = method_9(font4);
				_ = num17 * (float)font4.FontFamily.GetCellDescent(font4.Style) / (float)font4.FontFamily.GetEmHeight(font4.Style);
				float num18 = num17 * (float)font4.FontFamily.GetCellAscent(font4.Style) / (float)font4.FontFamily.GetEmHeight(font4.Style);
				_ = num17 * (float)font4.FontFamily.GetLineSpacing(font4.Style) / (float)font4.FontFamily.GetEmHeight(font4.Style);
				class4.rectangleF_0.Y += (num13 - num18 - num16) * float_2;
			}
		}
	}

	private void method_8(ArrayList arrayList_1, bool bool_0)
	{
		float num = float.MinValue;
		float num2 = float.MinValue;
		float num3 = 0f;
		for (int num4 = arrayList_1.Count - 1; num4 >= 0; num4--)
		{
			Class909 @class = (Class909)arrayList_1[num4];
			if (@class.enum125_0 == Enum125.const_0)
			{
				if (num4 < arrayList_1.Count - 1)
				{
					num3 = ((((Class909)arrayList_1[num4 + 1]).enum125_0 != Enum125.const_2) ? (num3 + float_0) : (num3 + num));
				}
				num = float.MinValue;
				num2 = float.MinValue;
			}
			else if (@class.enum125_0 == Enum125.const_2)
			{
				if (@class.rectangleF_0.Y < num2)
				{
					num3 += num;
					num = float.MinValue;
				}
				num2 = @class.rectangleF_0.Y;
				if (@class.sizeF_0.Height > num)
				{
					num = @class.sizeF_0.Height;
				}
			}
		}
		if (num != float.MinValue)
		{
			num3 += num;
		}
		float num5;
		if (bool_0)
		{
			_ = (Class909)arrayList_1[0];
			_ = (Class909)arrayList_1[arrayList_1.Count - 1];
			num5 = (rectangleF_0.Height - num3) / 2f;
		}
		else
		{
			num5 = rectangleF_0.Height - num3;
		}
		for (int num6 = arrayList_1.Count - 1; num6 >= 0; num6--)
		{
			Class909 class2 = (Class909)arrayList_1[num6];
			if (class2.enum125_0 == Enum125.const_2)
			{
				class2.rectangleF_0.Y += num5;
			}
		}
	}

	private int method_9(Font font_1)
	{
		return Struct72.smethod_7(interface42_0.imethod_0().imethod_2(font_1));
	}

	private bool method_10(string string_0)
	{
		if (string_0[0] > '一' && string_0[0] < '龥')
		{
			return true;
		}
		return false;
	}
}
