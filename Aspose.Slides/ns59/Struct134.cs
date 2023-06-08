using System.IO;
using ns4;

namespace ns59;

internal struct Struct134
{
	public uint uint_0;

	public bool Reserved1 => 0 != (uint_0 & 1);

	public bool Reserved2 => 0 != (uint_0 & 2);

	public bool fCryptoAPI
	{
		get
		{
			return 0 != (uint_0 & 4);
		}
		set
		{
			uint_0 = (value ? (uint_0 | 4u) : (uint_0 & 0xFFFFFFFBu));
		}
	}

	public bool fDocProps
	{
		get
		{
			return 0 != (uint_0 & 8);
		}
		set
		{
			uint_0 = (value ? (uint_0 | 8u) : (uint_0 & 0xFFFFFFF7u));
		}
	}

	public bool fExternal => 0 != (uint_0 & 0x10);

	public bool fAES => 0 != (uint_0 & 0x20);

	public static Struct134 smethod_0(Stream stream)
	{
		Struct134 result = default(Struct134);
		result.uint_0 = (uint)Class1162.smethod_24(stream);
		return result;
	}
}
