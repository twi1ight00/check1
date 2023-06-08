using System;
using x28925c9b27b37a46;
using xf9a9481c3f63a419;

namespace x2a6f63b6650e76c4;

internal class xdfbdf8708b1e8b71 : x82e26649b09596bd
{
	private readonly string x4574aea041dd835f;

	internal override string xf6e2349738d2d14e => x4574aea041dd835f;

	internal override xca3ee5e02f497e0b xca3ee5e02f497e0b => xca3ee5e02f497e0b.x4a498a651d07aefe;

	internal xdfbdf8708b1e8b71(string value)
	{
		x4574aea041dd835f = value;
	}

	internal override string x9540796cdde76ac8(string x5786461d089b10a0)
	{
		return x918e475ee39e3253.x19890931227f0f56(x4574aea041dd835f)?.x9540796cdde76ac8(x5786461d089b10a0);
	}

	internal override string x6681811cca8ac252(string x5786461d089b10a0, int xb0a546d42545a9ea)
	{
		DateTime dateTime = xca004f56614e2431.x5fa9002eedbc901d(x4574aea041dd835f);
		if (!(dateTime != DateTime.MinValue))
		{
			return null;
		}
		return xb7dbd7bb3ed97d5b.x6bf3310acbc2c04f(dateTime, x5786461d089b10a0, xb0a546d42545a9ea);
	}

	internal override bool xbbbd3dabf01980ee(out double xbcea506a33cf9111)
	{
		x918e475ee39e3253 x918e475ee39e3254 = x918e475ee39e3253.x19890931227f0f56(x4574aea041dd835f);
		if (x918e475ee39e3254 != null)
		{
			xbcea506a33cf9111 = x918e475ee39e3254.x7ce859afc0c75642;
			return true;
		}
		xbcea506a33cf9111 = 0.0;
		return false;
	}
}
