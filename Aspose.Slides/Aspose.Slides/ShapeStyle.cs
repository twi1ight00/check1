namespace Aspose.Slides;

public class ShapeStyle : IShapeStyle
{
	private GeometryShape geometryShape_0;

	private uint uint_0;

	private ColorFormat colorFormat_0;

	private ColorFormat colorFormat_1;

	private ColorFormat colorFormat_2;

	private ColorFormat colorFormat_3;

	private uint uint_1;

	private uint uint_2;

	private uint uint_3;

	private FontCollectionIndex fontCollectionIndex_0;

	public IColorFormat LineColor => colorFormat_0;

	public ushort LineStyleIndex
	{
		get
		{
			return (ushort)uint_1;
		}
		set
		{
			uint_1 = value;
			method_0();
		}
	}

	public IColorFormat FillColor => colorFormat_1;

	public short FillStyleIndex
	{
		get
		{
			short num = (short)(uint_2 % 1000u);
			if (uint_2 < 1000)
			{
				return num;
			}
			return (short)(-num);
		}
		set
		{
			if (value < 0)
			{
				uint_2 = (uint)(1000 - value);
			}
			else
			{
				uint_2 = (uint)value;
			}
			method_0();
		}
	}

	public IColorFormat EffectColor => colorFormat_2;

	public uint EffectStyleIndex
	{
		get
		{
			return uint_3;
		}
		set
		{
			uint_3 = value;
			method_0();
		}
	}

	public IColorFormat FontColor => colorFormat_3;

	public FontCollectionIndex FontCollectionIndex
	{
		get
		{
			return fontCollectionIndex_0;
		}
		set
		{
			fontCollectionIndex_0 = value;
			method_0();
		}
	}

	internal IBaseSlide Slide => geometryShape_0.Slide;

	internal uint Version => uint_0 + colorFormat_0.Version + colorFormat_1.Version + colorFormat_2.Version + colorFormat_3.Version;

	internal ShapeStyle(GeometryShape parent)
	{
		geometryShape_0 = parent;
		colorFormat_0 = new ColorFormat(parent);
		colorFormat_1 = new ColorFormat(parent);
		colorFormat_2 = new ColorFormat(parent);
		colorFormat_3 = new ColorFormat(parent);
	}

	private void method_0()
	{
		uint_0++;
	}
}
