using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using ns1;
using ns8;

namespace ns2;

internal class Class1385
{
	private static string smethod_0(TextAlignmentType textAlignmentType_0, Aspose.Cells.Font font_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (font_0.IsBold)
		{
			stringBuilder.Append("FONT-WEIGHT: bold;");
		}
		if (font_0.IsItalic)
		{
			stringBuilder.Append("FONT-STYLE: italic;");
		}
		if (font_0.Underline != 0 || font_0.IsStrikeout)
		{
			stringBuilder.Append("TEXT-DECORATION:");
			if (font_0.Underline != 0)
			{
				stringBuilder.Append(" underline");
				if (font_0.IsStrikeout)
				{
					stringBuilder.Append(" line-through;");
				}
				else
				{
					stringBuilder.Append(";");
				}
			}
			else if (font_0.IsStrikeout)
			{
				stringBuilder.Append(" line-through;");
			}
		}
		stringBuilder.Append("FONT-FAMILY: " + font_0.Name + ";");
		stringBuilder.Append("FONT-SIZE: " + font_0.Size + "pt;");
		stringBuilder.Append("COLOR: #" + font_0.Color.R.ToString("x02") + font_0.Color.G.ToString("x02") + font_0.Color.B.ToString("x02") + ";");
		string text = null;
		switch (textAlignmentType_0)
		{
		case TextAlignmentType.Left:
			text = "left;";
			break;
		case TextAlignmentType.Right:
			text = "right;";
			break;
		case TextAlignmentType.Center:
			text = "center;";
			break;
		}
		if (text != null)
		{
			stringBuilder.Append("TEXT-ALIGN: " + text);
		}
		return stringBuilder.ToString();
	}

	internal static string smethod_1(Cell cell_0)
	{
		Style style = cell_0.method_32();
		MemoryStream memoryStream = new MemoryStream();
		XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
		if (cell_0.IsRichText())
		{
			FontSetting[] characters = cell_0.GetCharacters();
			string stringValue = cell_0.StringValue;
			foreach (FontSetting fontSetting in characters)
			{
				xmlTextWriter.WriteStartElement("Font");
				string value = smethod_0(style.HorizontalAlignment, fontSetting.Font);
				xmlTextWriter.WriteAttributeString("Style", value);
				if (fontSetting.Font.IsSuperscript)
				{
					xmlTextWriter.WriteStartElement("Sup");
				}
				if (fontSetting.Font.IsSubscript)
				{
					xmlTextWriter.WriteStartElement("Sub");
				}
				xmlTextWriter.WriteString(stringValue.Substring(fontSetting.StartIndex, fontSetting.Length));
				if (fontSetting.Font.IsSuperscript)
				{
					xmlTextWriter.WriteEndElement();
				}
				if (fontSetting.Font.IsSubscript)
				{
					xmlTextWriter.WriteStartElement("Sub");
				}
				xmlTextWriter.WriteEndElement();
			}
		}
		else
		{
			xmlTextWriter.WriteStartElement("Font");
			string value2 = smethod_0(style.HorizontalAlignment, style.Font);
			xmlTextWriter.WriteAttributeString("Style", value2);
			if (style.Font.IsSuperscript)
			{
				xmlTextWriter.WriteStartElement("Sup");
			}
			if (style.Font.IsSubscript)
			{
				xmlTextWriter.WriteStartElement("Sub");
			}
			xmlTextWriter.WriteString(cell_0.StringValue);
			if (style.Font.IsSuperscript)
			{
				xmlTextWriter.WriteEndElement();
			}
			if (style.Font.IsSubscript)
			{
				xmlTextWriter.WriteStartElement("Sub");
			}
			xmlTextWriter.WriteEndElement();
		}
		xmlTextWriter.Flush();
		xmlTextWriter.Close();
		memoryStream.Close();
		byte[] array = memoryStream.ToArray();
		return Encoding.UTF8.GetString(array, 3, array.Length - 3);
	}

