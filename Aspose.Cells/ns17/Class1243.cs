using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Aspose.Cells.Rendering;
using ns1;
using ns18;
using ns19;
using ns2;
using ns40;

namespace ns17;

internal class Class1243
{
	private Workbook workbook_0;

	private WorksheetCollection worksheetCollection_0;

	private Worksheet worksheet_0;

	private Hashtable hashtable_0;

	private Stream stream_0;

	private double[] double_0;

	private Style style_0;

	private int int_0;

	private SizeF sizeF_0;

	private Hashtable hashtable_1;

	private Hashtable hashtable_2;

	private Hashtable hashtable_3;

	private Hashtable hashtable_4;

	private Hashtable hashtable_5;

	internal Class468 class468_0;

	internal Class1448 class1448_0;

	private Stream13 stream13_0;

	private ArrayList arrayList_0;

	internal ArrayList arrayList_1;

	internal Hashtable hashtable_6 = new Hashtable();

	internal Hashtable hashtable_7 = new Hashtable();

	internal Class1243(Workbook workbook_1)
	{
		workbook_0 = workbook_1;
		PdfSaveOptions pdfSaveOptions = null;
		if (!(workbook_1.SaveOptions is PdfSaveOptions))
		{
			pdfSaveOptions = new PdfSaveOptions(workbook_1.SaveOptions);
			workbook_1.method_17(pdfSaveOptions);
		}
		else
		{
			pdfSaveOptions = (PdfSaveOptions)workbook_1.SaveOptions;
		}
		if (pdfSaveOptions.CalculateFormula)
		{
			bool createCalcChain = workbook_1.Settings.CreateCalcChain;
			workbook_1.Settings.CreateCalcChain = false;
			workbook_1.CalculateFormula();
			workbook_1.Worksheets.method_44();
			workbook_1.Settings.CreateCalcChain = createCalcChain;
		}
		worksheetCollection_0 = workbook_1.Worksheets;
		double_0 = new double[2] { 1.0, 1.0 };
		style_0 = workbook_1.Worksheets.DefaultStyle;
		hashtable_0 = new Hashtable();
		sizeF_0 = new SizeF(0f, 0f);
		int_0 = -(workbook_1.Worksheets.method_73() + workbook_1.Worksheets.method_72() + 2);
		class1448_0 = new Class1448();
		class1448_0.method_0(Enum207.const_3);
		class1448_0.method_2(Enum208.const_2);
		stream13_0 = new Stream13();
		try
		{
			class1448_0.method_13((string)workbook_1.BuiltInDocumentProperties["Author"].Value);
			class1448_0.method_11((string)workbook_1.BuiltInDocumentProperties["Title"].Value);
			class1448_0.method_9((string)workbook_1.BuiltInDocumentProperties["Subject"].Value);
			class1448_0.method_15((string)workbook_1.BuiltInDocumentProperties["Keywords"].Value);
		}
		catch
		{
		}
		arrayList_0 = new ArrayList();
		arrayList_1 = new ArrayList();
		hashtable_4 = new Hashtable();
		hashtable_3 = new Hashtable();
		hashtable_5 = new Hashtable();
		hashtable_2 = new Hashtable();
	}

