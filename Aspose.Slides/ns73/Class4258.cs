using System.Text;

namespace ns73;

internal class Class4258
{
	private byte[] byte_0;

	private Encoding encoding_0;

	public byte[] Data => byte_0;

	public Encoding Encoding => encoding_0;

	public Class4258(byte[] data)
		: this(data, Encoding.Default)
	{
		byte_0 = data;
	}

	public Class4258(byte[] data, Encoding encoding)
	{
		byte_0 = data;
		encoding_0 = encoding;
	}
}
