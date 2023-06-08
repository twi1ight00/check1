using System;
using System.Collections;
using Aspose.Words;

namespace x1495530f35d79681;

internal class xc25c28c64aadfd1b : ArrayList
{
	internal void x5f3c0783a74b5d80(xeb0b4eb7a8e9f591 x59b00779808aa981)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				x22510822ff0a46e1 x22510822ff0a46e2 = (x22510822ff0a46e1)enumerator.Current;
				Style xfe2178c1f916f36c = x22510822ff0a46e2.xfe2178c1f916f36c;
				if (x22510822ff0a46e2.x4c48a782e25bce54 != null)
				{
					xfe2178c1f916f36c.xe709b224f455b863 = x59b00779808aa981.xc9b7340b035562c6(x22510822ff0a46e2.x4c48a782e25bce54, 4095);
				}
				if (x22510822ff0a46e2.xbc13914359462815 != null)
				{
					xfe2178c1f916f36c.xfb77c9ea054ac31c = x59b00779808aa981.xc9b7340b035562c6(x22510822ff0a46e2.xbc13914359462815, xfe2178c1f916f36c.x8301ab10c226b0c2);
				}
				if (x22510822ff0a46e2.xe014cc494bbbb1d4 != null)
				{
					xfe2178c1f916f36c.x4cf1854ef833220f = x59b00779808aa981.xc9b7340b035562c6(x22510822ff0a46e2.xe014cc494bbbb1d4, 4095);
				}
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
}
