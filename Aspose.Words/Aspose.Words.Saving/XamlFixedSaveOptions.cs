using System;
using xe9865c3fb834da49;

namespace Aspose.Words.Saving;

public class XamlFixedSaveOptions : SaveOptions, x1009bb9dacdb7e53, x99fd4075192789b2
{
	private int xe94c98f592fab2c8;

	private int x0c50d58c51fb0ad7 = int.MaxValue;

	private NumeralFormat x1f7ceef97f47be57;

	public override SaveFormat SaveFormat
	{
		get
		{
			return SaveFormat.XamlFixed;
		}
		set
		{
			if (value != SaveFormat.XamlFixed)
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
