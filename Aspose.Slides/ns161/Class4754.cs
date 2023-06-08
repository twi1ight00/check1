using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using ns218;
using ns224;
using ns233;
using ns235;

namespace ns161;

internal class Class4754
{
	private class Class6178 : Class6176
	{
		private Class5999 class5999_0;

		private Class5998 class5998_0 = Class5998.class5998_140;

		private RectangleF rectangleF_0 = RectangleF.Empty;

		private StringBuilder stringBuilder_0 = new StringBuilder();

		private RectangleF rectangleF_1 = RectangleF.Empty;

		private bool bool_0;

		private bool bool_1;

		private Class6270 class6270_0;

		private Class4754 class4754_0;

		public Class6178(Class4754 owner)
		{
			class4754_0 = owner;
		}

		public override void vmethod_11(Class6220 image)
		{
			method_0();
			class4754_0.xmlTextWriter_0.WriteStartElement("img");
			class4754_0.xmlTextWriter_0.WriteAttributeString("x", smethod_0(image.Origin.X));
			class4754_0.xmlTextWriter_0.WriteAttributeString("y", smethod_0(image.Origin.Y));
			class4754_0.xmlTextWriter_0.WriteAttributeString("width", smethod_0(image.Size.Width));
			class4754_0.xmlTextWriter_0.WriteAttributeString("height", smethod_0(image.Size.Height));
			Class4777 @class = new Class4777(image.Size, new MemoryStream(image.ImageBytes));
			string empty = string.Empty;
			bool flag = false;
			int i;
			for (i = 0; i < class4754_0.arrayList_0.Count; i++)
			{
				Class4777 class2 = (Class4777)class4754_0.arrayList_0[i];
				if (class2.Equals(@class))
				{
					flag = true;
					break;
				}
			}
			string arg = "png";
			if (image.ImageType == Enum788.const_4)
			{
				arg = "jpg";
			}
			empty = $"{class4754_0.string_17}_pic{++i}.{arg}";
			if (!flag)
			{
				using (FileStream fileStream = new FileStream(empty, FileMode.Create))
				{
					fileStream.Write(image.ImageBytes, 0, image.ImageBytes.Length);
				}
				class4754_0.arrayList_0.Add(@class);
			}
			class4754_0.xmlTextWriter_0.WriteAttributeString("src", Path.GetFileName(empty));
			class4754_0.xmlTextWriter_0.WriteEndElement();
		}

		public override void vmethod_0(Class6216 page)
		{
			class4754_0.xmlTextWriter_0.WriteStartElement("page");
			class4754_0.xmlTextWriter_0.WriteAttributeString("width", smethod_0(page.Width));
			class4754_0.xmlTextWriter_0.WriteAttributeString("height", smethod_0(page.Height));
		}

		public override void vmethod_1(Class6216 page)
		{
			if (bool_1)
			{
				method_0();
			}
			if (bool_0)
			{
				class4754_0.xmlTextWriter_0.WriteEndElement();
			}
			class4754_0.xmlTextWriter_0.WriteEndElement();
		}

		private static string smethod_0(float val)
		{
			return ((float)Math.Round(val, 3)).ToString(CultureInfo.InvariantCulture);
		}

