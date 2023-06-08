using System;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xc7ce8a6a920f8012;
using xe9865c3fb834da49;

namespace Aspose.Words.Saving;

public class SwfSaveOptions : SaveOptions, x1009bb9dacdb7e53, x99fd4075192789b2
{
	private const string x8ed6be0d97160da6 = "Arial";

	private int xe94c98f592fab2c8;

	private int x0c50d58c51fb0ad7 = int.MaxValue;

	private bool x0ffb6df7204de961 = true;

	private bool x0bdefa4306b9a05c = true;

	private int xa3f14f56617da4ce;

	private int x6efe68e6aabe9b31;

	private int xdb7f6aff14a27e60;

	private bool xe0300c6a6fcde986 = true;

	private SwfTopPaneControlFlags x4dfd9fc3808f1a1f = SwfTopPaneControlFlags.ShowAll;

	private SwfLeftPaneControlFlags x981ff9e6e59257b4 = SwfLeftPaneControlFlags.ShowAll;

	private bool xf1ae3202d4a6c4d5 = true;

	private bool xf6f5b9411cc1396d = true;

	private bool x05ec5cd60cf4b0d0 = true;

	private bool x2eeb56afc729a7da = true;

	private bool xfc646808e30fa971 = true;

	private bool x7805f76400718d30 = true;

	private bool x96b93e9730ef099e;

	private bool x7a2b1a8435f49b46 = true;

	private bool x89dd0f747de6e513 = true;

	private byte[] x917532dc9008c34f;

	private string xb8a02b9785405cd0;

	private string x45edb13b15a4c9e8 = "Arial";

	private SwfToolTips xb39800d44249c707 = new SwfToolTips();

	private int x5334cbf633e0b0a1 = 95;

	private NumeralFormat x1f7ceef97f47be57;

