using System;
using System.Collections.Generic;
using ns253;

namespace ns262;

internal class Class6466 : Interface310
{
	private List<Interface301> list_0 = new List<Interface301>();

	private Interface304 interface304_0;

	private Class6470 class6470_0 = new Class6470();

	public List<Interface301> RunParts => list_0;

	public Class6466(Interface304 serviceLocator)
	{
		interface304_0 = serviceLocator;
	}

	public void imethod_0(Class6438 run)
	{
		list_0.Clear();
		class6470_0.method_0(run.Text);
		while (class6470_0.MoveNext())
		{
			Interface301 item = method_0(run);
			list_0.Add(item);
		}
	}

	public Interface301 method_0(Class6438 run)
	{
		switch (class6470_0.TokenType)
		{
		default:
			throw new ArgumentOutOfRangeException();
		case Enum836.const_0:
		case Enum836.const_1:
			return new Class6454(interface304_0, run, class6470_0);
		case Enum836.const_2:
			return new Class6453(interface304_0, run, class6470_0);
		}
	}
}
