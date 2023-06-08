using System.Collections;
using x24ed092a62874e86;
using x5794c252ba25e723;
using x8b1f7613579e78d0;
using x9e34b6f7e9185197;

namespace xa6cc8e39f9a280d7;

internal abstract class x8af6aafe8486541b : xd7e8497b32a408b8, xa4e6507e0e2894c8
{
	private ArrayList x268ed50457065dac;

	public ArrayList x30f0af038def5996
	{
		get
		{
			if (x268ed50457065dac == null)
			{
				x268ed50457065dac = new ArrayList();
			}
			return x268ed50457065dac;
		}
		set
		{
			x268ed50457065dac = value;
		}
	}

	public x26d9ecb4bdf0456d x9f7ccd52de411b4f(x6ecdfaec63740001 xaeae22d502c36c76, xda4dde4038ab80db xe39834bd74888b98)
	{
		x26d9ecb4bdf0456d x6c50a99faab7d = CreateUnmodifiedColor(xaeae22d502c36c76);
		return x87e4db1b1f04e275(x6c50a99faab7d, xe39834bd74888b98);
	}

	public abstract xd7e8497b32a408b8 x8b61531c8ea35b85();

	public virtual void xbd7d8a7a0df4684a(xd7e8497b32a408b8 x8b80cdce7a15befe)
	{
	}

	private x26d9ecb4bdf0456d x87e4db1b1f04e275(x26d9ecb4bdf0456d x6c50a99faab7d741, xda4dde4038ab80db xe39834bd74888b98)
	{
		foreach (xda4dde4038ab80db item in x30f0af038def5996)
		{
			x6c50a99faab7d741 = item.x57f70b425b43a885(x6c50a99faab7d741);
		}
		if (xe39834bd74888b98 != null)
		{
			x6c50a99faab7d741 = xe39834bd74888b98.x57f70b425b43a885(x6c50a99faab7d741);
		}
		return x6c50a99faab7d741;
	}

	protected abstract x26d9ecb4bdf0456d CreateUnmodifiedColor(x6ecdfaec63740001 themeProvider);

	protected void xbda3841a2cedd7e2(x8af6aafe8486541b x6c50a99faab7d741)
	{
		ArrayList arrayList = new ArrayList(x30f0af038def5996.Count);
		foreach (xf8ef22f0e601a113 item in x30f0af038def5996)
		{
			arrayList.Add(item.x8b61531c8ea35b85());
		}
		x6c50a99faab7d741.x30f0af038def5996 = arrayList;
	}
}
