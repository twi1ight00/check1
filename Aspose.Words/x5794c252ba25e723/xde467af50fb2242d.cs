using System.Collections;
using System.Reflection;
using Aspose;

namespace x5794c252ba25e723;

[DefaultMember("Item")]
internal abstract class xde467af50fb2242d : xcb322cb732dde676
{
	private x630b5fb239bb4657 x06b983e52d670ed8;

	private ArrayList xddc60c8d74d0f01b = new ArrayList();

	public xcb322cb732dde676 xe6d4b1b411ed94b5 => (xcb322cb732dde676)xddc60c8d74d0f01b[xc0c4c459c6ccbd00];

	public int xd44988f225497f3a => xddc60c8d74d0f01b.Count;

	public x630b5fb239bb4657 x52dde376accdec7d
	{
		get
		{
			return x06b983e52d670ed8;
		}
		set
		{
			x06b983e52d670ed8 = value;
		}
	}

	[JavaThrows(true)]
	public override void Accept(x2f90c0cfb1f8b01a visitor)
	{
		for (int i = 0; i < xd44988f225497f3a; i++)
		{
			this.get_xe6d4b1b411ed94b5(i).Accept(visitor);
		}
	}

	public override xcb322cb732dde676 DeepCopy()
	{
		xde467af50fb2242d xde467af50fb2242d2 = (xde467af50fb2242d)MemberwiseClone();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < xddc60c8d74d0f01b.Count; i++)
		{
			xcb322cb732dde676 xcb322cb732dde677 = (xcb322cb732dde676)xddc60c8d74d0f01b[i];
			arrayList.Insert(i, xcb322cb732dde677.DeepCopy());
		}
		xde467af50fb2242d2.xddc60c8d74d0f01b = arrayList;
		return xde467af50fb2242d2;
	}

	public int xd6b6ed77479ef68c(xcb322cb732dde676 x4bbc2c453c470189)
	{
		return xddc60c8d74d0f01b.Add(x4bbc2c453c470189);
	}
}
