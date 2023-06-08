using ns84;

namespace ns92;

internal class Class4265 : Class4262
{
	public Class4265(Class4260 style)
		: base(style)
	{
	}

	public override string vmethod_0(int value)
	{
		if (value >= base.CounterStyle.FirstGlyphValue && value < base.CounterStyle.Glyphs.Count + base.CounterStyle.FirstGlyphValue)
		{
			return base.CounterStyle.Glyphs[value - base.CounterStyle.FirstGlyphValue];
		}
		return base.CounterStyle.FallbackConverter.vmethod_0(value);
	}
}
