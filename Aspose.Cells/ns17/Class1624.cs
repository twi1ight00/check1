using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using Aspose.Cells;
using ns16;
using ns18;
using ns19;
using ns44;

namespace ns17;

internal class Class1624
{
	private static Class454 class454_0 = new Class454();

	private Class1243 class1243_0;

	public Class454 class454_1;

	public Class456 class456_0;

	public int int_0;

	public int int_1;

	public int int_2;

	public int int_3;

	public float float_0;

	public float float_1;

	public float float_2;

	public float float_3;

	public int int_4;

	public int int_5;

	public Color color_0;

	public bool bool_0;

	public ArrayList arrayList_0;

	public TextAlignmentType textAlignmentType_0;

	public TextAlignmentType textAlignmentType_1;

	public float float_4;

	public Class454 class454_2;

	public Class468 class468_0;

	public string string_0;

	public RectangleF rectangleF_0;

	public float float_5;

	public float float_6;

	private Class451 class451_0;

	public Cells cells_0;

	public bool bool_1;

	public string string_1;

	public Class454 class454_3;

	public Class454 class454_4;

	public Class1620 class1620_0;

	public ArrayList arrayList_1;

	public double[] double_0;

	public Class454 class454_5;

	public Class454 class454_6;

	public Class454 class454_7;

	public float float_7;

	public bool bool_2;

	public Hashtable hashtable_0 = new Hashtable();

	private bool bool_3;

	private Class1398 class1398_0;

	private static string[] string_2 = new string[3] { "ColorScaledStyle", "DataBarStyle", "IconSetStyle" };

	public Class1624(Class1243 class1243_1)
	{
		class1243_0 = class1243_1;
	}

	private void method_0()
	{
		string_0 = null;
		float_7 = 1f;
	}

	public void method_1()
	{
		method_26();
		method_0();
	}

	internal void method_2(float float_8, float float_9)
	{
		float_3 = float_9;
		float_2 = float_8;
		int num = 0;
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		arrayList.Add(1f * (float)double_0[0]);
		arrayList2.Add(0.6f * (float)double_0[0]);
		arrayList.Add(Color.Black);
		arrayList2.Add(Color.Black);
		arrayList.Add(CellBorderType.Thick);
		arrayList2.Add(CellBorderType.Dashed);
		float num2 = float_8;
		float num3 = float_9;
		for (int i = int_0; i <= int_2; i++)
		{
			float num4 = (float)double_0[1] * (float)cells_0.GetRowHeight(i);
			if (num4 == 0f)
			{
				continue;
			}
			num2 = float_8;
			for (int j = int_1; j <= int_3; j++)
			{
				float num5 = (float)double_0[0] * (float)cells_0.GetColumnWidthInch(j) * 72f;
				if (num5 != 0f)
				{
					num = (i << 11) + (j << 1) + 1;
					if (j == int_1)
					{
						method_19(class454_2, 0, arrayList, i, j, num2, num3, num5, num4, bool_4: true);
					}
					else if (!hashtable_0.Contains(num))
					{
						method_19(class454_2, 0, arrayList2, i, j, num2, num3, num5, num4, bool_4: true);
					}
					num = (i << 11) + (j << 1);
					if (i == int_0)
					{
						method_19(class454_2, 1, arrayList, i, j, num2, num3, num5, num4, bool_4: true);
					}
					else if (!hashtable_0.Contains(num))
					{
						method_19(class454_2, 1, arrayList2, i, j, num2, num3, num5, num4, bool_4: true);
					}
					num = (i << 11) + (j + 1 << 1) + 1;
					if (j == int_3)
					{
						method_19(class454_2, 2, arrayList, i, j, num2, num3, num5, num4, bool_4: true);
					}
					else if (!hashtable_0.Contains(num))
					{
						method_19(class454_2, 2, arrayList2, i, j, num2, num3, num5, num4, bool_4: true);
					}
					num = (i + 1 << 11) + (j << 1);
					if (i == int_2)
					{
						method_19(class454_2, 3, arrayList, i, j, num2, num3, num5, num4, bool_4: true);
					}
					else if (!hashtable_0.Contains(num))
					{
						method_19(class454_2, 3, arrayList2, i, j, num2, num3, num5, num4, bool_4: true);
					}
					num2 += num5;
				}
			}
			num3 += num4;
		}
	}

	internal void method_3(RectangleF rectangleF_1)
	{
		Color color = Color.FromArgb(255, class1620_0.method_7().ForegroundColor);
		Color color_ = Color.FromArgb(255, class1620_0.method_7().BackgroundColor);
		if (class1620_0.method_7().BackgroundInternalColor.method_2())
		{
			color_ = Color.White;
		}
		ArrayList arrayList = Class1200.smethod_0(color, color_, rectangleF_1, class1620_0.method_7().method_51(), class1620_0.method_7().method_53());
		Class454 @class = new Class454();
		if (float_4 != 0f && bool_3)
		{
			foreach (Class458 item in arrayList)
			{
				@class.Add(item);
			}
			class454_7.Add(method_5(@class, float_2, float_3 + float_0));
			return;
		}
		if (bool_2)
		{
			@class.method_4(null);
		}
		else
		{
			@class.method_4(new Class461(rectangleF_1));
		}
		@class.vmethod_2(new Class458(rectangleF_1));
		foreach (Class458 item2 in arrayList)
		{
			@class.Add(item2);
		}
		class454_6.Add(@class);
	}

	private SolidBrush method_4(Color color_1)
	{
		lock (class1243_0.hashtable_7)
		{
			SolidBrush solidBrush = (SolidBrush)class1243_0.hashtable_7[color_1.ToArgb()];
			if (solidBrush == null)
			{
				solidBrush = new SolidBrush(color_1);
				class1243_0.hashtable_7[color_1.ToArgb()] = solidBrush;
			}
			return solidBrush;
		}
	}

	internal Class454 method_5(Class454 class454_8, float float_8, float float_9)
	{
		if (class454_8.imethod_0() == null)
		{
			class454_8.vmethod_1(new Matrix());
		}
		float num = (float)((double)(0f - float_4) * (Math.PI / 180.0));
		float num2 = (float)(1.0 / Math.Tan(num));
		class454_8.imethod_0().Shear(num2, 0f);
		Class454 @class = new Class454();
		@class.vmethod_1(new Matrix(1f, 0f, 0f, 1f, (0f - num2) * float_9, 0f));
		@class.Add(class454_8);
		return @class;
	}

