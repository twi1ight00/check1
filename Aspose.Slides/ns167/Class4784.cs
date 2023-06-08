using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ns161;
using ns169;
using ns224;
using ns235;

namespace ns167;

internal class Class4784 : Class4783
{
	private const int int_1 = 3;

	private const int int_2 = 0;

	private const int int_3 = 1;

	private const int int_4 = 2;

	private bool bool_1;

	private bool bool_2;

	private Class4783 class4783_0;

	private Class4783 class4783_1;

	private RectangleF rectangleF_0;

	private Enum672 enum672_1;

	internal static readonly float float_5 = 0.7f;

	private static readonly IComparer icomparer_0 = Class4847.smethod_0();

	internal override RectangleF BoundingBox => rectangleF_0;

	internal Class4846 TextSubSuperscriptParts
	{
		get
		{
			Class4846 @class = new Class4846();
			if (bool_2)
			{
				foreach (Class4845 item in class4783_1)
				{
					@class.Add(item);
				}
			}
			if (bool_1)
			{
				foreach (Class4845 item2 in class4783_0)
				{
					@class.Add(item2);
				}
			}
			return @class;
		}
	}

	internal override string Text
	{
		get
		{
			if (!(bool_2 | bool_1))
			{
				return base.Text;
			}
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < base.PageElementCount; i++)
			{
				arrayList.Add(base[i]);
			}
			if (bool_2)
			{
				for (int j = 0; j < class4783_1.PageElementCount; j++)
				{
					arrayList.Add(class4783_1[j]);
				}
			}
			if (bool_1)
			{
				for (int k = 0; k < class4783_0.PageElementCount; k++)
				{
					arrayList.Add(class4783_0[k]);
				}
			}
			Class4813.smethod_0(arrayList);
			StringBuilder stringBuilder = new StringBuilder();
			for (int l = 0; l < arrayList.Count; l++)
			{
				stringBuilder.Append(((Class4779)arrayList[l]).Text);
			}
			stringBuilder.Append("\n");
			return stringBuilder.ToString();
		}
	}

	internal override Enum672 Style
	{
		get
		{
			if (enum672_1 == Enum672.flag_0)
			{
				method_40();
			}
			return enum672_1;
		}
	}

	internal override PointF Origin
	{
		get
		{
			if (base.PageElementCount == 0)
			{
				if (bool_2)
				{
					return class4783_1[0].Origin;
				}
				if (bool_1)
				{
					return class4783_0[0].Origin;
				}
				throw new InvalidOperationException("Please report exception. Text line is empty.");
			}
			return base.Origin;
		}
		set
		{
			PointF offset = new PointF(value.X - base.Origin.X, value.Y - base.Origin.Y);
			method_35(offset);
			if (bool_2)
			{
				class4783_1.method_35(offset);
			}
			if (bool_1)
			{
				class4783_0.method_35(offset);
			}
			rectangleF_0.X += offset.X;
			rectangleF_0.Y += offset.Y;
		}
	}

	internal bool HasSubscript => bool_2;

	internal bool HasSuperscript => bool_1;

	internal Class4784(Class4783 sourceLine)
	{
		for (int i = 0; i < sourceLine.PageElementCount; i++)
		{
			Add(sourceLine[i]);
			method_39();
		}
		enum672_1 = Enum672.flag_0;
	}

	internal float method_36()
	{
		float num = 0f;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class4845 @class = (Class4845)enumerator.Current;
				if (@class.Value is Class4791 class2 && class2.Font != null)
				{
					num = Math.Max(num, class2.Font.AscentPoints);
				}
			}
			return num;
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	internal Class4784(Class4846 elements)
	{
		foreach (Class4845 element in elements)
		{
			Add(element.Value);
			element.Remove();
			method_39();
		}
		enum672_1 = Enum672.flag_0;
	}

	internal Class4784(List<Class4779> elements)
		: base(elements)
	{
		method_39();
		enum672_1 = Enum672.flag_0;
	}

	internal Class4784(Class4791 element)
		: base(element)
	{
		method_39();
		enum672_1 = Enum672.flag_0;
	}

	internal override void vmethod_1(Class6216 targetPage)
	{
		base.vmethod_1(targetPage);
		Class4842.smethod_0(targetPage, BoundingBox, Class4842.color_0);
		if (bool_2)
		{
			class4783_1.vmethod_1(targetPage);
			Class4842.smethod_0(targetPage, class4783_1.BoundingBox, Class4842.color_1);
		}
		if (bool_1)
		{
			class4783_0.vmethod_1(targetPage);
			Class4842.smethod_0(targetPage, class4783_0.BoundingBox, Class4842.color_2);
		}
	}

	internal override bool Add(Class4779 element)
	{
		bool flag = true;
		if (!(element is Class4791) && !(element is Class4790))
		{
			if (element is Class4784 @class)
			{
				for (int i = 0; i < @class.PageElementCount; i++)
				{
					Add(@class[i]);
				}
				if (@class.bool_2)
				{
					for (int j = 0; j < @class.class4783_1.PageElementCount; j++)
					{
						method_38(@class.class4783_1[j]);
					}
				}
				if (@class.bool_1)
				{
					for (int k = 0; k < @class.class4783_0.PageElementCount; k++)
					{
						method_37(@class.class4783_0[k]);
					}
				}
			}
			else if (element is Class4783 class2)
			{
				foreach (Class4845 item in class2)
				{
					Add(item.Value);
				}
			}
			else if (element is Class4785 class4)
			{
				foreach (Class4845 item2 in class4)
				{
					Add(item2.Value);
				}
			}
			else
			{
				flag = false;
			}
		}
		else
		{
			base.Add(element);
		}
		if (flag)
		{
			method_39();
			enum672_1 = Enum672.flag_0;
		}
		return flag;
	}

	internal void method_37(Class4779 textPart)
	{
		bool_1 = true;
		if (class4783_0 == null)
		{
			class4783_0 = new Class4783();
		}
		if (textPart is Class4791)
		{
			class4783_0.Add(textPart);
		}
		else
		{
			if (!(textPart is Class4784))
			{
				throw new InvalidOperationException("Please report exception. Unknown text part found during text line grouping.");
			}
			Class4784 @class = (Class4784)textPart;
			for (int i = 0; i < @class.PageElementCount; i++)
			{
				class4783_0.Add(@class[i]);
			}
			if (@class.bool_2)
			{
				for (int j = 0; j < @class.class4783_1.PageElementCount; j++)
				{
					class4783_0.Add(@class.class4783_1[j]);
				}
			}
			if (@class.bool_1)
			{
				for (int k = 0; k < @class.class4783_0.PageElementCount; k++)
				{
					class4783_0.Add(@class.class4783_0[k]);
				}
			}
		}
		method_39();
	}

	internal void method_38(Class4779 textPart)
	{
		bool_2 = true;
		if (class4783_1 == null)
		{
			class4783_1 = new Class4783();
		}
		if (textPart is Class4791)
		{
			class4783_1.Add(textPart);
		}
		else
		{
			if (!(textPart is Class4784))
			{
				throw new InvalidOperationException("Please report exception. Unknown text part found during text line grouping.");
			}
			Class4784 @class = (Class4784)textPart;
			for (int i = 0; i < @class.PageElementCount; i++)
			{
				class4783_1.Add(@class[i]);
			}
			if (@class.bool_2)
			{
				for (int j = 0; j < @class.class4783_1.PageElementCount; j++)
				{
					class4783_1.Add(@class.class4783_1[j]);
				}
			}
			if (@class.bool_1)
			{
				for (int k = 0; k < @class.class4783_0.PageElementCount; k++)
				{
					class4783_1.Add(@class.class4783_0[k]);
				}
			}
		}
		method_39();
	}

	private void method_39()
	{
		vmethod_0();
		rectangleF_0 = class4844_0.BoundingBox;
		if (bool_1)
		{
			for (int i = 0; i < class4783_0.PageElementCount; i++)
			{
				if (rectangleF_0.Top > class4783_0[i].BoundingBox.Top)
				{
					rectangleF_0.Height += rectangleF_0.Top - class4783_0[i].BoundingBox.Top;
					rectangleF_0.Y = class4783_0[i].BoundingBox.Y;
				}
				if (rectangleF_0.Left > class4783_0[i].BoundingBox.Left)
				{
					rectangleF_0.Width += rectangleF_0.Left - class4783_0[i].BoundingBox.Left;
					rectangleF_0.X = class4783_0[i].BoundingBox.X;
				}
				if (rectangleF_0.Right < class4783_0[i].BoundingBox.Right)
				{
					rectangleF_0.Width += class4783_0[i].BoundingBox.Right - rectangleF_0.Right;
				}
			}
		}
		if (!bool_2)
		{
			return;
		}
		for (int j = 0; j < class4783_1.PageElementCount; j++)
		{
			if (rectangleF_0.Bottom < class4783_1[j].BoundingBox.Bottom)
			{
				rectangleF_0.Height += class4783_1[j].BoundingBox.Bottom - rectangleF_0.Bottom;
			}
			if (rectangleF_0.Left > class4783_1[j].BoundingBox.Left)
			{
				rectangleF_0.Width += rectangleF_0.Left - class4783_1[j].BoundingBox.Left;
				rectangleF_0.X = class4783_1[j].BoundingBox.X;
			}
			if (rectangleF_0.Right < class4783_1[j].BoundingBox.Right)
			{
				rectangleF_0.Width += class4783_1[j].BoundingBox.Right - rectangleF_0.Right;
			}
		}
	}

	private void method_40()
	{
		float[] array = new float[3];
		int num = 0;
		for (int i = 0; i < base.PageElementCount; i++)
		{
			if ((base[i].Style & Enum672.flag_1) == Enum672.flag_1)
			{
				array[0] += base[i].Text.Length;
			}
			if ((base[i].Style & Enum672.flag_2) == Enum672.flag_2)
			{
				array[1] += base[i].Text.Length;
			}
			if ((base[i].Style & Enum672.flag_3) == Enum672.flag_3)
			{
				array[2] += base[i].Text.Length;
			}
			num += base[i].Text.Length;
		}
		for (int j = 0; j < 3; j++)
		{
			array[j] /= num;
		}
		bool flag = false;
		for (int k = 0; k < 3; k++)
		{
			if (array[k] > float_5)
			{
				switch (k)
				{
				case 0:
					enum672_1 |= Enum672.flag_1;
					flag = true;
					break;
				case 1:
					enum672_1 |= Enum672.flag_2;
					flag = true;
					break;
				case 2:
					enum672_1 |= Enum672.flag_3;
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			enum672_1 = Enum672.flag_4;
		}
	}

	private static Class4847 smethod_8(string text, Class4847 template, bool recreateFont)
	{
		Class5999 font = template.Font;
		if (recreateFont)
		{
			font = new Class5999(template.Font.SizePoints, FontStyle.Regular, template.Font.TrueTypeFont);
		}
		Class6219 @class = new Class6219(font, template.Color, template.Color, new PointF(0f, 0f), text, new SizeF(1f, 1f), 0f);
		@class.Id = template.string_0;
		Class4791 class2 = new Class4791(@class);
		class2.IsInvisible = template.IsInvisible;
		Class4847 class3 = new Class4847(class2, template.Type);
		class3.Hyperlink = template.Hyperlink;
		return class3;
	}

	internal ArrayList method_41(Enum676 mode, float blockLeftBoundary, float blockRightBoundary)
	{
		if (method_21())
		{
			return new ArrayList();
		}
		ArrayList arrayList = method_43();
		if (arrayList.Count > 1 && Class4860.Instance.Options.UserAgent == Enum678.const_1 && Class4860.Instance.Options.Mode == Enum676.const_0)
		{
			return smethod_10(arrayList);
		}
		if (arrayList.Count > 1 && Class4860.Instance.Options.UserAgent == Enum678.const_0 && Class4860.Instance.Options.Mode == Enum676.const_1)
		{
			return method_42(arrayList, blockLeftBoundary);
		}
		ArrayList arrayList2 = new ArrayList();
		StringBuilder stringBuilder = new StringBuilder(base.PageElementCount);
		ArrayList arrayList3 = new ArrayList();
		Class4847 @class = null;
		Class4847 class2 = null;
		int num = 0;
		float delta = 0f;
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class4847 class3 = arrayList[i] as Class4847;
			if (class3 != null)
			{
				if (i == 0)
				{
					string text = class3.method_2(blockLeftBoundary, blockRightBoundary, ref delta, arrayList3, blockLeftBoundary, mode);
					if (text.Length > 0)
					{
						class3.Text = text + class3.Text;
					}
				}
				if (@class != null)
				{
					stringBuilder.Append(@class.Text);
					string text2 = class3.method_2(@class.OffsetX + @class.ActualSize.Width, blockRightBoundary, ref delta, arrayList3, blockLeftBoundary, mode);
					num += text2.Length;
					Class4847 class4 = null;
					if (text2.Length > 0)
					{
						if (!(text2 == "\t") && @class.Font != null && (@class.Font.Style == FontStyle.Underline || @class.Font.Style == FontStyle.Strikeout || @class.Font.StyleEx != 0) && (@class.LineRef == null || @class.LineRef != class3.LineRef))
						{
							class4 = smethod_8(text2, @class, recreateFont: false);
						}
						else
						{
							stringBuilder.Append(text2);
						}
					}
					if (!class3.method_0(@class) || class4 != null)
					{
						@class.Text = stringBuilder.ToString();
						@class.TabsPosArray.AddRange(arrayList3);
						stringBuilder.Length = 0;
						num = 0;
						if (@class.Type != Enum674.const_2)
						{
							@class.FontSize = class3.FontSize;
						}
						arrayList3.Clear();
						arrayList2.Add(@class);
						if (class4 != null)
						{
							arrayList2.Add(class4);
						}
					}
				}
			}
			else if (arrayList[i] is Class4790 class5)
			{
				if (@class != null)
				{
					stringBuilder.Append(@class.Text);
					if (mode == Enum676.const_0)
					{
						StringBuilder stringBuilder2 = new StringBuilder();
						float num2 = class5.BoundingBox.Right - @class.BoundingBox.Right;
						float num3 = @class.method_3();
						double num4 = num2 / num3;
						if (num4 > 0.6000000238418579)
						{
							int num5 = (int)Math.Floor(num4);
							int num6 = ((num4 - (double)num5 > 0.6000000238418579) ? (num5 + 1) : num5);
							for (int j = 0; j < num6; j++)
							{
								stringBuilder2.Append(' ');
							}
						}
						stringBuilder.Append(stringBuilder2.ToString());
					}
					@class.Text = stringBuilder.ToString();
					if (@class.Type != Enum674.const_2)
					{
						@class.FontSize = class3.FontSize;
					}
					arrayList3.Clear();
					arrayList2.Add(@class);
				}
				@class = (class2 = null);
				arrayList2.Add(class5);
				stringBuilder.Length = 0;
				num = 0;
			}
			if (@class != null)
			{
				class2 = @class;
			}
			@class = class3;
		}
		if (@class != null)
		{
			if (stringBuilder.Length != 0 && class2 != null)
			{
				string text3 = class2.method_2(@class.OffsetX + @class.ActualSize.Width, blockRightBoundary, ref delta, arrayList3, blockLeftBoundary, mode);
				if (text3 == " ")
				{
					num++;
				}
				@class.Text = stringBuilder.ToString() + text3 + @class.Text;
				@class.TabsPosArray.AddRange(arrayList3);
			}
			arrayList3.Clear();
			arrayList2.Add(@class);
		}
		return arrayList2;
	}

	private ArrayList method_42(ArrayList stringRun, float blockLeftBoundary)
	{
		ArrayList arrayList = new ArrayList();
		if (stringRun.Count > 0)
		{
			Class4847 @class = stringRun[0] as Class4847;
			float num = @class.BoundingBox.Left - blockLeftBoundary;
			if (num != 0f)
			{
				float num2 = @class.method_3();
				Class4847 class2 = smethod_8(" ", @class, recreateFont: false);
				class2.LetterSpacing = num - num2;
				arrayList.Add(class2);
			}
		}
		List<float> list = new List<float>();
		StringBuilder stringBuilder = new StringBuilder();
		Class4847 class3 = null;
		for (int i = 0; i < stringRun.Count - 1; i++)
		{
			Class4847 class4 = stringRun[i] as Class4847;
			Class4847 class5 = stringRun[i + 1] as Class4847;
			float num3 = class5.BoundingBox.Left - class4.BoundingBox.Right;
			float num4 = class4.method_3();
			if (num3 >= num4 * 0.6f && !class5.Text.StartsWith(" "))
			{
				if (class3 != null)
				{
					Class4847 class6 = smethod_9(stringBuilder, class3, list, arrayList);
					class3 = null;
					num4 += class6.LetterSpacing;
				}
				else
				{
					arrayList.Add(class4);
				}
				Class4847 class7 = smethod_8(" ", class4, recreateFont: false);
				class7.LetterSpacing = num3 - num4;
				arrayList.Add(class7);
			}
			else if (class5.Text.Length == 1 && class5.Text != " " && class5.method_0(class4))
			{
				if (class3 == null)
				{
					stringBuilder.Append(class4.Text);
				}
				stringBuilder.Append(class5.Text);
				list.Add(num3);
				class3 = class5;
			}
			else if (class3 != null)
			{
				list.Add(num3);
				smethod_9(stringBuilder, class3, list, arrayList);
				class3 = null;
			}
			else
			{
				class4.LetterSpacing = num3;
				arrayList.Add(class4);
			}
		}
		if (class3 != null)
		{
			list.Add(0f);
			smethod_9(stringBuilder, class3, list, arrayList);
		}
		else
		{
			arrayList.Add(stringRun[stringRun.Count - 1]);
		}
		return arrayList;
	}

	private static Class4847 smethod_9(StringBuilder text, Class4847 elCurrent, List<float> distances, ArrayList result)
	{
		Class4847 @class = smethod_8(text.ToString(), elCurrent, recreateFont: false);
		float num = 0f;
		foreach (float distance in distances)
		{
			float num2 = distance;
			num += num2;
		}
		@class.LetterSpacing = num / (float)distances.Count;
		distances.Clear();
		text.Length = 0;
		result.Add(@class);
		return @class;
	}

	private static ArrayList smethod_10(ArrayList stringRun)
	{
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		float num = 0f;
		ArrayList arrayList3 = new ArrayList();
		ArrayList arrayList4 = new ArrayList();
		ArrayList arrayList5 = new ArrayList();
		for (int i = 0; i < stringRun.Count - 1; i++)
		{
			Class4847 @class = stringRun[i] as Class4847;
			Class4847 class2 = stringRun[i + 1] as Class4847;
			float num2 = class2.BoundingBox.Left - @class.BoundingBox.Right;
			float num3 = ((@class.Font.TrueTypeFont.Glyphs[' '] != null) ? @class.Font.method_1(' ') : Class4860.Instance.TimesNewRoman.TrueTypeFont.method_2(' ', @class.Font.SizePoints));
			if (num2 < num3 * 0.6f)
			{
				arrayList2.Add(num2);
				num += num2;
				continue;
			}
			float num4 = num2 - num3;
			arrayList3.Add(num4);
			arrayList4.Add(num3);
			arrayList5.Add(i);
		}
		float num5 = ((arrayList2.Count != 0) ? (num / (float)arrayList2.Count) : 0f);
		bool flag = true;
		float num6 = 0f;
		float num7 = 0f;
		if (arrayList3.Count > 0)
		{
			for (int j = 0; j < arrayList3.Count; j++)
			{
				float num8 = (float)arrayList3[j] - 2f * num5;
				arrayList3[j] = num8;
				num7 += num8;
			}
			num6 = num7 / (float)arrayList3.Count;
			if (arrayList3.Count > 1)
			{
				for (int k = 0; k < arrayList3.Count; k++)
				{
					float num9 = (float)arrayList3[k];
					float num10 = Math.Max(num6, num9);
					if (num10 == 0f)
					{
						num10 = 1E-05f;
					}
					if ((double)num9 > 0.1 * (double)(float)arrayList4[k] && !(Math.Min(num6, num9) / num10 >= 0.95f))
					{
						flag = false;
						break;
					}
				}
			}
		}
		if (flag)
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool flag2 = true;
			for (int l = 0; l < stringRun.Count; l++)
			{
				Class4847 class3 = null;
				Class4847 class4 = stringRun[l] as Class4847;
				if (flag2)
				{
					stringBuilder.Append(class4.Text);
					flag2 = false;
				}
				if (l < stringRun.Count - 1)
				{
					Class4847 class5 = stringRun[l + 1] as Class4847;
					if (class4.Font.StyleEx != 0 && class4.LineRef != null && class5 != null && class5.BoundingBox.X - class4.LineRef.Rect.Right > 1f)
					{
						class3 = smethod_8(" ", class4, recreateFont: true);
						class3.LetterSpacing = num5;
						class3.WordSpacing = num6;
					}
				}
				bool flag3 = false;
				if (arrayList5.Count > 0 && (int)arrayList5[0] == l)
				{
					if (class3 != null)
					{
						flag3 = true;
					}
					else
					{
						stringBuilder.Append(" ");
					}
					arrayList5.RemoveAt(0);
				}
				if (!flag3 && l < stringRun.Count - 1)
				{
					Class4847 class6 = stringRun[l + 1] as Class4847;
					if (class6.method_0(class4) && class6.Type != 0 && class6.Type != Enum674.const_1)
					{
						stringBuilder.Append(class6.Text);
					}
					else
					{
						flag3 = true;
					}
				}
				else
				{
					flag3 = true;
				}
				if (flag3)
				{
					string text = stringBuilder.ToString();
					smethod_11(class4, text, num5, num6, arrayList);
					stringBuilder.Remove(0, stringBuilder.Length);
					if (class3 != null)
					{
						arrayList.Add(class3);
					}
					flag2 = true;
				}
			}
		}
		else
		{
			ArrayList arrayList6 = new ArrayList();
			ArrayList arrayList7 = new ArrayList();
			float num11 = 0f;
			int num12 = 0;
			for (int m = 0; m < arrayList3.Count; m++)
			{
				float num13 = (float)arrayList3[m];
				num11 += num13;
				num12++;
				float val = num11 / (float)num12;
				float num14 = Math.Max(val, num13);
				if (num14 == 0f)
				{
					num14 = 1E-05f;
				}
				if (Math.Min(val, num13) / num14 < 0.95f)
				{
					arrayList6.Add((num11 - num13) / (float)(num12 - 1));
					arrayList7.Add(arrayList5[m]);
					num11 = num13;
					num12 = 1;
				}
			}
			if (num11 != 0f)
			{
				arrayList6.Add(num11 / (float)num12);
				arrayList7.Add(arrayList5[arrayList5.Count - 1]);
			}
			StringBuilder stringBuilder2 = new StringBuilder();
			bool flag4 = true;
			float num15 = ((arrayList6.Count == 0) ? 0f : ((float)arrayList6[0]));
			for (int n = 0; n < stringRun.Count; n++)
			{
				Class4847 class7 = null;
				Class4847 class8 = stringRun[n] as Class4847;
				if (flag4)
				{
					stringBuilder2.Append(class8.Text);
					flag4 = false;
				}
				if (n < stringRun.Count - 1 && stringRun[n + 1] is Class4847 class9 && ((class8.Font.StyleEx != 0 && class8.LineRef != null) || (class8.Font.StyleEx == 0 && class9.Font.StyleEx != 0)) && (class8.LineRef == null || class9.BoundingBox.X - class8.LineRef.Rect.Right > (class9.BoundingBox.X - class8.BoundingBox.Right) * 0.6f))
				{
					class7 = smethod_8(" ", class8, recreateFont: true);
					class7.LetterSpacing = num5;
					class7.WordSpacing = num15;
				}
				bool flag5 = false;
				bool flag6 = false;
				if (arrayList7.Count > 0 && (int)arrayList7[0] == n)
				{
					flag5 = true;
					num15 = (float)arrayList6[0];
					arrayList7.RemoveAt(0);
					arrayList6.RemoveAt(0);
					flag6 = true;
					if (class7 != null && arrayList6.Count > 0)
					{
						class7.WordSpacing = (float)arrayList6[0];
					}
				}
				if (arrayList5.Count > 0 && (int)arrayList5[0] == n)
				{
					if (class7 != null)
					{
						flag5 = true;
					}
					else if (!flag6)
					{
						stringBuilder2.Append(" ");
					}
					arrayList5.RemoveAt(0);
				}
				if (!flag5)
				{
					if (n < stringRun.Count - 1)
					{
						Class4847 class10 = stringRun[n + 1] as Class4847;
						if (class10.method_0(class8) && class10.Type != 0 && class10.Type != Enum674.const_1)
						{
							if (arrayList7.Count > 0)
							{
								num15 = (float)arrayList6[0];
							}
							stringBuilder2.Append(class10.Text);
						}
						else
						{
							flag5 = true;
						}
					}
					else
					{
						flag5 = true;
					}
				}
				if (flag5)
				{
					string text2 = stringBuilder2.ToString();
					smethod_11(class8, text2, num5, num15, arrayList);
					stringBuilder2.Remove(0, stringBuilder2.Length);
					if (class7 != null)
					{
						arrayList.Add(class7);
					}
					else if (flag6)
					{
						stringBuilder2.Append(" ");
					}
					flag4 = true;
				}
			}
		}
		if (arrayList.Count > 0)
		{
			(arrayList[arrayList.Count - 1] as Class4847).Text += "\r";
		}
		return arrayList;
	}

	private static void smethod_11(Class4847 elCurrent, string text, float letterSpaceOverage, float currentWordPace, ArrayList parts)
	{
		Class4847 @class = smethod_8(text, elCurrent, recreateFont: false);
		@class.LetterSpacing = letterSpaceOverage;
		@class.WordSpacing = currentWordPace;
		parts.Add(@class);
	}

	private ArrayList method_43()
	{
		ArrayList arrayList = new ArrayList();
		if (bool_1)
		{
			foreach (Class4845 item in class4783_0)
			{
				if (item.Value is Class4791 piece)
				{
					arrayList.Add(new Class4847(piece, Enum674.const_1));
				}
			}
		}
		if (bool_2)
		{
			foreach (Class4845 item2 in class4783_1)
			{
				if (item2.Value is Class4791 piece2)
				{
					arrayList.Add(new Class4847(piece2, Enum674.const_0));
				}
			}
		}
		IEnumerator enumerator3 = GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				Class4845 class3 = (Class4845)enumerator3.Current;
				if (class3.Value is Class4791 piece3)
				{
					arrayList.Add(new Class4847(piece3, Enum674.const_2));
				}
				else if (class3.Value is Class4790 value)
				{
					arrayList.Add(value);
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator3 as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		arrayList.Sort(icomparer_0);
		return arrayList;
	}
}
