using System.IO;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("ae237afa-7b05-4da4-bed3-654f6f09fd82")]
[ClassInterface(ClassInterfaceType.None)]
public class PresentationFactory : IPresentationFactory
{
	private static readonly PresentationFactory presentationFactory_0 = new PresentationFactory();

	public static PresentationFactory Instance => presentationFactory_0;

	public IPresentation CreatePresentation()
	{
		return new Presentation();
	}

	public IPresentation CreatePresentation(ILoadOptions options)
	{
		return new Presentation(options as LoadOptions);
	}

	public IPresentationInfo GetPresentationInfo(string file)
	{
		using FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read);
		return GetPresentationInfo(stream);
	}

	public IPresentationInfo GetPresentationInfo(Stream stream)
	{
		return new PresentationInfo(stream);
	}

	public IPresentation ReadPresentation(byte[] data)
	{
		using MemoryStream stream = new MemoryStream(data, writable: false);
		return new Presentation(stream);
	}

	public IPresentation ReadPresentation(byte[] data, ILoadOptions options)
	{
		using MemoryStream stream = new MemoryStream(data, writable: false);
		return new Presentation(stream, options as LoadOptions);
	}

	public IPresentation ReadPresentation(Stream stream)
	{
		return new Presentation(stream);
	}

	public IPresentation ReadPresentation(Stream stream, ILoadOptions options)
	{
		return new Presentation(stream, options as LoadOptions);
	}

	public IPresentation ReadPresentation(string file)
	{
		return new Presentation(file);
	}

	public IPresentation ReadPresentation(string file, ILoadOptions options)
	{
		return new Presentation(file, options as LoadOptions);
	}
}
