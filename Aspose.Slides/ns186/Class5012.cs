using System.Text;
using ns176;
using ns187;
using ns190;

namespace ns186;

internal class Class5012 : Class5003
{
	private class Class5385 : Interface180
	{
		public int imethod_2(Interface172 context)
		{
			return 0;
		}

		public double imethod_1()
		{
			return 255.0;
		}

		public int imethod_0()
		{
			return 0;
		}
	}

	public override int imethod_0()
	{
		return 5;
	}

	public override Interface180 imethod_1()
	{
		return new Class5385();
	}

	public override Class5024 imethod_2(Class5024[] args, Class5750 pInfo)
	{
		string text = args[3].vmethod_13();
		string value = args[4].vmethod_13();
		Class5167 @class = ((pInfo.method_2() != null) ? pInfo.method_2().vmethod_20().method_59() : null);
		Class5166 class2 = null;
		if (@class != null)
		{
			class2 = @class.method_49(text);
		}
		if (class2 == null)
		{
			Exception55 exception = new Exception55("The " + text + " color profile was not declared");
			exception.method_5(pInfo);
			throw exception;
		}
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		num = (float)args[0].vmethod_9();
		num2 = (float)args[1].vmethod_9();
		num3 = (float)args[2].vmethod_9();
		if (num < 0f || num > 255f || num2 < 0f || num2 > 255f || num3 < 0f || num3 > 255f)
		{
			throw new Exception55("sRGB color values out of range. Arguments to rgb-named-color() must be [0..255] or [0%..100%]");
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("fop-rgb-named-color(");
		stringBuilder.Append(num / 255f);
		stringBuilder.Append(',').Append(num2 / 255f);
		stringBuilder.Append(',').Append(num3 / 255f);
		stringBuilder.Append(',').Append(text);
		stringBuilder.Append(',').Append(class2.method_49());
		stringBuilder.Append(", '").Append(value).Append('\'');
		stringBuilder.Append(")");
		return Class5040.smethod_0(pInfo.method_7(), stringBuilder.ToString());
	}
}
