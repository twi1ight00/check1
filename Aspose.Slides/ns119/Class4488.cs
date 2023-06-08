using System.IO;

namespace ns119;

internal class Class4488 : Class4487
{
	private byte[] byte_0;

	private Class4488()
	{
	}

	public Class4488(byte[] fileContent)
	{
		byte_0 = fileContent;
	}

	public override Stream vmethod_0()
	{
		return new MemoryStream(byte_0);
	}

	public override object Clone()
	{
		return new Class4488(byte_0);
	}
}
