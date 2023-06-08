using x66dd9eaee57cfba4;

namespace x4f4df92b75ba3b67;

internal class xaed01f450602b405 : xb5ab0d03444f8c24
{
	private xf22a449df9af52b7 x016010e4e2992762;

	internal override string x612c0155ea8cfdfa => "/FontFile2";

	internal xaed01f450602b405(x4882ae789be6e2ef context, xcd986872cf3bcf68 subset)
		: base(context, subset)
	{
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		base.x968fd3630f239305.WriteToStream(base.x9e418ad9a56d1cf5);
		x016010e4e2992762 = new xf22a449df9af52b7(base.x28fcdc775a1d069c);
		x016010e4e2992762.x1be93eed8950d961 = (int)base.x9e418ad9a56d1cf5.Length;
		base.WriteToPdf(writer);
		x016010e4e2992762.WriteToPdf(writer);
	}

	internal override void x0a2e1f2c2da67e52(x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Length1", x016010e4e2992762.x899a2110a8a35fda);
	}
}
