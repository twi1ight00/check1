using System.Drawing;
using ns67;

namespace ns69;

internal sealed class Class3059
{
	private double double_0;

	private double double_1;

	private Class3041 class3041_0;

	private PointF pointF_0;

	private Struct159 struct159_0;

	private Class3059[] class3059_0;

	private bool bool_0;

	private Class3035 class3035_0;

	public double X => double_0;

	public double Y => double_1;

	public Struct159 AsPlanePoint => struct159_0;

	public PointF AsPointF => pointF_0;

	public Class3041 Triangles => class3041_0;

	public Class3035 StructuralEdges => class3035_0;

	internal Class3059[] ReflectedVertices
	{
		get
		{
			return class3059_0;
		}
		set
		{
			class3059_0 = value;
		}
	}

	internal bool BelongToSuperstructure
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public Class3059(double x, double y)
	{
		double_0 = x;
		double_1 = y;
		struct159_0 = new Struct159(x, y);
		pointF_0 = new PointF((float)x, (float)y);
		class3041_0 = new Class3041();
		class3059_0 = null;
		bool_0 = false;
		class3035_0 = new Class3035();
	}

	public Class3059(Class3059 vertex)
		: this(vertex.X, vertex.Y)
	{
	}

	public bool method_0(Class3059 vertex)
	{
		if (Class3037.smethod_0(X - vertex.X, 9.999999747378752E-06))
		{
			return Class3037.smethod_0(Y - vertex.Y, 9.999999747378752E-06);
		}
		return false;
	}
}
