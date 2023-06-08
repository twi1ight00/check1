using System;
using System.IO;
using ns11;
using ns2;

namespace ns59;

internal class Class1728
{
	private Class1647 class1647_0;

	private void method_0(Class1647 class1647_1)
	{
		if (class1647_1 == null)
		{
			class1647_0 = Class1677.smethod_39();
		}
		else
		{
			class1647_0 = class1647_1;
		}
	}

	internal void method_1(Stream stream_0, Class1647 class1647_1)
	{
		method_0(class1647_1);
		stream_0.Seek(0L, SeekOrigin.Begin);
		while (stream_0.Position < stream_0.Length)
		{
			byte[] array = new byte[2];
			stream_0.Read(array, 0, 2);
			short num;
			switch (BitConverter.ToUInt16(array, 0))
			{
			case 133:
				stream_0.Read(array, 0, 2);
				num = BitConverter.ToInt16(array, 0);
				stream_0.Seek(4L, SeekOrigin.Current);
				array = new byte[num - 4];
				stream_0.Read(array, 0, num - 4);
				array = method_4(stream_0, array);
				stream_0.Seek(4 - num, SeekOrigin.Current);
				stream_0.Write(array, 0, num - 4);
				continue;
			case 47:
				stream_0.Read(array, 0, 2);
				num = BitConverter.ToInt16(array, 0);
				stream_0.Seek(num, SeekOrigin.Current);
				continue;
			case 2057:
				stream_0.Seek(18L, SeekOrigin.Current);
				continue;
			case 225:
				stream_0.Seek(4L, SeekOrigin.Current);
				continue;
			}
			stream_0.Read(array, 0, 2);
			num = BitConverter.ToInt16(array, 0);
			if (num != 0)
			{
				array = new byte[num];
				stream_0.Read(array, 0, num);
				array = method_4(stream_0, array);
				stream_0.Seek(-num, SeekOrigin.Current);
				stream_0.Write(array, 0, num);
			}
		}
	}

	internal void method_2(Stream stream_0, Class1638 class1638_0)
	{
		stream_0.Seek(0L, SeekOrigin.Begin);
		while (stream_0.Position < stream_0.Length)
		{
			byte[] array = new byte[2];
			byte[] array2 = null;
			stream_0.Read(array, 0, 2);
			switch (BitConverter.ToUInt16(array, 0))
			{
			case 92:
			{
				stream_0.Read(array, 0, 2);
				short num = BitConverter.ToInt16(array, 0);
				array2 = new byte[num];
				stream_0.Read(array2, 0, num);
				array2 = method_3(stream_0, array2, class1638_0);
				stream_0.Seek(-num, SeekOrigin.Current);
				stream_0.Write(array2, 0, num);
				class1638_0.method_1(0u);
				uint uint_ = (uint)(stream_0.Position - num);
				class1638_0.method_3(array2, uint_);
				break;
			}
			case 47:
			{
				stream_0.Read(array, 0, 2);
				short num = BitConverter.ToInt16(array, 0);
				stream_0.Seek(num, SeekOrigin.Current);
				break;
			}
			case 2057:
				stream_0.Seek(18L, SeekOrigin.Current);
				break;
			default:
			{
				stream_0.Read(array, 0, 2);
				short num = BitConverter.ToInt16(array, 0);
				if (num != 0)
				{
					array2 = new byte[num];
					stream_0.Read(array2, 0, num);
					array2 = method_3(stream_0, array2, class1638_0);
					stream_0.Seek(-num, SeekOrigin.Current);
					stream_0.Write(array2, 0, num);
				}
				break;
			}
			case 225:
				stream_0.Seek(4L, SeekOrigin.Current);
				break;
			case 133:
			{
				stream_0.Read(array, 0, 2);
				short num = BitConverter.ToInt16(array, 0);
				stream_0.Seek(4L, SeekOrigin.Current);
				array = new byte[num - 4];
				stream_0.Read(array, 0, num - 4);
				array = method_3(stream_0, array, class1638_0);
				stream_0.Seek(4 - num, SeekOrigin.Current);
				stream_0.Write(array, 0, num - 4);
				break;
			}
			}
		}
	}

