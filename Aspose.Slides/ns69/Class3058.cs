namespace ns69;

internal sealed class Class3058
{
	public static void smethod_0(Class3056 triangulation, Class3040 removedTriangle, bool preserveAloneSecondaryEdges)
	{
		for (int i = 0; i < 3; i++)
		{
			if (removedTriangle == removedTriangle.Edges[i].Triangles[0])
			{
				removedTriangle.Edges[i].Triangles[0] = null;
				if (!preserveAloneSecondaryEdges && removedTriangle.Edges[i].Triangles[1] == null)
				{
					triangulation.Edges.Remove(removedTriangle.Edges[i]);
				}
			}
			else if (removedTriangle == removedTriangle.Edges[i].Triangles[1])
			{
				removedTriangle.Edges[i].Triangles[1] = null;
				if (!preserveAloneSecondaryEdges && removedTriangle.Edges[i].Triangles[0] == null)
				{
					triangulation.Edges.Remove(removedTriangle.Edges[i]);
				}
			}
		}
		for (int j = 0; j < 3; j++)
		{
			removedTriangle.Vertices[j].Triangles.Remove(removedTriangle);
		}
		triangulation.Triangles.Remove(removedTriangle);
	}

	public static void smethod_1(Class3056 triangulation, Class3033 removedEdge, bool preserveAloneSecondaryEdges)
	{
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				if (removedEdge.Triangles[i] == null)
				{
					break;
				}
				if (removedEdge.Triangles[i].Edges[j] == removedEdge)
				{
					continue;
				}
				if (removedEdge.Triangles[i].Edges[j].Triangles[0] == removedEdge.Triangles[i])
				{
					removedEdge.Triangles[i].Edges[j].Triangles[0] = null;
					if (!preserveAloneSecondaryEdges && removedEdge.Triangles[i].Edges[j].Triangles[1] == null)
					{
						triangulation.Edges.Remove(removedEdge.Triangles[i].Edges[j]);
					}
				}
				else if (removedEdge.Triangles[i].Edges[j].Triangles[1] == removedEdge.Triangles[i])
				{
					removedEdge.Triangles[i].Edges[j].Triangles[1] = null;
					if (!preserveAloneSecondaryEdges && removedEdge.Triangles[i].Edges[j].Triangles[0] == null)
					{
						triangulation.Edges.Remove(removedEdge.Triangles[i].Edges[j]);
					}
				}
			}
			for (int k = 0; k < 3; k++)
			{
				if (removedEdge.Triangles[i] != null)
				{
					removedEdge.Triangles[i].Vertices[k].Triangles.Remove(removedEdge.Triangles[i]);
				}
			}
			triangulation.Triangles.Remove(removedEdge.Triangles[i]);
		}
		triangulation.Edges.Remove(removedEdge);
	}
}
