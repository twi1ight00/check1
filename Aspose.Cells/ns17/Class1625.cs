using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Text.RegularExpressions;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Aspose.Cells.Tables;
using ns12;
using ns16;
using ns18;
using ns25;
using ns47;
using ns58;

namespace ns17;

internal class Class1625
{
	internal static Regex regex_0 = new Regex("[-+]?(\\d+([\\.\\,]\\d*)?|[\\.\\,]\\d+)([eE]([-+]?([012]?\\d{1,2}|30[0-7])|-3([01]?[4-9]|[012]?[0-3])))?[dD]?[\\s]*");

	internal static Regex regex_1 = new Regex("[\\d,\\.]+");

	internal static HatchStyle smethod_0(BackgroundType backgroundType_0)
	{
		return backgroundType_0 switch
		{
			BackgroundType.Gray50 => HatchStyle.Percent50, 
			BackgroundType.Gray75 => HatchStyle.Percent70, 
			BackgroundType.Gray25 => HatchStyle.Percent25, 
			BackgroundType.HorizontalStripe => HatchStyle.DarkHorizontal, 
			BackgroundType.VerticalStripe => HatchStyle.DarkVertical, 
			BackgroundType.ReverseDiagonalStripe => HatchStyle.DarkDownwardDiagonal, 
			BackgroundType.DiagonalStripe => HatchStyle.DarkUpwardDiagonal, 
			BackgroundType.DiagonalCrosshatch => HatchStyle.SmallCheckerBoard, 
			BackgroundType.ThickDiagonalCrosshatch => HatchStyle.Trellis, 
			BackgroundType.ThinHorizontalStripe => HatchStyle.LightHorizontal, 
			BackgroundType.ThinVerticalStripe => HatchStyle.LightVertical, 
			BackgroundType.ThinReverseDiagonalStripe => HatchStyle.LightDownwardDiagonal, 
			BackgroundType.ThinDiagonalStripe => HatchStyle.LightUpwardDiagonal, 
			BackgroundType.ThinHorizontalCrosshatch => HatchStyle.SmallGrid, 
			BackgroundType.ThinDiagonalCrosshatch => HatchStyle.Percent30, 
			BackgroundType.Gray12 => HatchStyle.Percent20, 
			BackgroundType.Gray6 => HatchStyle.Percent10, 
			_ => HatchStyle.Horizontal, 
		};
	}

	internal static bool smethod_1(Class1626 class1626_0, Struct88 struct88_0, int int_0)
	{
		if (int_0 != class1626_0.method_4().method_26().Index)
		{
			return false;
		}
		if (class1626_0.method_0() <= class1626_0.method_1() && class1626_0.method_2() <= class1626_0.method_3())
		{
			if (!(class1626_0.method_4() is ChartShape) && class1626_0.method_4().method_57().Width * class1626_0.method_4().method_57().Height == 0f)
			{
				return false;
			}
			if (class1626_0.method_4() is ChartShape)
			{
				ChartShape chartShape = (ChartShape)class1626_0.method_4();
				if (chartShape.Chart.ChartObject.Width * chartShape.Chart.ChartObject.Height == 0)
				{
					return false;
				}
			}
			Rectangle rectangle = new Rectangle(class1626_0.method_2(), class1626_0.method_0(), class1626_0.method_3() - class1626_0.method_2() + 1, class1626_0.method_1() - class1626_0.method_0() + 1);
			Rectangle rect = new Rectangle(struct88_0.int_1, struct88_0.int_0, struct88_0.int_3 - struct88_0.int_1 + 1, struct88_0.int_2 - struct88_0.int_0 + 1);
			return rectangle.IntersectsWith(rect);
		}
		return false;
	}

	internal static Class1544 smethod_2(int columnWidth, Style style, Aspose.Cells.Font font, out bool isLeft)
	{
		isLeft = false;
		if (style.Custom != null && style.Custom != "")
		{
			if (style.Custom.IndexOf('/') != -1)
			{
				return null;
			}
			string[] array = style.Custom.Split(';');
			char[] array2 = null;
			if (array.Length < 4)
			{
				return null;
			}
			array2 = array[3].ToCharArray();
			StringBuilder stringBuilder = new StringBuilder();
			for (int num = array2.Length - 1; num > 0; num--)
			{
				if (array2[num] == '?')
				{
					stringBuilder.Append(array2[num]);
				}
				else
				{
					switch (array2[num - 1])
					{
					case '_':
						stringBuilder.Append(array2[num--]);
						break;
					default:
						num = 0;
						break;
					case '*':
					{
						isLeft = true;
						stringBuilder = new StringBuilder();
						for (int i = 0; i < num - 1; i++)
						{
							switch (array2[i])
							{
							default:
								i = num;
								break;
							case '_':
								stringBuilder.Append(array2[i++]);
								break;
							case '?':
								stringBuilder.Append(array2[i]);
								break;
							}
						}
						break;
					}
					}
				}
			}
			if (stringBuilder.Length != 0)
			{
				Class1544 @class = new Class1544();
				@class.font_0 = font;
				@class.string_0 = stringBuilder.ToString();
				@class.enum217_0 = Enum217.flag_2;
				return @class;
			}
		}
		return null;
	}

