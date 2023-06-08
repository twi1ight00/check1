using System;

namespace ns67;

internal abstract class Class3090 : Class3089
{
	private Class3448 class3448_0 = new Class3448();

	public Class3448 Transform2D
	{
		get
		{
			return class3448_0;
		}
		set
		{
			if (class3448_0 != value)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				class3448_0 = value.method_0();
				method_0();
			}
		}
	}

	protected Class3090(Class3448 transform2D)
	{
		Transform2D = transform2D;
	}
}
