using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using ns33;

namespace Aspose.Slides;

[ClassInterface(ClassInterfaceType.None)]
[Guid("6CB16B79-8C40-4E1E-B09B-FC044F4D40BC")]
[ComVisible(true)]
public class ImageWrapper : IDisposable, IImageWrapper
{
	private bool bool_0;

	private Image image_0;

	public Image Image => image_0;

	public Size Size => image_0.Size;

	IDisposable IImageWrapper.AsIDisposable => this;

	internal ImageWrapper(Image image)
	{
		if (image == null)
		{
			throw new ArgumentNullException("image");
		}
		image_0 = image;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public void Save(string fileName)
	{
		image_0.Save(fileName);
	}

	public void Save(Stream stream, PPImageFormat imageFormat)
	{
		image_0.Save(stream, Class1159.smethod_5(imageFormat));
	}

	public void Save(string fileName, PPImageFormat imageFormat)
	{
		image_0.Save(fileName, Class1159.smethod_5(imageFormat));
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!bool_0)
		{
			if (disposing)
			{
				image_0.Dispose();
			}
			bool_0 = true;
		}
	}
}
