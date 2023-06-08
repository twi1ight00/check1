using System;
using System.Collections;
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Cells;
using ns16;
using ns18;

namespace ns17;

internal class Class451
{
	internal float float_0;

	internal float float_1;

	internal float float_2;

	internal float float_3;

	internal TextAlignmentType textAlignmentType_0;

	internal TextAlignmentType textAlignmentType_1;

	internal ArrayList arrayList_0;

	private double[] double_0;

	internal bool bool_0;

	internal Class468 class468_0;

	private static Regex regex_0 = new Regex("([\\u0600-\\u06ff\\u0590-\\u05FF]+)|([^\\u0600-\\u06ff\\u0590-\\u05FF]+)|([\\w]+)");

	private static Regex regex_1 = new Regex("(\\S+|\\s+)");

	internal void Draw(Class454 class454_0)
	{
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Class474 @class = (Class474)arrayList_0[i];
			int num = 0;
			float num2 = @class.float_3;
			foreach (Class1094 item in @class.arrayList_0)
			{
				if (item == null)
				{
					continue;
				}
				Color color_ = Color.FromArgb(255, item.class1544_0.font_0.Color);
				FontStyle fontStyle_ = (item.class1544_0.font_0.IsBold ? FontStyle.Bold : FontStyle.Regular) | (item.class1544_0.font_0.IsItalic ? FontStyle.Italic : FontStyle.Regular) | (item.class1544_0.font_0.IsStrikeout ? FontStyle.Strikeout : FontStyle.Regular) | ((item.class1544_0.font_0.Underline != 0) ? FontStyle.Underline : FontStyle.Regular);
				item.class1544_0.string_0 = item.class1544_0.string_0.Replace('\r', ' ');
				float num3 = 0f;
				string string_ = item.class1544_0.string_0;
				if (string_.Length == 0)
				{
					continue;
				}
				Class463 class3;
				if (bool_0)
				{
					float num4 = Math.Max(0.1f, (float)item.class1544_0.font_0.Size * (float)double_0[1]);
					if (item.class1544_0.font_0.IsSubscript || item.class1544_0.font_0.IsSuperscript)
					{
						num4 *= 0.6f;
					}
					Class1396 class1396_ = Class1396.smethod_1(item.class1544_0.font_0.Name, num4, fontStyle_);
					num3 = float_2 - (item.float_0 + item.float_1) * (float)double_0[1] - (float)num * @class.float_5 - 2f;
					class3 = new Class463(class1396_, color_, new PointF(num3, @class.float_0 - @class.float_4 * (float)double_0[1]), string_, item.class1544_0.font_0.IsSuperscript, item.class1544_0.font_0.IsSubscript);
				}
				else
				{
					num3 = @class.float_3 + item.float_0;
					if (textAlignmentType_1 != TextAlignmentType.Justify && textAlignmentType_1 != TextAlignmentType.Right)
					{
						float num4 = Math.Max(0.1f, (float)item.class1544_0.font_0.Size * (float)double_0[0]);
						if (item.class1544_0.font_0.IsSubscript || item.class1544_0.font_0.IsSuperscript)
						{
							num4 *= 0.6f;
						}
						Class1396 class1396_ = Class1396.smethod_1(item.class1544_0.font_0.Name, num4, fontStyle_);
						class3 = new Class463(class1396_, color_, new PointF(num2, @class.float_0 - @class.float_4 * (float)double_0[1]), string_, item.class1544_0.font_0.IsSuperscript, item.class1544_0.font_0.IsSubscript);
						num2 += item.float_1 * (float)double_0[0];
						if (item.class1544_0 != null && item.class1544_0.string_0.Length > 0)
						{
							if (!(class468_0 is Class473))
							{
								class3.method_7(item.float_1 / item.float_2);
							}
							else
							{
								class3.method_7((float)((double)(item.float_1 - item.float_2) * double_0[0] / (double)(item.class1544_0.string_0.Length + 1)));
							}
						}
					}
					else
					{
						float num4 = Math.Max(0.1f, (float)item.class1544_0.font_0.Size * (float)double_0[1]);
						if (item.class1544_0.font_0.IsSubscript || item.class1544_0.font_0.IsSuperscript)
						{
							num4 *= 0.6f;
						}
						Class1396 class1396_ = Class1396.smethod_1(item.class1544_0.font_0.Name, num4, fontStyle_);
						class3 = new Class463(class1396_, color_, new PointF(num3 * (float)double_0[0] + (float)num * @class.float_5, @class.float_0 - @class.float_4 * (float)double_0[1]), string_, item.class1544_0.font_0.IsSuperscript, item.class1544_0.font_0.IsSubscript);
						if (!(class468_0 is Class473))
						{
							class3.method_7(item.float_1 / item.float_2);
						}
						else
						{
							class3.method_7(item.float_1 * (float)(double_0[0] - double_0[1]) / (float)(string_.Length + 1));
						}
					}
				}
				class3.fontUnderlineType_0 = item.class1544_0.font_0.Underline;
				if (item.class1544_0.enum217_0 != Enum217.flag_2)
				{
					class454_0.Add(class3);
				}
				num++;
			}
		}
	}

	internal Class451(ArrayList arrayList_1, Class1620 class1620_0, float float_4, float float_5, double[] double_1, bool bool_1)
	{
		arrayList_0 = new ArrayList();
		float_0 = float_4;
		float_1 = float_5;
		double_0 = (double[])double_1.Clone();
		method_1(class1620_0);
		method_0(class1620_0);
		bool_0 = bool_1;
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			Class1544 @class = (Class1544)arrayList_1[i];
			if (@class != null && @class.string_0 != null && @class.string_0.Length != 0)
			{
				@class.string_0 = @class.string_0.Replace('\r', ' ');
				int num = @class.string_0.IndexOf('\n');
				if (num >= 0)
				{
					Class1544 value = new Class1544
					{
						font_0 = @class.font_0,
						string_0 = @class.string_0.Substring(0, num)
					};
					@class.string_0 = @class.string_0.Substring(num + 1);
					arrayList_1.Insert(i, new Class1544
					{
						font_0 = @class.font_0,
						string_0 = "",
						enum217_0 = Enum217.flag_4
					});
					arrayList_1.Insert(i, value);
				}
			}
		}
		while (arrayList_1.Count > 0)
		{
			arrayList_0.Add(new Class474(arrayList_1, arrayList_0.Count == 0, float_0 - class1620_0.method_2() * 1.3333f, float_1, textAlignmentType_1, class1620_0, double_0));
		}
		foreach (Class474 item in arrayList_0)
		{
			if (float_2 < item.float_1)
			{
				float_2 = item.float_1;
			}
			float_3 += item.float_2;
		}
		method_2(class1620_0);
	}

	private void method_0(Class1620 class1620_0)
	{
		textAlignmentType_0 = class1620_0.method_7().VerticalAlignment;
		if (class1620_0.method_7().RotationAngle <= 0)
		{
			_ = class1620_0.method_7().RotationAngle;
		}
		if (class1620_0.method_7().RotationAngle == 0)
		{
			textAlignmentType_0 = class1620_0.method_7().VerticalAlignment;
		}
	}

	private void method_1(Class1620 class1620_0)
	{
		textAlignmentType_1 = class1620_0.method_15();
		if (class1620_0.method_7().RotationAngle > 0)
		{
			switch (class1620_0.method_7().VerticalAlignment)
			{
			case TextAlignmentType.Top:
				textAlignmentType_1 = TextAlignmentType.Right;
				break;
			default:
				textAlignmentType_1 = class1620_0.method_7().VerticalAlignment;
				break;
			case TextAlignmentType.Bottom:
				textAlignmentType_1 = TextAlignmentType.Left;
				break;
			}
		}
		else if (class1620_0.method_7().RotationAngle < 0)
		{
			switch (class1620_0.method_7().VerticalAlignment)
			{
			case TextAlignmentType.Top:
				textAlignmentType_1 = TextAlignmentType.Left;
				break;
			default:
				textAlignmentType_1 = class1620_0.method_7().VerticalAlignment;
				break;
			case TextAlignmentType.Bottom:
				textAlignmentType_1 = TextAlignmentType.Right;
				break;
			}
		}
		else
		{
			switch (textAlignmentType_1)
			{
			case TextAlignmentType.Fill:
				textAlignmentType_1 = TextAlignmentType.Left;
				break;
			case TextAlignmentType.General:
				break;
			case TextAlignmentType.Distributed:
			case TextAlignmentType.Justify:
				textAlignmentType_1 = TextAlignmentType.Justify;
				break;
			}
		}
	}

	private void method_2(Class1620 class1620_0)
	{
		float num = 0f;
		float num2 = num;
		float_2 += class1620_0.method_2();
		for (int num3 = arrayList_0.Count - 1; num3 >= 0; num3--)
		{
			Class474 @class = (Class474)arrayList_0[num3];
			@class.float_0 -= num2;
			num2 += @class.float_2;
			switch (textAlignmentType_1)
			{
			case TextAlignmentType.Center:
			case TextAlignmentType.CenterAcross:
				@class.float_3 = (float_2 - @class.float_1) / 2f;
				break;
			case TextAlignmentType.Justify:
				@class.float_3 = 1f;
				float_2 = float_0 / 96f * 72f * (float)double_0[0];
				if (@class.arrayList_0.Count >= 2)
				{
					@class.float_5 = (float_2 - 2f - @class.float_1) / (float)(@class.arrayList_0.Count - 1);
				}
				if (!(@class.float_5 < 0f) && num3 == arrayList_0.Count - 1)
				{
					@class.float_5 = 0f;
				}
				break;
			case TextAlignmentType.Left:
				@class.float_3 = 1f + class1620_0.method_2();
				break;
			case TextAlignmentType.Right:
				@class.float_3 = float_2 - @class.float_1 - 1f - class1620_0.method_2();
				break;
			}
		}
	}
}
