using ns43;

namespace ns34;

internal class Class804
{
	private string string_0 = "";

	private uint uint_0;

	internal string FormatCode
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

	internal uint NumFormatID
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

	internal void method_0(Class814 numFmtElem)
	{
		string_0 = numFmtElem.FormatCode;
		uint_0 = numFmtElem.NumFormatID;
	}

	internal void Save(Class814 numFmtElem)
	{
		numFmtElem.FormatCode = string_0;
		numFmtElem.NumFormatID = uint_0;
	}
}
