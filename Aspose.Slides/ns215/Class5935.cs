using System.Collections;
using ns216;

namespace ns215;

internal class Class5935
{
	internal const string string_0 = "_unique_prefix_";

	private Hashtable hashtable_0 = new Hashtable();

	internal Class5935(Class5848 subform)
	{
	}

	internal void AddField(Class5817 field)
	{
		if (!string.IsNullOrEmpty(field.Name))
		{
			hashtable_0[field.Name] = field;
		}
		else
		{
			hashtable_0["_unique_prefix_" + hashtable_0.Count] = hashtable_0;
		}
	}

	internal void method_0(Class5809 field)
	{
		if (!string.IsNullOrEmpty(field.Name))
		{
			hashtable_0[field.Name] = field;
		}
		else
		{
			hashtable_0["_unique_prefix_" + hashtable_0.Count] = hashtable_0;
		}
	}
}
