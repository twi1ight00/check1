using Aspose.Words;

namespace x4adf554d20d941a6;

internal class xc0e747af79894e12 : x56410a8dd70087c5
{
	private TabLeader x9886858906e51a59;

	internal override int x5566e2d2acbd1fbe => 12803;

	internal override int x1be93eed8950d961 => 1;

	internal override string xf9ad6fb78355fe13
	{
		get
		{
			if (!base.x3a7473f820dd300b)
			{
				return "\uf022";
			}
			return "\uf021";
		}
	}

	internal override TabLeader x902d63c74e3c13c4
	{
		get
		{
			return x9886858906e51a59;
		}
		set
		{
			x9886858906e51a59 = value;
		}
	}

	internal virtual bool xd685b0558e5e035b => false;

	internal xc0e747af79894e12()
	{
	}

	internal static xc0e747af79894e12 xa7195540a6abf044(Inline xdbad0d793277cfda)
	{
		if (!(xdbad0d793277cfda is AbsolutePositionTab))
		{
			return new xc0e747af79894e12();
		}
		return x55d93e4cdc939ebf.xa7195540a6abf044((AbsolutePositionTab)xdbad0d793277cfda);
	}

	internal override x56410a8dd70087c5 xa9d7e8f6fbdcbcfc(x56410a8dd70087c5 x7d95d971d8923f4c)
	{
		if (x7d95d971d8923f4c == null)
		{
			x7d95d971d8923f4c = new xc0e747af79894e12();
		}
		x7d95d971d8923f4c.x902d63c74e3c13c4 = x902d63c74e3c13c4;
		return base.xa9d7e8f6fbdcbcfc(x7d95d971d8923f4c);
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.x76f324df3b49ece0(this);
	}
}
