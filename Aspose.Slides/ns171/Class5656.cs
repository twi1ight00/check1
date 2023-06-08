using System;
using ns183;

namespace ns171;

internal abstract class Class5656 : ICloneable, Interface208
{
	public abstract bool imethod_0();

	public abstract char vmethod_0();

	public object imethod_1()
	{
		return vmethod_0();
	}

	public virtual void imethod_6()
	{
		throw new NotSupportedException();
	}

	public virtual void vmethod_1(char c)
	{
	}

	public object Clone()
	{
		return MemberwiseClone();
	}
}
