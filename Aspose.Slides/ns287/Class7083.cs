using System.Collections.Generic;
using ns305;

namespace ns287;

internal class Class7083 : Class7078
{
	private readonly Class7075 class7075_0;

	public override int Length => class7075_0.Length;

	public override Class6976 this[int index] => class7075_0[index];

	public Class7083(Class6993 table, Class7075 rows)
	{
		class7075_0 = rows;
	}

	public override IEnumerator<Class6976> GetEnumerator()
	{
		return class7075_0.GetEnumerator();
	}

	public override Class6976 vmethod_0(string name)
	{
		return Class7079.smethod_0(class7075_0, name);
	}
}
