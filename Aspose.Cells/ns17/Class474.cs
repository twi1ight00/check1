using System;
using System.Collections;
using System.Drawing;
using Aspose.Cells;
using ns16;
using ns47;

namespace ns17;

internal class Class474
{
	internal ArrayList arrayList_0;

	internal float float_0;

	internal float float_1;

	internal float float_2;

	internal float float_3;

	internal float float_4;

	internal SizeF sizeF_0;

	internal float float_5;

	internal static float smethod_0(float float_6, double[] double_0)
	{
		return float_6;
	}

	internal Class474(ArrayList arrayList_1, bool bool_0, float float_6, float float_7, TextAlignmentType textAlignmentType_0, Class1620 class1620_0, double[] double_0)
	{
		Aspose.Cells.Font font = class1620_0.method_7().Font;
		arrayList_0 = new ArrayList();
		int idxSubDfr = -1;
		int idxInSubDfr = -1;
		sizeF_0 = default(SizeF);
		Class1460 @class = null;
		float stringHeight = 0f;
		bool flag = method_0(font, float_6, arrayList_1, bool_0, float_7, class1620_0.method_7().RotationAngle, class1620_0.method_7().RotationAngle == 255, out idxSubDfr, out idxInSubDfr, out sizeF_0, out stringHeight);
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		if (flag && idxInSubDfr >= 0 && idxSubDfr >= 0 && (class1620_0.method_7().IsTextWrapped || class1620_0.method_7().VerticalAlignment == TextAlignmentType.Justify || class1620_0.method_7().HorizontalAlignment == TextAlignmentType.Justify || class1620_0.method_7().RotationAngle == 255))
		{
			for (int i = 0; i < idxSubDfr; i++)
			{
				Class1544 class2 = (Class1544)arrayList_1[0];
				if (class2.string_0 != null && class2.string_0.Length > 0)
				{
					@class = Class1462.smethod_3(class2.font_0.Name, class2.font_0.method_30(), bool_0: false);
					float num4 = smethod_0(class2.font_0.Size, double_0);
					float num5 = @class.method_19(num4);
					if (float_4 < num5)
					{
						float_4 = num5;
					}
					if (!class2.font_0.IsSuperscript && !class2.font_0.IsSubscript)
					{
						num2 = @class.method_43(class2.string_0, num4);
						num3 = @class.method_45(class2.string_0, num4);
					}
					else
					{
						num2 = @class.method_43(class2.string_0, num4) * 0.6f;
						num3 = @class.method_45(class2.string_0, num4) * 0.6f;
					}
					arrayList_0.Add(new Class1094(class2, num, num2, num3));
					num += num2;
				}
				arrayList_1.RemoveAt(0);
			}
			Class1544 class3 = (Class1544)arrayList_1[0];
			if (class3.string_0 != null && class3.string_0.Length > 0)
			{
				Class1544 class4 = new Class1544();
				if (idxInSubDfr == int.MaxValue)
				{
					@class = Class1462.smethod_3(class3.font_0.Name, class3.font_0.method_30(), bool_0: false);
					float num6 = smethod_0(class3.font_0.Size, double_0);
					float num7 = @class.method_19(num6);
					if (float_4 < num7)
					{
						float_4 = num7;
					}
					class3.string_0 = class3.string_0.TrimEnd();
					if (!class3.font_0.IsSuperscript && !class3.font_0.IsSubscript)
					{
						num2 = @class.method_43(class3.string_0, num6);
						num3 = @class.method_45(class3.string_0, num6);
					}
					else
					{
						num2 = @class.method_43(class3.string_0, num6) * 0.6f;
						num3 = @class.method_45(class3.string_0, num6) * 0.6f;
					}
					num += num2;
					arrayList_1.RemoveAt(0);
				}
				else
				{
					class4.string_0 = class3.string_0.Substring(0, idxInSubDfr);
					class3.string_0 = class3.string_0.Substring(idxInSubDfr);
					class3.string_0 = class3.string_0.TrimStart();
					class4.font_0 = class3.font_0;
					class4.string_0 = class4.string_0.TrimEnd();
					if (class3.string_0.Length == 0)
					{
						arrayList_1.Remove(class3);
					}
					if (class4.string_0.Length != 0)
					{
						@class = Class1462.smethod_3(class4.font_0.Name, class4.font_0.method_30(), bool_0: false);
						float num8 = smethod_0(class3.font_0.Size, double_0);
						float num9 = @class.method_19(num8);
						if (float_4 < num9)
						{
							float_4 = num9;
						}
						if (!class4.font_0.IsSuperscript && !class4.font_0.IsSubscript)
						{
							num2 = @class.method_43(class4.string_0, num8);
							num3 = @class.method_45(class4.string_0, num8);
						}
						else
						{
							num2 = @class.method_43(class4.string_0, num8) * 0.6f;
							num3 = @class.method_45(class4.string_0, num8) * 0.6f;
						}
						arrayList_0.Add(new Class1094(class4, num, num2, num3));
						num += num2;
					}
				}
			}
			else
			{
				arrayList_1.RemoveAt(0);
			}
		}
		else
		{
			for (int j = 0; j < arrayList_1.Count; j++)
			{
				Class1544 class5 = (Class1544)arrayList_1[j];
				if (class5.font_0 == null)
				{
					class5.font_0 = font;
				}
				@class = Class1462.smethod_3(class5.font_0.Name, class5.font_0.method_30(), bool_0: false);
				float num10 = smethod_0(class5.font_0.Size, double_0);
				float num11 = @class.method_19(num10);
				if (float_4 < num11)
				{
					float_4 = num11;
				}
				if (!class5.font_0.IsSuperscript && !class5.font_0.IsSubscript)
				{
					num2 = @class.method_43(class5.string_0, num10);
					num3 = @class.method_45(class5.string_0, num10);
				}
				else
				{
					num2 = @class.method_43(class5.string_0, num10) * 0.6f;
					num3 = @class.method_45(class5.string_0, num10) * 0.6f;
				}
				arrayList_0.Add(new Class1094(class5, num, num2, num3));
				num += num2;
			}
			arrayList_1.RemoveRange(0, arrayList_1.Count);
		}
		float_2 = sizeF_0.Height * 72f / 96f * (float)double_0[1];
		float_1 = num * (float)double_0[0];
		float_4 += (sizeF_0.Height / 1.33333f - stringHeight) / 2f;
	}