	internal static Class1544 smethod_3(double doubleValue, int columnWidth, Style style, Aspose.Cells.Font font, out bool isLeft)
	{
		isLeft = false;
		if (style.Custom != null && style.Custom != "")
		{
			if (style.Custom.IndexOf('/') != -1)
			{
				return null;
			}
			string[] array = style.Custom.Split(';');
			char[] array2 = null;
			if (array.Length == 1)
			{
				array2 = style.Custom.ToCharArray();
			}
			else if (array.Length == 2)
			{
				array2 = ((!(doubleValue >= 0.0)) ? array[1].ToCharArray() : array[0].ToCharArray());
			}
			else if (array.Length >= 3)
			{
				array2 = ((doubleValue > 0.0) ? array[0].ToCharArray() : ((!(doubleValue < 0.0)) ? array[2].ToCharArray() : array[1].ToCharArray()));
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int num = array2.Length - 1; num > 0; num--)
			{
				if (array2[num] == '?')
				{
					stringBuilder.Append(array2[num]);
				}
				else
				{
					switch (array2[num - 1])
					{
					case '_':
						stringBuilder.Append(array2[num--]);
						break;
					default:
						num = 0;
						break;
					case '*':
					{
						isLeft = true;
						stringBuilder = new StringBuilder();
						for (int i = 0; i < num - 1; i++)
						{
							switch (array2[i])
							{
							default:
								i = num;
								break;
							case '_':
								stringBuilder.Append(array2[i++]);
								break;
							case '?':
								stringBuilder.Append(array2[i]);
								break;
							}
						}
						break;
					}
					}
				}
			}
			if (stringBuilder.Length != 0)
			{
				Class1544 @class = new Class1544();
				@class.font_0 = font;
				@class.string_0 = stringBuilder.ToString();
				@class.enum217_0 = Enum217.flag_2;
				return @class;
			}
			return null;
		}
		if (style.Number != 0)
		{
			switch (style.method_44())
			{
			case 42:
			case 44:
				if (doubleValue > 0.0)
				{
				}
				break;
			case 5:
			case 6:
			case 7:
			case 8:
			case 37:
			case 38:
			case 39:
			case 40:
			case 41:
			case 43:
				if (!(doubleValue < 0.0))
				{
				}
				break;
			}
		}
		return null;
	}

	internal static string smethod_4(int int_0, char char_0, Aspose.Cells.Font font_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = smethod_19(char_0.ToString(), font_0, 1.0);
		int num2 = int_0 / num;
		for (int i = 0; i < num2; i++)
		{
			stringBuilder.Append(char_0);
		}
		return stringBuilder.ToString();
	}

	internal static Style GetCellStyle(Cells cells_0, Cell cell_0, int int_0, int int_1, Style style_0, Struct88 struct88_0)
	{
		if (cell_0 != null)
		{
			return cell_0.GetStyle(struct88_0.int_0, struct88_0.int_1, struct88_0.int_2, struct88_0.int_3);
		}
		int num = cells_0.Rows.method_5(int_0);
		if (num != -1)
		{
			Row rowByIndex = cells_0.Rows.GetRowByIndex(num);
			if (rowByIndex.method_27())
			{
				return rowByIndex.method_26();
			}
		}
		num = cells_0.Columns.method_7(int_1);
		if (num != -1)
		{
			Column columnByIndex = cells_0.Columns.GetColumnByIndex(num);
			if (columnByIndex.method_10())
			{
				return columnByIndex.method_13();
			}
		}
		return style_0;
	}

	internal static Style smethod_5(Cells cells_0, int int_0, int int_1, int int_2, int int_3, Struct88 struct88_0)
	{
		Style style = new Style(cells_0.method_19());
		Cell cell_ = cells_0.CheckCell(struct88_0.int_0, struct88_0.int_1);
		Style style2 = GetCellStyle(struct88_0: new Struct88(int_0, int_1, int_2, int_3), cells_0: cells_0, cell_0: cell_, int_0: struct88_0.int_0, int_1: struct88_0.int_3, style_0: cells_0.method_19().DefaultStyle);
		cell_ = cells_0.CheckCell(struct88_0.int_2, struct88_0.int_3);
		style.Copy(style2);
		style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.None;
		style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.None;
		style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.None;
		style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.None;
		int_0 = ((struct88_0.int_0 > int_0) ? struct88_0.int_0 : int_0);
		int_1 = ((struct88_0.int_1 > int_1) ? struct88_0.int_1 : int_1);
		int_2 = ((struct88_0.int_2 < int_2) ? struct88_0.int_2 : int_2);
		int_3 = ((struct88_0.int_3 < int_3) ? struct88_0.int_3 : int_3);
		return style;
	}

