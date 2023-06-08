namespace ns69;

internal sealed class Class3053
{
	private Class3056 class3056_0;

	public Class3053(Class3056 triangulation)
	{
		class3056_0 = triangulation;
	}

	public void method_0()
	{
		Class3040 oneOfLastTriangle = null;
		Class3035 @class = new Class3035();
		Class3060 class2 = new Class3060();
		bool flag = false;
		for (int i = 0; i < class3056_0.Vertices.Count; i++)
		{
			Class3059 class3 = class3056_0.Vertices[i];
			if (!class3.BelongToSuperstructure)
			{
				if (!flag)
				{
					@class.method_0(class3056_0.Superstructure.Edges);
					class2.method_0(class3056_0.Superstructure.Vertices);
					flag = true;
				}
				else if (!method_2(class3, @class, class2, ref oneOfLastTriangle))
				{
					i--;
					continue;
				}
				method_1(class3, @class, class2, out oneOfLastTriangle);
			}
		}
	}

	private void method_1(Class3059 addedVertex, Class3035 polygonHoleEdges, Class3060 polygonHoleVertices, out Class3040 oneOfLastTriangle)
	{
		Class3033 @class = new Class3033(addedVertex, polygonHoleVertices[0]);
		Class3033 class2 = @class;
		class3056_0.Edges.Add(class2);
		for (int i = 1; i < polygonHoleVertices.Count; i++)
		{
			Class3033 class3;
			class3056_0.Triangles.Add(new Class3040(addedVertex, polygonHoleVertices[i - 1], polygonHoleVertices[i], class2, polygonHoleEdges[i - 1], class3 = new Class3033(addedVertex, polygonHoleVertices[i])));
			class2 = class3;
			class3056_0.Edges.Add(class2);
		}
		class3056_0.Triangles.Add(oneOfLastTriangle = new Class3040(addedVertex, polygonHoleVertices[polygonHoleVertices.Count - 1], polygonHoleVertices[0], class2, polygonHoleEdges[polygonHoleEdges.Count - 1], @class));
	}

	private bool method_2(Class3059 addedVertex, Class3035 polygonHoleEdges, Class3060 polygonHoleVertices, ref Class3040 oneOfLastTriangle)
	{
		if (oneOfLastTriangle == null)
		{
			oneOfLastTriangle = class3056_0.Triangles[0];
		}
		int insideStatus;
		Class3040 @class = (oneOfLastTriangle = Class3054.smethod_1(addedVertex, oneOfLastTriangle, out insideStatus));
		if (insideStatus == 2)
		{
			method_3(addedVertex, @class);
			return false;
		}
		polygonHoleEdges.Clear();
		polygonHoleEdges.method_3(@class.Edges);
		polygonHoleVertices.Clear();
		polygonHoleVertices.method_1(@class.Vertices);
		for (int i = 0; i < polygonHoleEdges.Count; i++)
		{
			Class3040 class2 = ((polygonHoleEdges.Count != 3) ? polygonHoleEdges[i].method_1() : polygonHoleEdges[i].method_0(@class));
			if (class2 != null)
			{
				int num = class2.method_5(polygonHoleEdges[i]);
				if (!Class3037.smethod_22(addedVertex, class2.Vertices[(num + 2) % 3], class2.Vertices[num], class2.Vertices[(num + 1) % 3]))
				{
					polygonHoleVertices.Insert(i + 1, class2.method_4(polygonHoleEdges[i]));
					Class3033 removedEdge = polygonHoleEdges[i];
					polygonHoleEdges[i] = class2.method_7(polygonHoleEdges[i]);
					polygonHoleEdges.Insert(i + 1, class2.method_7(polygonHoleEdges[i]));
					@class = null;
					Class3058.smethod_1(class3056_0, removedEdge, preserveAloneSecondaryEdges: true);
					i--;
				}
			}
		}
		if (polygonHoleEdges.Count == 3)
		{
			Class3058.smethod_0(class3056_0, @class, preserveAloneSecondaryEdges: true);
		}
		return true;
	}

	private void method_3(Class3059 addedVertex, Class3040 triangleWithPoint)
	{
		Class3059 @class = null;
		for (int i = 0; i < 3; i++)
		{
			if (triangleWithPoint.Vertices[i].method_0(addedVertex))
			{
				@class = triangleWithPoint.Vertices[i];
				break;
			}
		}
		for (int j = 0; j < class3056_0.StructuralEdges.Count; j++)
		{
			if (class3056_0.StructuralEdges[j].Vertices[0] == addedVertex)
			{
				class3056_0.StructuralEdges[j].Vertices[0] = @class;
			}
			if (class3056_0.StructuralEdges[j].Vertices[1] == addedVertex)
			{
				class3056_0.StructuralEdges[j].Vertices[1] = @class;
			}
		}
		class3056_0.Vertices.Remove(addedVertex);
	}
}
