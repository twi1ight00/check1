using System.Drawing;
using System.Drawing.Imaging;

namespace ns233;

internal struct Struct218
{
	private Image image_0;

	private Enum789 enum789_0;

	private EncoderParameters encoderParameters_0;

	public Image FirstFrame
	{
		get
		{
			return image_0;
		}
		set
		{
			image_0 = value;
		}
	}

	public Enum789 Compression
	{
		get
		{
			return enum789_0;
		}
		set
		{
			enum789_0 = value;
		}
	}

	public EncoderParameters EncoderParameters
	{
		get
		{
			return encoderParameters_0;
		}
		set
		{
			encoderParameters_0 = value;
		}
	}
}
