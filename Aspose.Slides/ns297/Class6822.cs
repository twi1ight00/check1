using System.Xml;

namespace ns297;

internal class Class6822
{
	private string string_0;

	private string string_1;

	private string string_2;

	public string LocalName => string_0;

	public string Name
	{
		get
		{
			if (string.IsNullOrEmpty(Prefix))
			{
				return string_0;
			}
			return $"{string_1}:{string_0}";
		}
	}

	public string Prefix => string_1;

	public string NamespaceUri => string_2;

	public Class6822(string name, XmlNamespaceManager namespaceManager)
	{
		int num = name.IndexOf(':');
		if (num == -1)
		{
			string_0 = name;
			string_2 = namespaceManager.DefaultNamespace;
			return;
		}
		string prefix = name.Substring(0, num);
		string value = namespaceManager.LookupNamespace(prefix);
		if (!string.IsNullOrEmpty(value))
		{
			string_1 = prefix;
			string_2 = value;
		}
		else
		{
			string_2 = namespaceManager.DefaultNamespace;
		}
		string_0 = name.Substring(num + 1);
	}
}