	internal void method_6(RectangleF rectangleF_1)
	{
		Class458 @class = null;
		Color color = Color.FromArgb(255, color_0);
		if ((color.R == byte.MaxValue && color.G == byte.MaxValue && color.B == byte.MaxValue) || color_0.IsEmpty)
		{
			return;
		}
		@class = Class458.smethod_2(new RectangleF(float_2, float_3, float_1 + 0.15f, float_0 + 0.15f));
		color = Color.FromArgb(255, color_0);
		@class.method_3(method_4(color));
		Class454 class2 = new Class454();
		class2.Add(@class);
		if (float_4 != 0f && bool_3)
		{
			class454_7.Add(method_5(class2, float_2, float_3 + float_0));
			return;
		}
		if (bool_2)
		{
			class2.method_4(null);
		}
		else
		{
			class2.method_4(new Class461(rectangleF_1));
		}
		class454_6.Add(class2);
	}

	internal void method_7(RectangleF rectangleF_1)
	{
		Class458 @class = Class458.smethod_2(rectangleF_1);
		_ = Color.White;
		HatchStyle hatchstyle = Class1625.smethod_0(class1620_0.method_7().Pattern);
		Color foreColor = Color.FromArgb(255, class1620_0.method_7().ForegroundColor);
		Color backColor = Color.FromArgb(255, class1620_0.method_7().BackgroundColor);
		if (class1620_0.method_7().BackgroundInternalColor.method_2())
		{
			backColor = Color.White;
		}
		Brush brush_ = new HatchBrush(hatchstyle, foreColor, backColor);
		@class.method_3(brush_);
		Class454 class2 = new Class454();
		class2.Add(@class);
		if (float_4 != 0f && bool_3)
		{
			class454_7.Add(method_5(class2, float_2, float_3 + float_0));
			return;
		}
		if (bool_2)
		{
			class2.method_4(null);
		}
		else
		{
			class2.method_4(new Class461(rectangleF_1));
		}
		class454_6.Add(class2);
	}

	internal void method_8()
	{
		if (!bool_0)
		{
			RectangleF rectangleF_ = new RectangleF(float_2 + 0.3f, float_3 + 0.3f, float_1 - 0.6f, float_0 - 0.6f);
			if (class1620_0.method_7().IsGradient)
			{
				method_3(rectangleF_);
			}
			else if (class1620_0.method_7().Pattern != 0 && class1620_0.method_7().Pattern != BackgroundType.Solid)
			{
				method_7(rectangleF_);
			}
			else
			{
				method_6(rectangleF_);
			}
		}
	}

	internal void method_9()
	{
		class454_5 = new Class454();
	}

	internal void method_10()
	{
		class454_6 = new Class454();
	}

	internal void method_11()
	{
		class454_2 = new Class454();
		class454_7 = new Class454();
		hashtable_0 = new Hashtable();
	}

	internal void method_12(float float_8, float float_9)
	{
		if (cells_0.PageSetup.PrintGridlines)
		{
			method_2(float_8, float_9);
		}
		class454_2.Add(class454_7);
		foreach (object key in hashtable_0.Keys)
		{
			Class452 @class = (Class452)hashtable_0[key];
			if (@class != null && @class != class454_0)
			{
				class454_2.Add(@class);
			}
		}
		bool_3 = false;
		class454_1.Add(class454_2);
		hashtable_0.Clear();
	}

	internal void method_13()
	{
		class454_1.Add(class454_6);
	}

	internal void method_14()
	{
		class454_1.Add(class454_5);
	}

