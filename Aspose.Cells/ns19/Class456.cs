using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using Aspose.Cells.Rendering;
using ns14;
using ns16;
using ns17;
using ns18;
using ns2;
using ns21;
using ns22;
using ns25;
using ns47;
using ns52;

namespace ns19;

internal class Class456 : Class453
{
	internal static ArrayList arrayList_1;

	internal Worksheet worksheet_0;

	internal Workbook workbook_0;

	internal Class1623 class1623_0;

	internal int int_0;

	internal int int_1;

	private Class1624 class1624_0;

	private float float_0;

	private float float_1;

	private double double_0;

	internal double double_1;

	internal double double_2;

	internal double double_3;

	internal double double_4;

	private Style style_0;

	private double[] double_5 = new double[2];

	private Class1622 class1622_0;

	private ArrayList arrayList_2;

	public int int_2 = -1;

	public int int_3;

	public int int_4 = -1;

	public int int_5;

	private WorksheetCollection worksheetCollection_0;

	private ArrayList arrayList_3 = new ArrayList();

	private Hashtable hashtable_0;

	private double double_6;

	private SizeF sizeF_0 = new SizeF(0f, 0f);

	private Class1448 class1448_0;

	private int int_6;

	private Cells cells_0;

	internal Hashtable hashtable_1;

	internal Hashtable hashtable_2;

	internal Hashtable hashtable_3;

	internal Hashtable hashtable_4;

	internal Hashtable hashtable_5;

	private int int_7;

	internal int int_8;

	internal int int_9;

	internal int int_10;

	internal int int_11;

	private int int_12;

	private int int_13;

	internal double[] double_7 = new double[2];

	private ArrayList arrayList_4;

	private Struct88 struct88_0;

	internal Aspose.Cells.Font font_0;

	internal ImageOrPrintOptions imageOrPrintOptions_0;

	internal Class468 class468_0;

	private Class515 class515_0 = new Class515();

	private bool bool_0;

	static Class456()
	{
		arrayList_1 = new ArrayList();
	}

	internal Class456(Worksheet worksheet_1, Class1623 class1623_1, int int_14, int int_15, ArrayList arrayList_5, ImageOrPrintOptions imageOrPrintOptions_1, Class1243 class1243_0)
	{
		worksheet_0 = worksheet_1;
		class1623_0 = class1623_1;
		struct88_0 = class1623_0.struct88_0;
		int_0 = int_14;
		int_1 = int_15;
		workbook_0 = worksheet_1.Workbook;
		worksheetCollection_0 = workbook_0.Worksheets;
		cells_0 = worksheet_0.Cells;
		double_5 = new double[2] { 1.0, 1.0 };
		double_6 = workbook_0.Worksheets.method_75();
		hashtable_0 = new Hashtable();
		style_0 = workbook_0.Worksheets.DefaultStyle;
		hashtable_0 = new Hashtable();
		sizeF_0 = new SizeF(0f, 0f);
		int_12 = class1623_1.int_1;
		int_13 = class1623_1.int_2;
		int_10 = class1623_1.int_3;
		int_11 = class1623_1.int_4;
		int_6 = -(workbook_0.Worksheets.method_73() + workbook_0.Worksheets.method_72() + 2);
		class1448_0 = class1243_0.class1448_0;
		class1624_0 = new Class1624(class1243_0);
		class1622_0 = new Class1622(workbook_0, class1624_0);
		arrayList_4 = arrayList_5;
		arrayList_3 = class1623_1.arrayList_1;
		imageOrPrintOptions_0 = imageOrPrintOptions_1;
		Class1625.smethod_10(worksheet_0.PageSetup, out double_1, out double_2);
		if (imageOrPrintOptions_0 != null && imageOrPrintOptions_0.OnlyArea)
		{
			double_1 = class1623_1.rectangleF_0.Width / 72f;
			double_2 = class1623_1.rectangleF_0.Height / 72f;
		}
		else if (imageOrPrintOptions_0 != null && imageOrPrintOptions_0.OnePagePerSheet)
		{
			double_1 = (double)(class1623_1.rectangleF_0.Width / 72f) + (worksheet_0.PageSetup.LeftMarginInch + worksheet_0.PageSetup.RightMarginInch);
			double_2 = (double)(class1623_1.rectangleF_0.Height / 72f) + (worksheet_0.PageSetup.TopMarginInch + worksheet_0.PageSetup.BottomMarginInch);
		}
		double_7[0] = double_1 * 72.0;
		double_7[1] = double_2 * 72.0;
		double_3 = (double_1 - (worksheet_0.PageSetup.LeftMarginInch + worksheet_0.PageSetup.RightMarginInch)) * 72.0;
		double_4 = (double_2 - (worksheet_0.PageSetup.TopMarginInch + worksheet_0.PageSetup.BottomMarginInch)) * 72.0;
		arrayList_2 = class1623_0.arrayList_0;
		font_0 = new Aspose.Cells.Font(null, null);
		if (workbook_0.SaveOptions.string_1 != null && workbook_0.SaveOptions.string_1.Length > 0)
		{
			font_0.Name = workbook_0.SaveOptions.string_1;
		}
		else
		{
			font_0.Name = Struct78.string_0;
		}
		workbook_0.SaveOptions.string_1 = font_0.Name;
	}

	private static void smethod_0(Class457 class457_0)
	{
		if (Class972.smethod_0() == Enum134.const_0)
		{
			Class463 class452_ = new Class463(new Class1396("Arial", 10f, FontStyle.Regular), Color.Red, new PointF(10f, 10f), "Evaluation Only. Created with " + Class1677.smethod_35() + ". Copyright 2003 - " + DateTime.Now.Year + " Aspose Pty Ltd.");
			class457_0.Add(class452_);
		}
	}

	private static void smethod_1(Class468 class468_1, Class454 class454_0)
	{
		Class461 class461_ = class468_1.class461_0;
		for (int i = 0; i < class468_1.arrayList_0.Count; i++)
		{
			if (class468_1.arrayList_0[i] != null)
			{
				Class454 @class = (Class454)class468_1.arrayList_0[i];
				if (@class != null && @class.method_3().method_3(class461_))
				{
					class454_0.Add(@class);
				}
			}
		}
	}

	private Class454 method_2(float float_2, float float_3, float[] float_4)
	{
		for (int i = class1623_0.struct88_0.int_1; i <= class1623_0.struct88_0.int_3; i++)
		{
			class468_0.arrayList_1.Add(i);
		}
		for (int j = class1623_0.struct88_0.int_0; j <= class1623_0.struct88_0.int_2; j++)
		{
			class468_0.arrayList_2.Add(j);
		}
		Class454 @class = new Class454();
		SizeF sizeF = Class1625.smethod_27(class1623_0.struct88_0.int_2, workbook_0.Worksheets.DefaultFont, double_5);
		float width = sizeF.Width;
		float height = sizeF.Height;
		float_4[0] = width;
		float_4[1] = height;
		Class458 class2 = Class458.smethod_2(new RectangleF(0f, 0f, width, height));
		class2.class770_0 = new Class770(Color.Black, 1f);
		@class.Add(class2);
		float num = width;
		Class1396 class3 = new Class1396(workbook_0.Worksheets.DefaultFont.Name, (int)Math.Max((double)workbook_0.Worksheets.DefaultFont.Size * double_5[1], 2.0), workbook_0.Worksheets.DefaultFont.method_30());
		for (int k = 0; k < class468_0.arrayList_1.Count; k++)
		{
			int column = (int)class468_0.arrayList_1[k];
			string text = CellsHelper.ColumnIndexToName(column);
			width = (float)(cells_0.GetColumnWidthInch(column) * 72.0 * double_5[0]);
			if (!(width <= 0.001f))
			{
				class2 = Class458.smethod_2(new RectangleF(num, 0f, width, height));
				class2.class770_0 = new Class770(Color.Black, 1f);
				@class.Add(class2);
				float num2 = Class1625.smethod_18(text, workbook_0.Worksheets.DefaultFont, double_5[1], 0);
				Class463 class452_ = new Class463(class3, Color.Black, new PointF(num + (width - num2) / 2f, (float)((double)height - (double)class3.method_2() * double_5[1])), text);
				@class.Add(class452_);
				num += width;
			}
		}
		width = sizeF.Width;
		float num3 = height;
		for (int l = 0; l < class468_0.arrayList_2.Count; l++)
		{
			int num4 = (int)class468_0.arrayList_2[l];
			string text2 = (num4 + 1).ToString();
			float num5 = (float)(cells_0.GetRowHeightInch(num4) * 72.0 * double_5[1]);
			if (!(num5 <= 0.001f))
			{
				class2 = Class458.smethod_2(new RectangleF(0f, num3, width, num5));
				class2.class770_0 = new Class770(Color.Black, 1f);
				@class.Add(class2);
				float num6 = Class1625.smethod_18(text2, workbook_0.Worksheets.DefaultFont, double_5[1], 0);
				Class463 class452_2 = new Class463(class3, Color.Black, new PointF((width - num6) / 2f, (float)((double)(num3 + num5) - (double)class3.method_2() * double_5[1])), text2);
				@class.Add(class452_2);
				num3 += num5;
			}
		}
		@class.vmethod_1(new Matrix(1f, 0f, 0f, 1f, float_2, float_3));
		return @class;
	}

