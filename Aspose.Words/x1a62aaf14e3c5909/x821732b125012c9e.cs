using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Drawing;
using x13f1efc79617a47b;

namespace x1a62aaf14e3c5909;

internal class x821732b125012c9e
{
	private readonly x373059570f6cfe23 x8cedcaa9a62c6e39;

	private readonly x3fadcf0602460de6 x5bb197a3bd3e47ae;

	internal static bool x492f529cee830a40;

	internal x821732b125012c9e(x373059570f6cfe23 context)
	{
		x8cedcaa9a62c6e39 = context;
		x5bb197a3bd3e47ae = new x3fadcf0602460de6(context);
	}

	internal ShapeBase x8c713173570e8643(xddf6304144fd3863 x40bb35f2f56a1197)
	{
		return x40bb35f2f56a1197.x1ea60bde2b5d0d28.x3146d638ec378671 switch
		{
			x773fe540042dad03.xf556a619f6f995f0 => xc4eb75b54b61d36c((x0c6eac1af67f9f81)x40bb35f2f56a1197), 
			x773fe540042dad03.xf6e35fb163f1c232 => xac287a575a05d160((xc6764e97e740ec5a)x40bb35f2f56a1197), 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ohnmejenoilnoicomijobjapfihpedopghfabimaogdbahkbkgbcehicpbpcoggdofndjfeecglecgcfbfjfkaaglfhgnfogbffhdemhlpcibekidebjcphjadpjmofkadnkidelcdllfdcmncjmknpmkbhndconpbfoccmomadpbbkpdbbahaiabbpakmfb", 1593560361))), 
		};
	}

	internal x21ad3b7fe343bc74 xcef849e3313d20a1(ShapeBase x5770cdefd8931aa9, x0771ab99a5b01492 x2acc2d9250a047a0)
	{
		if (x5770cdefd8931aa9.IsGroup)
		{
			return x7cdabf2a11d5469d((GroupShape)x5770cdefd8931aa9, x2acc2d9250a047a0);
		}
		return x06f0bb4c55cdf2ba(x5770cdefd8931aa9, x2acc2d9250a047a0);
	}

	private GroupShape xc4eb75b54b61d36c(x0c6eac1af67f9f81 x00df5329ca9a9353)
	{
		GroupShape groupShape = new GroupShape(x8cedcaa9a62c6e39.x2c8c6741422a1298);
		x8d121d7518e387cf((xc6764e97e740ec5a)((x21ad3b7fe343bc74)x00df5329ca9a9353).get_xe6d4b1b411ed94b5(0), groupShape);
		for (int i = 1; i < x00df5329ca9a9353.xd44988f225497f3a; i++)
		{
			ShapeBase x40e458b3a58f = x8c713173570e8643(((x21ad3b7fe343bc74)x00df5329ca9a9353).get_xe6d4b1b411ed94b5(i));
			groupShape.xdf7453d9fdf3f262(x40e458b3a58f);
		}
		return groupShape;
	}

	private x0c6eac1af67f9f81 x7cdabf2a11d5469d(GroupShape xe2c9497bf778cd2b, x0771ab99a5b01492 x2acc2d9250a047a0)
	{
		x0c6eac1af67f9f81 x0c6eac1af67f9f82 = new x0c6eac1af67f9f81();
		xc6764e97e740ec5a value = x06f0bb4c55cdf2ba(xe2c9497bf778cd2b, x2acc2d9250a047a0);
		x0c6eac1af67f9f82.xf2453c298c5de6f5.Add(value);
		for (Node node = xe2c9497bf778cd2b.FirstChild; node != null; node = node.NextSibling)
		{
			xddf6304144fd3863 value2 = xcef849e3313d20a1((ShapeBase)node, x0771ab99a5b01492.xafe684f748981f4f);
			x0c6eac1af67f9f82.xf2453c298c5de6f5.Add(value2);
		}
		return x0c6eac1af67f9f82;
	}

	internal Shape xac287a575a05d160(xc6764e97e740ec5a xc802e69602e43547)
	{
		Shape shape = new Shape(x8cedcaa9a62c6e39.x2c8c6741422a1298);
		x8d121d7518e387cf(xc802e69602e43547, shape);
		return shape;
	}

