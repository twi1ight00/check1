using System;

namespace x5794c252ba25e723;

internal class xc020fa2f5133cba8 : x845d6a068e0b03c5
{
	private x26d9ecb4bdf0456d x78e4acec873c7675;

	public x26d9ecb4bdf0456d x9b41425268471380
	{
		get
		{
			return x78e4acec873c7675;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			x78e4acec873c7675 = value;
		}
	}

	public override bool IsEmpty => x78e4acec873c7675.x7149c962c02931b3;

	public xc020fa2f5133cba8(x26d9ecb4bdf0456d color)
		: base(x0b257a9fb413b6c3.xb8751dec55f64252)
	{
		x9b41425268471380 = color;
	}
}
