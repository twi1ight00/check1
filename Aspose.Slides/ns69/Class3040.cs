using System;
using ns67;

namespace ns69;

internal sealed class Class3040
{
	private Class3059[] class3059_0;

	private Class3033[] class3033_0;

	private Class3032 class3032_0;

	private int int_0;

	public Class3059[] Vertices => class3059_0;

	public Class3033[] Edges => class3033_0;

	public Class3032 CircumCircle
	{
		get
		{
			if (class3032_0 == null)
			{
				class3032_0 = new Class3032(this);
			}
			return class3032_0;
		}
	}

	public int RegionInd
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public Struct159[] AsPlanePoints => new Struct159[3]
	{
		class3059_0[0].AsPlanePoint,
		class3059_0[1].AsPlanePoint,
		class3059_0[2].AsPlanePoint
	};

	public Class3040(Class3059 vertex0, Class3059 vertex1, Class3059 vertex2, Class3033 edge0, Class3033 edge1, Class3033 edge2)
	{
		class3059_0 = new Class3059[3];
		if ((vertex0.X - vertex2.X) * (vertex1.Y - vertex2.Y) - (vertex1.X - vertex2.X) * (vertex0.Y - vertex2.Y) < 0.0)
		{
			Vertices[0] = vertex0;
			Vertices[1] = vertex1;
			Vertices[2] = vertex2;
		}
		else
		{
			Vertices[0] = vertex0;
			Vertices[1] = vertex2;
			Vertices[2] = vertex1;
		}
		for (int i = 0; i < 3; i++)
		{
			Vertices[i].Triangles.Add(this);
		}
		class3033_0 = new Class3033[3];
		Edges[0] = edge0;
		Edges[1] = edge1;
		Edges[2] = edge2;
		for (int j = 0; j < 3; j++)
		{
			if (Edges[j].Triangles[0] == null)
			{
				Edges[j].Triangles[0] = this;
			}
			else if (Edges[j].Triangles[1] == null)
			{
				Edges[j].Triangles[1] = this;
			}
		}
		for (int k = 1; k < 3; k++)
		{
			if (Vertices[0] == Edges[0].Vertices[0] && Vertices[1] == Edges[0].Vertices[1])
			{
				break;
			}
			if (Vertices[0] == Edges[0].Vertices[1] && Vertices[1] == Edges[0].Vertices[0])
			{
				break;
			}
			Class3033 @class = Edges[0];
			Edges[0] = Edges[k];
			Edges[k] = @class;
		}
		if ((Vertices[1] != Edges[1].Vertices[0] || Vertices[2] != Edges[1].Vertices[1]) && (Vertices[1] != Edges[1].Vertices[1] || Vertices[2] != Edges[1].Vertices[0]))
		{
			Class3033 @class = Edges[1];
			Edges[1] = Edges[2];
			Edges[2] = @class;
		}
		class3032_0 = null;
		RegionInd = -1;
	}

	public bool method_0(Class3059 givenPoint, out double diff)
	{
		double num = givenPoint.X - CircumCircle.XCenter;
		double num2 = givenPoint.Y - CircumCircle.YCenter;
		diff = Math.Abs(num * num + num2 * num2 - CircumCircle.RadiusSqr);
		return num * num + num2 * num2 < CircumCircle.RadiusSqr;
	}

	public Class3033 method_1(Class3059 vertexA, Class3059 vertexB)
	{
		if (Vertices[0] != vertexA && Vertices[0] != vertexB)
		{
			if ((Vertices[1] == vertexA && Vertices[2] == vertexB) || (Vertices[2] == vertexA && Vertices[1] == vertexB))
			{
				return Edges[1];
			}
		}
		else if (Vertices[1] != vertexA && Vertices[1] != vertexB)
		{
			if ((Vertices[0] == vertexA && Vertices[2] == vertexB) || (Vertices[2] == vertexA && Vertices[0] == vertexB))
			{
				return Edges[2];
			}
		}
		else if (Vertices[2] != vertexA && Vertices[2] != vertexB && ((Vertices[1] == vertexA && Vertices[0] == vertexB) || (Vertices[0] == vertexA && Vertices[1] == vertexB)))
		{
			return Edges[0];
		}
		return null;
	}

	public Class3033 method_2(Class3059 vertex)
	{
		int i;
		for (i = 0; i < 3 && Vertices[i] != vertex; i++)
		{
		}
		return Edges[(i + 1) % 3];
	}

	public Class3059 method_3(int iEdge)
	{
		return Vertices[(iEdge + 2) % 3];
	}

	public Class3059 method_4(Class3033 edge)
	{
		int i;
		for (i = 0; i < 3 && Edges[i] != edge; i++)
		{
		}
		return Vertices[(i + 2) % 3];
	}

	public int method_5(Class3033 edge)
	{
		int i;
		for (i = 0; i < 3 && Edges[i] != edge; i++)
		{
		}
		return (i + 2) % 3;
	}

	public Class3040 method_6(Class3033 edge)
	{
		return edge.method_0(this);
	}

	public Class3033 method_7(Class3033 edge)
	{
		int i;
		for (i = 0; i < 3 && Edges[i] != edge; i++)
		{
		}
		return Edges[(i + 1) % 3];
	}
}
