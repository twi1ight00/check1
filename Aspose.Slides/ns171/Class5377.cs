using System.Collections;
using ns186;
using ns187;

namespace ns171;

internal class Class5377 : Class5376
{
	protected override Class5024 vmethod_0(int propId, Class5024 property, Class5052 maker, Class5634 propertyList)
	{
		ArrayList arrayList = property.vmethod_8();
		if (arrayList != null)
		{
			if (arrayList.Count == 1)
			{
				Class5024 len = (Class5024)arrayList[0];
				return new Class5044(len);
			}
			if (arrayList.Count == 2)
			{
				Class5024 ipd = (Class5024)arrayList[0];
				Class5024 bpd = (Class5024)arrayList[1];
				return new Class5044(ipd, bpd);
			}
		}
		throw new Exception55("list with 1 or 2 length values expected");
	}
}
