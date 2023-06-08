using System;
using System.Collections;

namespace x4adf554d20d941a6;

internal class xf8319e677a9bd732
{
	private x8d9303345f12a846 x233446e8759c5129;

	private x56410a8dd70087c5 x00be24a33bf25e2c;

	internal xf8319e677a9bd732(x8d9303345f12a846 lastParagraph, x56410a8dd70087c5 bbtNext)
	{
		x233446e8759c5129 = lastParagraph;
		x00be24a33bf25e2c = bbtNext;
	}

	internal void xef23aa45e7612fdd(x56410a8dd70087c5 x5906905c888d3d98)
	{
		if (x5906905c888d3d98.x5566e2d2acbd1fbe == 21537 && x5906905c888d3d98.x705ed5f9769744e5.x24385217e0d88ab8)
		{
			x6f6af857029e4ead(x5906905c888d3d98, x00be24a33bf25e2c, x233446e8759c5129);
		}
		if (!x5906905c888d3d98.xd181cfc9bf12b1ac)
		{
			if (!x5906905c888d3d98.x00fa20d37841acd0)
			{
				x55fd04d4bb90ddb5(x5906905c888d3d98);
			}
			x00be24a33bf25e2c = x5906905c888d3d98;
			x233446e8759c5129 = x5906905c888d3d98.x406d8cd2af514771;
		}
	}

	internal void x22eff0ce085903b3(x8d9303345f12a846 x2aa5114a5da7d6c8)
	{
		x8d9303345f12a846 x8d9303345f12a847 = x233446e8759c5129.x44f726f5706141a2();
		x8d9303345f12a846 x8d9303345f12a848 = ((x8d9303345f12a847 != null) ? x8d9303345f12a847 : x233446e8759c5129);
		for (x233446e8759c5129 = x2aa5114a5da7d6c8; x233446e8759c5129 != null; x233446e8759c5129 = x233446e8759c5129.x44f726f5706141a2())
		{
			x9343b418fde38f71();
			if (x233446e8759c5129 == x8d9303345f12a848)
			{
				break;
			}
		}
	}

	private void x55fd04d4bb90ddb5(x56410a8dd70087c5 x5906905c888d3d98)
	{
		x841a9642da9aa496(x233446e8759c5129, x00be24a33bf25e2c, x5906905c888d3d98);
	}

	private void x9343b418fde38f71()
	{
		x7c6f7cd821c90d52(x233446e8759c5129);
	}

