using System.Drawing;
using ns67;

namespace ns69;

internal class Class3056
{
	private Class3060 class3060_0;

	private Class3041 class3041_0;

	private Class3035 class3035_0;

	private Class3035 class3035_1;

	private Class3039 class3039_0;

	public Class3060 Vertices => class3060_0;

	public Class3035 Edges => class3035_0;

	public Class3035 StructuralEdges
	{
		get
		{
			return class3035_1;
		}
		set
		{
			class3035_1 = value;
		}
	}

	public Class3041 Triangles => class3041_0;

	public Class3039 Superstructure
	{
		get
		{
			return class3039_0;
		}
		set
		{
			class3039_0 = value;
		}
	}

	public Class3056()
	{
		class3060_0 = new Class3060();
		class3035_0 = new Class3035();
		class3041_0 = new Class3041();
		class3035_1 = null;
		class3039_0 = null;
	}

	public Class3056(Class3060 vertices, Class3035 structuralEdges)
	{
		if (vertices.Count >= 3)
		{
			class3060_0 = vertices;
			class3035_0 = new Class3035();
			class3041_0 = new Class3041();
			class3035_1 = structuralEdges;
			new Class3055(this);
			Class3051.smethod_0(this);
		}
	}

	public Class3056(Class3062 dpath)
		: this()
	{
		PointF[] pathPoints = dpath.PathPoints;
		Class3038 @class = new Class3038(dpath.PathPoints.Length);
		int num = dpath.PathPoints.Length;
		for (int i = 0; i < num; i++)
		{
			@class.Add(new Struct159(pathPoints[i].X, pathPoints[i].Y));
		}
		Enum458[] pathTypes = dpath.PathTypes;
		if (num >= 3)
		{
			new Class3055(this, @class, pathTypes);
			Class3051.smethod_0(this);
		}
	}

	public Class3056(Class3031[] contours)
		: this()
	{
		if (contours.Length > 0)
		{
			new Class3055(this, contours);
			Class3051.smethod_0(this);
		}
	}

	public Class3057 method_0()
	{
		Class3057 @class = new Class3057();
		@class.class3060_0.Capacity = class3060_0.Capacity;
		int count = Vertices.Count;
		for (int i = 0; i < count; i++)
		{
			Vertices[i].ReflectedVertices = new Class3059[1];
			@class.class3060_0.Add(Vertices[i].ReflectedVertices[0] = new Class3059(Vertices[i]));
		}
		@class.class3035_0.Capacity = class3035_0.Capacity;
		int count2 = Edges.Count;
		for (int j = 0; j < count2; j++)
		{
			Class3035 class2 = @class.class3035_0;
			Class3033 edge = (Edges[j].ReflectedEdge = new Class3033(Edges[j].Vertices[0].ReflectedVertices[0], Edges[j].Vertices[1].ReflectedVertices[0]));
			class2.Add(edge);
			Edges[j].ReflectedEdge.IsStructural = Edges[j].IsStructural;
		}
		@class.class3035_1 = new Class3035(class3035_1.Capacity);
		count2 = class3035_1.Count;
		for (int k = 0; k < count2; k++)
		{
			Class3035 class4 = @class.class3035_1;
			Class3033 edge2 = (class3035_1[k].ReflectedEdge = new Class3033(class3035_1[k].Vertices[0].ReflectedVertices[0], class3035_1[k].Vertices[1].ReflectedVertices[0]));
			class4.Add(edge2);
		}
		@class.class3041_0.Capacity = class3041_0.Capacity;
		int count3 = class3041_0.Count;
		for (int l = 0; l < count3; l++)
		{
			Class3040 class6 = new Class3040(class3041_0[l].Vertices[0].ReflectedVertices[0], class3041_0[l].Vertices[1].ReflectedVertices[0], class3041_0[l].Vertices[2].ReflectedVertices[0], class3041_0[l].Edges[0].ReflectedEdge, class3041_0[l].Edges[1].ReflectedEdge, class3041_0[l].Edges[2].ReflectedEdge);
			class6.RegionInd = class3041_0[l].RegionInd;
			@class.class3041_0.Add(class6);
		}
		if (Superstructure != null)
		{
			@class.class3039_0 = new Class3039();
			@class.class3039_0.Vertices.Capacity = class3039_0.Vertices.Capacity;
			count = Superstructure.Vertices.Count;
			for (int m = 0; m < count; m++)
			{
				@class.class3039_0.Vertices.Add(Superstructure.Vertices[m].ReflectedVertices[0]);
			}
			@class.class3039_0.Edges.Capacity = class3039_0.Edges.Capacity;
			count2 = Superstructure.Edges.Count;
			for (int n = 0; n < count2; n++)
			{
				@class.class3039_0.Edges.Add(Superstructure.Edges[n].ReflectedEdge);
			}
		}
		return @class;
	}
}
