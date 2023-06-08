using System.Collections;

namespace x2182451cabb5c30d;

internal class x066f9243a946f443 : x3b57052406b93b82
{
	private string xb0f6bd58ed1c33c4;

	private string x1e8c33730f04a5fb;

	private readonly Hashtable x873e474df27816d8 = new Hashtable();

	internal x066f9243a946f443(xe5e546ef5f0503b2 context)
		: base(context)
	{
	}

	internal override void x41e7a76e7e854e6e(x03f56b37a0050a82 x153c99a852375422)
	{
		x25099a8bbbd55d1c x3146d638ec = base.x1a55de3a01c1c82d.x3146d638ec378671;
		if (x3146d638ec == x25099a8bbbd55d1c.x8828ea8cd5c8ef5d)
		{
			xb0f6bd58ed1c33c4 = null;
			x1e8c33730f04a5fb = null;
		}
		else
		{
			base.x41e7a76e7e854e6e(x153c99a852375422);
		}
	}

	internal override void xa4085ff83f9ddeeb()
	{
		x25099a8bbbd55d1c x3146d638ec = base.x1a55de3a01c1c82d.x3146d638ec378671;
		if (x3146d638ec == x25099a8bbbd55d1c.x8828ea8cd5c8ef5d)
		{
			base.x2c8c6741422a1298.Variables.Add(xb0f6bd58ed1c33c4, x1e8c33730f04a5fb);
		}
		else
		{
			base.xa4085ff83f9ddeeb();
		}
	}

	internal override void xbd6083b329527c4e(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (base.x1a55de3a01c1c82d.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x3d75ee2af8ab22ab:
			base.xbd6083b329527c4e(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x79390bd50831438c:
			base.x2c8c6741422a1298.xdade2366eaa6f915.x8c0ad447fda248da = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.x86fd518c614ba0b8:
			base.x2c8c6741422a1298.xdade2366eaa6f915.x57a3ba5e84591507 = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.x8828ea8cd5c8ef5d:
			if (xb0f6bd58ed1c33c4 == null)
			{
				xb0f6bd58ed1c33c4 = x153c99a852375422.x9f1a6a3451a38d10();
			}
			else
			{
				x1e8c33730f04a5fb = x153c99a852375422.x9f1a6a3451a38d10();
			}
			break;
		case x25099a8bbbd55d1c.x83969420743625bc:
			x28fcdc775a1d069c.x2086e697b5620586.xd6b6ed77479ef68c(x153c99a852375422.x8b1c61c709b6f253());
			break;
		case x25099a8bbbd55d1c.xac6d65e3ddd73427:
			x7364ac353cb5a0c9.x06b0e25aa6ad68a9(x153c99a852375422.x9f1a6a3451a38d10(), base.x2c8c6741422a1298.xdade2366eaa6f915.xc57807e17cfa13d2.x218603e609fcc201);
			break;
		case x25099a8bbbd55d1c.xfc32bf4854f4898d:
		{
			x2dce569e9052de2d x2dce569e9052de2d2 = new x2dce569e9052de2d(x153c99a852375422.x9f1a6a3451a38d10());
			base.x2c8c6741422a1298.xdade2366eaa6f915.xfc32bf4854f4898d = x2dce569e9052de2d2.x2e6b89ad8001e18f();
			break;
		}
		default:
			base.xbd6083b329527c4e(x153c99a852375422);
			break;
		}
	}

	internal override void xa2d8e36cb99ac0f4(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\ansi":
			x28fcdc775a1d069c.x1ea60bde2b5d0d28.xf6968566e57d2798 = 1252;
			break;
		case "\\mac":
			x28fcdc775a1d069c.x1ea60bde2b5d0d28.xf6968566e57d2798 = 10000;
			break;
		case "\\pc":
			x28fcdc775a1d069c.x1ea60bde2b5d0d28.xf6968566e57d2798 = 437;
			break;
		case "\\pca":
			x28fcdc775a1d069c.x1ea60bde2b5d0d28.xf6968566e57d2798 = 850;
			break;
		case "\\ansicpg":
		{
			int num = x153c99a852375422.xd6f9e3c5ae6509d7();
			if (num >= 0 && num <= 65535)
			{
				x28fcdc775a1d069c.x1ea60bde2b5d0d28.xf6968566e57d2798 = num;
			}
			else
			{
				x28fcdc775a1d069c.x1ea60bde2b5d0d28.xf6968566e57d2798 = 1252;
			}
			break;
		}
		case "\\deff":
			x28fcdc775a1d069c.x1ea60bde2b5d0d28.x2ddab4ad01316604 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\stshfloch":
			x28fcdc775a1d069c.x1ea60bde2b5d0d28.xf1034b7f118809b3.xae20093bed1e48a8(230, x153c99a852375422.xd6f9e3c5ae6509d7());
			break;
		case "\\stshfdbch":
			x28fcdc775a1d069c.x1ea60bde2b5d0d28.xf1034b7f118809b3.xae20093bed1e48a8(235, x153c99a852375422.xd6f9e3c5ae6509d7());
			break;
		case "\\stshfhich":
			x28fcdc775a1d069c.x1ea60bde2b5d0d28.xf1034b7f118809b3.xae20093bed1e48a8(240, x153c99a852375422.xd6f9e3c5ae6509d7());
			break;
		case "\\stshfbi":
			x28fcdc775a1d069c.x1ea60bde2b5d0d28.xf1034b7f118809b3.xae20093bed1e48a8(270, x153c99a852375422.xd6f9e3c5ae6509d7());
			break;
		default:
			base.xa2d8e36cb99ac0f4(x153c99a852375422);
			break;
		}
	}

