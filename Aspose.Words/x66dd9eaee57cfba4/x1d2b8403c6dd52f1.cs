using System;
using System.Collections;
using System.Reflection;
using x13f1efc79617a47b;
using xeb665d1aeef09d64;

namespace x66dd9eaee57cfba4;

[DefaultMember("Item")]
internal class x1d2b8403c6dd52f1
{
	private readonly Hashtable x82b70567a5f68f41 = new Hashtable();

	private x7c1d47b289dfd9fa x9434a615992625f7;

	private readonly ArrayList xace7787d76440092;

	public x7c1d47b289dfd9fa xe6d4b1b411ed94b5
	{
		get
		{
			x7c1d47b289dfd9fa x7c1d47b289dfd9fa2 = (x7c1d47b289dfd9fa)x82b70567a5f68f41[x8dcb0a33c47803dd];
			if (x7c1d47b289dfd9fa2 != null)
			{
				return x7c1d47b289dfd9fa2;
			}
			foreach (int item in x6084df92c9a723c3(x8dcb0a33c47803dd))
			{
				x7c1d47b289dfd9fa2 = (x7c1d47b289dfd9fa)x82b70567a5f68f41[item];
				if (x7c1d47b289dfd9fa2 != null)
				{
					return x7c1d47b289dfd9fa2;
				}
			}
			return null;
		}
		set
		{
			x82b70567a5f68f41[x8dcb0a33c47803dd] = value;
		}
	}

	public int xd44988f225497f3a => x82b70567a5f68f41.Count;

	public x7c1d47b289dfd9fa x03efdcbb7b70d603
	{
		get
		{
			return x9434a615992625f7;
		}
		set
		{
			x9434a615992625f7 = value;
		}
	}

	public ICollection xe4a88350013963a1 => x82b70567a5f68f41.Values;

	public x1d2b8403c6dd52f1(bool isSymbolicFont)
	{
		xace7787d76440092 = new ArrayList();
		xace7787d76440092.Add(new xf680cc619adfc2aa());
		if (isSymbolicFont)
		{
			xace7787d76440092.Add(new xa7cce133345f9e8f());
		}
	}

	private ArrayList x6084df92c9a723c3(int x3c4da2980d043c95)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(x3c4da2980d043c95);
		foreach (xe26a2357ce987196 item in xace7787d76440092)
		{
			item.x57bf52bb3d1c2d43(arrayList);
		}
		return arrayList;
	}

	public void xd6b6ed77479ef68c(x7c1d47b289dfd9fa x268076ae4d2d65dd)
	{
		x82b70567a5f68f41[x268076ae4d2d65dd.xfea0b9f75f567474] = x268076ae4d2d65dd;
	}

	public x7c1d47b289dfd9fa x12f49b36ab885c48(int x8dcb0a33c47803dd)
	{
		x7c1d47b289dfd9fa x7c1d47b289dfd9fa2 = this.get_xe6d4b1b411ed94b5(x8dcb0a33c47803dd);
		if (x7c1d47b289dfd9fa2 != null)
		{
			return x7c1d47b289dfd9fa2;
		}
		return x5341bcaa5a3ff3ce();
	}

	public x7c1d47b289dfd9fa x6ecaa0bbab86f311(int x7a6027e2e9a31663)
	{
		foreach (x7c1d47b289dfd9fa value in x82b70567a5f68f41.Values)
		{
			if (value.xf642ec8fe8ccb98e == x7a6027e2e9a31663)
			{
				return value;
			}
		}
		return x5341bcaa5a3ff3ce();
	}

	private x7c1d47b289dfd9fa x5341bcaa5a3ff3ce()
	{
		x7c1d47b289dfd9fa x7c1d47b289dfd9fa2 = x9434a615992625f7;
		if (x7c1d47b289dfd9fa2 != null)
		{
			return x7c1d47b289dfd9fa2;
		}
		x7c1d47b289dfd9fa2 = this.get_xe6d4b1b411ed94b5(32);
		if (x7c1d47b289dfd9fa2 != null)
		{
			return x7c1d47b289dfd9fa2;
		}
		throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("abholcoofdfpcdmpaddacdkalnabobibobpbacgcdbncmmddkaldgmbekajemaafgbhfkaofppegellghpchnpjhnpaiikhijpoikofjiomjpodkjjkkjnbllnilbnplpngmlmnmkmeninlngmcoanjolhapllhpemopglfaelmakhdb", 1518724813)));
	}
}