	internal static string smethod_2(Class1737 class1737_0)
	{
		TextAlignmentType textHorizontalAlignment = class1737_0.TextHorizontalAlignment;
		MemoryStream memoryStream = new MemoryStream();
		XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
		if (class1737_0.GetCharacters() != null)
		{
			ArrayList characters = class1737_0.GetCharacters();
			string text = class1737_0.Text;
			for (int i = 0; i < characters.Count; i++)
			{
				FontSetting fontSetting = (FontSetting)characters[i];
				xmlTextWriter.WriteStartElement("Font");
				string value = smethod_0(textHorizontalAlignment, fontSetting.Font);
				xmlTextWriter.WriteAttributeString("Style", value);
				xmlTextWriter.WriteString(text.Substring(fontSetting.StartIndex, fontSetting.Length));
				xmlTextWriter.WriteEndElement();
			}
		}
		else
		{
			xmlTextWriter.WriteStartElement("Font");
			string value2 = smethod_0(textHorizontalAlignment, class1737_0.Font);
			xmlTextWriter.WriteAttributeString("Style", value2);
			xmlTextWriter.WriteString(class1737_0.Text);
			xmlTextWriter.WriteEndElement();
		}
		xmlTextWriter.Flush();
		xmlTextWriter.Close();
		memoryStream.Close();
		byte[] array = memoryStream.ToArray();
		return Encoding.UTF8.GetString(array, 3, array.Length - 3);
	}

