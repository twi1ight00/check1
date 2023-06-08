using System.Runtime.InteropServices;
using Aspose.Slides.Vba;

namespace ns10;

[Guid("96BCE4BA-9593-4F96-8E71-0797E492855A")]
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
internal class Class156 : IVbaReference, IVbaReferenceOleTwiddledTypeLib
{
	private string string_0;

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

	IVbaReference IVbaReferenceOleTwiddledTypeLib.AsIVbaReference => this;

	internal Class156(string name)
	{
		string_0 = name;
	}
}
