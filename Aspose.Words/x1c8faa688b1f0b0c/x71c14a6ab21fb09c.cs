using System;
using System.IO;
using Aspose;
using x38a89dee67fc7a16;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x1c8faa688b1f0b0c;

internal abstract class x71c14a6ab21fb09c
{
	private int x5334cbf633e0b0a1 = 95;

	private x54b98d0096d7251a xa056586c1f99e199;

	private x3959df40367ac8a3 x006c2eca1459fa26;

	protected x71c14a6ab21fb09c(int jpegQuality, x54b98d0096d7251a warningCallback, x3959df40367ac8a3 warningSource)
	{
		x5334cbf633e0b0a1 = jpegQuality;
		xa056586c1f99e199 = warningCallback;
		x006c2eca1459fa26 = warningSource;
	}

	internal byte[] x601e9a2243ca6720(byte[] x43e181e083db6cdf)
	{
		if (xfb5afe0c4cc0f96b(x43e181e083db6cdf))
		{
			return x43e181e083db6cdf;
		}
		try
		{
			using x3cd5d648729cd9b6 x4e889a1a809d1ee = new x3cd5d648729cd9b6(x43e181e083db6cdf);
			return x601e9a2243ca6720(x4e889a1a809d1ee);
		}
		catch
		{
			return x0d299f323d241756.xcd6c2a9742c9220a();
		}
	}

	internal byte[] x601e9a2243ca6720(x3cd5d648729cd9b6 x4e889a1a809d1ee2)
	{
		MemoryStream memoryStream = new MemoryStream();
		if (x87f8d22ca4dc9041(x4e889a1a809d1ee2.x688d6f6524ba3c8b))
		{
			x4e889a1a809d1ee2.x0acd3c2012ea2ee8(memoryStream, x4e889a1a809d1ee2.x688d6f6524ba3c8b);
		}
		else if (x4e889a1a809d1ee2.x688d6f6524ba3c8b == xfe2ff3c162b47c70.x8e716ec1cb703e9f && x87f8d22ca4dc9041(xfe2ff3c162b47c70.x6339cdb9e2b512c7))
		{
			x4e889a1a809d1ee2.x0acd3c2012ea2ee8(memoryStream, xfe2ff3c162b47c70.x6339cdb9e2b512c7);
			xa056586c1f99e199.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x13efdeb5b4f0d186, x006c2eca1459fa26, "GIF images are not supported, image converted to PNG");
		}
		else
		{
			x4e889a1a809d1ee2.x2746a43e49feca2f(memoryStream, x5334cbf633e0b0a1);
			string xe88104aeaa19b45d = ((x4e889a1a809d1ee2.x688d6f6524ba3c8b == xfe2ff3c162b47c70.xf6c17f648b65c793) ? "Unknown" : xb9015fe823e7e228.xac88cb4f794761a9(x4e889a1a809d1ee2.x688d6f6524ba3c8b));
			xa056586c1f99e199.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x13efdeb5b4f0d186, x006c2eca1459fa26, "{0} images are not supported, image converted to JPEG", xe88104aeaa19b45d);
		}
		return x0d299f323d241756.xa0aed4cd3b3d5d92(memoryStream);
	}

	internal byte[] xe323925c2800577d(byte[] x43e181e083db6cdf, x02df97c06afacbf3 x5edc4e0499c937b4)
	{
		try
		{
			if (x5edc4e0499c937b4 != null && x5edc4e0499c937b4.x523ab7004b988e96)
			{
				using x3cd5d648729cd9b6 x4e889a1a809d1ee = x5edc4e0499c937b4.xa4e45e1d9e114000(x43e181e083db6cdf);
				x43e181e083db6cdf = x601e9a2243ca6720(x4e889a1a809d1ee);
			}
		}
		catch (Exception ex)
		{
			xa056586c1f99e199.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x13efdeb5b4f0d186, x006c2eca1459fa26, $"Image cannot be cropped because: {ex.Message}");
		}
		return x43e181e083db6cdf;
	}

	[JavaThrows(true)]
	internal virtual bool xfb5afe0c4cc0f96b(byte[] x43e181e083db6cdf)
	{
		xfe2ff3c162b47c70 x0182a6dae298f8a = xdd1b8f14cc8ba86d.x22bfb60fc9ca9282(x43e181e083db6cdf);
		return x87f8d22ca4dc9041(x0182a6dae298f8a);
	}

	internal virtual bool x87f8d22ca4dc9041(xfe2ff3c162b47c70 x0182a6dae298f8a4)
	{
		return false;
	}
}
