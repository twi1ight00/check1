using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("E777AE35-C0D9-48EF-8074-CA370A9D12F4")]
public interface IPortionFormat : IBasePortionFormat, IHyperlinkContainer
{
	string BookmarkId { get; set; }

	bool SmartTagClean { get; set; }

	IBasePortionFormat AsIBasePortionFormat { get; }

	IHyperlinkContainer AsIHyperlinkContainer { get; }
}