	internal void method_15()
	{
		new Class467();
		if ((class1620_0.border_2 != null && class1620_0.border_2.LineStyle != 0) || (class1620_0.border_3 != null && class1620_0.border_3.LineStyle != 0))
		{
			method_18(class1620_0.method_7().Borders);
			method_20(arrayList_0, class1620_0.method_23(), class1620_0.method_24(), float_2, float_3, float_1, float_0);
		}
		int num;
		if (class1620_0.int_6 < 0)
		{
			num = class1620_0.method_24() - (class1620_0.method_27() - 1);
			if (num < 0)
			{
				num = 0;
			}
		}
		else
		{
			num = class1620_0.method_24();
		}
		BorderCollection borderCollection = new BorderCollection(new Style(cells_0.method_19()));
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		float num5 = float_3;
		for (int i = class1620_0.method_23(); i < class1620_0.method_23() + class1620_0.method_25() + num3; i++)
		{
			float num6 = (float)(cells_0.GetRowHeightInch(i) * double_0[1] * 72.0);
			if (num6 == 0f)
			{
				num3++;
			}
			float num7 = float_2;
			for (int j = num; j < num + class1620_0.method_27() + num2 && j <= 16383; j++)
			{
				float num8 = (float)(cells_0.GetColumnWidthInch(j) * double_0[0] * 72.0);
				if (num8 == 0f)
				{
					num2++;
				}
				Style cellStyle = cells_0.GetCellStyle(i, j);
				borderCollection = new BorderCollection(new Style(cells_0.method_19()));
				if (cellStyle != null)
				{
					borderCollection.Copy(cellStyle.Borders);
				}
				if (class1620_0.method_7() != null && class1620_0.method_7().Borders != null && ((class1620_0.method_27() == 1 && class1620_0.method_25() == 1) || class1620_0.IsMerged))
				{
					if (class1620_0.method_7().Borders[BorderType.LeftBorder].LineStyle != 0)
					{
						borderCollection[BorderType.LeftBorder].LineStyle = class1620_0.method_7().Borders[BorderType.LeftBorder].LineStyle;
						borderCollection[BorderType.LeftBorder].Color = class1620_0.method_7().Borders[BorderType.LeftBorder].Color;
					}
					if (class1620_0.method_7().Borders[BorderType.TopBorder].LineStyle != 0)
					{
						borderCollection[BorderType.TopBorder].LineStyle = class1620_0.method_7().Borders[BorderType.TopBorder].LineStyle;
						borderCollection[BorderType.TopBorder].Color = class1620_0.method_7().Borders[BorderType.TopBorder].Color;
					}
					if (class1620_0.method_7().Borders[BorderType.RightBorder].LineStyle != 0)
					{
						borderCollection[BorderType.RightBorder].LineStyle = class1620_0.method_7().Borders[BorderType.RightBorder].LineStyle;
						borderCollection[BorderType.RightBorder].Color = class1620_0.method_7().Borders[BorderType.RightBorder].Color;
					}
					if (class1620_0.method_7().Borders[BorderType.BottomBorder].LineStyle != 0)
					{
						borderCollection[BorderType.BottomBorder].LineStyle = class1620_0.method_7().Borders[BorderType.BottomBorder].LineStyle;
						borderCollection[BorderType.BottomBorder].Color = class1620_0.method_7().Borders[BorderType.BottomBorder].Color;
					}
				}
				if (class1620_0.method_27() > 1)
				{
					if (j != num)
					{
						num4 = (i << 11) + (j << 1) + 1;
						if (!hashtable_0.Contains(num4))
						{
							hashtable_0[num4] = class454_0;
						}
						borderCollection[BorderType.LeftBorder].LineStyle = CellBorderType.None;
					}
					if (j != num + class1620_0.method_27() - 1 + num2)
					{
						num4 = (i << 11) + (j + 1 << 1) + 1;
						if (!hashtable_0.Contains(num4))
						{
							hashtable_0[num4] = class454_0;
						}
						borderCollection[BorderType.RightBorder].LineStyle = CellBorderType.None;
					}
				}
				if (class1620_0.method_25() > 1)
				{
					if (i != class1620_0.method_23())
					{
						num4 = (i << 11) + (j << 1);
						if (!hashtable_0.Contains(num4))
						{
							hashtable_0[num4] = class454_0;
						}
						borderCollection[BorderType.TopBorder].LineStyle = CellBorderType.None;
					}
					if (i != class1620_0.method_23() + class1620_0.method_25() - 1 + num3)
					{
						num4 = (i + 1 << 11) + (j << 1);
						if (!hashtable_0.Contains(num4))
						{
							hashtable_0[num4] = class454_0;
						}
						borderCollection[BorderType.BottomBorder].LineStyle = CellBorderType.None;
					}
				}
				method_17(borderCollection);
				method_20(arrayList_0, i, j, num7, num5, num8, num6);
				num7 += num8;
			}
			num5 += num6;
			if (class1620_0.method_25() == 1)
			{
				break;
			}
		}
	}

	private void method_16(Border border_0, int int_6)
	{
		float num = 1f;
		switch (border_0.LineStyle)
		{
		case CellBorderType.Thin:
			num *= 0.5f;
			break;
		case CellBorderType.Dashed:
			num *= 0.5f;
			break;
		case CellBorderType.Dotted:
			num *= 0.5f;
			break;
		case CellBorderType.Thick:
			num *= 2f;
			break;
		case CellBorderType.Double:
			num *= 0.667f;
			break;
		case CellBorderType.Hair:
			num *= 0.5f;
			break;
		case CellBorderType.DashDot:
			num *= 0.5f;
			break;
		case CellBorderType.DashDotDot:
			num *= 0.5f;
			break;
		}
		ArrayList arrayList = new ArrayList(3);
		arrayList.Add((float)((double)num * double_0[0]));
		Color color = Color.FromArgb(255, border_0.Color);
		arrayList.Add(color);
		arrayList.Add(border_0.LineStyle);
		arrayList_0[int_6] = arrayList;
	}

	private ArrayList method_17(BorderCollection borderCollection_0)
	{
		arrayList_0 = new ArrayList(6);
		for (int i = 0; i < 6; i++)
		{
			arrayList_0.Add(null);
		}
		if (borderCollection_0[BorderType.TopBorder].LineStyle != 0)
		{
			bool_3 = true;
			method_16(borderCollection_0[BorderType.TopBorder], 1);
		}
		if (borderCollection_0[BorderType.BottomBorder].LineStyle != 0)
		{
			bool_3 = true;
			method_16(borderCollection_0[BorderType.BottomBorder], 3);
		}
		if (borderCollection_0[BorderType.LeftBorder].LineStyle != 0)
		{
			bool_3 = true;
			method_16(borderCollection_0[BorderType.LeftBorder], 0);
		}
		if (borderCollection_0[BorderType.RightBorder].LineStyle != 0)
		{
			bool_3 = true;
			method_16(borderCollection_0[BorderType.RightBorder], 2);
		}
		return arrayList_0;
	}

	private ArrayList method_18(BorderCollection borderCollection_0)
	{
		arrayList_0 = new ArrayList(6);
		for (int i = 0; i < 6; i++)
		{
			arrayList_0.Add(null);
		}
		if (borderCollection_0[BorderType.DiagonalUp].LineStyle != 0)
		{
			bool_3 = true;
			method_16(borderCollection_0[BorderType.DiagonalUp], 4);
		}
		if (borderCollection_0[BorderType.DiagonalDown].LineStyle != 0)
		{
			bool_3 = true;
			method_16(borderCollection_0[BorderType.DiagonalDown], 5);
		}
		return arrayList_0;
	}

