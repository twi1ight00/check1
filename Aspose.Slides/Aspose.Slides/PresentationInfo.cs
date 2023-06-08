using System.IO;
using System.Runtime.InteropServices;
using ns15;
using ns28;
using ns4;

namespace Aspose.Slides;

[Guid("6A446241-F30E-40A2-8555-9B263D9C9F72")]
[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
public sealed class PresentationInfo : IPresentationInfo
{
	private bool bool_0;

	private LoadFormat loadFormat_0;

	public bool IsEncrypted => bool_0;

	public LoadFormat LoadFormat => loadFormat_0;

	internal PresentationInfo(Stream stream)
	{
		bool_0 = false;
		Stream stream2 = Class1161.smethod_0(stream);
		if (Presentation.smethod_1(stream2))
		{
			if (Class476.smethod_1(stream))
			{
				loadFormat_0 = LoadFormat.Odp;
				bool_0 = Class476.smethod_2(stream2);
			}
			else
			{
				loadFormat_0 = LoadFormat.Pptx;
			}
		}
		else if (Class890.smethod_0(stream))
		{
			bool_0 = true;
			loadFormat_0 = LoadFormat.Pptx;
		}
		else if (Class890.smethod_1(stream))
		{
			bool_0 = true;
			loadFormat_0 = LoadFormat.Ppt;
		}
		else
		{
			loadFormat_0 = LoadFormat.Ppt;
		}
	}
}
