using ns305;

namespace ns81;

internal class Class4017 : Class4011
{
	public override string ConditionText => '[' + LocalName + "=\"" + base.Value + "\"]";

	public Class4017(string namespaceURI, string localName, string value)
		: base(namespaceURI, localName, value)
	{
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		if (!method_1(e))
		{
			return false;
		}
		string value = method_0(e);
		return base.Value.Equals(value);
	}
}
