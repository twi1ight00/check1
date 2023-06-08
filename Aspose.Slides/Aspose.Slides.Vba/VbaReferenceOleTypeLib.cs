using System.Runtime.InteropServices;

namespace Aspose.Slides.Vba;

[ComVisible(true)]
[Guid("108F1522-B8F2-45E6-B86D-A19134A1AF67")]
[ClassInterface(ClassInterfaceType.None)]
public class VbaReferenceOleTypeLib : IVbaReference, IVbaReferenceOleTypeLib
{
	private string string_0;

	private string string_1;

	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public string Libid
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	IVbaReference IVbaReferenceOleTypeLib.AsIVbaReference => this;

	public VbaReferenceOleTypeLib(string name, string libid)
	{
		string_0 = name;
		string_1 = libid;
	}
}
