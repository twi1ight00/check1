using System.Drawing;

namespace ns36;

internal class Class774 : Interface28
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

	internal bool method_0(Class774 other)
	{
		if (Position != other.Position)
		{
			return false;
		}
		if (Color.A == other.Color.A && Color.R == other.Color.R && Color.G == other.Color.G && Color.B == other.Color.B)
		{
			return true;
		}
		return false;
	}
}
