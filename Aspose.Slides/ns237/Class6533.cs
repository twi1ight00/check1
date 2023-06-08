using System;

namespace ns237;

internal class Class6533 : Class6511
{
	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	private string string_6;

	private string string_7;

	private DateTime dateTime_0 = DateTime.MinValue;

	private string string_8;

	public string Filter
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

	public string SubFilter
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

	public string ByteRange
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

	public string ContactInfo
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

	public string Location
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

	public string Reason
	{
		get
		{
			return string_6;
		}
		set
		{
			string_6 = value;
		}
	}

	public string AuthorityName
	{
		get
		{
			return string_7;
		}
		set
		{
			string_7 = value;
		}
	}

	public DateTime SigningDate
	{
		get
		{
			return dateTime_0;
		}
		set
		{
			dateTime_0 = value;
		}
	}

	public string Contents
	{
		get
		{
			return string_8;
		}
		set
		{
			string_8 = value;
		}
	}

	public Class6533(Class6672 context)
		: base(context)
	{
	}

	public override void vmethod_0(Class6679 writer)
	{
		writer.method_28(method_0());
		writer.method_29(this);
		writer.method_6();
		writer.method_8("/ByteRange", string_3.PadRight(30));
		writer.method_8("/Contents", $"<{string_8}>");
		writer.method_8("/Type", "/Sig");
		writer.method_8("/Filter", $"/{string_1}");
		writer.method_8("/SubFilter", $"/{string_2}");
		writer.method_13("/ContactInfo", string_4);
		writer.method_13("/Location", string_5);
		writer.method_13("/Reason", string_6);
		writer.method_13("/Name", string_7);
		writer.method_17("/M", dateTime_0);
		writer.method_7();
		writer.method_30();
	}
}
