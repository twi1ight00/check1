using System.IO;
using Aspose.Words.Settings;
using x79578da6a8a3ae37;

namespace xa604c4d210ae0581;

internal class x245cb6bf933aaf97
{
	internal MailMergeDataType xabdd4c8efb3f2050;

	internal bool x3289a7dac77cb243;

	internal bool x99a060dbcb60103a;

	internal bool xade2f9dc5d3b68d8;

	internal bool xef80fb6c6a293ea1;

	internal x42ea19b084a7c370 x32158491f5e28d99;

	internal x42ea19b084a7c370 xa0c0ceaacfcd0c83;

	internal int x6f148b4649a10af0;

	internal x245cb6bf933aaf97()
	{
	}

	internal x245cb6bf933aaf97(BinaryReader reader)
	{
		xabdd4c8efb3f2050 = (MailMergeDataType)reader.ReadByte();
		int num = reader.ReadByte();
		x3289a7dac77cb243 = (num & 1) != 0;
		x99a060dbcb60103a = (num & 2) != 0;
		xade2f9dc5d3b68d8 = (num & 4) != 0;
		xef80fb6c6a293ea1 = (num & 8) != 0;
		x32158491f5e28d99 = (x42ea19b084a7c370)reader.ReadInt16();
		xa0c0ceaacfcd0c83 = (x42ea19b084a7c370)reader.ReadInt16();
		x6f148b4649a10af0 = reader.ReadInt16();
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write((byte)xabdd4c8efb3f2050);
		int num = 0;
		num |= (x3289a7dac77cb243 ? 1 : 0);
		num |= (x99a060dbcb60103a ? 2 : 0);
		num |= (xade2f9dc5d3b68d8 ? 4 : 0);
		num |= (xef80fb6c6a293ea1 ? 8 : 0);
		xbdfb620b7167944b.Write((byte)num);
		xbdfb620b7167944b.Write((short)x32158491f5e28d99);
		xbdfb620b7167944b.Write((short)xa0c0ceaacfcd0c83);
		xbdfb620b7167944b.Write((short)x6f148b4649a10af0);
	}
}
