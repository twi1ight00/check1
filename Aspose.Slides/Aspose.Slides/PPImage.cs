using System;
using System.Drawing;
using System.IO;
using ns22;
using ns223;
using ns233;
using ns24;
using ns33;

namespace Aspose.Slides;

public class PPImage : IPPImage
{
	private readonly Class344 class344_0 = new Class344();

	private readonly Class276 class276_0 = new Class276();

	private readonly Guid guid_0 = Guid.NewGuid();

	private MemoryStream memoryStream_0;

	private WeakReference weakReference_0;

	private IPresentation ipresentation_0;

	private float float_0;

	private float float_1;

	private Rectangle rectangle_0;

	private bool bool_0;

	private uint uint_0;

	private uint uint_1;

	internal Class344 PPTXUnsupportedProps => class344_0;

	internal Class276 PPTUnsupportedProps => class276_0;

	internal uint CRC
	{
		get
		{
			if (uint_0 == 0)
			{
				uint_0 = Class5979.smethod_2(data);
			}
			return uint_0;
		}
	}

	internal byte[] data => PPTXUnsupportedProps.data;

	internal Image image
	{
		get
		{
			Image image = ((weakReference_0 != null) ? (weakReference_0.Target as Image) : null);
			if (image == null)
			{
				image = method_0();
			}
			return image;
		}
	}

	public string ContentType => PPTXUnsupportedProps.PartType.ContentType;

	public byte[] BinaryData => (byte[])data.Clone();

	public Image SystemImage => (Image)image.Clone();

	public int Width
	{
		get
		{
			if (!bool_0)
			{
				method_0();
			}
			return rectangle_0.Width;
		}
	}

	public int Height
	{
		get
		{
			if (!bool_0)
			{
				method_0();
			}
			return rectangle_0.Height;
		}
	}

	public int X
	{
		get
		{
			if (!bool_0)
			{
				method_0();
			}
			return rectangle_0.X;
		}
	}

	public int Y
	{
		get
		{
			if (!bool_0)
			{
				method_0();
			}
			return rectangle_0.Y;
		}
	}

	internal PointF Dpi
	{
		get
		{
			if (!bool_0)
			{
				method_0();
			}
			return new PointF(float_0, float_1);
		}
	}

	internal IPresentation Presentation
	{
		get
		{
			return ipresentation_0;
		}
		set
		{
			ipresentation_0 = value;
			method_1();
		}
	}

	internal Guid Guid => guid_0;

	internal uint Version => uint_1 + class344_0.Version + class276_0.Version;

	internal PPImage(byte[] data)
	{
		PPTXUnsupportedProps.data = data;
		memoryStream_0 = new MemoryStream(data);
	}

	internal PPImage(Image image, Rectangle imageFrame, byte[] data, uint crc)
		: this(data)
	{
		uint_0 = crc;
		weakReference_0 = new WeakReference(image);
		rectangle_0 = imageFrame;
	}

	public override int GetHashCode()
	{
		return (int)CRC;
	}

	public void ReplaceImage(byte[] newImageData)
	{
		if (newImageData == null)
		{
			throw new ArgumentNullException("newImageData");
		}
		PPTXUnsupportedProps.data = newImageData;
		memoryStream_0.Dispose();
		memoryStream_0 = new MemoryStream(newImageData);
		method_0();
	}

	public void ReplaceImage(Image newImage)
	{
		if (newImage == null)
		{
			throw new ArgumentNullException("newImage");
		}
		memoryStream_0.Dispose();
		memoryStream_0 = new MemoryStream();
		newImage.Save(memoryStream_0, newImage.RawFormat);
		PPTXUnsupportedProps.data = memoryStream_0.ToArray();
		method_0();
	}

	public void ReplaceImage(IPPImage newImage)
	{
		if (newImage == null)
		{
			throw new ArgumentNullException("newImage");
		}
		PPTXUnsupportedProps.data = newImage.BinaryData;
		memoryStream_0.Dispose();
		memoryStream_0 = new MemoryStream(PPTXUnsupportedProps.data);
		method_0();
	}

	private Image method_0()
	{
		if (memoryStream_0.CanSeek)
		{
			memoryStream_0.Seek(0L, SeekOrigin.Begin);
		}
		Image image = Image.FromStream(memoryStream_0);
		bool_0 = true;
		float_0 = image.HorizontalResolution;
		float_1 = image.VerticalResolution;
		if (ContentType == "image/x-emf")
		{
			try
			{
				Class6147 @class = Class6148.smethod_34(data);
				rectangle_0 = new Rectangle(@class.Left, @class.Top, @class.Width, @class.Height);
			}
			catch (Exception ex)
			{
				Class1165.smethod_28(ex);
				rectangle_0 = new Rectangle(0, 0, image.Width, image.Height);
			}
		}
		else
		{
			rectangle_0 = new Rectangle(0, 0, image.Width, image.Height);
		}
		weakReference_0 = new WeakReference(image);
		method_1();
		return image;
	}

	private void method_1()
	{
		uint_1++;
	}
}
