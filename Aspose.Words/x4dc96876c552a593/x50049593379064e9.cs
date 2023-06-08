using System.Drawing;

namespace x4dc96876c552a593;

internal class x50049593379064e9
{
	private int xc8ff13cb9454e1a9 = 45720;

	private int x933fbdb4e4f6c448 = 91440;

	private int xed5d42e5ec2e2a9e = 91440;

	private int x51556d800a83de54 = 45720;

	public int xe360b1885d8d4a41
	{
		get
		{
			return x51556d800a83de54;
		}
		set
		{
			x51556d800a83de54 = value;
		}
	}

	public int x9bcb07e204e30218
	{
		get
		{
			return xc8ff13cb9454e1a9;
		}
		set
		{
			xc8ff13cb9454e1a9 = value;
		}
	}

	public int x72d92bd1aff02e37
	{
		get
		{
			return x933fbdb4e4f6c448;
		}
		set
		{
			x933fbdb4e4f6c448 = value;
		}
	}

	public int x419ba17a5322627b
	{
		get
		{
			return xed5d42e5ec2e2a9e;
		}
		set
		{
			xed5d42e5ec2e2a9e = value;
		}
	}

	public x50049593379064e9()
	{
	}

	public x50049593379064e9(int left, int top, int right, int bottom)
	{
		xc8ff13cb9454e1a9 = bottom;
		x933fbdb4e4f6c448 = left;
		xed5d42e5ec2e2a9e = right;
		x51556d800a83de54 = top;
	}

	public static x50049593379064e9 xb4f2f2cd9736c886()
	{
		return new x50049593379064e9(0, 0, 0, 0);
	}

	public bool Equals(x50049593379064e9 other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		if (other.xc8ff13cb9454e1a9 == xc8ff13cb9454e1a9 && other.x933fbdb4e4f6c448 == x933fbdb4e4f6c448 && other.xed5d42e5ec2e2a9e == xed5d42e5ec2e2a9e)
		{
			return other.x51556d800a83de54 == x51556d800a83de54;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (object.ReferenceEquals(this, obj))
		{
			return true;
		}
		if (obj.GetType() != typeof(x50049593379064e9))
		{
			return false;
		}
		return Equals((x50049593379064e9)obj);
	}

	public override int GetHashCode()
	{
		int num = xc8ff13cb9454e1a9;
		num = (num * 397) ^ x933fbdb4e4f6c448;
		num = (num * 397) ^ xed5d42e5ec2e2a9e;
		return (num * 397) ^ x51556d800a83de54;
	}

	public RectangleF xbe2cb8264b39a622(RectangleF xcdaeea7afaf570ff)
	{
		return RectangleF.FromLTRB(xcdaeea7afaf570ff.Left + (float)x72d92bd1aff02e37, xcdaeea7afaf570ff.Top + (float)xe360b1885d8d4a41, xcdaeea7afaf570ff.Right - (float)x419ba17a5322627b, xcdaeea7afaf570ff.Bottom - (float)x9bcb07e204e30218);
	}
}
