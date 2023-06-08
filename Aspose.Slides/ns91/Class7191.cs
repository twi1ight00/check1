using System.Collections;

namespace ns91;

internal class Class7191
{
	internal Hashtable hashtable_0 = new Hashtable();

	internal void method_0(string style)
	{
		string[] array = style.Split('}');
		string[] array2 = array;
		foreach (string text in array2)
		{
			string[] array3 = text.Split('{');
			if (array3.Length > 1 && !hashtable_0.ContainsKey(array3[0].Trim()))
			{
				hashtable_0.Add(array3[0].Trim(), array3[1].Trim());
			}
		}
	}

	internal string method_1(string classId)
	{
		foreach (DictionaryEntry item in hashtable_0)
		{
			string text = item.Key.ToString();
			if (text.StartsWith(".") && classId == text.Remove(0, 1))
			{
				return item.Value.ToString();
			}
		}
		return string.Empty;
	}
}
