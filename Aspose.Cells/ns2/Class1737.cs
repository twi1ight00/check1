using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using ns16;

namespace ns2;

internal class Class1737
{
	private string string_0;

	private Font font_0;

	private ArrayList arrayList_0;

	private TextAlignmentType textAlignmentType_0 = TextAlignmentType.Left;

	private TextAlignmentType textAlignmentType_1 = TextAlignmentType.Top;

	private bool bool_0;

	private TextOrientationType textOrientationType_0 = TextOrientationType.NoRotation;

	private TextOverflowType textOverflowType_0;

	private TextOverflowType textOverflowType_1 = TextOverflowType.Overflow;

	internal bool bool_1 = true;

	private int int_0;

	private Shape shape_0;

	internal Class1363 class1363_0;

	private int int_1;

	public TextOverflowType TextVerticalOverflow
	{
		get
		{
			return textOverflowType_0;
		}
		set
		{
			textOverflowType_0 = value;
		}
	}

	internal TextOverflowType TextHorizontalOverflow
	{
		get
		{
			return textOverflowType_1;
		}
		set
		{
			textOverflowType_1 = value;
		}
	}

	internal TextOrientationType TextOrientationType
	{
		get
		{
			return textOrientationType_0;
		}
		set
		{
			method_15();
			textOrientationType_0 = value;
		}
	}

	internal TextAlignmentType TextHorizontalAlignment
	{
		get
		{
			return textAlignmentType_0;
		}
		set
		{
			method_15();
			switch (value)
			{
			case TextAlignmentType.Center:
			case TextAlignmentType.Distributed:
			case TextAlignmentType.Justify:
			case TextAlignmentType.Left:
			case TextAlignmentType.Right:
				textAlignmentType_0 = value;
				break;
			case TextAlignmentType.CenterAcross:
			case TextAlignmentType.Fill:
			case TextAlignmentType.General:
				break;
			}
		}
	}

	internal TextAlignmentType TextVerticalAlignment
	{
		get
		{
			return textAlignmentType_1;
		}
		set
		{
			method_15();
			switch (value)
			{
			case TextAlignmentType.Bottom:
			case TextAlignmentType.Center:
			case TextAlignmentType.Distributed:
			case TextAlignmentType.Justify:
			case TextAlignmentType.Top:
				textAlignmentType_1 = value;
				break;
			}
		}
	}

	internal string Text
	{
		get
		{
			return string_0;
		}
		set
		{
			method_15();
			string_0 = value;
			arrayList_0 = null;
		}
	}

	internal string HtmlString
	{
		get
		{
			return Class1385.smethod_2(this);
		}
		set
		{
			method_15();
			if (shape_0 != null)
			{
				Shape shape = shape_0;
				Class1385.smethod_7(shape, this, value);
			}
		}
	}

	internal Font Font
	{
		get
		{
			if (font_0 == null)
			{
				font_0 = new Font(method_2(), null, bool_0: true);
				if (shape_0 != null && shape_0.MsoDrawingType == MsoDrawingType.Comment)
				{
					font_0.method_14("Tahoma", Enum193.const_0);
					font_0.Size = 8;
					font_0.IsBold = true;
				}
			}
			return font_0;
		}
		set
		{
			method_15();
			font_0 = value;
		}
	}

	[SpecialName]
	internal int method_0()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_1(int int_2)
	{
		int_0 = int_2;
	}

	[SpecialName]
	private WorksheetCollection method_2()
	{
		return shape_0.method_25();
	}

	internal Class1363 method_3()
	{
		if (class1363_0 == null)
		{
			class1363_0 = new Class1363();
		}
		return class1363_0;
	}

	internal Class1737(Shape shape_1)
	{
		shape_0 = shape_1;
	}

