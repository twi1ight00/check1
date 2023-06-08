using System;
using System.IO;
using System.Text;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Aspose.Cells.Pivot;
using ns11;
using ns16;
using ns2;
using ns22;
using ns45;
using ns52;
using ns57;
using ns59;
using ns7;

namespace ns20;

internal class Class722
{
	private Workbook workbook_0;

	private WorksheetCollection worksheetCollection_0;

	private Class982 class982_0;

	private Class721[] class721_0;

	private readonly int int_0;

	private Class1702 class1702_0;

	private Class475[] class475_0;

	public Class722(Workbook workbook_1)
	{
		workbook_0 = workbook_1;
		worksheetCollection_0 = workbook_1.Worksheets;
		worksheetCollection_0.method_26();
		worksheetCollection_0.method_27();
		class982_0 = new Class982(workbook_1);
		int_0 = worksheetCollection_0.Count;
		class721_0 = new Class721[int_0];
		for (int i = 0; i < int_0; i++)
		{
			Worksheet worksheet = worksheetCollection_0[i];
			if (worksheet.Type != SheetType.Chart)
			{
				class721_0[i] = new Class721(class982_0, i);
			}
		}
	}

	internal void Write(Stream stream_0)
	{
		if (class982_0.string_0 != null)
		{
			string path = class982_0.string_0 + "_Wb.xls";
			using (FileStream stream_ = File.Create(path))
			{
				method_0(stream_);
				worksheetCollection_0.method_10().Save(stream_0);
				method_4();
			}
			File.Delete(path);
		}
		else
		{
			MemoryStream memoryStream = new MemoryStream();
			method_0(memoryStream);
			worksheetCollection_0.method_10().Save(stream_0);
			method_4();
			memoryStream.Close();
			memoryStream = null;
		}
	}

