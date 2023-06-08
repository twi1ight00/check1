namespace Aspose.Cells;

public class ConditionalFormattingIcon
{
	private IconSetType iconSetType_0;

	private int int_0;

	public IconSetType Type
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

	public int Index
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

	internal ConditionalFormattingIcon(IconSetType iconSetType_1, int int_1)
	{
		iconSetType_0 = iconSetType_1;
		int_0 = int_1;
	}

	internal ConditionalFormattingIcon()
	{
	}

	internal void Copy(ConditionalFormattingIcon conditionalFormattingIcon_0)
	{
		iconSetType_0 = conditionalFormattingIcon_0.iconSetType_0;
		int_0 = conditionalFormattingIcon_0.int_0;
	}
}
