namespace Aspose.Slides;

public class GradientStop : IGradientStop
{
	private float float_0;

	private ColorFormat colorFormat_0;

	private uint uint_0;

	public float Position
	{
		get
		{
			return float_0;
		}
		set
		{
			if (value < 0f)
			{
				value = 0f;
			}
			if (value > 1f)
			{
				value = 1f;
			}
			float_0 = value;
			method_0();
		}
	}

	public IColorFormat Color => colorFormat_0;

	internal uint Version => uint_0 + colorFormat_0.Version;

	internal GradientStop(IPresentationComponent parent)
	{
		Position = 0f;
		colorFormat_0 = new ColorFormat(parent as ISlideComponent);
	}

	internal GradientStop(float position, IColorFormat color)
	{
		Position = position;
		colorFormat_0 = (ColorFormat)color;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is GradientStop gradientStop))
		{
			return base.Equals(obj);
		}
		if (float_0 != gradientStop.float_0)
		{
			return false;
		}
		return colorFormat_0.Equals(gradientStop.colorFormat_0);
	}

	public override int GetHashCode()
	{
		return 23456;
	}

	private void method_0()
	{
		uint_0++;
	}
}
