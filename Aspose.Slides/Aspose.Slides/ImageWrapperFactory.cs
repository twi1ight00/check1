using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
[Guid("3D0394C7-780C-4FF5-AAA0-860822B5F4DC")]
public class ImageWrapperFactory : IImageWrapperFactory
{
	public IImageWrapper CreateImageWrapper(Image image)
	{
		return new ImageWrapper(image);
	}

	public IImageWrapper CreateImageWrapper(Stream stream)
	{
		return new ImageWrapper(Image.FromStream(stream));
	}

	public IImageWrapper CreateImageWrapper(string fileName)
	{
		return new ImageWrapper(Image.FromFile(fileName));
	}
}
