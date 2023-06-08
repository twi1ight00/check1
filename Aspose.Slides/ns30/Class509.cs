using System;
using System.Collections;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;
using ns12;
using ns4;

namespace ns30;

internal class Class509
{
	private const int int_0 = 80;

	private const string string_0 = "Version:1.0\r\nStartHTML:!HTMLSTART\r\nEndHTML:!HTMLEND!!\r\nStartFragment:!FRAGSTART\r\nEndFragment:!FRAGEND!!\r\n\r\n";

	private const int int_1 = 23;

	private const int int_2 = 43;

	private const int int_3 = 69;

	private const int int_4 = 93;

	private ArrayList arrayList_0 = new ArrayList();

	private StringBuilder stringBuilder_0;

	private bool bool_0;

	private int int_5;

	private TextToHtmlConversionOptions textToHtmlConversionOptions_0;

	private bool bool_1 = true;

	internal static string smethod_0(Paragraph[] text, TextToHtmlConversionOptions options, BaseSlide slide, FloatColor styleColor)
	{
		ILinkEmbedController linkEmbedController = options.LinkEmbedController;
		Class195 @class = new Class195();
		if (linkEmbedController == null)
		{
			linkEmbedController = Class2948.class2948_0;
		}
		string[] array = Class532.smethod_7(text);
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		if (options.AddClipboardFragmentHeader)
		{
			stringBuilder.Append("Version:1.0\r\nStartHTML:!HTMLSTART\r\nEndHTML:!HTMLEND!!\r\nStartFragment:!FRAGSTART\r\nEndFragment:!FRAGEND!!\r\n\r\n");
		}
		Class509 class2 = new Class509(stringBuilder, options);
		num = class2.stringBuilder_0.Length;
		class2.method_2("html");
		class2.method_2("head");
		class2.method_1("Content-Type", (options.EncodingName == null || !(options.EncodingName != "")) ? "text/html" : $"text/html; charset={options.EncodingName}");
		class2.method_0("ProgId", "PowerPoint.Slide");
		class2.method_0("Generator", "Aspose.Slides");
		class2.method_6();
		class2.method_2("body");
		if (options.AddClipboardFragmentHeader)
		{
			class2.AddComment("StartFragment");
			class2.stringBuilder_0.Append("\r\n\r\n");
			class2.int_5 = 0;
		}
		num3 = class2.stringBuilder_0.Length;
		for (int i = 0; i < text.Length; i++)
		{
			Paragraph paragraph = text[i];
			IParagraphFormat paragraphFormat = paragraph.ParagraphFormat;
			bool flag;
			if (flag = paragraphFormat.Bullet.Type != BulletType.NotDefined && paragraphFormat.Bullet.Type != 0 && paragraph.TextInternal.Length > 0)
			{
				class2.method_2("div");
			}
			else
			{
				class2.method_2("p");
			}
			class2.method_4("style", Class511.smethod_2(paragraphFormat));
			if (paragraphFormat.Depth > 0)
			{
				class2.method_4("class", "O" + paragraphFormat.Depth);
			}
			if (flag)
			{
				if (paragraphFormat.Bullet.Type == BulletType.Picture)
				{
					string text2 = null;
					if (((BulletFormat)paragraphFormat.Bullet).Picture.Image != null)
					{
						IPPImage image = ((BulletFormat)paragraphFormat.Bullet).Picture.Image;
						byte[] binaryData = image.BinaryData;
						LinkEmbedDecision decision;
						int id = @class.method_0(linkEmbedController, image, binaryData, "pictureBullet", image.ContentType, "image", out decision);
						switch (decision)
						{
						case LinkEmbedDecision.Link:
							text2 = linkEmbedController.GetUrl(id, 0);
							break;
						default:
							text2 = $"data:{image.ContentType};base64,{Convert.ToBase64String(binaryData)}";
							break;
						case LinkEmbedDecision.Ignore:
							break;
						}
					}
					else
					{
						text2 = ((BulletFormat)paragraphFormat.Bullet).Picture.LinkPathLong;
					}
					if (text2 != null)
					{
						if (class2.bool_1)
						{
							class2.method_2("span");
							class2.method_4("style", "mso-special-format: bullet");
						}
						class2.method_2("img");
						class2.method_4("src", text2);
						class2.method_4("alt", "*");
						class2.method_6();
						if (class2.bool_1)
						{
							class2.method_6();
						}
					}
				}
				else
				{
					class2.method_2("span");
					class2.method_4("style", Class511.smethod_4(paragraph, class2.bool_1, slide, styleColor));
					class2.AddText(array[i]);
					class2.method_6();
				}
			}
			else
			{
				string textInternal = paragraph.TextInternal;
				if (textInternal == "" || (textInternal.Length == 1 && textInternal[0] <= ' ' && textInternal[0] != '\t' && textInternal[0] != '\v' && textInternal[0] != '\n' && textInternal[0] != '\r'))
				{
					class2.AddText("\u00a0");
				}
			}
			for (int j = 0; j < paragraph.Portions.Count; j++)
			{
				Portion portion = (Portion)paragraph.Portions[j];
				class2.method_2("span");
				class2.method_4("style", Class511.smethod_3(portion.PortionFormat, class2.bool_1, slide, styleColor));
				int num5 = 0;
				if (portion.PortionFormat.StrikethroughType != TextStrikethroughType.NotDefined && portion.PortionFormat.StrikethroughType != 0)
				{
					class2.method_2("s");
					num5++;
				}
				if (portion.PortionFormat.FontUnderline != TextUnderlineType.NotDefined && portion.PortionFormat.FontUnderline != 0)
				{
					class2.method_2("u");
					num5++;
				}
				if (portion.PortionFormat.HyperlinkClick != null && portion.PortionFormat.HyperlinkClick.ExternalUrl != null)
				{
					class2.method_2("a");
					class2.method_4("href", portion.PortionFormat.HyperlinkClick.ExternalUrl);
					num5++;
				}
				class2.AddText(portion.TextInternal);
				while (num5-- > 0)
				{
					class2.method_6();
				}
				class2.method_6();
			}
			class2.method_6();
		}
		num4 = class2.stringBuilder_0.Length;
		if (options.AddClipboardFragmentHeader)
		{
			class2.stringBuilder_0.Append("\r\n\r\n");
			class2.AddComment("EndFragment");
		}
		class2.method_6();
		class2.method_6();
		num2 = class2.stringBuilder_0.Length;
		if (options.AddClipboardFragmentHeader)
		{
			smethod_1(stringBuilder, 23, num);
			smethod_1(stringBuilder, 43, num2);
			smethod_1(stringBuilder, 69, num3);
			smethod_1(stringBuilder, 93, num4);
		}
		return stringBuilder.ToString();
	}

