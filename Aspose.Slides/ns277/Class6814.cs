using System;
using System.Text;

namespace ns277;

internal class Class6814
{
	private byte[] byte_0;

	private Encoding encoding_0;

	private Exception exception_0;

	private string string_0;

	public byte[] Data => byte_0;

	public Exception ExceptionIfAny
	{
		get
		{
			return exception_0;
		}
		set
		{
			exception_0 = value;
		}
	}

	public Encoding EncodingIfKnown
	{
		get
		{
			return encoding_0;
		}
		set
		{
			encoding_0 = value;
		}
	}

	public string MIMEIfKnown
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

	public Class6814(byte[] data)
		: this(data, Encoding.Default)
	{
		byte_0 = data;
	}

	public Class6814(byte[] data, Encoding encoding)
	{
		byte_0 = data;
		encoding_0 = encoding;
	}
}
