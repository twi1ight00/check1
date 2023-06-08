using System.Collections;
using System.Reflection;
using x32a884d842a34446;
using xad5c68c1ad3b0224;

namespace xcc8a79815d76af85;

[DefaultMember("Item")]
internal class x27f25020c5c0f2d3
{
	private x9b87766ad1dbe8d6 xc5fd8e65b5bd24cc;

	private Hashtable x90522445dfd12fce = new Hashtable();

	internal x0c3d704ad3ea61a6 xe6d4b1b411ed94b5
	{
		get
		{
			if (x90522445dfd12fce[xc0c4c459c6ccbd00] == null)
			{
				return xc5fd8e65b5bd24cc.x4ccdf3e6468ad446;
			}
			return (x0c3d704ad3ea61a6)x90522445dfd12fce[xc0c4c459c6ccbd00];
		}
	}

	internal x0c3d704ad3ea61a6 x24d50ab5d64a016e => this.get_xe6d4b1b411ed94b5(0);

	internal bool xddf2b5348950b232 => x90522445dfd12fce.Count > 0;

	internal x27f25020c5c0f2d3(x9b87766ad1dbe8d6 series)
	{
		xc5fd8e65b5bd24cc = series;
	}

	internal void xc4be0dfe29fdaf67(x0c3d704ad3ea61a6 x6a2484744dda7709)
	{
		x90522445dfd12fce[x6a2484744dda7709.xd1bdf42207dd3638] = x6a2484744dda7709;
	}

	internal void x9816b2cae76d771f()
	{
		foreach (DictionaryEntry item in x90522445dfd12fce)
		{
			x0c3d704ad3ea61a6 x0c3d704ad3ea61a7 = (x0c3d704ad3ea61a6)item.Value;
			if (!x0c3d704ad3ea61a7.x5d610dd35e5d8581 && xc5fd8e65b5bd24cc.x4ccdf3e6468ad446.x5d610dd35e5d8581)
			{
				x0c3d704ad3ea61a7.x94e4690631260a6c = xc5fd8e65b5bd24cc.x4ccdf3e6468ad446.x94e4690631260a6c;
			}
			if (x0c3d704ad3ea61a7.x5d610dd35e5d8581 && xc5fd8e65b5bd24cc.x4ccdf3e6468ad446.x5d610dd35e5d8581)
			{
				if (x0c3d704ad3ea61a7.x94e4690631260a6c.xe59d6d35c76d70aa == x40b68bd2f183c615.xb9715d2f06b63cf0)
				{
					x0c3d704ad3ea61a7.x94e4690631260a6c.xe59d6d35c76d70aa = xc5fd8e65b5bd24cc.x4ccdf3e6468ad446.x94e4690631260a6c.xe59d6d35c76d70aa;
				}
				if (x0c3d704ad3ea61a7.x94e4690631260a6c.xa30c6b7a8d1f61a8 && !xc5fd8e65b5bd24cc.x4ccdf3e6468ad446.x94e4690631260a6c.xa30c6b7a8d1f61a8)
				{
					x0c3d704ad3ea61a7.x94e4690631260a6c.x437e3b626c0fdd43 = xc5fd8e65b5bd24cc.x4ccdf3e6468ad446.x94e4690631260a6c.x437e3b626c0fdd43;
				}
			}
			if (x0c3d704ad3ea61a7.xff13b489d81606b6.x93e68a44438355fd == null && x0c3d704ad3ea61a7.xff13b489d81606b6.x6a81a30bcaf20a97 == null)
			{
				if (xc5fd8e65b5bd24cc.x4ccdf3e6468ad446.xff13b489d81606b6.x6a81a30bcaf20a97 != null)
				{
					x0c3d704ad3ea61a7.xff13b489d81606b6.x6a81a30bcaf20a97 = xc5fd8e65b5bd24cc.x4ccdf3e6468ad446.xff13b489d81606b6.x6a81a30bcaf20a97;
				}
				if (xc5fd8e65b5bd24cc.x4ccdf3e6468ad446.xff13b489d81606b6.x93e68a44438355fd != null)
				{
					x0c3d704ad3ea61a7.xff13b489d81606b6.x93e68a44438355fd = xc5fd8e65b5bd24cc.x4ccdf3e6468ad446.xff13b489d81606b6.x93e68a44438355fd;
				}
			}
			if (x0c3d704ad3ea61a7.xebda71a9872c4199 < 0 && xc5fd8e65b5bd24cc.x4ccdf3e6468ad446.xebda71a9872c4199 >= 0)
			{
				x0c3d704ad3ea61a7.xebda71a9872c4199 = xc5fd8e65b5bd24cc.x4ccdf3e6468ad446.xebda71a9872c4199;
			}
		}
	}
}
