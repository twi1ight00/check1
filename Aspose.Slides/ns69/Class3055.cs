using ns67;

namespace ns69;

internal sealed class Class3055
{
	private Class3056 class3056_0;

	private Class3060 class3060_0;

	private Class3035 class3035_0;

	private Class3035 class3035_1;

	private Class3039 class3039_0;

	public Class3055(Class3056 triangulation, Class3038 pathPoints, Enum458[] pathPTypes)
	{
		class3056_0 = triangulation;
		class3060_0 = triangulation.Vertices;
		class3035_0 = triangulation.Edges;
		method_4(pathPoints);
		method_0(pathPoints, pathPTypes);
		triangulation.StructuralEdges = class3035_1;
		triangulation.Superstructure = class3039_0;
	}

	public Class3055(Class3056 triangulation, Class3031[] triangulableContours)
	{
		class3056_0 = triangulation;
		class3060_0 = triangulation.Vertices;
		class3035_0 = triangulation.Edges;
		method_3(triangulableContours);
		method_1(triangulableContours);
		triangulation.StructuralEdges = class3035_1;
		triangulation.Superstructure = class3039_0;
	}

	public Class3055(Class3056 triangulation)
	{
		class3056_0 = triangulation;
		class3060_0 = triangulation.Vertices;
		class3035_0 = triangulation.Edges;
		method_5();
		triangulation.Superstructure = class3039_0;
	}

	private void method_0(Class3038 pathPoints, Enum458[] pathPTypes)
	{
		Class3059 @class = null;
		Class3059 class2 = null;
		int count = pathPoints.Count;
		class3035_1 = new Class3035(count);
		for (int i = 0; i < count; i++)
		{
			Class3059 class3 = new Class3059(pathPoints[i].X, pathPoints[i].Y);
			if ((pathPTypes[i] & Enum458.flag_1) == 0)
			{
				class3060_0.Add(class3);
				class2 = class3;
				@class = class2;
			}
			if ((pathPTypes[i] & Enum458.flag_5) != 0)
			{
				if (!class3.method_0(class2))
				{
					class3060_0.Add(class3);
					class3035_1.Add(new Class3033(@class, class3));
					@class = class3;
				}
				if (!@class.method_0(class2))
				{
					class3035_1.Add(new Class3033(@class, class2));
					@class = class2;
				}
			}
			else if ((pathPTypes[i] & Enum458.flag_1) != 0 && !class3.method_0(@class))
			{
				class3060_0.Add(class3);
				class3035_1.Add(new Class3033(@class, class3));
				@class = class3;
			}
		}
	}

	private void method_1(Class3031[] triangulableContours)
	{
		class3035_1 = new Class3035();
		int num = triangulableContours.Length;
		for (int i = 0; i < num; i++)
		{
			Class3059 @class = null;
			Class3059 class2 = null;
			int pointsCount = triangulableContours[i].PointsCount;
			for (int j = 0; j < pointsCount; j++)
			{
				Class3031 class3 = triangulableContours[i];
				Class3059 class4 = new Class3059(class3[j].X, class3[j].Y);
				if (class2 == null)
				{
					class3060_0.Add(class4);
					class2 = class4;
					@class = class2;
				}
				else if (j == pointsCount - 1)
				{
					if (!class4.method_0(@class) && !class4.method_0(class2))
					{
						class3060_0.Add(class4);
						class3035_1.Add(new Class3033(@class, class4));
						@class = class4;
					}
					if (!@class.method_0(class2))
					{
						class3035_1.Add(new Class3033(@class, class2));
					}
				}
				else if (!class4.method_0(@class))
				{
					class3060_0.Add(class4);
					class3035_1.Add(new Class3033(@class, class4));
					@class = class4;
				}
			}
		}
	}

