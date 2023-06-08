using x5794c252ba25e723;
using xa6cc8e39f9a280d7;

namespace x8b1f7613579e78d0;

internal class x87c4c4fc74c6df41 : x48d7478d49393961
{
	public override x845d6a068e0b03c5 CreateBrush(x8b545195dd56c1c7 brushRenderingContext)
	{
		x48d7478d49393961 x48d7478d49393962 = brushRenderingContext.x48e825ed21caf482.x266a2542508e691d();
		if (x48d7478d49393962 == null)
		{
			return x845d6a068e0b03c5.xb4f2f2cd9736c886();
		}
		return x48d7478d49393962.CreateBrush(brushRenderingContext);
	}

	public override void xbd7d8a7a0df4684a(xd7e8497b32a408b8 x8b80cdce7a15befe)
	{
	}

	public override x48d7478d49393961 Clone()
	{
		return new x87c4c4fc74c6df41();
	}

	public override x26d9ecb4bdf0456d GetSingleColor(x8b545195dd56c1c7 brushRenderingContext)
	{
		x48d7478d49393961 x48d7478d49393962 = brushRenderingContext.x48e825ed21caf482.x266a2542508e691d();
		if (x48d7478d49393962 == null)
		{
			return x26d9ecb4bdf0456d.x45260ad4b94166f2;
		}
		return x48d7478d49393962.GetSingleColor(brushRenderingContext);
	}
}