	public override void vmethod_0(Class468 class468_1)
	{
		class515_0.method_1(new Class426(workbook_0, bool_0: true));
		class468_0 = class468_1;
		if (class468_0 is Class473)
		{
			bool_0 = false;
		}
		else
		{
			bool_0 = true;
		}
		Class457 @class = null;
		@class = ((imageOrPrintOptions_0 != null && imageOrPrintOptions_0.OnlyArea) ? new Class457(class1623_0.rectangleF_0.Width, class1623_0.rectangleF_0.Height) : ((imageOrPrintOptions_0 == null || !imageOrPrintOptions_0.OnePagePerSheet) ? new Class457((float)double_7[0], (float)double_7[1]) : new Class457(class1623_0.rectangleF_0.Width + (float)class1623_0.double_7 * 72f / 2.54f + (float)class1623_0.double_9 * 72f / 2.54f, class1623_0.rectangleF_0.Height + (float)class1623_0.double_8 * 72f / 2.54f + (float)class1623_0.double_10 * 72f / 2.54f)));
		class468_1.arrayList_1.Clear();
		class468_1.arrayList_2.Clear();
		if (!imageOrPrintOptions_0.OnlyArea)
		{
			@class.Add(method_26());
		}
		int_4 = class1623_0.int_7;
		int_5 = class1623_0.int_8;
		int_2 = class1623_0.int_5;
		int_3 = class1623_0.int_6;
		RectangleF rectangleF_ = default(RectangleF);
		RectangleF rectangleF_2 = default(RectangleF);
		double_5 = class1623_0.double_0;
		Class454 class2 = method_27(ref rectangleF_);
		RectangleF rectangleF_3 = default(RectangleF);
		rectangleF_3.X = rectangleF_.X - 0.5f;
		rectangleF_3.Y = rectangleF_.Y - 0.5f;
		rectangleF_3.Width = rectangleF_.Width + 1f;
		rectangleF_3.Height = rectangleF_.Height + 1f;
		class2.vmethod_2(new Class458(rectangleF_3));
		@class.Add(class2);
		Class454 class3 = method_28(ref rectangleF_2);
		rectangleF_3.X = rectangleF_2.X - 0.5f;
		rectangleF_3.Y = rectangleF_2.Y - 0.5f;
		rectangleF_3.Width = rectangleF_2.Width + 1f;
		rectangleF_3.Height = rectangleF_2.Height + 1f;
		class3.vmethod_2(new Class458(rectangleF_3));
		@class.Add(class3);
		float[] array = new float[2];
		float[] array2 = array;
		Class454 class4 = null;
		if (worksheet_0.PageSetup.PrintHeadings)
		{
			class4 = method_2((float)class1623_0.double_7 * 72f / 2.54f, (float)class1623_0.double_8 * 72f / 2.54f, array2);
		}
		if (class2.method_1().Count > 0)
		{
			class2.vmethod_1(new Matrix());
			class2.imethod_0().Translate((float)class1623_0.double_7 * 72f / 2.54f + array2[0], (float)class1623_0.double_8 * 72f / 2.54f + array2[1]);
		}
		if (class3.method_1().Count > 0)
		{
			class3.vmethod_1(new Matrix());
			class3.imethod_0().Translate((float)class1623_0.double_7 * 72f / 2.54f + rectangleF_.Width + array2[0], (float)class1623_0.double_8 * 72f / 2.54f + array2[1]);
		}
		foreach (Class453 item in method_1())
		{
			item.method_0(@class);
			@class.Add(item);
		}
		class468_1.class461_0 = method_29();
		if (imageOrPrintOptions_0 != null && imageOrPrintOptions_0.DrawObjectEventHandler != null)
		{
			imageOrPrintOptions_0.DrawObjectEventHandler.method_1(int_0, int_1, int_7);
			imageOrPrintOptions_0.DrawObjectEventHandler.method_0(0f - class1623_0.rectangleF_0.X + (float)class1623_0.double_7 * 72f / 2.54f + rectangleF_.Width + array2[0], 0f - class1623_0.rectangleF_0.Y + (float)class1623_0.double_8 * 72f / 2.54f + rectangleF_2.Height + array2[1]);
		}
		Class454 class6 = method_25();
		smethod_1(class468_0, class6);
		class6.vmethod_2(new Class458(new RectangleF(class1623_0.rectangleF_0.X - 0.5f, class1623_0.rectangleF_0.Y - 0.5f, (float)Math.Ceiling(Math.Min(class1623_0.rectangleF_0.Width, class1623_0.double_3)) + 1f, (float)Math.Ceiling(class1623_0.rectangleF_0.Height + 1f))));
		class6.vmethod_1(new Matrix());
		@class.Add(class6);
		if (worksheet_0.DisplayRightToLeft)
		{
			class6.imethod_0().Translate(0f - class1623_0.rectangleF_0.Right - (float)class1623_0.double_9 * 72f / 2.54f + (float)double_1 * 72f + rectangleF_.Width + array2[0], 0f - class1623_0.rectangleF_0.Y + (float)class1623_0.double_8 * 72f / 2.54f + rectangleF_2.Height + array2[1]);
		}
		else
		{
			class6.imethod_0().Translate(0f - class1623_0.rectangleF_0.X + (float)class1623_0.double_7 * 72f / 2.54f + rectangleF_.Width + array2[0], 0f - class1623_0.rectangleF_0.Y + (float)class1623_0.double_8 * 72f / 2.54f + rectangleF_2.Height + array2[1]);
		}
		if (class4 != null)
		{
			class4.vmethod_2(new Class458(new RectangleF(-0.5f, -0.5f, rectangleF_.Width + array2[0] + (float)Math.Ceiling(Math.Min(class1623_0.rectangleF_0.Width, class1623_0.double_3)) + 1f, rectangleF_2.Height + (float)Math.Ceiling(class1623_0.rectangleF_0.Height + 1f) + array2[1])));
			Class458 class7 = Class458.smethod_2(new RectangleF(0f, 0f, rectangleF_.Width + array2[0] + (float)Math.Ceiling(Math.Min(class1623_0.rectangleF_0.Width, class1623_0.double_3)), rectangleF_2.Height + (float)Math.Ceiling(class1623_0.rectangleF_0.Height) + array2[1]));
			class7.class770_0 = new Class770(Color.Black);
			class4.Add(class7);
			@class.Add(class4);
		}
		smethod_0(@class);
		@class.vmethod_0(class468_0);
		class4 = null;
		class6.vmethod_2(null);
		class6.method_0(null);
		class6 = null;
		@class = null;
	}

	private void method_3(Struct88 struct88_1, float float_2, float float_3)
	{
		float_1 = float_2;
		float_0 = float_3;
		class1624_0.class454_1 = new Class454();
		method_4(struct88_1);
	}

	private void method_4(Struct88 struct88_1)
	{
		int num = struct88_1.int_0;
		int num2 = struct88_1.int_2;
		int int_ = struct88_1.int_1;
		int int_2 = struct88_1.int_3;
		int num3 = num;
		double_0 = 0.0;
		class1624_0.int_0 = num;
		class1624_0.int_1 = int_;
		class1624_0.int_2 = num2;
		class1624_0.int_3 = int_2;
		class1624_0.cells_0 = worksheet_0.Cells;
		class1624_0.method_10();
		class1624_0.method_9();
		class1624_0.method_11();
		class1624_0.method_27();
		class1624_0.bool_2 = false;
		class1624_0.float_3 = float_0;
		class1624_0.float_2 = float_1;
		class1624_0.double_0 = double_5;
		int num4 = 0;
		for (num3 = num; num3 <= num2; num3++)
		{
			float num5 = (float)double_5[1] * (float)cells_0.GetRowHeight(num3);
			if (num5 == 0f)
			{
				num4++;
				if (num4 > 1)
				{
					continue;
				}
			}
			else
			{
				num4 = 0;
			}
			method_6(num3, num, int_, num2, int_2);
			class1624_0.float_3 += num5;
		}
		struct88_1 = method_5(struct88_1, bool_1: false);
		class1624_0.method_13();
		class1624_0.method_12(float_1, float_0);
		class1624_0.method_14();
		class1624_0.method_30();
	}

