using System.Collections;
using x32a884d842a34446;

namespace xcc8a79815d76af85;

internal class xb7d17fc15d44a902
{
	private xa4d912a00c540cf0 x2c9b21f64c8361c0;

	private xe52a139d93fd6397 xea4baf2ce70daf94;

	private bool xc0c8b0f89d0298e5;

	private xbc46977eebea4733 xda54f2210ded5b25;

	private x4694a3400bb4849a x5266ea28de8a5780;

	private Hashtable xde2156c4a61d677d = new Hashtable();

	internal xa4d912a00c540cf0 xb7ae55095fddecd9
	{
		get
		{
			return x2c9b21f64c8361c0;
		}
		set
		{
			x2c9b21f64c8361c0 = value;
		}
	}

	internal xe52a139d93fd6397 x6e1ac924b90562d1
	{
		get
		{
			return xea4baf2ce70daf94;
		}
		set
		{
			xea4baf2ce70daf94 = value;
		}
	}

	internal bool x3f5e31045e967a38
	{
		get
		{
			return xc0c8b0f89d0298e5;
		}
		set
		{
			xc0c8b0f89d0298e5 = value;
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

	internal void xd7d75c376e5ae843(xe34702c565a0b0b9 xa85f9dbcec37a9e8)
	{
		xde2156c4a61d677d[xa85f9dbcec37a9e8.xd1bdf42207dd3638] = xa85f9dbcec37a9e8;
	}

	internal xe34702c565a0b0b9 x17b0a2d8e345ae45(int xc0c4c459c6ccbd00)
	{
		return (xe34702c565a0b0b9)xde2156c4a61d677d[xc0c4c459c6ccbd00];
	}
}
