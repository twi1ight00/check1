using System;
using System.Drawing;
using System.IO;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Loading;
using x38a89dee67fc7a16;
using x6c95d9cf46ff5f25;
using x9b5b1a17490bd5f3;
using xe9fa6af9e1184312;
using xf9a9481c3f63a419;

namespace x011d489fb9df7027;

internal class x8e500baeffc6e539
{
	private readonly Document xd1424e1a0bb4a72b;

	private readonly xffb5c43a03777178 x0bd7f354c41c3e15;

	private ImageSize x40b8719f8a672c37;

	private static string xfd7518ca51a1013b;

	private static int x922c09bbf82ff9ba;

	internal string x9f8e4dc805c6986e
	{
		get
		{
			return x0bd7f354c41c3e15.x9f8e4dc805c6986e;
		}
		set
		{
			x0bd7f354c41c3e15.x9f8e4dc805c6986e = value;
		}
	}

	internal byte[] xcc18177a965e0313
	{
		get
		{
			return x0bd7f354c41c3e15.xcc18177a965e0313;
		}
		set
		{
			x40b8719f8a672c37 = null;
			if (!xcd4bd3abd72ff2da.x57a8965bf85f0d71(value))
			{
				x0bd7f354c41c3e15.xcc18177a965e0313 = null;
			}
			else
			{
				x0bd7f354c41c3e15.xcc18177a965e0313 = (xdd1b8f14cc8ba86d.x5188b06a528c8ec9(value) ? xdad2bb39c82501b3(value) : x601e9a2243ca6720(value));
			}
		}
	}

	internal bool x13055c95ca5083f1
	{
		get
		{
			if (!x169baa05e57bf312)
			{
				return xce9657aabb6b6e6f;
			}
			return true;
		}
	}

	internal ImageSize x8d0c72c5b2891cbc
	{
		get
		{
			if (x40b8719f8a672c37 == null)
			{
				x40b8719f8a672c37 = (x169baa05e57bf312 ? new ImageSize(xdd1b8f14cc8ba86d.x16a7fb03c627ebfb(xcc18177a965e0313)) : new ImageSize(0, 0));
			}
			return x40b8719f8a672c37;
		}
	}

	internal ImageType x688d6f6524ba3c8b => FileFormatUtil.xd93505cfb3e61804(xfe2ff3c162b47c70);

	internal bool xce9657aabb6b6e6f => x0d299f323d241756.x5959bccb67bbf051(x0bd7f354c41c3e15.x9f8e4dc805c6986e);

	internal bool x66b8b219d7a8c7b2
	{
		get
		{
			if (xce9657aabb6b6e6f)
			{
				return !x169baa05e57bf312;
			}
			return false;
		}
	}

	internal bool x169baa05e57bf312 => xcd4bd3abd72ff2da.x57a8965bf85f0d71(xcc18177a965e0313);

	internal xfe2ff3c162b47c70 xfe2ff3c162b47c70
	{
		get
		{
			if (x169baa05e57bf312)
			{
				return xdd1b8f14cc8ba86d.x22bfb60fc9ca9282(xcc18177a965e0313);
			}
			if (xce9657aabb6b6e6f && x0bd7f354c41c3e15.x9f8e4dc805c6986e.Length > 0)
			{
				return xdd1b8f14cc8ba86d.x50ba8f29b1c5ad67(x0bd7f354c41c3e15.x9f8e4dc805c6986e);
			}
			return xfe2ff3c162b47c70.xf6c17f648b65c793;
		}
	}

	internal x8e500baeffc6e539(Document document, xffb5c43a03777178 imageDataSource)
	{
		xd1424e1a0bb4a72b = document;
		x0bd7f354c41c3e15 = imageDataSource;
	}

	internal void xdb835d73003565c5(Image xe058541ca798c059)
	{
		if (xe058541ca798c059 == null)
		{
			throw new ArgumentNullException("image");
		}
		using MemoryStream xcf18e5243f8d5fd = new MemoryStream();
		x3cd5d648729cd9b6.x367bb145e7fa9226(xe058541ca798c059, xcf18e5243f8d5fd);
		xdb835d73003565c5(xcf18e5243f8d5fd);
	}

