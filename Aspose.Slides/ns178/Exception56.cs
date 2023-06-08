using System;

namespace ns178;

internal class Exception56 : Exception
{
	private string string_0 = string.Empty;

	private string string_1 = string.Empty;

	private string string_2 = string.Empty;

	public string LineNumber
	{
		set
		{
			string_0 = value;
		}
	}

	public string SystemID
	{
		set
		{
			string_1 = value;
		}
	}

	public new string Message
	{
		set
		{
			string_2 = value;
		}
	}

	public string method_0()
	{
		return string_0;
	}

	public string method_1()
	{
		return string_1;
	}

	public string method_2()
	{
		return string_2;
	}
}
