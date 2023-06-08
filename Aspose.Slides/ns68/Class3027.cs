using ns67;
using ns69;

namespace ns68;

internal sealed class Class3027
{
	private Class3013 class3013_0;

	private Class3028 class3028_0;

	private Class2994 class2994_0;

	public Class3028 Step2Primitives => class3028_0;

	public Class3027(Class2994 parentStructuralEdgeSegment)
	{
		class3028_0 = new Class3028();
		class2994_0 = parentStructuralEdgeSegment;
		class3013_0 = null;
	}

	public void method_0()
	{
		class3013_0 = class2994_0.Step1BuilderCache.Cell;
		Class3013 @class = new Class3013();
		for (int i = 1; i <= class3013_0.Count - 2; i++)
		{
			Class3012 class2 = class3013_0[i];
			if (!class2.bool_2)
			{
				@class.Clear();
				method_5(i, class2, @class);
				method_4(class2, @class);
				method_2(ref i, class2, @class);
			}
		}
		class3013_0[0].class3012_2 = class3013_0[class3013_0.Count - 1];
		class3013_0[0].double_0 = 0.0;
		method_1();
	}

	private void method_1()
	{
		int count = class3013_0.Count;
		for (int i = 1; i <= count - 2; i++)
		{
			if (class3013_0[i].class3012_1 != null)
			{
				class3028_0.Add(new Class3025(class3013_0[i - 1].double_0, class3013_0[i].double_0, class3013_0[i].struct159_0, class3013_0[i].class3012_1.struct159_0, class3013_0[i - 1].struct159_0, class3013_0[i - 1].class3012_2.struct159_0));
			}
			else if (class3013_0[i].bool_0)
			{
				class3028_0.Add(new Class3026(class3013_0[i - 1].double_0, class3013_0[i].double_0, class3013_0[i].struct159_0, class3013_0[i - 1].struct159_0, class3013_0[i - 1].class3012_2.struct159_0));
			}
		}
	}

	private void method_2(ref int cellVertexIndex, Class3012 currentEmitterCellVertex, Class3013 intersectsTrack)
	{
		double double_ = Class2990.smethod_4(currentEmitterCellVertex.struct159_0, class2994_0.A, class2994_0.B);
		if (intersectsTrack.Count == 2 && intersectsTrack[0] == currentEmitterCellVertex && !intersectsTrack[1].bool_1)
		{
			method_3(intersectsTrack[1], ref cellVertexIndex);
			intersectsTrack[0].class3012_1 = intersectsTrack[1];
			intersectsTrack[0].class3012_2 = intersectsTrack[1];
			intersectsTrack[0].double_0 = double_;
			intersectsTrack[1].bool_2 = true;
		}
		else if (intersectsTrack.Count == 2 && intersectsTrack[1] == currentEmitterCellVertex && !intersectsTrack[0].bool_1)
		{
			method_3(intersectsTrack[0], ref cellVertexIndex);
			intersectsTrack[0].class3012_1 = intersectsTrack[1];
			intersectsTrack[0].class3012_2 = intersectsTrack[1];
			intersectsTrack[0].double_0 = double_;
		}
		else if (intersectsTrack.Count == 3 && intersectsTrack[1] == currentEmitterCellVertex && !intersectsTrack[0].bool_1 && !intersectsTrack[2].bool_1)
		{
			method_3(intersectsTrack[0], ref cellVertexIndex);
			method_3(intersectsTrack[2], ref cellVertexIndex);
			intersectsTrack[0].class3012_1 = intersectsTrack[2];
			intersectsTrack[0].class3012_2 = intersectsTrack[1];
			intersectsTrack[0].double_0 = double_;
			intersectsTrack[1].class3012_2 = intersectsTrack[2];
			intersectsTrack[1].double_0 = double_;
			intersectsTrack[2].bool_2 = true;
		}
		else if (intersectsTrack.Count == 1 && intersectsTrack[0] == currentEmitterCellVertex)
		{
			intersectsTrack[0].bool_0 = true;
			intersectsTrack[0].double_0 = double_;
		}
		else if (intersectsTrack.Count == 3 && intersectsTrack[0] == currentEmitterCellVertex && intersectsTrack[1].bool_1)
		{
			method_3(intersectsTrack[2], ref cellVertexIndex);
			intersectsTrack[0].class3012_1 = intersectsTrack[2];
			intersectsTrack[0].double_0 = double_;
			intersectsTrack[1].class3012_2 = intersectsTrack[2];
			intersectsTrack[1].double_0 = double_;
			intersectsTrack[1].bool_2 = true;
			intersectsTrack[2].bool_2 = true;
		}
		else if (intersectsTrack.Count == 3 && intersectsTrack[1] == currentEmitterCellVertex && intersectsTrack[2].bool_1)
		{
			method_3(intersectsTrack[0], ref cellVertexIndex);
			intersectsTrack[0].class3012_1 = intersectsTrack[2];
			intersectsTrack[0].class3012_2 = intersectsTrack[1];
			intersectsTrack[0].double_0 = double_;
			intersectsTrack[2].bool_2 = true;
		}
		else if (intersectsTrack.Count == 4 && intersectsTrack[1] == currentEmitterCellVertex && intersectsTrack[2].bool_1)
		{
			method_3(intersectsTrack[0], ref cellVertexIndex);
			method_3(intersectsTrack[3], ref cellVertexIndex);
			intersectsTrack[0].class3012_1 = intersectsTrack[3];
			intersectsTrack[0].class3012_2 = intersectsTrack[1];
			intersectsTrack[0].double_0 = double_;
			intersectsTrack[2].class3012_2 = intersectsTrack[3];
			intersectsTrack[2].double_0 = double_;
			intersectsTrack[2].bool_2 = true;
			intersectsTrack[3].bool_2 = true;
		}
		else if (intersectsTrack.Count == 2 && intersectsTrack[0] == currentEmitterCellVertex && intersectsTrack[1].bool_1)
		{
			intersectsTrack[0].class3012_1 = intersectsTrack[1];
			intersectsTrack[0].double_0 = double_;
			intersectsTrack[1].bool_2 = true;
		}
		else if ((intersectsTrack.Count != 3 || intersectsTrack[1] != currentEmitterCellVertex || !intersectsTrack[0].bool_1) && (intersectsTrack.Count != 3 || intersectsTrack[2] != currentEmitterCellVertex || !intersectsTrack[1].bool_1) && (intersectsTrack.Count != 4 || intersectsTrack[2] != currentEmitterCellVertex || !intersectsTrack[1].bool_1) && intersectsTrack.Count == 2 && intersectsTrack[1] == currentEmitterCellVertex)
		{
			_ = intersectsTrack[0].bool_1;
		}
	}

