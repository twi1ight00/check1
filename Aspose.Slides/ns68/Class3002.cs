using System.Collections.Generic;
using System.Drawing;

namespace ns68;

internal sealed class Class3002
{
	private class Class3003 : IComparer<Point>
	{
		public int Compare(Point cross1, Point cross2)
		{
			if (cross1.X < cross2.X)
			{
				return -1;
			}
			if (cross1.X > cross2.X)
			{
				return 1;
			}
			if (cross1.Y < cross2.Y)
			{
				return -1;
			}
			if (cross1.Y > cross2.Y)
			{
				return 1;
			}
			return 0;
		}
	}

	private Class3009 class3009_0;

	private Class3000 class3000_0;

	public Class3009 CellVertices => class3009_0;

	public Class3000 ProjectionsLayer => class3000_0;

	public Class3002(Class3000 projectionsLayer)
	{
		class3000_0 = projectionsLayer;
		class3009_0 = new Class3009();
	}

	internal void method_0()
	{
		Class3019 backBuffer = ProjectionsLayer.Step1Builder.BackBuffer;
		Class2995 crossesList = backBuffer.CrossesList;
		Struct156[,] pixels = backBuffer.Pixels;
		method_6(crossesList);
		method_5(crossesList, pixels);
		method_4(crossesList, pixels);
		method_3();
		method_2();
		method_1();
	}

	private void method_1()
	{
		Class2998 structuralEdges = ProjectionsLayer.StructuralEdges;
		int count = structuralEdges.Count;
		for (int i = 0; i < count; i++)
		{
			if (structuralEdges[i].Step1BuilderCache.CellVertices.Count > 0)
			{
				Class3001.smethod_0(structuralEdges[i]);
			}
		}
		for (int j = 0; j < count; j++)
		{
			if (structuralEdges[j].Step1BuilderCache.CellVertices.Count == 0)
			{
				Class3001.smethod_0(structuralEdges[j]);
			}
		}
	}

	private void method_2()
	{
		int count = CellVertices.Count;
		for (int i = 0; i < count; i++)
		{
			int count2 = CellVertices[i].class2998_0.Count;
			for (int j = 0; j < count2; j++)
			{
				CellVertices[i].class2998_0[j].Step1BuilderCache.method_0(CellVertices[i]);
			}
		}
	}

	private void method_3()
	{
		int count = CellVertices.Count;
		for (int i = 0; i < count; i++)
		{
			CellVertices[i].class2998_0.method_1(new Class2994.Class2997());
		}
		CellVertices.method_1(new Class3007.Class3008());
		for (int j = 0; j < CellVertices.Count - 1; j++)
		{
			if (!Class3004.smethod_0(CellVertices[j], CellVertices[j + 1]))
			{
				continue;
			}
			int count2 = CellVertices[j].class2998_0.Count;
			int count3 = CellVertices[j + 1].class2998_0.Count;
			if (count2 != count3)
			{
				continue;
			}
			bool flag = true;
			for (int k = 0; k < count2; k++)
			{
				if (CellVertices[j].class2998_0[k].EdgeID != CellVertices[j + 1].class2998_0[k].EdgeID)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				CellVertices.RemoveAt(j);
				j--;
			}
		}
	}

