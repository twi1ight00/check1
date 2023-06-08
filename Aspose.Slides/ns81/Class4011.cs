using ns305;

namespace ns81;

internal abstract class Class4011 : Class4010, Interface81, Interface82
{
	private string string_0;

	private string string_1;

	private string string_2;

	public virtual string NamespaceURI => string_0;

	public virtual string LocalName => string_1;

	public string Value => string_2;

	public override int Specificity => 10;

	public override short ConditionType => 4;

	public override string ConditionText
	{
		get
		{
			if (string_2 == null)
			{
				return '[' + string_1 + ']';
			}
			return '[' + string_1 + "=\"" + string_2 + "\"]";
		}
	}

	protected Class4011(string namespaceURI, string localName, string value)
	{
		string_0 = namespaceURI;
		string_1 = localName;
		string_2 = value;
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		if (string_2 == null)
		{
			return e.method_34(string_1);
		}
		return e.method_20(string_1).Equals(string_2);
	}

	protected string method_0(Class6981 e)
	{
		if (string_0 == null)
		{
			return e.method_20(LocalName);
		}
		if (NamespaceURI == "*")
		{
			return e.method_28(string_0, LocalName);
		}
		string namespaceURI = base.Rule.ParentStyleSheet.NamespaceManager.LookupNamespace(NamespaceURI);
		return e.method_28(namespaceURI, LocalName);
	}

	protected bool method_1(Class6981 e)
	{
		if (string_0 == null)
		{
			return e.method_34(LocalName);
		}
		if (NamespaceURI == "*")
		{
			return e.method_35(string_0, LocalName);
		}
		string namespaceURI = base.Rule.ParentStyleSheet.NamespaceManager.LookupNamespace(NamespaceURI);
		return e.method_35(namespaceURI, LocalName);
	}
}
