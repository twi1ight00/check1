using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("14A06FD9-CB20-4802-BD87-7DF1E9A92F8D")]
public interface IHyperlinkQueries
{
	IList<IHyperlinkContainer> GetHyperlinkClicks();

	IList<IHyperlinkContainer> GetHyperlinkMouseOvers();

	IList<IHyperlinkContainer> GetAnyHyperlinks();

	void RemoveAllHyperlinks();
}
