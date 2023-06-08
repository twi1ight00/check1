using System;
using System.IO;
using ns16;

namespace ns22;

internal class Class1030
{
	private readonly Stream6 stream6_0;

	internal Class1030(Stream stream_0)
	{
		stream6_0 = new Stream6(stream_0);
		stream6_0.method_10(Enum32.const_0);
	}

	internal void method_0(string string_0, Stream stream_0)
	{
		Class744 @class = stream6_0.method_18(string_0);
		@class.method_5(DateTime.Now);
		byte[] array = new byte[1024];
		int num = 0;
		do
		{
			num = stream_0.Read(array, 0, array.Length);
			stream6_0.Write(array, 0, num);
		}
		while (num > 0);
		stream6_0.Flush();
		stream6_0.method_23();
	}

	public void method_1()
	{
		stream6_0.Flush();
		stream6_0.method_22();
	}

	public void method_2(int int_0)
	{
		stream6_0.method_6((Enum42)int_0);
	}
}
