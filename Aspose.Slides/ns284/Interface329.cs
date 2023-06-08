using System;
using System.Drawing;

namespace ns284;

internal interface Interface329 : ICloneable
{
	FontStyle FontStyle { get; set; }

	float FontSize { get; set; }

	int FontLarger { get; set; }

	string FontFamilyName { get; set; }

	bool IsTextOverlined { get; set; }

	float CharSpace { get; set; }

	Color Color { get; set; }

	Color BackgroundColor { get; set; }

	Color FirstLineColor { get; set; }

	Color FirstLetterColor { get; set; }

	Enum952 Display { get; set; }

	Enum953 Overflow { get; set; }

	Enum954 Float { get; set; }

	Enum956 Position { get; set; }

	Enum935 Clear { get; set; }

	Rectangle Clip { get; set; }

	Class6959 Left { get; set; }

	Class6959 Top { get; set; }

	Class6959 Bottom { get; set; }

	Class6959 Right { get; set; }

	int ZIndex { get; set; }

	Class6959 Width { get; set; }

	Class6959 Height { get; set; }

	Class6959 PaddingLeft { get; set; }

	Class6959 PaddingRight { get; set; }

	Class6959 PaddingTop { get; set; }

	Class6959 PaddingBottom { get; set; }

	Class6959 MarginLeft { get; set; }

	Class6959 MarginRight { get; set; }

	Class6959 MarginTop { get; set; }

	Class6959 MarginBottom { get; set; }

	Class6959 BorderWidthLeft { get; set; }

	Class6959 BorderWidthRight { get; set; }

	Class6959 BorderWidthTop { get; set; }

	Class6959 BorderWidthBottom { get; set; }

	Class6959 BorderTableWidthLeft { get; set; }

	Class6959 BorderTableWidthRight { get; set; }

	Class6959 BorderTableWidthTop { get; set; }

	Class6959 BorderTableWidthBottom { get; set; }

	Enum957 TextAlign { get; set; }

	Enum958 TextVAlign { get; set; }

	Enum959 WhiteSpace { get; set; }

	Enum948 Align { get; set; }

	Enum940 TextTransform { get; set; }

	Class6959 TextIndent { get; set; }

	Class6959 WordSpacing { get; set; }

	Enum951 BorderStyleTop { get; set; }

	Enum951 BorderStyleRight { get; set; }

	Enum951 BorderStyleBottom { get; set; }

	Enum951 BorderStyleLeft { get; set; }

	Enum951 BorderTableStyleTop { get; set; }

	Enum951 BorderTableStyleRight { get; set; }

	Enum951 BorderTableStyleBottom { get; set; }

	Enum951 BorderTableStyleLeft { get; set; }

	Color BorderColorTop { get; set; }

	Color BorderColorRight { get; set; }

	Color BorderColorBottom { get; set; }

	Color BorderColorLeft { get; set; }

	Color BorderTableColorTop { get; set; }

	Color BorderTableColorRight { get; set; }

	Color BorderTableColorBottom { get; set; }

	Color BorderTableColorLeft { get; set; }

	float LineSpacing { get; set; }

	float LineHeight { get; set; }

	Enum939 TableLayout { get; set; }

	int Colspan { get; set; }

	string Content { get; set; }

	int Rowspan { get; set; }

	Enum933 BorderCollapse { get; set; }

	Enum937 EmptyCells { get; set; }

	Class6959 BorderSpacingHorisontal { get; set; }

	Class6959 BorderSpacingVertical { get; set; }

	Class6959 CellPadding { get; set; }

	int ListStyle { get; set; }

	Enum938 ListStylePosition { get; set; }

	Class6959 CounterValue { get; set; }

	int CounterIncrementValue { get; set; }

	bool IsBordered { get; set; }

	string BackgroundImage { get; set; }

	Enum936 Direction { get; set; }

	Enum950 PageBreakBefore { get; set; }

	Enum950 PageBreakAfter { get; set; }

	Enum950 PageBreakInside { get; set; }

	int Orphans { get; set; }

	int Windows { get; set; }

	bool TextWrapType { get; set; }

	Class6959 PageFirstMarginLeft { get; set; }

	Class6959 PageFirstMarginRight { get; set; }

	Class6959 PageFirstMarginTop { get; set; }

	Class6959 PageFirstMarginBottom { get; set; }

	Class6959 PageLeftMarginTop { get; set; }

	Class6959 PageLeftMarginBottom { get; set; }

	Class6959 PageLeftMarginLeft { get; set; }

	Class6959 PageLeftMarginRight { get; set; }

	Class6959 PageRightMarginTop { get; set; }

	Class6959 PageRightMarginBottom { get; set; }

	Class6959 PageRightMarginLeft { get; set; }

	Class6959 PageRightMarginRight { get; set; }

	Enum960 Visibility { get; set; }

	Interface329 Before { get; set; }

	Interface329 After { get; set; }

	Interface329 imethod_0(string tagName);
}
