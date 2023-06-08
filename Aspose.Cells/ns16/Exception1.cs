using System;
using System.Runtime.InteropServices;

namespace ns16;

[Guid("ebc25cf6-9120-4283-b972-0e5520d00006")]
internal class Exception1 : Exception
{
	public Exception1()
	{
	}

	public Exception1(string string_0)
		: base(string_0)
	{
	}

	public Exception1(string string_0, Exception exception_0)
		: base(string_0, exception_0)
	{
	}
}