	internal static double[] smethod_6(Worksheet worksheet_0)
	{
		Aspose.Cells.Font defaultFont = worksheet_0.Workbook.Worksheets.DefaultFont;
		double num = 1.0;
		double num2 = 1.0;
		if (defaultFont.Name == "Times New Roman")
		{
			switch (defaultFont.Size)
			{
			case 10:
				num = 1.1186943620178043;
				num2 = 1.0214285714285714;
				break;
			case 11:
				num = 1.0505836575875487;
				num2 = 302.0 / 321.0;
				break;
			case 12:
				num = 1.0103703703703704;
				num2 = 387.0 / 410.0;
				break;
			}
		}
		else if (defaultFont.Name == "Calibri" && defaultFont.Size == 10)
		{
			switch (worksheet_0.PageSetup.PrintQuality)
			{
			case 100:
				num = 649.0 / 676.0;
				num2 = 1.0163934426229508;
				break;
			case 96:
				num = 1.001543209876543;
				num2 = 0.9422492401215805;
				break;
			default:
				num = 649.0 / 675.0;
				num2 = 1.0367892976588629;
				break;
			case 600:
				num = 649.0 / 675.0;
				num2 = 1.0276243093922652;
				break;
			case 200:
				num = 649.0 / 676.0;
				num2 = 1.0449438202247192;
				break;
			case 120:
				num = 1.0268987341772151;
				num2 = 1.0356347438752784;
				break;
			}
		}
		else if (defaultFont.Name == "Calibri" && defaultFont.Size == 12)
		{
			num = 1.0;
			num2 = 1.0238095238095237;
		}
		else if (defaultFont.Name == "Calibri" && defaultFont.Size == 11)
		{
			switch (worksheet_0.PageSetup.PrintQuality)
			{
			case 100:
				num = 649.0 / 676.0;
				num2 = 0.9126594700686947;
				break;
			case 96:
				num = 1.001543209876543;
				num2 = 0.950920245398773;
				break;
			default:
				num = 1.0518638573743921;
				num2 = 465.0 / 484.0;
				break;
			case 600:
				num = 1.0700389105058365;
				num2 = 29.0 / 30.0;
				break;
			case 200:
				num = 1.0962837837837838;
				num2 = 465.0 / 484.0;
				break;
			case 120:
				num = 1.0268987341772151;
				num2 = 0.9198813056379822;
				break;
			}
		}
		else if (defaultFont.Name.StartsWith("ＭＳ") && defaultFont.Size == 9)
		{
			switch (worksheet_0.PageSetup.PrintQuality)
			{
			case 100:
				num = 1.1151202749140894;
				num2 = 1.024229074889868;
				break;
			case 96:
				num = 1.001543209876543;
				num2 = 1.0010764262648009;
				break;
			default:
				num = 1.0140625;
				num2 = 31.0 / 33.0;
				break;
			case 600:
				num = 1.0156494522691706;
				num2 = 465.0 / 512.0;
				break;
			case 200:
				num = 1.0384;
				num2 = 0.9281437125748503;
				break;
			case 120:
				num = 1.0709570957095709;
				num2 = 0.9597523219814241;
				break;
			}
		}
		else if (defaultFont.Name.StartsWith("ＭＳ") && defaultFont.Size == 10)
		{
			switch (worksheet_0.PageSetup.PrintQuality)
			{
			case 100:
				num = 649.0 / 676.0;
				num2 = 1.0208562019758507;
				break;
			case 96:
				num = 1.001543209876543;
				num2 = 1.0010764262648009;
				break;
			default:
				num = 649.0 / 675.0;
				num2 = 465.0 / 484.0;
				break;
			case 600:
				num = 649.0 / 675.0;
				num2 = 310.0 / 333.0;
				break;
			case 200:
				num = 649.0 / 676.0;
				num2 = 465.0 / 484.0;
				break;
			case 120:
				num = 1.0268987341772151;
				num2 = 1.0;
				break;
			}
		}
		else if (defaultFont.Name.StartsWith("ＭＳ") && defaultFont.Size == 11)
		{
			switch (worksheet_0.PageSetup.PrintQuality)
			{
			case 100:
				num = 649.0 / 676.0;
				num2 = 465.0 / 484.0;
				break;
			case 96:
				num = 1.001543209876543;
				num2 = 1.0010764262648009;
				break;
			default:
				num = 59.0 / 64.0;
				num2 = 0.9253731343283582;
				break;
			case 600:
				num = 59.0 / 64.0;
				num2 = 465.0 / 512.0;
				break;
			case 200:
				num = 649.0 / 676.0;
				num2 = 155.0 / 166.0;
				break;
			case 120:
				num = 0.9001386962552012;
				num2 = 155.0 / 166.0;
				break;
			}
		}
		else if (defaultFont.Name.StartsWith("ＭＳ") && defaultFont.Size == 12)
		{
			switch (worksheet_0.PageSetup.PrintQuality)
			{
			case 100:
				num = 1.0798668885191347;
				num2 = 1.0108695652173914;
				break;
			case 96:
				num = 1.001543209876543;
				num2 = 1.0010764262648009;
				break;
			default:
				num = 1.001543209876543;
				num2 = 0.9441624365482234;
				break;
			case 600:
				num = 1.001543209876543;
				num2 = 0.9272183449651047;
				break;
			case 200:
				num = 1.020440251572327;
				num2 = 0.9346733668341709;
				break;
			case 120:
				num = 1.0;
				num2 = 31.0 / 32.0;
				break;
			}
		}
		else if (defaultFont.Name == "Arial" && defaultFont.Size == 9)
		{
			switch (worksheet_0.PageSetup.PrintQuality)
			{
			case 100:
				num = 649.0 / 676.0;
				num2 = 1.0208562019758507;
				break;
			case 96:
				num = 1.001543209876543;
				num2 = 1.0010764262648009;
				break;
			default:
				num = 649.0 / 675.0;
				num2 = 465.0 / 484.0;
				break;
			case 600:
				num = 128.0 / 135.0;
				num2 = 310.0 / 333.0;
				break;
			case 200:
				num = 649.0 / 676.0;
				num2 = 0.93;
				break;
			case 120:
				num = 649.0 / 711.0;
				num2 = 0.9002904162633107;
				break;
			}
		}
		else if (defaultFont.Name == "Arial" && defaultFont.Size == 10)
		{
			num = 1.0521920668058455;
			num2 = 0.9679144385026738;
		}
		else if (defaultFont.Name == "Arial" && defaultFont.Size == 11)
		{
			switch (worksheet_0.PageSetup.PrintQuality)
			{
			case 100:
				num = 649.0 / 676.0;
				num2 = 0.9099804305283757;
				break;
			case 96:
				num = 1.001543209876543;
				num2 = 310.0 / 327.0;
				break;
			default:
				num = 1.0417335473515248;
				num2 = 0.9779179810725552;
				break;
			case 600:
				num = 1.020440251572327;
				num2 = 0.9617373319544984;
				break;
			case 200:
				num = 1.020440251572327;
				num2 = 465.0 / 484.0;
				break;
			case 120:
				num = 1.0;
				num2 = 31.0 / 32.0;
				break;
			}
		}
		else if (defaultFont.Name == "Arial" && defaultFont.Size == 8)
		{
			num = 0.9866369710467706;
			num2 = 29.0 / 32.0;
		}
		else if (defaultFont.Name == "Geneva" && defaultFont.Size == 9)
		{
			num = 1.0807600950118765;
			num2 = 1.0551470588235294;
		}
		else if (defaultFont.Name == "Verdana" && defaultFont.Size == 10)
		{
			num = 1.055363321799308;
			num2 = 1.013840830449827;
		}
		else if (defaultFont.Name == "Verdana" && defaultFont.Size == 8)
		{
			num = 0.9607201309328969;
			num2 = 109.0 / 116.0;
		}
		else if (defaultFont.Name == "Arial MT" && defaultFont.Size == 12)
		{
			num = 0.995850622406639;
			num2 = 0.983402489626556;
		}
		else if (defaultFont.Name == "Tahoma" && defaultFont.Size == 10)
		{
			num = 1.0260416666666667;
			num2 = 1.0;
		}
		else if (defaultFont.Name == "MS Sans Serif" && defaultFont.Size == 8)
		{
			num = 281.0 / 312.0;
			num2 = 148.0 / 155.0;
		}
		else
		{
			switch (worksheet_0.PageSetup.PrintQuality)
			{
			case 100:
				num = 1.0944350758853287;
				num2 = 465.0 / 484.0;
				break;
			case 96:
				num = 1.001543209876543;
				num2 = 1.0010764262648009;
				break;
			default:
				num = 1.0518638573743921;
				num2 = 0.9799789251844047;
				break;
			case 600:
				num = 1.0535714285714286;
				num2 = 0.9707724425887265;
				break;
			case 200:
				num = 1.0962837837837838;
				num2 = 0.9883103081827843;
				break;
			case 120:
				num = 1.0268987341772151;
				num2 = 0.9883103081827843;
				break;
			}
		}
		return new double[2] { num, num2 };
	}

