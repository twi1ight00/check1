namespace ns69;

internal sealed class Class3054
{
	public static Class3033 smethod_0(Class3033 originalEdge, Class3035 sortedEdges)
	{
		int num = sortedEdges.method_2(originalEdge);
		if (num < 0)
		{
			return null;
		}
		int num2 = num;
		bool flag = true;
		while (((sortedEdges[num2].Vertices[0].X != originalEdge.Vertices[0].X || sortedEdges[num2].Vertices[0].Y != originalEdge.Vertices[0].Y || sortedEdges[num2].Vertices[1].X != originalEdge.Vertices[1].X || sortedEdges[num2].Vertices[1].Y != originalEdge.Vertices[1].Y) && (sortedEdges[num2].Vertices[0].X != originalEdge.Vertices[1].X || sortedEdges[num2].Vertices[0].Y != originalEdge.Vertices[1].Y || sortedEdges[num2].Vertices[1].X != originalEdge.Vertices[0].X || sortedEdges[num2].Vertices[1].Y != originalEdge.Vertices[0].Y)) || sortedEdges[num2] == originalEdge)
		{
			num2++;
			if (sortedEdges.Count > num2)
			{
				if (!Class3037.smethod_3(sortedEdges[num2].EdgeLengthSqr, originalEdge.EdgeLengthSqr, 1E-07))
				{
					flag = false;
					break;
				}
				continue;
			}
			flag = false;
			break;
		}
		if (flag)
		{
			return sortedEdges[num2];
		}
		num2 = num - 1;
		if (num2 < 0)
		{
			return null;
		}
		do
		{
			if (((sortedEdges[num2].Vertices[0].X != originalEdge.Vertices[0].X || sortedEdges[num2].Vertices[0].Y != originalEdge.Vertices[0].Y || sortedEdges[num2].Vertices[1].X != originalEdge.Vertices[1].X || sortedEdges[num2].Vertices[1].Y != originalEdge.Vertices[1].Y) && (sortedEdges[num2].Vertices[0].X != originalEdge.Vertices[1].X || sortedEdges[num2].Vertices[0].Y != originalEdge.Vertices[1].Y || sortedEdges[num2].Vertices[1].X != originalEdge.Vertices[0].X || sortedEdges[num2].Vertices[1].Y != originalEdge.Vertices[0].Y)) || sortedEdges[num2] == originalEdge)
			{
				num2--;
				if (num2 < 0)
				{
					return null;
				}
				continue;
			}
			return sortedEdges[num2];
		}
		while (Class3037.smethod_3(sortedEdges[num2].EdgeLengthSqr, originalEdge.EdgeLengthSqr, 1E-07));
		return null;
	}

	public static Class3040 smethod_1(Class3059 givenPoint, Class3040 initialTriangle, out int insideStatus)
	{
		Class3040 @class = initialTriangle;
		int num = 0;
		while (!Class3037.smethod_11(givenPoint, @class, out insideStatus))
		{
			for (int i = 0; i < 3; i++)
			{
				int num2 = Class3037.smethod_7(@class.Edges[i].Vertices[0].AsPlanePoint, @class.Edges[i].Vertices[1].AsPlanePoint, @class.method_3(i).AsPlanePoint, givenPoint.AsPlanePoint);
				if (num2 == -1)
				{
					@class = @class.Edges[i].method_0(@class);
					break;
				}
			}
			num++;
		}
		return @class;
	}
}
