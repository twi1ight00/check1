namespace ns45;

internal abstract class Class1105
{
	protected string string_0 = "";

	protected short short_0;

	protected short short_1;

	protected byte[] byte_0;

	protected long long_0;

	protected long long_1;

	protected Class1105 class1105_0;

	protected int int_0;

	protected int int_1;

	protected int int_2 = -1;

	private Class1105 class1105_1;

	private Class1105 class1105_2;

	private Class1105 class1105_3;

	public int SId
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

	public int DId
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

	public byte[] UId
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public Class1105 RootEntry
	{
		get
		{
			return class1105_1;
		}
		set
		{
			class1105_1 = value;
		}
	}

	public Class1105 LeftEntry
	{
		get
		{
			return class1105_2;
		}
		set
		{
			class1105_2 = value;
		}
	}

	public Class1105 RightEntry
	{
		get
		{
			return class1105_3;
		}
		set
		{
			class1105_3 = value;
		}
	}

	public short TypeEntry
	{
		get
		{
			return short_0;
		}
		set
		{
			short_0 = value;
		}
	}

	public short NodeColor
	{
		get
		{
			return short_1;
		}
		set
		{
			short_1 = value;
		}
	}

	public string EntryName
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

	public Class1105 ParentEntry => class1105_0;

	public long TimestampCreation
	{
		get
		{
			return long_0;
		}
		set
		{
			long_0 = value;
		}
	}

	public long TimestampModification
	{
		get
		{
			return long_1;
		}
		set
		{
			long_1 = value;
		}
	}

	public int Size
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

	public int CompareTo(Class1105 entry)
	{
		if (string_0.Length > entry.EntryName.Length)
		{
			return 1;
		}
		if (string_0.Length < entry.EntryName.Length)
		{
			return -1;
		}
		return string.CompareOrdinal(string_0, entry.EntryName);
	}
}