	private static void x841a9642da9aa496(x8d9303345f12a846 x31e6518f5e08db6c, x56410a8dd70087c5 x2171c110ade1f79e, x56410a8dd70087c5 x5906905c888d3d98)
	{
		if (x2171c110ade1f79e == null)
		{
			x8528b59a769e9f0a(x31e6518f5e08db6c, x2171c110ade1f79e, x5906905c888d3d98);
		}
		else if (x5566e2d2acbd1fbe.xff7735def89bf56b(x5906905c888d3d98.x5566e2d2acbd1fbe) || (21537 == x5906905c888d3d98.x5566e2d2acbd1fbe && x5906905c888d3d98.x705ed5f9769744e5.x17c40acbe47f16cc))
		{
			x67eeecfbdb45346b(x31e6518f5e08db6c, x5906905c888d3d98);
			x8528b59a769e9f0a(x31e6518f5e08db6c, x2171c110ade1f79e, x5906905c888d3d98);
		}
		else if (x31e6518f5e08db6c.x2be2727bb322530e == null || x31e6518f5e08db6c.x2be2727bb322530e == x2171c110ade1f79e.x7f6ad514996fb03a)
		{
			x8528b59a769e9f0a(x31e6518f5e08db6c, x2171c110ade1f79e, x5906905c888d3d98);
			x94b50805164237ec(x31e6518f5e08db6c, x5906905c888d3d98);
			if (x5906905c888d3d98.xc0e56f2fca892328 && x5906905c888d3d98.x7f6ad514996fb03a != null && !x5566e2d2acbd1fbe.xff7735def89bf56b(x5906905c888d3d98.x7f6ad514996fb03a.x5566e2d2acbd1fbe))
			{
				x94b50805164237ec(x5906905c888d3d98.x7f6ad514996fb03a.x406d8cd2af514771, x5906905c888d3d98.x7f6ad514996fb03a);
			}
			x72cefbd49cff3fbb(x5906905c888d3d98);
		}
		else
		{
			x56410a8dd70087c5 x7f6ad514996fb03a = x2171c110ade1f79e.x7f6ad514996fb03a;
			x8d9303345f12a846 x31e6518f5e08db6c2;
			if (x7f6ad514996fb03a == null || x7f6ad514996fb03a.x406d8cd2af514771 != x31e6518f5e08db6c)
			{
				x31e6518f5e08db6c2 = ((x7f6ad514996fb03a == null) ? x3f83765b73f31aa4(x31e6518f5e08db6c, x5906905c888d3d98.x772764427592d4bb, x3ea1cab4b5f1dac3: true) : ((!x5566e2d2acbd1fbe.xff7735def89bf56b(x7f6ad514996fb03a.x5566e2d2acbd1fbe)) ? x3f83765b73f31aa4(x7f6ad514996fb03a.x406d8cd2af514771, x5906905c888d3d98.x772764427592d4bb, x3ea1cab4b5f1dac3: false) : ((x7f6ad514996fb03a.x772764427592d4bb != x5906905c888d3d98.x772764427592d4bb) ? x3f83765b73f31aa4(x7f6ad514996fb03a.x406d8cd2af514771, x5906905c888d3d98.x772764427592d4bb, x3ea1cab4b5f1dac3: false) : x7f6ad514996fb03a.x406d8cd2af514771)));
			}
			else
			{
				x3df13c9311a0ba9b(x31e6518f5e08db6c, x7f6ad514996fb03a);
				x31e6518f5e08db6c2 = ((x31e6518f5e08db6c.xf36c5c9e57c969ad() == x5906905c888d3d98.x772764427592d4bb) ? x31e6518f5e08db6c : x3f83765b73f31aa4(x31e6518f5e08db6c, x5906905c888d3d98.x772764427592d4bb, x3ea1cab4b5f1dac3: false));
			}
			x841a9642da9aa496(x31e6518f5e08db6c2, x2171c110ade1f79e, x5906905c888d3d98);
		}
	}

	private static void x67eeecfbdb45346b(x8d9303345f12a846 x31e6518f5e08db6c, x56410a8dd70087c5 x5906905c888d3d98)
	{
		int num = x31e6518f5e08db6c.xf36c5c9e57c969ad();
		if (num != x5906905c888d3d98.x772764427592d4bb)
		{
			x5906905c888d3d98.x772764427592d4bb = num;
		}
	}

	private static void x8528b59a769e9f0a(x8d9303345f12a846 x31e6518f5e08db6c, x56410a8dd70087c5 x2171c110ade1f79e, x56410a8dd70087c5 x5906905c888d3d98)
	{
		x5906905c888d3d98.xbc13914359462815 = x2171c110ade1f79e;
		x5906905c888d3d98.x3e8d56eefc6dfdad = x2171c110ade1f79e?.x7f6ad514996fb03a;
		if (x5906905c888d3d98.x61712f0b4f5455af != null)
		{
			x5906905c888d3d98.x61712f0b4f5455af.x3e8d56eefc6dfdad = x5906905c888d3d98;
		}
		if (x5906905c888d3d98.x7f6ad514996fb03a != null)
		{
			x5906905c888d3d98.x7f6ad514996fb03a.xbc13914359462815 = x5906905c888d3d98;
		}
		if (x31e6518f5e08db6c.x0eafd527bd1e778e == null || x31e6518f5e08db6c.x0eafd527bd1e778e.x7f6ad514996fb03a == x5906905c888d3d98)
		{
			x31e6518f5e08db6c.x0eafd527bd1e778e = x5906905c888d3d98;
		}
		if (x31e6518f5e08db6c.x2be2727bb322530e == null || x31e6518f5e08db6c.x2be2727bb322530e.x61712f0b4f5455af == x5906905c888d3d98)
		{
			x31e6518f5e08db6c.x2be2727bb322530e = x5906905c888d3d98;
		}
		x5906905c888d3d98.x332a8eedb847940d = x31e6518f5e08db6c;
		x31e6518f5e08db6c.x8db1e90bce56e416(x5906905c888d3d98).xbc4db1b9481c1d31(x5906905c888d3d98);
		xbba4ca0462c7486f.x59ffb83fd2ec03c5(x5906905c888d3d98);
		xbba4ca0462c7486f.xe276d9c95797c034(x5906905c888d3d98);
		x31e6518f5e08db6c.x89d8cf71874cebb8();
	}

