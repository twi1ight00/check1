using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Text;
using ns224;
using ns233;

namespace ns239;

internal class Class6564 : Class6562
{
	private const string string_0 = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang3081";

	private const string string_1 = "{\\fonttbl";

	private const string string_2 = "{{f{0}\\fnil\\fprq2\\ {1};}}";

	private const string string_3 = "{\\colortbl ";

	private const string string_4 = "\\red{0}\\green{1}\\blue{2};";

	private const string string_5 = "\\viewkind0\\uc1\\plain\\f0";

	private const string string_6 = "{{\\field{{\\*\\fldinst FORMCHECKBOX {{\\*\\formfield{{\\fftype1\\ffres25\\fftypetxt0\\ffsize1\\ffhps{0}\\ffdefres{1}}}}}}}}}{{\\fldrslt }}";

	private const string string_7 = "\\pard ";

	private const string string_8 = "\\pvpg\\phpg\\posx{0}\\posy{1}\\absw{2}\\absh{3}\\chshdng0\\chcbpat{4}\\cf{5}\\f{6}\\fs{7} {8} \\par";

	private const string string_9 = "\\i";

	private const string string_10 = "\\b";

	private const string string_11 = "";

	private const string string_12 = "{{\\field{{\\*\\fldinst HYPERLINK \"{0}\"}}{{\\fldrslt ";

	private const string string_13 = "{{\\bkmkstart {0}}}{{\\bkmkend {1}}}";

	private const string string_14 = "{{\\*\\do\\dppolyline\\dppolycount{0}";

	private const string string_15 = "\\dpptx{0}\\dppty{1}";

	private const string string_16 = "\\dpx0\\dpy0\\dpxsize{0}\\dpysize{1}}}";

	private const string string_17 = "{{\\field{{\\*\\fldinst FORMTEXT}}{{\\fldrslt {0}}}}}";

	private const string string_18 = "{{\\field\\fldpriv{{\\*\\fldinst {{FORMDROPDOWN }}\r\n                                                    {{\\*\\formfield{{\\fftype2\\ffres{0}\\fftypetxt0\\ffhaslistbox{{\\*\\ffname \r\n                                                    {1}}}\\ffdefres0{2}}}}}}}}}{{\\fldrslt }}";

	private const string string_19 = "{{\\*\\ffl {0}}}";

	private const string string_20 = "\\pvpg\\phpg\\posx{0}\\posy{1}\\chshdng0\\outlinelevel{2} {3} \\par";

	private StringCollection stringCollection_0;

	private List<Class5998> list_0;

	private readonly StringBuilder stringBuilder_0;

	public Class6564(Class6562 builder)
		: base(builder)
	{
		stringBuilder_0 = new StringBuilder();
		stringCollection_0 = new StringCollection();
		list_0 = new List<Class5998>();
	}

	private int method_0(string font)
	{
		if (font != null && font.Length != 0)
		{
			int num = stringCollection_0.IndexOf(font);
			if (num < 0)
			{
				return stringCollection_0.Add(font);
			}
			return num;
		}
		return 0;
	}

	public int method_1(Class5998 color)
	{
		if (!list_0.Contains(color))
		{
			list_0.Add(color);
		}
		return list_0.IndexOf(color);
	}

	public void method_2(string element, string target)
	{
		if (target.Length != 0)
		{
			stringBuilder_0.AppendFormat("{{\\field{{\\*\\fldinst HYPERLINK \"{0}\"}}{{\\fldrslt ", target);
		}
		stringBuilder_0.Append(element);
		if (target.Length != 0)
		{
			stringBuilder_0.Append("}}");
		}
	}

	public override void vmethod_9(PointF origin, string title, int outlineLevel)
	{
		PointF pointF = Class6632.smethod_0(origin);
		stringBuilder_0.AppendFormat("\\pvpg\\phpg\\posx{0}\\posy{1}\\chshdng0\\outlinelevel{2} {3} \\par", pointF.X, pointF.Y, outlineLevel, title);
	}

	public override void vmethod_0(Class5999 font, Class5998 color, Class5998 outlineColor, PointF origin, string text, SizeF size, float charSpace, string hyperlink)
	{
		string text2 = "\\pard ";
		if (font.IsItalic)
		{
			text2 += "\\i";
		}
		if (font.IsBold)
		{
			text2 += "\\b";
		}
		PointF pointF = Class6632.smethod_0(origin);
		SizeF sizeF = Class6632.smethod_1(size);
		text2 += $"\\pvpg\\phpg\\posx{pointF.X}\\posy{pointF.Y}\\absw{sizeF.Width}\\absh{sizeF.Height}\\chshdng0\\chcbpat{method_1(color)}\\cf{method_1(outlineColor)}\\f{method_0(font.FamilyName)}\\fs{font.SizePoints * 2f} {text} \\par";
		method_2(text2, hyperlink);
	}

