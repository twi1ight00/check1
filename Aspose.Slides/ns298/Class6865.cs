using System.Collections;

namespace ns298;

internal class Class6865
{
	private string string_0;

	private static readonly Hashtable hashtable_0;

	internal string Name => string_0;

	static Class6865()
	{
		hashtable_0 = new Hashtable();
		smethod_0("Align", Enum929.const_0);
		smethod_0("Alt", Enum929.const_1);
		smethod_0("Background", Enum929.const_2);
		smethod_0("Bgcolor", Enum929.const_3);
		smethod_0("Border", Enum929.const_4);
		smethod_0("Bordercolor", Enum929.const_5);
		smethod_0("Cellpadding", Enum929.const_6);
		smethod_0("Cellspacing", Enum929.const_7);
		smethod_0("Checked", Enum929.const_8);
		smethod_0("Class", Enum929.const_9);
		smethod_0("Color", Enum929.const_10);
		smethod_0("Cols", Enum929.const_11);
		smethod_0("Colspan", Enum929.const_12);
		smethod_0("Disabled", Enum929.const_13);
		smethod_0("Height", Enum929.const_14);
		smethod_0("Href", Enum929.const_15);
		smethod_0("Id", Enum929.const_16);
		smethod_0("Face", Enum929.const_17);
		smethod_0("Language", Enum929.const_18);
		smethod_0("Maxlength", Enum929.const_19);
		smethod_0("Multiple", Enum929.const_20);
		smethod_0("Name", Enum929.const_21);
		smethod_0("Nowrap", Enum929.const_22);
		smethod_0("Readonly", Enum929.const_23);
		smethod_0("Rows", Enum929.const_24);
		smethod_0("Rowspan", Enum929.const_25);
		smethod_0("Rel", Enum929.const_26);
		smethod_0("Selected", Enum929.const_27);
		smethod_0("Size", Enum929.const_28);
		smethod_0("Src", Enum929.const_29);
		smethod_0("Style", Enum929.const_30);
		smethod_0("Tabindex", Enum929.const_31);
		smethod_0("Target", Enum929.const_32);
		smethod_0("Title", Enum929.const_33);
		smethod_0("Type", Enum929.const_34);
		smethod_0("Valign", Enum929.const_35);
		smethod_0("Value", Enum929.const_36);
		smethod_0("Width", Enum929.const_37);
		smethod_0("charset", Enum929.const_38);
		smethod_0("http-equiv", Enum929.const_39);
		smethod_0("content", Enum929.const_40);
		smethod_0("data", Enum929.const_41);
		smethod_0("dir", Enum929.const_42);
	}

	public Class6865(Enum929 attribute)
	{
		string_0 = smethod_1(attribute);
	}

	private static void smethod_0(string name, Enum929 key)
	{
		lock (hashtable_0)
		{
			hashtable_0.Add(key, name);
		}
	}

	private static string smethod_1(Enum929 attribute)
	{
		lock (hashtable_0)
		{
			return (string)hashtable_0[attribute];
		}
	}
}