	private static void x94b50805164237ec(x8d9303345f12a846 x31e6518f5e08db6c, x56410a8dd70087c5 x5906905c888d3d98)
	{
		if (x5906905c888d3d98.x5566e2d2acbd1fbe == 21537)
		{
			return;
		}
		if (x5566e2d2acbd1fbe.x74f5d3c8c1c169b6(x5906905c888d3d98.x5566e2d2acbd1fbe))
		{
			if (x31e6518f5e08db6c.xbc13914359462815 != null)
			{
				x31e6518f5e08db6c.x332a8eedb847940d.x3df13c9311a0ba9b(x31e6518f5e08db6c);
			}
			return;
		}
		if (x5566e2d2acbd1fbe.x1f181a8f918a6604(x5906905c888d3d98.x5566e2d2acbd1fbe) && x31e6518f5e08db6c.xbc13914359462815 != null)
		{
			x31e6518f5e08db6c.x332a8eedb847940d.x3df13c9311a0ba9b(x31e6518f5e08db6c);
		}
		if (x5566e2d2acbd1fbe.x136f1ea510f02333(x5906905c888d3d98.x5566e2d2acbd1fbe) && x31e6518f5e08db6c.x332a8eedb847940d.xbc13914359462815 != null)
		{
			x31e6518f5e08db6c.x332a8eedb847940d.x332a8eedb847940d.x3df13c9311a0ba9b(x31e6518f5e08db6c.x332a8eedb847940d);
		}
		if (x5566e2d2acbd1fbe.x4215e7520479ea58(x5906905c888d3d98.x5566e2d2acbd1fbe) && x31e6518f5e08db6c.x332a8eedb847940d.x332a8eedb847940d.xbc13914359462815 != null)
		{
			x31e6518f5e08db6c.x332a8eedb847940d.x332a8eedb847940d.x332a8eedb847940d.x3df13c9311a0ba9b(x31e6518f5e08db6c.x332a8eedb847940d.x332a8eedb847940d);
		}
	}

	private static void x72cefbd49cff3fbb(x56410a8dd70087c5 x5906905c888d3d98)
	{
		if (x5566e2d2acbd1fbe.x8197188ddb6f93d3(x5906905c888d3d98.x5566e2d2acbd1fbe))
		{
			x5906905c888d3d98.x406d8cd2af514771.x705ed5f9769744e5 = x5906905c888d3d98.xa79651e2f1a1416e;
		}
		if (!x5566e2d2acbd1fbe.x74f5d3c8c1c169b6(x5906905c888d3d98.x5566e2d2acbd1fbe))
		{
			if (x5566e2d2acbd1fbe.x1f181a8f918a6604(x5906905c888d3d98.x5566e2d2acbd1fbe) && !x5566e2d2acbd1fbe.x136f1ea510f02333(x5906905c888d3d98.x5566e2d2acbd1fbe))
			{
				x5906905c888d3d98.x406d8cd2af514771.x332a8eedb847940d.x705ed5f9769744e5 = x5906905c888d3d98.xdfd0c9de0b4aa96a;
			}
			if (x5566e2d2acbd1fbe.x136f1ea510f02333(x5906905c888d3d98.x5566e2d2acbd1fbe))
			{
				x5906905c888d3d98.x406d8cd2af514771.x332a8eedb847940d.x332a8eedb847940d.x705ed5f9769744e5 = x5906905c888d3d98.x768f9befb545345a;
			}
			if (x5566e2d2acbd1fbe.x4215e7520479ea58(x5906905c888d3d98.x5566e2d2acbd1fbe))
			{
				x5906905c888d3d98.x406d8cd2af514771.x332a8eedb847940d.x332a8eedb847940d.x332a8eedb847940d.x705ed5f9769744e5 = x5906905c888d3d98.xeb54885ba753f70e;
			}
		}
		else if (x5906905c888d3d98.x53111d6596d16a99.xf684fc5abe7ca67a)
		{
			x5906905c888d3d98.x406d8cd2af514771.x2cbc0fc707d2e1eb().x705ed5f9769744e5 = x5906905c888d3d98.xa70fedcedcd0e1da;
		}
		x5906905c888d3d98.x835e25325f5f515d();
	}

