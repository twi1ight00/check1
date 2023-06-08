using System;
using System.IO;
using System.Text;
using Aspose;
using Aspose.Words;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace xa604c4d210ae0581;

internal class x8aeace2bf92692ab
{
	internal const int xb674f9a1d781384a = 68;

	internal const int xe506472af74e4c7b = 93;

	internal const int xe93509dd1582baa5 = 108;

	internal const int xed70afc37cb842eb = 136;

	internal const int xc55a520bf1b74ac0 = 164;

	internal const int xc3e15bc7c16a3bb8 = 183;

	private const int x1df07f7ba644ca48 = 898;

	private ushort x5f5cc1c32334d993;

	internal x3a9e25666c8d1ee1 x4debd6958bcd2b55;

	private ushort x73a1e305574eb564;

	private short x835e4449b464b4ff;

	private short xe13a429298806b09;

	internal bool x6e7b4319da225d18;

	private bool x0d530648a27ff549;

	internal bool xa9455751659fce9a;

	internal bool x9c1eabb9200f04a0;

	internal int xdfcd77c301257abf;

	internal bool xa07212033002e423;

	internal bool x76a664845d700102;

	internal bool x240eec731225c48e;

	internal bool x61144b80cccda275;

	private bool x5ac14f6e10f33899;

	private bool x0b7aa040f9a3cf6e;

	private bool xb4039c7c5bd43aaf;

	internal bool x9729e21f6f99ff8e;

	internal ushort xc6ad7b9979f7a862;

	internal int x7f6d57b052cf10a1;

	private byte x3e601acd111d1459;

	private bool x6dcf24a9b4cbb951;

	private bool x62fa4f18373e9848;

	private bool x983b1fcdf4ae5ed5;

	private bool xd2db69cac75b630f;

	private bool xeaf7f77c32c1daba;

	private ushort xcea0888db854bf5d;

	private ushort xd4eef15de4571b37;

	internal int xfc37d20436abe4da;

	internal int xac503f724179767e;

	private ushort x80eaf490a6d11231;

	private ushort x75b5dfef4a74a7fc;

	private ushort x5b85f5e15dfaa6a0;

	private ushort x1369adb4e974cd22;

	private ushort x297ceca630631edf;

	private short xf28518085958e54c;

	private ushort x696d8387af70cafc;

	internal int x80d8e916f0118723;

	private int x2d1c65a885cca6c3;

	private int x8900c05aed89c224;

	internal int x3ab228b2748114ba;

	internal int xb2064fa1fb7ec49d;

	internal int xb7cf421883a1056d;

	private int x0282831212e026ad;

	internal int xe912105fd2ce9a26;

	internal int xe424d5fa33780ef0;

	internal int x104e0eb43d042a92;

	internal int x0e27fa6d83e7f186;

	private int xd9716dd786cb533b;

	private int xb02bb78a28f6e0e5;

	private int xc19b224f3458379f;

	private int x9fcae0e22e6782cf;

	private int x4b5cb097b6046069;

	private int x58cbe8130326417b;

	private int x0fd99cc8b266163f;

	private int x267fb78ccffaa30b;

	private int x1564426eecfd1d5b;

	private int x15f3f40cb543f15f;

	private int x075396cd2d3f5f21;

	private ushort xb2703a606fce1f26;

	internal x955a03f821588c52 x955a03f821588c52 = new x955a03f821588c52();

	internal x01bd3f0735eb5899 x01bd3f0735eb5899 = new x01bd3f0735eb5899();

	internal x4605e55a1901024b x4605e55a1901024b = new x4605e55a1901024b();

	internal x61c3ae0ca90c00b3 x61c3ae0ca90c00b3 = new x61c3ae0ca90c00b3();

	internal x12f68c3c6e8308df x12f68c3c6e8308df = new x12f68c3c6e8308df();

	private readonly IWarningCallback xa056586c1f99e199;

	internal static bool x492f529cee830a40;

	internal string xa20346a1e3c44f1b
	{
		get
		{
			if (!x76a664845d700102)
			{
				return "0Table";
			}
			return "1Table";
		}
	}

	internal bool x3bf62ca21be92f49 => x4debd6958bcd2b55 < x3a9e25666c8d1ee1.x2d2c6bfbdf4c8896;

