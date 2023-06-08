using System;

namespace x16f9a31f749b8bb1;

internal class x98d75821045fe9bd
{
	private readonly char[] x82653fa7be4739f8;

	private readonly xa7539800dadf4e5b x96dcb40119072b51;

	private readonly int xcc92e4668e62eea8;

	internal char[] xf73ef160527516c8 => x82653fa7be4739f8;

	internal xa7539800dadf4e5b xa7539800dadf4e5b => x96dcb40119072b51;

	internal int x90e1673346897dcf => xcc92e4668e62eea8;

	internal int xdbc2d3b44916c4fc => x854ced39b93c1246(x82653fa7be4739f8.Length);

	internal int x99c79d880fd694d7 => xaa55b781867db091(0);

	internal bool x75b732ba9b2cd574 => x96dcb40119072b51.xc77edd00162b84f4.x75b732ba9b2cd574;

	internal char x0defee75348dbb6e => x82653fa7be4739f8[x82653fa7be4739f8.Length - 1];

	internal x98d75821045fe9bd(char[] chars, xa7539800dadf4e5b complexPosition, int startFC)
	{
		x82653fa7be4739f8 = chars;
		x96dcb40119072b51 = complexPosition;
		xcc92e4668e62eea8 = startFC;
	}

	internal x98d75821045fe9bd(x98d75821045fe9bd chunk, int startIdx, int endIdx)
	{
		int num = endIdx - startIdx;
		x82653fa7be4739f8 = new char[num];
		Array.Copy(chunk.x82653fa7be4739f8, startIdx, x82653fa7be4739f8, 0, num);
		x96dcb40119072b51 = new xa7539800dadf4e5b(chunk.xa7539800dadf4e5b.xc77edd00162b84f4, chunk.xa7539800dadf4e5b.xf1d9b91c9700c401 + startIdx);
		xcc92e4668e62eea8 = chunk.x90e1673346897dcf + startIdx * ((!chunk.xa7539800dadf4e5b.xc77edd00162b84f4.x75b732ba9b2cd574) ? 1 : 2);
	}

	internal int xaa55b781867db091(int xc0c4c459c6ccbd00)
	{
		return x96dcb40119072b51.xc77edd00162b84f4.x76bcde38a5a4c721.x12cb12b5d2cad53d + x96dcb40119072b51.xf1d9b91c9700c401 + xc0c4c459c6ccbd00;
	}

	internal int x854ced39b93c1246(int xc0c4c459c6ccbd00)
	{
		return xcc92e4668e62eea8 + xc0c4c459c6ccbd00 * ((!x96dcb40119072b51.xc77edd00162b84f4.x75b732ba9b2cd574) ? 1 : 2);
	}
}
