namespace ns69;

internal sealed class Class3052
{
	private Class3056 class3056_0;

	public Class3052(Class3056 triangulation)
	{
		class3056_0 = triangulation;
	}

	public void method_0()
	{
		class3056_0.Edges.method_1(new Class3033.Class3034());
		for (int i = 0; i < class3056_0.StructuralEdges.Count; i++)
		{
			Class3033 @class = class3056_0.StructuralEdges[i];
			Class3033 class2 = Class3054.smethod_0(@class, class3056_0.Edges);
			if (class2 != null)
			{
				class2.IsStructural = true;
			}
			if (class2 == null)
			{
				Class3050 class3 = new Class3050(class3056_0);
				Class3047 class4 = new Class3049(@class.Vertices[0]);
				do
				{
					class4 = method_1(@class, class4, class3);
				}
				while (class4.IntersectedVertex != @class.Vertices[1]);
				if (method_2(class3.EdgesToAdd, class3.VerticesToAdd, out var splitVertex))
				{
					Class3033 value = new Class3033(@class.Vertices[0], splitVertex);
					Class3033 insertedEdge = new Class3033(splitVertex, @class.Vertices[1]);
					class3056_0.StructuralEdges[i] = value;
					class3056_0.StructuralEdges.Insert(i + 1, insertedEdge);
					i--;
				}
				else
				{
					Class3041 trianglesForConditionCheck = class3.method_0();
					method_11(trianglesForConditionCheck);
				}
			}
		}
		method_3();
	}

	private Class3047 method_1(Class3033 addedEdge, Class3047 intersectionContext, Class3050 triangulationStructureModification)
	{
		if (intersectionContext is Class3049)
		{
			return method_4((Class3049)intersectionContext, addedEdge, triangulationStructureModification);
		}
		if (intersectionContext is Class3048)
		{
			return method_8((Class3048)intersectionContext, addedEdge, triangulationStructureModification);
		}
		return null;
	}

	private bool method_2(Class3035 edgesToAdd, Class3060 verticesToAdd, out Class3059 splitVertex)
	{
		int num = 0;
		Class3033 @class;
		while (true)
		{
			if (num < edgesToAdd.Count)
			{
				@class = edgesToAdd[num];
				if (@class.EdgeLengthSqr == 0.0)
				{
					if (verticesToAdd.IndexOf(@class.Vertices[0]) < 0)
					{
						splitVertex = @class.Vertices[0];
						return true;
					}
					if (verticesToAdd.IndexOf(@class.Vertices[1]) < 0)
					{
						break;
					}
				}
				num++;
				continue;
			}
			splitVertex = null;
			return false;
		}
		splitVertex = @class.Vertices[1];
		return true;
	}

	private void method_3()
	{
		Class3041 @class = new Class3041();
		for (int i = 0; i < class3056_0.Edges.Count; i++)
		{
			Class3033 class2 = class3056_0.Edges[i];
			if (class2.IsStructural || class2.Triangles[0] == null || class2.Triangles[1] == null)
			{
				continue;
			}
			Class3040 class3 = class2.Triangles[1];
			int num = class3.method_5(class2);
			Class3059 p = class2.Triangles[0].method_4(class2);
			Class3059 p2 = class3.Vertices[(num + 2) % 3];
			Class3059 p3 = class3.Vertices[num];
			Class3059 p4 = class3.Vertices[(num + 1) % 3];
			if (!Class3037.smethod_22(p, p2, p3, p4))
			{
				if (@class.IndexOf(class2.Triangles[0]) < 0)
				{
					@class.Add(class2.Triangles[0]);
				}
				if (@class.IndexOf(class2.Triangles[1]) < 0)
				{
					@class.Add(class2.Triangles[1]);
				}
			}
		}
		method_11(@class);
	}

