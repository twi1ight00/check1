using System.Text;
using ns84;

namespace ns92;

internal class Class4263 : Class4262
{
	public Class4263(Class4260 style)
		: base(style)
	{
	}

	public override string vmethod_0(int value)
	{
		if (value <= 0)
		{
			return base.CounterStyle.FallbackConverter.vmethod_0(value);
		}
		StringBuilder stringBuilder = new StringBuilder();
		int count = base.CounterStyle.Glyphs.Count;
		while (value != 0)
		{
			value--;
			int index = value % count;
			stringBuilder.Insert(0, base.CounterStyle.Glyphs[index]);
			value /= count;
		}
		return stringBuilder.ToString();
	}
}