	private Class509(StringBuilder sb, TextToHtmlConversionOptions options)
	{
		stringBuilder_0 = sb;
		textToHtmlConversionOptions_0 = options;
	}

	private void method_0(string name, string content)
	{
		method_2("meta");
		method_4("name", name);
		method_4("content", content);
		method_6();
	}

	private void method_1(string header, string content)
	{
		method_2("meta");
		method_4("http-equiv", header);
		method_4("content", content);
		method_6();
	}

	private static void smethod_1(StringBuilder sb, int position, int value)
	{
		string text = value.ToString("d10");
		for (int i = 0; i < text.Length; i++)
		{
			sb[position + i] = text[i];
		}
	}

	private void method_2(string name)
	{
		if (bool_0)
		{
			method_3();
		}
		stringBuilder_0.AppendFormat("<{0}", name);
		bool_0 = true;
		arrayList_0.Add(name);
	}

	private void method_3()
	{
		bool_0 = false;
		method_7(">", canBreakBefore: false, canBreakAfter: false);
	}

	private void AddText(string text)
	{
		if (bool_0)
		{
			method_3();
		}
		int num = 0;
		int num2 = 0;
		while (num2 < text.Length)
		{
			char c = text[num2];
			if (c == '<')
			{
				if (num < num2)
				{
					method_8(text, num, num2 - num, canBreakBefore: false, canBreakAfter: false);
				}
				method_7("&lt;", canBreakBefore: false, canBreakAfter: false);
				num = ++num2;
			}
			else if (c == '>')
			{
				if (num < num2)
				{
					method_8(text, num, num2 - num, canBreakBefore: false, canBreakAfter: false);
				}
				method_7("&gt;", canBreakBefore: false, canBreakAfter: false);
				num = ++num2;
			}
			else if (c == '&')
			{
				if (num < num2)
				{
					method_8(text, num, num2 - num, canBreakBefore: false, canBreakAfter: false);
				}
				method_7("&amp;", canBreakBefore: false, canBreakAfter: false);
				num = ++num2;
			}
			else if (c <= ' ')
			{
				if (num < num2)
				{
					method_8(text, num, num2 - num, canBreakBefore: false, canBreakAfter: false);
				}
				switch (c)
				{
				case '\t':
				{
					int i;
					for (i = num2 + 1; i < text.Length && text[i] == '\t'; i++)
					{
					}
					if (bool_1)
					{
						method_2("span");
						method_4("style", $"mso-tab-count:{i - num2}");
						method_3();
					}
					while (num2 < i)
					{
						num2++;
						method_7("\u00a0 ", canBreakBefore: true, canBreakAfter: true);
					}
					if (bool_1)
					{
						method_6();
					}
					num = num2;
					continue;
				}
				case '\n':
				case '\v':
				case '\r':
					method_2("br");
					method_6();
					num = ++num2;
					continue;
				}
				int j;
				for (j = num2 + 1; j < text.Length && text[j] <= ' ' && text[j] != '\t' && text[j] != '\n' && text[j] != '\r' && text[j] != '\v'; j++)
				{
				}
				bool flag;
				if (flag = bool_1 && num2 + 1 < j)
				{
					method_2("span");
					method_4("style", "mso-spacerun:yes");
					method_3();
				}
				while (num2 < j - 1)
				{
					num2++;
					method_9('\u00a0', canBreakBefore: false, canBreakAfter: false);
				}
				if (flag)
				{
					method_6();
				}
				method_10();
				num2++;
				num = num2;
			}
			else
			{
				num2++;
			}
		}
		if (num < num2)
		{
			method_8(text, num, num2 - num, canBreakBefore: false, canBreakAfter: false);
		}
	}