	private void x8d121d7518e387cf(xc6764e97e740ec5a xc802e69602e43547, ShapeBase x5770cdefd8931aa9)
	{
		xa8c46bf9cb77fa81 xa8c46bf9cb77fa82 = null;
		for (int i = 0; i < xc802e69602e43547.xd44988f225497f3a; i++)
		{
			xddf6304144fd3863 xddf6304144fd3864 = ((x21ad3b7fe343bc74)xc802e69602e43547).get_xe6d4b1b411ed94b5(i);
			if (xddf6304144fd3864 == null)
			{
				x8cedcaa9a62c6e39.x3dc950453374051a("Invalid OfficeArt record found, ignored.");
				continue;
			}
			switch (xddf6304144fd3864.x1ea60bde2b5d0d28.x3146d638ec378671)
			{
			case x773fe540042dad03.x873e507a3bc924e4:
			{
				x1f112a7e89020b14 x1f112a7e89020b15 = (x1f112a7e89020b14)xddf6304144fd3864;
				x5770cdefd8931aa9.CoordOrigin = x1f112a7e89020b15.x48269779ca77dbce;
				x5770cdefd8931aa9.x0ac950b592cc7720(x1f112a7e89020b15.x82f47b4c4fcc123d);
				break;
			}
			case x773fe540042dad03.xa9993ed2e0c64574:
			{
				x00f3419456bbf9dc x00f3419456bbf9dc2 = (x00f3419456bbf9dc)xddf6304144fd3864;
				x5770cdefd8931aa9.xea1e81378298fa81 = x00f3419456bbf9dc2.xdd2aea3eb7514107;
				if (x00f3419456bbf9dc2.xe23970fbd4f20532)
				{
					x5770cdefd8931aa9.x88d1b78392d1a0ab(ShapeType.Group);
				}
				else if (x00f3419456bbf9dc2.xa170cce2bc40bdf5)
				{
					x5770cdefd8931aa9.x88d1b78392d1a0ab(ShapeType.OleObject);
				}
				else
				{
					x5770cdefd8931aa9.x88d1b78392d1a0ab(x00f3419456bbf9dc2.xbed4d3b2bc339f99);
				}
				x5770cdefd8931aa9.FlipOrientation = x00f3419456bbf9dc2.x6c63cd63ecbef700;
				break;
			}
			case x773fe540042dad03.x25010a8486e00671:
			case x773fe540042dad03.xb80a65a936e596c7:
				x5bb197a3bd3e47ae.x06b0e25aa6ad68a9(((x7307718157e7e7c1)xddf6304144fd3864).x4e35c79189b28e26, x5770cdefd8931aa9);
				break;
			case x773fe540042dad03.x8615a69be17cd289:
				xa8c46bf9cb77fa82 = (xa8c46bf9cb77fa81)xddf6304144fd3864;
				break;
			}
		}
		if (xa8c46bf9cb77fa82 != null)
		{
			x5a479118db43fa5e.xe63b9d2198d90be1(x5770cdefd8931aa9, xa8c46bf9cb77fa82.x72d92bd1aff02e37, xa8c46bf9cb77fa82.xe360b1885d8d4a41, xa8c46bf9cb77fa82.xdc1bf80853046136, xa8c46bf9cb77fa82.xb0f146032f47c24e);
		}
	}

