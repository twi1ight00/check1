using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using x38a89dee67fc7a16;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xe9865c3fb834da49;

namespace Aspose.Words.Saving;

public class ImageSaveOptions : SaveOptions, x1009bb9dacdb7e53, x99fd4075192789b2
{
	private SaveFormat xdeadbdaa7eaefd95;

	private int xe94c98f592fab2c8;

	private int x0c50d58c51fb0ad7 = int.MaxValue;

	private x26d9ecb4bdf0456d x27ef8cc2eb2a2c9c = x26d9ecb4bdf0456d.x8f02f53f1587477d;

	private ImagePixelFormat xeead61f95d325ffe = ImagePixelFormat.Format32BppArgb;

	private float x24e534029b4ff3e0 = 96f;

	private int x5334cbf633e0b0a1 = 95;

	private TiffCompression x78158e410116f7d2 = TiffCompression.Lzw;

	private ImageColorMode x693aa13c99b372f1;

	private float x3024781687a7fda2 = 0.5f;

	private float x365ea2e7446c49d4 = 0.5f;

	private float x53f147a75a984b21 = 1f;

	private EmfType xd7a95afdd881f60b = EmfType.EmfPlusDual;

	private NumeralFormat x1f7ceef97f47be57;

	private static readonly Hashtable x8f41b1b2beaeb468;

	private static readonly Hashtable x41e5b18e5b766001;

	private static readonly Hashtable xd4674c3ed1cbbddf;

	private static readonly Hashtable x3483092a3a8145a8;

	private static readonly Hashtable xa3434d8d7750a651;

	private static readonly Hashtable xaa45f0ee72d9ca93;

	public override SaveFormat SaveFormat
	{
		get
		{
			return xdeadbdaa7eaefd95;
		}
		set
		{
			x144c0b7717868eb8(value);
		}
	}

	internal override bool xda76bf558c43e688 => false;

	public int PageIndex
	{
		get
		{
			return xe94c98f592fab2c8;
		}
		set
		{
			xe94c98f592fab2c8 = value;
		}
	}

	public int PageCount
	{
		get
		{
			return x0c50d58c51fb0ad7;
		}
		set
		{
			x0c50d58c51fb0ad7 = value;
		}
	}

	public Color PaperColor
	{
		get
		{
			return x27ef8cc2eb2a2c9c.xc7656a130b2889c7();
		}
		set
		{
			x27ef8cc2eb2a2c9c = x26d9ecb4bdf0456d.xcd907c08c553c15c(value);
		}
	}

	[JavaDelete("ImagePixelFormat not ported to Java yet.")]
	public ImagePixelFormat PixelFormat
	{
		get
		{
			return xeead61f95d325ffe;
		}
		set
		{
			xeead61f95d325ffe = value;
		}
	}

	public float Resolution
	{
		get
		{
			return x24e534029b4ff3e0;
		}
		set
		{
			if (value <= 0f)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			x24e534029b4ff3e0 = value;
		}
	}

	public int JpegQuality
	{
		get
		{
			return x5334cbf633e0b0a1;
		}
		set
		{
			if (value < 0 || value > 100)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			x5334cbf633e0b0a1 = value;
		}
	}

	public TiffCompression TiffCompression
	{
		get
		{
			return x78158e410116f7d2;
		}
		set
		{
			x78158e410116f7d2 = value;
		}
	}

	public ImageColorMode ImageColorMode
	{
		get
		{
			return x693aa13c99b372f1;
		}
		set
		{
			x693aa13c99b372f1 = value;
		}
	}

	public float ImageBrightness
	{
		get
		{
			return x3024781687a7fda2;
		}
		set
		{
			if (value < 0f || value > 1f)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			x3024781687a7fda2 = value;
		}
	}

	public float ImageContrast
	{
		get
		{
			return x365ea2e7446c49d4;
		}
		set
		{
			if (value < 0f || value > 1f)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			x365ea2e7446c49d4 = value;
		}
	}

	public float Scale
	{
		get
		{
			return x53f147a75a984b21;
		}
		set
		{
			if (value <= 0f)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			x53f147a75a984b21 = value;
		}
	}

	public NumeralFormat NumeralFormat
	{
		get
		{
			return x1f7ceef97f47be57;
		}
		set
		{
			x1f7ceef97f47be57 = value;
		}
	}

	[JavaDelete("Rendering to EMF is not ported to Java.")]
	internal EmfType xa921e223ffb8ac41
	{
		get
		{
			return xd7a95afdd881f60b;
		}
		set
		{
			xd7a95afdd881f60b = value;
		}
	}

	internal x26d9ecb4bdf0456d x64debce685f4c70c => x27ef8cc2eb2a2c9c;

	internal xb56653ec61f2ac36 xb56653ec61f2ac36 => (xb56653ec61f2ac36)x682712679dbc585a.xce92de628aa023cf(x41e5b18e5b766001, x693aa13c99b372f1);