	private static x8d9303345f12a846 x3f83765b73f31aa4(x8d9303345f12a846 x31e6518f5e08db6c, int xb538f46557da764b, bool x3ea1cab4b5f1dac3)
	{
		x8d9303345f12a846 x8d9303345f12a847 = (x8d9303345f12a846)x31e6518f5e08db6c.x8b61531c8ea35b85();
		int num = x31e6518f5e08db6c.xf36c5c9e57c969ad();
		if (xb538f46557da764b == num)
		{
			x31e6518f5e08db6c.x332a8eedb847940d.x45a34609c70da3e5(x3ea1cab4b5f1dac3 ? x31e6518f5e08db6c.x3e8d56eefc6dfdad : x31e6518f5e08db6c, null, x8d9303345f12a847);
		}
		else if (xb538f46557da764b > num)
		{
			xc1e43d6be7c1713c xc1e43d6be7c1713c2 = x802f9db57bcae6dc(x31e6518f5e08db6c, xb538f46557da764b - num, x3ea1cab4b5f1dac3);
			xc1e43d6be7c1713c2.x45a34609c70da3e5(null, null, x8d9303345f12a847);
		}
		else
		{
			xc63cc34daaa2e2d9 xc63cc34daaa2e2d10 = x713aa3dff7f6e9a2(x31e6518f5e08db6c, num - xb538f46557da764b, x3ea1cab4b5f1dac3);
			xc63cc34daaa2e2d10.x332a8eedb847940d.x45a34609c70da3e5(x3ea1cab4b5f1dac3 ? xc63cc34daaa2e2d10.x3e8d56eefc6dfdad : xc63cc34daaa2e2d10, null, x8d9303345f12a847);
		}
		return x8d9303345f12a847;
	}

	private static xc63cc34daaa2e2d9 x713aa3dff7f6e9a2(xc63cc34daaa2e2d9 x2612f62f94df47de, int xe3991fd7371c9315, bool x3ea1cab4b5f1dac3)
	{
		xc1e43d6be7c1713c xb6a159a84cb992d = (xc1e43d6be7c1713c)x2612f62f94df47de.x332a8eedb847940d;
		while (0 < xe3991fd7371c9315)
		{
			x2612f62f94df47de = x935d76adef5c9f1a(ref xb6a159a84cb992d, x2612f62f94df47de, x3ea1cab4b5f1dac3);
			x2612f62f94df47de = x935d76adef5c9f1a(ref xb6a159a84cb992d, x2612f62f94df47de, x3ea1cab4b5f1dac3);
			x2612f62f94df47de = x935d76adef5c9f1a(ref xb6a159a84cb992d, x2612f62f94df47de, x3ea1cab4b5f1dac3);
			xe3991fd7371c9315--;
		}
		return x2612f62f94df47de;
	}

	private static xc63cc34daaa2e2d9 x935d76adef5c9f1a(ref xc1e43d6be7c1713c xb6a159a84cb992d6, xc63cc34daaa2e2d9 x2612f62f94df47de, bool x3ea1cab4b5f1dac3)
	{
		if ((x2612f62f94df47de.xbc13914359462815 != null && !x3ea1cab4b5f1dac3) || (x2612f62f94df47de.x3e8d56eefc6dfdad != null && x3ea1cab4b5f1dac3))
		{
			xb6a159a84cb992d6.x3df13c9311a0ba9b(x3ea1cab4b5f1dac3 ? x2612f62f94df47de.x3e8d56eefc6dfdad : x2612f62f94df47de);
		}
		x2612f62f94df47de = xb6a159a84cb992d6;
		xb6a159a84cb992d6 = (xc1e43d6be7c1713c)x2612f62f94df47de.x332a8eedb847940d;
		return x2612f62f94df47de;
	}

