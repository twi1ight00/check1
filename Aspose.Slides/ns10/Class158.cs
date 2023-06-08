using System.Runtime.InteropServices;
using Aspose.Slides.Vba;

namespace ns10;

[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
[Guid("D53A0C3E-2288-4525-8A48-C695F0B509C3")]
internal class Class158 : IVbaReference, IVbaReferenceProject
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

	IVbaReference IVbaReferenceProject.AsIVbaReference => this;

	internal Class158(string name)
	{
		string_0 = name;
	}
}
