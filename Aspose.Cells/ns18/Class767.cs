using System.IO;
using System.Runtime.CompilerServices;
using ns22;

namespace ns18;

internal abstract class Class767
{
	internal Stream stream_0;

	internal byte[] byte_0 = new byte[8];

	private int int_0;

	public Class767()
	{
	}

	[Attribute0(true)]
	public virtual void vmethod_0(Stream stream_1)
	{
		stream_0 = stream_1;
		int num = 0;
		num = stream_0.Read(byte_0, 0, byte_0.Length);
		if (num < 8 || byte_0[0] != 137 || byte_0[1] != 80 || byte_0[2] != 78 || byte_0[3] != 71 || byte_0[4] != 13 || byte_0[5] != 10 || byte_0[6] != 26 || byte_0[7] != 10)
		{
			return;
		}
		int_0 += 8;
		bool flag;
		do
		{
			num = stream_0.Read(byte_0, 0, byte_0.Length);
			if (num > 0 && num >= 8)
			{
				int num2 = 8 + method_0() + 4;
				flag = vmethod_1();
				int_0 += num2;
				continue;
			}
			break;
		}
		while (flag);
	}

	[Attribute0(true)]
	protected abstract bool vmethod_1();

	[SpecialName]
	protected int method_0()
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			num += (byte_0[i] & 0xFF) << 24 - i * 8;
		}
		return num;
	}

	protected void method_1()
	{
		int num = method_0() + 4;
		method_2(num);
	}

	protected void method_2(long long_0)
	{
		while (long_0 > 0)
		{
			long num = stream_0.Seek(long_0, SeekOrigin.Current);
			if (num > 0)
			{
				long_0 -= num;
				continue;
			}
			break;
		}
	}
}
