using System.Drawing.Drawing2D;
using x5794c252ba25e723;

namespace x8784bdb393e53e65;

internal class x804c5bce88a9bb35
{
	private x54366fa5f75a02f7 x2a33c77044044630;

	private x54366fa5f75a02f7 x584deca3044bbe33;

	public x54366fa5f75a02f7 x9bc1831bb7bbf0f7
	{
		get
		{
			return x584deca3044bbe33;
		}
		set
		{
			x584deca3044bbe33 = value;
		}
	}

	public x54366fa5f75a02f7 x53c2efee610e1f9d
	{
		get
		{
			return x2a33c77044044630;
		}
		set
		{
			x2a33c77044044630 = value;
		}
	}

	public x804c5bce88a9bb35(x54366fa5f75a02f7 shapeTransformation, x54366fa5f75a02f7 shapeOffset)
	{
		x584deca3044bbe33 = shapeTransformation;
		x2a33c77044044630 = shapeOffset;
	}

	public x54366fa5f75a02f7 x206418821030fd55()
	{
		x54366fa5f75a02f7 x54366fa5f75a02f = x584deca3044bbe33.x8b61531c8ea35b85();
		x54366fa5f75a02f.x490e30087768649f(x2a33c77044044630, MatrixOrder.Append);
		return x54366fa5f75a02f;
	}
}
