using System.Diagnostics;
using ns305;
using ns76;

namespace ns81;

[DebuggerDisplay("{SelectorText}")]
internal abstract class Class4051 : Interface83
{
	public const short short_0 = 0;

	public const short short_1 = 1;

	public const short short_2 = 2;

	public const short short_3 = 3;

	public const short short_4 = 4;

	public const short short_5 = 5;

	public const short short_6 = 6;

	public const short short_7 = 7;

	public const short short_8 = 8;

	public const short short_9 = 9;

	public const short short_10 = 10;

	public const short short_11 = 11;

	public const short short_12 = 12;

	public const short short_13 = 13;

	private Class3707 class3707_0;

	public abstract int SelectorType { get; }

	public abstract string SelectorText { get; }

	public abstract int Specificity { get; }

	protected Class3707 Rule => class3707_0;

	public abstract bool imethod_0(Class6981 e, string pseudoElement);

	public virtual void vmethod_0(Class3707 rule)
	{
		class3707_0 = rule;
	}

	public virtual bool vmethod_1()
	{
		return false;
	}
}
