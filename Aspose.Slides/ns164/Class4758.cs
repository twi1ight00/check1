using System;
using System.Collections;
using ns165;

namespace ns164;

internal class Class4758 : Class4755
{
	private readonly float float_0;

	internal Class4758(float height)
	{
		float_0 = height;
	}

	internal override void Add(Class4755 child)
	{
		if (!(child is Class4757))
		{
			throw new ArgumentException("Please report exception. ");
		}
		base.Add(child);
	}

	internal override void vmethod_0(Interface145 builder)
	{
		builder.imethod_14(float_0, base.Attributes);
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class4755 @class = (Class4755)enumerator.Current;
				@class.vmethod_0(builder);
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		builder.imethod_15();
	}
}
