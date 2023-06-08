using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ns33;
using ns60;

namespace ns63;

internal abstract class Class2639 : Class2623
{
	private List<Class2623> list_0 = new List<Class2623>(10);

	private bool bool_1;

	public bool AutoInit
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
			if (!value)
			{
				vmethod_5();
			}
		}
	}

	public List<Class2623> Records => list_0;

	public Class2623 this[int index] => list_0[index];

	public virtual void vmethod_5()
	{
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("{0} Start\n", GetType().Name);
		stringBuilder.AppendFormat("Self: {0}\n", base.ToString());
		for (int i = 0; i < Records.Count; i++)
		{
			stringBuilder.AppendFormat("{0}\n", Records[i]);
		}
		stringBuilder.AppendFormat("{0} End\n", GetType().Name);
		return stringBuilder.ToString();
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		long num = reader.BaseStream.Position + base.Header.Length;
		while (reader.BaseStream.Position < num)
		{
			Class2623 item = Class2950.smethod_1(reader, this);
			Records.Add(item);
		}
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		for (int i = 0; i < Records.Count; i++)
		{
			Class2623 @class = Records[i];
			if (@class is Class2727)
			{
				Class2727 class2 = (Class2727)@class;
				if (class2.Records.Count == 0)
				{
					continue;
				}
			}
			Records[i].Write(writer);
		}
	}

	public override int vmethod_2()
	{
		int num = 0;
		for (int i = 0; i < Records.Count; i++)
		{
			Class2623 @class = Records[i];
			if (@class is Class2727)
			{
				Class2727 class2 = (Class2727)@class;
				if (class2.Records.Count == 0)
				{
					continue;
				}
			}
			num += @class.vmethod_2() + 8;
		}
		return num;
	}

	public Class2623 method_1(ushort recordType)
	{
		int num = 0;
		Class2623 @class;
		while (true)
		{
			if (num < Records.Count)
			{
				@class = Records[num];
				if (@class.Type == recordType)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return @class.method_0();
	}

	public static List<Class2623> smethod_0(Class2639 container, ushort recordType)
	{
		List<Class2623> list = new List<Class2623>();
		smethod_1(container.Records, recordType, list);
		return list;
	}

	public override void vmethod_3(Interface38 statistics)
	{
		if (statistics == null)
		{
			return;
		}
		foreach (Class2623 record in Records)
		{
			record.vmethod_3(statistics);
		}
	}

	public void method_2(Class2623 record)
	{
		int[] array = vmethod_6();
		record.ParentRecord = this;
		int i;
		for (i = 0; i + 1 < array.Length && (array[i] != record.Type || (array[i + 1] != int.MaxValue && array[i + 1] != record.Header.Instance)); i += 2)
		{
		}
		if (i + 1 >= array.Length)
		{
			Records.Add(record);
			return;
		}
		int num = 0;
		int num2 = 0;
		while (true)
		{
			if (num < Records.Count)
			{
				Class2623 @class = Records[num];
				if (array[num2] == @class.Type && (array[num2 + 1] == int.MaxValue || array[num2 + 1] == @class.Header.Instance))
				{
					num++;
					continue;
				}
				int j;
				for (j = num2 + 2; j + 1 < array.Length && (array[j] != @class.Type || (array[j + 1] != int.MaxValue && array[j + 1] != @class.Header.Instance)); j += 2)
				{
				}
				if (j + 1 >= array.Length)
				{
					break;
				}
				if (j <= i)
				{
					num2 = j;
					continue;
				}
				Records.Insert(num, record);
				return;
			}
			Records.Add(record);
			return;
		}
		Records.Insert(num, record);
	}

	internal Class2639()
	{
		base.Header.Version = 15;
		base.Header.Type = 0;
	}

	internal Class2639(ushort type)
	{
		base.Header.Version = 15;
		base.Header.Type = type;
	}

	public Class2623 method_3(ushort recordType, short instance)
	{
		int num = 0;
		Class2623 @class;
		while (true)
		{
			if (num < Records.Count)
			{
				@class = Records[num];
				if (@class.Type == recordType && @class.Header.Instance == instance)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return @class.method_0();
	}

	protected Class2843 method_4(short instance)
	{
		int num = 0;
		while (true)
		{
			if (num < Records.Count)
			{
				if (Records[num] is Class2843 && Records[num].Header.Instance == instance)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return (Class2843)Records[num];
	}

	protected virtual int[] vmethod_6()
	{
		throw new NotImplementedException();
	}

	private static void smethod_1(IEnumerable<Class2623> containerRecords, ushort recordType, List<Class2623> outputRecords)
	{
		foreach (Class2623 containerRecord in containerRecords)
		{
			if (containerRecord.Type == recordType)
			{
				outputRecords.Add(containerRecord);
				continue;
			}
			Class2623 @class = containerRecord as Class2639;
			if (@class != null)
			{
				smethod_1(((Class2639)@class).Records, recordType, outputRecords);
			}
		}
	}
}