	private Struct88 method_5(Struct88 struct88_1, bool bool_1)
	{
		double num = 0.0;
		double num2 = 0.0;
		if (arrayList_3 != null)
		{
			foreach (Class1626 item in arrayList_3)
			{
				if (!Class1625.smethod_1(item, struct88_1, int_7))
				{
					continue;
				}
				class1624_0.arrayList_0 = null;
				if (!item.method_4().IsPrintable)
				{
					continue;
				}
				num = float_1;
				num2 = float_0;
				for (int i = struct88_1.int_0; i < item.method_0(); i++)
				{
					num2 += cells_0.GetRowHeightInch(i) * 72.0 * double_5[1];
				}
				if (item.method_0() < struct88_1.int_0)
				{
					for (int num3 = struct88_1.int_0 - 1; num3 >= item.method_0(); num3--)
					{
						num2 -= cells_0.GetRowHeightInch(num3) * 72.0 * double_5[1];
					}
				}
				class1624_0.float_3 = (float)num2;
				for (int j = struct88_1.int_1; j < item.method_2(); j++)
				{
					num += cells_0.GetColumnWidthInch(j) * 72.0 * double_5[0];
				}
				if (item.method_2() < struct88_1.int_1)
				{
					for (int num4 = struct88_1.int_1 - 1; num4 >= item.method_2(); num4--)
					{
						num -= cells_0.GetColumnWidthInch(num4) * 72.0 * double_5[0];
					}
				}
				class1624_0.float_2 = (float)num;
				if (bool_1)
				{
					method_14(item, bool_1);
				}
				else if (!item.bool_0)
				{
					Rectangle rect = new Rectangle(item.method_2(), item.method_0(), item.method_3() - item.method_2() + 1, item.method_1() - item.method_0() + 1);
					if (new Rectangle(struct88_1.int_1, struct88_1.int_0, struct88_1.int_3 - struct88_1.int_1 + 1, struct88_1.int_2 - struct88_1.int_0 + 1).IntersectsWith(rect))
					{
						method_14(item, bool_1);
						item.bool_0 = true;
					}
				}
			}
		}
		if (worksheet_0.SparklineGroupCollection != null && worksheet_0.SparklineGroupCollection.Count > 0)
		{
			for (int k = 0; k < worksheet_0.SparklineGroupCollection.Count; k++)
			{
				SparklineGroup sparklineGroup = worksheet_0.SparklineGroupCollection[k];
				SparklineCollection sparklineCollection = sparklineGroup.SparklineCollection;
				if (sparklineCollection.method_3().Index != worksheet_0.Index)
				{
					continue;
				}
				for (int l = 0; l < sparklineCollection.Count; l++)
				{
					Sparkline sparkline = sparklineCollection[l];
					if (sparkline.Row >= struct88_1.int_0 && sparkline.Row <= struct88_1.int_2 && sparkline.Column >= struct88_1.int_1 && sparkline.Column <= struct88_1.int_3)
					{
						num = float_1;
						num2 = float_0;
						for (int m = struct88_1.int_0; m < sparkline.Row; m++)
						{
							num2 += cells_0.GetRowHeightInch(m) * 72.0 * double_5[1];
						}
						for (int n = struct88_1.int_1; n < sparkline.Column; n++)
						{
							num += cells_0.GetColumnWidthInch(n) * 72.0 * double_5[0];
						}
						float width = (float)(cells_0.GetColumnWidthInch(sparkline.Column) * 72.0 * double_5[0]);
						float height = (float)(cells_0.GetRowHeightInch(sparkline.Row) * 72.0 * double_5[1]);
						new Class454();
						ImageOrPrintOptions imageOrPrintOptions = new ImageOrPrintOptions();
						imageOrPrintOptions.ImageFormat = ImageFormat.Emf;
						MemoryStream memoryStream = new MemoryStream();
						sparkline.ToImage(memoryStream, imageOrPrintOptions);
						Class465 class452_ = Class465.smethod_0(new PointF((float)num, (float)num2), new SizeF(width, height), memoryStream);
						class1624_0.method_28(class452_);
						memoryStream = null;
					}
				}
			}
		}
		return struct88_1;
	}

	private void method_6(int int_14, int int_15, int int_16, int int_17, int int_18)
	{
		class1624_0.class456_0 = this;
		ArrayList arrayList = method_10(int_14, int_15, int_16, int_17, int_18);
		foreach (Class1620 item in arrayList)
		{
			float num = float_1;
			float num2 = 0f;
			int num3 = item.method_24();
			if (item.int_6 < 0)
			{
				num3 = item.method_24() - (item.method_27() - 1);
				if (num3 < 0)
				{
					num3 = 0;
				}
			}
			for (int i = int_16; i < num3; i++)
			{
				num2 += (float)cells_0.GetColumnWidthInch(i) * 72f * (float)double_5[0];
			}
			class1624_0.float_1 = 0f;
			class1624_0.int_4 = 0;
			if (item.int_6 > 0)
			{
				int num4 = 0;
				for (int j = num3; j < item.method_24() + item.method_27() + num4 && j <= 16383; j++)
				{
					if (cells_0.GetColumnWidthPixel(j) == 0)
					{
						num4++;
					}
					float num5 = (float)cells_0.GetColumnWidthInch(j) * 72f * (float)double_5[0];
					class1624_0.float_1 += num5;
					class1624_0.int_4 += cells_0.GetColumnWidthPixel(j);
				}
			}
			else
			{
				for (int k = num3; k <= item.method_24() && k <= 16383; k++)
				{
					float num6 = (float)cells_0.GetColumnWidthInch(k) * 72f * (float)double_5[0];
					class1624_0.float_1 += num6;
					class1624_0.int_4 += cells_0.GetColumnWidthPixel(k);
				}
			}
			num += num2;
			if (int_4 > 0 && int_16 > int_4)
			{
				num += (float)double_0;
			}
			if (worksheet_0.DisplayRightToLeft)
			{
				class1624_0.float_2 = class1623_0.rectangleF_0.Right - (num - class1623_0.rectangleF_0.Left) - class1624_0.float_1 + 1f;
			}
			else
			{
				class1624_0.float_2 = num;
			}
			if (smethod_2(cells_0, item))
			{
				method_13(item);
			}
		}
		arrayList = null;
	}

	private static bool smethod_2(Cells cells_1, Class1620 class1620_0)
	{
		if (class1620_0 == null)
		{
			return false;
		}
		if (class1620_0.method_13())
		{
			return false;
		}
		double num = 0.0;
		int num2 = 0;
		int num3 = class1620_0.method_24();
		while (num2 < class1620_0.method_27())
		{
			num += (double)cells_1.GetColumnWidthPixel(num3);
			num2++;
			num3 += class1620_0.int_6;
		}
		if (num > 0.0)
		{
			return true;
		}
		return false;
	}

	public static void smethod_3(ArrayList arrayList_5, Workbook workbook_1, string string_0)
	{
		foreach (Class1544 item in arrayList_5)
		{
			if (item.font_0 == null)
			{
				item.font_0 = new Aspose.Cells.Font(workbook_1.Worksheets, null);
			}
			if (!Class1462.smethod_6(item.font_0.Name, item.font_0.method_30(), item.string_0))
			{
				Aspose.Cells.Font font = workbook_1.DefaultStyle.method_40();
				Aspose.Cells.Font font2 = new Aspose.Cells.Font(workbook_1.Worksheets, null);
				font2.Copy(item.font_0);
				if (Class1462.smethod_6(font.Name, item.font_0.method_30(), item.string_0))
				{
					font2.Name = font.Name;
				}
				else if (Class1462.smethod_6(string_0, item.font_0.method_30(), item.string_0))
				{
					font2.Name = string_0;
				}
				else
				{
					font2.Name = Struct78.string_0;
				}
				item.font_0 = font2;
			}
		}
	}

	private void method_7(Class1620 class1620_0)
	{
		foreach (Class1544 item in class1620_0.method_36())
		{
			class1620_0.string_2 += item.string_0;
			if (item.font_0 == null)
			{
				item.font_0 = new Aspose.Cells.Font(workbook_0.Worksheets, null);
			}
			if (class1448_0.method_18() && !Class1462.smethod_6(item.font_0.Name, item.font_0.method_30(), item.string_0))
			{
				Aspose.Cells.Font font = workbook_0.DefaultStyle.method_40();
				Aspose.Cells.Font font2 = new Aspose.Cells.Font(workbook_0.Worksheets, null);
				font2.Copy(item.font_0);
				if (Class1462.smethod_6(font.Name, item.font_0.method_30(), item.string_0))
				{
					font2.Name = font.Name;
				}
				else if (Class1462.smethod_6(font_0.Name, item.font_0.method_30(), item.string_0))
				{
					font2.Name = font_0.Name;
				}
				else
				{
					font2.Name = Struct78.string_0;
				}
				item.font_0 = font2;
			}
		}
	}

