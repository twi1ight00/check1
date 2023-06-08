using System.IO;
using System.Text;

namespace x011d489fb9df7027;

internal class xd11a6e043172eeb6
{
	internal int x94a76e3a5bbb5ca6;

	internal int x329e3c69afa4fbe7;

	internal string xba89ca2127612c56;

	internal string x8e132340d926fc9c;

	internal int xf9ae63fc557debf2;

	internal string xe0ce4dd9132871d4;

	internal int x00917a4a76319d76;

	internal xd11a6e043172eeb6(BinaryReader reader)
	{
		x94a76e3a5bbb5ca6 = reader.ReadInt32();
		x329e3c69afa4fbe7 = reader.ReadUInt16();
		if (x329e3c69afa4fbe7 == 2)
		{
			xba89ca2127612c56 = xbe24fe5b7462deff(reader);
			x8e132340d926fc9c = xbe24fe5b7462deff(reader);
			reader.ReadUInt16();
			xf9ae63fc557debf2 = reader.ReadUInt16();
			switch (xf9ae63fc557debf2)
			{
			case 1:
				reader.ReadUInt16();
				xe0ce4dd9132871d4 = xbe24fe5b7462deff(reader);
				reader.ReadUInt16();
				break;
			case 3:
				reader.ReadInt32();
				xe0ce4dd9132871d4 = xbe24fe5b7462deff(reader);
				x00917a4a76319d76 = reader.ReadInt32();
				break;
			case 2:
				break;
			}
		}
	}

	private static string xbe24fe5b7462deff(BinaryReader xe134235b3526fa75)
	{
		StringBuilder stringBuilder = new StringBuilder();
		while (true)
		{
			char c = xe134235b3526fa75.ReadChar();
			if (c == '\0')
			{
				break;
			}
			stringBuilder.Append(c);
		}
		return stringBuilder.ToString();
	}
}
