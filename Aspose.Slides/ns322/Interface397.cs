using System.Collections;

namespace ns322;

internal interface Interface397 : IEnumerable
{
	int Count { get; }

	IEnumerable Values { get; }

	Class7352 imethod_0(string name, Class7352 descriptor);

	void imethod_1(string name);

	Class7352 imethod_2(string name);

	bool imethod_3(string name, out Class7352 descriptor);
}
