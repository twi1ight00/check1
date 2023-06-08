using System.Xml;
using ns171;
using ns173;
using ns181;
using ns189;

namespace ns198;

internal class Class5305 : Class5302
{
	public Class5305(Class5111 node)
		: base(node)
	{
	}

	protected override Class4942 vmethod_6()
	{
		Class5089 @class = ((Class5111)class5094_0).method_58();
		XmlDocument d = @class.method_25();
		string ns = @class.vmethod_23();
		return new Class4970(d, ns, @class);
	}
}