	internal x8aeace2bf92692ab()
	{
		x5f5cc1c32334d993 = 42476;
		x4debd6958bcd2b55 = x3a9e25666c8d1ee1.x1ab0f9731505945e;
		xb2703a606fce1f26 = 164;
		x73a1e305574eb564 = 24609;
		x835e4449b464b4ff = 1033;
		xa9455751659fce9a = true;
		x5ac14f6e10f33899 = true;
		xc6ad7b9979f7a862 = 191;
		xeaf7f77c32c1daba = true;
		x80eaf490a6d11231 = 14;
		x75b5dfef4a74a7fc = 22337;
		x5b85f5e15dfaa6a0 = 78;
		x1369adb4e974cd22 = (ushort)("11.9.0.0"[0] | ((uint)"11.9.0.0"[2] << 8));
		x297ceca630631edf = (ushort)("11.9.0.0"[4] | ((uint)"11.9.0.0"[6] << 8));
		xf28518085958e54c = 1033;
		x696d8387af70cafc = 22;
		xd9716dd786cb533b = (x9fcae0e22e6782cf = (x0fd99cc8b266163f = 1048575));
		x2d1c65a885cca6c3 = 51006;
		x8900c05aed89c224 = 51006;
	}

	internal x8aeace2bf92692ab(BinaryReader reader, IWarningCallback warningCallback)
	{
		xa056586c1f99e199 = warningCallback;
		x8d84b0fbff3dde4f(reader);
	}

	private void x8d84b0fbff3dde4f(BinaryReader xe134235b3526fa75)
	{
		xe134235b3526fa75.BaseStream.Position = 0L;
		x5f5cc1c32334d993 = xe134235b3526fa75.ReadUInt16();
		x4debd6958bcd2b55 = (x3a9e25666c8d1ee1)xe134235b3526fa75.ReadUInt16();
		x73a1e305574eb564 = xe134235b3526fa75.ReadUInt16();
		x835e4449b464b4ff = xe134235b3526fa75.ReadInt16();
		xe13a429298806b09 = xe134235b3526fa75.ReadInt16();
		int num = xe134235b3526fa75.ReadByte();
		x6e7b4319da225d18 = (num & 1) != 0;
		x0d530648a27ff549 = (num & 2) != 0;
		xa9455751659fce9a = (num & 4) != 0;
		x9c1eabb9200f04a0 = (num & 8) != 0;
		xdfcd77c301257abf = (num & 0xF0) >> 4;
		num = xe134235b3526fa75.ReadByte();
		xa07212033002e423 = (num & 1) != 0;
		x76a664845d700102 = (num & 2) != 0;
		x240eec731225c48e = (num & 4) != 0;
		x61144b80cccda275 = (num & 8) != 0;
		x5ac14f6e10f33899 = (num & 0x10) != 0;
		x0b7aa040f9a3cf6e = (num & 0x20) != 0;
		xb4039c7c5bd43aaf = (num & 0x40) != 0;
		x9729e21f6f99ff8e = (num & 0x80) != 0;
		xc6ad7b9979f7a862 = xe134235b3526fa75.ReadUInt16();
		x7f6d57b052cf10a1 = xe134235b3526fa75.ReadInt32();
		x3e601acd111d1459 = xe134235b3526fa75.ReadByte();
		num = xe134235b3526fa75.ReadByte();
		x6dcf24a9b4cbb951 = (num & 1) != 0;
		x62fa4f18373e9848 = (num & 2) != 0;
		x983b1fcdf4ae5ed5 = (num & 4) != 0;
		xd2db69cac75b630f = (num & 8) != 0;
		xeaf7f77c32c1daba = (num & 0x10) != 0;
		xcea0888db854bf5d = xe134235b3526fa75.ReadUInt16();
		xd4eef15de4571b37 = xe134235b3526fa75.ReadUInt16();
		xfc37d20436abe4da = xe134235b3526fa75.ReadInt32();
		xac503f724179767e = xe134235b3526fa75.ReadInt32();
		x80eaf490a6d11231 = xe134235b3526fa75.ReadUInt16();
		x75b5dfef4a74a7fc = xe134235b3526fa75.ReadUInt16();
		x5b85f5e15dfaa6a0 = xe134235b3526fa75.ReadUInt16();
		x1369adb4e974cd22 = xe134235b3526fa75.ReadUInt16();
		x297ceca630631edf = xe134235b3526fa75.ReadUInt16();
		xe134235b3526fa75.BaseStream.Seek(18L, SeekOrigin.Current);
		xf28518085958e54c = xe134235b3526fa75.ReadInt16();
		x696d8387af70cafc = xe134235b3526fa75.ReadUInt16();
		x80d8e916f0118723 = xe134235b3526fa75.ReadInt32();
	}