		public override void vmethod_4(Class6219 glyphs)
		{
			bool flag = false;
			if (!class4754_0.hashtable_0.Contains(glyphs.Font.FamilyName))
			{
				class4754_0.hashtable_0.Add(glyphs.Font.FamilyName, glyphs.Font);
			}
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			string text = glyphs.Text;
			foreach (char c in text)
			{
				if (c != ' ' && c != '\r' && c != '\n')
				{
					num++;
				}
				switch (c)
				{
				case '&':
					stringBuilder.Append("&amp;");
					break;
				case '<':
					stringBuilder.Append("&lt;");
					break;
				case '>':
					stringBuilder.Append("&gt;");
					break;
				default:
					stringBuilder.Append(c);
					break;
				}
			}
			if (num == 0)
			{
				return;
			}
			float num2 = glyphs.Font.method_1(' ');
			if (num2 == 0f)
			{
				num2 = glyphs.Font.method_1('A') * 0.5f;
			}
			if (class5999_0 == null || class5999_0.FamilyName != glyphs.Font.FamilyName || class5999_0.SizePoints != glyphs.Font.SizePoints || class5999_0.Style != glyphs.Font.Style || class5998_0 != glyphs.Color)
			{
				flag = true;
				class5999_0 = glyphs.Font;
				class5998_0 = glyphs.Color;
			}
			bool flag2 = false;
			RectangleF rectangleF = new RectangleF(glyphs.Origin, glyphs.Size);
			RectangleF rectangleF2 = RectangleF.Intersect(rectangleF, rectangleF_0);
			if (!rectangleF2.IsEmpty && rectangleF2.Width * rectangleF2.Height > 0.5f * rectangleF.Width * rectangleF.Height)
			{
				string text2 = stringBuilder.ToString();
				string text3 = stringBuilder_0.ToString();
				int num3 = 0;
				int num4 = 0;
				while (num3 < text2.Length && num4 < stringBuilder_0.Length)
				{
					if (text2[num3] == ' ')
					{
						num3++;
						continue;
					}
					if (text3[num4] == ' ')
					{
						num4++;
						continue;
					}
					if (text2[num3] != text3[num4])
					{
						break;
					}
					num3++;
					num4++;
				}
				flag2 = num3 == text2.Length && num4 == text3.Length;
			}
			double num5 = rectangleF.Left - rectangleF_0.Right;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = (rectangleF_0.Top <= rectangleF.Top && !(rectangleF_0.Bottom < rectangleF.Top)) || (rectangleF.Top <= rectangleF_0.Top && rectangleF.Bottom >= rectangleF_0.Top);
			if (glyphs.Origin.Y == rectangleF_0.Y && num5 > (double)(0f - num2) && num5 < 0.75 * (double)num2)
			{
				if (!flag)
				{
					flag3 = true;
				}
			}
			else if (flag5 && num5 > (double)(0f - num2) && num5 < 2.4 * (double)num2)
			{
				if (!flag)
				{
					flag3 = true;
				}
				if (num5 >= 0.75 * (double)num2)
				{
					flag4 = true;
				}
			}
			flag3 &= glyphs.Hyperlink == null && class6270_0 == null;
			flag2 &= glyphs.Hyperlink == null && class6270_0 == null;
			if (flag3)
			{
				rectangleF = RectangleF.Union(rectangleF_0, rectangleF);
			}
			if (!flag3)
			{
				if (flag2)
				{
					bool_1 = false;
				}
				else if (bool_1)
				{
					method_0();
				}
			}
			if (flag)
			{
				if (bool_0)
				{
					class4754_0.xmlTextWriter_0.WriteEndElement();
				}
				class4754_0.xmlTextWriter_0.WriteStartElement("font");
				class4754_0.xmlTextWriter_0.WriteAttributeString("size", smethod_0(class5999_0.SizePoints));
				class4754_0.xmlTextWriter_0.WriteAttributeString("face", class5999_0.TrueTypeFont.FamilyName);
				if (class5998_0 != Class5998.class5998_7)
				{
					class4754_0.xmlTextWriter_0.WriteAttributeString("color", string.Format("#{0}", class5998_0.method_1().ToString("X4").Substring(2)));
				}
				if ((class5999_0.Style & FontStyle.Italic) == FontStyle.Italic)
				{
					class4754_0.xmlTextWriter_0.WriteAttributeString("italic", "true");
				}
				if ((class5999_0.Style & FontStyle.Italic) == FontStyle.Bold)
				{
					class4754_0.xmlTextWriter_0.WriteAttributeString("bold", "true");
				}
				Class4776 @class = new Class4776(class5999_0.TrueTypeFont.Data.vmethod_0(), class5999_0.FamilyName);
				string empty = string.Empty;
				bool flag6 = false;
				int j;
				for (j = 0; j < class4754_0.arrayList_1.Count; j++)
				{
					Class4776 class2 = (Class4776)class4754_0.arrayList_1[j];
					if (class2.Equals(@class))
					{
						flag6 = true;
						break;
					}
				}
				empty = $"{class4754_0.string_17}_font{++j}.ttf";
				if (!flag6)
				{
					using (FileStream dstStream = new FileStream(empty, FileMode.Create))
					{
						using Stream stream = class5999_0.TrueTypeFont.Data.vmethod_0();
						stream.Seek(0L, SeekOrigin.Begin);
						Class5964.smethod_9(stream, dstStream);
					}
					class4754_0.arrayList_1.Add(@class);
				}
				class4754_0.xmlTextWriter_0.WriteAttributeString("src", Path.GetFileName(empty));
				bool_0 = true;
			}
			if (!bool_1)
			{
				stringBuilder_0.Remove(0, stringBuilder_0.Length);
				rectangleF_1 = RectangleF.Empty;
			}
			if (flag4)
			{
				stringBuilder_0.Append(' ');
			}
			stringBuilder_0.Append(stringBuilder);
			bool_1 = true;
			rectangleF_1 = (rectangleF_0 = rectangleF);
			class6270_0 = glyphs.Hyperlink;
		}

