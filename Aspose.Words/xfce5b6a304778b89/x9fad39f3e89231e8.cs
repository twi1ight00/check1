using System;
using System.Collections;
using System.Reflection;

namespace xfce5b6a304778b89;

[DefaultMember("Item")]
internal class x9fad39f3e89231e8 : ArrayList
{
	internal x250900dc40a654f4 xe6d4b1b411ed94b5
	{
		get
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					x250900dc40a654f4 x250900dc40a654f5 = (x250900dc40a654f4)enumerator.Current;
					if (x250900dc40a654f5.x759aa16c2016a289 == xc15bd84e01929885)
					{
						return x250900dc40a654f5;
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

	internal xa18c3a814ffd9901 x1dba2c5863398e07(string xc15bd84e01929885)
	{
		for (int i = 0; i < Count; i++)
		{
			xa18c3a814ffd9901 xa18c3a814ffd9902 = ((x250900dc40a654f4)base[i]).x2ee60809805f40f3.get_xe6d4b1b411ed94b5(xc15bd84e01929885);
			if (xa18c3a814ffd9902 != null)
			{
				return xa18c3a814ffd9902;
			}
		}
		return null;
	}
}