	internal void x3a5e2abdc5dbcfd0(BinaryReader xe134235b3526fa75)
	{
		xe134235b3526fa75.BaseStream.Position = 68L;
		x2d1c65a885cca6c3 = xe134235b3526fa75.ReadInt32();
		x8900c05aed89c224 = xe134235b3526fa75.ReadInt32();
		x3ab228b2748114ba = xe134235b3526fa75.ReadInt32();
		xb2064fa1fb7ec49d = xe134235b3526fa75.ReadInt32();
		xb7cf421883a1056d = xe134235b3526fa75.ReadInt32();
		x0282831212e026ad = xe134235b3526fa75.ReadInt32();
		xe912105fd2ce9a26 = xe134235b3526fa75.ReadInt32();
		xe424d5fa33780ef0 = xe134235b3526fa75.ReadInt32();
		x104e0eb43d042a92 = xe134235b3526fa75.ReadInt32();
		x0e27fa6d83e7f186 = xe134235b3526fa75.ReadInt32();
		xd9716dd786cb533b = xe134235b3526fa75.ReadInt32();
		xb02bb78a28f6e0e5 = xe134235b3526fa75.ReadInt32();
		xc19b224f3458379f = xe134235b3526fa75.ReadInt32();
		x9fcae0e22e6782cf = xe134235b3526fa75.ReadInt32();
		x4b5cb097b6046069 = xe134235b3526fa75.ReadInt32();
		x58cbe8130326417b = xe134235b3526fa75.ReadInt32();
		x0fd99cc8b266163f = xe134235b3526fa75.ReadInt32();
		x267fb78ccffaa30b = xe134235b3526fa75.ReadInt32();
		x1564426eecfd1d5b = xe134235b3526fa75.ReadInt32();
		x15f3f40cb543f15f = xe134235b3526fa75.ReadInt32();
		x075396cd2d3f5f21 = xe134235b3526fa75.ReadInt32();
		xb2703a606fce1f26 = xe134235b3526fa75.ReadUInt16();
		int num = (int)xe134235b3526fa75.BaseStream.Position;
		x955a03f821588c52.x06b0e25aa6ad68a9(xe134235b3526fa75);
		if (xb2703a606fce1f26 >= 108)
		{
			x01bd3f0735eb5899.x06b0e25aa6ad68a9(xe134235b3526fa75);
		}
		if (xb2703a606fce1f26 >= 136)
		{
			x4605e55a1901024b.x06b0e25aa6ad68a9(xe134235b3526fa75);
		}
		if (xb2703a606fce1f26 >= 164)
		{
			x61c3ae0ca90c00b3.x06b0e25aa6ad68a9(xe134235b3526fa75);
		}
		if (xb2703a606fce1f26 >= 183)
		{
			x12f68c3c6e8308df.x06b0e25aa6ad68a9(xe134235b3526fa75);
		}
		if (xb2703a606fce1f26 >= 108)
		{
			xe134235b3526fa75.BaseStream.Position = num + xb2703a606fce1f26 * 8;
			int num2 = xe134235b3526fa75.ReadUInt16();
			if (num2 >= 2)
			{
				x4debd6958bcd2b55 = (x3a9e25666c8d1ee1)xe134235b3526fa75.ReadUInt16();
				xdfcd77c301257abf = xe134235b3526fa75.ReadUInt16();
			}
		}
		xc7b443f1cdbccfbe();
	}

