using System;
using ns100;
using ns101;
using ns102;
using ns119;

namespace ns99;

internal abstract class Class4417
{
	public abstract Class4408 vmethod_0(Class4490 fontDefinition);

	public static Class4417 smethod_0(Enum639 fontType)
	{
		return fontType switch
		{
			Enum639.const_1 => new Class4420(), 
			Enum639.const_0 => new Class4419(), 
			Enum639.const_2 => new Class4418(), 
			_ => throw new NotSupportedException(), 
		};
	}
}
