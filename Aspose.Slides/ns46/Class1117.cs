namespace ns46;

internal class Class1117
{
	private Class1115[] class1115_0 = new Class1115[64];

	private int int_0;

	public int Count => int_0;

	public void method_0(Class1115 element)
	{
		if (int_0 >= class1115_0.Length)
		{
			Class1115[] array = new Class1115[class1115_0.Length + class1115_0.Length / 2 + 8];
			for (int i = 0; i < class1115_0.Length; i++)
			{
				array[i] = class1115_0[i];
			}
			class1115_0 = array;
		}
		class1115_0[int_0++] = element;
	}

	public void method_1()
	{
		int_0--;
	}

	public Class1115 Peek()
	{
		return class1115_0[int_0 - 1];
	}

	public Class1115 Peek(int index)
	{
		return class1115_0[int_0 - 1 - index];
	}

	public void Clear()
	{
		int_0 = 0;
	}

	public string method_2(string prefix)
	{
		int num = int_0 - 1;
		string text;
		while (true)
		{
			if (num >= 0)
			{
				text = class1115_0[num].method_3(prefix);
				if (text != null)
				{
					break;
				}
				num--;
				continue;
			}
			return null;
		}
		return text;
	}

	public bool method_3(string prefix)
	{
		string text = method_2(prefix);
		int num = 0;
		while (true)
		{
			if (num < Class1120.list_0.Count)
			{
				if (string.Compare(text, Class1120.list_0[num], ignoreCase: true) == 0)
				{
					break;
				}
				num++;
				continue;
			}
			if (string.Compare(text, "http://schemas.openxmlformats.org/markup-compatibility/2006", ignoreCase: true) == 0)
			{
				return true;
			}
			for (int num2 = int_0 - 1; num2 >= 0; num2--)
			{
				for (int i = 0; i < class1115_0[num2].IgnorableCount; i++)
				{
					if (class1115_0[num2].method_4(text))
					{
						return true;
					}
				}
			}
			return false;
		}
		return false;
	}

	public bool method_4(string prefix)
	{
		string text = method_2(prefix);
		if (string.Compare(text, "http://schemas.openxmlformats.org/markup-compatibility/2006", ignoreCase: true) == 0)
		{
			return true;
		}
		for (int num = int_0 - 1; num >= 0; num--)
		{
			for (int i = 0; i < class1115_0[num].IgnorableCount; i++)
			{
				if (class1115_0[num].method_4(text))
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool method_5(string prefix, string localName)
	{
		string text = method_2(prefix);
		for (int num = int_0 - 1; num >= 0; num--)
		{
			for (int i = 0; i < class1115_0[num].IgnorableCount; i++)
			{
				if (class1115_0[num].method_5(text, localName))
				{
					return true;
				}
			}
		}
		if (text == "http://schemas.openxmlformats.org/markup-compatibility/2006")
		{
			if (!(localName == "AlternateContent") && !(localName == "Choice"))
			{
				return localName == "Fallback";
			}
			return true;
		}
		return false;
	}

	public bool method_6(string prefix)
	{
		string strA = method_2(prefix);
		int num = 0;
		while (true)
		{
			if (num < Class1120.list_0.Count)
			{
				if (string.Compare(strA, Class1120.list_0[num], ignoreCase: true) == 0)
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
