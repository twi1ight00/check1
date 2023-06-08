using ns134;
using ns137;
using ns138;
using ns99;

namespace ns113;

internal class Class4441
{
	private Class4609 class4609_0;

	private Class4480 class4480_0;

	public Class4480 Glyph => class4480_0;

	public Class4441(Class4480 glyph)
	{
		class4609_0 = new Class4609();
		class4480_0 = glyph;
		glyph.SourceResolution = 1000;
	}

	public void method_0(double sidebearingX, double sidebearingY)
	{
		class4480_0.LeftSidebearingX = sidebearingX;
		class4480_0.LeftSidebearingY = sidebearingY;
	}

	public void method_1(double widthVectorX, double widthVectorY)
	{
		class4480_0.WidthVectorX = widthVectorX;
		class4480_0.WidthVectorY = widthVectorY;
	}

	public void method_2()
	{
		if (class4609_0 != null)
		{
			class4480_0.HintCollections.Add(class4609_0);
		}
		class4609_0 = null;
	}

	public void method_3(Class4603 command)
	{
		Class4613 @class = new Class4613(command.X, command.Y);
		@class.Hints = class4609_0;
		class4480_0.Path.Segments.Add(@class);
	}

	public void method_4(Class4605 command)
	{
		Class4614 @class = new Class4614(command.X, command.Y);
		@class.Hints = class4609_0;
		class4480_0.Path.Segments.Add(@class);
	}

	public void method_5(Class4602 command)
	{
		Class4612 @class = new Class4612(command.X1, command.Y1, command.X2, command.Y2, command.X3, command.Y3);
		@class.Hints = class4609_0;
		class4480_0.Path.Segments.Add(@class);
	}

	public void method_6(Class4601 command)
	{
		Class4611 @class = new Class4611(command.X, command.Y);
		@class.Hints = class4609_0;
		class4480_0.Path.Segments.Add(@class);
	}

	internal void method_7(Class4618 renderingPath)
	{
		foreach (Interface143 segment in renderingPath.Segments)
		{
			class4480_0.Path.Segments.Add(segment);
		}
	}

	internal void method_8(Class4618 renderingPath, double dx, double dy)
	{
		foreach (Interface143 segment in renderingPath.Segments)
		{
			Interface143 interface2 = segment.imethod_0();
			interface2.imethod_1(dx, dy);
			class4480_0.Path.Segments.Add(interface2);
		}
	}
}
