using System.Collections.Generic;
using ns235;
using ns253;

namespace ns262;

internal class Class6457 : Interface303
{
	private readonly Interface304 interface304_0;

	private List<Interface305> list_0;

	private List<Class6463> list_1 = new List<Class6463>();

	private Class6434 class6434_0;

	public Class6434 Paragraph => class6434_0;

	public List<Interface305> LayoutSpans => list_0;

	public List<Class6463> Lines => list_1;

	public Class6457(Interface304 serviceLocator, Class6434 paragraph)
	{
		interface304_0 = serviceLocator;
		class6434_0 = paragraph;
	}

	public void imethod_0(double columnWidth)
	{
		Interface306 @interface = interface304_0.imethod_1();
		list_0 = @interface.imethod_0(Paragraph);
		Interface308 interface2 = interface304_0.imethod_0();
		Interface309 widthProvider = new Class6465(Paragraph.Properties, columnWidth);
		list_1 = interface2.imethod_0(list_0, widthProvider);
	}

	public void imethod_1(Interface312 flow)
	{
		double spaceBefore = Paragraph.Properties.SpaceBefore.imethod_0(Paragraph);
		flow.imethod_1(spaceBefore);
		for (int i = 0; i < list_1.Count; i++)
		{
			Interface307 @interface = list_1[i];
			flow.imethod_0(@interface, Paragraph.Properties.LineSpacing);
			@interface.X += Paragraph.Properties.LeftMargin;
		}
		method_0();
		double spaceAfter = Paragraph.Properties.SpaceAfter.imethod_0(Paragraph);
		flow.imethod_2(spaceAfter);
	}

	private void method_0()
	{
		if (list_1.Count != 0)
		{
			Interface307 @interface = list_1[0];
			if (Paragraph.Properties.TextIdentation < 0)
			{
				@interface.X -= Paragraph.Properties.LeftMargin;
			}
			else
			{
				@interface.X += Paragraph.Properties.TextIdentation;
			}
		}
	}

	public Class6204 imethod_2()
	{
		Class6213 @class = new Class6213();
		foreach (Class6463 item in list_1)
		{
			if (!((Interface307)item).IsOverflowed)
			{
				@class.Add(((Interface307)item).imethod_1());
			}
		}
		return @class;
	}

	public void imethod_3()
	{
		foreach (Class6463 item in list_1)
		{
			((Interface307)item).imethod_0(Paragraph.Properties.Alignment);
		}
		if (list_1.Count > 0 && (Paragraph.Properties.Alignment == Enum825.const_5 || Paragraph.Properties.Alignment == Enum825.const_3 || Paragraph.Properties.Alignment == Enum825.const_4 || Paragraph.Properties.Alignment == Enum825.const_6))
		{
			((Interface307)list_1[list_1.Count - 1]).imethod_0(Enum825.const_0);
		}
	}
}
