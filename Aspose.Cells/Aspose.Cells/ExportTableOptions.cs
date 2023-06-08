namespace Aspose.Cells;

/// <summary>
///       Represents all export table options.
///       </summary>
public class ExportTableOptions
{
	private bool bool_0;

	private bool bool_1;

	/// <summary>
	///       Indicates whether the data in the first row are exported to the column name of the DataTable.
	///       The default value is false.
	///       </summary>
	public bool ExportColumnName
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
	///       Indicates whether skip invalid value for the column.
	///        For example,if the column type is decimal ,the value is greater than decimal.MaxValue 
	///        and this property is true,we will not throw exception again.
	///        The default value is false.
	///        </summary>
	public bool SkipErrorValue
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
