using Aspose.Cells;
using ns2;

namespace ns26;

internal class Class1099
{
	internal string string_0;

	internal PaperSizeType paperSizeType_0 = PaperSizeType.PaperA4;

	internal double double_0;

	internal double double_1;

	internal int int_0;

	internal PageOrientationType pageOrientationType_0 = PageOrientationType.Portrait;

	internal double double_2 = 0.7874;

	internal double double_3 = 0.7874;

	internal double double_4 = 0.7874;

	internal double double_5 = 0.7874;

	internal double double_6 = 0.2953;

	internal double double_7 = 0.2953;

	internal double double_8 = 0.0984;

	internal double double_9 = 0.0984;

	internal int int_1 = -1;

	internal bool bool_0 = true;

	internal bool bool_1 = true;

	internal double double_10 = 100.0;

	internal double double_11;

	internal double double_12;

	internal bool bool_2;

	internal bool bool_3;

	internal PrintOrderType printOrderType_0;

	internal bool bool_4;

	internal bool bool_5;

	internal bool bool_6;

	internal bool bool_7;

	internal void method_0()
	{
		if (pageOrientationType_0 == PageOrientationType.Landscape)
		{
			paperSizeType_0 = Class1677.smethod_2(double_1, double_0);
		}
		else
		{
			paperSizeType_0 = Class1677.smethod_2(double_0, double_1);
		}
	}

	internal void method_1(PageSetup pageSetup_0)
	{
		if (bool_1)
		{
			pageSetup_0.Zoom = (int)double_10;
		}
		else
		{
			pageSetup_0.FitToPagesWide = (int)double_12;
			pageSetup_0.FitToPagesTall = (int)double_11;
		}
		pageSetup_0.PaperSize = paperSizeType_0;
		pageSetup_0.Orientation = pageOrientationType_0;
		pageSetup_0.Order = printOrderType_0;
		pageSetup_0.CenterHorizontally = bool_2;
		pageSetup_0.CenterVertically = bool_3;
		pageSetup_0.LeftMarginInch = double_3;
		pageSetup_0.RightMarginInch = double_5;
		pageSetup_0.HeaderMarginInch = double_2;
		pageSetup_0.FooterMarginInch = double_4;
		pageSetup_0.TopMarginInch = double_2 + double_6;
		pageSetup_0.BottomMarginInch = double_4 + double_7;
		pageSetup_0.PrintDraft = bool_6;
		if (!bool_0)
		{
			pageSetup_0.FirstPageNumber = int_1;
		}
		pageSetup_0.PrintComments = ((!bool_7) ? PrintCommentsType.PrintNoComments : PrintCommentsType.PrintInPlace);
		pageSetup_0.PrintGridlines = bool_5;
		pageSetup_0.PrintHeadings = bool_4;
	}
}
