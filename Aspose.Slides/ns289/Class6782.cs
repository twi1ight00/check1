using System.Drawing;
using ns235;

namespace ns289;

internal class Class6782
{
	private const string string_0 = "pc";

	private const string string_1 = "pt";

	private const string string_2 = "mm";

	private const string string_3 = "cm";

	private const string string_4 = "in";

	private const string string_5 = "mpt";

	private const string string_6 = "px";

	private float float_0 = 96f;

	private float float_1;

	private float float_2;

	public Class6782(Class6779 options)
	{
		float_1 = method_0(options.PageSize.Width).Value;
		float_1 -= method_0(options.Margin.Left).Value;
		float_2 = method_0(options.Margin.Left).Value;
	}

	private Class6785 method_0(Class6785 value)
	{
		int num = smethod_0(value.Value, Class6785.smethod_0(value.Unit), 72f / float_0);
		return new Class6785((float)num / 1000f, Enum920.const_4);
	}

	private static int smethod_0(double dvalue, string unit, float res)
	{
		if ("px".Equals(unit))
		{
			dvalue *= (double)(res * 1000f);
		}
		else if ("in".Equals(unit))
		{
			dvalue *= 72000.0;
		}
		else if ("cm".Equals(unit))
		{
			dvalue *= 28346.4567;
		}
		else if ("mm".Equals(unit))
		{
			dvalue *= 2834.64567;
		}
		else if ("pt".Equals(unit))
		{
			dvalue *= 1000.0;
		}
		else if ("pc".Equals(unit))
		{
			dvalue *= 12000.0;
		}
		else if (!"mpt".Equals(unit))
		{
			dvalue = 0.0;
		}
		return (int)dvalue;
	}

	public Class6216[] method_1(Class6216[] pages)
	{
		for (int i = 0; i < pages.Length; i++)
		{
			Class6216 @class = pages[i];
			Class6216 class2 = new Class6216(@class.Size, @class.PaperTray);
			Class6213 class3 = new Class6213();
			class3.Clip = Class6217.smethod_1(new RectangleF(float_2 - 1f, 0f, float_1 + 2f, @class.Height));
			for (int j = 0; j < @class.Count; j++)
			{
				class3.Add(@class[j]);
			}
			class2.Add(class3);
			pages[i] = class2;
		}
		return pages;
	}
}