	internal xc6764e97e740ec5a x06f0bb4c55cdf2ba(ShapeBase x5770cdefd8931aa9, x0771ab99a5b01492 x2acc2d9250a047a0)
	{
		xc6764e97e740ec5a xc6764e97e740ec5a2 = new xc6764e97e740ec5a();
		if (x5770cdefd8931aa9.IsGroup)
		{
			x1f112a7e89020b14 x1f112a7e89020b15 = new x1f112a7e89020b14();
			x1f112a7e89020b15.x48269779ca77dbce = x5770cdefd8931aa9.CoordOrigin;
			x1f112a7e89020b15.x82f47b4c4fcc123d = x5770cdefd8931aa9.CoordSize;
			xc6764e97e740ec5a2.xf2453c298c5de6f5.Add(x1f112a7e89020b15);
		}
		x00f3419456bbf9dc x00f3419456bbf9dc2 = new x00f3419456bbf9dc();
		x00f3419456bbf9dc2.xdd2aea3eb7514107 = x5770cdefd8931aa9.xea1e81378298fa81;
		switch (x5770cdefd8931aa9.ShapeType)
		{
		case ShapeType.Group:
			x00f3419456bbf9dc2.xbed4d3b2bc339f99 = ShapeType.NonPrimitive;
			break;
		case ShapeType.OleObject:
		case ShapeType.OleControl:
			x00f3419456bbf9dc2.xbed4d3b2bc339f99 = ShapeType.Image;
			break;
		default:
			x00f3419456bbf9dc2.xbed4d3b2bc339f99 = x5770cdefd8931aa9.ShapeType;
			break;
		}
		x00f3419456bbf9dc2.xe23970fbd4f20532 = x5770cdefd8931aa9.IsGroup;
		x00f3419456bbf9dc2.x1a3b93a566584a7d = x2acc2d9250a047a0 == x0771ab99a5b01492.x52578e3c8384728f;
		x00f3419456bbf9dc2.x3b9e71c3ee8a81a6 = x2acc2d9250a047a0 == x0771ab99a5b01492.xafe684f748981f4f;
		x00f3419456bbf9dc2.x6dcbdae8b4f7f447 = x5770cdefd8931aa9.x6dcbdae8b4f7f447;
		x00f3419456bbf9dc2.xa170cce2bc40bdf5 = x5770cdefd8931aa9.xa170cce2bc40bdf5 && !x5770cdefd8931aa9.IsInline;
		x00f3419456bbf9dc2.xf94637ee9e16822d = !x5770cdefd8931aa9.IsGroup;
		x00f3419456bbf9dc2.x0cf12e39ba2fb49f = true;
		x00f3419456bbf9dc2.x6c63cd63ecbef700 = x5770cdefd8931aa9.FlipOrientation;
		xc6764e97e740ec5a2.xf2453c298c5de6f5.Add(x00f3419456bbf9dc2);
		x7307718157e7e7c1 x7307718157e7e7c2 = new x7307718157e7e7c1(isExtendedOptions: false);
		x7307718157e7e7c1 x7307718157e7e7c3 = new x7307718157e7e7c1(isExtendedOptions: true);
		x5bb197a3bd3e47ae.x6210059f049f0d48(x5770cdefd8931aa9, x7307718157e7e7c2.x4e35c79189b28e26, x7307718157e7e7c3.x4e35c79189b28e26, x00f3419456bbf9dc2.x1a3b93a566584a7d);
		if (x7307718157e7e7c2.x4e35c79189b28e26.xd44988f225497f3a > 0)
		{
			xc6764e97e740ec5a2.xf2453c298c5de6f5.Add(x7307718157e7e7c2);
		}
		if (x7307718157e7e7c3.x4e35c79189b28e26.xd44988f225497f3a > 0)
		{
			xc6764e97e740ec5a2.xf2453c298c5de6f5.Add(x7307718157e7e7c3);
		}
		if (x2acc2d9250a047a0 == x0771ab99a5b01492.x23dbaf02de42dd52)
		{
			x753e51109756f7c2 x753e51109756f7c3 = new x753e51109756f7c2();
			x753e51109756f7c3.xd2f68ee6f47e9dfb = x23b42b2a85a030f4.xb3a1dda83e2dc492;
			xc6764e97e740ec5a2.xf2453c298c5de6f5.Add(x753e51109756f7c3);
		}
		else
		{
			if (!x00f3419456bbf9dc2.x1a3b93a566584a7d)
			{
				if (x00f3419456bbf9dc2.x3b9e71c3ee8a81a6)
				{
					xa8c46bf9cb77fa81 xa8c46bf9cb77fa82 = new xa8c46bf9cb77fa81();
					x5a479118db43fa5e x5a479118db43fa5e2 = x5a479118db43fa5e.xf648b77e8172fa16(x5770cdefd8931aa9);
					xa8c46bf9cb77fa82.x72d92bd1aff02e37 = (int)x5a479118db43fa5e2.x72d92bd1aff02e37;
					xa8c46bf9cb77fa82.xe360b1885d8d4a41 = (int)x5a479118db43fa5e2.xe360b1885d8d4a41;
					xa8c46bf9cb77fa82.xdc1bf80853046136 = (int)x5a479118db43fa5e2.xdc1bf80853046136;
					xa8c46bf9cb77fa82.xb0f146032f47c24e = (int)x5a479118db43fa5e2.xb0f146032f47c24e;
					xc6764e97e740ec5a2.xf2453c298c5de6f5.Add(xa8c46bf9cb77fa82);
				}
				else
				{
					x753e51109756f7c2 value = new x753e51109756f7c2();
					xc6764e97e740ec5a2.xf2453c298c5de6f5.Add(value);
				}
			}
			x7cc5116ad29b31ca x7cc5116ad29b31ca2 = new x7cc5116ad29b31ca();
			x7cc5116ad29b31ca2.x3a89c964078835a5 = 1;
			xc6764e97e740ec5a2.xf2453c298c5de6f5.Add(x7cc5116ad29b31ca2);
			if (x5770cdefd8931aa9.xc95ed8e8690eb564 != 0)
			{
				x60a83a1c77a6b0d0 x60a83a1c77a6b0d = new x60a83a1c77a6b0d0();
				x60a83a1c77a6b0d.xc95ed8e8690eb564 = x5770cdefd8931aa9.xc95ed8e8690eb564;
				xc6764e97e740ec5a2.xf2453c298c5de6f5.Add(x60a83a1c77a6b0d);
			}
		}
		return xc6764e97e740ec5a2;
	}

