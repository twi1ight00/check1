using System;
using System.Reflection;
using Aspose.Words;

namespace x4adf554d20d941a6;

[DefaultMember("Item")]
internal class xd410c9b07f3bc70b
{
	private readonly x928803c35fad8dec[] x3d26df6f8b783006 = new x928803c35fad8dec[6];

	internal x928803c35fad8dec xe6d4b1b411ed94b5
	{
		get
		{
			int num = xdd17d7cb3cbfb097(xdbbf47b5e620c262);
			return x3d26df6f8b783006[num];
		}
	}

	internal void x51b3590e861af38f(x4e2f8bff72d83f71 x25c880b62d33ccbc, StoryType xdbbf47b5e620c262)
	{
		if (x25c880b62d33ccbc != null)
		{
			int num = xdd17d7cb3cbfb097(xdbbf47b5e620c262);
			if (x3d26df6f8b783006[num] == null)
			{
				x3d26df6f8b783006[num] = new x928803c35fad8dec(x25c880b62d33ccbc, xdbbf47b5e620c262);
			}
		}
	}

	internal x928803c35fad8dec xa2711a6fcb6054d5(StoryType xdbbf47b5e620c262)
	{
		x928803c35fad8dec x928803c35fad8dec2 = this.get_xe6d4b1b411ed94b5(xdbbf47b5e620c262);
		if (x928803c35fad8dec2 == null)
		{
			return null;
		}
		x928803c35fad8dec x928803c35fad8dec3 = new x928803c35fad8dec(x928803c35fad8dec2.x2c8c6741422a1298, xdbbf47b5e620c262);
		xc99ce4f545e9c120.xc1d98b06788daae1(x928803c35fad8dec2, x928803c35fad8dec3);
		return x928803c35fad8dec3;
	}

	private int xdd17d7cb3cbfb097(StoryType xdbbf47b5e620c262)
	{
		int num = (int)(xdbbf47b5e620c262 - 12);
		if (0 > num || num > x3d26df6f8b783006.Length)
		{
			throw new ArgumentOutOfRangeException("storyType");
		}
		return num;
	}
}