	internal void Copy(Class1737 class1737_0)
	{
		textOverflowType_0 = class1737_0.textOverflowType_0;
		textOverflowType_1 = class1737_0.textOverflowType_1;
		string_0 = class1737_0.string_0;
		font_0 = class1737_0.font_0;
		textAlignmentType_0 = class1737_0.textAlignmentType_0;
		textAlignmentType_1 = class1737_0.textAlignmentType_1;
		bool_0 = class1737_0.bool_0;
		textOrientationType_0 = class1737_0.textOrientationType_0;
		int_1 = class1737_0.int_1;
		int_0 = class1737_0.int_0;
		if (class1737_0.arrayList_0 == null || class1737_0.arrayList_0.Count == 0)
		{
			return;
		}
		foreach (FontSetting item in class1737_0.arrayList_0)
		{
			FontSetting fontSetting2 = Characters(item.StartIndex, item.Length);
			fontSetting2.Copy(item);
		}
	}

	internal void method_4(string string_1)
	{
		method_15();
		string_0 = string_1;
	}

	internal Font method_5()
	{
		return font_0;
	}

	[SpecialName]
	internal bool method_6()
	{
		return bool_0;
	}

	[SpecialName]
	internal void method_7(bool bool_2)
	{
		method_15();
		bool_0 = bool_2;
	}

	[SpecialName]
	internal int method_8()
	{
		if (font_0 != null)
		{
			return font_0.method_21();
		}
		return int_1;
	}

	[SpecialName]
	internal void method_9(int int_2)
	{
		method_15();
		int_1 = int_2;
	}

	internal void method_10(int int_2)
	{
		int_1 = int_2;
	}

	internal FontSetting Characters(int int_2, int int_3)
	{
		if (arrayList_0 == null)
		{
			arrayList_0 = new ArrayList();
		}
		int num = 0;
		FontSetting fontSetting;
		while (true)
		{
			if (num < arrayList_0.Count)
			{
				fontSetting = (FontSetting)arrayList_0[num];
				if (fontSetting.Length == int_3 && fontSetting.StartIndex == int_2)
				{
					break;
				}
				num++;
				continue;
			}
			fontSetting = new FontSetting(int_2, int_3, method_2(), bool_1: true);
			if (font_0 != null)
			{
				fontSetting.Font.Copy(font_0);
				fontSetting.Font.method_25();
			}
			arrayList_0.Add(fontSetting);
			return fontSetting;
		}
		return fontSetting;
	}

