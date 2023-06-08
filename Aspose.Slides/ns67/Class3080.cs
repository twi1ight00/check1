using ns99;

namespace ns67;

internal sealed class Class3080 : Class3073
{
	private readonly double double_0;

	private string string_0;

	private double double_1;

	private Interface113 interface113_0;

	private Class3449 class3449_0;

	private readonly Class3406 class3406_0;

	public Class3406 Properties => class3406_0;

	public Class3080(Class3406 properties, Class3455 textBodyExtents)
	{
		class3406_0 = properties.method_0();
		method_8();
		method_7();
		double_1 = 0.0;
		double_0 = (Properties.FontSize - interface113_0.Metrics.imethod_4(Properties.FontSize)) * Class3072.smethod_0();
		string_0 = string.Empty;
	}

	public void method_3()
	{
		double num = 0.0;
		for (int i = 0; i < string_0.Length; i++)
		{
			char c = string_0[i];
			if (i > 0)
			{
				char ch = string_0[i - 1];
				double num2 = method_9(ch, c);
				num += num2;
			}
			Class3084 @class = new Class3084(c, Properties, interface113_0);
			@class.Point = new Class3456(num, 0.0);
			method_1(@class);
			num += @class.vmethod_0().Cx;
		}
	}

	public override Class3455 vmethod_0()
	{
		return new Class3455(double_1, double_0);
	}

	public string method_4()
	{
		return string_0;
	}

	public void method_5(char ch)
	{
		if (string_0.Length > 0)
		{
			char ch2 = string_0[string_0.Length - 1];
			double num = method_9(ch2, ch);
			double_1 += num;
		}
		Class3084 @class = new Class3084(ch, Properties, interface113_0);
		double cx = @class.vmethod_0().Cx;
		double_1 += cx + Properties.Spacing;
		string_0 += ch;
	}

	public char method_6()
	{
		char c = string_0[string_0.Length - 1];
		if (string_0.Length > 1)
		{
			char ch = string_0[string_0.Length - 2];
			double num = method_9(ch, c);
			double_1 -= num;
		}
		Class3084 @class = new Class3084(c, Properties, interface113_0);
		double cx = @class.vmethod_0().Cx;
		double_1 -= cx;
		string_0 = string_0.Substring(0, string_0.Length - 1);
		return c;
	}

	private void method_7()
	{
		interface113_0 = Class3086.Instance.method_4(class3449_0.Typeface, Properties.Bold, Properties.Italics);
	}

	private void method_8()
	{
		class3449_0 = Properties.LatinFont;
	}

	private double method_9(char ch1, char ch2)
	{
		Class4506 prevGlyphId = interface113_0.Encoding.imethod_2(ch1);
		Class4506 nextGlyphId = interface113_0.Encoding.imethod_2(ch2);
		double num = interface113_0.Metrics.imethod_0(prevGlyphId, nextGlyphId);
		return num * Properties.FontSize / (double)interface113_0.Metrics.UnitsPerEM * Class3072.smethod_0();
	}
}
