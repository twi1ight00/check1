using System;

namespace x4f4df92b75ba3b67;

internal abstract class xbbf64dacc941f5e3 : x4d8917c8186e8cb2
{
	private readonly int xaf3d8df36c20b06a;

	private readonly int xcce880390b0498cb;

	private readonly float[] xae5c7c71d312494a;

	private readonly float[] x4517c2b411ea1d52;

	internal float[] x9fba715a9f95491c => xae5c7c71d312494a;

	internal float[] x7d2e50686d249839 => x4517c2b411ea1d52;

	internal int xab413bee118de3cd => xaf3d8df36c20b06a;

	internal int x3f8e7a57d68071e3 => xcce880390b0498cb;

	protected abstract int FunctionType { get; }

	internal xbbf64dacc941f5e3(x4882ae789be6e2ef context, int nInputs, int nOutputs, float[] domain, float[] range)
		: base(context)
	{
		xaf3d8df36c20b06a = nInputs;
		xcce880390b0498cb = nOutputs;
		x3ecf89383eedd106(domain, xab413bee118de3cd);
		xae5c7c71d312494a = domain;
		x3ecf89383eedd106(range, x3f8e7a57d68071e3);
		x4517c2b411ea1d52 = range;
	}

	private static void x3ecf89383eedd106(float[] xe462df746fe80ea1, int x83f327c81b68aac0)
	{
		if (xe462df746fe80ea1.Length % x83f327c81b68aac0 != 0)
		{
			throw new ArgumentException("Incorrect array dimension.");
		}
		for (int i = 0; i < x83f327c81b68aac0; i++)
		{
			if (xe462df746fe80ea1[i * 2] > xe462df746fe80ea1[i * 2 + 1])
			{
				throw new ArgumentException("Min is greater than Max.");
			}
		}
	}

	internal override void x0a2e1f2c2da67e52(x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/FunctionType", FunctionType);
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Domain", xae5c7c71d312494a);
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Range", x4517c2b411ea1d52);
		base.x0a2e1f2c2da67e52(xbdfb620b7167944b);
	}
}
