using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("7CFD37CA-D181-4F4B-BFE2-223387FE5959")]
public interface IMasterNotesSlideManager
{
	IMasterNotesSlide MasterNotesSlide { get; }

	IMasterNotesSlide SetDefaultMasterNotesSlide();

	void RemoveMasterNotesSlide();
}