	private Class3047 method_4(Class3049 currentContext, Class3033 addedEdge, Class3050 triangulationStructureModification)
	{
		Class3059 intersectedVertex = currentContext.IntersectedVertex;
		Class3059 intersect = null;
		Class3033 @class = null;
		int i;
		for (i = 0; i < intersectedVertex.Triangles.Count; i++)
		{
			@class = intersectedVertex.Triangles[i].method_2(intersectedVertex);
			if (Class3037.smethod_12(intersectedVertex, addedEdge.Vertices[1], @class.Vertices[0], @class.Vertices[1], out intersect) == 1)
			{
				break;
			}
		}
		Class3040 intersectedTriangle = intersectedVertex.Triangles[i];
		Class3059 class2 = method_7(@class, intersect);
		if (class2 != null)
		{
			return method_6(intersectedVertex, class2, intersectedTriangle);
		}
		return method_5(intersectedVertex, @class, intersect, intersectedTriangle, triangulationStructureModification);
	}

	private Class3048 method_5(Class3059 currentContextIntersectedVertex, Class3033 nextContextIntersectedEdge, Class3059 nextContextIntersectedVertex, Class3040 intersectedTriangle, Class3050 triangulationStructureModification)
	{
		triangulationStructureModification.VerticesToAdd.Add(nextContextIntersectedVertex);
		Class3033 @class;
		triangulationStructureModification.EdgesToAdd.Add(@class = new Class3033(nextContextIntersectedVertex, currentContextIntersectedVertex));
		@class.IsStructural = true;
		Class3033 class2;
		triangulationStructureModification.EdgesToAdd.Add(class2 = new Class3033(nextContextIntersectedVertex, nextContextIntersectedEdge.Vertices[0]));
		class2.IsStructural = nextContextIntersectedEdge.IsStructural;
		Class3033 class3;
		triangulationStructureModification.EdgesToAdd.Add(class3 = new Class3033(nextContextIntersectedVertex, nextContextIntersectedEdge.Vertices[1]));
		class3.IsStructural = nextContextIntersectedEdge.IsStructural;
		triangulationStructureModification.TrianglesToAdd.Add(new Class3043(currentContextIntersectedVertex, nextContextIntersectedVertex, nextContextIntersectedEdge.Vertices[0], @class, class2, intersectedTriangle.method_1(currentContextIntersectedVertex, nextContextIntersectedEdge.Vertices[0])));
		triangulationStructureModification.TrianglesToAdd.Add(new Class3043(currentContextIntersectedVertex, nextContextIntersectedVertex, nextContextIntersectedEdge.Vertices[1], @class, class3, intersectedTriangle.method_1(currentContextIntersectedVertex, nextContextIntersectedEdge.Vertices[1])));
		triangulationStructureModification.EdgesToDel.Add(nextContextIntersectedEdge);
		triangulationStructureModification.TrianglesToDel.Add(intersectedTriangle);
		return new Class3048(nextContextIntersectedEdge, nextContextIntersectedVertex, class2, class3, nextContextIntersectedEdge.method_0(intersectedTriangle));
	}

	private Class3049 method_6(Class3059 currentContextIntersectedVertex, Class3059 existentVertexForNextContext, Class3040 intersectedTriangle)
	{
		Class3049 @class = new Class3049(existentVertexForNextContext);
		Class3033 class2 = intersectedTriangle.method_1(currentContextIntersectedVertex, @class.IntersectedVertex);
		class2.IsStructural = true;
		return @class;
	}

	private Class3059 method_7(Class3033 edgeTestedToBeIntersected, Class3059 nextContextIntersectedVertex)
	{
		if (Class3037.smethod_5(edgeTestedToBeIntersected.Vertices[0].AsPlanePoint, nextContextIntersectedVertex.AsPlanePoint, 1E-07))
		{
			return edgeTestedToBeIntersected.Vertices[0];
		}
		if (Class3037.smethod_5(edgeTestedToBeIntersected.Vertices[1].AsPlanePoint, nextContextIntersectedVertex.AsPlanePoint, 1E-07))
		{
			return edgeTestedToBeIntersected.Vertices[1];
		}
		return null;
	}

