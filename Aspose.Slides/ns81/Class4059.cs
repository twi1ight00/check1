using ns305;

namespace ns81;

internal class Class4059 : Class4055
{
	public override int SelectorType => 1;

	public override string SelectorText
	{
		get
		{
			if (base.NamespaceURI != null)
			{
				return $"{base.NamespaceURI}|*";
			}
			return "*";
		}
	}

	public override int Specificity => 0;

	public Class4059(string uri)
		: base(uri, null)
	{
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		if (base.NamespaceURI != null)
		{
			if (base.NamespaceURI.Length == 0)
			{
				return string.IsNullOrEmpty(e.NamespaceURI);
			}
			if (base.NamespaceURI == "*")
			{
				return true;
			}
			if (base.Rule != null && base.Rule.ParentStyleSheet != null)
			{
				string text = base.Rule.ParentStyleSheet.NamespaceManager.LookupNamespace(base.NamespaceURI);
				if (text != null)
				{
					return text.Equals(e.NamespaceURI);
				}
			}
			return false;
		}
		return true;
	}
}
