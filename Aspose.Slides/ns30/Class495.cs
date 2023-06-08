using System.Collections;
using System.Collections.Generic;

namespace ns30;

internal class Class495
{
	internal class Class496
	{
		public string string_0;

		public IDictionary idictionary_0;

		public Class496(string name, IDictionary attributes)
		{
			string_0 = name;
			idictionary_0 = attributes;
		}
	}

	internal class Class497
	{
		private readonly IDictionary[] idictionary_0;

		public string this[string key]
		{
			get
			{
				int num = 0;
				object obj;
				while (true)
				{
					if (num < idictionary_0.Length)
					{
						obj = idictionary_0[num][key];
						if (obj != null)
						{
							break;
						}
						num++;
						continue;
					}
					return null;
				}
				return (string)obj;
			}
		}

		public Class497(IDictionary[] dictionaries)
		{
			idictionary_0 = dictionaries;
		}

		internal bool Contains(string key)
		{
			int num = 0;
			while (true)
			{
				if (num < idictionary_0.Length)
				{
					if (idictionary_0[num].Contains(key))
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

	private static readonly IDictionary[] idictionary_0 = new IDictionary[0];

	public Class497 method_0(List<Class496> openedElementsStack, ArrayList previousElements)
	{
		Class496 @class = openedElementsStack[openedElementsStack.Count - 1];
		string text = (string)@class.idictionary_0["style"];
		if (text == null)
		{
			return new Class497(idictionary_0);
		}
		return new Class497(new IDictionary[1] { smethod_0(text) });
	}

	private static Hashtable smethod_0(string style)
	{
		Hashtable hashtable = new Hashtable(CaseInsensitiveHashCodeProvider.DefaultInvariant, CaseInsensitiveComparer.DefaultInvariant);
		string[] array = style.Split(';');
		foreach (string text in array)
		{
			string text2 = text.Trim();
			if (!string.IsNullOrEmpty(text2))
			{
				int num = text2.IndexOf(':');
				if (num > 0)
				{
					hashtable.Add(text2.Substring(0, num).Trim(), text2.Substring(num + 1).Trim());
				}
			}
		}
		return hashtable;
	}
}
