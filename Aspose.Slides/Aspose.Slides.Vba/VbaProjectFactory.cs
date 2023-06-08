using System.Runtime.InteropServices;

namespace Aspose.Slides.Vba;

[ClassInterface(ClassInterfaceType.None)]
[Guid("5F121A26-C101-4D65-A22C-F4BB8DA5E009")]
[ComVisible(true)]
public class VbaProjectFactory : IVbaProjectFactory
{
	private static readonly VbaProjectFactory vbaProjectFactory_0 = new VbaProjectFactory();

	public static VbaProjectFactory Instance => vbaProjectFactory_0;

	public IVbaProject CreateVbaProject()
	{
		return new VbaProject();
	}

	public IVbaProject ReadVbaProject(byte[] data)
	{
		return new VbaProject(data);
	}
}
