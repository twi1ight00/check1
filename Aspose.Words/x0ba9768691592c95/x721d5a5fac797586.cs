using System.Collections;
using System.Reflection;

namespace x0ba9768691592c95;

[DefaultMember("Item")]
internal class x721d5a5fac797586
{
	private readonly ArrayList x82b70567a5f68f41 = new ArrayList();

	public x879a106b0501b9dc xe6d4b1b411ed94b5
	{
		get
		{
			return (x879a106b0501b9dc)x82b70567a5f68f41[xc0c4c459c6ccbd00];
		}
		set
		{
			x82b70567a5f68f41[xc0c4c459c6ccbd00] = value;
		}
	}

	public int xd44988f225497f3a => x82b70567a5f68f41.Count;

	public bool x0b282179752635da
	{
		get
		{
			for (int i = 0; i < x82b70567a5f68f41.Count; i++)
			{
				if (this.get_xe6d4b1b411ed94b5(i).x420916cc68dc98ad)
				{
					return true;
				}
			}
			return false;
		}
	}

	public int x5cd4620946d48c1a
	{
		get
		{
			int num = 0;
			for (int i = 0; i < x82b70567a5f68f41.Count; i++)
			{
				if (this.get_xe6d4b1b411ed94b5(i).x420916cc68dc98ad)
				{
					num++;
				}
			}
			return num;
		}
	}

	public void xd6b6ed77479ef68c(x879a106b0501b9dc xccb63ca5f63dc470)
	{
		x82b70567a5f68f41.Add(xccb63ca5f63dc470);
	}

	public x879a106b0501b9dc x212c1a2c5130b96e(int xeaf1b27180c0557b)
	{
		for (int i = 0; i < x82b70567a5f68f41.Count; i++)
		{
			if (this.get_xe6d4b1b411ed94b5(i).xea1e81378298fa81 == xeaf1b27180c0557b)
			{
				return this.get_xe6d4b1b411ed94b5(i);
			}
		}
		return null;
	}

	public x879a106b0501b9dc xe931c242f6b9055f(string xc15bd84e01929885)
	{
		for (int i = 0; i < x82b70567a5f68f41.Count; i++)
		{
			if (this.get_xe6d4b1b411ed94b5(i).x759aa16c2016a289 == xc15bd84e01929885)
			{
				return this.get_xe6d4b1b411ed94b5(i);
			}
		}
		return null;
	}
}
