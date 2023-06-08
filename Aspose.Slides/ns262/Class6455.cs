using System;
using System.Collections.Generic;
using System.Drawing;
using ns224;
using ns235;
using ns253;

namespace ns262;

internal class Class6455
{
	private readonly Interface304 interface304_0;

	private Class6468 class6468_0;

	private Class6457[] class6457_0;

	private Class6451 class6451_0;

	public Class6455(Interface304 serviceLocator)
	{
		interface304_0 = serviceLocator;
	}

	public void method_0(Class6451 textShape, RectangleF targetRect)
	{
		class6451_0 = textShape;
		class6468_0 = new Class6468(interface304_0);
		class6468_0.Initialize(class6451_0.TextBody.Properties, targetRect);
		method_4(textShape, class6468_0);
		method_3(class6468_0);
	}

	public Class6204 method_1()
	{
		Class6213 @class = new Class6213();
		Class6457[] array = class6457_0;
		foreach (Class6457 class2 in array)
		{
			@class.Add(class2.imethod_2());
		}
		@class.RenderTransform = method_2();
		return @class;
	}

	private Class6002 method_2()
	{
		Class6002 @class = new Class6002();
		double columnHeight = class6468_0.ColumnHeight;
		double maximumColumnHeight = class6468_0.MaximumColumnHeight;
		switch (class6451_0.TextBody.Properties.Anchor)
		{
		default:
			throw new ArgumentOutOfRangeException();
		case Enum826.const_1:
			@class.method_8(0f, (float)((columnHeight - maximumColumnHeight) / 2.0));
			break;
		case Enum826.const_2:
			@class.method_8(0f, (float)(columnHeight - maximumColumnHeight));
			break;
		case Enum826.const_0:
		case Enum826.const_3:
		case Enum826.const_4:
			break;
		}
		return @class;
	}

	private void method_3(Class6468 flow)
	{
		Class6457[] array = class6457_0;
		foreach (Class6457 @class in array)
		{
			@class.imethod_1(flow);
		}
	}

	private void method_4(Class6451 textShape, Class6468 flow)
	{
		List<Class6434> paragraphs = textShape.TextBody.Paragraphs;
		class6457_0 = new Class6457[paragraphs.Count];
		for (int i = 0; i < paragraphs.Count; i++)
		{
			Class6434 paragraph = paragraphs[i];
			Class6457 @class = new Class6457(interface304_0, paragraph);
			@class.imethod_0(flow.ColumnWidth);
			@class.imethod_3();
			class6457_0[i] = @class;
		}
	}
}
