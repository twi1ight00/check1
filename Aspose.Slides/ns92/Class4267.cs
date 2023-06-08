using System.Text;
using ns84;

namespace ns92;

internal class Class4267 : Class4262
{
	public Class4267(Class4260 style)
		: base(style)
	{
	}

	public override string vmethod_0(int value)
	{
		if (value == 0)
		{
			return base.CounterStyle.Glyphs[0];
		}
		bool flag = false;
		if (value < 0)
		{
			flag = true;
			value *= -1;
		}
		StringBuilder stringBuilder = new StringBuilder();
		int count = base.CounterStyle.Glyphs.Count;
		while (value != 0)
		{
			int index = value % count;
			stringBuilder.Insert(0, base.CounterStyle.Glyphs[index]);
			value /= count;
		}
		if (flag)
		{
			stringBuilder.Insert(0, "-");
		}
		return stringBuilder.ToString();
	}
}
