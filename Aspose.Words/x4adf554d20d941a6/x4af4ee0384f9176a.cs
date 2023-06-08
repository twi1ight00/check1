using System;
using Aspose;

namespace x4adf554d20d941a6;

internal abstract class x4af4ee0384f9176a : xac6c82c74ce247fb
{
	private x398b3bd0acd94b61 x6d394320b25a5754;

	private x398b3bd0acd94b61 x7947a6fc7cce3424;

	internal override x398b3bd0acd94b61 x8b8a0a04b3aeaf3a
	{
		get
		{
			return x6d394320b25a5754;
		}
		set
		{
			x6d394320b25a5754 = value;
		}
	}

	internal override x398b3bd0acd94b61 x7e2e5dd40daabc3b
	{
		get
		{
			return x7947a6fc7cce3424;
		}
		set
		{
			x7947a6fc7cce3424 = value;
		}
	}

	internal x4af4ee0384f9176a(x4e2f8bff72d83f71 documentLayout)
		: base(documentLayout)
	{
	}

	internal override x8d9303345f12a846 x4b2e8e22f36c8990(x41ac54db4e627dea x5906905c888d3d98)
	{
		return x42c697007cbd48df(x5906905c888d3d98);
	}

	internal override x1073233de8252b3e x8db1e90bce56e416(x398b3bd0acd94b61 xd7e5673853e47af4)
	{
		throw new InvalidOperationException();
	}

	[JavaThrows(true)]
	internal abstract x78752dd11b777af5 x6160b752f2880dec(x852fe8bb5ac31098 xe3e287548b3d01f5, bool x502d59bacbd3e16e);

	internal abstract void x2eb651a26ca80730(x852fe8bb5ac31098 xe3e287548b3d01f5, x78752dd11b777af5 xd7e5673853e47af4);

	internal x78752dd11b777af5[] x3411594c37cd9251(x852fe8bb5ac31098 xebab5ee98475329d, bool xfb73ba58c683a607)
	{
		x78752dd11b777af5[] array = new x78752dd11b777af5[2]
		{
			x5227b6539e814029(xebab5ee98475329d),
			null
		};
		if (array[0] == null || xfb73ba58c683a607)
		{
			array[1] = x97907443d5da6292(xebab5ee98475329d);
		}
		return array;
	}

	private x78752dd11b777af5 x5227b6539e814029(x852fe8bb5ac31098 xebab5ee98475329d)
	{
		x78752dd11b777af5 x78752dd11b777af6 = null;
		xebab5ee98475329d = xebab5ee98475329d.xf26f3fd618be2d13();
		while (x78752dd11b777af6 == null && xebab5ee98475329d != null)
		{
			x78752dd11b777af6 = x6160b752f2880dec(xebab5ee98475329d, x502d59bacbd3e16e: false);
			xebab5ee98475329d = xebab5ee98475329d.xf26f3fd618be2d13();
		}
		return x78752dd11b777af6;
	}

	private x78752dd11b777af5 x97907443d5da6292(x852fe8bb5ac31098 xebab5ee98475329d)
	{
		x78752dd11b777af5 x78752dd11b777af6 = null;
		xebab5ee98475329d = xebab5ee98475329d.x4eca8015611fb7a9();
		while (x78752dd11b777af6 == null && xebab5ee98475329d != null)
		{
			x78752dd11b777af6 = x6160b752f2880dec(xebab5ee98475329d, x502d59bacbd3e16e: false);
			xebab5ee98475329d = xebab5ee98475329d.x4eca8015611fb7a9();
		}
		return x78752dd11b777af6;
	}
}
