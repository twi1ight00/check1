using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Import;
using ns14;
using ns33;

namespace ns30;

internal class Class499 : Class498
{
	private class Class506
	{
		public PortionFormat portionFormat_0;

		public IParagraphFormat iparagraphFormat_0;

		public bool bool_0;

		public bool bool_1;

		public bool bool_2;

		public bool bool_3;

		public Class506()
		{
			portionFormat_0 = new PortionFormat((ParagraphFormat)null);
			iparagraphFormat_0 = new ParagraphFormat(null);
		}

		public Class506(Class506 source)
		{
			portionFormat_0 = new PortionFormat(source.portionFormat_0);
			iparagraphFormat_0 = new ParagraphFormat(source.iparagraphFormat_0, null);
			bool_1 = source.bool_1;
			bool_3 = source.bool_3;
		}
	}

	private const float float_0 = -22.5f;

	private readonly ArrayList arrayList_0 = new ArrayList();

	private readonly List<Class495.Class496> list_0 = new List<Class495.Class496>();

	private readonly ArrayList arrayList_1 = new ArrayList();

	private int int_0;

	private readonly HtmlExternalResolver htmlExternalResolver_0;

	private Class506 class506_0 = new Class506();

	private readonly ParagraphCollection paragraphCollection_0;

	private readonly string string_0;

	private static readonly char[] char_0 = new char[2] { '\r', '\n' };

	private static readonly char[] char_1 = new char[6] { '•', '–', '•', '–', '»', '•' };

	private readonly ArrayList arrayList_2 = new ArrayList();

	private readonly Class495 class495_0 = new Class495();

	private static readonly int[] int_1 = new int[7] { 10, 13, 16, 18, 24, 32, 48 };

	public Class499(ParagraphCollection paragraphs, HtmlExternalResolver resolver, string documentUri)
	{
		htmlExternalResolver_0 = resolver ?? Class199.class199_0;
		string_0 = documentUri;
		paragraphCollection_0 = paragraphs;
		int_0 = paragraphs.Count;
		paragraphCollection_0.Add(new Paragraph());
	}

	internal override void AddText(string text)
	{
		if (class506_0.bool_2)
		{
			int i;
			for (i = 0; i < text.Length && text[i] <= ' '; i++)
			{
			}
			if (i < text.Length)
			{
				paragraphCollection_0[paragraphCollection_0.Count - 1].ParagraphFormat.Bullet.Char = text[i];
			}
		}
		if (class506_0.bool_1 || arrayList_0.Count == 0)
		{
			return;
		}
		if (text.IndexOfAny(char_0) >= 0)
		{
			int num = 0;
			while (num < text.Length)
			{
				int num2 = text.IndexOfAny(char_0);
				if (num2 < 0)
				{
					num2 = text.Length;
				}
				Portion portion = new Portion(class506_0.portionFormat_0);
				portion.TextInternal = ((num < num2) ? text.Substring(num, num2 - num) : "");
				paragraphCollection_0[paragraphCollection_0.Count - 1].Portions.Add(portion);
				if (class506_0.bool_3)
				{
					arrayList_2.Add(portion);
				}
				if (num2 < text.Length)
				{
					paragraphCollection_0.Add(new Paragraph((ParagraphFormat)paragraphCollection_0[paragraphCollection_0.Count - 1].ParagraphFormat));
					num = num2 + 1;
					if (num < text.Length && ((text[num - 1] == '\r' && text[num] == '\n') || (text[num - 1] == '\n' && text[num] == '\r')))
					{
						num++;
					}
				}
			}
		}
		else
		{
			Portion portion2 = new Portion(class506_0.portionFormat_0);
			portion2.TextInternal = text;
			if (class506_0.bool_3)
			{
				arrayList_2.Add(portion2);
			}
			paragraphCollection_0[paragraphCollection_0.Count - 1].Portions.Add(portion2);
		}
	}

