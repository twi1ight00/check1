using x5794c252ba25e723;
using x9e34b6f7e9185197;

namespace xa6cc8e39f9a280d7;

internal class x18eebb9e98608d0f : x8af6aafe8486541b
{
	private xd7e8497b32a408b8 xadf06aa41b767ec0;

	public xd7e8497b32a408b8 x6f25eddbab5be6b5
	{
		get
		{
			return xadf06aa41b767ec0;
		}
		set
		{
			xadf06aa41b767ec0 = value;
		}
	}

	protected override x26d9ecb4bdf0456d CreateUnmodifiedColor(x6ecdfaec63740001 themeProvider)
	{
		if (x6f25eddbab5be6b5 != null)
		{
			return x6f25eddbab5be6b5.x9f7ccd52de411b4f(themeProvider, null);
		}
		return x26d9ecb4bdf0456d.x45260ad4b94166f2;
	}

	public override xd7e8497b32a408b8 x8b61531c8ea35b85()
	{
		x18eebb9e98608d0f x18eebb9e98608d0f2 = new x18eebb9e98608d0f();
		if (x6f25eddbab5be6b5 != null)
		{
			x18eebb9e98608d0f2.x6f25eddbab5be6b5 = x6f25eddbab5be6b5.x8b61531c8ea35b85();
		}
		xbda3841a2cedd7e2(x18eebb9e98608d0f2);
		return x18eebb9e98608d0f2;
	}

	public override void xbd7d8a7a0df4684a(xd7e8497b32a408b8 x8b80cdce7a15befe)
	{
		x6f25eddbab5be6b5 = x8b80cdce7a15befe;
	}
}
