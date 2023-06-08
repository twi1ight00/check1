using System.Collections;
using System.Drawing;
using System.Globalization;

namespace Aspose.Cells;

public class HeaderFooterCommand
{
	private HeaderFooterCommandType headerFooterCommandType_0;

	internal Font font_0;

	private string string_0;

	public HeaderFooterCommandType Type => headerFooterCommandType_0;

	public Font Font => font_0;

	public string Text => string_0;

	internal HeaderFooterCommand(HeaderFooterCommandType headerFooterCommandType_1, Font font_1, string string_1)
	{
		headerFooterCommandType_0 = headerFooterCommandType_1;
		font_0 = font_1;
		string_0 = string_1;
	}

	internal static ArrayList smethod_0(Workbook workbook_0, string string_1)
	{
		Font font = null;
		bool flag = false;
		int num = 0;
		bool flag2 = false;
		bool flag3 = false;
		if (string_1 != null && !(string_1 == ""))
		{
			ArrayList arrayList = new ArrayList();
			int i;
			for (i = 0; i < string_1.Length; i++)
			{
				flag = false;
				if (string_1[i] != '&')
				{
					flag3 = false;
				}
				else
				{
					if (i + 1 >= string_1.Length)
					{
						continue;
					}
					switch (string_1[i + 1])
					{
					default:
						i++;
						flag = false;
						flag2 = false;
						flag3 = false;
						break;
					case '&':
					case 'A':
					case 'D':
					case 'F':
					case 'G':
					case 'N':
					case 'P':
					case 'T':
					case 'Z':
						i++;
						flag = true;
						flag2 = false;
						flag3 = false;
						break;
					case '"':
					case '1':
					case '2':
					case '3':
					case '4':
					case '5':
					case '6':
					case '7':
					case '8':
					case '9':
					case 'B':
					case 'E':
					case 'I':
					case 'K':
					case 'S':
					case 'U':
					case 'X':
					case 'Y':
						flag2 = true;
						i++;
						flag = true;
						break;
					}
					if (!flag)
					{
						if (i - 1 > num)
						{
							arrayList.Add(new HeaderFooterCommand(HeaderFooterCommandType.Text, font, string_1.Substring(num, i - 1 - num)));
							i++;
							num = i;
						}
						continue;
					}
					if (i - 1 > num)
					{
						arrayList.Add(new HeaderFooterCommand(HeaderFooterCommandType.Text, font, string_1.Substring(num, i - 1 - num)));
					}
					if (flag2)
					{
						if (font == null)
						{
							font = new Font(workbook_0.Worksheets, null, bool_0: false);
							font.Copy(workbook_0.Worksheets.DefaultFont);
						}
						else if (!flag3)
						{
							font = new Font(workbook_0.Worksheets, null, bool_0: false);
							font.Copy(workbook_0.Worksheets.DefaultFont);
						}
						flag3 = true;
					}
					switch (string_1[i])
					{
					case 'A':
						arrayList.Add(new HeaderFooterCommand(HeaderFooterCommandType.SheetName, font, null));
						goto case '&';
					case 'B':
						font.IsBold = true;
						goto case '&';
					case 'D':
						arrayList.Add(new HeaderFooterCommand(HeaderFooterCommandType.CurrentDate, font, null));
						goto case '&';
					case 'E':
						font.Underline = FontUnderlineType.Double;
						goto case '&';
					case 'F':
						arrayList.Add(new HeaderFooterCommand(HeaderFooterCommandType.FileName, font, null));
						goto case '&';
					case 'G':
						arrayList.Add(new HeaderFooterCommand(HeaderFooterCommandType.Picture, font, null));
						goto case '&';
					case 'I':
						font.IsItalic = true;
						goto case '&';
					case 'K':
						if (i + 6 < string_1.Length)
						{
							try
							{
								int red = int.Parse(string_1.Substring(i + 1, 2), NumberStyles.HexNumber);
								int green = int.Parse(string_1.Substring(i + 3, 2), NumberStyles.HexNumber);
								int blue = int.Parse(string_1.Substring(i + 5, 2), NumberStyles.HexNumber);
								font.Color = Color.FromArgb(red, green, blue);
							}
							catch
							{
							}
							i += 6;
							goto case '&';
						}
						throw new CellsException(ExceptionType.InvalidData, "Invalid font color of the page header/footer");
					case 'N':
						arrayList.Add(new HeaderFooterCommand(HeaderFooterCommandType.Pagecount, font, null));
						goto case '&';
					case 'P':
						arrayList.Add(new HeaderFooterCommand(HeaderFooterCommandType.CurrentPage, font, null));
						goto case '&';
					case 'S':
						font.IsStrikeout = true;
						goto case '&';
					case 'T':
						arrayList.Add(new HeaderFooterCommand(HeaderFooterCommandType.CurrentTime, font, null));
						goto case '&';
					case 'U':
						font.Underline = FontUnderlineType.Single;
						goto case '&';
					default:
						num = i;
						for (i++; i < string_1.Length && char.IsDigit(string_1[i]); i++)
						{
						}
						font.Size = int.Parse(string_1.Substring(num, i - num));
						i--;
						goto case '&';
					case 'X':
						font.IsSuperscript = true;
						goto case '&';
					case 'Y':
						font.IsSubscript = true;
						goto case '&';
					case 'Z':
						arrayList.Add(new HeaderFooterCommand(HeaderFooterCommandType.FilePath, font, null));
						goto case '&';
					case '"':
						i++;
						num = i;
						for (; i < string_1.Length && string_1[i] != '"'; i++)
						{
						}
						if (i - num >= 0)
						{
							string string_2 = string_1.Substring(num, i - num);
							smethod_1(font, string_2);
						}
						goto case '&';
					case '&':
						num = ((string_1[i] == '&') ? i : (i + 1));
						break;
					}
				}
			}
			if (i > num && num < string_1.Length)
			{
				arrayList.Add(new HeaderFooterCommand(HeaderFooterCommandType.Text, font, string_1.Substring(num, i - num)));
			}
			return arrayList;
		}
		return null;
	}

	private static void smethod_1(Font font_1, string string_1)
	{
		int num = string_1.IndexOf(',');
		if (num == -1)
		{
			font_1.method_13(string_1);
			return;
		}
		font_1.method_13(string_1.Substring(0, num));
		string_1 = string_1.Substring(num + 1);
		string[] array = string_1.Split(' ');
		for (int i = 0; i < array.Length; i++)
		{
			switch (array[i])
			{
			case "Regular":
			case "常规":
				font_1.IsItalic = false;
				font_1.IsBold = false;
				break;
			case "Italic":
			case "倾斜":
				font_1.IsItalic = true;
				break;
			case "Bold":
			case "加粗":
				font_1.IsBold = true;
				break;
			}
		}
	}
}
