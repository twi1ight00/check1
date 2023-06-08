using System.Drawing;
using System.Drawing.Drawing2D;

namespace ns224;

internal class Class5995 : Class5991
{
	private Class5998[] class5998_0;

	private byte[] byte_0;

	private float float_0 = float.MinValue;

	private RectangleF rectangleF_0 = RectangleF.Empty;

	public byte[] ImageBytes
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public float Opacity
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	public Class5998[] ColorMap
	{
		get
		{
			return class5998_0;
		}
		set
		{
			class5998_0 = value;
		}
	}

	public RectangleF ImageArea
	{
		get
		{
			return rectangleF_0;
		}
		set
		{
			rectangleF_0 = value;
		}
	}

	public Class5995(byte[] imageBytes)
		: this(imageBytes, WrapMode.Tile)
	{
	}

	public Class5995(byte[] imageBytes, WrapMode wrapMode)
		: base(Enum746.const_2)
	{
		ImageBytes = imageBytes;
		base.Transform = new Class6002();
		base.WrapMode = wrapMode;
	}
}
