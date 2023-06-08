using System.Text;
using ns284;
using ns73;
using ns84;

namespace ns296;

internal class Class6807 : Class6806
{
	private Class4347 class4347_0;

	public Class6807(Class6983 element, Class4347 model)
		: base(element)
	{
		class4347_0 = model;
	}

	public override string vmethod_0()
	{
		Enum615 line = class4347_0.TextDecoration.Line;
		if (line == Enum615.flag_0)
		{
			return "none";
		}
		StringBuilder stringBuilder = new StringBuilder();
		if ((Enum615.flag_4 & line) == Enum615.flag_4)
		{
			stringBuilder.Append(Class4342.smethod_2(Enum615.flag_4));
		}
		if ((Enum615.flag_3 & line) == Enum615.flag_3)
		{
			if (stringBuilder.Length != 0)
			{
				stringBuilder.Append(" ");
			}
			stringBuilder.Append(Class4342.smethod_2(Enum615.flag_3));
		}
		if ((Enum615.flag_2 & line) == Enum615.flag_2)
		{
			if (stringBuilder.Length != 0)
			{
				stringBuilder.Append(" ");
			}
			stringBuilder.Append(Class4342.smethod_2(Enum615.flag_2));
		}
		if ((Enum615.flag_1 & line) == Enum615.flag_1)
		{
			if (stringBuilder.Length != 0)
			{
				stringBuilder.Append(" ");
			}
			stringBuilder.Append(Class4342.smethod_2(Enum615.flag_1));
		}
		return stringBuilder.ToString();
	}
}
