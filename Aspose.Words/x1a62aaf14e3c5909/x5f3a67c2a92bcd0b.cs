using System;
using Aspose.Words.Drawing;

namespace x1a62aaf14e3c5909;

internal class x5f3a67c2a92bcd0b : x21ad3b7fe343bc74
{
	private xc40bef0fb61c8a3e x36e537bc6dfd6811;

	internal x3ed37e433e884f79 x91ac32ef4a85c752 => (x3ed37e433e884f79)xe382d6617070a76d(typeof(x3ed37e433e884f79));

	internal x9ced206c3c179783 x66105e422ac8a42a => (x9ced206c3c179783)xe382d6617070a76d(typeof(x9ced206c3c179783));

	internal xc40bef0fb61c8a3e x8d179ee9582d1d8e
	{
		get
		{
			return x36e537bc6dfd6811;
		}
		set
		{
			x36e537bc6dfd6811 = value;
		}
	}

	internal x0c6eac1af67f9f81 xaedb5aa958e0ae8f => (x0c6eac1af67f9f81)xe382d6617070a76d(typeof(x0c6eac1af67f9f81));

	internal x5f3a67c2a92bcd0b()
		: base(x773fe540042dad03.xfee552314006c468)
	{
	}

	internal static x5f3a67c2a92bcd0b xa574237c8982796b(xc40bef0fb61c8a3e x4d49889b5a27d1df)
	{
		x5f3a67c2a92bcd0b x5f3a67c2a92bcd0b2 = new x5f3a67c2a92bcd0b();
		x5f3a67c2a92bcd0b2.x8d179ee9582d1d8e = x4d49889b5a27d1df;
		x3ed37e433e884f79 x3ed37e433e884f80 = new x3ed37e433e884f79();
		x5f3a67c2a92bcd0b2.xf2453c298c5de6f5.Add(x3ed37e433e884f80);
		x3ed37e433e884f80.x65ea8654a7f70de3 = (int)(x4d49889b5a27d1df + 1);
		x0c6eac1af67f9f81 x0c6eac1af67f9f82 = new x0c6eac1af67f9f81();
		x5f3a67c2a92bcd0b2.xf2453c298c5de6f5.Add(x0c6eac1af67f9f82);
		xc6764e97e740ec5a xc6764e97e740ec5a2 = new xc6764e97e740ec5a();
		x0c6eac1af67f9f82.xf2453c298c5de6f5.Add(xc6764e97e740ec5a2);
		x1f112a7e89020b14 value = new x1f112a7e89020b14();
		xc6764e97e740ec5a2.xf2453c298c5de6f5.Add(value);
		x00f3419456bbf9dc x00f3419456bbf9dc2 = new x00f3419456bbf9dc();
		x00f3419456bbf9dc2.xdd2aea3eb7514107 = 0;
		x00f3419456bbf9dc2.xbed4d3b2bc339f99 = ShapeType.NonPrimitive;
		x00f3419456bbf9dc2.xe23970fbd4f20532 = true;
		x00f3419456bbf9dc2.xab3829a04b8614ba = true;
		xc6764e97e740ec5a2.xf2453c298c5de6f5.Add(x00f3419456bbf9dc2);
		return x5f3a67c2a92bcd0b2;
	}

	internal void x6671cf4b0be888ea()
	{
		x8af7dcff09cae1a6(this, x91ac32ef4a85c752);
	}

	private static void x8af7dcff09cae1a6(x21ad3b7fe343bc74 xa71d725cbde3e9e6, x3ed37e433e884f79 x133570bb51c9080f)
	{
		for (int i = 0; i < xa71d725cbde3e9e6.xf2453c298c5de6f5.Count; i++)
		{
			xddf6304144fd3863 xddf6304144fd3864 = xa71d725cbde3e9e6.xf2453c298c5de6f5.get_xe6d4b1b411ed94b5(i);
			if (xddf6304144fd3864 is x00f3419456bbf9dc)
			{
				x00f3419456bbf9dc x00f3419456bbf9dc2 = (x00f3419456bbf9dc)xddf6304144fd3864;
				if (!x00f3419456bbf9dc2.x65fd966a6b330c28 && !x00f3419456bbf9dc2.x1a3b93a566584a7d)
				{
					x133570bb51c9080f.x45856a8054f10613++;
				}
				if (!x00f3419456bbf9dc2.x65fd966a6b330c28)
				{
					x133570bb51c9080f.x80a0fbcf860ec6e0 = Math.Max(x133570bb51c9080f.x80a0fbcf860ec6e0, x00f3419456bbf9dc2.xdd2aea3eb7514107);
				}
			}
			if (xddf6304144fd3864 is x21ad3b7fe343bc74)
			{
				x8af7dcff09cae1a6((x21ad3b7fe343bc74)xddf6304144fd3864, x133570bb51c9080f);
			}
		}
	}
}
