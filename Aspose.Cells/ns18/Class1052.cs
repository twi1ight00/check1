using System.Collections;
using ns22;

namespace ns18;

internal class Class1052 : IEnumerable
{
	private Class1030 class1030_0;

	private ArrayList arrayList_0 = new ArrayList();

	private readonly IDictionary idictionary_0;

	public Class1051 this[string string_0] => (Class1051)idictionary_0[string_0];

	public Class1052(Class1030 class1030_1)
	{
		class1030_0 = class1030_1;
		idictionary_0 = Class1177.smethod_0();
	}

	public void Add(Class1051 class1051_0)
	{
		class1051_0.method_1().Position = 0L;
		class1030_0.method_0(smethod_0(class1051_0.Name), class1051_0.method_1());
		class1051_0.method_1().Close();
		class1051_0.method_2(null);
		idictionary_0.Add(class1051_0.Name, class1051_0);
	}

	public void method_0(Class1051 class1051_0)
	{
		class1051_0.method_1().Position = 0L;
		arrayList_0.Add(class1051_0);
		idictionary_0.Add(class1051_0.Name, class1051_0);
	}

	public void Close()
	{
		foreach (Class1051 item in arrayList_0)
		{
			item.method_1().Position = 0L;
			class1030_0.method_0(smethod_0(item.Name), item.method_1());
			item.method_1().Close();
			item.method_2(null);
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return idictionary_0.Values.GetEnumerator();
	}

	private static string smethod_0(string string_0)
	{
		return string_0.TrimStart('/');
	}
}
