namespace ns322;

internal sealed class Class7428 : Class7399, Interface402
{
	private bool bool_2;

	public override object Value => bool_2;

	public override string Type => "boolean";

	public override string _Class => "Boolean";

	public override bool vmethod_2()
	{
		return bool_2;
	}

	public override string ToString()
	{
		if (!bool_2)
		{
			return "false";
		}
		return "true";
	}

	public static double smethod_0(bool value)
	{
		return value ? 1 : 0;
	}

	public override double vmethod_3()
	{
		return smethod_0(bool_2);
	}

	public Class7428(bool value, Class7399 prototype)
		: base(prototype)
	{
		bool_2 = value;
	}
}
