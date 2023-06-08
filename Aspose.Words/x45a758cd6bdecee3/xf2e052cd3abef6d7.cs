using x6c95d9cf46ff5f25;

namespace x45a758cd6bdecee3;

internal class xf2e052cd3abef6d7
{
	private const int x8945d19deebff738 = 65536;

	private const int x1b23a05f674640a1 = 1330926671;

	public int x77fa6322561797a0;

	public ushort x444aa5ad583fb445;

	public bool x22ab5dfa6f12e902
	{
		get
		{
			if (x77fa6322561797a0 == 65536 || x77fa6322561797a0 == 1330926671)
			{
				return x444aa5ad583fb445 > 0;
			}
			return false;
		}
	}

	public static xf2e052cd3abef6d7 x06b0e25aa6ad68a9(xa8866d7566da0aa2 xe134235b3526fa75)
	{
		xf2e052cd3abef6d7 xf2e052cd3abef6d8 = new xf2e052cd3abef6d7();
		xf2e052cd3abef6d8.x77fa6322561797a0 = xe134235b3526fa75.x95ea7d23cc8ee04d();
		xf2e052cd3abef6d8.x444aa5ad583fb445 = xe134235b3526fa75.xdb264d863790ee7b();
		xe134235b3526fa75.xdb264d863790ee7b();
		xe134235b3526fa75.xdb264d863790ee7b();
		xe134235b3526fa75.xdb264d863790ee7b();
		return xf2e052cd3abef6d8;
	}

	public void x6210059f049f0d48(x73087173962e3778 xbdfb620b7167944b)
	{
		xbdfb620b7167944b.x6ff7c65ed4805c27(x77fa6322561797a0);
		xbdfb620b7167944b.xb0c682b9901a2443(x444aa5ad583fb445);
		ushort num = 0;
		ushort num2;
		for (num2 = 1; num2 < x444aa5ad583fb445 >> 1; num2 = (ushort)(num2 << 1))
		{
			num = (ushort)(num + 1);
		}
		num2 = (ushort)(num2 << 4);
		ushort xbcea506a33cf = (ushort)(x444aa5ad583fb445 * 16 - num2);
		xbdfb620b7167944b.xb0c682b9901a2443(num2);
		xbdfb620b7167944b.xb0c682b9901a2443(num);
		xbdfb620b7167944b.xb0c682b9901a2443(xbcea506a33cf);
	}
}