	private void method_19(Class454 class454_8, int int_6, ArrayList arrayList_2, int int_7, int int_8, float float_8, float float_9, float float_10, float float_11, bool bool_4)
	{
		if (arrayList_2 == null)
		{
			return;
		}
		Color color_ = (Color)arrayList_2[1];
		float num = (float)arrayList_2[0];
		if (bool_0)
		{
			color_ = Color.Black;
		}
		Class770 @class = new Class770(color_, num);
		@class.float_2 = 1f;
		float num2 = num * 5f;
		float num3 = num * 2f;
		float num4 = num * 2f;
		switch ((CellBorderType)arrayList_2[2])
		{
		case CellBorderType.Dashed:
			@class.dashStyle_0 = DashStyle.Custom;
			@class.method_1(new float[2] { num2, num4 });
			@class.float_3 = float_8 % (num2 + num4);
			@class.method_2(LineCap.Square, LineCap.Square, DashCap.Flat);
			break;
		case CellBorderType.Dotted:
			@class.dashStyle_0 = DashStyle.Solid;
			@class.dashStyle_0 = DashStyle.Custom;
			@class.method_1(new float[2] { num3, num4 });
			@class.float_3 = float_8 % (num2 + num4);
			break;
		case CellBorderType.Thin:
		case CellBorderType.Medium:
		case CellBorderType.Thick:
			@class.dashStyle_0 = DashStyle.Solid;
			@class.method_2(LineCap.Flat, LineCap.Flat, DashCap.Flat);
			break;
		case CellBorderType.Double:
			@class.dashStyle_0 = DashStyle.Solid;
			@class.method_2(LineCap.Flat, LineCap.Flat, DashCap.Flat);
			break;
		case CellBorderType.Hair:
			@class.dashStyle_0 = DashStyle.Custom;
			@class.method_1(new float[2] { num3, num4 });
			@class.float_3 = float_8 % (num3 + num4);
			break;
		case CellBorderType.MediumDashed:
			@class.dashStyle_0 = DashStyle.Custom;
			@class.method_1(new float[2] { num2, num4 });
			@class.float_3 = float_8 % (num2 + num4);
			@class.method_2(LineCap.Square, LineCap.Square, DashCap.Flat);
			break;
		case CellBorderType.DashDot:
			@class.dashStyle_0 = DashStyle.Custom;
			@class.method_1(new float[4] { num2, num4, num3, num4 });
			break;
		case CellBorderType.MediumDashDot:
			@class.dashStyle_0 = DashStyle.Custom;
			@class.method_1(new float[4] { num2, num4, num3, num4 });
			@class.float_3 = float_8 % (num2 + num4 + num3 + num4);
			@class.method_2(LineCap.Square, LineCap.Square, DashCap.Flat);
			break;
		case CellBorderType.DashDotDot:
			@class.dashStyle_0 = DashStyle.Custom;
			@class.method_1(new float[6] { num2, num4, num3, num4, num3, num4 });
			@class.float_3 = float_8 % (num2 + num4 + num3 + num4 + num3 + num4);
			break;
		case CellBorderType.MediumDashDotDot:
			@class.dashStyle_0 = DashStyle.Custom;
			@class.method_1(new float[6] { num2, num4, num3, num4, num3, num4 });
			@class.float_3 = float_8 % (num2 + num4 + num3 + num4 + num3 + num4);
			@class.method_2(LineCap.Square, LineCap.Square, DashCap.Flat);
			break;
		case CellBorderType.SlantedDashDot:
			@class.dashStyle_0 = DashStyle.Custom;
			@class.method_1(new float[4] { num2, num4, num3, num4 });
			@class.float_3 = float_8 % (num2 + num4 + num3 + num4);
			@class.method_2(LineCap.Square, LineCap.Square, DashCap.Flat);
			break;
		}
		float num5 = num;
		int num6 = 0;
		float num15;
		float num14;
		float num13;
		float num12;
		float num11;
		if ((CellBorderType)arrayList_2[2] == CellBorderType.Double)
		{
			float num9;
			float num7;
			float num10;
			float num8;
			num15 = (num14 = (num13 = (num12 = (num11 = (num10 = (num9 = (num8 = (num7 = 0f))))))));
			Class458 class2 = new Class458();
			Class458 class3 = new Class458();
			Class458 class4 = new Class458();
			Class454 class5 = new Class454();
			num5 = num;
			switch (int_6)
			{
			case 0:
			{
				num6 = (int_7 << 11) + (int_8 << 1) + 1;
				if (bool_4)
				{
					hashtable_0[num6] = class454_0;
				}
				else if (!hashtable_0.Contains(num6))
				{
					hashtable_0[num6] = class5;
				}
				num14 = Class1240.smethod_2(cells_0, int_7, int_8, int_7, int_8 - 1, BorderType.TopBorder) * (float)double_0[1];
				num11 = Class1240.smethod_2(cells_0, int_7, int_8, int_7, int_8 - 1, BorderType.BottomBorder) * (float)double_0[1];
				float num18 = Class1240.smethod_3(cells_0, int_7, int_8, int_7, int_8 - 1, BorderType.TopBorder) * (float)double_0[1];
				num15 = Class1240.smethod_3(cells_0, int_7, int_8, int_7, int_8 - 1, BorderType.BottomBorder) * (float)double_0[1];
				num9 = Class1240.smethod_0(cells_0, int_7, int_8, int_7, int_8 - 1, BorderType.TopBorder, int_7 - 1, int_8, BorderType.LeftBorder) * (float)double_0[1];
				num7 = Class1240.smethod_0(cells_0, int_7, int_8, int_7, int_8 - 1, BorderType.BottomBorder, int_7 + class1620_0.method_25(), int_8, BorderType.LeftBorder) * (float)double_0[1];
				class2 = Class458.smethod_3(new PointF(float_8 - num5, float_9 + num18), new PointF(float_8 - num5, float_9 + float_11 - num15));
				class3 = Class458.smethod_3(new PointF(float_8 + num5, float_9 + num14), new PointF(float_8 + num5, float_9 + float_11 - num11));
				class4 = Class458.smethod_3(new PointF(float_8, float_9 + num9), new PointF(float_8, float_9 + float_11 - num7));
				break;
			}
			case 1:
			{
				num6 = (int_7 << 11) + (int_8 << 1);
				if (bool_4)
				{
					hashtable_0[num6] = class454_0;
				}
				else if (!hashtable_0.Contains(num6))
				{
					hashtable_0[num6] = class5;
				}
				num14 = Class1240.smethod_2(cells_0, int_7, int_8, int_7 - 1, int_8, BorderType.LeftBorder) * (float)double_0[0];
				num11 = Class1240.smethod_2(cells_0, int_7, int_8, int_7 - 1, int_8, BorderType.RightBorder) * (float)double_0[0];
				float num18 = Class1240.smethod_3(cells_0, int_7, int_8, int_7 - 1, int_8, BorderType.LeftBorder) * (float)double_0[0];
				num15 = Class1240.smethod_3(cells_0, int_7, int_8, int_7 - 1, int_8, BorderType.RightBorder) * (float)double_0[0];
				num10 = Class1240.smethod_0(cells_0, int_7, int_8, int_7 - 1, int_8, BorderType.LeftBorder, int_7, int_8 - 1, BorderType.TopBorder) * (float)double_0[0];
				num8 = Class1240.smethod_0(cells_0, int_7, int_8, int_7 - 1, int_8, BorderType.RightBorder, int_7, int_8 + class1620_0.method_27(), BorderType.TopBorder) * (float)double_0[0];
				class2 = Class458.smethod_3(new PointF(float_8 + num14, float_9 + num5), new PointF(float_8 + float_10 - num11, float_9 + num5));
				class3 = Class458.smethod_3(new PointF(float_8 + num18, float_9 - num5), new PointF(float_8 + float_10 - num15, float_9 - num5));
				class4 = Class458.smethod_3(new PointF(float_8 + num10, float_9), new PointF(float_8 + float_10 - num8, float_9));
				break;
			}
			case 2:
			{
				num6 = (int_7 << 11) + (int_8 + 1 << 1) + 1;
				if (bool_4)
				{
					hashtable_0[num6] = class454_0;
				}
				else if (!hashtable_0.Contains(num6))
				{
					hashtable_0[num6] = class5;
				}
				int num16 = ((class1620_0.method_27() == 1) ? int_8 : (int_8 + class1620_0.method_27() - 1));
				int num17 = ((class1620_0.method_25() == 1) ? int_7 : (int_7 + class1620_0.method_25() - 1));
				num14 = Class1240.smethod_2(cells_0, num17, num16, num17, num16 + 1, BorderType.TopBorder) * (float)double_0[1];
				num11 = Class1240.smethod_2(cells_0, num17, num16, num17, num16 + 1, BorderType.BottomBorder) * (float)double_0[1];
				float num18 = Class1240.smethod_3(cells_0, num17, num16, num17, num16 + 1, BorderType.TopBorder) * (float)double_0[1];
				num15 = Class1240.smethod_3(cells_0, num17, num16, num17, num16 + 1, BorderType.BottomBorder) * (float)double_0[1];
				num9 = Class1240.smethod_0(cells_0, num17, num16, num17, num16 + 1, BorderType.TopBorder, num17 - 1, num16, BorderType.RightBorder) * (float)double_0[1];
				num7 = Class1240.smethod_0(cells_0, num17, num16, num17, num16 + 1, BorderType.BottomBorder, num17 + 1, num16, BorderType.RightBorder) * (float)double_0[1];
				class2 = Class458.smethod_3(new PointF(float_8 - num5 + float_10, float_9 + num18), new PointF(float_8 - num5 + float_10, float_9 + float_11 - num15));
				class3 = Class458.smethod_3(new PointF(float_8 + num5 + float_10, float_9 + num14), new PointF(float_8 + num5 + float_10, float_9 + float_11 - num11));
				class4 = Class458.smethod_3(new PointF(float_8 + float_10, float_9 + num9), new PointF(float_8 + float_10, float_9 + float_11 - num7));
				break;
			}
			case 3:
			{
				num6 = (int_7 + 1 << 11) + (int_8 << 1);
				if (bool_4)
				{
					hashtable_0[num6] = class454_0;
				}
				else if (!hashtable_0.Contains(num6))
				{
					hashtable_0[num6] = class5;
				}
				int num16 = ((class1620_0.method_27() == 1) ? int_8 : (int_8 + class1620_0.method_27() - 1));
				int num17 = ((class1620_0.method_25() == 1) ? int_7 : (int_7 + class1620_0.method_25() - 1));
				num14 = Class1240.smethod_2(cells_0, num17, num16, num17 + 1, num16, BorderType.LeftBorder) * (float)double_0[0];
				num11 = Class1240.smethod_2(cells_0, num17, num16, num17 + 1, num16, BorderType.RightBorder) * (float)double_0[0];
				float num18 = Class1240.smethod_3(cells_0, num17, num16, num17 + 1, num16, BorderType.LeftBorder) * (float)double_0[0];
				num15 = Class1240.smethod_3(cells_0, num17, num16, num17 + 1, num16, BorderType.RightBorder) * (float)double_0[0];
				num10 = Class1240.smethod_0(cells_0, num17, num16, num17 + 1, num16, BorderType.LeftBorder, num17, num16 - 1, BorderType.BottomBorder) * (float)double_0[0];
				num8 = Class1240.smethod_0(cells_0, num17, num16, num17 + 1, num16, BorderType.RightBorder, num17, num16 + class1620_0.method_27(), BorderType.BottomBorder) * (float)double_0[0];
				class2 = Class458.smethod_3(new PointF(float_8 + num14, float_9 + float_11 - num5), new PointF(float_8 + float_10 - num11, float_9 + float_11 - num5));
				class3 = Class458.smethod_3(new PointF(float_8 + num18, float_9 + float_11 + num5), new PointF(float_8 + float_10 - num15, float_9 + float_11 + num5));
				class4 = Class458.smethod_3(new PointF(float_8 + num10, float_9 + float_11), new PointF(float_8 + float_10 - num8, float_9 + float_11));
				break;
			}
			}
			class2.class770_0 = @class;
			class3.class770_0 = @class;
			Class770 class6 = new Class770(Color.White, num);
			class6.method_2(LineCap.Flat, LineCap.Flat, DashCap.Flat);
			class4.class770_0 = class6;
			class5.Add(class2);
			class5.Add(class3);
			class5.Add(class4);
			if (bool_4)
			{
				class454_8.Add(class5);
			}
			return;
		}
		Class460 class7 = null;
		num15 = (num14 = (num13 = (num12 = (num11 = 0f))));
		switch (int_6)
		{
		case 0:
			num6 = (int_7 << 11) + (int_8 << 1) + 1;
			class7 = new Class460(new PointF((float)Math.Round(float_8, 3), float_9 + num14), new PointF((float)Math.Round(float_8, 3), float_9 + float_11 - num11));
			if (bool_4)
			{
				hashtable_0[num6] = class454_0;
			}
			else if (!hashtable_0.Contains(num6) || cells_0.method_3().DisplayRightToLeft)
			{
				hashtable_0[num6] = class7;
			}
			break;
		case 1:
			num6 = (int_7 << 11) + (int_8 << 1);
			class7 = new Class460(new PointF(float_8 + num13, (float)Math.Round(float_9, 3)), new PointF(float_8 + float_10 - num12, (float)Math.Round(float_9, 3)));
			if (bool_4)
			{
				hashtable_0[num6] = class454_0;
			}
			else if (!hashtable_0.Contains(num6))
			{
				hashtable_0[num6] = class7;
			}
			break;
		case 2:
			num6 = (int_7 << 11) + (int_8 + 1 << 1) + 1;
			class7 = new Class460(new PointF((float)Math.Round(float_8 + float_10, 3), float_9 + num14), new PointF((float)Math.Round(float_8 + float_10, 3), float_9 + float_11 - num11));
			if (bool_4)
			{
				hashtable_0[num6] = class454_0;
			}
			else if (!hashtable_0.Contains(num6))
			{
				hashtable_0[num6] = class7;
			}
			break;
		case 3:
			num6 = (int_7 + 1 << 11) + (int_8 << 1);
			class7 = new Class460(new PointF(float_8 + num13, (float)Math.Round(float_9 + float_11, 3)), new PointF(float_8 + float_10 - num12, (float)Math.Round(float_9 + float_11, 3)));
			if (bool_4)
			{
				hashtable_0[num6] = class454_0;
			}
			else if (!hashtable_0.Contains(num6))
			{
				hashtable_0[num6] = class7;
			}
			break;
		case 4:
			num6 = -((int_7 + 1 << 11) + (int_8 << 1));
			class7 = new Class460(new PointF(float_8, float_9 + float_11), new PointF(float_8 + float_10, float_9));
			if (bool_4)
			{
				hashtable_0[num6] = class454_0;
			}
			else
			{
				hashtable_0[num6] = class7;
			}
			break;
		case 5:
			num6 = -((int_7 + 1 << 11) + (int_8 << 1) + 1);
			class7 = new Class460(new PointF(float_8, float_9), new PointF(float_8 + float_10, float_9 + float_11));
			if (bool_4)
			{
				hashtable_0[num6] = class454_0;
			}
			else
			{
				hashtable_0[num6] = class7;
			}
			break;
		}
		if (class7 != null)
		{
			class7.class770_0 = @class;
			if (bool_4)
			{
				class454_8.Add(class7);
			}
		}
	}

