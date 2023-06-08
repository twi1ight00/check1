using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("90A20159-5D64-4018-9ADF-334EF580BC93")]
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
public class TabFactory : ITabFactory
{
	public ITab CreateTab(double position, TabAlignment align)
	{
		return new Tab(position, align);
	}
}