	internal static double[] smethod_7(Worksheet worksheet_0, double double_0, double double_1, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, int int_6, int int_7)
	{
		Cells cells = worksheet_0.Cells;
		double[] array = new double[2] { 1.0, 1.0 };
		PageSetup pageSetup = worksheet_0.PageSetup;
		double[] array2 = smethod_6(worksheet_0);
		double num = 0.0;
		double num2 = 0.0;
		if (!pageSetup.IsPercentScale && (pageSetup.FitToPagesTall != 0 || pageSetup.FitToPagesWide != 0))
		{
			if (pageSetup.FitToPagesWide != 0)
			{
				for (int i = int_6; i <= int_7 && i >= 0; i++)
				{
					num += cells.GetColumnWidthInch(i) * 72.0;
				}
				array[0] = smethod_8(worksheet_0, double_0, int_0, int_1, num);
				if (array[0] < 0.1)
				{
					array[0] = 0.1;
				}
			}
			if (pageSetup.FitToPagesTall != 0)
			{
				for (int j = int_4; j <= int_5 && j >= 0; j++)
				{
					num2 += cells.GetRowHeightInch(j) * 72.0;
				}
				num2 = num2 / 96.0 * 72.0;
				array[1] = smethod_9(worksheet_0, double_1, int_2, int_3, num2);
				if (array[1] < 0.1)
				{
					array[1] = 0.1;
				}
			}
			if (pageSetup.FitToPagesTall == 0 && pageSetup.FitToPagesWide == 0)
			{
				array[0] *= array2[0];
				array[1] *= array2[1];
			}
			else
			{
				double num3 = Math.Min(array[0], array[1]);
				if (num3 > Math.Min(array2[0], array2[1]))
				{
					array[0] = array2[0];
					array[1] = array2[1];
				}
				else if (num3 > 1.0)
				{
					array = array2;
				}
				else
				{
					if (pageSetup.FitToPagesTall == pageSetup.FitToPagesWide && pageSetup.FitToPagesWide == 1 && Math.Abs((array[0] - array[1]) / array[0]) < 0.15)
					{
						return array;
					}
					array[0] = num3;
					array[1] = array2[1] / array2[0] * array[0];
				}
			}
			return array;
		}
		double num4 = (double)pageSetup.Zoom / 100.0;
		array = new double[2] { num4, num4 };
		array[0] *= array2[0];
		array[1] *= array2[1];
		return array;
	}

	internal static double smethod_8(Worksheet worksheet_0, double double_0, int int_0, int int_1, double double_1)
	{
		double result = 0.0;
		double num = 0.0;
		Cells cells = worksheet_0.Cells;
		PageSetup pageSetup = worksheet_0.PageSetup;
		if (!pageSetup.IsPercentScale)
		{
			for (int i = int_0; i <= int_1; i++)
			{
				num += cells.GetColumnWidthInch(i) * 72.0;
			}
			num += double_1 * (double)(pageSetup.FitToPagesWide - 1);
			if (num != 0.0)
			{
				result = (double)pageSetup.FitToPagesWide * double_0 / num;
			}
		}
		return result;
	}

	internal static double smethod_9(Worksheet worksheet_0, double double_0, int int_0, int int_1, double double_1)
	{
		double result = 0.0;
		double num = 0.0;
		Cells cells = worksheet_0.Cells;
		PageSetup pageSetup = worksheet_0.PageSetup;
		if (!pageSetup.IsPercentScale)
		{
			for (int i = int_0; i <= int_1; i++)
			{
				num += cells.GetRowHeightInch(i) * 72.0;
			}
			num += double_1 * (double)(pageSetup.FitToPagesTall - 1);
			if (num != 0.0)
			{
				result = (double)pageSetup.FitToPagesTall * double_0 / num;
			}
		}
		return result;
	}

	internal static void GetPageSize(Worksheet worksheet, out double cellAreasWidth, out double cellAreasHeight, double pageWidthBase, double pageHeightBase)
	{
		PageSetup pageSetup = worksheet.PageSetup;
		cellAreasWidth = (pageWidthBase - (pageSetup.LeftMarginInch + pageSetup.RightMarginInch)) * 72.0;
		cellAreasHeight = (pageHeightBase - (pageSetup.TopMarginInch + pageSetup.BottomMarginInch)) * 72.0;
	}

