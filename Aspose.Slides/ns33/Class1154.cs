using System.Collections;

namespace ns33;

internal sealed class Class1154 : IComparer
{
	private readonly IComparer icomparer_0;

	public static readonly Class1154 class1154_0 = new Class1154(Comparer.Default);

	public static readonly Class1154 class1154_1 = new Class1154(Comparer.DefaultInvariant);

	private Class1154(IComparer baseComparer)
	{
		icomparer_0 = baseComparer;
	}

	public int Compare(object a, object b)
	{
		DictionaryEntry dictionaryEntry = (DictionaryEntry)a;
		DictionaryEntry dictionaryEntry2 = (DictionaryEntry)b;
		return icomparer_0.Compare(dictionaryEntry.Key, dictionaryEntry2.Key);
	}
}
