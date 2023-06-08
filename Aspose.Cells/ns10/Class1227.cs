using System;
using System.Collections;
using Aspose.Cells;
using ns16;
using ns2;
using ns25;

namespace ns10;

internal class Class1227
{
	private Workbook workbook_0;

	private Class1218 class1218_0;

	private Class1212 class1212_0;

	private Worksheet worksheet_0;

	private Class1548 class1548_0;

	private Class1547 class1547_0;

	private int int_0;

	private byte[] byte_0;

	private int int_1;

	private bool bool_0;

	private bool bool_1;

	private Cells cells_0;

	internal Class1227(Class1218 class1218_1)
	{
		class1218_0 = class1218_1;
		workbook_0 = class1218_1.workbook_0;
		class1547_0 = class1218_1.class1547_0;
	}

	internal void Read(Class1548 class1548_1, Class1212 class1212_1)
	{
		class1548_0 = class1548_1;
		worksheet_0 = class1548_1.worksheet_0;
		cells_0 = worksheet_0.Cells;
		class1212_0 = class1212_1;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 494:
				method_18();
				break;
			case 485:
				method_32();
				break;
			case 550:
				byte_0 = class1218_0.method_0(class1212_0);
				class1548_1.string_4 = Class1217.smethod_8(byte_0, 0);
				if (class1548_1.string_4 != null)
				{
					string text = class1548_1.method_3(class1548_1.string_4);
					worksheet_0.class1557_0.string_1 = "xl" + text.Substring(2);
					break;
				}
				throw new CellsException(ExceptionType.InvalidData, "Invalid DrawingRid element");
			case 551:
				byte_0 = class1218_0.method_0(class1212_0);
				class1548_1.string_2 = Class1217.smethod_8(byte_0, 0);
				if (class1548_1.string_2 != null)
				{
					string text = class1548_1.method_3(class1548_1.string_2);
					if (text[0] == '/')
					{
						worksheet_0.class1557_0.string_2 = "xl" + text.Substring(3);
					}
					else
					{
						worksheet_0.class1557_0.string_2 = "xl" + text.Substring(2);
					}
					break;
				}
				throw new CellsException(ExceptionType.InvalidData, "Invalid legacyDrawing element");
			case 552:
				byte_0 = class1218_0.method_0(class1212_0);
				class1548_1.string_3 = Class1217.smethod_8(byte_0, 0);
				break;
			case 535:
				method_23();
				break;
			case 573:
				method_14();
				break;
			case 562:
				byte_0 = class1218_0.method_0(class1212_0);
				class1548_1.string_5 = Class1217.smethod_8(byte_0, 0);
				break;
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 1054:
				method_15();
				break;
			case 644:
				method_1();
				break;
			case 639:
				method_0();
				break;
			case 60:
				method_29();
				break;
			case 145:
				method_24();
				break;
			case 147:
				method_30();
				break;
			case 133:
				method_31();
				break;
			case 177:
				method_22();
				break;
			case 161:
				method_5();
				break;
			case 476:
				method_21();
				break;
			case 477:
				method_20();
				break;
			case 478:
				method_19();
				break;
			case 479:
				method_17();
				break;
			case 461:
				method_9();
				break;
			case 392:
				method_2();
				break;
			case 394:
				method_3();
				break;
			case 130:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_0()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		Class1552 @class = new Class1552();
		int num = 14;
		@class.string_6 = Class1618.smethod_80(BitConverter.ToInt32(byte_0, 0));
		@class.bool_1 = (byte_0[4] & 1) == 1;
		@class.string_1 = Class1618.smethod_80(BitConverter.ToInt32(byte_0, 8));
		@class.bool_0 = (byte_0[12] & 1) == 1;
		@class.string_0 = Class1217.smethod_5(byte_0, ref num);
		if (@class.bool_0)
		{
			int num2 = BitConverter.ToInt32(byte_0, num);
			@class.byte_0 = new byte[num2 + 8];
			Array.Copy(byte_0, num, @class.byte_0, 0, @class.byte_0.Length);
		}
		else
		{
			string string_ = Class1217.smethod_5(byte_0, ref num);
			Class1564 class2 = class1548_0.method_4(string_);
			if (class2 != null)
			{
				@class.string_2 = class2.string_3;
				@class.string_3 = class2.string_2;
			}
		}
		class1548_0.arrayList_1.Add(@class);
	}

	private void method_1()
	{
		Class1550 @class = new Class1550();
		byte_0 = class1218_0.method_0(class1212_0);
		int num = 4;
		@class.string_0 = Class1618.smethod_80(BitConverter.ToInt32(byte_0, 0));
		@class.string_4 = Class1217.smethod_5(byte_0, ref num);
		@class.string_2 = class1548_0.method_3(@class.string_4);
		@class.string_1 = Class1217.smethod_5(byte_0, ref num);
		worksheet_0.class1557_0.arrayList_2.Add(@class);
	}

	private void method_2()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		BitConverter.ToInt32(byte_0, 0);
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 396:
				method_4(bool_2: false);
				break;
			case 393:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_3()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		BitConverter.ToInt32(byte_0, 0);
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 396:
				method_4(bool_2: true);
				break;
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 395:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_4(bool bool_2)
	{
		byte_0 = class1218_0.method_0(class1212_0);
		int int_ = BitConverter.ToInt32(byte_0, 0);
		int num = BitConverter.ToInt32(byte_0, 4);
		int num2 = BitConverter.ToInt32(byte_0, 8);
		if (num2 < num)
		{
			int num3 = num;
			num = num2;
			num2 = num3;
		}
		if (bool_2)
		{
			VerticalPageBreakCollection vPageBreaks = cells_0.VPageBreaks;
			vPageBreaks.method_0(num, num2, int_);
		}
		else
		{
			HorizontalPageBreakCollection hPageBreaks = cells_0.HPageBreaks;
			hPageBreaks.method_0(int_, num, num2);
		}
	}

