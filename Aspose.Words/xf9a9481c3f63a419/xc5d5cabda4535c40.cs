using System.Collections;
using System.IO;
using Aspose;
using xe8730a664ff488a4;

namespace xf9a9481c3f63a419;

[JavaManual("Manual porting by design.")]
internal class xc5d5cabda4535c40
{
	private readonly xef4b7685c2495ff2 x381358988cf0d26e;

	private readonly IEnumerator x7d37b73b5e686011;

	public string x2b9ddc3bb222d878 => x0daee7c95d8427c1.xa39af5a82860a9a3;

	private x990d54f34b2b5118 x0daee7c95d8427c1 => (x990d54f34b2b5118)x7d37b73b5e686011.Current;

	public xc5d5cabda4535c40(Stream stream)
	{
		x381358988cf0d26e = xef4b7685c2495ff2.x06b0e25aa6ad68a9(stream);
		x7d37b73b5e686011 = ((IEnumerable)x381358988cf0d26e).GetEnumerator();
	}

	public bool xa10f9c7d6062e4a9()
	{
		return x7d37b73b5e686011.MoveNext();
	}

	public MemoryStream x2b03692de8748ac6()
	{
		MemoryStream memoryStream = new MemoryStream();
		x5b90d11fb5da5910(memoryStream);
		memoryStream.Position = 0L;
		return memoryStream;
	}

	public void x5b90d11fb5da5910(Stream xcf18e5243f8d5fd3)
	{
		x0daee7c95d8427c1.xf098323036d9ec26(xcf18e5243f8d5fd3);
	}
}
