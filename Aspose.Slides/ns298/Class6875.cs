using System.Collections;

namespace ns298;

internal class Class6875
{
	private readonly Enum931 enum931_0;

	private readonly string string_0;

	private static readonly Hashtable hashtable_0;

	public Enum931 Tag => enum931_0;

	public string Name => string_0;

	static Class6875()
	{
		hashtable_0 = new Hashtable();
		smethod_0("Body", Enum931.const_1);
		smethod_0("I", Enum931.const_2);
		smethod_0("Font", Enum931.const_3);
		smethod_0("Head", Enum931.const_4);
		smethod_0("Html", Enum931.const_5);
		smethod_0("P", Enum931.const_6);
		smethod_0("B", Enum931.const_7);
		smethod_0("Br", Enum931.const_8);
		smethod_0("Link", Enum931.const_9);
		smethod_0("Img", Enum931.const_10);
		smethod_0("Span", Enum931.const_11);
		smethod_0("Script", Enum931.const_12);
		smethod_0("Style", Enum931.const_13);
		smethod_0("Title", Enum931.const_14);
		smethod_0("Table", Enum931.const_15);
		smethod_0("Sub", Enum931.const_16);
		smethod_0("Sup", Enum931.const_17);
		smethod_0("Td", Enum931.const_18);
		smethod_0("Tr", Enum931.const_19);
		smethod_0("Ul", Enum931.const_20);
		smethod_0("Li", Enum931.const_21);
		smethod_0("Ol", Enum931.const_22);
		smethod_0("Div", Enum931.const_23);
		smethod_0("Meta", Enum931.const_24);
		smethod_0("Embed", Enum931.const_25);
		smethod_0("Object", Enum931.const_26);
		smethod_0("A", Enum931.const_0);
	}

	public Class6875(Enum931 tag)
	{
		enum931_0 = tag;
		string_0 = smethod_1(tag);
	}

	private static void smethod_0(string name, Enum931 key)
	{
		lock (hashtable_0)
		{
			hashtable_0.Add(key, name);
		}
	}

	private static string smethod_1(Enum931 attribute)
	{
		lock (hashtable_0)
		{
			return (string)hashtable_0[attribute];
		}
	}
}
