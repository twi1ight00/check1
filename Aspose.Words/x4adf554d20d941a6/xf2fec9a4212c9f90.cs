using System.Reflection;
using Aspose.Words;

namespace x4adf554d20d941a6;

[DefaultMember("Item")]
internal sealed class xf2fec9a4212c9f90 : xcf9d359063aa93f2
{
	private readonly xc8e01097217ac9d2[] xac8df3ffedaa82be = new xc8e01097217ac9d2[8]
	{
		xc8e01097217ac9d2.x45260ad4b94166f2,
		xc8e01097217ac9d2.x45260ad4b94166f2,
		xc8e01097217ac9d2.x45260ad4b94166f2,
		xc8e01097217ac9d2.x45260ad4b94166f2,
		xc8e01097217ac9d2.x45260ad4b94166f2,
		xc8e01097217ac9d2.x45260ad4b94166f2,
		xc8e01097217ac9d2.x45260ad4b94166f2,
		xc8e01097217ac9d2.x45260ad4b94166f2
	};

	internal xc8e01097217ac9d2 xe6d4b1b411ed94b5
	{
		get
		{
			return xac8df3ffedaa82be[(int)xe6e655492739f7d2];
		}
		set
		{
			x71c6d753219cc1b7();
			xac8df3ffedaa82be[(int)xe6e655492739f7d2] = value;
		}
	}

	internal xf2fec9a4212c9f90(x17dcbf5fe3c0d2d2 context, bool initKey)
		: base(context)
	{
		if (initKey)
		{
			GetHashCode();
		}
	}

