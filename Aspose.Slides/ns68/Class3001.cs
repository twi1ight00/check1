using System.Collections.Generic;
using ns67;
using ns69;

namespace ns68;

internal sealed class Class3001
{
	internal static void smethod_0(Class2994 analyzedStructuralEdge)
	{
		Class3011 cellVertices = analyzedStructuralEdge.Step1BuilderCache.CellVertices;
		Class3013 cell = analyzedStructuralEdge.Step1BuilderCache.Cell;
		Class2998 contour = analyzedStructuralEdge.Contour;
		int contourIndex = analyzedStructuralEdge.ContourIndex;
		smethod_2(cellVertices);
		cell.Add(new Class3012(analyzedStructuralEdge.B));
		int count = cellVertices.Count;
		int edgeID = contour[(contourIndex + 1) % contour.Count].EdgeID;
		smethod_3(analyzedStructuralEdge, edgeID, appendMode: true);
		bool flag = false;
		for (int i = 0; i < count; i++)
		{
			if (!cellVertices[i].bool_0)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			edgeID = contour[(contourIndex + contour.Count - 1) % contour.Count].EdgeID;
			smethod_3(analyzedStructuralEdge, edgeID, appendMode: false);
		}
		smethod_1(analyzedStructuralEdge);
		cell.Add(new Class3012(analyzedStructuralEdge.A));
		cell.method_6();
	}

	private static void smethod_1(Class2994 analyzedStructuralEdge)
	{
		Class3013 cell = analyzedStructuralEdge.Step1BuilderCache.Cell;
		Class2998 contour = analyzedStructuralEdge.Contour;
		int contourIndex = analyzedStructuralEdge.ContourIndex;
		if (cell.Count != 1)
		{
			return;
		}
		int count = contour.Count;
		Class2994 @class = contour[(contourIndex + count - 1) % count];
		Class2994 class2 = contour[(contourIndex + 1) % count];
		if (@class.Step1BuilderCache.Cell.Count > 2 && class2.Step1BuilderCache.Cell.Count > 2)
		{
			cell.Add(class2.Step1BuilderCache.Cell[1]);
			cell.Add(@class.Step1BuilderCache.Cell[@class.Step1BuilderCache.Cell.Count - 2]);
		}
		else if (@class.Step1BuilderCache.Cell.Count > 2 && class2.Step1BuilderCache.Cell.Count <= 2)
		{
			cell.Add(@class.Step1BuilderCache.Cell[@class.Step1BuilderCache.Cell.Count - 2]);
		}
		else if (@class.Step1BuilderCache.Cell.Count <= 2 && class2.Step1BuilderCache.Cell.Count > 2)
		{
			cell.Add(class2.Step1BuilderCache.Cell[1]);
		}
		else if (@class.Step1BuilderCache.Cell.Count <= 2 && class2.Step1BuilderCache.Cell.Count <= 2)
		{
			Class2992 class3 = Class2990.smethod_0(@class, analyzedStructuralEdge);
			Class2992 class4 = Class2990.smethod_0(analyzedStructuralEdge, class2);
			Struct159 intrsct;
			int num = Class3037.smethod_18(class3.A, class3.B, class4.A, class4.B, out intrsct);
			if (num == 1)
			{
				cell.Add(new Class3012(intrsct));
			}
		}
	}

	private static void smethod_2(Class3011 cellVertices)
	{
		for (int i = 0; i < cellVertices.Count - 1; i++)
		{
			if (cellVertices[i].class3007_0.class2998_0.Count != cellVertices[i + 1].class3007_0.class2998_0.Count)
			{
				continue;
			}
			bool flag = true;
			for (int j = 0; j < cellVertices[i].class3007_0.class2998_0.Count; j++)
			{
				if (cellVertices[i].class3007_0.class2998_0[j].EdgeID != cellVertices[i + 1].class3007_0.class2998_0[j].EdgeID)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				cellVertices.RemoveAt(i);
				i--;
			}
		}
	}

	private static void smethod_3(Class2994 analyzedStructuralEdge, int startIndex, bool appendMode)
	{
		Class3011 cellVertices = analyzedStructuralEdge.Step1BuilderCache.CellVertices;
		Class3013 cell = analyzedStructuralEdge.Step1BuilderCache.Cell;
		int count = cellVertices.Count;
		List<int> list = new List<int>(2);
		list.Add(startIndex);
		int index = -1;
		if (!appendMode)
		{
			index = cell.Count;
		}
		for (int i = 0; i < count; i++)
		{
			for (int j = 0; j < cellVertices.Count; j++)
			{
				if (cellVertices[j].bool_0)
				{
					continue;
				}
				int count2 = cellVertices[j].class3007_0.class2998_0.Count;
				int k;
				for (k = 0; k < count2; k++)
				{
					for (int num = 0; num < list.Count; num++)
					{
						if (cellVertices[j].class3007_0.class2998_0[k].EdgeID == list[num])
						{
							goto IL_00d8;
						}
					}
				}
				continue;
				IL_00d8:
				if (appendMode)
				{
					cell.Add(new Class3012(new Struct159(cellVertices[j].class3007_0.X, cellVertices[j].class3007_0.Y)));
				}
				else
				{
					cell.Insert(index, new Class3012(new Struct159(cellVertices[j].class3007_0.X, cellVertices[j].class3007_0.Y)));
				}
				cellVertices[j].bool_0 = true;
				list.Clear();
				for (int l = 1; l <= count2 - 1; l++)
				{
					int edgeID = cellVertices[j].class3007_0.class2998_0[(k + l) % count2].EdgeID;
					if (edgeID != analyzedStructuralEdge.EdgeID)
					{
						list.Add(edgeID);
					}
				}
				break;
			}
		}
	}
}