	internal void method_11()
	{
		FontSetting fontSetting = null;
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			fontSetting = (FontSetting)arrayList_0[i];
			bool flag = false;
			for (int j = i + 1; j < arrayList_0.Count; j++)
			{
				FontSetting fontSetting2 = (FontSetting)arrayList_0[j];
				if (fontSetting.StartIndex <= fontSetting2.StartIndex)
				{
					if (fontSetting.StartIndex + fontSetting.Length <= fontSetting2.StartIndex)
					{
						continue;
					}
					if (fontSetting.Font.Equals(fontSetting2.Font))
					{
						if (fontSetting.StartIndex + fontSetting.Length < fontSetting2.StartIndex + fontSetting2.Length)
						{
							fontSetting.method_1(fontSetting2.StartIndex + fontSetting2.Length - fontSetting.Length);
						}
						arrayList_0.RemoveAt(j--);
						continue;
					}
					int num = fontSetting.StartIndex + fontSetting.Length;
					int num2 = fontSetting2.StartIndex + fontSetting2.Length;
					if (fontSetting2.StartIndex == fontSetting.StartIndex)
					{
						if (!flag)
						{
							arrayList_0.RemoveAt(i);
							i--;
							j--;
							flag = true;
						}
					}
					else
					{
						fontSetting.method_1(fontSetting2.StartIndex - fontSetting.StartIndex);
					}
					Font font = new Font(fontSetting.worksheetCollection_0, null, bool_0: true);
					font.Copy(fontSetting.Font);
					font.method_26(fontSetting2.Font);
					Font font2 = fontSetting2.Font;
					if (num > num2)
					{
						int num3 = num;
						num = num2;
						num2 = num3;
						font2 = fontSetting.Font;
					}
					fontSetting2.method_1(num - fontSetting2.StartIndex);
					fontSetting2.method_3(font);
					if (num2 != num)
					{
						FontSetting fontSetting3 = new FontSetting(num, num2 - num, fontSetting.worksheetCollection_0, bool_1: true);
						fontSetting3.method_3(font2);
						arrayList_0.Insert(j + 1, fontSetting3);
						j++;
					}
				}
				else if (fontSetting2.StartIndex + fontSetting2.Length > fontSetting.StartIndex)
				{
					int num4 = fontSetting.StartIndex + fontSetting.Length;
					int num5 = fontSetting2.StartIndex + fontSetting2.Length;
					fontSetting2.method_1(fontSetting2.StartIndex - fontSetting.StartIndex);
					Font font3 = fontSetting.Font;
					Font font4 = new Font(fontSetting.worksheetCollection_0, null, bool_0: true);
					font4.Copy(fontSetting.Font);
					font4.method_26(fontSetting2.Font);
					fontSetting.method_3(font4);
					if (num4 > num5)
					{
						int num6 = num5;
						num5 = num4;
						num4 = num6;
						font3 = fontSetting2.Font;
					}
					fontSetting.method_1(num4 - fontSetting.StartIndex);
					if (num4 != num5)
					{
						FontSetting fontSetting4 = new FontSetting(num4, num5 - num4, fontSetting.worksheetCollection_0, bool_1: true);
						fontSetting4.method_3(font3);
						arrayList_0.Insert(j + 1, fontSetting4);
						j++;
					}
				}
			}
		}
	}

	[SpecialName]
	internal ArrayList method_12()
	{
		return arrayList_0;
	}

	[SpecialName]
	internal void method_13(ArrayList arrayList_1)
	{
		method_15();
		arrayList_0 = arrayList_1;
	}

	[SpecialName]
	internal bool method_14()
	{
		if (method_12() != null && method_12().Count > 0)
		{
			return true;
		}
		return false;
	}

	internal ArrayList GetCharacters()
	{
		if (method_14())
		{
			bool flag = false;
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				flag = false;
				for (int num = arrayList_0.Count - 2; num >= i; num--)
				{
					FontSetting fontSetting = (FontSetting)arrayList_0[num + 1];
					FontSetting fontSetting2 = (FontSetting)arrayList_0[num];
					if (fontSetting.StartIndex < fontSetting2.StartIndex)
					{
						arrayList_0[num + 1] = fontSetting2;
						arrayList_0[num] = fontSetting;
						flag = true;
					}
				}
				if (!flag)
				{
					break;
				}
			}
			ArrayList arrayList = new ArrayList();
			int num2 = 0;
			Font font = Font;
			for (int j = 0; j < arrayList_0.Count; j++)
			{
				FontSetting fontSetting3 = (FontSetting)arrayList_0[j];
				if (fontSetting3.StartIndex != num2)
				{
					FontSetting fontSetting4 = new FontSetting(num2, fontSetting3.StartIndex - num2, method_2(), bool_1: true);
					fontSetting4.Font.Copy(font);
					arrayList.Add(fontSetting4);
				}
				arrayList.Add(fontSetting3);
				num2 = fontSetting3.StartIndex + fontSetting3.Length;
			}
			string text = Text;
			if (num2 < text.Length)
			{
				FontSetting fontSetting5 = new FontSetting(num2, text.Length - num2, method_2(), bool_1: true);
				fontSetting5.Font.Copy(font);
				arrayList.Add(fontSetting5);
			}
			return arrayList;
		}
		return null;
	}

	internal void method_15()
	{
		if (shape_0 != null)
		{
			shape_0.method_62(Enum169.const_7);
		}
	}
}