	internal void x6210059f049f0d48(Stream xcf18e5243f8d5fd3)
	{
		BinaryWriter binaryWriter = new BinaryWriter(xcf18e5243f8d5fd3, Encoding.Unicode);
		binaryWriter.Write(x5f5cc1c32334d993);
		binaryWriter.Write((ushort)193);
		binaryWriter.Write(x73a1e305574eb564);
		binaryWriter.Write(x835e4449b464b4ff);
		binaryWriter.Write(xe13a429298806b09);
		ushort num = 0;
		if (x6e7b4319da225d18)
		{
			num = (ushort)(num | 1u);
		}
		if (x0d530648a27ff549)
		{
			num = (ushort)(num | 2u);
		}
		if (xa9455751659fce9a)
		{
			num = (ushort)(num | 4u);
		}
		if (x9c1eabb9200f04a0)
		{
			num = (ushort)(num | 8u);
		}
		num = (ushort)(num | (ushort)(0xF0u & (uint)(xdfcd77c301257abf << 4)));
		if (xa07212033002e423)
		{
			num = (ushort)(num | 0x100u);
		}
		if (x76a664845d700102)
		{
			num = (ushort)(num | 0x200u);
		}
		if (x240eec731225c48e)
		{
			num = (ushort)(num | 0x400u);
		}
		if (x61144b80cccda275)
		{
			num = (ushort)(num | 0x800u);
		}
		if (x5ac14f6e10f33899)
		{
			num = (ushort)(num | 0x1000u);
		}
		binaryWriter.Write(num);
		binaryWriter.Write(xc6ad7b9979f7a862);
		binaryWriter.Write(x7f6d57b052cf10a1);
		binaryWriter.Write(x3e601acd111d1459);
		byte b = 0;
		if (x6dcf24a9b4cbb951)
		{
			b = (byte)(b | 1u);
		}
		if (x62fa4f18373e9848)
		{
			b = (byte)(b | 2u);
		}
		if (x983b1fcdf4ae5ed5)
		{
			b = (byte)(b | 4u);
		}
		if (xd2db69cac75b630f)
		{
			b = (byte)(b | 8u);
		}
		if (xeaf7f77c32c1daba)
		{
			b = (byte)(b | 0x10u);
		}
		binaryWriter.Write(b);
		binaryWriter.Write(xcea0888db854bf5d);
		binaryWriter.Write(xd4eef15de4571b37);
		binaryWriter.Write(xfc37d20436abe4da);
		binaryWriter.Write(xac503f724179767e);
		binaryWriter.Write(x80eaf490a6d11231);
		binaryWriter.Write(x75b5dfef4a74a7fc);
		binaryWriter.Write(x5b85f5e15dfaa6a0);
		binaryWriter.Write(x1369adb4e974cd22);
		binaryWriter.Write(x297ceca630631edf);
		binaryWriter.Seek(18, SeekOrigin.Current);
		binaryWriter.Write(xf28518085958e54c);
		binaryWriter.Write(x696d8387af70cafc);
		binaryWriter.Write(x80d8e916f0118723);
		binaryWriter.Write(x2d1c65a885cca6c3);
		binaryWriter.Write(x8900c05aed89c224);
		binaryWriter.Write(x3ab228b2748114ba);
		binaryWriter.Write(xb2064fa1fb7ec49d);
		binaryWriter.Write(xb7cf421883a1056d);
		binaryWriter.Write(x0282831212e026ad);
		binaryWriter.Write(xe912105fd2ce9a26);
		binaryWriter.Write(xe424d5fa33780ef0);
		binaryWriter.Write(x104e0eb43d042a92);
		binaryWriter.Write(x0e27fa6d83e7f186);
		binaryWriter.Write(xd9716dd786cb533b);
		binaryWriter.Write(xb02bb78a28f6e0e5);
		binaryWriter.Write(xc19b224f3458379f);
		binaryWriter.Write(x9fcae0e22e6782cf);
		binaryWriter.Write(x4b5cb097b6046069);
		binaryWriter.Write(x58cbe8130326417b);
		binaryWriter.Write(x0fd99cc8b266163f);
		binaryWriter.Write(x267fb78ccffaa30b);
		binaryWriter.Write(x1564426eecfd1d5b);
		binaryWriter.Write(x15f3f40cb543f15f);
		binaryWriter.Write(x075396cd2d3f5f21);
		binaryWriter.Write(xb2703a606fce1f26);
		int num2 = (int)binaryWriter.BaseStream.Position;
		x955a03f821588c52.x6210059f049f0d48(binaryWriter);
		x01bd3f0735eb5899.x6210059f049f0d48(binaryWriter);
		x4605e55a1901024b.x6210059f049f0d48(binaryWriter);
		x61c3ae0ca90c00b3.x6210059f049f0d48(binaryWriter, x955a03f821588c52.x84d66a6d1fa468c7.xe53f0e68147463d1);
		int num3 = ((int)binaryWriter.BaseStream.Position - num2) / 8;
		binaryWriter.Write((ushort)2);
		binaryWriter.Write((ushort)x4debd6958bcd2b55);
		binaryWriter.Write((ushort)0);
	}

