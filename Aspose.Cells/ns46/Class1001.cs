using System.Collections;

namespace ns46;

internal class Class1001 : Class999
{
	internal ArrayList arrayList_1 = new ArrayList();

	internal Class1001(string string_1)
	{
		string_0 = string_1;
	}

	internal override void vmethod_1(ref string string_1)
	{
		string_1 = string_1 + "<" + string_0;
		foreach (Class998 item in arrayList_1)
		{
			string text = string_1;
			string_1 = text + " " + item.string_0 + "=\"" + item.string_1 + "\"";
		}
		string_1 += "/>";
	}

	internal override void vmethod_0(Class1008 class1008_0)
	{
		class1008_0.string_0 = class1008_0.string_0 + "<" + string_0;
		foreach (Class998 item in arrayList_1)
		{
			string text = class1008_0.string_0;
			class1008_0.string_0 = text + " " + item.string_0 + "=\"" + item.string_1 + "\"";
		}
		class1008_0.string_0 += "/>";
	}
}
