namespace ns46;

internal class Class1115
{
	private class Class1116
	{
		public readonly string string_0;

		public readonly string string_1;

		public Class1116(string first, string second)
		{
			string_0 = first;
			string_1 = second;
		}
	}

	private Class1116[] class1116_0 = new Class1116[8];

	private Class1116[] class1116_1 = new Class1116[8];

	private string[] string_0 = new string[8];

	private int int_0;

	private int int_1;

	private int int_2;

	public bool bool_0;

	public int int_3;

	public string string_1;

	public string string_2;

	public int int_4;

	public int int_5;

	public int NamespacesCount => int_0;

	public int PreserveContentCount => int_1;

	public int IgnorableCount => int_2;

	public Class1115(string namespacePrefix, string localName)
	{
		string_1 = namespacePrefix;
		string_2 = localName;
	}

	public Class1115(string namespacePrefix, string localName, int startPosition, int endPosition)
	{
		string_1 = namespacePrefix;
		string_2 = localName;
		int_4 = startPosition;
		int_5 = endPosition;
	}

	public void method_0(string prefix, string namespaceUri)
	{
		if (int_0 >= class1116_0.Length)
		{
			Class1116[] array = new Class1116[class1116_0.Length + class1116_0.Length / 2 + 8];
			for (int i = 0; i < class1116_0.Length; i++)
			{
				array[i] = class1116_0[i];
			}
			class1116_0 = array;
		}
		class1116_0[int_0++] = new Class1116(prefix, namespaceUri);
	}

	public void method_1(string namespaceUri, string localName)
	{
		if (int_1 >= class1116_1.Length)
		{
			Class1116[] array = new Class1116[class1116_1.Length + class1116_1.Length / 2 + 8];
			for (int i = 0; i < class1116_1.Length; i++)
			{
				array[i] = class1116_1[i];
			}
			class1116_1 = array;
		}
		if (localName == "*")
		{
			localName = null;
		}
		class1116_1[int_1++] = new Class1116(namespaceUri, localName);
	}

	public void method_2(string namespaceUri)
	{
		if (int_2 >= string_0.Length)
		{
			string[] array = new string[string_0.Length + string_0.Length / 2 + 8];
			for (int i = 0; i < class1116_0.Length; i++)
			{
				array[i] = string_0[i];
			}
			string_0 = array;
		}
		string_0[int_2++] = namespaceUri;
	}

	public string method_3(string prefix)
	{
		int num = 0;
		while (true)
		{
			if (num < int_0)
			{
				if (class1116_0[num].string_0 == prefix)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return class1116_0[num].string_1;
	}

	public bool method_4(string namespaceUri)
	{
		int num = 0;
		while (true)
		{
			if (num < int_2)
			{
				if (string.Compare(namespaceUri, string_0[num], ignoreCase: true) == 0)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	public bool method_5(string namespaceUri, string localName)
	{
		int num = 0;
		while (true)
		{
			if (num < int_1)
			{
				if (string.Compare(namespaceUri, class1116_1[num].string_0, ignoreCase: true) == 0 && (class1116_1[num].string_1 == null || class1116_1[num].string_1 == localName))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}
}
