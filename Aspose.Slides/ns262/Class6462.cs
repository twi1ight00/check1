using System;
using System.Collections.Generic;
using ns253;

namespace ns262;

internal class Class6462 : Interface306
{
	private readonly Interface304 interface304_0;

	private List<Interface305> list_0;

	public Class6462(Interface304 serviceLocator)
	{
		interface304_0 = serviceLocator;
	}

	public List<Interface305> imethod_0(Class6434 paragraph)
	{
		list_0 = new List<Interface305>();
		foreach (Interface298 element in paragraph.Elements)
		{
			if (element is Class6438 run)
			{
				method_0(run);
			}
		}
		return list_0;
	}

	private void method_0(Class6438 run)
	{
		Class6459 @class = null;
		if (list_0.Count > 0)
		{
			@class = (Class6459)list_0[list_0.Count - 1];
		}
		Interface310 @interface = interface304_0.imethod_4();
		@interface.imethod_0(run);
		foreach (Interface301 runPart in @interface.RunParts)
		{
			if (smethod_0(runPart, @class))
			{
				@class = method_1(runPart);
			}
			@class.method_0(runPart);
		}
	}

	private static bool smethod_0(Interface301 runPart, Class6459 currentSpan)
	{
		if (currentSpan == null)
		{
			return true;
		}
		if (currentSpan.Type == Enum835.const_0 && runPart.TokenType != 0)
		{
			return true;
		}
		if (currentSpan.Type == Enum835.const_1 && runPart.TokenType != Enum836.const_1)
		{
			return true;
		}
		return false;
	}

	private Class6459 method_1(Interface301 runPart)
	{
		Class6459 @class = runPart.TokenType switch
		{
			Enum836.const_0 => new Class6461(interface304_0), 
			Enum836.const_1 => new Class6460(interface304_0), 
			Enum836.const_2 => new Class6460(interface304_0), 
			_ => throw new ArgumentOutOfRangeException(), 
		};
		list_0.Add(@class);
		return @class;
	}
}
