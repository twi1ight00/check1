using System.IO;
using Aspose;
using x6c95d9cf46ff5f25;

namespace x66dd9eaee57cfba4;

internal abstract class x6c5a92230c2f59e2
{
	private readonly int xa6343dc875c3a0d0;

	private readonly int xa7966b77592d0cda;

	private readonly x09ce2c02826e31a6 xfb2cb2f4d3a5b43b;

	public int xb120d6e4572c845b => xa7966b77592d0cda;

	public int xa6fc5ae695dd3435 => xa6343dc875c3a0d0;

	public x09ce2c02826e31a6 xe6414aff183c47a1 => xfb2cb2f4d3a5b43b;

	protected x6c5a92230c2f59e2(int platformId, int encodingId, x09ce2c02826e31a6 charMap)
	{
		xa6343dc875c3a0d0 = platformId;
		xa7966b77592d0cda = encodingId;
		xfb2cb2f4d3a5b43b = charMap;
	}

	[JavaThrows(true)]
	public abstract void Write(x73087173962e3778 writer);

	public byte[] xbdc1ba5a08db0865()
	{
		using MemoryStream memoryStream = new MemoryStream();
		x73087173962e3778 writer = new x73087173962e3778(memoryStream);
		Write(writer);
		return memoryStream.ToArray();
	}
}
