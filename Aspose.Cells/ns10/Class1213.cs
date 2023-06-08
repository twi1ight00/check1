using System;
using Aspose.Cells;
using Aspose.Cells.Charts;
using ns16;
using ns2;
using ns25;

namespace ns10;

internal class Class1213
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

	internal Class1213(Class1218 class1218_1)
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
		worksheet_0.Type = SheetType.Chart;
		worksheet_0.Charts.Add(new Chart(worksheet_0));
		class1212_0 = class1212_1;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 562:
				byte_0 = class1218_0.method_0(class1212_0);
				class1548_1.string_5 = Class1217.smethod_8(byte_0, 0);
				break;
			case 550:
				byte_0 = class1218_0.method_0(class1212_0);
				class1548_1.string_4 = Class1217.smethod_8(byte_0, 0);
				break;
			case 551:
				byte_0 = class1218_0.method_0(class1212_0);
				class1548_1.string_2 = Class1217.smethod_8(byte_0, 0);
				break;
			case 552:
				byte_0 = class1218_0.method_0(class1212_0);
				class1548_1.string_3 = Class1217.smethod_8(byte_0, 0);
				break;
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 669:
				method_2();
				break;
			case 651:
				method_0();
				break;
			case 652:
				method_4();
				break;
			case 139:
				method_1();
				break;
			case 479:
				method_5();
				break;
			case 476:
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
		bool isNotSet = false;
		InternalColor internalColor = Class1220.smethod_0(byte_0, 2, out isNotSet);
		if (!isNotSet && !internalColor.method_2())
		{
			worksheet_0.TabColor = internalColor.method_6(workbook_0);
		}
		worksheet_0.method_46(Class1217.smethod_8(byte_0, 10));
	}

	private void method_1()
	{
		class1212_0.Seek(1L);
		Class1733 class1733_ = new Class1733(worksheet_0);
		worksheet_0.method_35(class1733_);
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 141:
				byte_0 = class1218_0.method_0(class1212_0);
				worksheet_0.IsSelected = (byte_0[0] & 1) != 0;
				worksheet_0.Zoom = BitConverter.ToInt32(byte_0, 2);
				break;
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 142:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_2()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		Protection protection = worksheet_0.Protection;
		protection.method_3(BitConverter.ToUInt16(byte_0, 0));
		protection.AllowEditingContent = byte_0[2] == 0;
		protection.AllowEditingObject = byte_0[6] == 0;
	}

	private void method_3()
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

	private void method_4()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		PageSetup pageSetup = worksheet_0.PageSetup;
		if ((byte_0[18] & 2) == 0)
		{
			pageSetup.PaperSize = (PaperSizeType)BitConverter.ToInt32(byte_0, 0);
			pageSetup.method_16(BitConverter.ToInt32(byte_0, 4));
			pageSetup.method_18(BitConverter.ToInt32(byte_0, 8));
			if ((byte_0[18] & 8) == 0)
			{
				pageSetup.Orientation = (((byte_0[18] & 1) == 0) ? PageOrientationType.Portrait : PageOrientationType.Landscape);
			}
		}
		if ((byte_0[18] & 0x10u) != 0)
		{
			pageSetup.FirstPageNumber = BitConverter.ToInt16(byte_0, 16);
			pageSetup.IsAutoFirstPageNumber = false;
		}
		pageSetup.BlackAndWhite = (byte_0[18] & 4) != 0;
		pageSetup.PrintDraft = (byte_0[18] & 0x20) != 0;
	}

	private void method_5()
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
}
