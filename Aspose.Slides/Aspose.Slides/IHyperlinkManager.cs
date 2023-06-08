using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("c470189a-0657-46e5-9f69-e1bf639f154a")]
[ComVisible(true)]
public interface IHyperlinkManager
{
	IHyperlink SetExternalHyperlinkClick(string url);

	IHyperlink SetInternalHyperlinkClick(ISlide targetSlide);

	void RemoveHyperlinkClick();

	IHyperlink SetExternalHyperlinkMouseOver(string url);

	IHyperlink SetInternalHyperlinkMouseOver(ISlide targetSlide);

	void RemoveHyperlinkMouseOver();
}
