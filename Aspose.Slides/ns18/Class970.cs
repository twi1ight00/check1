using System;
using Aspose.Slides;
using ns16;
using ns56;

namespace ns18;

internal class Class970
{
	internal static readonly char[] char_0 = new char[1] { '\r' };

	public static void smethod_0(IParagraphCollection paragraphs, Class1962[] textParagraphElementDatas, Class1341 deserializationContext)
	{
		if (textParagraphElementDatas == null)
		{
			return;
		}
		paragraphs.Clear();
		foreach (Class1962 @class in textParagraphElementDatas)
		{
			IParagraph paragraph = ((ParagraphCollection)paragraphs).Add();
			Class971.smethod_0(paragraph.ParagraphFormat, @class.PPr, deserializationContext);
			IPortion portion = null;
			if (@class.TextRunList.Length == 0)
			{
				((PortionCollection)paragraph.Portions).Add();
			}
			for (int j = 0; j < @class.TextRunList.Length; j++)
			{
				Class2605 class2 = @class.TextRunList[j];
				IPortion portion2 = ((PortionCollection)paragraph.Portions).Add();
				switch (class2.Name)
				{
				case "br":
				{
					Class1957 class5 = (Class1957)class2.Object;
					portion2.Text = "\v";
					Class979.smethod_0(portion2.PortionFormat, class5.RPr, deserializationContext);
					goto IL_022e;
				}
				case "fld":
				case "r":
				{
					Class1953 rPr;
					string text;
					if (class2.Name == "fld")
					{
						Class1955 class3 = (Class1955)class2.Object;
						portion2.AddField(class3.Type);
						Class971.smethod_0(((Field)portion2.Field).PPTXUnsupportedProps.ParagraphFormat, class3.PPr, deserializationContext);
						((Field)portion2.Field).PPTXUnsupportedProps.Guid = class3.Id;
						rPr = class3.RPr;
						text = class3.T ?? "";
					}
					else
					{
						Class1354 class4 = (Class1354)class2.Object;
						rPr = class4.RPr;
						text = class4.T;
					}
					Class979.smethod_0(portion2.PortionFormat, rPr, deserializationContext);
					int startIndex = 0;
					string text2 = null;
					while ((text2 = smethod_2(text, ref startIndex)) != null)
					{
						portion2.Text = text2;
						((ParagraphFormat)paragraph.ParagraphFormat).PPTXUnsupportedProps.SoftParagraph = true;
						portion = null;
						paragraph = ((ParagraphCollection)paragraphs).Add();
						Class971.smethod_0(paragraph.ParagraphFormat, @class.PPr, deserializationContext);
						portion2 = ((PortionCollection)paragraph.Portions).Add();
						Class979.smethod_0(portion2.PortionFormat, rPr, deserializationContext);
					}
					portion2.Text = ((startIndex > 0) ? text.Substring(startIndex) : text);
					goto IL_022e;
				}
				default:
					{
						throw new Exception("Unknown element \"" + class2.Name + "\"");
					}
					IL_022e:
					if (portion != null && portion.PortionFormat.Equals(portion2.PortionFormat) && portion.Field == null && portion2.Field == null)
					{
						portion.Text = ((Portion)portion).TextInternal + ((Portion)portion2).TextInternal;
						((PortionCollection)paragraph.Portions).method_0();
					}
					else
					{
						portion = portion2;
					}
					break;
				}
			}
			Class1953 endParaRPr = @class.EndParaRPr;
			if (endParaRPr != null)
			{
				IPortion portion3 = ((PortionCollection)paragraph.Portions).Add();
				Class979.smethod_0(portion3.PortionFormat, endParaRPr, deserializationContext);
				if (paragraph.Portions.Count > 1 && portion3.PortionFormat.Equals(paragraph.Portions[paragraph.Portions.Count - 2].PortionFormat))
				{
					((PortionCollection)paragraph.Portions).method_0();
				}
			}
			else if (((Paragraph)paragraph).TextInternal == "" && paragraphs.Count >= 2)
			{
				IParagraph paragraph2 = paragraphs[paragraphs.Count - 2];
				IPortion portion4 = ((PortionCollection)paragraph.Portions).Add();
				((PortionFormat)portion4.PortionFormat).vmethod_1((PortionFormat)paragraph2.Portions[paragraph2.Portions.Count - 1].PortionFormat);
			}
		}
	}