	private void method_4(string name, string value)
	{
		if (!bool_0)
		{
			throw new InvalidOperationException("Trying to write element without element tag opening");
		}
		if (name != null && value != null)
		{
			method_10();
			method_7(name, canBreakBefore: true, canBreakAfter: false);
			method_7("=\"", canBreakBefore: true, canBreakAfter: false);
			method_7(method_5(value), canBreakBefore: false, canBreakAfter: false);
			method_9('"', canBreakBefore: false, canBreakAfter: false);
		}
	}

	private string method_5(string value)
	{
		StringBuilder stringBuilder = new StringBuilder(value.Length + value.Length / 8);
		for (int i = 0; i < value.Length; i++)
		{
			if (value[i] == '&')
			{
				stringBuilder.Append("&amp;");
			}
			else if (value[i] == '"')
			{
				stringBuilder.Append("&quot;");
			}
			else
			{
				stringBuilder.Append(value[i]);
			}
		}
		return stringBuilder.ToString();
	}

	private void method_6()
	{
		if (bool_0)
		{
			method_7("/>", canBreakBefore: false, canBreakAfter: false);
		}
		else
		{
			method_7($"</{arrayList_0[arrayList_0.Count - 1]}>", canBreakBefore: false, canBreakAfter: false);
		}
		arrayList_0.RemoveAt(arrayList_0.Count - 1);
		bool_0 = false;
	}

	private void AddComment(string comment)
	{
		if (bool_0)
		{
			method_3();
		}
		if (comment.IndexOf("--") >= 0)
		{
			comment = comment.Replace("--", "-- -->\r\n<!-- ");
		}
		stringBuilder_0.Append("\r\n<!-- ");
		stringBuilder_0.Append(comment);
		stringBuilder_0.Append("-->\r\n");
		int_5 = 0;
	}

	private void method_7(string text, bool canBreakBefore, bool canBreakAfter)
	{
		method_8(text, 0, text.Length, canBreakBefore, canBreakAfter);
	}

	private void method_8(string text, int startIndex, int length, bool canBreakBefore, bool canBreakAfter)
	{
		if (canBreakBefore && (int_5 >= 80 || int_5 + length >= 80))
		{
			stringBuilder_0.Append("\r\n");
			int_5 = 0;
		}
		stringBuilder_0.Append(text, startIndex, length);
		int_5 += length;
		if (canBreakAfter && int_5 >= 80)
		{
			stringBuilder_0.Append("\r\n");
			int_5 = 0;
		}
	}

	private void method_9(char text, bool canBreakBefore, bool canBreakAfter)
	{
		if (canBreakBefore && int_5 >= 80)
		{
			stringBuilder_0.Append("\r\n");
			int_5 = 0;
		}
		stringBuilder_0.Append(text);
		int_5++;
		if (canBreakAfter && int_5 >= 80)
		{
			stringBuilder_0.Append("\r\n");
			int_5 = 0;
		}
	}

	private void method_10()
	{
		if (int_5 >= 80)
		{
			stringBuilder_0.Append("\r\n");
			int_5 = 0;
		}
		else
		{
			stringBuilder_0.Append(' ');
			int_5++;
		}
	}
}
