using System;
using System.Collections;
using ns165;

namespace ns164;

internal class Class4757 : Class4755
{
	private readonly float float_0;

	private readonly bool bool_0;

	internal Class4757(float width, bool drawBorders)
	{
		float_0 = width;
		bool_0 = drawBorders;
	}

	internal override void vmethod_0(Interface145 builder)
	{
		builder.imethod_18(float_0, base.Attributes, bool_0);
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
		builder.imethod_19();
	}
}