	private Class1620 method_8(int int_14, int int_15, int int_16, int int_17, int int_18, int int_19)
	{
		Class1620 @class = new Class1620(int_14, int_15);
		Cell cell = cells_0.CheckCell(int_14, int_15);
		if (cell != null)
		{
			if (cell.IsRichText())
			{
				@class.method_12(1);
			}
			@class.method_6(cell.method_20() == Enum199.const_4 || cell.method_20() == Enum199.const_5);
			@class.method_20(cell.Type);
		}
		@class.method_1(worksheet_0.DisplayZeros);
		@class.method_18(cell);
		if (hashtable_1 != null && hashtable_1 != null && hashtable_1.ContainsValue(cell))
		{
			@class.method_34("Cell_" + worksheet_0.Index + "_" + int_14 + "_" + int_15);
			if (@class.method_33() != null && @class.method_33().Length > 0)
			{
				int num = smethod_5(arrayList_4, @class);
				float num2 = (float)(class1623_0.double_7 / 2.5399999618530273 * 72.0);
				float num3 = (float)(class1623_0.double_8 / 2.5399999618530273 * 72.0);
				hashtable_3[@class.Cell] = "" + num + "_" + (num2 + class1624_0.float_2 - ((Class1623)arrayList_4[num]).rectangleF_0.X) + "_" + (float)(double_7[1] - (double)(class1624_0.float_3 + num3 - ((Class1623)arrayList_4[num]).rectangleF_0.Y));
			}
		}
		foreach (Struct88 item in arrayList_2)
		{
			if (int_14 < item.int_0 || int_14 > item.int_2 || int_15 < item.int_1 || int_15 > item.int_3)
			{
				continue;
			}
			@class.method_31(item);
			@class.method_29(bool_5: true);
			if ((int_14 != item.int_0 && int_14 != int_16) || (int_15 != item.int_1 && int_15 != int_17))
			{
				@class.method_14(bool_5: true);
				return @class;
			}
			if (item.int_0 <= int_18 && item.int_0 >= int_16 && item.int_2 <= int_18 && item.int_2 >= int_16)
			{
				@class.method_8(Class1625.smethod_5(cells_0, int_16, int_17, int_18, int_19, item));
			}
			else
			{
				int num4 = Math.Max(int_2, item.int_0);
				int num5 = Math.Min(int_3, item.int_2);
				@class.method_8(Class1625.smethod_5(cells_0, num4, item.int_1, num5, item.int_3, item));
			}
			@class.method_28(0);
			for (int i = int_15; i <= item.int_3; i++)
			{
				if (cells_0.GetColumnWidthPixel(i) != 0)
				{
					@class.method_28(@class.method_27() + 1);
				}
			}
			@class.method_26(0);
			for (int j = int_14; j <= item.int_2; j++)
			{
				if (cells_0.GetRowHeightPixel(j) != 0)
				{
					@class.method_26(@class.method_25() + 1);
				}
			}
			break;
		}
		for (int k = 0; k < worksheet_0.Hyperlinks.Count; k++)
		{
			CellArea area = worksheet_0.Hyperlinks[k].Area;
			if (int_14 >= area.StartRow && int_14 <= area.EndRow && int_15 >= area.StartColumn && int_15 <= area.EndColumn)
			{
				@class.method_32(worksheet_0.Hyperlinks[k]);
				break;
			}
		}
		if (@class.method_7() == null)
		{
			@class.method_8(Class1625.GetCellStyle(cells_0, cell, int_14, int_15, style_0, struct88_0));
		}
		if (worksheet_0.ListObjects != null && worksheet_0.ListObjects.Count > 0)
		{
			try
			{
				Style cellStyle = worksheet_0.ListObjects.GetCellStyle(int_14, int_15);
				if (cellStyle != null)
				{
					Style style = new Style(workbook_0.Worksheets);
					style.Copy(@class.method_7());
					@class.method_8(style);
					Class1627.smethod_4(@class.method_7(), cellStyle, workbook_0.Worksheets.DefaultStyle);
				}
			}
			catch
			{
			}
		}
		if (cell != null)
		{
			Class518 class2 = cell.Format(class515_0);
			if (!Class1178.smethod_0(class2.Color))
			{
				@class.method_7().Font.Color = class2.Color;
			}
		}
		if (cell != null && worksheet_0.conditionalFormattingCollection_0 != null && worksheet_0.conditionalFormattingCollection_0.Count > 0)
		{
			Class314 class3 = Class1627.smethod_0(worksheet_0, cell, @class.method_7(), bool_0: true);
			@class.method_8(class3.style_1);
			@class.hashtable_0 = class3.hashtable_0;
		}
		if (@class.method_35())
		{
			CellValueType type = cell.Type;
			switch (@class.method_7().HorizontalAlignment)
			{
			case TextAlignmentType.CenterAcross:
				@class.method_16(TextAlignmentType.Center);
				@class.method_5(bool_5: true);
				break;
			case TextAlignmentType.Center:
			case TextAlignmentType.Distributed:
				@class.method_16(TextAlignmentType.Center);
				break;
			case TextAlignmentType.General:
				switch (type)
				{
				case CellValueType.IsBool:
					@class.method_16(TextAlignmentType.Center);
					break;
				case CellValueType.IsDateTime:
					@class.method_16(TextAlignmentType.Right);
					break;
				default:
					@class.method_16(TextAlignmentType.Center);
					break;
				case CellValueType.IsNumeric:
				{
					if (@class.method_7().Number == Class1242.int_1)
					{
						@class.method_16(TextAlignmentType.Left);
						break;
					}
					bool isLeft3 = false;
					@class.method_10(Class1625.smethod_3(cell.DoubleValue, cells_0.GetColumnWidthPixel(cell.Column), @class.method_7(), @class.method_7().Font, out isLeft3));
					if (isLeft3)
					{
						@class.method_16(TextAlignmentType.Left);
					}
					else
					{
						@class.method_16(TextAlignmentType.Right);
					}
					break;
				}
				case CellValueType.IsString:
					if ((cell != null && Class1078.smethod_1(cell.StringValue)) || @class.method_7().RotationAngle < 0)
					{
						@class.method_16(TextAlignmentType.Right);
					}
					else
					{
						@class.method_16(TextAlignmentType.Left);
					}
					break;
				}
				break;
			case TextAlignmentType.Justify:
				@class.method_16(TextAlignmentType.Justify);
				break;
			case TextAlignmentType.Left:
				if (@class.method_7().IndentLevel != 0)
				{
					@class.method_22("PaddingLeft");
					@class.method_3(72f * (float)Class1625.smethod_26(@class.method_7().IndentLevel, style_0.Font, double_5[1]) / 96f);
					@class.method_39(@class.method_38() + (int)Class1625.smethod_26(@class.method_7().IndentLevel, style_0.Font, 1.0));
				}
				@class.method_16(TextAlignmentType.Left);
				break;
			case TextAlignmentType.Right:
				if (@class.method_7().IndentLevel != 0)
				{
					@class.method_22("PaddingRight");
					@class.method_3(72f * (float)Class1625.smethod_26(@class.method_7().IndentLevel, style_0.Font, double_5[1]) / 96f);
					@class.method_39(@class.method_38() + (int)Class1625.smethod_26(@class.method_7().IndentLevel, style_0.Font, 1.0));
				}
				else
				{
					switch (type)
					{
					case CellValueType.IsNumeric:
					{
						bool isLeft2 = false;
						@class.method_10(Class1625.smethod_3(cell.DoubleValue, cells_0.GetColumnWidthPixel(cell.Column), @class.method_7(), @class.method_7().Font, out isLeft2));
						if (isLeft2)
						{
							@class.method_16(TextAlignmentType.Left);
						}
						else
						{
							@class.method_16(TextAlignmentType.Right);
						}
						break;
					}
					case CellValueType.IsString:
					{
						bool isLeft = false;
						@class.method_10(Class1625.smethod_2(cells_0.GetColumnWidthPixel(cell.Column), @class.method_7(), @class.method_7().Font, out isLeft));
						if (isLeft)
						{
							@class.method_16(TextAlignmentType.Left);
						}
						else
						{
							@class.method_16(TextAlignmentType.Right);
						}
						break;
					}
					}
				}
				@class.method_16(TextAlignmentType.Right);
				break;
			}
		}
		@class.border_2 = ((@class.method_7().method_4() == null) ? null : @class.method_7().Borders[BorderType.DiagonalUp]);
		@class.border_3 = ((@class.method_7().method_4() == null) ? null : @class.method_7().Borders[BorderType.DiagonalDown]);
		if (@class.method_7().IsTextWrapped && @class.method_35())
		{
			@class.method_7().ShrinkToFit = false;
		}
		if (@class.Cell != null)
		{
			if (@class.Cell.Type == CellValueType.IsDateTime && @class.Cell.DoubleValue < 0.0)
			{
				@class.method_37(new ArrayList());
				Class1544 class4 = new Class1544();
				class4.font_0 = @class.method_7().Font;
				class4.string_0 = Class1625.smethod_4(cells_0.GetColumnWidthPixel(@class.method_24()), '#', @class.method_7().Font);
				@class.method_36().Add(class4);
				@class.string_2 = class4.string_0;
			}
			else if (@class.Cell.StringValue.Length != 0)
			{
				@class.method_37(@class.Cell.method_70());
				if (@class.method_36().Count > 0)
				{
					method_7(@class);
				}
			}
		}
		if (@class.method_36() != null)
		{
			if (@class.method_9() != null && @class.method_7() != null && (@class.method_7().HorizontalAlignment == TextAlignmentType.General || (@class.method_7().HorizontalAlignment == TextAlignmentType.Right && !@class.method_7().IsTextWrapped)))
			{
				if (@class.method_15() == TextAlignmentType.Left)
				{
					@class.method_36().Insert(0, @class.method_9());
				}
				else
				{
					@class.method_36().Add(@class.method_9());
				}
			}
			if (@class.method_11() == -1 && @class.method_36().Count == 1)
			{
				Class1544 class5 = (Class1544)@class.method_36()[0];
				string name = class5.font_0.Name;
				class5.font_0.Copy(@class.method_7().Font);
				class5.font_0.Color = Class1625.smethod_22(@class.method_7(), @class.method_7().Font, cell);
				class5.font_0.Name = name;
			}
			foreach (Class1544 item2 in @class.method_36())
			{
				if (@class.Cell != null && @class.Cell.Type == CellValueType.IsNumeric)
				{
					item2.font_0.Color = @class.method_7().Font.Color;
				}
				item2.int_0 = Class1625.smethod_19(item2.string_0, item2.font_0, 1.0);
				@class.method_39(@class.method_38() + item2.int_0);
			}
		}
		if (@class.method_21() != null && @class.method_21() != "")
		{
			@class.method_39(@class.method_38() + (int)Class1625.smethod_26(@class.method_7().IndentLevel, style_0.Font, 1.0));
		}
		return @class;
	}

