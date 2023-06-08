using System.Drawing;
using Aspose.XfaConverter.Elements;
using ns216;

namespace ns215;

internal class Class5927 : Interface250
{
	private SizeF sizeF_0;

	public Class5829 Margin => null;

	public XfaEnums.Enum702 AnchorType => XfaEnums.Enum702.const_0;

	public float X => 0f;

	public float Y => 0f;

	public float H
	{
		get
		{
			return sizeF_0.Height;
		}
		set
		{
			sizeF_0.Height = value;
		}
	}

	public float W
	{
		get
		{
			return sizeF_0.Width;
		}
		set
		{
			sizeF_0.Width = value;
		}
	}

	public float MinH => 0f;

	public float MaxH => 0f;

	public float MinW => 0f;

	public float MaxW => 0f;

	public int ColSpan => 0;

	internal Class5927(SizeF size)
	{
		sizeF_0 = size;
	}
}
