using System.Collections;
using ns3;

namespace ns33;

internal class Class826 : CollectionBase, Interface12
{
	public Interface7 this[int int_0] => (Interface7)base.InnerList[int_0];

	internal Class821 method_0(int int_0)
	{
		return (Class821)base.InnerList[int_0];
	}

	public void Add(Interface7 interface7_0)
	{
		base.InnerList.Add(interface7_0);
	}
}