	internal PixelFormat xc8eead30a36b30c5 => (PixelFormat)x682712679dbc585a.xce92de628aa023cf(x3483092a3a8145a8, xeead61f95d325ffe);

	internal x858159a2ee718ca5 x858159a2ee718ca5 => (x858159a2ee718ca5)x682712679dbc585a.xce92de628aa023cf(xaa45f0ee72d9ca93, x78158e410116f7d2);

	public ImageSaveOptions(SaveFormat saveFormat)
	{
		x144c0b7717868eb8(saveFormat);
	}

	private void x144c0b7717868eb8(SaveFormat xd003f66121eb36a0)
	{
		switch (xd003f66121eb36a0)
		{
		case SaveFormat.Tiff:
		case SaveFormat.Png:
		case SaveFormat.Bmp:
		case SaveFormat.Emf:
		case SaveFormat.Jpeg:
			xdeadbdaa7eaefd95 = xd003f66121eb36a0;
			break;
		default:
			throw new ArgumentException("An invalid SaveFormat for this options type was chosen.");
		}
	}

	private NumeralFormat x1c4fae32ddb5d010()
	{
		return x1f7ceef97f47be57;
	}

	NumeralFormat x99fd4075192789b2.xce9c42bd4e3f2c89()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x1c4fae32ddb5d010
		return this.x1c4fae32ddb5d010();
	}

	public ImageSaveOptions Clone()
	{
		return (ImageSaveOptions)MemberwiseClone();
	}

	private x03d8a7b5b983d366 x52f64fbb3dc455c2()
	{
		return new x03d8a7b5b983d366(xe94c98f592fab2c8, x0c50d58c51fb0ad7);
	}

	x03d8a7b5b983d366 x1009bb9dacdb7e53.x0d2c113a382af9d3()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x52f64fbb3dc455c2
		return this.x52f64fbb3dc455c2();
	}

	static ImageSaveOptions()
	{
		x8f41b1b2beaeb468 = new Hashtable();
		x41e5b18e5b766001 = new Hashtable();
		xd4674c3ed1cbbddf = new Hashtable();
		x3483092a3a8145a8 = new Hashtable();
		xa3434d8d7750a651 = new Hashtable();
		xaa45f0ee72d9ca93 = new Hashtable();
		x682712679dbc585a.x70fa1602ceccddee(new object[6]
		{
			xb56653ec61f2ac36.x4d0b9d4447ba7566,
			ImageColorMode.None,
			xb56653ec61f2ac36.x478ac70dbc87f772,
			ImageColorMode.BlackAndWhite,
			xb56653ec61f2ac36.x3d4eb3afdab166b1,
			ImageColorMode.Grayscale
		}, x8f41b1b2beaeb468, x41e5b18e5b766001);
		x682712679dbc585a.x70fa1602ceccddee(new object[20]
		{
			System.Drawing.Imaging.PixelFormat.Format16bppArgb1555,
			ImagePixelFormat.Format16BppArgb1555,
			System.Drawing.Imaging.PixelFormat.Format16bppRgb555,
			ImagePixelFormat.Format16BppRgb555,
			System.Drawing.Imaging.PixelFormat.Format16bppRgb565,
			ImagePixelFormat.Format16BppRgb565,
			System.Drawing.Imaging.PixelFormat.Format24bppRgb,
			ImagePixelFormat.Format24BppRgb,
			System.Drawing.Imaging.PixelFormat.Format32bppArgb,
			ImagePixelFormat.Format32BppArgb,
			System.Drawing.Imaging.PixelFormat.Format32bppRgb,
			ImagePixelFormat.Format32BppRgb,
			System.Drawing.Imaging.PixelFormat.Format32bppPArgb,
			ImagePixelFormat.Format32BppPArgb,
			System.Drawing.Imaging.PixelFormat.Format48bppRgb,
			ImagePixelFormat.Format48BppRgb,
			System.Drawing.Imaging.PixelFormat.Format64bppArgb,
			ImagePixelFormat.Format64BppArgb,
			System.Drawing.Imaging.PixelFormat.Format64bppPArgb,
			ImagePixelFormat.Format64BppPArgb
		}, xd4674c3ed1cbbddf, x3483092a3a8145a8);
		x682712679dbc585a.x70fa1602ceccddee(new object[10]
		{
			x858159a2ee718ca5.xf6875da725c82a98,
			TiffCompression.Ccitt3,
			x858159a2ee718ca5.xd9c34d7c9f00a2f9,
			TiffCompression.Ccitt4,
			x858159a2ee718ca5.x79eafe89940e5b0e,
			TiffCompression.Lzw,
			x858159a2ee718ca5.x67749da60288d66c,
			TiffCompression.Rle,
			x858159a2ee718ca5.x4d0b9d4447ba7566,
			TiffCompression.None
		}, xa3434d8d7750a651, xaa45f0ee72d9ca93);
	}
}
