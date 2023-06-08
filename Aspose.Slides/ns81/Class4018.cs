using ns305;

namespace ns81;

internal class Class4018 : Class4011
{
	private const string string_3 = "id";

	public override string ConditionText => "#" + base.Value;

	public override short ConditionType => 5;

	public override int Specificity => 100;

	public Class4018(string namespaceURI, string value)
		: base(namespaceURI, "id", value)
	{
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		if (!method_1(e))
		{
			return false;
		}
		string a = method_0(e);
		return string.Equals(a, base.Value);
	}
}