	private bool method_2()
	{
		int num = 0;
		while (true)
		{
			if (num < class3035_1.Count)
			{
				if (class3035_1[num].EdgeLengthSqr == 0.0)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	private void method_3(Class3031[] triangulableContours)
	{
		Struct160 superstructureBounds = method_6(triangulableContours);
		method_9(superstructureBounds);
	}

	private void method_4(Class3038 pathPoints)
	{
		Struct160 superstructureBounds = method_7(pathPoints);
		method_9(superstructureBounds);
	}

	private void method_5()
	{
		Struct160 superstructureBounds = method_8();
		method_9(superstructureBounds);
	}

	private Struct160 method_6(Class3031[] triangulableContours)
	{
		Class3031 @class = triangulableContours[0];
		double x = @class[0].X;
		double x2 = @class[0].X;
		double y = @class[0].Y;
		double y2 = @class[0].Y;
		int num = triangulableContours.Length;
		for (int i = 0; i < num; i++)
		{
			Class3031 class2 = triangulableContours[i];
			int pointsCount = class2.PointsCount;
			for (int j = 0; j < pointsCount; j++)
			{
				if (class2[j].X < x)
				{
					x = class2[j].X;
				}
				if (class2[j].X > x2)
				{
					x2 = class2[j].X;
				}
				if (class2[j].Y < y)
				{
					y = class2[j].Y;
				}
				if (class2[j].Y > y2)
				{
					y2 = class2[j].Y;
				}
			}
		}
		return new Struct160(x, y, x2, y2);
	}

	private Struct160 method_7(Class3038 pathPoints)
	{
		double x = pathPoints[0].X;
		double x2 = pathPoints[0].X;
		double y = pathPoints[0].Y;
		double y2 = pathPoints[0].Y;
		int count = pathPoints.Count;
		for (int i = 1; i < count; i++)
		{
			if (pathPoints[i].X < x)
			{
				x = pathPoints[i].X;
			}
			if (pathPoints[i].X > x2)
			{
				x2 = pathPoints[i].X;
			}
			if (pathPoints[i].Y < y)
			{
				y = pathPoints[i].Y;
			}
			if (pathPoints[i].Y > y2)
			{
				y2 = pathPoints[i].Y;
			}
		}
		return new Struct160(x, y, x2, y2);
	}

	private Struct160 method_8()
	{
		double x = class3060_0[0].X;
		double x2 = class3060_0[0].X;
		double y = class3060_0[0].Y;
		double y2 = class3060_0[0].Y;
		int count = class3060_0.Count;
		for (int i = 1; i < count; i++)
		{
			if (class3060_0[i].X < x)
			{
				x = class3060_0[i].X;
			}
			if (class3060_0[i].X > x2)
			{
				x2 = class3060_0[i].X;
			}
			if (class3060_0[i].Y < y)
			{
				y = class3060_0[i].Y;
			}
			if (class3060_0[i].Y > y2)
			{
				y2 = class3060_0[i].Y;
			}
		}
		return new Struct160(x, y, x2, y2);
	}

	private void method_9(Struct160 superstructureBounds)
	{
		double x = superstructureBounds.Left - 50.0;
		double x2 = superstructureBounds.Right + 50.0;
		double y = superstructureBounds.Top - 50.0;
		double y2 = superstructureBounds.Bottom + 50.0;
		Class3059 @class;
		class3060_0.Add(@class = new Class3059(x, y));
		Class3059 class2;
		class3060_0.Add(class2 = new Class3059(x2, y));
		Class3059 class3;
		class3060_0.Add(class3 = new Class3059(x2, y2));
		Class3059 class4;
		class3060_0.Add(class4 = new Class3059(x, y2));
		Class3033 edge;
		class3035_0.Add(edge = new Class3033(@class, class2));
		Class3033 edge2;
		class3035_0.Add(edge2 = new Class3033(class2, class3));
		Class3033 edge3;
		class3035_0.Add(edge3 = new Class3033(class3, class4));
		Class3033 edge4;
		class3035_0.Add(edge4 = new Class3033(class4, @class));
		class3039_0 = new Class3039();
		class3039_0.Vertices.Add(@class);
		class3039_0.Vertices.Add(class2);
		class3039_0.Vertices.Add(class3);
		class3039_0.Vertices.Add(class4);
		class3039_0.Edges.Add(edge);
		class3039_0.Edges.Add(edge2);
		class3039_0.Edges.Add(edge3);
		class3039_0.Edges.Add(edge4);
		method_10();
	}

	private void method_10()
	{
		int count = class3039_0.Vertices.Count;
		for (int i = 0; i < count; i++)
		{
			class3039_0.Vertices[i].BelongToSuperstructure = true;
		}
	}
}
