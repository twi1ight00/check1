using System;
using Aspose.Cells;
using Aspose.Cells.Tables;
using ns16;

namespace ns10;

internal class Class1222
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

	private Cells cells_0;

	private ListObject listObject_0;

	internal Class1222(Class1218 class1218_1)
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
			case 161:
				method_4();
				break;
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 513:
				method_3();
				break;
			case 343:
				method_0();
				break;
			case 345:
				method_1();
				break;
			case 344:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_0()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		CellArea cellArea = Class1217.smethod_1(byte_0, 0);
		listObject_0 = new ListObject(worksheet_0.ListObjects);
		listObject_0.method_2(cellArea.StartRow);
		listObject_0.method_3(cellArea.StartColumn);
		listObject_0.method_4(cellArea.EndRow);
		listObject_0.method_5(cellArea.EndColumn);
		worksheet_0.ListObjects.Add(listObject_0);
		int num = BitConverter.ToInt32(byte_0, 16);
		listObject_0.method_14(Class1224.smethod_26(num));
		int int_ = BitConverter.ToInt32(byte_0, 20);
		listObject_0.method_46(int_);
		int num2 = BitConverter.ToInt32(byte_0, 24);
		if (num2 != 0)
		{
			listObject_0.method_49(num2);
		}
		byte b = byte_0[32];
		listObject_0.method_20((((uint)b & (true ? 1u : 0u)) != 0) ? true : false);
		listObject_0.method_22(((b & 2u) != 0) ? true : false);
		listObject_0.method_18(((b & 8u) != 0) ? true : false);
		listObject_0.method_26(((b & 0x10u) != 0) ? true : false);
		int num3 = BitConverter.ToInt32(byte_0, 28);
		if (num3 != 0)
		{
			listObject_0.method_52(num3);
		}
		else
		{
			listObject_0.method_20(bool_0: false);
		}
		listObject_0.int_10[0] = BitConverter.ToInt32(byte_0, 36);
		listObject_0.int_10[1] = BitConverter.ToInt32(byte_0, 40);
		listObject_0.int_10[2] = BitConverter.ToInt32(byte_0, 44);
		listObject_0.int_10[3] = BitConverter.ToInt32(byte_0, 48);
		listObject_0.int_10[4] = BitConverter.ToInt32(byte_0, 52);
		listObject_0.int_10[5] = BitConverter.ToInt32(byte_0, 56);
		listObject_0.method_34(BitConverter.ToInt32(byte_0, 60));
		int num4 = 64;
		string text = Class1217.smethod_5(byte_0, ref num4);
		if (text != null && text.Length > 0)
		{
			listObject_0.method_47(text);
		}
		string text2 = Class1217.smethod_5(byte_0, ref num4);
		if (text2 != null && text2.Length > 0)
		{
			listObject_0.DisplayName = text2;
		}
		listObject_0.Comment = Class1217.smethod_5(byte_0, ref num4);
	}

	private void method_1()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		BitConverter.ToInt32(byte_0, 0);
		listObject_0.method_6(new ListColumnCollection(listObject_0));
		int num = 0;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 347:
				method_2(num);
				num++;
				break;
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 346:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_2(int int_2)
	{
		byte_0 = class1218_0.method_0(class1212_0);
		int num = 24;
		string string_ = Class1217.smethod_5(byte_0, ref num);
		ListColumn listColumn = new ListColumn(listObject_0.ListColumns, string_, int_2);
		listObject_0.ListColumns.Add(listColumn);
		listColumn.int_5 = BitConverter.ToInt32(byte_0, 0);
		TotalsCalculation totalsCalculation_ = Class1224.smethod_28(BitConverter.ToInt32(byte_0, 4));
		listColumn.method_6(totalsCalculation_);
		listColumn.int_3[0] = BitConverter.ToInt32(byte_0, 8);
		listColumn.int_3[1] = BitConverter.ToInt32(byte_0, 12);
		listColumn.int_3[2] = BitConverter.ToInt32(byte_0, 16);
		listColumn.method_22(BitConverter.ToInt32(byte_0, 20));
		string string_2 = Class1217.smethod_5(byte_0, ref num);
		listColumn.method_3(string_2);
		listColumn.method_2(string_2);
		string string_3 = Class1217.smethod_5(byte_0, ref num);
		listColumn.method_17(string_3);
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 352:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				int num2 = BitConverter.ToInt32(byte_0, 1);
				listColumn.byte_1 = new byte[num2];
				Array.Copy(byte_0, 5, listColumn.byte_1, 0, num2);
				break;
			}
			case 351:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				int num2 = BitConverter.ToInt32(byte_0, 1);
				listColumn.byte_0 = new byte[num2];
				Array.Copy(byte_0, 5, listColumn.byte_0, 0, num2);
				break;
			}
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 348:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_3()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		byte b = byte_0[0];
		listObject_0.ShowTableStyleFirstColumn = ((((uint)b & (true ? 1u : 0u)) != 0) ? true : false);
		listObject_0.ShowTableStyleLastColumn = (((b & 2u) != 0) ? true : false);
		listObject_0.ShowTableStyleRowStripes = (((b & 4u) != 0) ? true : false);
		listObject_0.ShowTableStyleColumnStripes = (((b & 8u) != 0) ? true : false);
		listObject_0.TableStyleName = Class1217.smethod_8(byte_0, 2);
	}

	private void method_4()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		AutoFilter autoFilter = listObject_0.AutoFilter;
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
				method_5(autoFilter);
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

	private void method_5(AutoFilter autoFilter_0)
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
				method_6(customFilterCollection_);
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
				method_7(multipleFilterCollection_);
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

	private void method_6(CustomFilterCollection customFilterCollection_0)
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

	private void method_7(MultipleFilterCollection multipleFilterCollection_0)
	{
		byte_0 = class1218_0.method_0(class1212_0);
		if (byte_0[0] == 1)
		{
			multipleFilterCollection_0.MatchBlank = true;
		}
		int num = BitConverter.ToInt32(byte_0, 4);
		multipleFilterCollection_0.string_0 = Class1224.smethod_16(num);
		int num2 = 0;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 167:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				string string_ = Class1217.smethod_5(byte_0, ref num2);
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
}
