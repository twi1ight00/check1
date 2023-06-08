using System;
using System.Text;

namespace ns302;

internal class Exception68 : Exception
{
	private Encoding encoding_0;

	internal Encoding Encoding => encoding_0;

	internal Exception68(Encoding encoding)
	{
		encoding_0 = encoding;
	}

	public Exception68()
	{
	}
}
