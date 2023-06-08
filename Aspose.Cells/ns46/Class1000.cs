namespace ns46;

internal class Class1000 : Class999
{
	internal string string_1 = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";

	internal Class1000(string string_2)
	{
		string_1 = string_2;
	}

	internal Class1000()
	{
	}

	internal override void vmethod_0(Class1008 class1008_0)
	{
		class1008_0.string_0 = string_1;
		foreach (Class999 item in arrayList_0)
		{
			item.vmethod_0(class1008_0);
		}
	}

	internal override void vmethod_1(ref string string_2)
	{
		string_2 += string_1;
		foreach (Class999 item in arrayList_0)
		{
			item.vmethod_1(ref string_2);
		}
	}
}