		private void method_0()
		{
			class4754_0.xmlTextWriter_0.WriteStartElement("text");
			class4754_0.xmlTextWriter_0.WriteAttributeString("x", smethod_0(rectangleF_1.X));
			class4754_0.xmlTextWriter_0.WriteAttributeString("y", smethod_0(rectangleF_1.Y));
			class4754_0.xmlTextWriter_0.WriteAttributeString("width", smethod_0(Math.Abs(rectangleF_1.Width)));
			class4754_0.xmlTextWriter_0.WriteAttributeString("height", smethod_0(rectangleF_1.Height));
			class4754_0.xmlTextWriter_0.WriteString(stringBuilder_0.ToString());
			class4754_0.xmlTextWriter_0.WriteEndElement();
			bool_1 = false;
			if (class6270_0 != null)
			{
				class4754_0.xmlTextWriter_0.WriteStartElement("link");
				class4754_0.xmlTextWriter_0.WriteAttributeString("x", smethod_0(class6270_0.ActiveRect.X));
				class4754_0.xmlTextWriter_0.WriteAttributeString("y", smethod_0(class6270_0.ActiveRect.Y));
				class4754_0.xmlTextWriter_0.WriteAttributeString("width", smethod_0(Math.Abs(class6270_0.ActiveRect.Width)));
				class4754_0.xmlTextWriter_0.WriteAttributeString("height", smethod_0(class6270_0.ActiveRect.Height));
				class4754_0.xmlTextWriter_0.WriteAttributeString("href", class6270_0.Target);
				class4754_0.xmlTextWriter_0.WriteEndElement();
				class6270_0 = null;
			}
		}
	}

	private const string string_0 = "pdf2xml";

	private const string string_1 = "pages";

	private const string string_2 = "font";

	private const string string_3 = "size";

	private const string string_4 = "face";

	private const string string_5 = "color";

	private const string string_6 = "text";

	private const string string_7 = "x";

	private const string string_8 = "y";

	private const string string_9 = "width";

	private const string string_10 = "height";

	private const string string_11 = "page";

	private const string string_12 = "img";

	private const string string_13 = "src";

	private const string string_14 = "title";

	private const string string_15 = "link";

	private const string string_16 = "href";

	private XmlTextWriter xmlTextWriter_0;

	private Hashtable hashtable_0 = new Hashtable();

	private string string_17;

	private ArrayList arrayList_0 = new ArrayList();

	private ArrayList arrayList_1 = new ArrayList();

	public void method_0(ArrayList apsPages, string xmlFileName, string title)
	{
		Class4859 @class = new Class4859();
		@class.Normalize = true;
		@class.UseEmbeddedTrueTypeFonts = true;
		using FileStream w = new FileStream(xmlFileName, FileMode.Create);
		xmlTextWriter_0 = new XmlTextWriter(w, Encoding.UTF8);
		xmlTextWriter_0.Formatting = Formatting.Indented;
		int num = 0;
		xmlTextWriter_0.WriteStartDocument();
		xmlTextWriter_0.WriteStartElement("pdf2xml");
		xmlTextWriter_0.WriteAttributeString("pages", apsPages.Count.ToString());
		xmlTextWriter_0.WriteElementString("title", title);
		string_17 = Path.GetDirectoryName(xmlFileName) + "\\" + Path.GetFileNameWithoutExtension(xmlFileName);
		foreach (Class6216 apsPage in apsPages)
		{
			Class6178 visitor = new Class6178(this);
			if (@class.Normalize)
			{
				Class6216 class3 = Class4753.smethod_0(apsPage, ++num, @class, 2, transformImages: true);
				class3.vmethod_0(visitor);
			}
			else
			{
				apsPage.vmethod_0(visitor);
			}
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}
}
