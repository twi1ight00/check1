using System.Collections.Generic;
using ns305;
using ns307;

namespace ns308;

internal class Class7067 : Interface370
{
	private readonly IList<string> ilist_0;

	private readonly IList<KeyValuePair<string, string>> ilist_1;

	private readonly bool bool_0;

	private readonly bool bool_1;

	public Class7067(IEnumerable<string> name, string asterisk)
	{
		ilist_0 = new List<string>(name);
		ilist_1 = null;
		bool_0 = ilist_0.Contains(asterisk);
	}

	public Class7067(IEnumerable<KeyValuePair<string, string>> nameAndNs, string asterisk)
	{
		ilist_0 = null;
		ilist_1 = new List<KeyValuePair<string, string>>(nameAndNs);
		bool_1 = ilist_1.Contains(new KeyValuePair<string, string>(asterisk, asterisk));
	}

	public Class7067(string name, string asterisk)
		: this(new List<string>(), asterisk)
	{
		ilist_0.Add(name);
		bool_0 = name == asterisk;
	}

	public Class7067(string namespaceUri, string localName, string asterisk)
		: this(new List<KeyValuePair<string, string>>(), asterisk)
	{
		ilist_1.Add(new KeyValuePair<string, string>(namespaceUri, localName));
		bool_1 = localName == asterisk && namespaceUri == asterisk;
	}

	public virtual short imethod_0(Class6976 n)
	{
		if (ilist_0 != null)
		{
			if (bool_0 || ilist_0.Contains(n.NodeName))
			{
				return 1;
			}
		}
		else
		{
			KeyValuePair<string, string> item = new KeyValuePair<string, string>(n.NamespaceURI, n.LocalName);
			if (bool_1 || ilist_1.Contains(item))
			{
				return 1;
			}
		}
		return 3;
	}
}
