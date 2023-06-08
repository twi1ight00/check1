using System.Collections;

namespace ns46;

internal class Class1003 : Class999
{
	public string string_1;

	internal ArrayList arrayList_1 = new ArrayList();

	internal Class1003(string string_2, string string_3)
	{
		string_0 = string_2;
		if (string_3 != null && string_3.Length != 0)
		{
			string_1 = string_3;
		}
		else
		{
			string_1 = "";
		}
	}

	internal override void vmethod_1(ref string string_2)
	{
		string_2 = string_2 + "<" + string_0;
		foreach (Class998 item in arrayList_1)
		{
			string text = string_2;
			string_2 = text + " " + item.string_0 + "=\"" + item.string_1 + "\"";
		}
		string_2 += ">";
		foreach (Class999 item2 in arrayList_0)
		{
			item2.vmethod_1(ref string_2);
		}
		string text2 = string_2;
		string_2 = text2 + string_1 + "</" + string_0 + ">";
	}

	internal override void vmethod_0(Class1008 class1008_0)
	{
		class1008_0.string_0 = class1008_0.string_0 + "<" + string_0;
		foreach (Class998 item in arrayList_1)
		{
			string text = class1008_0.string_0;
			class1008_0.string_0 = text + " " + item.string_0 + "=\"" + item.string_1 + "\"";
		}
		class1008_0.string_0 += ">";
		foreach (Class999 item2 in arrayList_0)
		{
			item2.vmethod_0(class1008_0);
		}
		string text2 = class1008_0.string_0;
		class1008_0.string_0 = text2 + string_1 + "</" + string_0 + ">";
	}
}
