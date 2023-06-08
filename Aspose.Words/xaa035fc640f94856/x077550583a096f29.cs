using System.IO;

namespace xaa035fc640f94856;

internal class x077550583a096f29
{
	internal int xea1e81378298fa81;

	internal readonly int[] xf74d8efdcaef8ee6;

	internal readonly int[] xa32ede1025f7736e;

	internal x077550583a096f29(int id, int propertyCount)
	{
		xea1e81378298fa81 = id;
		xf74d8efdcaef8ee6 = new int[propertyCount];
		xa32ede1025f7736e = new int[propertyCount];
	}

	internal x077550583a096f29(BinaryReader reader)
	{
		xea1e81378298fa81 = reader.ReadUInt16();
		int num = reader.ReadUInt16();
		xf74d8efdcaef8ee6 = new int[num];
		xa32ede1025f7736e = new int[num];
		reader.ReadUInt16();
		for (int i = 0; i < num; i++)
		{
			xf74d8efdcaef8ee6[i] = reader.ReadInt32();
			xa32ede1025f7736e[i] = reader.ReadInt32();
		}
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write((ushort)xea1e81378298fa81);
		xbdfb620b7167944b.Write((ushort)xf74d8efdcaef8ee6.Length);
		xbdfb620b7167944b.Write((ushort)0);
		for (int i = 0; i < xf74d8efdcaef8ee6.Length; i++)
		{
			xbdfb620b7167944b.Write(xf74d8efdcaef8ee6[i]);
			xbdfb620b7167944b.Write(xa32ede1025f7736e[i]);
		}
	}
}
