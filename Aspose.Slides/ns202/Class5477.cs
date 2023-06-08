using System.Xml;
using ns178;
using ns195;
using ns200;

namespace ns202;

internal class Class5477 : Interface190
{
	public static string string_0 = "handler";

	public void imethod_0(Class5467 context, XmlDocument doc, string ns)
	{
		Interface153 handler = (Interface153)context.method_5(string_0);
		new Class5476(handler).method_0(doc, fragment: true);
	}

	public bool imethod_1(Interface177 renderer)
	{
		return false;
	}

	public string imethod_2()
	{
		return null;
	}
}
