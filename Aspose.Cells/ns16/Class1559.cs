using Aspose.Cells.Charts;

namespace ns16;

internal class Class1559
{
	internal string string_0;

	internal string string_1;

	internal string string_2;

	internal string string_3;

	internal string string_4;

	internal string string_5;

	internal string string_6;

	internal string string_7;

	internal string string_8;

	internal void method_0(Chart chart_0, Title title_0)
	{
		if (string_0 == "inner")
		{
			title_0.IsInnerMode = true;
		}
		if ((string_1 != null && !(string_1 == "factor")) || (string_2 != null && !(string_2 == "factor")))
		{
			if (string_1 == "edge" && string_2 == "edge")
			{
				title_0.IsAutoSize = false;
				if (string_5 != null)
				{
					title_0.method_22((int)(Class1618.smethod_85(string_5) * 4000.0 + 0.5));
					title_0.method_19(bool_5: false);
					title_0.method_2(bool_5: true);
				}
				if (string_6 != null)
				{
					title_0.method_24((int)(Class1618.smethod_85(string_6) * 4000.0 + 0.5));
					title_0.method_21(bool_5: false);
					title_0.method_4(bool_5: true);
				}
			}
		}
		else
		{
			if (string_5 != null)
			{
				title_0.method_22((int)(Class1618.smethod_85(string_5) * 4000.0 + 0.5));
				title_0.method_19(bool_5: false);
				title_0.method_2(bool_5: false);
			}
			if (string_6 != null)
			{
				title_0.method_24((int)(Class1618.smethod_85(string_6) * 4000.0 + 0.5));
				title_0.method_21(bool_5: false);
				title_0.method_4(bool_5: false);
			}
		}
	}

	internal void method_1(Chart chart_0)
	{
		PlotArea plotArea = chart_0.PlotArea;
		if (string_0 != "inner")
		{
			if (string_1 == "edge" && string_5 != null)
			{
				plotArea.method_22((int)(Class1618.smethod_85(string_5) * 4000.0 + 0.5));
				plotArea.method_19(bool_5: false);
				plotArea.method_2(bool_5: true);
			}
			if (string_2 == "edge" && string_6 != null)
			{
				plotArea.method_24((int)(Class1618.smethod_85(string_6) * 4000.0 + 0.5));
				plotArea.method_21(bool_5: false);
				plotArea.method_4(bool_5: true);
			}
			if ((string_3 == null || string_3 == "factor") && string_7 != null)
			{
				plotArea.Width = (int)(4000.0 * Class1618.smethod_85(string_7) + 0.5);
				plotArea.method_5(bool_5: false);
			}
			if ((string_4 == null || string_4 == "factor") && string_8 != null)
			{
				plotArea.Height = (int)(4000.0 * Class1618.smethod_85(string_8) + 0.5);
				plotArea.method_6(bool_5: false);
			}
		}
		else
		{
			if (string_1 == "edge" && string_5 != null)
			{
				plotArea.int_12 = (int)(Class1618.smethod_85(string_5) * 4000.0 + 0.5);
				plotArea.method_19(bool_5: false);
				plotArea.method_2(bool_5: true);
			}
			if (string_2 == "edge" && string_6 != null)
			{
				plotArea.int_13 = (int)(Class1618.smethod_85(string_6) * 4000.0 + 0.5);
				plotArea.method_21(bool_5: false);
				plotArea.method_4(bool_5: true);
			}
			if ((string_3 == null || string_3 == "factor") && string_7 != null)
			{
				plotArea.InnerWidth = (int)(4000.0 * Class1618.smethod_85(string_7) + 0.5);
				plotArea.method_5(bool_5: false);
			}
			if ((string_4 == null || string_4 == "factor") && string_8 != null)
			{
				plotArea.InnerHeight = (int)(4000.0 * Class1618.smethod_85(string_8) + 0.5);
				plotArea.method_6(bool_5: false);
			}
		}
		chart_0.method_11((byte)(chart_0.method_10() | 0x18u));
	}

	internal void method_2(Chart chart_0, Legend legend_0)
	{
		if (string_0 == "inner")
		{
			legend_0.IsInnerMode = true;
		}
		if (string_1 == "edge" && string_5 != null)
		{
			legend_0.method_22((int)(Class1618.smethod_85(string_5) * 4000.0 + 0.5));
			legend_0.method_19(bool_5: false);
			legend_0.method_2(bool_5: true);
		}
		if (string_2 == "edge" && string_6 != null)
		{
			legend_0.method_24((int)(Class1618.smethod_85(string_6) * 4000.0 + 0.5));
			legend_0.method_21(bool_5: false);
			legend_0.method_4(bool_5: true);
		}
		if ((string_3 == null || string_3 == "factor") && string_7 != null)
		{
			legend_0.Width = (int)(Class1618.smethod_85(string_7) * 4000.0 + 0.5);
			legend_0.method_5(bool_5: false);
		}
		if ((string_4 == null || string_4 == "factor") && string_8 != null)
		{
			legend_0.Height = (int)(Class1618.smethod_85(string_8) * 4000.0 + 0.5);
			legend_0.method_6(bool_5: false);
		}
	}

	internal void method_3(Chart chart_0, DataLabels dataLabels_0)
	{
		if ((string_1 == null || string_1 == "factor") && string_5 != null)
		{
			dataLabels_0.OffsetX = (int)(Class1618.smethod_85(string_5) * 4000.0 + 0.5);
			dataLabels_0.method_19(bool_5: false);
			dataLabels_0.method_2(bool_5: false);
		}
		if ((string_2 == null || string_2 == "factor") && string_6 != null)
		{
			dataLabels_0.OffsetY = (int)(Class1618.smethod_85(string_6) * 4000.0 + 0.5);
			dataLabels_0.method_21(bool_5: false);
			dataLabels_0.method_4(bool_5: false);
		}
		dataLabels_0.method_67(LabelPositionType.Moved);
	}

	internal void method_4(Chart chart_0, DisplayUnitLabel displayUnitLabel_0)
	{
		if (string_0 == "inner")
		{
			displayUnitLabel_0.IsInnerMode = true;
		}
		if (string_1 == "edge" && string_5 != null)
		{
			displayUnitLabel_0.method_22((int)(Class1618.smethod_85(string_5) * 4000.0 + 0.5));
			displayUnitLabel_0.method_19(bool_5: false);
			displayUnitLabel_0.method_2(bool_5: true);
		}
		if (string_2 == "edge" && string_6 != null)
		{
			displayUnitLabel_0.method_24((int)(Class1618.smethod_85(string_6) * 4000.0 + 0.5));
			displayUnitLabel_0.method_21(bool_5: false);
			displayUnitLabel_0.method_4(bool_5: true);
		}
	}
}