	private long method_9(int int_14, int int_15)
	{
		if (arrayList_2 != null && arrayList_2.Count > 0)
		{
			for (int num = arrayList_2.Count - 1; num >= 0; num--)
			{
				Struct88 @struct = (Struct88)arrayList_2[num];
				if (@struct.int_0 <= int_14 && @struct.int_2 >= int_14 && @struct.int_1 <= int_15 && @struct.int_3 >= int_15)
				{
					for (int i = @struct.int_1; i <= @struct.int_3; i++)
					{
						if (cells_0.GetColumnWidthPixel(i) <= 0)
						{
							continue;
						}
						for (int j = @struct.int_0; j <= @struct.int_2; j++)
						{
							if (cells_0.GetRowHeightPixel(j) > 0)
							{
								return ((long)@struct.int_0 << 20) + @struct.int_1;
							}
						}
					}
				}
			}
		}
		return -1L;
	}

	private static string smethod_4(int int_14, Aspose.Cells.Font font_1)
	{
		string text = "";
		if (font_1 == null)
		{
			return text;
		}
		int num = (int)((double)Class1625.smethod_19("##########", font_1, 1.0) / 10.0);
		int num2 = (int_14 - 2) / num;
		for (int i = 0; i < num2; i++)
		{
			text += "#";
		}
		return text;
	}