	internal static void smethod_10(PageSetup pageSetup, out double pageWidthBase, out double pageHeightBase)
	{
		pageWidthBase = Math.Round(8.267716535433072, 2);
		pageHeightBase = Math.Round(16.535433070866144, 2);
		switch (pageSetup.PaperSize)
		{
		case PaperSizeType.PaperLetter:
		{
			double value = 8.5;
			pageWidthBase = Math.Round(value, 2);
			pageHeightBase = 11.0;
			break;
		}
		case PaperSizeType.PaperLetterSmall:
		{
			double value = 8.5;
			pageWidthBase = Math.Round(value, 2);
			pageHeightBase = 11.0;
			break;
		}
		case PaperSizeType.PaperTabloid:
			pageWidthBase = 11.0;
			pageHeightBase = 17.0;
			break;
		case PaperSizeType.PaperLedger:
			pageWidthBase = 17.0;
			pageHeightBase = 11.0;
			break;
		case PaperSizeType.PaperLegal:
		{
			double value = 8.5;
			pageWidthBase = Math.Round(value, 2);
			pageHeightBase = 14.0;
			break;
		}
		case PaperSizeType.PaperStatement:
			pageWidthBase = 5.5;
			pageHeightBase = 8.5;
			break;
		case PaperSizeType.PaperExecutive:
		{
			double value = 7.5;
			pageWidthBase = Math.Round(value, 2);
			value = 10.5;
			pageHeightBase = Math.Round(value, 2);
			break;
		}
		case PaperSizeType.PaperA3:
			pageWidthBase = Math.Round(11.692913385826772, 2);
			pageHeightBase = Math.Round(16.535433070866144, 2);
			break;
		case PaperSizeType.PaperA4:
			pageWidthBase = Math.Round(8.267716535433072, 2);
			pageHeightBase = Math.Round(11.692913385826772, 2);
			break;
		case PaperSizeType.PaperA4Small:
			pageWidthBase = Math.Round(8.267716535433072, 2);
			pageHeightBase = Math.Round(11.692913385826772, 2);
			break;
		case PaperSizeType.PaperA5:
			pageWidthBase = Math.Round(5.826771653543307, 2);
			pageHeightBase = Math.Round(8.267716535433072, 2);
			break;
		case PaperSizeType.PaperB4:
			pageWidthBase = Math.Round(9.84251968503937, 2);
			pageHeightBase = Math.Round(13.937007874015748, 2);
			break;
		case PaperSizeType.PaperB5:
			pageWidthBase = Math.Round(7.165354330708662, 2);
			pageHeightBase = Math.Round(10.118110236220472, 2);
			break;
		case PaperSizeType.PaperFolio:
		{
			double value = 8.5;
			pageWidthBase = Math.Round(value, 2);
			pageHeightBase = 13.0;
			break;
		}
		case PaperSizeType.PaperQuarto:
			pageWidthBase = Math.Round(8.46456692913386, 2);
			pageHeightBase = Math.Round(10.826771653543307, 2);
			break;
		case PaperSizeType.Paper10x14:
			pageWidthBase = 10.0;
			pageHeightBase = 14.0;
			break;
		case PaperSizeType.Paper11x17:
			pageWidthBase = 11.0;
			pageHeightBase = 17.0;
			break;
		case PaperSizeType.PaperNote:
		{
			double value = 8.5;
			pageWidthBase = Math.Round(value, 2);
			pageHeightBase = 11.0;
			break;
		}
		case PaperSizeType.PaperEnvelope9:
		{
			double value = 3.875;
			pageWidthBase = Math.Round(value, 2);
			value = 8.875;
			pageHeightBase = Math.Round(value, 2);
			break;
		}
		case PaperSizeType.PaperEnvelope10:
		{
			double value = 4.125;
			pageWidthBase = Math.Round(value, 2);
			value = 9.5;
			pageHeightBase = Math.Round(value, 2);
			break;
		}
		case PaperSizeType.PaperEnvelope11:
		{
			double value = 4.5;
			pageWidthBase = Math.Round(value, 2);
			value = 10.375;
			pageHeightBase = Math.Round(value, 2);
			break;
		}
		case PaperSizeType.PaperEnvelope12:
		{
			double value = 4.75;
			pageWidthBase = Math.Round(value, 2);
			pageHeightBase = 11.0;
			break;
		}
		case PaperSizeType.PaperEnvelope14:
		{
			pageWidthBase = 5.0;
			double value = 11.5;
			pageHeightBase = Math.Round(value, 2);
			break;
		}
		case PaperSizeType.PaperCSheet:
			pageWidthBase = Math.Round(17.0, 2);
			pageHeightBase = Math.Round(22.0, 2);
			break;
		case PaperSizeType.PaperDSheet:
			pageWidthBase = Math.Round(22.0, 2);
			pageHeightBase = Math.Round(34.0, 2);
			break;
		case PaperSizeType.PaperESheet:
			pageWidthBase = Math.Round(34.0, 2);
			pageHeightBase = Math.Round(44.0, 2);
			break;
		case PaperSizeType.PaperEnvelopeDL:
			pageWidthBase = Math.Round(4.330708661417323, 2);
			pageHeightBase = Math.Round(8.661417322834646, 2);
			break;
		case PaperSizeType.PaperEnvelopeC5:
			pageWidthBase = Math.Round(6.377952755905512, 2);
			pageHeightBase = Math.Round(9.015748031496063, 2);
			break;
		case PaperSizeType.PaperEnvelopeC3:
			pageWidthBase = Math.Round(12.755905511811024, 2);
			pageHeightBase = Math.Round(18.031496062992126, 2);
			break;
		case PaperSizeType.PaperEnvelopeC4:
			pageWidthBase = Math.Round(9.015748031496063, 2);
			pageHeightBase = Math.Round(12.755905511811024, 2);
			break;
		case PaperSizeType.PaperEnvelopeC6:
			pageWidthBase = Math.Round(4.488188976377953, 2);
			pageHeightBase = Math.Round(6.377952755905512, 2);
			break;
		case PaperSizeType.PaperEnvelopeC65:
			pageWidthBase = Math.Round(4.488188976377953, 2);
			pageHeightBase = Math.Round(9.015748031496063, 2);
			break;
		case PaperSizeType.PaperEnvelopeB4:
			pageWidthBase = Math.Round(9.84251968503937, 2);
			pageHeightBase = Math.Round(13.89763779527559, 2);
			break;
		case PaperSizeType.PaperEnvelopeB5:
			pageWidthBase = Math.Round(6.929133858267717, 2);
			pageHeightBase = Math.Round(9.84251968503937, 2);
			break;
		case PaperSizeType.PaperEnvelopeB6:
			pageWidthBase = Math.Round(6.929133858267717, 2);
			pageHeightBase = Math.Round(4.921259842519685, 2);
			break;
		case PaperSizeType.PaperEnvelopeItaly:
			pageWidthBase = Math.Round(4.330708661417323, 2);
			pageHeightBase = Math.Round(9.05511811023622, 2);
			break;
		case PaperSizeType.PaperEnvelopeMonarch:
		{
			double value = 3.875;
			pageWidthBase = Math.Round(value, 2);
			value = 7.5;
			pageHeightBase = Math.Round(value, 2);
			break;
		}
		case PaperSizeType.PaperEnvelopePersonal:
		{
			double value = 3.625;
			pageWidthBase = Math.Round(value, 2);
			value = 6.5;
			pageHeightBase = Math.Round(value, 2);
			break;
		}
		case PaperSizeType.PaperFanfoldUS:
		{
			double value = 14.875;
			pageWidthBase = Math.Round(value, 2);
			pageHeightBase = 11.0;
			break;
		}
		case PaperSizeType.PaperFanfoldStdGerman:
		{
			double value = 8.5;
			pageWidthBase = Math.Round(value, 2);
			pageHeightBase = 12.0;
			break;
		}
		case PaperSizeType.PaperFanfoldLegalGerman:
		{
			double value = 8.5;
			pageWidthBase = Math.Round(value, 2);
			pageHeightBase = 13.0;
			break;
		}
		default:
			pageWidthBase = Math.Round(8.267716535433072, 2);
			pageHeightBase = Math.Round(11.692913385826772, 2);
			break;
		case PaperSizeType.PaperLetterRotated:
		{
			double value = 8.5;
			pageWidthBase = 11.0;
			pageHeightBase = Math.Round(value, 2);
			break;
		}
		}
		if (pageSetup.Orientation == PageOrientationType.Landscape)
		{
			double num = pageWidthBase;
			pageWidthBase = pageHeightBase;
			pageHeightBase = num;
		}
	}