	internal override void vmethod_0(string name, IDictionary attributes)
	{
		if (attributes == null)
		{
			attributes = new Hashtable();
		}
		arrayList_0.Add(class506_0);
		list_0.Add(new Class495.Class496(name, attributes));
		arrayList_1.Add(null);
		class506_0 = new Class506(class506_0);
		Class495.Class497 @class = class495_0.method_0(list_0, arrayList_1);
		switch (name)
		{
		case "i":
		case "em":
			class506_0.portionFormat_0.FontItalic = NullableBool.True;
			break;
		case "b":
		case "strong":
			class506_0.portionFormat_0.FontBold = NullableBool.True;
			break;
		case "u":
			class506_0.portionFormat_0.FontUnderline = TextUnderlineType.Single;
			break;
		case "font":
		{
			string text3 = (string)attributes["size"];
			if (!string.IsNullOrEmpty(text3))
			{
				Class1149 class2 = new Class1149(text3);
				class2.method_8();
				if (class2.method_9() != '-' && class2.method_9() != '+')
				{
					float num = class2.method_11(float.NaN);
					if (!float.IsNaN(num))
					{
						class506_0.portionFormat_0.FontHeight = int_1[(int)Class1165.smethod_6(Math.Round(num), 1.0, 7.0) - 1];
					}
				}
				else
				{
					float num2 = class2.method_11(float.NaN);
					if (!float.IsNaN(num2))
					{
						class506_0.portionFormat_0.FontHeight = int_1[(int)Class1165.smethod_6(Math.Round(num2), -2.0, 4.0) + 2];
					}
				}
			}
			text3 = (string)attributes["face"];
			if (!string.IsNullOrEmpty(text3))
			{
				IFontData fontData = new FontData(text3);
				PortionFormat portionFormat_ = class506_0.portionFormat_0;
				PortionFormat portionFormat_2 = class506_0.portionFormat_0;
				IFontData fontData3 = (class506_0.portionFormat_0.ComplexScriptFont = fontData);
				IFontData latinFont = (portionFormat_2.EastAsianFont = fontData3);
				portionFormat_.LatinFont = latinFont;
			}
			text3 = (string)attributes["color"];
			if (!string.IsNullOrEmpty(text3))
			{
				Class1149 class3 = new Class1149(text3);
				class3.method_0(class506_0.portionFormat_0.FillFormat.SolidFillColor);
				if (class506_0.portionFormat_0.FillFormat.SolidFillColor.ColorType != ColorType.NotDefined)
				{
					class506_0.portionFormat_0.FillFormat.FillType = FillType.Solid;
				}
			}
			break;
		}
		case "a":
		{
			string text2 = (string)attributes["href"];
			if (!string.IsNullOrEmpty(text2))
			{
				class506_0.portionFormat_0.HyperlinkClick = new Hyperlink(text2);
			}
			break;
		}
		case "br":
			method_5();
			break;
		case "s":
		case "strike":
			class506_0.portionFormat_0.StrikethroughType = TextStrikethroughType.Single;
			break;
		case "ul":
			method_7(attributes);
			goto case "div";
		case "ol":
			method_6(attributes);
			goto case "div";
		case "span":
		{
			if (CaseInsensitiveComparer.DefaultInvariant.Compare(@class["mso-spacerun"], "yes") == 0)
			{
				class506_0.bool_3 = true;
			}
			string text5 = @class["mso-special-format"];
			if (text5 != null)
			{
				class506_0.bool_1 = true;
				if (CaseInsensitiveComparer.DefaultInvariant.Compare(text5, "bullet") == 0)
				{
					class506_0.bool_2 = true;
					paragraphCollection_0[paragraphCollection_0.Count - 1].ParagraphFormat.Bullet.Type = BulletType.Symbol;
					if (@class.Contains("font-family"))
					{
						string[] array = Class511.smethod_16(@class, "font-family");
						if (array != null && array.Length > 0)
						{
							paragraphCollection_0[paragraphCollection_0.Count - 1].ParagraphFormat.Bullet.IsBulletHardFont = NullableBool.True;
							paragraphCollection_0[paragraphCollection_0.Count - 1].ParagraphFormat.Bullet.Font = new FontData(array[0]);
						}
					}
				}
				else
				{
					if (!text5.ToLower().StartsWith("\"numbullet") && !text5.ToLower().StartsWith("'numbullet"))
					{
						break;
					}
					int length = "\"numbullet".Length;
					Class1149 class5 = new Class1149(text5, length, text5.Length - 1 - length);
					int num4 = class5.method_15(-1);
					class5.method_8();
					if (class5.method_9() == '\\')
					{
						class5.method_7();
					}
					class5.method_7();
					int num5 = class5.method_15(-1);
					if (num4 >= 0 && num5 >= 0)
					{
						IParagraph paragraph = paragraphCollection_0[paragraphCollection_0.Count - 1];
						paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
						paragraph.ParagraphFormat.Bullet.NumberedBulletStyle = (NumberedBulletStyle)num4;
						paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = (short)num5;
					}
					if (@class.Contains("font-family"))
					{
						string[] array2 = Class511.smethod_16(@class, "font-family");
						if (array2 != null && array2.Length > 0)
						{
							paragraphCollection_0[paragraphCollection_0.Count - 1].ParagraphFormat.Bullet.IsBulletHardFont = NullableBool.True;
							paragraphCollection_0[paragraphCollection_0.Count - 1].ParagraphFormat.Bullet.Font = new FontData(array2[0]);
						}
					}
				}
			}
			else if (@class.Contains("mso-tab-count"))
			{
				string str = @class["mso-tab-count"];
				int num6 = new Class1149(str).method_15(-1);
				if (num6 > 0)
				{
					AddText(new string('\t', num6));
				}
				class506_0.bool_1 = true;
			}
			break;
		}
		case "div":
		case "p":
		case "h1":
		case "h2":
		case "h3":
		case "h4":
		case "h5":
		case "h6":
		case "noscript":
		case "hr":
		case "li":
		case "td":
		case "blockquote":
		{
			IParagraphFormat paragraphFormat = new ParagraphFormat(null);
			Class511.smethod_0(@class, paragraphFormat, 1024f);
			string text4 = (string)attributes["class"];
			if (!string.IsNullOrEmpty(text4) && (text4[0] == 'O' || text4[0] == 'o'))
			{
				Class1149 class4 = new Class1149(text4, 1, text4.Length - 1);
				int num3 = class4.method_15(-1);
				if (num3 > 0 && num3 < 8 && class4.CharsLeftCount == 0)
				{
					paragraphFormat.Depth = (short)num3;
				}
			}
			((ParagraphFormat)class506_0.iparagraphFormat_0).method_5((ParagraphFormat)paragraphFormat);
			class506_0.bool_0 = true;
			paragraphCollection_0.Add(new Paragraph((ParagraphFormat)class506_0.iparagraphFormat_0));
			break;
		}
		case "img":
		{
			IParagraph paragraph = paragraphCollection_0[paragraphCollection_0.Count - 1];
			string text = (string)attributes["src"];
			if (paragraph.Portions.Count == 0 && !string.IsNullOrEmpty(text))
			{
				Stream stream = method_8(text);
				if (stream != null)
				{
					IPPImage image = ((IPresentationComponent)paragraphCollection_0).Presentation.Images.AddImage(stream);
					((BulletFormat)paragraph.ParagraphFormat.Bullet).Picture.Image = image;
					paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
				}
				else if (attributes["alt"] != null && (string)attributes["alt"] != "")
				{
					paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
					paragraph.ParagraphFormat.Bullet.Char = ((string)attributes["alt"])[0];
				}
			}
			else if (attributes["alt"] != null)
			{
				AddText((string)attributes["alt"]);
			}
			break;
		}
		case "sub":
			class506_0.portionFormat_0.Escapement = -25f;
			break;
		case "sup":
			class506_0.portionFormat_0.Escapement = 30f;
			break;
		}
		PortionFormat portionFormat = new PortionFormat((ParagraphFormat)null);
		Class511.smethod_1(@class, portionFormat);
		class506_0.portionFormat_0.vmethod_3(portionFormat);
	}

