namespace Aspose.Cells;

/// <summary>
///       Represents all auto fitter options.
///       </summary>
public class AutoFitterOptions
{
	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	internal bool bool_3 = true;

	/// <summary>
	///       Indicates whether auto fit row height when the cells is merged in a row.
	///       The default value is false.
	///       </summary>
	/// <remarks>
	///       If the cells in merged in a row and auto fit the rows in MS Excel,
	///       MS Excel do not expand the row height.
	///       If this option is true, Aspose.Cells will expand the row height to fit the cells' data.
	///       </remarks>
	public bool AutoFitMergedCells
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
	///       Indicates whether only fit the rows which height are not customed.
	///       </summary>
	public bool OnlyAuto
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

	/// <summary>
	///       Ingored the hidden rows.
	///       </summary>
	public bool IgnoreHidden
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}
}
