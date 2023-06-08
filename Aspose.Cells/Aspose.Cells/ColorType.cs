namespace Aspose.Cells;

/// <summary>
///       Indicates all color type 
///       </summary>
public enum ColorType
{
	/// <summary>
	///       Automatic color.
	///       </summary>
	Automatic,
	/// <summary>
	///       It's automaic color,but the displayed color depends the setting of the OS System.
	///       </summary>
	/// <remarks>
	///       Not supported.
	///       </remarks>
	AutomaticIndex,
	/// <summary>
	///       The RGB color.
	///       </summary>
	RGB,
	/// <summary>
	///       The color index in the color palette.
	///       </summary>
	IndexedColor,
	/// <summary>
	///       The theme color.
	///       </summary>
	Theme
}
