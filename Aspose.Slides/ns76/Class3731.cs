using ns73;

namespace ns76;

internal class Class3731
{
	public static Class3731 Instance => new Class3731();

	public Interface59 method_0(short rule, Class3735 styleSheet, Interface59 parentRule)
	{
		return rule switch
		{
			0 => new Class3715(styleSheet, parentRule), 
			1 => new Class3714(styleSheet, parentRule), 
			2 => new Class3708(styleSheet, parentRule), 
			3 => new Class3711(styleSheet, parentRule), 
			4 => new Class3712(styleSheet, parentRule), 
			5 => new Class3710(styleSheet, parentRule), 
			6 => new Class3713(styleSheet, parentRule), 
			11 => new Class3709(styleSheet, parentRule), 
			_ => null, 
		};
	}

	public Interface74 method_1(Class3735 styleSheet, Interface59 parentRule)
	{
		return new Class3714(styleSheet, parentRule);
	}
}
