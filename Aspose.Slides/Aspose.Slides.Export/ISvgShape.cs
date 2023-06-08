using System.Runtime.InteropServices;

namespace Aspose.Slides.Export;

[ComVisible(true)]
[Guid("F443D824-D5DB-499A-BCD7-B961A808C62C")]
public interface ISvgShape
{
	void SetEventHandler(SvgEvent eventType, string handler);
}