	internal static Shape xa5b547b6ce00aa54(x7e738ecc9d58b06d x26bd0e776a61cb6b, BinaryReader x2876c9437120b4af, int x9e4be1b404ab074b, IWarningCallback x57fef5933b41d0c2)
	{
		if (x9e4be1b404ab074b == 0)
		{
			return null;
		}
		int num = (int)x2876c9437120b4af.BaseStream.Position;
		x622ccf73c1aa9e89 x622ccf73c1aa9e90 = new x622ccf73c1aa9e89();
		x622ccf73c1aa9e90.x06b0e25aa6ad68a9(x2876c9437120b4af, x9e4be1b404ab074b, x57fef5933b41d0c2);
		if (x492f529cee830a40)
		{
			foreach (xddf6304144fd3863 item in x622ccf73c1aa9e90)
			{
				_ = item;
			}
			_ = x2876c9437120b4af.BaseStream.Position;
			_ = num + x9e4be1b404ab074b;
		}
		if (x622ccf73c1aa9e90.Count == 0)
		{
			return null;
		}
		xc6764e97e740ec5a xc802e69602e = (xc6764e97e740ec5a)x622ccf73c1aa9e90.get_xe6d4b1b411ed94b5(0);
		xfbb3f4be330f4086 xfbb3f4be330f4087 = null;
		x7036f104bc5c45f0 x7036f104bc5c45f = new x7036f104bc5c45f0();
		for (int i = 1; i < x622ccf73c1aa9e90.Count; i++)
		{
			if (x622ccf73c1aa9e90.get_xe6d4b1b411ed94b5(i) == null || x622ccf73c1aa9e90.get_xe6d4b1b411ed94b5(i).x1ea60bde2b5d0d28.x3146d638ec378671 != x773fe540042dad03.x1a32cef9417f917a)
			{
				continue;
			}
			xfbb3f4be330f4087 = (xfbb3f4be330f4086)x622ccf73c1aa9e90.get_xe6d4b1b411ed94b5(i);
			if (xfbb3f4be330f4087 != null)
			{
				if (xfbb3f4be330f4087.x90c6e45466e5b849 == null && i < x622ccf73c1aa9e90.Count && x622ccf73c1aa9e90.get_xe6d4b1b411ed94b5(i + 1) is xd959c7c7ca733332)
				{
					xfbb3f4be330f4087.x90c6e45466e5b849 = (xd959c7c7ca733332)x622ccf73c1aa9e90.get_xe6d4b1b411ed94b5(i + 1);
				}
				xfbb3f4be330f4086 xfbb3f4be330f4088 = x26bd0e776a61cb6b.x590497a2b838b652(xfbb3f4be330f4087.x90c6e45466e5b849.x0217cda8370c1f17);
				if (xfbb3f4be330f4088 != null)
				{
					xfbb3f4be330f4087 = xfbb3f4be330f4088;
				}
				else
				{
					x26bd0e776a61cb6b.xc3eb1b4e429c8893(xfbb3f4be330f4087);
				}
				((xc93de5b84cb7a11f)x7036f104bc5c45f).xcfcc704945beca71(xfbb3f4be330f4087);
			}
		}
		x373059570f6cfe23 context = new x373059570f6cfe23(x26bd0e776a61cb6b.x2c8c6741422a1298, x7036f104bc5c45f, null, x57fef5933b41d0c2);
		x821732b125012c9e x821732b125012c9e2 = new x821732b125012c9e(context);
		Shape shape = x821732b125012c9e2.xac287a575a05d160(xc802e69602e);
		shape.WrapType = WrapType.Inline;
		return shape;
	}

