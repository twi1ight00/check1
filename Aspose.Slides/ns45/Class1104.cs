using System;
using System.Collections.Generic;
using System.IO;

namespace ns45;

internal class Class1104 : Interface36
{
	private readonly Stream stream_0;

	private Class1103 class1103_0;

	private List<Class1111> list_0;

	private Class1100 class1100_0;

	private Class1101 class1101_0;

	public Class1103 imethod_0()
	{
		return class1103_0;
	}

	public Class1111 imethod_1(int i)
	{
		return list_0[i];
	}

	public int imethod_2()
	{
		return list_0.Count;
	}

	public Class1100 imethod_3()
	{
		return class1100_0;
	}

	public Class1101 imethod_4()
	{
		return class1101_0;
	}

	public Class1104(Stream inStream)
	{
		stream_0 = inStream;
		Read();
	}

	private void Read()
	{
		method_1();
		method_2();
		method_3();
		if (class1103_0.method_28() != -2L)
		{
			class1100_0.method_9(this, (int)class1103_0.method_28());
		}
		method_0();
	}

	private void method_0()
	{
		class1101_0 = new Class1101(class1103_0.method_11());
		class1101_0.method_3(class1100_0, this);
	}

	private Class1103 method_1()
	{
		class1103_0 = new Class1103(stream_0);
		return class1103_0;
	}

	private void method_2()
	{
		class1100_0 = new Class1100((int)class1103_0.method_26(), class1103_0.method_11());
		class1100_0.method_5(stream_0);
	}

	private void method_3()
	{
		int num = class1103_0.method_11();
		bool flag = false;
		list_0 = new List<Class1111>();
		BinaryReader binaryReader = new BinaryReader(stream_0);
		while (!flag)
		{
			byte[] array = binaryReader.ReadBytes(num);
			if (array.Length < num)
			{
				if (array.Length > 0)
				{
					byte[] array2 = new byte[num];
					Array.Copy(array, array2, array.Length);
					array = array2;
				}
				else
				{
					array = new byte[num];
					flag = true;
				}
			}
			list_0.Add(new Class1111(array));
		}
	}
}
