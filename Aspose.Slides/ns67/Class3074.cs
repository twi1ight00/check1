using System;
using System.Collections.Generic;
using System.Drawing;

namespace ns67;

internal class Class3074 : Class3073
{
	private readonly Class3448 class3448_0;

	private readonly Class3450 class3450_0;

	private readonly Class3406 class3406_0;

	private List<Class3069> list_1;

	private List<Class3071> list_2;

	public Class3074(Class3450 textBody, Class3448 transform, Class3406 defaultProperties)
	{
		if (textBody.PredefinedPathCoordinates == null || textBody.PredefinedPaths == null)
		{
			throw new ArgumentException("TextBody must contain predefined paths and coordinates");
		}
		class3450_0 = textBody;
		class3448_0 = transform;
		class3406_0 = defaultProperties;
		list_1 = new List<Class3069>();
		list_2 = new List<Class3071>();
		method_6();
	}

	public Class3069[] method_3()
	{
		return list_1.ToArray();
	}

	public Class3071[] method_4()
	{
		return list_2.ToArray();
	}

	private Struct160 method_5(RectangleF[] bounds)
	{
		if (bounds.Length == 0)
		{
			return default(Struct160);
		}
		double num = double.MaxValue;
		double num2 = double.MinValue;
		double num3 = double.MaxValue;
		double num4 = double.MinValue;
		for (int i = 0; i < bounds.Length; i++)
		{
			RectangleF rectangleF = bounds[i];
			num = Math.Min(num, rectangleF.Left);
			num2 = Math.Max(num2, rectangleF.Right);
			num3 = Math.Min(num3, rectangleF.Top);
			num4 = Math.Max(num4, rectangleF.Bottom);
		}
		return new Struct160(num, num3, num2, num4);
	}

	private void method_6()
	{
		RectangleF[] predefinedPathCoordinates = class3450_0.PredefinedPathCoordinates;
		Class3062[] predefinedPaths = class3450_0.PredefinedPaths;
		int num = 0;
		double num2 = 4.0;
		if (class3450_0.Properties.TextWarp is Class3290 || class3450_0.Properties.TextWarp is Class3281)
		{
			Struct160 @struct = method_5(predefinedPathCoordinates);
			double val = class3448_0.Extents.Cx / @struct.Width;
			double val2 = class3448_0.Extents.Cy / @struct.Height;
			num2 = Math.Min(num2, 2.0 * Math.Max(val, val2));
		}
		Class3451[] paragraphs = class3450_0.Paragraphs;
		foreach (Class3451 @class in paragraphs)
		{
			Class3423[] textRuns = @class.TextRuns;
			foreach (Class3423 class2 in textRuns)
			{
				if (class2 is Class3424 class3)
				{
					for (int k = 0; k < class3.TextString.Length; k++)
					{
						Class3062 class4 = predefinedPaths[num];
						RectangleF rectangleF = predefinedPathCoordinates[num];
						class4.method_15(num2, num2, append: false);
						class4.method_12();
						class4.method_13();
						class4.method_15(1.0 / num2, 1.0 / num2, append: false);
						class4.method_12();
						Class3069 class5 = new Class3069(Class3070.smethod_0(class4), class2.RunProperties);
						list_1.Add(class5);
						list_2.Add(new Class3071(class5, new Struct160(rectangleF.Left, rectangleF.Top, rectangleF.Right, rectangleF.Bottom)));
						num++;
					}
				}
			}
		}
	}

	public override Class3455 vmethod_0()
	{
		return class3448_0.Extents;
	}
}