	public override bool Equals(object obj)
	{
		if (obj == this)
		{
			return true;
		}
		if (!x39f156868f37b760(obj))
		{
			return false;
		}
		xf2fec9a4212c9f90 xf2fec9a4212c9f91 = (xf2fec9a4212c9f90)obj;
		return x5003c1d655073976(xac8df3ffedaa82be, xf2fec9a4212c9f91.xac8df3ffedaa82be);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	protected override void AddKeysToHashCode()
	{
		xc8e01097217ac9d2[] array = xac8df3ffedaa82be;
		foreach (xc8e01097217ac9d2 xba08ce632055a1d in array)
		{
			xd94964d84c426258(xba08ce632055a1d);
		}
	}

	internal xc8e01097217ac9d2 xc9cd83e7ff351ae8(BorderType xe6e655492739f7d2, x86accec882b7012a xe6de5e5fa2d44af5)
	{
		bool flag = !xe6de5e5fa2d44af5.xce4443deee105995(x954503abc583f675.x4c38e800e85b21ad | x954503abc583f675.x69d28a4aeef83a6f | x954503abc583f675.xd90ac7fcbe961761 | x954503abc583f675.x924e4e3967c494db | x954503abc583f675.x77f91d2130d08599 | x954503abc583f675.x937e050c63ea1527).xe5764fe5359a6d91;
		if (xe6e655492739f7d2 != 0 && xe6e655492739f7d2 != BorderType.Top)
		{
			return this.get_xe6d4b1b411ed94b5(xe6e655492739f7d2);
		}
		x6c68e8efd3a92e85 x6c68e8efd3a92e86 = xe6de5e5fa2d44af5.xc5464084edc8e226.x6c68e8efd3a92e85;
		bool flag2;
		xc8e01097217ac9d2 xc8e01097217ac9d3;
		if (xe6e655492739f7d2 == BorderType.Top)
		{
			flag2 = xe6de5e5fa2d44af5.x798272c9805cc00e.x288ca0fb36572474;
			bool flag3 = x6c68e8efd3a92e86 == x6c68e8efd3a92e85.x83e8265cdba541b5 || x6c68e8efd3a92e86 == x6c68e8efd3a92e85.xed3e432f7c9bf846;
			xc8e01097217ac9d3 = ((!flag2 && flag3) ? xc8e01097217ac9d2.x45260ad4b94166f2 : (flag3 ? xe6de5e5fa2d44af5.xc5464084edc8e226.xcbf32d085c63547c().xdfd0c9de0b4aa96a.xb70a9d14469748bf.get_xe6d4b1b411ed94b5(xe6e655492739f7d2) : xe6de5e5fa2d44af5.xc5464084edc8e226.xdfd0c9de0b4aa96a.xb70a9d14469748bf.get_xe6d4b1b411ed94b5(xe6e655492739f7d2)));
		}
		else
		{
			flag2 = xe6de5e5fa2d44af5.x798272c9805cc00e.x72376d6f76e1c4e5 || flag;
			bool flag4 = x6c68e8efd3a92e86 == x6c68e8efd3a92e85.x83e8265cdba541b5 || x6c68e8efd3a92e86 == x6c68e8efd3a92e85.x38ced5a01a389303;
			xc8e01097217ac9d3 = ((!flag2 && flag4) ? xc8e01097217ac9d2.x45260ad4b94166f2 : (flag4 ? xe6de5e5fa2d44af5.xc5464084edc8e226.x20151bd42b5561f0().xdfd0c9de0b4aa96a.xb70a9d14469748bf.get_xe6d4b1b411ed94b5(xe6e655492739f7d2) : xe6de5e5fa2d44af5.xc5464084edc8e226.xdfd0c9de0b4aa96a.xb70a9d14469748bf.get_xe6d4b1b411ed94b5(xe6e655492739f7d2)));
		}
		if (!xc8e01097217ac9d3.x151ac08c86e712bc)
		{
			return xc8e01097217ac9d3;
		}
		return xe6de5e5fa2d44af5.xc5464084edc8e226.x838c6c67b5953bb0.x768f9befb545345a.xb70a9d14469748bf.get_xe6d4b1b411ed94b5(flag2 ? xe6e655492739f7d2 : BorderType.Horizontal);
	}

	internal static xf2fec9a4212c9f90 x38758cbbee49e4cb(xf2fec9a4212c9f90 x50a18ad2656e7181)
	{
		if (x50a18ad2656e7181 == null)
		{
			x50a18ad2656e7181 = new xf2fec9a4212c9f90(null, initKey: true);
		}
		if (x50a18ad2656e7181.x17dcbf5fe3c0d2d2 == null)
		{
			return x50a18ad2656e7181;
		}
		if (x50a18ad2656e7181.xe76bdd563aa52beb)
		{
			return x50a18ad2656e7181;
		}
		xf2fec9a4212c9f90 xf2fec9a4212c9f91 = (xf2fec9a4212c9f90)x50a18ad2656e7181.x17dcbf5fe3c0d2d2.xf1f814b70045b816[x50a18ad2656e7181];
		if (xf2fec9a4212c9f91 == null)
		{
			x50a18ad2656e7181.x17dcbf5fe3c0d2d2.xf1f814b70045b816.Add(x50a18ad2656e7181, xf2fec9a4212c9f91 = x50a18ad2656e7181);
		}
		return xf2fec9a4212c9f91;
	}

	internal static xf2fec9a4212c9f90 xdb83cd4968ca9d31(xf2fec9a4212c9f90 x50a18ad2656e7181)
	{
		xf2fec9a4212c9f90 xf2fec9a4212c9f91 = new xf2fec9a4212c9f90(x50a18ad2656e7181.x17dcbf5fe3c0d2d2, initKey: false);
		xf2fec9a4212c9f91.set_xe6d4b1b411ed94b5(BorderType.Bottom, xc8e01097217ac9d2.xdb83cd4968ca9d31(x50a18ad2656e7181.get_xe6d4b1b411ed94b5(BorderType.Bottom)));
		xf2fec9a4212c9f91.set_xe6d4b1b411ed94b5(BorderType.Left, xc8e01097217ac9d2.xdb83cd4968ca9d31(x50a18ad2656e7181.get_xe6d4b1b411ed94b5(BorderType.Left)));
		xf2fec9a4212c9f91.set_xe6d4b1b411ed94b5(BorderType.Right, xc8e01097217ac9d2.xdb83cd4968ca9d31(x50a18ad2656e7181.get_xe6d4b1b411ed94b5(BorderType.Right)));
		xf2fec9a4212c9f91.set_xe6d4b1b411ed94b5(BorderType.Top, xc8e01097217ac9d2.xdb83cd4968ca9d31(x50a18ad2656e7181.get_xe6d4b1b411ed94b5(BorderType.Top)));
		xf2fec9a4212c9f91.set_xe6d4b1b411ed94b5(BorderType.Horizontal, xc8e01097217ac9d2.xdb83cd4968ca9d31(x50a18ad2656e7181.get_xe6d4b1b411ed94b5(BorderType.Horizontal)));
		xf2fec9a4212c9f91.set_xe6d4b1b411ed94b5(BorderType.Vertical, xc8e01097217ac9d2.xdb83cd4968ca9d31(x50a18ad2656e7181.get_xe6d4b1b411ed94b5(BorderType.Vertical)));
		xf2fec9a4212c9f91.set_xe6d4b1b411ed94b5(BorderType.DiagonalDown, xc8e01097217ac9d2.xdb83cd4968ca9d31(x50a18ad2656e7181.get_xe6d4b1b411ed94b5(BorderType.DiagonalDown)));
		xf2fec9a4212c9f91.set_xe6d4b1b411ed94b5(BorderType.DiagonalUp, xc8e01097217ac9d2.xdb83cd4968ca9d31(x50a18ad2656e7181.get_xe6d4b1b411ed94b5(BorderType.DiagonalUp)));
		return xf2fec9a4212c9f91;
	}
}
