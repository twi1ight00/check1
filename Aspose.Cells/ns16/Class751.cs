using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace ns16;

internal class Class751
{
	private Class746 class746_0;

	private Stream6 stream6_0;

	private Stream5 stream5_0;

	public string Password
	{
		get
		{
			if (class746_0 != null)
			{
				return class746_0.string_3;
			}
			if (stream5_0 != null)
			{
				return stream5_0.string_0;
			}
			return stream6_0.string_0;
		}
	}

	public Class751(object object_0)
	{
		class746_0 = object_0 as Class746;
		stream6_0 = object_0 as Stream6;
		stream5_0 = object_0 as Stream5;
	}

	[SpecialName]
	public Class746 method_0()
	{
		return class746_0;
	}

	[SpecialName]
	public Stream6 method_1()
	{
		return stream6_0;
	}

	[SpecialName]
	public Enum32 method_2()
	{
		if (class746_0 != null)
		{
			return class746_0.enum32_0;
		}
		if (stream5_0 != null)
		{
			throw new NotSupportedException();
		}
		return stream6_0.enum32_0;
	}

	[SpecialName]
	public int method_3()
	{
		if (class746_0 != null)
		{
			return class746_0.method_8();
		}
		if (stream5_0 != null)
		{
			throw new NotSupportedException();
		}
		return 0;
	}

	[SpecialName]
	public Stream10 method_4()
	{
		if (class746_0 != null)
		{
			return class746_0.stream10_0;
		}
		if (stream5_0 != null)
		{
			return null;
		}
		return stream6_0.stream10_0;
	}

	[SpecialName]
	public void method_5(Stream10 stream10_0)
	{
		if (class746_0 != null)
		{
			class746_0.stream10_0 = stream10_0;
		}
		else if (stream6_0 != null)
		{
			stream6_0.stream10_0 = stream10_0;
		}
	}

	[SpecialName]
	public long method_6()
	{
		if (class746_0 != null)
		{
			return class746_0.method_31();
		}
		return stream6_0.method_14();
	}

	[SpecialName]
	public int method_7()
	{
		if (class746_0 != null)
		{
			return class746_0.method_32();
		}
		return stream6_0.method_15();
	}

	[SpecialName]
	public int method_8()
	{
		if (class746_0 != null)
		{
			return class746_0.method_9();
		}
		if (stream5_0 != null)
		{
			return stream5_0.method_0();
		}
		return stream6_0.method_2();
	}

	[SpecialName]
	public Enum43 method_9()
	{
		if (class746_0 != null)
		{
			return class746_0.method_11();
		}
		return stream6_0.method_3();
	}

	[SpecialName]
	public Enum32 method_10()
	{
		if (class746_0 != null)
		{
			return class746_0.method_17();
		}
		return stream6_0.method_9();
	}

	[SpecialName]
	public Encoding method_11()
	{
		if (class746_0 != null)
		{
			return class746_0.method_19();
		}
		if (stream6_0 != null)
		{
			return stream6_0.method_11();
		}
		return null;
	}

	[SpecialName]
	public Encoding method_12()
	{
		if (class746_0 != null)
		{
			return Class746.smethod_0();
		}
		if (stream6_0 != null)
		{
			return Stream6.smethod_0();
		}
		return null;
	}

	[SpecialName]
	public Enum33 method_13()
	{
		if (class746_0 != null)
		{
			return class746_0.method_21();
		}
		if (stream6_0 != null)
		{
			return stream6_0.method_12();
		}
		return Enum33.const_0;
	}

	[SpecialName]
	public Stream method_14()
	{
		if (class746_0 != null)
		{
			return class746_0.method_46();
		}
		return stream5_0.method_2();
	}
}
