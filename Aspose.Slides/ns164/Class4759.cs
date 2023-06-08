using System;
using System.Collections;
using ns165;

namespace ns164;

internal class Class4759 : Class4755
{
	internal override void Add(Class4755 child)
	{
		if (child is Class4758)
		{
			if (base.Attributes.method_0(Enum670.const_11))
			{
				child.Attributes.Add(Enum670.const_11, base.Attributes[Enum670.const_11]);
			}
			if (base.Attributes.method_0(Enum670.const_2))
			{
				float num = (float)base.Attributes[Enum670.const_2];
				if (num != 0f)
				{
					Class4757 child2 = new Class4757(num, drawBorders: false);
					child.Add(child2);
				}
			}
			base.Add(child);
			return;
		}
		throw new ArgumentException("Please report report exception. Table can only host rows.");
	}

	internal override void vmethod_0(Interface145 builder)
	{
		builder.imethod_12(base.Attributes);
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
		builder.imethod_13();
	}
}