	private void method_20(ArrayList arrayList_2, int int_6, int int_7, float float_8, float float_9, float float_10, float float_11)
	{
		int num = -1;
		if (arrayList_2 == null)
		{
			return;
		}
		if (float_4 != 0f && float_4 != 90f && float_4 != -90f && class1620_0.method_36() != null && class1620_0.method_36().Count != 0)
		{
			Class454 @class = new Class454();
			float num2 = (float)((double)(0f - float_4) * (Math.PI / 180.0));
			float shearX = (float)(1.0 / Math.Tan(num2));
			@class.vmethod_1(new Matrix());
			@class.imethod_0().Shear(shearX, 0f);
			foreach (ArrayList item in arrayList_2)
			{
				num++;
				method_19(@class, num, item, int_6, int_7, 0f, 0f, float_10, float_11, bool_4: true);
			}
			Class454 class2 = new Class454();
			class2.Add(@class);
			class2.vmethod_1(new Matrix(1f, 0f, 0f, 1f, float_8 + float_11 / (float)Math.Tan((double)(float_4 / 180f) * Math.PI), float_9));
			class454_7.Add(class2);
			return;
		}
		foreach (ArrayList item2 in arrayList_2)
		{
			num++;
			method_19(class454_2, num, item2, int_6, int_7, float_8, float_9, float_10, float_11, bool_4: false);
		}
	}

