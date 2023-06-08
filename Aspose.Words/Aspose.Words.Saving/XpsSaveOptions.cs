using System;
using x28925c9b27b37a46;
using xaf73fad8cede26de;
using xe9865c3fb834da49;

namespace Aspose.Words.Saving;

public class XpsSaveOptions : SaveOptions, x1009bb9dacdb7e53, x99fd4075192789b2
{
	private int x0c50d58c51fb0ad7 = int.MaxValue;

	private int xe94c98f592fab2c8;

	private int xa3f14f56617da4ce;

	private int xdb7f6aff14a27e60;

	private NumeralFormat x1f7ceef97f47be57;

	private readonly MetafileRenderingOptions xedeee4e28b7ff47f = new MetafileRenderingOptions();

	public override SaveFormat SaveFormat
	{
		get
		{
			return SaveFormat.Xps;
		}
		set
		{
			if (value != SaveFormat.Xps)
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

	[JavaInternal]
	[Obsolete("Use MetafileRenderingOptions.RenderingMode property.")]
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

	internal override bool xda76bf558c43e688 => false;

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

	internal x26efbcdc713eaa49 x5eff1f3a09faac7e()
	{
		x26efbcdc713eaa49 x26efbcdc713eaa = new x26efbcdc713eaa49();
		x26efbcdc713eaa.xcaedf7c40a4ec358 = xa3f14f56617da4ce;
		x26efbcdc713eaa.x9b6007a17b33a42b = xdb7f6aff14a27e60;
		x26efbcdc713eaa.xafc42de38a25321a = xedeee4e28b7ff47f.x5eff1f3a09faac7e();
		x26efbcdc713eaa.xe1be84fa0dab2c38(new x7c8328a75e9baa2d(base.WarningCallback));
		return x26efbcdc713eaa;
	}
}
