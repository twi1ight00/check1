using System.IO;
using x66dd9eaee57cfba4;

namespace xc7ce8a6a920f8012;

internal class x5d2a005e0aeac7cc : x0096796e2eb81db6
{
	public x5d2a005e0aeac7cc(x34b34bf589d8ec1e context)
		: base(context)
	{
	}

	public void x31eb6524f38f9495(x6b1a899052c71a60 x26094932cf7a9139)
	{
		xb4e6bcae51300e9c xb4e6bcae51300e9c2 = new xb4e6bcae51300e9c(base.x28fcdc775a1d069c);
		xb4e6bcae51300e9c2.xacf4b9ddf32bef06();
		base.x5aa326f374b3d0ef.xab5f6b7526efa5be(base.x28fcdc775a1d069c.x4a59854a1bae262a(x26094932cf7a9139));
		base.x5aa326f374b3d0ef.x1485d1261faf8961(x2dd7de7c7b0ddad5: true, xde809bbd71bb692c: false);
		base.x5aa326f374b3d0ef.x1485d1261faf8961(x2dd7de7c7b0ddad5: false, xde809bbd71bb692c: false);
		base.x5aa326f374b3d0ef.x1485d1261faf8961(x2dd7de7c7b0ddad5: true, xde809bbd71bb692c: false);
		base.x5aa326f374b3d0ef.x1485d1261faf8961(x2dd7de7c7b0ddad5: false, xde809bbd71bb692c: false);
		base.x5aa326f374b3d0ef.x1485d1261faf8961(x2dd7de7c7b0ddad5: true, xde809bbd71bb692c: false);
		base.x5aa326f374b3d0ef.x1485d1261faf8961(x2dd7de7c7b0ddad5: true, xde809bbd71bb692c: false);
		base.x5aa326f374b3d0ef.x1485d1261faf8961(x2dd7de7c7b0ddad5: false, xde809bbd71bb692c: false);
		base.x5aa326f374b3d0ef.x1485d1261faf8961(x2dd7de7c7b0ddad5: false, xde809bbd71bb692c: true);
		base.x5aa326f374b3d0ef.xc351d479ff7ee789(0);
		string text = x26094932cf7a9139.x0a4b32fbe2e5933b + "_AW";
		base.x5aa326f374b3d0ef.xc351d479ff7ee789((byte)text.Length);
		for (int i = 0; i < text.Length; i++)
		{
			base.x5aa326f374b3d0ef.xc351d479ff7ee789((byte)text[i]);
		}
		xd6b2549ca8b77560(x26094932cf7a9139);
		base.x5aa326f374b3d0ef.x7fdc1bfc45368624.BaseStream.Seek(0L, SeekOrigin.End);
		xb4e6bcae51300e9c2.xc463dec5a3ab6e2d(xf066f1f57515a14c.x4c3bc143745bec0e);
	}

	private void xd6b2549ca8b77560(x6b1a899052c71a60 x26094932cf7a9139)
	{
		x6ba9063ea0f44561 x6ba9063ea0f44562 = base.x28fcdc775a1d069c.x5fa376febd884803(x26094932cf7a9139);
		base.x5aa326f374b3d0ef.xab5f6b7526efa5be((short)x6ba9063ea0f44562.xf73ef160527516c8.Length);
		long position = base.x5aa326f374b3d0ef.x7fdc1bfc45368624.BaseStream.Position;
		int[] array = new int[x6ba9063ea0f44562.xf73ef160527516c8.Length];
		for (int i = 0; i < array.Length; i++)
		{
			base.x5aa326f374b3d0ef.x6ff7c65ed4805c27(0);
		}
		long position2 = base.x5aa326f374b3d0ef.x7fdc1bfc45368624.BaseStream.Position;
		base.x5aa326f374b3d0ef.x6ff7c65ed4805c27(0);
		x22edb047bb09319a x22edb047bb09319a2 = new x22edb047bb09319a(base.x28fcdc775a1d069c);
		for (int j = 0; j < x6ba9063ea0f44562.xf73ef160527516c8.Length; j++)
		{
			array[j] = (int)(base.x5aa326f374b3d0ef.x7fdc1bfc45368624.BaseStream.Position - position);
			int num = x6ba9063ea0f44562.xf73ef160527516c8[j];
			if (num != 32)
			{
				x5ddcd7f1136699aa x0ff2a0e3d912821b = x6ba9063ea0f44562.x10801e6f4a897d62(num);
				x22edb047bb09319a2.x7051c5b39bd84697(x0ff2a0e3d912821b);
			}
			else
			{
				x22edb047bb09319a2.x4b0404a34ccdfdf7();
			}
		}
		int xbcea506a33cf = (int)(base.x5aa326f374b3d0ef.x7fdc1bfc45368624.BaseStream.Position - position);
		base.x5aa326f374b3d0ef.x7fdc1bfc45368624.BaseStream.Position = position2;
		base.x5aa326f374b3d0ef.x6ff7c65ed4805c27(xbcea506a33cf);
		base.x5aa326f374b3d0ef.x7fdc1bfc45368624.BaseStream.Position = position;
		for (int k = 0; k < array.Length; k++)
		{
			base.x5aa326f374b3d0ef.x6ff7c65ed4805c27(array[k]);
		}
		base.x5aa326f374b3d0ef.x7fdc1bfc45368624.BaseStream.Seek(0L, SeekOrigin.End);
		for (int l = 0; l < x6ba9063ea0f44562.xf73ef160527516c8.Length; l++)
		{
			base.x5aa326f374b3d0ef.xab5f6b7526efa5be((short)x6ba9063ea0f44562.xf73ef160527516c8[l]);
		}
		base.x5aa326f374b3d0ef.xab5f6b7526efa5be(x6ba9063ea0f44562.x3f80ed349f729542);
		base.x5aa326f374b3d0ef.xab5f6b7526efa5be(x6ba9063ea0f44562.xc9f7bec53c29c691);
		base.x5aa326f374b3d0ef.xab5f6b7526efa5be(x6ba9063ea0f44562.x68260316ab6c4d5b);
		for (int m = 0; m < x6ba9063ea0f44562.xf73ef160527516c8.Length; m++)
		{
			short xbcea506a33cf2 = x6ba9063ea0f44562.xa56be56d48dd0980(x6ba9063ea0f44562.xf73ef160527516c8[m]);
			base.x5aa326f374b3d0ef.xab5f6b7526efa5be(xbcea506a33cf2);
		}
		for (int n = 0; n < x6ba9063ea0f44562.xf73ef160527516c8.Length; n++)
		{
			base.x5aa326f374b3d0ef.xe62552de84356436(0, 0, 0, 0);
		}
		base.x5aa326f374b3d0ef.xab5f6b7526efa5be(0);
	}
}
