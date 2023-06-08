using Aspose;
using x66dd9eaee57cfba4;

namespace x4f4df92b75ba3b67;

internal class x36f3cc9da1a9048d : xb5ab0d03444f8c24
{
	private readonly string x72428685b8a2c33f;

	internal override string x612c0155ea8cfdfa => "/FontFile3";

	internal x36f3cc9da1a9048d(x4882ae789be6e2ef context, string subtype, xcd986872cf3bcf68 subset)
		: base(context, subset)
	{
		x72428685b8a2c33f = subtype;
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		base.x968fd3630f239305.WriteToStream(base.x9e418ad9a56d1cf5);
		base.WriteToPdf(writer);
	}

	[JavaThrows(true)]
	internal override void x0a2e1f2c2da67e52(x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Subtype", x72428685b8a2c33f);
	}
}
