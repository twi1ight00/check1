using x5794c252ba25e723;
using x9e34b6f7e9185197;
using xf9a9481c3f63a419;

namespace xa6cc8e39f9a280d7;

internal class x43287db0aa155c99 : x8af6aafe8486541b
{
	private string x4574aea041dd835f;

	public string xd2f68ee6f47e9dfb
	{
		get
		{
			if (x4574aea041dd835f == null)
			{
				x4574aea041dd835f = string.Empty;
			}
			return x4574aea041dd835f;
		}
		set
		{
			x4574aea041dd835f = value;
		}
	}

	public x43287db0aa155c99()
	{
	}

	public x43287db0aa155c99(string value)
	{
		xd2f68ee6f47e9dfb = value;
	}

	protected override x26d9ecb4bdf0456d CreateUnmodifiedColor(x6ecdfaec63740001 themeProvider)
	{
		if (xd2f68ee6f47e9dfb.Length == 0)
		{
			return x26d9ecb4bdf0456d.x45260ad4b94166f2;
		}
		return xa85c3c231557eaae(xd2f68ee6f47e9dfb);
	}

	public override xd7e8497b32a408b8 x8b61531c8ea35b85()
	{
		x43287db0aa155c99 x43287db0aa155c100 = new x43287db0aa155c99();
		x43287db0aa155c100.xd2f68ee6f47e9dfb = xd2f68ee6f47e9dfb;
		xbda3841a2cedd7e2(x43287db0aa155c100);
		return x43287db0aa155c100;
	}

	internal static x26d9ecb4bdf0456d xa85c3c231557eaae(string xbcea506a33cf9111)
	{
		int argb = xca004f56614e2431.xadcf75bfc0bf31e3(xbcea506a33cf9111) | -16777216;
		return new x26d9ecb4bdf0456d(argb);
	}
}