	private void method_3(Class3012 intersectsTrackItem, ref int cellVertexIndex)
	{
		if (intersectsTrackItem.class3012_0 != null)
		{
			int num = class3013_0.IndexOf(intersectsTrackItem.class3012_0);
			class3013_0.Insert(num + 1, intersectsTrackItem);
			if (num + 1 <= cellVertexIndex)
			{
				cellVertexIndex++;
			}
		}
	}

	private void method_4(Class3012 currentEmitterCellVertex, Class3013 intersectsTrack)
	{
		int num = 0;
		while (num <= intersectsTrack.Count - 2 && intersectsTrack[num] != currentEmitterCellVertex && intersectsTrack[num + 1] != currentEmitterCellVertex && !intersectsTrack[num + 1].bool_1)
		{
			intersectsTrack.method_5(num, 2);
			num--;
			num++;
		}
		int num2 = intersectsTrack.Count - 1;
		while (num2 >= 1 && intersectsTrack[num2] != currentEmitterCellVertex && intersectsTrack[num2 - 1] != currentEmitterCellVertex && !intersectsTrack[num2 - 1].bool_1)
		{
			intersectsTrack.method_5(num2 - 1, 2);
			num2--;
			num2--;
		}
	}

	private void method_5(int cellVertexIndex, Class3012 currentEmitterCellVertex, Class3013 intersectsTrack)
	{
		Struct159 lineB = new Struct159(currentEmitterCellVertex.X + class2994_0.AB.X, currentEmitterCellVertex.Y + class2994_0.AB.Y);
		for (int i = 0; i <= class3013_0.Count - 2; i++)
		{
			if (i == cellVertexIndex - 1)
			{
				continue;
			}
			if (i == cellVertexIndex)
			{
				intersectsTrack.Add(currentEmitterCellVertex);
				continue;
			}
			Class3012 @class = class3013_0[i];
			Class3012 class2 = class3013_0[i + 1];
			if (Class3037.smethod_15(@class.struct159_0, class2.struct159_0, currentEmitterCellVertex.struct159_0, lineB, out var intrsct) == 1)
			{
				if (i + 1 == cellVertexIndex - 1 && Class3037.smethod_6(intrsct, class2.struct159_0, 1E-07))
				{
					intersectsTrack.Add(class2);
					class2.bool_1 = true;
				}
				else if (i == cellVertexIndex + 1 && Class3037.smethod_6(intrsct, @class.struct159_0, 1E-07))
				{
					intersectsTrack.Add(@class);
					@class.bool_1 = true;
				}
				else if (Class3037.smethod_6(class2.struct159_0, intrsct, 1E-07))
				{
					intersectsTrack.Add(class2);
				}
				else if (!Class3037.smethod_6(@class.struct159_0, intrsct, 1E-07))
				{
					intersectsTrack.Add(new Class3012(intrsct, @class));
				}
			}
		}
	}
}
