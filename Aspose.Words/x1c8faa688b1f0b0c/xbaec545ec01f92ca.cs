using System;
using System.Collections;
using System.Reflection;

namespace x1c8faa688b1f0b0c;

[DefaultMember("Item")]
internal abstract class xbaec545ec01f92ca : x4fdf549af9de6b97
{
	private ArrayList xddc60c8d74d0f01b = new ArrayList();

	public x4fdf549af9de6b97 xe6d4b1b411ed94b5 => (x4fdf549af9de6b97)xddc60c8d74d0f01b[xc0c4c459c6ccbd00];

	public int xd44988f225497f3a => xddc60c8d74d0f01b.Count;

	public override void Accept(xf51865b83a7a0b3b visitor)
	{
		for (int i = 0; i < xddc60c8d74d0f01b.Count; i++)
		{
			x4fdf549af9de6b97 x4fdf549af9de6b98 = (x4fdf549af9de6b97)xddc60c8d74d0f01b[i];
			x4fdf549af9de6b98.Accept(visitor);
		}
	}

	public void xef23aa45e7612fdd(int xc0c4c459c6ccbd00, x4fdf549af9de6b97 xda5bf54deb817e37)
	{
		xda5bf54deb817e37.x332a8eedb847940d = this;
		xddc60c8d74d0f01b.Insert(xc0c4c459c6ccbd00, xda5bf54deb817e37);
	}

	public int xd6b6ed77479ef68c(x4fdf549af9de6b97 xda5bf54deb817e37)
	{
		xda5bf54deb817e37.x332a8eedb847940d = this;
		return xddc60c8d74d0f01b.Add(xda5bf54deb817e37);
	}

	public void xf82029c4e8b4cfc3(x4fdf549af9de6b97[] xa955664f4f50999d)
	{
		for (int i = 0; i < xa955664f4f50999d.Length; i++)
		{
			xd6b6ed77479ef68c(xa955664f4f50999d[i]);
		}
	}

	public void x7121e9e177952651(int xc0c4c459c6ccbd00)
	{
		if (0 > xc0c4c459c6ccbd00 || xc0c4c459c6ccbd00 >= xddc60c8d74d0f01b.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		xddc60c8d74d0f01b.RemoveAt(xc0c4c459c6ccbd00);
	}

	public void xa9d636b00ff486b7()
	{
		xddc60c8d74d0f01b.Clear();
	}

	public int x2ee5ad3d826ed0fe(x4fdf549af9de6b97 xda5bf54deb817e37)
	{
		return xddc60c8d74d0f01b.IndexOf(xda5bf54deb817e37);
	}

	public override x4fdf549af9de6b97 DeepCopy()
	{
		xbaec545ec01f92ca xbaec545ec01f92ca2 = (xbaec545ec01f92ca)MemberwiseClone();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < xddc60c8d74d0f01b.Count; i++)
		{
			x4fdf549af9de6b97 x4fdf549af9de6b98 = (x4fdf549af9de6b97)xddc60c8d74d0f01b[i];
			arrayList.Insert(i, x4fdf549af9de6b98.DeepCopy());
		}
		xbaec545ec01f92ca2.xddc60c8d74d0f01b = arrayList;
		return xbaec545ec01f92ca2;
	}
}
