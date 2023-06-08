using System.Collections;

namespace ns18;

internal class Class1055
{
	private Class1055()
	{
	}

	public static void Write(Class1049 class1049_0, bool bool_0)
	{
		smethod_0(class1049_0, class1049_0.method_2(), "", bool_0);
		ArrayList arrayList = new ArrayList();
		foreach (Class1051 item in (IEnumerable)class1049_0.method_0())
		{
			if (item.method_3().Count > 0)
			{
				arrayList.Add(item);
			}
		}
		foreach (Class1051 item2 in arrayList)
		{
			smethod_0(class1049_0, item2.method_3(), item2.Name, bool_0);
		}
	}

	private static void smethod_0(Class1049 class1049_0, Class1054 class1054_0, string string_0, bool bool_0)
	{
		int num = string_0.LastIndexOf('/');
		string text = string_0.Substring(0, num + 1);
		string arg = string_0.Substring(num + 1);
		string string_ = string.Format("{0}{1}_rels/{2}.rels", text.StartsWith("/") ? "" : "/", text, arg);
		Class1051 @class = new Class1051(string_, "application/vnd.openxmlformats-package.relationships+xml");
		Class1009 class2 = new Class1009(@class.method_1(), bool_0);
		class2.method_1("Relationships");
		class2.method_9("xmlns", "http://schemas.openxmlformats.org/package/2006/relationships");
		foreach (Class1053 item in (IEnumerable)class1054_0)
		{
			class2.method_3("Relationship");
			class2.method_9("Id", item.method_0());
			class2.method_9("Type", item.Type);
			class2.method_9("Target", item.method_1());
			if (item.method_2())
			{
				class2.method_9("TargetMode", "External");
			}
			class2.method_4();
		}
		class2.method_2();
		class1049_0.method_0().Add(@class);
	}
}
