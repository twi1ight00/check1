using System;
using System.IO;
using x6c95d9cf46ff5f25;

namespace xfaf39c3a57bb7414;

internal class x86b6cc609e8ca432 : Exception
{
	public x86b6cc609e8ca432(string message)
		: base(message)
	{
	}

	public x86b6cc609e8ca432(string message, string filename)
		: base(string.Format("{0} {1}", message, x0d299f323d241756.x5959bccb67bbf051(filename) ? Path.GetFullPath(filename) : ""))
	{
	}
}
