using System.Collections;

namespace ns19;

internal class Class877
{
	private int int_0;

	internal string[] string_0;

	private Hashtable hashtable_0;

	public int this[string string_1] => (int)hashtable_0[string_1];

	public string this[int int_1] => string_0[int_1 - int_0];

	public Class877(string[] string_1)
		: this(0, string_1)
	{
	}

	public Class877(int int_1, string[] string_1)
	{
		int_0 = int_1;
		string_0 = string_1;
		hashtable_0 = new Hashtable(string_1.Length);
		for (int i = 0; i < string_1.Length; i++)
		{
			hashtable_0.Add(string_1[i], i + int_1);
		}
	}
}
