using Aspose.Slides.Warnings;

namespace Aspose.Slides.Export;

public abstract class SaveOptions : ISaveOptions
{
	private IWarningCallback iwarningCallback_0;

	public IWarningCallback WarningCallback
	{
		get
		{
			return iwarningCallback_0;
		}
		set
		{
			iwarningCallback_0 = value;
		}
	}
}