	private void method_4(Class2995 crossesList, Struct156[,] backBufferPixels)
	{
		Class3019 backBuffer = ProjectionsLayer.Step1Builder.BackBuffer;
		Class2998 structuralEdges = ProjectionsLayer.StructuralEdges;
		List<short> list = new List<short>(4);
		int count = crossesList.Count;
		for (int i = 0; i < count; i++)
		{
			list.Clear();
			list.Add(backBufferPixels[crossesList[i].X, crossesList[i].Y].short_0);
			list.Add(backBufferPixels[crossesList[i].X + 1, crossesList[i].Y].short_0);
			list.Add(backBufferPixels[crossesList[i].X, crossesList[i].Y + 1].short_0);
			list.Add(backBufferPixels[crossesList[i].X + 1, crossesList[i].Y + 1].short_0);
			list.Sort();
			for (int j = 0; j < list.Count - 1; j++)
			{
				if (list[j] != -10)
				{
					if (list[j] == list[j + 1])
					{
						list.RemoveAt(j);
						j--;
					}
					continue;
				}
				list.Clear();
				break;
			}
			if (list.Count == 3 && (backBufferPixels[crossesList[i].X, crossesList[i].Y].short_0 == backBufferPixels[crossesList[i].X + 1, crossesList[i].Y + 1].short_0 || backBufferPixels[crossesList[i].X + 1, crossesList[i].Y].short_0 == backBufferPixels[crossesList[i].X, crossesList[i].Y + 1].short_0))
			{
				continue;
			}
			if (list.Count == 3)
			{
				Class3007 @class = Class3006.smethod_0(new Class2994[3]
				{
					structuralEdges[list[0]],
					structuralEdges[list[1]],
					structuralEdges[list[2]]
				}, backBuffer, crossesList[i]);
				if (@class != null)
				{
					@class.class2998_0.Add(structuralEdges[list[0]]);
					@class.class2998_0.Add(structuralEdges[list[1]]);
					@class.class2998_0.Add(structuralEdges[list[2]]);
					CellVertices.Add(@class);
				}
			}
			else if (list.Count == 4)
			{
				Class3005.smethod_0(this, crossesList, i, list);
			}
		}
	}

	private void method_5(Class2995 crossesList, Struct156[,] backBufferPixels)
	{
		Class3019 backBuffer = ProjectionsLayer.Step1Builder.BackBuffer;
		int count = crossesList.Count;
		for (int i = 0; i < count; i++)
		{
			for (int j = 0; j <= 1; j++)
			{
				for (int k = 0; k <= 1; k++)
				{
					int short_ = backBufferPixels[crossesList[i].X + j, crossesList[i].Y + k].short_0;
					if (crossesList[i].Y >= 1 && crossesList[i].X >= 1 && crossesList[i].Y < backBuffer.Height - 2 && crossesList[i].X < backBuffer.Width - 2 && backBufferPixels[crossesList[i].X + j, crossesList[i].Y + k - 1].short_0 != short_ && backBufferPixels[crossesList[i].X + j + 1, crossesList[i].Y + k].short_0 != short_ && backBufferPixels[crossesList[i].X + j, crossesList[i].Y + k + 1].short_0 != short_ && backBufferPixels[crossesList[i].X + j - 1, crossesList[i].Y + k].short_0 != short_ && backBufferPixels[crossesList[i].X + j + 1, crossesList[i].Y + k - 1].short_0 != short_ && backBufferPixels[crossesList[i].X + j + 1, crossesList[i].Y + k + 1].short_0 != short_ && backBufferPixels[crossesList[i].X + j - 1, crossesList[i].Y + k + 1].short_0 != short_ && backBufferPixels[crossesList[i].X + j - 1, crossesList[i].Y + k - 1].short_0 != short_)
					{
						backBufferPixels[crossesList[i].X + j, crossesList[i].Y + k].short_0 = backBufferPixels[crossesList[i].X + j - 1, crossesList[i].Y + k].short_0;
						backBufferPixels[crossesList[i].X + j, crossesList[i].Y + k].short_1 = backBufferPixels[crossesList[i].X + j - 1, crossesList[i].Y + k].short_1;
					}
				}
			}
		}
	}

	private void method_6(Class2995 crossesList)
	{
		ProjectionsLayer.Step1Builder.BackBuffer.CrossesList.method_1(new Class3003());
		for (int i = 0; i < crossesList.Count - 1; i++)
		{
			if (crossesList[i] == crossesList[i + 1])
			{
				crossesList.RemoveAt(i);
				i--;
			}
		}
	}
}
