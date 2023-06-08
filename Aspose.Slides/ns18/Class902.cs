using Aspose.Slides;
using ns16;
using ns24;
using ns56;

namespace ns18;

internal class Class902
{
	public static void smethod_0(ICell cell, Class1934 cellElementData, int rowIndex, int rowCount, int columnIndex, int columnCount, Class1341 deserializationContext)
	{
		if (cellElementData != null)
		{
			Class305 pPTXUnsupportedProps = ((Cell)cell).PPTXUnsupportedProps;
			Class1002.smethod_0(cell.TextFrame, cellElementData.TxBody, deserializationContext);
			Class1935 tcPr = cellElementData.TcPr;
			if (tcPr != null)
			{
				Class968.smethod_0(cell.BorderLeft, tcPr.LnL);
				Class968.smethod_0(cell.BorderTop, tcPr.LnT);
				Class968.smethod_0(cell.BorderDiagonalDown, tcPr.LnTlToBr);
				Class968.smethod_0(cell.BorderDiagonalUp, tcPr.LnBlToTr);
				Class968.smethod_0(cell.BorderRight, tcPr.LnR);
				Class968.smethod_0(cell.BorderBottom, tcPr.LnB);
				Class949.smethod_0(cell.FillFormat, tcPr.FillProperties, deserializationContext);
				cell.MarginLeft = tcPr.MarL;
				cell.MarginRight = tcPr.MarR;
				cell.MarginTop = tcPr.MarT;
				cell.MarginBottom = tcPr.MarB;
				cell.TextVerticalType = ((tcPr.Vert != TextVerticalType.NotDefined) ? tcPr.Vert : TextVerticalType.Horizontal);
				cell.TextAnchorType = ((tcPr.Anchor != TextAnchorType.NotDefined) ? tcPr.Anchor : TextAnchorType.Top);
				cell.AnchorCenter = tcPr.AnchorCtr;
				pPTXUnsupportedProps.TextHorizontalOverflow = tcPr.HorzOverflow;
				pPTXUnsupportedProps.Cell3D = tcPr.Cell3D;
				pPTXUnsupportedProps.ExtensionListOfCellProperties = tcPr.ExtLst;
			}
			pPTXUnsupportedProps.ExtensionList = cellElementData.ExtLst;
		}
	}

	public static void smethod_1(ICell cell, Class1934.Delegate1669 addTc, Class1346 serializationContext)
	{
		Class1934 @class = addTc();
		Cell cell2 = (Cell)cell;
		Class305 pPTXUnsupportedProps = cell2.PPTXUnsupportedProps;
		Class1002.smethod_1(cell.TextFrame, @class.delegate1705_0, serializationContext);
		Cell mergedTo = cell2.MergedTo;
		if (mergedTo == null && (!cell.BorderLeft.IsFormatNotDefined || !cell.BorderRight.IsFormatNotDefined || !cell.BorderTop.IsFormatNotDefined || !cell.BorderBottom.IsFormatNotDefined || !cell.BorderDiagonalDown.IsFormatNotDefined || !cell.BorderDiagonalUp.IsFormatNotDefined || cell.FillFormat.FillType != FillType.NotDefined || cell.MarginLeft != 7.2 || cell.MarginRight != 7.2 || cell.MarginTop != 3.6 || cell.MarginBottom != 3.6 || cell.TextVerticalType != 0 || cell.TextAnchorType != 0 || cell.AnchorCenter))
		{
			cell2.method_6();
			Class1935 class2 = @class.delegate1672_0();
			Class968.smethod_1(cell.BorderLeft, class2.delegate1504_0);
			Class968.smethod_1(cell.BorderRight, class2.delegate1504_1);
			Class968.smethod_1(cell.BorderTop, class2.delegate1504_2);
			Class968.smethod_1(cell.BorderBottom, class2.delegate1504_3);
			Class968.smethod_1(cell.BorderDiagonalDown, class2.delegate1504_4);
			Class968.smethod_1(cell.BorderDiagonalUp, class2.delegate1504_5);
			Class949.smethod_1(cell.FillFormat, class2.delegate2773_0, serializationContext);
			class2.MarL = cell.MarginLeft;
			class2.MarR = cell.MarginRight;
			class2.MarT = cell.MarginTop;
			class2.MarB = cell.MarginBottom;
			class2.Vert = cell.TextVerticalType;
			class2.Anchor = cell.TextAnchorType;
			class2.AnchorCtr = cell.AnchorCenter;
			class2.HorzOverflow = pPTXUnsupportedProps.TextHorizontalOverflow;
			class2.delegate304_0(pPTXUnsupportedProps.Cell3D);
			class2.delegate1535_0(pPTXUnsupportedProps.ExtensionListOfCellProperties);
		}
		else
		{
			@class.delegate1672_0();
		}
		if (mergedTo != null)
		{
			if (mergedTo.ParentColumnInternal.ColumnIndex != cell2.ParentColumnInternal.ColumnIndex)
			{
				@class.HMerge = true;
			}
			else
			{
				@class.GridSpan = mergedTo.ColSpan;
			}
			if (mergedTo.ParentRowInternal.RowIndex != cell2.ParentRowInternal.RowIndex)
			{
				@class.VMerge = true;
			}
			else
			{
				@class.RowSpan = mergedTo.RowSpan;
			}
		}
		else
		{
			@class.GridSpan = cell.ColSpan;
			@class.RowSpan = cell.RowSpan;
		}
		@class.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
	}
}
