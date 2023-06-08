namespace ns17;

internal class Class1086 : Class1080
{
	public Class1086(Class1087 class1087_1)
	{
		class1087_0 = class1087_1;
	}

	public override Enum170 vmethod_0(ref string string_0)
	{
		for (int i = 0; i < string_0.Length; i++)
		{
			switch (string_0[i])
			{
			case '&':
				class1087_0.method_5();
				class1087_0.class1080_6 = class1087_0.class1080_0;
				string_0 = string_0.Substring(i);
				return Enum170.const_0;
			case '\n':
			case '\r':
				class1087_0.method_5();
				class1087_0.class1080_6 = class1087_0.class1080_0;
				string_0 = string_0.Substring(i);
				return Enum170.const_0;
			}
			class1087_0.string_0 += string_0[i];
			if ((string_0[i] == '-' || string_0[i] == ' ') && !(Class1625.smethod_20(class1087_0.string_0, class1087_0.font_0, class1087_0.double_0).Width <= class1087_0.float_2))
			{
				class1087_0.method_5();
				class1087_0.class1080_6 = class1087_0.class1080_0;
				string_0 = "\n" + string_0.Substring(i + 1);
				return Enum170.const_0;
			}
		}
		class1087_0.method_5();
		string_0 = "";
		return Enum170.const_0;
	}
}
