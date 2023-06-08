using Aspose.Slides;

namespace ns4;

internal sealed class Class1072 : IMasterNotesSlideManager
{
	private MasterNotesSlide masterNotesSlide_0;

	private readonly Presentation presentation_0;

	public IMasterNotesSlide MasterNotesSlide => masterNotesSlide_0;

	public IMasterNotesSlide SetDefaultMasterNotesSlide()
	{
		masterNotesSlide_0 = new MasterNotesSlide(presentation_0);
		return masterNotesSlide_0;
	}

	public void RemoveMasterNotesSlide()
	{
		masterNotesSlide_0 = null;
	}

	internal Class1072(Presentation parentPresentation)
	{
		presentation_0 = parentPresentation;
	}
}