	private ImageFormat method_0(string string_0, ImageOrPrintOptions imageOrPrintOptions_0)
	{
		if (string_0 == null)
		{
			return imageOrPrintOptions_0.ImageFormat;
		}
		string extension = Path.GetExtension(string_0);
		string key;
		if ((key = extension.ToLower()) != null)
		{
			if (Class1742.dictionary_59 == null)
			{
				Class1742.dictionary_59 = new Dictionary<string, int>(8)
				{
					{ ".bmp", 0 },
					{ ".emf", 1 },
					{ ".jpg", 2 },
					{ ".jpeg", 3 },
					{ ".png", 4 },
					{ ".gif", 5 },
					{ ".tif", 6 },
					{ ".tiff", 7 }
				};
			}
			if (Class1742.dictionary_59.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return ImageFormat.Bmp;
				case 1:
					return ImageFormat.Emf;
				case 2:
				case 3:
					return ImageFormat.Jpeg;
				case 4:
					return ImageFormat.Png;
				case 5:
					return ImageFormat.Gif;
				case 6:
				case 7:
					return ImageFormat.Tiff;
				}
			}
		}
		return imageOrPrintOptions_0.ImageFormat;
	}

	internal void method_1(int int_1, Stream stream_1, ImageOrPrintOptions imageOrPrintOptions_0)
	{
		try
		{
			if (int_1 < arrayList_1.Count)
			{
				if (int_1 >= 0 && int_1 < arrayList_1.Count)
				{
					imageOrPrintOptions_0.method_1(bool_11: true);
				}
				if (int_1 < 0)
				{
					imageOrPrintOptions_0.method_1(bool_11: false);
				}
				Class456 class456_ = (Class456)arrayList_1[int_1];
				Class930.smethod_0(class456_, stream_1, class468_0, imageOrPrintOptions_0);
			}
		}
		catch (Exception ex)
		{
			throw new CellsException(ExceptionType.FileFormat, ex.Message);
		}
	}

	internal void method_2(int int_1, ImageOrPrintOptions imageOrPrintOptions_0, Stream stream_1)
	{
		ImageFormat imageFormat = method_0("", imageOrPrintOptions_0);
		if (imageFormat == ImageFormat.Emf)
		{
			method_1(int_1, stream_1, imageOrPrintOptions_0);
			stream_1.Position = 0L;
		}
		else if (imageFormat == ImageFormat.Jpeg)
		{
			Bitmap bitmap = method_5(int_1, imageOrPrintOptions_0);
			if (bitmap != null)
			{
				Class1404.smethod_40(bitmap, stream_1, imageOrPrintOptions_0.Quality);
				bitmap.Dispose();
				bitmap = null;
			}
		}
		else if (imageFormat != ImageFormat.Bmp && imageFormat != ImageFormat.Png && imageFormat != ImageFormat.Gif)
		{
			if (imageFormat == ImageFormat.Tiff)
			{
				Encoder saveFlag = Encoder.SaveFlag;
				EncoderParameters encoderParameters = new EncoderParameters(2);
				encoderParameters.Param[0] = new EncoderParameter(saveFlag, 18L);
				long value = 0L;
				switch (imageOrPrintOptions_0.TiffCompression)
				{
				case TiffCompression.CompressionNone:
					value = 6L;
					break;
				case TiffCompression.CompressionRle:
					value = 5L;
					break;
				case TiffCompression.CompressionLZW:
					value = 2L;
					break;
				case TiffCompression.CompressionCCITT3:
					imageOrPrintOptions_0.bool_6 = true;
					value = 3L;
					break;
				case TiffCompression.CompressionCCITT4:
					imageOrPrintOptions_0.bool_6 = true;
					value = 4L;
					break;
				}
				encoderParameters.Param[1] = new EncoderParameter(Encoder.Compression, value);
				Bitmap bitmap2 = null;
				ImageCodecInfo encoder = null;
				ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
				for (int i = 0; i < imageEncoders.Length - 1; i++)
				{
					if (imageEncoders[i].FormatDescription.ToUpper().Equals("TIFF"))
					{
						encoder = imageEncoders[i];
					}
				}
				bitmap2 = method_5(int_1, imageOrPrintOptions_0);
				bitmap2.Save(stream_1, encoder, encoderParameters);
				bitmap2.Dispose();
				bitmap2 = null;
			}
			else if (imageOrPrintOptions_0.SaveFormat == SaveFormat.XPS)
			{
				Class471 @class = new Class471(stream_1);
				@class.imageFormat_0 = imageOrPrintOptions_0.ChartImageType;
				Class456 class452_ = (Class456)arrayList_1[int_1];
				@class.vmethod_0(class452_);
				@class.vmethod_16();
				stream_1.Position = 0L;
			}
			else if (imageOrPrintOptions_0.SaveFormat == SaveFormat.SVG)
			{
				Class469 class2 = new Class469();
				class2.imageFormat_0 = imageOrPrintOptions_0.ChartImageType;
				Class456 class452_2 = (Class456)arrayList_1[int_1];
				class2.method_2(class452_2, stream_1, imageOrPrintOptions_0.EmbededImageNameInSvg);
				class2.vmethod_16();
				stream_1.Position = 0L;
			}
		}
		else
		{
			Bitmap bitmap3 = method_5(int_1, imageOrPrintOptions_0);
			if (bitmap3 != null)
			{
				bitmap3.Save(stream_1, imageFormat);
				stream_1.Position = 0L;
				bitmap3.Dispose();
				bitmap3 = null;
			}
		}
	}

	internal void method_3(int int_1, string string_0, ImageOrPrintOptions imageOrPrintOptions_0)
	{
		FileStream fileStream = new FileStream(string_0, FileMode.Create);
		method_2(int_1, imageOrPrintOptions_0, fileStream);
		fileStream.Flush();
		fileStream.Close();
	}

	internal bool method_4(int int_1, ImageOrPrintOptions imageOrPrintOptions_0, PrintPageEventArgs printPageEventArgs_0)
	{
		Graphics graphics = printPageEventArgs_0.Graphics;
		graphics.PageUnit = GraphicsUnit.Point;
		graphics.Clear(Color.White);
		Class456 @class = (Class456)arrayList_1[int_1];
		if (int_1 > 0)
		{
			Class456 class2 = (Class456)arrayList_1[int_1 - 1];
			if (class2.worksheet_0.SheetIndex != @class.worksheet_0.SheetIndex)
			{
				class468_0.method_1();
			}
		}
		((Class472)class468_0).method_2(@class, graphics);
		class468_0.vmethod_16();
		if (int_1 < arrayList_1.Count - 1)
		{
			return true;
		}
		return false;
	}

	internal Bitmap method_5(int int_1, ImageOrPrintOptions imageOrPrintOptions_0)
	{
		int[] array = new int[2] { 1, 1 };
		Bitmap bitmap = null;
		Class456 @class = null;
		try
		{
			if (int_1 >= arrayList_1.Count)
			{
				return null;
			}
			if (int_1 >= 0 && int_1 < arrayList_1.Count)
			{
				imageOrPrintOptions_0.method_1(bool_11: true);
			}
			if (int_1 < 0)
			{
				imageOrPrintOptions_0.method_1(bool_11: false);
			}
			@class = (Class456)arrayList_1[int_1];
			bitmap = Class1404.smethod_43((int)Math.Ceiling(@class.double_1 * (double)imageOrPrintOptions_0.HorizontalResolution) + 1, (int)Math.Ceiling(@class.double_2 * (double)imageOrPrintOptions_0.VerticalResolution) + 1);
			array[0] = bitmap.Size.Width;
			array[1] = bitmap.Size.Height;
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.PageUnit = GraphicsUnit.Point;
			graphics.Clear(Color.White);
			graphics.ScaleTransform((float)imageOrPrintOptions_0.HorizontalResolution / 96f, (float)imageOrPrintOptions_0.VerticalResolution / 96f);
			Class472 class2 = (Class472)class468_0;
			class2.imageFormat_0 = imageOrPrintOptions_0.ChartImageType;
			class2.bool_1 = imageOrPrintOptions_0.bool_6;
			class2.method_2(@class, graphics);
			bitmap.SetResolution(imageOrPrintOptions_0.HorizontalResolution, imageOrPrintOptions_0.VerticalResolution);
			class2.vmethod_16();
			graphics.Save();
			graphics.Dispose();
		}
		catch (Exception ex)
		{
			throw new CellsException(ExceptionType.FileFormat, ex.Message);
		}
		if ((@class != null && @class.worksheet_0.PageSetup.BlackAndWhite) || imageOrPrintOptions_0.bool_6)
		{
			return Class1335.smethod_0(bitmap);
		}
		return bitmap;
	}

	internal bool method_6(Stream stream_1, ImageOrPrintOptions imageOrPrintOptions_0)
	{
		imageOrPrintOptions_0.method_1(bool_11: false);
		ImageFormat imageFormat = method_0(null, imageOrPrintOptions_0);
		if (imageFormat == ImageFormat.Tiff)
		{
			Encoder saveFlag = Encoder.SaveFlag;
			EncoderParameters encoderParameters = new EncoderParameters(2);
			encoderParameters.Param[0] = new EncoderParameter(saveFlag, 18L);
			long value = 0L;
			switch (imageOrPrintOptions_0.TiffCompression)
			{
			case TiffCompression.CompressionNone:
				value = 6L;
				break;
			case TiffCompression.CompressionRle:
				value = 5L;
				break;
			case TiffCompression.CompressionLZW:
				value = 2L;
				break;
			case TiffCompression.CompressionCCITT3:
				imageOrPrintOptions_0.bool_6 = true;
				value = 3L;
				break;
			case TiffCompression.CompressionCCITT4:
				imageOrPrintOptions_0.bool_6 = true;
				value = 4L;
				break;
			}
			encoderParameters.Param[1] = new EncoderParameter(Encoder.Compression, value);
			Bitmap bitmap = null;
			int num = 0;
			ImageCodecInfo encoder = null;
			ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
			for (int i = 0; i < imageEncoders.Length - 1; i++)
			{
				if (imageEncoders[i].FormatDescription.ToUpper().Equals("TIFF"))
				{
					encoder = imageEncoders[i];
				}
			}
			int num2 = -1;
			for (int j = 0; j < arrayList_1.Count; j++)
			{
				Class456 @class = (Class456)arrayList_1[j];
				if (@class.worksheet_0.SheetIndex != num2 && num2 != -1)
				{
					class468_0.method_1();
				}
				if (num == 0)
				{
					bitmap = method_5(j, imageOrPrintOptions_0);
					bitmap.Save(stream_1, encoder, encoderParameters);
				}
				else
				{
					encoderParameters.Param[0] = new EncoderParameter(saveFlag, 23L);
					Bitmap bitmap2 = method_5(j, imageOrPrintOptions_0);
					bitmap.SaveAdd(bitmap2, encoderParameters);
					bitmap2.Dispose();
					bitmap2 = null;
				}
				if (num == arrayList_1.Count - 1)
				{
					encoderParameters.Param[0] = new EncoderParameter(saveFlag, 20L);
					bitmap.SaveAdd(encoderParameters);
				}
				num++;
				num2 = @class.worksheet_0.SheetIndex;
			}
			if (bitmap != null)
			{
				stream_1.Position = 0L;
				bitmap.Dispose();
				bitmap = null;
				return true;
			}
			Bitmap bitmap3 = Class1404.smethod_43(793, 1122);
			bitmap = bitmap3;
			if (imageOrPrintOptions_0.bool_6)
			{
				bitmap = Class1335.smethod_0(bitmap3);
				bitmap.Save(stream_1, encoder, encoderParameters);
				return true;
			}
			bitmap.Save(stream_1, encoder, encoderParameters);
			return true;
		}
		if (imageOrPrintOptions_0.SaveFormat == SaveFormat.XPS)
		{
			Class471 class2 = new Class471(stream_1);
			class2.imageFormat_0 = imageOrPrintOptions_0.ChartImageType;
			int num3 = -1;
			for (int k = 0; k < arrayList_1.Count; k++)
			{
				Class456 class3 = (Class456)arrayList_1[k];
				if (class3.worksheet_0.SheetIndex != num3 && num3 != -1)
				{
					class2.method_1();
				}
				if (k % 50 == 0 && k != 0)
				{
					GC.Collect();
					GC.WaitForPendingFinalizers();
				}
				try
				{
					class2.vmethod_0(class3);
				}
				catch (Exception)
				{
				}
				num3 = class3.worksheet_0.SheetIndex;
				workbook_0.method_30();
			}
			if (arrayList_1.Count == 0)
			{
				Class457 class4 = null;
				double pageWidthBase = 595.2755905511812;
				double pageHeightBase = 841.8897637795276;
				if (workbook_0 != null && workbook_0.Worksheets.Count > 0)
				{
					PageSetup pageSetup = workbook_0.Worksheets[0].PageSetup;
					Class1625.smethod_10(pageSetup, out pageWidthBase, out pageHeightBase);
					pageWidthBase *= 72.0;
					pageHeightBase *= 72.0;
				}
				class4 = new Class457((float)pageWidthBase, (float)pageHeightBase);
				class2.vmethod_0(class4);
			}
			class2.vmethod_16();
			stream_1.Position = 0L;
			return true;
		}
		if (stream_1 == null)
		{
			return false;
		}
		return false;
	}

	internal void method_7(ImageOrPrintOptions imageOrPrintOptions_0)
	{
		method_10();
		new Hashtable();
		style_0 = workbook_0.DefaultStyle;
		Class1241 @class = new Class1241(workbook_0);
		foreach (Worksheet worksheet2 in workbook_0.Worksheets)
		{
			@class.method_9(worksheet2, imageOrPrintOptions_0);
		}
		arrayList_1 = new ArrayList();
		int num = -1;
		int num2 = 1;
		for (int i = 0; i < @class.arrayList_2.Count; i++)
		{
			Class1623 class2 = (Class1623)@class.arrayList_2[i];
			Worksheet worksheet = workbook_0.Worksheets[class2.int_0];
			if (worksheet.SheetIndex != num && !worksheet.PageSetup.IsAutoFirstPageNumber)
			{
				num2 = worksheet.PageSetup.FirstPageNumber;
			}
			Class456 value = new Class456(worksheet, class2, num2, @class.arrayList_2.Count, @class.arrayList_2, imageOrPrintOptions_0, this);
			num2++;
			num = worksheet.SheetIndex;
			arrayList_1.Add(value);
		}
	}

	internal void method_8(Worksheet worksheet_1, ImageOrPrintOptions imageOrPrintOptions_0)
	{
		method_10();
		new Hashtable();
		style_0 = workbook_0.DefaultStyle;
		worksheet_0 = worksheet_1;
		Class1241 @class = new Class1241(workbook_0);
		@class.method_9(worksheet_1, imageOrPrintOptions_0);
		arrayList_1 = new ArrayList();
		int num = -1;
		int num2 = 1;
		for (int i = 0; i < @class.arrayList_2.Count; i++)
		{
			Class1623 class2 = (Class1623)@class.arrayList_2[i];
			Worksheet worksheet = workbook_0.Worksheets[class2.int_0];
			if (worksheet.SheetIndex != num && !worksheet.PageSetup.IsAutoFirstPageNumber)
			{
				num2 = worksheet.PageSetup.FirstPageNumber;
			}
			Class456 value = new Class456(worksheet, class2, num2, @class.arrayList_2.Count, @class.arrayList_2, imageOrPrintOptions_0, this);
			num2++;
			num = worksheet.SheetIndex;
			arrayList_1.Add(value);
		}
	}

	internal void method_9(Stream stream_1)
	{
		try
		{
			stream_0 = stream_1;
			method_12();
			if (stream_0.CanSeek)
			{
				stream_0.Seek(0L, SeekOrigin.Begin);
			}
			arrayList_1 = null;
		}
		catch (Exception ex)
		{
			throw new CellsException(ExceptionType.FileFormat, ex.Message);
		}
	}

	private void method_10()
	{
		Hashtable hashtable = new Hashtable();
		foreach (Name name in workbook_0.Worksheets.Names)
		{
			hashtable[name.Text] = name;
		}
		hashtable_1 = new Hashtable();
		for (int i = 0; i < workbook_0.Worksheets.Count; i++)
		{
			Worksheet worksheet = workbook_0.Worksheets[i];
			if (worksheet.Type != SheetType.Worksheet || !worksheet.IsVisible)
			{
				continue;
			}
			for (int j = 0; j < worksheet.Hyperlinks.Count; j++)
			{
				Hyperlink hyperlink_ = worksheet.Hyperlinks[j];
				method_11(hashtable, hyperlink_);
			}
			foreach (Shape shape in worksheet.Shapes)
			{
				Hyperlink hyperlink = shape.Hyperlink;
				if (hyperlink != null)
				{
					method_11(hashtable, hyperlink);
				}
			}
		}
	}

	private void method_11(Hashtable hashtable_8, Hyperlink hyperlink_0)
	{
		string text = hyperlink_0.Address.ToLower();
		if (text.IndexOf("!") != -1)
		{
			string[] array = text.Split('!');
			if (array[1] == null || !(array[1] != "") || array[1].IndexOf(":") != -1 || !Class1677.smethod_23(array[1]))
			{
				return;
			}
			string text2 = array[0];
			if (text2[0] == '\'')
			{
				text2 = text2.Substring(1, text2.Length - 2);
			}
			Worksheet worksheet = workbook_0.Worksheets[text2];
			if (worksheet == null)
			{
				return;
			}
			try
			{
				array[1] = array[1].Replace("$", "");
				CellsHelper.CellNameToIndex(array[1], out var row, out var column);
				Cell cell = worksheet.Cells.GetCell(row, column, bool_2: false);
				if (hashtable_1[hyperlink_0] == null)
				{
					hashtable_1.Add(hyperlink_0, cell);
				}
				return;
			}
			catch
			{
				return;
			}
		}
		if (!hashtable_8.Contains(hyperlink_0.Address))
		{
			return;
		}
		Name name = (Name)hashtable_8[hyperlink_0.Address];
		int num = 0;
		Range[] ranges = name.GetRanges();
		if (ranges != null && ranges.Length != 0)
		{
			Range range = ranges[0];
			num = range.Worksheet.Index;
			Cell cell2 = workbook_0.Worksheets[num].Cells.GetCell(range.FirstRow, range.FirstColumn, bool_2: false);
			if (hashtable_1[hyperlink_0] == null)
			{
				hashtable_1.Add(hyperlink_0, cell2);
			}
		}
	}

	private void method_12()
	{
		PdfSaveOptions pdfSaveOptions = (PdfSaveOptions)workbook_0.SaveOptions;
		class1448_0.Bookmark = pdfSaveOptions.pdfBookmarkEntry_0;
		class1448_0.Compliance = pdfSaveOptions.pdfCompliance_0;
		class1448_0.SecurityOptions = pdfSaveOptions.SecurityOptions;
		class1448_0.method_19(pdfSaveOptions.CheckFontCompatibility);
		ImageOrPrintOptions imageOrPrintOptions = new ImageOrPrintOptions();
		imageOrPrintOptions.OnePagePerSheet = pdfSaveOptions.OnePagePerSheet;
		imageOrPrintOptions.PrintingPage = pdfSaveOptions.PrintingPageType;
		class468_0 = new Class473(stream13_0, class1448_0);
		class468_0.imageFormat_0 = pdfSaveOptions.ChartImageType;
		method_10();
		new Hashtable();
		method_16(class1448_0.Bookmark);
		style_0 = workbook_0.DefaultStyle;
		if (class1448_0.SecurityOptions != null)
		{
			class1448_0.method_17(new Class945(((Class473)class468_0).method_2(), class1448_0.SecurityOptions));
			class1448_0.method_16().method_8();
		}
		Class1241 @class = new Class1241(workbook_0);
		foreach (Worksheet worksheet3 in workbook_0.Worksheets)
		{
			if (!worksheet3.IsVisible)
			{
				continue;
			}
			if (worksheet3.PivotTables != null && worksheet3.PivotTables.Count > 0)
			{
				for (int i = 0; i < worksheet3.PivotTables.Count; i++)
				{
					if (worksheet3.IsVisible && !worksheet3.PivotTables[i].bool_20)
					{
						worksheet3.PivotTables[i].method_0();
					}
				}
			}
			@class.method_9(worksheet3, imageOrPrintOptions);
		}
		int num = -1;
		int num2 = 1;
		for (int j = 0; j < @class.arrayList_2.Count; j++)
		{
			Class1623 class2 = (Class1623)@class.arrayList_2[j];
			if (class2.int_0 != num && num != -1)
			{
				class468_0.method_1();
			}
			if (j % 200 == 0 && j != 0)
			{
				GC.Collect();
				GC.WaitForPendingFinalizers();
			}
			Worksheet worksheet2 = workbook_0.Worksheets[class2.int_0];
			if (class2.int_0 != num && !worksheet2.PageSetup.IsAutoFirstPageNumber)
			{
				num2 = worksheet2.PageSetup.FirstPageNumber;
			}
			Class456 class3 = new Class456(worksheet2, class2, num2, @class.arrayList_2.Count, @class.arrayList_2, imageOrPrintOptions, this);
			num2++;
			class3.hashtable_1 = hashtable_1;
			class3.hashtable_5 = hashtable_5;
			class3.hashtable_4 = hashtable_4;
			class3.hashtable_3 = hashtable_3;
			class3.hashtable_2 = hashtable_2;
			class468_0.method_0(worksheet2.PageSetup.BlackAndWhite || (imageOrPrintOptions?.bool_6 ?? false));
			class468_0.vmethod_0(class3);
			num = class2.int_0;
			stream13_0.vmethod_0(stream_0);
			stream13_0.method_3();
			workbook_0.method_30();
			class3 = null;
		}
		if (@class.arrayList_2.Count == 0)
		{
			method_13((Class473)class468_0);
		}
		method_14();
		method_15();
		class468_0.vmethod_16();
		stream13_0.vmethod_0(stream_0);
		stream13_0.Close();
		stream13_0 = null;
		@class = null;
		class468_0 = null;
	}

	private void method_13(Class473 class473_0)
	{
		Class457 @class = null;
		double pageWidthBase = 595.2755905511812;
		double pageHeightBase = 841.8897637795276;
		if (workbook_0 != null && workbook_0.Worksheets.Count > 0)
		{
			PageSetup pageSetup = workbook_0.Worksheets[0].PageSetup;
			Class1625.smethod_10(pageSetup, out pageWidthBase, out pageHeightBase);
			pageWidthBase *= 72.0;
			pageHeightBase *= 72.0;
		}
		@class = new Class457((float)pageWidthBase, (float)pageHeightBase);
		class468_0.vmethod_0(@class);
	}

	private void method_14()
	{
		if (!(class468_0 is Class473) || hashtable_4 == null || hashtable_4.Count <= 0)
		{
			return;
		}
		foreach (object key2 in hashtable_4.Keys)
		{
			Cell key = (Cell)hashtable_4[key2];
			string text = (string)hashtable_3[key];
			if (text == null || text.Length <= 0)
			{
				continue;
			}
			string[] array = text.Split('_');
			int int_ = int.Parse(array[0]);
			float x = float.Parse(array[1]);
			float y = float.Parse(array[2]);
			Class464 @class = (Class464)hashtable_2[key2];
			foreach (Class950 item in ((Class473)class468_0).method_2().method_10().arrayList_0)
			{
				if (item.method_4() == @class.method_3())
				{
					item.method_5((string)hashtable_3[key]);
				}
			}
			_ = "" + @class.method_3();
			@class.method_4((string)hashtable_3[key]);
			((Class473)class468_0).method_2().method_10().hashtable_0[@class.method_3()] = new Class1441(int_, new PointF(x, y));
		}
	}

	private void method_15()
	{
		if (class1448_0.Bookmark != null)
		{
			method_17(class1448_0.Bookmark, 0);
		}
	}

	private void method_16(PdfBookmarkEntry pdfBookmarkEntry_0)
	{
		if (pdfBookmarkEntry_0 == null || pdfBookmarkEntry_0.Destination == null)
		{
			return;
		}
		hashtable_5[pdfBookmarkEntry_0] = null;
		if (pdfBookmarkEntry_0 == null || pdfBookmarkEntry_0.SubEntry == null || pdfBookmarkEntry_0.SubEntry.Count <= 0)
		{
			return;
		}
		foreach (PdfBookmarkEntry item in pdfBookmarkEntry_0.SubEntry)
		{
			method_16(item);
		}
	}

	private void method_17(PdfBookmarkEntry pdfBookmarkEntry_0, int int_1)
	{
		if (pdfBookmarkEntry_0 == null)
		{
			return;
		}
		Class1441 class1441_ = new Class1441(pdfBookmarkEntry_0.int_0, pdfBookmarkEntry_0.pointF_0);
		if (pdfBookmarkEntry_0.Text != null && pdfBookmarkEntry_0.Text.Length != 0)
		{
			((Class473)class468_0).method_2().Outline.method_0(pdfBookmarkEntry_0.Text, int_1, class1441_, pdfBookmarkEntry_0.IsOpen);
		}
		else
		{
			int_1--;
		}
		if (pdfBookmarkEntry_0.SubEntry == null || pdfBookmarkEntry_0.SubEntry.Count <= 0)
		{
			return;
		}
		int_1++;
		foreach (PdfBookmarkEntry item in pdfBookmarkEntry_0.SubEntry)
		{
			method_17(item, int_1);
		}
	}
}
