using System;
using System.Collections;
using System.Drawing;
using System.Text.RegularExpressions;
using ns19;

namespace ns3;

internal class Class866
{
	private Interface42 interface42_0;

	private RectangleF rectangleF_0;

	private Class863 class863_0;

	private Font font_0;

	private float float_0;

	private float float_1;

	private float float_2;

	private ArrayList arrayList_0;

	private bool bool_0;

	public Class866(RectangleF rectangleF_1, Class863 class863_1, Interface38 interface38_0, Font font_1)
		: this(rectangleF_1, class863_1, interface38_0, font_1, 1f, 1f)
	{
	}

	public Class866(RectangleF rectangleF_1, Class863 class863_1, Interface38 interface38_0, Font font_1, float float_3, float float_4)
	{
		rectangleF_0 = rectangleF_1;
		class863_0 = class863_1;
		arrayList_0 = new ArrayList();
		for (int i = 0; i < interface38_0.Count; i++)
		{
			arrayList_0.Add(interface38_0[i]);
		}
		font_0 = font_1;
		float_1 = float_3;
		float_2 = float_4;
	}

	public RectangleF Calculate(Interface42 interface42_1)
	{
		if (!method_1())
		{
			return RectangleF.Empty;
		}
		interface42_0 = interface42_1;
		float_0 = interface42_0.imethod_39("A", font_0).Height * float_2;
		if (arrayList_0 != null && arrayList_0.Count > 0)
		{
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = class863_0.TextHorizontalAlignment;
			stringFormat.LineAlignment = class863_0.TextVerticalAlignment;
			method_2(arrayList_0);
			if (class863_0.TextVerticalAlignment == StringAlignment.Near)
			{
				if (class863_0.TextHorizontalAlignment == StringAlignment.Near)
				{
					method_6(arrayList_0);
					method_8(arrayList_0);
				}
				else if (class863_0.TextHorizontalAlignment == StringAlignment.Center)
				{
					method_6(arrayList_0);
					method_7(arrayList_0, bool_1: true);
					method_8(arrayList_0);
				}
				else
				{
					method_6(arrayList_0);
					method_7(arrayList_0, bool_1: false);
					method_8(arrayList_0);
				}
			}
			else if (class863_0.TextVerticalAlignment == StringAlignment.Far)
			{
				if (class863_0.TextHorizontalAlignment == StringAlignment.Near)
				{
					method_6(arrayList_0);
					method_9(arrayList_0, bool_1: false);
					method_8(arrayList_0);
				}
				else if (class863_0.TextHorizontalAlignment == StringAlignment.Center)
				{
					method_6(arrayList_0);
					method_7(arrayList_0, bool_1: true);
					method_9(arrayList_0, bool_1: false);
					method_8(arrayList_0);
				}
				else
				{
					method_6(arrayList_0);
					method_7(arrayList_0, bool_1: false);
					method_9(arrayList_0, bool_1: false);
					method_8(arrayList_0);
				}
			}
			else if (class863_0.TextHorizontalAlignment == StringAlignment.Near)
			{
				method_6(arrayList_0);
				method_9(arrayList_0, bool_1: true);
				method_8(arrayList_0);
			}
			else if (class863_0.TextHorizontalAlignment == StringAlignment.Center)
			{
				method_6(arrayList_0);
				method_7(arrayList_0, bool_1: true);
				method_9(arrayList_0, bool_1: true);
				method_8(arrayList_0);
			}
			else
			{
				method_6(arrayList_0);
				method_7(arrayList_0, bool_1: false);
				method_9(arrayList_0, bool_1: true);
				method_8(arrayList_0);
			}
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			bool flag = true;
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				Class865 @class = (Class865)arrayList_0[i];
				if (@class.vmethod_0() != Enum81.const_2)
				{
					continue;
				}
				if (flag)
				{
					num = @class.rectangleF_0.Left;
					num2 = @class.rectangleF_0.Top;
					num4 = @class.rectangleF_0.Right;
					num3 = @class.rectangleF_0.Bottom;
					flag = false;
					continue;
				}
				if (@class.rectangleF_0.Left < num)
				{
					num = @class.rectangleF_0.Left;
				}
				if (@class.rectangleF_0.Top < num2)
				{
					num2 = @class.rectangleF_0.Top;
				}
				if (@class.rectangleF_0.Right > num4)
				{
					num4 = @class.rectangleF_0.Right;
				}
				if (@class.rectangleF_0.Bottom > num3)
				{
					num3 = @class.rectangleF_0.Bottom;
				}
			}
			bool_0 = true;
			return new RectangleF(num, num2, num4 - num, num3 - num2);
		}
		return RectangleF.Empty;
	}

	public void method_0(Interface42 interface42_1)
	{
		if (!bool_0)
		{
			Calculate(interface42_1);
		}
		foreach (Class865 item in arrayList_0)
		{
			if (item.vmethod_0() == Enum81.const_2)
			{
				Font font = item.Font;
				float num = method_10(font) * (float)font.FontFamily.GetCellAscent(font.Style) / (float)font.FontFamily.GetEmHeight(font.Style);
				float num2 = method_10(font) * (float)font.FontFamily.GetCellDescent(font.Style) / (float)font.FontFamily.GetEmHeight(font.Style);
				float num3 = method_10(font) * (float)font.FontFamily.GetLineSpacing(font.Style) / (float)font.FontFamily.GetEmHeight(font.Style);
				item.rectangleF_0.X -= num3 - num - num2;
				StringFormat stringFormat_ = new StringFormat(StringFormat.GenericTypographic);
				interface42_0.imethod_26(item.Text, item.Font, new SolidBrush(item.FontColor), item.rectangleF_0.Location, stringFormat_);
			}
		}
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
			Class865 @class = (Class865)arrayList_1[i];
			string[] array = regex.Split(@class.Text);
			if (array.Length <= 1)
			{
				continue;
			}
			for (int j = 0; j < array.Length; j++)
			{
				if (array[j] != "")
				{
					Class865 value = new Class865(array[j], @class.Font, @class.FontColor, Enum81.const_2);
					arrayList_1.Insert(i, value);
					i++;
				}
				else if (array[j] == "" && j == array.Length - 1)
				{
					break;
				}
				if (j != array.Length - 1)
				{
					Class865 value = new Class865("", @class.Font, @class.FontColor, Enum81.const_0);
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
			Class865 class2 = (Class865)arrayList_1[k];
			MatchCollection matchCollection = regex2.Matches(class2.Text);
			if (matchCollection.Count <= 0)
			{
				continue;
			}
			int num = 0;
			for (int l = 0; l < matchCollection.Count; l++)
			{
				Class865 value2;
				if (matchCollection[l].Index > num)
				{
					string string_ = class2.Text.Substring(num, matchCollection[l].Index - num);
					value2 = new Class865(string_, class2.Font, class2.FontColor, Enum81.const_2);
					arrayList_1.Insert(k, value2);
					k++;
				}
				value2 = new Class865(matchCollection[l].Value, class2.Font, class2.FontColor, Enum81.const_1);
				arrayList_1.Insert(k, value2);
				k++;
				num = matchCollection[l].Index + matchCollection[l].Value.Length;
				if (l == matchCollection.Count - 1 && num <= class2.Text.Length - 1)
				{
					string string_2 = class2.Text.Substring(num, class2.Text.Length - num);
					value2 = new Class865(string_2, class2.Font, class2.FontColor, Enum81.const_2);
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
			Class865 class3 = (Class865)arrayList_1[m];
			if (class3.vmethod_0() != 0)
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
		return method_5(interface42_0, string_0, font_1, new SizeF(2.1474836E+09f, 2.1474836E+09f));
	}

	private SizeF method_5(Interface42 interface42_1, string string_0, Font font_1, SizeF sizeF_0)
	{
		int num = (int)Math.Ceiling(interface42_1.imethod_0().imethod_2(font_1));
		if (string_0 != null && string_0.Length != 0)
		{
			Regex regex = new Regex("^\\s{1,}$");
			if (!regex.IsMatch(string_0) && !regex.IsMatch(string_0.Substring(string_0.Length - 1)))
			{
				StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
				stringFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
				SizeF result = interface42_1.imethod_42(string_0, font_1, sizeF_0, stringFormat);
				bool flag = false;
				if (result.Height < (float)num * 1.5f)
				{
					string_0 += "|";
					sizeF_0.Width += num;
					result = interface42_1.imethod_42(string_0, font_1, sizeF_0, stringFormat);
					flag = true;
				}
				int num2 = (int)Math.Ceiling(result.Height);
				if (num2 >= 1 && result.Width >= 1f)
				{
					int num3 = (int)((double)result.Width * 0.1);
					if (num3 < 10)
					{
						num3 = 10;
					}
					Bitmap bitmap = new Bitmap(num3, num2);
					Graphics graphics = Graphics.FromImage(bitmap);
					float num4 = (int)Math.Ceiling(result.Width);
					if (!flag)
					{
						graphics.Clear(Color.White);
						graphics.DrawString(layoutRectangle: new RectangleF((float)num3 - num4, 0f, num4, num2), s: string_0, font: font_1, brush: Brushes.Black, format: stringFormat);
						int num5 = num3 - 1;
						while (num5 >= 0)
						{
							num4 -= 1f;
							int i;
							for (i = 0; i < num2 && bitmap.GetPixel(num5, i).R == byte.MaxValue; i++)
							{
							}
							if (i >= num2)
							{
								num5--;
								continue;
							}
							num4 += 1f;
							break;
						}
					}
					else
					{
						float num6 = num4;
						graphics.Clear(Color.White);
						graphics.DrawString(string_0, font_1, Brushes.Black, (float)num3 - num6, 0f, stringFormat);
						for (int num7 = num3 - 1; num7 >= 0; num7--)
						{
							num6 -= 1f;
							if (bitmap.GetPixel(num7, num / 2).R != byte.MaxValue)
							{
								break;
							}
						}
						string_0 += "|";
						SizeF sizeF = interface42_1.imethod_42(string_0, font_1, sizeF_0, stringFormat);
						int num8 = (int)((double)result.Width * 0.1);
						if (num8 < 10)
						{
							num8 = 10;
						}
						float num9 = (int)Math.Ceiling(sizeF.Width);
						graphics.Clear(Color.White);
						graphics.DrawString(string_0, font_1, Brushes.Black, (float)num8 - num9, 0f, stringFormat);
						for (int num10 = num8 - 1; num10 >= 0; num10--)
						{
							num9 -= 1f;
							if (bitmap.GetPixel(num10, num / 2).R != byte.MaxValue)
							{
								break;
							}
						}
						num4 = num6 - (num9 - num6) / 2f;
					}
					bitmap?.Dispose();
					graphics?.Dispose();
					return new SizeF(num4, num2);
				}
				return result;
			}
			SizeF result2 = interface42_1.imethod_41(string_0, font_1, new PointF(0f, 0f), new StringFormat(StringFormatFlags.MeasureTrailingSpaces));
			if (result2.Height > (float)num * 1.5f)
			{
				return result2;
			}
			string text = "aaaaaaaaaa";
			string string_ = text + string_0 + text;
			SizeF sizeF_ = new SizeF(2.1474836E+09f, 2.1474836E+09f);
			SizeF sizeF2 = method_5(interface42_1, text, font_1, sizeF_);
			SizeF sizeF3 = method_5(interface42_1, string_, font_1, sizeF_);
			float width = ((sizeF3.Width - 2f * sizeF2.Width > 0f) ? (sizeF3.Width - 2f * sizeF2.Width) : ((float)num / 5f));
			return new SizeF(width, result2.Height);
		}
		return new SizeF(0f, num);
	}

	private void method_6(ArrayList arrayList_1)
	{
		PointF location = rectangleF_0.Location;
		float num = float.MinValue;
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			Class865 @class = (Class865)arrayList_1[i];
			float num2 = rectangleF_0.Right - location.X;
			if (@class.vmethod_0() == Enum81.const_0)
			{
				@class.rectangleF_0 = new RectangleF(rectangleF_0.X, location.Y, rectangleF_0.Width, @class.sizeF_0.Height);
				location.X = rectangleF_0.Location.X;
				location.Y += ((num == float.MinValue) ? @class.sizeF_0.Height : num);
				num = float.MinValue;
			}
			else if (@class.vmethod_0() == Enum81.const_1)
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
				if (@class.vmethod_0() != Enum81.const_2)
				{
					continue;
				}
				Class865 class2 = null;
				Class865 class3 = null;
				if (i > 0)
				{
					class2 = (Class865)arrayList_1[i - 1];
				}
				if (i + 1 < arrayList_1.Count)
				{
					class3 = (Class865)arrayList_1[i + 1];
				}
				if (class2 != null && class2.vmethod_0() == Enum81.const_1)
				{
					if (@class.sizeF_0.Width <= num2)
					{
						float num3 = @class.sizeF_0.Width;
						int j;
						for (j = i + 1; j < arrayList_1.Count; j++)
						{
							if (class3.vmethod_0() != Enum81.const_2)
							{
								break;
							}
							class3 = (Class865)arrayList_1[j];
							if (class3.vmethod_0() != Enum81.const_2)
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
								class3 = (Class865)arrayList_1[i];
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
								class3 = (Class865)arrayList_1[i];
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
						else if (num2 == rectangleF_0.Right - location.X)
						{
							for (; i < j; i++)
							{
								class3 = (Class865)arrayList_1[i];
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
									Class865 class4 = new Class865(array[0], class3.Font, class3.FontColor, Enum81.const_2);
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
						continue;
					}
					location.X = rectangleF_0.X;
					location.Y += ((num == float.MinValue) ? float_0 : num);
					num = @class.sizeF_0.Height;
					num2 = rectangleF_0.Right - location.X;
					if (@class.sizeF_0.Width < num2)
					{
						@class.rectangleF_0.Location = location;
						@class.rectangleF_0.Size = @class.sizeF_0;
						location.X += @class.sizeF_0.Width;
						continue;
					}
					if (@class.sizeF_0.Width == num2)
					{
						@class.rectangleF_0.Location = location;
						@class.rectangleF_0.Size = @class.sizeF_0;
						location.X = rectangleF_0.X;
						location.Y += ((num == float.MinValue) ? float_0 : num);
						num = float.MinValue;
						continue;
					}
					string[] array2 = method_3(@class.Text, num2, @class.Font);
					Class865 class5 = new Class865(array2[0], @class.Font, @class.FontColor, Enum81.const_2);
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
					string[] array3 = method_3(@class.Text, num2, @class.Font);
					Class865 class6 = new Class865(array3[0], @class.Font, @class.FontColor, Enum81.const_2);
					class6.rectangleF_0 = new RectangleF(location, new SizeF(num2, @class.sizeF_0.Height));
					class6.sizeF_0 = class6.rectangleF_0.Size;
					arrayList_1.Insert(i, class6);
					@class.Text = array3[1];
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

	private void method_7(ArrayList arrayList_1, bool bool_1)
	{
		int num = 0;
		float num2 = float.MaxValue;
		float num3 = 0f;
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			Class865 @class = (Class865)arrayList_1[i];
			if (@class.vmethod_0() == Enum81.const_0)
			{
				continue;
			}
			if (@class.rectangleF_0.Y > num2)
			{
				for (int num4 = i - 1; num4 > num; num4--)
				{
					Class865 class2 = (Class865)arrayList_1[num4];
					if (class2.vmethod_0() == Enum81.const_2)
					{
						break;
					}
					if (class2.vmethod_0() == Enum81.const_1)
					{
						num3 -= class2.sizeF_0.Width;
					}
				}
				float num5 = 0f;
				num5 = ((!bool_1) ? (rectangleF_0.Width - num3) : ((rectangleF_0.Width - num3) / 2f));
				for (int j = num; j < i; j++)
				{
					Class865 class3 = (Class865)arrayList_1[j];
					if (class3.vmethod_0() == Enum81.const_2)
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
			Class865 class4 = (Class865)arrayList_1[num6];
			if (class4.vmethod_0() == Enum81.const_2)
			{
				break;
			}
			if (class4.vmethod_0() == Enum81.const_1)
			{
				num3 -= class4.sizeF_0.Width;
			}
		}
		float num7 = 0f;
		num7 = ((!bool_1) ? (rectangleF_0.Width - num3) : ((rectangleF_0.Width - num3) / 2f));
		for (int k = num; k < arrayList_1.Count; k++)
		{
			Class865 class5 = (Class865)arrayList_1[k];
			if (class5.vmethod_0() == Enum81.const_2)
			{
				class5.rectangleF_0.X += num7;
			}
		}
	}

	private void method_8(ArrayList arrayList_1)
	{
		int num = 0;
		float num2 = float.MaxValue;
		float num3 = float.MinValue;
		float num4 = float.MaxValue;
		Class865 @class = null;
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			Class865 class2 = (Class865)arrayList_1[i];
			if (class2.vmethod_0() != Enum81.const_2)
			{
				continue;
			}
			if (class2.rectangleF_0.Y > num4)
			{
				if (num2 != num3)
				{
					Font font = @class.Font;
					float num5 = method_10(font) * (float)font.FontFamily.GetCellAscent(font.Style) / (float)font.FontFamily.GetEmHeight(font.Style);
					float num6 = method_10(font) * (float)font.FontFamily.GetCellDescent(font.Style) / (float)font.FontFamily.GetEmHeight(font.Style);
					float num7 = method_10(font) * (float)font.FontFamily.GetLineSpacing(font.Style) / (float)font.FontFamily.GetEmHeight(font.Style);
					float num8 = num7 - num5 - num6;
					for (int j = num; j < i; j++)
					{
						Class865 class3 = (Class865)arrayList_1[j];
						if (class3.vmethod_0() == Enum81.const_2 && class3 != @class)
						{
							Font font2 = class3.Font;
							float num9 = method_10(font2);
							_ = num9 * (float)font2.FontFamily.GetCellDescent(font2.Style) / (float)font2.FontFamily.GetEmHeight(font2.Style);
							float num10 = num9 * (float)font2.FontFamily.GetCellAscent(font2.Style) / (float)font2.FontFamily.GetEmHeight(font2.Style);
							_ = num9 * (float)font2.FontFamily.GetLineSpacing(font2.Style) / (float)font2.FontFamily.GetEmHeight(font2.Style);
							class3.rectangleF_0.Y += (num5 - num10 - num8) * float_2;
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
		float num11 = method_10(font3);
		float num12 = num11 * (float)font3.FontFamily.GetCellAscent(font3.Style) / (float)font3.FontFamily.GetEmHeight(font3.Style);
		float num13 = num11 * (float)font3.FontFamily.GetCellDescent(font3.Style) / (float)font3.FontFamily.GetEmHeight(font3.Style);
		float num14 = num11 * (float)font3.FontFamily.GetLineSpacing(font3.Style) / (float)font3.FontFamily.GetEmHeight(font3.Style);
		float num15 = num14 - num12 - num13;
		for (int k = num; k < arrayList_1.Count; k++)
		{
			Class865 class4 = (Class865)arrayList_1[k];
			if (class4.vmethod_0() == Enum81.const_2 && class4 != @class)
			{
				Font font4 = class4.Font;
				float num16 = method_10(font4);
				_ = num16 * (float)font4.FontFamily.GetCellDescent(font4.Style) / (float)font4.FontFamily.GetEmHeight(font4.Style);
				float num17 = num16 * (float)font4.FontFamily.GetCellAscent(font4.Style) / (float)font4.FontFamily.GetEmHeight(font4.Style);
				_ = num16 * (float)font4.FontFamily.GetLineSpacing(font4.Style) / (float)font4.FontFamily.GetEmHeight(font4.Style);
				class4.rectangleF_0.Y += (num12 - num17 - num15) * float_2;
			}
		}
	}

	private void method_9(ArrayList arrayList_1, bool bool_1)
	{
		float num = float.MinValue;
		float num2 = float.MinValue;
		float num3 = 0f;
		for (int num4 = arrayList_1.Count - 1; num4 >= 0; num4--)
		{
			Class865 @class = (Class865)arrayList_1[num4];
			if (@class.vmethod_0() == Enum81.const_0)
			{
				if (num4 < arrayList_1.Count - 1)
				{
					num3 = ((((Class865)arrayList_1[num4 + 1]).vmethod_0() != Enum81.const_2) ? (num3 + float_0) : (num3 + num));
				}
				num = float.MinValue;
				num2 = float.MinValue;
			}
			else if (@class.vmethod_0() == Enum81.const_2)
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
			else
			{
				@class.vmethod_0();
			}
		}
		if (num != float.MinValue)
		{
			num3 += num;
		}
		float num5;
		if (bool_1)
		{
			_ = (Class865)arrayList_1[0];
			_ = (Class865)arrayList_1[arrayList_1.Count - 1];
			num5 = (rectangleF_0.Height - num3) / 2f;
		}
		else
		{
			num5 = rectangleF_0.Height - num3;
		}
		for (int num6 = arrayList_1.Count - 1; num6 >= 0; num6--)
		{
			Class865 class2 = (Class865)arrayList_1[num6];
			if (class2.vmethod_0() == Enum81.const_2)
			{
				class2.rectangleF_0.Y += num5;
			}
		}
	}

	private float method_10(Font font_1)
	{
		return (int)Math.Ceiling(interface42_0.imethod_0().imethod_2(font_1));
	}
}
