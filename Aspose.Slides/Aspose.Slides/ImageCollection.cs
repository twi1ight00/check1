using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using ns223;
using ns28;

namespace Aspose.Slides;

public sealed class ImageCollection : ICollection, IEnumerable, IEnumerable<IPPImage>, IImageCollection
{
	internal const string string_0 = "image/gif";

	internal const string string_1 = "image/jpeg";

	internal const string string_2 = "image/x-wmf";

	internal const string string_3 = "image/x-emf";

	internal const string string_4 = "image/png";

	internal const string string_5 = "image/tiff";

	internal const string string_6 = "image/bmp";

	internal const string string_7 = "image/pict";

	private readonly List<IPPImage> list_0;

	private Presentation presentation_0;

	private PPImage ppimage_0;

	private PPImage ppimage_1;

	private PPImage ppimage_2;

	public int Count => list_0.Count;

	public IPPImage this[int index] => list_0[index];

	internal IPPImage NoImage
	{
		get
		{
			if (ppimage_0 == null)
			{
				ppimage_0 = (PPImage)AddImage(Assembly.GetExecutingAssembly().GetManifestResourceStream("Aspose.Slides.DOM.resources.noImage.emf"));
			}
			return ppimage_0;
		}
	}

	internal PPImage AudioImage
	{
		get
		{
			if (ppimage_1 == null)
			{
				ppimage_1 = (PPImage)AddImage(Assembly.GetExecutingAssembly().GetManifestResourceStream("Aspose.Slides.DOM.resources.AudioFrame.png"));
			}
			return ppimage_1;
		}
	}

	internal PPImage OleImage
	{
		get
		{
			if (ppimage_2 == null)
			{
				ppimage_2 = (PPImage)AddImage(Assembly.GetExecutingAssembly().GetManifestResourceStream("Aspose.Slides.DOM.resources.EmbeddedOLE_template.png"));
			}
			return ppimage_2;
		}
	}

	IEnumerable IImageCollection.AsIEnumerable => this;

	ICollection IImageCollection.AsICollection => this;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal ImageCollection(Presentation parent)
	{
		list_0 = new List<IPPImage>();
		presentation_0 = parent;
	}

	internal PPImage method_0(byte[] data, uint crc32)
	{
		foreach (PPImage item in list_0)
		{
			if (item.CRC != crc32)
			{
				continue;
			}
			_ = item.data;
			if (item.data.Length == data.Length)
			{
				for (int i = 0; i < data.Length; i++)
				{
				}
				return item;
			}
		}
		return null;
	}

	internal void Add(PPImage image)
	{
		image.Presentation = presentation_0;
		list_0.Add(image);
	}

	public IPPImage AddImage(IPPImage imageSource)
	{
		PPImage pPImage = (PPImage)imageSource;
		_ = pPImage.Presentation;
		if (list_0.Contains(pPImage))
		{
			return pPImage;
		}
		return method_1(pPImage.data, pPImage.image);
	}

	public IPPImage AddImage(Image image)
	{
		return method_1(null, image);
	}

	public IPPImage AddImage(MemoryStream stream)
	{
		Image image = Image.FromStream(stream);
		return method_1(stream.ToArray(), image);
	}

	public IPPImage AddImage(Stream stream)
	{
		MemoryStream memoryStream = new MemoryStream();
		byte[] array = new byte[4096];
		while (true)
		{
			int num = stream.Read(array, 0, array.Length);
			if (num <= 0)
			{
				break;
			}
			memoryStream.Write(array, 0, num);
		}
		array = memoryStream.ToArray();
		memoryStream.Position = 0L;
		Image image = Image.FromStream(memoryStream);
		return method_1(array, image);
	}

	public IPPImage AddImage(byte[] buffer)
	{
		return AddImage(new MemoryStream(buffer));
	}

	private IPPImage method_1(byte[] data, Image image)
	{
		if (data == null && image == null)
		{
			throw new PptxEditException("Null image adding");
		}
		if (image == null)
		{
			image = Image.FromStream(new MemoryStream(data, writable: false));
		}
		ImageFormat imageFormat = image.RawFormat;
		bool flag = false;
		if (data == null && image is Metafile)
		{
			imageFormat = ImageFormat.Png;
		}
		if (data == null)
		{
			if (image is Bitmap && imageFormat.Guid != ImageFormat.Gif.Guid)
			{
				imageFormat = ((imageFormat.Guid == ImageFormat.Png.Guid || (image.PixelFormat & PixelFormat.Alpha) == PixelFormat.Alpha || (image.PixelFormat & PixelFormat.Indexed) == PixelFormat.Indexed || image.Width < 16 || image.Height < 16) ? ImageFormat.Png : ImageFormat.Jpeg);
			}
			using MemoryStream memoryStream = new MemoryStream();
			image.Save(memoryStream, imageFormat);
			data = memoryStream.ToArray();
		}
		uint num = Class5979.smethod_2(data);
		PPImage pPImage = method_0(data, num);
		if (pPImage != null)
		{
			return pPImage;
		}
		Rectangle imageFrame = new Rectangle(0, 0, 0, 0);
		if (image != null)
		{
			if (flag)
			{
				image = null;
			}
			else
			{
				imageFrame = new Rectangle(0, 0, image.Width, image.Height);
			}
		}
		pPImage = new PPImage(image, imageFrame, data, num);
		Add(pPImage);
		return pPImage;
	}

	internal static string smethod_0(string contentType)
	{
		return contentType switch
		{
			"image/bmp" => "bmp", 
			"image/x-emf" => "emf", 
			"image/jpeg" => "jpeg", 
			"image/png" => "png", 
			"image/x-wmf" => "wmf", 
			"image/pict" => "pict", 
			"image/gif" => "gif", 
			"image/tiff" => "tiff", 
			_ => "image", 
		};
	}

	internal void method_2(Class472 image)
	{
		Image image2 = null;
		method_1(image.data, image2);
	}

	IEnumerator<IPPImage> IEnumerable<IPPImage>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public void CopyTo(Array array, int index)
	{
		((ICollection)list_0).CopyTo(array, index);
	}
}
