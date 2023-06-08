using ns305;

namespace ns307;

internal static class Class7066
{
	public const short short_0 = 1;

	public const short short_1 = 2;

	public const short short_2 = 3;

	public const int int_0 = -1;

	public const int int_1 = 1;

	public const int int_2 = 2;

	public const int int_3 = 4;

	public const int int_4 = 8;

	public const int int_5 = 16;

	public const int int_6 = 32;

	public const int int_7 = 64;

	public const int int_8 = 128;

	public const int int_9 = 256;

	public const int int_10 = 512;

	public const int int_11 = 1024;

	public const int int_12 = 2048;

	internal static bool smethod_0(Class6976 node, int showFlag)
	{
		if ((showFlag & -1) == -1)
		{
			return true;
		}
		if ((showFlag & 1) == 1 && node.NodeType == Enum969.const_0)
		{
			return true;
		}
		if ((showFlag & 2) == 2 && node.NodeType == Enum969.const_1)
		{
			return true;
		}
		if ((showFlag & 4) == 4 && node.NodeType == Enum969.const_2)
		{
			return true;
		}
		if ((showFlag & 8) == 8 && node.NodeType == Enum969.const_3)
		{
			return true;
		}
		if ((showFlag & 0x10) == 16 && node.NodeType == Enum969.const_4)
		{
			return true;
		}
		if ((showFlag & 0x20) == 32 && node.NodeType == Enum969.const_5)
		{
			return true;
		}
		if ((showFlag & 0x40) == 64 && node.NodeType == Enum969.const_6)
		{
			return true;
		}
		if ((showFlag & 0x80) == 128 && node.NodeType == Enum969.const_7)
		{
			return true;
		}
		if ((showFlag & 0x100) == 256 && node.NodeType == Enum969.const_8)
		{
			return true;
		}
		if ((showFlag & 0x200) == 512 && node.NodeType == Enum969.const_9)
		{
			return true;
		}
		if ((showFlag & 0x400) == 1024 && node.NodeType == Enum969.const_10)
		{
			return true;
		}
		if ((showFlag & 0x800) == 2048 && node.NodeType == Enum969.const_11)
		{
			return true;
		}
		return false;
	}
}