	internal void xdb835d73003565c5(Stream xcf18e5243f8d5fd3)
	{
		if (xcf18e5243f8d5fd3 == null)
		{
			throw new ArgumentNullException("stream");
		}
		xcc18177a965e0313 = x0d299f323d241756.xa0aed4cd3b3d5d92(xcf18e5243f8d5fd3);
	}

	internal void xdb835d73003565c5(string xafe2f3653ee64ebc)
	{
		x0d299f323d241756.x48501aec8e48c869(xafe2f3653ee64ebc, "fileName");
		xcc18177a965e0313 = x096dc407252fbea0(xafe2f3653ee64ebc);
	}

	internal Image x83e84e1d3bc59160()
	{
		return x3cd5d648729cd9b6.x40854b0899c49243(x3fd9dd6564874d14());
	}

	internal Stream x3fd9dd6564874d14()
	{
		byte[] array = xcc18177a965e0313;
		if (xcd4bd3abd72ff2da.x57a8965bf85f0d71(array))
		{
			return new MemoryStream(array);
		}
		try
		{
			return new MemoryStream(x096dc407252fbea0(x0bd7f354c41c3e15.x9f8e4dc805c6986e));
		}
		catch (Exception)
		{
			return x0d299f323d241756.x2f4c87e11bfb8f32();
		}
	}

	internal byte[] x2797b998ab68f4ab()
	{
		byte[] array = xcc18177a965e0313;
		if (!xcd4bd3abd72ff2da.x57a8965bf85f0d71(array))
		{
			return xaf95a5debdc0edc1();
		}
		return array;
	}

	internal void x0acd3c2012ea2ee8(Stream xcf18e5243f8d5fd3)
	{
		if (xcf18e5243f8d5fd3 == null)
		{
			throw new ArgumentNullException("stream");
		}
		using Stream x23cda4cfdf81f2cf = x3fd9dd6564874d14();
		x0d299f323d241756.x3ad8e53785c39acd(x23cda4cfdf81f2cf, xcf18e5243f8d5fd3);
	}

	internal void x0acd3c2012ea2ee8(string xafe2f3653ee64ebc)
	{
		x0d299f323d241756.x48501aec8e48c869(xafe2f3653ee64ebc, "fileName");
		using Stream xcf18e5243f8d5fd = File.Create(xafe2f3653ee64ebc);
		x0acd3c2012ea2ee8(xcf18e5243f8d5fd);
	}

	internal void x7a0cb9855dd2eab1(byte[] x43e181e083db6cdf)
	{
		try
		{
			if (xfd7518ca51a1013b != null)
			{
				x0f03644a2f40f83e(x43e181e083db6cdf);
			}
			xcc18177a965e0313 = x43e181e083db6cdf;
		}
		catch
		{
		}
	}

