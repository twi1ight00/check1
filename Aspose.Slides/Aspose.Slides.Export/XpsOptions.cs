using System.Runtime.InteropServices;

namespace Aspose.Slides.Export;

[Guid("d0c30791-2e61-4b9e-abff-d29f298110ac")]
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
public class XpsOptions : SaveOptions, ISaveOptions, IXpsOptions
{
	private bool bool_0;

	public bool SaveMetafilesAsPng
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	ISaveOptions IXpsOptions.AsISaveOptions => this;

	public XpsOptions()
	{
		bool_0 = true;
	}
}
