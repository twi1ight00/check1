using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using Aspose.Cells.Pivot;
using Aspose.Cells.Tables;
using ns10;
using ns11;
using ns12;
using ns16;
using ns2;
using ns21;
using ns22;
using ns27;
using ns29;
using ns45;
using ns52;
using ns55;
using ns57;
using ns58;
using ns7;

namespace ns59;

internal class Class1730
{
	private Workbook workbook_0;

	private WorksheetCollection worksheetCollection_0;

	private Cells cells_0;

	private Worksheet worksheet_0;

	private Row row_0;

	private RowCollection rowCollection_0;

	private Hashtable hashtable_0;

	private FileFormatType fileFormatType_0 = FileFormatType.Default;

	private ushort ushort_0;

	private ushort ushort_1;

	private byte[] byte_0;

	private byte[] byte_1;

	private ArrayList arrayList_0;

	private Hashtable hashtable_1 = new Hashtable();

	private ArrayList arrayList_1;

	private ArrayList arrayList_2;

	internal Class1317 class1317_0;

	private Class1317 class1317_1;

	private Hashtable hashtable_2 = new Hashtable();

	private void method_0(int int_0)
	{
		if (row_0 == null)
		{
			row_0 = rowCollection_0.GetRow(int_0, bool_0: false, bool_1: false);
		}
		else if (row_0.int_0 != int_0)
		{
			row_0 = rowCollection_0.GetRow(int_0, bool_0: false, bool_1: false);
		}
	}

	private Cell method_1(int int_0, int int_1)
	{
		if (row_0 == null)
		{
			row_0 = rowCollection_0.GetRow(int_0, bool_0: false, bool_1: false);
		}
		else if (row_0.int_0 != int_0)
		{
			row_0 = rowCollection_0.GetRow(int_0, bool_0: false, bool_1: false);
		}
		return row_0.GetCell(rowCollection_0, int_1, bool_1: false, bool_2: false, bool_3: false, 0);
	}

	[Attribute0(true)]
	internal Class1730(Workbook workbook_1)
	{
		workbook_0 = workbook_1;
		worksheetCollection_0 = workbook_0.Worksheets;
		worksheetCollection_0.Clear();
		byte_0 = new byte[2];
	}

	private void method_2(Class1723 class1723_0)
	{
		ushort_0 = class1723_0.method_2(byte_0);
		if (ushort_0 != 2057)
		{
			throw new Exception("Bad Workbook file format.");
		}
		ushort_1 = class1723_0.method_2(byte_0);
		byte_1 = new byte[ushort_1];
		class1723_0.method_1(byte_1);
		if (byte_1[1] != 6)
		{
			if (byte_1[1] == 5)
			{
				throw new CellsException(ExceptionType.UnsupportedFeature, "This Excel files contains (Excel95 or earlier file format) records.");
			}
			throw new Exception("Bad Workbook file format.");
		}
		fileFormatType_0 = FileFormatType.Default;
	}