	public static int smethod_1(string string_0, int int_0, FontStyle fontStyle_0)
	{
		int num = (int_0 * 20 * 96 + 720) / 1440;
		num = ~num + 1;
		int[] array = new int[10];
		Class1460 @class = Class1462.smethod_3(string_0, fontStyle_0, bool_0: false);
		for (int i = 48; i < 58; i++)
		{
			array[i - 48] = @class.method_61(Math.Abs(num), (char)i, int_0).int_6;
		}
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		num4 = array[0];
		for (int j = 0; j < 10; j++)
		{
			num3 = array[j];
			num2 += num3;
			if (num4 < num3)
			{
				num4 = num3;
			}
		}
		int num5 = (num2 + 9) / 10;
		if (num4 < num5)
		{
			num4 = num5;
		}
		return (num5 + 3) / 4;
	}

	private bool method_0(Aspose.Cells.Font defaultFont, float cellWidth, ArrayList dataFormatRuns, bool isFirstLine, float cellHeight, int rotateAngle, bool isVertical, out int idxSubDfr, out int idxInSubDfr, out SizeF lineSize, out float stringHeight)
	{
		float num = 0f;
		float num2 = 0f;
		int num3 = -1;
		int num4 = -1;
		int num5 = -1;
		int num6 = -1;
		float width = 0f;
		idxInSubDfr = -1;
		idxSubDfr = -1;
		lineSize = default(SizeF);
		stringHeight = 0f;
		float num7 = 0f;
		float num8 = 0f;
		int num9 = 1;
		int num10 = 1;
		float num11 = 0f;
		if (dataFormatRuns.Count > 0)
		{
			Class1544 @class = (Class1544)dataFormatRuns[0];
			if (@class.font_0 == null)
			{
				@class.font_0 = defaultFont;
			}
			num9 = smethod_1(@class.font_0.Name, @class.font_0.Size, @class.font_0.method_30());
			num10 = smethod_1(@class.font_0.Name, @class.font_0.Size, @class.font_0.method_30()) + 1;
		}
		int num12 = 0;
		while (true)
		{
			if (num12 < dataFormatRuns.Count)
			{
				Class1544 class2 = (Class1544)dataFormatRuns[num12];
				if (num12 == 0 && !isFirstLine)
				{
					class2.string_0 = class2.string_0.TrimStart();
				}
				idxSubDfr++;
				if (class2.font_0 == null)
				{
					class2.font_0 = defaultFont;
				}
				Class1460 class3 = Class1462.smethod_3(class2.font_0.Name, class2.font_0.method_30(), bool_0: false);
				num7 = class2.font_0.Size;
				float num13 = class3.method_17(class2.font_0.Size);
				if (stringHeight < num13)
				{
					stringHeight = num13;
				}
				num8 = Class1460.smethod_0(class2.font_0.Name, class2.font_0.Size, "|", class2.font_0.method_30()).Height;
				if (num2 < num8)
				{
					num2 = num8;
				}
				if (class2.enum217_0 == Enum217.flag_4)
				{
					break;
				}
				class2.string_0 = class2.string_0.Replace("\0", "");
				for (int i = 0; i < class2.string_0.Length; i++)
				{
					num3++;
					char c = class2.string_0[i];
					num7 = class2.font_0.Size;
					float num14 = class3.method_42(c, num7);
					if (class2.font_0.IsSubscript || class2.font_0.IsSuperscript)
					{
						num14 *= 0.6f;
					}
					if (!isVertical && (c == '-' || c == '/' || c == ' ') && num6 < num3 && i < class2.string_0.Length)
					{
						num5 = idxSubDfr;
						num4 = i;
						width = num;
						num6 = num3;
					}
					switch (rotateAngle)
					{
					default:
						num11 = (float)Math.Abs((double)cellHeight / Math.Sin((float)rotateAngle / 180f * 3.14f) - (double)num2 / Math.Tan((float)rotateAngle / 180f * 3.14f));
						break;
					case -90:
					case 90:
						num11 = cellHeight;
						break;
					case 0:
						num11 = cellWidth;
						break;
					}
					if (!(num + num14 > num11 - (float)num9 - (float)num10) && (!isVertical || num3 <= 0))
					{
						num += num14;
						continue;
					}
					if (i == 0)
					{
						idxSubDfr--;
						if (idxSubDfr < 0)
						{
							idxInSubDfr = 0;
							lineSize.Width = num;
							lineSize.Height = num2;
							return false;
						}
						idxInSubDfr = ((Class1544)dataFormatRuns[idxSubDfr]).string_0.Length;
						lineSize.Width = num;
						lineSize.Height = num2;
					}
					else if (num6 >= 0)
					{
						idxSubDfr = num5;
						idxInSubDfr = num4 + 1;
						lineSize.Width = width;
						lineSize.Height = num2;
					}
					else if (idxSubDfr > 0 && num6 < 0)
					{
						idxSubDfr--;
						idxInSubDfr = int.MaxValue;
						lineSize.Width = num;
						lineSize.Height = num2;
					}
					else
					{
						if (idxSubDfr >= 0)
						{
							idxInSubDfr = i;
						}
						lineSize.Width = num;
						lineSize.Height = num2;
					}
					return true;
				}
				num12++;
				continue;
			}
			lineSize.Width = num;
			lineSize.Height = num2;
			return false;
		}
		lineSize.Width = 1f;
		lineSize.Height = num2;
		idxInSubDfr = 0;
		return true;
	}
}
