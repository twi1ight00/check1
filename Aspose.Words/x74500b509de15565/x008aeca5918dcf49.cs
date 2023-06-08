using System;
using System.Drawing;
using x13f1efc79617a47b;

namespace x74500b509de15565;

internal class x008aeca5918dcf49
{
	private int x8c12e899802729de;

	private int xb36382c363017f63;

	private int x5964b81df3a779c8;

	private int xd9498f662416465e;

	public int x76ed43b7f1d4f9c5 => x8c12e899802729de;

	public int xb96d365eed99e7aa => xb36382c363017f63;

	public int x167dd7ed2479f910 => x5964b81df3a779c8;

	public int x3856eff83c7532fc => xd9498f662416465e;

	public x008aeca5918dcf49(int yDenom, int yNum, int xDenom, int xNum)
	{
		x8c12e899802729de = yDenom;
		xb36382c363017f63 = yNum;
		x5964b81df3a779c8 = xDenom;
		xd9498f662416465e = xNum;
	}

	public SizeF x858aeb69ed4ea256(SizeF x695cbd2e3eef64df)
	{
		if (x76ed43b7f1d4f9c5 == 0 || x167dd7ed2479f910 == 0)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mfiaohpadigblgnbdhecnglcfgcdobjdogaelfhegfoeofffefmfmadgpfkghebhpeihffphceginenifaej", 357632019)));
		}
		return new SizeF(x695cbd2e3eef64df.Width * (float)x3856eff83c7532fc / (float)x167dd7ed2479f910, x695cbd2e3eef64df.Height * (float)xb96d365eed99e7aa / (float)x76ed43b7f1d4f9c5);
	}
}