	public override void vmethod_1(PointF startPoint, PointF controlPoint1, PointF controlPoint2, PointF EndPoint)
	{
		Class6563 @class = new Class6563(this);
		@class.vmethod_1(startPoint, controlPoint1, controlPoint2, EndPoint);
		AddImage(@class.Size, new PointF(0f, 0f), @class.ToArray(), null, string.Empty);
	}

	public override void vmethod_2(PointF origin, string name)
	{
		stringBuilder_0.AppendFormat("{{\\bkmkstart {0}}}{{\\bkmkend {1}}}", name, name);
	}

	public override void AddImage(SizeF size, PointF origin, byte[] byteArray, Class6145 crop, string hyperlink)
	{
		Class6633 @class = new Class6633(origin, size, byteArray, crop);
		method_2(@class.ToString(), hyperlink);
	}

	public override void vmethod_3(List<PointF> coords)
	{
		SizeF sizeF = Class6632.smethod_4(coords);
		stringBuilder_0.AppendFormat("{{\\*\\do\\dppolyline\\dppolycount{0}", coords.Count);
		foreach (PointF coord in coords)
		{
			stringBuilder_0.AppendFormat("\\dpptx{0}\\dppty{1}", coord.X, coord.Y);
		}
		stringBuilder_0.AppendFormat("\\dpx0\\dpy0\\dpxsize{0}\\dpysize{1}}}", sizeF.Width, sizeF.Height);
	}

	public override void vmethod_4(PointF origin, string name, SizeF size, bool isRichText)
	{
		stringBuilder_0.AppendFormat("{{\\field{{\\*\\fldinst FORMTEXT}}{{\\fldrslt {0}}}}}", name);
	}

	public override void vmethod_5(PointF origin, string name, List<string> items, int value, RectangleF boundingBox)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (string item in items)
		{
			stringBuilder.AppendFormat("{{\\*\\ffl {0}}}", item);
		}
		stringBuilder_0.AppendFormat("{{\\field\\fldpriv{{\\*\\fldinst {{FORMDROPDOWN }}\r\n                                                    {{\\*\\formfield{{\\fftype2\\ffres{0}\\fftypetxt0\\ffhaslistbox{{\\*\\ffname \r\n                                                    {1}}}\\ffdefres0{2}}}}}}}}}{{\\fldrslt }}", value, name, stringBuilder.ToString());
	}

	public override void vmethod_6(PointF origin, string name, bool isEnabled, RectangleF bounds)
	{
		stringBuilder_0.AppendFormat("{{\\field{{\\*\\fldinst FORMCHECKBOX {{\\*\\formfield{{\\fftype1\\ffres25\\fftypetxt0\\ffsize1\\ffhps{0}\\ffdefres{1}}}}}}}}}{{\\fldrslt }}", bounds.Height, Convert.ToInt32(isEnabled));
	}

	public override void vmethod_8(Class6563 canvas)
	{
		if (canvas.Bookmark != null)
		{
			vmethod_2(canvas.Bookmark.pointF_0, canvas.Bookmark.string_0);
		}
		AddImage(canvas.Size, new PointF(0f, 0f), canvas.ToArray(), null, canvas.Hyperlink);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang3081");
		stringBuilder.Append("{\\fonttbl");
		for (int i = 0; i < stringCollection_0.Count; i++)
		{
			try
			{
				stringBuilder.AppendFormat("{{f{0}\\fnil\\fprq2\\ {1};}}", i, stringCollection_0[i]);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		stringBuilder.Append("}" + Environment.NewLine);
		stringBuilder.Append("{\\colortbl ");
		foreach (Class5998 item in list_0)
		{
			stringBuilder.AppendFormat("\\red{0}\\green{1}\\blue{2};", item.R, item.G, item.B);
		}
		stringBuilder.Append("}" + Environment.NewLine);
		stringBuilder.Append("\\viewkind0\\uc1\\plain\\f0");
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.Append(stringBuilder_0.ToString());
		stringBuilder.Append("}");
		return stringBuilder.ToString();
	}
}
