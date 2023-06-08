using Aspose.Slides;

namespace ns24;

internal class Class346 : Class278
{
	private Class1148 class1148_0 = new Class1148();

	public Class1148 class1148_1 = new Class1148();

	private double double_0;

	private double double_1;

	private float float_0 = 1f;

	private float float_1 = 1f;

	private TileFlip tileFlip_0;

	private RectangleAlignment rectangleAlignment_0;

	private uint uint_0;

	public Class1148 StretchFillRectangle => class1148_1;

	public Class1148 SrcRect => class1148_0;

	public double TileOffsetX
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
			method_1();
		}
	}

	public double TileOffsetY
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
			method_1();
		}
	}

	public float TileScaleX
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
			method_1();
		}
	}

	public float TileScaleY
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
			method_1();
		}
	}

	public TileFlip TileFlip
	{
		get
		{
			return tileFlip_0;
		}
		set
		{
			tileFlip_0 = value;
			method_1();
		}
	}

	public RectangleAlignment TileAlign
	{
		get
		{
			return rectangleAlignment_0;
		}
		set
		{
			rectangleAlignment_0 = value;
			method_1();
		}
	}

	internal uint Version => uint_0 + class1148_0.Version + class1148_1.Version;

	public void method_0(Class346 source)
	{
		class1148_1.method_0(source.class1148_1);
		class1148_0.method_0(source.class1148_0);
		double_0 = source.double_0;
		double_1 = source.double_1;
		float_0 = source.float_0;
		float_1 = source.float_1;
		tileFlip_0 = source.tileFlip_0;
		rectangleAlignment_0 = source.rectangleAlignment_0;
		method_1();
	}

	private void method_1()
	{
		uint_0++;
	}
}
