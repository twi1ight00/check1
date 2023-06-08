using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("46A93BF3-B54B-4090-8369-BD212BE16934")]
[ComVisible(true)]
public interface IMasterHandoutSlideManager
{
	IMasterHandoutSlide MasterHandoutSlide { get; }

	IMasterHandoutSlide SetDefaultMasterHandoutSlide();

	void RemoveMasterHandoutSlide();
}
