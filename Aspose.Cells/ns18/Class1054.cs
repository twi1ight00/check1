using System.Collections;

namespace ns18;

internal class Class1054 : IEnumerable
{
	private readonly string string_0;

	private readonly Class1016 class1016_0;

	private readonly Class1016 class1016_1;

	private int int_0 = 1;

	public int Count => class1016_0.Count;

	public Class1054(string string_1)
	{
		string_0 = string_1;
		class1016_0 = new Class1016(bool_0: true);
		class1016_1 = new Class1016(bool_0: false);
	}

	public string Add(string string_1, string string_2, bool bool_0)
	{
		if (bool_0)
		{
			if (Class1399.smethod_1(string_2))
			{
				string_2 = "file:///" + string_2;
				string_2 = Class1399.smethod_7(string_2);
			}
		}
		else
		{
			string_2 = Class1049.smethod_0(string_0, string_2);
		}
		Class1053 @class = (Class1053)class1016_1[string_2];
		if (@class != null)
		{
			return @class.method_0();
		}
		string text = $"rId{int_0}";
		int_0++;
		Add(text, string_1, string_2, bool_0);
		return text;
	}

	public void Add(string string_1, string string_2, string string_3, bool bool_0)
	{
		Class1053 value = new Class1053(string_1, string_2, string_3, bool_0);
		class1016_0[string_1] = value;
		class1016_1[string_3] = value;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return class1016_0.GetValueList().GetEnumerator();
	}
}
