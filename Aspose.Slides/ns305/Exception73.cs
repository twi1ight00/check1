using System;

namespace ns305;

internal class Exception73 : Exception
{
	private readonly byte byte_0;

	public byte Code => byte_0;

	public Exception73(Enum968 code)
	{
		byte_0 = (byte)code;
	}

	public Exception73(Enum968 code, string message)
		: base(message)
	{
		byte_0 = (byte)code;
	}

	public static void smethod_0(Enum968 code)
	{
		throw new Exception73(code);
	}
}
