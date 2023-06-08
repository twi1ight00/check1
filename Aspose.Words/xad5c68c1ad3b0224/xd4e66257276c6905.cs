using x1c8faa688b1f0b0c;
using x8784bdb393e53e65;
using x996431aaaaf00543;
using xb3013071794e5415;
using xcc8a79815d76af85;

namespace xad5c68c1ad3b0224;

internal class xd4e66257276c6905 : x18041b360bf02656
{
	private xfe1068a58387cabb x802036dd51c4b5db;

	private bool x6709a0bcd6fd2cfb;

	private string xd28cbcdc9b3478eb;

	private string x4ef11b6c3a659555;

	private xe7173b93ad02d837 x8108f06ca091375f;

	private x4ff4ed4f880a2f4e xe14220e5dfde0be0;

	private bool xbd3070af9a8bdbe8;

	private xbc46977eebea4733 xda54f2210ded5b25;

	private int x5d9fbd9603e9dee5 = 2;

	private x4694a3400bb4849a x5266ea28de8a5780;

	private string xba2a9976414fe615;

	private x78e18bdf9a108059 x435b26849f0d2436;

	internal xfe1068a58387cabb x317eef27d88d4cf9
	{
		get
		{
			return x802036dd51c4b5db;
		}
		set
		{
			x802036dd51c4b5db = value;
		}
	}

	internal bool xcb380cb55fa000ee
	{
		get
		{
			return x6709a0bcd6fd2cfb;
		}
		set
		{
			x6709a0bcd6fd2cfb = value;
		}
	}

	internal string xcd69b22e9bd2730d
	{
		get
		{
			return xd28cbcdc9b3478eb;
		}
		set
		{
			xd28cbcdc9b3478eb = value;
		}
	}

	internal string x8e720b4f276ab89d
	{
		get
		{
			return x4ef11b6c3a659555;
		}
		set
		{
			x4ef11b6c3a659555 = value;
		}
	}

	internal xe7173b93ad02d837 xc059785ea37454aa
	{
		get
		{
			return x8108f06ca091375f;
		}
		set
		{
			x8108f06ca091375f = value;
		}
	}

	internal x4ff4ed4f880a2f4e x14c3f5426fc2c1fc
	{
		get
		{
			return xe14220e5dfde0be0;
		}
		set
		{
			xe14220e5dfde0be0 = value;
		}
	}

	internal bool xb2a22256f7eba14a
	{
		get
		{
			return xbd3070af9a8bdbe8;
		}
		set
		{
			xbd3070af9a8bdbe8 = value;
		}
	}

	internal xbc46977eebea4733 xff13b489d81606b6
	{
		get
		{
			if (xda54f2210ded5b25 == null)
			{
				xda54f2210ded5b25 = new xbc46977eebea4733();
			}
			return xda54f2210ded5b25;
		}
	}

	internal int xfe2178c1f916f36c
	{
		get
		{
			return x5d9fbd9603e9dee5;
		}
		set
		{
			if (value >= 1 && value <= 48)
			{
				x5d9fbd9603e9dee5 = value;
			}
		}
	}

	internal x4694a3400bb4849a x68955bfadd010132
	{
		get
		{
			if (x5266ea28de8a5780 == null)
			{
				x5266ea28de8a5780 = new x4694a3400bb4849a();
			}
			return x5266ea28de8a5780;
		}
	}

	internal string x51c3e56314230f85
	{
		get
		{
			return xba2a9976414fe615;
		}
		set
		{
			xba2a9976414fe615 = value;
		}
	}

	public override x4fdf549af9de6b97 Render(x2094302a66c2ec77 nodeRenderParams)
	{
		nodeRenderParams.x1a1fb4b19097b9f6.x84e43ba1eb351dc4(GetTransform());
		xcd7d6e7318ee6574 x0f7b23d1c393aed = new xcd7d6e7318ee6574(this, nodeRenderParams);
		return x6d22cf1ff5170ee8.xe406325e56f74b46(this, x0f7b23d1c393aed);
	}

	public override x78e18bdf9a108059 GetTransform()
	{
		if (x435b26849f0d2436 == null)
		{
			x435b26849f0d2436 = new x78e18bdf9a108059();
		}
		return x435b26849f0d2436;
	}
}
