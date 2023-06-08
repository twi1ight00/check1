using System.Collections;

namespace ns99;

internal abstract class Class4496
{
	protected const int int_0 = 0;

	public const string string_0 = ".notdef";

	private Hashtable hashtable_0;

	private Hashtable hashtable_1;

	public Class4496()
	{
		hashtable_0 = new Hashtable();
		hashtable_1 = new Hashtable();
	}

	public virtual int vmethod_0(string glyphName)
	{
		if (hashtable_0.ContainsKey(glyphName))
		{
			return ((int[])hashtable_0[glyphName])[0];
		}
		return 0;
	}

	public virtual int[] vmethod_1(string glyphName)
	{
		if (hashtable_0.ContainsKey(glyphName))
		{
			return (int[])hashtable_0[glyphName];
		}
		return new int[1];
	}

	public virtual string vmethod_2(int unicodeValue)
	{
		if (hashtable_1.ContainsKey(unicodeValue))
		{
			return (string)((ArrayList)hashtable_1[unicodeValue])[0];
		}
		return ".notdef";
	}

	public virtual string[] vmethod_3(int unicodeValue)
	{
		if (hashtable_1.ContainsKey(unicodeValue))
		{
			return (string[])((ArrayList)hashtable_1[unicodeValue]).ToArray(typeof(string));
		}
		return new string[1] { ".notdef" };
	}

	internal void method_0(string glyphName, params int[] unicodeValues)
	{
		hashtable_0[glyphName] = unicodeValues;
		foreach (int num in unicodeValues)
		{
			if (!hashtable_1.ContainsKey(num))
			{
				hashtable_1.Add(num, new ArrayList());
			}
			((ArrayList)hashtable_1[num]).Add(glyphName);
		}
	}

	internal int[] method_1()
	{
		ArrayList arrayList = new ArrayList();
		foreach (int key in hashtable_1.Keys)
		{
			arrayList.Add(key);
		}
		return (int[])arrayList.ToArray(typeof(int));
	}
}
