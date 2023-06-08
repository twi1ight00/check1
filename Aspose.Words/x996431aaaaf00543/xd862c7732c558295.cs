using System.Collections;
using x1c8faa688b1f0b0c;
using x8784bdb393e53e65;

namespace x996431aaaaf00543;

internal abstract class xd862c7732c558295 : x0a99c580c5be9824
{
	private readonly ArrayList xc7d5d28b3f8072cd = new ArrayList();

	private x734f6a4f5af93ce5 x435b26849f0d2436;

	internal ArrayList x63b0f7fed3f5bd88 => xc7d5d28b3f8072cd;

	public override x78e18bdf9a108059 GetTransform()
	{
		if (x435b26849f0d2436 == null)
		{
			x435b26849f0d2436 = new x734f6a4f5af93ce5();
		}
		return x435b26849f0d2436;
	}

	internal void x625c1e7700dd35e9(x734f6a4f5af93ce5 x678241938de24d81)
	{
		x435b26849f0d2436 = x678241938de24d81;
	}

	public override x4fdf549af9de6b97 Render(x2094302a66c2ec77 nodeRenderParams)
	{
		nodeRenderParams.x1a1fb4b19097b9f6.x84e43ba1eb351dc4(GetTransform());
		try
		{
			xbaec545ec01f92ca xbaec545ec01f92ca = CreateApsCompositeNode();
			foreach (x18041b360bf02656 item in x63b0f7fed3f5bd88)
			{
				x4fdf549af9de6b97 xda5bf54deb817e = item.Render(nodeRenderParams);
				xbaec545ec01f92ca.xd6b6ed77479ef68c(xda5bf54deb817e);
			}
			return xbaec545ec01f92ca;
		}
		finally
		{
			nodeRenderParams.x1a1fb4b19097b9f6.x23f6d2779534dd99();
		}
	}

	internal void x07a948cd08942074(x18041b360bf02656 xda5bf54deb817e37)
	{
		if (xda5bf54deb817e37 != null)
		{
			xc7d5d28b3f8072cd.Add(xda5bf54deb817e37);
			xda5bf54deb817e37.x332a8eedb847940d = this;
		}
	}

	protected abstract xbaec545ec01f92ca CreateApsCompositeNode();
}
