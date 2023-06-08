using ns84;

namespace ns92;

internal class Class4268 : Class4262
{
	private int int_0;

	public Class4268(Class4260 style)
		: base(style)
	{
		int_0 = base.CounterStyle.Glyphs.Count;
	}

	public override string vmethod_0(int value)
	{
		if (int_0 == 0)
		{
			return string.Empty;
		}
		value %= int_0;
		value = ((value != 0) ? (value - 1) : (int_0 - 1));
		return base.CounterStyle.Glyphs[value];
	}
}
