using System;
using System.Collections;

namespace ns18;

internal abstract class Class453 : Class452
{
	private ArrayList arrayList_0 = new ArrayList();

	public Class452 this[int int_0] => (Class452)arrayList_0[int_0];

	public override void vmethod_0(Class468 class468_0)
	{
		foreach (Class452 item in arrayList_0)
		{
			item.vmethod_0(class468_0);
		}
	}

	public int Add(Class452 class452_0)
	{
		if (class452_0 == null)
		{
			throw new ArgumentNullException("node");
		}
		class452_0.method_0(this);
		return arrayList_0.Add(class452_0);
	}

	public ArrayList method_1()
	{
		return arrayList_0;
	}
}