	private void method_0(Stream stream_0)
	{
		Class1725 class1725_ = new Class1725(stream_0);
		for (int i = 0; i < int_0; i++)
		{
			worksheetCollection_0[i].method_5();
		}
		if (worksheetCollection_0.method_10() == null)
		{
			worksheetCollection_0.method_11(new Class1317(WorksheetCollection.guid_0));
			Stream stream = worksheetCollection_0.method_12();
			if (stream != null)
			{
				Class1317 @class = new Class1317(stream);
				worksheetCollection_0.method_18(bool_4: true);
				worksheetCollection_0.method_10().method_9().Add("_VBA_PROJECT_CUR", @class.method_9());
			}
		}
		method_1(class1725_);
		worksheetCollection_0.method_10().method_9().Add("Workbook", stream_0);
		if (worksheetCollection_0.XmlMaps.Count > 0 && worksheetCollection_0.method_10().method_9().GetStream("XML") == null)
		{
			MemoryStream memoryStream = new MemoryStream();
			XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
			worksheetCollection_0.XmlMaps.string_1 = "";
			Class446 class2 = new Class446(worksheetCollection_0.Workbook);
			class2.Write(xmlTextWriter);
			xmlTextWriter.Flush();
			worksheetCollection_0.method_10().method_9().Add("XML", memoryStream);
		}
		if (worksheetCollection_0.method_90() != null)
		{
			Class1142 class3 = worksheetCollection_0.method_90();
			if (class3.Count > 0)
			{
				Class1319 class4 = worksheetCollection_0.method_10().method_9().method_0("_SX_DB_CUR");
				if (class4 == null)
				{
					class4 = new Class1319(new Guid("00000000-0000-0000-0000-000000000000"));
					worksheetCollection_0.method_10().method_9().Add("_SX_DB_CUR", class4);
				}
				_ = class4.Count;
				foreach (Class1141 item in class3)
				{
					MemoryStream memoryStream_ = new MemoryStream();
					item.method_19(memoryStream_);
					string text = Class1025.smethod_6(item.int_6);
					if (!class4.Contains(text))
					{
						class4.Add(text, memoryStream_);
					}
				}
			}
		}
		if (worksheetCollection_0.method_28() != null)
		{
			method_6(stream_0, worksheetCollection_0.method_10(), worksheetCollection_0.method_28());
		}
		else if (worksheetCollection_0.method_30() != null)
		{
			method_7(stream_0, worksheetCollection_0.method_10(), worksheetCollection_0.method_30());
			worksheetCollection_0.method_31(null);
		}
		else if (workbook_0.Settings.Password != null && workbook_0.Settings.Password != "")
		{
			Class1637 class1637_ = new Class1637(workbook_0.Settings.Password);
			method_5(stream_0, worksheetCollection_0.method_10(), class1637_);
		}
		if (worksheetCollection_0.method_69() != null || worksheetCollection_0.method_70() != null)
		{
			Class1726 class6 = new Class1726();
			class6.Write(worksheetCollection_0.BuiltInDocumentProperties, worksheetCollection_0.CustomDocumentProperties, worksheetCollection_0.method_10().method_9());
		}
		if (worksheetCollection_0.Workbook.Settings.Shared)
		{
			MemoryStream stream2 = worksheetCollection_0.method_10().method_9().GetStream("User Names");
			if (stream2 == null)
			{
				MemoryStream stream3 = new MemoryStream(Class1186.smethod_0());
				Workbook workbook = new Workbook(stream3);
				stream2 = workbook.Worksheets.method_10().method_9().GetStream("User Names");
				worksheetCollection_0.method_10().method_9()["User Names"] = stream2;
				stream2 = workbook.Worksheets.method_10().method_9().GetStream("Revision Log");
				worksheetCollection_0.method_10().method_9()["Revision Log"] = stream2;
			}
		}
		else
		{
			worksheetCollection_0.method_10().method_9().Remove("User Names");
		}
		for (int j = 0; j < int_0; j++)
		{
			Worksheet worksheet = worksheetCollection_0[j];
			if (worksheet.method_18() == null || worksheet.OleObjects.method_0() || worksheet.OleObjects.Count <= 0)
			{
				continue;
			}
			if (worksheetCollection_0.method_10().method_9().GetStream("\u0001CompObj") == null)
			{
				byte[] array = Class1186.smethod_2();
				MemoryStream memoryStream2 = new MemoryStream();
				memoryStream2.Write(array, 0, array.Length);
				worksheetCollection_0.method_10().method_9().Add("\u0001CompObj", memoryStream2);
			}
			for (int k = 0; k < worksheet.OleObjects.Count; k++)
			{
				OleObject oleObject = worksheet.OleObjects[k];
				if (oleObject.method_69())
				{
					continue;
				}
				string string_ = "MBD" + Class1025.smethod_7(oleObject.method_97());
				if (oleObject.method_79())
				{
					Class1319 class7 = new Class1319(oleObject.method_99());
					MemoryStream memoryStream_2 = new MemoryStream(oleObject.ObjectData);
					class7.Add("Package", memoryStream_2);
					worksheetCollection_0.method_10().method_9().Add(string_, class7);
				}
				else if (oleObject.method_85())
				{
					Guid guid = oleObject.method_99();
					if (guid == Guid.Empty)
					{
						guid = OleObject.smethod_2(oleObject.FileType);
					}
					Class1319 class8 = new Class1319(guid);
					MemoryStream memoryStream_3 = new MemoryStream(oleObject.method_83());
					class8.Add("\u0001Ole10Native", memoryStream_3);
					worksheetCollection_0.method_10().method_9().Add(string_, class8);
				}
				else if (Class1677.smethod_12(oleObject.ObjectData))
				{
					MemoryStream stream_ = new MemoryStream(oleObject.ObjectData);
					Class1317 class9 = new Class1317(stream_);
					Class1319 class10 = class9.method_9();
					if (class10.method_1() == Guid.Empty)
					{
						if (oleObject.FileType == OleFileType.Unknown)
						{
							oleObject.FileType = Class1677.smethod_11(class9);
						}
						if (oleObject.FileType != OleFileType.Unknown && oleObject.method_99() == Guid.Empty)
						{
							oleObject.method_100(Class1677.smethod_10(oleObject.FileType));
						}
						class10.method_2(oleObject.method_99());
					}
					if (oleObject.FileType == OleFileType.MapiMessage && class10.method_0("MAPIMessage") == null)
					{
						Class1319 class11 = new Class1319(oleObject.method_99());
						class11.Add("MAPIMessage", class10);
						class10 = class11;
					}
					worksheetCollection_0.method_10().method_9().Add(string_, class10);
				}
				else
				{
					Class1319 class12 = new Class1319(oleObject.method_99());
					MemoryStream memoryStream_4 = new MemoryStream(oleObject.ObjectData);
					class12.Add("CONTENTS", memoryStream_4);
					worksheetCollection_0.method_10().method_9().Add(string_, class12);
				}
			}
		}
	}

