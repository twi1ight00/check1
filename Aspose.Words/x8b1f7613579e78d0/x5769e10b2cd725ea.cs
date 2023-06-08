using x5794c252ba25e723;
using xa6cc8e39f9a280d7;

namespace x8b1f7613579e78d0;

internal class x5769e10b2cd725ea : x48d7478d49393961
{
	private xd7e8497b32a408b8 x78e4acec873c7675;

	public xd7e8497b32a408b8 x9b41425268471380
	{
		get
		{
			if (x78e4acec873c7675 == null)
			{
				x78e4acec873c7675 = new x43287db0aa155c99();
			}
			return x78e4acec873c7675;
		}
		set
		{
			x78e4acec873c7675 = value;
		}
	}

	public x5769e10b2cd725ea()
	{
	}

	public x5769e10b2cd725ea(xd7e8497b32a408b8 color)
	{
		x78e4acec873c7675 = color;
	}

	public override x845d6a068e0b03c5 CreateBrush(x8b545195dd56c1c7 brushRenderingContext)
	{
		x26d9ecb4bdf0456d singleColor = GetSingleColor(brushRenderingContext);
		return new xc020fa2f5133cba8(singleColor);
	}

	public override void xbd7d8a7a0df4684a(xd7e8497b32a408b8 x8b80cdce7a15befe)
	{
		x9b41425268471380.xbd7d8a7a0df4684a(x8b80cdce7a15befe);
	}

	public override x48d7478d49393961 Clone()
	{
		x5769e10b2cd725ea x5769e10b2cd725ea2 = new x5769e10b2cd725ea();
		x5769e10b2cd725ea2.x9b41425268471380 = x9b41425268471380.x8b61531c8ea35b85();
		return x5769e10b2cd725ea2;
	}

	public override x26d9ecb4bdf0456d GetSingleColor(x8b545195dd56c1c7 brushRenderingContext)
	{
		return x9b41425268471380.x9f7ccd52de411b4f(brushRenderingContext.x2898a4fa3477fa50, brushRenderingContext.x4b34cc8966adf8f7);
	}
}
