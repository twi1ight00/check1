using System.IO;
using System.Text;

namespace ns82;

internal class Class4390 : Class4389
{
	protected Class4390()
	{
	}

	public Class4390(Stream istream)
		: this(istream, null)
	{
	}

	public Class4390(Stream istream, Encoding encoding)
		: this(istream, Class4389.int_7, encoding)
	{
	}

	public Class4390(Stream istream, int size)
		: this(istream, size, null)
	{
	}

	public Class4390(Stream istream, int size, Encoding encoding)
		: this(istream, size, Class4389.int_6, encoding)
	{
	}

	public Class4390(Stream istream, int size, int readBufferSize, Encoding encoding)
	{
		vmethod_0((encoding == null) ? new StreamReader(istream) : new StreamReader(istream, encoding), size, readBufferSize);
	}
}
