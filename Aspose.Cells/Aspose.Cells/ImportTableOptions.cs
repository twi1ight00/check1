namespace Aspose.Cells;

public class ImportTableOptions
{
	private bool bool_0;

	private bool bool_1 = true;

	private bool bool_2 = true;

	private string string_0;

	private string[] string_1;

	private int int_0 = -1;

	private int int_1 = -1;

	private int[] int_2;

	private object[] object_0;

	public bool ConvertNumericData
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

	public bool InsertRows
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

	public bool IsFieldNameShown
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

	public string DateFormat
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public string[] NumberFormats
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public int TotalRows
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public int TotalColumns
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public int[] ColumnIndexes
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public object[] DefaultValues
	{
		get
		{
			return object_0;
		}
		set
		{
			object_0 = value;
		}
	}

	internal object method_0(int int_3)
	{
		if (object_0 != null && int_3 < object_0.Length)
		{
			return object_0[int_3];
		}
		return null;
	}
}
