namespace Aspose.Cells;

/// <summary>
///       Represents the paste special options.
///       </summary>
public class PasteOptions
{
	private PasteType pasteType_0;

	private bool bool_0;

	private bool bool_1;

	/// <summary>
	///       The paste special type.
	///       </summary>
	public PasteType PasteType
	{
		get
		{
			return pasteType_0;
		}
		set
		{
			pasteType_0 = value;
		}
	}

	/// <summary>
	///       Indicates whether skips blank cells.
	///       </summary>
	public bool SkipBlanks
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	/// <summary>
	///        True to transpose rows and columns when the range is pasted. The default value is False.
	///       </summary>
	public bool Transpose
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}
}
