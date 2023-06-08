using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using ns35;

namespace ns36;

internal class Class780
{
	private Interface32 interface32_0;

	private RectangleF rectangleF_0;

	private Class777 class777_0;

	private Font font_0;

	private float float_0;

	private float float_1;

	private float float_2;

	private List<Interface30> list_0;

	public Class780(RectangleF wholeRectOut, Class777 alignment, Interface29 textList, Font defaultFont)
		: this(wholeRectOut, alignment, textList, defaultFont, 1f, 1f)
	{
	}

	public Class780(RectangleF wholeRectOut, Class777 alignment, Interface29 textList, Font defaultFont, float dpiXRate, float dpiYRate)
	{
		rectangleF_0 = wholeRectOut;
		class777_0 = alignment;
		list_0 = new List<Interface30>();
		for (int i = 0; i < textList.Count; i++)
		{
			list_0.Add(textList[i]);
		}
		font_0 = defaultFont;
		float_1 = dpiXRate;
		float_2 = dpiYRate;
	}

	public void method_0(Interface32 g)
	{
		if (!method_1())
		{
			return;
		}
		interface32_0 = g;
		float_0 = interface32_0.imethod_105("A", font_0).Height * float_2;
		if (list_0 == null || list_0.Count <= 0)
		{
			return;
		}
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = class777_0.TextHorizontalAlignment;
		stringFormat.LineAlignment = class777_0.TextVerticalAlignment;
		method_2(list_0);
		if (class777_0.TextVerticalAlignment == StringAlignment.Near)
		{
			if (class777_0.TextHorizontalAlignment == StringAlignment.Near)
			{
				method_5(list_0);
				method_7(list_0);
			}
			else if (class777_0.TextHorizontalAlignment == StringAlignment.Center)
			{
				method_5(list_0);
				method_6(list_0, isCenter: true);
				method_7(list_0);
			}
			else
			{
				method_5(list_0);
				method_6(list_0, isCenter: false);
				method_7(list_0);
			}
		}
		else if (class777_0.TextVerticalAlignment == StringAlignment.Far)
		{
			if (class777_0.TextHorizontalAlignment == StringAlignment.Near)
			{
				method_5(list_0);
				method_8(list_0, isCenter: false);
				method_7(list_0);
			}
			else if (class777_0.TextHorizontalAlignment == StringAlignment.Center)
			{
				method_5(list_0);
				method_6(list_0, isCenter: true);
				method_8(list_0, isCenter: false);
				method_7(list_0);
			}
			else
			{
				method_5(list_0);
				method_6(list_0, isCenter: false);
				method_8(list_0, isCenter: false);
				method_7(list_0);
			}
		}
		else if (class777_0.TextHorizontalAlignment == StringAlignment.Near)
		{
			method_5(list_0);
			method_8(list_0, isCenter: true);
			method_7(list_0);
		}
		else if (class777_0.TextHorizontalAlignment == StringAlignment.Center)
		{
			method_5(list_0);
			method_6(list_0, isCenter: true);
			method_8(list_0, isCenter: true);
			method_7(list_0);
		}
		else
		{
			method_5(list_0);
			method_6(list_0, isCenter: false);
			method_8(list_0, isCenter: true);
			method_7(list_0);
		}
		foreach (Class779 item in list_0)
		{
			if (item.TextType == Enum156.const_2)
			{
				Font font = item.Font;
				float num = method_9(font) * (float)font.FontFamily.GetCellAscent(font.Style) / (float)font.FontFamily.GetEmHeight(font.Style);
				float num2 = method_9(font) * (float)font.FontFamily.GetCellDescent(font.Style) / (float)font.FontFamily.GetEmHeight(font.Style);
				float num3 = method_9(font) * (float)font.FontFamily.GetLineSpacing(font.Style) / (float)font.FontFamily.GetEmHeight(font.Style);
				item.rectangleF_0.X -= num3 - num - num2;
				StringFormat format = new StringFormat(StringFormat.GenericTypographic);
				interface32_0.imethod_60(item.Text, item.Font, new SolidBrush(item.FontColor), item.rectangleF_0.Location, format);
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

	private void method_2(List<Interface30> textList)
	{
		Regex regex = new Regex("\\n");
		for (int i = 0; i < textList.Count; i++)
		{
			Class779 @class = (Class779)textList[i];
			string[] array = regex.Split(@class.Text);
			if (array.Length <= 1)
			{
				continue;
			}
			for (int j = 0; j < array.Length; j++)
			{
				if (array[j] != "")
				{
					Class779 item = new Class779(array[j], @class.Font, @class.FontColor, Enum156.const_2);
					textList.Insert(i, item);
					i++;
				}
				else if (array[j] == "" && j == array.Length - 1)
				{
					break;
				}
				if (j != array.Length - 1)
				{
					Class779 item = new Class779("", @class.Font, @class.FontColor, Enum156.const_0);
					textList.Insert(i, item);
					i++;
				}
			}
			textList.RemoveAt(i);
			i--;
		}
		Regex regex2 = new Regex("(\\s){1,}");
		for (int k = 0; k < textList.Count; k++)
		{
			Class779 class2 = (Class779)textList[k];
			MatchCollection matchCollection = regex2.Matches(class2.Text);
			if (matchCollection.Count <= 0)
			{
				continue;
			}
			int num = 0;
			for (int l = 0; l < matchCollection.Count; l++)
			{
				Class779 item2;
				if (matchCollection[l].Index > num)
				{
					string text = class2.Text.Substring(num, matchCollection[l].Index - num);
					item2 = new Class779(text, class2.Font, class2.FontColor, Enum156.const_2);
					textList.Insert(k, item2);
					k++;
				}
				item2 = new Class779(matchCollection[l].Value, class2.Font, class2.FontColor, Enum156.const_1);
				textList.Insert(k, item2);
				k++;
				num = matchCollection[l].Index + matchCollection[l].Value.Length;
				if (l == matchCollection.Count - 1 && num <= class2.Text.Length - 1)
				{
					string text2 = class2.Text.Substring(num, class2.Text.Length - num);
					item2 = new Class779(text2, class2.Font, class2.FontColor, Enum156.const_2);
					textList.Insert(k, item2);
					k++;
				}
			}
			textList.RemoveAt(k);
			k--;
		}
		StringFormat stringFormat = new StringFormat();
		stringFormat.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
		for (int m = 0; m < textList.Count; m++)
		{
			Class779 class3 = (Class779)textList[m];
			if (class3.TextType != 0)
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

	private string[] method_3(string text, float maxWidth, Font font)
	{
		if (text != null && text.Length >= 1)
		{
			string[] array = new string[2];
			if (text.Length == 1)
			{
				return new string[2] { text, "" };
			}
			for (int i = 1; i <= text.Length; i++)
			{
				string text2 = text.Substring(0, i);
				if (!(method_4(text2, font).Width <= maxWidth))
				{
					array[0] = text.Substring(0, i - 1);
					array[1] = text.Substring((i - 2 > 0) ? (i - 2) : (i - 1));
					break;
				}
			}
			return array;
		}
		return new string[2] { "", "" };
	}

	private SizeF method_4(string text, Font font)
	{
		return smethod_0(interface32_0, text, font, new SizeF(2.1474836E+09f, 2.1474836E+09f));
	}

	public static SizeF smethod_0(Interface32 g, string text, Font font, SizeF layout)
	{
		int num = (int)Math.Ceiling(g.GraphicsTools.imethod_2(font));
		if (text != null && text.Length != 0)
		{
			Regex regex = new Regex("^\\s{1,}$");
			if (!regex.IsMatch(text) && !regex.IsMatch(text.Substring(text.Length - 1)))
			{
				StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
				stringFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
				SizeF result = g.imethod_109(text, font, layout, stringFormat);
				bool flag = false;
				if (result.Height < (float)num * 1.5f)
				{
					text += "|";
					layout.Width += num;
					result = g.imethod_109(text, font, layout, stringFormat);
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
						graphics.DrawString(layoutRectangle: new RectangleF((float)num3 - num4, 0f, num4, num2), s: text, font: font, brush: Brushes.Black, format: stringFormat);
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
						graphics.Clear(Color.White);
						graphics.DrawString(text, font, Brushes.Black, (float)num3 - num4, 0f, stringFormat);
						for (int num6 = num3 - 1; num6 >= 0; num6--)
						{
							num4 -= 1f;
							if (bitmap.GetPixel(num6, num / 2).R != byte.MaxValue)
							{
								break;
							}
						}
					}
					bitmap?.Dispose();
					graphics?.Dispose();
					return new SizeF(num4, num2);
				}
				return result;
			}
			SizeF result2 = g.imethod_108(text, font, new PointF(0f, 0f), new StringFormat(StringFormatFlags.MeasureTrailingSpaces));
			if (result2.Height > (float)num * 1.5f)
			{
				return result2;
			}
			string text2 = "aaaaaaaaaa";
			string text3 = text2 + text + text2;
			SizeF layout2 = new SizeF(2.1474836E+09f, 2.1474836E+09f);
			SizeF sizeF = smethod_0(g, text2, font, layout2);
			SizeF sizeF2 = smethod_0(g, text3, font, layout2);
			float width = ((sizeF2.Width - 2f * sizeF.Width > 0f) ? (sizeF2.Width - 2f * sizeF.Width) : ((float)num / 5f));
			return new SizeF(width, result2.Height);
		}
		return new SizeF(0f, num);
	}

	private void method_5(List<Interface30> textList)
	{
		PointF location = rectangleF_0.Location;
		float num = float.MinValue;
		for (int i = 0; i < textList.Count; i++)
		{
			Class779 @class = (Class779)textList[i];
			float num2 = rectangleF_0.Right - location.X;
			if (@class.TextType == Enum156.const_0)
			{
				@class.rectangleF_0 = new RectangleF(rectangleF_0.X, location.Y, rectangleF_0.Width, @class.sizeF_0.Height);
				location.X = rectangleF_0.Location.X;
				location.Y += ((num == float.MinValue) ? @class.sizeF_0.Height : num);
				num = float.MinValue;
			}
			else if (@class.TextType == Enum156.const_1)
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
				if (@class.TextType != Enum156.const_2)
				{
					continue;
				}
				Class779 class2 = null;
				Class779 class3 = null;
				if (i > 0)
				{
					class2 = (Class779)textList[i - 1];
				}
				if (i + 1 < textList.Count)
				{
					class3 = (Class779)textList[i + 1];
				}
				if (class2 != null && class2.TextType == Enum156.const_1)
				{
					if (@class.sizeF_0.Width <= num2)
					{
						float num3 = @class.sizeF_0.Width;
						int j;
						for (j = i + 1; j < textList.Count; j++)
						{
							if (class3.TextType != Enum156.const_2)
							{
								break;
							}
							class3 = (Class779)textList[j];
							if (class3.TextType != Enum156.const_2)
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
								class3 = (Class779)textList[i];
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
								class3 = (Class779)textList[i];
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
								class3 = (Class779)textList[i];
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
									Class779 class4 = new Class779(array[0], class3.Font, class3.FontColor, Enum156.const_2);
									class4.rectangleF_0 = new RectangleF(location, new SizeF(num2, class3.sizeF_0.Height));
									class4.sizeF_0 = class4.rectangleF_0.Size;
									textList.Insert(i, class4);
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
					Class779 class5 = new Class779(array2[0], @class.Font, @class.FontColor, Enum156.const_2);
					class5.rectangleF_0 = new RectangleF(location, new SizeF(num2, @class.sizeF_0.Height));
					class5.sizeF_0 = class5.rectangleF_0.Size;
					textList.Insert(i, class5);
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
					Class779 class6 = new Class779(array3[0], @class.Font, @class.FontColor, Enum156.const_2);
					class6.rectangleF_0 = new RectangleF(location, new SizeF(num2, @class.sizeF_0.Height));
					class6.sizeF_0 = class6.rectangleF_0.Size;
					textList.Insert(i, class6);
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

	private void method_6(List<Interface30> textList, bool isCenter)
	{
		int num = 0;
		float num2 = float.MaxValue;
		float num3 = 0f;
		for (int i = 0; i < textList.Count; i++)
		{
			Class779 @class = (Class779)textList[i];
			if (@class.TextType == Enum156.const_0)
			{
				continue;
			}
			if (@class.rectangleF_0.Y > num2)
			{
				for (int num4 = i - 1; num4 > num; num4--)
				{
					Class779 class2 = (Class779)textList[num4];
					if (class2.TextType == Enum156.const_2)
					{
						break;
					}
					if (class2.TextType == Enum156.const_1)
					{
						num3 -= class2.sizeF_0.Width;
					}
				}
				float num5 = 0f;
				num5 = ((!isCenter) ? (rectangleF_0.Width - num3) : ((rectangleF_0.Width - num3) / 2f));
				for (int j = num; j < i; j++)
				{
					Class779 class3 = (Class779)textList[j];
					if (class3.TextType == Enum156.const_2)
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
		for (int num6 = textList.Count - 1; num6 > num; num6--)
		{
			Class779 class4 = (Class779)textList[num6];
			if (class4.TextType == Enum156.const_2)
			{
				break;
			}
			if (class4.TextType == Enum156.const_1)
			{
				num3 -= class4.sizeF_0.Width;
			}
		}
		float num7 = 0f;
		num7 = ((!isCenter) ? (rectangleF_0.Width - num3) : ((rectangleF_0.Width - num3) / 2f));
		for (int k = num; k < textList.Count; k++)
		{
			Class779 class5 = (Class779)textList[k];
			if (class5.TextType == Enum156.const_2)
			{
				class5.rectangleF_0.X += num7;
			}
		}
	}

	private void method_7(List<Interface30> textList)
	{
		int num = 0;
		float num2 = float.MaxValue;
		float num3 = float.MinValue;
		float num4 = float.MaxValue;
		Class779 @class = null;
		for (int i = 0; i < textList.Count; i++)
		{
			Class779 class2 = (Class779)textList[i];
			if (class2.TextType != Enum156.const_2)
			{
				continue;
			}
			if (class2.rectangleF_0.Y > num4)
			{
				if (num2 != num3)
				{
					Font font = @class.Font;
					float num5 = method_9(font) * (float)font.FontFamily.GetCellAscent(font.Style) / (float)font.FontFamily.GetEmHeight(font.Style);
					float num6 = method_9(font) * (float)font.FontFamily.GetCellDescent(font.Style) / (float)font.FontFamily.GetEmHeight(font.Style);
					float num7 = method_9(font) * (float)font.FontFamily.GetLineSpacing(font.Style) / (float)font.FontFamily.GetEmHeight(font.Style);
					float num8 = num7 - num5 - num6;
					for (int j = num; j < i; j++)
					{
						Class779 class3 = (Class779)textList[j];
						if (class3.TextType == Enum156.const_2 && class3 != @class)
						{
							Font font2 = class3.Font;
							float num9 = method_9(font2);
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
		float num11 = method_9(font3);
		float num12 = num11 * (float)font3.FontFamily.GetCellAscent(font3.Style) / (float)font3.FontFamily.GetEmHeight(font3.Style);
		float num13 = num11 * (float)font3.FontFamily.GetCellDescent(font3.Style) / (float)font3.FontFamily.GetEmHeight(font3.Style);
		float num14 = num11 * (float)font3.FontFamily.GetLineSpacing(font3.Style) / (float)font3.FontFamily.GetEmHeight(font3.Style);
		float num15 = num14 - num12 - num13;
		for (int k = num; k < textList.Count; k++)
		{
			Class779 class4 = (Class779)textList[k];
			if (class4.TextType == Enum156.const_2 && class4 != @class)
			{
				Font font4 = class4.Font;
				float num16 = method_9(font4);
				_ = num16 * (float)font4.FontFamily.GetCellDescent(font4.Style) / (float)font4.FontFamily.GetEmHeight(font4.Style);
				float num17 = num16 * (float)font4.FontFamily.GetCellAscent(font4.Style) / (float)font4.FontFamily.GetEmHeight(font4.Style);
				_ = num16 * (float)font4.FontFamily.GetLineSpacing(font4.Style) / (float)font4.FontFamily.GetEmHeight(font4.Style);
				class4.rectangleF_0.Y += (num12 - num17 - num15) * float_2;
			}
		}
	}

	private void method_8(List<Interface30> textList, bool isCenter)
	{
		float num = float.MinValue;
		float num2 = float.MinValue;
		float num3 = 0f;
		for (int num4 = textList.Count - 1; num4 >= 0; num4--)
		{
			Class779 @class = (Class779)textList[num4];
			if (@class.TextType == Enum156.const_0)
			{
				if (num4 < textList.Count - 1)
				{
					num3 = ((((Class779)textList[num4 + 1]).TextType != Enum156.const_2) ? (num3 + float_0) : (num3 + num));
				}
				num = float.MinValue;
				num2 = float.MinValue;
			}
			else if (@class.TextType == Enum156.const_2)
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
				_ = @class.TextType;
			}
		}
		if (num != float.MinValue)
		{
			num3 += num;
		}
		float num5;
		if (isCenter)
		{
			_ = (Class779)textList[0];
			_ = (Class779)textList[textList.Count - 1];
			num5 = (rectangleF_0.Height - num3) / 2f;
		}
		else
		{
			num5 = rectangleF_0.Height - num3;
		}
		for (int num6 = textList.Count - 1; num6 >= 0; num6--)
		{
			Class779 class2 = (Class779)textList[num6];
			if (class2.TextType == Enum156.const_2)
			{
				class2.rectangleF_0.Y += num5;
			}
		}
	}

	private float method_9(Font font)
	{
		return (int)Math.Ceiling(interface32_0.GraphicsTools.imethod_2(font));
	}
}
