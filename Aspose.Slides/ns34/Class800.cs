using ns56;

namespace ns34;

internal class Class800 : Class798
{
	private uint uint_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private Enum247 enum247_0;

	private uint uint_1;

	private bool bool_0;

	private bool bool_1;

	private uint uint_2;

	private bool bool_2;

	private bool bool_3;

	private uint uint_3;

	private uint uint_4;

	private uint uint_5;

	private uint uint_6;

	private uint uint_7;

	private uint uint_8;

	private string string_3;

	private string string_4;

	private string string_5;

	private uint uint_9;

	private Class1371 class1371_0;

	private Class1706 class1706_0;

	private Class1712 class1712_0;

	private Class1720 class1720_0;

	private Class1502 class1502_0;

	public uint Id
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public string Name
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

	public string DisplayName
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

	public string Comment
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public Enum247 TableType
	{
		get
		{
			return enum247_0;
		}
		set
		{
			enum247_0 = value;
		}
	}

	public uint HeaderRowCount
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	public bool InsertRow
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

	public bool InsertRowShift
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

	public uint TotalsRowCount
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
		}
	}

	public bool TotalsRowShown
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

	public bool Published
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public uint HeaderRowDxfId
	{
		get
		{
			return uint_3;
		}
		set
		{
			uint_3 = value;
		}
	}

	public uint DataDxfId
	{
		get
		{
			return uint_4;
		}
		set
		{
			uint_4 = value;
		}
	}

	public uint TotalsRowDxfId
	{
		get
		{
			return uint_5;
		}
		set
		{
			uint_5 = value;
		}
	}

	public uint HeaderRowBorderDxfId
	{
		get
		{
			return uint_6;
		}
		set
		{
			uint_6 = value;
		}
	}

	public uint TableBorderDxfId
	{
		get
		{
			return uint_7;
		}
		set
		{
			uint_7 = value;
		}
	}

	public uint TotalsRowBorderDxfId
	{
		get
		{
			return uint_8;
		}
		set
		{
			uint_8 = value;
		}
	}

	public string HeaderRowCellStyle
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public string DataCellStyle
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	public string TotalsRowCellStyle
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	public uint ConnectionId
	{
		get
		{
			return uint_9;
		}
		set
		{
			uint_9 = value;
		}
	}

	public Class1371 AutoFilter
	{
		get
		{
			return class1371_0;
		}
		set
		{
			class1371_0 = value;
		}
	}

	public Class1706 SortState
	{
		get
		{
			return class1706_0;
		}
		set
		{
			class1706_0 = value;
		}
	}

	public Class1712 TableColumns
	{
		get
		{
			return class1712_0;
		}
		set
		{
			class1712_0 = value;
		}
	}

	public Class1720 TableStyleInfo
	{
		get
		{
			return class1720_0;
		}
		set
		{
			class1720_0 = value;
		}
	}

	public Class1502 ExtLst
	{
		get
		{
			return class1502_0;
		}
		set
		{
			class1502_0 = value;
		}
	}

	internal Class800()
	{
		enum247_0 = Class1710.enum247_1;
		uint_1 = 1u;
		bool_0 = false;
		bool_1 = false;
		uint_2 = 0u;
		bool_2 = true;
		bool_3 = false;
		uint_3 = uint.MaxValue;
		uint_4 = uint.MaxValue;
		uint_5 = uint.MaxValue;
		uint_6 = uint.MaxValue;
		uint_7 = uint.MaxValue;
		uint_8 = uint.MaxValue;
		uint_9 = uint.MaxValue;
	}
}
