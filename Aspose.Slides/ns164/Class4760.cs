using System;
using System.Collections;
using ns165;

namespace ns164;

internal class Class4760 : Class4755
{
	internal override void vmethod_0(Interface145 builder)
	{
		builder.imethod_0();
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
		builder.imethod_1();
	}
}
