using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using ns33;

namespace ns4;

internal class Class64 : IDisposable
{
	private byte[] byte_0;

	private Image image_0;

	private readonly string string_0;

	private static readonly EncoderParameters encoderParameters_0;

	private static readonly ImageCodecInfo imageCodecInfo_0;

	private int int_0 = -1;

	internal byte[] ImageData
	{
		get
		{
			if (byte_0 == null)
			{
				MemoryStream memoryStream = new MemoryStream();
				try
				{
					if (ImageFormat.Wmf.Guid == image_0.RawFormat.Guid)
					{
						image_0.Save(memoryStream, ImageFormat.Wmf);
					}
					else if (ImageFormat.Emf.Guid == image_0.RawFormat.Guid)
					{
						image_0.Save(memoryStream, ImageFormat.Emf);
					}
					else
					{
						image_0.Save(memoryStream, ImageFormat.Png);
					}
					byte_0 = memoryStream.ToArray();
				}
				catch (Exception ex)
				{
					Class1165.smethod_28(ex);
					using Bitmap bitmap = new Bitmap(image_0.Width, image_0.Height);
					using Graphics graphics = Graphics.FromImage(bitmap);
					graphics.CompositingMode = CompositingMode.SourceCopy;
					graphics.DrawImage(image_0, 0, 0);
					bitmap.SetResolution(96f, 96f);
					bitmap.Save(memoryStream, ImageFormat.Png);
					byte_0 = memoryStream.ToArray();
				}
			}
			return byte_0;
		}
	}

	internal bool IsMetafile
	{
		get
		{
			if (byte_0 != null)
			{
				if (!Class1159.smethod_1(byte_0))
				{
					return Class1159.smethod_0(byte_0);
				}
				return true;
			}
			Image image = Image;
			if (!(image.RawFormat.Guid == ImageFormat.Wmf.Guid))
			{
				return image.RawFormat.Guid == ImageFormat.Emf.Guid;
			}
			return true;
		}
	}

	internal bool IsAnimatedGif
	{
		get
		{
			if (int_0 < 0)
			{
				Image image = Image;
				int_0 = ((image.RawFormat.Guid == ImageFormat.Gif.Guid && image.GetFrameCount(new FrameDimension(image.FrameDimensionsList[0])) > 1) ? 1 : 0);
			}
			return int_0 > 0;
		}
	}

	internal Image LoadedImage => image_0;

	internal Image Image
	{
		get
		{
			if (image_0 == null)
			{
				image_0 = Image.FromStream(new MemoryStream(byte_0));
			}
			return image_0;
		}
	}

	internal int Width => Image.Width;

	internal int Height => Image.Height;

	internal float HorizontalResolution => Image.HorizontalResolution;

	internal float VerticalResolution => Image.VerticalResolution;

	internal string Code => string_0;

	static Class64()
	{
		encoderParameters_0 = new EncoderParameters(1);
		encoderParameters_0.Param[0] = new EncoderParameter(Encoder.Quality, 99L);
		ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
		ImageCodecInfo[] array = imageEncoders;
		foreach (ImageCodecInfo imageCodecInfo in array)
		{
			if (imageCodecInfo.MimeType == "image/jpeg")
			{
				imageCodecInfo_0 = imageCodecInfo;
			}
		}
	}

	internal Class64(Image image, byte[] imageData, string code)
	{
		byte_0 = imageData;
		image_0 = image;
		string_0 = code;
	}

	internal Class64(Image image, string code)
		: this(image, null, code)
	{
	}

	internal Class64(byte[] imageData, string code)
		: this(null, imageData, code)
	{
	}

	public void Dispose()
	{
		if (image_0 != null)
		{
			image_0.Dispose();
			image_0 = null;
		}
		if (byte_0 != null)
		{
			byte_0 = null;
		}
	}
}
