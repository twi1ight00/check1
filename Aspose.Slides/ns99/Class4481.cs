using ns138;
using ns139;

namespace ns99;

internal class Class4481 : Class4480
{
	private Class4484 class4484_0;

	private bool bool_1;

	private object object_4 = new object();

	public Class4484 Components => class4484_0;

	internal override Class4615 PathDefinition
	{
		get
		{
			if (!bool_1)
			{
				lock (object_4)
				{
					if (!bool_1)
					{
						int num = 0;
						int num2 = 0;
						foreach (Class4483 component in Components)
						{
							num += ((Class4616)component.Glyph.PathDefinition).int_1;
							num2 += ((Class4616)component.Glyph.PathDefinition).int_0;
						}
						Class4616 class2 = Class4616.smethod_1();
						class2.double_0 = new double[num];
						class2.double_1 = new double[num];
						class2.byte_0 = new byte[num];
						class2.bool_0 = new bool[num];
						class2.bool_1 = new bool[num];
						class2.ushort_0 = new ushort[num2];
						foreach (Class4483 component2 in Components)
						{
							Class4509 matrix = component2.Matrix;
							Class4616 class4 = (Class4616)component2.Glyph.PathDefinition;
							for (int i = 0; i < class4.int_1; i++)
							{
								matrix.method_0(class4.double_0[i], class4.double_1[i], out var x, out var y);
								class2.double_0[i + class2.int_1] = x;
								class2.double_1[i + class2.int_1] = y;
								class2.byte_0[i + class2.int_1] = class4.byte_0[i];
								class2.bool_0[i + class2.int_1] = class4.bool_0[i];
								class2.bool_1[i + class2.int_1] = class4.bool_1[i];
							}
							for (int j = 0; j < class4.ushort_0.Length; j++)
							{
								class2.ushort_0[j + class2.int_0] = (ushort)(class2.int_1 + class4.ushort_0[j]);
							}
							class2.int_1 += class4.int_1;
							class2.int_0 += class4.int_0;
						}
						class4615_0 = class2;
						bool_1 = true;
					}
				}
			}
			return class4615_0;
		}
		set
		{
			class4615_0 = value;
		}
	}

	public Class4481()
	{
		class4484_0 = new Class4484();
	}

	internal Class4480 method_3()
	{
		Class4480 @class = new Class4480();
		foreach (Interface143 segment in Path.Segments)
		{
			@class.Path.Segments.Add(segment);
		}
		@class.LeftSidebearingX = base.LeftSidebearingX;
		@class.LeftSidebearingY = base.LeftSidebearingY;
		@class.GlyphBBox = base.GlyphBBox;
		@class.SourceResolution = base.SourceResolution;
		@class.WidthVectorX = base.WidthVectorX;
		@class.WidthVectorY = base.WidthVectorY;
		return @class;
	}
}
