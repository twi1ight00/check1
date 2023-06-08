using System;
using x28925c9b27b37a46;
using x7dc87ca8f7f7b273;
using xe9865c3fb834da49;

namespace Aspose.Words.Saving;

public class SvgSaveOptions : SaveOptions, x1009bb9dacdb7e53, x99fd4075192789b2
{
	private bool xe0300c6a6fcde986 = true;

	private SvgTextOutputMode x1d3ab847536f56e2 = SvgTextOutputMode.UseTargetMachineFonts;

	private string x6d013c1e0924eebe;

	private string xa2fff74252bae51d;

	private int x5334cbf633e0b0a1 = 95;

	private bool x7915ced651964d5a;

	private int x0c50d58c51fb0ad7 = int.MaxValue;

	private int xe94c98f592fab2c8;

	private NumeralFormat x1f7ceef97f47be57;

	private readonly MetafileRenderingOptions xedeee4e28b7ff47f = new MetafileRenderingOptions();

	public override SaveFormat SaveFormat
	{
		get
		{
			return SaveFormat.Svg;
		}
		set
		{
			if (value != SaveFormat.Svg)
			{
				throw new ArgumentException("An invalid SaveFormat for this options type was chosen.");
			}
		}
	}

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

	internal override bool xda76bf558c43e688 => false;

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

	public SvgTextOutputMode TextOutputMode
	{
		get
		{
			return x1d3ab847536f56e2;
		}
		set
		{
			x1d3ab847536f56e2 = value;
		}
	}

	public string ResourcesFolder
	{
		get
		{
			return x6d013c1e0924eebe;
		}
		set
		{
			x6d013c1e0924eebe = value;
		}
	}

	public string ResourcesFolderAlias
	{
		get
		{
			return xa2fff74252bae51d;
		}
		set
		{
			xa2fff74252bae51d = value;
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
				throw new ArgumentException("value");
			}
			x5334cbf633e0b0a1 = value;
		}
	}

	public bool ExportEmbeddedImages
	{
		get
		{
			return x7915ced651964d5a;
		}
		set
		{
			x7915ced651964d5a = value;
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

	internal xbc9dfa2bfc69713d x5eff1f3a09faac7e()
	{
		xbc9dfa2bfc69713d xbc9dfa2bfc69713d = new xbc9dfa2bfc69713d();
		xbc9dfa2bfc69713d.x953b08b2c4ae3d24 = base.PrettyFormat;
		xbc9dfa2bfc69713d.x016e5a0032b3cd7b = x7915ced651964d5a;
		xbc9dfa2bfc69713d.xf7575b7b1ee35d49 = x5334cbf633e0b0a1;
		xbc9dfa2bfc69713d.xc2e1b0b1bf7219c5 = xe0300c6a6fcde986;
		xbc9dfa2bfc69713d.xafc42de38a25321a = MetafileRenderingOptions.x5eff1f3a09faac7e();
		xbc9dfa2bfc69713d.xda77249ca2dc4984 = x6d013c1e0924eebe;
		xbc9dfa2bfc69713d.x95e7cce59d14bdff = xa2fff74252bae51d;
		xbc9dfa2bfc69713d.xe1be84fa0dab2c38(new x7c8328a75e9baa2d(base.WarningCallback));
		xbc9dfa2bfc69713d.xd6830e3399cd5355 = x87e77d25a6acdcb6(x1d3ab847536f56e2);
		return xbc9dfa2bfc69713d;
	}

	private static xa1f9fc75a377297a x87e77d25a6acdcb6(SvgTextOutputMode xa4aa8b4150b11435)
	{
		return xa4aa8b4150b11435 switch
		{
			SvgTextOutputMode.UsePlacedGlyphs => xa1f9fc75a377297a.x516adb49f27e286e, 
			SvgTextOutputMode.UseSvgFonts => xa1f9fc75a377297a.xdbd20e87a6636992, 
			SvgTextOutputMode.UseTargetMachineFonts => xa1f9fc75a377297a.x40590fcd18085b57, 
			_ => xa1f9fc75a377297a.x40590fcd18085b57, 
		};
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

	private NumeralFormat x1c4fae32ddb5d010()
	{
		return x1f7ceef97f47be57;
	}

	NumeralFormat x99fd4075192789b2.xce9c42bd4e3f2c89()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x1c4fae32ddb5d010
		return this.x1c4fae32ddb5d010();
	}
}
