using Aspose.Slides;

namespace ns4;

internal sealed class Class1071 : IMasterHandoutSlideManager
{
	private Presentation presentation_0;

	internal MasterHandoutSlide masterHandoutSlide_0;

	public IMasterHandoutSlide MasterHandoutSlide => masterHandoutSlide_0;

	public IMasterHandoutSlide SetDefaultMasterHandoutSlide()
	{
		masterHandoutSlide_0 = new MasterHandoutSlide(presentation_0);
		return masterHandoutSlide_0;
	}

	public void RemoveMasterHandoutSlide()
	{
		masterHandoutSlide_0 = null;
	}

	internal Class1071(Presentation parentPresentation)
	{
		presentation_0 = parentPresentation;
	}
}