	internal static bool smethod_11(Style style_0, Style style_1)
	{
		if (style_0 == null)
		{
			return false;
		}
		if (style_0.ForegroundColor.ToArgb() == style_1.ForegroundColor.ToArgb() && style_0.Pattern == BackgroundType.None)
		{
			if (style_0.method_4() != null)
			{
				if (style_0.Borders[BorderType.TopBorder].LineStyle == CellBorderType.None && style_0.Borders[BorderType.BottomBorder].LineStyle == CellBorderType.None && style_0.Borders[BorderType.LeftBorder].LineStyle == CellBorderType.None)
				{
					return style_0.Borders[BorderType.RightBorder].LineStyle != CellBorderType.None;
				}
				return true;
			}
			return false;
		}
		return true;
	}

	internal static ArrayList smethod_12(string string_0, Worksheet worksheet_0)
	{
		ArrayList arrayList = new ArrayList();
		if (string_0.EndsWith("]"))
		{
			bool InvalidTable;
			byte[] byte_ = Class1689.smethod_0(worksheet_0.method_2(), worksheet_0.Index, 0, 0, string_0, Enum227.const_0, out InvalidTable);
			if (!InvalidTable)
			{
				int[] range = Class1689.GetRange(worksheet_0.method_2(), byte_, 0, 0, 0);
				CellArea cellArea = default(CellArea);
				cellArea.StartRow = range[1];
				cellArea.StartColumn = range[2];
				cellArea.EndRow = range[3];
				cellArea.EndColumn = range[4];
				arrayList.Add(cellArea);
				return arrayList;
			}
		}
		if (string_0.IndexOf(',') != -1)
		{
			string[] array = Class1660.smethod_17(string_0);
			if (array == null)
			{
				arrayList.Add(smethod_14(string_0, worksheet_0));
			}
			else
			{
				for (int i = 0; i < array.Length; i++)
				{
					arrayList.Add(smethod_14(array[i], worksheet_0));
				}
			}
		}
		else
		{
			arrayList.Add(smethod_14(string_0, worksheet_0));
		}
		return arrayList;
	}

	internal static CellArea smethod_13(string string_0, Worksheet worksheet_0)
	{
		CellArea result = default(CellArea);
		result.EndRow = -1;
		result.EndColumn = -1;
		result.StartColumn = -1;
		result.StartRow = -1;
		int num = string_0.IndexOf('[');
		string text = "";
		string text2 = "";
		if (num < 0)
		{
			text = string_0;
		}
		else
		{
			text = string_0.Substring(0, num);
			text2 = string_0.Substring(num);
		}
		ListObject listObject = null;
		foreach (ListObject listObject2 in worksheet_0.ListObjects)
		{
			if (listObject2.Name == text)
			{
				listObject = listObject2;
			}
		}
		if (listObject != null)
		{
			if (text2.Length == 0)
			{
				result.StartColumn = listObject.StartColumn;
				result.StartRow = listObject.StartRow;
				result.EndColumn = listObject.EndColumn;
				result.EndRow = listObject.EndRow;
			}
			else
			{
				Regex regex = new Regex("\\x23([\\w\\s]+)");
				Match match = regex.Match(text2);
				if (!match.Success)
				{
					Regex regex2 = new Regex("\\[([\\w\\s]+)\\]");
					Match match2 = regex2.Match(text2);
					if (!match2.Success)
					{
						return listObject.DataRange.Area;
					}
					string value = match2.Groups[1].Value;
					foreach (ListColumn listColumn in listObject.ListColumns)
					{
						if (listColumn.Name == value)
						{
							result = listObject.DataRange.Area;
							result.StartColumn = (result.EndColumn = listColumn.method_5());
						}
					}
				}
				switch (match.Groups[1].Value)
				{
				case "This Row":
				{
					int row = -1;
					int column = -1;
					CellsHelper.CellNameToIndex(worksheet_0.ActiveCell, out row, out column);
					result.StartRow = (result.EndRow = row);
					result.StartColumn = listObject.StartColumn;
					result.EndColumn = listObject.EndColumn;
					break;
				}
				case "All":
					result.StartRow = listObject.StartRow;
					result.StartColumn = listObject.StartColumn;
					result.EndColumn = listObject.EndColumn;
					result.EndRow = listObject.EndRow;
					break;
				case "Headers":
					result.StartRow = listObject.StartRow;
					result.EndRow = result.StartRow + listObject.method_48() - 1;
					result.StartColumn = listObject.StartColumn;
					result.EndColumn = listObject.EndColumn;
					break;
				}
			}
		}
		return result;
	}

