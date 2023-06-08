namespace x4f4df92b75ba3b67;

internal class x469ef7a51cfbda24 : x4d8917c8186e8cb2
{
	private readonly byte[] x771782ffbd372410;

	private readonly int xd74c65b8d28b1740;

	private readonly int x8918dc7c534575e5;

	internal x469ef7a51cfbda24(x4882ae789be6e2ef context, byte[] alphaValues, int width, int height)
		: base(context)
	{
		x771782ffbd372410 = alphaValues;
		xd74c65b8d28b1740 = width;
		x8918dc7c534575e5 = height;
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		x6210059f049f0d48(x771782ffbd372410, 0, x771782ffbd372410.Length);
		base.WriteToPdf(writer);
	}

	internal override void x0a2e1f2c2da67e52(x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Type", "/XObject");
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Subtype", "/Image");
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Width", xd74c65b8d28b1740);
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Height", x8918dc7c534575e5);
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/ColorSpace", "/DeviceGray");
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/BitsPerComponent", 8);
	}

	internal override x4c746eafc29e5079 xf57599e513eb82be()
	{
		xa73d31814e085e6d xa73d31814e085e6d2 = new xa73d31814e085e6d();
		xa73d31814e085e6d2.x1fda32d41ebcf020 = 8;
		xa73d31814e085e6d2.xbd7bb54d8760ed0a = xd74c65b8d28b1740;
		xa73d31814e085e6d2.x2c0320b7c80c1e61 = 1;
		xa73d31814e085e6d2.x988e9397bc83aaf3 = true;
		return xa73d31814e085e6d2;
	}
}
