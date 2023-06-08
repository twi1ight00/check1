using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;
using Aspose.Cells;
using Aspose.Cells.Charts;
using ns2;

namespace ns16;

internal class Class1570
{
	internal int int_0 = -1;

	internal bool bool_0 = true;

	internal bool bool_1 = true;

	private TextAlignmentType textAlignmentType_0 = TextAlignmentType.Top;

	private TextAlignmentType textAlignmentType_1 = TextAlignmentType.Left;

	internal Class1542 class1542_0;

	internal bool bool_2;

	internal ArrayList arrayList_0;

	internal TextDirectionType textDirectionType_0 = TextDirectionType.LeftToRight;

	internal string string_0;

	internal string string_1;

	internal string Text
	{
		set
		{
			if (value != null)
			{
				Class1565 @class = new Class1565();
				@class.string_0 = value;
				arrayList_0 = new ArrayList();
				arrayList_0.Add(@class);
			}
		}
	}

	[SpecialName]
	public TextAlignmentType method_0()
	{
		return textAlignmentType_0;
	}

	[SpecialName]
	public void method_1(TextAlignmentType textAlignmentType_2)
	{
		textAlignmentType_0 = textAlignmentType_2;
		bool_0 = false;
	}

	[SpecialName]
	public TextAlignmentType method_2()
	{
		return textAlignmentType_1;
	}

	[SpecialName]
	public void method_3(TextAlignmentType textAlignmentType_2)
	{
		textAlignmentType_1 = textAlignmentType_2;
		bool_1 = false;
	}

	internal void method_4(string string_2, string string_3)
	{
		string_1 = string_2;
		if (string_3 != null)
		{
			if (string_3[0] == '{')
			{
				string_3 = string_3.Substring(1);
			}
			int length = string_3.Length;
			if (length > 0 && string_3[length - 1] == '}')
			{
				string_3 = string_3.Substring(0, length - 1);
			}
			Text = string_3;
		}
	}

	internal void method_5(Chart chart_0, bool bool_3)
	{
		if (chart_0 != null)
		{
			Class1542 @class = chart_0.class1549_0.class1542_0;
			if (@class != null)
			{
				double double_ = (bool_3 ? 1.2 : 1.0);
				class1542_0.method_17(@class, double_);
			}
		}
	}

	internal void method_6(Class1542 class1542_1, Title title_0, WorksheetCollection worksheetCollection_0, bool bool_3)
	{
		if (class1542_0 == null)
		{
			class1542_0 = class1542_1;
		}
		else if (class1542_0 != null)
		{
			method_5(title_0.Chart, bool_3);
		}
		if (int_0 != -1)
		{
			title_0.RotationAngle = int_0;
		}
		if (!bool_0)
		{
			title_0.TextVerticalAlignment = method_0();
		}
		if (!bool_1)
		{
			title_0.TextHorizontalAlignment = method_2();
		}
		if (arrayList_0 != null && arrayList_0.Count > 0)
		{
			if (arrayList_0.Count == 1)
			{
				Class1565 @class = (Class1565)arrayList_0[0];
				Class1542 class2 = @class.class1542_0;
				if (class2 == null)
				{
					class2 = class1542_0;
				}
				else
				{
					class2.method_17(class1542_0, 1.0);
				}
				Font font = title_0.Font;
				class2?.method_20(font);
				title_0.method_41(@class.string_0);
			}
			else
			{
				title_0.method_40(new ArrayList());
				StringBuilder stringBuilder = new StringBuilder();
				int num = 0;
				for (int i = 0; i < arrayList_0.Count; i++)
				{
					Class1565 class3 = (Class1565)arrayList_0[i];
					if (class3.string_0 != null)
					{
						int length = class3.string_0.Length;
						FontSetting fontSetting = new FontSetting(num, length, worksheetCollection_0, bool_1: true);
						Class1542 class4 = class3.class1542_0;
						if (class4 == null)
						{
							class4 = class1542_0;
						}
						else
						{
							class3.class1542_0.method_17(class1542_0, 1.0);
						}
						Font font2 = new Font(worksheetCollection_0, null, bool_0: true);
						Title.smethod_0(title_0.Chart, font2, bool_3);
						class4?.method_19(font2);
						fontSetting.method_3(font2);
						num += length;
						stringBuilder.Append(class3.string_0);
						title_0.method_39().Add(fontSetting);
					}
				}
				title_0.method_41(stringBuilder.ToString());
			}
		}
		if (string_1 != null)
		{
			title_0.LinkedSource = string_1;
		}
		title_0.TextDirection = textDirectionType_0;
	}

