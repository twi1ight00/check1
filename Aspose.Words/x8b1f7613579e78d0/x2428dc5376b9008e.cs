using System.Drawing.Drawing2D;
using x5794c252ba25e723;
using xa6cc8e39f9a280d7;

namespace x8b1f7613579e78d0;

internal class x2428dc5376b9008e : x48d7478d49393961
{
	private xd7e8497b32a408b8 xe5cc466041b3bc40;

	private HatchStyle x21f185dd7bb86df2;

	private xd7e8497b32a408b8 x5c3b7d4a019de9e1;

	public HatchStyle x2a59303840dae913
	{
		get
		{
			return x21f185dd7bb86df2;
		}
		set
		{
			x21f185dd7bb86df2 = value;
		}
	}

	public xd7e8497b32a408b8 x83729c7ebf48ae24
	{
		get
		{
			if (xe5cc466041b3bc40 == null)
			{
				xe5cc466041b3bc40 = new x43287db0aa155c99();
			}
			return xe5cc466041b3bc40;
		}
		set
		{
			xe5cc466041b3bc40 = value;
		}
	}

	public xd7e8497b32a408b8 x8fdbd80e8da6b0e6
	{
		get
		{
			if (x5c3b7d4a019de9e1 == null)
			{
				x5c3b7d4a019de9e1 = new x43287db0aa155c99();
			}
			return x5c3b7d4a019de9e1;
		}
		set
		{
			x5c3b7d4a019de9e1 = value;
		}
	}

	public override x845d6a068e0b03c5 CreateBrush(x8b545195dd56c1c7 brushRenderingContext)
	{
		x26d9ecb4bdf0456d foreColor = x23acf9287ae03218(brushRenderingContext);
		x26d9ecb4bdf0456d backColor = x8a0feb50a8624d8e(brushRenderingContext);
		return new x5bdb4ba66c23277c(x2a59303840dae913, foreColor, backColor);
	}

	private x26d9ecb4bdf0456d x23acf9287ae03218(x8b545195dd56c1c7 xf1125c563ec28c45)
	{
		return x8fdbd80e8da6b0e6.x9f7ccd52de411b4f(xf1125c563ec28c45.x2898a4fa3477fa50, xf1125c563ec28c45.x4b34cc8966adf8f7);
	}

	private x26d9ecb4bdf0456d x8a0feb50a8624d8e(x8b545195dd56c1c7 xf1125c563ec28c45)
	{
		return x83729c7ebf48ae24.x9f7ccd52de411b4f(xf1125c563ec28c45.x2898a4fa3477fa50, xf1125c563ec28c45.x4b34cc8966adf8f7);
	}

	public override void xbd7d8a7a0df4684a(xd7e8497b32a408b8 x8b80cdce7a15befe)
	{
		x8fdbd80e8da6b0e6.xbd7d8a7a0df4684a(x8b80cdce7a15befe);
		x83729c7ebf48ae24.xbd7d8a7a0df4684a(x8b80cdce7a15befe);
	}

	public override x48d7478d49393961 Clone()
	{
		x2428dc5376b9008e x2428dc5376b9008e2 = new x2428dc5376b9008e();
		x2428dc5376b9008e2.x2a59303840dae913 = x2a59303840dae913;
		x2428dc5376b9008e2.x83729c7ebf48ae24 = x83729c7ebf48ae24.x8b61531c8ea35b85();
		x2428dc5376b9008e2.x8fdbd80e8da6b0e6 = x8fdbd80e8da6b0e6.x8b61531c8ea35b85();
		return x2428dc5376b9008e2;
	}

	public override x26d9ecb4bdf0456d GetSingleColor(x8b545195dd56c1c7 brushRenderingContext)
	{
		return x23acf9287ae03218(brushRenderingContext);
	}
}
