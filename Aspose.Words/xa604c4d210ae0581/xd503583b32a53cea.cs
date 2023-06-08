using System;
using System.IO;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;

namespace xa604c4d210ae0581;

internal class xd503583b32a53cea
{
	private readonly BinaryReader x7450cc1e48712286;

	private readonly x456c8b07916a8790 xea288d4121bac055;

	private readonly BinaryReader xc1a4431284c0dbe1;

	private xd503583b32a53cea x23a5b19bb470e2f5;

	private static readonly byte[] x790d63655c741a77 = new byte[8] { 1, 1, 2, 4, 2, 2, 0, 3 };

	private bool xabe67db178d9744c = true;

	internal static bool x492f529cee830a40 = false;

	internal bool xd2f1f3523585ff1e
	{
		set
		{
			xabe67db178d9744c = value;
		}
	}

	internal xd503583b32a53cea(x456c8b07916a8790 sink, BinaryReader dataStreamReader)
	{
		Stream stream = new MemoryStream();
		stream.SetLength(1024L);
		x7450cc1e48712286 = new BinaryReader(stream);
		xea288d4121bac055 = sink;
		xc1a4431284c0dbe1 = dataStreamReader;
	}

	private bool x1f0eeeeea44439b6(x875aca5784596b73 x28180b3c3774af93, int xe4cc3b7a4bdc0d8f)
	{
		if (x28180b3c3774af93 != x875aca5784596b73.xa58379af07dd1eca || xe4cc3b7a4bdc0d8f != 0)
		{
			if (x28180b3c3774af93 == x875aca5784596b73.xe300e699444c1f39)
			{
				return xabe67db178d9744c;
			}
			return false;
		}
		return true;
	}

	internal void x06b0e25aa6ad68a9(byte[] x24c45257571ea504)
	{
		if (x24c45257571ea504 == null)
		{
			return;
		}
		Stream baseStream = x7450cc1e48712286.BaseStream;
		baseStream.Position = 0L;
		baseStream.Write(x24c45257571ea504, 0, x24c45257571ea504.Length);
		baseStream.Position = 0L;
		int num = 0;
		while (baseStream.Position < x24c45257571ea504.Length)
		{
			int num2 = (int)baseStream.Position;
			x875aca5784596b73 x875aca5784596b74 = (x875aca5784596b73)x7450cc1e48712286.ReadUInt16();
			int num3 = x52d4d5662a2d0400(x7450cc1e48712286, x875aca5784596b74);
			x8de82539c936c298 xe780cde24dcce6f = (x8de82539c936c298)((int)(x875aca5784596b74 & (x875aca5784596b73)7168) >> 10);
			if (x492f529cee830a40)
			{
				byte[] buffer = new byte[num3];
				long position = baseStream.Position;
				baseStream.Read(buffer, 0, num3);
				baseStream.Position = position;
			}
			if (x1f0eeeeea44439b6(x875aca5784596b74, num))
			{
				int xd59ec9a3f7a434cb = x7450cc1e48712286.ReadInt32();
				x32939c68497cb083 x32939c68497cb84 = x3ff949c473a702d2.x8300c23c6ee65fb7(xc1a4431284c0dbe1, xd59ec9a3f7a434cb);
				if (x23a5b19bb470e2f5 == null)
				{
					x23a5b19bb470e2f5 = new xd503583b32a53cea(xea288d4121bac055, xc1a4431284c0dbe1);
				}
				x23a5b19bb470e2f5.xd2f1f3523585ff1e = xabe67db178d9744c;
				x23a5b19bb470e2f5.x06b0e25aa6ad68a9(x32939c68497cb84.x6b73aa01aa019d3a);
				baseStream.Position = x24c45257571ea504.Length;
			}
			else
			{
				int num4 = (int)baseStream.Position;
				int num5 = num4 + num3;
				if (!xea288d4121bac055.x09a3d4a7eac8f520(x875aca5784596b74, xe780cde24dcce6f, num3, x7450cc1e48712286) && x492f529cee830a40)
				{
					int x10f4d88af727adbc = Math.Min(num5 - num2, x24c45257571ea504.Length - num2);
					string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hikmnkbnalingkpnjjgocfnoekepkjlpnicafjjagiabfjhbkiobphfcfimciiddghkdchbelcielfpeffgfefnfmeeggdlgehchgcjhncaiiehikgoikafjhfmjfedkdfkkpdblieilndpljegmhdnmbeenmoknfdcolcjobdaphchpbdopccfabplapcdbcojblcbchnhcimocibgdcbndbbeejalednbfglifoaagcmggkaogileh", 685820481)), (int)x875aca5784596b74, num3, xcd4bd3abd72ff2da.xd20e56ce95eb96ff(x24c45257571ea504, num2, x10f4d88af727adbc));
				}
				if (baseStream.Position != num5)
				{
					if (baseStream.Position == num4)
					{
						baseStream.Position = num5;
					}
					else if (x875aca5784596b74 != x875aca5784596b73.x55e4199f9d8c0034 && x875aca5784596b74 != x875aca5784596b73.x1834af1a4308ffef && x875aca5784596b74 != x875aca5784596b73.xb11f973f5b4b3b79 && x875aca5784596b74 != x875aca5784596b73.x8c63dce62e038bc8)
					{
						throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("faoehcffjbmfccdgcckgpbbhpaihkaphibginanihbejllkjkackkpikdppkdpglmknlmnemgnlmfncnnmjnhlaofphohkoookfpjmmplodajjkaiibbkkibknpbpmgcbmncmledkmldilceeljengaffmhfihofbmfgngmgofdhnjkhnkbijkiicfpibkgjbjnjkiekkilkdeclljjlpeamhjhmhdomghfnkimncidoahkolhbpddip", 338316732)), (int)x875aca5784596b74, num3, baseStream.Position - num4));
					}
				}
			}
			num++;
		}
	}

	internal static int x65f094754e99b28c(x875aca5784596b73 x28180b3c3774af93)
	{
		int num = (int)(x28180b3c3774af93 & (x875aca5784596b73)57344) >> 13;
		return x790d63655c741a77[num];
	}

	private static int x52d4d5662a2d0400(BinaryReader xe134235b3526fa75, x875aca5784596b73 x28180b3c3774af93)
	{
		int num = x65f094754e99b28c(x28180b3c3774af93);
		if (num == 0)
		{
			switch (x28180b3c3774af93)
			{
			case x875aca5784596b73.x14e44c90761a3cfd:
			case x875aca5784596b73.x79d0fad9e29c9f31:
				num = xe134235b3526fa75.ReadUInt16() - 1;
				break;
			case x875aca5784596b73.x0d02b68a5ba692ca:
			{
				int num2 = xe134235b3526fa75.ReadByte();
				if (num2 == 255)
				{
					throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hiijalpjlkgklknkekelkjllkkcmpejmpianojhnjjonhjfopimokidpkdkplibafhiadhpaocgbohnbmhecehlcchcdchjdmbaeahhepfoehgffifmfnadgofkggfbhafihgephafgimdnigeejidljhdckpoikbdalhdhljcolcdfmfdmmlcdnocknmbbogciogbpocbgpjnmp", 570857540)));
				}
				num = num2;
				break;
			}
			default:
				num = xe134235b3526fa75.ReadByte();
				break;
			}
		}
		return num;
	}
}
