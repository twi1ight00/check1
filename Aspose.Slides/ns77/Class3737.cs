using System.Diagnostics;
using ns73;

namespace ns77;

[DebuggerDisplay("{Text}")]
internal abstract class Class3737 : Interface80
{
	public abstract string Text { get; }

	public abstract bool imethod_0(Class3677 device);

	public Class3737 method_0()
	{
		return new Class3768(this);
	}

	public Class3737 method_1(Interface80 expression)
	{
		return new Class3738(this, expression);
	}
}
