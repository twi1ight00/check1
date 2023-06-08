using System.Collections;
using System.Reflection;
using x6c95d9cf46ff5f25;

namespace x79578da6a8a3ae37;

[DefaultMember("Item")]
internal class xa72ab20cfb0c9945 : IEnumerable
{
	private readonly ArrayList x82b70567a5f68f41 = new ArrayList();

	internal int xd44988f225497f3a => x82b70567a5f68f41.Count;

	internal x4e1b8abc07d6c49d xe6d4b1b411ed94b5
	{
		get
		{
			return (x4e1b8abc07d6c49d)x82b70567a5f68f41[xc0c4c459c6ccbd00];
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x82b70567a5f68f41[xc0c4c459c6ccbd00] = value;
		}
	}

	internal x4e1b8abc07d6c49d xe6d4b1b411ed94b5
	{
		get
		{
			foreach (x4e1b8abc07d6c49d item in x82b70567a5f68f41)
			{
				if (item.x759aa16c2016a289 == xc15bd84e01929885)
				{
					return item;
				}
			}
			return null;
		}
	}

	public IEnumerator GetEnumerator()
	{
		return x82b70567a5f68f41.GetEnumerator();
	}

	internal int xd6b6ed77479ef68c(x4e1b8abc07d6c49d xbcea506a33cf9111)
	{
		x0d299f323d241756.x0aaaea7864a53f26(xbcea506a33cf9111, "value");
		return x82b70567a5f68f41.Add(xbcea506a33cf9111);
	}

	internal void xa9d636b00ff486b7()
	{
		x82b70567a5f68f41.Clear();
	}

	internal void x7121e9e177952651(int xc0c4c459c6ccbd00)
	{
		x82b70567a5f68f41.RemoveAt(xc0c4c459c6ccbd00);
	}
}
