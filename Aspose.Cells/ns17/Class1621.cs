using System.Collections;
using System.Text.RegularExpressions;
using Aspose.Cells;
using ns16;

namespace ns17;

internal class Class1621
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

	private static Regex regex_0 = new Regex("([\\u0600-\\u06ff\\u0590-\\u05FF]+)|([^\\u0600-\\u06ff\\u0590-\\u05FF]+)|([\\w]+)");

	private static Regex regex_1 = new Regex("(\\S+|\\s+)");

	internal static void smethod_0(ArrayList arrayList_1)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			Class1544 @class = (Class1544)arrayList_1[i];
			string string_ = @class.string_0;
			foreach (char c in string_)
			{
				Class1544 class2 = new Class1544();
				class2.string_0 = "" + c;
				class2.font_0 = @class.font_0;
				class2.enum217_0 = @class.enum217_0;
				arrayList.Add(class2);
			}
		}
		arrayList_1.Clear();
		arrayList_1.AddRange(arrayList);
	}

	internal static void smethod_1(ArrayList arrayList_1)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			Class1544 @class = (Class1544)arrayList_1[i];
			Font font_ = @class.font_0;
			int length = @class.string_0.Length;
			Match match;
			for (int j = 0; j < length; j += match.Length)
			{
				match = regex_1.Match(@class.string_0, j);
				if (!match.Success)
				{
					break;
				}
				Class1544 class2 = new Class1544();
				class2.string_0 = match.Value;
				class2.font_0 = font_;
				class2.enum217_0 = @class.enum217_0;
				arrayList.Add(class2);
			}
		}
		arrayList_1.Clear();
		arrayList_1.AddRange(arrayList);
	}

	internal Class1621(ArrayList arrayList_1, Class1620 class1620_0, float float_4, float float_5, double[] double_1, bool bool_1)
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
			arrayList_0.Add(new Class1093(arrayList_1, arrayList_0.Count == 0, float_0 - class1620_0.method_2(), textAlignmentType_1, class1620_0, double_0));
		}
		foreach (Class1093 item in arrayList_0)
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
		if (class1620_0.method_7().RotationAngle > 0)
		{
			switch (class1620_0.method_7().HorizontalAlignment)
			{
			default:
				textAlignmentType_0 = class1620_0.method_7().HorizontalAlignment;
				break;
			case TextAlignmentType.Left:
				textAlignmentType_0 = TextAlignmentType.Bottom;
				break;
			case TextAlignmentType.Right:
				textAlignmentType_0 = TextAlignmentType.Top;
				break;
			}
			float num = float_1;
			float_1 = float_0;
			float_0 = num;
			double num2 = double_0[0];
			double_0[0] = double_0[1];
			double_0[1] = num2;
		}
		else if (class1620_0.method_7().RotationAngle < 0)
		{
			switch (class1620_0.method_7().HorizontalAlignment)
			{
			default:
				textAlignmentType_0 = class1620_0.method_7().HorizontalAlignment;
				break;
			case TextAlignmentType.Left:
				textAlignmentType_0 = TextAlignmentType.Top;
				break;
			case TextAlignmentType.Right:
				textAlignmentType_0 = TextAlignmentType.Bottom;
				break;
			}
			float num3 = float_1;
			float_1 = float_0;
			float_0 = num3;
			double num4 = double_0[0];
			double_0[0] = double_0[1];
			double_0[1] = num4;
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
		for (int num3 = arrayList_0.Count - 1; num3 >= 0; num3--)
		{
			Class1093 @class = (Class1093)arrayList_0[num3];
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
		float_2 += class1620_0.method_2();
	}
}
