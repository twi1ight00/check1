namespace ns220;

internal class Class6596
{
	private int int_0;

	private int int_1;

	private bool bool_0;

	private Class6595 class6595_0 = new Class6595();

	public int HeadingsOutlineLevels
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

	public int BookmarksOutlineLevel
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public bool RenderMetafileAsBitmap
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

	public Class6595 EmulateFormFieldRendering => class6595_0;
}
