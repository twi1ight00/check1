using System;
using System.Collections;
using System.Drawing;
using x1c8faa688b1f0b0c;
using x4dc96876c552a593;
using x5794c252ba25e723;

namespace x7cd71466ce904867;

internal class x3427685813c1b941
{
	private readonly xe9a355a58980e0a4 xd995695f8e3419d6;

	private x6dbfc8ac01b2bcf9 xd40100a1d4fa98ac;

	private xe7e20ec746b92db8[] x49b8ecede46cff41;

	private x34b8da5e65f2d94f x317be79405176667;

	public x3427685813c1b941(xe9a355a58980e0a4 serviceLocator)
	{
		xd995695f8e3419d6 = serviceLocator;
	}

	public void xd586e0c16bdae7fc(x34b8da5e65f2d94f xc180b27d3f565cae, RectangleF xefa4262da9bfb09c)
	{
		x317be79405176667 = xc180b27d3f565cae;
		xd40100a1d4fa98ac = new x6dbfc8ac01b2bcf9(xd995695f8e3419d6);
		xd40100a1d4fa98ac.x20aee281977480cf(x317be79405176667.xf6bed998bac61470.x4e35c79189b28e26, xefa4262da9bfb09c);
		xe174fd65218c4ffb(xc180b27d3f565cae, xd40100a1d4fa98ac);
		x98b8bff5d4f58e0b(xd40100a1d4fa98ac);
	}

	public x4fdf549af9de6b97 xe406325e56f74b46()
	{
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		xe7e20ec746b92db8[] array = x49b8ecede46cff41;
		foreach (xe7e20ec746b92db8 xe7e20ec746b92db9 in array)
		{
			xb8e7e788f6d.xd6b6ed77479ef68c(xe7e20ec746b92db9.xe406325e56f74b46());
		}
		xb8e7e788f6d.x52dde376accdec7d = xae3ede445752d01f();
		return xb8e7e788f6d;
	}

	private x54366fa5f75a02f7 xae3ede445752d01f()
	{
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		double x842782b6ef7e2bba = xd40100a1d4fa98ac.x842782b6ef7e2bba;
		double x7757bd7d74f2b5d = xd40100a1d4fa98ac.x7757bd7d74f2b5d9;
		switch (x317be79405176667.xf6bed998bac61470.x4e35c79189b28e26.x1452024de1251c74)
		{
		case x5a0fcf86fc261088.x58d2ccae3c5cfd08:
			x54366fa5f75a02f.xce92de628aa023cf(0f, (float)((x842782b6ef7e2bba - x7757bd7d74f2b5d) / 2.0));
			break;
		case x5a0fcf86fc261088.x9bcb07e204e30218:
			x54366fa5f75a02f.xce92de628aa023cf(0f, (float)(x842782b6ef7e2bba - x7757bd7d74f2b5d));
			break;
		default:
			throw new ArgumentOutOfRangeException();
		case x5a0fcf86fc261088.xe360b1885d8d4a41:
		case x5a0fcf86fc261088.xe590b96312e08b5b:
		case x5a0fcf86fc261088.x18ef0deb23f38251:
			break;
		}
		return x54366fa5f75a02f;
	}

	private void x98b8bff5d4f58e0b(x6dbfc8ac01b2bcf9 xee0aaeab57df8a67)
	{
		xe7e20ec746b92db8[] array = x49b8ecede46cff41;
		foreach (xe7e20ec746b92db8 xe7e20ec746b92db9 in array)
		{
			xe7e20ec746b92db9.x98b8bff5d4f58e0b(xee0aaeab57df8a67);
		}
	}

	private void xe174fd65218c4ffb(x34b8da5e65f2d94f xc180b27d3f565cae, x6dbfc8ac01b2bcf9 xee0aaeab57df8a67)
	{
		ArrayList xe944988856b6cea = xc180b27d3f565cae.xf6bed998bac61470.xe944988856b6cea9;
		x49b8ecede46cff41 = new xe7e20ec746b92db8[xe944988856b6cea.Count];
		for (int i = 0; i < xe944988856b6cea.Count; i++)
		{
			xf5c6aa532fe023d4 paragraph = (xf5c6aa532fe023d4)xe944988856b6cea[i];
			xe7e20ec746b92db8 xe7e20ec746b92db9 = new xe7e20ec746b92db8(xd995695f8e3419d6, paragraph);
			xe7e20ec746b92db9.xea15e3cee7163799(xee0aaeab57df8a67.x884d3da464d53ce7);
			xe7e20ec746b92db9.xceaa36575b797b5b();
			x49b8ecede46cff41[i] = xe7e20ec746b92db9;
		}
	}
}
