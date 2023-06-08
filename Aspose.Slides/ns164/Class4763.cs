using System;
using System.Collections;
using System.Drawing;
using ns165;

namespace ns164;

internal class Class4763 : Class4755
{
	internal SizeF PageSize
	{
		get
		{
			if (!base.Attributes.method_0(Enum670.const_6) || !base.Attributes.method_0(Enum670.const_7))
			{
				throw new ArgumentException("Please report exception. Page does not contain size attributes.");
			}
			return new SizeF((float)base.Attributes[Enum670.const_6], (float)base.Attributes[Enum670.const_7]);
		}
	}

	internal Class4763(Class4767 allAttributes)
		: base(allAttributes)
	{
	}

	internal override void vmethod_0(Interface145 builder)
	{
		if (base.Attributes.method_0(Enum670.const_6) && base.Attributes.method_0(Enum670.const_7))
		{
			if (base.Attributes.method_0(Enum670.const_4))
			{
				builder.imethod_3((float)base.Attributes[Enum670.const_6], (float)base.Attributes[Enum670.const_7], base.Attributes);
			}
			else
			{
				builder.imethod_2((float)base.Attributes[Enum670.const_6], (float)base.Attributes[Enum670.const_7]);
			}
			{
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
			}
			builder.imethod_4();
			return;
		}
		throw new ArgumentException("Please report exception. Page size not defined in " + ToString());
	}
}
