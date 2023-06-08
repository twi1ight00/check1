using Aspose.Words;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal sealed class xc8e01097217ac9d2 : xcf9d359063aa93f2
{
	internal static readonly xc8e01097217ac9d2 x45260ad4b94166f2;

	internal static readonly xc8e01097217ac9d2 x66f2271ac271c2df;

	private x26d9ecb4bdf0456d x78e4acec873c7675 = x26d9ecb4bdf0456d.x45260ad4b94166f2;

	private LineStyle x8001c24628d75f20;

	private float x1aefc8a2390552c2;

	private bool x65ae3956ae69f375;

	private bool x98909799bac6d87a;

	private float x969a58dd03b1342f;

	private bool x432bfe013beed3a9;

	internal x26d9ecb4bdf0456d x9b41425268471380
	{
		get
		{
			return x78e4acec873c7675;
		}
		set
		{
			x71c6d753219cc1b7();
			x78e4acec873c7675 = x396b77a306f83da6.x9e48744bdf3be5f8(value);
		}
	}

	internal LineStyle x3d0571719b5893b4
	{
		get
		{
			return x8001c24628d75f20;
		}
		set
		{
			x71c6d753219cc1b7();
			x8001c24628d75f20 = value;
		}
	}

	internal float xffa1fc725bf36690
	{
		get
		{
			return x1aefc8a2390552c2;
		}
		set
		{
			x71c6d753219cc1b7();
			x1aefc8a2390552c2 = value;
		}
	}

	internal bool x0214605434693fc1
	{
		get
		{
			return x65ae3956ae69f375;
		}
		set
		{
			x71c6d753219cc1b7();
			x65ae3956ae69f375 = value;
		}
	}

	internal bool x75c2a4a522094a98
	{
		get
		{
			return x98909799bac6d87a;
		}
		set
		{
			x71c6d753219cc1b7();
			x98909799bac6d87a = value;
		}
	}

	internal float x58316dde3396e982
	{
		get
		{
			return x969a58dd03b1342f;
		}
		set
		{
			x71c6d753219cc1b7();
			x969a58dd03b1342f = value;
		}
	}

	internal bool x151ac08c86e712bc
	{
		get
		{
			return x432bfe013beed3a9;
		}
		set
		{
			x71c6d753219cc1b7();
			x432bfe013beed3a9 = value;
		}
	}

	internal bool xa853df7acdb217c8 => Border.xae56a19b8a07173b(x3d0571719b5893b4, xffa1fc725bf36690);

	internal int x0b5855089a074d93
	{
		get
		{
			if (xa853df7acdb217c8)
			{
				int num = x4574ea26106f0edb.x8d50b8a62ba1cd84(xeae235558dc44397);
				if (x0214605434693fc1)
				{
					num *= 2;
				}
				return num + x4574ea26106f0edb.x8d50b8a62ba1cd84(x58316dde3396e982);
			}
			return 0;
		}
	}

	private float xeae235558dc44397 => Border.xb556d1cd3d419a11(x3d0571719b5893b4, xffa1fc725bf36690);

	internal xc8e01097217ac9d2(x17dcbf5fe3c0d2d2 context, bool initKey)
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
		xc8e01097217ac9d2 xc8e01097217ac9d3 = (xc8e01097217ac9d2)obj;
		return xffa1fc725bf36690 == xc8e01097217ac9d3.xffa1fc725bf36690 && x3d0571719b5893b4 == xc8e01097217ac9d3.x3d0571719b5893b4 && object.Equals(x9b41425268471380, xc8e01097217ac9d3.x9b41425268471380) && x0214605434693fc1 == xc8e01097217ac9d3.x0214605434693fc1 && x75c2a4a522094a98 == xc8e01097217ac9d3.x75c2a4a522094a98 && x58316dde3396e982 == xc8e01097217ac9d3.x58316dde3396e982 && x151ac08c86e712bc == xc8e01097217ac9d3.x151ac08c86e712bc;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	protected override void AddKeysToHashCode()
	{
		x1e94bce19c84490b(xffa1fc725bf36690);
		x1e94bce19c84490b(x3d0571719b5893b4);
		xd94964d84c426258(x9b41425268471380);
		x1e94bce19c84490b(x0214605434693fc1);
		x1e94bce19c84490b(x75c2a4a522094a98);
		x1e94bce19c84490b(x58316dde3396e982);
		x1e94bce19c84490b(x151ac08c86e712bc);
	}

	internal static xc8e01097217ac9d2 x38758cbbee49e4cb(xc8e01097217ac9d2 x50a18ad2656e7181)
	{
		if (x50a18ad2656e7181 == null)
		{
			x50a18ad2656e7181 = x45260ad4b94166f2;
		}
		if (x50a18ad2656e7181.x17dcbf5fe3c0d2d2 == null)
		{
			return x50a18ad2656e7181;
		}
		if (x50a18ad2656e7181.xe76bdd563aa52beb)
		{
			return x50a18ad2656e7181;
		}
		xc8e01097217ac9d2 xc8e01097217ac9d3 = (xc8e01097217ac9d2)x50a18ad2656e7181.x17dcbf5fe3c0d2d2.xfa8f23b513b96f79[x50a18ad2656e7181];
		if (xc8e01097217ac9d3 == null)
		{
			x50a18ad2656e7181.x17dcbf5fe3c0d2d2.xfa8f23b513b96f79.Add(x50a18ad2656e7181, xc8e01097217ac9d3 = x50a18ad2656e7181);
		}
		return xc8e01097217ac9d3;
	}

	internal static xc8e01097217ac9d2 xdb83cd4968ca9d31(xc8e01097217ac9d2 x50a18ad2656e7181)
	{
		if (x50a18ad2656e7181 == null)
		{
			return new xc8e01097217ac9d2(null, initKey: false);
		}
		xc8e01097217ac9d2 xc8e01097217ac9d3 = new xc8e01097217ac9d2(x50a18ad2656e7181.x17dcbf5fe3c0d2d2, initKey: false);
		xc8e01097217ac9d3.x9b41425268471380 = x50a18ad2656e7181.x9b41425268471380;
		xc8e01097217ac9d3.xffa1fc725bf36690 = x50a18ad2656e7181.xffa1fc725bf36690;
		xc8e01097217ac9d3.x3d0571719b5893b4 = x50a18ad2656e7181.x3d0571719b5893b4;
		xc8e01097217ac9d3.x0214605434693fc1 = x50a18ad2656e7181.x0214605434693fc1;
		xc8e01097217ac9d3.x75c2a4a522094a98 = x50a18ad2656e7181.x75c2a4a522094a98;
		xc8e01097217ac9d3.x58316dde3396e982 = x50a18ad2656e7181.x58316dde3396e982;
		return xc8e01097217ac9d3;
	}

	internal static xc8e01097217ac9d2 x38758cbbee49e4cb(x17dcbf5fe3c0d2d2 x0f7b23d1c393aed9, float xce90ee8e49859281, LineStyle x26516bbd7ae94699, x26d9ecb4bdf0456d x6c50a99faab7d741, float x40390ac90cd57a02, bool xc92c7e4aeaca654f, bool x4ee446528fc06d93)
	{
		xc8e01097217ac9d2 xc8e01097217ac9d3 = new xc8e01097217ac9d2(x0f7b23d1c393aed9, initKey: false);
		xc8e01097217ac9d3.xffa1fc725bf36690 = xce90ee8e49859281;
		xc8e01097217ac9d3.x3d0571719b5893b4 = x26516bbd7ae94699;
		xc8e01097217ac9d3.x9b41425268471380 = x6c50a99faab7d741;
		xc8e01097217ac9d3.x58316dde3396e982 = x40390ac90cd57a02;
		xc8e01097217ac9d3.x0214605434693fc1 = xc92c7e4aeaca654f;
		xc8e01097217ac9d3.x75c2a4a522094a98 = x4ee446528fc06d93;
		return x38758cbbee49e4cb(xc8e01097217ac9d3);
	}

	static xc8e01097217ac9d2()
	{
		x45260ad4b94166f2 = x38758cbbee49e4cb(null, 0f, LineStyle.None, x26d9ecb4bdf0456d.x45260ad4b94166f2, 0f, xc92c7e4aeaca654f: false, x4ee446528fc06d93: false);
		x45260ad4b94166f2.x151ac08c86e712bc = false;
		x45260ad4b94166f2.GetHashCode();
		x66f2271ac271c2df = x38758cbbee49e4cb(null, 0.1f, LineStyle.Single, x26d9ecb4bdf0456d.x45260ad4b94166f2, 0f, xc92c7e4aeaca654f: false, x4ee446528fc06d93: false);
		x66f2271ac271c2df.x151ac08c86e712bc = true;
		x66f2271ac271c2df.GetHashCode();
	}
}
