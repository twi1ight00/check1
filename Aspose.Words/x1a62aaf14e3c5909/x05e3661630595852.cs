using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x13f1efc79617a47b;
using x38a89dee67fc7a16;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x1a62aaf14e3c5909;

internal class x05e3661630595852 : xd959c7c7ca733332
{
	private class x3fdd94ad1098db2f
	{
		private readonly BinaryReader x7450cc1e48712286;

		private readonly int x212ae880d15d2ed1;

		internal x3fdd94ad1098db2f(BinaryReader reader, int start)
		{
			x7450cc1e48712286 = reader;
			x212ae880d15d2ed1 = start;
		}

		internal byte[] x06b0e25aa6ad68a9()
		{
			x7450cc1e48712286.BaseStream.Position = x212ae880d15d2ed1;
			int x584b67d526f6b9d = x7450cc1e48712286.ReadInt32();
			int xa447fc54e41dfe = x7450cc1e48712286.ReadInt32();
			int xc941868c59399d3e = x7450cc1e48712286.ReadInt32();
			int xfc2074a859a5db8c = x7450cc1e48712286.ReadInt32();
			int xaf9a0436a70689de = x7450cc1e48712286.ReadInt32();
			int x1c991b839ad1125f = x7450cc1e48712286.ReadInt32();
			int xf578678e53bd422f = x7450cc1e48712286.ReadInt32();
			xa2745adfabe0c674 x95dac044246123ac = xa2745adfabe0c674.xa0a47601432e91a8(xa447fc54e41dfe, xc941868c59399d3e, xfc2074a859a5db8c, xaf9a0436a70689de, x1c991b839ad1125f, xf578678e53bd422f);
			int num = x7450cc1e48712286.ReadInt32();
			if (num <= 0)
			{
				return null;
			}
			xe646452fa22908cf xe646452fa22908cf2 = (xe646452fa22908cf)x7450cc1e48712286.ReadByte();
			x7450cc1e48712286.ReadByte();
			byte[] array = x7450cc1e48712286.ReadBytes(num);
			switch (xe646452fa22908cf2)
			{
			case xe646452fa22908cf.x575db3fedeadea6b:
				try
				{
					array = xf1da3993f05a75b7.x4671919d08389f8e(array, x584b67d526f6b9d, x2e6ebe7013ab34b9.x1455a9a8b1cd9f39);
				}
				catch (Exception)
				{
					array = x0d299f323d241756.xcd6c2a9742c9220a();
				}
				break;
			default:
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("lihmnkomclfnkjmnckdomjkoejbpneiphjppmigaijnaciebeilbeicceijckhadcdhdchodlhfeghmeghdffhkffgbgahigngpgagghdgnhpfeioaliifcjnejjjfakkehkoeokaeflhaml", 1290323778)));
			case xe646452fa22908cf.x4d0b9d4447ba7566:
				break;
			}
			if (xdd1b8f14cc8ba86d.xa112135733098ff7(array))
			{
				array = xdd1b8f14cc8ba86d.x300bc69d382eb52c(array, x95dac044246123ac);
			}
			return array;
		}
	}

	private const int x4366728c93a75264 = 16384;

	private x3fdd94ad1098db2f xeb9c755c47f4cc4b;

	private byte[] xd08494dce3b2b550;

	internal override byte[] xcc18177a965e0313
	{
		get
		{
			if (xd08494dce3b2b550 == null && xeb9c755c47f4cc4b != null)
			{
				xd08494dce3b2b550 = xeb9c755c47f4cc4b.x06b0e25aa6ad68a9();
			}
			return xd08494dce3b2b550;
		}
	}

	internal override x10884bb8036bcee0 x10884bb8036bcee0 => x10884bb8036bcee0.x1a23317d325de634;

	internal x05e3661630595852()
	{
	}

	internal x05e3661630595852(Guid guid, byte[] imageBytes)
		: base(guid)
	{
		base.x688d6f6524ba3c8b = FileFormatUtil.xd93505cfb3e61804(xdd1b8f14cc8ba86d.x22bfb60fc9ca9282(imageBytes));
		switch (base.x688d6f6524ba3c8b)
		{
		case ImageType.Emf:
		case ImageType.Wmf:
		case ImageType.Pict:
			xd08494dce3b2b550 = imageBytes;
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ihmigjdjijkjbebkdiikdjpkiiglkhnlfhemdilmfhcnhhjnngaodchoehoofgfpdgmpkgdaebkakfbblfibmepbpegckenccaedfeldlecelejedeafedhfeeofnoegcdmgmcdhgdkhgcbimohi", 2076871722)));
		}
	}

	protected override void DoRead(BinaryReader reader)
	{
		int num = (int)reader.BaseStream.Position;
		x46acc5353d0f1389(reader);
		xeb9c755c47f4cc4b = new x3fdd94ad1098db2f(reader, (int)reader.BaseStream.Position);
		reader.BaseStream.Position = num + base.x1ea60bde2b5d0d28.x1be93eed8950d961;
	}

	protected override void DoWrite(BinaryWriter writer)
	{
		byte[] array = xdd1b8f14cc8ba86d.x36948be2ab2261b1(xd08494dce3b2b550);
		x356b036984855690(writer);
		writer.Write(array.Length);
		xa2745adfabe0c674 xa2745adfabe0c = xdd1b8f14cc8ba86d.x16a7fb03c627ebfb(xd08494dce3b2b550);
		writer.Write(xa2745adfabe0c.x72d92bd1aff02e37);
		writer.Write(xa2745adfabe0c.xe360b1885d8d4a41);
		writer.Write(xa2745adfabe0c.x419ba17a5322627b);
		writer.Write(xa2745adfabe0c.x9bcb07e204e30218);
		writer.Write(xa2745adfabe0c.xf0dac309e0310811);
		writer.Write(xa2745adfabe0c.x46df0eb1a743eced);
		if (array.Length > 16384)
		{
			MemoryStream memoryStream = new MemoryStream(array);
			MemoryStream memoryStream2 = new MemoryStream();
			xf1da3993f05a75b7.x575db3fedeadea6b(memoryStream, memoryStream2, x2e6ebe7013ab34b9.x1455a9a8b1cd9f39);
			writer.Write((int)memoryStream2.Length);
			writer.Write((byte)0);
			writer.Write((byte)254);
			writer.Write(memoryStream2.GetBuffer(), 0, (int)memoryStream2.Length);
			memoryStream2.Close();
			memoryStream.Close();
		}
		else
		{
			writer.Write(array.Length);
			writer.Write((byte)254);
			writer.Write((byte)254);
			writer.Write(array);
		}
	}
}
