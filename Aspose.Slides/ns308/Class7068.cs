using System;
using System.Collections.Generic;
using ns305;
using ns307;

namespace ns308;

internal class Class7068 : Class7067
{
	private readonly IDictionary<string, IEnumerable<KeyValuePair<string, string>>> idictionary_0;

	private readonly IDictionary<KeyValuePair<string, string>, IEnumerable<KeyValuePair<string, string>>> idictionary_1;

	private readonly Enum964 enum964_0;

	public Class7068(IDictionary<string, IEnumerable<KeyValuePair<string, string>>> tagsAttrs, Enum964 options, string asterisk)
		: base(tagsAttrs.Keys, asterisk)
	{
		idictionary_1 = null;
		idictionary_0 = new Dictionary<string, IEnumerable<KeyValuePair<string, string>>>(tagsAttrs);
		enum964_0 = options;
	}

	public Class7068(IDictionary<KeyValuePair<string, string>, IEnumerable<KeyValuePair<string, string>>> tagsNsAttrs, Enum964 options, string asterisk)
		: base(tagsNsAttrs.Keys, asterisk)
	{
		idictionary_0 = null;
		idictionary_1 = new Dictionary<KeyValuePair<string, string>, IEnumerable<KeyValuePair<string, string>>>(tagsNsAttrs);
		enum964_0 = options;
	}

	public Class7068(string name, IEnumerable<KeyValuePair<string, string>> attributes, Enum964 options, string asterisk)
		: base(name, asterisk)
	{
		idictionary_1 = null;
		idictionary_0 = new Dictionary<string, IEnumerable<KeyValuePair<string, string>>>();
		idictionary_0.Add(name, attributes);
		enum964_0 = options;
	}

	public Class7068(string namespaceUri, string localName, IEnumerable<KeyValuePair<string, string>> attributes, Enum964 options, string asterisk)
		: base(namespaceUri, localName, asterisk)
	{
		idictionary_0 = null;
		idictionary_1 = new Dictionary<KeyValuePair<string, string>, IEnumerable<KeyValuePair<string, string>>>();
		idictionary_1.Add(new KeyValuePair<string, string>(namespaceUri, localName), attributes);
		enum964_0 = options;
	}

	public override short imethod_0(Class6976 n)
	{
		short num = base.imethod_0(n);
		if (num != 1)
		{
			return num;
		}
		IEnumerable<KeyValuePair<string, string>> enumerable = null;
		if (idictionary_0 != null && idictionary_0.ContainsKey(n.NodeName))
		{
			enumerable = idictionary_0[n.NodeName];
		}
		else if (idictionary_1 != null)
		{
			KeyValuePair<string, string> key = new KeyValuePair<string, string>(n.NamespaceURI, n.LocalName);
			if (idictionary_1.ContainsKey(key))
			{
				enumerable = idictionary_1[key];
			}
		}
		if (enumerable == null)
		{
			return 1;
		}
		foreach (KeyValuePair<string, string> item in enumerable)
		{
			if (n.Attributes.Contains(item.Key))
			{
				if (!string.IsNullOrEmpty(item.Value))
				{
					string value = n.Attributes.method_11(item.Key).Value;
					if (value != null && value.StartsWith(item.Value, StringComparison.OrdinalIgnoreCase))
					{
						if (enum964_0 == Enum964.const_0)
						{
							return 1;
						}
					}
					else if (enum964_0 == Enum964.const_1)
					{
						return 3;
					}
				}
				else if (enum964_0 == Enum964.const_0)
				{
					return 1;
				}
			}
			else if (enum964_0 == Enum964.const_1)
			{
				return 3;
			}
		}
		if (enum964_0 != Enum964.const_1)
		{
			return 3;
		}
		return 1;
	}
}
