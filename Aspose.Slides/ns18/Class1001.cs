using ns16;
using ns4;
using ns56;

namespace ns18;

internal class Class1001
{
	public static void smethod_0(Class144 style, Class1942 tableStyleElementData, Class1341 deserializationContext)
	{
		if (tableStyleElementData != null)
		{
			Class996.smethod_0(style.TblBackgroundStyle, tableStyleElementData.TblBg, deserializationContext);
			if (tableStyleElementData.WholeTbl != null)
			{
				Class998.smethod_0(style.WholeTbl, tableStyleElementData.WholeTbl.TcStyle, deserializationContext);
				Class997.smethod_0(style.WholeTblText, tableStyleElementData.WholeTbl.TcTxStyle);
			}
			if (tableStyleElementData.Band1H != null)
			{
				Class998.smethod_0(style.Band1H, tableStyleElementData.Band1H.TcStyle, deserializationContext);
				Class997.smethod_0(style.Band1HText, tableStyleElementData.Band1H.TcTxStyle);
			}
			if (tableStyleElementData.Band2H != null)
			{
				Class998.smethod_0(style.Band2H, tableStyleElementData.Band2H.TcStyle, deserializationContext);
				Class997.smethod_0(style.Band2HText, tableStyleElementData.Band2H.TcTxStyle);
			}
			if (tableStyleElementData.Band1V != null)
			{
				Class998.smethod_0(style.Band1V, tableStyleElementData.Band1V.TcStyle, deserializationContext);
				Class997.smethod_0(style.Band1VText, tableStyleElementData.Band1V.TcTxStyle);
			}
			if (tableStyleElementData.Band2V != null)
			{
				Class998.smethod_0(style.Band2V, tableStyleElementData.Band2V.TcStyle, deserializationContext);
				Class997.smethod_0(style.Band2VText, tableStyleElementData.Band2V.TcTxStyle);
			}
			if (tableStyleElementData.LastCol != null)
			{
				Class998.smethod_0(style.LastCol, tableStyleElementData.LastCol.TcStyle, deserializationContext);
				Class997.smethod_0(style.LastColText, tableStyleElementData.LastCol.TcTxStyle);
			}
			if (tableStyleElementData.FirstCol != null)
			{
				Class998.smethod_0(style.FirstCol, tableStyleElementData.FirstCol.TcStyle, deserializationContext);
				Class997.smethod_0(style.FirstColText, tableStyleElementData.FirstCol.TcTxStyle);
			}
			if (tableStyleElementData.LastRow != null)
			{
				Class998.smethod_0(style.LastRow, tableStyleElementData.LastRow.TcStyle, deserializationContext);
				Class997.smethod_0(style.LastRowText, tableStyleElementData.LastRow.TcTxStyle);
			}
			if (tableStyleElementData.SeCell != null)
			{
				Class998.smethod_0(style.SeCell, tableStyleElementData.SeCell.TcStyle, deserializationContext);
				Class997.smethod_0(style.SeCellText, tableStyleElementData.SeCell.TcTxStyle);
			}
			if (tableStyleElementData.SwCell != null)
			{
				Class998.smethod_0(style.SwCell, tableStyleElementData.SwCell.TcStyle, deserializationContext);
				Class997.smethod_0(style.SwCellText, tableStyleElementData.SwCell.TcTxStyle);
			}
			if (tableStyleElementData.FirstRow != null)
			{
				Class998.smethod_0(style.FirstRow, tableStyleElementData.FirstRow.TcStyle, deserializationContext);
				Class997.smethod_0(style.FirstRowText, tableStyleElementData.FirstRow.TcTxStyle);
			}
			if (tableStyleElementData.NeCell != null)
			{
				Class998.smethod_0(style.NeCell, tableStyleElementData.NeCell.TcStyle, deserializationContext);
				Class997.smethod_0(style.NeCellText, tableStyleElementData.NeCell.TcTxStyle);
			}
			if (tableStyleElementData.NwCell != null)
			{
				Class998.smethod_0(style.NwCell, tableStyleElementData.NwCell.TcStyle, deserializationContext);
				Class997.smethod_0(style.NwCellText, tableStyleElementData.NwCell.TcTxStyle);
			}
			style.PPTXUnsupportedProps.ExtensionList = tableStyleElementData.ExtLst;
		}
	}

	public static void smethod_1(Class144 style, Class1942.Delegate1693 addTblStyle, Class1346 serializationContext)
	{
		Class1942 tableStyleElementData = addTblStyle();
		smethod_2(style, tableStyleElementData, serializationContext);
	}

	public static void smethod_2(Class144 style, Class1942 tableStyleElementData, Class1346 serializationContext)
	{
		tableStyleElementData.StyleId = style.PPTXUnsupportedProps.Id;
		tableStyleElementData.StyleName = style.PPTXUnsupportedProps.Name;
		Class996.smethod_1(style.TblBackgroundStyle, tableStyleElementData.delegate1663_0, serializationContext);
		smethod_3(style.WholeTblText, style.WholeTbl, tableStyleElementData.delegate1681_0, serializationContext);
		smethod_3(style.Band1HText, style.Band1H, tableStyleElementData.delegate1681_1, serializationContext);
		smethod_3(style.Band2HText, style.Band2H, tableStyleElementData.delegate1681_2, serializationContext);
		smethod_3(style.Band1VText, style.Band1V, tableStyleElementData.delegate1681_3, serializationContext);
		smethod_3(style.Band2VText, style.Band2V, tableStyleElementData.delegate1681_4, serializationContext);
		smethod_3(style.LastColText, style.LastCol, tableStyleElementData.delegate1681_5, serializationContext);
		smethod_3(style.FirstColText, style.FirstCol, tableStyleElementData.delegate1681_6, serializationContext);
		smethod_3(style.LastRowText, style.LastRow, tableStyleElementData.delegate1681_7, serializationContext);
		smethod_3(style.SeCellText, style.SeCell, tableStyleElementData.delegate1681_8, serializationContext);
		smethod_3(style.SwCellText, style.SwCell, tableStyleElementData.delegate1681_9, serializationContext);
		smethod_3(style.FirstRowText, style.FirstRow, tableStyleElementData.delegate1681_10, serializationContext);
		smethod_3(style.NeCellText, style.NeCell, tableStyleElementData.delegate1681_11, serializationContext);
		smethod_3(style.NwCellText, style.NwCell, tableStyleElementData.delegate1681_12, serializationContext);
		tableStyleElementData.delegate1535_0(style.PPTXUnsupportedProps.ExtensionList);
	}

	private static void smethod_3(Class142 cellTextStyle, Class143 partStyle, Class1938.Delegate1681 addPartStyle, Class1346 serializationContext)
	{
		if (cellTextStyle.NeedElement || partStyle.NeedElement)
		{
			Class1938 @class = addPartStyle();
			Class998.smethod_1(partStyle, @class.delegate1690_0, serializationContext);
			Class997.smethod_1(cellTextStyle, @class.delegate1696_0);
		}
	}
}
