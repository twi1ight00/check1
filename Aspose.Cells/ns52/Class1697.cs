using System;
using System.Collections;
using System.IO;
using Aspose.Cells;
using ns22;

namespace ns52;

internal class Class1697 : CollectionBase
{
	private Class1703 class1703_0;

	public Class1696 this[int int_0] => (Class1696)base.InnerList[int_0];

	internal uint Length
	{
		get
		{
			uint num = 0u;
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Class1696 @class = (Class1696)enumerator.Current;
					num += 8 + @class.Length;
				}
				return num;
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
	}

	internal Class1697(Class1703 class1703_1)
	{
		class1703_0 = class1703_1;
	}

	internal void Copy(Class1697 class1697_0)
	{
		foreach (Class1696 item in class1697_0)
		{
			Class1696 @class = new Class1696();
			@class.Copy(item);
			base.InnerList.Add(@class);
		}
	}

	internal int Copy(Class1696 class1696_0, int int_0, bool bool_0)
	{
		if (bool_0)
		{
			class1696_0.method_7();
			return int_0;
		}
		int num = 0;
		Class1696 @class;
		while (true)
		{
			if (num < base.Count)
			{
				@class = this[num];
				bool flag = true;
				for (int i = 0; i < 16; i++)
				{
					if (class1696_0.method_5().byte_2[i] != @class.method_5().byte_2[i])
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					break;
				}
				num++;
				continue;
			}
			Class1696 class2 = new Class1696();
			class2.Copy(class1696_0);
			class2.method_7();
			base.InnerList.Add(class2);
			return base.Count;
		}
		@class.method_7();
		return num + 1;
	}

	internal void Add(Class1696 class1696_0)
	{
		base.InnerList.Add(class1696_0);
	}

	internal int Add(Stream stream_0)
	{
		try
		{
			byte[] byte_ = Class936.smethod_1(stream_0, bool_0: false);
			Class1696 @class = new Class1696(byte_, class1703_0.method_8().method_75());
			byte[] array = @class.method_6();
			int num = 0;
			Class1696 class2;
			while (true)
			{
				if (num < base.Count)
				{
					class2 = this[num];
					bool flag = true;
					for (int i = 0; i < 16; i++)
					{
						if (array[i] != class2.method_5().byte_2[i])
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						break;
					}
					num++;
					continue;
				}
				base.InnerList.Add(@class);
				return base.Count - 1;
			}
			class2.method_7();
			return num;
		}
		catch (Exception ex)
		{
			throw new CellsException(ExceptionType.InvalidData, "Unknown image format:" + ex.Message);
		}
	}
}
