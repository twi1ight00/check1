using System;
using Aspose.Words;

namespace x28925c9b27b37a46;

internal class x72f94792b483ceab
{
	private bool x52820af000e1795c;

	private bool x4fe31c6772a777c6;

	private bool x0da69c7c0b1cc4d0;

	private bool xc77e562044dece70;

	private bool x4163303904a03d44;

	private x98739d759efb5fe7 xd4bd25740614b729;

	private readonly Node x212ae880d15d2ed1;

	internal bool x9ceb94a75755dfd0
	{
		get
		{
			return x52820af000e1795c;
		}
		set
		{
			x52820af000e1795c = value;
		}
	}

	internal bool x9cc771377faeec73
	{
		get
		{
			return x4fe31c6772a777c6;
		}
		set
		{
			x4fe31c6772a777c6 = value;
		}
	}

	internal bool xf000b643162cefd9
	{
		get
		{
			return x0da69c7c0b1cc4d0;
		}
		set
		{
			x0da69c7c0b1cc4d0 = value;
		}
	}

	internal bool x589d1a65ee6d5c85
	{
		get
		{
			return xc77e562044dece70;
		}
		set
		{
			xc77e562044dece70 = value;
		}
	}

	internal bool xd1d5a76d3c766ef6
	{
		get
		{
			return x4163303904a03d44;
		}
		set
		{
			x4163303904a03d44 = value;
		}
	}

	public x98739d759efb5fe7 xbe1e23e7d5b43370 => xd4bd25740614b729;

	public object x35cfcea4890f4e7d => xbe1e23e7d5b43370;

	internal x72f94792b483ceab(Node start)
	{
		if (start == null)
		{
			throw new ArgumentNullException("start");
		}
		x212ae880d15d2ed1 = start;
		x74f5a1ef3906e23c();
	}

	public bool x47f176deff0d42e2()
	{
		if (xd4bd25740614b729.x40212106aad8a8b0 == null)
		{
			xd4bd25740614b729.x40212106aad8a8b0 = x212ae880d15d2ed1;
			if (xd1d5a76d3c766ef6)
			{
				xd4bd25740614b729.x8a92b04b9d325900();
			}
			else
			{
				xd4bd25740614b729.xac0bfd155c704ff8();
			}
			return true;
		}
		return xd4bd25740614b729.x9e19f5bd0a6dd5b7(x212ae880d15d2ed1, !xd1d5a76d3c766ef6, !xf000b643162cefd9, x589d1a65ee6d5c85, x9ceb94a75755dfd0, x9cc771377faeec73);
	}

	public void x74f5a1ef3906e23c()
	{
		xd4bd25740614b729 = new x98739d759efb5fe7(null, 0);
	}
}
