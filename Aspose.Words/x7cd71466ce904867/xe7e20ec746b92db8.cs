using System.Collections;
using x1c8faa688b1f0b0c;
using x4dc96876c552a593;

namespace x7cd71466ce904867;

internal class xe7e20ec746b92db8 : x5f12ca95fce47288
{
	private readonly xe9a355a58980e0a4 xd995695f8e3419d6;

	private ArrayList xf89ae317d9629037;

	private ArrayList x047f3d74dc5f5da7 = new ArrayList();

	private xf5c6aa532fe023d4 x233446e8759c5129;

	public xf5c6aa532fe023d4 xfdc1a17f479acc42 => x233446e8759c5129;

	public ArrayList x8870d31a54300a17 => xf89ae317d9629037;

	public ArrayList x734991a6e63a780b => x047f3d74dc5f5da7;

	public xe7e20ec746b92db8(xe9a355a58980e0a4 serviceLocator, xf5c6aa532fe023d4 paragraph)
	{
		xd995695f8e3419d6 = serviceLocator;
		x233446e8759c5129 = paragraph;
	}

	public void xea15e3cee7163799(double x0e7c6d1cbd874291)
	{
		x5e1f4fd20247e6da x5e1f4fd20247e6da2 = xd995695f8e3419d6.x6e8404530039a935();
		xf89ae317d9629037 = x5e1f4fd20247e6da2.x6f1735600d67f8c8(xfdc1a17f479acc42);
		xda0e2d3e80c66802 xda0e2d3e80c66803 = xd995695f8e3419d6.xee664247577c982a();
		x149f0bd36fa2cea2 xb0a3951ddb0b = new xfd71039dd289000b(xfdc1a17f479acc42.x4e35c79189b28e26, x0e7c6d1cbd874291);
		x047f3d74dc5f5da7 = xda0e2d3e80c66803.x5684e14bfcd27e00(xf89ae317d9629037, xb0a3951ddb0b);
	}

	public void x98b8bff5d4f58e0b(x4f93a140c903e3c5 xee0aaeab57df8a67)
	{
		double x29a242958ae284ac = xfdc1a17f479acc42.x4e35c79189b28e26.xce7d39f89d44bc2a.x77463c049b3fadfb(xfdc1a17f479acc42);
		xee0aaeab57df8a67.xb6c5870a775295da(x29a242958ae284ac);
		for (int i = 0; i < x047f3d74dc5f5da7.Count; i++)
		{
			x4e65d9f1b1fbe157 x4e65d9f1b1fbe158 = (x4e65d9f1b1fbe157)x047f3d74dc5f5da7[i];
			xee0aaeab57df8a67.x49babf6761229eb5(x4e65d9f1b1fbe158, xfdc1a17f479acc42.x4e35c79189b28e26.x84bbacdc1fc0efd2);
			x4e65d9f1b1fbe158.x8df91a2f90079e88 += xfdc1a17f479acc42.x4e35c79189b28e26.xc8a7b7ce5c5279ee;
		}
		x590ec00cb6049d7b();
		double xfb0f7ad9a3c6ddd = xfdc1a17f479acc42.x4e35c79189b28e26.xdc88f9287c50d24f.x77463c049b3fadfb(xfdc1a17f479acc42);
		xee0aaeab57df8a67.xd257a163f3436872(xfb0f7ad9a3c6ddd);
	}

	private void x590ec00cb6049d7b()
	{
		if (x047f3d74dc5f5da7.Count != 0)
		{
			x4e65d9f1b1fbe157 x4e65d9f1b1fbe158 = (x4e65d9f1b1fbe157)x047f3d74dc5f5da7[0];
			if (xfdc1a17f479acc42.x4e35c79189b28e26.x412be8036a42f59b < 0)
			{
				x4e65d9f1b1fbe158.x8df91a2f90079e88 -= xfdc1a17f479acc42.x4e35c79189b28e26.xc8a7b7ce5c5279ee;
			}
			else
			{
				x4e65d9f1b1fbe158.x8df91a2f90079e88 += xfdc1a17f479acc42.x4e35c79189b28e26.x412be8036a42f59b;
			}
		}
	}

	public x4fdf549af9de6b97 xe406325e56f74b46()
	{
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		foreach (x4e65d9f1b1fbe157 item in x047f3d74dc5f5da7)
		{
			if (!item.x8bfe79484ce3a1f2)
			{
				xb8e7e788f6d.xd6b6ed77479ef68c(item.xe406325e56f74b46());
			}
		}
		return xb8e7e788f6d;
	}

	public void xceaa36575b797b5b()
	{
		foreach (x4e65d9f1b1fbe157 item in x047f3d74dc5f5da7)
		{
			item.xceaa36575b797b5b(xfdc1a17f479acc42.x4e35c79189b28e26.x9ba359ff37a3a63b);
		}
		if (x047f3d74dc5f5da7.Count > 0 && (xfdc1a17f479acc42.x4e35c79189b28e26.x9ba359ff37a3a63b == x19a216c91d09a513.x18ef0deb23f38251 || xfdc1a17f479acc42.x4e35c79189b28e26.x9ba359ff37a3a63b == x19a216c91d09a513.xe590b96312e08b5b || xfdc1a17f479acc42.x4e35c79189b28e26.x9ba359ff37a3a63b == x19a216c91d09a513.xbcf8338386567937 || xfdc1a17f479acc42.x4e35c79189b28e26.x9ba359ff37a3a63b == x19a216c91d09a513.x8132d8efd150f3e7))
		{
			((x4e65d9f1b1fbe157)x047f3d74dc5f5da7[x047f3d74dc5f5da7.Count - 1]).xceaa36575b797b5b(x19a216c91d09a513.x72d92bd1aff02e37);
		}
	}
}
