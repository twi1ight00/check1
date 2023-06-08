using System;
using System.Collections;
using System.Drawing;
using System.IO;
using x011d489fb9df7027;
using x28925c9b27b37a46;
using x38a89dee67fc7a16;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace Aspose.Words.Drawing;

public class ImageData : x0e9935be205598e7, IImageData
{
	internal const double xb831ae06697d0bac = 0.0;

	internal const double xcbf43d369f6691c7 = 1.0;

	internal const double x39085b2d8325ddd2 = -0.5;

	internal const double x5bb3cedb4feef879 = 0.5;

	private readonly x7b71245a33212e76 xc454c03c23d4b4d9;

	private BorderCollection x52f94035dff03a3d;

	private static readonly SortedList x0504f8a641e0e833;

	private readonly x8e500baeffc6e539 xbf762ca9cde15360;

	public byte[] ImageBytes
	{
		get
		{
			return xbf762ca9cde15360.xcc18177a965e0313;
		}
		set
		{
			xbf762ca9cde15360.xcc18177a965e0313 = value;
		}
	}

	public bool HasImage => xbf762ca9cde15360.x13055c95ca5083f1;

	public ImageSize ImageSize => xbf762ca9cde15360.x8d0c72c5b2891cbc;

	public ImageType ImageType => xbf762ca9cde15360.x688d6f6524ba3c8b;

	internal xfe2ff3c162b47c70 xfe2ff3c162b47c70 => xbf762ca9cde15360.xfe2ff3c162b47c70;

	public bool IsLink => xbf762ca9cde15360.xce9657aabb6b6e6f;

	public bool IsLinkOnly => xbf762ca9cde15360.x66b8b219d7a8c7b2;

	public string SourceFullName
	{
		get
		{
			return xbf762ca9cde15360.x9f8e4dc805c6986e;
		}
		set
		{
			xbf762ca9cde15360.x9f8e4dc805c6986e = value;
		}
	}

	public string Title
	{
		get
		{
			return (string)xfe91eeeafcb3026a(4103);
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			xae20093bed1e48a8(4103, value);
		}
	}

	public double CropTop
	{
		get
		{
			return xd3e37b85e82bdff4(256);
		}
		set
		{
			x87dffe4872c36e30(256, value);
		}
	}

	public double CropBottom
	{
		get
		{
			return xd3e37b85e82bdff4(257);
		}
		set
		{
			x87dffe4872c36e30(257, value);
		}
	}

	public double CropLeft
	{
		get
		{
			return xd3e37b85e82bdff4(258);
		}
		set
		{
			x87dffe4872c36e30(258, value);
		}
	}

	public double CropRight
	{
		get
		{
			return xd3e37b85e82bdff4(259);
		}
		set
		{
			x87dffe4872c36e30(259, value);
		}
	}

	public BorderCollection Borders
	{
		get
		{
			if (x52f94035dff03a3d == null)
			{
				x52f94035dff03a3d = new BorderCollection(this);
			}
			return x52f94035dff03a3d;
		}
	}

	public Color ChromaKey
	{
		get
		{
			return xa51f787cd3c1054d.xc7656a130b2889c7();
		}
		set
		{
			xa51f787cd3c1054d = x26d9ecb4bdf0456d.xcd907c08c553c15c(value);
		}
	}

	internal x26d9ecb4bdf0456d xa51f787cd3c1054d
	{
		get
		{
			return (x26d9ecb4bdf0456d)xfe91eeeafcb3026a(263);
		}
		set
		{
			xae20093bed1e48a8(263, value);
		}
	}

	public double Brightness
	{
		get
		{
			return x255a3096360f7e02(x4574ea26106f0edb.x97ab502db0c0e5c2((int)xfe91eeeafcb3026a(265)));
		}
		set
		{
			if (value < 0.0 || value > 1.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			xae20093bed1e48a8(265, x4574ea26106f0edb.x091b250f00534aae(x162213a92fe5bbc0(value)));
		}
	}

	public double Contrast
	{
		get
		{
			return x7186d4360cc84539(x4574ea26106f0edb.x97ab502db0c0e5c2((int)xfe91eeeafcb3026a(264)));
		}
		set
		{
			if (value < 0.0 || value > 1.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			xae20093bed1e48a8(264, x4574ea26106f0edb.x091b250f00534aae(x9db0f77f74058bc0(value)));
		}
	}

	public bool BiLevel
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(318);
		}
		set
		{
			xae20093bed1e48a8(318, value);
		}
	}

