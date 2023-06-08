using System.Drawing;

namespace ns3;

internal class Class860 : Interface37
{
	private Color color_0;

	private float float_0;

	public Color Color
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
		}
	}

	public float Position
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

	internal bool method_0(Class860 class860_0)
	{
		if (Position != class860_0.Position)
		{
			return false;
		}
		if (Color.A == class860_0.Color.A && Color.R == class860_0.Color.R && Color.G == class860_0.Color.G && Color.B == class860_0.Color.B)
		{
			return true;
		}
		return false;
	}
}
