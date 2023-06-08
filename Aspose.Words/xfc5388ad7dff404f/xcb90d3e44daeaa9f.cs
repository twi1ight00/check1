using System.Collections;
using System.Reflection;
using x6c95d9cf46ff5f25;

namespace xfc5388ad7dff404f;

[DefaultMember("Item")]
internal class xcb90d3e44daeaa9f : IEnumerable
{
	private readonly xd345c73dd1b16b74 x82b70567a5f68f41;

	public int xd44988f225497f3a => x82b70567a5f68f41.Count;

	public xa2f1c3dcbd86f20a xe6d4b1b411ed94b5 => (xa2f1c3dcbd86f20a)x82b70567a5f68f41[xc15bd84e01929885];

	public xcb90d3e44daeaa9f()
	{
		x82b70567a5f68f41 = new xd345c73dd1b16b74(isCaseSensitive: false);
	}

	public void xd6b6ed77479ef68c(xa2f1c3dcbd86f20a xd7e5673853e47af4)
	{
		x82b70567a5f68f41.Add(xd7e5673853e47af4.x759aa16c2016a289, xd7e5673853e47af4);
	}

	public bool x263d579af1d0d43f(string xc15bd84e01929885)
	{
		return x82b70567a5f68f41.Contains(xc15bd84e01929885);
	}

	private IEnumerator x05b0b83b5e6c5de6()
	{
		return x82b70567a5f68f41.GetValueList().GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x05b0b83b5e6c5de6
		return this.x05b0b83b5e6c5de6();
	}
}