	public static void smethod_1(IParagraphCollection paragraphs, Class1962.Delegate1753 addP, Class1346 serializationContext)
	{
		if (paragraphs.Count == 0)
		{
			addP();
			return;
		}
		Paragraph paragraph = null;
		Class1962 @class = null;
		foreach (Paragraph paragraph2 in paragraphs)
		{
			if (paragraph != null && paragraph.ParagraphFormatInternal.PPTXUnsupportedProps.SoftParagraph && paragraph.ParagraphFormatInternal.method_1(paragraph2.ParagraphFormatInternal))
			{
				@class.delegate1728_0(null);
				Portion portion = (Portion)paragraph.Portions[paragraph.Portions.Count - 1];
				Class1354 class2 = (Class1354)@class.delegate2773_0("r").Object;
				Class979.smethod_1(portion.PortionFormat, class2.delegate1726_0, serializationContext);
				class2.T = "\r\n";
			}
			else
			{
				@class = addP();
				Class971.smethod_2(paragraph2.ParagraphFormat, @class.delegate1756_0, serializationContext);
			}
			foreach (IPortion portion3 in paragraph2.Portions)
			{
				if (portion3.Field == null && ((Portion)portion3).TextInternal == "")
				{
					continue;
				}
				string[] array = ((Portion)portion3).TextInternal.Split('\v');
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] != "" || portion3.Field != null)
					{
						if (portion3.Field != null)
						{
							Class1955 class3 = (Class1955)@class.delegate2773_0("fld").Object;
							class3.Id = ((Field)portion3.Field).PPTXUnsupportedProps.Guid;
							if (portion3.Field.Type != null && portion3.Field.Type.InternalString != null && portion3.Field.Type.InternalString.Length != 0)
							{
								class3.Type = portion3.Field.Type.InternalString;
							}
							Class971.smethod_2(((Field)portion3.Field).PPTXUnsupportedProps.ParagraphFormat, class3.delegate1756_0, serializationContext);
							Class979.smethod_1(portion3.PortionFormat, class3.delegate1726_0, serializationContext);
							class3.T = array[i];
						}
						else
						{
							Class1354 class4 = (Class1354)@class.delegate2773_0("r").Object;
							Class979.smethod_1(portion3.PortionFormat, class4.delegate1726_0, serializationContext);
							class4.T = array[i];
						}
					}
					if (i < array.Length - 1)
					{
						Class1957 class5 = (Class1957)@class.delegate2773_0("br").Object;
						Class979.smethod_1(portion3.PortionFormat, class5.delegate1726_0, serializationContext);
					}
				}
			}
			if (paragraph2.Portions.Count > 0)
			{
				IPortion portion2 = paragraph2.Portions[paragraph2.Portions.Count - 1];
				if (((Portion)portion2).TextInternal == "")
				{
					Class979.smethod_1(portion2.PortionFormat, @class.delegate1726_0, serializationContext);
				}
			}
			paragraph = paragraph2;
		}
	}

	internal static string smethod_2(string str, ref int startIndex)
	{
		int num = str.IndexOfAny(char_0, startIndex);
		if (num < 0)
		{
			return null;
		}
		string result = str.Substring(startIndex, num - startIndex);
		if (num < str.Length - 1 && ((str[num] == '\r' && str[num + 1] == '\n') || (str[num] == '\n' && str[num + 1] == '\r')))
		{
			num++;
		}
		startIndex = num + 1;
		return result;
	}
}
