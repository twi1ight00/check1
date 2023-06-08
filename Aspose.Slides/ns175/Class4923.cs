using System;
using System.IO;
using ns171;
using ns178;

namespace ns175;

internal class Class4923
{
	private string string_0;

	private Stream stream_0;

	private Class5738 class5738_0;

	private Class4931 class4931_0;

	internal Class4923(string outputFormat, Class5738 ua, Stream stream)
	{
		string_0 = outputFormat;
		class5738_0 = ua;
		if (class5738_0 == null)
		{
			class5738_0 = Class5734.smethod_0().method_0();
		}
		stream_0 = stream;
		method_1();
	}

	public Class5738 method_0()
	{
		return class5738_0;
	}

	private void method_1()
	{
		class4931_0 = new Class4931(string_0, class5738_0, stream_0);
	}

	public Class4927 method_2()
	{
		if (class4931_0 == null)
		{
			method_1();
		}
		return class4931_0;
	}

	public Class5493 method_3()
	{
		if (class4931_0 == null)
		{
			throw new InvalidOperationException("Results are only available after calling getDefaultHandler().");
		}
		return class4931_0.method_3();
	}
}