	private Class3047 method_8(Class3048 currentContext, Class3033 addedEdge, Class3050 triangulationStructureModification)
	{
		Class3040 triangleMustBeSplit = currentContext.TriangleMustBeSplit;
		int i;
		for (i = 0; i < 3 && triangleMustBeSplit.Edges[i] != currentContext.IntersectedEdge; i++)
		{
		}
		Class3033 @class = null;
		Class3059 intersect = null;
		Class3059 a = addedEdge.Vertices[0];
		Class3059 b = addedEdge.Vertices[1];
		for (int j = 1; j <= 2; j++)
		{
			@class = triangleMustBeSplit.Edges[(i + j) % 3];
			if (Class3037.smethod_12(a, b, @class.Vertices[0], @class.Vertices[1], out intersect) == 1)
			{
				break;
			}
		}
		Class3059 class2 = method_7(@class, intersect);
		if (class2 != null)
		{
			return method_9(currentContext, class2, triangulationStructureModification);
		}
		return method_10(currentContext, @class, intersect, triangulationStructureModification);
	}

	private Class3049 method_9(Class3048 currentContext, Class3059 existentVertexForNextContext, Class3050 triangulationStructureModification)
	{
		Class3040 triangleMustBeSplit = currentContext.TriangleMustBeSplit;
		Class3033 intersectedEdge = currentContext.IntersectedEdge;
		Class3059 intersectedVertex = currentContext.IntersectedVertex;
		Class3033 @class;
		triangulationStructureModification.EdgesToAdd.Add(@class = new Class3033(intersectedVertex, existentVertexForNextContext));
		@class.IsStructural = true;
		Class3033 edge;
		Class3033 edge2;
		if (currentContext.EdgeV0S0.Vertices[0] != intersectedEdge.Vertices[0] && currentContext.EdgeV0S0.Vertices[1] != intersectedEdge.Vertices[0])
		{
			edge = currentContext.EdgeV0S1;
			edge2 = currentContext.EdgeV0S0;
		}
		else
		{
			edge = currentContext.EdgeV0S0;
			edge2 = currentContext.EdgeV0S1;
		}
		triangulationStructureModification.TrianglesToAdd.Add(new Class3043(existentVertexForNextContext, intersectedVertex, intersectedEdge.Vertices[0], @class, edge, triangleMustBeSplit.method_1(existentVertexForNextContext, intersectedEdge.Vertices[0])));
		triangulationStructureModification.TrianglesToAdd.Add(new Class3043(existentVertexForNextContext, intersectedVertex, intersectedEdge.Vertices[1], @class, edge2, triangleMustBeSplit.method_1(existentVertexForNextContext, intersectedEdge.Vertices[1])));
		triangulationStructureModification.TrianglesToDel.Add(triangleMustBeSplit);
		return new Class3049(existentVertexForNextContext);
	}

