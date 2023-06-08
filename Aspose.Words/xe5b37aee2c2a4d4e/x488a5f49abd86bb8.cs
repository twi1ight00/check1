using x28925c9b27b37a46;

namespace xe5b37aee2c2a4d4e;

internal class x488a5f49abd86bb8 : x11e014059489ae95
{
	private int xbe63ce924b03850f;

	public bool xc8ea2954a6825f32 => false;

	internal int x9ba359ff37a3a63b
	{
		get
		{
			return xbe63ce924b03850f;
		}
		set
		{
			xbe63ce924b03850f = ((value > 255) ? 255 : ((value >= 0) ? value : 0));
		}
	}

	internal bool x6e0ec7bb3cf6a773 => xbe63ce924b03850f == 0;

	public x11e014059489ae95 xcc4933610939ad04()
	{
		return (x11e014059489ae95)MemberwiseClone();
	}
}
