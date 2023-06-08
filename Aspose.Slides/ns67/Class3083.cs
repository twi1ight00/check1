using System;
using System.Collections;

namespace ns67;

internal sealed class Class3083 : Class3073
{
	private Class3081 class3081_0;

	private Class3082 class3082_0;

	private double double_0;

	private double double_1;

	private readonly Class3406 class3406_0;

	private double double_2;

	private Hashtable hashtable_0;

	private readonly Class3448 class3448_0;

	private readonly Class3450 class3450_0;

	public Class3083(Class3450 textBody, Class3448 transform, Class3406 defaultProperties)
	{
		class3450_0 = textBody;
		class3448_0 = transform;
		class3406_0 = defaultProperties;
		double_0 = 0.0;
		double_1 = 0.0;
		double_2 = 0.0;
		hashtable_0 = new Hashtable();
		for (int i = 0; i < 9; i++)
		{
			hashtable_0.Add(i, 0);
		}
		method_7();
	}

	public override Class3455 vmethod_0()
	{
		return class3448_0.Extents;
	}

	public double method_3()
	{
		return double_2;
	}

	private void AddField(Class3425 field)
	{
		if (field.RunProperties.FontSize > double_2)
		{
			double_2 = field.RunProperties.FontSize;
		}
		throw new NotImplementedException();
	}

	private void method_4()
	{
		class3082_0.method_4(class3081_0);
		class3081_0 = class3082_0.method_3();
	}

	private void method_5(Class3426 lineBreak)
	{
		if (lineBreak.RunProperties.FontSize > double_2)
		{
			double_2 = lineBreak.RunProperties.FontSize;
		}
		Class3406 runProperties = lineBreak.RunProperties;
		Class3080 subbuilder = new Class3080(runProperties, class3448_0.Extents);
		class3081_0.method_3(subbuilder);
		method_4();
	}

	private void method_6(Class3424 regularTextRun, Class3455 extents)
	{
		Class3406 runProperties = regularTextRun.RunProperties;
		Class3080 @class = new Class3080(runProperties, class3448_0.Extents);
		if (regularTextRun.RunProperties.FontSize > double_2)
		{
			double_2 = regularTextRun.RunProperties.FontSize;
		}
		for (int i = 0; i < regularTextRun.TextString.Length; i++)
		{
			char ch = regularTextRun.TextString[i];
			@class.method_5(ch);
			double num = class3081_0.vmethod_0().Cx + @class.vmethod_0().Cx;
			if (num > extents.Cx)
			{
				if (class3081_0.method_0().Length != 0 && @class.method_4().Length > 1)
				{
					@class.method_6();
				}
				class3081_0.method_3(@class);
				method_4();
				@class = new Class3080(runProperties, class3448_0.Extents);
			}
		}
		class3081_0.method_3(@class);
	}

	private void method_7()
	{
		Class3455 extents = class3448_0.Extents;
		Class3451[] paragraphs = class3450_0.Paragraphs;
		foreach (Class3451 @class in paragraphs)
		{
			class3082_0 = new Class3082(@class.Properties, class3406_0);
			class3082_0.Point = new Class3456(double_0, double_1);
			class3081_0 = class3082_0.method_3();
			if (@class.Properties.TextBullet != null)
			{
				Class3406 runProperties = @class.TextRuns[0].RunProperties;
				Class3401 bullet = method_8(@class);
				Class3075 bulletBuilder = Class3087.Instance.method_0(bullet, @class.Properties.TextBulletColor, @class.Properties.TextBulletSize, @class.Properties.TextBulletTypeface, runProperties, class3448_0.Extents);
				class3081_0.BulletBuilder = bulletBuilder;
			}
			Class3423[] textRuns = @class.TextRuns;
			foreach (Class3423 class2 in textRuns)
			{
				if (class2 is Class3424 regularTextRun)
				{
					method_6(regularTextRun, extents);
				}
				else if (class2 is Class3426 lineBreak)
				{
					method_5(lineBreak);
				}
				else if (class2 is Class3425 field)
				{
					AddField(field);
				}
			}
			method_4();
			method_1(class3082_0);
			double_1 += class3082_0.vmethod_0().Cy;
		}
	}

	private Class3401 method_8(Class3451 paragraph)
	{
		if (paragraph.Properties.TextBullet == null)
		{
			return null;
		}
		if (paragraph.Properties.TextBullet is Class3402 @class)
		{
			int value = method_9(paragraph);
			return new Class3402(new Class3375(value), @class.BulletAutonumberingType);
		}
		return paragraph.Properties.TextBullet.vmethod_0();
	}

	private int method_9(Class3451 paragraph)
	{
		int result = 0;
		if (paragraph.Properties.TextBullet is Class3402 @class)
		{
			int num = 0;
			if (paragraph.Properties.Level != null)
			{
				num = paragraph.Properties.Level.Value;
			}
			if (@class.StartNumberingAt != null)
			{
				hashtable_0[num] = @class.StartNumberingAt.Value;
			}
			else
			{
				hashtable_0[num] = (int)hashtable_0[num] + 1;
			}
			result = (int)hashtable_0[num];
			for (int i = num + 1; i < 9; i++)
			{
				hashtable_0[i] = 0;
			}
		}
		return result;
	}

	private Class3390 method_10(Class3390 currentProperties)
	{
		Class3390 @class = currentProperties.method_0();
		if (@class.Level != null)
		{
			Class3390 class2 = class3450_0.ListStyle.ListLevelTextStyles[@class.Level.Value];
			if (@class.Indent == null)
			{
				@class.Indent = class2.Indent.method_0();
			}
			if (@class.LeftMargin == null)
			{
				@class.LeftMargin = class2.LeftMargin.vmethod_0();
			}
			if (@class.LeftMargin == null)
			{
				@class.LeftMargin = class2.LeftMargin.vmethod_0();
			}
		}
		return @class;
	}
}
