namespace Aspose.Cells;

/// <summary>
///       Represents the directory  type of the file name.
///       </summary>
public enum DirectoryType
{
	/// <summary>
	///       Represents an MS-DOS drive letter. It is followed by the drive letter.
	///       Or UNC file names, such as \\server\share\myfile.xls
	///       </summary>
	Volume,
	/// <summary>
	///       Indicates that the source workbook is on the same drive as the dependent workbook (the drive letter is omitted)
	///       </summary>
	SameVolume,
	/// <summary>
	///       Indicates that the source workbook is in a subdirectory of the current directory.
	///       </summary>
	DownDirectory,
	/// <summary>
	///       Indicates that the source workbook is in the parent directory of the current directory.
	///       </summary>
	UpDirectory
}
