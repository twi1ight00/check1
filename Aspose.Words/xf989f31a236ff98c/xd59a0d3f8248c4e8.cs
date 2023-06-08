using System.IO;
using System.Text;
using Aspose;

namespace xf989f31a236ff98c;

internal abstract class xd59a0d3f8248c4e8
{
	private readonly Encoding xfbe3d4b3365de1d2;

	private readonly string x98e285df741c9d32;

	private readonly string x85672ef2a158d360;

	internal bool x1ede37fe2e573750 => xfbe3d4b3365de1d2 != null;

	internal Encoding xb5305bb23e4178cb => xfbe3d4b3365de1d2;

	internal string x0b93856f95be30d0 => x98e285df741c9d32;

	internal string xb405a444ca77e2d4 => x85672ef2a158d360;

	protected xd59a0d3f8248c4e8(Encoding textEncoding, string contentType, string uri)
	{
		xfbe3d4b3365de1d2 = textEncoding;
		x98e285df741c9d32 = contentType;
		x85672ef2a158d360 = uri;
	}

	[JavaThrows(true)]
	internal abstract MemoryStream x878afbafb98bf640();
}
