using System.Drawing;
using x6b8130194ad714f7;

namespace x8b1f7613579e78d0;

internal class x60eea316590e7fe7
{
	private x55c6a66cc28d5b86 xf63c9a791cae8f48 = new x55c6a66cc28d5b86();

	private x55c6a66cc28d5b86 x6e74c79ac777f020 = new x55c6a66cc28d5b86();

	private x55c6a66cc28d5b86 xf995a7a9bffac1cf = new x55c6a66cc28d5b86();

	private x55c6a66cc28d5b86 x2cede84e47db333b = new x55c6a66cc28d5b86();

	public x55c6a66cc28d5b86 xd0fade446b8d532a
	{
		get
		{
			return xf63c9a791cae8f48;
		}
		set
		{
			xf63c9a791cae8f48 = value;
		}
	}

	public x55c6a66cc28d5b86 xcdb214dfc38b1be3
	{
		get
		{
			return x2cede84e47db333b;
		}
		set
		{
			x2cede84e47db333b = value;
		}
	}

	public x55c6a66cc28d5b86 xc24e3e091abd3197
	{
		get
		{
			return x6e74c79ac777f020;
		}
		set
		{
			x6e74c79ac777f020 = value;
		}
	}

	public x55c6a66cc28d5b86 xb50d6cb9d3b61d4d
	{
		get
		{
			return xf995a7a9bffac1cf;
		}
		set
		{
			xf995a7a9bffac1cf = value;
		}
	}

	public x60eea316590e7fe7()
	{
	}

	public x60eea316590e7fe7(double leftOffsetFraction, double topOffsetFraction, double rightOffsetFraction, double bottomOffsetFraction)
	{
		xf63c9a791cae8f48 = x55c6a66cc28d5b86.x220dcfbc81260c16(bottomOffsetFraction);
		x6e74c79ac777f020 = x55c6a66cc28d5b86.x220dcfbc81260c16(leftOffsetFraction);
		xf995a7a9bffac1cf = x55c6a66cc28d5b86.x220dcfbc81260c16(rightOffsetFraction);
		x2cede84e47db333b = x55c6a66cc28d5b86.x220dcfbc81260c16(topOffsetFraction);
	}

	public x60eea316590e7fe7(x55c6a66cc28d5b86 leftOffset, x55c6a66cc28d5b86 topOffset, x55c6a66cc28d5b86 rightOffset, x55c6a66cc28d5b86 bottomOffset)
	{
		xf63c9a791cae8f48 = bottomOffset;
		x6e74c79ac777f020 = leftOffset;
		xf995a7a9bffac1cf = rightOffset;
		x2cede84e47db333b = topOffset;
	}

	public bool Equals(x60eea316590e7fe7 other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		if (object.Equals(other.xf63c9a791cae8f48, xf63c9a791cae8f48) && object.Equals(other.x6e74c79ac777f020, x6e74c79ac777f020) && object.Equals(other.xf995a7a9bffac1cf, xf995a7a9bffac1cf))
		{
			return object.Equals(other.x2cede84e47db333b, x2cede84e47db333b);
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
		if (obj.GetType() != typeof(x60eea316590e7fe7))
		{
			return false;
		}
		return Equals((x60eea316590e7fe7)obj);
	}

	public override int GetHashCode()
	{
		int num = ((xf63c9a791cae8f48 != null) ? xf63c9a791cae8f48.GetHashCode() : 0);
		num = (num * 397) ^ ((x6e74c79ac777f020 != null) ? x6e74c79ac777f020.GetHashCode() : 0);
		num = (num * 397) ^ ((xf995a7a9bffac1cf != null) ? xf995a7a9bffac1cf.GetHashCode() : 0);
		return (num * 397) ^ ((x2cede84e47db333b != null) ? x2cede84e47db333b.GetHashCode() : 0);
	}

	public x60eea316590e7fe7 x8b61531c8ea35b85()
	{
		x60eea316590e7fe7 x60eea316590e7fe8 = new x60eea316590e7fe7();
		x60eea316590e7fe8.xcdb214dfc38b1be3 = xcdb214dfc38b1be3;
		x60eea316590e7fe8.xd0fade446b8d532a = xd0fade446b8d532a;
		x60eea316590e7fe8.xc24e3e091abd3197 = xc24e3e091abd3197;
		x60eea316590e7fe8.xb50d6cb9d3b61d4d = xb50d6cb9d3b61d4d;
		return x60eea316590e7fe8;
	}

	public RectangleF xfaab97dd0218026f(RectangleF x26545669838eb36e)
	{
		float width = x26545669838eb36e.Width;
		float height = x26545669838eb36e.Height;
		float left = (float)((double)x26545669838eb36e.Left + (double)width * xc24e3e091abd3197.x71c5078172d72420);
		float right = (float)((double)x26545669838eb36e.Right - (double)width * xb50d6cb9d3b61d4d.x71c5078172d72420);
		float top = (float)((double)x26545669838eb36e.Top + (double)height * xcdb214dfc38b1be3.x71c5078172d72420);
		float bottom = (float)((double)x26545669838eb36e.Bottom - (double)height * xd0fade446b8d532a.x71c5078172d72420);
		return RectangleF.FromLTRB(left, top, right, bottom);
	}
}
