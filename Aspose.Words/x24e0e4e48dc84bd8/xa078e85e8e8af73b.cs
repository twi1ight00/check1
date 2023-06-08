using x6c95d9cf46ff5f25;
using x74500b509de15565;

namespace x24e0e4e48dc84bd8;

internal class xa078e85e8e8af73b
{
	private ushort x4574aea041dd835f;

	public bool x6df3968c42b004a7 => x375aed0ef1326002(3);

	public bool x4e9908888e512fd5 => x375aed0ef1326002(4);

	public bool xaf09b1a5e6d60a5c => x375aed0ef1326002(1);

	public int xd2f68ee6f47e9dfb => x4574aea041dd835f;

	public xa078e85e8e8af73b()
	{
	}

	internal xa078e85e8e8af73b(ushort value)
	{
		x4574aea041dd835f = value;
	}

	public void x1b4522c8590b3e1a(x28a5d52551b64191 xe134235b3526fa75)
	{
		x4574aea041dd835f = xe134235b3526fa75.ReadUInt16();
	}

	public int x2341221de20e9ed3()
	{
		return x02995f229cff83b4(8, 15);
	}

	public bool x375aed0ef1326002(int xa41af725458db489)
	{
		return x26000ce44ebda9ea.x3c25c5b87860f214(x4574aea041dd835f, (ushort)(1 << 15 - xa41af725458db489));
	}

	public int x02995f229cff83b4(int xc1d66aac15ff18ea, int x0ba52c67cce26c51)
	{
		return ((x4574aea041dd835f << xc1d66aac15ff18ea) & 0xFFFF) >> 15 - (x0ba52c67cce26c51 - xc1d66aac15ff18ea);
	}
}
