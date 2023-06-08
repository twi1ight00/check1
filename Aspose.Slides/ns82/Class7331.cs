using System.IO;
using System.Text;

namespace ns82;

internal class Class7331 : Class7330
{
	protected Class7331()
	{
	}

	public Class7331(Stream istream)
		: this(istream, null)
	{
	}

	public Class7331(Stream istream, Encoding encoding)
		: this(istream, Class7330.int_7, encoding)
	{
	}

	public Class7331(Stream istream, int size)
		: this(istream, size, null)
	{
	}

	public Class7331(Stream istream, int size, Encoding encoding)
		: this(istream, size, Class7330.int_6, encoding)
	{
	}

	public Class7331(Stream istream, int size, int readBufferSize, Encoding encoding)
	{
		vmethod_0((encoding == null) ? new StreamReader(istream) : new StreamReader(istream, encoding), size, readBufferSize);
	}
}
