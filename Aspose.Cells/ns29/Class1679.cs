using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using Aspose.Cells;
using ns1;
using ns47;

namespace ns29;

internal class Class1679
{
	internal static string[] Split(string string_0, char char_0)
	{
		if (string_0.IndexOf('"') != -1)
		{
			char[] array = string_0.ToCharArray();
			ArrayList arrayList = new ArrayList();
			StringBuilder stringBuilder = new StringBuilder(array.Length);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == char_0)
				{
					arrayList.Add(stringBuilder.ToString());
					stringBuilder = new StringBuilder(array.Length);
				}
				else if (array[i] == '"')
				{
					i++;
					while (i < array.Length && array[i] == '"' && i + 1 < array.Length && array[i + 1] == '"')
					{
						stringBuilder.Append('"');
						i++;
						i++;
					}
				}
				else
				{
					stringBuilder.Append(array[i]);
				}
			}
			return null;
		}
		return string_0.Split(char_0);
	}

	internal static int smethod_0(Graphics graphics_0, System.Drawing.Font font_0)
	{
		if ((int)font_0.Size == 0)
		{
			throw new CellsException(ExceptionType.InvalidData, "Default font size is 0.");
		}
		int num = 0;
		string text = "00";
		CharacterRange[] measurableCharacterRanges = new CharacterRange[1]
		{
			new CharacterRange(0, 1)
		};
		float x = 0f;
		float y = 0f;
		float width = 100f;
		float height = 100f;
		RectangleF layoutRect = new RectangleF(x, y, width, height);
		StringFormat stringFormat = new StringFormat();
		stringFormat.SetMeasurableCharacterRanges(measurableCharacterRanges);
		Region[] array = new Region[1];
		array = graphics_0.MeasureCharacterRanges(text, font_0, layoutRect, stringFormat);
		num = (int)array[0].GetBounds(graphics_0).Width;
		if (num == 0)
		{
			using System.Drawing.Font font_ = new System.Drawing.Font("Arial", font_0.Size);
			num = smethod_0(graphics_0, font_);
		}
		return num;
	}

	internal static int smethod_1(Graphics graphics_0, System.Drawing.Font font_0)
	{
		int num = 0;
		string text = "0";
		CharacterRange[] measurableCharacterRanges = new CharacterRange[1]
		{
			new CharacterRange(0, 1)
		};
		float x = 0f;
		float y = 0f;
		float width = 100f;
		float height = 100f;
		RectangleF layoutRect = new RectangleF(x, y, width, height);
		StringFormat stringFormat = new StringFormat();
		stringFormat.SetMeasurableCharacterRanges(measurableCharacterRanges);
		Region[] array = new Region[1];
		array = graphics_0.MeasureCharacterRanges(text, font_0, layoutRect, stringFormat);
		num = (int)array[0].GetBounds(graphics_0).Width;
		if (num == 0)
		{
			using System.Drawing.Font font_ = new System.Drawing.Font("Arial", font_0.Size);
			num = smethod_1(graphics_0, font_);
		}
		return num;
	}

	internal static int[] smethod_2(WorksheetCollection worksheetCollection_0)
	{
		Aspose.Cells.Font font = (Aspose.Cells.Font)worksheetCollection_0.method_52()[0];
		if (font.Size == 0)
		{
			throw new CellsException(ExceptionType.InvalidData, "Default font size is 0.");
		}
		int num = 0;
		int num2 = 96;
		int num3 = 96;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		bool flag = false;
		using (Bitmap bitmap = new Bitmap(1, 1))
		{
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				num2 = (int)graphics.DpiX;
				num3 = (int)graphics.DpiY;
				FontStyle fontStyle = FontStyle.Regular;
				if (font.IsBold)
				{
					fontStyle |= FontStyle.Bold;
				}
				if (font.IsItalic)
				{
					fontStyle |= FontStyle.Italic;
				}
				string familyName = worksheetCollection_0.Workbook.method_0(font.Name);
				float num7 = (float)font.DoubleSize;
				if ((double)num7 > 409.5)
				{
					familyName = "Arial";
					num7 = 10f;
				}
				if (num2 == 96 && fontStyle == FontStyle.Regular)
				{
					using (System.Drawing.Font font2 = new System.Drawing.Font(familyName, num7, fontStyle))
					{
						string name;
						if ((name = font2.FontFamily.GetName(1033)) != null)
						{
							if (Class1742.dictionary_218 == null)
							{
								Class1742.dictionary_218 = new Dictionary<string, int>(7)
								{
									{ "Arial", 0 },
									{ "Verdana", 1 },
									{ "MS PGothic", 2 },
									{ "SimSun", 3 },
									{ "MS Gothic", 4 },
									{ "Times New Roman", 5 },
									{ "Frutiger 45 Light", 6 }
								};
							}
							if (Class1742.dictionary_218.TryGetValue(name, out var value))
							{
								switch (value)
								{
								case 0:
									switch ((int)num7)
									{
									case 8:
										num4 = 6;
										num = 5;
										flag = true;
										break;
									case 10:
										num4 = 7;
										num = 5;
										flag = true;
										break;
									}
									break;
								case 1:
								{
									int num10 = (int)num7;
									if (num10 == 7)
									{
										num4 = 7;
										num = 5;
										flag = true;
									}
									break;
								}
								case 2:
								case 3:
								{
									int num11 = (int)num7;
									if (num11 == 11)
									{
										num4 = 8;
										num = 5;
										flag = true;
									}
									break;
								}
								case 4:
									switch ((int)num7)
									{
									case 9:
										num4 = 6;
										num = 5;
										flag = true;
										break;
									case 11:
										num4 = 8;
										num = 5;
										flag = true;
										break;
									}
									break;
								case 5:
								{
									int num9 = (int)num7;
									if (num9 == 10)
									{
										num4 = 6;
										num = 5;
										flag = true;
									}
									break;
								}
								case 6:
								{
									int num8 = (int)num7;
									if (num8 == 10)
									{
										num4 = 8;
										num = 5;
										flag = true;
									}
									break;
								}
								}
							}
						}
						if (!flag)
						{
							num4 = smethod_0(graphics, font2);
						}
					}
					if (!flag)
					{
						float num12 = 0f;
						num12 = ((!(num7 > 1f)) ? 1f : ((float)((int)num7 / 2)));
						using System.Drawing.Font font_ = new System.Drawing.Font(familyName, num12, fontStyle);
						num = smethod_1(graphics, font_);
					}
				}
				else
				{
					using (System.Drawing.Font font_2 = new System.Drawing.Font(familyName, num7, fontStyle))
					{
						num4 = smethod_0(graphics, font_2);
					}
					int num13 = 0;
					num13 = ((!(num7 > 1f)) ? 1 : ((int)num7 / 2));
					using System.Drawing.Font font_3 = new System.Drawing.Font(familyName, num13, fontStyle);
					num = smethod_1(graphics, font_3);
				}
				graphics.Dispose();
			}
			bitmap.Dispose();
		}
		num5 = ((!flag) ? (num + ((font.Size <= 30) ? 1 : 2)) : num);
		num6 = (int)((double)num5 * 1.0 / (double)num4 * 256.0);
		return new int[5] { num2, num3, num4, num6, num5 };
	}

	internal static int smethod_3(char[] char_0, char[] char_1, int int_0, int int_1)
	{
		int num;
		while (true)
		{
			if (int_1 < char_1.Length)
			{
				if (char_0[int_0] == char_1[int_1])
				{
					bool flag = true;
					num = int_1 + 1;
					int num2 = int_0 + 1;
					while (num2 < char_0.Length)
					{
						if (char_0[num2] != '*')
						{
							if (num < char_1.Length)
							{
								if (char_0[num2] == char_1[num])
								{
									num2++;
									num++;
									continue;
								}
								flag = false;
								break;
							}
							return num;
						}
						if (num2 + 1 == char_0.Length)
						{
							return char_1.Length - 1;
						}
						return smethod_3(char_0, char_1, num2 + 1, num);
					}
					if (flag)
					{
						break;
					}
				}
				int_1++;
				continue;
			}
			return int_1;
		}
		return num - 1;
	}

	public static int smethod_4(string string_0, string string_1, bool bool_0)
	{
		if (bool_0)
		{
			string_0 = string_0.ToUpper();
			string_1 = string_1.ToUpper();
		}
		char[] array = string_0.ToCharArray();
		char[] array2 = string_1.ToCharArray();
		int num = array.Length;
		int num2 = array2.Length;
		int num3 = 0;
		int num4 = 0;
		while (true)
		{
			if (num3 < num)
			{
				if (num4 >= num2)
				{
					break;
				}
				switch (array[num3])
				{
				case '~':
					if (num3 + 1 < num && (array[num3 + 1] == '*' || array[num3 + 1] == '?'))
					{
						num3++;
					}
					if (array[num3] <= array2[num4])
					{
						if (array[num3] < array2[num4])
						{
							return -1;
						}
						break;
					}
					return 1;
				default:
					if (array[num3] <= array2[num4])
					{
						if (array[num3] < array2[num4])
						{
							return -1;
						}
						break;
					}
					return 1;
				case '*':
					if (num3 + 1 != num)
					{
						if (array[num3 + 1] == '*')
						{
							num4--;
							break;
						}
						num4 = smethod_3(array, array2, num3 + 1, num4);
						if (num4 >= num2)
						{
							return 1;
						}
						if (num4 == num2 - 1)
						{
							return 0;
						}
						return -1;
					}
					return 0;
				case '?':
					break;
				}
				num3++;
				num4++;
				continue;
			}
			if (num4 < num2)
			{
				return -1;
			}
			return 0;
		}
		if (array[num3] == '*' && num3 + 1 == num)
		{
			return 0;
		}
		return 1;
	}

	internal static int smethod_5(string string_0, Aspose.Cells.Font font_0)
	{
		FontStyle fontStyle = FontStyle.Regular;
		float float_ = 10f;
		string string_ = "Arial";
		if (font_0 != null)
		{
			if (font_0.IsBold)
			{
				fontStyle |= FontStyle.Bold;
			}
			if (font_0.IsItalic)
			{
				fontStyle |= FontStyle.Italic;
			}
			if (font_0.IsStrikeout)
			{
				fontStyle |= FontStyle.Strikeout;
			}
			if (font_0.Underline != 0)
			{
				fontStyle |= FontStyle.Underline;
			}
			string_ = font_0.Name;
			float_ = (float)font_0.DoubleSize;
		}
		Class1460 @class = Class1462.smethod_3(string_, fontStyle, bool_0: false);
		int num = 0;
		for (int i = 0; i < string_0.Length; i++)
		{
			num += (int)@class.method_42(string_0[i], float_);
		}
		return num;
	}

	internal static string smethod_6(BinaryReader binaryReader_0, int int_0, bool bool_0)
	{
		if (bool_0)
		{
			byte[] bytes = binaryReader_0.ReadBytes(int_0 * 2);
			return Encoding.Unicode.GetString(bytes);
		}
		byte[] bytes2 = binaryReader_0.ReadBytes(int_0);
		return Encoding.ASCII.GetString(bytes2);
	}
}