	private Class3048 method_10(Class3048 currentContext, Class3033 nextContextIntersectedEdge, Class3059 nextContextIntersectedVertex, Class3050 triangulationStructureModification)
	{
		Class3040 triangleMustBeSplit = currentContext.TriangleMustBeSplit;
		Class3033 intersectedEdge = currentContext.IntersectedEdge;
		Class3059 @class = triangleMustBeSplit.method_4(nextContextIntersectedEdge);
		Class3059 class2 = triangleMustBeSplit.method_4(intersectedEdge);
		Class3059 class3 = null;
		for (int i = 0; i < 3; i++)
		{
			if (triangleMustBeSplit.Vertices[i] != @class && triangleMustBeSplit.Vertices[i] != class2)
			{
				class3 = triangleMustBeSplit.Vertices[i];
				break;
			}
		}
		Class3033 edge = null;
		Class3033 class4 = null;
		Class3033 edgeV0S = currentContext.EdgeV0S0;
		Class3033 edgeV0S2 = currentContext.EdgeV0S1;
		if (edgeV0S.Vertices[0] != class3 && edgeV0S.Vertices[1] != class3)
		{
			if (edgeV0S2.Vertices[0] == class3 || edgeV0S2.Vertices[1] == class3)
			{
				edge = edgeV0S2;
				class4 = edgeV0S;
			}
		}
		else
		{
			edge = edgeV0S;
			class4 = edgeV0S2;
		}
		Class3059 intersectedVertex = currentContext.IntersectedVertex;
		triangulationStructureModification.VerticesToAdd.Add(nextContextIntersectedVertex);
		Class3033 class5;
		triangulationStructureModification.EdgesToAdd.Add(class5 = new Class3033(class3, nextContextIntersectedVertex));
		class5.IsStructural = nextContextIntersectedEdge.IsStructural;
		Class3033 class6;
		triangulationStructureModification.EdgesToAdd.Add(class6 = new Class3033(intersectedVertex, nextContextIntersectedVertex));
		class6.IsStructural = true;
		Class3033 class7;
		triangulationStructureModification.EdgesToAdd.Add(class7 = new Class3033(nextContextIntersectedVertex, class2));
		class7.IsStructural = nextContextIntersectedEdge.IsStructural;
		if (Class3037.smethod_22(@class, class2, nextContextIntersectedVertex, intersectedVertex))
		{
			Class3033 class8;
			triangulationStructureModification.EdgesToAdd.Add(class8 = new Class3033(intersectedVertex, class2));
			triangulationStructureModification.TrianglesToAdd.Add(new Class3043(@class, class2, intersectedVertex, triangleMustBeSplit.method_2(class3), class8, class4));
			triangulationStructureModification.TrianglesToAdd.Add(new Class3043(class2, nextContextIntersectedVertex, intersectedVertex, class7, class6, class8));
		}
		else if (Class3037.smethod_22(class2, @class, intersectedVertex, nextContextIntersectedVertex))
		{
			Class3033 class8;
			triangulationStructureModification.EdgesToAdd.Add(class8 = new Class3033(nextContextIntersectedVertex, @class));
			triangulationStructureModification.TrianglesToAdd.Add(new Class3043(@class, class2, nextContextIntersectedVertex, triangleMustBeSplit.method_2(class3), class8, class7));
			triangulationStructureModification.TrianglesToAdd.Add(new Class3043(@class, nextContextIntersectedVertex, intersectedVertex, class4, class6, class8));
		}
		triangulationStructureModification.EdgesToDel.Add(nextContextIntersectedEdge);
		triangulationStructureModification.TrianglesToDel.Add(triangleMustBeSplit);
		triangulationStructureModification.TrianglesToAdd.Add(new Class3043(intersectedVertex, nextContextIntersectedVertex, class3, edge, class6, class5));
		return new Class3048(nextContextIntersectedEdge, nextContextIntersectedVertex, class7, class5, nextContextIntersectedEdge.method_0(triangleMustBeSplit));
	}

	private void method_11(Class3041 trianglesForConditionCheck)
	{
		for (int i = 0; i < trianglesForConditionCheck.Count; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				Class3033 @class = trianglesForConditionCheck[i].Edges[j];
				if (@class.IsStructural || @class.Triangles[0] == null || @class.Triangles[1] == null)
				{
					continue;
				}
				Class3040 class2 = @class.method_0(trianglesForConditionCheck[i]);
				int num = trianglesForConditionCheck[i].method_5(@class);
				int num2 = class2.method_5(@class);
				Class3059 class3 = trianglesForConditionCheck[i].Vertices[num];
				Class3059 class4 = class2.Vertices[(num2 + 2) % 3];
				Class3059 class5 = class2.Vertices[num2];
				Class3059 class6 = class2.Vertices[(num2 + 1) % 3];
				Class3033 edge = trianglesForConditionCheck[i].method_2(class6);
				Class3033 edge2 = class2.method_2(class6);
				Class3033 edge3 = class2.method_2(class4);
				Class3033 edge4 = trianglesForConditionCheck[i].method_2(class4);
				if (!Class3037.smethod_22(class3, class4, class5, class6))
				{
					Class3033 class7 = new Class3033(class3, class5);
					Class3058.smethod_1(class3056_0, @class, preserveAloneSecondaryEdges: true);
					trianglesForConditionCheck.Remove(@class.Triangles[0]);
					trianglesForConditionCheck.Remove(@class.Triangles[1]);
					class3056_0.Edges.method_4(class7);
					Class3040 triangle;
					class3056_0.Triangles.Add(triangle = new Class3040(class3, class4, class5, edge, edge2, class7));
					trianglesForConditionCheck.Add(triangle);
					class3056_0.Triangles.Add(triangle = new Class3040(class5, class6, class3, edge3, edge4, class7));
					trianglesForConditionCheck.Add(triangle);
					if (i > 0)
					{
						i -= 2;
					}
					break;
				}
			}
		}
		trianglesForConditionCheck.Clear();
	}
}
