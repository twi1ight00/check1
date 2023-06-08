using System.Collections.Generic;

namespace ns69;

internal sealed class Class3045
{
	private Class3056 class3056_0;

	public Class3045(Class3056 triangulation)
	{
		class3056_0 = triangulation;
	}

	public Class3046 method_0()
	{
		int regionsCount;
		Class3046 result = method_1(out regionsCount);
		if (regionsCount <= 1)
		{
			return result;
		}
		return method_3(regionsCount);
	}

	private Class3046 method_1(out int regionsCount)
	{
		regionsCount = method_7();
		if (regionsCount != 1 && regionsCount != 0)
		{
			if (regionsCount == -1)
			{
				return null;
			}
			return null;
		}
		Class3046 @class = new Class3046(1);
		@class.Add(class3056_0.method_0());
		return @class;
	}

	private void method_2(Class3040 seedTrngl, int regionInd)
	{
		Class3042 @class = new Class3042(class3056_0.Triangles.Count);
		Class3040 class2 = seedTrngl;
		class2.RegionInd = regionInd;
		int num = 0;
		while (true)
		{
			for (int i = 0; i < 3; i++)
			{
				if (!class2.Edges[i].IsStructural)
				{
					Class3040 class3 = class2.Edges[i].method_0(class2);
					if (class3 != null && class3.RegionInd == -1)
					{
						class3.RegionInd = regionInd;
						@class.method_0(class3);
						num++;
					}
				}
			}
			num--;
			if (num < 0)
			{
				break;
			}
			class2 = @class.method_1();
		}
		seedTrngl.RegionInd = regionInd;
	}

	private Class3046 method_3(int regionsCount)
	{
		int count = class3056_0.Triangles.Count;
		for (int i = 0; i < count; i++)
		{
			class3056_0.Triangles[i].RegionInd = -1;
		}
		int num = 0;
		for (int j = 0; j < count; j++)
		{
			if (class3056_0.Triangles[j].RegionInd == -1)
			{
				method_2(class3056_0.Triangles[j], num);
				num++;
			}
		}
		Class3061 @class = method_4(regionsCount);
		Class3036 class2 = method_5(regionsCount);
		Class3046 class3 = new Class3046(regionsCount);
		for (int k = 0; k < regionsCount; k++)
		{
			Class3057 class4 = new Class3057(@class[k], class2[k]);
			Class3045 class5 = new Class3045(class4);
			class5.method_7();
			class3.Add(class4);
		}
		return class3;
	}

	private Class3061 method_4(int regionsCount)
	{
		Class3061 @class = new Class3061(regionsCount);
		for (int i = 0; i < regionsCount; i++)
		{
			@class.Add(new Class3060());
		}
		List<int> list = new List<int>();
		int count = class3056_0.Vertices.Count;
		for (int j = 0; j < count; j++)
		{
			list.Clear();
			int count2 = class3056_0.Vertices[j].Triangles.Count;
			for (int k = 0; k < count2; k++)
			{
				if (list.IndexOf(class3056_0.Vertices[j].Triangles[k].RegionInd) == -1)
				{
					list.Add(class3056_0.Vertices[j].Triangles[k].RegionInd);
				}
			}
			int count3 = list.Count;
			class3056_0.Vertices[j].ReflectedVertices = new Class3059[regionsCount];
			for (int l = 0; l < count3; l++)
			{
				@class[list[l]].Add(class3056_0.Vertices[j].ReflectedVertices[list[l]] = new Class3059(class3056_0.Vertices[j]));
			}
		}
		return @class;
	}

	private Class3036 method_5(int regionsCount)
	{
		Class3036 @class = new Class3036(regionsCount);
		for (int i = 0; i < regionsCount; i++)
		{
			@class.Add(new Class3035());
		}
		int count = class3056_0.Edges.Count;
		for (int j = 0; j < count; j++)
		{
			if (!class3056_0.Edges[j].IsStructural)
			{
				continue;
			}
			Class3033 class2 = class3056_0.Edges[j];
			Class3040 class3 = class2.Triangles[0];
			Class3040 class4 = class2.Triangles[1];
			if (class3 != null && class4 != null)
			{
				if (class3.RegionInd == class4.RegionInd)
				{
					method_6(@class, class2, class3.RegionInd);
					continue;
				}
				method_6(@class, class2, class3.RegionInd);
				method_6(@class, class2, class4.RegionInd);
			}
			else if (class3 != null && class4 == null)
			{
				method_6(@class, class2, class3.RegionInd);
			}
			else if (class3 == null && class4 != null)
			{
				method_6(@class, class2, class4.RegionInd);
			}
		}
		return @class;
	}

	private void method_6(Class3036 structuralEdgesLists, Class3033 reflectedEdge, int regionInd)
	{
		if (!reflectedEdge.Vertices[0].ReflectedVertices[regionInd].method_0(reflectedEdge.Vertices[1].ReflectedVertices[regionInd]))
		{
			structuralEdgesLists[regionInd].Add(new Class3033(reflectedEdge.Vertices[0].ReflectedVertices[regionInd], reflectedEdge.Vertices[1].ReflectedVertices[regionInd]));
		}
	}

	private int method_7()
	{
		if (class3056_0.Superstructure == null)
		{
			return -1;
		}
		int result = method_8();
		method_11();
		return result;
	}