	internal static void x84e71ff4edf2ec72(ShapeBase x5770cdefd8931aa9, BinaryWriter xbdfb620b7167944b)
	{
		if (x5770cdefd8931aa9.x3d318285d887cd3a)
		{
			x08f8282e97be31ec(x5770cdefd8931aa9, xbdfb620b7167944b);
		}
		else
		{
			x146cca823fff5ec9(x5770cdefd8931aa9, xbdfb620b7167944b);
		}
	}

	private static void x146cca823fff5ec9(ShapeBase x5770cdefd8931aa9, BinaryWriter xbdfb620b7167944b)
	{
		x7036f104bc5c45f0 x7036f104bc5c45f = new x7036f104bc5c45f0();
		x373059570f6cfe23 context = new x373059570f6cfe23(x5770cdefd8931aa9.Document, x7036f104bc5c45f, null, null);
		x821732b125012c9e x821732b125012c9e2 = new x821732b125012c9e(context);
		xc6764e97e740ec5a xc6764e97e740ec5a2 = x821732b125012c9e2.x06f0bb4c55cdf2ba(x5770cdefd8931aa9, x0771ab99a5b01492.x23dbaf02de42dd52);
		int x62ccf2f5b04cb08c = (int)xbdfb620b7167944b.BaseStream.Position;
		xc6764e97e740ec5a2.x6210059f049f0d48(xbdfb620b7167944b);
		x7036f104bc5c45f.x6210059f049f0d48(xbdfb620b7167944b, x62ccf2f5b04cb08c);
	}

	private static void x08f8282e97be31ec(ShapeBase x5770cdefd8931aa9, BinaryWriter xbdfb620b7167944b)
	{
		xc6764e97e740ec5a xc6764e97e740ec5a2 = new xc6764e97e740ec5a();
		x00f3419456bbf9dc x00f3419456bbf9dc2 = new x00f3419456bbf9dc();
		x00f3419456bbf9dc2.xdd2aea3eb7514107 = x5770cdefd8931aa9.xea1e81378298fa81;
		x00f3419456bbf9dc2.xbed4d3b2bc339f99 = ShapeType.Image;
		x00f3419456bbf9dc2.xf94637ee9e16822d = true;
		x00f3419456bbf9dc2.x0cf12e39ba2fb49f = true;
		xc6764e97e740ec5a2.xf2453c298c5de6f5.Add(x00f3419456bbf9dc2);
		x7307718157e7e7c1 x7307718157e7e7c2 = new x7307718157e7e7c1(isExtendedOptions: false);
		x7307718157e7e7c2.x4e35c79189b28e26.x790922ad5280636d(127, 20971840);
		xc6764e97e740ec5a2.xf2453c298c5de6f5.Add(x7307718157e7e7c2);
		x7307718157e7e7c1 x7307718157e7e7c3 = new x7307718157e7e7c1(isExtendedOptions: true);
		x7307718157e7e7c3.x4e35c79189b28e26.x790922ad5280636d(1343, 65537);
		xc6764e97e740ec5a2.xf2453c298c5de6f5.Add(x7307718157e7e7c3);
		x753e51109756f7c2 x753e51109756f7c3 = new x753e51109756f7c2();
		x753e51109756f7c3.xd2f68ee6f47e9dfb = x23b42b2a85a030f4.xb3a1dda83e2dc492;
		xc6764e97e740ec5a2.xf2453c298c5de6f5.Add(x753e51109756f7c3);
		xc6764e97e740ec5a2.x6210059f049f0d48(xbdfb620b7167944b);
	}
}
