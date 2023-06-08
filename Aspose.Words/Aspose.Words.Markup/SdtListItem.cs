using x6c95d9cf46ff5f25;

namespace Aspose.Words.Markup;

public class SdtListItem
{
	private readonly string x4574aea041dd835f;

	private readonly string xebce2cd3b1476ab2;

	public string DisplayText => xebce2cd3b1476ab2;

	public string Value => x4574aea041dd835f;

	public SdtListItem(string displayText, string value)
	{
		xebce2cd3b1476ab2 = displayText;
		x0d299f323d241756.x48501aec8e48c869(value, "value");
		x4574aea041dd835f = value;
	}

	public SdtListItem(string value)
		: this(value, value)
	{
	}

	internal SdtListItem x8b61531c8ea35b85()
	{
		return (SdtListItem)MemberwiseClone();
	}
}
