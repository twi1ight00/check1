using ns305;

namespace ns81;

internal class Class4015 : Class4011
{
	public override string ConditionText => '[' + LocalName + "|=\"" + base.Value + "\"]";

	public Class4015(string namespaceURI, string localName, string value)
		: base(namespaceURI, localName, value)
	{
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		if (!method_1(e))
		{
			return false;
		}
		string text = method_0(e);
		if (text.Length < base.Value.Length)
		{
			return false;
		}
		if (text.Length == base.Value.Length)
		{
			return text.Equals(base.Value);
		}
		if (text.IndexOf(base.Value) != 0)
		{
			return false;
		}
		return text[base.Value.Length] == '-';
	}
}