	private ArrayList method_10(int int_14, int int_15, int int_16, int int_17, int int_18)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = int_16; i <= int_18; i++)
		{
			if (cells_0.GetColumnWidthPixel(i) == 0 && method_9(int_14, i) < 0)
			{
				continue;
			}
			Class1620 @class = method_8(int_14, i, int_15, int_16, int_17, int_18);
			if (@class.method_13())
			{
				i = @class.method_30().int_3;
				continue;
			}
			arrayList.Add(@class);
			if (@class.method_15() == TextAlignmentType.Left && i <= int_18 && @class.method_7().VerticalAlignment != TextAlignmentType.Justify)
			{
				float float_ = (float)@class.method_38() / 96f * 72f;
				Class1620 class1620_ = method_8(int_14, i + 1, int_15, int_16, int_17, int_18);
				Class1620 class1620_2 = @class;
				if (!@class.method_7().IsTextWrapped && @class.method_19() == CellValueType.IsString && !@class.method_7().ShrinkToFit)
				{
					while (!method_11(@class, class1620_2, class1620_, ref float_, ref i, arrayList) && i < int_11)
					{
						class1620_ = method_8(int_14, i + 1, int_15, int_16, int_17, int_18);
					}
				}
			}
			else if (@class.method_15() == TextAlignmentType.Center)
			{
				if (@class.method_4())
				{
					Class1620 class2 = @class;
					while (i <= int_18)
					{
						i++;
						Class1620 class3 = method_8(int_14, i, int_15, int_16, int_17, int_18);
						if (!class3.method_35() && class3.method_7() != null && class3.method_7().HorizontalAlignment == TextAlignmentType.CenterAcross)
						{
							@class.method_28(@class.method_27() + 1);
							class2.RightBorder = null;
							class3.LeftBorder = null;
							class2 = class3;
							continue;
						}
						i--;
						break;
					}
				}
			}
			else if (@class.method_15() == TextAlignmentType.Right && @class.method_35() && !@class.IsMerged && !@class.method_7().IsTextWrapped && @class.method_19() == CellValueType.IsString && !@class.method_7().ShrinkToFit)
			{
				method_12(arrayList, @class);
			}
			if (@class.method_36() == null || @class.method_36().Count == 0)
			{
				continue;
			}
			Class1544 class4 = (Class1544)@class.method_36()[0];
			int num = @class.method_43(cells_0);
			if (@class.hashtable_0 != null && @class.hashtable_0.Count > 0 && @class.hashtable_0.Contains("IconSetStyle"))
			{
				num -= 16;
			}
			if (@class.Cell == null)
			{
				continue;
			}
			int num2 = @class.method_43(cells_0) - (int)(Class1625.smethod_26(@class.method_7().IndentLevel, style_0.Font, 1.0) * 1.3333);
			((Class426)class515_0.method_0()).Width = num2 - 2;
			((Class426)class515_0.method_0()).method_0(@class.Cell.method_35());
			switch (@class.method_19())
			{
			case CellValueType.IsDateTime:
			{
				if (Math.Abs(@class.Cell.DoubleValue) == 0.0 && !@class.method_0())
				{
					class4.string_0 = "";
					break;
				}
				Class518 class6 = @class.Cell.Format(class515_0);
				if (class6.method_4())
				{
					class4.string_0 = smethod_4(num2, class4.font_0);
				}
				else
				{
					class4.string_0 = class6.StringValue;
				}
				break;
			}
			case CellValueType.IsBool:
			case CellValueType.IsError:
			case CellValueType.IsNumeric:
			{
				if (@class.method_19() == CellValueType.IsNumeric && Math.Abs(@class.Cell.DoubleValue) == 0.0 && !@class.method_0())
				{
					class4.string_0 = "";
					break;
				}
				Class518 class5 = @class.Cell.Format(class515_0);
				if (class5.method_4())
				{
					class4.string_0 = smethod_4(num2, class4.font_0);
				}
				else
				{
					class4.string_0 = class5.StringValue;
				}
				break;
			}
			}
		}
		return arrayList;
	}

	internal bool method_11(Class1620 class1620_0, Class1620 class1620_1, Class1620 class1620_2, ref float float_2, ref int int_14, ArrayList arrayList_5)
	{
		if (cells_0.GetColumnWidthPixel(class1620_2.method_24()) != 0 && (class1620_2.method_35() || class1620_2.IsMerged || (class1620_2.method_19() != CellValueType.IsNull && class1620_2.method_36() != null)))
		{
			return true;
		}
		if ((double)float_2 >= class1620_0.method_42(cells_0))
		{
			class1620_2.LeftBorder = null;
			class1620_1.RightBorder = null;
			if (cells_0.GetColumnWidthPixel(class1620_2.method_24()) != 0)
			{
				class1620_0.method_28(class1620_0.method_27() + 1);
			}
			int_14++;
			class1620_1 = class1620_2;
			return false;
		}
		return true;
	}

	private void method_12(ArrayList arrayList_5, Class1620 class1620_0)
	{
		Class1620 @class = class1620_0;
		if (arrayList_5.Count == 0 || (class1620_0.Cell != null && (class1620_0.Cell.method_20() == Enum199.const_3 || class1620_0.Cell.method_20() == Enum199.const_8)))
		{
			return;
		}
		int num = 0;
		int num2 = class1620_0.method_38() - class1620_0.method_43(cells_0);
		if (num2 <= 0)
		{
			return;
		}
		int num3 = 1;
		num = arrayList_5.Count - 2;
		while (num >= 0 && num2 > 0)
		{
			Class1620 class2 = (Class1620)arrayList_5[num];
			if (class2 != null && (class2.method_36() != null || method_9(class1620_0.method_23(), class2.method_24()) >= 0))
			{
				break;
			}
			num2 -= cells_0.GetColumnWidthPixel(class2.method_24());
			class1620_0.int_6 = -1;
			num3++;
			class2.RightBorder = null;
			@class.LeftBorder = null;
			@class = class2;
			num--;
		}
		class1620_0.method_28(num3);
	}

	private void method_13(Class1620 class1620_0)
	{
		class1624_0.class468_0 = class468_0;
		method_21(class1620_0);
		class1624_0.class1620_0 = class1620_0;
		class1624_0.method_15();
		class1624_0.method_8();
		class1624_0.method_31();
		if (class1620_0.method_35() && class1620_0.method_36() != null)
		{
			class1624_0.arrayList_1 = class1620_0.method_36();
			class1624_0.class1620_0 = class1620_0;
			if (imageOrPrintOptions_0.DrawObjectEventHandler != null)
			{
				imageOrPrintOptions_0.DrawObjectEventHandler.Draw(class1624_0);
			}
			class1624_0.method_1();
		}
		class1624_0.arrayList_0 = null;
	}

	private void method_14(Class1626 class1626_0, bool bool_1)
	{
		lock (arrayList_1)
		{
			MsoDrawingType msoDrawingType = class1626_0.MsoDrawingType;
			if (msoDrawingType != MsoDrawingType.Chart && msoDrawingType != MsoDrawingType.Picture)
			{
				try
				{
					method_15(class1626_0, bool_1);
					return;
				}
				catch (Exception)
				{
					throw new CellsException(ExceptionType.Shape, "Shape to image Error!");
				}
			}
			try
			{
				method_20(class1626_0, bool_1);
			}
			catch (Exception)
			{
				throw new CellsException(ExceptionType.Chart, "Chart to image Error!");
			}
		}
	}

	private void method_15(Class1626 class1626_0, bool bool_1)
	{
		class1624_0.float_5 = (float)((double)class1626_0.method_4().method_57().Left * double_5[0]) * 72f / 96f;
		class1624_0.float_6 = (float)((double)class1626_0.method_4().method_57().Top * double_5[1]) * 72f / 96f;
		class1624_0.float_1 = Math.Max((float)((double)class1626_0.method_4().method_57().Width * double_5[0]), 1f) * 72f / 96f;
		class1624_0.float_0 = Math.Max((float)((double)class1626_0.method_4().method_57().Height * double_5[1]), 1f) * 72f / 96f;
		ImageOrPrintOptions imageOrPrintOptions = new ImageOrPrintOptions();
		imageOrPrintOptions.ImageFormat = class468_0.imageFormat_0;
		int width = class1626_0.method_4().Width;
		int height = class1626_0.method_4().Height;
		if (class1624_0.float_0 * class1624_0.float_1 != 0f)
		{
			MemoryStream memoryStream = new MemoryStream();
			if (Class1448.smethod_0())
			{
				imageOrPrintOptions.ImageFormat = ImageFormat.Jpeg;
				if (class1626_0.MsoDrawingType == MsoDrawingType.Line)
				{
					class1626_0.method_4().method_56(memoryStream, imageOrPrintOptions);
				}
				else
				{
					class1626_0.method_4().ToImage(memoryStream, imageOrPrintOptions);
				}
			}
			else if (class1626_0.MsoDrawingType == MsoDrawingType.OleObject)
			{
				imageOrPrintOptions.ImageFormat = ImageFormat.Emf;
				class1626_0.method_4().ToImage(memoryStream, imageOrPrintOptions);
			}
			else
			{
				class1626_0.method_4().ToImage(memoryStream, imageOrPrintOptions);
			}
			memoryStream.Seek(0L, SeekOrigin.Begin);
			if (class1626_0.method_4().method_57().Height * class1626_0.method_4().method_57().Width > 0f)
			{
				RectangleF rectangleF_ = new RectangleF(class1624_0.float_2 + class1624_0.float_5, class1624_0.float_3 + class1624_0.float_6, (float)((double)class1626_0.method_4().method_57().Width * double_5[0] * 72.0 / 96.0), (float)((double)class1626_0.method_4().method_57().Height * double_5[1] * 72.0 / 96.0));
				Class454 @class = null;
				if (class1626_0.method_4().AutoShapeType == AutoShapeType.Line && class1626_0.method_4().LineFormat.BeginArrowheadStyle == MsoArrowheadStyle.None && class1626_0.method_4().LineFormat.EndArrowheadStyle == MsoArrowheadStyle.None)
				{
					@class = new Class454();
					Class454 class452_ = Class871.smethod_1(class1626_0.method_4());
					@class.Add(class452_);
					@class.vmethod_1(new Matrix());
					@class.imethod_0().Translate(class1624_0.float_2, class1624_0.float_3);
					@class.imethod_0().Scale((float)double_5[0], (float)double_5[1]);
				}
				else
				{
					@class = method_18(class1626_0, memoryStream, rectangleF_);
				}
				if (!bool_1)
				{
					@class.method_4(new Class461(rectangleF_.X - 0.5f, rectangleF_.Y - 0.5f, rectangleF_.Width + 1f, rectangleF_.Height + 1f));
				}
				if (imageOrPrintOptions_0.DrawObjectEventHandler != null)
				{
					memoryStream.Seek(0L, SeekOrigin.Begin);
					imageOrPrintOptions_0.DrawObjectEventHandler.method_2(memoryStream, rectangleF_);
				}
				class1624_0.method_28(@class);
			}
			memoryStream.Seek(0L, SeekOrigin.Begin);
		}
		class1626_0.method_4().Width = width;
		class1626_0.method_4().Height = height;
	}

	private MemoryStream method_16(Class1626 class1626_0, int int_14)
	{
		MemoryStream memoryStream = new MemoryStream();
		if (hashtable_0[int_14] == null)
		{
			if (int_14 < 0 || int_14 >= worksheetCollection_0.method_84().method_0().Count)
			{
				memoryStream.Seek(0L, SeekOrigin.Begin);
				return memoryStream;
			}
			Class1696 class1696_ = worksheetCollection_0.method_84().method_0()[int_14];
			Class1715 picture = Class1716.GetPicture(class1696_);
			if (picture.Data != null)
			{
				memoryStream.Write(picture.Data, 0, picture.Data.Length);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				Enum200 @enum = Class1404.smethod_0(memoryStream);
				if ((@enum == Enum200.const_1 || @enum == Enum200.const_2) && class468_0.imageFormat_0 == ImageFormat.Emf)
				{
					return memoryStream;
				}
				Image image = Image.FromStream(memoryStream);
				memoryStream = new MemoryStream();
				if (image.Width >= 8 && image.Height >= 8)
				{
					switch (image.PixelFormat)
					{
					case PixelFormat.Format32bppRgb:
						Class1404.smethod_40(image, memoryStream, 90L);
						break;
					default:
						Class1404.smethod_38(image, memoryStream);
						break;
					case PixelFormat.Max:
					case PixelFormat.Indexed:
					case PixelFormat.Gdi:
					case PixelFormat.Format24bppRgb:
					case PixelFormat.Format4bppIndexed:
					case PixelFormat.Format8bppIndexed:
					case PixelFormat.Format48bppRgb:
						Class1404.smethod_38(image, memoryStream);
						break;
					}
				}
				else
				{
					Class1404.smethod_37(image, memoryStream);
				}
				memoryStream.Seek(0L, SeekOrigin.Begin);
				hashtable_0[int_14] = memoryStream;
				return memoryStream;
			}
		}
		memoryStream = (MemoryStream)hashtable_0[int_14];
		memoryStream.Seek(0L, SeekOrigin.Begin);
		return memoryStream;
	}

	private MemoryStream method_17(Class1626 class1626_0)
	{
		MemoryStream memoryStream = new MemoryStream();
		switch (class1626_0.method_4().MsoDrawingType)
		{
		default:
		{
			int num3 = 0;
			return null;
		}
		case MsoDrawingType.OleObject:
		{
			int num3 = ((OleObject)class1626_0.method_4()).method_75() - 1;
			return method_16(class1626_0, num3);
		}
		case MsoDrawingType.Picture:
		{
			int num3 = ((Picture)class1626_0.method_4()).method_70() - 1;
			return method_16(class1626_0, num3);
		}
		case MsoDrawingType.Chart:
		{
			Chart chart = ((ChartShape)class1626_0.method_4()).method_69();
			float num = 0f;
			float num2 = (float)worksheet_0.PageSetup.Zoom / 100f;
			num = ((!((double)num2 > double_5[1]) || !((double)num2 < double_5[0])) ? ((float)(double_5[0] + double_5[1]) / 2f) : num2);
			int width = chart.ChartObject.Width;
			int height = chart.ChartObject.Height;
			chart.ChartObject.Width = (int)((double)chart.ChartObject.Width * (double_5[0] / (double)num));
			chart.ChartObject.Height = (int)((double)chart.ChartObject.Height * (double_5[1] / (double)num));
			memoryStream = new MemoryStream();
			if (Class1448.smethod_0())
			{
				chart.ToImage(memoryStream, 90L);
			}
			else
			{
				chart.ToImage(memoryStream, class468_0.imageFormat_0);
			}
			memoryStream.Seek(0L, SeekOrigin.Begin);
			chart.ChartObject.Width = width;
			chart.ChartObject.Height = height;
			return memoryStream;
		}
		}
	}

	private Class454 method_18(Class1626 class1626_0, Stream stream_0, RectangleF rectangleF_0)
	{
		Class465 @class = Class465.smethod_0(new PointF(0f, 0f), new SizeF((float)class1626_0.method_4().WidthPt, (float)class1626_0.method_4().HeightPt), stream_0);
		SizeF sizeF_ = new SizeF((float)@class.method_4().method_0(), (float)@class.method_4().method_1());
		stream_0.Position = 0L;
		@class = Class465.smethod_0(new PointF(0f, 0f), sizeF_, stream_0);
		Class454 class2 = new Class454();
		if ((double)(@class.method_4().Width * @class.method_4().Height) < 0.0001)
		{
			return class2;
		}
		class2.Add(@class);
		float num = 0f;
		float num2 = 0f;
		float num3 = @class.Size.Width;
		float num4 = @class.Size.Height;
		RectangleF rectangleF_ = new RectangleF(num - 0.5f, num2 - 0.5f, num3 + 1f, num4 + 1f);
		class2.vmethod_1(new Matrix());
		float num5 = 1f;
		float num6 = 1f;
		num5 = rectangleF_0.Width / num3;
		num6 = rectangleF_0.Height / num4;
		class2.imethod_0().Translate((0f - num) * num5 + rectangleF_0.X, (0f - num2) * num6 + rectangleF_0.Y);
		class2.imethod_0().Scale(num5, num6);
		if (class1626_0.method_4().Hyperlink != null)
		{
			if (hashtable_1 != null && hashtable_1.ContainsKey(class1626_0.method_4().Hyperlink))
			{
				Cell value = (Cell)hashtable_1[class1626_0.method_4().Hyperlink];
				hashtable_4[class1626_0] = value;
				Class464 class3 = new Class464(new RectangleF(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height), "#shape_" + class1626_0.GetHashCode());
				hashtable_2[class1626_0] = class3;
				class1624_0.class454_1.Add(class3);
			}
			else
			{
				@class.method_5(new Class464(rectangleF_, class1626_0.method_4().Hyperlink.Address));
			}
		}
		return class2;
	}

	private Class454 method_19(Class1626 class1626_0, Stream stream_0, RectangleF rectangleF_0)
	{
		Class465 @class = Class465.smethod_0(new PointF(0f, 0f), new SizeF((float)class1626_0.method_4().WidthPt, (float)class1626_0.method_4().HeightPt), stream_0);
		SizeF sizeF_ = new SizeF((float)@class.method_4().method_0(), (float)@class.method_4().method_1());
		stream_0.Position = 0L;
		@class = Class465.smethod_0(new PointF(0f, 0f), sizeF_, stream_0);
		Class454 class2 = new Class454();
		if ((double)(@class.method_4().Width * @class.method_4().Height) < 0.0001)
		{
			return class2;
		}
		class2.Add(@class);
		MsoFormatPicture formatPicture = class1626_0.method_4().FormatPicture;
		double leftCrop = formatPicture.LeftCrop;
		double rightCrop = formatPicture.RightCrop;
		double topCrop = formatPicture.TopCrop;
		double bottomCrop = formatPicture.BottomCrop;
		float num = (float)((double)@class.Size.Width * leftCrop);
		float num2 = (float)((double)@class.Size.Height * topCrop);
		float num3 = (float)((double)@class.Size.Width * (1.0 - leftCrop - rightCrop));
		float num4 = (float)((double)@class.Size.Height * (1.0 - topCrop - bottomCrop));
		RectangleF rectangleF = new RectangleF(num - 0.5f, num2 - 0.5f, num3 + 1f, num4 + 1f);
		class2.vmethod_2(new Class458(rectangleF));
		class2.vmethod_1(new Matrix());
		float num5 = 1f;
		float num6 = 1f;
		num5 = rectangleF_0.Width / num3;
		num6 = rectangleF_0.Height / num4;
		class2.imethod_0().Translate((0f - num) * num5 + rectangleF_0.X, (0f - num2) * num6 + rectangleF_0.Y);
		class2.imethod_0().Scale(num5, num6);
		if (class1626_0.method_4().Hyperlink != null)
		{
			if (hashtable_1 != null && hashtable_1.ContainsKey(class1626_0.method_4().Hyperlink))
			{
				Cell value = (Cell)hashtable_1[class1626_0.method_4().Hyperlink];
				hashtable_4[class1626_0] = value;
				Class464 class3 = new Class464(new RectangleF(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height), "#shape_" + class1626_0.GetHashCode());
				hashtable_2[class1626_0] = class3;
				class1624_0.class454_1.Add(class3);
			}
			else
			{
				@class.method_5(new Class464(rectangleF, class1626_0.method_4().Hyperlink.Address));
			}
		}
		return class2;
	}

	private void method_20(Class1626 class1626_0, bool bool_1)
	{
		class1624_0.float_5 = (float)class1626_0.Left * (float)double_5[0];
		class1624_0.float_6 = (float)class1626_0.Top * (float)double_5[1];
		class1624_0.float_0 = (float)class1626_0.Height * (float)double_5[1];
		class1624_0.float_1 = (float)class1626_0.Width * (float)double_5[0];
		try
		{
			MemoryStream memoryStream = method_17(class1626_0);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			if (memoryStream.Length > 0 && class1624_0.float_0 * class1624_0.float_1 != 0f)
			{
				RectangleF rectangleF_ = new RectangleF(class1624_0.float_2 + class1624_0.float_5, class1624_0.float_3 + class1624_0.float_6, class1624_0.float_1, class1624_0.float_0);
				Class454 @class = null;
				@class = ((class1626_0.MsoDrawingType != MsoDrawingType.Chart) ? method_19(class1626_0, memoryStream, rectangleF_) : method_18(class1626_0, memoryStream, rectangleF_));
				if (!class1624_0.bool_2 && !bool_1)
				{
					@class.method_4(new Class461(new RectangleF(class1624_0.float_2 + class1624_0.float_5, class1624_0.float_3 + class1624_0.float_6, class1624_0.float_1, class1624_0.float_0)));
				}
				else
				{
					@class.method_4(null);
				}
				if (imageOrPrintOptions_0.DrawObjectEventHandler != null)
				{
					memoryStream.Seek(0L, SeekOrigin.Begin);
					imageOrPrintOptions_0.DrawObjectEventHandler.method_2(memoryStream, rectangleF_);
					memoryStream.Seek(0L, SeekOrigin.Begin);
				}
				class1624_0.method_28(@class);
			}
		}
		catch
		{
		}
	}

	private static int smethod_5(ArrayList arrayList_5, Class1620 class1620_0)
	{
		int num = -1;
		foreach (Class1623 item in arrayList_5)
		{
			num++;
			if (item.int_0 == class1620_0.Cell.method_4().method_3().SheetIndex && class1620_0.method_23() >= item.struct88_0.int_0 && class1620_0.method_23() <= item.struct88_0.int_2 && class1620_0.method_24() >= item.struct88_0.int_1 && class1620_0.method_24() <= item.struct88_0.int_3)
			{
				return num;
			}
		}
		return 0;
	}

	private void method_21(Class1620 class1620_0)
	{
		class1624_0.float_0 = (float)class1620_0.method_40(worksheet_0, class1620_0.method_23(), class1623_0.int_2, class1620_0.method_25()) * (float)double_5[1];
		class1624_0.int_5 = class1620_0.method_41(worksheet_0, class1620_0.method_23(), class1623_0.int_2, class1620_0.method_25());
		class1624_0.textAlignmentType_1 = class1620_0.method_15();
		class1624_0.textAlignmentType_0 = class1620_0.method_7().VerticalAlignment;
		class1624_0.bool_0 = worksheet_0.PageSetup.BlackAndWhite || (imageOrPrintOptions_0 != null && imageOrPrintOptions_0.bool_6);
		Style style = class1620_0.method_7();
		if (style == null)
		{
			return;
		}
		Color color_ = Class1625.smethod_23(style);
		if (class1620_0.Cell != null && hashtable_5 != null)
		{
			foreach (PdfBookmarkEntry key in hashtable_5.Keys)
			{
				if (key.Destination == class1620_0.Cell)
				{
					int index = smethod_5(arrayList_4, class1620_0);
					float num = (float)(class1623_0.double_7 / 2.5399999618530273 * 72.0);
					float num2 = (float)(class1623_0.double_8 / 2.5399999618530273 * 72.0);
					if (!key.method_1())
					{
						key.method_0(smethod_5(arrayList_4, class1620_0), new PointF(class1624_0.float_2 + num - ((Class1623)arrayList_4[index]).rectangleF_0.X, (float)double_7[1] - (class1624_0.float_3 + num2 - ((Class1623)arrayList_4[index]).rectangleF_0.Y)));
					}
				}
			}
		}
		if (class1620_0.Hyperlink != null)
		{
			if (hashtable_1 != null && hashtable_1.ContainsKey(class1620_0.Hyperlink))
			{
				Cell value = (Cell)hashtable_1[class1620_0.Hyperlink];
				if (class1620_0.Cell == null)
				{
					class1620_0.method_18(cells_0.GetCell(class1620_0.method_23(), class1620_0.method_24(), bool_2: false));
				}
				hashtable_4[class1620_0.Cell] = value;
				Class464 @class = new Class464(new RectangleF(class1624_0.float_2, class1624_0.float_3, class1624_0.float_1, class1624_0.float_0), "#" + class1620_0.Cell.method_4().method_3().Index + "_" + class1620_0.Cell.Row + "_" + class1620_0.Cell.Column);
				hashtable_2[class1620_0.Cell] = @class;
				class1624_0.class454_1.Add(@class);
			}
			else
			{
				switch (class1620_0.Hyperlink.method_5(workbook_0.Worksheets))
				{
				case 0:
					class1624_0.bool_1 = true;
					class1624_0.string_1 = class1620_0.Hyperlink.Address;
					break;
				case 1:
					class1624_0.bool_1 = true;
					class1624_0.string_1 = class1620_0.Hyperlink.Address;
					break;
				}
			}
		}
		class1624_0.color_0 = color_;
		if (style.RotationAngle != 255)
		{
			class1624_0.float_4 = style.RotationAngle;
		}
	}

	private void method_22(Worksheet worksheet_1)
	{
		class1624_0.class454_1 = new Class454();
		Chart chart = worksheet_0.Charts[0];
		PageSetup pageSetup = worksheet_0.Charts[0].PageSetup;
		class1624_0.cells_0 = worksheet_0.Cells;
		class1624_0.method_11();
		class1624_0.method_27();
		float num = 1f;
		class1624_0.arrayList_0 = null;
		class1624_0.float_5 = 0f;
		class1624_0.float_6 = 0f;
		class1624_0.double_0 = double_5;
		float num2 = (float)(chart.ChartObject.WidthPt * double_5[0]);
		float num3 = (float)(chart.ChartObject.HeightPt * double_5[1]);
		num = (float)Math.Min((double_7[0] - (pageSetup.LeftMarginInch + pageSetup.RightMarginInch) * 72.0) / (double)num2, (double_7[1] - (pageSetup.TopMarginInch + pageSetup.BottomMarginInch) * 72.0) / (double)num3);
		class1624_0.float_1 = num2 * num;
		class1624_0.float_0 = num3 * num;
		class1623_0.double_3 = double_7[0];
		class1623_0.double_4 = double_7[1];
		if (class1624_0.float_0 * class1624_0.float_1 != 0f)
		{
			MemoryStream memoryStream = new MemoryStream();
			chart.ToImage(memoryStream, class468_0.imageFormat_0);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			if (memoryStream.Length > 0)
			{
				class1624_0.method_29(memoryStream);
			}
		}
		class1624_0.method_30();
		class1624_0.method_12(0f, 0f);
	}

	public Class454 method_23()
	{
		cells_0 = worksheet_0.Cells;
		Class1623 @class = class1623_0;
		int_7 = @class.int_0;
		worksheet_0 = workbook_0.Worksheets[int_7];
		double_5 = @class.double_0;
		int_8 = @class.struct88_0.int_0;
		int_9 = @class.struct88_0.int_2;
		int_10 = @class.struct88_0.int_1;
		int_12 = @class.struct88_0.int_0;
		double_1 = @class.double_1;
		double_2 = @class.double_2;
		double_3 = @class.double_3;
		double_4 = @class.double_4;
		int_2 = @class.int_5;
		int_3 = @class.int_6;
		int_4 = @class.int_7;
		int_5 = @class.int_8;
		arrayList_3 = @class.arrayList_1;
		arrayList_2 = @class.arrayList_0;
		float num = 0f;
		float num2 = 0f;
		num = @class.rectangleF_0.Y;
		num2 = @class.rectangleF_0.X;
		if (worksheet_0.Type == SheetType.Chart)
		{
			try
			{
				method_22(worksheet_0);
				return class1624_0.class454_1;
			}
			catch
			{
			}
		}
		Struct88 struct88_ = new Struct88(int_8, int_10, int_9, @class.struct88_0.int_3);
		method_3(struct88_, num2, num);
		return class1624_0.class454_1;
	}

	public Class454 method_24()
	{
		cells_0 = worksheet_0.Cells;
		Class1623 @class = class1623_0;
		int_7 = @class.int_0;
		worksheet_0 = workbook_0.Worksheets[int_7];
		double_5 = @class.double_0;
		int_8 = @class.struct88_0.int_0;
		int_9 = @class.struct88_0.int_2;
		int_10 = Math.Min(@class.struct88_0.int_1, int_10);
		int_12 = Math.Min(@class.struct88_0.int_0, int_12);
		double_1 = @class.double_1;
		double_2 = @class.double_2;
		double_3 = @class.double_3;
		double_4 = @class.double_4;
		int_2 = @class.int_5;
		int_3 = @class.int_6;
		int_4 = @class.int_7;
		int_5 = @class.int_8;
		arrayList_3 = @class.arrayList_1;
		arrayList_2 = @class.arrayList_0;
		int_8 = @class.struct88_0.int_0;
		int_9 = @class.struct88_0.int_2;
		float num = 0f;
		float num2 = 0f;
		num = @class.rectangleF_0.Y;
		num2 = @class.rectangleF_0.X;
		if (worksheet_0.Type == SheetType.Chart)
		{
			try
			{
				method_22(worksheet_0);
				return class1624_0.class454_1;
			}
			catch
			{
			}
		}
		Struct88 struct88_ = new Struct88(int_8, @class.struct88_0.int_1, int_9, @class.struct88_0.int_3);
		method_3(struct88_, num2, num);
		return class1624_0.class454_1;
	}

	public Class454 method_25()
	{
		if (worksheet_0.PageSetup.PrintArea != null && worksheet_0.PageSetup.PrintArea.Length > 0)
		{
			return method_23();
		}
		return method_24();
	}

	public Class454 method_26()
	{
		class1624_0.class454_1 = new Class454();
		class1624_0.method_10();
		class1624_0.method_9();
		class1624_0.method_11();
		class1624_0.method_27();
		class1622_0 = new Class1622(workbook_0, class1624_0);
		class1622_0.Write(worksheet_0, int_0, int_1, class1623_0);
		class1624_0.method_13();
		class1624_0.method_14();
		class1624_0.method_30();
		return class1624_0.class454_1;
	}

	public Class454 method_27(ref RectangleF rectangleF_0)
	{
		float num = 0f;
		float num2 = 0f;
		Class454 @class = new Class454();
		class1624_0.class454_1 = @class;
		float_0 = 0f;
		float_1 = 0f;
		class1624_0.float_2 = 0f;
		class1624_0.float_3 = 0f;
		rectangleF_0.Width = 0f;
		rectangleF_0.Height = 0f;
		if (int_4 >= 0 && int_5 >= 0)
		{
			if (int_4 >= struct88_0.int_1)
			{
				return @class;
			}
			for (int i = int_4; i <= int_5; i++)
			{
				num += (float)(worksheet_0.Cells.GetColumnWidthInch(i) * 72.0 * double_5[0]);
			}
			for (int j = struct88_0.int_0; j <= struct88_0.int_2; j++)
			{
				num2 += (float)(worksheet_0.Cells.GetRowHeight(j) * double_5[1]);
			}
			for (int k = int_2; k <= int_3 && k >= 0; k++)
			{
				if (k < struct88_0.int_0 || k > struct88_0.int_2)
				{
					num2 += (float)(worksheet_0.Cells.GetRowHeightInch(k) * 72.0 * double_5[1]);
				}
			}
			class1624_0.int_0 = struct88_0.int_0;
			class1624_0.int_1 = Math.Min(struct88_0.int_1, int_4);
			class1624_0.int_2 = struct88_0.int_2;
			class1624_0.int_3 = Math.Max(struct88_0.int_3, int_5);
			class1624_0.cells_0 = worksheet_0.Cells;
			class1624_0.method_10();
			class1624_0.method_9();
			class1624_0.method_11();
			class1624_0.method_27();
			class1624_0.bool_2 = true;
			float_1 = (float_0 = 0f);
			class1624_0.double_0 = double_5;
			for (int l = int_2; l <= int_3 && l >= 0; l++)
			{
				if (l < struct88_0.int_0 || l > struct88_0.int_2)
				{
					double rowHeightInch = worksheet_0.Cells.GetRowHeightInch(l);
					method_6(l, struct88_0.int_0, int_4, struct88_0.int_2, int_5);
					class1624_0.float_3 += (float)(rowHeightInch * 72.0 * double_5[1]);
				}
			}
			for (int m = struct88_0.int_0; m <= struct88_0.int_2; m++)
			{
				double rowHeightInch = worksheet_0.Cells.GetRowHeightInch(m);
				method_6(m, struct88_0.int_0, int_4, struct88_0.int_2, int_5);
				class1624_0.float_3 += (float)(rowHeightInch * 72.0 * double_5[1]);
			}
			for (int n = int_4; n <= int_5; n++)
			{
				class468_0.arrayList_1.Add(n);
			}
			rectangleF_0.X = 0f;
			rectangleF_0.Y = 0f;
			rectangleF_0.Width = num;
			rectangleF_0.Height = num2;
			Struct88 struct88_ = new Struct88(class1624_0.int_0, class1624_0.int_1, class1624_0.int_2, class1624_0.int_3);
			method_5(struct88_, bool_1: true);
			class1624_0.method_13();
			class1624_0.method_14();
			class1624_0.method_12(0f, 0f);
			class1624_0.method_30();
			class1624_0.bool_2 = false;
			return @class;
		}
		return @class;
	}

	public Class454 method_28(ref RectangleF rectangleF_0)
	{
		float num = 0f;
		float num2 = 0f;
		Class454 @class = new Class454();
		class1624_0.class454_1 = @class;
		float_0 = 0f;
		float_1 = 0f;
		class1624_0.float_2 = 0f;
		class1624_0.float_3 = 0f;
		rectangleF_0.Width = 0f;
		rectangleF_0.Height = 0f;
		if (int_2 >= 0 && int_3 >= 0)
		{
			if (int_2 >= struct88_0.int_0)
			{
				return @class;
			}
			for (int i = struct88_0.int_1; i <= struct88_0.int_3; i++)
			{
				num += (float)(worksheet_0.Cells.GetColumnWidthInch(i) * 72.0 * double_5[0]);
			}
			for (int j = int_4; j <= int_5 && j >= 0; j++)
			{
				num += (float)(worksheet_0.Cells.GetColumnWidthInch(j) * 72.0 * double_5[0]);
			}
			for (int k = int_2; k <= int_3 && k >= 0; k++)
			{
				num2 += (float)(worksheet_0.Cells.GetRowHeightInch(k) * 72.0 * double_5[1]);
			}
			rectangleF_0.X = 0f;
			rectangleF_0.Y = 0f;
			rectangleF_0.Width = num;
			rectangleF_0.Height = num2;
			class1624_0.int_0 = Math.Min(int_2, struct88_0.int_0);
			class1624_0.int_1 = struct88_0.int_1;
			class1624_0.int_2 = Math.Max(int_3, struct88_0.int_2);
			class1624_0.int_3 = struct88_0.int_3;
			class1624_0.cells_0 = worksheet_0.Cells;
			class1624_0.method_10();
			class1624_0.method_9();
			class1624_0.method_11();
			class1624_0.method_27();
			float_1 = 0f;
			float_0 = 0f;
			class1624_0.double_0 = double_5;
			class1624_0.bool_2 = true;
			for (int l = int_2; l <= int_3; l++)
			{
				double rowHeightInch = worksheet_0.Cells.GetRowHeightInch(l);
				class468_0.arrayList_2.Add(l);
				method_6(l, int_2, struct88_0.int_1, int_3, struct88_0.int_3);
				class1624_0.float_3 += (float)(rowHeightInch * 72.0 * double_5[1]);
			}
			rectangleF_0.Width = num;
			rectangleF_0.Height = num2;
			Struct88 struct88_ = new Struct88(class1624_0.int_0, class1624_0.int_1, class1624_0.int_2, class1624_0.int_3);
			method_5(struct88_, bool_1: true);
			class1624_0.method_13();
			class1624_0.method_14();
			class1624_0.method_12(0f, 0f);
			class1624_0.method_30();
			class1624_0.bool_2 = false;
			return @class;
		}
		return @class;
	}

	public Class461 method_29()
	{
		return new Class461(class1623_0.rectangleF_0);
	}
}
