using System.Text;
using ns84;

namespace ns92;

internal class Class4266 : Class4262
{
	public Class4266(Class4260 style)
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
		int index = value % count;
		int num = (value - 1) / count;
		do
		{
			stringBuilder.Append(base.CounterStyle.Glyphs[index]);
			num--;
		}
		while (num >= 0);
		return stringBuilder.ToString();
	}
}
