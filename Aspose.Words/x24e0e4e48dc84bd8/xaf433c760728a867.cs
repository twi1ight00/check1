using x1c8faa688b1f0b0c;
using x74500b509de15565;
using xa7850104c8d8c135;

namespace x24e0e4e48dc84bd8;

internal class xaf433c760728a867 : x1183fab9204ba68f
{
	private x4e88096751fad171 xd995695f8e3419d6;

	private xe13683ed8fc82e3e x0bd73765f3a26a8b;

	public xaf433c760728a867(x3fa09e8d7b952fbc metafileInfo, xb0d8039f74776744 apsBuilderContext)
		: base(metafileInfo, apsBuilderContext)
	{
	}

	protected override void InitPlayer()
	{
		xd995695f8e3419d6 = new x4e88096751fad171(base.x4aca0559c9e6ddc0, base.x437e3b626c0fdd43, base.xa6f30a6360be2a75);
		x0bd73765f3a26a8b = new xe13683ed8fc82e3e(base.x4aca0559c9e6ddc0, base.x437e3b626c0fdd43, xd995695f8e3419d6.xf86de1bd2f396938, base.xf69ca7a9bb4a4a51);
	}

	protected override xb8e7e788f6d59708 GetResult()
	{
		return xd995695f8e3419d6.x145e3af29556cafe.x5fe28c2b4826581d;
	}

	protected override void PlayRecord()
	{
		xec95ecd2fe18d5f2 x3146d638ec = xe3e99d3417159bec.x3146d638ec378671;
		if (x3146d638ec == xec95ecd2fe18d5f2.x32a832cf175b0e64)
		{
			if (xd995695f8e3419d6.x329f25d15ea01db1.x8b4b6fcc891336ca)
			{
				xcd10177112ae83c8();
			}
			xd995695f8e3419d6.x329f25d15ea01db1.x0613827d1b6c81c9(xf86de1bd2f396938, base.x6cd834400ec1b81e);
		}
		else if (xd995695f8e3419d6.x329f25d15ea01db1.x8b4b6fcc891336ca)
		{
			x0bd73765f3a26a8b.xb820878a71fbe650(xe3e99d3417159bec.x3146d638ec378671);
			base.xa6f30a6360be2a75.xec8728ceac69f279 |= x0bd73765f3a26a8b.xec8728ceac69f279;
		}
	}

	private void xcd10177112ae83c8()
	{
		xd995695f8e3419d6.x145e3af29556cafe.xbb4d4033cbf2c7fd(x0bd73765f3a26a8b.x2194e74ed40dc190);
		x0bd73765f3a26a8b.x37a875a771670c60();
	}
}
