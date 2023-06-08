using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("d7c4bf28-7795-4a4b-a683-f09a1784cf0f")]
public interface IHyperlinkContainer
{
	IHyperlink HyperlinkClick { get; set; }

	IHyperlink HyperlinkMouseOver { get; set; }

	IHyperlinkManager HyperlinkManager { get; }
}
