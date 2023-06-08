using System.IO;

namespace x650fee20d618512c;

internal class xbe381c99c49e5bb0
{
	internal x0486206a85f53753 x75a94114ed00f99b;

	internal xe9b252f3b5f4e1ed x915ce04b6995076f;

	internal int xe46e0b6a73ca799b;

	internal int x252bd7f063d1cfa8;

	internal int xc96fb0ddcd34be0c;

	internal int x9b0739496f8b5475;

	internal int x4d5aabc7a55b12ba;

	internal xbe381c99c49e5bb0(BinaryReader reader)
	{
		reader.ReadByte();
		reader.ReadByte();
		x75a94114ed00f99b = (x0486206a85f53753)reader.ReadByte();
		x915ce04b6995076f = (xe9b252f3b5f4e1ed)reader.ReadByte();
		xe46e0b6a73ca799b = reader.ReadUInt16();
		x252bd7f063d1cfa8 = reader.ReadInt32();
		xc96fb0ddcd34be0c = reader.ReadByte();
		if ((x75a94114ed00f99b & x0486206a85f53753.xa8c85e13b416f594) != 0)
		{
			x9b0739496f8b5475 = reader.ReadUInt16();
			x4d5aabc7a55b12ba = reader.ReadUInt16();
		}
	}
}