	private void method_1(Class1725 class1725_0)
	{
		method_2();
		method_3();
		class1725_0.method_10();
		int[] array = new int[int_0];
		new Class537(workbook_0, class982_0).Write(class1725_0, array);
		if (worksheetCollection_0.ActiveSheetIndex >= int_0)
		{
			worksheetCollection_0.method_34(0);
		}
		Worksheet worksheet = worksheetCollection_0[worksheetCollection_0.ActiveSheetIndex];
		worksheet.IsSelected = true;
		for (int i = 0; i < int_0; i++)
		{
			class982_0.class521_0.workbook_0.method_30();
			long num = class1725_0.method_10();
			class1725_0.Seek(array[i]);
			class1725_0.method_4((uint)num);
			class1725_0.Seek(num);
			Worksheet worksheet2 = worksheetCollection_0[i];
			if (worksheet2.Type == SheetType.Chart)
			{
				Class1390 @class = new Class1390(worksheetCollection_0, i, worksheet2.Charts, class1725_0);
				@class.method_1(worksheet2.Charts[0]);
			}
			else
			{
				Class723 class2 = new Class723(worksheet2, class721_0[i]);
				class2.Write(class1725_0);
				class721_0[i] = null;
			}
		}
	}

	private void method_2()
	{
		for (int i = 0; i < int_0; i++)
		{
			Worksheet worksheet = worksheetCollection_0[i];
			if (worksheet.Validations == null || worksheet.Validations.Count == 0)
			{
				continue;
			}
			foreach (Validation validation in worksheet.Validations)
			{
				validation.method_12(out var _, out var _);
			}
		}
	}

	private void method_3()
	{
		if (worksheetCollection_0.method_85() != null)
		{
			class1702_0 = new Class1702(worksheetCollection_0.method_84());
			class1702_0.Copy(worksheetCollection_0.method_84().method_2());
		}
		class475_0 = new Class475[int_0];
		for (int i = 0; i < int_0; i++)
		{
			Worksheet worksheet = worksheetCollection_0[i];
			class475_0[i] = new Class475();
			if (worksheet.method_36() != null)
			{
				class475_0[i].class1700_0 = new Class1700(0);
				class475_0[i].class1700_0.Copy(worksheet.Shapes.method_4().method_2());
			}
			int num = worksheet.method_24();
			int num2 = (worksheet.Validations.method_8() ? 1 : 0);
			int num3 = 0;
			if (worksheet.pivotTableCollection_0 != null && worksheet.pivotTableCollection_0.Count > 0)
			{
				foreach (PivotTable item in worksheet.pivotTableCollection_0)
				{
					PivotFieldCollection pageFields = item.PageFields;
					num3 += pageFields.Count;
				}
			}
			int num4 = num + num2 + num3;
			if (num4 == 0)
			{
				continue;
			}
			class475_0[i].int_0 = num4;
			if (worksheet.method_36() != null)
			{
				int num5 = worksheetCollection_0.method_84().method_2().method_5(worksheet.Shapes.method_4().method_2().method_0(), num4);
				if (num5 != -1)
				{
					worksheet.Shapes.method_4().method_2().method_4(num5);
				}
			}
			if (worksheet.method_24() != 0)
			{
				ComboBox shape_ = new ComboBox(worksheet.Shapes, worksheet.AutoFilter);
				worksheet.Shapes.Add(shape_);
				int num6 = worksheet.method_24();
				ShapeCollection shapes = worksheet.Shapes;
				shapes.method_9(shapes.method_8() + (num6 - 1));
				Class1700 @class = worksheet.Shapes.method_4().method_2();
				@class.method_4(@class.method_3() + (num6 - 1));
				Class1700 class2 = worksheet.Shapes.method_4().method_2();
				class2.method_2(class2.method_1() + (num6 - 1));
				worksheetCollection_0.method_84().method_2().AddShape(worksheet.Shapes.method_4().method_2().method_0(), num6 - 1);
			}
			if (worksheet.Validations.method_8())
			{
				ComboBox comboBox = new ComboBox(worksheet.Shapes, worksheet.Validations);
				worksheet.Shapes.Add(comboBox);
				worksheet.Validations.method_7(comboBox.method_23());
			}
			if (worksheet.pivotTableCollection_0 == null || worksheet.pivotTableCollection_0.Count <= 0)
			{
				continue;
			}
			foreach (PivotTable item2 in worksheet.pivotTableCollection_0)
			{
				PivotFieldCollection pageFields2 = item2.PageFields;
				if (pageFields2.Count != 0)
				{
					ComboBox comboBox2 = new ComboBox(worksheet.Shapes, item2);
					worksheet.Shapes.Add(comboBox2);
					pageFields2.int_0 = comboBox2.method_23();
					ShapeCollection shapes2 = worksheet.Shapes;
					shapes2.method_9(shapes2.method_8() + (pageFields2.Count - 1));
					Class1700 class3 = worksheet.Shapes.method_4().method_2();
					class3.method_4(class3.method_3() + (pageFields2.Count - 1));
					Class1700 class4 = worksheet.Shapes.method_4().method_2();
					class4.method_2(class4.method_1() + (pageFields2.Count - 1));
					worksheetCollection_0.method_84().method_2().AddShape(worksheet.Shapes.method_4().method_2().method_0(), pageFields2.Count - 1);
				}
			}
		}
	}

