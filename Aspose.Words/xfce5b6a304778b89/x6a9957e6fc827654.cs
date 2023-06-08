using System;
using System.Collections;
using System.Reflection;

namespace xfce5b6a304778b89;

[DefaultMember("Item")]
internal class x6a9957e6fc827654 : ArrayList
{
	internal x68feb341faa622d7 xe6d4b1b411ed94b5
	{
		get
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					x68feb341faa622d7 x68feb341faa622d8 = (x68feb341faa622d7)enumerator.Current;
					if (x68feb341faa622d8.x759aa16c2016a289 == xc15bd84e01929885)
					{
						return x68feb341faa622d8;
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

	public x68feb341faa622d7 xe6d4b1b411ed94b5 => (x68feb341faa622d7)base[xc0c4c459c6ccbd00];
}
