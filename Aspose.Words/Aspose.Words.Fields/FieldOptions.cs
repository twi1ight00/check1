namespace Aspose.Words.Fields;

public class FieldOptions
{
	private FieldUpdateCultureSource x43fca6771a55ac94;

	private bool x29f57e7c16caa0fd;

	private IFieldUserPromptRespondent x5b52fda1e66ab217;

	public FieldUpdateCultureSource FieldUpdateCultureSource
	{
		get
		{
			return x43fca6771a55ac94;
		}
		set
		{
			x43fca6771a55ac94 = value;
		}
	}

	public bool IsBidiTextSupportedOnUpdate
	{
		get
		{
			return x29f57e7c16caa0fd;
		}
		set
		{
			x29f57e7c16caa0fd = value;
		}
	}

	public IFieldUserPromptRespondent UserPromptRespondent
	{
		get
		{
			return x5b52fda1e66ab217;
		}
		set
		{
			x5b52fda1e66ab217 = value;
		}
	}

	internal FieldOptions()
	{
	}
}
