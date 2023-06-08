namespace ns17;

internal class Class1084 : Class1080
{
	public Class1084(Class1087 class1087_1)
	{
		class1087_0 = class1087_1;
	}

	public override Enum170 vmethod_0(ref string string_0)
	{
		string_0 = string_0.Substring(1);
		if (class1087_0.string_0.Length == 0)
		{
			class1087_0.string_0 = " ";
		}
		class1087_0.method_5();
		class1087_0.method_3();
		if (string_0.Length < 1)
		{
			class1087_0.string_0 = " ";
			class1087_0.method_5();
		}
		class1087_0.class1080_6 = class1087_0.class1080_0;
		return Enum170.const_0;
	}
}