	private void method_3(ushort ushort_2, Class1723 class1723_0)
	{
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 == ushort_2)
			{
				break;
			}
			ushort_1 = class1723_0.method_2(byte_0);
			class1723_0.method_3(ushort_1);
		}
	}

	private void method_4(Class1723 class1723_0)
	{
		method_5(class1723_0);
		Class639 @class = new Class639();
		@class.method_3(byte_1);
		worksheetCollection_0.method_55().Add(@class);
		ushort num = BitConverter.ToUInt16(byte_1, 0);
		if (num > worksheetCollection_0.method_41())
		{
			worksheetCollection_0.method_42(num);
		}
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 1054)
			{
				break;
			}
			method_5(class1723_0);
			@class = new Class639();
			@class.method_3(byte_1);
			worksheetCollection_0.method_55().Add(@class);
			num = BitConverter.ToUInt16(byte_1, 0);
			if (num > worksheetCollection_0.method_41())
			{
				worksheetCollection_0.method_42(num);
			}
		}
		class1723_0.method_3(-2);
	}

	internal int method_5(Class1723 class1723_0)
	{
		ushort_1 = class1723_0.method_2(byte_0);
		if (ushort_1 != 0)
		{
			byte_1 = new byte[ushort_1];
			class1723_0.method_1(byte_1);
		}
		else
		{
			byte_1 = null;
		}
		return ushort_1;
	}

	private void method_6(Class1723 class1723_0)
	{
		arrayList_0 = new ArrayList();
		method_5(class1723_0);
		arrayList_0.Add(byte_1);
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 224)
			{
				break;
			}
			method_5(class1723_0);
			arrayList_0.Add(byte_1);
		}
		class1723_0.method_3(-2);
	}

	private void method_7(Class1723 class1723_0)
	{
		try
		{
			string @string;
			if (byte_1[7] == 0)
			{
				byte[] array = new byte[2 * byte_1.Length - 16];
				for (int i = 0; i < byte_1.Length - 8; i++)
				{
					array[2 * i] = byte_1[8 + i];
				}
				@string = Encoding.Unicode.GetString(array);
			}
			else
			{
				@string = Encoding.Unicode.GetString(byte_1, 8, byte_1.Length - 8);
			}
			int num = worksheetCollection_0.method_38(@string);
			hashtable_1.Add(BitConverter.ToInt32(byte_1, 0), num);
			worksheetCollection_0[num].method_27(byte_1[4]);
			switch (byte_1[5])
			{
			case 0:
				worksheetCollection_0[num].Type = SheetType.Worksheet;
				break;
			case 1:
				worksheetCollection_0[num].Type = SheetType.BIFF4Macro;
				break;
			case 2:
				worksheetCollection_0[num].Type = SheetType.Chart;
				break;
			default:
				worksheetCollection_0[num].Type = SheetType.Other;
				break;
			case 6:
				worksheetCollection_0[num].Type = SheetType.VB;
				break;
			}
		}
		catch
		{
			throw new CellsException(ExceptionType.InvalidData, "Incalid sheet name info");
		}
	}

	[Attribute0(true)]
	private void method_8(Class1723 class1723_0)
	{
		ArrayList arrayList = new ArrayList();
		method_5(class1723_0);
		arrayList.Add(byte_1);
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 60)
			{
				break;
			}
			method_5(class1723_0);
			arrayList.Add(byte_1);
		}
		class1723_0.method_3(-2);
		Class1729.smethod_0(arrayList, worksheetCollection_0);
	}

	[Attribute0(true)]
	internal void method_9(Class1723 class1723_0)
	{
		method_2(class1723_0);
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			case 235:
				method_95(class1723_0, worksheetCollection_0.method_84());
				break;
			case 224:
				method_6(class1723_0);
				break;
			case 92:
			case 193:
			case 194:
			case 195:
			case 225:
			case 226:
				method_74(class1723_0, ushort_0);
				if (worksheetCollection_0.method_50().method_1() == null)
				{
					worksheetCollection_0.method_50().method_2(new ArrayList());
				}
				worksheetCollection_0.method_50().method_1().Add(byte_1);
				break;
			case 218:
				method_5(class1723_0);
				worksheetCollection_0.method_9(BitConverter.ToUInt16(byte_1, 0));
				break;
			case 317:
				method_5(class1723_0);
				worksheetCollection_0.method_50().method_3(byte_1);
				break;
			case 252:
				method_8(class1723_0);
				break;
			case 425:
				method_5(class1723_0);
				worksheetCollection_0.method_21().Add(byte_1);
				break;
			case 352:
				method_5(class1723_0);
				if (byte_1[0] != 0 || byte_1[1] != 0)
				{
					worksheetCollection_0.method_15(bool_4: true);
				}
				break;
			case 442:
				method_5(class1723_0);
				if (byte_1[2] == 0)
				{
					worksheetCollection_0.method_16(Class937.smethod_3(byte_1, 3, byte_1.Length - 3));
				}
				else
				{
					worksheetCollection_0.method_16(Encoding.Unicode.GetString(byte_1, 3, byte_1.Length - 3));
				}
				break;
			case 444:
				method_5(class1723_0);
				worksheetCollection_0.method_50().method_6(byte_1);
				break;
			case 445:
				ushort_1 = class1723_0.method_2(byte_0);
				if (ushort_1 != 0)
				{
					class1723_0.method_3(ushort_1);
				}
				worksheetCollection_0.method_20(bool_4: true);
				break;
			case 430:
				method_13(class1723_0);
				break;
			case 431:
				method_5(class1723_0);
				worksheetCollection_0.method_50().method_5(byte_1);
				break;
			case 1054:
				method_4(class1723_0);
				break;
			case 659:
				method_19(class1723_0);
				break;
			case 2173:
				method_99(class1723_0);
				break;
			case 2147:
				method_5(class1723_0);
				worksheetCollection_0.method_50().method_8(byte_1);
				break;
			case 2148:
				method_5(class1723_0);
				worksheetCollection_0.method_50().method_4().Add(byte_1);
				break;
			case 2150:
				method_95(class1723_0, worksheetCollection_0.method_87());
				break;
			case 2196:
				method_26(class1723_0);
				break;
			default:
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
				break;
			case 2198:
				method_10(class1723_0);
				break;
			case 2188:
				method_5(class1723_0);
				worksheetCollection_0.Workbook.Settings.CheckComptiliblity = byte_1[12] == 0;
				break;
			case 2189:
				method_103(class1723_0);
				break;
			case 2190:
				method_20(class1723_0);
				break;
			case 18:
				method_5(class1723_0);
				worksheetCollection_0.method_80(ushort_1 != 0 && byte_1[0] == 1);
				break;
			case 19:
				method_5(class1723_0);
				worksheetCollection_0.method_82(BitConverter.ToUInt16(byte_1, 0));
				break;
			case 23:
				method_12(class1723_0);
				break;
			case 24:
				method_27(class1723_0);
				break;
			case 25:
				method_5(class1723_0);
				worksheetCollection_0.method_78(byte_1[0] == 1);
				break;
			case 14:
				method_5(class1723_0);
				if (byte_1[0] == 0)
				{
					worksheetCollection_0.Workbook.Settings.PrecisionAsDisplayed = true;
				}
				break;
			case 47:
			{
				ushort_1 = class1723_0.method_2(byte_0);
				byte_1 = new byte[ushort_1];
				class1723_0.method_1(byte_1);
				if (byte_1[0] == 0 && byte_1[1] == 0)
				{
					string string_ = workbook_0.Settings.Password;
					if (workbook_0.Settings.Password == null || workbook_0.Settings.Password == "")
					{
						string_ = "VelvetSweatshop";
					}
					ushort num2 = BitConverter.ToUInt16(byte_1, 2);
					ushort num3 = BitConverter.ToUInt16(byte_1, 4);
					if (Class1637.smethod_0(string_, num3, num2))
					{
						method_89(class1723_0.memoryStream_0, class1317_1, new Class1637(string_));
						break;
					}
					throw new CellsException(ExceptionType.IncorrectPassword, "Invalid password.");
				}
				if (byte_1[4] == 1)
				{
					byte[] array = new byte[16];
					byte[] array2 = new byte[16];
					byte[] array3 = new byte[16];
					Array.Copy(byte_1, 6, array, 0, 16);
					Array.Copy(byte_1, 22, array2, 0, 16);
					Array.Copy(byte_1, 38, array3, 0, 16);
					try
					{
						Class1647 @class = null;
						@class = ((workbook_0.Settings.Password == null || workbook_0.Settings.Password == "") ? new Class1647("VelvetSweatshop", array, array2, array3) : new Class1647(workbook_0.Settings.Password, array, array2, array3));
						worksheetCollection_0.method_29(@class);
						method_90(class1723_0.memoryStream_0, class1317_1, @class);
					}
					catch
					{
						if (workbook_0.Settings.Password != null && !(workbook_0.Settings.Password == ""))
						{
							throw new CellsException(ExceptionType.IncorrectPassword, "Invalid password.");
						}
						throw new CellsException(ExceptionType.IncorrectPassword, "Please provide password for the Workbook file.");
					}
					break;
				}
				int num4 = BitConverter.ToInt32(byte_1, 10);
				int num5 = 10;
				uint uint_ = BitConverter.ToUInt32(byte_1, 10 + 12);
				uint uint_2 = BitConverter.ToUInt32(byte_1, 10 + 16);
				uint num6 = BitConverter.ToUInt32(byte_1, 10 + 20);
				uint uint_3 = BitConverter.ToUInt32(byte_1, 10 + 24);
				string @string = Encoding.Unicode.GetString(byte_1, 10 + 36, num4 - 34);
				num5 = 14 + num4;
				num4 = BitConverter.ToInt32(byte_1, num5);
				num5 += 4;
				byte[] array4 = new byte[num4];
				byte[] array5 = new byte[num4];
				Array.Copy(byte_1, num5, array4, 0, num4);
				num5 += num4;
				Array.Copy(byte_1, num5, array5, 0, num4);
				num5 += num4;
				num4 = BitConverter.ToInt32(byte_1, num5);
				byte[] array6 = new byte[num4];
				num5 += 4;
				Array.Copy(byte_1, num5, array6, 0, num4);
				num5 += num4;
				try
				{
					Class1638 class2 = null;
					class2 = ((workbook_0.Settings.Password == null || workbook_0.Settings.Password == "") ? new Class1638("VelvetSweatshop", array4, @string, uint_3, 0u, uint_2, uint_, num6) : new Class1638(workbook_0.Settings.Password, array4, @string, uint_3, 0u, uint_2, uint_, num6));
					if (!class2.method_2(array5, array6))
					{
						throw new CellsException(ExceptionType.IncorrectPassword, "Invalid password.");
					}
					method_91(class1723_0.memoryStream_0, class1317_1, class2);
					worksheetCollection_0.Workbook.method_13(EncryptionType.StrongCryptographicProvider);
					worksheetCollection_0.Workbook.method_15((int)num6);
				}
				catch
				{
					if (workbook_0.Settings.Password != null && !(workbook_0.Settings.Password == ""))
					{
						throw new CellsException(ExceptionType.IncorrectPassword, "Invalid password.");
					}
					throw new CellsException(ExceptionType.IncorrectPassword, "Please provide password for the Workbook file.");
				}
				break;
			}
			case 49:
				method_23(class1723_0);
				break;
			case 34:
				method_5(class1723_0);
				if (byte_1 != null && byte_1[0] != 0)
				{
					worksheetCollection_0.Workbook.Settings.Date1904 = true;
				}
				break;
			case 66:
				method_5(class1723_0);
				worksheetCollection_0.Workbook.Settings.short_0 = BitConverter.ToInt16(byte_1, 0);
				break;
			case 61:
				method_25(class1723_0);
				break;
			case 140:
				method_38(class1723_0);
				break;
			case 141:
				method_5(class1723_0);
				switch (byte_1[0])
				{
				case 0:
					worksheetCollection_0.Workbook.Settings.DisplayDrawingObjects = DisplayDrawingObjects.DisplayShapes;
					break;
				case 1:
					worksheetCollection_0.Workbook.Settings.DisplayDrawingObjects = DisplayDrawingObjects.Placeholders;
					break;
				case 2:
					worksheetCollection_0.Workbook.Settings.DisplayDrawingObjects = DisplayDrawingObjects.Hide;
					break;
				}
				break;
			case 133:
				method_17(class1723_0);
				break;
			case 134:
				method_5(class1723_0);
				worksheetCollection_0.Workbook.Settings.IsWriteProtected = true;
				break;
			case 91:
				method_5(class1723_0);
				worksheetCollection_0.Workbook.Settings.RecommendReadOnly = byte_1[0] == 1;
				worksheetCollection_0.Workbook.Settings.method_5(BitConverter.ToUInt16(byte_1, 2));
				break;
			case 156:
				method_5(class1723_0);
				worksheetCollection_0.method_50().method_0(BitConverter.ToUInt16(byte_1, 0));
				break;
			case 146:
				method_16(class1723_0);
				break;
			case 211:
				ushort_1 = class1723_0.method_2(byte_0);
				if (ushort_1 != 0)
				{
					class1723_0.method_3(ushort_1);
				}
				worksheetCollection_0.method_18(bool_4: true);
				break;
			case 213:
				method_11(class1723_0);
				break;
			case 10:
			{
				class1723_0.method_3(2);
				int num = ((worksheetCollection_0.method_72() * 8 + worksheetCollection_0.method_73()) / 8 + 1) * 8;
				double width = (double)(num - worksheetCollection_0.method_73()) / (double)worksheetCollection_0.method_72();
				for (int i = 0; i < worksheetCollection_0.Count; i++)
				{
					Cells cells = worksheetCollection_0[i].Cells;
					cells.Columns.Width = width;
				}
				Class1129.smethod_1();
				return;
			}
			}
		}
	}

	private void method_10(Class1723 class1723_0)
	{
		method_5(class1723_0);
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(byte_1, 16, ushort_1 - 16);
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 2175)
			{
				break;
			}
			method_5(class1723_0);
			memoryStream.Write(byte_1, 12, ushort_1 - 12);
		}
		class1723_0.method_3(-2);
		if (memoryStream.Length == 0)
		{
			return;
		}
		try
		{
			memoryStream.Position = 0L;
			Class746 @class = Class746.Read(memoryStream);
			string text = "theme/theme/theme1.xml";
			if (@class.method_40(text, bool_18: true) != -1)
			{
				Class744 class744_ = @class.method_38(text);
				Stream stream = @class.method_39(class744_);
				XmlDocument xmlDocument_ = Class1188.smethod_2(stream);
				stream.Close();
				Class1612 class2 = new Class1612(worksheetCollection_0.Workbook, text);
				class2.Read(xmlDocument_);
			}
			@class.Close();
		}
		catch
		{
		}
	}

	private void method_11(Class1723 class1723_0)
	{
		Class1141 @class = null;
		while (ushort_0 != 352 && ushort_0 != 133)
		{
			method_74(class1723_0, ushort_0);
			switch (ushort_0)
			{
			case 227:
			{
				int int_ = BitConverter.ToUInt16(byte_1, 4);
				@class.pivotTableSourceType_0 = Class1673.smethod_0(int_);
				break;
			}
			case 213:
				@class = new Class1141(worksheetCollection_0.method_89());
				worksheetCollection_0.method_89().method_1(@class);
				worksheetCollection_0.method_89().int_1++;
				@class.arrayList_2 = new ArrayList();
				@class.int_6 = BitConverter.ToUInt16(byte_1, 4);
				if (@class.int_6 > worksheetCollection_0.method_89().int_0)
				{
					worksheetCollection_0.method_89().int_0 = @class.int_6;
				}
				break;
			}
			@class.arrayList_2.Add(byte_1);
			ushort_0 = class1723_0.method_2(byte_0);
		}
		class1723_0.method_3(-2);
	}

	private void method_12(Class1723 class1723_0)
	{
		Class1303 @class = worksheetCollection_0.method_39();
		bool flag = false;
		for (int i = 0; i < @class.Count; i++)
		{
			Class1718 class2 = @class[i];
			if (class2.method_12())
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			Class1718 class1718_ = new Class1718(Enum194.const_1);
			worksheetCollection_0.method_37(@class.Count);
			@class.Add(class1718_);
		}
		method_5(class1723_0);
		ushort num = BitConverter.ToUInt16(byte_1, 0);
		worksheetCollection_0.method_32().Clear();
		if (num * 6 + 2 > 8224)
		{
			int num2 = (byte_1.Length - 2) / 6;
			for (int j = 0; j < num2; j++)
			{
				ushort num3 = BitConverter.ToUInt16(byte_1, 6 * j + 2);
				ushort num4 = BitConverter.ToUInt16(byte_1, 6 * j + 4);
				ushort ushort_ = BitConverter.ToUInt16(byte_1, 6 * j + 6);
				worksheetCollection_0.method_32().method_3(num3, num4, ushort_);
			}
			while (true)
			{
				ushort_0 = class1723_0.method_2(byte_0);
				if (ushort_0 != 60)
				{
					break;
				}
				method_5(class1723_0);
				num2 = byte_1.Length / 6;
				for (int k = 0; k < num2; k++)
				{
					ushort num5 = BitConverter.ToUInt16(byte_1, 6 * k);
					ushort num6 = BitConverter.ToUInt16(byte_1, 6 * k + 2);
					ushort ushort_2 = BitConverter.ToUInt16(byte_1, 6 * k + 4);
					worksheetCollection_0.method_32().method_3(num5, num6, ushort_2);
				}
			}
			class1723_0.method_3(-2);
		}
		else
		{
			for (int l = 0; l < num; l++)
			{
				ushort num7 = BitConverter.ToUInt16(byte_1, 6 * l + 2);
				ushort num8 = BitConverter.ToUInt16(byte_1, 6 * l + 4);
				ushort ushort_3 = BitConverter.ToUInt16(byte_1, 6 * l + 6);
				worksheetCollection_0.method_32().method_3(num7, num8, ushort_3);
			}
		}
	}

	private void method_13(Class1723 class1723_0)
	{
		method_5(class1723_0);
		if (worksheetCollection_0.method_39() == null)
		{
			worksheetCollection_0.method_40(new Class1303());
		}
		Class1718 @class = new Class1718();
		if (byte_1.Length == 4)
		{
			if (byte_1[2] == 1 && byte_1[3] == 4)
			{
				@class.Type = Enum194.const_1;
				worksheetCollection_0.method_37(worksheetCollection_0.method_39().Count);
			}
			else if (byte_1[0] == 1 && byte_1[2] == 1 && byte_1[3] == 58)
			{
				@class.Type = Enum194.const_2;
			}
		}
		else
		{
			int num = BitConverter.ToUInt16(byte_1, 0);
			@class.Type = ((num == 0) ? Enum194.const_3 : Enum194.const_0);
			int num2 = 2;
			int num3 = BitConverter.ToUInt16(byte_1, 2);
			if (byte_1[2 + 2] == 1)
			{
				@class.method_17(Encoding.Unicode.GetString(byte_1, num2 + 3, num3 * 2));
				num2 += 3 + num3 * 2;
			}
			else
			{
				byte[] array = new byte[2 * num3];
				for (int i = 0; i < num3; i++)
				{
					array[2 * i] = byte_1[num2 + 3 + i];
				}
				@class.method_17(Encoding.Unicode.GetString(array, 0, array.Length));
				num2 += 3 + num3;
			}
			if (num != 0)
			{
				string[] array2 = new string[num];
				for (int j = 0; j < num; j++)
				{
					num3 = BitConverter.ToUInt16(byte_1, num2);
					if (byte_1[num2 + 2] == 1)
					{
						array2[j] = Encoding.Unicode.GetString(byte_1, num2 + 3, num3 * 2);
						num2 += 3 + num3 * 2;
					}
					else
					{
						byte[] array3 = new byte[2 * num3];
						for (int k = 0; k < num3; k++)
						{
							array3[2 * k] = byte_1[num2 + 3 + k];
						}
						array2[j] = Encoding.Unicode.GetString(array3, 0, array3.Length);
						num2 += 3 + num3;
					}
					if (num2 >= ushort_1 && j != num - 1)
					{
						ushort_0 = class1723_0.method_2(byte_0);
						if (ushort_0 != 60)
						{
							class1723_0.method_3(-2);
							break;
						}
						method_5(class1723_0);
						num2 = 0;
					}
				}
				@class.method_5(array2);
			}
		}
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 35)
			{
				break;
			}
			method_5(class1723_0);
			Class1653 class2 = new Class1653(@class);
			class2.method_11(BitConverter.ToUInt16(byte_1, 0));
			class2.method_2(BitConverter.ToInt32(byte_1, 2));
			int num4 = 8;
			if (class2.method_14())
			{
				class2.int_1 = byte_1[num4];
				switch (byte_1[num4])
				{
				case 0:
					class2.Name = "CONSOLIDATE_AREA";
					break;
				case 1:
					class2.Name = "AUTO_OPEN";
					break;
				case 2:
					class2.Name = "AUTO_CLOSE";
					break;
				case 3:
					class2.Name = "EXTRACT";
					break;
				case 4:
					class2.Name = "DATABASE";
					break;
				case 5:
					class2.Name = "CRITERIA";
					break;
				case 6:
					class2.Name = "PRINT_AREA";
					break;
				case 7:
					class2.Name = "PRINT_TITLES";
					break;
				case 8:
					class2.Name = "RECORDER";
					break;
				case 9:
					class2.Name = "DATA_FORM";
					break;
				case 10:
					class2.Name = "AUTO_ACTIVATE";
					break;
				case 11:
					class2.Name = "AUTO_DEACTIVATE";
					break;
				case 12:
					class2.Name = "SHEET_TITLE";
					break;
				case 13:
					class2.Name = "_FILTERDATABASE";
					break;
				}
				num4++;
			}
			else if (byte_1[7] == 0)
			{
				int num5 = byte_1[6];
				byte[] array4 = new byte[2 * num5];
				for (int l = 0; l < num5; l++)
				{
					array4[2 * l] = byte_1[8 + l];
				}
				class2.Name = Encoding.Unicode.GetString(array4, 0, array4.Length);
				num4 += byte_1[6];
			}
			else
			{
				class2.Name = Encoding.Unicode.GetString(byte_1, 8, byte_1[6] * 2);
				num4 += byte_1[6] * 2;
			}
			if (byte_1.Length - num4 > 0)
			{
				byte[] array5 = new byte[byte_1.Length - num4];
				Array.Copy(byte_1, num4, array5, 0, array5.Length);
				class2.method_13(array5);
			}
			if (@class.Type == Enum194.const_3 && @class.method_0().Count == 0 && byte_1.Length == 9)
			{
				@class.Type = Enum194.const_4;
			}
			@class.method_0().Add(class2);
		}
		class1723_0.method_3(-2);
		worksheetCollection_0.method_39().Add(@class);
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 89)
			{
				break;
			}
			method_14(class1723_0, @class);
		}
		class1723_0.method_3(-2);
	}

	private void method_14(Class1723 class1723_0, Class1718 class1718_0)
	{
		method_5(class1723_0);
		int num = BitConverter.ToUInt16(byte_1, 0);
		int int_ = BitConverter.ToUInt16(byte_1, 2);
		if (num == 0)
		{
			return;
		}
		Class1373 @class = class1718_0.method_9(int_);
		int num2 = 0;
		while (true)
		{
			if (num2 >= num)
			{
				return;
			}
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 90 && ushort_0 != 60)
			{
				break;
			}
			method_5(class1723_0);
			int num3 = byte_1[1];
			int num4 = byte_1[0];
			int int_2 = BitConverter.ToUInt16(byte_1, 2);
			Class1117 row = @class.GetRow(int_2);
			int num5 = 4;
			int int_3 = -1;
			for (int i = num3; i <= num4; i++)
			{
				if (num5 >= byte_1.Length)
				{
					ushort_0 = class1723_0.method_2(byte_0);
					if (ushort_0 != 60)
					{
						class1723_0.method_3(-2);
						break;
					}
					method_5(class1723_0);
					num5 = 0;
				}
				if (byte_1[num5] != 2 && num5 + 9 > byte_1.Length)
				{
					byte[] array = byte_1;
					ushort_0 = class1723_0.method_2(byte_0);
					if (ushort_0 != 60)
					{
						class1723_0.method_3(-2);
						break;
					}
					method_5(class1723_0);
					byte[] array2 = byte_1;
					byte_1 = new byte[byte_1.Length + array.Length - num5];
					Array.Copy(array, num5, byte_1, 0, array.Length - num5);
					Array.Copy(array2, array.Length - num5, byte_1, 0, array2.Length);
					num5 = 0;
				}
				switch (byte_1[num5])
				{
				case 16:
					row.method_15(int_3, i, Enum179.const_3, byte_1, num5 + 1);
					num5 += 9;
					break;
				case 0:
					num5 += 9;
					break;
				case 1:
					row.method_15(int_3, i, Enum179.const_1, byte_1, num5 + 1);
					num5 += 9;
					break;
				case 2:
				{
					row.method_15(int_3, i, Enum179.const_2, byte_1, num5 + 1);
					int num6 = BitConverter.ToUInt16(byte_1, num5 + 1);
					num5 = ((byte_1[num5 + 3] != 0) ? (num5 + (4 + num6 * 2)) : (num5 + (4 + num6)));
					break;
				}
				case 4:
					row.method_15(int_3, i, Enum179.const_4, byte_1, num5 + 1);
					num5 += 9;
					break;
				default:
					return;
				}
				int_3 = i;
			}
			num2++;
		}
		class1723_0.method_3(-2);
	}

	private void method_15(Class1723 class1723_0)
	{
		method_5(class1723_0);
		int num = BitConverter.ToInt32(byte_1, 16);
		if (num <= 65)
		{
			worksheet_0.method_40(BitConverter.ToInt32(byte_1, 16));
		}
		if (ushort_1 == 40)
		{
			worksheet_0.internalColor_0 = method_80(byte_1, 24);
		}
	}

	private void method_16(Class1723 class1723_0)
	{
		method_5(class1723_0);
		ushort num = BitConverter.ToUInt16(byte_1, 0);
		for (int i = 0; i < num; i++)
		{
			int int_ = BitConverter.ToInt32(byte_1, 4 * i + 2);
			worksheetCollection_0.method_24().SetColor(int_, i + 8);
		}
	}

	private void method_17(Class1723 class1723_0)
	{
		if (arrayList_2 != null || arrayList_0 != null)
		{
			if (arrayList_2 != null)
			{
				for (int i = 0; i < arrayList_2.Count; i++)
				{
					byte[] byte_ = (byte[])arrayList_2[i];
					method_24(byte_);
				}
			}
			else
			{
				worksheetCollection_0.method_58().method_8();
			}
			arrayList_2 = null;
			for (int j = 0; j < arrayList_0.Count; j++)
			{
				byte[] array = (byte[])arrayList_0[j];
				Style style = new Style(worksheetCollection_0);
				style.GetStyle(array);
				worksheetCollection_0.method_58().method_0(style);
				if (hashtable_2 != null && hashtable_2[j] != null && ((Class1685)hashtable_2[j]).method_2(style) && j == 15)
				{
					worksheetCollection_0.method_52()[0] = style.Font;
				}
			}
			if (arrayList_1 != null)
			{
				for (int k = 0; k < arrayList_1.Count; k++)
				{
					byte[] byte_2 = (byte[])arrayList_1[k];
					method_18(byte_2);
				}
			}
			worksheetCollection_0.method_74();
			arrayList_0 = null;
		}
		method_5(class1723_0);
		method_7(class1723_0);
	}

	private void method_18(byte[] byte_2)
	{
		int num = BitConverter.ToUInt16(byte_2, 0);
		int num2 = num & 0x8000;
		num &= 0xFFF;
		string text = "";
		if (num2 == 0)
		{
			if (byte_2[2] == 0)
			{
				return;
			}
			if (byte_2[4] == 0)
			{
				byte[] array = new byte[2 * byte_2.Length - 10];
				for (int i = 0; i < byte_2.Length - 5; i++)
				{
					array[2 * i] = byte_2[i + 5];
				}
				text = Encoding.Unicode.GetString(array);
			}
			else
			{
				text = Encoding.Unicode.GetString(byte_2, 5, byte_2.Length - 5);
			}
		}
		else
		{
			switch (byte_2[2])
			{
			case 0:
				text = "Normal";
				break;
			case 1:
				text = "RowLevel_" + byte_2[3];
				break;
			case 2:
				text = "ColLevel_" + byte_2[3];
				break;
			case 3:
				text = "Comma";
				break;
			case 4:
				text = "Currency";
				break;
			case 5:
				text = "Percent";
				break;
			case 6:
				text = "Comma [0]";
				break;
			case 7:
				text = "Currency [0]";
				break;
			case 8:
				text = "Hyperlink";
				break;
			case 9:
				text = "Followed Hyperlink";
				break;
			}
		}
		if (text != null && text != "")
		{
			Style style = worksheetCollection_0.method_58()[num];
			worksheetCollection_0.Styles.Add(style);
			style.method_3(text);
		}
	}

	private void method_19(Class1723 class1723_0)
	{
		method_5(class1723_0);
		if (arrayList_1 == null)
		{
			arrayList_1 = new ArrayList();
		}
		arrayList_1.Add(byte_1);
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 659)
			{
				break;
			}
			method_5(class1723_0);
			arrayList_1.Add(byte_1);
		}
		class1723_0.method_3(-2);
	}

	private void method_20(Class1723 class1723_0)
	{
		method_5(class1723_0);
		TableStyleCollection tableStyles = worksheetCollection_0.TableStyles;
		int num = BitConverter.ToUInt16(byte_1, 16);
		int num2 = BitConverter.ToUInt16(byte_1, 18);
		int num3 = 20;
		tableStyles.method_1(Encoding.Unicode.GetString(byte_1, 20, num * 2));
		if (tableStyles.method_0() != null)
		{
			num3 += num * 2;
		}
		tableStyles.method_3(Encoding.Unicode.GetString(byte_1, num3, num2 * 2));
		ushort_0 = class1723_0.method_2(byte_0);
		ushort num4 = ushort_0;
		if (num4 == 2191)
		{
			method_21(class1723_0);
		}
		else
		{
			class1723_0.method_3(-2);
		}
	}

	private void method_21(Class1723 class1723_0)
	{
		method_5(class1723_0);
		TableStyle tableStyle = null;
		int num = BitConverter.ToUInt16(byte_1, 18);
		string @string = Encoding.Unicode.GetString(byte_1, 20, num * 2);
		int index = worksheetCollection_0.TableStyles.Add(@string);
		tableStyle = worksheetCollection_0.TableStyles[index];
		tableStyle.method_3(((byte_1[12] & 2u) != 0) ? true : false);
		tableStyle.method_5(((byte_1[12] & 4u) != 0) ? true : false);
		TableStyleElementCollection tableStyleElementCollection_ = new TableStyleElementCollection(tableStyle);
		tableStyle.method_1(tableStyleElementCollection_);
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			ushort num2 = ushort_0;
			if (num2 != 2192)
			{
				break;
			}
			method_22(tableStyle, class1723_0);
		}
		class1723_0.method_3(-2);
	}

	private void method_22(TableStyle tableStyle_0, Class1723 class1723_0)
	{
		method_5(class1723_0);
		int int_ = BitConverter.ToInt32(byte_1, 12);
		int size = BitConverter.ToInt32(byte_1, 16);
		int int_2 = BitConverter.ToInt32(byte_1, 20);
		try
		{
			TableStyleElement tableStyleElement = new TableStyleElement(tableStyle_0.TableStyleElements, Class1224.smethod_30(int_));
			tableStyleElement.Size = size;
			tableStyleElement.int_1 = int_2;
			tableStyle_0.TableStyleElements.Add(tableStyleElement);
		}
		catch
		{
		}
	}

	private void method_23(Class1723 class1723_0)
	{
		arrayList_2 = new ArrayList();
		method_5(class1723_0);
		arrayList_2.Add(byte_1);
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 49)
			{
				break;
			}
			method_5(class1723_0);
			arrayList_2.Add(byte_1);
		}
		class1723_0.method_3(-2);
	}

	private void method_24(byte[] byte_2)
	{
		Aspose.Cells.Font font = new Aspose.Cells.Font(worksheetCollection_0, null, bool_0: false);
		font.method_28(byte_2);
		if (worksheetCollection_0.method_52().Count > 3)
		{
			font.method_22(worksheetCollection_0.method_52().Count + 1);
		}
		else
		{
			font.method_22(worksheetCollection_0.method_52().Count);
		}
		worksheetCollection_0.method_52().Add(font);
	}

	private void method_25(Class1723 class1723_0)
	{
		method_5(class1723_0);
		worksheetCollection_0.Workbook.Settings.method_13(BitConverter.ToUInt16(byte_1, 0));
		worksheetCollection_0.Workbook.Settings.method_15(BitConverter.ToUInt16(byte_1, 2));
		worksheetCollection_0.Workbook.Settings.method_17(BitConverter.ToUInt16(byte_1, 4));
		worksheetCollection_0.Workbook.Settings.method_19(BitConverter.ToUInt16(byte_1, 6));
		byte b = byte_1[8];
		byte b2 = (byte)(b & 1u);
		worksheetCollection_0.Workbook.Settings.IsHidden = b2 != 0;
		b2 = (byte)(b & 2u);
		worksheetCollection_0.Workbook.Settings.IsMinimized = b2 != 0;
		if ((byte)(b & 8) == 0)
		{
			worksheetCollection_0.Workbook.Settings.IsHScrollBarVisible = false;
		}
		else
		{
			worksheetCollection_0.Workbook.Settings.IsHScrollBarVisible = true;
		}
		if ((byte)(b & 0x10) == 0)
		{
			worksheetCollection_0.Workbook.Settings.IsVScrollBarVisible = false;
		}
		else
		{
			worksheetCollection_0.Workbook.Settings.IsVScrollBarVisible = true;
		}
		if ((byte)(b & 0x20) == 0)
		{
			worksheetCollection_0.Workbook.Settings.ShowTabs = false;
		}
		else
		{
			worksheetCollection_0.Workbook.Settings.ShowTabs = true;
		}
		worksheetCollection_0.method_34(BitConverter.ToUInt16(byte_1, 10));
		worksheetCollection_0.FirstVisibleTab = BitConverter.ToUInt16(byte_1, 12);
		worksheetCollection_0.Workbook.Settings.SheetTabBarWidth = BitConverter.ToUInt16(byte_1, 16);
	}

	private void method_26(Class1723 class1723_0)
	{
		method_5(class1723_0);
		Name name = null;
		if (worksheetCollection_0.Names.Count <= 0)
		{
			return;
		}
		name = worksheetCollection_0.Names[worksheetCollection_0.Names.Count - 1];
		int num = BitConverter.ToUInt16(byte_1, 12);
		int num2 = BitConverter.ToUInt16(byte_1, 14);
		if (num2 != 0)
		{
			int num3 = 0;
			num3 = ((byte_1[16] != 0) ? (17 + num * 2) : (17 + num));
			if (byte_1[num3] == 0)
			{
				name.Comment = Encoding.ASCII.GetString(byte_1, num3 + 1, num2);
			}
			else
			{
				name.Comment = Encoding.Unicode.GetString(byte_1, num3 + 1, num2 * 2);
			}
		}
	}

	private void method_27(Class1723 class1723_0)
	{
		method_5(class1723_0);
		method_28();
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 24)
			{
				break;
			}
			method_5(class1723_0);
			method_28();
		}
		class1723_0.method_3(-2);
	}

	private void method_28()
	{
		Name name = new Name(worksheetCollection_0);
		name.method_27(byte_1);
		worksheetCollection_0.Names.method_3(name, bool_0: false);
		string first;
		string second;
		switch (name.Text)
		{
		case "PRINT_TITLES":
			if (name.SheetIndex > 0 && !name.IsHidden && worksheetCollection_0[name.SheetIndex - 1].PageSetup.PrintTitleRows == null && worksheetCollection_0[name.SheetIndex - 1].PageSetup.PrintTitleColumns == null)
			{
				Class1279.smethod_3(name, isPrintArea: false, out first, out second);
				worksheetCollection_0[name.SheetIndex - 1].PageSetup.PrintTitleRows = first;
				worksheetCollection_0[name.SheetIndex - 1].PageSetup.PrintTitleColumns = second;
				worksheetCollection_0[name.SheetIndex - 1].PageSetup.method_3(bool_14: false);
			}
			break;
		case "PRINT_AREA":
			if (name.SheetIndex > 0 && !name.IsHidden && worksheetCollection_0[name.SheetIndex - 1].PageSetup.PrintArea == null)
			{
				Class1279.smethod_3(name, isPrintArea: true, out first, out second);
				worksheetCollection_0[name.SheetIndex - 1].PageSetup.PrintArea = first;
				worksheetCollection_0[name.SheetIndex - 1].PageSetup.method_30(bool_14: false);
			}
			break;
		}
	}

	private void method_29(Class1723 class1723_0)
	{
		method_5(class1723_0);
		ushort num = BitConverter.ToUInt16(byte_1, 0);
		for (int i = 0; i < num; i++)
		{
			int int_ = BitConverter.ToUInt16(byte_1, 6 * i + 2);
			int num2 = BitConverter.ToUInt16(byte_1, 6 * i + 4);
			int num3 = BitConverter.ToUInt16(byte_1, 6 * i + 6);
			if (num3 < num2)
			{
				int num4 = num2;
				num2 = num3;
				num3 = num4;
			}
			HorizontalPageBreakCollection hPageBreaks = cells_0.HPageBreaks;
			hPageBreaks.method_0(int_, num2, num3);
		}
	}

	private void method_30(Class1723 class1723_0)
	{
		method_5(class1723_0);
		ushort num = BitConverter.ToUInt16(byte_1, 0);
		for (int i = 0; i < num; i++)
		{
			int int_ = BitConverter.ToUInt16(byte_1, 6 * i + 2);
			int num2 = BitConverter.ToUInt16(byte_1, 6 * i + 4);
			int num3 = BitConverter.ToUInt16(byte_1, 6 * i + 6);
			if (num3 < num2)
			{
				int num4 = num2;
				num2 = num3;
				num3 = num4;
			}
			VerticalPageBreakCollection vPageBreaks = cells_0.VPageBreaks;
			vPageBreaks.method_0(num2, num3, int_);
		}
	}

	private void method_31(Class1723 class1723_0)
	{
		method_5(class1723_0);
		ushort int_ = BitConverter.ToUInt16(byte_1, 0);
		ushort int_2 = BitConverter.ToUInt16(byte_1, 2);
		ushort int_3 = BitConverter.ToUInt16(byte_1, 4);
		Cell cell = method_1(int_, int_2);
		cell.method_37(int_3);
		cell.SetFormula(byte_1, fileFormatType_0);
		ushort_0 = class1723_0.method_2(byte_0);
		switch (ushort_0)
		{
		case 545:
			method_33(cell, class1723_0);
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 == 519)
			{
				string object_ = method_32(class1723_0);
				cell.method_65(object_);
			}
			else
			{
				class1723_0.method_3(-2);
			}
			break;
		case 519:
		{
			string object_ = method_32(class1723_0);
			cell.method_65(object_);
			break;
		}
		default:
			class1723_0.method_3(-2);
			break;
		case 1212:
			method_35(cell, class1723_0);
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			default:
				class1723_0.method_3(-2);
				break;
			case 545:
				method_33(cell, class1723_0);
				break;
			case 519:
			{
				string object_ = method_32(class1723_0);
				cell.method_65(object_);
				break;
			}
			}
			break;
		case 566:
			method_34(cell, class1723_0);
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 == 519)
			{
				method_5(class1723_0);
				string object_ = ((byte_1[2] != 0) ? Encoding.Unicode.GetString(byte_1, 3, byte_1.Length - 3) : Encoding.ASCII.GetString(byte_1, 3, byte_1.Length - 3));
				cell.method_65(object_);
			}
			else
			{
				class1723_0.method_3(-2);
			}
			break;
		}
	}

	internal string method_32(Class1723 class1723_0)
	{
		method_5(class1723_0);
		int num = BitConverter.ToUInt16(byte_1, 0);
		bool flag = (byte_1[2] & 1) == 0;
		bool flag2 = (byte_1[2] & 4) != 0;
		bool flag3 = (byte_1[2] & 8) != 0;
		int num2 = 3 + (flag3 ? 2 : 0) + (flag2 ? 4 : 0);
		int num3 = (ushort_1 - num2) / (flag ? 1 : 2);
		string text = Class937.smethod_0(byte_1, num2, flag, num3);
		num -= num3;
		while (true)
		{
			if (num > 0)
			{
				ushort_0 = class1723_0.method_2(byte_0);
				if (ushort_0 != 60 && ushort_0 != 519)
				{
					break;
				}
				method_5(class1723_0);
				flag = (byte_1[0] & 1) == 0;
				num2 = 1;
				num3 = (ushort_1 - 1) / (flag ? 1 : 2);
				text += Class937.smethod_0(byte_1, num2, flag, num3);
				num -= num3;
				continue;
			}
			return text;
		}
		class1723_0.method_3(-2);
		return text;
	}

	private void method_33(Cell cell_0, Class1723 class1723_0)
	{
		method_5(class1723_0);
		CellArea cellArea_ = default(CellArea);
		cellArea_.StartRow = BitConverter.ToUInt16(byte_1, 0);
		cellArea_.EndRow = BitConverter.ToUInt16(byte_1, 2);
		cellArea_.StartColumn = byte_1[4];
		cellArea_.EndColumn = byte_1[5];
		byte[] array = new byte[ushort_1 - 12];
		Array.Copy(byte_1, 12, array, 0, array.Length);
		cell_0.method_51(new Class1348(cellArea_, bool_0: true, array));
		cell_0.method_17().method_8(bool_0: true);
	}

	private void method_34(Cell cell_0, Class1723 class1723_0)
	{
		method_5(class1723_0);
		Class1119 @class = new Class1119();
		CellArea cellArea_ = default(CellArea);
		cellArea_.StartRow = BitConverter.ToUInt16(byte_1, 0);
		cellArea_.EndRow = BitConverter.ToUInt16(byte_1, 2);
		cellArea_.StartColumn = byte_1[4];
		cellArea_.EndColumn = byte_1[5];
		@class.cellArea_0 = cellArea_;
		@class.method_1(byte_1[6]);
		if (@class.method_7())
		{
			@class.int_0 = BitConverter.ToUInt16(byte_1, 8);
			@class.int_1 = BitConverter.ToUInt16(byte_1, 10);
			@class.int_2 = BitConverter.ToUInt16(byte_1, 12);
			@class.int_3 = BitConverter.ToUInt16(byte_1, 14);
		}
		else if (@class.method_11())
		{
			@class.int_2 = BitConverter.ToUInt16(byte_1, 8);
			@class.int_3 = BitConverter.ToUInt16(byte_1, 10);
		}
		else
		{
			@class.int_0 = BitConverter.ToUInt16(byte_1, 8);
			@class.int_1 = BitConverter.ToUInt16(byte_1, 10);
		}
		cell_0.method_53(@class);
	}

	private void method_35(Cell cell_0, Class1723 class1723_0)
	{
		method_5(class1723_0);
		CellArea cellArea_ = default(CellArea);
		cellArea_.StartRow = BitConverter.ToUInt16(byte_1, 0);
		cellArea_.EndRow = BitConverter.ToUInt16(byte_1, 2);
		cellArea_.StartColumn = byte_1[4];
		cellArea_.EndColumn = byte_1[5];
		byte[] array = new byte[ushort_1 - 8];
		Array.Copy(byte_1, 8, array, 0, array.Length);
		cell_0.method_51(new Class1348(cellArea_, bool_0: false, array));
	}

	private void method_36(Class1723 class1723_0)
	{
		method_5(class1723_0);
		ushort int_ = BitConverter.ToUInt16(byte_1, 0);
		byte int_2 = byte_1[2];
		ushort int_3 = BitConverter.ToUInt16(byte_1, 4);
		byte b = byte_1[6];
		byte b2 = byte_1[7];
		Cell cell = method_1(int_, int_2);
		cell.method_37(int_3);
		if (b2 == 0)
		{
			bool flag = ((b != 0) ? true : false);
			cell.method_65(flag);
		}
		else
		{
			cell.method_65(Class1673.smethod_6(b));
		}
	}

	private void method_37(Class1723 class1723_0)
	{
		method_5(class1723_0);
		ushort int_ = BitConverter.ToUInt16(byte_1, 0);
		byte int_2 = byte_1[2];
		ushort int_3 = BitConverter.ToUInt16(byte_1, 4);
		Cell cell = method_1(int_, int_2);
		cell.method_37(int_3);
	}

	private void method_38(Class1723 class1723_0)
	{
		method_5(class1723_0);
		worksheetCollection_0.Workbook.Settings.LanguageCode = method_39(BitConverter.ToUInt16(byte_1, 0));
		worksheetCollection_0.Workbook.Settings.Region = method_39(BitConverter.ToUInt16(byte_1, 2));
	}

	private CountryCode method_39(int int_0)
	{
		return int_0 switch
		{
			55 => CountryCode.Brazil, 
			20 => CountryCode.Egypt, 
			30 => CountryCode.Greece, 
			31 => CountryCode.Netherlands, 
			32 => CountryCode.Belgium, 
			33 => CountryCode.France, 
			34 => CountryCode.Spain, 
			36 => CountryCode.Hungary, 
			39 => CountryCode.Italy, 
			41 => CountryCode.Switzerland, 
			43 => CountryCode.Austria, 
			44 => CountryCode.UnitedKingdom, 
			45 => CountryCode.Denmark, 
			46 => CountryCode.Sweden, 
			47 => CountryCode.Norway, 
			48 => CountryCode.Poland, 
			49 => CountryCode.Germany, 
			52 => CountryCode.Mexico, 
			0 => CountryCode.Default, 
			1 => CountryCode.USA, 
			2 => CountryCode.Canada, 
			3 => CountryCode.LatinAmeric, 
			7 => CountryCode.Russia, 
			64 => CountryCode.NewZealand, 
			66 => CountryCode.Thailand, 
			61 => CountryCode.Australia, 
			213 => CountryCode.Algeria, 
			81 => CountryCode.Japan, 
			82 => CountryCode.SouthKorea, 
			84 => CountryCode.VietNam, 
			86 => CountryCode.China, 
			90 => CountryCode.Turkey, 
			91 => CountryCode.India, 
			351 => CountryCode.Portugal, 
			216 => CountryCode.Morocco, 
			218 => CountryCode.Libya, 
			358 => CountryCode.Finland, 
			354 => CountryCode.Iceland, 
			886 => CountryCode.Taiwan, 
			420 => CountryCode.Czech, 
			981 => CountryCode.Iran, 
			961 => CountryCode.Lebanon, 
			962 => CountryCode.Jordan, 
			963 => CountryCode.Syria, 
			964 => CountryCode.Iraq, 
			965 => CountryCode.Kuwait, 
			966 => CountryCode.Saudi, 
			971 => CountryCode.UnitedArabEmirates, 
			972 => CountryCode.Israel, 
			974 => CountryCode.Qatar, 
			_ => CountryCode.Default, 
		};
	}

	private void method_40(Class1723 class1723_0, ushort[] ushort_2)
	{
		method_5(class1723_0);
		ushort int_ = BitConverter.ToUInt16(byte_1, 0);
		byte b = byte_1[2];
		method_0(int_);
		ushort num = (ushort)row_0.method_10();
		for (int i = 0; i < byte_1.Length / 2 - 3; i++)
		{
			ushort num2 = BitConverter.ToUInt16(byte_1, 4 + 2 * i);
			if (num == 15)
			{
				if (num2 == ushort_2[b + i])
				{
					continue;
				}
			}
			else if (num == num2)
			{
				continue;
			}
			Cell cell = method_1(int_, b + i);
			cell.method_37(num2);
		}
	}

	private void method_41(Class1723 class1723_0)
	{
		method_5(class1723_0);
		byte byte_ = byte_1[0];
		ushort num = BitConverter.ToUInt16(byte_1, 2);
		ushort num2 = class1723_0.method_2(byte_0);
		if (num2 != 128)
		{
			cells_0.method_24(byte_);
			cells_0.double_0 = (int)num;
		}
		class1723_0.method_3(-2);
	}

	private void method_42(Class1723 class1723_0)
	{
		method_5(class1723_0);
		ushort num = BitConverter.ToUInt16(byte_1, 0);
		if (num != 8)
		{
			int num2 = num * 8;
			double num3 = 0.0;
			num3 = ((num2 < 12) ? ((double)num2 / 12.0) : ((double)(num2 - 5) / 7.0));
			cells_0.Columns.Width = num3;
		}
		ushort_0 = class1723_0.method_2(byte_0);
		if (ushort_0 == 512)
		{
			method_5(class1723_0);
		}
		else
		{
			class1723_0.method_3(-2);
		}
	}

	private void method_43(Class1723 class1723_0)
	{
		method_5(class1723_0);
		ushort int_ = BitConverter.ToUInt16(byte_1, 0);
		BitConverter.ToInt16(byte_1, 2);
		BitConverter.ToInt16(byte_1, 4);
		ushort num = (ushort)cells_0.method_0();
		num = (((byte_1[7] & 0x80u) != 0) ? ((ushort)(BitConverter.ToUInt16(byte_1, 6) & 0x7FFFu)) : BitConverter.ToUInt16(byte_1, 6));
		Row row = rowCollection_0.GetRow(int_, bool_0: false, bool_1: false);
		row.method_12(num);
		uint num2 = BitConverter.ToUInt32(byte_1, 12);
		if ((num2 & 0xF0000000u) != 0)
		{
			num2 = ((num2 & 0xF0000000u) >> 16) | (num2 & 0xFFFFFFFu);
		}
		if ((num2 & 0x100) == 0)
		{
			num2 &= 0xFFFFFFF0u;
			num2 |= 0x100u;
		}
		if ((num2 & 0xFFF0000) == 0)
		{
			num2 |= 0xF0000u;
		}
		if (num <= 0)
		{
			num2 |= 0x20u;
		}
		row.method_9((int)num2);
		if (row.method_24() > cells_0.method_29())
		{
			cells_0.method_30(row.method_24());
		}
	}

	private void method_44(Class1723 class1723_0, ushort[] ushort_2)
	{
		method_5(class1723_0);
		ushort num = BitConverter.ToUInt16(byte_1, 0);
		ushort num2 = BitConverter.ToUInt16(byte_1, 2);
		if (num2 >= 256)
		{
			cells_0.Columns.method_0().method_12(byte_1);
			cells_0.Columns.method_0().method_0(num);
			for (int i = num; i <= 255; i++)
			{
				ushort_2[i] = (ushort)cells_0.Columns.method_0().method_5();
			}
			return;
		}
		for (int j = num; j <= num2 && j <= 255; j++)
		{
			Column column = cells_0.Columns[j];
			column.method_12(byte_1);
			if (column.method_3() > cells_0.method_27())
			{
				cells_0.method_28(column.method_3());
			}
			ushort_2[j] = (ushort)column.method_5();
		}
	}

	private void method_45(Class1723 class1723_0)
	{
		method_5(class1723_0);
		ushort int_ = BitConverter.ToUInt16(byte_1, 0);
		byte int_2 = byte_1[2];
		ushort int_3 = BitConverter.ToUInt16(byte_1, 4);
		int num = BitConverter.ToUInt16(byte_1, 6);
		string stringValue = ((num <= 0) ? "" : ((byte_1[8] != 0) ? Encoding.Unicode.GetString(byte_1, 9, num * 2) : Class937.smethod_3(byte_1, 9, num)));
		Cell cell = method_1(int_, int_2);
		cell.method_37(int_3);
		cell.PutValue(stringValue);
	}

	private void method_46(Class1723 class1723_0)
	{
		method_5(class1723_0);
		ushort int_ = BitConverter.ToUInt16(byte_1, 0);
		byte int_2 = byte_1[2];
		ushort int_3 = BitConverter.ToUInt16(byte_1, 4);
		double double_ = BitConverter.ToDouble(byte_1, 6);
		Cell cell = method_1(int_, int_2);
		cell.method_37(int_3);
		cell.method_5(double_);
	}

	private void method_47(Class1723 class1723_0)
	{
		method_5(class1723_0);
		ushort int_ = BitConverter.ToUInt16(byte_1, 0);
		byte int_2 = byte_1[2];
		ushort int_3 = BitConverter.ToUInt16(byte_1, 4);
		int num = BitConverter.ToInt32(byte_1, 6);
		double num2 = 0.0;
		if (((uint)num & 2u) != 0)
		{
			num2 = num >> 2;
		}
		else
		{
			long value = (num & 0xFFFFFFFCu) << 32;
			num2 = BitConverter.Int64BitsToDouble(value);
		}
		if (((uint)num & (true ? 1u : 0u)) != 0)
		{
			num2 /= 100.0;
		}
		Cell cell = method_1(int_, int_2);
		cell.method_37(int_3);
		cell.method_5(num2);
	}

	private void method_48(Class1723 class1723_0)
	{
		method_5(class1723_0);
		ushort int_ = BitConverter.ToUInt16(byte_1, 0);
		method_0(int_);
		ushort num = BitConverter.ToUInt16(byte_1, 2);
		int num2 = (ushort_1 - 6) / 6;
		for (int i = 0; i < num2; i++)
		{
			ushort int_2 = BitConverter.ToUInt16(byte_1, 4 + 6 * i);
			int num3 = BitConverter.ToInt32(byte_1, 6 + 6 * i);
			double num4 = 0.0;
			if (((uint)num3 & 2u) != 0)
			{
				num4 = num3 >> 2;
			}
			else
			{
				long value = (num3 & 0xFFFFFFFCu) << 32;
				num4 = BitConverter.Int64BitsToDouble(value);
			}
			if (((uint)num3 & (true ? 1u : 0u)) != 0)
			{
				num4 /= 100.0;
			}
			Cell cell = method_1(int_, num + i);
			cell.method_37(int_2);
			cell.method_5(num4);
		}
	}

	private void method_49(Class1723 class1723_0)
	{
		method_5(class1723_0);
		ushort int_ = BitConverter.ToUInt16(byte_1, 0);
		byte int_2 = byte_1[2];
		ushort int_3 = BitConverter.ToUInt16(byte_1, 4);
		int int_4 = BitConverter.ToInt32(byte_1, 6);
		Cell cell = method_1(int_, int_2);
		cell.method_37(int_3);
		cells_0.method_2().method_5(cell, int_4);
	}

	private void method_50(Class1723 class1723_0)
	{
		method_5(class1723_0);
		worksheet_0.Hyperlinks.method_7(byte_1);
		ushort_0 = class1723_0.method_2(byte_0);
		if (ushort_0 == 2048)
		{
			method_5(class1723_0);
			if (worksheet_0.Hyperlinks.Count != 0)
			{
				Hyperlink hyperlink = worksheet_0.Hyperlinks[worksheet_0.Hyperlinks.Count - 1];
				hyperlink.ScreenTip = Encoding.Unicode.GetString(byte_1, 10, byte_1.Length - 12);
			}
		}
		else
		{
			class1723_0.method_3(-2);
		}
	}

	private void method_51(Class1723 class1723_0)
	{
		ushort[] array = new ushort[256];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = 15;
		}
		row_0 = null;
		hashtable_0 = new Hashtable();
		bool bool_ = false;
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			case 253:
				method_49(class1723_0);
				break;
			case 236:
			{
				Class1709 class2 = new Class1709(this, class1723_0, worksheetCollection_0, worksheet_0, worksheet_0);
				class2.method_1();
				break;
			}
			case 429:
				method_70(class1723_0);
				break;
			case 426:
				method_72(class1723_0);
				break;
			case 440:
				method_50(class1723_0);
				break;
			case 442:
				method_67(class1723_0);
				break;
			case 432:
				method_84(class1723_0);
				break;
			case 434:
			{
				method_5(class1723_0);
				worksheet_0.Validations.method_9(byte_1);
				int num10 = BitConverter.ToInt32(byte_1, 14);
				for (int k = 0; k < num10; k++)
				{
					class1723_0.method_3(2);
					method_5(class1723_0);
					Class629 @class = new Class629(worksheet_0);
					Validation validation = @class.method_6(byte_1);
					if (validation != null)
					{
						worksheet_0.Validations.method_0(validation);
					}
				}
				break;
			}
			case 549:
				method_41(class1723_0);
				break;
			case 513:
				method_37(class1723_0);
				break;
			case 515:
				method_46(class1723_0);
				break;
			case 516:
				method_45(class1723_0);
				break;
			case 517:
				method_36(class1723_0);
				break;
			case 520:
				method_43(class1723_0);
				break;
			case 638:
				method_47(class1723_0);
				break;
			case 574:
				method_71(class1723_0);
				break;
			case 1048:
				method_62(class1723_0);
				break;
			case 6:
			case 1030:
				method_31(class1723_0);
				break;
			case 2161:
			{
				method_5(class1723_0);
				if (byte_1[12] == 5)
				{
					int num12 = BitConverter.ToInt32(byte_1, 23);
					if (num12 > worksheetCollection_0.int_11)
					{
						worksheetCollection_0.int_11 = num12;
					}
					method_59(class1723_0);
					break;
				}
				if (worksheet_0.method_50() == null)
				{
					worksheet_0.method_51(new ArrayList());
				}
				byte[] array4 = new byte[ushort_1 + 4];
				Array.Copy(BitConverter.GetBytes(ushort_0), 0, array4, 0, 2);
				Array.Copy(BitConverter.GetBytes(ushort_1), 2, array4, 0, 2);
				Array.Copy(byte_1, 0, array4, 4, byte_1.Length);
				worksheet_0.method_50().Add(array4);
				break;
			}
			case 2162:
				method_58(class1723_0);
				break;
			case 2165:
				if (worksheet_0.method_50() == null)
				{
					worksheet_0.method_51(new ArrayList());
				}
				method_74(class1723_0, ushort_0);
				worksheet_0.method_50().Add(byte_1);
				break;
			case 2167:
				method_57(class1723_0);
				break;
			case 2169:
				method_75(class1723_0);
				break;
			case 2171:
				method_83(class1723_0);
				break;
			case 2146:
				method_15(class1723_0);
				break;
			case 2150:
				method_96(class1723_0, worksheet_0.PageSetup);
				break;
			case 2151:
				method_5(class1723_0);
				if (byte_1[12] == 2)
				{
					worksheet_0.Protection.method_1(byte_1);
				}
				break;
			case 2152:
				method_5(class1723_0);
				if (byte_1[12] == 2)
				{
					method_56();
				}
				else if (byte_1[12] == 3)
				{
					method_55();
				}
				break;
			default:
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
				break;
			case 2197:
			{
				method_5(class1723_0);
				DataSorter dataSorter = null;
				int num5 = (byte_1[12] >> 3) & 7;
				if (num5 == 2)
				{
					dataSorter = worksheet_0.AutoFilter.Sorter;
				}
				if (dataSorter != null)
				{
					method_104(dataSorter, class1723_0);
				}
				break;
			}
			case 2187:
				method_54(class1723_0);
				break;
			case 2174:
				method_64(class1723_0, worksheet_0.AutoFilter);
				break;
			case 65:
				method_85(class1723_0);
				break;
			case 12:
				method_5(class1723_0);
				worksheetCollection_0.Workbook.Settings.MaxIteration = BitConverter.ToUInt16(byte_1, 0);
				break;
			case 13:
				method_5(class1723_0);
				switch (BitConverter.ToUInt16(byte_1, 0))
				{
				default:
					worksheetCollection_0.Workbook.Settings.CalcMode = CalcModeType.AutomaticExceptTable;
					break;
				case 0:
					worksheetCollection_0.Workbook.Settings.CalcMode = CalcModeType.Manual;
					break;
				case 1:
					worksheetCollection_0.Workbook.Settings.CalcMode = CalcModeType.Automatic;
					break;
				}
				break;
			case 15:
				method_5(class1723_0);
				worksheetCollection_0.Workbook.Settings.method_2(BitConverter.ToUInt16(byte_1, 0) == 0);
				break;
			case 16:
				method_5(class1723_0);
				worksheetCollection_0.Workbook.Settings.MaxChange = BitConverter.ToDouble(byte_1, 0);
				break;
			case 17:
				method_5(class1723_0);
				worksheetCollection_0.Workbook.Settings.Iteration = byte_1[0] == 1;
				break;
			case 18:
				method_5(class1723_0);
				worksheet_0.Protection.AllowEditingContent = byte_1[0] == 0;
				break;
			case 19:
				method_5(class1723_0);
				worksheet_0.Protection.method_3(BitConverter.ToUInt16(byte_1, 0));
				break;
			case 20:
				method_5(class1723_0);
				if (byte_1 != null && byte_1.Length != 0)
				{
					cells_0.PageSetup.method_27(byte_1);
				}
				break;
			case 21:
				method_5(class1723_0);
				if (byte_1 != null && byte_1.Length != 0)
				{
					cells_0.PageSetup.method_28(byte_1);
				}
				break;
			case 26:
				method_30(class1723_0);
				break;
			case 27:
				method_29(class1723_0);
				break;
			case 28:
				method_65(class1723_0);
				break;
			case 29:
				method_69(class1723_0);
				break;
			case 38:
			{
				method_5(class1723_0);
				double num13 = BitConverter.ToDouble(byte_1, 0);
				if (num13 < 0.0 || num13 > 49.0)
				{
					num13 = 0.0;
				}
				cells_0.PageSetup.LeftMarginInch = num13;
				break;
			}
			case 39:
			{
				method_5(class1723_0);
				double num11 = BitConverter.ToDouble(byte_1, 0);
				if (num11 < 0.0 || num11 > 49.0)
				{
					num11 = 0.0;
				}
				cells_0.PageSetup.RightMarginInch = num11;
				break;
			}
			case 40:
			{
				method_5(class1723_0);
				double num9 = BitConverter.ToDouble(byte_1, 0);
				if (num9 < 0.0 || num9 > 49.0)
				{
					num9 = 0.0;
				}
				cells_0.PageSetup.TopMarginInch = num9;
				break;
			}
			case 41:
			{
				method_5(class1723_0);
				double num8 = BitConverter.ToDouble(byte_1, 0);
				if (num8 < 0.0 || num8 > 49.0)
				{
					num8 = 0.0;
				}
				cells_0.PageSetup.BottomMarginInch = num8;
				break;
			}
			case 42:
				method_5(class1723_0);
				if (byte_1[0] == 0 && byte_1[1] == 0)
				{
					cells_0.PageSetup.PrintHeadings = false;
				}
				else
				{
					cells_0.PageSetup.PrintHeadings = true;
				}
				break;
			case 43:
				method_5(class1723_0);
				if (byte_1[0] == 0 && byte_1[1] == 0)
				{
					cells_0.PageSetup.PrintGridlines = false;
				}
				else
				{
					cells_0.PageSetup.PrintGridlines = true;
				}
				break;
			case 85:
				method_42(class1723_0);
				break;
			case 77:
			{
				ushort_1 = class1723_0.method_2(byte_0);
				if (class1723_0.method_2(byte_0) != 0)
				{
					class1723_0.method_3(ushort_1 - 2);
					break;
				}
				byte[] array2 = new byte[ushort_1 - 2];
				class1723_0.method_1(array2);
				ArrayList arrayList = new ArrayList();
				arrayList.Add(array2);
				int num6 = array2.Length;
				while (true)
				{
					ushort_0 = class1723_0.method_2(byte_0);
					if (ushort_0 != 77)
					{
						if (ushort_0 != 60)
						{
							break;
						}
						method_5(class1723_0);
						arrayList.Add(byte_1);
						num6 += ushort_1;
					}
					else
					{
						ushort_1 = class1723_0.method_2(byte_0);
						int num7 = class1723_0.method_2(byte_0);
						array2 = new byte[ushort_1 - 2];
						class1723_0.method_1(array2);
						arrayList.Add(array2);
						num6 += array2.Length;
					}
				}
				class1723_0.method_3(-2);
				byte[] array3 = new byte[num6];
				num6 = 0;
				for (int j = 0; j < arrayList.Count; j++)
				{
					array2 = (byte[])arrayList[j];
					Array.Copy(array2, 0, array3, num6, array2.Length);
					num6 += array2.Length;
				}
				worksheet_0.Cells.PageSetup.method_5(array3);
				break;
			}
			case 99:
				method_5(class1723_0);
				worksheet_0.Protection.AllowEditingObject = byte_1[0] == 0;
				break;
			case 95:
				method_5(class1723_0);
				worksheetCollection_0.Workbook.Settings.RecalculateBeforeSave = byte_1[0] == 1;
				break;
			case 129:
				method_5(class1723_0);
				worksheet_0.short_0 = BitConverter.ToInt16(byte_1, 0);
				if ((worksheet_0.short_0 & 0x100) == 0)
				{
					cells_0.PageSetup.IsPercentScale = true;
				}
				else
				{
					cells_0.PageSetup.IsPercentScale = false;
				}
				if ((worksheet_0.short_0 & 0x40) == 0)
				{
					worksheet_0.Outline.SummaryRowBelow = false;
				}
				if ((worksheet_0.short_0 & 0x80) == 0)
				{
					worksheet_0.Outline.SummaryColumnRight = false;
				}
				break;
			case 131:
				method_5(class1723_0);
				if (byte_1[0] == 0 && byte_1[1] == 0)
				{
					cells_0.PageSetup.CenterHorizontally = false;
				}
				else
				{
					cells_0.PageSetup.CenterHorizontally = true;
				}
				break;
			case 132:
				method_5(class1723_0);
				if (byte_1[0] == 0 && byte_1[1] == 0)
				{
					cells_0.PageSetup.CenterVertically = false;
				}
				else
				{
					cells_0.PageSetup.CenterVertically = true;
				}
				break;
			case 125:
				method_44(class1723_0, array);
				break;
			case 153:
			{
				method_5(class1723_0);
				ushort num3 = BitConverter.ToUInt16(byte_1, 0);
				double num4 = 0.0;
				num4 = ((256 + worksheetCollection_0.method_71() <= num3) ? ((double)(num3 - worksheetCollection_0.method_71()) / 256.0) : ((double)(int)num3 / (256.0 + (double)worksheetCollection_0.method_71())));
				if (num4 < 0.0)
				{
					num4 = 0.0;
				}
				cells_0.method_8(num4);
				break;
			}
			case 155:
				class1723_0.method_3(2);
				break;
			case 157:
			{
				method_5(class1723_0);
				Name name = worksheetCollection_0.Names["_FILTERDATABASE", worksheet_0.Index];
				if (name != null)
				{
					worksheet_0.AutoFilter.method_3(name);
				}
				break;
			}
			case 158:
				method_63(class1723_0, worksheet_0.AutoFilter);
				break;
			case 160:
			{
				method_5(class1723_0);
				bool_ = true;
				ushort num = BitConverter.ToUInt16(byte_1, 0);
				ushort num2 = BitConverter.ToUInt16(byte_1, 2);
				worksheet_0.Zoom = num * 100 / (int)num2;
				break;
			}
			case 161:
				method_5(class1723_0);
				if (!cells_0.PageSetup.method_0())
				{
					cells_0.PageSetup.method_11(byte_1);
					cells_0.PageSetup.method_1(bool_14: true);
				}
				ushort_0 = class1723_0.method_2(byte_0);
				if (ushort_0 == 2204)
				{
					method_61(cells_0.PageSetup, class1723_0, null);
				}
				else
				{
					class1723_0.method_3(-2);
				}
				break;
			case 144:
				method_5(class1723_0);
				worksheet_0.method_33(new Class705());
				worksheet_0.method_32().method_3(byte_1);
				break;
			case 189:
				method_48(class1723_0);
				break;
			case 190:
				method_40(class1723_0, array);
				break;
			case 176:
				method_68(class1723_0);
				break;
			case 221:
				method_5(class1723_0);
				worksheet_0.Protection.AllowEditingScenario = byte_1[0] == 0;
				break;
			case 215:
				worksheetCollection_0.Workbook.method_30();
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
				break;
			case 233:
				method_66(class1723_0);
				break;
			case 229:
				method_86(class1723_0);
				break;
			case 10:
				class1723_0.method_3(2);
				method_53(bool_);
				return;
			}
		}
	}

	private void method_52(ShapeCollection shapeCollection_0)
	{
		if (shapeCollection_0 == null || shapeCollection_0.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < shapeCollection_0.Count; i++)
		{
			Shape shape = shapeCollection_0[i];
			if (shape.method_27().method_7().placementType_1 != PlacementType.MoveAndSize)
			{
				shape.Placement = shape.method_27().method_7().placementType_1;
			}
			if (shape.MsoDrawingType == MsoDrawingType.Chart)
			{
				Chart chart = ((ChartShape)shape).method_69();
				method_52(chart.method_16());
			}
		}
	}

	private void method_53(bool bool_0)
	{
		method_52(worksheet_0.method_36());
		if (!bool_0)
		{
			switch (worksheet_0.ViewType)
			{
			case ViewType.NormalView:
				worksheet_0.Zoom = 100;
				break;
			case ViewType.PageBreakPreview:
				worksheet_0.Zoom = 100;
				break;
			case ViewType.PageLayoutView:
				break;
			}
		}
	}

	private void method_54(Class1723 class1723_0)
	{
		method_5(class1723_0);
		if (worksheet_0.method_39() != null)
		{
			worksheet_0.method_39()[2] = BitConverter.ToUInt16(byte_1, 12);
		}
		if (((uint)byte_1[14] & (true ? 1u : 0u)) != 0)
		{
			worksheet_0.ViewType = ViewType.PageLayoutView;
		}
		worksheet_0.IsRulerVisible = (byte_1[14] & 2) != 0;
	}

	private void method_55()
	{
		int index = worksheet_0.ErrorCheckOptions.Add();
		ErrorCheckOption errorCheckOption = worksheet_0.ErrorCheckOptions[index];
		int num = 19;
		int num2 = BitConverter.ToUInt16(byte_1, 19);
		num = 19 + 8;
		for (int i = 0; i < num2; i++)
		{
			CellArea ca = default(CellArea);
			ca.StartRow = BitConverter.ToUInt16(byte_1, num);
			ca.EndRow = BitConverter.ToUInt16(byte_1, num + 2);
			ca.StartColumn = BitConverter.ToInt16(byte_1, num + 4);
			ca.EndColumn = BitConverter.ToInt16(byte_1, num + 6);
			errorCheckOption.AddRange(ca);
			num += 8;
		}
		errorCheckOption.int_0 = BitConverter.ToInt32(byte_1, num);
		num += 4;
	}

	private void method_56()
	{
		ProtectedRange protectedRange = new ProtectedRange(worksheet_0.AllowEditRanges);
		int num = 19;
		int num2 = BitConverter.ToUInt16(byte_1, 19);
		num = 19 + 8;
		for (int i = 0; i < num2; i++)
		{
			CellArea cellArea_ = default(CellArea);
			cellArea_.StartRow = BitConverter.ToUInt16(byte_1, num);
			cellArea_.EndRow = BitConverter.ToUInt16(byte_1, num + 2);
			cellArea_.StartColumn = BitConverter.ToUInt16(byte_1, num + 4);
			cellArea_.EndColumn = BitConverter.ToUInt16(byte_1, num + 6);
			protectedRange.AddArea(cellArea_);
			num += 8;
		}
		bool flag = (byte_1[num] & 1) != 0;
		num += 4;
		if (num + 4 <= ushort_1)
		{
			protectedRange.method_2(BitConverter.ToUInt16(byte_1, num));
			num += 4;
			protectedRange.Name = smethod_1(byte_1, ref num);
			if (flag)
			{
				int num3 = BitConverter.ToInt32(byte_1, num);
				protectedRange.byte_0 = new byte[num3 + 4];
				Array.Copy(byte_1, num, protectedRange.byte_0, 0, num3 + 4);
			}
			worksheet_0.AllowEditRanges.Add(protectedRange);
		}
	}

	private void method_57(Class1723 class1723_0)
	{
		method_5(class1723_0);
		int num = BitConverter.ToInt16(byte_1, 12);
		int int_ = BitConverter.ToInt32(byte_1, 14);
		ListObject listObject = worksheet_0.ListObjects.method_3(int_);
		if (listObject == null)
		{
			return;
		}
		int int_2 = 18;
		switch (num)
		{
		case 0:
		{
			int num2 = BitConverter.ToInt32(byte_1, 18);
			BitConverter.ToInt32(byte_1, 22);
			int num3 = BitConverter.ToInt32(byte_1, 26);
			BitConverter.ToInt32(byte_1, 30);
			int num4 = BitConverter.ToInt32(byte_1, 34);
			BitConverter.ToInt32(byte_1, 38);
			BitConverter.ToInt32(byte_1, 42);
			BitConverter.ToInt32(byte_1, 46);
			BitConverter.ToInt32(byte_1, 50);
			int_2 = 54;
			if (num2 != 0)
			{
				int_2 = method_76(int_2, listObject.method_42(), num2);
			}
			if (num3 != 0)
			{
				int_2 = method_76(int_2, listObject.method_44(), num3);
			}
			if (num4 != 0)
			{
				int_2 = method_76(int_2, listObject.method_45(), num4);
			}
			break;
		}
		case 1:
		{
			byte b = byte_1[18];
			listObject.ShowTableStyleFirstColumn = (b & 1) != 0;
			listObject.ShowTableStyleLastColumn = (b & 2) != 0;
			listObject.ShowTableStyleRowStripes = (b & 4) != 0;
			listObject.ShowTableStyleColumnStripes = (b & 8) != 0;
			int_2 += 2;
			listObject.TableStyleName = smethod_1(byte_1, ref int_2);
			break;
		}
		case 2:
			listObject.DisplayName = smethod_1(byte_1, ref int_2);
			listObject.Comment = smethod_1(byte_1, ref int_2);
			break;
		}
	}

	private void method_58(Class1723 class1723_0)
	{
		byte_1 = method_60(class1723_0);
		ListObject listObject = new ListObject(worksheet_0.ListObjects);
		worksheet_0.ListObjects.Add(listObject);
		if (byte_1[12] != 5)
		{
			listObject.byte_0 = byte_1;
			return;
		}
		int num = BitConverter.ToUInt16(byte_1, 19);
		BitConverter.ToInt32(byte_1, 21);
		int num2 = 27;
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < num; i++)
		{
			CellArea cellArea = default(CellArea);
			cellArea.StartRow = BitConverter.ToUInt16(byte_1, num2);
			cellArea.EndRow = BitConverter.ToUInt16(byte_1, num2 + 2);
			cellArea.StartColumn = BitConverter.ToUInt16(byte_1, num2 + 4);
			cellArea.EndColumn = BitConverter.ToUInt16(byte_1, num2 + 6);
			num2 += 8;
			arrayList.Add(cellArea);
		}
		CellArea cellArea2 = (CellArea)arrayList[0];
		listObject.method_2(cellArea2.StartRow);
		listObject.method_4(cellArea2.EndRow);
		listObject.method_3(cellArea2.StartColumn);
		listObject.method_5(cellArea2.EndColumn);
		switch (byte_1[num2])
		{
		default:
			listObject.method_14(Enum234.const_0);
			break;
		case 1:
			listObject.method_14(Enum234.const_1);
			break;
		case 2:
			listObject.method_14(Enum234.const_2);
			break;
		case 3:
			listObject.method_14(Enum234.const_3);
			break;
		}
		if (listObject.method_13() != 0)
		{
			listObject.byte_0 = byte_1;
			return;
		}
		listObject.method_46(BitConverter.ToInt32(byte_1, num2 + 4));
		listObject.method_16(BitConverter.ToUInt32(byte_1, num2 + 28));
		if ((listObject.method_15() & 2u) != 0)
		{
			listObject.method_37().Range = listObject.method_50();
		}
		listObject.method_29(BitConverter.ToInt32(byte_1, num2 + 32));
		listObject.method_30(BitConverter.ToInt32(byte_1, num2 + 36));
		listObject.method_31(BitConverter.ToInt32(byte_1, num2 + 40));
		listObject.method_32(BitConverter.ToInt32(byte_1, num2 + 44));
		listObject.method_36(new byte[16]);
		Array.Copy(byte_1, num2 + 48, listObject.method_35(), 0, 16);
		num2 += 64;
		listObject.method_47(smethod_1(byte_1, ref num2));
		int num3 = BitConverter.ToUInt16(byte_1, num2);
		num2 += 2;
		if (listObject.method_23())
		{
			listObject.method_27(smethod_1(byte_1, ref num2));
		}
		if (listObject.method_24())
		{
			listObject.method_28(smethod_1(byte_1, ref num2));
		}
		for (int j = 0; j < num3; j++)
		{
			ListColumn listColumn = new ListColumn(listObject.ListColumns);
			listObject.ListColumns.Add(listColumn);
			listColumn.method_4(j);
			listColumn.int_5 = BitConverter.ToInt32(byte_1, num2);
			listColumn.int_4 = BitConverter.ToInt32(byte_1, num2 + 4);
			listColumn.int_2 = BitConverter.ToInt32(byte_1, num2 + 8);
			listColumn.method_6((TotalsCalculation)byte_1[num2 + 12]);
			int num4 = BitConverter.ToInt32(byte_1, num2 + 16);
			BitConverter.ToInt32(byte_1, num2 + 20);
			uint num5 = (listColumn.uint_0 = BitConverter.ToUInt32(byte_1, num2 + 24));
			int num6 = BitConverter.ToInt32(byte_1, num2 + 28);
			BitConverter.ToInt32(byte_1, num2 + 32);
			num2 += 36;
			listColumn.method_2(smethod_1(byte_1, ref num2));
			if (!listObject.method_21())
			{
				listColumn.method_3(smethod_1(byte_1, ref num2));
			}
			if (num4 > 0)
			{
				num2 = method_76(num2, listColumn.method_20(), num4);
			}
			if (num6 > 0)
			{
				num2 = method_76(num2, listColumn.method_19(), num6);
			}
			if ((num5 & (true ? 1u : 0u)) != 0)
			{
				int num7 = BitConverter.ToInt32(byte_1, num2);
				num2 += 6 + num7;
			}
			if ((num5 & 4u) != 0)
			{
				int num8 = BitConverter.ToUInt16(byte_1, num2);
				num2 += 2 + num8;
			}
			if ((num5 & 8u) != 0)
			{
				int num9 = BitConverter.ToUInt16(byte_1, num2);
				listColumn.byte_0 = new byte[num9];
				Array.Copy(byte_1, num2, listColumn.byte_0, 0, num9 + 2);
				num2 += num9 + 2;
			}
			if ((num5 & 0x80u) != 0)
			{
				int num10 = BitConverter.ToUInt16(byte_1, num2);
				listColumn.byte_1 = new byte[num10];
				Array.Copy(byte_1, num2, listColumn.byte_1, 0, num10 + 2);
				num2 += num10 + 2;
			}
			if ((num5 & 0x400u) != 0)
			{
				listColumn.method_17(smethod_1(byte_1, ref num2));
			}
			if (byte_1[12] != 1)
			{
				continue;
			}
			BitConverter.ToInt32(byte_1, num2);
			num2 += 4;
			BitConverter.ToInt32(byte_1, num2);
			num2 += 4;
			BitConverter.ToUInt32(byte_1, num2);
			num2 += 4;
			uint num11 = BitConverter.ToUInt32(byte_1, num2);
			num2 += 4;
			if ((num11 & 0x10u) != 0)
			{
				switch (listColumn.int_4)
				{
				case 3:
					num2 += 4;
					break;
				case 4:
					num2 += 8;
					break;
				case 2:
				case 6:
					num2 += 8;
					break;
				case 1:
				case 8:
				case 11:
				{
					int num12 = BitConverter.ToUInt16(byte_1, num2);
					num2 += 2;
					num2 += ((byte_1[num2 + 2] == 0) ? (num12 + 3) : (num12 * 2 + 3));
					break;
				}
				}
			}
			if ((num11 & 0x40u) != 0)
			{
				int num13 = BitConverter.ToUInt16(byte_1, num2);
				num2 += 2 + num13;
			}
			num2 += 4;
		}
	}

	private void method_59(Class1723 class1723_0)
	{
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 2162)
			{
				break;
			}
			method_58(class1723_0);
		}
		class1723_0.method_3(-2);
	}

	internal static int smethod_0(byte[] byte_2, int int_0, Style style_0)
	{
		WorksheetCollection worksheetCollection = style_0.method_5();
		uint num = BitConverter.ToUInt32(byte_2, int_0);
		int_0 += 4;
		ushort num2 = BitConverter.ToUInt16(byte_2, int_0);
		bool flag = (byte_2[int_0] & 1) != 0;
		int_0 += 2;
		if (num == 0)
		{
			return int_0;
		}
		if ((num & 0x2000000u) != 0)
		{
			if (!flag)
			{
				int num3 = byte_2[int_0 + 1];
				for (int i = 0; i < worksheetCollection.method_55().Count; i++)
				{
					Class639 @class = (Class639)worksheetCollection.method_55()[i];
					if (@class.Index == num3)
					{
						if (@class.Custom != null && !(@class.Custom == ""))
						{
							style_0.Custom = @class.Custom;
						}
						break;
					}
				}
				style_0.method_45(num3);
				int_0 += 2;
			}
			else
			{
				int num4 = BitConverter.ToUInt16(byte_2, int_0);
				int_0 += 2;
				if (num4 > 0)
				{
					style_0.Custom = smethod_1(byte_2, ref int_0);
				}
			}
		}
		if ((num & 0x4000000u) != 0)
		{
			bool flag2 = BitConverter.ToInt32(byte_2, int_0 + 92) == 0;
			bool flag3 = BitConverter.ToInt32(byte_2, int_0 + 96) == 0;
			bool flag4 = BitConverter.ToInt32(byte_2, int_0 + 100) == 0;
			bool flag5 = (byte_2[int_0 + 88] & 2) == 0;
			bool flag6 = (byte_2[int_0 + 88] & 0x80) == 0;
			int num5 = BitConverter.ToInt32(byte_2, int_0 + 64);
			if (num5 != -1)
			{
				style_0.Font.Size = (short)(num5 / 20);
			}
			if (flag5)
			{
				style_0.Font.IsItalic = (byte_2[int_0 + 68] & 2) != 0;
			}
			if (flag4)
			{
				style_0.Font.Weight = BitConverter.ToUInt16(byte_2, int_0 + 72);
			}
			if (flag6)
			{
				style_0.Font.IsStrikeout = (byte_2[int_0 + 68] & 0x80) != 0;
			}
			if (flag2)
			{
				switch (BitConverter.ToInt16(byte_2, int_0 + 74))
				{
				case 1:
					style_0.Font.IsSuperscript = true;
					break;
				case 2:
					style_0.Font.IsSubscript = true;
					break;
				}
			}
			if (flag3)
			{
				switch (BitConverter.ToInt16(byte_2, int_0 + 76))
				{
				case 33:
					style_0.Font.Underline = FontUnderlineType.Accounting;
					break;
				case 34:
					style_0.Font.Underline = FontUnderlineType.DoubleAccounting;
					break;
				case 0:
					style_0.Font.Underline = FontUnderlineType.None;
					break;
				case 1:
					style_0.Font.Underline = FontUnderlineType.Single;
					break;
				case 2:
					style_0.Font.Underline = FontUnderlineType.Double;
					break;
				}
			}
			num5 = BitConverter.ToInt32(byte_2, int_0 + 80);
			if (num5 != -1)
			{
				style_0.Font.Color = worksheetCollection.method_24().method_7(num5);
			}
			int_0 += 118;
		}
		if ((num & 0x8000000u) != 0)
		{
			if ((num & 1) == 0)
			{
				style_0.HorizontalAlignment = Class1673.smethod_10(byte_2[int_0] & 7, bool_0: false);
			}
			if ((num & 2) == 0)
			{
				style_0.HorizontalAlignment = Class1673.smethod_10((byte_2[int_0] & 0x70) >> 4, bool_0: true);
			}
			if ((num & 4) == 0)
			{
				style_0.IsTextWrapped = (byte_2[int_0] & 0x80) != 0;
			}
			if ((num & 8) == 0)
			{
				style_0.RotationAngle = byte_2[int_0 + 1];
			}
			if ((num & 0x20) == 0)
			{
				int indentLevel = byte_2[int_0 + 2] & 0xF;
				int num6 = byte_2[int_0 + 4];
				if (num6 != 255)
				{
					style_0.IndentLevel = num6;
				}
				else
				{
					style_0.IndentLevel = indentLevel;
				}
			}
			if ((num & 0x40) == 0)
			{
				style_0.ShrinkToFit = (byte_2[int_0 + 2] & 0x10) != 0;
			}
			if ((num & 0x80000000u) != 0)
			{
				switch ((byte_2[int_0 + 2] & 0xC0) >> 2)
				{
				case 0:
					style_0.TextDirection = TextDirectionType.Context;
					break;
				case 1:
					style_0.TextDirection = TextDirectionType.LeftToRight;
					break;
				case 2:
					style_0.TextDirection = TextDirectionType.RightToLeft;
					break;
				}
			}
			int_0 += 8;
		}
		if ((num & 0x10000000u) != 0)
		{
			if ((num2 & 4u) != 0)
			{
				style_0.Borders.Outline = true;
			}
			ushort num7 = BitConverter.ToUInt16(byte_2, int_0);
			uint num8 = BitConverter.ToUInt16(byte_2, int_0 + 2);
			int num9 = 0;
			bool flag7 = false;
			bool flag8 = false;
			if ((num & 0x400) == 0)
			{
				style_0.Borders[BorderType.LeftBorder].LineStyle = (CellBorderType)(num7 & 0xF);
				num9 = (int)(num8 & 0x3F);
				style_0.Borders[BorderType.LeftBorder].Color = worksheetCollection.method_24().method_7(num9);
			}
			if ((num & 0x800) == 0)
			{
				style_0.Borders[BorderType.RightBorder].LineStyle = (CellBorderType)((num7 & 0xF0) >> 4);
				num9 = (int)((num8 & 0x3F8) >> 7);
				style_0.Borders[BorderType.RightBorder].Color = worksheetCollection.method_24().method_7(num9);
			}
			flag7 = (num8 & 0x4000) != 0;
			flag8 = (num8 & 0x8000) != 0;
			num8 = BitConverter.ToUInt32(byte_2, int_0 + 4);
			if ((num & 0x1000) == 0)
			{
				style_0.Borders[BorderType.TopBorder].LineStyle = (CellBorderType)((num7 & 0xF00) >> 8);
				num9 = (int)(num8 & 0x3F00);
				style_0.Borders[BorderType.TopBorder].Color = worksheetCollection.method_24().method_7(num9);
			}
			if ((num & 0x2000) == 0)
			{
				style_0.Borders[BorderType.BottomBorder].LineStyle = (CellBorderType)((num7 & 0xF000) >> 12);
				num9 = (int)((num8 & 0x3F8) >> 7);
				style_0.Borders[BorderType.BottomBorder].Color = worksheetCollection.method_24().method_7(num9);
			}
			if ((num & 0x4000) == 0 && flag7)
			{
				style_0.Borders[BorderType.DiagonalDown].LineStyle = (CellBorderType)((num8 & 0x1E00000) >> 21);
				num9 = (int)((num8 & 0x1FC00) >> 14);
				style_0.Borders[BorderType.DiagonalDown].Color = worksheetCollection.method_24().method_7(num9);
			}
			if ((num & 0x8000) == 0 && flag8)
			{
				style_0.Borders[BorderType.DiagonalUp].LineStyle = (CellBorderType)((num8 & 0x1E00000) >> 21);
				num9 = (int)((num8 & 0x1FC00) >> 14);
				style_0.Borders[BorderType.DiagonalUp].Color = worksheetCollection.method_24().method_7(num9);
			}
			int_0 += 8;
		}
		if ((num & 0x20000000u) != 0)
		{
			if ((num & 0x10000) == 0)
			{
				style_0.Pattern = (BackgroundType)(byte_2[int_0 + 1] >> 2);
			}
			int num10 = 0;
			if ((num & 0x20000) == 0)
			{
				num10 = byte_2[int_0 + 2] & 0x7F;
				style_0.ForegroundColor = worksheetCollection.method_24().method_7(num10);
			}
			if ((num & 0x40000) == 0)
			{
				num10 = (BitConverter.ToUInt16(byte_2, int_0 + 2) & 0x3F80) >> 7;
				style_0.BackgroundColor = worksheetCollection.method_24().method_7(num10);
			}
			int_0 += 4;
		}
		if ((num & 0x40000000u) != 0)
		{
			if ((num & 0x100) == 0)
			{
				style_0.IsLocked = (byte_2[int_0] & 1) != 0;
			}
			if ((num & 0x200) == 0)
			{
				style_0.IsFormulaHidden = (byte_2[int_0] & 2) != 0;
			}
			int_0 += 2;
		}
		return int_0;
	}

	[Attribute0(true)]
	private static string smethod_1(byte[] byte_2, ref int int_0)
	{
		int num = BitConverter.ToUInt16(byte_2, int_0);
		string text = null;
		if (byte_2[int_0 + 2] == 0)
		{
			text = Encoding.ASCII.GetString(byte_2, int_0 + 3, num);
			int_0 += 3 + num;
		}
		else
		{
			text = Encoding.Unicode.GetString(byte_2, int_0 + 3, num * 2);
			int_0 += 3 + num * 2;
		}
		return text;
	}

	private byte[] method_60(Class1723 class1723_0)
	{
		method_5(class1723_0);
		byte[] array = byte_1;
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 2165)
			{
				break;
			}
			method_5(class1723_0);
			byte[] array2 = new byte[array.Length + ushort_1 - 12];
			Array.Copy(array, 0, array2, 0, array.Length);
			Array.Copy(byte_1, 12, array2, array.Length, ushort_1 - 12);
			array = array2;
		}
		class1723_0.method_3(-2);
		return array;
	}

	private void method_61(PageSetup pageSetup_0, Class1723 class1723_0, byte[] byte_2)
	{
		method_5(class1723_0);
		int num = 12;
		if (28 < ushort_1)
		{
			bool flag = true;
			if (byte_2 == null)
			{
				for (int i = 0; i < 16; i++)
				{
					if (byte_1[num + i] != 0)
					{
						flag = false;
						break;
					}
				}
			}
			else
			{
				for (int j = 0; j < 16; j++)
				{
					if (byte_1[num + j] != byte_2[j])
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				num += 16;
			}
		}
		pageSetup_0.method_22(byte_1[num]);
		num += 2;
		int num2 = BitConverter.ToUInt16(byte_1, num);
		int num3 = BitConverter.ToUInt16(byte_1, num + 2);
		int num4 = BitConverter.ToUInt16(byte_1, num + 4);
		int num5 = BitConverter.ToUInt16(byte_1, num + 6);
		num += 8;
		if (num2 != 0)
		{
			num2 = BitConverter.ToUInt16(byte_1, num);
			num += 2;
			string text = null;
			if (byte_1[num] == 0)
			{
				text = Encoding.ASCII.GetString(byte_1, num + 1, num2);
				num += 1 + num2;
			}
			else
			{
				text = Encoding.Unicode.GetString(byte_1, num + 1, num2 * 2);
				num += 1 + num2 * 2;
			}
			pageSetup_0.string_4 = new string[3];
			PageSetup.smethod_1(text, pageSetup_0.string_4);
		}
		if (num3 != 0)
		{
			num3 = BitConverter.ToUInt16(byte_1, num);
			num += 2;
			string text2 = null;
			if (byte_1[num] == 0)
			{
				text2 = Encoding.ASCII.GetString(byte_1, num + 1, num3);
				num += 1 + num3;
			}
			else
			{
				text2 = Encoding.Unicode.GetString(byte_1, num + 1, num3 * 2);
				num += 1 + num3 * 2;
			}
			pageSetup_0.string_5 = new string[3];
			PageSetup.smethod_1(text2, pageSetup_0.string_5);
		}
		if (num4 != 0)
		{
			num4 = BitConverter.ToUInt16(byte_1, num);
			num += 2;
			string text3 = null;
			if (byte_1[num] == 0)
			{
				text3 = Encoding.ASCII.GetString(byte_1, num + 1, num4);
				num += 1 + num4;
			}
			else
			{
				text3 = Encoding.Unicode.GetString(byte_1, num + 1, num4 * 2);
				num += 1 + num4 * 2;
			}
			pageSetup_0.string_7 = new string[3];
			PageSetup.smethod_1(text3, pageSetup_0.string_7);
		}
		if (num5 != 0)
		{
			num5 = BitConverter.ToUInt16(byte_1, num);
			num += 2;
			string text4 = null;
			if (byte_1[num] == 0)
			{
				text4 = Encoding.ASCII.GetString(byte_1, num + 1, num5);
				num += 1 + num5;
			}
			else
			{
				text4 = Encoding.Unicode.GetString(byte_1, num + 1, num5 * 2);
				num += 1 + num5 * 2;
			}
			pageSetup_0.string_6 = new string[3];
			PageSetup.smethod_1(text4, pageSetup_0.string_6);
		}
	}

	private void method_62(Class1723 class1723_0)
	{
		method_5(class1723_0);
		int num = BitConverter.ToInt32(byte_1, 2);
		int num2 = byte_1[6];
		if (num2 + 7 > ushort_1)
		{
			return;
		}
		string @string = Encoding.ASCII.GetString(byte_1, 7, num2);
		int num3 = 7 + num2;
		int num4 = ushort_1 - num3;
		string text = "";
		if (num > num4)
		{
			byte[] array = new byte[num];
			Array.Copy(byte_1, num3, array, 0, num4);
			for (num3 = num4; num3 < num; num3 += ushort_1)
			{
				ushort_0 = class1723_0.method_2(byte_0);
				if (ushort_0 != 1084 && ushort_0 != 60)
				{
					break;
				}
				method_5(class1723_0);
				Array.Copy(byte_1, 0, array, num3, ushort_1);
			}
			text = Encoding.Unicode.GetString(array, 0, num);
		}
		else
		{
			text = Encoding.Unicode.GetString(byte_1, num3, num);
		}
		worksheet_0.CustomProperties.Add(@string, text);
	}

	private void method_63(Class1723 class1723_0, AutoFilter autoFilter_0)
	{
		Class1194 @class = null;
		try
		{
			method_5(class1723_0);
			int int_ = BitConverter.ToUInt16(byte_1, 0);
			@class = new Class1194(int_);
			@class.ushort_0 = BitConverter.ToUInt16(byte_1, 2);
			int num = 4;
			int num2 = 24;
			bool flag = false;
			switch (byte_1[4])
			{
			case 12:
				@class.filterOperatorType_0 = FilterOperatorType.Equal;
				return;
			case 13:
				@class.filterOperatorType_0 = FilterOperatorType.NotEqual;
				return;
			case 0:
				flag = true;
				break;
			case 2:
				@class.object_1 = Class1132.smethod_2(BitConverter.ToInt32(byte_1, num + 2));
				break;
			case 4:
				@class.object_1 = BitConverter.ToDouble(byte_1, num + 2);
				break;
			case 6:
			{
				int num3 = byte_1[num + 6];
				if (byte_1[num2] == 0)
				{
					@class.object_1 = Encoding.ASCII.GetString(byte_1, num2 + 1, num3);
					num2 += 1 + num3;
				}
				else
				{
					@class.object_1 = Encoding.Unicode.GetString(byte_1, num2 + 1, num3 * 2);
					num2 += 1 + num3 * 2;
				}
				break;
			}
			case 8:
				if (byte_1[num + 3] == 1)
				{
					switch (byte_1[num + 2])
					{
					case 15:
						@class.object_1 = "#VALUE!";
						break;
					case 7:
						@class.object_1 = "#DIV/0!";
						break;
					case 0:
						@class.object_1 = "#NULL!";
						break;
					case 29:
						@class.object_1 = "#NAME?";
						break;
					case 23:
						@class.object_1 = "#REF!";
						break;
					case 42:
						@class.object_1 = "#N/A";
						break;
					case 36:
						@class.object_1 = "#NUM!";
						break;
					}
				}
				else
				{
					@class.object_1 = byte_1[num + 2] == 1;
				}
				break;
			}
			if (!flag)
			{
				switch (byte_1[num + 1])
				{
				case 0:
					@class.filterOperatorType_0 = FilterOperatorType.None;
					break;
				case 1:
					@class.filterOperatorType_0 = FilterOperatorType.LessThan;
					break;
				case 2:
					@class.filterOperatorType_0 = FilterOperatorType.Equal;
					break;
				case 3:
					@class.filterOperatorType_0 = FilterOperatorType.LessOrEqual;
					break;
				case 4:
					@class.filterOperatorType_0 = FilterOperatorType.GreaterThan;
					break;
				case 5:
					@class.filterOperatorType_0 = FilterOperatorType.NotEqual;
					break;
				case 6:
					@class.filterOperatorType_0 = FilterOperatorType.GreaterOrEqual;
					break;
				}
			}
			flag = false;
			num += 10;
			switch (byte_1[num])
			{
			case 12:
				@class.filterOperatorType_1 = FilterOperatorType.Equal;
				return;
			case 13:
				@class.filterOperatorType_1 = FilterOperatorType.NotEqual;
				return;
			case 0:
				flag = true;
				return;
			case 2:
				@class.object_0 = Class1132.smethod_2(BitConverter.ToInt32(byte_1, num + 2));
				break;
			case 4:
				@class.object_0 = BitConverter.ToDouble(byte_1, num + 2);
				break;
			case 6:
			{
				int num4 = byte_1[num + 6];
				if (byte_1[num2] == 0)
				{
					@class.object_0 = Encoding.ASCII.GetString(byte_1, num2 + 1, num4);
					num2 += 1 + num4;
				}
				else
				{
					@class.object_0 = Encoding.Unicode.GetString(byte_1, num2 + 1, num4 * 2);
					num2 += 1 + num4 * 2;
				}
				break;
			}
			case 8:
				if (byte_1[num + 3] == 1)
				{
					switch (byte_1[num + 2])
					{
					case 15:
						@class.object_0 = "#VALUE!";
						break;
					case 7:
						@class.object_0 = "#DIV/0!";
						break;
					case 0:
						@class.object_0 = "#NULL!";
						break;
					case 29:
						@class.object_0 = "#NAME?";
						break;
					case 23:
						@class.object_0 = "#REF!";
						break;
					case 42:
						@class.object_0 = "#N/A";
						break;
					case 36:
						@class.object_0 = "#NUM!";
						break;
					}
				}
				else
				{
					@class.object_0 = byte_1[num + 2] == 1;
				}
				break;
			}
			switch (byte_1[num + 1])
			{
			case 0:
				@class.filterOperatorType_1 = FilterOperatorType.None;
				break;
			case 1:
				@class.filterOperatorType_1 = FilterOperatorType.LessThan;
				break;
			case 2:
				@class.filterOperatorType_1 = FilterOperatorType.Equal;
				break;
			case 3:
				@class.filterOperatorType_1 = FilterOperatorType.LessOrEqual;
				break;
			case 4:
				@class.filterOperatorType_1 = FilterOperatorType.GreaterThan;
				break;
			case 5:
				@class.filterOperatorType_1 = FilterOperatorType.NotEqual;
				break;
			case 6:
				@class.filterOperatorType_1 = FilterOperatorType.GreaterOrEqual;
				break;
			}
		}
		finally
		{
			FilterColumn filterColumn_ = @class.method_4(autoFilter_0.method_5());
			autoFilter_0.method_5().method_0(filterColumn_);
			autoFilter_0.bool_0 = false;
		}
	}

	private void method_64(Class1723 class1723_0, AutoFilter autoFilter_0)
	{
		method_5(class1723_0);
		int int_ = BitConverter.ToUInt16(byte_1, 12);
		FilterColumn filterColumn = new FilterColumn(autoFilter_0.FilterColumnCollection, int_);
		filterColumn.method_1(BitConverter.ToInt32(byte_1, 14) == 1);
		int num = BitConverter.ToInt32(byte_1, 18);
		int num2 = BitConverter.ToInt32(byte_1, 22);
		if (num != 0 || num2 != 0)
		{
			return;
		}
		int num3 = BitConverter.ToInt32(byte_1, 26);
		int num4 = BitConverter.ToInt32(byte_1, 30);
		MultipleFilterCollection multipleFilterCollection = new MultipleFilterCollection();
		int num5 = 0;
		while (true)
		{
			if (num5 < num3)
			{
				ushort_0 = class1723_0.method_2(byte_0);
				if (ushort_0 != 2175)
				{
					break;
				}
				method_5(class1723_0);
				switch (byte_1[12])
				{
				case 12:
					multipleFilterCollection.MatchBlank = true;
					break;
				case 6:
					if (byte_1[13] == 2)
					{
						if (byte_1[22] == 0)
						{
							multipleFilterCollection.Add(Encoding.ASCII.GetString(byte_1, 23, byte_1[14]));
						}
						else
						{
							multipleFilterCollection.Add(Encoding.Unicode.GetString(byte_1, 23, byte_1[14] * 2));
						}
					}
					break;
				}
				num5++;
				continue;
			}
			int num6 = 0;
			while (true)
			{
				if (num6 < num4)
				{
					ushort_0 = class1723_0.method_2(byte_0);
					if (ushort_0 != 2175)
					{
						break;
					}
					method_5(class1723_0);
					DateTimeGroupItem dateTimeGroupItem = new DateTimeGroupItem();
					dateTimeGroupItem.Year = BitConverter.ToInt16(byte_1, 12);
					dateTimeGroupItem.Month = BitConverter.ToInt16(byte_1, 14);
					dateTimeGroupItem.Day = BitConverter.ToInt32(byte_1, 16);
					dateTimeGroupItem.Hour = BitConverter.ToInt16(byte_1, 20);
					dateTimeGroupItem.Minute = BitConverter.ToInt16(byte_1, 22);
					dateTimeGroupItem.Second = BitConverter.ToInt16(byte_1, 24);
					switch (byte_1[32])
					{
					default:
						dateTimeGroupItem.DateTimeGroupingType = DateTimeGroupingType.Year;
						break;
					case 1:
						dateTimeGroupItem.DateTimeGroupingType = DateTimeGroupingType.Month;
						break;
					case 2:
						dateTimeGroupItem.DateTimeGroupingType = DateTimeGroupingType.Day;
						break;
					case 3:
						dateTimeGroupItem.DateTimeGroupingType = DateTimeGroupingType.Hour;
						break;
					case 4:
						dateTimeGroupItem.DateTimeGroupingType = DateTimeGroupingType.Minute;
						break;
					case 5:
						dateTimeGroupItem.DateTimeGroupingType = DateTimeGroupingType.Second;
						break;
					}
					multipleFilterCollection.Add(dateTimeGroupItem);
					num6++;
					continue;
				}
				filterColumn.Filter = multipleFilterCollection;
				filterColumn.FilterType = FilterType.MultipleFilters;
				autoFilter_0.method_5().method_0(filterColumn);
				return;
			}
			class1723_0.method_3(-2);
			return;
		}
		class1723_0.method_3(-2);
	}

	private void method_65(Class1723 class1723_0)
	{
		method_5(class1723_0);
		int num = BitConverter.ToUInt16(byte_1, 6);
		Shape shape = null;
		foreach (Shape shape2 in worksheet_0.Shapes)
		{
			if (shape2.method_23() == num)
			{
				shape = shape2;
				break;
			}
		}
		if (shape != null && shape is CommentShape)
		{
			Comment comment = ((CommentShape)shape).method_69();
			comment.method_4(BitConverter.ToUInt16(byte_1, 0));
			comment.method_5(byte_1[2]);
			comment.method_1(bool_1: true);
			int num2 = BitConverter.ToUInt16(byte_1, 8);
			if (byte_1[10] == 0)
			{
				comment.Author = Encoding.ASCII.GetString(byte_1, 11, num2);
			}
			else
			{
				comment.Author = Encoding.Unicode.GetString(byte_1, 11, num2 * 2);
			}
		}
	}

	private void method_66(Class1723 class1723_0)
	{
		ArrayList arrayList = new ArrayList();
		class1723_0.method_3(-2);
		method_73(class1723_0);
		arrayList.Add(byte_1);
		int num = byte_1.Length - 12;
		int num2 = BitConverter.ToInt32(byte_1, 8);
		num2 -= num;
		while (num2 > 0)
		{
			method_73(class1723_0);
			int num3 = BitConverter.ToInt16(byte_1, 0);
			if (num3 == 233 || num3 == 60)
			{
				arrayList.Add(byte_1);
				num2 -= byte_1.Length - 4;
				continue;
			}
			throw new IOException("File is corrupted");
		}
		worksheet_0.method_48(arrayList);
	}

	private void method_67(Class1723 class1723_0)
	{
		method_5(class1723_0);
		if (byte_1[2] == 0)
		{
			worksheet_0.method_46(Class937.smethod_3(byte_1, 3, byte_1.Length - 3));
		}
		else
		{
			worksheet_0.method_46(Encoding.Unicode.GetString(byte_1, 3, byte_1.Length - 3));
		}
	}

	private void method_68(Class1723 class1723_0)
	{
		Class1155 @class = new Class1155();
		@class.Read(worksheetCollection_0, worksheet_0, this, class1723_0);
	}

	private void method_69(Class1723 class1723_0)
	{
		if (worksheet_0.method_34() == null)
		{
			worksheet_0.method_35(new Class1733(worksheet_0));
		}
		method_5(class1723_0);
		Class1732 @class = new Class1732(byte_1[0]);
		@class.method_2(byte_1[0]);
		@class.method_6(BitConverter.ToUInt16(byte_1, 1));
		@class.method_8(BitConverter.ToInt16(byte_1, 3));
		@class.method_10(BitConverter.ToUInt16(byte_1, 5));
		for (int i = 9; i + 6 <= byte_1.Length; i += 6)
		{
			CellArea cellArea = default(CellArea);
			cellArea.StartRow = BitConverter.ToUInt16(byte_1, i);
			cellArea.EndRow = BitConverter.ToUInt16(byte_1, i + 2);
			cellArea.StartColumn = byte_1[i + 4];
			cellArea.EndColumn = byte_1[i + 5];
			@class.method_3().Add(cellArea);
		}
		worksheet_0.method_34().Add(@class);
	}

	private void method_70(Class1723 class1723_0)
	{
		class1723_0.method_3(-2);
		if (worksheet_0.method_30() == null)
		{
			worksheet_0.method_31(new ArrayList());
		}
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 == 442 || ushort_0 == 10 || ushort_0 == 239 || ushort_0 == 432)
			{
				break;
			}
			ushort_1 = class1723_0.method_2(byte_0);
			class1723_0.method_3(-4);
			byte_1 = new byte[ushort_1 + 4];
			class1723_0.method_1(byte_1);
			worksheet_0.method_30().Add(byte_1);
		}
		class1723_0.method_3(-2);
	}

	private void method_71(Class1723 class1723_0)
	{
		method_5(class1723_0);
		worksheet_0.method_10((ushort)(BitConverter.ToUInt16(byte_1, 0) & 0x3FFu));
		if ((byte_1[1] & 8u) != 0)
		{
			worksheet_0.ViewType = ViewType.PageBreakPreview;
		}
		worksheet_0.FirstVisibleRow = BitConverter.ToUInt16(byte_1, 2);
		worksheet_0.FirstVisibleColumn = byte_1[4] & 0xFF;
		worksheet_0.method_45(byte_1[6]);
		if (ushort_1 > 10)
		{
			int num = BitConverter.ToUInt16(byte_1, 10);
			if (num != 0)
			{
				worksheet_0.method_39()[1] = num;
			}
			num = BitConverter.ToUInt16(byte_1, 12);
			if (num != 0)
			{
				worksheet_0.method_39()[0] = num;
			}
		}
	}

	private void method_72(Class1723 class1723_0)
	{
		method_74(class1723_0, 426);
		worksheet_0.method_20().Add(byte_1);
		ushort num;
		do
		{
			ushort_0 = class1723_0.method_2(byte_0);
			method_74(class1723_0, ushort_0);
			worksheet_0.method_20().Add(byte_1);
			num = ushort_0;
		}
		while (num != 427);
	}

	internal void method_73(Class1723 class1723_0)
	{
		ushort_0 = class1723_0.method_2(byte_0);
		method_74(class1723_0, ushort_0);
	}

	internal void method_74(Class1723 class1723_0, int int_0)
	{
		method_5(class1723_0);
		if (byte_1 != null && byte_1.Length != 0)
		{
			byte[] destinationArray = new byte[byte_1.Length + 4];
			Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, destinationArray, 0, 2);
			Array.Copy(BitConverter.GetBytes((ushort)byte_1.Length), 0, destinationArray, 2, 2);
			Array.Copy(byte_1, 0, destinationArray, 4, byte_1.Length);
			byte_1 = destinationArray;
		}
		else
		{
			byte_1 = new byte[4];
			Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, byte_1, 0, 2);
		}
	}

	private void method_75(Class1723 class1723_0)
	{
		method_5(class1723_0);
		ConditionalFormattingCollection conditionalFormattings = worksheet_0.ConditionalFormattings;
		FormatConditionCollection formatConditionCollection = null;
		int num = conditionalFormattings.Add();
		formatConditionCollection = conditionalFormattings[num];
		int num2 = 12;
		int num3 = BitConverter.ToUInt16(byte_1, 12);
		formatConditionCollection.bool_0 = (byte_1[14] & 1) != 0;
		int num4 = BitConverter.ToUInt16(byte_1, 12 + 2) >> 1;
		hashtable_0[num4] = num;
		num2 = 12 + 12;
		int num5 = Math.Min(BitConverter.ToUInt16(byte_1, 24), (ushort_1 - 24 - 2) / 8);
		num2 = 24 + 2;
		for (int i = 0; i < num5; i++)
		{
			CellArea cellArea = default(CellArea);
			cellArea.StartRow = BitConverter.ToUInt16(byte_1, num2);
			cellArea.EndRow = BitConverter.ToUInt16(byte_1, num2 + 2);
			cellArea.StartColumn = BitConverter.ToUInt16(byte_1, num2 + 4);
			cellArea.EndColumn = BitConverter.ToUInt16(byte_1, num2 + 6);
			formatConditionCollection.arrayList_1.Add(cellArea);
			num2 += 8;
		}
		int num6 = 0;
		while (true)
		{
			if (num6 < num3)
			{
				ushort_0 = class1723_0.method_2(byte_0);
				if (ushort_0 != 2170)
				{
					break;
				}
				FormatCondition formatCondition_ = new FormatCondition(formatConditionCollection);
				formatConditionCollection.AddCondition(formatCondition_);
				method_78(class1723_0, formatCondition_);
				num6++;
				continue;
			}
			return;
		}
		class1723_0.method_3(-2);
	}

	private int method_76(int int_0, Style style_0, int int_1)
	{
		int num = int_0;
		int_0 = smethod_0(byte_1, int_0, style_0);
		int num2 = int_0 - num;
		if (int_1 == num2)
		{
			return int_0;
		}
		int_0 += 6;
		num2 = BitConverter.ToUInt16(byte_1, int_0);
		int_0 += 2;
		Class1685 @class = method_100(byte_1, ref int_0, num2);
		@class.method_2(style_0);
		return int_0;
	}

	private int method_77(int int_0, Style style_0)
	{
		int num = BitConverter.ToUInt16(byte_1, int_0);
		int num2 = num;
		int num3 = int_0;
		int_0 += 4;
		if (num == 0)
		{
			int_0 += 2;
			return int_0;
		}
		int num4 = int_0;
		int_0 = smethod_0(byte_1, int_0, style_0);
		if (num - (int_0 - num4) == 0)
		{
			return int_0;
		}
		int_0 += 6;
		num = BitConverter.ToUInt16(byte_1, int_0);
		int_0 += 2;
		Class1685 @class = method_100(byte_1, ref int_0, num);
		@class.method_2(style_0);
		if (num3 + 4 + num2 != int_0)
		{
			int_0 = num3 + 6 + num2;
		}
		return int_0;
	}

	private void method_78(Class1723 class1723_0, FormatCondition formatCondition_0)
	{
		method_5(class1723_0);
		formatCondition_0.operatorType_0 = Class1673.smethod_12(byte_1[13]);
		int num = 18;
		num = method_77(18, formatCondition_0.Style);
		int num2 = BitConverter.ToUInt16(byte_1, 14);
		if (num2 != 0)
		{
			byte[] array = new byte[num2 + 2];
			Array.Copy(BitConverter.GetBytes(num2), 0, array, 0, 2);
			Array.Copy(byte_1, num, array, 2, num2);
			formatCondition_0.method_1(array);
		}
		num += num2;
		num2 = BitConverter.ToUInt16(byte_1, 16);
		if (num2 != 0)
		{
			byte[] array2 = new byte[num2 + 2];
			Array.Copy(BitConverter.GetBytes(num2), 0, array2, 0, 2);
			Array.Copy(byte_1, num, array2, 2, num2);
			formatCondition_0.method_5(array2);
		}
		num += num2;
		num2 = BitConverter.ToUInt16(byte_1, num);
		num += 2 + num2;
		formatCondition_0.StopIfTrue = (byte_1[num] & 2) != 0;
		num++;
		formatCondition_0.Priority = BitConverter.ToUInt16(byte_1, num);
		num += 2;
		if (formatCondition_0.Priority > formatCondition_0.formatConditionCollection_0.worksheet_0.method_3())
		{
			formatCondition_0.formatConditionCollection_0.worksheet_0.method_4(formatCondition_0.Priority + 1);
		}
		switch (byte_1[12])
		{
		case 1:
			formatCondition_0.formatConditionType_0 = FormatConditionType.CellValue;
			break;
		case 2:
			formatCondition_0.formatConditionType_0 = FormatConditionType.Expression;
			break;
		}
		int int_ = BitConverter.ToUInt16(byte_1, num);
		num += 2;
		method_79(formatCondition_0, int_, num, bool_0: true, byte_1[12]);
	}

	private void method_79(FormatCondition formatCondition_0, int int_0, int int_1, bool bool_0, int int_2)
	{
		int_1++;
		switch (int_0)
		{
		case 0:
			if (formatCondition_0.formatConditionType_0 != FormatConditionType.Expression)
			{
				formatCondition_0.formatConditionType_0 = FormatConditionType.CellValue;
			}
			break;
		case 1:
			formatCondition_0.formatConditionType_0 = FormatConditionType.Expression;
			break;
		case 2:
		{
			formatCondition_0.formatConditionType_0 = FormatConditionType.ColorScale;
			ColorScale colorScale_ = new ColorScale(worksheetCollection_0.Workbook, formatCondition_0);
			formatCondition_0.method_20(colorScale_);
			break;
		}
		case 3:
		{
			formatCondition_0.formatConditionType_0 = FormatConditionType.DataBar;
			DataBar dataBar_ = new DataBar(worksheetCollection_0.Workbook, formatCondition_0);
			formatCondition_0.method_19(dataBar_);
			break;
		}
		case 4:
		{
			formatCondition_0.formatConditionType_0 = FormatConditionType.IconSet;
			IconSet iconSet_ = new IconSet(formatCondition_0);
			formatCondition_0.method_18(iconSet_);
			break;
		}
		case 5:
		{
			formatCondition_0.formatConditionType_0 = FormatConditionType.Top10;
			Top10 top = new Top10();
			formatCondition_0.method_21(top);
			top.IsBottom = (byte_1[int_1] & 1) == 0;
			top.IsPercent = (byte_1[int_1] & 2) != 0;
			top.Rank = BitConverter.ToUInt16(byte_1, int_1 + 1);
			break;
		}
		case 7:
			formatCondition_0.formatConditionType_0 = FormatConditionType.UniqueValues;
			break;
		case 8:
			switch (byte_1[int_1])
			{
			case 0:
			case 1:
			{
				string text2 = null;
				if (formatCondition_0.method_0() != null)
				{
					string formula2 = formatCondition_0.Formula1;
					if (formula2 != null)
					{
						string text3 = formula2.ToUpper();
						int num2 = text3.IndexOf("SEARCH(");
						if (num2 != -1)
						{
							int num3 = text3.IndexOf(',', num2);
							if (num3 != -1)
							{
								text2 = "=" + formula2.Substring(num2 + 7, num3 - (num2 + 7));
							}
						}
					}
				}
				if (text2 != null)
				{
					formatCondition_0.Text = text2;
					switch (byte_1[int_1])
					{
					case 0:
						formatCondition_0.formatConditionType_0 = FormatConditionType.ContainsText;
						break;
					case 1:
						formatCondition_0.formatConditionType_0 = FormatConditionType.NotContainsText;
						break;
					}
				}
				break;
			}
			case 2:
			case 3:
			{
				string text = null;
				if (formatCondition_0.method_0() != null)
				{
					string formula = formatCondition_0.Formula1;
					if (formula != null)
					{
						int num = formula.LastIndexOf("=");
						if (num > 1)
						{
							text = formula.Substring(num);
						}
					}
				}
				if (text != null)
				{
					formatCondition_0.Text = text;
					switch (byte_1[int_1])
					{
					case 2:
						formatCondition_0.formatConditionType_0 = FormatConditionType.BeginsWith;
						break;
					case 3:
						formatCondition_0.formatConditionType_0 = FormatConditionType.EndsWith;
						break;
					}
				}
				break;
			}
			}
			break;
		case 9:
			formatCondition_0.formatConditionType_0 = FormatConditionType.ContainsBlanks;
			break;
		case 10:
			formatCondition_0.formatConditionType_0 = FormatConditionType.NotContainsBlanks;
			break;
		case 11:
			formatCondition_0.formatConditionType_0 = FormatConditionType.ContainsErrors;
			break;
		case 12:
			formatCondition_0.formatConditionType_0 = FormatConditionType.NotContainsErrors;
			break;
		case 15:
			formatCondition_0.formatConditionType_0 = FormatConditionType.TimePeriod;
			formatCondition_0.TimePeriod = TimePeriodType.Today;
			break;
		case 16:
			formatCondition_0.formatConditionType_0 = FormatConditionType.TimePeriod;
			formatCondition_0.TimePeriod = TimePeriodType.Tomorrow;
			break;
		case 17:
			formatCondition_0.formatConditionType_0 = FormatConditionType.TimePeriod;
			formatCondition_0.TimePeriod = TimePeriodType.Yesterday;
			break;
		case 18:
			formatCondition_0.formatConditionType_0 = FormatConditionType.TimePeriod;
			formatCondition_0.TimePeriod = TimePeriodType.Last7Days;
			break;
		case 19:
			formatCondition_0.formatConditionType_0 = FormatConditionType.TimePeriod;
			formatCondition_0.TimePeriod = TimePeriodType.LastMonth;
			break;
		case 20:
			formatCondition_0.formatConditionType_0 = FormatConditionType.TimePeriod;
			formatCondition_0.TimePeriod = TimePeriodType.NextMonth;
			break;
		case 21:
			formatCondition_0.formatConditionType_0 = FormatConditionType.TimePeriod;
			formatCondition_0.TimePeriod = TimePeriodType.ThisWeek;
			break;
		case 22:
			formatCondition_0.formatConditionType_0 = FormatConditionType.TimePeriod;
			formatCondition_0.TimePeriod = TimePeriodType.NextWeek;
			break;
		case 23:
			formatCondition_0.formatConditionType_0 = FormatConditionType.TimePeriod;
			formatCondition_0.TimePeriod = TimePeriodType.LastWeek;
			break;
		case 24:
			formatCondition_0.formatConditionType_0 = FormatConditionType.TimePeriod;
			formatCondition_0.TimePeriod = TimePeriodType.ThisMonth;
			break;
		case 25:
			formatCondition_0.formatConditionType_0 = FormatConditionType.AboveAverage;
			formatCondition_0.AboveAverage.IsAboveAverage = true;
			formatCondition_0.AboveAverage.IsEqualAverage = false;
			formatCondition_0.AboveAverage.StdDev = BitConverter.ToUInt16(byte_1, int_1);
			break;
		case 26:
			formatCondition_0.formatConditionType_0 = FormatConditionType.AboveAverage;
			formatCondition_0.AboveAverage.IsAboveAverage = false;
			formatCondition_0.AboveAverage.IsEqualAverage = false;
			formatCondition_0.AboveAverage.StdDev = BitConverter.ToUInt16(byte_1, int_1);
			break;
		case 27:
			formatCondition_0.formatConditionType_0 = FormatConditionType.DuplicateValues;
			break;
		case 29:
			formatCondition_0.formatConditionType_0 = FormatConditionType.AboveAverage;
			formatCondition_0.AboveAverage.IsAboveAverage = true;
			formatCondition_0.AboveAverage.IsEqualAverage = true;
			formatCondition_0.AboveAverage.StdDev = BitConverter.ToUInt16(byte_1, int_1);
			break;
		case 30:
			formatCondition_0.formatConditionType_0 = FormatConditionType.AboveAverage;
			formatCondition_0.AboveAverage.IsAboveAverage = false;
			formatCondition_0.AboveAverage.IsEqualAverage = true;
			formatCondition_0.AboveAverage.StdDev = BitConverter.ToUInt16(byte_1, int_1);
			break;
		}
		int_1 += 16;
		if (!bool_0)
		{
			return;
		}
		switch (int_2)
		{
		case 3:
		{
			ColorScale colorScale = null;
			if (formatCondition_0.Type != FormatConditionType.ColorScale)
			{
				formatCondition_0.formatConditionType_0 = FormatConditionType.ColorScale;
				colorScale = new ColorScale(worksheetCollection_0.Workbook, formatCondition_0);
				formatCondition_0.method_20(colorScale);
			}
			else
			{
				colorScale = formatCondition_0.ColorScale;
			}
			int num5 = byte_1[int_1 + 3];
			int_1 += 6;
			for (int j = 0; j < num5; j++)
			{
				ConditionalFormattingValue conditionalFormattingValue2 = new ConditionalFormattingValue(formatCondition_0);
				int_1 = method_81(int_1, conditionalFormattingValue2);
				switch (j)
				{
				case 0:
					colorScale.conditionalFormattingValue_0 = conditionalFormattingValue2;
					break;
				case 2:
					colorScale.conditionalFormattingValue_2 = conditionalFormattingValue2;
					break;
				default:
					if (num5 == 2)
					{
						colorScale.conditionalFormattingValue_2 = conditionalFormattingValue2;
					}
					else
					{
						colorScale.conditionalFormattingValue_1 = conditionalFormattingValue2;
					}
					break;
				}
				int_1 += 8;
			}
			for (int k = 0; k < num5; k++)
			{
				int_1 += 8;
				InternalColor internalColor = method_80(byte_1, int_1);
				int_1 += 16;
				switch (k)
				{
				case 0:
					colorScale.internalColor_0 = internalColor;
					continue;
				case 2:
					colorScale.internalColor_2 = internalColor;
					continue;
				}
				if (num5 == 2)
				{
					colorScale.internalColor_2 = internalColor;
				}
				else
				{
					colorScale.internalColor_1 = internalColor;
				}
			}
			break;
		}
		case 4:
		{
			DataBar dataBar = null;
			if (formatCondition_0.Type != FormatConditionType.DataBar)
			{
				formatCondition_0.formatConditionType_0 = FormatConditionType.DataBar;
				dataBar = new DataBar(worksheetCollection_0.Workbook, formatCondition_0);
				formatCondition_0.method_19(dataBar);
			}
			else
			{
				dataBar = formatCondition_0.DataBar;
			}
			int_1 += 3;
			dataBar.ShowValue = (byte_1[int_1] & 2) == 0;
			int_1++;
			dataBar.MinLength = byte_1[int_1];
			dataBar.MaxLength = byte_1[int_1 + 1];
			int_1 += 2;
			dataBar.method_5(method_80(byte_1, int_1));
			int_1 += 16;
			ConditionalFormattingValue conditionalFormattingValue3 = new ConditionalFormattingValue(formatCondition_0);
			int_1 = method_81(int_1, conditionalFormattingValue3);
			ConditionalFormattingValue conditionalFormattingValue4 = new ConditionalFormattingValue(formatCondition_0);
			int_1 = method_81(int_1, conditionalFormattingValue4);
			dataBar.method_2(conditionalFormattingValue4);
			dataBar.method_3(conditionalFormattingValue3);
			break;
		}
		case 5:
			if (formatCondition_0.Type != FormatConditionType.Top10)
			{
				formatCondition_0.formatConditionType_0 = FormatConditionType.Top10;
				Top10 top10_ = new Top10();
				formatCondition_0.method_21(top10_);
			}
			int_1 += 2;
			int_1++;
			formatCondition_0.Top10.IsBottom = (byte_1[int_1] & 1) == 0;
			formatCondition_0.Top10.IsPercent = (byte_1[int_1] & 2) != 0;
			int_1++;
			formatCondition_0.Top10.Rank = BitConverter.ToUInt16(byte_1, int_1);
			int_1 += 2;
			break;
		case 6:
		{
			if (formatCondition_0.Type != FormatConditionType.IconSet)
			{
				formatCondition_0.formatConditionType_0 = FormatConditionType.IconSet;
				IconSet iconSet_2 = new IconSet(formatCondition_0);
				formatCondition_0.method_18(iconSet_2);
			}
			int_1 += 3;
			int num4 = byte_1[int_1];
			int_1++;
			formatCondition_0.IconSet.method_2(Class1673.smethod_13(byte_1[int_1]));
			int_1++;
			formatCondition_0.IconSet.ShowValue = (byte_1[int_1] & 1) == 0;
			formatCondition_0.IconSet.Reverse = (byte_1[int_1] & 4) != 0;
			int_1++;
			for (int i = 0; i < num4; i++)
			{
				ConditionalFormattingValue conditionalFormattingValue = new ConditionalFormattingValue(formatCondition_0);
				formatCondition_0.IconSet.Cfvos.Add(conditionalFormattingValue);
				int_1 = method_81(int_1, conditionalFormattingValue);
				conditionalFormattingValue.IsGTE = byte_1[int_1] == 1;
				int_1 += 5;
			}
			break;
		}
		}
	}

	private InternalColor method_80(byte[] byte_2, int int_0)
	{
		InternalColor internalColor = new InternalColor(bool_0: false);
		switch (byte_2[int_0])
		{
		case 1:
			internalColor.SetColor(ColorType.IndexedColor, BitConverter.ToInt32(byte_2, int_0 + 4));
			goto default;
		case 2:
			internalColor.SetColor(ColorType.RGB, Color.FromArgb(byte_1[int_0 + 7], byte_1[int_0 + 4], byte_1[int_0 + 5], byte_1[int_0 + 6]).ToArgb());
			goto default;
		case 3:
			internalColor.SetColor(ColorType.Theme, BitConverter.ToInt32(byte_2, int_0 + 4));
			goto default;
		default:
			internalColor.Tint = BitConverter.ToDouble(byte_2, int_0 + 8);
			return internalColor;
		case 4:
			return internalColor;
		}
	}

	private int method_81(int int_0, ConditionalFormattingValue conditionalFormattingValue_0)
	{
		switch (byte_1[int_0])
		{
		case 1:
			conditionalFormattingValue_0.Type = FormatConditionValueType.Number;
			return method_82(int_0 + 1, conditionalFormattingValue_0);
		case 2:
			conditionalFormattingValue_0.Type = FormatConditionValueType.Min;
			return int_0 + 3;
		case 3:
			conditionalFormattingValue_0.Type = FormatConditionValueType.Max;
			return int_0 + 3;
		case 4:
			conditionalFormattingValue_0.Type = FormatConditionValueType.Percent;
			return method_82(int_0 + 1, conditionalFormattingValue_0);
		case 5:
			conditionalFormattingValue_0.Type = FormatConditionValueType.Percentile;
			return method_82(int_0 + 1, conditionalFormattingValue_0);
		default:
			return int_0;
		case 7:
			conditionalFormattingValue_0.Type = FormatConditionValueType.Formula;
			return method_82(int_0 + 1, conditionalFormattingValue_0);
		}
	}

	private int method_82(int int_0, ConditionalFormattingValue conditionalFormattingValue_0)
	{
		if (BitConverter.ToUInt16(byte_1, int_0) != 0)
		{
			byte[] array = new byte[BitConverter.ToUInt16(byte_1, int_0) + 2];
			Array.Copy(byte_1, int_0, array, 0, array.Length);
			conditionalFormattingValue_0.method_7(array);
			return int_0 + array.Length;
		}
		conditionalFormattingValue_0.method_0(BitConverter.ToDouble(byte_1, int_0 + 2));
		return int_0 + 10;
	}

	private void method_83(Class1723 class1723_0)
	{
		method_5(class1723_0);
		int num = BitConverter.ToUInt16(byte_1, 16);
		if (hashtable_0[num] == null)
		{
			return;
		}
		num = (int)hashtable_0[num];
		FormatConditionCollection formatConditionCollection = worksheet_0.ConditionalFormattings[num];
		if (byte_1[12] == 0)
		{
			int num2 = 18;
			int num3 = BitConverter.ToUInt16(byte_1, 18);
			if (num3 < 0 || num3 >= formatConditionCollection.Count)
			{
				return;
			}
			num2 += 2;
			FormatCondition formatCondition = formatConditionCollection[num3];
			formatCondition.operatorType_0 = Class1673.smethod_12(byte_1[num2]);
			num2++;
			int int_ = byte_1[num2];
			num2++;
			formatCondition.Priority = BitConverter.ToUInt16(byte_1, num2);
			if (formatCondition.Priority > formatConditionCollection.worksheet_0.method_3())
			{
				formatConditionCollection.worksheet_0.method_4(formatCondition.Priority + 1);
			}
			num2 += 2;
			if (((uint)byte_1[num2] & (true ? 1u : 0u)) != 0)
			{
				formatCondition.StopIfTrue = (byte_1[num2] & 2) != 0;
				if (byte_1[num2 + 1] != 0)
				{
					num2 += 2;
					num2 = method_77(num2, formatCondition.Style);
				}
				else
				{
					num2 += 2;
				}
				method_79(formatCondition, int_, num2, bool_0: false, 0);
			}
		}
		else
		{
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 2170)
			{
				class1723_0.Seek(-2);
				return;
			}
			FormatCondition formatCondition_ = new FormatCondition(formatConditionCollection);
			method_78(class1723_0, formatCondition_);
			formatConditionCollection.AddCondition(formatCondition_);
		}
	}

	private void method_84(Class1723 class1723_0)
	{
		method_5(class1723_0);
		ConditionalFormattingCollection conditionalFormattings = worksheet_0.ConditionalFormattings;
		FormatConditionCollection formatConditionCollection = null;
		int num = conditionalFormattings.Add();
		formatConditionCollection = conditionalFormattings[num];
		formatConditionCollection.Read(byte_1, ushort_1);
		hashtable_0[BitConverter.ToUInt16(byte_1, 2) >> 1] = num;
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			case 433:
			{
				method_5(class1723_0);
				if (formatConditionCollection == null)
				{
					formatConditionCollection = conditionalFormattings[conditionalFormattings.Count - 1];
				}
				FormatCondition formatCondition = new FormatCondition(formatConditionCollection);
				formatCondition.Read(byte_1, ushort_1);
				formatCondition.Priority = formatConditionCollection.worksheet_0.method_3();
				Worksheet worksheet = formatConditionCollection.worksheet_0;
				worksheet.method_4(worksheet.method_3() + 1);
				formatCondition.StopIfTrue = true;
				formatConditionCollection.AddCondition(formatCondition);
				break;
			}
			case 432:
				method_5(class1723_0);
				num = conditionalFormattings.Add();
				formatConditionCollection = conditionalFormattings[num];
				formatConditionCollection.Read(byte_1, ushort_1);
				hashtable_0[BitConverter.ToUInt16(byte_1, 2) >> 1] = num;
				break;
			default:
				class1723_0.method_3(-2);
				return;
			}
		}
	}

	private void method_85(Class1723 class1723_0)
	{
		method_5(class1723_0);
		PaneCollection paneCollection = worksheet_0.method_1();
		paneCollection.method_5(BitConverter.ToUInt16(byte_1, 2));
		paneCollection.method_7(BitConverter.ToUInt16(byte_1, 0));
		paneCollection.method_2(BitConverter.ToUInt16(byte_1, 4));
		paneCollection.method_3(BitConverter.ToUInt16(byte_1, 6));
		paneCollection.method_1(byte_1[8]);
	}

	private void method_86(Class1723 class1723_0)
	{
		method_5(class1723_0);
		ushort num = BitConverter.ToUInt16(byte_1, 0);
		Class1133 @class = cells_0.method_18();
		for (int i = 0; i < num; i++)
		{
			CellArea cellArea_ = default(CellArea);
			cellArea_.StartRow = BitConverter.ToUInt16(byte_1, 8 * i + 2);
			cellArea_.EndRow = BitConverter.ToUInt16(byte_1, 8 * i + 4);
			cellArea_.StartColumn = byte_1[8 * i + 6];
			cellArea_.EndColumn = byte_1[8 * i + 8];
			@class.Add(cellArea_);
		}
	}

	private void method_87(Class1723 class1723_0)
	{
		for (int i = 0; i < worksheetCollection_0.Count; i++)
		{
			worksheetCollection_0.Workbook.method_30();
			object obj = hashtable_1[(int)class1723_0.Position];
			if (obj != null)
			{
				worksheet_0 = worksheetCollection_0[(int)obj];
			}
			else
			{
				worksheet_0 = worksheetCollection_0[i];
			}
			cells_0 = worksheet_0.Cells;
			rowCollection_0 = cells_0.Rows;
			if (worksheet_0.Type == SheetType.Chart)
			{
				Chart chart = new Chart(worksheet_0);
				worksheet_0.Charts.Add(chart);
				method_3(2057, class1723_0);
				class1723_0.method_3(-2);
				Class1389 @class = new Class1389(this, class1723_0, worksheetCollection_0, worksheet_0);
				@class.method_0(chart);
			}
			else
			{
				method_51(class1723_0);
			}
		}
	}

	internal void method_88(Class1317 class1317_2)
	{
		class1317_0 = class1317_2;
		MemoryStream stream = class1317_2.method_9().GetStream("Workbook");
		if (stream == null)
		{
			stream = class1317_2.method_9().GetStream("WORKBOOK");
			class1317_2.method_9().Remove("WORKBOOK");
		}
		else
		{
			class1317_2.method_9().Remove("Workbook");
		}
		if (stream == null)
		{
			stream = class1317_2.method_9().GetStream("Book");
			if (stream == null)
			{
				return;
			}
			byte[] array = new byte[6];
			stream.Read(array, 0, array.Length);
			if (array[0] != 9 || array[1] != 8 || array[2] != 16 || array[3] != 0 || array[4] != 0 || array[5] != 6)
			{
				throw new CellsException(ExceptionType.UnsupportedFeature, "This Excel files contains BIFF7(Excel95 or earlier file format) records.");
			}
			class1317_2.method_9().Remove("Book");
			stream.Seek(-6L, SeekOrigin.Current);
		}
		method_92(stream);
		if (stream.Length > 20000000)
		{
			stream = null;
			GC.Collect();
			GC.WaitForPendingFinalizers();
		}
		else
		{
			stream = null;
		}
		for (int i = 0; i < worksheetCollection_0.Count; i++)
		{
			if (worksheetCollection_0[i].pivotTableCollection_0 != null && worksheetCollection_0[i].pivotTableCollection_0.Count != 0)
			{
				foreach (PivotTable item in worksheetCollection_0[i].pivotTableCollection_0)
				{
					if (item.class1141_0 == null || item.class1141_0.string_3 == null || item.class1141_0.string_3.Length == 0)
					{
						continue;
					}
					Name name = worksheetCollection_0.Names[item.class1141_0.string_3];
					if (name == null)
					{
						continue;
					}
					Range range = name.GetRange();
					if (range != null)
					{
						Class1139 @class = new Class1139(item.class1141_0, range.Worksheet, range.RefersTo);
						@class.range_0 = range;
						@class.range_1 = range;
						if (item.class1141_0.class1139_0 == null)
						{
							item.class1141_0.class1139_0 = new Class1139[1];
							item.class1141_0.class1139_0[0] = @class;
						}
					}
				}
			}
			if (worksheetCollection_0[i].method_18() == null || worksheetCollection_0[i].OleObjects.Count == 0)
			{
				continue;
			}
			foreach (OleObject oleObject in worksheetCollection_0[i].OleObjects)
			{
				if (oleObject.method_97() > worksheetCollection_0.method_0())
				{
					worksheetCollection_0.method_1(oleObject.method_97());
				}
				if (!oleObject.method_82())
				{
					continue;
				}
				string text = "MBD" + Class1025.smethod_7(oleObject.method_97());
				Class1319 class2 = class1317_2.method_9().method_0(text);
				MemoryStream memoryStream = null;
				if (Class1677.smethod_14(class2))
				{
					memoryStream = class2.GetStream("\u0001Ole10Native");
					oleObject.method_86(bool_6: true);
				}
				else if (Class1677.smethod_13(class2))
				{
					bool flag = false;
					if (class2.GetStream("Workbook") != null)
					{
						oleObject.method_87(OleFileType.Xls);
					}
					else if (class2.GetStream("PowerPoint Document") != null)
					{
						oleObject.method_87(OleFileType.Ppt);
					}
					else if (class2.GetStream("WordDocument") != null)
					{
						oleObject.method_87(OleFileType.Doc);
					}
					else if (class2.GetStream("Equation Native") != null)
					{
						oleObject.method_87(OleFileType.MSEquation);
					}
					else if (class2.method_0("MAPIMessage") != null)
					{
						oleObject.method_87(OleFileType.MapiMessage);
						Guid guid_ = class2.method_1();
						class2 = class2.method_0("MAPIMessage");
						class2.method_2(guid_);
					}
					else if (class2.GetStream("Package") != null)
					{
						Guid guid_2 = class2.method_1();
						memoryStream = class2.GetStream("Package");
						class2.method_2(guid_2);
						flag = true;
						string text2 = text;
						switch (CellsHelper.DetectFileFormat(memoryStream))
						{
						default:
							flag = false;
							break;
						case FileFormatType.Pptx:
							text2 += ".pptx";
							oleObject.method_87(OleFileType.Pptx);
							break;
						case FileFormatType.Docx:
							text2 += ".docx";
							oleObject.method_87(OleFileType.Docx);
							break;
						case FileFormatType.Xlsb:
							oleObject.method_87(OleFileType.Xlsb);
							break;
						case FileFormatType.Xlsx:
							text2 += ".xlsx";
							oleObject.method_87(OleFileType.Xlsx);
							break;
						}
						if (flag)
						{
							oleObject.method_88(text2, bool_6: false, bool_7: false);
						}
					}
					if (!flag)
					{
						Class1317 class3 = new Class1317(class2);
						memoryStream = new MemoryStream();
						class3.Save(memoryStream);
					}
				}
				else
				{
					memoryStream = class2.GetStream("CONTENTS");
					class2.Remove("CONTENTS");
				}
				if (memoryStream != null)
				{
					class1317_2.method_9().Remove(text);
					oleObject.method_100(class2.method_1());
					oleObject.method_70(bool_6: false);
					if (oleObject.method_85())
					{
						oleObject.method_84(memoryStream);
					}
					else
					{
						oleObject.ObjectData = memoryStream.ToArray();
					}
				}
			}
		}
		IList keyList = class1317_2.method_9().GetKeyList();
		for (int j = 0; j < keyList.Count; j++)
		{
			string text3 = (string)keyList[j];
			if (text3.StartsWith("MBD"))
			{
				Convert.ToInt32(text3.Substring(3), 16);
			}
		}
		stream = class1317_2.method_9().GetStream("User Names");
		if (stream != null)
		{
			workbook_0.Settings.Shared = true;
		}
		stream = class1317_2.method_9().GetStream("XML");
		if (stream != null)
		{
			class1317_2.method_9().Remove("XML");
			Encoding.UTF8.GetString(stream.GetBuffer());
			XmlTextReader xmlTextReader = null;
			try
			{
				xmlTextReader = Class1029.smethod_1(stream);
				Class1547 class1547_ = new Class1547(worksheetCollection_0.Workbook);
				Class450 class4 = new Class450(class1547_);
				class4.Read(xmlTextReader);
			}
			finally
			{
				xmlTextReader?.Close();
			}
		}
	}

	private void method_89(Stream stream_0, Class1317 class1317_2, Class1637 class1637_0)
	{
		Class1728 @class = new Class1728();
		long position = stream_0.Position;
		@class.Decrypt(stream_0, class1637_0);
		stream_0.Position = position;
		Class1319 class2 = class1317_2.method_9().method_0("_SX_DB_CUR");
		if (class2 != null)
		{
			for (int i = 0; i < class2.Count; i++)
			{
				MemoryStream memoryStream = (MemoryStream)class2.GetByIndex(i);
				@class.Decrypt(memoryStream, class1637_0);
				memoryStream.Position = 0L;
			}
		}
	}

	private void method_90(Stream stream_0, Class1317 class1317_2, Class1647 class1647_0)
	{
		Class1728 @class = new Class1728();
		long position = stream_0.Position;
		@class.method_1(stream_0, class1647_0);
		stream_0.Position = position;
		Class1319 class2 = class1317_2.method_9().method_0("_SX_DB_CUR");
		if (class2 != null)
		{
			for (int i = 0; i < class2.Count; i++)
			{
				MemoryStream memoryStream = (MemoryStream)class2.GetByIndex(i);
				@class.method_1(memoryStream, class1647_0);
				memoryStream.Position = 0L;
			}
		}
	}

	private void method_91(Stream stream_0, Class1317 class1317_2, Class1638 class1638_0)
	{
		Class1728 @class = new Class1728();
		long position = stream_0.Position;
		@class.method_2(stream_0, class1638_0);
		stream_0.Position = position;
		Class1319 class2 = class1317_2.method_9().method_0("_SX_DB_CUR");
		if (class2 != null)
		{
			for (int i = 0; i < class2.Count; i++)
			{
				MemoryStream memoryStream = (MemoryStream)class2.GetByIndex(i);
				@class.method_2(memoryStream, class1638_0);
				memoryStream.Position = 0L;
			}
		}
	}

	internal Class1317 Read(Stream stream_0)
	{
		class1317_1 = new Class1317(stream_0);
		method_88(class1317_1);
		return class1317_1;
	}

	internal void Read(Class1317 class1317_2)
	{
		class1317_1 = class1317_2;
		method_88(class1317_2);
	}

	private void method_92(MemoryStream memoryStream_0)
	{
		Class1723 class1723_ = new Class1723(memoryStream_0);
		worksheetCollection_0.method_35();
		method_9(class1723_);
		int num = 0;
		if (worksheetCollection_0.method_39() != null && worksheetCollection_0.method_39().Count != 0)
		{
			for (int i = 0; i < worksheetCollection_0.method_39().Count; i++)
			{
				Class1718 @class = worksheetCollection_0.method_39()[i];
				if (@class.method_12())
				{
					num = i;
					break;
				}
			}
		}
		else
		{
			worksheetCollection_0.method_40(new Class1303());
			Class1718 class2 = new Class1718();
			class2.method_13(bool_0: true);
			worksheetCollection_0.method_39().Add(class2);
			num = 0;
		}
		for (int j = 0; j < worksheetCollection_0.Count; j++)
		{
			worksheetCollection_0.method_32().method_2((ushort)num, (ushort)j, (ushort)j);
		}
		worksheetCollection_0.ExternalLinks.method_1(worksheetCollection_0.method_39());
		method_87(class1723_);
		method_93();
	}

	private void method_93()
	{
		worksheetCollection_0.class1301_0.Clear();
	}

	[Attribute0(true)]
	private void method_94(Class1723 class1723_0, bool bool_0)
	{
		ushort_0 = class1723_0.method_2(byte_0);
		if (bool_0)
		{
			if (ushort_0 == 2150)
			{
				method_5(class1723_0);
				return;
			}
			throw new IOException("File is corrupted");
		}
		ushort num = ushort_0;
		if (num != 60 && num != 235)
		{
			throw new IOException("File is corrupted");
		}
		method_5(class1723_0);
	}

	[Attribute0(true)]
	private void method_95(Class1723 class1723_0, Class1703 class1703_0)
	{
		int num = 0;
		int num2 = 0;
		ushort num3 = 0;
		byte[] array = null;
		method_5(class1723_0);
		int num4 = 0;
		bool bool_;
		if (bool_ = class1703_0.Type == Enum181.const_1)
		{
			num4 = 14;
		}
		int num5 = num4;
		num2 = BitConverter.ToInt32(byte_1, num5 + 4);
		num5 += 8;
		short num6 = 0;
		byte b = 0;
		while (num2 > 0)
		{
			if (num5 < ushort_1 && num5 + 8 > ushort_1)
			{
				array = new byte[8];
				int num7 = ushort_1 - num5;
				Array.Copy(byte_1, num5, array, 0, num7);
				method_94(class1723_0, bool_);
				Array.Copy(byte_1, num4, array, num7, 8 - num7);
				num6 = (short)(BitConverter.ToUInt16(array, 0) >> 4);
				b = (byte)(array[0] & 0xFu);
				num3 = BitConverter.ToUInt16(array, 2);
				num = BitConverter.ToInt32(array, 4);
				num5 = num4 + 8 - num7;
			}
			else
			{
				if (num5 == ushort_1)
				{
					method_94(class1723_0, bool_);
					num5 = num4;
				}
				num6 = (short)(BitConverter.ToUInt16(byte_1, num5) >> 4);
				b = (byte)(byte_1[num5] & 0xFu);
				num3 = BitConverter.ToUInt16(byte_1, num5 + 2);
				num = BitConverter.ToInt32(byte_1, num5 + 4);
				num5 += 8;
			}
			num2 -= num + 8;
			switch (num3)
			{
			case 61446:
			{
				Class1702 class4 = class1703_0.method_2();
				Class1705 class5 = class4.method_0();
				class5.int_0 = BitConverter.ToInt32(byte_1, num5);
				int num17 = BitConverter.ToInt32(byte_1, num5 + 4) - 1;
				class5.int_1 = BitConverter.ToInt32(byte_1, num5 + 8);
				class5.int_2 = BitConverter.ToInt32(byte_1, num5 + 12);
				num5 += 16;
				for (int j = 0; j < num17; j++)
				{
					Class1706 class6 = new Class1706();
					class4.method_1().Add(class6);
					if (num5 < ushort_1 && num5 + 8 > ushort_1)
					{
						array = new byte[8];
						int num18 = ushort_1 - num5;
						Array.Copy(byte_1, num5, array, 0, num18);
						method_94(class1723_0, bool_);
						num5 = num4;
						Array.Copy(byte_1, num5, array, num18, 8 - num18);
						class6.int_0 = BitConverter.ToInt32(array, 0);
						class6.int_1 = BitConverter.ToInt32(array, 4);
						num5 += 8 - num18;
					}
					else
					{
						if (num5 == ushort_1)
						{
							method_94(class1723_0, bool_);
							num5 = num4;
						}
						class6.int_0 = BitConverter.ToInt32(byte_1, num5);
						class6.int_1 = BitConverter.ToInt32(byte_1, num5 + 4);
						num5 += 8;
					}
					if (class6.int_0 > class4.method_2())
					{
						class4.method_3((ushort)class6.int_0);
					}
				}
				break;
			}
			default:
				array = new byte[8 + num];
				Array.Copy(BitConverter.GetBytes((short)((num6 << 4) | b)), 0, array, 0, 2);
				Array.Copy(BitConverter.GetBytes(num3), 0, array, 2, 2);
				Array.Copy(BitConverter.GetBytes(num), 0, array, 4, 4);
				num5 = method_97(class1723_0, num4, num5, array, 8, num);
				class1703_0.method_4().Add(array);
				break;
			case 61441:
			{
				int num8 = num;
				int num9 = num6;
				bool flag = true;
				while (num8 != 0)
				{
					if (flag)
					{
						if (num5 < ushort_1 && num5 + 8 > ushort_1)
						{
							array = new byte[8];
							int num10 = ushort_1 - num5;
							Array.Copy(byte_1, num5, array, 0, num10);
							method_94(class1723_0, bool_);
							num5 = num4;
							Array.Copy(byte_1, num5, array, num10, 8 - num10);
							num6 = (short)(BitConverter.ToUInt16(array, num5) >> 4);
							num3 = BitConverter.ToUInt16(array, 2);
							num = BitConverter.ToInt32(array, 4);
							num5 += 8 - num10;
						}
						else
						{
							if (num5 == ushort_1)
							{
								method_94(class1723_0, bool_);
								num5 = num4;
							}
							num6 = (short)(BitConverter.ToUInt16(byte_1, num5) >> 4);
							num3 = BitConverter.ToUInt16(byte_1, num5 + 2);
							num = BitConverter.ToInt32(byte_1, num5 + 4);
							num5 += 8;
						}
					}
					if (num3 != 61447)
					{
						if (num9 <= 0)
						{
							num8 -= 8 + num;
							if (num != 0)
							{
								byte[] byte_ = new byte[num];
								num5 = method_97(class1723_0, num4, num5, byte_, 0, num);
							}
							continue;
						}
						throw new IOException("File is corrupted");
					}
					num9--;
					Class1696 @class = null;
					int num11 = 0;
					if (num <= 38)
					{
						num = 36;
					}
					num8 -= num + 8;
					@class = new Class1696();
					class1703_0.method_0().Add(@class);
					@class.method_12((byte)num6);
					byte[] array2 = new byte[num];
					num5 = method_97(class1723_0, num4, num5, array2, 0, num);
					Class1704 class2 = @class.method_5();
					class2.byte_0 = array2[num11];
					class2.byte_1 = array2[num11 + 1];
					bool flag2 = true;
					for (int i = 0; i < 16; i++)
					{
						if (array2[num11 + 2 + i] != 0)
						{
							flag2 = false;
							break;
						}
					}
					num11 += 18;
					class2.short_0 = BitConverter.ToInt16(array2, num11);
					uint num12 = BitConverter.ToUInt32(array2, num11 + 2);
					num11 += 6;
					class2.int_0 = BitConverter.ToInt32(array2, num11);
					num11 += 8;
					class2.byte_3 = array2[num11];
					byte b2 = array2[num11 + 1];
					class2.byte_4 = array2[num11 + 2];
					class2.byte_5 = array2[num11 + 3];
					num11 += 4;
					if (b2 != 0)
					{
						num11 += b2;
					}
					if (num == 36)
					{
						if (flag2 || num12 <= 8)
						{
							@class.method_5().byte_2 = new byte[16];
							continue;
						}
						array2 = new byte[8];
						num5 = method_97(class1723_0, num4, num5, array2, 0, 8);
						ushort num13 = BitConverter.ToUInt16(array2, 2);
						if (num13 == 61447)
						{
							num6 = (short)(BitConverter.ToUInt16(array2, 0) >> 4);
							num3 = num13;
							num = BitConverter.ToInt32(array2, 4);
							flag = false;
							@class.method_5().byte_2 = new byte[16];
							continue;
						}
						num11 = 0;
						num = BitConverter.ToInt32(array2, 0 + 4);
						num8 -= num + 8;
					}
					flag = true;
					Class1695 class3 = @class.method_4();
					class3.method_5((short)(BitConverter.ToUInt16(array2, num11) >> 4));
					class3.method_3(BitConverter.ToUInt16(array2, num11 + 2));
					num = BitConverter.ToInt32(array2, num11 + 4);
					num11 += 8;
					if (array2.Length == 8)
					{
						array2 = new byte[num];
						num5 = method_97(class1723_0, num4, num5, array2, 0, num);
						num11 = 0;
					}
					int num14 = num - (array2.Length - num11);
					num8 -= num14;
					bool flag3 = false;
					switch (@class.method_11())
					{
					case 4:
						flag3 = (class3.method_4() ^ 0x542) == 1;
						break;
					case 6:
						flag3 = (class3.method_4() ^ 0x6E0) == 1;
						break;
					case 7:
						flag3 = (class3.method_4() ^ 0x7A8) == 1;
						break;
					}
					if (class3.method_9())
					{
						num11 += 16;
						if (flag3)
						{
							class3.method_1(new byte[16]);
							Array.Copy(array2, num11, class3.method_0(), 0, 16);
							num11 += 16;
						}
						class3.int_0 = BitConverter.ToInt32(array2, num11);
						num11 += 4;
						int num15 = BitConverter.ToInt32(array2, num11 + 8) - BitConverter.ToInt32(array2, num11);
						num11 += 16;
						@class.Width = (int)((double)(BitConverter.ToInt32(array2, num11) * worksheetCollection_0.method_75() / 914400) + 0.5);
						@class.Height = (int)((double)(BitConverter.ToInt32(array2, num11 + 4) * worksheetCollection_0.method_76() / 914400) + 0.5);
						if (@class.method_11() == 3 && @class.Width != 0)
						{
							@class.method_10(num15 * 96 / @class.Width);
						}
						num11 += 8;
						num11 += 4;
						class3.byte_2 = array2[num11];
						class3.byte_3 = array2[num11 + 1];
						num11 += 2;
					}
					else
					{
						if (flag3)
						{
							class3.method_1(new byte[16]);
							Array.Copy(array2, num11, class3.method_0(), 0, 16);
							num11 += 16;
						}
						class3.byte_4 = array2[num11 + 16];
						num11 += 17;
					}
					int num16 = array2.Length - num11;
					class3.method_7(new byte[num16 + num14]);
					Array.Copy(array2, num11, class3.method_6(), 0, num16);
					if (num14 != 0)
					{
						num5 = method_97(class1723_0, num4, num5, class3.method_6(), num16, num14);
					}
					byte[] byte_2 = Class1026.smethod_0(class3.method_6());
					@class.method_5().byte_2 = byte_2;
					if (@class.method_4().method_9())
					{
						continue;
					}
					byte b3 = @class.method_11();
					if (b3 == 7)
					{
						@class.Width = BitConverter.ToInt32(class3.method_6(), 4);
						@class.Height = BitConverter.ToInt32(class3.method_6(), 8);
						continue;
					}
					try
					{
						int[] array3 = Class1181.smethod_0(@class.method_11() == 254, class3.method_6(), worksheetCollection_0.method_75());
						@class.Width = array3[0];
						@class.Height = array3[1];
					}
					catch
					{
					}
				}
				break;
			}
			}
		}
	}

	internal void method_96(Class1723 class1723_0, PageSetup pageSetup_0)
	{
		method_5(class1723_0);
		int num = 14;
		ShapeCollection shapeCollection = null;
		if (byte_1[14 + 2] == 2 && byte_1[num + 3] == 240)
		{
			int int_ = BitConverter.ToInt16(byte_1, num + 8) >> 4;
			shapeCollection = new ShapeCollection(worksheetCollection_0, worksheet_0, worksheetCollection_0.method_87(), pageSetup_0, int_);
			pageSetup_0.method_31(shapeCollection);
			num += 16;
			shapeCollection.method_4().method_2().method_2(BitConverter.ToInt32(byte_1, num));
			shapeCollection.method_4().method_2().method_4(BitConverter.ToInt32(byte_1, num + 4));
			num += 16;
			int num2 = BitConverter.ToInt32(byte_1, num + 4);
			num += 8 + num2;
		}
		if (shapeCollection == null)
		{
			shapeCollection = pageSetup_0.Shapes;
		}
		Picture picture = null;
		ushort num3 = 0;
		ushort num4 = 1;
		while (num < ushort_1)
		{
			switch (BitConverter.ToUInt16(byte_1, num + 2))
			{
			default:
				num += 8 + BitConverter.ToInt32(byte_1, num + 4);
				break;
			case 61456:
				num += 8;
				picture.method_27().method_7().method_4(PlacementType.FreeFloating);
				picture.method_27().method_7().Left = 0;
				picture.method_27().method_7().Top = 0;
				picture.method_27().method_7().Right = BitConverter.ToInt32(byte_1, num);
				picture.method_27().method_7().Bottom = BitConverter.ToInt32(byte_1, num + 4);
				num += 8;
				break;
			case 61450:
				picture.method_27().method_9().method_1((short)(BitConverter.ToUInt16(byte_1, num) >> 4));
				num += 8;
				picture.method_27().method_9().method_3(BitConverter.ToInt32(byte_1, num));
				picture.method_27().method_9().method_5(BitConverter.ToInt32(byte_1, num + 4));
				num += 8;
				break;
			case 61451:
			{
				picture.method_27().method_2().Clear();
				int num5 = BitConverter.ToInt16(byte_1, num) >> 4;
				num += 8;
				int num6 = num + num5 * 6;
				ushort num7 = 0;
				int num8 = 0;
				for (int i = 0; i < num5; i++)
				{
					num7 = BitConverter.ToUInt16(byte_1, num);
					num8 = BitConverter.ToInt32(byte_1, num + 2);
					if ((num7 & 0x8000u) != 0)
					{
						if (num8 != 0)
						{
							byte[] array = new byte[num8];
							Array.Copy(byte_1, num6, array, 0, num8);
							picture.method_27().method_2().method_1(num7, Enum183.const_4, array);
							num6 += num8;
						}
					}
					else
					{
						picture.method_27().method_2().method_1(num7, Enum183.const_0, num8);
					}
					num += 6;
				}
				num = num6;
				break;
			}
			case 61444:
				picture = new Picture(shapeCollection);
				picture.method_29(null);
				picture.method_24(num4++);
				shapeCollection.Add(picture);
				num += 8;
				break;
			}
		}
	}

	private int method_97(Class1723 class1723_0, int int_0, int int_1, byte[] byte_2, int int_2, int int_3)
	{
		if (int_1 + int_3 <= ushort_1)
		{
			Array.Copy(byte_1, int_1, byte_2, int_2, int_3);
			int_1 += int_3;
			return int_1;
		}
		int num = 0;
		int num2 = int_3 + int_2;
		while (num2 - int_2 > ushort_1 - int_1)
		{
			num = ushort_1 - int_1;
			Array.Copy(byte_1, int_1, byte_2, int_2, num);
			int_2 += num;
			method_94(class1723_0, int_0 != 0);
			int_1 = int_0;
		}
		num = num2 - int_2;
		Array.Copy(byte_1, int_1, byte_2, int_2, num);
		int_1 += num;
		return int_1;
	}

	private InternalColor method_98(byte[] byte_2, int int_0)
	{
		InternalColor internalColor = new InternalColor(bool_0: false);
		double tint = (double)BitConverter.ToInt16(byte_2, int_0 + 2) * 1.0 / 32767.0;
		internalColor.Tint = tint;
		switch (byte_2[int_0])
		{
		case 0:
			internalColor.method_3(bool_0: true);
			break;
		case 1:
		{
			int num = BitConverter.ToInt32(byte_2, int_0 + 4);
			if (num >= 64)
			{
				internalColor.SetColor(ColorType.AutomaticIndex, num);
			}
			else
			{
				internalColor.SetColor(ColorType.IndexedColor, num);
			}
			break;
		}
		case 2:
		{
			int int_ = (byte_2[int_0 + 4] << 16) + (byte_2[int_0 + 5] << 8) + byte_2[int_0 + 6];
			internalColor.SetColor(ColorType.RGB, int_);
			break;
		}
		case 3:
			internalColor.SetColor(ColorType.Theme, BitConverter.ToInt32(byte_2, int_0 + 4));
			break;
		}
		return internalColor;
	}

	private void method_99(Class1723 class1723_0)
	{
		method_5(class1723_0);
		if (BitConverter.ToUInt16(byte_1, 12) == 0)
		{
			int num = BitConverter.ToUInt16(byte_1, 14);
			int int_ = BitConverter.ToUInt16(byte_1, 18);
			int int_2 = 20;
			Class1685 value = method_100(byte_1, ref int_2, int_);
			hashtable_2.Add(num, value);
		}
	}

	private Class1685 method_100(byte[] byte_2, ref int int_0, int int_1)
	{
		Class1685 @class = new Class1685();
		for (int i = 0; i < int_1 && int_0 < byte_2.Length; i++)
		{
			Enum235 @enum = (Enum235)byte_2[int_0];
			Class1684 class2 = new Class1684();
			class2.enum235_0 = @enum;
			int num = BitConverter.ToUInt16(byte_2, int_0 + 2);
			switch (@enum)
			{
			case Enum235.const_0:
			case Enum235.const_1:
				class2.object_0 = Color.FromArgb(byte_2[int_0 + 4], byte_2[int_0 + 5], byte_2[int_0 + 6]);
				break;
			case Enum235.const_6:
			{
				int num2 = int_0 + 4;
				GradientFill gradientFill = (GradientFill)(class2.object_0 = new GradientFill(null, null));
				if (byte_2[num2] == 0)
				{
					gradientFill.object_0 = new Class925();
					num2 += 4;
					gradientFill.method_1().int_0 = (int)(BitConverter.ToDouble(byte_2, num2) * 6000.0);
					num2 += 8;
					gradientFill.method_3().int_0 = (int)(BitConverter.ToDouble(byte_2, num2) * 100000.0);
					gradientFill.method_3().int_3 = (int)(BitConverter.ToDouble(byte_2, num2 + 8) * 100000.0);
					gradientFill.method_3().int_1 = (int)(BitConverter.ToDouble(byte_2, num2 + 16) * 100000.0);
					gradientFill.method_3().int_2 = (int)(BitConverter.ToDouble(byte_2, num2 + 24) * 100000.0);
					num2 += 32;
				}
				else
				{
					num2 += 4;
					gradientFill.object_0 = new Class926();
					gradientFill.method_2().enum128_0 = Enum128.const_1;
					num2 += 8;
					gradientFill.method_2().int_0 = (int)(BitConverter.ToDouble(byte_2, num2) * 100000.0);
					gradientFill.method_2().int_3 = (int)(BitConverter.ToDouble(byte_2, num2 + 8) * 100000.0);
					gradientFill.method_2().int_1 = (int)(BitConverter.ToDouble(byte_2, num2 + 16) * 100000.0);
					gradientFill.method_2().int_2 = (int)(BitConverter.ToDouble(byte_2, num2 + 24) * 100000.0);
					num2 += 32;
				}
				int num3 = BitConverter.ToInt32(byte_2, num2);
				num2 += 4;
				for (int j = 0; j < num3; j++)
				{
					GradientStop gradientStop = new GradientStop(gradientFill.GradientStops);
					gradientStop.internalColor_0.IsShapeColor = false;
					gradientFill.GradientStops.Add(gradientStop);
					switch (byte_2[num2])
					{
					case 1:
						gradientStop.internalColor_0.SetColor(ColorType.IndexedColor, BitConverter.ToInt32(byte_2, num2 + 2));
						break;
					case 2:
					{
						int int_2 = (byte_2[num2 + 2] << 16) + (byte_2[num2 + 3] << 8) + byte_2[num2 + 4];
						gradientStop.internalColor_0.SetColor(ColorType.RGB, int_2);
						break;
					}
					case 3:
						gradientStop.internalColor_0.SetColor(ColorType.Theme, BitConverter.ToInt32(byte_2, num2 + 2));
						break;
					}
					num2 += 6;
					gradientStop.Position = BitConverter.ToDouble(byte_2, num2) * 100.0;
					num2 += 8;
					gradientStop.internalColor_0.Tint = BitConverter.ToDouble(byte_2, num2);
					num2 += 8;
				}
				break;
			}
			default:
				int_0 += num;
				continue;
			case Enum235.const_4:
			case Enum235.const_5:
			case Enum235.const_7:
			case Enum235.const_8:
			case Enum235.const_9:
			case Enum235.const_10:
			case Enum235.const_11:
			case Enum235.const_13:
				class2.object_0 = method_98(byte_2, int_0 + 4);
				break;
			case Enum235.const_14:
				class2.object_0 = (int)byte_2[int_0 + 4];
				break;
			case Enum235.const_15:
				class2.object_0 = BitConverter.ToInt16(byte_2, int_0 + 4);
				break;
			}
			int_0 += num;
			@class.Add(class2);
		}
		return @class;
	}

	internal void method_101(Border border_0, byte[] byte_2, int int_0)
	{
		bool isNotSet = false;
		border_0.InternalColor = method_102(byte_2, int_0, out isNotSet);
		int_0 += 8;
		border_0.LineStyle = Class1224.smethod_10(byte_1[int_0]);
	}

	internal InternalColor method_102(byte[] buffer, int offset, out bool isNotSet)
	{
		isNotSet = false;
		InternalColor internalColor = new InternalColor(bool_0: false);
		internalColor.Tint = (double)BitConverter.ToInt16(buffer, offset + 2) / 32767.0;
		switch ((buffer[offset] & 0xFE) >> 1)
		{
		default:
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
				internalColor.SetColor(ColorType.IndexedColor, buffer[offset + 1]);
			}
			break;
		case 2:
			offset += 4;
			internalColor.SetColor(ColorType.RGB, (buffer[offset] << 16) + (buffer[offset + 1] << 8) + buffer[offset + 2]);
			break;
		case 3:
			if (buffer[offset + 1] >= 64)
			{
				internalColor.method_3(bool_0: true);
			}
			else
			{
				internalColor.SetColor(ColorType.Theme, buffer[offset + 1]);
			}
			break;
		case 4:
			isNotSet = true;
			break;
		}
		return internalColor;
	}

	private void method_103(Class1723 class1723_0)
	{
		method_5(class1723_0);
		Class1205 @class = new Class1205(worksheetCollection_0);
		bool flag = false;
		bool flag2 = false;
		@class.bool_0 = (byte_1[12] & 2) != 0;
		int num = 16;
		int num2 = BitConverter.ToInt16(byte_1, 16);
		num = 16 + 2;
		Border border = null;
		bool isNotSet = false;
		for (int i = 0; i < num2; i++)
		{
			int num3 = BitConverter.ToInt16(byte_1, num);
			int num4 = BitConverter.ToInt16(byte_1, num + 2);
			switch (num3)
			{
			case 0:
				@class.style_0.Pattern = Class1224.smethod_13(byte_1[num + 4]);
				break;
			case 1:
				@class.style_0.ForeInternalColor = method_102(byte_1, num + 4, out isNotSet);
				@class.style_0.method_36(StyleModifyFlag.ForegroundColor);
				break;
			case 2:
				@class.style_0.BackgroundInternalColor = method_102(byte_1, num + 4, out isNotSet);
				@class.style_0.method_36(StyleModifyFlag.BackgroundColor);
				break;
			case 5:
				@class.Font.InternalColor = method_102(byte_1, num + 4, out isNotSet);
				@class.style_0.method_36(StyleModifyFlag.FontColor);
				break;
			case 6:
				method_101(@class.style_0.Borders[BorderType.TopBorder], byte_1, num + 4);
				break;
			case 7:
				method_101(@class.style_0.Borders[BorderType.BottomBorder], byte_1, num + 4);
				break;
			case 8:
				method_101(@class.style_0.Borders[BorderType.LeftBorder], byte_1, num + 4);
				break;
			case 9:
				method_101(@class.style_0.Borders[BorderType.RightBorder], byte_1, num + 4);
				break;
			case 10:
				if (flag)
				{
					border = @class.style_0.Borders[BorderType.DiagonalUp];
					method_101(border, byte_1, num + 4);
				}
				else if (flag2)
				{
					method_101(@class.style_0.Borders[BorderType.DiagonalDown], byte_1, num + 4);
				}
				break;
			case 11:
				method_101(@class.style_0.Borders[BorderType.TopBorder], byte_1, num + 4);
				method_101(@class.style_0.Borders[BorderType.BottomBorder], byte_1, num + 4);
				break;
			case 12:
				method_101(@class.style_0.Borders[BorderType.LeftBorder], byte_1, num + 4);
				method_101(@class.style_0.Borders[BorderType.RightBorder], byte_1, num + 4);
				break;
			case 13:
				flag = byte_1[num + 4] == 1;
				break;
			case 14:
				flag2 = byte_1[num + 4] == 1;
				break;
			case 15:
				@class.style_0.HorizontalAlignment = Class1224.smethod_8(byte_1[num + 4]);
				break;
			case 16:
				@class.style_0.VerticalAlignment = Class1224.smethod_6(byte_1[num + 4]);
				break;
			case 17:
				@class.style_0.RotationAngle = byte_1[num + 4];
				break;
			case 18:
				@class.style_0.IndentLevel = BitConverter.ToInt16(byte_1, num + 4);
				break;
			case 19:
				switch (byte_1[num + 4])
				{
				default:
					@class.style_0.TextDirection = TextDirectionType.Context;
					break;
				case 1:
					@class.style_0.TextDirection = TextDirectionType.LeftToRight;
					break;
				case 2:
					@class.style_0.TextDirection = TextDirectionType.RightToLeft;
					break;
				}
				break;
			case 20:
				@class.style_0.IsTextWrapped = byte_1[num + 4] != 0;
				break;
			case 22:
				@class.style_0.ShrinkToFit = byte_1[num + 4] != 0;
				break;
			case 24:
				@class.Font.method_14(Class1217.smethod_9(byte_1, num + 4), Enum193.const_0);
				break;
			case 25:
				@class.Font.Weight = BitConverter.ToInt16(byte_1, num + 4);
				break;
			case 26:
				@class.Font.Underline = Class1224.smethod_4(BitConverter.ToInt16(byte_1, num + 4));
				break;
			case 27:
				switch (byte_1[num + 4])
				{
				case 1:
					@class.Font.IsSuperscript = true;
					break;
				case 2:
					@class.Font.IsSubscript = true;
					break;
				}
				break;
			case 28:
				@class.Font.IsItalic = byte_1[num + 4] != 0;
				break;
			case 29:
				@class.Font.IsStrikeout = byte_1[num + 4] != 0;
				break;
			case 34:
				@class.Font.method_3(byte_1[num + 4]);
				break;
			case 35:
				@class.Font.method_12(byte_1[num + 4]);
				break;
			case 36:
				@class.Font.method_17(BitConverter.ToInt16(byte_1, num + 4));
				break;
			case 37:
				@class.Font.method_24(Class1224.smethod_37(byte_1[num + 4]));
				break;
			case 38:
			{
				int int_ = num + 4;
				@class.style_0.Custom = Class1217.smethod_9(byte_1, int_);
				break;
			}
			case 41:
				@class.style_0.method_45(BitConverter.ToInt16(byte_1, num + 4));
				break;
			case 43:
				@class.style_0.IsFormulaHidden = byte_1[num + 4] != 0;
				break;
			case 44:
				@class.style_0.IsLocked = byte_1[num + 4] != 0;
				break;
			}
			num += num4;
		}
		worksheetCollection_0.method_56().method_1(@class.style_0);
	}

	private void method_104(DataSorter dataSorter_0, Class1723 class1723_0)
	{
		dataSorter_0.SortLeftToRight = (byte_1[12] & 1) != 0;
		dataSorter_0.CaseSensitive = (byte_1[12] & 2) != 0;
		if ((byte_1[12] & 4u) != 0)
		{
			dataSorter_0.string_0 = "pinYin";
		}
		CellArea cellArea_ = default(CellArea);
		cellArea_.StartRow = BitConverter.ToInt32(byte_1, 14);
		cellArea_.EndRow = BitConverter.ToUInt16(byte_1, 18);
		cellArea_.StartColumn = BitConverter.ToUInt16(byte_1, 22);
		cellArea_.EndColumn = BitConverter.ToUInt16(byte_1, 26);
		dataSorter_0.method_1(cellArea_);
		int num = BitConverter.ToInt32(byte_1, 30);
		while (true)
		{
			if (num <= 0)
			{
				return;
			}
			num--;
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 2175)
			{
				break;
			}
			method_5(class1723_0);
			ushort num2 = BitConverter.ToUInt16(byte_1, 12);
			Class1108 @class = new Class1108(dataSorter_0);
			switch ((num2 >> 1) & 0xF)
			{
			case 0:
			{
				string value = null;
				int num5 = BitConverter.ToInt32(byte_1, 38);
				if (num5 > 0)
				{
					value = ((byte_1[42] != 0) ? Encoding.Unicode.GetString(byte_1, 43, num5 * 2) : Encoding.ASCII.GetString(byte_1, 43, num5));
				}
				@class.Value = value;
				break;
			}
			case 1:
			{
				int num4 = BitConverter.ToInt32(byte_1, 30);
				if (num4 > -1 && num4 < worksheetCollection_0.method_56().Count)
				{
					Style style2 = new Style(dataSorter_0.workbook_0.Worksheets);
					style2.Copy(dataSorter_0.workbook_0.Worksheets.method_56()[num4]);
					@class.method_7(style2);
				}
				break;
			}
			case 2:
			{
				int num3 = BitConverter.ToInt32(byte_1, 30);
				if (num3 > -1 && num3 < worksheetCollection_0.method_56().Count)
				{
					Style style = new Style(dataSorter_0.workbook_0.Worksheets);
					style.Copy(dataSorter_0.workbook_0.Worksheets.method_56()[num3]);
					@class.method_9(style);
				}
				break;
			}
			case 3:
				@class.method_5(Class1673.smethod_13(BitConverter.ToInt32(byte_1, 30)), BitConverter.ToInt32(byte_1, 34));
				break;
			default:
				continue;
			}
			if (((uint)num2 & (true ? 1u : 0u)) != 0)
			{
				@class.Order = SortOrder.Descending;
			}
			dataSorter_0.AddKey(@class);
			int num6;
			int num7;
			if (dataSorter_0.SortLeftToRight)
			{
				num6 = BitConverter.ToInt32(byte_1, 14);
				num7 = BitConverter.ToInt32(byte_1, 18);
			}
			else
			{
				num6 = BitConverter.ToInt32(byte_1, 22);
				num7 = BitConverter.ToInt32(byte_1, 26);
			}
			@class.Index = num6;
			while (num6 < num7)
			{
				num6++;
				Class1108 class2 = new Class1108(dataSorter_0);
				class2.Copy(@class);
				class2.Index = num6;
				dataSorter_0.AddKey(class2);
			}
		}
		class1723_0.method_3(-2);
	}

	[SpecialName]
	internal byte[] method_105()
	{
		return byte_1;
	}

	[SpecialName]
	internal ushort method_106()
	{
		return ushort_1;
	}
}