	private int method_8()
	{
		Class3035 @class = new Class3035();
		int count = class3056_0.Edges.Count;
		for (int i = 0; i < count; i++)
		{
			if (class3056_0.Edges[i].IsStructural)
			{
				@class.Add(class3056_0.Edges[i]);
			}
		}
		Class3040 seedTrngl = class3056_0.Superstructure.Edges[0].method_1();
		int j = 0;
		int num = 0;
		method_2(seedTrngl, 0);
		Class3036 class2 = new Class3036();
		class2.Add(new Class3035());
		class2.Add(new Class3035());
		int count2 = @class.Count;
		for (int k = 0; k < count2; k++)
		{
			if (@class[k].Triangles[0].RegionInd != 0 && @class[k].Triangles[1].RegionInd != 0)
			{
				class2[1].Add(@class[k]);
			}
			else
			{
				class2[0].Add(@class[k]);
			}
		}
		for (; class2[j].Count > 0; j++)
		{
			for (int l = 0; l < class2[j].Count; l++)
			{
				seedTrngl = method_9(class2, j, l);
				if (seedTrngl != null)
				{
					method_2(seedTrngl, j + 1);
					if ((j + 1) % 2 == 1)
					{
						num++;
					}
				}
			}
			Class3035 class3 = class2[j + 1];
			class2[j + 1] = new Class3035();
			class2.Add(new Class3035());
			for (int m = 0; m < class3.Count; m++)
			{
				if (class3[m].Triangles[0].RegionInd != j + 1 && class3[m].Triangles[1].RegionInd != j + 1)
				{
					class2[j + 2].Add(class3[m]);
				}
				else
				{
					class2[j + 1].Add(class3[m]);
				}
			}
		}
		return num;
	}

	private Class3040 method_9(Class3036 edgesByOutermostFillID, int OutermostFillID, int iii)
	{
		Class3040 result = null;
		if (edgesByOutermostFillID[OutermostFillID][iii].Triangles[0].RegionInd == -1)
		{
			result = edgesByOutermostFillID[OutermostFillID][iii].Triangles[0];
		}
		if (edgesByOutermostFillID[OutermostFillID][iii].Triangles[1].RegionInd == -1)
		{
			result = edgesByOutermostFillID[OutermostFillID][iii].Triangles[1];
		}
		return result;
	}

	private int method_10()
	{
		Class3040 @class = class3056_0.Superstructure.Edges[0].method_1();
		int num = 0;
		int num2 = 0;
		while (@class != null)
		{
			method_2(@class, num);
			if (num % 2 == 1)
			{
				num2++;
			}
			@class = null;
			int count = class3056_0.Edges.Count;
			for (int i = 0; i < count; i++)
			{
				if (class3056_0.Edges[i].Triangles[0] != null && class3056_0.Edges[i].Triangles[1] != null)
				{
					if (class3056_0.Edges[i].Triangles[0].RegionInd == -1 && class3056_0.Edges[i].Triangles[1].RegionInd != -1)
					{
						@class = class3056_0.Edges[i].Triangles[0];
						num = class3056_0.Edges[i].Triangles[1].RegionInd + 1;
						break;
					}
					if (class3056_0.Edges[i].Triangles[1].RegionInd == -1 && class3056_0.Edges[i].Triangles[0].RegionInd != -1)
					{
						@class = class3056_0.Edges[i].Triangles[1];
						num = class3056_0.Edges[i].Triangles[0].RegionInd + 1;
						break;
					}
				}
			}
		}
		return num2;
	}

	private void method_11()
	{
		Queue<Class3033> queue = new Queue<Class3033>(class3056_0.Edges.Count);
		for (int i = 0; i < class3056_0.Edges.Count; i++)
		{
			queue.Enqueue(class3056_0.Edges[i]);
		}
		int count = queue.Count;
		for (int j = 0; j < count; j++)
		{
			Class3033 @class = queue.Dequeue();
			if (!@class.IsStructural)
			{
				if (@class.Triangles[0] != null && @class.Triangles[1] != null && @class.Triangles[0].RegionInd % 2 == 0 && @class.Triangles[1].RegionInd % 2 == 0)
				{
					Class3058.smethod_1(class3056_0, @class, preserveAloneSecondaryEdges: false);
				}
				if ((@class.Triangles[0] == null && @class.Triangles[1] != null && @class.Triangles[1].RegionInd % 2 == 0) || (@class.Triangles[1] == null && @class.Triangles[0] != null && @class.Triangles[0].RegionInd % 2 == 0))
				{
					Class3058.smethod_1(class3056_0, @class, preserveAloneSecondaryEdges: false);
				}
			}
		}
		count = class3056_0.Edges.Count;
		for (int k = 0; k < count; k++)
		{
			Class3033 @class = class3056_0.Edges[k];
			if (@class.IsStructural && @class.Triangles[0] != null && @class.Triangles[1] != null)
			{
				if (@class.Triangles[0].RegionInd % 2 == 0)
				{
					Class3058.smethod_0(class3056_0, @class.Triangles[0], preserveAloneSecondaryEdges: true);
				}
				else if (@class.Triangles[1].RegionInd % 2 == 0)
				{
					Class3058.smethod_0(class3056_0, @class.Triangles[1], preserveAloneSecondaryEdges: true);
				}
			}
		}
	}
}
