namespace Aspose.Cells;

/// <summary>
///       Reprents icon filter.
///       </summary>
public class IconFilter
{
	private FilterColumn filterColumn_0;

	private IconSetType iconSetType_0;

	private int int_0 = -1;

	/// <summary>
	/// </summary>
	public IconSetType IconSetType
	{
		get
		{
			return iconSetType_0;
		}
		set
		{
			iconSetType_0 = value;
		}
	}

	/// <summary>
	/// </summary>
	public int IconId
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

	internal IconFilter(FilterColumn filterColumn_1)
	{
		filterColumn_0 = filterColumn_1;
	}

	internal void Copy(IconFilter iconFilter_0)
	{
		iconSetType_0 = iconFilter_0.iconSetType_0;
		int_0 = iconFilter_0.int_0;
	}

	internal bool method_0(Cell cell_0)
	{
		return true;
	}
}
