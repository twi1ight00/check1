using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("8267F5C2-A8F9-417D-9A3E-9662898F6ABB")]
public interface ITabFactory
{
	ITab CreateTab(double position, TabAlignment align);
}
