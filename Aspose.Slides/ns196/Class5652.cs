using System;
using ns183;

namespace ns196;

internal class Class5652 : Interface208
{
	private Interface208 interface208_0;

	private object object_0;

	private Interface173 interface173_0;

	private bool bool_0;

	public Class5652(Interface208 parentIter)
	{
		interface208_0 = parentIter;
		method_1();
	}

	public Interface173 method_0()
	{
		if (interface173_0 == null && object_0 != null)
		{
			interface173_0 = vmethod_0(object_0);
			bool_0 = true;
		}
		return interface173_0;
	}

	protected virtual Interface173 vmethod_0(object nextObJ)
	{
		return vmethod_1(nextObJ).method_0();
	}

	protected virtual Class5254 vmethod_1(object nextObJ)
	{
		if (!(nextObJ is Class5254))
		{
			throw new ArgumentException("Cannot obtain Position from the given object.");
		}
		return (Class5254)nextObJ;
	}

	private void method_1()
	{
		if (interface208_0.imethod_0())
		{
			bool_0 = true;
			object_0 = interface208_0.imethod_1();
		}
		else
		{
			method_2();
		}
	}

	protected virtual bool vmethod_2()
	{
		Interface173 @interface = vmethod_0(object_0);
		if (interface173_0 == null)
		{
			interface173_0 = @interface;
		}
		else if (interface173_0 != @interface && @interface != null)
		{
			bool_0 = false;
			interface173_0 = null;
			return false;
		}
		return true;
	}

	protected void method_2()
	{
		bool_0 = false;
		object_0 = null;
		interface173_0 = null;
	}

	public bool imethod_0()
	{
		if (bool_0)
		{
			return vmethod_2();
		}
		return false;
	}

	public virtual object imethod_1()
	{
		if (!bool_0)
		{
			throw new InvalidOperationException("PosIter");
		}
		Class5254 result = vmethod_1(object_0);
		method_1();
		return result;
	}

	public object method_3()
	{
		return object_0;
	}

	public void imethod_6()
	{
		throw new NotSupportedException("PositionIterator doesn't support remove");
	}
}