	internal void method_7(Title title_0, WorksheetCollection worksheetCollection_0, bool bool_3)
	{
		if (class1542_0 == null)
		{
			class1542_0 = new Class1542();
		}
		method_5(title_0.Chart, bool_3);
		if (bool_3 && !class1542_0.class1543_0.method_0(Enum216.const_12))
		{
			class1542_0.method_16(360);
		}
		if (!class1542_0.class1543_0.method_0(Enum216.const_2))
		{
			class1542_0.IsBold = true;
		}
		if (title_0.method_12() != null)
		{
			class1542_0.method_19(title_0.Font);
		}
		else
		{
			title_0.method_14(Class1618.smethod_119(class1542_0, worksheetCollection_0));
		}
		if (int_0 != -1)
		{
			title_0.RotationAngle = int_0;
		}
		if (!bool_0)
		{
			title_0.TextVerticalAlignment = method_0();
		}
		if (!bool_1)
		{
			title_0.TextHorizontalAlignment = method_2();
		}
		if (arrayList_0 != null && arrayList_0.Count > 0)
		{
			if (arrayList_0.Count == 1)
			{
				Class1565 @class = (Class1565)arrayList_0[0];
				Class1542 class2 = @class.class1542_0;
				if (class2 == null)
				{
					class2 = class1542_0;
				}
				class2?.method_19(title_0.Font);
				title_0.method_41(@class.string_0);
			}
			else
			{
				title_0.method_40(new ArrayList());
				StringBuilder stringBuilder = new StringBuilder();
				int num = 0;
				for (int i = 0; i < arrayList_0.Count; i++)
				{
					Class1565 class3 = (Class1565)arrayList_0[i];
					if (class3.string_0 != null)
					{
						int length = class3.string_0.Length;
						FontSetting fontSetting = new FontSetting(num, length, worksheetCollection_0, bool_1: true);
						if (class3.class1542_0 != null)
						{
							class3.class1542_0.method_17(class1542_0, 1.0);
							Font font = new Font(worksheetCollection_0, null, bool_0: true);
							class3.class1542_0.method_19(font);
							fontSetting.method_3(font);
						}
						else
						{
							class1542_0.method_19(fontSetting.Font);
						}
						num += length;
						stringBuilder.Append(class3.string_0);
						title_0.method_39().Add(fontSetting);
					}
				}
				title_0.method_41(stringBuilder.ToString());
			}
		}
		if (string_1 != null)
		{
			title_0.LinkedSource = string_1;
		}
		title_0.TextDirection = textDirectionType_0;
	}

