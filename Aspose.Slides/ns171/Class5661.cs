using System;
using ns183;

namespace ns171;

internal class Class5661 : Class5656
{
	private Class5088 class5088_0;

	private Interface208 interface208_0;

	private Class5088 class5088_1;

	private Class5656 class5656_0;

	public Class5661(Class5094 fobj)
	{
		class5088_0 = fobj;
		interface208_0 = (Interface208)fobj.vmethod_15();
		method_2();
	}

	public Class5661(Class5094 fobj, Class5088 child)
	{
		class5088_0 = fobj;
		interface208_0 = (Interface208)fobj.vmethod_16(child);
		method_2();
	}

	public Class5656 method_0()
	{
		return (Class5656)method_1();
	}

	public object method_1()
	{
		Class5661 @class = (Class5661)Clone();
		@class.interface208_0 = (Interface208)class5088_0.vmethod_16(@class.class5088_1);
		@class.interface208_0.imethod_1();
		@class.class5656_0 = (Class5656)class5656_0.Clone();
		return @class;
	}

	public override void vmethod_1(char c)
	{
		if (class5656_0 != null)
		{
			class5656_0.vmethod_1(c);
		}
	}

	private void method_2()
	{
		if (interface208_0 != null && interface208_0.imethod_0())
		{
			class5088_1 = (Class5088)interface208_0.imethod_1();
			class5656_0 = class5088_1.vmethod_17();
		}
		else
		{
			class5088_1 = null;
			class5656_0 = null;
		}
	}

	public override bool imethod_0()
	{
		while (true)
		{
			if (class5656_0 != null)
			{
				if (class5656_0.imethod_0())
				{
					break;
				}
				method_2();
				continue;
			}
			return false;
		}
		return true;
	}

	public override char vmethod_0()
	{
		if (class5656_0 == null)
		{
			throw new NotSupportedException();
		}
		return class5656_0.vmethod_0();
	}

	public override void imethod_6()
	{
		if (class5656_0 != null)
		{
			class5656_0.imethod_6();
		}
	}
}