	[JavaDelete("Don't need this logging method in Java.")]
	internal new string ToString()
	{
		return x0d299f323d241756.xd0b98a7a416f4bca(this, "FIB");
	}

	internal int xe53581d2051aca20(int x2865e605e9fbfb80)
	{
		int num = x2865e605e9fbfb80;
		if (num < x3ab228b2748114ba)
		{
			return num;
		}
		num -= x3ab228b2748114ba;
		if (num < xb2064fa1fb7ec49d)
		{
			return num;
		}
		num -= xb2064fa1fb7ec49d;
		if (num < xb7cf421883a1056d)
		{
			return num;
		}
		num -= xb7cf421883a1056d;
		if (num < x0282831212e026ad)
		{
			return num;
		}
		num -= x0282831212e026ad;
		if (num < xe912105fd2ce9a26)
		{
			return num;
		}
		num -= xe912105fd2ce9a26;
		if (num < xe424d5fa33780ef0)
		{
			return num;
		}
		num -= xe424d5fa33780ef0;
		if (num < x104e0eb43d042a92)
		{
			return num;
		}
		num -= x104e0eb43d042a92;
		if (num < x0e27fa6d83e7f186)
		{
			return num;
		}
		throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jancjdedgdldeccejcjejcafkchfibofebfgnmlgobdhgbkhemaicaiihapiiagjilmjabekcmkkmaclmkilmoploogmeonmcpenonlnnncolojojnapdohpbooplifainmagmdbfnkbdnbcmhicnmpcolgdilndaheeclleilcflkjfegagalhgekoglffhmkmhnjdihjkipebjakijoipjojgkhjnkoeelndll", 1460415688)), num));
	}

	internal int x5172d05e08678764(x9e131021ba70185c x77b06614416ee4d3, int x1e5b3c79ded5dbc8)
	{
		int num = x1e5b3c79ded5dbc8;
		if (x77b06614416ee4d3 == x9e131021ba70185c.xc447809891322395)
		{
			return num;
		}
		num += x3ab228b2748114ba;
		if (x77b06614416ee4d3 == x9e131021ba70185c.x69d28a4aeef83a6f)
		{
			return num;
		}
		num += xb2064fa1fb7ec49d;
		if (x77b06614416ee4d3 == x9e131021ba70185c.x1ea60bde2b5d0d28)
		{
			return num;
		}
		num += xb7cf421883a1056d;
		num += x0282831212e026ad;
		if (x77b06614416ee4d3 == x9e131021ba70185c.x937e050c63ea1527)
		{
			return num;
		}
		num += xe912105fd2ce9a26;
		if (x77b06614416ee4d3 == x9e131021ba70185c.xd90ac7fcbe961761)
		{
			return num;
		}
		num += xe424d5fa33780ef0;
		if (x77b06614416ee4d3 == x9e131021ba70185c.xf79eacb7dc6313bb)
		{
			return num;
		}
		num += x104e0eb43d042a92;
		if (x77b06614416ee4d3 == x9e131021ba70185c.xda79e5b626eda365)
		{
			return num;
		}
		throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jabmpbimjbpmjbgnhbnnmbeoabloplbppajpoaaaipgahpnappebaplbppccepjcjoadpohdcpodljfemomeoodfcokfenbgmiigmnpggnghimnhdmeigmliamcjamjjjlakflhkmhok", 1119666356)));
	}

