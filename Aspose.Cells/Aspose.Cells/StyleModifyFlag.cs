using System;
using System.ComponentModel;

namespace Aspose.Cells;

/// <summary>
///       The style mofied flags.
///       </summary>
public enum StyleModifyFlag
{
	/// <summary>
	/// </summary>
	All,
	/// <summary>
	/// </summary>
	Borders,
	/// <summary>
	/// </summary>
	LeftBorder,
	/// <summary>
	/// </summary>
	RightBorder,
	/// <summary>
	/// </summary>
	TopBorder,
	/// <summary>
	/// </summary>
	BottomBorder,
	/// <summary>
	///       Only for dynamic style,such as conditional formatting.
	///       </summary>
	HorizontalBorder,
	/// <summary>
	///       Only for dynamic style,such as conditional formatting.
	///       </summary>
	VerticalBorder,
	/// <summary>
	/// </summary>
	Diagonal,
	/// <summary>
	/// </summary>
	DiagonalDownBorder,
	/// <summary>
	/// </summary>
	DiagonalUpBorder,
	/// <summary>
	/// </summary>
	Font,
	/// <summary>
	/// </summary>
	FontSize,
	/// <summary>
	/// </summary>
	FontName,
	/// <summary>
	/// </summary>
	FontFamily,
	/// <summary>
	/// </summary>
	FontCharset,
	/// <summary>
	/// </summary>
	FontColor,
	/// <summary>
	/// </summary>
	FontWeight,
	/// <summary>
	/// </summary>
	FontItalic,
	/// <summary>
	/// </summary>
	FontUnderline,
	/// <summary>
	/// </summary>
	FontStrike,
	/// <summary>
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use FontScript instead.")]
	FontSubscript,
	/// <summary>
	/// </summary>
	[Browsable(false)]
	[Obsolete("Use FontScript instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	FontSuperscript,
	/// <summary>
	/// </summary>
	FontScript,
	/// <summary>
	/// </summary>
	NumberFormat,
	/// <summary>
	/// </summary>
	HorizontalAlignment,
	/// <summary>
	/// </summary>
	VerticalAlignment,
	/// <summary>
	/// </summary>
	Indent,
	/// <summary>
	/// </summary>
	Rotation,
	/// <summary>
	/// </summary>
	WrapText,
	/// <summary>
	/// </summary>
	ShrinkToFit,
	/// <summary>
	/// </summary>
	TextDirection,
	/// <summary>
	/// </summary>
	CellShading,
	/// <summary>
	/// </summary>
	Pattern,
	/// <summary>
	/// </summary>
	ForegroundColor,
	/// <summary>
	/// </summary>
	BackgroundColor,
	/// <summary>
	/// </summary>
	Locked,
	/// <summary>
	/// </summary>
	HideFormula,
	/// <summary>
	///       Includes horizontal/vertical Alignment, rotation,wrap Text,indent,shrinkToFit,Text Direction 
	///       </summary>
	AlignmentSettings,
	FontScheme,
	FontShadow,
	FontCondense,
	FontExtend
}
