using System;
using System.Collections;
using System.Drawing;
using ns165;

namespace ns164;

internal class Class4764 : Class4755
{
	private RectangleF rectangleF_0;

	internal Class4764(Class4767 allAttributes)
		: base(allAttributes)
	{
		rectangleF_0 = new RectangleF((float)allAttributes[Enum670.const_0], (float)allAttributes[Enum670.const_1], (float)allAttributes[Enum670.const_6], (float)allAttributes[Enum670.const_7]);
	}

	internal override void vmethod_0(Interface145 builder)
	{
		builder.imethod_8(rectangleF_0);
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
		builder.imethod_9();
	}
}