	private static x56b4eac69b5fa65b x802f9db57bcae6dc(xc63cc34daaa2e2d9 x2612f62f94df47de, int xe3991fd7371c9315, bool x3ea1cab4b5f1dac3)
	{
		xc63cc34daaa2e2d9 xd9ff4dee1dba180e = (x3ea1cab4b5f1dac3 ? x2612f62f94df47de.x3e8d56eefc6dfdad : x2612f62f94df47de);
		xc1e43d6be7c1713c xc1e43d6be7c1713c2 = (xc1e43d6be7c1713c)x2612f62f94df47de.x332a8eedb847940d;
		xc1e43d6be7c1713c xc1e43d6be7c1713c3 = null;
		while (0 < xe3991fd7371c9315)
		{
			xc1e43d6be7c1713c3 = new x7c1e2b821e8b8220();
			xc1e43d6be7c1713c2.x45a34609c70da3e5(xd9ff4dee1dba180e, null, xc1e43d6be7c1713c3);
			xc1e43d6be7c1713c2 = xc1e43d6be7c1713c3;
			xd9ff4dee1dba180e = null;
			xc1e43d6be7c1713c3 = new x387d31b7e6ea1182();
			xc1e43d6be7c1713c2.x45a34609c70da3e5(xd9ff4dee1dba180e, null, xc1e43d6be7c1713c3);
			xc1e43d6be7c1713c2 = xc1e43d6be7c1713c3;
			xc1e43d6be7c1713c3 = new x56b4eac69b5fa65b();
			xc1e43d6be7c1713c2.x45a34609c70da3e5(xd9ff4dee1dba180e, null, xc1e43d6be7c1713c3);
			xc1e43d6be7c1713c2 = xc1e43d6be7c1713c3;
			xe3991fd7371c9315--;
		}
		return (x56b4eac69b5fa65b)xc1e43d6be7c1713c3;
	}

	private static void x3df13c9311a0ba9b(x8d9303345f12a846 x31e6518f5e08db6c, x56410a8dd70087c5 x0e990edf4549ee50)
	{
		if (x0e990edf4549ee50.x61712f0b4f5455af == null || x31e6518f5e08db6c != x0e990edf4549ee50.x61712f0b4f5455af.x406d8cd2af514771)
		{
			return;
		}
		if (x0e990edf4549ee50.x5a7799e1836857e3.x2be2727bb322530e != x0e990edf4549ee50)
		{
			x0e990edf4549ee50.x5a7799e1836857e3.x3df13c9311a0ba9b(x0e990edf4549ee50);
		}
		x8d9303345f12a846 x8d9303345f12a847 = (x8d9303345f12a846)x31e6518f5e08db6c.x8b61531c8ea35b85();
		x31e6518f5e08db6c.x332a8eedb847940d.x45a34609c70da3e5(x31e6518f5e08db6c, null, x8d9303345f12a847);
		x31e6518f5e08db6c.x0ec18313f761be96 = x0e990edf4549ee50.x5a7799e1836857e3;
		IList list = x31e6518f5e08db6c.xae38dac157c088d7(x0e990edf4549ee50.x61712f0b4f5455af.x5a7799e1836857e3, null);
		foreach (x398b3bd0acd94b61 item in list)
		{
			item.x332a8eedb847940d = x8d9303345f12a847;
		}
		x8d9303345f12a847.x927910b7aed705e2 = (xf6937c72cebe4ad1)list[0];
		x8d9303345f12a847.x0ec18313f761be96 = (xf6937c72cebe4ad1)list[list.Count - 1];
		x0e990edf4549ee50.x5a7799e1836857e3.xbc13914359462815 = null;
		x0e990edf4549ee50.x61712f0b4f5455af.x5a7799e1836857e3.x3e8d56eefc6dfdad = null;
		x31e6518f5e08db6c.x2be2727bb322530e = x0e990edf4549ee50;
		list = x31e6518f5e08db6c.xae38dac157c088d7(x0e990edf4549ee50.x61712f0b4f5455af, null);
		foreach (x398b3bd0acd94b61 item2 in list)
		{
			item2.x332a8eedb847940d = x8d9303345f12a847;
		}
		x8d9303345f12a847.x0eafd527bd1e778e = (x56410a8dd70087c5)list[0];
		x8d9303345f12a847.x2be2727bb322530e = (x56410a8dd70087c5)list[list.Count - 1];
	}

