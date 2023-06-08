using ns134;
using ns135;
using ns137;
using ns138;
using ns158;
using ns99;

namespace ns160;

internal class Class4737
{
	private Class4609 class4609_0;

	private Class4607 class4607_0;

	private Class4480 class4480_0;

	public Class4480 Glyph => class4480_0;

	public Class4737(Class4480 glyph)
	{
		class4609_0 = new Class4609();
		class4607_0 = new Class4607();
		class4480_0 = glyph;
		glyph.SourceResolution = 1000;
	}

	public void method_0(double sidebearingX, double sidebearingY)
	{
		Glyph.LeftSidebearingX = sidebearingX;
		Glyph.LeftSidebearingY = sidebearingY;
	}

	public void method_1(double widthVectorX, double widthVectorY)
	{
		Glyph.WidthVectorX = widthVectorX;
		Glyph.WidthVectorY = widthVectorY;
	}

	public void method_2()
	{
		if (class4609_0 != null)
		{
			Glyph.HintCollections.Add(class4609_0);
		}
		class4609_0 = null;
	}

	public void method_3(double[][] hGroups, double[][] vGroups)
	{
		for (int i = 0; i < hGroups.Length; i++)
		{
			for (int j = 0; j < hGroups[i].Length; j++)
			{
				if (j % 2 == 0)
				{
					hGroups[i][j] = hGroups[i][j] + Glyph.LeftSidebearingY;
				}
			}
		}
		for (int k = 0; k < vGroups.Length; k++)
		{
			for (int l = 0; l < vGroups[k].Length; l++)
			{
				if (l % 2 == 0)
				{
					vGroups[k][l] = vGroups[k][l] + Glyph.LeftSidebearingX;
				}
			}
		}
		Class4731 hint = new Class4731(hGroups, vGroups);
		class4609_0.Add(hint);
	}

	public void method_4(double y, double dy)
	{
		class4609_0.Add(new Class4736(y + Glyph.LeftSidebearingY, dy));
	}

	public void method_5(double x, double dx)
	{
		class4609_0.Add(new Class4735(x + Glyph.LeftSidebearingX, dx));
	}

	public void method_6()
	{
		Glyph.HintCollections.Add(class4609_0);
		class4609_0 = new Class4609();
	}

	public void method_7(Class4603 command)
	{
		Class4613 @class = new Class4613(command.X, command.Y);
		@class.Hints = class4609_0;
		Glyph.Path.Segments.Add(@class);
	}

	public void method_8(Class4605 command)
	{
		Class4614 @class = new Class4614(command.X, command.Y);
		@class.Hints = class4609_0;
		Glyph.Path.Segments.Add(@class);
	}

	public void method_9(Class4602 command)
	{
		Class4612 @class = new Class4612(command.X1, command.Y1, command.X2, command.Y2, command.X3, command.Y3);
		@class.Hints = class4609_0;
		Glyph.Path.Segments.Add(@class);
	}

	public void method_10(Class4601 command)
	{
		Class4611 @class = new Class4611(command.X, command.Y);
		@class.Hints = class4609_0;
		Glyph.Path.Segments.Add(@class);
	}

	internal void method_11(Class4618 renderingPath)
	{
		foreach (Interface143 segment in renderingPath.Segments)
		{
			Glyph.Path.Segments.Add(segment);
		}
	}

	internal void method_12(Class4618 renderingPath, double dx, double dy)
	{
		foreach (Interface143 segment in renderingPath.Segments)
		{
			Interface143 interface2 = segment.imethod_0();
			interface2.imethod_1(dx, dy);
			Glyph.Path.Segments.Add(interface2);
		}
	}
}