	private void xc7b443f1cdbccfbe()
	{
		x89ca82218e8d711e(xe13a429298806b09 != 0, "AutoText items is not supported in DOC format by Aspose.Words.");
		x89ca82218e8d711e(x0b7aa040f9a3cf6e, "LoadOverride flag is not supported in DOC format by Aspose.Words.");
		x89ca82218e8d711e(xb4039c7c5bd43aaf, "Installation language is FarEast language.");
		x89ca82218e8d711e(x955a03f821588c52.x70d3182315b9a234, "Printer driver information is not supported by Aspose.Words.");
		x89ca82218e8d711e(x955a03f821588c52.x8cb2508c6c2c0cad, "Last selection information is not supported by Aspose.Words.");
		x89ca82218e8d711e(x6e7b4319da225d18 && x955a03f821588c52.xbfea0243fd02cf01, "Captions/AutoCaptions are not supported, ignored.");
		x89ca82218e8d711e(x955a03f821588c52.x80ad755e931abb38, "Spell checker information is not supported by Aspose.Words.");
		x89ca82218e8d711e(x955a03f821588c52.x1d72588da167059c, "Grammar checker information is not supported by Aspose.Words.");
		x89ca82218e8d711e(x955a03f821588c52.x6e417902046283c7, "RouteSlip information is DOC format only feature and lost if saved to another format.");
		x89ca82218e8d711e(x955a03f821588c52.x5191b2ec867b482f, "Word97/2000 save history is not supported by Aspose.Words.");
		x89ca82218e8d711e(x955a03f821588c52.xd26e8e6afe795175, "Document versioning is not supported by Aspose.Words.");
		x89ca82218e8d711e(x955a03f821588c52.xf42995b4f9983752, "Pre-Word2003 additional information for ActiveX is not supported by Aspose.Words.");
		x89ca82218e8d711e(x955a03f821588c52.xaeb93dd91af3bc60, "Priority of a text ranges for AutoSummary is not supported, ignored.");
		x89ca82218e8d711e(x01bd3f0735eb5899.xf31b170dec5d7d1f, "Threading information is not supported by Aspose.Words.");
		x89ca82218e8d711e(x01bd3f0735eb5899.xd93ceb9dfb3f8070, "Hybrid multilevel lists numbering formats is not supported by Apose.Words.");
		x89ca82218e8d711e(x01bd3f0735eb5899.x732a0a91877519b5, "MSO Envelope information is not supported by Aspose.Words.");
		x89ca82218e8d711e(x01bd3f0735eb5899.xb0e24e5fa1f1a332, "Language auto-detect data is not supported by Aspose.Words.");
		x89ca82218e8d711e(x01bd3f0735eb5899.x21b20207b7cd9505, "Grammar checker options is not supported is not supported by Aspose.Words.");
		x89ca82218e8d711e(x4605e55a1901024b.xdcc0d4324e298aba, "Grammar checker cookies is not supported is not supported by Aspose.Words.");
		x89ca82218e8d711e(x4605e55a1901024b.xd8ae9cad0d497c58, "Microsoft Text Framework data is not supported by Aspose.Words.");
		x89ca82218e8d711e(x4605e55a1901024b.xabc940c4b4d17f0f, "Smart tag recognizer data is not supported by Aspose.Words.");
		x89ca82218e8d711e(x4605e55a1901024b.x52fbbdbe7c5e49d3, "Repair bookmarks are not supported by Aspose.Words.");
		x89ca82218e8d711e(x4605e55a1901024b.x4d4435b90dd0e7ff, "Consistency checker bookmarks are not supported, ignored.");
		x89ca82218e8d711e(x4605e55a1901024b.x452abada5987b262, "Revision state identifiers table is not supported in DOC format by Aspose.Words.");
		x89ca82218e8d711e(x4605e55a1901024b.x72fbf422e798858b, "Paragraph range borders and margins is not supported by Aspose.Words.");
		x89ca82218e8d711e(x61c3ae0ca90c00b3.x68948c6d4e93bea5, "Range level protection is not supported by Aspose.Words.");
		x89ca82218e8d711e(x61c3ae0ca90c00b3.xbea5bebc6f07ed65, "Saved revision author selection is not supported, ignored.");
	}

	private void x89ca82218e8d711e(bool x29ca7772d281a736, string xc2358fbac7da3d45)
	{
		if (x29ca7772d281a736)
		{
			x98b0e09ccece0a5a.x3dc950453374051a(xa056586c1f99e199, WarningSource.Doc, xc2358fbac7da3d45);
		}
	}
}