	internal void method_8(DataLabels dataLabels_0, WorksheetCollection worksheetCollection_0)
	{
		if (string_1 != null && string_1 != "")
		{
			dataLabels_0.LinkedSource = string_1;
		}
		if (class1542_0 == null)
		{
			if (dataLabels_0.method_60() != null && dataLabels_0.method_60() is ChartPoint)
			{
				if (arrayList_0 == null)
				{
					return;
				}
				if (arrayList_0.Count == 1)
				{
					Class1565 @class = (Class1565)arrayList_0[0];
					if (@class.string_0 == null)
					{
						return;
					}
					dataLabels_0.method_42(@class.string_0);
					dataLabels_0.IsAutoText = false;
					Class1542 class2 = @class.class1542_0;
					if (class2 != null)
					{
						if (dataLabels_0.method_12() != null)
						{
							class2.method_19(dataLabels_0.Font);
						}
						else
						{
							dataLabels_0.method_14(Class1618.smethod_119(class2, worksheetCollection_0));
						}
					}
					return;
				}
				dataLabels_0.method_40(new ArrayList());
				StringBuilder stringBuilder = new StringBuilder();
				int num = 0;
				for (int i = 0; i < arrayList_0.Count; i++)
				{
					Class1565 class3 = (Class1565)arrayList_0[i];
					if (class3.string_0 != null)
					{
						int length = class3.string_0.Length;
						FontSetting fontSetting = new FontSetting(num, length, worksheetCollection_0, bool_1: true);
						if (class3.class1542_0 != null)
						{
							Font font = new Font(worksheetCollection_0, null, bool_0: true);
							class3.class1542_0.method_19(font);
							fontSetting.method_3(font);
						}
						num += length;
						stringBuilder.Append(class3.string_0);
						dataLabels_0.method_39().Add(fontSetting);
					}
				}
				if (stringBuilder.Length > 0)
				{
					dataLabels_0.IsAutoText = false;
				}
				dataLabels_0.method_42(stringBuilder.ToString());
				return;
			}
			class1542_0 = new Class1542();
		}
		method_5(dataLabels_0.Chart, bool_3: false);
		if (int_0 != -1)
		{
			dataLabels_0.RotationAngle = int_0;
		}
		if (!bool_0)
		{
			dataLabels_0.TextVerticalAlignment = method_0();
		}
		if (!bool_1)
		{
			dataLabels_0.TextHorizontalAlignment = method_2();
		}
		if (arrayList_0 == null)
		{
			if (dataLabels_0.method_12() != null)
			{
				class1542_0.method_19(dataLabels_0.Font);
			}
			else
			{
				dataLabels_0.method_14(Class1618.smethod_119(class1542_0, worksheetCollection_0));
			}
		}
		else if (arrayList_0.Count == 1)
		{
			Class1565 class4 = (Class1565)arrayList_0[0];
			if (class4.string_0 != null)
			{
				dataLabels_0.method_42(class4.string_0);
				Class1542 class5 = class4.class1542_0;
				if (class4.class1542_0 == null)
				{
					class5 = class1542_0;
				}
				if (class5 != null)
				{
					if (dataLabels_0.method_12() != null)
					{
						class5.method_19(dataLabels_0.Font);
					}
					else
					{
						dataLabels_0.method_14(Class1618.smethod_119(class5, worksheetCollection_0));
					}
				}
			}
		}
		else
		{
			if (dataLabels_0.method_12() != null)
			{
				class1542_0.method_19(dataLabels_0.Font);
			}
			else
			{
				dataLabels_0.method_14(Class1618.smethod_119(class1542_0, worksheetCollection_0));
			}
			dataLabels_0.method_40(new ArrayList());
			StringBuilder stringBuilder2 = new StringBuilder();
			int num2 = 0;
			for (int j = 0; j < arrayList_0.Count; j++)
			{
				Class1565 class6 = (Class1565)arrayList_0[j];
				if (class6.string_0 != null)
				{
					int length2 = class6.string_0.Length;
					FontSetting fontSetting2 = new FontSetting(num2, length2, worksheetCollection_0, bool_1: true);
					if (class6.class1542_0 != null)
					{
						class6.class1542_0.method_17(class1542_0, 1.0);
						Font font2 = new Font(worksheetCollection_0, null, bool_0: true);
						class6.class1542_0.method_19(font2);
						fontSetting2.method_3(font2);
					}
					else
					{
						class1542_0.method_19(fontSetting2.Font);
					}
					num2 += length2;
					stringBuilder2.Append(class6.string_0);
					dataLabels_0.method_39().Add(fontSetting2);
				}
			}
			dataLabels_0.method_42(stringBuilder2.ToString());
		}
		dataLabels_0.TextDirection = textDirectionType_0;
	}

	internal void method_9(TickLabels tickLabels_0, Chart chart_0, WorksheetCollection worksheetCollection_0)
	{
		if (int_0 != -1)
		{
			tickLabels_0.method_4(int_0);
		}
		if (class1542_0 != null)
		{
			method_5(chart_0, bool_3: false);
			tickLabels_0.method_2(Class1618.smethod_119(class1542_0, worksheetCollection_0));
		}
		tickLabels_0.TextDirection = textDirectionType_0;
	}

