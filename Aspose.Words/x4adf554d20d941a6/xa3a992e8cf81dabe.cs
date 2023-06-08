using System;
using System.Drawing;
using Aspose.Words;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal class xa3a992e8cf81dabe
{
	internal static int x795e09a07e435cf4(x56b4eac69b5fa65b x2612f62f94df47de)
	{
		if (!x2612f62f94df47de.xc0e56f2fca892328)
		{
			return x2612f62f94df47de.x2f5fd09b3d327fb0.x419ba17a5322627b;
		}
		return x6a99a91d69d51674(x2612f62f94df47de.x838c6c67b5953bb0, -x2612f62f94df47de.x838c6c67b5953bb0.x768f9befb545345a.x0364c07ad4dcfe0c);
	}

	internal static int xc7c6550a888abaf3(x56b4eac69b5fa65b x2612f62f94df47de)
	{
		if (x2612f62f94df47de.xb2e852052ab1c1be == null)
		{
			return 0;
		}
		int num = 0;
		int num2 = x2612f62f94df47de.xa8c2682cb8534de2();
		int[] x03bb6a33fcd217b = x2612f62f94df47de.x838c6c67b5953bb0.x133f2db9e5b5690d.x03bb6a33fcd217b4;
		int x6e1eb96b81362ebc = x2612f62f94df47de.xdfd0c9de0b4aa96a.x6e1eb96b81362ebc;
		for (int i = 0; i < x6e1eb96b81362ebc && num2 + i < x03bb6a33fcd217b.Length; i++)
		{
			num += x03bb6a33fcd217b[num2 + i];
		}
		return num;
	}

	internal static int xa1de765ea88f71a2(x56b4eac69b5fa65b x2612f62f94df47de)
	{
		if (x2612f62f94df47de.x55b6066f30988caf)
		{
			if (x2612f62f94df47de.x2f5fd09b3d327fb0 != null)
			{
				return x084819436cb905ef(x2612f62f94df47de.x2f5fd09b3d327fb0, BorderType.Right) / 2;
			}
			return 0;
		}
		return Math.Max(x2612f62f94df47de.xdfd0c9de0b4aa96a.xcad2e59522947ede, x084819436cb905ef(x2612f62f94df47de, BorderType.Left) / 2);
	}

	internal static int xb5e088b6b5dc233d(x56b4eac69b5fa65b x2612f62f94df47de)
	{
		if (x2612f62f94df47de.x55b6066f30988caf)
		{
			return 0;
		}
		return Math.Max(x2612f62f94df47de.xdfd0c9de0b4aa96a.x41c99cca24bc80be, x084819436cb905ef(x2612f62f94df47de, BorderType.Right) / 2);
	}

	internal static int x99c80529a1c59616(x86accec882b7012a xe6de5e5fa2d44af5)
	{
		if (xe6de5e5fa2d44af5.xfdc6650195492419 || xe6de5e5fa2d44af5.x7149c962c02931b3)
		{
			return 0;
		}
		x398b3bd0acd94b61 x398b3bd0acd94b62 = xe6de5e5fa2d44af5.xe0a65b356d2eb477(null);
		int num = ((x398b3bd0acd94b62 != null) ? (x398b3bd0acd94b62.x9bcb07e204e30218 - xe6de5e5fa2d44af5.x3dcafc2d758260e1) : 0);
		xd4c1d21f07094800 xd4c1d21f7094801 = xe6de5e5fa2d44af5.xf9d5944b191eb276(x5aa7d09b258e0f23: false);
		if (xd4c1d21f7094801 != null)
		{
			int bottom = xd4c1d21f7094801.x37b1dbbad6246778().Bottom;
			int val = ((bottom != int.MinValue) ? (bottom - xe6de5e5fa2d44af5.x3dcafc2d758260e1) : 0);
			num = Math.Max(val, num);
		}
		return Math.Max(num, 0);
	}

	internal static int x718661739aaa907b(x86accec882b7012a xe6de5e5fa2d44af5, bool x41537952ab630933, bool x39df78691dbb02b2)
	{
		x387d31b7e6ea1182 x838c6c67b5953bb = xe6de5e5fa2d44af5.xc5464084edc8e226.x838c6c67b5953bb0;
		HeightRule x85e9ab4255d7e70c = x838c6c67b5953bb.x768f9befb545345a.x85e9ab4255d7e70c;
		if (x85e9ab4255d7e70c == HeightRule.Exactly)
		{
			return x838c6c67b5953bb.x768f9befb545345a.xb0f146032f47c24e + xe6de5e5fa2d44af5.x798272c9805cc00e.x79a071bfba0c5e7d;
		}
		int num = 0;
		if (!xe6de5e5fa2d44af5.x7149c962c02931b3 && !xe6de5e5fa2d44af5.xfdc6650195492419 && (xe6de5e5fa2d44af5.xc5464084edc8e226.x6c68e8efd3a92e85 == x6c68e8efd3a92e85.x4d0b9d4447ba7566 || x39df78691dbb02b2))
		{
			if (xe6de5e5fa2d44af5.x8b8a0a04b3aeaf3a.x954503abc583f675 == x954503abc583f675.x48cc0c3eaf9f5f05)
			{
				num = xe6de5e5fa2d44af5.x8b8a0a04b3aeaf3a.x319720dedc082a9d;
			}
			else
			{
				x694f001896973fe3 x694f001896973fe4 = (x694f001896973fe3)xe6de5e5fa2d44af5.x8b8a0a04b3aeaf3a;
				num = (x41537952ab630933 ? x694f001896973fe4.x647980b7bc85885a : x694f001896973fe4.xde5f4b1d50e6b329);
			}
		}
		if (!x41537952ab630933 && x838c6c67b5953bb.x768f9befb545345a.x85e9ab4255d7e70c == HeightRule.AtLeast)
		{
			num = Math.Max(num, x838c6c67b5953bb.x768f9befb545345a.xb0f146032f47c24e);
		}
		return num + (xe6de5e5fa2d44af5.x798272c9805cc00e.x887a0c79ecbe5ee3 + xe6de5e5fa2d44af5.x798272c9805cc00e.x79a071bfba0c5e7d);
	}

	internal static int x084819436cb905ef(x56b4eac69b5fa65b x2612f62f94df47de, BorderType xe6e655492739f7d2)
	{
		if (x2612f62f94df47de.x55b6066f30988caf && BorderType.Left != xe6e655492739f7d2)
		{
			return 0;
		}
		x71a4a9bfdf7899a6 xdfd0c9de0b4aa96a = x2612f62f94df47de.xdfd0c9de0b4aa96a;
		if (xdfd0c9de0b4aa96a == null || xdfd0c9de0b4aa96a.xb70a9d14469748bf == null || xdfd0c9de0b4aa96a.xb70a9d14469748bf.get_xe6d4b1b411ed94b5(xe6e655492739f7d2) == null)
		{
			return 0;
		}
		return xdfd0c9de0b4aa96a.xb70a9d14469748bf.get_xe6d4b1b411ed94b5(xe6e655492739f7d2).x0b5855089a074d93;
	}

	internal static RectangleF xe6cffb3d72baa311(x86accec882b7012a xe6de5e5fa2d44af5)
	{
		int num = x084819436cb905ef(xe6de5e5fa2d44af5.xc5464084edc8e226, BorderType.Left) / 2;
		int num2 = x084819436cb905ef(xe6de5e5fa2d44af5.xc5464084edc8e226, BorderType.Top);
		Rectangle xf671230c49fb86ad = new Rectangle(num, num2, xe6de5e5fa2d44af5.xdc1bf80853046136 - num - x084819436cb905ef(xe6de5e5fa2d44af5.xc5464084edc8e226, BorderType.Right) / 2, xdab87d3e2c659d95(xe6de5e5fa2d44af5, x39df78691dbb02b2: true) - num2);
		return x4574ea26106f0edb.xc96d70553223ee04(xf671230c49fb86ad);
	}

	internal static RectangleF x1049a67c4c918fe0(x86accec882b7012a xe6de5e5fa2d44af5)
	{
		return x4574ea26106f0edb.xc96d70553223ee04(new Rectangle(0, 0, xe6de5e5fa2d44af5.xdc1bf80853046136, xdab87d3e2c659d95(xe6de5e5fa2d44af5, x39df78691dbb02b2: false)));
	}

	internal static int xdab87d3e2c659d95(x86accec882b7012a xe6de5e5fa2d44af5, bool x39df78691dbb02b2)
	{
		if (!x39df78691dbb02b2 || xe6de5e5fa2d44af5.xc5464084edc8e226.x6c68e8efd3a92e85 != x6c68e8efd3a92e85.x38ced5a01a389303)
		{
			return xe49914456d73f03a.xdab87d3e2c659d95(xe6de5e5fa2d44af5.x798272c9805cc00e);
		}
		x56b4eac69b5fa65b x56b4eac69b5fa65b2 = xa6c6ed003f022075.x52ed17204d837166(xe6de5e5fa2d44af5.xc5464084edc8e226, xe6de5e5fa2d44af5.x798272c9805cc00e.x838c6c67b5953bb0);
		int num = 0;
		x694f001896973fe3 x694f001896973fe4 = xe6de5e5fa2d44af5.x798272c9805cc00e;
		while (x694f001896973fe4 != null)
		{
			if (x56b4eac69b5fa65b2.x332a8eedb847940d != x694f001896973fe4.x332a8eedb847940d)
			{
				x56b4eac69b5fa65b2 = x56b4eac69b5fa65b2.xea12dbf0aee845fc;
			}
			if (x56b4eac69b5fa65b2 == null || !x694f001896973fe4.xe5764fe5359a6d91)
			{
				break;
			}
			num += xe49914456d73f03a.xdab87d3e2c659d95(x694f001896973fe4);
			x398b3bd0acd94b61 x398b3bd0acd94b62 = x694f001896973fe4.xf432ece93e450408();
			x694f001896973fe4 = ((x398b3bd0acd94b62 is x694f001896973fe3) ? ((x694f001896973fe3)x398b3bd0acd94b62) : null);
		}
		return num;
	}

	internal static int x97761a9f20472ac6(x86accec882b7012a xe6de5e5fa2d44af5)
	{
		x694f001896973fe3 x2aa5114a5da7d6c = null;
		if (xe6de5e5fa2d44af5.xc5464084edc8e226.x6c68e8efd3a92e85 == x6c68e8efd3a92e85.x38ced5a01a389303)
		{
			x2aa5114a5da7d6c = x36d44214ff2c1e83.xc72f32bc1d4d9a27(xe6de5e5fa2d44af5);
		}
		return x9cffa0aae6b55286(xe6de5e5fa2d44af5, x2aa5114a5da7d6c);
	}

	private static int x9cffa0aae6b55286(x86accec882b7012a xe6de5e5fa2d44af5, x694f001896973fe3 x2aa5114a5da7d6c8)
	{
		x387d31b7e6ea1182 x838c6c67b5953bb = xe6de5e5fa2d44af5.xc5464084edc8e226.x838c6c67b5953bb0;
		int x887a0c79ecbe5ee = xe6de5e5fa2d44af5.x798272c9805cc00e.x887a0c79ecbe5ee3;
		x887a0c79ecbe5ee += x26f8a702152631c7(xe6de5e5fa2d44af5, x838c6c67b5953bb);
		return x887a0c79ecbe5ee + (x2aa5114a5da7d6c8?.x79a071bfba0c5e7d ?? xe6de5e5fa2d44af5.x798272c9805cc00e.x79a071bfba0c5e7d);
	}

	internal static int x26f8a702152631c7(x398b3bd0acd94b61 xd7e5673853e47af4, x387d31b7e6ea1182 x2612f62f94df47de)
	{
		return x2612f62f94df47de.x768f9befb545345a.x85e9ab4255d7e70c switch
		{
			HeightRule.Exactly => x2612f62f94df47de.x768f9befb545345a.xb0f146032f47c24e - ((xd7e5673853e47af4.x954503abc583f675 == x954503abc583f675.xa19781cfbe8b4961) ? ((x694f001896973fe3)xd7e5673853e47af4).x887a0c79ecbe5ee3 : ((x86accec882b7012a)xd7e5673853e47af4).x798272c9805cc00e.x887a0c79ecbe5ee3), 
			HeightRule.AtLeast => Math.Max(x2612f62f94df47de.x768f9befb545345a.xb0f146032f47c24e, xd7e5673853e47af4.xbcd477821fdbd81b), 
			_ => xd7e5673853e47af4.xbcd477821fdbd81b, 
		};
	}

	internal static int x6a99a91d69d51674(x387d31b7e6ea1182 xa806b754814b9ae0, int xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 == 0)
		{
			return 0;
		}
		if (xa806b754814b9ae0.x768f9befb545345a.x9ba359ff37a3a63b != 0 && xa806b754814b9ae0.x2c8c6741422a1298.x80f061859cd048ae.xde015839cc88f18d.xbdfb47a8b2b25dd9)
		{
			return 0;
		}
		int[] x03bb6a33fcd217b = xa806b754814b9ae0.x133f2db9e5b5690d.x03bb6a33fcd217b4;
		int num = ((0 <= xbcea506a33cf9111) ? (x03bb6a33fcd217b.Length - xbcea506a33cf9111) : 0);
		int num2 = ((0 > xbcea506a33cf9111) ? (-xbcea506a33cf9111) : x03bb6a33fcd217b.Length);
		int num3 = 0;
		for (int i = num; i < num2; i++)
		{
			num3 += x03bb6a33fcd217b[i];
		}
		return num3;
	}

	internal static RectangleF xb525df69a6e7d8ef(x86accec882b7012a xd7e5673853e47af4, bool x39df78691dbb02b2)
	{
		int x887a0c79ecbe5ee = xd7e5673853e47af4.x798272c9805cc00e.x887a0c79ecbe5ee3;
		int num = xa1de765ea88f71a2(xd7e5673853e47af4.xc5464084edc8e226);
		int num2 = xb5e088b6b5dc233d(xd7e5673853e47af4.xc5464084edc8e226);
		int width = Math.Max(0, xd7e5673853e47af4.xdc1bf80853046136 - num - num2);
		int height = Math.Max(0, xdab87d3e2c659d95(xd7e5673853e47af4, x39df78691dbb02b2) - xd7e5673853e47af4.x798272c9805cc00e.x79a071bfba0c5e7d) - x887a0c79ecbe5ee;
		return x4574ea26106f0edb.xc96d70553223ee04(new Rectangle(num, x887a0c79ecbe5ee, width, height));
	}
}
