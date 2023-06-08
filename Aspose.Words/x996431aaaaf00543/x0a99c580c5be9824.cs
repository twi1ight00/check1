using x8b1f7613579e78d0;

namespace x996431aaaaf00543;

internal abstract class x0a99c580c5be9824 : x18041b360bf02656, x11cda15653a19e6d
{
	private x48d7478d49393961 xc67007a9d484cbb0;

	public x48d7478d49393961 x6a81a30bcaf20a97
	{
		get
		{
			if (xc67007a9d484cbb0 == null)
			{
				xc67007a9d484cbb0 = new x0efa7dbac80173d5();
			}
			return xc67007a9d484cbb0;
		}
		set
		{
			xc67007a9d484cbb0 = value;
		}
	}

	private x48d7478d49393961 x5df050cde52b2b7f()
	{
		if (!(x6a81a30bcaf20a97 is x87c4c4fc74c6df41))
		{
			return x6a81a30bcaf20a97;
		}
		x18041b360bf02656 x18041b360bf2657 = base.x332a8eedb847940d;
		if (x18041b360bf2657 != null && x18041b360bf2657 is x11cda15653a19e6d)
		{
			return ((x11cda15653a19e6d)x18041b360bf2657).x266a2542508e691d();
		}
		return null;
	}

	x48d7478d49393961 x11cda15653a19e6d.x266a2542508e691d()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x5df050cde52b2b7f
		return this.x5df050cde52b2b7f();
	}
}
