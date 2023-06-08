using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Aspose.XfaConverter.Elements;
using ns216;
using ns224;
using ns235;

namespace ns215;

internal class Class5937
{
	private class Class5938
	{
		internal string string_0;

		internal Class5999 class5999_0;

		internal PointF pointF_0;

		internal SizeF sizeF_0;

		internal int int_0 = 1;

		internal int int_1;

		internal XfaEnums.Enum719 enum719_0;

		internal XfaEnums.Enum720 enum720_0;

		internal Class5998 class5998_0;

		internal Class5938(string text, Class5999 font, PointF pos, SizeF size, int paragraph, XfaEnums.Enum719 hAlign, XfaEnums.Enum720 vAlign, Class5998 color)
		{
			string_0 = text;
			class5999_0 = font;
			pointF_0 = pos;
			sizeF_0 = size;
			int_1 = paragraph;
			enum719_0 = hAlign;
			enum720_0 = vAlign;
			class5998_0 = color;
		}
	}

	private bool bool_0;

	private List<Class5938> list_0 = new List<Class5938>();

	private Dictionary<string, Interface246> dictionary_0 = new Dictionary<string, Interface246>();

	internal bool Initialized => bool_0;

	internal void method_0(Class6213 canvas, PointF pos, SizeF size)
	{
		if (!Initialized)
		{
			return;
		}
		Class6213 @class = new Class6213();
		@class.RenderTransform = new Class6002(1f, 0f, 0f, 1f, pos.X, pos.Y);
		canvas.Add(@class);
		foreach (Class5938 item in list_0)
		{
			@class.Add(new Class6219(item.class5999_0, item.class5998_0, item.class5998_0, item.pointF_0, item.string_0.Trim('\u2028', '\u2029'), size, 0f));
		}
	}

	private void method_1(string text, Class5999 font, PointF pos, SizeF size, int paragraph, XfaEnums.Enum719 hAlign, XfaEnums.Enum720 vAlign, Class5998 color, int line)
	{
		text = text.Replace("\r", string.Empty);
		text = text.Replace("\n", string.Empty);
		text = text.Replace("\u00a0", string.Empty);
		if (text.Length != 0 && text.Trim(' ').Length != 0)
		{
			pos = new PointF(pos.X, pos.Y - font.DescentPoints);
			Class5938 @class = new Class5938(text, font, pos, size, paragraph, hAlign, vAlign, color);
			@class.int_0 = line;
			list_0.Add(@class);
		}
	}

