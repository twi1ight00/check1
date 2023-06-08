using System;
using System.Runtime.InteropServices;

namespace ns16;

[ClassInterface(ClassInterfaceType.AutoDispatch)]
[Guid("ebc25cf6-9120-4283-b972-0e5520d0000D")]
[ComVisible(true)]
internal sealed class Class765
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

	internal Class752 class752_0;

	internal Class757 class757_0;

	internal uint uint_0;

	public Enum42 enum42_0 = Enum42.const_8;

	public int int_4 = 15;

	public Enum43 enum43_0;

	public int method_0(bool bool_0)
	{
		return method_1(int_4, bool_0);
	}

	public int method_1(int int_5, bool bool_0)
	{
		int_4 = int_5;
		if (class752_0 != null)
		{
			throw new Exception5("You may not call InitializeInflate() after calling InitializeDeflate().");
		}
		class757_0 = new Class757(bool_0);
		return class757_0.Initialize(this, int_5);
	}

	public int method_2(Enum41 enum41_0)
	{
		if (class757_0 == null)
		{
			throw new Exception5("No Inflate State!");
		}
		return class757_0.method_2(enum41_0);
	}

	public int method_3()
	{
		if (class757_0 == null)
		{
			throw new Exception5("No Inflate State!");
		}
		int result = class757_0.method_1();
		class757_0 = null;
		return result;
	}

	public int method_4(Enum42 enum42_1, bool bool_0)
	{
		enum42_0 = enum42_1;
		return method_5(bool_0);
	}

	private int method_5(bool bool_0)
	{
		if (class757_0 != null)
		{
			throw new Exception5("You may not call InitializeDeflate() after calling InitializeInflate().");
		}
		class752_0 = new Class752();
		class752_0.method_27(bool_0);
		return class752_0.Initialize(this, enum42_0, int_4, enum43_0);
	}

	public int method_6(Enum41 enum41_0)
	{
		if (class752_0 == null)
		{
			throw new Exception5("No Deflate State!");
		}
		return class752_0.method_29(enum41_0);
	}

	public int method_7()
	{
		if (class752_0 == null)
		{
			throw new Exception5("No Deflate State!");
		}
		class752_0 = null;
		return 0;
	}

	public void method_8()
	{
		if (class752_0 == null)
		{
			throw new Exception5("No Deflate State!");
		}
		class752_0.Reset();
	}

	internal void method_9()
	{
		int int_ = class752_0.int_21;
		if (int_ > int_3)
		{
			int_ = int_3;
		}
		if (int_ != 0)
		{
			if (class752_0.byte_0.Length <= class752_0.int_20 || byte_1.Length <= int_2 || class752_0.byte_0.Length < class752_0.int_20 + int_ || byte_1.Length < int_2 + int_)
			{
				throw new Exception5($"Invalid State. (pending.Length={class752_0.byte_0.Length}, pendingCount={class752_0.int_21})");
			}
			Array.Copy(class752_0.byte_0, class752_0.int_20, byte_1, int_2, int_);
			int_2 += int_;
			class752_0.int_20 += int_;
			long_1 += int_;
			int_3 -= int_;
			class752_0.int_21 -= int_;
			if (class752_0.int_21 == 0)
			{
				class752_0.int_20 = 0;
			}
		}
	}

	internal int method_10(byte[] byte_2, int int_5, int int_6)
	{
		int num = int_1;
		if (num > int_6)
		{
			num = int_6;
		}
		if (num == 0)
		{
			return 0;
		}
		int_1 -= num;
		if (class752_0.method_26())
		{
			uint_0 = Class764.smethod_0(uint_0, byte_0, int_0, num);
		}
		Array.Copy(byte_0, int_0, byte_2, int_5, num);
		int_0 += num;
		long_0 += num;
		return num;
	}
}
