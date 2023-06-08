using System.IO;
using System.Text;

namespace xf989f31a236ff98c;

internal class x32626c54bb4e8c9e : xd59a0d3f8248c4e8
{
	private readonly byte[] x73f065a6b420cfe1;

	internal x32626c54bb4e8c9e(string contentType, string uri, byte[] data)
		: base(null, contentType, uri)
	{
		x73f065a6b420cfe1 = data;
	}

	internal x32626c54bb4e8c9e(Encoding textEncoding, string contentType, string uri, byte[] data)
		: base(textEncoding, contentType, uri)
	{
		x73f065a6b420cfe1 = data;
	}

	internal override MemoryStream x878afbafb98bf640()
	{
		return new MemoryStream(x73f065a6b420cfe1);
	}
}
