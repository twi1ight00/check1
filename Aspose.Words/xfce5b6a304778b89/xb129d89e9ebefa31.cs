using System;
using System.Collections;
using System.Reflection;

namespace xfce5b6a304778b89;

[DefaultMember("Item")]
internal class xb129d89e9ebefa31 : ArrayList
{
	internal x899ab188166aec2d xe6d4b1b411ed94b5
	{
		get
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					x899ab188166aec2d x899ab188166aec2d2 = (x899ab188166aec2d)enumerator.Current;
					if (x899ab188166aec2d2.x759aa16c2016a289 == xc15bd84e01929885)
					{
						return x899ab188166aec2d2;
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