	internal static void smethod_3(WorksheetCollection worksheetCollection_0, Aspose.Cells.Font font_0, Hashtable hashtable_0)
	{
		string text = (string)hashtable_0["STYLE"];
		if (text != null)
		{
			string[] array = text.Split(';');
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(':');
				for (int j = 0; j < array2.Length; j++)
				{
					array2[j] = array2[j].Trim();
				}
				switch (array2[0].ToUpper())
				{
				case "FONT-SIZE":
				{
					int num = -1;
					string text2 = array2[1].ToUpper();
					string key;
					if ((key = text2) != null)
					{
						if (Class1742.dictionary_100 == null)
						{
							Class1742.dictionary_100 = new Dictionary<string, int>(7)
							{
								{ "X-SMALL", 0 },
								{ "XX-SMALL", 1 },
								{ "SMALL", 2 },
								{ "MEDIUM", 3 },
								{ "LARGE", 4 },
								{ "X-LARGE", 5 },
								{ "XX-LARGE", 6 }
							};
						}
						if (Class1742.dictionary_100.TryGetValue(key, out var value))
						{
							switch (value)
							{
							case 0:
								font_0.Size = 8;
								goto end_IL_0070;
							case 1:
								font_0.Size = 10;
								goto end_IL_0070;
							case 2:
								font_0.Size = 12;
								goto end_IL_0070;
							case 3:
								font_0.Size = 14;
								goto end_IL_0070;
							case 4:
								font_0.Size = 18;
								goto end_IL_0070;
							case 5:
								font_0.Size = 24;
								goto end_IL_0070;
							case 6:
								font_0.Size = 36;
								goto end_IL_0070;
							}
						}
					}
					char[] array4 = text2.ToCharArray();
					for (int l = 0; l < array4.Length; l++)
					{
						if (!char.IsDigit(array4[l]) && array4[l] != '.' && array4[l] != '+' && array4[l] != '-')
						{
							num = l;
							break;
						}
					}
					string text3 = "PX";
					double num2 = 0.0;
					if (num == -1)
					{
						num2 = double.Parse(array2[1]);
					}
					else
					{
						num2 = double.Parse(array2[1].Substring(0, num).Trim());
						text3 = array2[1].Substring(num).Trim();
					}
					double num3 = 0.0;
					font_0.DoubleSize = text3.ToUpper() switch
					{
						"CM" => num2 * 72.0 / 2.54, 
						"IN" => num2 * 72.0, 
						"PT" => num2, 
						"PX" => num2 * 72.0 / (double)worksheetCollection_0.method_75(), 
						_ => num2, 
					};
					break;
				}
				case "COLOR":
					if (array2[1].ToUpper().StartsWith("RGB("))
					{
						string text4 = array2[1].Substring(4, array2[1].Length - 5);
						string[] array5 = text4.Split(',');
						font_0.Color = Color.FromArgb(int.Parse(array5[0]), int.Parse(array5[1]), int.Parse(array5[2]));
					}
					else
					{
						font_0.Color = ColorTranslator.FromHtml(array2[1]);
					}
					break;
				case "FONT-FAMILY":
					font_0.method_13(array2[1]);
					break;
				case "TEXT-DECORATION":
				{
					string[] array3 = array2[1].ToUpper().Split(' ');
					for (int k = 0; k < array3.Length; k++)
					{
						switch (array3[k].Trim())
						{
						case "LINE-THROUGH":
							font_0.IsStrikeout = true;
							break;
						case "UNDERLINE":
							font_0.Underline = FontUnderlineType.Single;
							break;
						}
					}
					break;
				}
				case "FONT-STYLE":
					font_0.IsItalic = array2[1].ToUpper() == "ITALIC";
					break;
				case "FONT-WEIGHT":
					{
						font_0.IsBold = array2[1].ToUpper() == "BOLD";
						break;
					}
					end_IL_0070:
					break;
				}
			}
			return;
		}
		IEnumerator enumerator = hashtable_0.Keys.GetEnumerator();
		while (enumerator.MoveNext())
		{
			string text5 = (string)enumerator.Current;
			object obj = hashtable_0[text5];
			switch (text5.ToUpper())
			{
			case "FACE":
			{
				string text6 = (string)obj;
				int num4 = text6.IndexOf(',');
				if (num4 == -1)
				{
					font_0.method_13(text6);
				}
				else
				{
					font_0.method_13(text6.Substring(0, num4).Trim());
				}
				break;
			}
			case "COLOR":
				font_0.Color = ColorTranslator.FromHtml((string)obj);
				break;
			case "SIZE":
				font_0.DoubleSize = double.Parse((string)obj);
				break;
			}
		}
	}

	internal static void smethod_4(StringBuilder stringBuilder_0, Hashtable hashtable_0)
	{
		string text = stringBuilder_0.ToString();
		if (text == "")
		{
			return;
		}
		stringBuilder_0.Remove(0, stringBuilder_0.Length);
		if (text.IndexOf('=') != -1)
		{
			string[] array = text.Split('=');
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = array[i].Trim();
				if (array[i][0] == '\'')
				{
					array[i] = array[i].Substring(1, array.Length - 2);
				}
				if (array[i][0] == '"')
				{
					array[i] = array[i].Substring(1, array.Length - 2);
				}
			}
			hashtable_0.Add(array[0].ToUpper(), array[1]);
		}
		else
		{
			hashtable_0.Add(text.ToUpper(), true);
		}
	}

	internal static string smethod_5(WorksheetCollection worksheetCollection_0, Aspose.Cells.Font font_0, string string_0, ArrayList arrayList_0)
	{
		char[] array = string_0.ToCharArray();
		StringBuilder stringBuilder = new StringBuilder();
		Aspose.Cells.Font font = new Aspose.Cells.Font(worksheetCollection_0, null, bool_0: false);
		font.Copy(font_0);
		int num = 0;
		bool flag = false;
		bool flag2 = false;
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == '<')
			{
				if (array[i + 1] == ' ')
				{
					stringBuilder.Append(array[i]);
					continue;
				}
				if (array[i + 1] == '!' && array[i + 2] == '-' && array[i + 3] == '-')
				{
					for (i += 4; i < array.Length; i++)
					{
						if (array[i] == '-' && array[i + 1] == '-' && array[i + 2] == '>')
						{
							i += 2;
							break;
						}
					}
					continue;
				}
				bool flag3;
				if (flag3 = array[i + 1] == '/')
				{
					i++;
				}
				StringBuilder stringBuilder2 = new StringBuilder();
				Hashtable hashtable = new Hashtable();
				string text = null;
				for (i++; i < array.Length && array[i] != '>'; i++)
				{
					if (array[i] == '=')
					{
						bool flag4 = false;
						string key = stringBuilder2.ToString().Trim().ToUpper();
						stringBuilder2.Remove(0, stringBuilder2.Length);
						for (i++; i < array.Length; i++)
						{
							if (array[i] != '>')
							{
								if (array[i] == ' ')
								{
									if (!flag4)
									{
										break;
									}
								}
								else if (array[i] == '\'')
								{
									for (i++; i < array.Length && array[i] != '\''; i++)
									{
										stringBuilder2.Append(array[i]);
									}
									flag4 = false;
								}
								else if (array[i] == '"')
								{
									for (i++; i < array.Length && array[i] != '"'; i++)
									{
										stringBuilder2.Append(array[i]);
									}
									flag4 = false;
								}
								else
								{
									stringBuilder2.Append(array[i]);
									flag4 = false;
								}
								continue;
							}
							i--;
							break;
						}
						hashtable.Add(key, stringBuilder2.ToString().Trim());
						stringBuilder2.Remove(0, stringBuilder2.Length);
					}
					else if (array[i] == ' ')
					{
						if (stringBuilder2.Length > 0)
						{
							if (text == null)
							{
								text = stringBuilder2.ToString().Trim().ToUpper();
								stringBuilder2.Remove(0, stringBuilder2.Length);
							}
							else
							{
								smethod_4(stringBuilder2, hashtable);
							}
						}
					}
					else
					{
						stringBuilder2.Append(array[i]);
					}
				}
				if (stringBuilder2.Length > 0)
				{
					if (text == null)
					{
						text = stringBuilder2.ToString().Trim().ToUpper();
						stringBuilder2.Remove(0, stringBuilder2.Length);
					}
					else
					{
						smethod_4(stringBuilder2, hashtable);
					}
				}
				if (flag3)
				{
					ArrayList arrayList3 = new ArrayList();
					arrayList3.Add(text);
					i++;
					while (i < array.Length)
					{
						if (array[i] == '<' && array[i + 1] == '/')
						{
							for (i += 2; i < array.Length && array[i] != '>'; i++)
							{
								stringBuilder2.Append(array[i]);
							}
							arrayList3.Add(stringBuilder2.ToString().ToUpper());
							stringBuilder2.Remove(0, stringBuilder2.Length);
							i++;
							continue;
						}
						i--;
						break;
					}
					if (num != stringBuilder.Length)
					{
						FontSetting fontSetting = new FontSetting(num, stringBuilder.Length - num, worksheetCollection_0, bool_1: false);
						fontSetting.Font.Copy(font);
						arrayList_0.Add(fontSetting);
						num = stringBuilder.Length;
					}
					for (int j = 0; j < arrayList3.Count; j++)
					{
						string key2;
						if ((key2 = (string)arrayList3[j]) == null)
						{
							continue;
						}
						if (Class1742.dictionary_101 == null)
						{
							Class1742.dictionary_101 = new Dictionary<string, int>(15)
							{
								{ "P", 0 },
								{ "OL", 1 },
								{ "UL", 2 },
								{ "LI", 3 },
								{ "TD", 4 },
								{ "FONT", 5 },
								{ "SPAN", 6 },
								{ "B", 7 },
								{ "STRONG", 8 },
								{ "I", 9 },
								{ "U", 10 },
								{ "S", 11 },
								{ "STRIKE", 12 },
								{ "SUP", 13 },
								{ "SUB", 14 }
							};
						}
						if (!Class1742.dictionary_101.TryGetValue(key2, out var value))
						{
							continue;
						}
						switch (value)
						{
						case 0:
							stringBuilder.Append('\n');
							break;
						case 1:
						case 2:
							arrayList.RemoveAt(arrayList.Count - 1);
							if (arrayList2.Count > arrayList.Count)
							{
								arrayList2.RemoveRange(arrayList.Count, arrayList2.Count - arrayList.Count);
							}
							break;
						case 3:
							stringBuilder.Append('\n');
							break;
						case 4:
						case 5:
						case 6:
							font = new Aspose.Cells.Font(worksheetCollection_0, null, bool_0: false);
							break;
						case 7:
						case 8:
							font.IsBold = false;
							break;
						case 9:
							font.IsItalic = false;
							break;
						case 10:
							font.Underline = FontUnderlineType.None;
							break;
						case 11:
						case 12:
							font.IsStrikeout = false;
							break;
						case 13:
							font.IsSuperscript = false;
							break;
						case 14:
							font.IsSubscript = false;
							break;
						}
					}
				}
				else
				{
					if (text == null || text == "")
					{
						continue;
					}
					if (text.EndsWith("/"))
					{
						if (text.StartsWith("BR"))
						{
							stringBuilder.Append('\n');
						}
						continue;
					}
					string key3;
					if ((key3 = text) != null)
					{
						if (Class1742.dictionary_102 == null)
						{
							Class1742.dictionary_102 = new Dictionary<string, int>(15)
							{
								{ "TD", 0 },
								{ "FONT", 1 },
								{ "SPAN", 2 },
								{ "B", 3 },
								{ "STRONG", 4 },
								{ "I", 5 },
								{ "U", 6 },
								{ "S", 7 },
								{ "STRIKE", 8 },
								{ "SUP", 9 },
								{ "SUB", 10 },
								{ "BR", 11 },
								{ "UL", 12 },
								{ "OL", 13 },
								{ "LI", 14 }
							};
						}
						if (Class1742.dictionary_102.TryGetValue(key3, out var value2))
						{
							switch (value2)
							{
							case 0:
							case 1:
							case 2:
								flag = true;
								break;
							case 3:
							case 4:
							case 5:
							case 6:
							case 7:
							case 8:
							case 9:
							case 10:
								flag = true;
								break;
							case 11:
								stringBuilder.Append('\n');
								continue;
							case 12:
							case 13:
								arrayList.Add(text);
								break;
							case 14:
							{
								int num2 = 1;
								if (arrayList.Count > arrayList2.Count)
								{
									arrayList2.Add(num2);
								}
								else
								{
									num2 = (int)arrayList2[arrayList2.Count - 1];
									num2++;
									arrayList2[arrayList2.Count - 1] = num2;
								}
								for (int k = 0; k < arrayList2.Count; k++)
								{
									stringBuilder.Append("    ");
								}
								if (arrayList.Count > 0 && (string)arrayList[arrayList.Count - 1] == "OL")
								{
									stringBuilder.Append(num2 + ".");
									stringBuilder.Append(" ");
								}
								break;
							}
							}
						}
					}
					if (!flag2 && num != stringBuilder.Length)
					{
						FontSetting fontSetting2 = new FontSetting(num, stringBuilder.Length - num, worksheetCollection_0, bool_1: false);
						fontSetting2.Font.Copy(font);
						arrayList_0.Add(fontSetting2);
						num = stringBuilder.Length;
					}
					string key4;
					if ((key4 = text) != null)
					{
						if (Class1742.dictionary_103 == null)
						{
							Class1742.dictionary_103 = new Dictionary<string, int>(11)
							{
								{ "TD", 0 },
								{ "FONT", 1 },
								{ "SPAN", 2 },
								{ "STRONG", 3 },
								{ "B", 4 },
								{ "I", 5 },
								{ "U", 6 },
								{ "S", 7 },
								{ "STRIKE", 8 },
								{ "SUP", 9 },
								{ "SUB", 10 }
							};
						}
						if (Class1742.dictionary_103.TryGetValue(key4, out var value3))
						{
							switch (value3)
							{
							case 0:
								font = new Aspose.Cells.Font(worksheetCollection_0, null, bool_0: false);
								font.Copy(font_0);
								smethod_3(worksheetCollection_0, font, hashtable);
								break;
							case 1:
							case 2:
								font = new Aspose.Cells.Font(worksheetCollection_0, null, bool_0: false);
								font.Copy(font_0);
								smethod_3(worksheetCollection_0, font, hashtable);
								break;
							case 3:
							case 4:
								font.IsBold = true;
								break;
							case 5:
								font.IsItalic = true;
								break;
							case 6:
								font.Underline = FontUnderlineType.Single;
								break;
							case 7:
							case 8:
								font.IsStrikeout = true;
								break;
							case 9:
								font.IsSuperscript = true;
								break;
							case 10:
								font.IsSubscript = true;
								break;
							}
						}
					}
					flag2 = flag;
				}
			}
			else if (array[i] == '&')
			{
				flag2 = false;
				int num3 = i;
				StringBuilder stringBuilder3 = new StringBuilder();
				bool flag5 = false;
				for (; i < array.Length; i++)
				{
					stringBuilder3.Append(array[i]);
					if (array[i] == ';')
					{
						flag5 = true;
						break;
					}
				}
				if (flag5)
				{
					Class429.smethod_1(stringBuilder, stringBuilder3);
					continue;
				}
				i = num3;
				stringBuilder.Append(array[i]);
			}
			else if (array[i] == '\r')
			{
				flag2 = false;
				if (i + 1 < array.Length && array[i + 1] == '\n')
				{
					stringBuilder.Append('\n');
					i++;
				}
				else
				{
					stringBuilder.Append('\n');
				}
			}
			else
			{
				flag2 = false;
				stringBuilder.Append(array[i]);
			}
		}
		if (num != stringBuilder.Length)
		{
			FontSetting fontSetting3 = new FontSetting(num, stringBuilder.Length - num, worksheetCollection_0, bool_1: false);
			fontSetting3.Font.Copy(font);
			arrayList_0.Add(fontSetting3);
			num = stringBuilder.Length;
		}
		if (stringBuilder.Length > 0 && stringBuilder[stringBuilder.Length - 1] == '\n')
		{
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
			if (arrayList_0.Count > 0)
			{
				FontSetting fontSetting4 = (FontSetting)arrayList_0[arrayList_0.Count - 1];
				if (fontSetting4.StartIndex + fontSetting4.Length > stringBuilder.Length)
				{
					fontSetting4.method_1(stringBuilder.Length - fontSetting4.StartIndex);
					if (fontSetting4.Length < 0)
					{
						arrayList_0.RemoveAt(arrayList_0.Count - 1);
					}
				}
			}
		}
		return stringBuilder.ToString();
	}

	internal static void smethod_6(Cell cell_0, string string_0)
	{
		Aspose.Cells.Font font = cell_0.GetStyle().Font;
		WorksheetCollection worksheetCollection_ = cell_0.method_4().method_19();
		ArrayList arrayList = new ArrayList();
		string text = smethod_5(worksheetCollection_, font, string_0, arrayList);
		if (arrayList.Count == 2)
		{
			FontSetting fontSetting = (FontSetting)arrayList[1];
			if (fontSetting.StartIndex == text.Length)
			{
				arrayList.RemoveAt(1);
			}
		}
		cell_0.method_67(text, arrayList);
	}

	internal static void smethod_7(Shape shape_0, Class1737 class1737_0, string string_0)
	{
		Aspose.Cells.Font font = class1737_0.Font;
		WorksheetCollection worksheetCollection_ = shape_0.method_25();
		ArrayList arrayList = new ArrayList();
		class1737_0.Text = smethod_5(worksheetCollection_, font, string_0, arrayList);
		if (arrayList.Count != 0)
		{
			if (arrayList.Count == 1)
			{
				class1737_0.Font.Copy(((FontSetting)arrayList[0]).Font);
			}
			else
			{
				class1737_0.method_13(arrayList);
			}
		}
	}
}
