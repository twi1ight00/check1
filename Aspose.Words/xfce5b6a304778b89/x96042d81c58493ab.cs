using System;
using System.Collections;
using System.Reflection;

namespace xfce5b6a304778b89;

[DefaultMember("Item")]
internal class x96042d81c58493ab : ArrayList
{
	internal xa18c3a814ffd9901 xe6d4b1b411ed94b5
	{
		get
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					xa18c3a814ffd9901 xa18c3a814ffd9902 = (xa18c3a814ffd9901)enumerator.Current;
					if (xa18c3a814ffd9902.xea1e81378298fa81 == xeaf1b27180c0557b)
					{
						return xa18c3a814ffd9902;
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
			return null;
		}
	}
}