	private byte[] method_3(Stream stream_0, byte[] byte_0, Class1638 class1638_0)
	{
		uint uint_ = (uint)(stream_0.Position - byte_0.Length);
		return class1638_0.method_4(byte_0, uint_);
	}

	private byte[] method_4(Stream stream_0, byte[] byte_0)
	{
		uint uint_ = (uint)(stream_0.Position - byte_0.Length);
		return class1647_0.method_0(byte_0, 0, (ushort)byte_0.Length, uint_);
	}

	private byte[] method_5(Stream stream_0, byte[] byte_0, Class1637 class1637_0)
	{
		int int_ = (int)(stream_0.Position - byte_0.Length);
		return class1637_0.method_0(byte_0, int_, (short)byte_0.Length);
	}

	private byte[] method_6(Stream stream_0, byte[] byte_0, Class1637 class1637_0)
	{
		int int_ = (int)(stream_0.Position - byte_0.Length);
		return class1637_0.Decrypt(byte_0, int_, (short)byte_0.Length);
	}

	internal void Decrypt(Stream stream_0, Class1637 class1637_0)
	{
		stream_0.Seek(0L, SeekOrigin.Begin);
		while (stream_0.Position < stream_0.Length)
		{
			byte[] array = new byte[2];
			stream_0.Read(array, 0, 2);
			short num;
			switch (BitConverter.ToUInt16(array, 0))
			{
			case 133:
				stream_0.Read(array, 0, 2);
				num = BitConverter.ToInt16(array, 0);
				array = new byte[num];
				stream_0.Read(array, 0, num);
				array = method_6(stream_0, array, class1637_0);
				stream_0.Seek(4 - num, SeekOrigin.Current);
				stream_0.Write(array, 4, num - 4);
				continue;
			case 47:
				stream_0.Seek(8L, SeekOrigin.Current);
				continue;
			case 2057:
				stream_0.Seek(18L, SeekOrigin.Current);
				continue;
			case 225:
				stream_0.Seek(4L, SeekOrigin.Current);
				continue;
			}
			stream_0.Read(array, 0, 2);
			num = BitConverter.ToInt16(array, 0);
			if (num != 0)
			{
				array = new byte[num];
				stream_0.Read(array, 0, num);
				array = method_6(stream_0, array, class1637_0);
				stream_0.Seek(-num, SeekOrigin.Current);
				stream_0.Write(array, 0, num);
			}
		}
	}

	internal void method_7(Stream stream_0, Class1637 class1637_0)
	{
		stream_0.Seek(0L, SeekOrigin.Begin);
		while (stream_0.Position < stream_0.Length)
		{
			byte[] array = new byte[2];
			stream_0.Read(array, 0, 2);
			short num;
			switch (BitConverter.ToUInt16(array, 0))
			{
			case 133:
				stream_0.Read(array, 0, 2);
				num = BitConverter.ToInt16(array, 0);
				array = new byte[num];
				stream_0.Read(array, 0, num);
				array = method_5(stream_0, array, class1637_0);
				stream_0.Seek(4 - num, SeekOrigin.Current);
				stream_0.Write(array, 4, num - 4);
				continue;
			case 47:
				stream_0.Seek(8L, SeekOrigin.Current);
				continue;
			case 2057:
				stream_0.Seek(18L, SeekOrigin.Current);
				continue;
			case 225:
				stream_0.Seek(4L, SeekOrigin.Current);
				continue;
			}
			stream_0.Read(array, 0, 2);
			num = BitConverter.ToInt16(array, 0);
			if (num != 0)
			{
				array = new byte[num];
				stream_0.Read(array, 0, num);
				array = method_5(stream_0, array, class1637_0);
				stream_0.Seek(-num, SeekOrigin.Current);
				stream_0.Write(array, 0, num);
			}
		}
	}
}