	internal override x77fb5b1d5c73757b x3e0bce851c12a688(xbf575e106f2f2373 x8d3f74e5f925679c)
	{
		switch (x8d3f74e5f925679c.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x88bf28725f671e38:
			return new xaa3301875e5e81d5(x28fcdc775a1d069c);
		case x25099a8bbbd55d1c.x1f12cbed334321cb:
			return new xd94e350e15f3b071(x28fcdc775a1d069c);
		case x25099a8bbbd55d1c.x8b1cb9d9e99957fd:
		case x25099a8bbbd55d1c.x238bf167ccfdd282:
		case x25099a8bbbd55d1c.x191dcb88c409b8dd:
		case x25099a8bbbd55d1c.xb063bbfcfeade526:
		case x25099a8bbbd55d1c.x460ab163f44a604d:
		case x25099a8bbbd55d1c.xcd76cf11e368bbb7:
		case x25099a8bbbd55d1c.x3924d9c4d0914f45:
		case x25099a8bbbd55d1c.x65f1c5fa03df41d5:
		case x25099a8bbbd55d1c.x9ee8adcec1e2f351:
		case x25099a8bbbd55d1c.x514c0ea24ce40ef0:
		case x25099a8bbbd55d1c.x4e020dae918bd2ce:
		case x25099a8bbbd55d1c.x3495c9728d107e27:
		case x25099a8bbbd55d1c.x46d7a886a16e7d52:
		case x25099a8bbbd55d1c.x412556343b1cb75e:
		case x25099a8bbbd55d1c.x13964cbdcc2ac7cf:
		case x25099a8bbbd55d1c.x97fd7ee24073e9ef:
			return new x6bdf715e14ebfd8b(x28fcdc775a1d069c);
		case x25099a8bbbd55d1c.x4f52398a8225e3d4:
			return new x6ee65bbda9516e17(x28fcdc775a1d069c);
		case x25099a8bbbd55d1c.xd5208d8e1e3a3e5f:
			return new xa643f5c4a202fda5(x28fcdc775a1d069c);
		case x25099a8bbbd55d1c.xccc4aace2acc681c:
			return new xd05bf601528fbb64(x28fcdc775a1d069c, x873e474df27816d8);
		case x25099a8bbbd55d1c.xdbe1f09404874fc9:
			return new xfb933939610e0899(x28fcdc775a1d069c, x873e474df27816d8);
		case x25099a8bbbd55d1c.x8119232d8a051462:
		case x25099a8bbbd55d1c.xe371885afc332af6:
		case x25099a8bbbd55d1c.xa02784f65694ca5f:
		case x25099a8bbbd55d1c.x244ef638ba612102:
		case x25099a8bbbd55d1c.x0498ce72dad89268:
		case x25099a8bbbd55d1c.x70db6c6c5d95991c:
		case x25099a8bbbd55d1c.x18a8ea22afe9348e:
		case x25099a8bbbd55d1c.xece13b02cb4b1216:
			return new x69c31a748f1ec0d5(x28fcdc775a1d069c);
		case x25099a8bbbd55d1c.xa1e2a8ed32a026dd:
		case x25099a8bbbd55d1c.xeab6532eb0797a6e:
		case x25099a8bbbd55d1c.x1e0d716fba95db43:
		case x25099a8bbbd55d1c.x0affbe34bb1f8b8b:
		case x25099a8bbbd55d1c.x354a2c7b596483f1:
		case x25099a8bbbd55d1c.x281934d7c2c96a88:
			return new xb5119fc69b53f43b(x28fcdc775a1d069c);
		case x25099a8bbbd55d1c.x79390bd50831438c:
		case x25099a8bbbd55d1c.x86fd518c614ba0b8:
		case x25099a8bbbd55d1c.x8828ea8cd5c8ef5d:
		case x25099a8bbbd55d1c.x83969420743625bc:
		case x25099a8bbbd55d1c.x5ab5a058833da74f:
		case x25099a8bbbd55d1c.xac6d65e3ddd73427:
		case x25099a8bbbd55d1c.xfc32bf4854f4898d:
			return this;
		case x25099a8bbbd55d1c.x90347bcd8deede01:
			return new x2d9ca1c983037fc4(x28fcdc775a1d069c);
		case x25099a8bbbd55d1c.x1034e0e08a491ded:
			return new x568fcff574baff75(x28fcdc775a1d069c);
		case x25099a8bbbd55d1c.x62fbf4dd585f8a01:
			return new x0aef601223d08f3b(x28fcdc775a1d069c);
		case x25099a8bbbd55d1c.x0f1b548a1d4927cb:
			return new x325a9841c7a9970e(x28fcdc775a1d069c);
		default:
			return base.x3e0bce851c12a688(x8d3f74e5f925679c);
		}
	}
}