	internal static CellArea smethod_14(string string_0, Worksheet worksheet_0)
	{
		string_0 = string_0.Replace("$", "");
		Regex regex = new Regex(":");
		Match match = regex.Match(string_0);
		CellArea result = default(CellArea);
		int row;
		int column;
		if (match.Success)
		{
			string text = string_0.Substring(0, match.Index).Trim();
			string text2 = string_0.Substring(match.Index + 1).Trim();
			if (char.IsDigit(text[0]))
			{
				result.StartRow = int.Parse(text) - 1;
				result.EndColumn = -1;
				result.StartColumn = -1;
				result.EndRow = int.Parse(text2) - 1;
			}
			else if (char.IsLetter(text[text.Length - 1]))
			{
				result.EndRow = -1;
				result.StartRow = -1;
				result.StartColumn = CellsHelper.ColumnNameToIndex(text);
				result.EndColumn = CellsHelper.ColumnNameToIndex(text2);
			}
			else
			{
				CellsHelper.CellNameToIndex(text, out row, out column);
				result.StartRow = row;
				result.StartColumn = column;
				CellsHelper.CellNameToIndex(text2, out row, out column);
				result.EndRow = row;
				result.EndColumn = column;
			}
		}
		else
		{
			if (string_0 == null || !char.IsLetter(string_0, 0) || !char.IsDigit(string_0, string_0.Length - 1))
			{
				return smethod_13(string_0, worksheet_0);
			}
			CellsHelper.CellNameToIndex(string_0, out row, out column);
			result.StartRow = (result.EndRow = row);
			result.StartColumn = (result.EndColumn = column);
		}
		return result;
	}

	internal static int smethod_15(Cells cells_0, int int_0, int int_1, bool bool_0)
	{
		int columnWidthPixel = cells_0.GetColumnWidthPixel(int_0);
		if (columnWidthPixel > int_1)
		{
			return int_0;
		}
		int_1 -= columnWidthPixel;
		int_0++;
		do
		{
			columnWidthPixel = cells_0.GetColumnWidthPixel(int_0);
			int_1 -= columnWidthPixel;
			if (int_1 <= 0)
			{
				break;
			}
			int_0++;
		}
		while (int_0 != 255);
		if (int_1 < 0 && bool_0)
		{
			int_0--;
		}
		return int_0;
	}

	internal static int smethod_16(Worksheet worksheet_0, ArrayList arrayList_0)
	{
		return 0;
	}

	internal static int smethod_17(Worksheet worksheet_0, ArrayList arrayList_0)
	{
		return 0;
	}

	internal static int smethod_18(string string_0, Aspose.Cells.Font font_0, double double_0, int int_0)
	{
		Class1544 @class = new Class1544();
		@class.string_0 = string_0;
		@class.font_0 = font_0;
		int num = Math.Max(1, (int)((double)@class.font_0.Size * double_0));
		FontStyle fontStyle_ = (@class.font_0.IsBold ? FontStyle.Bold : FontStyle.Regular) | (@class.font_0.IsItalic ? FontStyle.Italic : FontStyle.Regular) | (@class.font_0.IsStrikeout ? FontStyle.Strikeout : FontStyle.Regular) | ((@class.font_0.Underline != 0) ? FontStyle.Underline : FontStyle.Regular);
		Class1396 class1396_ = Class1396.smethod_1(@class.font_0.Name, num, fontStyle_);
		Class463 class2 = new Class463(class1396_, Color.Black, new PointF(0f, 0f), @class.string_0, @class.font_0.IsSuperscript, @class.font_0.IsSubscript);
		if (Math.Abs(int_0) == 90)
		{
			return (int)((double)(class2.Size.Height / 72f * 96f) * double_0 + 0.9990000128746033);
		}
		return (int)((double)(class2.Size.Width / 72f * 96f) * double_0 + 0.9990000128746033);
	}

	internal static int smethod_19(string string_0, Aspose.Cells.Font font_0, double double_0)
	{
		Class1544 @class = new Class1544();
		@class.string_0 = string_0;
		@class.font_0 = font_0;
		int num = Math.Max(1, (int)((double)@class.font_0.Size * double_0));
		FontStyle fontStyle_ = (@class.font_0.IsBold ? FontStyle.Bold : FontStyle.Regular) | (@class.font_0.IsItalic ? FontStyle.Italic : FontStyle.Regular) | (@class.font_0.IsStrikeout ? FontStyle.Strikeout : FontStyle.Regular) | ((@class.font_0.Underline != 0) ? FontStyle.Underline : FontStyle.Regular);
		Class1396 class1396_ = Class1396.smethod_1(@class.font_0.Name, num, fontStyle_);
		Class463 class2 = new Class463(class1396_, Color.Black, new PointF(0f, 0f), @class.string_0, @class.font_0.IsSuperscript, @class.font_0.IsSubscript);
		return (int)((double)(class2.Size.Width / 72f * 96f) * double_0 + 0.9990000128746033);
	}

