using System;
using System.Collections.Generic;
using System.Text;
using ns305;
using ns73;

namespace ns81;

internal class Class4045 : Class4021
{
	private IList<string> ilist_0;

	public override short ConditionType => 6;

	public override string ConditionText
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (ilist_0.Count != 0)
			{
				stringBuilder.Append(ilist_0[0]);
				for (int i = 1; i < ilist_0.Count; i++)
				{
					stringBuilder.Append(", ").Append(ilist_0[i]);
				}
			}
			return ':' + base.ClassName + stringBuilder.ToString() + ')';
		}
	}

	public Class4045(IList<string> languages)
		: base("lang(")
	{
		ilist_0 = languages;
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		string text = ((!e.method_34("lang")) ? ((Interface89)e.OwnerDocument).Engine.Context.Language : e.method_20("lang"));
		if (string.IsNullOrEmpty(text))
		{
			return false;
		}
		foreach (string item in ilist_0)
		{
			if (method_0(text, item))
			{
				return true;
			}
		}
		return false;
	}

	private bool method_0(string attributeValue, string language)
	{
		if (attributeValue.Length < language.Length)
		{
			return false;
		}
		if (attributeValue.Length == language.Length)
		{
			return attributeValue.Equals(language, StringComparison.OrdinalIgnoreCase);
		}
		if (!attributeValue.StartsWith(language, StringComparison.OrdinalIgnoreCase))
		{
			return false;
		}
		return attributeValue[language.Length] == '-';
	}
}
