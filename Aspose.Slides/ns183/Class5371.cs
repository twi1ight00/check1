using System;
using System.Text;

namespace ns183;

internal class Class5371
{
	private byte[] byte_0;

	private Encoding encoding_0;

	private Exception exception_0;

	private string string_0;

	public byte[] Data => byte_0;

	public Exception Exception
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

	public Encoding Encoding
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

	public string MIMEType
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

	public Class5371(byte[] data)
		: this(data, Encoding.Default)
	{
		byte_0 = data;
	}

	public Class5371(byte[] data, Encoding encoding)
	{
		byte_0 = data;
		encoding_0 = encoding;
	}

	public Class5371(Exception exception)
	{
		exception_0 = exception;
	}
}
