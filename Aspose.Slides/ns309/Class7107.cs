using System.Collections;

namespace ns309;

internal class Class7107
{
	public static ArrayList arrayList_0 = new ArrayList(new string[3] { "Arial", "Times", "Courier" });

	public Hashtable hashtable_0 = new Hashtable();

	internal float float_0;

	public float float_1;

	internal float float_2;

	internal float float_3;

	public Class7107()
	{
		foreach (string item in arrayList_0)
		{
			hashtable_0.Add(item, new Hashtable());
		}
	}
}
