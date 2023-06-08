using System.Collections.Generic;
using System.Text;
using ns84;

namespace ns92;

internal class Class4264 : Class4262
{
	public Class4264(Class4260 style)
		: base(style)
	{
	}

	public override string vmethod_0(int value)
	{
		if (value < 0)
		{
			return base.CounterStyle.FallbackConverter.vmethod_0(value);
		}
		base.CounterStyle.AdditiveGlyphs.Sort(smethod_1);
		if (value == 0)
		{
			if (base.CounterStyle.AdditiveGlyphs[base.CounterStyle.AdditiveGlyphs.Count - 1].Weight == 0)
			{
				return base.CounterStyle.AdditiveGlyphs[base.CounterStyle.AdditiveGlyphs.Count - 1].Glyph;
			}
			return base.CounterStyle.FallbackConverter.vmethod_0(value);
		}
		StringBuilder stringBuilder = new StringBuilder();
		IEnumerator<Class4260.Class4261> enumerator = base.CounterStyle.AdditiveGlyphs.GetEnumerator();
		int num = value;
		while (num > 0 && enumerator.MoveNext())
		{
			int num2 = num / enumerator.Current.Weight;
			if (num2 <= 3)
			{
				while (num2 > 0)
				{
					stringBuilder.Append(enumerator.Current.Glyph);
					num -= enumerator.Current.Weight;
					num2--;
				}
				continue;
			}
			return base.CounterStyle.FallbackConverter.vmethod_0(value);
		}
		return stringBuilder.ToString();
	}

	private static int smethod_1(Class4260.Class4261 x, Class4260.Class4261 y)
	{
		return x.Weight.CompareTo(y.Weight) * -1;
	}
}
