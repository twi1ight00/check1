using System.Collections;

namespace xcc8a79815d76af85;

internal class xecb835beef9d8f87
{
	private int x224f8347c8135f7c;

	private Hashtable xc72926de6b6361e2;

	private xd620087af5172910 xd8b5b1f3cca7ee13;

	private bool xa5958282693f3f7d;

	private string x9a825beeeb75071e;

	public Hashtable x320382c5f1993a78 => xc72926de6b6361e2;

	public string xfc954f23e7c18656
	{
		get
		{
			return x9a825beeeb75071e;
		}
		set
		{
			x9a825beeeb75071e = value;
		}
	}

	public bool x65f91c9f46c9e393 => xa5958282693f3f7d;

	public xd620087af5172910 x2bd4228892f25674 => xd8b5b1f3cca7ee13;

	public int xf42c656bff43cb4a => xc72926de6b6361e2.Count;

	public int x2205bab75ecf5743
	{
		get
		{
			return x224f8347c8135f7c;
		}
		set
		{
			x224f8347c8135f7c = value;
		}
	}

	public xecb835beef9d8f87(xd620087af5172910 pointType, bool isCache)
	{
		xd8b5b1f3cca7ee13 = pointType;
		xa5958282693f3f7d = isCache;
		xc72926de6b6361e2 = new Hashtable();
	}

	public void x2f72b9643ccd1483(x86270791cf6a92b9 x2f7096dac971d6ec)
	{
		xc72926de6b6361e2[x2f7096dac971d6ec.xd1bdf42207dd3638] = x2f7096dac971d6ec;
	}
}
