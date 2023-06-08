using System.Collections.Generic;

namespace ns33;

internal class Class1167 : Interface38
{
	private List<uint> list_0 = new List<uint>();

	public List<uint> UsedExObjIds => list_0;

	public void imethod_0(uint objId)
	{
		if (!list_0.Contains(objId))
		{
			list_0.Add(objId);
		}
	}
}
