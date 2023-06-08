using System;
using System.Collections;
using ns218;

namespace ns271;

internal class Class6724
{
	private readonly Hashtable hashtable_0 = new Hashtable();

	private readonly Hashtable hashtable_1 = new Hashtable();

	private readonly Hashtable hashtable_2 = new Hashtable();

	private readonly Hashtable hashtable_3 = new Hashtable();

	public void Add(Enum896 nameId, int languageId, string name)
	{
		if (Class5964.smethod_20(name))
		{
			Hashtable hashtable = method_5(nameId);
			if (hashtable != null)
			{
				hashtable[languageId] = name;
			}
		}
	}

	public string method_0(Enum896 nameId)
	{
		string text = method_1(nameId);
		if (text == null)
		{
			throw new InvalidOperationException("Requested a name string that is not present in the font.");
		}
		return text;
	}

	public string method_1(Enum896 nameId)
	{
		Hashtable hashtable = method_5(nameId);
		if (hashtable == null)
		{
			return null;
		}
		if (hashtable.Count <= 0)
		{
			return null;
		}
		string text = (string)hashtable[1033];
		if (text == null)
		{
			text = (string)smethod_0(hashtable);
		}
		return text;
	}

	public string method_2(Enum896 nameId, int languageId)
	{
		Hashtable hashtable = method_5(nameId);
		if (hashtable == null)
		{
			return null;
		}
		if (hashtable.Count <= 0)
		{
			return null;
		}
		return hashtable[languageId] as string;
	}

	public string[] method_3(Enum896 nameId)
	{
		Hashtable hashtable = method_5(nameId);
		if (hashtable == null)
		{
			return null;
		}
		string[] array = new string[hashtable.Count];
		int num = 0;
		foreach (string value in hashtable.Values)
		{
			array[num] = value;
			num++;
		}
		return array;
	}

	internal Class6723[] method_4()
	{
		Hashtable hashtable = method_5(Enum896.const_4);
		Hashtable hashtable2 = method_5(Enum896.const_1);
		if (hashtable.Count != 0 && hashtable2.Count != 0)
		{
			Class6723[] array = new Class6723[hashtable.Count];
			int num = 0;
			{
				foreach (DictionaryEntry item in hashtable)
				{
					string text = (string)hashtable2[item.Key];
					if (text == null)
					{
						text = (string)hashtable2[1033];
					}
					if (text == null)
					{
						text = (string)smethod_0(hashtable2);
					}
					array[num++] = new Class6723(text, (string)item.Value);
				}
				return array;
			}
		}
		return null;
	}

	private Hashtable method_5(Enum896 nameId)
	{
		return nameId switch
		{
			Enum896.const_1 => hashtable_0, 
			Enum896.const_2 => hashtable_1, 
			Enum896.const_4 => hashtable_2, 
			Enum896.const_6 => hashtable_3, 
			_ => null, 
		};
	}

	private static object smethod_0(Hashtable table)
	{
		IEnumerator enumerator = table.Values.GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				return enumerator.Current;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return null;
	}
}
