using System;

namespace ns304;

internal class Exception72 : Exception
{
	public const ushort ushort_0 = 0;

	private readonly ushort ushort_1;

	public ushort Code => ushort_1;

	public Exception72()
		: this(0)
	{
	}

	public Exception72(ushort code)
	{
		ushort_1 = code;
	}
}
