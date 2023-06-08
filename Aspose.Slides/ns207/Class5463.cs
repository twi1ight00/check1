using ns175;
using ns200;
using ns208;

namespace ns207;

internal class Class5463 : Class5462
{
	private int int_0;

	private Class5738 class5738_0;

	public Class5463(Interface196 ifDocumentHandler, Class5738 userAgent)
		: base(ifDocumentHandler)
	{
		class5738_0 = userAgent;
	}

	public override void imethod_20()
	{
		base.imethod_20();
		int_0++;
		Class5466.smethod_0(class5738_0.method_48()).imethod_1(this, int_0);
	}
}