	private void method_21()
	{
		float num = 0f;
		float num2 = 0f;
		float x = 0f;
		float num3 = 0f;
		float_7 = 1f;
		num = class451_0.float_3;
		num2 = class451_0.float_2;
		if (class1620_0.method_7().ShrinkToFit && (num2 > float_1 || num > float_0))
		{
			float_7 = method_22(float_1, float_0, num2, num);
			num2 *= float_7;
			num *= float_7;
		}
		num3 = ((float_0 <= num) ? float_3 : (textAlignmentType_0 switch
		{
			TextAlignmentType.Top => float_3 + 1f, 
			TextAlignmentType.Bottom => float_3 + float_0 - num - 1f, 
			TextAlignmentType.Center => float_3 + (float_0 - num) * 0.5f, 
			_ => float_3 + (float_0 - num) * 0.5f, 
		}));
		if (textAlignmentType_1 == TextAlignmentType.General)
		{
			textAlignmentType_1 = class1620_0.method_15();
		}
		if (float_1 < num2 && (textAlignmentType_1 == TextAlignmentType.Center || textAlignmentType_1 == TextAlignmentType.CenterAcross) && float_4 != 0f)
		{
			x = float_2 + 1f;
		}
		else
		{
			switch (textAlignmentType_1)
			{
			case TextAlignmentType.Center:
			case TextAlignmentType.CenterAcross:
				x = float_2 + (float_1 - num2) * 0.5f;
				break;
			case TextAlignmentType.Justify:
			case TextAlignmentType.Left:
				x = float_2 + 1f;
				break;
			case TextAlignmentType.Right:
				x = float_2 + (float_1 - num2 - 1f);
				break;
			}
		}
		rectangleF_0 = new RectangleF(x, num3, num2, num);
	}

	private float method_22(float float_8, float float_9, float float_10, float float_11)
	{
		return Math.Min(Math.Max(float_8 - 2f, 1f) / float_10, float_9 / float_11);
	}

