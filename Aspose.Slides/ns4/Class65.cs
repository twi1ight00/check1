using System.Drawing;
using ns233;

namespace ns4;

internal sealed class Class65
{
	private readonly Color color_0;

	private readonly Class6145 class6145_0;

	public Color TransparentColor => color_0;

	public Class6145 Crop => class6145_0;

	public Class65()
		: this(Color.Empty)
	{
	}

	public Class65(Color transparentColor)
		: this(transparentColor, new Class6145(0.0, 0.0, 0.0, 0.0))
	{
	}

	public Class65(Color transparentColor, Class6145 crop)
	{
		color_0 = transparentColor;
		class6145_0 = crop;
	}
}
