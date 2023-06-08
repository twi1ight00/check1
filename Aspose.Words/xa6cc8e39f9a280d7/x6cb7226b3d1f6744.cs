using x5794c252ba25e723;
using x6b8130194ad714f7;
using x6c95d9cf46ff5f25;
using x9e34b6f7e9185197;

namespace xa6cc8e39f9a280d7;

internal class x6cb7226b3d1f6744 : x8af6aafe8486541b
{
	private xd4583a58cd9d2194 x2587bd395eda0985 = new xd4583a58cd9d2194();

	private x2f7951fa0946af7e xb791511f505b4227 = new x2f7951fa0946af7e(0.0);

	private x2f7951fa0946af7e x7045162f25d703b1 = new x2f7951fa0946af7e(0.0);

	public x2f7951fa0946af7e xa93394e415277432
	{
		get
		{
			return x7045162f25d703b1;
		}
		set
		{
			x7045162f25d703b1 = value;
		}
	}

	public x2f7951fa0946af7e x5977e61981871b60
	{
		get
		{
			return xb791511f505b4227;
		}
		set
		{
			xb791511f505b4227 = value;
		}
	}

	public xd4583a58cd9d2194 x771e11bd2ca66cba
	{
		get
		{
			return x2587bd395eda0985;
		}
		set
		{
			x2587bd395eda0985 = value;
		}
	}

	public override xd7e8497b32a408b8 x8b61531c8ea35b85()
	{
		x6cb7226b3d1f6744 x6cb7226b3d1f6745 = new x6cb7226b3d1f6744();
		x6cb7226b3d1f6745.xa93394e415277432 = xa93394e415277432;
		x6cb7226b3d1f6745.x5977e61981871b60 = x5977e61981871b60;
		x6cb7226b3d1f6745.x771e11bd2ca66cba = x771e11bd2ca66cba;
		xbda3841a2cedd7e2(x6cb7226b3d1f6745);
		return x6cb7226b3d1f6745;
	}

	protected override x26d9ecb4bdf0456d CreateUnmodifiedColor(x6ecdfaec63740001 themeProvider)
	{
		x01f74f175f4a1d3d x01f74f175f4a1d3d = new x01f74f175f4a1d3d(x771e11bd2ca66cba.x95bb1b6b5e161bbe / 360.0, xa93394e415277432.x71c5078172d72420, x5977e61981871b60.x71c5078172d72420);
		return x01f74f175f4a1d3d.x1659cb35054965d4();
	}
}
