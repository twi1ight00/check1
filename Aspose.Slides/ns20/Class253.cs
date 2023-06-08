using ns34;
using ns56;

namespace ns20;

internal class Class253
{
	public static void smethod_0(Class736 cellFormat, Class1750 cellXfsElementData)
	{
		if (cellXfsElementData != null)
		{
			cellFormat.ApplyAlignment = cellXfsElementData.ApplyAlignment;
			cellFormat.ApplyBorder = cellXfsElementData.ApplyBorder;
			cellFormat.ApplyFill = cellXfsElementData.ApplyFill;
			cellFormat.ApplyFont = cellXfsElementData.ApplyFont;
			cellFormat.ApplyNumberFormat = cellXfsElementData.ApplyNumberFormat;
			cellFormat.ApplyProtection = cellXfsElementData.ApplyProtection;
			cellFormat.BorderId = cellXfsElementData.BorderId;
			cellFormat.FillId = cellXfsElementData.FillId;
			cellFormat.FontId = cellXfsElementData.FontId;
			cellFormat.NumFmtId = cellXfsElementData.NumFmtId;
			cellFormat.PivotButton = cellXfsElementData.PivotButton;
			cellFormat.QuotePrefix = cellXfsElementData.QuotePrefix;
			cellFormat.XfId = cellXfsElementData.XfId;
			cellFormat.Alignment = cellXfsElementData.Alignment;
			cellFormat.Protection = cellXfsElementData.Protection;
			cellFormat.ExtLst = cellXfsElementData.ExtLst;
		}
	}

	public static void smethod_1(Class736 cellFormat, Class1750 cellXfsElementData)
	{
		if (cellFormat != null)
		{
			cellXfsElementData.ApplyAlignment = cellFormat.ApplyAlignment;
			cellXfsElementData.ApplyBorder = cellFormat.ApplyBorder;
			cellXfsElementData.ApplyFill = cellFormat.ApplyFill;
			cellXfsElementData.ApplyFont = cellFormat.ApplyFont;
			cellXfsElementData.ApplyNumberFormat = cellFormat.ApplyNumberFormat;
			cellXfsElementData.ApplyProtection = cellFormat.ApplyProtection;
			cellXfsElementData.BorderId = cellFormat.BorderId;
			cellXfsElementData.FillId = cellFormat.FillId;
			cellXfsElementData.FontId = cellFormat.FontId;
			cellXfsElementData.NumFmtId = cellFormat.NumFmtId;
			cellXfsElementData.PivotButton = cellFormat.PivotButton;
			cellXfsElementData.QuotePrefix = cellFormat.QuotePrefix;
			cellXfsElementData.XfId = cellFormat.XfId;
			cellXfsElementData.delegate143_0(cellFormat.Alignment);
			cellXfsElementData.delegate152_0(cellFormat.Protection);
			cellXfsElementData.delegate387_0(cellFormat.ExtLst);
		}
	}
}
