using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x13f1efc79617a47b;
using x38a89dee67fc7a16;

namespace x1a62aaf14e3c5909;

internal class x681808f408a7efac : xd959c7c7ca733332
{
	private class x53fe63ef2efcef4f
	{
		private readonly BinaryReader x7450cc1e48712286;

		private readonly int x212ae880d15d2ed1;

		private readonly int x823c6b25cc2689d8;

		private readonly ImageType xedcf13d9a3fd42bd;

		internal x53fe63ef2efcef4f(BinaryReader reader, int start, int length, ImageType imageType)
		{
			x7450cc1e48712286 = reader;
			x212ae880d15d2ed1 = start;
			x823c6b25cc2689d8 = length;
			xedcf13d9a3fd42bd = imageType;
		}

		internal byte[] x06b0e25aa6ad68a9()
		{
			x7450cc1e48712286.BaseStream.Position = x212ae880d15d2ed1;
			if (xedcf13d9a3fd42bd == ImageType.Bmp)
			{
				return xdd1b8f14cc8ba86d.x10e7a0599aa303ae(x7450cc1e48712286, x823c6b25cc2689d8);
			}
			return x7450cc1e48712286.ReadBytes(x823c6b25cc2689d8);
		}
	}

	private x53fe63ef2efcef4f xf1e9e9fa3875615f;

	private byte[] xd08494dce3b2b550;

	private x10884bb8036bcee0 x89fbb53b2a997ef0;

	internal override byte[] xcc18177a965e0313
	{
		get
		{
			if (xd08494dce3b2b550 == null && xf1e9e9fa3875615f != null)
			{
				xd08494dce3b2b550 = xf1e9e9fa3875615f.x06b0e25aa6ad68a9();
			}
			return xd08494dce3b2b550;
		}
	}

	internal override x10884bb8036bcee0 x10884bb8036bcee0 => x89fbb53b2a997ef0;

	internal x681808f408a7efac()
	{
	}

	internal x681808f408a7efac(Guid guid, byte[] imageBytes, x10884bb8036bcee0 presetTexture)
		: base(guid)
	{
		x89fbb53b2a997ef0 = presetTexture;
		base.x688d6f6524ba3c8b = FileFormatUtil.xd93505cfb3e61804(xdd1b8f14cc8ba86d.x22bfb60fc9ca9282(imageBytes));
		switch (base.x688d6f6524ba3c8b)
		{
		case ImageType.Jpeg:
		case ImageType.Png:
		case ImageType.Bmp:
			xd08494dce3b2b550 = imageBytes;
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("gdceefjegfafppgfbeofbffggemgiddhddkhbebipciilcpieofjadnjcdekdclknbclhcjlcnplibhmjbomkafnnamniadoamjodabpjaipjappbagacpmacaebopkbikbcnoichopcbpgdbondhkee", 405815784)));
		}
	}

	protected override void DoRead(BinaryReader reader)
	{
		int num = (int)reader.BaseStream.Position;
		x46acc5353d0f1389(reader);
		x89fbb53b2a997ef0 = (x10884bb8036bcee0)reader.ReadByte();
		int num2 = (int)reader.BaseStream.Position - num;
		int length = base.x1ea60bde2b5d0d28.x1be93eed8950d961 - num2;
		xf1e9e9fa3875615f = new x53fe63ef2efcef4f(reader, (int)reader.BaseStream.Position, length, base.x688d6f6524ba3c8b);
		reader.BaseStream.Position = num + base.x1ea60bde2b5d0d28.x1be93eed8950d961;
	}

	protected override void DoWrite(BinaryWriter writer)
	{
		x356b036984855690(writer);
		writer.Write((byte)x89fbb53b2a997ef0);
		if (base.x688d6f6524ba3c8b == ImageType.Bmp)
		{
			writer.Write(xd08494dce3b2b550, 14, xd08494dce3b2b550.Length - 14);
		}
		else
		{
			writer.Write(xd08494dce3b2b550);
		}
	}
}
