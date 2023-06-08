using System.IO;

namespace x1a62aaf14e3c5909;

internal class xc2d70347f7484382 : x21ad3b7fe343bc74, xc93de5b84cb7a11f
{
	internal xc2d70347f7484382()
		: base(x773fe540042dad03.xfd0364e33cd32983)
	{
	}

	internal void x92293779605aaa59(BinaryReader x44008b73fc5f9672)
	{
		foreach (xfbb3f4be330f4086 item in base.xf2453c298c5de6f5)
		{
			if (!item.xcb09944671f5a4fd)
			{
				item.x707eda0bf8f1735b(x44008b73fc5f9672);
			}
		}
	}

	internal void x5ed090cee2aa9cab(BinaryWriter xc83188e30d5f47a5)
	{
		foreach (xfbb3f4be330f4086 item in base.xf2453c298c5de6f5)
		{
			if (!item.xcb09944671f5a4fd)
			{
				item.xbf2311da8da339cb(xc83188e30d5f47a5);
			}
		}
	}

	protected override void DoWrite(BinaryWriter writer)
	{
		base.x1ea60bde2b5d0d28.x9834ddb0e0bd5996 = base.xf2453c298c5de6f5.Count;
		base.DoWrite(writer);
	}

	private xfbb3f4be330f4086 xe1b9c2e6c31f3c20(int xc8f6fc994c5e1a4f)
	{
		int num = xc8f6fc994c5e1a4f - 1;
		if (num >= 0 && num < base.xf2453c298c5de6f5.Count)
		{
			return (xfbb3f4be330f4086)base.xf2453c298c5de6f5.get_xe6d4b1b411ed94b5(num);
		}
		return null;
	}

	xfbb3f4be330f4086 xc93de5b84cb7a11f.x590497a2b838b652(int xc8f6fc994c5e1a4f)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xe1b9c2e6c31f3c20
		return this.xe1b9c2e6c31f3c20(xc8f6fc994c5e1a4f);
	}

	private int x3e6724484e60ec90(xfbb3f4be330f4086 xd1741b157ea7d032)
	{
		int result = base.xf2453c298c5de6f5.Count + 1;
		base.xf2453c298c5de6f5.Add(xd1741b157ea7d032);
		return result;
	}

	int xc93de5b84cb7a11f.xcfcc704945beca71(xfbb3f4be330f4086 xd1741b157ea7d032)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x3e6724484e60ec90
		return this.x3e6724484e60ec90(xd1741b157ea7d032);
	}
}
