using ns110;
using ns111;

namespace ns109;

internal class Class4434
{
	private static Class4434 class4434_0 = new Class4434();

	private Class4428 class4428_0;

	private Class4430 class4430_0;

	private Class4429 class4429_0;

	private Class4432 class4432_0;

	private Class4431 class4431_0;

	public static Class4434 Instance => class4434_0;

	public Class4428 ExpertCharset
	{
		get
		{
			if (class4428_0 == null)
			{
				class4428_0 = new Class4428();
			}
			return class4428_0;
		}
	}

	public Class4430 ExpertSubsetCharset
	{
		get
		{
			if (class4430_0 == null)
			{
				class4430_0 = new Class4430();
			}
			return class4430_0;
		}
	}

	public Class4429 ISOAdobeCharset
	{
		get
		{
			if (class4429_0 == null)
			{
				class4429_0 = new Class4429();
			}
			return class4429_0;
		}
	}

	public Class4432 ExpertEncoding
	{
		get
		{
			if (class4432_0 == null)
			{
				class4432_0 = new Class4432();
			}
			return class4432_0;
		}
	}

	public Class4431 StandardEncoding
	{
		get
		{
			if (class4431_0 == null)
			{
				class4431_0 = new Class4431();
			}
			return class4431_0;
		}
	}
}
