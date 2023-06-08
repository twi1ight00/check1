using System;

namespace ns70;

internal sealed class Exception8 : Exception
{
	private readonly uint uint_0;

	public uint ErrorCode => uint_0;

	public Exception8(uint code)
		: base(smethod_0(code))
	{
		uint_0 = code;
	}

	private static string smethod_0(uint code)
	{
		return code switch
		{
			1280u => "A GLenum argument was out of range.", 
			1281u => "A numeric argument was out of range.", 
			1282u => "Operation illeagal in current state.", 
			1283u => "Command would cause a stack overflow.", 
			1284u => "Command would cause a stack underflow.", 
			1285u => "Not enough memory left to execute command.", 
			_ => "Unknown OpenGL Error. Code: " + code, 
		};
	}
}
