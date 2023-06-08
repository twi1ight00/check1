using System;
using System.Collections.Generic;

namespace ns69;

internal sealed class Class3033 : IComparable
{
	internal sealed class Class3034 : IComparer<Class3033>
	{
		int IComparer<Class3033>.Compare(Class3033 x, Class3033 y)
		{
			if (x.EdgeLengthSqr == y.EdgeLengthSqr)
			{
				return 0;
			}
			if (x.EdgeLengthSqr > y.EdgeLengthSqr)
			{
				return 1;
			}
			return -1;
		}
	}

	private Class3059[] class3059_0;

	private Class3040[] class3040_0;

	private bool bool_0;

	private double double_0;

	private Class3033 class3033_0;

	public Class3059[] Vertices => class3059_0;

	public Class3040[] Triangles => class3040_0;

	public bool IsStructural
	{
		get
		{
			return bool_0;
		}
		set
		{
			if (bool_0 != value)
			{
				if (value)
				{
					Vertices[0].StructuralEdges.Add(this);
					Vertices[1].StructuralEdges.Add(this);
				}
				else
				{
					Vertices[0].StructuralEdges.Remove(this);
					Vertices[1].StructuralEdges.Remove(this);
				}
				bool_0 = value;
			}
		}
	}

	public double EdgeLengthSqr => double_0;

	internal Class3033 ReflectedEdge
	{
		get
		{
			return class3033_0;
		}
		set
		{
			class3033_0 = value;
		}
	}

	public Class3033(Class3059 vertex0, Class3059 vertex1)
	{
		class3059_0 = new Class3059[2];
		Vertices[0] = vertex0;
		Vertices[1] = vertex1;
		class3040_0 = new Class3040[2];
		Triangles[0] = null;
		Triangles[1] = null;
		bool_0 = false;
		double num = vertex1.X - vertex0.X;
		double num2 = vertex1.Y - vertex0.Y;
		double_0 = num * num + num2 * num2;
	}

	public Class3033(Class3059 vertex0, Class3059 vertex1, Class3040 triangle0, Class3040 triangle1)
		: this(vertex0, vertex1)
	{
		Triangles[0] = triangle0;
		Triangles[1] = triangle1;
	}

	public Class3040 method_0(Class3040 triangle)
	{
		if (Triangles[0] == triangle)
		{
			return Triangles[1];
		}
		if (Triangles[1] == triangle)
		{
			return Triangles[0];
		}
		if (Triangles[0] != null || Triangles[1] == null)
		{
		}
		return null;
	}

	public Class3040 method_1()
	{
		if (Triangles[0] == null && Triangles[1] != null)
		{
			return Triangles[1];
		}
		if (Triangles[0] != null && Triangles[1] == null)
		{
			return Triangles[0];
		}
		if (Triangles[0] == null && Triangles[1] == null)
		{
			return null;
		}
		if (Triangles[0] != null)
		{
			_ = Triangles[1];
		}
		return null;
	}

	public int CompareTo(object obj)
	{
		Class3033 @class = (Class3033)obj;
		if (Class3037.smethod_3(EdgeLengthSqr, @class.EdgeLengthSqr, 1E-07))
		{
			return 0;
		}
		if (EdgeLengthSqr > @class.EdgeLengthSqr)
		{
			return 1;
		}
		return -1;
	}
}