	public void method_23(Class454 class454_8)
	{
		float offsetX = 0f;
		float num = 0f;
		double num2 = (double)(float_4 / 180f) * Math.PI;
		class454_8.vmethod_1(null);
		if (!bool_3)
		{
			if (float_4 < -1E-45f)
			{
				switch (textAlignmentType_1)
				{
				case TextAlignmentType.Center:
				case TextAlignmentType.CenterAcross:
					offsetX = float_2 + (float_1 + rectangleF_0.Height * (float)Math.Sin(num2) - rectangleF_0.Width * (float)Math.Cos(num2)) / 2f;
					break;
				case TextAlignmentType.Justify:
				case TextAlignmentType.Left:
					offsetX = float_2;
					break;
				case TextAlignmentType.Right:
					offsetX = float_2 + float_1 + rectangleF_0.Height * (float)Math.Sin(num2) - rectangleF_0.Width * (float)Math.Cos(num2);
					break;
				}
				num = textAlignmentType_0 switch
				{
					TextAlignmentType.Top => float_3 + rectangleF_0.Height * (float)Math.Cos(num2), 
					TextAlignmentType.Bottom => float_3 + float_0 - rectangleF_0.Height * (float)Math.Cos(num2) - rectangleF_0.Width * (float)Math.Sin(0.0 - num2), 
					TextAlignmentType.Center => float_3 + (float_0 - rectangleF_0.Width * (float)Math.Sin(0.0 - num2)) / 2f, 
					_ => float_3 + rectangleF_0.Height * (float)Math.Cos(num2), 
				};
				class454_8.vmethod_1(new Matrix(1f * float_7, 0f, 0f, 1f * float_7, 0f, 0f));
				class454_8.imethod_0().Translate(offsetX, num, MatrixOrder.Append);
			}
			else if (float_4 > float.Epsilon)
			{
				switch (textAlignmentType_1)
				{
				case TextAlignmentType.Center:
				case TextAlignmentType.CenterAcross:
					offsetX = float_2 + (float_1 - rectangleF_0.Width * (float)Math.Cos(num2) + rectangleF_0.Height * (float)Math.Sin(num2)) / 2f;
					break;
				case TextAlignmentType.Justify:
				case TextAlignmentType.Left:
					offsetX = float_2 + rectangleF_0.Height * (float)Math.Sin(num2);
					break;
				case TextAlignmentType.Right:
					offsetX = float_2 + float_1 - rectangleF_0.Width * (float)Math.Cos(num2);
					break;
				}
				num = textAlignmentType_0 switch
				{
					TextAlignmentType.Top => float_3 + rectangleF_0.Height * (float)Math.Cos(num2) + rectangleF_0.Width * (float)Math.Sin(num2), 
					TextAlignmentType.Bottom => float_3 + float_0, 
					TextAlignmentType.Center => float_3 + (float_0 + rectangleF_0.Height * (float)Math.Cos(num2) + rectangleF_0.Width * (float)Math.Sin(num2)) / 2f, 
					_ => float_3 + float_0 - (rectangleF_0.Height * (float)Math.Cos(num2) - rectangleF_0.Width * (float)Math.Sin(num2)) / 2f, 
				};
				class454_8.vmethod_1(new Matrix(1f * float_7, 0f, 0f, 1f * float_7, 0f, 0f));
				class454_8.imethod_0().Translate(offsetX, num, MatrixOrder.Append);
			}
		}
		else if (float_4 < -1E-45f)
		{
			switch (textAlignmentType_1)
			{
			case TextAlignmentType.Center:
			case TextAlignmentType.CenterAcross:
				offsetX = float_2 + (float_1 + rectangleF_0.Height / (float)Math.Sin(num2) - rectangleF_0.Width * (float)Math.Cos(num2)) / 2f;
				break;
			case TextAlignmentType.Justify:
			case TextAlignmentType.Left:
				offsetX = float_2;
				break;
			case TextAlignmentType.Right:
				offsetX = float_2 + float_1 + rectangleF_0.Height / (float)Math.Sin(num2) - rectangleF_0.Width * (float)Math.Cos(num2);
				break;
			}
			num = textAlignmentType_0 switch
			{
				TextAlignmentType.Top => float_3 + rectangleF_0.Height * (float)Math.Cos(num2), 
				TextAlignmentType.Bottom => float_3 + float_0 - rectangleF_0.Height * (float)Math.Cos(num2) - rectangleF_0.Width * (float)Math.Sin(0.0 - num2), 
				TextAlignmentType.Center => float_3 + (float_0 - rectangleF_0.Width * (float)Math.Sin(0.0 - num2)) / 2f, 
				_ => float_3 + rectangleF_0.Height * (float)Math.Cos(num2), 
			};
			class454_8.vmethod_1(new Matrix(1f * float_7, 0f, 0f, 1f * float_7, 0f, 0f));
			class454_8.imethod_0().Translate(offsetX, num, MatrixOrder.Append);
		}
		else if (float_4 > float.Epsilon)
		{
			switch (textAlignmentType_1)
			{
			case TextAlignmentType.Center:
			case TextAlignmentType.CenterAcross:
				offsetX = float_2 + (float_1 - rectangleF_0.Width * (float)Math.Cos(num2) + rectangleF_0.Height / (float)Math.Sin(num2)) / 2f;
				break;
			case TextAlignmentType.Justify:
			case TextAlignmentType.Left:
				offsetX = float_2 + rectangleF_0.Height / (float)Math.Sin(num2);
				break;
			case TextAlignmentType.Right:
				offsetX = float_2 + float_1 - rectangleF_0.Width * (float)Math.Cos(num2);
				break;
			}
			num = textAlignmentType_0 switch
			{
				TextAlignmentType.Top => float_3 + rectangleF_0.Height * (float)Math.Cos(num2) + rectangleF_0.Width * (float)Math.Sin(num2), 
				TextAlignmentType.Bottom => float_3 + float_0, 
				TextAlignmentType.Center => float_3 + (float_0 + rectangleF_0.Height * (float)Math.Cos(num2) + rectangleF_0.Width * (float)Math.Sin(num2)) / 2f, 
				_ => float_3 + float_0 - (rectangleF_0.Height * (float)Math.Cos(num2) - rectangleF_0.Width * (float)Math.Sin(num2)) / 2f, 
			};
			class454_8.vmethod_1(new Matrix(1f * float_7, 0f, 0f, 1f * float_7, 0f, 0f));
			class454_8.imethod_0().Translate(offsetX, num, MatrixOrder.Append);
		}
	}