	private void method_5()
	{
		IParagraph paragraph = paragraphCollection_0[paragraphCollection_0.Count - 1];
		bool flag;
		if (!(flag = paragraph.Portions.Count == 0))
		{
			PortionFormat portionFormat = (PortionFormat)paragraph.Portions[paragraph.Portions.Count - 1].PortionFormat;
			if (portionFormat.Equals(class506_0.portionFormat_0))
			{
				((Portion)paragraph.Portions[paragraph.Portions.Count - 1]).TextInternal += '\v';
			}
			else
			{
				flag = true;
			}
		}
		if (flag)
		{
			Portion portion = new Portion(class506_0.portionFormat_0);
			portion.Text = "\v";
			paragraph.Portions.Add(portion);
		}
	}

	private void method_6(IDictionary attributes)
	{
		class506_0.iparagraphFormat_0.Depth++;
		class506_0.iparagraphFormat_0.Indent = -22.5f;
		class506_0.iparagraphFormat_0.Bullet.Type = BulletType.Numbered;
		string s = (string)attributes["start"];
		if (!short.TryParse(s, out var result))
		{
			result = 1;
		}
		class506_0.iparagraphFormat_0.Bullet.NumberedBulletStartWith = result;
		string text = (string)attributes["type"];
		bool flag;
		if (!(flag = string.IsNullOrEmpty(text)))
		{
			switch (text)
			{
			case "I":
				class506_0.iparagraphFormat_0.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletRomanUCPeriod;
				break;
			case "i":
				class506_0.iparagraphFormat_0.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletRomanLCPeriod;
				break;
			case "A":
				class506_0.iparagraphFormat_0.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletAlphaUCPeriod;
				break;
			case "a":
				class506_0.iparagraphFormat_0.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletAlphaLCPeriod;
				break;
			case "1":
				class506_0.iparagraphFormat_0.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletArabicPeriod;
				break;
			default:
				flag = true;
				break;
			}
		}
		if (flag)
		{
			class506_0.iparagraphFormat_0.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletArabicPeriod;
		}
	}

