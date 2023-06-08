namespace ns17;

internal class Class1085 : Class1080
{
	public Class1085(Class1087 class1087_1)
	{
		class1087_0 = class1087_1;
	}

	public override Enum170 vmethod_0(ref string string_0)
	{
		if (string_0.Length == 0)
		{
			return Enum170.const_1;
		}
		switch (string_0[0])
		{
		default:
			class1087_0.class1080_6 = class1087_0.class1080_1;
			break;
		case '&':
			class1087_0.class1080_6 = class1087_0.class1080_5;
			break;
		case '\n':
		case '\r':
			class1087_0.class1080_6 = class1087_0.class1080_2;
			break;
		}
		return Enum170.const_0;
	}
}
