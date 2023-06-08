using System;
using System.Collections;
using System.Drawing;
using System.Text;
using ns166;
using ns224;
using ns235;
using ns271;

namespace ns161;

internal class Class4770 : Interface146
{
	private class Class4771
	{
		private Class6730 class6730_0;

		private float float_0;

		private FontStyle fontStyle_0;

		private float float_1;

		private string string_0;

		public float SpaceWidth => float_1;

		public Class6730 Ttfont => class6730_0;

		public float Size => float_0;

		public FontStyle Style => fontStyle_0;

		public string Name => string_0;

		public Class4771(Class6730 ttfont, float size, FontStyle style, string name)
		{
			class6730_0 = ttfont;
			float_0 = size;
			fontStyle_0 = style;
			string_0 = name;
			float_1 = ttfont.method_2(' ', size);
			if (float_1 == 0f)
			{
				float_1 = ttfont.method_2('A', size) * 0.5f;
			}
		}
	}

	private class Class4772
	{
		private Class4771 class4771_0;

		private Class5998 class5998_0;

		private string string_0;

		private RectangleF rectangleF_0;

		private float float_0;

		public string Text => string_0;

		public RectangleF Rect => rectangleF_0;

		public Class4771 FontInfo => class4771_0;

		public float LeftMargin
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
			}
		}

		public Class4772(Class4771 fontInfo, Class5998 color, RectangleF rect, float leftMargin, string text)
		{
			class4771_0 = fontInfo;
			class5998_0 = color;
			string_0 = text;
			rectangleF_0 = rect;
			float_0 = leftMargin;
		}

		public void method_0(Interface148 builder)
		{
			builder.imethod_6(class4771_0.Ttfont, class4771_0.Name, class4771_0.Size, class4771_0.Style, class5998_0, float_0, string_0);
		}
	}

	private class Class4773
	{
		private ArrayList arrayList_0 = new ArrayList();

		private RectangleF rectangleF_0 = RectangleF.Empty;

		public RectangleF Rect => rectangleF_0;

		public float method_0()
		{
			if (arrayList_0.Count == 0)
			{
				return 0f;
			}
			return ((Class4772)arrayList_0[arrayList_0.Count - 1]).FontInfo.SpaceWidth;
		}

		public void method_1(Class4772 textSegment)
		{
			arrayList_0.Add(textSegment);
			if (rectangleF_0.IsEmpty)
			{
				rectangleF_0 = textSegment.Rect;
			}
			else
			{
				rectangleF_0 = RectangleF.Union(rectangleF_0, textSegment.Rect);
			}
		}

		public void method_2(Interface148 builder, RectangleF rect)
		{
			builder.imethod_4();
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				Class4772 @class = (Class4772)arrayList_0[i];
				if (i == 0)
				{
					@class.LeftMargin = @class.Rect.Left - rect.Left;
				}
				@class.method_0(builder);
			}
			builder.imethod_5(rect.Right - Rect.Right);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Class4772 item in arrayList_0)
			{
				stringBuilder.Append(item.Text);
			}
			return stringBuilder.ToString();
		}
	}

	private class Class4774
	{
		private ArrayList arrayList_0 = new ArrayList();

		private float float_0;

		private float float_1;

		private RectangleF rectangleF_0 = RectangleF.Empty;

		public RectangleF Rect => rectangleF_0;

		public float MarginTop
		{
			set
			{
				float_0 = value;
			}
		}

		public bool method_0(Class4773 textLine)
		{
			if (arrayList_0.Count == 0)
			{
				arrayList_0.Add(textLine);
				rectangleF_0 = textLine.Rect;
				return true;
			}
			Class4773 @class = (Class4773)arrayList_0[arrayList_0.Count - 1];
			float num = textLine.Rect.Bottom - @class.Rect.Bottom;
			float num2 = Math.Abs(((Class4773)arrayList_0[0]).Rect.Right - textLine.Rect.Right);
			float num3 = @class.Rect.Left - textLine.Rect.Left;
			if ((num2 <= textLine.method_0() * 2f || @class.Rect.Right > textLine.Rect.Right) && ((arrayList_0.Count == 1 && num3 >= 0f) || Math.Abs(num3) <= textLine.method_0() * 4f) && (arrayList_0.Count == 1 || Math.Min(num, float_1) / Math.Max(num, float_1) > 0.9f) && num / textLine.Rect.Height < 1.5f && Math.Min(textLine.Rect.Height, @class.Rect.Height) / Math.Max(textLine.Rect.Height, @class.Rect.Height) > 0.9f)
			{
				if (arrayList_0.Count == 1)
				{
					float_1 = textLine.Rect.Bottom - @class.Rect.Bottom;
				}
				rectangleF_0 = RectangleF.Union(rectangleF_0, textLine.Rect);
				arrayList_0.Add(textLine);
				return true;
			}
			if (arrayList_0.Count == 1)
			{
				float_1 = @class.Rect.Height;
			}
			return false;
		}

		public void method_1(Interface148 builder)
		{
			if (arrayList_0.Count == 0)
			{
				return;
			}
			builder.imethod_2(float_0, rectangleF_0.Width, float_1);
			foreach (Class4773 item in arrayList_0)
			{
				item.method_2(builder, rectangleF_0);
			}
			builder.imethod_3();
			arrayList_0.Clear();
		}
	}

	private Interface148 interface148_0;

	private RectangleF rectangleF_0 = RectangleF.Empty;

	private bool bool_0;

	private Class4774 class4774_0;

	private Class4771 class4771_0;

	private Class4773 class4773_0;

	public Class4770(Interface148 flowBuilder)
	{
		interface148_0 = flowBuilder;
	}

	public void imethod_0(float width, float height)
	{
		interface148_0.imethod_0(width, height);
		bool_0 = false;
		class4774_0 = new Class4774();
	}

	public void imethod_1()
	{
		if (class4774_0 != null)
		{
			class4774_0.method_1(interface148_0);
		}
		if (class4773_0 != null)
		{
			class4774_0 = new Class4774();
			class4774_0.method_0(class4773_0);
			class4774_0.method_1(interface148_0);
		}
		class4774_0 = null;
		interface148_0.imethod_1();
	}

	public void imethod_2(Class6730 font, float size, FontStyle style, string name)
	{
		class4771_0 = new Class4771(font, size, style, name);
	}

	public void imethod_3()
	{
	}

	public void imethod_4(string href)
	{
	}

	public void imethod_5()
	{
	}

	public void imethod_6(RectangleF rect, Class5998 color, string text)
	{
		float num = rect.Left - rectangleF_0.Right;
		bool flag = false;
		bool flag2 = Class4778.smethod_12(rectangleF_0, rect) > 0.5f;
		float leftMargin = 0f;
		if (flag2 && num > 0f - class4771_0.SpaceWidth)
		{
			flag = true;
			num -= class4771_0.SpaceWidth;
			text = " " + text;
			leftMargin = num;
		}
		if (bool_0 && !flag)
		{
			if (!class4774_0.method_0(class4773_0))
			{
				float marginTop = class4773_0.Rect.Height;
				if (Class4778.smethod_14(class4774_0.Rect, class4773_0.Rect) > 0.6f)
				{
					float num2 = class4773_0.Rect.Top - class4774_0.Rect.Bottom;
					if (num2 < 100f)
					{
						marginTop = num2;
					}
				}
				class4774_0.method_1(interface148_0);
				class4774_0 = new Class4774();
				class4774_0.method_0(class4773_0);
				class4774_0.MarginTop = marginTop;
			}
			class4773_0 = null;
			bool_0 = false;
		}
		if (!bool_0)
		{
			class4773_0 = new Class4773();
			bool_0 = true;
		}
		class4773_0.method_1(new Class4772(class4771_0, color, rect, leftMargin, text));
		if (flag)
		{
			rectangleF_0 = RectangleF.Union(rectangleF_0, rect);
		}
		else
		{
			rectangleF_0 = rect;
		}
	}

	public void imethod_7(Class6220 image, string name)
	{
		interface148_0.imethod_8(10f, 10f, image, name);
	}
}
