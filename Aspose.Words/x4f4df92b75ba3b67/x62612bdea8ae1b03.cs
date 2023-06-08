using System.IO;
using x38a89dee67fc7a16;

namespace x4f4df92b75ba3b67;

internal class x62612bdea8ae1b03 : x8fbf0a5e230a8cae
{
	private readonly x302a61bb21175bd5 x4a66f2abeb17a818;

	private readonly float xc01fd179bbea222c;

	private readonly int xc46f3d1a3128ad99;

	internal x62612bdea8ae1b03(Stream outputStream, x302a61bb21175bd5 compression, float vRes, int widthPixels)
		: base(outputStream)
	{
		x4a66f2abeb17a818 = compression;
		xc01fd179bbea222c = vRes;
		xc46f3d1a3128ad99 = widthPixels;
	}

	public override void Write(byte[] srcBuffer, int srcOffset, int srcCount)
	{
		x142ca5546cdedfa6 x142ca5546cdedfa = new x142ca5546cdedfa6();
		x142ca5546cdedfa.x9ba359ff37a3a63b = x79a2a2b1912e76bf.xc0f9b651d77da240;
		x142ca5546cdedfa.x4d18d829509725c2 = false;
		x142ca5546cdedfa.x9d4ba7c4540816af = false;
		x142ca5546cdedfa.x8291881ef07bb5c7(srcBuffer, x4a66f2abeb17a818, xc01fd179bbea222c, xc46f3d1a3128ad99, x6169576fb3c218d3);
	}
}