	private void method_4()
	{
		worksheetCollection_0.method_10().method_9().Remove("Workbook");
		if (worksheetCollection_0.method_69() != null)
		{
			worksheetCollection_0.method_10().method_9().Remove("\u0005SummaryInformation");
			worksheetCollection_0.method_10().method_9().Remove("\u0005DocumentSummaryInformation");
		}
		if (worksheetCollection_0.method_90() != null)
		{
			Class1142 @class = worksheetCollection_0.method_90();
			if (@class.Count > 0)
			{
				Class1319 class2 = worksheetCollection_0.method_10().method_9().method_0("_SX_DB_CUR");
				foreach (Class1141 item in @class)
				{
					string key = Class1025.smethod_6(item.int_6);
					class2.Remove(key);
				}
			}
		}
		for (int i = 0; i < int_0; i++)
		{
			Worksheet worksheet = worksheetCollection_0[i];
			ShapeCollection shapeCollection = worksheet.method_36();
			if (shapeCollection == null)
			{
				continue;
			}
			Class475 class4 = class475_0[i];
			if (class4 != null)
			{
				shapeCollection.method_9(shapeCollection.method_8() - class4.int_0);
				if (class4.class1700_0 == null)
				{
					worksheet.method_37(null);
				}
				else
				{
					shapeCollection.method_4().method_2().Copy(class4.class1700_0);
				}
			}
			for (int j = 0; j < shapeCollection.Count; j++)
			{
				MsoDrawingType msoDrawingType = shapeCollection[j].MsoDrawingType;
				if (msoDrawingType == MsoDrawingType.OleObject)
				{
					OleObject oleObject = (OleObject)shapeCollection[j];
					if (!oleObject.method_69())
					{
						worksheetCollection_0.method_10().method_9().Remove("MBD" + Class1025.smethod_7(oleObject.method_97()));
					}
				}
			}
		}
		if (class1702_0 != null)
		{
			worksheetCollection_0.method_84().method_2().Copy(class1702_0);
		}
		else
		{
			worksheetCollection_0.method_86(null);
		}
	}

	private void method_5(Stream stream_0, Class1317 class1317_0, Class1637 class1637_0)
	{
		Class1728 @class = new Class1728();
		long position = stream_0.Position;
		@class.method_7(stream_0, class1637_0);
		stream_0.Position = position;
		Class1319 class2 = class1317_0.method_9().method_0("_SX_DB_CUR");
		if (class2 != null)
		{
			for (int i = 0; i < class2.Count; i++)
			{
				MemoryStream memoryStream = (MemoryStream)class2.GetByIndex(i);
				@class.method_7(memoryStream, class1637_0);
				memoryStream.Position = 0L;
			}
		}
	}

	private void method_6(Stream stream_0, Class1317 class1317_0, Class1647 class1647_0)
	{
		Class1728 @class = new Class1728();
		long position = stream_0.Position;
		@class.method_1(stream_0, class1647_0);
		stream_0.Position = position;
		Class1319 class2 = class1317_0.method_9().method_0("_SX_DB_CUR");
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

	private void method_7(Stream stream_0, Class1317 class1317_0, Class1638 class1638_0)
	{
		Class1728 @class = new Class1728();
		long position = stream_0.Position;
		@class.method_2(stream_0, class1638_0);
		stream_0.Position = position;
		Class1319 class2 = class1317_0.method_9().method_0("_SX_DB_CUR");
		if (class2 != null)
		{
			for (int i = 0; i < class2.Count; i++)
			{
				MemoryStream memoryStream = (MemoryStream)class2.GetByIndex(i);
				class1638_0.Reset();
				@class.method_2(memoryStream, class1638_0);
				memoryStream.Position = 0L;
			}
		}
	}
}