	private static void x7c6f7cd821c90d52(x8d9303345f12a846 x31e6518f5e08db6c)
	{
		x56410a8dd70087c5 x61712f0b4f5455af = x31e6518f5e08db6c.x2be2727bb322530e.x61712f0b4f5455af;
		if (x61712f0b4f5455af == null)
		{
			return;
		}
		xc63cc34daaa2e2d9[] array = x856e4b96fad5711e(x31e6518f5e08db6c);
		xc63cc34daaa2e2d9[] array2 = x856e4b96fad5711e(x61712f0b4f5455af.x406d8cd2af514771);
		int num = 0;
		if (array[num] != array2[num] && !x5566e2d2acbd1fbe.x74f5d3c8c1c169b6(x31e6518f5e08db6c.x2be2727bb322530e.x5566e2d2acbd1fbe))
		{
			array[num].xd5da23b762ce52a2();
		}
		num++;
		if (5 < array.Length)
		{
			for (; num < array.Length - 4 && num < array2.Length - 1; num++)
			{
				if (array[num] != array2[num])
				{
					array[num].xd5da23b762ce52a2();
				}
			}
			_ = array2.Length - 1;
		}
		if (2 < array.Length && num < array2.Length - 1)
		{
			if (array[num] != array2[num] && !x5566e2d2acbd1fbe.x4215e7520479ea58(x31e6518f5e08db6c.x2be2727bb322530e.x5566e2d2acbd1fbe))
			{
				array[num].xd5da23b762ce52a2();
			}
			num++;
			if (array[num] != array2[num] && !x5566e2d2acbd1fbe.x136f1ea510f02333(x31e6518f5e08db6c.x2be2727bb322530e.x5566e2d2acbd1fbe))
			{
				array[num].xd5da23b762ce52a2();
			}
			num++;
			if (array[num] != array2[num] && !x5566e2d2acbd1fbe.x1f181a8f918a6604(x31e6518f5e08db6c.x2be2727bb322530e.x5566e2d2acbd1fbe))
			{
				array[num].xd5da23b762ce52a2();
			}
			num++;
		}
		if (array[num] != array2[num] && !x5566e2d2acbd1fbe.x8197188ddb6f93d3(x31e6518f5e08db6c.x2be2727bb322530e.x5566e2d2acbd1fbe))
		{
			array[num].xd5da23b762ce52a2();
		}
	}

	private static xc63cc34daaa2e2d9[] x856e4b96fad5711e(xc63cc34daaa2e2d9 x2612f62f94df47de)
	{
		ArrayList arrayList = new ArrayList();
		while (x2612f62f94df47de != null)
		{
			arrayList.Add(x2612f62f94df47de);
			x2612f62f94df47de = x2612f62f94df47de.x332a8eedb847940d;
		}
		xc63cc34daaa2e2d9[] array = new xc63cc34daaa2e2d9[arrayList.Count - 1];
		arrayList.CopyTo(0, array, 0, arrayList.Count - 1);
		Array.Reverse(array);
		return array;
	}

	private static void x6f6af857029e4ead(x56410a8dd70087c5 xc25555cc3d1337f7, x56410a8dd70087c5 xc45ee7b4fb201e6c, x8d9303345f12a846 x334daba48175c7b5)
	{
		bool x0524267b51e1f4ba = xc25555cc3d1337f7.x2c8c6741422a1298.xdeb77ea37ad74c56.x0524267b51e1f4ba;
		if ((x0524267b51e1f4ba || !xc25555cc3d1337f7.xa79651e2f1a1416e.x7fc015364b8e5a44) && ((!x0524267b51e1f4ba && !(xc45ee7b4fb201e6c is xd14f50a067a58062)) || (x0524267b51e1f4ba && xc25555cc3d1337f7.x705ed5f9769744e5.x17c40acbe47f16cc)))
		{
			x41ccdd7753312e4f xa79651e2f1a1416e = xc25555cc3d1337f7.xa79651e2f1a1416e;
			x41ccdd7753312e4f x41ccdd7753312e4f2 = x41ccdd7753312e4f.xdb83cd4968ca9d31(x334daba48175c7b5.xa79651e2f1a1416e);
			x41ccdd7753312e4f2.xc0741c7ff92cf1aa = xa79651e2f1a1416e.xc0741c7ff92cf1aa;
			x41ccdd7753312e4f2.xc7d7e186f0ace1e0 = xa79651e2f1a1416e.xc7d7e186f0ace1e0;
			x334daba48175c7b5.x705ed5f9769744e5 = x41ccdd7753312e4f.x38758cbbee49e4cb(x41ccdd7753312e4f2);
		}
	}
}