	public override SaveFormat SaveFormat
	{
		get
		{
			return SaveFormat.Swf;
		}
		set
		{
			if (value != SaveFormat.Swf)
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

	public bool Compressed
	{
		get
		{
			return x0ffb6df7204de961;
		}
		set
		{
			x0ffb6df7204de961 = value;
		}
	}

	public bool ViewerIncluded
	{
		get
		{
			return x0bdefa4306b9a05c;
		}
		set
		{
			x0bdefa4306b9a05c = value;
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

	public bool ShowPageBorder
	{
		get
		{
			return xe0300c6a6fcde986;
		}
		set
		{
			xe0300c6a6fcde986 = value;
		}
	}

	public bool ShowFullScreen
	{
		get
		{
			return xf1ae3202d4a6c4d5;
		}
		set
		{
			xf1ae3202d4a6c4d5 = value;
		}
	}

	public bool ShowPageStepper
	{
		get
		{
			return xf6f5b9411cc1396d;
		}
		set
		{
			xf6f5b9411cc1396d = value;
		}
	}

	public bool ShowSearch
	{
		get
		{
			return x05ec5cd60cf4b0d0;
		}
		set
		{
			x05ec5cd60cf4b0d0 = value;
		}
	}

	public bool ShowTopPane
	{
		get
		{
			return x2eeb56afc729a7da;
		}
		set
		{
			x2eeb56afc729a7da = value;
		}
	}

	public bool ShowBottomPane
	{
		get
		{
			return xfc646808e30fa971;
		}
		set
		{
			xfc646808e30fa971 = value;
		}
	}

	public bool ShowLeftPane
	{
		get
		{
			return x7805f76400718d30;
		}
		set
		{
			x7805f76400718d30 = value;
		}
	}

	public bool StartOpenLeftPane
	{
		get
		{
			return x96b93e9730ef099e;
		}
		set
		{
			x96b93e9730ef099e = value;
		}
	}

	public bool AllowReadMode
	{
		get
		{
			return x7a2b1a8435f49b46;
		}
		set
		{
			x7a2b1a8435f49b46 = value;
		}
	}

	public bool EnableContextMenu
	{
		get
		{
			return x89dd0f747de6e513;
		}
		set
		{
			x89dd0f747de6e513 = value;
		}
	}

	public SwfTopPaneControlFlags TopPaneControlFlags
	{
		get
		{
			return x4dfd9fc3808f1a1f;
		}
		set
		{
			x4dfd9fc3808f1a1f = value;
		}
	}

	public SwfLeftPaneControlFlags LeftPaneControlFlags
	{
		get
		{
			return x981ff9e6e59257b4;
		}
		set
		{
			x981ff9e6e59257b4 = value;
		}
	}

	public byte[] LogoImageBytes
	{
		get
		{
			return x917532dc9008c34f;
		}
		set
		{
			x917532dc9008c34f = value;
		}
	}

	public string LogoLink
	{
		get
		{
			return xb8a02b9785405cd0;
		}
		set
		{
			xb8a02b9785405cd0 = value;
		}
	}

	public string ToolTipsFontName
	{
		get
		{
			return x45edb13b15a4c9e8;
		}
		set
		{
			x45edb13b15a4c9e8 = value;
		}
	}

	public SwfToolTips ToolTips => xb39800d44249c707;

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

	private NumeralFormat x1c4fae32ddb5d010()
	{
		return x1f7ceef97f47be57;
	}

	NumeralFormat x99fd4075192789b2.xce9c42bd4e3f2c89()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x1c4fae32ddb5d010
		return this.x1c4fae32ddb5d010();
	}

	internal xf62f848e5d3ba660 x5eff1f3a09faac7e()
	{
		xf62f848e5d3ba660 xf62f848e5d3ba = new xf62f848e5d3ba660();
		xf62f848e5d3ba.xaf09b1a5e6d60a5c = x0ffb6df7204de961;
		xf62f848e5d3ba.x50d413fba889b359 = x0bdefa4306b9a05c;
		xf62f848e5d3ba.x9b6007a17b33a42b = xdb7f6aff14a27e60;
		xf62f848e5d3ba.x6b12d92d6782ee94 = x6efe68e6aabe9b31;
		xf62f848e5d3ba.xcaedf7c40a4ec358 = xa3f14f56617da4ce;
		xf62f848e5d3ba.xc2e1b0b1bf7219c5 = xe0300c6a6fcde986;
		xf62f848e5d3ba.xf87cb1395914575c = xf1ae3202d4a6c4d5;
		xf62f848e5d3ba.x95d9e8797e4cd333 = xf6f5b9411cc1396d;
		xf62f848e5d3ba.x33444f9326ac61fb = x05ec5cd60cf4b0d0;
		xf62f848e5d3ba.x3e2affdc39719136 = x2eeb56afc729a7da;
		xf62f848e5d3ba.xbd9ac706e3f1b075 = xfc646808e30fa971;
		xf62f848e5d3ba.xb21850ba8e249cba = x7805f76400718d30;
		xf62f848e5d3ba.x279102e917642b7e = x96b93e9730ef099e;
		xf62f848e5d3ba.xa4866abd29e857a4 = x7a2b1a8435f49b46;
		xf62f848e5d3ba.x98366ee248c13eda = x89dd0f747de6e513;
		xf62f848e5d3ba.x594c3b7ff1a9e3ee = (int)x4dfd9fc3808f1a1f;
		xf62f848e5d3ba.x1b7f1e60fe3e4d73 = (int)x981ff9e6e59257b4;
		xf62f848e5d3ba.x7ebe0c078042f9e8 = x917532dc9008c34f;
		xf62f848e5d3ba.x423a4f3f3de80da8 = xb8a02b9785405cd0;
		xf62f848e5d3ba.x76c3b8e27e953ad6 = (x0d299f323d241756.x5959bccb67bbf051(x45edb13b15a4c9e8) ? x45edb13b15a4c9e8 : "Arial");
		xf62f848e5d3ba.xf7575b7b1ee35d49 = x5334cbf633e0b0a1;
		xf62f848e5d3ba.xe1be84fa0dab2c38(new x7c8328a75e9baa2d(base.WarningCallback));
		xb39800d44249c707.x5eff1f3a09faac7e(xf62f848e5d3ba);
		return xf62f848e5d3ba;
	}

	public SwfSaveOptions Clone()
	{
		return (SwfSaveOptions)MemberwiseClone();
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
