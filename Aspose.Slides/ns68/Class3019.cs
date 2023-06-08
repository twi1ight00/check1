using System;

namespace ns68;

internal sealed class Class3019
{
	internal const int int_0 = 5;

	internal const int int_1 = -10;

	private Class2999 class2999_0;

	private Class2998 class2998_0;

	private Struct156[,] struct156_0;

	private Class2989 class2989_0;

	private Class3017 class3017_0;

	private Class3016 class3016_0;

	private Class3020 class3020_0;

	private Class3015 class3015_0;

	private Class2995 class2995_0;

	private int int_2;

	private int int_3;

	private double double_0;

	internal Struct156[,] Pixels => struct156_0;

	internal Class2995 CrossesList => class2995_0;

	internal int Width => int_2;

	internal int Height => int_3;

	internal Class2989 NormalizedBackBufferCoordinateSystem => class2989_0;

	internal Class2998 StructuralEdges => class2998_0;

	internal Class3020 PixelChecker => class3020_0;

	internal Class3017 FloodFiller => class3017_0;

	internal Class3016 FloodFillerCache => class3016_0;

	internal double MinEdgeLenToSize => double_0;

	internal Class3019(Class2998 structuralEdges, Class2996 structuralEdgesBox, Class2999 contours)
	{
		class2999_0 = contours;
		class2998_0 = structuralEdges;
		class2995_0 = new Class2995();
		class3017_0 = new Class3017(this);
		class3020_0 = new Class3020(this);
		class3015_0 = new Class3015(this);
		method_4(structuralEdges, structuralEdgesBox);
		method_3();
		class3016_0 = new Class3016(this);
		method_2();
		method_1();
		method_0();
	}

	private void method_0()
	{
		for (int num = class2999_0.Count - 1; num >= 0; num--)
		{
			class3016_0.CurrentContour = class2999_0[num];
			int count = class3016_0.CurrentContour.Count;
			for (short num2 = 0; num2 < count; num2 = (short)(num2 + 1))
			{
				if (class3016_0.CurrentContour[num2].Step1BuilderCache.FlagToRefillBecauseOfBlameBorderChained)
				{
					FloodFiller.method_0(class3016_0.CurrentContour[num2].Step1BuilderCache.StartFillPoint, num2, fillAsFirst: false, reFilling: true, Enum457.const_3);
				}
			}
		}
	}

	private void method_1()
	{
		for (int num = class2999_0.Count - 1; num >= 0; num--)
		{
			class3016_0.CurrentContour = class2999_0[num];
			Class2998 currentContour = class3016_0.CurrentContour;
			int count = currentContour.Count;
			FloodFiller.method_0(currentContour[0].Step1BuilderCache.StartFillPoint, 0, fillAsFirst: true, reFilling: false, Enum457.const_2);
			for (short num2 = 1; num2 < count - 1; num2 = (short)(num2 + 1))
			{
				FloodFiller.method_0(currentContour[num2].Step1BuilderCache.StartFillPoint, num2, fillAsFirst: false, reFilling: false, Enum457.const_2);
				class3015_0.method_1(currentContour[num2].EdgeID, currentContour[num2].InnerNormal.X, currentContour[num2].InnerNormal.Y);
			}
			short num3 = (short)(count - 1);
			FloodFiller.method_0(currentContour[num3].Step1BuilderCache.StartFillPoint, num3, fillAsFirst: false, reFilling: false, (currentContour[num3].Step1BuilderCache.BDegreesType != 1) ? Enum457.const_2 : Enum457.const_0);
			class3015_0.method_1(currentContour[num3].EdgeID, currentContour[num3].InnerNormal.X, currentContour[num3].InnerNormal.Y);
			FloodFiller.method_0(currentContour[0].Step1BuilderCache.StartFillPoint, 0, fillAsFirst: false, reFilling: false, Enum457.const_2);
			class3015_0.method_1(currentContour[0].EdgeID, currentContour[0].InnerNormal.X, currentContour[0].InnerNormal.Y);
		}
	}

	private void method_2()
	{
		for (short num = 0; num < StructuralEdges.Count; num = (short)(num + 1))
		{
			StructuralEdges[num].EdgeID = num;
			class3015_0.method_0(num);
		}
	}

	private void method_3()
	{
		struct156_0 = new Struct156[Width, Height];
		for (int i = 0; i < Width; i++)
		{
			for (int j = 0; j < Height; j++)
			{
				struct156_0[i, j].short_0 = -10;
				struct156_0[i, j].short_1 = -10;
			}
		}
	}

	private void method_4(Class2998 structuralEdges, Class2996 structuralEdgesBox)
	{
		double num = double.MaxValue;
		for (int i = 0; i < StructuralEdges.Count; i++)
		{
			if (num > structuralEdges[i].Length)
			{
				num = structuralEdges[i].Length;
			}
		}
		double num2 = num / 5.0;
		class2989_0 = new Class2989(this, structuralEdgesBox, num2);
		int_2 = (int)Math.Round(structuralEdgesBox.WidthOrigin / num2 + 2.0);
		int_3 = (int)Math.Round(structuralEdgesBox.HeightOrigin / num2 + 2.0);
		double_0 = (double)Math.Min(Width, Height) / num;
	}
}