	internal void method_10(Class1737 class1737_0, WorksheetCollection worksheetCollection_0)
	{
		class1737_0.TextHorizontalAlignment = method_2();
		if (class1542_0 != null)
		{
			class1737_0.method_9(Class1618.smethod_119(class1542_0, worksheetCollection_0));
		}
		if (arrayList_0 != null)
		{
			if (class1737_0.method_12() == null)
			{
				class1737_0.method_13(new ArrayList());
			}
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			if (class1737_0.Text != null)
			{
				num = class1737_0.Text.Length;
			}
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				Class1565 @class = (Class1565)arrayList_0[i];
				if (@class.string_0 == null)
				{
					continue;
				}
				int length = @class.string_0.Length;
				FontSetting fontSetting = new FontSetting(num, length, worksheetCollection_0, bool_1: true);
				Font font = null;
				if (@class.class1542_0 != null)
				{
					if (@class.class1542_0.Name == null && class1737_0.Font.method_0() != null)
					{
						Workbook workbook = worksheetCollection_0.Workbook;
						if (workbook.Settings.Region != 0)
						{
							bool flag = true;
							if (class1737_0.Font.method_0().ToLower() == "minor")
							{
								flag = false;
							}
							string text = workbook.class1569_0.class1193_0.method_1(workbook.Settings.Region, flag);
							if (text != null)
							{
								@class.class1542_0.Name = text;
							}
						}
						else
						{
							bool flag2 = true;
							if (class1737_0.Font.method_0().ToLower() == "minor")
							{
								flag2 = false;
							}
							string text2 = workbook.class1569_0.class1193_0.method_6(@class.class1542_0.method_4(), @class.class1542_0.method_6(), flag2);
							if (text2 != null)
							{
								@class.class1542_0.Name = text2;
							}
						}
					}
					if (@class.class1542_0.method_10() != null && @class.class1542_0.method_10().method_2())
					{
						@class.class1542_0.method_11(class1737_0.Font.InternalColor);
					}
					@class.class1542_0.method_17(class1542_0, 1.0);
					font = new Font(worksheetCollection_0, null, bool_0: true);
					@class.class1542_0.method_19(font);
					fontSetting.method_3(font);
				}
				else if (class1542_0 != null)
				{
					class1542_0.method_19(fontSetting.Font);
				}
				num += length;
				stringBuilder.Append(@class.string_0);
				class1737_0.method_12().Add(fontSetting);
				if (class1542_0 == null && i == 0 && font != null)
				{
					class1737_0.method_9(Class1618.smethod_118(font, worksheetCollection_0));
				}
			}
			if (class1737_0.Text != null)
			{
				class1737_0.method_4(class1737_0.Text + stringBuilder.ToString());
			}
			else
			{
				class1737_0.method_4(stringBuilder.ToString());
			}
		}
		if (string_0 != null)
		{
			class1737_0.method_3().Add(Enum129.const_0, string_0);
		}
	}

	internal void method_11(DisplayUnitLabel displayUnitLabel_0, WorksheetCollection worksheetCollection_0)
	{
		if (string_1 != null)
		{
			displayUnitLabel_0.method_40(string_1);
		}
		if (class1542_0 == null)
		{
			class1542_0 = new Class1542();
		}
		method_5(displayUnitLabel_0.Chart, bool_3: false);
		if (int_0 != -1)
		{
			displayUnitLabel_0.RotationAngle = int_0;
		}
		if (!bool_0)
		{
			displayUnitLabel_0.TextVerticalAlignment = method_0();
		}
		if (!bool_1)
		{
			displayUnitLabel_0.TextHorizontalAlignment = method_2();
		}
		if (arrayList_0 == null)
		{
			if (displayUnitLabel_0.method_12() != null)
			{
				class1542_0.method_19(displayUnitLabel_0.Font);
			}
			else
			{
				displayUnitLabel_0.method_14(Class1618.smethod_119(class1542_0, worksheetCollection_0));
			}
		}
		else
		{
			Class1565 @class = (Class1565)arrayList_0[0];
			if (@class.string_0 != null)
			{
				displayUnitLabel_0.Text = @class.string_0;
				Class1542 class2 = @class.class1542_0;
				if (@class.class1542_0 == null)
				{
					class2 = class1542_0;
				}
				if (class2 != null)
				{
					if (displayUnitLabel_0.method_12() != null)
					{
						class2.method_19(displayUnitLabel_0.Font);
					}
					else
					{
						displayUnitLabel_0.method_14(Class1618.smethod_119(class2, worksheetCollection_0));
					}
				}
			}
		}
		displayUnitLabel_0.TextDirection = textDirectionType_0;
	}
}
