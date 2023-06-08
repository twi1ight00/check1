using System.Collections;
using System.Collections.Generic;
using ns218;

namespace ns247;

internal static class Class6264
{
	public static void Write(Class6254 package, bool isPrettyFormat)
	{
		smethod_0(package, package.Rels, string.Empty, isPrettyFormat);
		List<Class6260> list = new List<Class6260>();
		foreach (Class6260 item in (IEnumerable)package.Parts)
		{
			if (item.Rels.Count > 0)
			{
				list.Add(item);
			}
		}
		foreach (Class6260 item2 in list)
		{
			smethod_0(package, item2.Rels, item2.Name, isPrettyFormat);
		}
	}

	private static void smethod_0(Class6254 package, Class6263 rels, string uri, bool isPrettyFormat)
	{
		int num = uri.LastIndexOf('/');
		string text = uri.Substring(0, num + 1);
		string arg = uri.Substring(num + 1);
		string partName = string.Format("{0}{1}_rels/{2}.rels", text.StartsWith("/") ? string.Empty : "/", text, arg);
		Class6260 @class = new Class6260(partName, "application/vnd.openxmlformats-package.relationships+xml");
		Class5946 class2 = new Class5946(@class.Stream, isPrettyFormat);
		class2.method_0("Relationships");
		class2.method_14("xmlns", "http://schemas.openxmlformats.org/package/2006/relationships");
		foreach (Class6262 item in (IEnumerable)rels)
		{
			class2.method_2("Relationship");
			class2.method_14("Id", item.Id);
			class2.method_14("Type", item.Type);
			class2.method_14("Target", item.Target);
			if (item.IsExternal)
			{
				class2.method_14("TargetMode", "External");
			}
			class2.method_3();
		}
		class2.method_1();
		package.Parts.Add(@class);
	}
}
