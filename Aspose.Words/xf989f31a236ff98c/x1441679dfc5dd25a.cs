using System.IO;
using System.Text;

namespace xf989f31a236ff98c;

internal class x1441679dfc5dd25a : xd59a0d3f8248c4e8
{
	private readonly string xed4a7b1500064e12;

	internal x1441679dfc5dd25a(Encoding textEncoding, string contentType, string uri, string text)
		: base(textEncoding, contentType, uri)
	{
		xed4a7b1500064e12 = text;
	}

	internal override MemoryStream x878afbafb98bf640()
	{
		MemoryStream memoryStream = new MemoryStream();
		StreamWriter streamWriter = new StreamWriter(memoryStream, base.xb5305bb23e4178cb);
		streamWriter.Write(xed4a7b1500064e12);
		streamWriter.Flush();
		memoryStream.Position = 0L;
		return memoryStream;
	}
}
