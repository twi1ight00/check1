using System;
using x28925c9b27b37a46;
using x4f4df92b75ba3b67;
using xe9865c3fb834da49;

namespace Aspose.Words.Saving;

public class PdfSaveOptions : SaveOptions, x1009bb9dacdb7e53, x99fd4075192789b2
{
	private PdfDigitalSignatureDetails x4be737bffe2129ea;

	private int xe94c98f592fab2c8;

	private int x0c50d58c51fb0ad7 = int.MaxValue;

	private int xa3f14f56617da4ce;

	private int x6efe68e6aabe9b31;

	private int xdb7f6aff14a27e60;

	private PdfTextCompression xbdc6190dc5bf3ad6 = PdfTextCompression.Flate;

	private PdfCompliance x38f73f642a5eb695;

	private int x5334cbf633e0b0a1 = 100;

	private bool x293388dcffa316cc;

	private bool x82d504937559d995;

	private PdfEncryptionDetails x46decbb84d242e96;

	private bool x22cc744aeaa88cf5 = true;

	private bool x8cf30d3ed8c88d45;

	private bool x317da23b74aff8e5;

	private PdfZoomBehavior x8dd4401983de7185;

	private int x1fbc765ed8d7e811;

	private NumeralFormat x1f7ceef97f47be57;

	private readonly MetafileRenderingOptions xedeee4e28b7ff47f = new MetafileRenderingOptions();

	public override SaveFormat SaveFormat
	{
		get
		{
			return SaveFormat.Pdf;
		}
		set
		{
			if (value != SaveFormat.Pdf)
			{
				throw new ArgumentException("An invalid SaveFormat for this options type was chosen.");
			}
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

	public int HeadingsOutlineLevels
	{
		get
		{
			return xa3f14f56617da4ce;
		}
		set
		{
			if (value < 0 || value > 9)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			xa3f14f56617da4ce = value;
		}
	}

	public int ExpandedOutlineLevels
	{
		get
		{
			return x6efe68e6aabe9b31;
		}
		set
		{
			if (value < 0 || value > 9)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			x6efe68e6aabe9b31 = value;
		}
	}

	public int BookmarksOutlineLevel
	{
		get
		{
			return xdb7f6aff14a27e60;
		}
		set
		{
			if (value < 0 || value > 9)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			xdb7f6aff14a27e60 = value;
		}
	}

	public PdfTextCompression TextCompression
	{
		get
		{
			return xbdc6190dc5bf3ad6;
		}
		set
		{
			xbdc6190dc5bf3ad6 = value;
		}
	}

	public PdfCompliance Compliance
	{
		get
		{
			return x38f73f642a5eb695;
		}
		set
		{
			x38f73f642a5eb695 = value;
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

	public bool PreserveFormFields
	{
		get
		{
			return x293388dcffa316cc;
		}
		set
		{
			x293388dcffa316cc = value;
		}
	}

	public PdfEncryptionDetails EncryptionDetails
	{
		get
		{
			return x46decbb84d242e96;
		}
		set
		{
			x46decbb84d242e96 = value;
		}
	}

	public PdfDigitalSignatureDetails DigitalSignatureDetails
	{
		get
		{
			return x4be737bffe2129ea;
		}
		set
		{
			x4be737bffe2129ea = value;
		}
	}

	public bool EmbedFullFonts
	{
		get
		{
			return x82d504937559d995;
		}
		set
		{
			x82d504937559d995 = value;
		}
	}

	public bool EmbedStandardWindowsFonts
	{
		get
		{
			return x22cc744aeaa88cf5;
		}
		set
		{
			x22cc744aeaa88cf5 = value;
		}
	}

	public bool UseCoreFonts
	{
		get
		{
			return x8cf30d3ed8c88d45;
		}
		set
		{
			x8cf30d3ed8c88d45 = value;
		}
	}

	public bool ExportCustomPropertiesAsMetadata
	{
		get
		{
			return x317da23b74aff8e5;
		}
		set
		{
			x317da23b74aff8e5 = value;
		}
	}

	public PdfZoomBehavior ZoomBehavior
	{
		get
		{
			return x8dd4401983de7185;
		}
		set
		{
			x8dd4401983de7185 = value;
		}
	}

	public int ZoomFactor
	{
		get
		{
			return x1fbc765ed8d7e811;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			x1fbc765ed8d7e811 = value;
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

	[Obsolete("Use MetafileRenderingOptions.RenderingMode property.")]
	[JavaInternal]
	public MetafileRenderingMode MetafileRenderingMode
	{
		get
		{
			return MetafileRenderingOptions.RenderingMode;
		}
		set
		{
			MetafileRenderingOptions.RenderingMode = value;
		}
	}

	public MetafileRenderingOptions MetafileRenderingOptions => xedeee4e28b7ff47f;

	public PdfSaveOptions Clone()
	{
		return (PdfSaveOptions)MemberwiseClone();
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

	internal xd0e7b6ac3d6a3950 x5eff1f3a09faac7e()
	{
		xd0e7b6ac3d6a3950 xd0e7b6ac3d6a = new xd0e7b6ac3d6a3950();
		xd0e7b6ac3d6a.xcaedf7c40a4ec358 = xa3f14f56617da4ce;
		xd0e7b6ac3d6a.x6b12d92d6782ee94 = x6efe68e6aabe9b31;
		xd0e7b6ac3d6a.x9b6007a17b33a42b = xdb7f6aff14a27e60;
		xd0e7b6ac3d6a.x5f45bae3337a9d27 = x254b8e0d5c68f194.x4d7be58ea3ab7854(xbdc6190dc5bf3ad6);
		xd0e7b6ac3d6a.x0b744c5c26c5b3b3 = x254b8e0d5c68f194.xba187b84c1028357(x38f73f642a5eb695);
		xd0e7b6ac3d6a.xf7575b7b1ee35d49 = x5334cbf633e0b0a1;
		xd0e7b6ac3d6a.x977582846a207e5e = x82d504937559d995;
		xd0e7b6ac3d6a.xd2c8b9d8784ba23d = x22cc744aeaa88cf5;
		xd0e7b6ac3d6a.x71274a3323f4303d = x8cf30d3ed8c88d45;
		xd0e7b6ac3d6a.xba780c56881ff4f7 = x317da23b74aff8e5;
		xd0e7b6ac3d6a.xafc42de38a25321a = MetafileRenderingOptions.x5eff1f3a09faac7e();
		if (x46decbb84d242e96 != null)
		{
			xd0e7b6ac3d6a.x9da647d0334b8864 = x46decbb84d242e96.x5eff1f3a09faac7e();
		}
		if (x4be737bffe2129ea != null)
		{
			xd0e7b6ac3d6a.xf0c8dca398b16b43 = x4be737bffe2129ea.x5eff1f3a09faac7e();
		}
		if (ZoomBehavior != 0)
		{
			xd0e7b6ac3d6a.xa8c6944aca2d6edc = true;
			xd0e7b6ac3d6a.x6912ee5d48e468f3 = x254b8e0d5c68f194.x48717d189e1ac4b2(x8dd4401983de7185);
			xd0e7b6ac3d6a.xd83c2eee63f2eabf = (float)ZoomFactor / 100f;
		}
		xd0e7b6ac3d6a.xe1be84fa0dab2c38(new x7c8328a75e9baa2d(base.WarningCallback));
		return xd0e7b6ac3d6a;
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
}
