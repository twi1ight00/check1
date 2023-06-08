using System;
using ns140;
using ns141;
using ns99;

namespace ns67;

internal sealed class Class3084 : Class3072
{
	private readonly char char_0;

	private float float_0;

	private Interface113 interface113_0;

	private readonly Class3406 class3406_0;

	public Class3406 Properties => class3406_0;

	public Class3084(char ch, Class3406 properties, Interface113 font)
	{
		char_0 = ch;
		float_0 = 0.001f;
		class3406_0 = properties;
		interface113_0 = font;
	}

	public override Class3455 vmethod_0()
	{
		Class4506 glyphId = interface113_0.Encoding.imethod_2(char_0);
		double cy = (Properties.FontSize - interface113_0.Metrics.imethod_4(Properties.FontSize)) * Class3072.smethod_0();
		double num = interface113_0.Metrics.imethod_1(glyphId);
		double cx = num * Properties.FontSize / (double)interface113_0.Metrics.UnitsPerEM * Class3072.smethod_0();
		return new Class3455(cx, cy);
	}

	public Class3062 method_0()
	{
		Class3062 @class = new Class3062();
		try
		{
			if (char.IsWhiteSpace(char_0))
			{
				return @class;
			}
			Class3088 painter = new Class3088(@class);
			Interface144 @interface = new Class4620(painter);
			double fontSize = Properties.FontSize;
			Class4509 glyphPlacementMatrix = new Class4509(new double[6]
			{
				fontSize,
				0.0,
				0.0,
				0.0 - fontSize,
				0.0,
				0.0
			});
			@interface.imethod_3(interface113_0, interface113_0.Encoding.imethod_2(char_0), glyphPlacementMatrix);
			float num = (float)Class3072.smethod_0();
			@class.method_2();
			@class.method_15(num * 4f, num * 4f, append: false);
			@class.method_12();
			@class.method_13();
			@class.method_15(0.25, 0.25, append: false);
			@class.method_14(base.Point.X, base.Point.Y, append: false);
			@class.method_12();
			return @class;
		}
		catch (Exception)
		{
			@class.Dispose();
			throw;
		}
	}
}