	private void method_5()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		AutoFilter autoFilter = worksheet_0.AutoFilter;
		Name name = workbook_0.Worksheets.Names["_FILTERDATABASE", worksheet_0.Index];
		if (name != null)
		{
			autoFilter.method_3(name);
		}
		int row = BitConverter.ToInt32(byte_0, 0);
		BitConverter.ToInt32(byte_0, 4);
		int startColumn = BitConverter.ToInt32(byte_0, 8);
		int endColumn = BitConverter.ToInt32(byte_0, 12);
		autoFilter.SetRange(row, startColumn, endColumn);
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 163:
				method_6(autoFilter);
				break;
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 162:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_6(AutoFilter autoFilter_0)
	{
		byte_0 = class1218_0.method_0(class1212_0);
		int num = BitConverter.ToInt32(byte_0, 0);
		bool bool_ = (byte_0[4] & 1) == 1;
		bool bool_2 = (((byte_0[4] & 2) == 0) ? true : false);
		FilterColumn filterColumn = null;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 172:
			{
				filterColumn = new FilterColumn(autoFilter_0.method_5(), num, bool_, bool_2);
				filterColumn.FilterType = FilterType.CustomFilters;
				CustomFilterCollection customFilterCollection_ = (CustomFilterCollection)(filterColumn.Filter = new CustomFilterCollection());
				method_7(customFilterCollection_);
				break;
			}
			case 171:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				filterColumn = new FilterColumn(autoFilter_0.method_5(), num, bool_, bool_2);
				filterColumn.FilterType = FilterType.DynamicFilter;
				DynamicFilter dynamicFilter2 = (DynamicFilter)(filterColumn.Filter = new DynamicFilter());
				int num2 = BitConverter.ToInt32(byte_0, 0);
				dynamicFilter2.DynamicFilterType = Class1224.smethod_17(num2);
				bool flag = byte_0[4] == 1;
				double num3 = BitConverter.ToDouble(byte_0, 5);
				double num4 = BitConverter.ToDouble(byte_0, 13);
				if (flag)
				{
					dynamicFilter2.MaxValue = num4;
				}
				dynamicFilter2.Value = num3;
				break;
			}
			case 170:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				filterColumn = new FilterColumn(autoFilter_0.method_5(), num, bool_, bool_2);
				filterColumn.FilterType = FilterType.Top10;
				bool bool_3 = ((((uint)byte_0[0] & (true ? 1u : 0u)) != 0) ? true : false);
				bool bool_4 = (((byte_0[0] & 2u) != 0) ? true : false);
				bool flag2 = (((byte_0[0] & 4u) != 0) ? true : false);
				double num6 = BitConverter.ToDouble(byte_0, 1);
				double num7 = BitConverter.ToDouble(byte_0, 9);
				int num8 = 10;
				if (flag2)
				{
					num8 = (int)num6;
				}
				Top10Filter top10Filter2 = (Top10Filter)(filterColumn.Filter = new Top10Filter(bool_3, bool_4, num8));
				try
				{
					top10Filter2.Criteria = num7;
				}
				catch
				{
				}
				break;
			}
			case 169:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				int num5 = BitConverter.ToInt32(byte_0, 0);
				int iconId = BitConverter.ToInt32(byte_0, 4);
				filterColumn = new FilterColumn(autoFilter_0.method_5(), num, bool_, bool_2);
				filterColumn.FilterType = FilterType.IconFilter;
				IconFilter iconFilter2 = (IconFilter)(filterColumn.Filter = new IconFilter(filterColumn));
				iconFilter2.IconSetType = Class1224.smethod_14(num5);
				iconFilter2.IconId = iconId;
				break;
			}
			case 168:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				filterColumn = new FilterColumn(autoFilter_0.method_5(), num, bool_, bool_2);
				filterColumn.FilterType = FilterType.ColorFilter;
				ColorFilter colorFilter2 = (ColorFilter)(filterColumn.Filter = new ColorFilter(filterColumn));
				colorFilter2.FilterByFillColor = byte_0[4] == 1;
				colorFilter2.method_2(BitConverter.ToInt32(byte_0, 0));
				break;
			}
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 165:
			{
				filterColumn = new FilterColumn(autoFilter_0.method_5(), num, bool_, bool_2);
				filterColumn.FilterType = FilterType.MultipleFilters;
				MultipleFilterCollection multipleFilterCollection_ = (MultipleFilterCollection)(filterColumn.Filter = new MultipleFilterCollection());
				method_8(multipleFilterCollection_);
				break;
			}
			case 164:
				class1212_0.Seek(1L);
				if (filterColumn != null)
				{
					autoFilter_0.method_5().method_0(filterColumn);
				}
				return;
			}
		}
	}

	private void method_7(CustomFilterCollection customFilterCollection_0)
	{
		byte_0 = class1218_0.method_0(class1212_0);
		bool and = byte_0[0] == 1;
		customFilterCollection_0.And = and;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 174:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				byte b = byte_0[0];
				byte b2 = byte_0[1];
				CustomFilter customFilter = new CustomFilter();
				customFilterCollection_0.Add(customFilter);
				customFilter.FilterOperatorType = Class1224.smethod_19(b2);
				if (b == 6)
				{
					string criteria = Class1217.smethod_8(byte_0, 10);
					customFilter.Criteria = criteria;
				}
				else
				{
					customFilter.Criteria = BitConverter.ToDouble(byte_0, 2);
				}
				break;
			}
			case 173:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_8(MultipleFilterCollection multipleFilterCollection_0)
	{
		byte_0 = class1218_0.method_0(class1212_0);
		if (byte_0[0] == 1)
		{
			multipleFilterCollection_0.MatchBlank = true;
		}
		int num = BitConverter.ToInt32(byte_0, 4);
		multipleFilterCollection_0.string_0 = Class1224.smethod_16(num);
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 167:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				string string_ = Class1217.smethod_8(byte_0, 0);
				multipleFilterCollection_0.Add(string_);
				break;
			}
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 175:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				DateTimeGroupItem dateTimeGroupItem = new DateTimeGroupItem();
				multipleFilterCollection_0.Add(dateTimeGroupItem);
				dateTimeGroupItem.Year = BitConverter.ToInt16(byte_0, 0);
				dateTimeGroupItem.Month = BitConverter.ToInt16(byte_0, 2);
				dateTimeGroupItem.Day = BitConverter.ToInt16(byte_0, 4);
				dateTimeGroupItem.Hour = BitConverter.ToInt16(byte_0, 6);
				dateTimeGroupItem.Minute = BitConverter.ToInt16(byte_0, 8);
				dateTimeGroupItem.Second = BitConverter.ToInt16(byte_0, 10);
				dateTimeGroupItem.DateTimeGroupingType = Class1224.smethod_21(BitConverter.ToInt32(byte_0, 20));
				break;
			}
			case 166:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_9()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		int index = worksheet_0.ConditionalFormattings.Add();
		FormatConditionCollection formatConditionCollection = worksheet_0.ConditionalFormattings[index];
		formatConditionCollection.bool_1 = byte_0[4] == 1;
		FormatCondition formatCondition = null;
		formatConditionCollection.arrayList_1 = Class1217.smethod_2(byte_0, 8);
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 469:
				method_13(formatCondition);
				break;
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 467:
				method_12(formatCondition);
				break;
			case 465:
				method_10(formatCondition);
				break;
			case 463:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				formatCondition = new FormatCondition(formatConditionCollection);
				formatConditionCollection.AddCondition(formatCondition);
				int num = byte_0[0];
				int num2 = BitConverter.ToInt32(byte_0, 4);
				int int_ = BitConverter.ToInt32(byte_0, 16);
				Class1224.smethod_23(byte_0, num, num2, int_, formatCondition);
				formatCondition.Operator = Class1224.smethod_0(BitConverter.ToInt32(byte_0, 16));
				int num3 = BitConverter.ToInt32(byte_0, 8);
				if (num3 != -1 && num3 < workbook_0.Worksheets.method_56().Count)
				{
					formatCondition.Style.Copy(workbook_0.Worksheets.method_56()[num3]);
				}
				formatCondition.StopIfTrue = (byte_0[28] & 2) != 0;
				formatCondition.Priority = BitConverter.ToInt16(byte_0, 12);
				int num4 = BitConverter.ToInt32(byte_0, 30);
				int num5 = BitConverter.ToInt32(byte_0, 34);
				int num6 = BitConverter.ToInt32(byte_0, 38);
				formatCondition.Text = Class1217.smethod_8(byte_0, 42);
				int num7 = 0;
				if (formatCondition.Text != null)
				{
					num7 = 46 + formatCondition.Text.Length * 2;
					break;
				}
				num7 = 46;
				if (num4 != 0)
				{
					num4 = BitConverter.ToInt32(byte_0, num7);
					formatCondition.method_1(new byte[num4 + 8]);
					Array.Copy(byte_0, num7, formatCondition.method_0(), 0, formatCondition.method_0().Length);
					num7 += formatCondition.method_0().Length;
				}
				if (num5 != 0)
				{
					num5 = BitConverter.ToInt32(byte_0, num7);
					formatCondition.method_5(new byte[num5 + 8]);
					Array.Copy(byte_0, num7, formatCondition.method_4(), 0, formatCondition.method_4().Length);
					num7 += formatCondition.method_4().Length;
				}
				if (num6 != 0)
				{
				}
				break;
			}
			case 462:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_10(FormatCondition formatCondition_0)
	{
		IconSet iconSet = new IconSet(formatCondition_0);
		byte_0 = class1218_0.method_0(class1212_0);
		int num = BitConverter.ToInt32(byte_0, 0);
		iconSet.method_2(Class1224.smethod_14(num));
		if ((byte_0[4] & 2) == 0)
		{
			iconSet.ShowValue = true;
		}
		else
		{
			iconSet.ShowValue = false;
		}
		if ((byte_0[4] & 4u) != 0)
		{
			iconSet.Reverse = true;
		}
		formatCondition_0.method_18(iconSet);
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 471:
			{
				ConditionalFormattingValue conditionalFormattingValue_ = method_11(formatCondition_0);
				iconSet.Cfvos.Add(conditionalFormattingValue_);
				break;
			}
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 466:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private ConditionalFormattingValue method_11(FormatCondition formatCondition_0)
	{
		ConditionalFormattingValue conditionalFormattingValue = new ConditionalFormattingValue(formatCondition_0);
		byte_0 = class1218_0.method_0(class1212_0);
		int num = BitConverter.ToInt32(byte_0, 0);
		conditionalFormattingValue.Type = Class1224.smethod_24(num);
		double double_ = BitConverter.ToDouble(byte_0, 4);
		conditionalFormattingValue.method_0(double_);
		if (byte_0[12] == 1)
		{
			if (byte_0[16] == 1)
			{
				conditionalFormattingValue.IsGTE = true;
			}
			else
			{
				conditionalFormattingValue.IsGTE = false;
			}
		}
		int num2 = BitConverter.ToInt32(byte_0, 20);
		if (num2 > 0)
		{
			conditionalFormattingValue.method_7(new byte[byte_0.Length - 24]);
			Array.Copy(byte_0, 24, conditionalFormattingValue.method_6(), 0, conditionalFormattingValue.method_6().Length);
		}
		return conditionalFormattingValue;
	}

	private void method_12(FormatCondition formatCondition_0)
	{
		DataBar dataBar = new DataBar(workbook_0, formatCondition_0);
		byte_0 = class1218_0.method_0(class1212_0);
		dataBar.MinLength = byte_0[0];
		dataBar.MaxLength = byte_0[1];
		dataBar.ShowValue = byte_0[2] == 1;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 564:
			{
				bool isNotSet = false;
				byte_0 = class1218_0.method_0(class1212_0);
				dataBar.method_5(Class1220.smethod_0(byte_0, 0, out isNotSet));
				break;
			}
			case 471:
			{
				ConditionalFormattingValue conditionalFormattingValue = method_11(formatCondition_0);
				if (dataBar.conditionalFormattingValue_0 == null)
				{
					dataBar.conditionalFormattingValue_0 = conditionalFormattingValue;
				}
				else
				{
					dataBar.conditionalFormattingValue_1 = conditionalFormattingValue;
				}
				break;
			}
			case 468:
				class1212_0.Seek(1L);
				formatCondition_0.method_19(dataBar);
				return;
			}
		}
	}

	private void method_13(FormatCondition formatCondition_0)
	{
		ColorScale colorScale = new ColorScale(workbook_0, formatCondition_0);
		ConditionalFormattingValueCollection conditionalFormattingValueCollection = new ConditionalFormattingValueCollection(formatCondition_0);
		ArrayList arrayList = new ArrayList(3);
		byte_0 = class1218_0.method_0(class1212_0);
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 471:
			{
				ConditionalFormattingValue conditionalFormattingValue_ = method_11(formatCondition_0);
				conditionalFormattingValueCollection.Add(conditionalFormattingValue_);
				break;
			}
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 564:
			{
				bool isNotSet = false;
				byte_0 = class1218_0.method_0(class1212_0);
				InternalColor value = Class1220.smethod_0(byte_0, 0, out isNotSet);
				arrayList.Add(value);
				break;
			}
			case 470:
				class1212_0.Seek(1L);
				if (conditionalFormattingValueCollection.Count == 2)
				{
					colorScale.conditionalFormattingValue_0 = conditionalFormattingValueCollection[0];
					colorScale.conditionalFormattingValue_2 = conditionalFormattingValueCollection[1];
					colorScale.internalColor_0 = (InternalColor)arrayList[0];
					colorScale.method_6((InternalColor)arrayList[1]);
				}
				else if (conditionalFormattingValueCollection.Count == 3)
				{
					colorScale.conditionalFormattingValue_0 = conditionalFormattingValueCollection[0];
					colorScale.conditionalFormattingValue_1 = conditionalFormattingValueCollection[1];
					colorScale.conditionalFormattingValue_2 = conditionalFormattingValueCollection[2];
					colorScale.method_2((InternalColor)arrayList[0]);
					colorScale.method_4((InternalColor)arrayList[1]);
					colorScale.method_6((InternalColor)arrayList[2]);
				}
				formatCondition_0.method_20(colorScale);
				return;
			}
		}
	}

	private void method_14()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		ValidationCollection validations = worksheet_0.Validations;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 64:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				Validation validation = new Validation(validations);
				validations.Add(validation);
				switch (byte_0[0] & 0xF)
				{
				case 0:
					validation.Type = ValidationType.AnyValue;
					break;
				case 1:
					validation.Type = ValidationType.WholeNumber;
					break;
				case 2:
					validation.Type = ValidationType.Decimal;
					break;
				case 3:
					validation.Type = ValidationType.List;
					break;
				case 4:
					validation.Type = ValidationType.Date;
					break;
				case 5:
					validation.Type = ValidationType.Time;
					break;
				case 6:
					validation.Type = ValidationType.TextLength;
					break;
				case 7:
					validation.Type = ValidationType.Custom;
					break;
				}
				switch (byte_0[0] & 0x70)
				{
				case 32:
					validation.AlertStyle = ValidationAlertType.Information;
					break;
				case 16:
					validation.AlertStyle = ValidationAlertType.Warning;
					break;
				case 0:
					validation.AlertStyle = ValidationAlertType.Stop;
					break;
				}
				if (((uint)byte_0[1] & (true ? 1u : 0u)) != 0)
				{
					validation.IgnoreBlank = true;
				}
				else
				{
					validation.IgnoreBlank = false;
				}
				if ((byte_0[1] & 2) == 0)
				{
					validation.InCellDropDown = true;
				}
				else
				{
					validation.InCellDropDown = false;
				}
				switch (((byte_0[2] & 3) << 6) + ((byte_0[1] & 0xFC) >> 2))
				{
				case 0:
					validation.method_6(Enum228.const_0);
					break;
				case 1:
					validation.method_6(Enum228.const_1);
					break;
				case 2:
					validation.method_6(Enum228.const_2);
					break;
				default:
					validation.method_6(Enum228.const_0);
					break;
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
					break;
				}
				if ((byte_0[2] & 4) == 0)
				{
					validation.ShowInput = false;
				}
				else
				{
					validation.ShowInput = true;
				}
				if ((byte_0[2] & 8) == 0)
				{
					validation.ShowError = false;
				}
				else
				{
					validation.ShowError = true;
				}
				switch (byte_0[2] & 0xF0)
				{
				case 16:
					validation.Operator = OperatorType.NotBetween;
					break;
				case 0:
					validation.Operator = OperatorType.Between;
					break;
				case 48:
					validation.Operator = OperatorType.NotEqual;
					break;
				case 32:
					validation.Operator = OperatorType.Equal;
					break;
				case 80:
					validation.Operator = OperatorType.LessThan;
					break;
				case 64:
					validation.Operator = OperatorType.GreaterThan;
					break;
				case 112:
					validation.Operator = OperatorType.LessOrEqual;
					break;
				case 96:
					validation.Operator = OperatorType.GreaterOrEqual;
					break;
				}
				int num = 4;
				int num2 = BitConverter.ToInt32(byte_0, 4);
				num = 4 + 4;
				for (int i = 0; i < num2; i++)
				{
					CellArea cellArea = default(CellArea);
					cellArea.StartRow = BitConverter.ToInt32(byte_0, num);
					cellArea.EndRow = BitConverter.ToInt32(byte_0, num + 4);
					cellArea.StartColumn = BitConverter.ToInt32(byte_0, num + 8);
					cellArea.EndColumn = BitConverter.ToInt32(byte_0, num + 12);
					validation.AreaList.Add(cellArea);
					num += 16;
				}
				validation.ErrorTitle = Class1217.smethod_5(byte_0, ref num);
				validation.ErrorMessage = Class1217.smethod_5(byte_0, ref num);
				validation.InputTitle = Class1217.smethod_5(byte_0, ref num);
				validation.InputMessage = Class1217.smethod_5(byte_0, ref num);
				int num3 = BitConverter.ToInt32(byte_0, num);
				validation.method_8(new byte[num3]);
				num += 4;
				Array.Copy(byte_0, num, validation.method_7(), 0, num3);
				num += num3 + 4;
				num3 = BitConverter.ToInt32(byte_0, num);
				validation.method_10(new byte[num3]);
				num += 4;
				Array.Copy(byte_0, num, validation.method_9(), 0, num3);
				num += num3 + 4;
				int num4 = 1048575;
				int int_ = 0;
				for (int num5 = validation.AreaList.Count - 1; num5 >= 0; num5--)
				{
					CellArea cellArea2 = (CellArea)validation.AreaList[num5];
					if (cellArea2.StartRow < num4)
					{
						num4 = cellArea2.StartRow;
						int_ = cellArea2.StartColumn;
					}
				}
				string string_ = Validation.smethod_2(workbook_0.Worksheets, validation.method_7(), 0, validation.Type, num4, int_);
				string string_2 = Validation.smethod_2(workbook_0.Worksheets, validation.method_9(), 0, validation.Type, num4, int_);
				validation.method_2(string_);
				validation.method_3(string_2);
				break;
			}
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 574:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_15()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		ValidationCollection validations = worksheet_0.Validations;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 1053:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				Validation validation = new Validation(validations);
				validations.Add(validation);
				byte b = byte_0[0];
				bool flag = (((b & 4u) != 0) ? true : false);
				int num = 4;
				BitConverter.ToInt32(byte_0, 4);
				num = 4 + 4;
				num = 8 + 4;
				int num2 = BitConverter.ToInt32(byte_0, 12);
				num = 12 + 4;
				if (num2 > 0)
				{
					for (int i = 0; i < num2; i++)
					{
						CellArea cellArea = default(CellArea);
						cellArea.StartRow = BitConverter.ToInt32(byte_0, num);
						cellArea.EndRow = BitConverter.ToInt32(byte_0, num + 4);
						cellArea.StartColumn = BitConverter.ToInt32(byte_0, num + 8);
						cellArea.EndColumn = BitConverter.ToInt32(byte_0, num + 12);
						validation.AreaList.Add(cellArea);
						num += 16;
					}
				}
				if (flag)
				{
					num += 4;
					num += 4;
					int num3 = BitConverter.ToInt32(byte_0, num);
					validation.method_8(new byte[num3]);
					num += 4;
					int num4 = BitConverter.ToInt32(byte_0, num);
					validation.method_10(new byte[num4]);
					num += 4;
					Array.Copy(byte_0, num, validation.method_7(), 0, num3);
					num += num3;
					Array.Copy(byte_0, num, validation.method_9(), 0, num4);
					num += num4;
					int num5 = 1048575;
					int int_ = 0;
					for (int num6 = validation.AreaList.Count - 1; num6 >= 0; num6--)
					{
						CellArea cellArea2 = (CellArea)validation.AreaList[num6];
						if (cellArea2.StartRow < num5)
						{
							num5 = cellArea2.StartRow;
							int_ = cellArea2.StartColumn;
						}
					}
					string string_ = Validation.smethod_2(workbook_0.Worksheets, validation.method_7(), 0, validation.Type, num5, int_);
					string string_2 = Validation.smethod_2(workbook_0.Worksheets, validation.method_9(), 0, validation.Type, num5, int_);
					validation.method_2(string_);
					validation.method_3(string_2);
				}
				method_16(num, validation);
				break;
			}
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 1154:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_16(int int_2, Validation validation_0)
	{
		switch (byte_0[int_2] & 0xF)
		{
		case 0:
			validation_0.Type = ValidationType.AnyValue;
			break;
		case 1:
			validation_0.Type = ValidationType.WholeNumber;
			break;
		case 2:
			validation_0.Type = ValidationType.Decimal;
			break;
		case 3:
			validation_0.Type = ValidationType.List;
			break;
		case 4:
			validation_0.Type = ValidationType.Date;
			break;
		case 5:
			validation_0.Type = ValidationType.Time;
			break;
		case 6:
			validation_0.Type = ValidationType.TextLength;
			break;
		case 7:
			validation_0.Type = ValidationType.Custom;
			break;
		}
		switch (byte_0[int_2] & 0x70)
		{
		case 32:
			validation_0.AlertStyle = ValidationAlertType.Information;
			break;
		case 16:
			validation_0.AlertStyle = ValidationAlertType.Warning;
			break;
		case 0:
			validation_0.AlertStyle = ValidationAlertType.Stop;
			break;
		}
		if (((uint)byte_0[int_2 + 1] & (true ? 1u : 0u)) != 0)
		{
			validation_0.IgnoreBlank = true;
		}
		else
		{
			validation_0.IgnoreBlank = false;
		}
		if ((byte_0[int_2 + 1] & 2) == 0)
		{
			validation_0.InCellDropDown = true;
		}
		else
		{
			validation_0.InCellDropDown = false;
		}
		switch (((byte_0[int_2 + 2] & 3) << 6) + ((byte_0[int_2 + 1] & 0xFC) >> 2))
		{
		case 0:
			validation_0.method_6(Enum228.const_0);
			break;
		case 1:
			validation_0.method_6(Enum228.const_1);
			break;
		case 2:
			validation_0.method_6(Enum228.const_2);
			break;
		default:
			validation_0.method_6(Enum228.const_0);
			break;
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
		case 10:
			break;
		}
		if ((byte_0[int_2 + 2] & 4) == 0)
		{
			validation_0.ShowInput = false;
		}
		else
		{
			validation_0.ShowInput = true;
		}
		if ((byte_0[int_2 + 2] & 8) == 0)
		{
			validation_0.ShowError = false;
		}
		else
		{
			validation_0.ShowError = true;
		}
		switch (byte_0[int_2 + 2] & 0xF0)
		{
		case 16:
			validation_0.Operator = OperatorType.NotBetween;
			break;
		case 0:
			validation_0.Operator = OperatorType.Between;
			break;
		case 48:
			validation_0.Operator = OperatorType.NotEqual;
			break;
		case 32:
			validation_0.Operator = OperatorType.Equal;
			break;
		case 80:
			validation_0.Operator = OperatorType.LessThan;
			break;
		case 64:
			validation_0.Operator = OperatorType.GreaterThan;
			break;
		case 112:
			validation_0.Operator = OperatorType.LessOrEqual;
			break;
		case 96:
			validation_0.Operator = OperatorType.GreaterOrEqual;
			break;
		}
	}

	private void method_17()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		PageSetup pageSetup = worksheet_0.PageSetup;
		pageSetup.method_22(byte_0[0]);
		int num = 2;
		string text = Class1217.smethod_5(byte_0, ref num);
		string[] array;
		if (text != null && text != "")
		{
			array = Class1619.smethod_0(text);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != null)
				{
					pageSetup.SetHeader(i, array[i]);
				}
			}
		}
		text = Class1217.smethod_5(byte_0, ref num);
		if (text != null && text != "")
		{
			array = Class1619.smethod_0(text);
			for (int j = 0; j < array.Length; j++)
			{
				if (array[j] != null)
				{
					pageSetup.SetFooter(j, array[j]);
				}
			}
		}
		text = Class1217.smethod_5(byte_0, ref num);
		if (text != null && text != "")
		{
			array = Class1619.smethod_0(text);
			for (int k = 0; k < array.Length; k++)
			{
				if (array[k] != null)
				{
					pageSetup.SetEvenHeader(k, array[k]);
				}
			}
		}
		text = Class1217.smethod_5(byte_0, ref num);
		if (text != null && text != "")
		{
			array = Class1619.smethod_0(text);
			for (int l = 0; l < array.Length; l++)
			{
				if (array[l] != null)
				{
					pageSetup.SetEvenFooter(l, array[l]);
				}
			}
		}
		text = Class1217.smethod_5(byte_0, ref num);
		if (text != null && text != "")
		{
			array = Class1619.smethod_0(text);
			for (int m = 0; m < array.Length; m++)
			{
				if (array[m] != null)
				{
					pageSetup.SetFirstPageHeader(m, array[m]);
				}
			}
		}
		text = Class1217.smethod_5(byte_0, ref num);
		if (text == null || !(text != ""))
		{
			return;
		}
		array = Class1619.smethod_0(text);
		for (int n = 0; n < array.Length; n++)
		{
			if (array[n] != null)
			{
				pageSetup.SetFirstPageFooter(n, array[n]);
			}
		}
	}

	private void method_18()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		CellArea cellArea = Class1217.smethod_1(byte_0, 0);
		int num = 16;
		string text = Class1217.smethod_5(byte_0, ref num);
		string text2 = Class1217.smethod_5(byte_0, ref num);
		string text3 = Class1217.smethod_5(byte_0, ref num);
		Class1217.smethod_5(byte_0, ref num);
		if (text != null)
		{
			Hashtable hashtable_ = class1548_0.hashtable_0;
			if (hashtable_ != null && hashtable_.ContainsKey(text))
			{
				Class1564 @class = (Class1564)hashtable_[text];
				if (text2 == null || text2 == "")
				{
					text2 = @class.string_3;
				}
			}
		}
		int index = worksheet_0.Hyperlinks.method_1(cellArea.StartRow, cellArea.StartColumn, cellArea.EndRow - cellArea.StartRow + 1, cellArea.EndColumn - cellArea.StartColumn + 1, text2);
		Hyperlink hyperlink = worksheet_0.Hyperlinks[index];
		if (text3 != null && text3.Length != 0)
		{
			hyperlink.ScreenTip = text3;
		}
	}

	internal void method_19()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		PageSetup pageSetup = worksheet_0.PageSetup;
		if ((byte_0[32] & 4) == 0)
		{
			pageSetup.PaperSize = (PaperSizeType)BitConverter.ToInt32(byte_0, 0);
			if (bool_0)
			{
				pageSetup.FitToPagesWide = BitConverter.ToInt32(byte_0, 24);
				pageSetup.FitToPagesTall = BitConverter.ToInt32(byte_0, 28);
			}
			else
			{
				pageSetup.Zoom = BitConverter.ToInt32(byte_0, 4);
			}
			pageSetup.method_16(BitConverter.ToInt32(byte_0, 8));
			pageSetup.method_18(BitConverter.ToInt32(byte_0, 12));
			if ((byte_0[32] & 0x40) == 0)
			{
				pageSetup.Orientation = (((byte_0[32] & 2) == 0) ? PageOrientationType.Portrait : PageOrientationType.Landscape);
			}
		}
		if ((byte_0[32] & 0x80u) != 0)
		{
			pageSetup.FirstPageNumber = BitConverter.ToInt32(byte_0, 20);
			pageSetup.IsAutoFirstPageNumber = false;
		}
		pageSetup.Order = ((((uint)byte_0[32] & (true ? 1u : 0u)) != 0) ? PrintOrderType.OverThenDown : PrintOrderType.DownThenOver);
		pageSetup.BlackAndWhite = (byte_0[32] & 8) != 0;
		pageSetup.PrintDraft = (byte_0[32] & 0x10) != 0;
		if ((byte_0[32] & 0x20u) != 0)
		{
			pageSetup.PrintComments = PrintCommentsType.PrintInPlace;
		}
		if (((uint)byte_0[33] & (true ? 1u : 0u)) != 0)
		{
			pageSetup.PrintComments = PrintCommentsType.PrintSheetEnd;
		}
		switch ((byte_0[33] & 6) >> 1)
		{
		case 0:
			pageSetup.PrintErrors = PrintErrorsType.PrintErrorsDisplayed;
			break;
		case 1:
			pageSetup.PrintErrors = PrintErrorsType.PrintErrorsBlank;
			break;
		case 2:
			pageSetup.PrintErrors = PrintErrorsType.PrintErrorsDash;
			break;
		case 3:
			pageSetup.PrintErrors = PrintErrorsType.PrintErrorsNA;
			break;
		}
	}

	internal void method_20()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		PageSetup pageSetup = worksheet_0.PageSetup;
		pageSetup.CenterHorizontally = (byte_0[0] & 1) != 0;
		pageSetup.CenterVertically = (byte_0[0] & 2) != 0;
		pageSetup.PrintHeadings = (byte_0[0] & 4) != 0;
		pageSetup.PrintGridlines = (byte_0[0] & 0x18) == 24;
	}

	internal void method_21()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		PageSetup pageSetup = worksheet_0.PageSetup;
		pageSetup.LeftMarginInch = BitConverter.ToDouble(byte_0, 0);
		pageSetup.RightMarginInch = BitConverter.ToDouble(byte_0, 8);
		pageSetup.TopMarginInch = BitConverter.ToDouble(byte_0, 16);
		pageSetup.BottomMarginInch = BitConverter.ToDouble(byte_0, 24);
		pageSetup.HeaderMarginInch = BitConverter.ToDouble(byte_0, 32);
		pageSetup.FooterMarginInch = BitConverter.ToDouble(byte_0, 40);
	}

	internal void method_22()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		int num = BitConverter.ToInt32(byte_0, 0);
		Class1133 @class = worksheet_0.Cells.method_18();
		for (int i = 0; i < num; i++)
		{
			int_0 = class1212_0.method_0();
			if (int_0 != 176)
			{
				break;
			}
			byte_0 = class1218_0.method_0(class1212_0);
			@class.Add(Class1217.smethod_1(byte_0, 0));
		}
	}

	private void method_23()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		Protection protection = worksheet_0.Protection;
		protection.method_3(BitConverter.ToUInt16(byte_0, 0));
		protection.AllowEditingContent = byte_0[2] == 0;
		protection.AllowEditingObject = byte_0[6] == 1;
		protection.AllowEditingScenario = byte_0[10] == 1;
		protection.AllowFormattingCell = byte_0[14] == 1;
		protection.AllowFormattingColumn = byte_0[18] == 1;
		protection.AllowFormattingRow = byte_0[22] == 1;
		protection.AllowInsertingColumn = byte_0[26] == 1;
		protection.AllowInsertingRow = byte_0[30] == 1;
		protection.AllowInsertingHyperlink = byte_0[34] == 1;
		protection.AllowDeletingColumn = byte_0[38] == 1;
		protection.AllowDeletingRow = byte_0[42] == 1;
		protection.AllowSelectingLockedCell = byte_0[46] == 1;
		protection.AllowSorting = byte_0[50] == 1;
		protection.AllowFiltering = byte_0[54] == 1;
		protection.AllowUsingPivotTable = byte_0[58] == 1;
		protection.AllowSelectingUnlockedCell = byte_0[62] == 1;
	}

	private void method_24()
	{
		class1212_0.Seek(1L);
		int int_ = 0;
		int num = 0;
		Cell cell = null;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 18:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				cell = method_26(byte_0, 0, cell);
				int num3 = BitConverter.ToInt32(byte_0, 4);
				if (num3 < cells_0.method_2().method_3())
				{
					cells_0.method_2().method_5(cell, num3);
				}
				break;
			}
			case 17:
				byte_0 = class1218_0.method_0(class1212_0);
				cell = method_26(byte_0, 0, cell);
				cell.PutValue(Class1217.smethod_8(byte_0, 4));
				break;
			case 16:
				byte_0 = class1218_0.method_0(class1212_0);
				cell = method_26(byte_0, 0, cell);
				cell.method_65(BitConverter.ToDouble(byte_0, 4));
				break;
			case 15:
				byte_0 = class1218_0.method_0(class1212_0);
				cell = method_26(byte_0, 0, cell);
				cell.method_65((byte_0[4] != 0) ? Class1391.object_0 : Class1391.object_1);
				break;
			case 14:
				byte_0 = class1218_0.method_0(class1212_0);
				cell = method_26(byte_0, 0, cell);
				cell.method_65(Class1673.smethod_6(byte_0[4]));
				break;
			case 13:
				byte_0 = class1218_0.method_0(class1212_0);
				cell = method_26(byte_0, 0, cell);
				cell.method_65(method_25(byte_0, 4));
				break;
			case 12:
				byte_0 = class1218_0.method_0(class1212_0);
				cell = method_26(byte_0, 0, cell);
				break;
			case 11:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				cell = method_27(byte_0, 0, int_);
				num = 11;
				byte[] array3 = new byte[byte_0.Length - 11];
				Array.Copy(byte_0, 11, array3, 0, byte_0.Length - 11);
				cell.method_43(array3);
				cell.method_65(Class1673.smethod_6(byte_0[8]));
				break;
			}
			case 10:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				cell = method_27(byte_0, 0, int_);
				num = 11;
				byte[] array3 = new byte[byte_0.Length - 11];
				Array.Copy(byte_0, 11, array3, 0, byte_0.Length - 11);
				cell.method_43(array3);
				cell.method_65((byte_0[8] == 1) ? Class1391.object_0 : Class1391.object_1);
				break;
			}
			case 9:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				cell = method_27(byte_0, 0, int_);
				num = 18;
				byte[] array3 = new byte[byte_0.Length - 18];
				Array.Copy(byte_0, 18, array3, 0, byte_0.Length - 18);
				cell.method_43(array3);
				cell.method_65(BitConverter.ToDouble(byte_0, 8));
				break;
			}
			case 8:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				cell = method_27(byte_0, 0, int_);
				num = 8;
				string text = Class1217.smethod_5(byte_0, ref num);
				num += 2;
				byte[] array3 = new byte[byte_0.Length - 10 - 4 - text.Length * 2];
				Array.Copy(byte_0, num, array3, 0, array3.Length);
				cell.method_43(array3);
				cell.method_65(text);
				break;
			}
			case 7:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				cell = method_27(byte_0, 0, int_);
				int num2 = BitConverter.ToInt32(byte_0, 8);
				if (num2 < cells_0.method_2().method_3())
				{
					cells_0.method_2().method_5(cell, num2);
				}
				break;
			}
			case 6:
				byte_0 = class1218_0.method_0(class1212_0);
				cell = method_27(byte_0, 0, int_);
				cell.PutValue(Class1217.smethod_8(byte_0, 8));
				break;
			case 5:
				byte_0 = class1218_0.method_0(class1212_0);
				cell = method_27(byte_0, 0, int_);
				cell.method_65(BitConverter.ToDouble(byte_0, 8));
				break;
			case 4:
				byte_0 = class1218_0.method_0(class1212_0);
				cell = method_27(byte_0, 0, int_);
				cell.method_65((byte_0[8] != 0) ? Class1391.object_0 : Class1391.object_1);
				break;
			case 3:
				byte_0 = class1218_0.method_0(class1212_0);
				cell = method_27(byte_0, 0, int_);
				cell.method_65(Class1673.smethod_6(byte_0[8]));
				break;
			case 2:
				byte_0 = class1218_0.method_0(class1212_0);
				cell = method_27(byte_0, 0, int_);
				cell.method_65(method_25(byte_0, 8));
				break;
			case 1:
				byte_0 = class1218_0.method_0(class1212_0);
				cell = method_27(byte_0, 0, int_);
				break;
			case 0:
				int_ = method_28();
				break;
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 426:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				CellArea cellArea_2 = Class1217.smethod_1(byte_0, 0);
				byte[] array2 = new byte[byte_0.Length - 17];
				Array.Copy(byte_0, 17, array2, 0, array2.Length);
				cell.method_51(new Class1348(cellArea_2, bool_0: true, array2));
				cell.method_17().method_8(bool_0: true);
				break;
			}
			case 427:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				CellArea cellArea_ = Class1217.smethod_1(byte_0, 0);
				byte[] array = new byte[byte_0.Length - 16];
				Array.Copy(byte_0, 16, array, 0, array.Length);
				cell.method_51(new Class1348(cellArea_, bool_0: false, array));
				break;
			}
			case 146:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private double method_25(byte[] byte_1, int int_2)
	{
		int num = BitConverter.ToInt32(byte_1, int_2);
		double num2 = 0.0;
		if (((uint)num & 2u) != 0)
		{
			num2 = num >> 2;
		}
		else
		{
			int value = num - (num & 3);
			byte[] array = new byte[8];
			Array.Copy(BitConverter.GetBytes(value), 0, array, 4, 4);
			num2 = BitConverter.ToDouble(array, 0);
		}
		if (((uint)num & (true ? 1u : 0u)) != 0)
		{
			num2 /= 100.0;
		}
		return num2;
	}

	private Cell method_26(byte[] byte_1, int int_2, Cell cell_0)
	{
		int int_3 = (int)class1547_0.hashtable_3[BitConverter.ToInt32(byte_1, int_2) & 0xFFFFFF];
		Cell cell = cells_0.Rows.GetCell(cell_0.Row, cell_0.Column + 1, bool_0: false, bool_1: false, bool_2: false);
		cell.method_37(int_3);
		return cell;
	}

	private Cell method_27(byte[] byte_1, int int_2, int int_3)
	{
		int int_4 = BitConverter.ToInt32(byte_1, int_2);
		int int_5 = (int)class1547_0.hashtable_3[BitConverter.ToInt32(byte_1, int_2 + 4) & 0xFFFFFF];
		Cell cell = cells_0.Rows.GetCell(int_3, int_4, bool_0: false, bool_1: false, bool_2: false);
		cell.method_37(int_5);
		return cell;
	}

	private int method_28()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		int num = BitConverter.ToInt32(byte_0, 0);
		Row row = cells_0.Rows.GetRow(num, bool_0: false, bool_1: false);
		row.method_14(BitConverter.ToUInt16(byte_0, 8));
		row.method_25((byte)(byte_0[11] & 7u));
		row.method_16((byte_0[11] & 8) != 0);
		row.IsHidden = (byte_0[11] & 0x10) != 0;
		row.IsHeightMatched = (byte_0[11] & 0x20) >> 5 != 1;
		row.method_21((byte_0[11] & 0x40) != 0);
		if (row.method_20())
		{
			row.method_11((int)class1547_0.hashtable_3[BitConverter.ToInt32(byte_0, 4)]);
		}
		return num;
	}

	private void method_29()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		int num = BitConverter.ToInt32(byte_0, 0);
		int num2 = BitConverter.ToInt32(byte_0, 4);
		int num3 = BitConverter.ToInt32(byte_0, 8);
		int num4 = BitConverter.ToInt32(byte_0, 12);
		num4 = (int)class1547_0.hashtable_3[num4];
		bool flag = (byte_0[16] & 1) != 0;
		bool flag2 = (byte_0[17] & 0x10) != 0;
		int num5 = byte_0[17] & 7;
		ColumnCollection columns = worksheet_0.Cells.Columns;
		for (int i = num; i <= num2; i++)
		{
			Column column = null;
			if (num2 >= 16383)
			{
				column = columns.method_0();
				column.method_0(i);
			}
			else
			{
				column = columns[i];
			}
			column.method_6(num4);
			int num6 = workbook_0.Worksheets.method_71();
			workbook_0.Worksheets.method_73();
			column.Width = (double)(num3 - num6) / 256.0;
			if (flag)
			{
				column.IsHidden = true;
			}
			column.method_4((byte)num5);
			column.method_15(flag2);
			if (num2 >= 16383)
			{
				break;
			}
		}
	}

	private void method_30()
	{
		bool IsNotSet = false;
		byte_0 = class1218_0.method_0(class1212_0);
		bool_0 = (byte_0[1] & 1) != 0;
		worksheet_0.IsOutlineShown = (byte_0[1] & 4) != 0;
		bool_1 = (byte_0[2] & 1) != 0;
		InternalColor internalColor = method_33(byte_0, 3, out IsNotSet);
		if (!IsNotSet && !internalColor.method_2())
		{
			worksheet_0.TabColor = internalColor.method_6(workbook_0);
		}
		int num = BitConverter.ToInt32(byte_0, 11);
		if (num != -1)
		{
			worksheet_0.FirstVisibleRow = num;
		}
		num = BitConverter.ToInt32(byte_0, 15);
		if (num != -1)
		{
			worksheet_0.FirstVisibleColumn = num;
		}
		worksheet_0.method_46(Class1217.smethod_8(byte_0, 19));
	}

	private void method_31()
	{
		class1212_0.Seek(1L);
		Class1733 @class = new Class1733(worksheet_0);
		worksheet_0.method_35(@class);
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 151:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				PaneCollection paneCollection = worksheet_0.method_1();
				paneCollection.method_7((int)BitConverter.ToDouble(byte_0, 0));
				paneCollection.method_5((int)BitConverter.ToDouble(byte_0, 8));
				paneCollection.method_2(BitConverter.ToInt32(byte_0, 16));
				paneCollection.method_3(BitConverter.ToInt32(byte_0, 20));
				paneCollection.method_1((byte)BitConverter.ToInt32(byte_0, 24));
				worksheet_0.method_14((byte_0[28] & 1) != 0);
				break;
			}
			case 152:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				Class1732 class2 = new Class1732(BitConverter.ToInt32(byte_0, 0));
				class2.method_6(BitConverter.ToInt32(byte_0, 4));
				class2.method_8(BitConverter.ToInt32(byte_0, 8));
				class2.method_10(BitConverter.ToInt32(byte_0, 12));
				class2.method_4(Class1217.smethod_2(byte_0, 16));
				@class.Add(class2);
				break;
			}
			case 137:
				byte_0 = class1218_0.method_0(class1212_0);
				worksheet_0.method_12((byte_0[0] & 2) != 0);
				worksheet_0.IsGridlinesVisible = (byte_0[0] & 4) != 0;
				worksheet_0.IsRowColumnHeadersVisible = (byte_0[0] & 8) != 0;
				worksheet_0.DisplayZeros = (byte_0[0] & 0x10) != 0;
				worksheet_0.DisplayRightToLeft = (byte_0[0] & 0x20) != 0;
				worksheet_0.IsSelected = (byte_0[0] & 0x40) != 0;
				worksheet_0.IsOutlineShown = (byte_0[1] & 1) != 0;
				worksheet_0.FirstVisibleRow = BitConverter.ToInt32(byte_0, 6);
				worksheet_0.FirstVisibleColumn = BitConverter.ToInt32(byte_0, 10);
				worksheet_0.method_45(BitConverter.ToInt32(byte_0, 14));
				worksheet_0.Zoom = BitConverter.ToInt16(byte_0, 18);
				break;
			case 134:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_32()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		ushort num = BitConverter.ToUInt16(byte_0, 4);
		if (num != 8)
		{
			int num2 = num * 8;
			double num3 = 0.0;
			num3 = ((num2 < 12) ? ((double)num2 / 12.0) : ((double)(num2 - 5) / 7.0));
			worksheet_0.Cells.method_8(num3);
		}
		int num4 = ((workbook_0.Worksheets.method_72() * 8 + workbook_0.Worksheets.method_73()) / 8 + 1) * 8;
		double width = ((double)num4 - (double)workbook_0.Worksheets.method_73()) / (double)workbook_0.Worksheets.method_72();
		worksheet_0.Cells.Columns.Width = width;
		int num5 = BitConverter.ToUInt16(byte_0, 6);
		if ((byte_0[8] & 2u) != 0)
		{
			num5 = 0;
		}
		worksheet_0.Cells.double_0 = num5;
		worksheet_0.Cells.method_30(byte_0[10]);
		worksheet_0.Cells.method_28(byte_0[11]);
	}

	internal InternalColor method_33(byte[] buffer, int offset, out bool IsNotSet)
	{
		ColorType colorType_ = ColorType.Automatic;
		IsNotSet = false;
		InternalColor internalColor = new InternalColor(bool_0: false);
		switch (buffer[offset])
		{
		default:
			IsNotSet = true;
			internalColor.method_3(bool_0: true);
			break;
		case 0:
			internalColor.method_3(bool_0: true);
			break;
		case 1:
			if (buffer[offset + 1] >= 64)
			{
				internalColor.method_3(bool_0: true);
			}
			else
			{
				internalColor.SetColor(colorType_, workbook_0.Worksheets.method_24().method_3(buffer[offset + 1]));
			}
			break;
		case 2:
			offset += 4;
			internalColor.SetColor(colorType_, (buffer[offset] << 16) + (buffer[offset + 1] << 8) + buffer[offset + 2]);
			break;
		case 3:
			internalColor.method_3(bool_0: true);
			break;
		}
		return internalColor;
	}
}
