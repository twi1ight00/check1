using System;

namespace ns276;

internal sealed class Class6756
{
	public byte[] byte_0;

	public int int_0;

	public int int_1;

	public long long_0;

	public byte[] byte_1;

	public int int_2;

	public int int_3;

	public long long_1;

	public string string_0;

	internal Class6741 class6741_0;

	internal Class6746 class6746_0;

	internal long long_2;

	public Enum914 enum914_0 = Enum914.const_8;

	public int int_4 = 15;

	public Enum915 enum915_0;

	public long Adler32 => long_2;

	public Class6756()
	{
	}

	public Class6756(Enum916 mode)
	{
		switch (mode)
		{
		case Enum916.const_0:
			if (method_7() != 0)
			{
				throw new Exception67("Cannot initialize for deflate.");
			}
			break;
		case Enum916.const_1:
			if (method_0() != 0)
			{
				throw new Exception67("Cannot initialize for inflate.");
			}
			break;
		default:
			throw new Exception67("Invalid ZlibStreamFlavor.");
		}
	}

	public int method_0()
	{
		return method_2(int_4);
	}

	public int method_1(bool expectRfc1950Header)
	{
		return method_3(int_4, expectRfc1950Header);
	}

	public int method_2(int windowBits)
	{
		int_4 = windowBits;
		return method_3(windowBits, expectRfc1950Header: true);
	}

	public int method_3(int windowBits, bool expectRfc1950Header)
	{
		int_4 = windowBits;
		if (class6741_0 != null)
		{
			throw new Exception67("You may not call InitializeInflate() after calling InitializeDeflate().");
		}
		class6746_0 = new Class6746(expectRfc1950Header);
		return class6746_0.Initialize(this, windowBits);
	}

	public int method_4(Enum898 flush)
	{
		if (class6746_0 == null)
		{
			throw new Exception67("No Inflate State!");
		}
		return class6746_0.method_1(flush);
	}

	public int method_5()
	{
		if (class6746_0 == null)
		{
			throw new Exception67("No Inflate State!");
		}
		int result = class6746_0.method_0();
		class6746_0 = null;
		return result;
	}

	public int method_6()
	{
		if (class6746_0 == null)
		{
			throw new Exception67("No Inflate State!");
		}
		return class6746_0.method_3();
	}

	public int method_7()
	{
		return method_12(wantRfc1950Header: true);
	}

	public int method_8(Enum914 level)
	{
		enum914_0 = level;
		return method_12(wantRfc1950Header: true);
	}

	public int method_9(Enum914 level, bool wantRfc1950Header)
	{
		enum914_0 = level;
		return method_12(wantRfc1950Header);
	}

	public int method_10(Enum914 level, int bits)
	{
		enum914_0 = level;
		int_4 = bits;
		return method_12(wantRfc1950Header: true);
	}

	public int method_11(Enum914 level, int bits, bool wantRfc1950Header)
	{
		enum914_0 = level;
		int_4 = bits;
		return method_12(wantRfc1950Header);
	}

	private int method_12(bool wantRfc1950Header)
	{
		if (class6746_0 != null)
		{
			throw new Exception67("You may not call InitializeDeflate() after calling InitializeInflate().");
		}
		class6741_0 = new Class6741();
		class6741_0.WantRfc1950HeaderBytes = wantRfc1950Header;
		return class6741_0.Initialize(this, enum914_0, int_4, enum915_0);
	}

	public int method_13(Enum898 flush)
	{
		if (class6741_0 == null)
		{
			throw new Exception67("No Deflate State!");
		}
		return class6741_0.method_32(flush);
	}

	public int method_14()
	{
		if (class6741_0 == null)
		{
			throw new Exception67("No Deflate State!");
		}
		int result = class6741_0.method_29();
		class6741_0 = null;
		return result;
	}

	public void method_15()
	{
		if (class6741_0 == null)
		{
			throw new Exception67("No Deflate State!");
		}
		class6741_0.Reset();
	}

	public int method_16(Enum914 level, Enum915 strategy)
	{
		if (class6741_0 == null)
		{
			throw new Exception67("No Deflate State!");
		}
		return class6741_0.method_30(level, strategy);
	}

	public int method_17(byte[] dictionary)
	{
		if (class6746_0 != null)
		{
			return class6746_0.method_2(dictionary);
		}
		if (class6741_0 == null)
		{
			throw new Exception67("No Inflate or Deflate state!");
		}
		return class6741_0.method_31(dictionary);
	}

	internal void method_18()
	{
		int int_ = class6741_0.int_30;
		if (int_ > int_3)
		{
			int_ = int_3;
		}
		if (int_ != 0)
		{
			if (class6741_0.byte_0.Length <= class6741_0.int_29 || byte_1.Length <= int_2 || class6741_0.byte_0.Length < class6741_0.int_29 + int_ || byte_1.Length < int_2 + int_)
			{
				throw new Exception67($"Invalid State. (pending.Length={class6741_0.byte_0.Length}, pendingCount={class6741_0.int_30})");
			}
			Array.Copy(class6741_0.byte_0, class6741_0.int_29, byte_1, int_2, int_);
			int_2 += int_;
			class6741_0.int_29 += int_;
			long_1 += int_;
			int_3 -= int_;
			class6741_0.int_30 -= int_;
			if (class6741_0.int_30 == 0)
			{
				class6741_0.int_29 = 0;
			}
		}
	}

	internal int method_19(byte[] buf, int start, int size)
	{
		int num = int_1;
		if (num > size)
		{
			num = size;
		}
		if (num == 0)
		{
			return 0;
		}
		int_1 -= num;
		if (class6741_0.WantRfc1950HeaderBytes)
		{
			long_2 = Class6755.smethod_0(long_2, byte_0, int_0, num);
		}
		Array.Copy(byte_0, int_0, buf, start, num);
		int_0 += num;
		long_0 += num;
		return num;
	}
}
