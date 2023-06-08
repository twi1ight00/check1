using System;

namespace ns40;

[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
internal class Attribute0 : Attribute
{
	public readonly bool bool_0;

	public Attribute0(bool isThrows)
	{
		bool_0 = isThrows;
	}
}
