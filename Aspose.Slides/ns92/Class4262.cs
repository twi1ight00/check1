using System;
using ns84;

namespace ns92;

internal abstract class Class4262
{
	private Class4260 class4260_0;

	protected Class4260 CounterStyle => class4260_0;

	protected Class4262(Class4260 style)
	{
		class4260_0 = style;
	}

	public abstract string vmethod_0(int value);

	public static Class4262 smethod_0(Class4260 style)
	{
		return style.Type switch
		{
			Class4260.Enum500.const_0 => new Class4268(style), 
			Class4260.Enum500.const_1 => new Class4267(style), 
			Class4260.Enum500.const_2 => new Class4263(style), 
			Class4260.Enum500.const_3 => new Class4266(style), 
			Class4260.Enum500.const_4 => new Class4264(style), 
			Class4260.Enum500.const_5 => new Class4265(style), 
			_ => throw new NotSupportedException(), 
		};
	}
}
