using System;
using ns180;

namespace ns184;

internal class Class5600 : Interface218
{
	private Interface207 interface207_0;

	private Interface205 interface205_0;

	public Class5600(Interface207 broadcaster)
	{
		interface207_0 = broadcaster;
	}

	private Interface205 method_0()
	{
		if (interface205_0 == null)
		{
			interface205_0 = Class5483.smethod_0(interface207_0);
		}
		return interface205_0;
	}

	public void imethod_0(object source, Class5732 requested, Class5732 effective)
	{
		method_0().imethod_0(source, requested, effective);
	}

	public void imethod_1(object source, string fontURL, Exception e)
	{
		method_0().imethod_1(source, fontURL, e);
	}

	public void imethod_2(object source, char ch, string fontName)
	{
		method_0().imethod_2(source, ch, fontName);
	}

	public void imethod_3(object source, string dir)
	{
		method_0().imethod_3(source, dir);
	}

	public void imethod_4(object source, string fontFamily)
	{
		method_0().imethod_4(source, fontFamily);
	}
}
