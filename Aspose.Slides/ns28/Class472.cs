using System.Drawing;
using System.IO;
using Aspose.Slides;

namespace ns28;

internal class Class472
{
	internal Class480 class480_0;

	private Image image_0;

	internal Presentation presentation_0;

	internal float float_0;

	internal float float_1;

	internal uint CRC => (uint)class480_0.Crc32;

	internal string partName => class480_0.string_0;

	internal byte[] data => class480_0.byte_0;

	internal Image image
	{
		get
		{
			method_0();
			return image_0;
		}
	}

	public string ContentType => class480_0.string_1;

	public byte[] BinaryData => (byte[])class480_0.byte_0.Clone();

	public Image Image
	{
		get
		{
			method_0();
			return (Image)image_0.Clone();
		}
	}

	public int Width
	{
		get
		{
			method_0();
			return image_0.Width;
		}
	}

	public int Height
	{
		get
		{
			method_0();
			return image_0.Height;
		}
	}

	internal PointF Dpi
	{
		get
		{
			method_0();
			return new PointF(float_0, float_1);
		}
	}

	internal Class472(Class480 part, Class476 package)
	{
		class480_0 = part;
		if (class480_0.byte_0 == null)
		{
			using Stream stream = class480_0.class6751_0.method_19();
			class480_0.byte_0 = new byte[class480_0.class6751_0.UncompressedSize];
			int num = 0;
			int num2;
			do
			{
				num2 = stream.Read(class480_0.byte_0, num, class480_0.byte_0.Length - num);
				num += num2;
			}
			while (num2 > 0 && class480_0.byte_0.Length - num > 0);
			part.class6751_0 = null;
		}
		part.object_0 = this;
	}

	internal Class472(Class480 part, Class476 package, Image image)
		: this(part, package)
	{
		image_0 = image;
	}

	public override int GetHashCode()
	{
		return (int)CRC;
	}

	private void method_0()
	{
		if (image_0 == null)
		{
			MemoryStream memoryStream = new MemoryStream(class480_0.byte_0, writable: false);
			image_0 = Image.FromStream(memoryStream);
			float_0 = image_0.HorizontalResolution;
			float_1 = image_0.VerticalResolution;
			if (image_0 is Bitmap)
			{
				Image image = image_0;
				image_0 = new Bitmap(image_0);
				image.Dispose();
			}
			memoryStream.Close();
		}
	}
}
