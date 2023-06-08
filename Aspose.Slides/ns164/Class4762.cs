using System;
using System.Collections;
using ns165;

namespace ns164;

internal class Class4762 : Class4755
{
	internal Class4762(Class4767 allAttributes)
		: base(allAttributes)
	{
	}

	internal override void vmethod_0(Interface145 builder)
	{
		builder.imethod_6(base.Attributes);
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
		builder.imethod_7();
	}
}
