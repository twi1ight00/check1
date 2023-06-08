using ns25;

namespace Aspose.Slides.Charts;

public class UpDownBarsManager : IUpDownBarsManager
{
	private Class328 class328_0 = new Class328();

	private Format format_0;

	private Format format_1;

	private bool bool_0;

	private int int_0 = 150;

	public IFormat UpBarsFormat => format_0;

	public IFormat DownBarsFormat => format_1;

	public bool HasUpDownBars
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

	public int GapWidth
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	internal Class328 PPTXUnsupportedProps => class328_0;

	internal UpDownBarsManager(IChart parent)
	{
		format_0 = new Format(parent);
		format_1 = new Format(parent);
	}
}
