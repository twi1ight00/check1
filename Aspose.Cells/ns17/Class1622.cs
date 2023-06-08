using System;
using System.Collections;
using System.Globalization;
using Aspose.Cells;

namespace ns17;

internal class Class1622
{
	private PageSetup pageSetup_0;

	private Workbook workbook_0;

	private Worksheet worksheet_0;

	private Hashtable hashtable_0;

	private double double_0;

	private bool bool_0;

	internal Class1624 class1624_0;

	private Class1092 class1092_0;

	private Class1087 class1087_0;

	internal Class1622(Workbook workbook_1, Class1624 class1624_1)
	{
		workbook_0 = workbook_1;
		hashtable_0 = new Hashtable();
		class1624_0 = class1624_1;
	}

	internal void Write(Worksheet worksheet_1, int int_0, int int_1, Class1623 class1623_0)
	{
		worksheet_0 = worksheet_1;
		pageSetup_0 = worksheet_0.PageSetup;
		if (worksheet_1.Type == SheetType.Chart)
		{
			pageSetup_0 = worksheet_0.Charts[0].PageSetup;
		}
		bool_0 = true;
		method_0(int_0, int_1, class1623_0);
		bool_0 = false;
		method_0(int_0, int_1, class1623_0);
	}

	private void method_0(int int_0, int int_1, Class1623 class1623_0)
	{
		string text = "";
		string text2 = "";
		string text3 = "";
		string[] string_ = null;
		string[] string_2 = null;
		int num = 0;
		if (pageSetup_0.IsHFDiffFirst && int_0 == 1)
		{
			if (bool_0)
			{
				text = pageSetup_0.method_26(0);
				text2 = pageSetup_0.method_26(1);
				text3 = pageSetup_0.method_26(2);
			}
			else
			{
				text = pageSetup_0.method_25(0);
				text2 = pageSetup_0.method_25(1);
				text3 = pageSetup_0.method_25(2);
			}
		}
		else if (pageSetup_0.IsHFDiffOddEven && int_0 % 2 == 0)
		{
			if (bool_0)
			{
				text = pageSetup_0.method_23(0);
				text2 = pageSetup_0.method_23(1);
				text3 = pageSetup_0.method_23(2);
			}
			else
			{
				text = pageSetup_0.method_24(0);
				text2 = pageSetup_0.method_24(1);
				text3 = pageSetup_0.method_24(2);
			}
		}
		else if (bool_0)
		{
			text = pageSetup_0.method_19(0);
			text2 = pageSetup_0.method_19(1);
			text3 = pageSetup_0.method_19(2);
		}
		else
		{
			text = pageSetup_0.method_20(0);
			text2 = pageSetup_0.method_20(1);
			text3 = pageSetup_0.method_20(2);
		}
		if (text != null)
		{
			if (text.Length >= 2 && text.Length == 0)
			{
				text = null;
			}
			if (text != null)
			{
				num++;
			}
		}
		if (text2 != null)
		{
			if (text2.Length >= 2 && text2.Length == 0)
			{
				text2 = null;
			}
			if (text2 != null)
			{
				num++;
			}
		}
		if (text3 != null && text3.Length >= 2)
		{
			if (text3.Length >= 2 && text3.Length == 0)
			{
				text3 = null;
			}
			if (text3 != null)
			{
				num++;
			}
		}
		switch (num)
		{
		case 1:
		{
			string[] string_4 = null;
			if (text != null)
			{
				string_4 = new string[1] { text };
				string_ = new string[1] { "Left" };
			}
			if (text2 != null)
			{
				string_4 = new string[1] { text2 };
				string_ = new string[1] { "Center" };
			}
			if (text3 != null)
			{
				string_4 = new string[1] { text3 };
				string_ = new string[1] { "Right" };
			}
			string_2 = new string[1] { double_0.ToString(NumberFormatInfo.InvariantInfo) };
			method_1(string_4, string_, string_2, int_0, int_1, class1623_0);
			return;
		}
		case 2:
			if (text != null && text3 != null)
			{
				string[] string_3 = new string[2] { text, text3 };
				string_ = new string[2] { "Left", "Right" };
				double num2 = Math.Round(double_0 / 2.0, 2);
				string_2 = new string[2]
				{
					num2.ToString(NumberFormatInfo.InvariantInfo),
					num2.ToString(NumberFormatInfo.InvariantInfo)
				};
				method_1(string_3, string_, string_2, int_0, int_1, class1623_0);
				return;
			}
			break;
		case 0:
			return;
		}
		string_ = new string[3] { "Left", "Center", "Right" };
		string[] string_5 = new string[3] { text, text2, text3 };
		method_1(string_5, string_, string_2, int_0, int_1, class1623_0);
	}

	private void method_1(string[] string_0, string[] string_1, string[] string_2, int int_0, int int_1, Class1623 class1623_0)
	{
		int num = 0;
		while (true)
		{
			if (num >= string_0.Length)
			{
				return;
			}
			string string_3 = string_0[num];
			string text = string_1[num];
			class1092_0 = new Class1092(textAlignmentType_3: bool_0 ? TextAlignmentType.Top : TextAlignmentType.Bottom, class454_1: class1624_0.class454_1, class1623_1: class1623_0, pageSetup_0: pageSetup_0, textAlignmentType_2: text switch
			{
				"Right" => TextAlignmentType.Right, 
				"Center" => TextAlignmentType.Center, 
				"Left" => TextAlignmentType.Left, 
				_ => TextAlignmentType.Center, 
			}, workbook_1: workbook_0);
			if (string_3 != null)
			{
				if (num == 1 && string_2 == null)
				{
					class1087_0 = new Class1087(class1092_0, workbook_0.Worksheets[class1623_0.int_0], hashtable_0, int_0, int_1);
					if (class1087_0.method_1(ref string_3) == Enum170.const_1)
					{
						throw new CellsException(ExceptionType.UnsupportedFeature, "Such header or footer is not supported yet!");
					}
				}
				else
				{
					class1087_0 = new Class1087(class1092_0, workbook_0.Worksheets[class1623_0.int_0], hashtable_0, int_0, int_1);
					if (class1087_0.method_1(ref string_3) == Enum170.const_1)
					{
						break;
					}
				}
			}
			class1092_0.method_4();
			num++;
		}
		throw new CellsException(ExceptionType.UnsupportedFeature, "Such header or footer is not supported yet!");
	}
}
