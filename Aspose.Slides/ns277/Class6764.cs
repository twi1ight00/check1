using System.Drawing;

namespace ns277;

internal class Class6764 : Interface321
{
	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private Color color_0;

	private Color color_1;

	private bool bool_3;

	private Color color_2;

	public bool IsBaselineVisible
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

	public bool AreWordBoxBordersVisible
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public bool IsFilledWordBox
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public Color WordBoxColor
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

	public Color WordBoxBorderColor
	{
		get
		{
			return color_1;
		}
		set
		{
			color_1 = value;
		}
	}

	public bool IsFilledSpaceBoxes
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public Color SpaceBoxColor
	{
		get
		{
			return color_2;
		}
		set
		{
			color_2 = value;
		}
	}
}
