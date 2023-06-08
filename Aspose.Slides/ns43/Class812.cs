using System.Xml;
using ns42;

namespace ns43;

internal class Class812 : Class810
{
	internal static readonly string string_1 = "col";

	private int int_0;

	private int int_1;

	private bool bool_0;

	internal bool Hidden => bool_0;

	internal int Max => int_1;

	internal int Min => int_0;

	public Class812(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}

	internal override void vmethod_0()
	{
		base.vmethod_0();
		int_0 = method_11("min", string.Empty, -1);
		int_1 = method_11("max", string.Empty, -1);
		string attribute = GetAttribute("hidden");
		bool_0 = attribute != string.Empty && XmlConvert.ToBoolean(attribute);
	}
}