	private void method_7(IDictionary attributes)
	{
		class506_0.iparagraphFormat_0.Depth++;
		class506_0.iparagraphFormat_0.Indent = -22.5f;
		class506_0.iparagraphFormat_0.Bullet.Type = BulletType.Symbol;
		string text = (string)attributes["type"];
		bool flag;
		if (!(flag = string.IsNullOrEmpty(text)))
		{
			class506_0.iparagraphFormat_0.Bullet.IsBulletHardFont = NullableBool.True;
			FontDataFactory fontDataFactory = new FontDataFactory();
			switch (text)
			{
			case "square":
			{
				FontData fontData = (FontData)fontDataFactory.CreateFontData("Wingdings");
				fontData.CharSet = 2;
				fontData.PitchFamily = 2;
				class506_0.iparagraphFormat_0.Bullet.Font = fontData;
				class506_0.iparagraphFormat_0.Bullet.Char = '§';
				break;
			}
			case "circle":
			{
				FontData fontData = (FontData)fontDataFactory.CreateFontData("Courier New");
				fontData.CharSet = 0;
				fontData.PitchFamily = 49;
				class506_0.iparagraphFormat_0.Bullet.Font = fontData;
				class506_0.iparagraphFormat_0.Bullet.Char = 'o';
				break;
			}
			case "disc":
			{
				FontData fontData = (FontData)fontDataFactory.CreateFontData("Arial");
				fontData.CharSet = 0;
				fontData.PitchFamily = 34;
				class506_0.iparagraphFormat_0.Bullet.Font = fontData;
				class506_0.iparagraphFormat_0.Bullet.Char = '•';
				break;
			}
			default:
				flag = true;
				break;
			}
		}
		if (flag)
		{
			int num = class506_0.iparagraphFormat_0.Depth - 1;
			if (num >= char_1.Length)
			{
				num = char_1.Length - 1;
			}
			class506_0.iparagraphFormat_0.Bullet.Char = char_1[num];
		}
	}

	private Stream method_8(string uri)
	{
		string text = htmlExternalResolver_0.ResolveUri(string_0, uri);
		if (text == null)
		{
			return null;
		}
		return htmlExternalResolver_0.GetEntity(text);
	}

	internal override void vmethod_1(string name)
	{
		Class506 @class = class506_0;
		int num = arrayList_0.Count - 1;
		class506_0 = (Class506)arrayList_0[num];
		arrayList_0.RemoveAt(num);
		if (@class.bool_0)
		{
			paragraphCollection_0.Add(new Paragraph((ParagraphFormat)class506_0.iparagraphFormat_0));
		}
		Class495.Class496 value = list_0[num];
		list_0.RemoveAt(num);
		if (num == arrayList_1.Count)
		{
			arrayList_1.RemoveAt(num + 1);
		}
		ArrayList arrayList = (ArrayList)arrayList_1[num];
		if (arrayList == null)
		{
			arrayList = (ArrayList)(arrayList_1[num] = new ArrayList());
		}
		arrayList.Add(value);
		if (list_0.Count != 0)
		{
			return;
		}
		while (int_0 < paragraphCollection_0.Count)
		{
			string textInternal = ((Paragraph)paragraphCollection_0[int_0]).TextInternal;
			if (!(textInternal == "") && !(textInternal == " "))
			{
				bool flag = false;
				for (int i = 0; i < textInternal.Length; i++)
				{
					if (textInternal[i] != ' ')
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					int_0++;
				}
				else
				{
					paragraphCollection_0.RemoveAt(int_0);
				}
			}
			else
			{
				paragraphCollection_0.RemoveAt(int_0);
			}
		}
		foreach (Portion item in arrayList_2)
		{
			item.Text = item.Text.Replace('\u00a0', ' ');
		}
		arrayList_2.Clear();
	}

	internal override void vmethod_2(string text)
	{
	}
}
