using System;
using ns305;

namespace ns81;

internal class Class4056 : Class4055
{
	public override int SelectorType => 4;

	public override string SelectorText
	{
		get
		{
			if (base.NamespaceURI != null)
			{
				return $"{base.NamespaceURI}|{base.LocalName}";
			}
			return base.LocalName;
		}
	}

	public override int Specificity => 1;

	public Class4056(string uri, string name)
		: base(uri, name)
	{
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		if (e == null)
		{
			return false;
		}
		if (base.NamespaceURI != null)
		{
			if (base.NamespaceURI.Length == 0)
			{
				return string.IsNullOrEmpty(e.NamespaceURI);
			}
			if (base.NamespaceURI == "*")
			{
				return e.LocalName.Equals(base.LocalName, StringComparison.InvariantCultureIgnoreCase);
			}
			if (base.Rule != null && base.Rule.ParentStyleSheet != null)
			{
				string text = base.Rule.ParentStyleSheet.NamespaceManager.LookupNamespace(base.NamespaceURI);
				if (text != null && text.Equals(e.NamespaceURI))
				{
					return e.LocalName.Equals(base.LocalName, StringComparison.InvariantCultureIgnoreCase);
				}
			}
			return false;
		}
		string text2 = ((e.Prefix != null) ? e.LocalName : e.NodeName);
		return text2.Equals(base.LocalName, StringComparison.InvariantCultureIgnoreCase);
	}
}
