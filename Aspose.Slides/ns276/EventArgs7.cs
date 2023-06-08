using System;

namespace ns276;

internal class EventArgs7 : EventArgs
{
	private int int_0;

	private bool bool_0;

	private Class6751 class6751_0;

	private Enum912 enum912_0;

	private string string_0;

	private long long_0;

	private long long_1;

	public int EntriesTotal
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

	public Class6751 CurrentEntry
	{
		get
		{
			return class6751_0;
		}
		set
		{
			class6751_0 = value;
		}
	}

	public bool Cancel
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = bool_0 || value;
		}
	}

	public Enum912 EventType
	{
		get
		{
			return enum912_0;
		}
		set
		{
			enum912_0 = value;
		}
	}

	public string ArchiveName
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

	public long BytesTransferred
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

	public long TotalBytesToTransfer
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

	internal EventArgs7()
	{
	}

	internal EventArgs7(string archiveName, Enum912 flavor)
	{
		string_0 = archiveName;
		enum912_0 = flavor;
	}
}