	public static SizeF smethod_20(string string_0, Aspose.Cells.Font font_0, double[] double_0)
	{
		Class1544 @class = new Class1544();
		@class.string_0 = string_0;
		@class.font_0 = font_0;
		float float_ = Math.Max(1f, @class.font_0.Size);
		FontStyle fontStyle_ = (@class.font_0.IsBold ? FontStyle.Bold : FontStyle.Regular) | (@class.font_0.IsItalic ? FontStyle.Italic : FontStyle.Regular) | (@class.font_0.IsStrikeout ? FontStyle.Strikeout : FontStyle.Regular) | ((@class.font_0.Underline != 0) ? FontStyle.Underline : FontStyle.Regular);
		Class1396 class1396_ = Class1396.smethod_1(@class.font_0.Name, float_, fontStyle_);
		Class463 class2 = new Class463(class1396_, Color.Black, new PointF(0f, 0f), @class.string_0, @class.font_0.IsSuperscript, @class.font_0.IsSubscript);
		return class2.Size;
	}

	private static Color GetColor(string string_0, Color color_0)
	{
		if (string_0 != null && string_0.Length != 0)
		{
			string_0 = string_0.ToLower();
			if (string_0.IndexOf("[red]") >= 0)
			{
				return Color.Red;
			}
			if (string_0.IndexOf("[green]") >= 0)
			{
				return Color.Green;
			}
			return color_0;
		}
		return color_0;
	}

	internal static Color smethod_21(double double_0, string string_0, Color color_0)
	{
		string[] array = string_0.Split(';');
		if (array.Length >= 1)
		{
			if (double_0 > 0.0)
			{
				return GetColor(array[0], color_0);
			}
			if (double_0 < 0.0 && array.Length >= 2)
			{
				return GetColor(array[1], color_0);
			}
			if (Math.Abs(double_0) < 1E-14 && array.Length >= 3)
			{
				return GetColor(array[2], color_0);
			}
		}
		return color_0;
	}

	internal static Color smethod_22(Style style_0, Aspose.Cells.Font font_0, Cell cell_0)
	{
		if (cell_0 != null && cell_0.Type == CellValueType.IsNumeric)
		{
			switch (style_0.Number)
			{
			default:
				return font_0.Color;
			case 6:
			case 8:
			case 38:
			case 40:
				if (!(cell_0.DoubleValue < 0.0))
				{
					return font_0.Color;
				}
				return Color.Red;
			case 0:
			{
				string custom = style_0.Custom;
				if (custom != null && !(custom == ""))
				{
					return smethod_21(cell_0.DoubleValue, style_0.Custom, font_0.Color);
				}
				return font_0.Color;
			}
			}
		}
		return font_0.Color;
	}

	internal static Color smethod_23(Style style_0)
	{
		if (style_0.Pattern == BackgroundType.None)
		{
			return Color.Empty;
		}
		return style_0.ForegroundColor;
	}

	internal static void smethod_24(Worksheet worksheet_0, ArrayList arrayList_0, ref int int_0, ref int int_1)
	{
		string printTitleColumns = worksheet_0.PageSetup.PrintTitleColumns;
		if (printTitleColumns != null)
		{
			string[] array = printTitleColumns.Split(':');
			if (array.Length != 2)
			{
				return;
			}
			if (array[0][0] == '$')
			{
				array[0] = array[0].Substring(1) + "1";
			}
			int row = 0;
			int column = 0;
			CellsHelper.CellNameToIndex(array[0], out row, out column);
			int_0 = column;
			if (array[1][0] == '$')
			{
				array[1] = array[1].Substring(1) + "1";
			}
			CellsHelper.CellNameToIndex(array[1], out row, out column);
			int_1 = column;
		}
		else
		{
			int_0 = -1;
			int_1 = -1;
		}
		int_0 = Math.Min(int_0, int_1);
		int_1 = Math.Max(int_0, int_1);
	}

	internal static void smethod_25(Worksheet worksheet_0, ArrayList arrayList_0, ref int int_0, ref int int_1)
	{
		string printTitleRows = worksheet_0.PageSetup.PrintTitleRows;
		if (printTitleRows != null)
		{
			string[] array = printTitleRows.Split(':');
			if (array.Length != 2)
			{
				return;
			}
			if (array[0][0] == '$')
			{
				array[0] = array[0].Substring(1);
			}
			int_0 = int.Parse(array[0]) - 1;
			if (array[1][0] == '$')
			{
				array[1] = array[1].Substring(1);
			}
			int_1 = int.Parse(array[1]) - 1;
		}
		else
		{
			int_0 = -1;
			int_1 = -1;
		}
		int_0 = Math.Min(int_0, int_1);
		int_1 = Math.Max(int_0, int_1);
	}

	internal static double smethod_26(int int_0, Aspose.Cells.Font font_0, double double_0)
	{
		_ = font_0.IsBold;
		_ = font_0.IsItalic;
		_ = font_0.IsStrikeout;
		_ = font_0.Underline;
		Class1460 @class = Class1462.smethod_3(font_0.Name, font_0.method_30(), bool_0: false);
		return @class.method_41(' ', font_0.Size) * 3f * (float)int_0 * (float)double_0;
	}

	internal static SizeF smethod_27(int int_0, Aspose.Cells.Font font_0, double[] double_0)
	{
		Class1460 @class = Class1462.smethod_3(font_0.Name, font_0.method_30(), bool_0: false);
		float width = @class.method_45(int_0 + " ", font_0.Size) * (float)double_0[0];
		float height = @class.method_17(font_0.Size) * (float)double_0[1];
		return new SizeF(width, height);
	}
}