	internal SizeF Initialize(ArrayList textAttributes, Class5836 para, Class5829 margin, Interface250 location, Class5998 color, Class5873 hyphenation, Class5783 xfaElement)
	{
		list_0.Clear();
		bool_0 = true;
		PointF pointF = new PointF(0f, 0f);
		float num = location.W;
		if (num == 0f)
		{
			num = ((location.MaxW == 0f) ? 10000f : location.MaxW);
		}
		if (margin != null)
		{
			num -= margin.LeftInset + margin.RightInset;
			pointF.X += margin.LeftInset;
			pointF.Y += margin.TopInset;
		}
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		int num6 = 0;
		bool flag = false;
		int num7 = 7;
		int num8 = 3;
		int num9 = 3;
		if (hyphenation != null)
		{
			flag = hyphenation.Hyphenate;
			num7 = hyphenation.WordCharacterCount;
			num8 = hyphenation.RemainCharacterCount;
			num9 = hyphenation.PushCharacterCount;
		}
		int num10 = 1;
		foreach (Class5913 textAttribute in textAttributes)
		{
			string @object = "Courier";
			float object2 = 10f;
			XfaEnums.Enum709 @enum = XfaEnums.Enum709.const_0;
			XfaEnums.Enum710 enum2 = XfaEnums.Enum710.const_0;
			int object3 = 0;
			float object4 = 0f;
			float object5 = 0f;
			float object6 = 0f;
			float object7 = 0f;
			float object8 = 0f;
			float object9 = 0f;
			float object10 = 36f;
			string object11 = string.Empty;
			textAttribute.method_3(Enum739.const_14, ref object10);
			bool flag2 = true;
			if (textAttribute.method_0(Enum739.const_21) && textAttribute.method_0(Enum739.const_20) && textAttribute.method_0(Enum739.const_19))
			{
				string object12 = string.Empty;
				string object13 = string.Empty;
				string object14 = string.Empty;
				textAttribute.method_2(Enum739.const_21, ref object12);
				textAttribute.method_2(Enum739.const_20, ref object13);
				textAttribute.method_2(Enum739.const_19, ref object14);
				if (object14 == "uri" && object13 == "raw")
				{
					textAttribute.method_2(Enum739.const_16, ref object11);
					flag2 = false;
					if (object11 == "###EmbedAnchor")
					{
						object11 = " ";
					}
					if (!string.IsNullOrEmpty(object12) && xfaElement.Parent != null)
					{
						string key = object12.TrimStart('#');
						Interface246 @interface;
						if (!dictionary_0.ContainsKey(key))
						{
							@interface = ((Class5784)xfaElement.method_2()).IdElementsDictionary[key] as Interface246;
							if (@interface != null)
							{
								@interface.imethod_0(xfaElement);
								dictionary_0[key] = @interface;
							}
						}
						else
						{
							@interface = dictionary_0[key];
						}
						if (@interface != null)
						{
							object11 = @interface.imethod_1();
							if (object11 == null)
							{
								object11 = " ";
							}
						}
					}
				}
			}
			if (flag2)
			{
				textAttribute.method_2(Enum739.const_16, ref object11);
			}
			textAttribute.method_2(Enum739.const_0, ref @object);
			textAttribute.method_3(Enum739.const_1, ref object2);
			if (object2 == 0f)
			{
				continue;
			}
			if (textAttribute.method_0(Enum739.const_2))
			{
				@enum = (XfaEnums.Enum709)textAttribute[Enum739.const_2];
			}
			if (textAttribute.method_0(Enum739.const_3))
			{
				enum2 = (XfaEnums.Enum710)textAttribute[Enum739.const_3];
			}
			if (para != null)
			{
				object5 = para.MarginLeft;
				object6 = para.MarginRight;
			}
			textAttribute.method_4(Enum739.const_6, ref object3);
			textAttribute.method_3(Enum739.const_9, ref object5);
			textAttribute.method_3(Enum739.const_10, ref object6);
			textAttribute.method_3(Enum739.const_11, ref object7);
			textAttribute.method_3(Enum739.const_8, ref object8);
			XfaEnums.Enum719 object15 = XfaEnums.Enum719.const_6;
			XfaEnums.Enum720 object16 = XfaEnums.Enum720.const_3;
			textAttribute.method_7(Enum739.const_18, ref object16);
			textAttribute.method_6(Enum739.const_17, ref object15);
			if (textAttribute.method_0(Enum739.const_7))
			{
				object5 = (object6 = (object7 = (object8 = (float)textAttribute[Enum739.const_7])));
			}
			textAttribute.method_3(Enum739.const_12, ref object9);
			textAttribute.method_3(Enum739.const_4, ref object4);
			if (para != null && para.LineHeight != 0f)
			{
				object4 = para.LineHeight;
			}
			FontStyle fontStyle = FontStyle.Regular;
			if (@enum == XfaEnums.Enum709.const_1)
			{
				fontStyle |= FontStyle.Italic;
			}
			if (enum2 == XfaEnums.Enum710.const_1)
			{
				fontStyle |= FontStyle.Bold;
			}
			Class5999 class2 = new Class5999(object2, fontStyle, Class5907.smethod_0(@object, fontStyle));
			if (object4 == 0f)
			{
				object4 = class2.LineSpacingPoints;
			}
			if (textAttribute.method_0(Enum739.const_15))
			{
				num3 += object4;
				num2 = object5 - object9;
				num4 += object4;
				continue;
			}
			if (textAttributes.IndexOf(textAttribute) == 0)
			{
				num2 = object5;
			}
			if (object3 != num6)
			{
				num10 = 1;
				if (object3 > 0 && textAttributes.IndexOf(textAttribute) != 0)
				{
					num2 = object5;
					num3 += object4;
					num6 = object3;
				}
			}
			if (textAttribute.method_0(Enum739.const_13))
			{
				int num11 = (int)textAttribute[Enum739.const_13];
				num2 += (float)num11 * object10 - num2 % object10;
				continue;
			}
			string[] array = object11.Split('\r', '\n', '\u2029');
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				if (text.Length == 0)
				{
					num4 = Math.Max(num4, new PointF(pointF.X + num2, pointF.Y + object4 + num3).Y);
				}
				bool flag3 = false;
				while (text.Length > 0)
				{
					SizeF size = class2.method_4(text);
					float width = size.Width;
					if (num2 + width > num - object6)
					{
						int length = text.Length;
						short[] array2 = null;
						short[] array3 = null;
						if (flag)
						{
							array2 = new short[length];
							array3 = new short[length];
							int num12 = 0;
							short num13 = 0;
							for (int j = 0; j < length; j++)
							{
								if (text[j] != ' ' && text[j] != '/')
								{
									num13 = (short)(num13 + 1);
									continue;
								}
								array2[j] = 0;
								array3[j] = 0;
								short num14 = 1;
								for (int k = num12; k < j; k++)
								{
									array2[k] = num13;
									array3[k] = num14++;
								}
								num12 = j + 1;
								num13 = 0;
							}
							if (num13 != 0)
							{
								short num15 = 1;
								for (int l = num12; l < length; l++)
								{
									array2[l] = num13;
									array3[l] = num15++;
								}
							}
						}
						bool flag4 = false;
						for (int num16 = length - 1; num16 >= 0; num16--)
						{
							if (text[num16] == ' ' || text[num16] == '/')
							{
								flag3 = true;
							}
							if (flag && !flag3 && num16 > 0)
							{
								int num17 = num16 - 1;
								flag3 = array2[num17] >= num7 && array3[num17] >= num8 && array2[num17] - array3[num17] >= num9;
								flag4 = true;
							}
							else
							{
								flag4 = false;
							}
							if (flag3 && num16 != 0)
							{
								string text2 = text.Substring(0, num16);
								if (flag4)
								{
									text2 += "-";
								}
								SizeF size2 = class2.method_4(text2);
								float width2 = size2.Width;
								if (!(num2 + width2 > num - object6))
								{
									PointF pos = new PointF(pointF.X + num2, pointF.Y + object4 + num3);
									method_1(text2, class2, pos, size2, object3, object15, object16, color, num10);
									num4 = Math.Max(num4, pos.Y + object4);
									num5 = Math.Max(num5, num2 + width2);
									if (num16 < text.Length - 1)
									{
										int num18 = ((text[num16] == ' ') ? (num16 + 1) : num16);
										text = text.Substring(num18, text.Length - num18);
										num3 += object4;
										num10++;
										num2 = object5 - object9;
									}
									else
									{
										num2 += width2;
										text = string.Empty;
									}
									break;
								}
								flag3 = false;
							}
							if (num16 == 0)
							{
								SizeF size3 = class2.method_4(text);
								float width3 = size3.Width;
								if (num2 + width3 > num - object6)
								{
									if (num2 == object5 - object9)
									{
										PointF pos2 = new PointF(pointF.X + num2, pointF.Y + object4 + num3);
										method_1(text, class2, pos2, size3, object3, object15, object16, color, num10);
										num4 = Math.Max(num4, pos2.Y + object4);
										num5 = Math.Max(num5, num);
										text = string.Empty;
									}
								}
								else if (text.IndexOf(" ") == -1)
								{
									flag3 = true;
								}
								else
								{
									text = string.Empty;
								}
								num2 = object5 - object9;
								num3 += object4;
								num10++;
							}
						}
						continue;
					}
					PointF pos3 = new PointF(pointF.X + num2, pointF.Y + object4 + num3);
					method_1(text, class2, pos3, size, object3, object15, object16, color, num10);
					num4 = Math.Max(num4, pos3.Y);
					num2 += width;
					num5 = Math.Max(num5, num2);
					break;
				}
				if (text.Length == 0 || i + 1 <= array.Length - 1)
				{
					num2 = object5 - object9;
					num3 += object4;
					num10++;
				}
			}
		}
		float num19 = Math.Max(location.MinW, location.W);
		float num20 = Math.Max(location.MinH, location.H);
		List<Class5938> list = new List<Class5938>();
		List<Class5938> list2 = new List<Class5938>();
		for (int m = 0; m < list_0.Count; m++)
		{
			if (m > 0 && list_0[m].int_1 != list_0[m - 1].int_1)
			{
				list2.AddRange(smethod_0(list, para, num19, num5, num20, num4));
				list.Clear();
			}
			list.Add(list_0[m]);
		}
		if (list.Count > 0)
		{
			list2.AddRange(smethod_0(list, para, num19, num5, num20, num4));
		}
		list_0 = list2;
		if (location.H == 0f)
		{
			if (margin != null)
			{
				num4 += margin.BottomInset;
			}
			return new SizeF(num19, num4);
		}
		return new SizeF(num19, num20);
	}

	private static List<Class5938> smethod_0(List<Class5938> textFragments, Class5836 para, float elementWidth, float maxWidth, float elementHeight, float height)
	{
		Class5938 @class = textFragments[0];
		XfaEnums.Enum719 @enum = ((@class.enum719_0 != XfaEnums.Enum719.const_6) ? @class.enum719_0 : (para?.HAlign ?? XfaEnums.Enum719.const_6));
		XfaEnums.Enum720 enum2 = ((@class.enum720_0 != XfaEnums.Enum720.const_3) ? @class.enum720_0 : (para?.VAlign ?? XfaEnums.Enum720.const_3));
		float num = 0f;
		float num2 = 0f;
		switch (@enum)
		{
		case XfaEnums.Enum719.const_1:
			foreach (Class5938 textFragment in textFragments)
			{
				float num3 = elementWidth / 2f - textFragment.sizeF_0.Width / 2f;
				textFragment.pointF_0 = new PointF(textFragment.pointF_0.X + num3, textFragment.pointF_0.Y);
			}
			break;
		case XfaEnums.Enum719.const_2:
		case XfaEnums.Enum719.const_3:
		{
			List<Class5938> list = new List<Class5938>();
			List<Class5938> list2 = new List<Class5938>();
			foreach (Class5938 textFragment2 in textFragments)
			{
				if (list2.Count == 0)
				{
					list2.Add(textFragment2);
					continue;
				}
				float y = list2[list2.Count - 1].pointF_0.Y;
				int int_ = list2[list2.Count - 1].int_0;
				int int_2 = list2[list2.Count - 1].int_1;
				if ((int_2 == textFragment2.int_1 && int_ != textFragment2.int_0) || (int_2 != textFragment2.int_1 && y != textFragment2.pointF_0.Y))
				{
					if (int_2 == textFragment2.int_1)
					{
						smethod_1(elementWidth, list2, list);
					}
					else
					{
						foreach (Class5938 item in list2)
						{
							list.Add(item);
						}
					}
					list2.Clear();
				}
				list2.Add(textFragment2);
			}
			if (list2.Count > 0)
			{
				if (@enum == XfaEnums.Enum719.const_3)
				{
					smethod_1(elementWidth, list2, list);
				}
				else
				{
					foreach (Class5938 item2 in list2)
					{
						list.Add(item2);
					}
				}
			}
			textFragments = list;
			break;
		}
		case XfaEnums.Enum719.const_5:
			num = elementWidth - maxWidth;
			break;
		}
		switch (enum2)
		{
		case XfaEnums.Enum720.const_1:
			if (elementHeight != 0f)
			{
				num2 = elementHeight - Math.Min(height, elementHeight);
			}
			break;
		case XfaEnums.Enum720.const_2:
			if (elementHeight != 0f)
			{
				num2 = elementHeight / 2f - Math.Min(height, elementHeight) / 2f;
			}
			break;
		}
		if (num != 0f || num2 != 0f)
		{
			foreach (Class5938 textFragment3 in textFragments)
			{
				textFragment3.pointF_0 = new PointF(textFragment3.pointF_0.X + num, textFragment3.pointF_0.Y + num2);
			}
		}
		return textFragments;
	}

	private static void smethod_1(float elementWidth, List<Class5938> inlineTexFragments, List<Class5938> textFragmentsNew)
	{
		float num = 0f;
		foreach (Class5938 inlineTexFragment in inlineTexFragments)
		{
			num += inlineTexFragment.sizeF_0.Width;
		}
		if (inlineTexFragments.Count > 0)
		{
			num += inlineTexFragments[0].pointF_0.X;
		}
		float num2 = elementWidth - num;
		if (num2 > 0f)
		{
			float num3 = 0f;
			for (int i = 0; i < inlineTexFragments.Count; i++)
			{
				Class5938 @class = inlineTexFragments[i];
				if (i == 0)
				{
					num3 = @class.pointF_0.X;
				}
				if (@class.string_0.Trim(' ').Length == 0)
				{
					num3 += num2 * @class.sizeF_0.Width / num;
					continue;
				}
				string[] array = @class.string_0.Split(' ');
				if (array.Length > 1)
				{
					float num4 = num2 / (float)array.Length * @class.sizeF_0.Width / num;
					for (int j = 0; j < array.Length; j++)
					{
						string text = array[j];
						string text2 = text;
						if (j < array.Length - 1)
						{
							text2 += " ";
						}
						float width = @class.class5999_0.method_4(text2).Width;
						textFragmentsNew.Add(new Class5938(text, @class.class5999_0, new PointF(num3, @class.pointF_0.Y), new SizeF(width, @class.sizeF_0.Height), @class.int_1, @class.enum719_0, @class.enum720_0, @class.class5998_0));
						num3 += width + num4;
					}
				}
				else
				{
					@class.pointF_0 = new PointF(num3, @class.pointF_0.Y);
					textFragmentsNew.Add(@class);
					num3 += @class.sizeF_0.Width;
				}
			}
			return;
		}
		foreach (Class5938 inlineTexFragment2 in inlineTexFragments)
		{
			textFragmentsNew.Add(inlineTexFragment2);
		}
	}
}
