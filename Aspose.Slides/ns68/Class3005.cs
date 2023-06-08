using System.Collections.Generic;
using ns67;
using ns69;

namespace ns68;

internal sealed class Class3005
{
	public static void smethod_0(Class3002 cellRecognizer, Class2995 crossesList, int crossIndex, List<short> crossVicinity)
	{
		Class2998 structuralEdges = cellRecognizer.ProjectionsLayer.StructuralEdges;
		Class3009 cellVertices = cellRecognizer.CellVertices;
		Class3009 @class = smethod_2(cellRecognizer, crossVicinity, crossesList, crossIndex);
		if (Class3004.smethod_0(@class[0], @class[1]) && Class3004.smethod_0(@class[2], @class[3]) && Class3004.smethod_0(@class[0], @class[3]))
		{
			cellVertices.Add(@class[0]);
			cellVertices.Add(@class[2]);
		}
		int i = 0;
		int j;
		for (j = 0; j < 3; j++)
		{
			for (i = j + 1; i < 4; i++)
			{
				Class2998 class2 = new Class2998(2);
				for (int k = 0; k < 4; k++)
				{
					if (k != j && k != i)
					{
						class2.Add(structuralEdges[crossVicinity[k]]);
					}
				}
				Class2994 class3 = structuralEdges[crossVicinity[j]];
				Class2994 class4 = structuralEdges[crossVicinity[i]];
				Class2994 class5 = class2[0];
				Class2994 class6 = class2[1];
				Struct159 mEdMidPoint = new Struct159((class3.A.X + class3.B.X) / 2.0, (class3.A.Y + class3.B.Y) / 2.0);
				Struct159 mEdMidPoint2 = new Struct159((class4.A.X + class4.B.X) / 2.0, (class4.A.Y + class4.B.Y) / 2.0);
				Struct159 refPoint = new Struct159((class5.A.X + class5.B.X) / 2.0, (class5.A.Y + class5.B.Y) / 2.0);
				Struct159 refPoint2 = new Struct159((class6.A.X + class6.B.X) / 2.0, (class6.A.Y + class6.B.Y) / 2.0);
				smethod_1(@class, i, class2, class3, mEdMidPoint, out var ray_, out var ray_2);
				smethod_1(@class, j, class2, class4, mEdMidPoint2, out var ray_3, out var ray_4);
				int num = Class3037.smethod_7(ray_.A, ray_.B, refPoint, ray_3.B);
				int num2 = Class3037.smethod_7(ray_3.A, ray_3.B, refPoint, ray_.B);
				int num3 = Class3037.smethod_7(ray_2.A, ray_2.B, refPoint2, ray_4.B);
				int num4 = Class3037.smethod_7(ray_4.A, ray_4.B, refPoint2, ray_2.B);
				if (num == 1 && num2 == 1 && num3 == 1 && num4 == 1)
				{
					goto end_IL_032a;
				}
			}
			continue;
			end_IL_032a:
			break;
		}
		if (i != 4)
		{
			cellVertices.Add(@class[j]);
			cellVertices.Add(@class[i]);
			return;
		}
		int num5 = 0;
		while (true)
		{
			if (num5 < @class.Count)
			{
				if (@class[num5].bool_0)
				{
					break;
				}
				num5++;
				continue;
			}
			return;
		}
		Class3007 class7 = new Class3007(@class[num5].X, @class[num5].Y);
		for (int l = 0; l < 4; l++)
		{
			class7.class2998_0.Add(structuralEdges[crossVicinity[l]]);
		}
		cellVertices.Add(class7);
	}

	private static void smethod_1(Class3009 cellVerticesAnti, int m, Class2998 EdsForRays_notj_notk, Class2994 mEd, Struct159 mEdMidPoint, out Class2992 ray_0, out Class2992 ray_1)
	{
		ray_0 = Class2990.smethod_0(mEd, EdsForRays_notj_notk[0]);
		ray_1 = Class2990.smethod_0(mEd, EdsForRays_notj_notk[1]);
		Class3037.smethod_14(ray_0.A, ray_0.B, ray_1.A, ray_1.B, out var _);
		ray_0 = new Class2992(new Struct159(cellVerticesAnti[m].X, cellVerticesAnti[m].Y), new Struct159(cellVerticesAnti[m].X + (ray_0.B.X - ray_0.A.X), cellVerticesAnti[m].Y + (ray_0.B.Y - ray_0.A.Y)));
		ray_1 = new Class2992(new Struct159(cellVerticesAnti[m].X, cellVerticesAnti[m].Y), new Struct159(cellVerticesAnti[m].X + (ray_1.B.X - ray_1.A.X), cellVerticesAnti[m].Y + (ray_1.B.Y - ray_1.A.Y)));
		int num = Class3037.smethod_7(ray_1.A, ray_1.B, mEdMidPoint, ray_0.B);
		if (num == -1)
		{
			ray_0.method_0();
		}
		num = Class3037.smethod_7(ray_0.A, ray_0.B, mEdMidPoint, ray_1.B);
		if (num == -1)
		{
			ray_1.method_0();
		}
	}

	private static Class3009 smethod_2(Class3002 cellRecognizer, IList<short> crossVicinity, Class2995 crossesList, int crossIndex)
	{
		Class2998 structuralEdges = cellRecognizer.ProjectionsLayer.StructuralEdges;
		Class3019 backBuffer = cellRecognizer.ProjectionsLayer.Step1Builder.BackBuffer;
		Class2994[][] array = new Class2994[4][]
		{
			new Class2994[3]
			{
				structuralEdges[crossVicinity[1]],
				structuralEdges[crossVicinity[2]],
				structuralEdges[crossVicinity[3]]
			},
			new Class2994[3]
			{
				structuralEdges[crossVicinity[0]],
				structuralEdges[crossVicinity[2]],
				structuralEdges[crossVicinity[3]]
			},
			new Class2994[3]
			{
				structuralEdges[crossVicinity[0]],
				structuralEdges[crossVicinity[1]],
				structuralEdges[crossVicinity[3]]
			},
			new Class2994[3]
			{
				structuralEdges[crossVicinity[0]],
				structuralEdges[crossVicinity[1]],
				structuralEdges[crossVicinity[2]]
			}
		};
		Class3009 @class = new Class3009(4);
		for (int i = 0; i < 4; i++)
		{
			Class3007 class2 = Class3006.smethod_0(array[i], backBuffer, crossesList[crossIndex]);
			if (class2 != null)
			{
				class2.class2998_0.Add(array[i][0]);
				class2.class2998_0.Add(array[i][1]);
				class2.class2998_0.Add(array[i][2]);
				@class.Add(class2);
			}
		}
		return @class;
	}
}