	private void x0f03644a2f40f83e(byte[] x43e181e083db6cdf)
	{
		try
		{
			if (!Directory.Exists(xfd7518ca51a1013b))
			{
				Directory.CreateDirectory(xfd7518ca51a1013b);
			}
			string path = xfd7518ca51a1013b + Path.DirectorySeparatorChar + Path.GetFileName(xd1424e1a0bb4a72b.OriginalFileName) + "." + ++x922c09bbf82ff9ba + "." + xb9015fe823e7e228.xac88cb4f794761a9(xdd1b8f14cc8ba86d.x22bfb60fc9ca9282(x43e181e083db6cdf));
			using Stream stream = File.Create(path);
			stream.Write(x43e181e083db6cdf, 0, x43e181e083db6cdf.Length);
			stream.Flush();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	internal byte[] x096dc407252fbea0()
	{
		return x096dc407252fbea0(x0bd7f354c41c3e15.x9f8e4dc805c6986e);
	}

	internal byte[] x096dc407252fbea0(string xafe2f3653ee64ebc)
	{
		byte[] result = null;
		if (xd1424e1a0bb4a72b.ResourceLoadingCallback != null)
		{
			ResourceLoadingArgs resourceLoadingArgs = new ResourceLoadingArgs("", xafe2f3653ee64ebc, ResourceType.Image);
			switch (xd1424e1a0bb4a72b.ResourceLoadingCallback.ResourceLoading(resourceLoadingArgs))
			{
			case ResourceLoadingAction.UserProvided:
				result = resourceLoadingArgs.xd378208b5267f7e2();
				break;
			case ResourceLoadingAction.Default:
				result = x3b5b48028135ffcc(xafe2f3653ee64ebc);
				break;
			case ResourceLoadingAction.Skip:
				result = x0d299f323d241756.xcd6c2a9742c9220a();
				break;
			}
		}
		else
		{
			result = x3b5b48028135ffcc(xafe2f3653ee64ebc);
		}
		return result;
	}

	private byte[] x3b5b48028135ffcc(string xafe2f3653ee64ebc)
	{
		byte[] result = null;
		try
		{
			using Stream x23cda4cfdf81f2cf = xed158952e6342987.x1e9addd30221cf4d(xd1424e1a0bb4a72b, xafe2f3653ee64ebc);
			result = x0d299f323d241756.xa0aed4cd3b3d5d92(x23cda4cfdf81f2cf);
		}
		catch
		{
		}
		return result;
	}

	private byte[] xaf95a5debdc0edc1()
	{
		byte[] array = x096dc407252fbea0();
		if (array == null)
		{
			return x0d299f323d241756.xcd6c2a9742c9220a();
		}
		return array;
	}

	private byte[] xdad2bb39c82501b3(byte[] x43e181e083db6cdf)
	{
		using MemoryStream stream = new MemoryStream(x43e181e083db6cdf);
		x95792ebebfd0979f x95792ebebfd0979f = new x95792ebebfd0979f(stream, xd1424e1a0bb4a72b.xb93d084d48e486dd, new x0cd0eeb5ca95cea9(xd1424e1a0bb4a72b.ResourceLoadingCallback), null);
		x4bb20e393c4d7846 x4bb20e393c4d = x95792ebebfd0979f.x06b0e25aa6ad68a9();
		using MemoryStream memoryStream = new MemoryStream();
		x4bb20e393c4d.x0acd3c2012ea2ee8(memoryStream, xfe2ff3c162b47c70.x6339cdb9e2b512c7);
		x43e181e083db6cdf = x0d299f323d241756.xa0aed4cd3b3d5d92(memoryStream);
		return x43e181e083db6cdf;
	}

	internal static byte[] x601e9a2243ca6720(byte[] x43e181e083db6cdf)
	{
		if (x798360f2e0cd0117(x43e181e083db6cdf))
		{
			if (xdd1b8f14cc8ba86d.xa112135733098ff7(x43e181e083db6cdf))
			{
				x43e181e083db6cdf = xdd1b8f14cc8ba86d.x300bc69d382eb52c(x43e181e083db6cdf, xdd1b8f14cc8ba86d.x59837dfeb1fc5a82(x43e181e083db6cdf));
			}
		}
		else
		{
			using x3cd5d648729cd9b6 x3cd5d648729cd9b = new x3cd5d648729cd9b6(x43e181e083db6cdf);
			using MemoryStream memoryStream = new MemoryStream();
			x3cd5d648729cd9b.x0acd3c2012ea2ee8(memoryStream, xfe2ff3c162b47c70.x6339cdb9e2b512c7);
			x43e181e083db6cdf = x0d299f323d241756.xa0aed4cd3b3d5d92(memoryStream);
		}
		return x43e181e083db6cdf;
	}

	private static bool x798360f2e0cd0117(byte[] xf1c258adc3c53c0e)
	{
		return x798360f2e0cd0117(xdd1b8f14cc8ba86d.x22bfb60fc9ca9282(xf1c258adc3c53c0e));
	}

	private static bool x798360f2e0cd0117(xfe2ff3c162b47c70 x0182a6dae298f8a4)
	{
		switch (x0182a6dae298f8a4)
		{
		case xfe2ff3c162b47c70.xd69df86e2a88ddb2:
		case xfe2ff3c162b47c70.xb5fe04c34562f438:
		case xfe2ff3c162b47c70.x26c36dd85013b919:
		case xfe2ff3c162b47c70.x796ab23ce57ee1e0:
		case xfe2ff3c162b47c70.x6339cdb9e2b512c7:
			return true;
		default:
			return false;
		}
	}

	internal static void x2311df4ec1a6218b(string xe83bef4ca199d0c6)
	{
		xfd7518ca51a1013b = xe83bef4ca199d0c6;
	}
}