	public void method_24(Class454 class454_8)
	{
		float num = 0f;
		class454_8.vmethod_1(null);
		if (!(float_4 < -1E-45f) && float_4 <= float.Epsilon)
		{
			num = 0f;
			if (class1620_0.method_7().ShrinkToFit && (rectangleF_0.Width > float_1 || rectangleF_0.Height > float_0))
			{
				float_7 = method_22(float_1 - 2f, float_0 - 2f, rectangleF_0.Width, rectangleF_0.Height);
			}
			class454_8.vmethod_1(new Matrix(1f * float_7, 0f, 0f, 1f * float_7, 0f, 0f));
			class454_8.imethod_0().Translate(rectangleF_0.Left, rectangleF_0.Bottom, MatrixOrder.Append);
		}
		else
		{
			num = 0f - float_4;
			class454_8.vmethod_1(new Matrix(1f * float_7, 0f, 0f, 1f * float_7, 0f, 0f));
			class454_8.imethod_0().RotateAt(num, new PointF(0f, 0f));
		}
	}

	private void method_25(float float_8, float float_9, ref float float_10, ref float float_11)
	{
		float num = float_8 - float_9;
		float_10 = 0f;
		float_11 = 0f;
		if (num <= 0f)
		{
			return;
		}
		int column = class1620_0.Cell.Column;
		int row = class1620_0.Cell.Row;
		int num2 = column - 1;
		while (num2 >= 0 && cells_0.GetCell(row, num2, bool_2: false).StringValue.Length == 0)
		{
			float num3 = (float)(cells_0.GetColumnWidthInch(num2) * 72.0 * double_0[0]);
			if (num >= num3)
			{
				float_10 += num3;
				num -= num3;
				num2--;
				continue;
			}
			float_10 += num;
			break;
		}
		num2 = column + 1;
		num = (float_8 - float_9) / 2f + 1f;
		for (; num2 <= cells_0.method_22(0) && cells_0.GetCell(row, num2, bool_2: false).StringValue.Length == 0; num2++)
		{
			float num3 = (float)(cells_0.GetColumnWidthInch(num2) * 72.0 * double_0[0]);
			if (num >= num3)
			{
				float_11 += num3;
				num -= num3;
				continue;
			}
			float_11 += num;
			break;
		}
	}

	public void method_26()
	{
		bool flag;
		if (flag = Class1078.smethod_0(arrayList_1))
		{
			Class534 @class = new Class534();
			@class.method_1(arrayList_1);
		}
		if (!flag && class1620_0.method_15() == TextAlignmentType.Right && (class1620_0.method_19() == CellValueType.IsDateTime || class1620_0.method_19() == CellValueType.IsNumeric))
		{
			Class1621.smethod_0(arrayList_1);
		}
		else
		{
			Class1621.smethod_1(arrayList_1);
		}
		if (bool_0)
		{
			foreach (Class1544 item in arrayList_1)
			{
				item.font_0.Color = Color.Black;
			}
		}
		class451_0 = new Class451(arrayList_1, class1620_0, int_4, int_5, double_0, flag);
		class451_0.class468_0 = class468_0;
		class454_3 = new Class454();
		class451_0.Draw(class454_3);
		method_21();
		if (bool_1)
		{
			Class464 class452_ = new Class464(rectangleF_0, string_1);
			class454_5.Add(class452_);
			bool_1 = false;
		}
		Class454 class3 = new Class454();
		method_24(class454_3);
		method_23(class3);
		class3.Add(class454_3);
		float float_ = 0f;
		float float_2 = 0f;
		if (textAlignmentType_1 == TextAlignmentType.Center && !class1620_0.IsMerged)
		{
			method_25(rectangleF_0.Width, float_1, ref float_, ref float_2);
		}
		RectangleF rectangleF_ = new RectangleF(this.float_2 - float_ - 0.3f, float_3 - 0.3f, float_1 + float_ + float_2 + 0.6f, float_0 + 0.6f);
		if (bool_2)
		{
			class3.method_4(null);
		}
		else if (float_4 == 0f || float_4 == 90f || float_4 == -90f)
		{
			class3.method_4(new Class461(rectangleF_));
		}
		if (float_4 != 0f && float_4 != 90f && float_4 != -90f)
		{
			class454_5.Add(class3);
			return;
		}
		Class454 class4 = new Class454();
		class4.vmethod_2(new Class458(rectangleF_));
		class4.Add(class3);
		class454_5.Add(class4);
	}

	internal void method_27()
	{
		class454_4 = new Class454();
		if (class1398_0 == null)
		{
			class1398_0 = new Class1398();
		}
	}

	public void method_28(Class452 class452_0)
	{
		class454_4.Add(class452_0);
	}

	public void method_29(Stream stream_0)
	{
		Class465 class452_ = Class465.smethod_0(new PointF(float_2 + float_5, float_3 + float_6), new SizeF(float_1, float_0), stream_0);
		RectangleF rectangleF_ = new RectangleF(float_2 + float_5, float_3 + float_6, float_1, float_0);
		if (class1620_0 != null)
		{
			if (bool_2)
			{
				class454_4.method_4(null);
			}
			else
			{
				class454_4.method_4(new Class461(rectangleF_));
			}
		}
		else
		{
			class454_4.Add(class452_);
		}
	}

	public void method_30()
	{
		for (int i = 0; i < class1398_0.Count; i++)
		{
			Class454 @class = new Class454();
			Class465 class2 = (Class465)class1398_0.GetByIndex(i);
			@class.Add(class2);
			@class.vmethod_2(class2.class458_0);
			class454_4.Add(@class);
		}
		class454_1.Add(class454_4);
		class1398_0 = new Class1398();
	}

	internal void method_31()
	{
		if (class1620_0.hashtable_0 == null || class1620_0.hashtable_0.Count <= 0)
		{
			return;
		}
		RectangleF rectangleF = new RectangleF(float_2, float_3, float_1, float_0);
		string[] array = string_2;
		foreach (object key in array)
		{
			Class984 @class = (Class984)class1620_0.hashtable_0[key];
			if (@class == null)
			{
				continue;
			}
			Class454 class2 = @class.vmethod_0(rectangleF, double_0, class1620_0.method_17());
			if (class2 != null)
			{
				class454_6.Add(class2);
				if (!@class.vmethod_1() && class1620_0.method_36() != null)
				{
					class1620_0.method_36().Clear();
				}
			}
		}
	}
}