	public bool GrayScale
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(317);
		}
		set
		{
			xae20093bed1e48a8(317, value);
		}
	}

	internal bool x05c52fc2b5b2b094 => xc454c03c23d4b4d9.x048513c924d75f6b(263) != null;

	internal bool x169baa05e57bf312
	{
		get
		{
			if (ImageBytes != null)
			{
				return ImageBytes.Length > 0;
			}
			return false;
		}
	}

	SortedList x0e9935be205598e7.xa652231a0259f1c4 => x0504f8a641e0e833;

	internal ImageData(x7b71245a33212e76 parent, Document doc)
	{
		xc454c03c23d4b4d9 = parent;
		xbf762ca9cde15360 = new x8e500baeffc6e539(doc, new x85da6a35702db04e(parent));
	}

	public void SetImage(Image image)
	{
		xbf762ca9cde15360.xdb835d73003565c5(image);
	}

	[Obsolete("Please use the ImageBytes property to set an image.")]
	public void SetImage(byte[] imageBytes)
	{
		xbf762ca9cde15360.xcc18177a965e0313 = imageBytes;
	}

	[JavaInternal]
	public void SetImage(Stream stream)
	{
		xbf762ca9cde15360.xdb835d73003565c5(stream);
	}

	public void SetImage(string fileName)
	{
		xbf762ca9cde15360.xdb835d73003565c5(fileName);
	}

	public Image ToImage()
	{
		return xbf762ca9cde15360.x83e84e1d3bc59160();
	}

	public Stream ToStream()
	{
		return xbf762ca9cde15360.x3fd9dd6564874d14();
	}

	public byte[] ToByteArray()
	{
		return xbf762ca9cde15360.x2797b998ab68f4ab();
	}

	[JavaInternal]
	public void Save(Stream stream)
	{
		xbf762ca9cde15360.x0acd3c2012ea2ee8(stream);
	}

	public void Save(string fileName)
	{
		xbf762ca9cde15360.x0acd3c2012ea2ee8(fileName);
	}

	internal void x7a0cb9855dd2eab1(byte[] xf9a0d04800d70471)
	{
		xbf762ca9cde15360.x7a0cb9855dd2eab1(xf9a0d04800d70471);
	}

	internal x02df97c06afacbf3 x33295b3b60c18456()
	{
		return new x02df97c06afacbf3(CropLeft, CropRight, CropTop, CropBottom);
	}

	private double xd3e37b85e82bdff4(int xba08ce632055a1d9)
	{
		return x4574ea26106f0edb.x97ab502db0c0e5c2((int)xfe91eeeafcb3026a(xba08ce632055a1d9));
	}

	private void x87dffe4872c36e30(int xba08ce632055a1d9, double xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 < -1.0 || xbcea506a33cf9111 > 1.0)
		{
			throw new ArgumentOutOfRangeException("value");
		}
		xae20093bed1e48a8(xba08ce632055a1d9, x4574ea26106f0edb.x091b250f00534aae(xbcea506a33cf9111));
	}

	internal static double x255a3096360f7e02(double xeb9e3f0b1926b451)
	{
		if (xeb9e3f0b1926b451 < -0.5 || xeb9e3f0b1926b451 > 0.5)
		{
			throw new ArgumentOutOfRangeException("escherBrightness");
		}
		return xeb9e3f0b1926b451 + 0.5;
	}

	internal static double x162213a92fe5bbc0(double x4afa7e85b5b4d006)
	{
		if (x4afa7e85b5b4d006 < 0.0 || x4afa7e85b5b4d006 > 1.0)
		{
			throw new ArgumentOutOfRangeException("percent");
		}
		return x4afa7e85b5b4d006 - 0.5;
	}

	internal static double x7186d4360cc84539(double x9227a61eacee485c)
	{
		if (x9227a61eacee485c < 0.0)
		{
			throw new ArgumentOutOfRangeException("escherContrast");
		}
		if (x9227a61eacee485c <= 1.0)
		{
			return x9227a61eacee485c / 2.0;
		}
		return (x9227a61eacee485c - 0.5) / x9227a61eacee485c;
	}

	internal static double x9db0f77f74058bc0(double x4afa7e85b5b4d006)
	{
		if (x4afa7e85b5b4d006 < 0.0 || x4afa7e85b5b4d006 > 1.0)
		{
			throw new ArgumentOutOfRangeException("percent");
		}
		if (x4afa7e85b5b4d006 <= 0.5)
		{
			return x4afa7e85b5b4d006 * 2.0;
		}
		if (x4afa7e85b5b4d006 < 1.0)
		{
			return 0.5 / (1.0 - x4afa7e85b5b4d006);
		}
		return double.MaxValue;
	}

	private object xfe91eeeafcb3026a(int xba08ce632055a1d9)
	{
		return xc454c03c23d4b4d9.xfc928672852cc4c4(xba08ce632055a1d9);
	}

	private void xae20093bed1e48a8(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		xc454c03c23d4b4d9.x0817d5cde9e19bf6(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	private object x4497e36644489fd4(int xba08ce632055a1d9)
	{
		return xc454c03c23d4b4d9.x048513c924d75f6b(xba08ce632055a1d9);
	}

	object x0e9935be205598e7.x6e9ebce5ff38cae9(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x4497e36644489fd4
		return this.x4497e36644489fd4(xba08ce632055a1d9);
	}

	private object x38e65374c3e63df4(int xba08ce632055a1d9)
	{
		return xc454c03c23d4b4d9.x21ab6fa9997bd6d3(xba08ce632055a1d9);
	}

	object x0e9935be205598e7.x3087b5fa67bcf3f4(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x38e65374c3e63df4
		return this.x38e65374c3e63df4(xba08ce632055a1d9);
	}

	private void xf448a09b8f5e15e8(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		xae20093bed1e48a8(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	void x0e9935be205598e7.x039f0f0de50f5575(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xf448a09b8f5e15e8
		this.xf448a09b8f5e15e8(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	static ImageData()
	{
		x0504f8a641e0e833 = new SortedList();
		x0504f8a641e0e833.Add(BorderType.Top, 4106);
		x0504f8a641e0e833.Add(BorderType.Left, 4107);
		x0504f8a641e0e833.Add(BorderType.Bottom, 4108);
		x0504f8a641e0e833.Add(BorderType.Right, 4109);
	}

	internal byte[] x096dc407252fbea0()
	{
		return xbf762ca9cde15360.x096dc407252fbea0();
	}
}
