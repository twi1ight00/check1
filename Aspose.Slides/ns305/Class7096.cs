namespace ns305;

internal class Class7096
{
	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	internal Class7046 class7046_0;

	public string LocalName => string_0;

	public string Name
	{
		get
		{
			if (string_1 == null)
			{
				if (string_3.Length > 0)
				{
					if (string_0.Length > 0)
					{
						string array = string_3 + ":" + string_0;
						lock (class7046_0.NameTable)
						{
							if (string_1 == null)
							{
								string_1 = class7046_0.NameTable.Add(array);
							}
							return string_1;
						}
					}
					string_1 = string_3;
				}
				else
				{
					string_1 = string_0;
				}
			}
			return string_1;
		}
	}

	public string NamespaceURI
	{
		get
		{
			if (string_2 == null)
			{
				string_2 = OwnerDocument.method_10(Prefix);
			}
			return string_2;
		}
	}

	public Class7046 OwnerDocument => class7046_0;

	public string Prefix
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	internal Class7096(string prefix, string localName, string ns, Class7046 ownerDoc)
	{
		string_3 = prefix;
		string_0 = localName;
		string_2 = ns;
		class7046_0 = ownerDoc;
	}

	public bool method_0()
	{
		if (string.IsNullOrEmpty(Prefix))
		{
			return true;
		}
		if (!string.IsNullOrEmpty(OwnerDocument.NamespaceManager.LookupNamespace(Prefix)) && (class7046_0.Implementation.imethod_1("xhtml", string.Empty) || class7046_0.method_9(NamespaceURI)))
		{
			return true;
		}
		string_1 = (string_0 = $"{string_3}:{string_0}");
		string_3 = string.Empty;
		string_2 = null;
		return false;
	}
}
