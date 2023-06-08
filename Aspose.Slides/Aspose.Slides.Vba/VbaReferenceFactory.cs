using System.Runtime.InteropServices;

namespace Aspose.Slides.Vba;

[Guid("76112CBF-5D2F-48C3-9E0E-495DFBD62612")]
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
public class VbaReferenceFactory : IVbaReferenceFactory
{
	private static readonly VbaReferenceFactory vbaReferenceFactory_0 = new VbaReferenceFactory();

	public static VbaReferenceFactory Instance => vbaReferenceFactory_0;

	public IVbaReferenceOleTypeLib CreateOleTypeLibReference(string name, string libid)
	{
		return new VbaReferenceOleTypeLib(name, libid);
	}
}
