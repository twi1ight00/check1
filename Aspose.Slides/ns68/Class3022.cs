using System;
using ns67;
using ns69;

namespace ns68;

internal sealed class Class3022
{
	private Class2999 class2999_0;

	private Class2998 class2998_0;

	private Class3000 class3000_0;

	public Class3022(Class3000 projectionsLayer)
	{
		class3000_0 = projectionsLayer;
		class2999_0 = projectionsLayer.Contours;
		class2998_0 = projectionsLayer.StructuralEdges;
	}

	public void method_0(Class3057 region)
	{
		method_1(region);
		method_2();
		method_3();
		method_4();
	}

	private void method_1(Class3057 region)
	{
		Class3035 @class = new Class3035();
		int count = region.Edges.Count;
		for (int i = 0; i < count; i++)
		{
			if (region.Edges[i].IsStructural)
			{
				@class.Add(region.Edges[i]);
			}
		}
		int num = 0;
		while (@class.Count > 0)
		{
			Class3033 class2 = @class[0];
			@class.RemoveAt(0);
			Class3059 class3 = class2.Vertices[0];
			Class3059 class4 = class2.Vertices[1];
			double length = Math.Sqrt(class2.EdgeLengthSqr);
			Class3040 class5 = class2.method_1();
			Struct159 asPlanePoint = class5.method_4(class2).AsPlanePoint;
			Struct159 @struct = new Struct159(class4.X - class3.X, class4.Y - class3.Y);
			Struct159 struct2 = new Struct159(asPlanePoint.X - class3.X, asPlanePoint.Y - class3.Y);
			double num2 = @struct.X * struct2.Y - @struct.Y * struct2.X;
			if (num2 > 0.0)
			{
				Class3059 class6 = class3;
				class3 = class4;
				class4 = class6;
			}
			int num3 = ((class4.StructuralEdges[0] != class2) ? 1 : 0);
			class2999_0.Add(new Class2998());
			Class3033 class7;
			do
			{
				Class2994 structuralEdgeSegment = new Class2994(class3.AsPlanePoint, class4.AsPlanePoint, length);
				class2999_0[num].Add(structuralEdgeSegment);
				class7 = class4.StructuralEdges[(num3 == 0) ? 1 : 0];
				@class.Remove(class7);
				class3 = class4;
				class4 = ((class7.Vertices[0] == class3) ? class7.Vertices[1] : class7.Vertices[0]);
				length = Math.Sqrt(class7.EdgeLengthSqr);
				num3 = ((class4.StructuralEdges[0] != class7) ? 1 : 0);
			}
			while (class2 != class7);
			num++;
		}
	}

	private void method_2()
	{
		int count = class2999_0.Count;
		for (int i = 0; i < count; i++)
		{
			int count2;
			for (int j = 0; j < class2999_0[i].Count; j++)
			{
				count2 = class2999_0[i].Count;
				Class2994 @class = class2999_0[i][j];
				Class2994 class2 = class2999_0[i][(j + 1) % count2];
				if (Class3037.smethod_14(@class.A, @class.B, class2.A, class2.B, out var _) == 0)
				{
					class2999_0[i][j] = new Class2994(@class.A, class2.B);
					class2999_0[i].RemoveAt((j + 1) % count2);
					j--;
				}
			}
			count2 = class2999_0[i].Count;
			for (int k = 0; k < count2; k++)
			{
				class2999_0[i][k].Contour = class2999_0[i];
				class2999_0[i][k].ContourIndex = k;
				class2998_0.Add(class2999_0[i][k]);
			}
		}
	}

	private void method_3()
	{
		int count = class2999_0.Count;
		for (int i = 0; i < count; i++)
		{
			Class2998 @class = class2999_0[i];
			int count2 = @class.Count;
			for (int j = 0; j < count2; j++)
			{
				Class2994 class2 = @class[j];
				Class2994 class3 = @class[(j + 1) % count2];
				if (class2.BA.X * class3.AB.Y - class2.BA.Y * class3.AB.X >= 0.0)
				{
					class2.Step1BuilderCache.BDegreesType = 1;
					class2.Step1BuilderCache.BDegrees = (class2.BA.X * class3.AB.X + class2.BA.Y * class3.AB.Y) / (class2.Length * class3.Length);
				}
				else
				{
					class2.Step1BuilderCache.BDegreesType = ((class2.BA.X * class3.AB.X + class2.BA.Y * class3.AB.Y < 0.0) ? 2 : 3);
				}
			}
		}
	}

	private void method_4()
	{
		double num = double.MaxValue;
		double num2 = double.MaxValue;
		double num3 = double.MinValue;
		double num4 = double.MinValue;
		double num5 = double.MaxValue;
		int count = class2998_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (num2 > class2998_0[i].A.X)
			{
				num2 = class2998_0[i].A.X;
			}
			if (num4 < class2998_0[i].A.X)
			{
				num4 = class2998_0[i].A.X;
			}
			if (num > class2998_0[i].A.Y)
			{
				num = class2998_0[i].A.Y;
			}
			if (num3 < class2998_0[i].A.Y)
			{
				num3 = class2998_0[i].A.Y;
			}
			if (num5 > class2998_0[i].Length)
			{
				num5 = class2998_0[i].Length;
			}
		}
		class3000_0.StructuralEdgesBox = new Class2996(num2, num, num4 - num2, num3 - num);
	}
}
