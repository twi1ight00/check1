namespace ns67;

internal sealed class Class3338 : Class3331
{
	private uint uint_0;

	private bool bool_0 = true;

	private readonly Class3369 class3369_0;

	private Struct157 struct157_0;

	private Class3370 class3370_0;

	private Class3371 class3371_0;

	public uint Dpi
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public bool RotateWithShape
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

	public Class3369 Blip => class3369_0;

	public Struct157 SourceRectangle
	{
		get
		{
			return struct157_0;
		}
		set
		{
			struct157_0 = value;
		}
	}

	public Class3370 Stretch
	{
		get
		{
			return class3370_0;
		}
		set
		{
			if (class3370_0 != value)
			{
				class3370_0 = value?.method_0();
			}
		}
	}

	public Class3371 Tile
	{
		get
		{
			return class3371_0;
		}
		set
		{
			if (class3371_0 != value)
			{
				class3371_0 = value?.method_0();
			}
		}
	}

	public Class3338(string pictureReference)
	{
		class3369_0 = new Class3369(pictureReference);
	}

	public override Class3331 vmethod_0()
	{
		return new Class3338(this);
	}

	private Class3338(Class3338 src)
	{
		Dpi = src.Dpi;
		RotateWithShape = src.RotateWithShape;
		class3369_0 = src.class3369_0.method_0();
		SourceRectangle = src.SourceRectangle;
		Stretch = src.Stretch;
		Tile = src.Tile;
	}
}
