using ns305;

namespace ns81;

internal class Class4020 : Class4011
{
	public override string ConditionText => '[' + LocalName + "^=\"" + base.Value + "\"]";

	public Class4020(string namespaceURI, string localName, string value)
		: base(namespaceURI, localName, value)
	{
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		if (!method_1(e))
		{
			return false;
		}
		if (string.IsNullOrEmpty(base.Value))
		{
			return false;
		}
		string text = method_0(e);
		if (text.Length == 0)
		{
			return false;
		}
		return text.StartsWith(base.Value);
	}
}
