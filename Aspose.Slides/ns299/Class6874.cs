using System.Collections;

namespace ns299;

internal class Class6874
{
	private static Hashtable hashtable_0;

	private static Hashtable LookupTable
	{
		get
		{
			if (hashtable_0 == null)
			{
				hashtable_0 = new Hashtable(43);
				smethod_0("background-color", Enum930.const_0);
				smethod_0("background-image", Enum930.const_1);
				smethod_0("border-collapse", Enum930.const_2);
				smethod_0("border-color", Enum930.const_3);
				smethod_0("border-style", Enum930.const_4);
				smethod_0("border-width", Enum930.const_5);
				smethod_0("border-top", Enum930.const_6);
				smethod_0("border-right", Enum930.const_7);
				smethod_0("border-bottom", Enum930.const_8);
				smethod_0("border-left", Enum930.const_9);
				smethod_0("color", Enum930.const_10);
				smethod_0("cursor", Enum930.const_20);
				smethod_0("direction", Enum930.const_21);
				smethod_0("display", Enum930.const_22);
				smethod_0("filter", Enum930.const_23);
				smethod_0("font-family", Enum930.const_11);
				smethod_0("font-size", Enum930.const_12);
				smethod_0("font-style", Enum930.const_13);
				smethod_0("font-variant", Enum930.const_24);
				smethod_0("font-weight", Enum930.const_14);
				smethod_0("height", Enum930.const_15);
				smethod_0("left", Enum930.const_25);
				smethod_0("line-height", Enum930.const_26);
				smethod_0("list-style-image", Enum930.const_18);
				smethod_0("list-style-type", Enum930.const_19);
				smethod_0("margin", Enum930.const_27);
				smethod_0("margin-bottom", Enum930.const_28);
				smethod_0("margin-left", Enum930.const_29);
				smethod_0("margin-right", Enum930.const_30);
				smethod_0("margin-top", Enum930.const_31);
				smethod_0("max-width", Enum930.const_32);
				smethod_0("overflow-x", Enum930.const_34);
				smethod_0("overflow-y", Enum930.const_35);
				smethod_0("overflow", Enum930.const_33);
				smethod_0("padding", Enum930.const_36);
				smethod_0("padding-bottom", Enum930.const_37);
				smethod_0("padding-left", Enum930.const_38);
				smethod_0("padding-right", Enum930.const_39);
				smethod_0("padding-top", Enum930.const_40);
				smethod_0("position", Enum930.const_41);
				smethod_0("text-align", Enum930.const_42);
				smethod_0("text-decoration", Enum930.const_16);
				smethod_0("text-overflow", Enum930.const_44);
				smethod_0("top", Enum930.const_45);
				smethod_0("vertical-align", Enum930.const_43);
				smethod_0("visibility", Enum930.const_46);
				smethod_0("width", Enum930.const_17);
				smethod_0("white-space", Enum930.const_47);
				smethod_0("z-index", Enum930.const_48);
				smethod_0("word-spacing", Enum930.const_49);
				smethod_0("letter-spacing", Enum930.const_50);
			}
			return hashtable_0;
		}
	}

	private Class6874()
	{
	}

	private static void smethod_0(string name, Enum930 key)
	{
		LookupTable.Add(key, name);
	}

	public static string smethod_1(Enum930 styleKey)
	{
		return (string)LookupTable[styleKey];
	}
}
