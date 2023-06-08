using System.Collections.Generic;
using ns305;

namespace ns287;

internal class Class7077 : Class7076
{
	private readonly Class7075 class7075_0;

	public override Class6976 this[int index] => class7075_0[index];

	public override int Length => class7075_0.Length;

	public Class7077(Class7075 list)
	{
		class7075_0 = list;
	}

	public override IEnumerator<Class6976> GetEnumerator()
	{
		return class7075_0.GetEnumerator();
	}

	public override Class6976 vmethod_0(string name)
	{
		return Class7081.smethod_0(name, class7075_0);
	}
}
