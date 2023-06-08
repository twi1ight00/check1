using System;

namespace ns67;

internal abstract class Class3072
{
	private Class3456 class3456_0;

	public Class3456 Point
	{
		get
		{
			return class3456_0;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException();
			}
			class3456_0 = value;
		}
	}

	public abstract Class3455 vmethod_0();

	protected Class3072()
	{
		class3456_0 = new Class3456(0.0, 0.0);
	}

	protected static double smethod_0()
	{
		return 127.0;
	}
}
