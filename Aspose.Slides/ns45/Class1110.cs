using System;
using System.Collections.Generic;
using System.IO;

namespace ns45;

internal class Class1110
{
	private Class1103 class1103_0;

	private Class1101 class1101_0;

	private Class1102 class1102_0;

	private Interface36 interface36_0;

	private List<Class1111> list_0;

	private Class1109 class1109_0;

	private Class1100 class1100_0;

	public Class1107 RootFolder
	{
		get
		{
			return class1109_0.RootFolder;
		}
		set
		{
			class1109_0.RootFolder = value;
		}
	}

	public Class1110()
	{
		class1109_0 = new Class1109();
		class1109_0.RootFolder = new Class1107("Root Entry");
	}

	public Class1110(Stream inputStream)
	{
		Read(inputStream);
	}

	public void Read(Stream inputStream)
	{
		interface36_0 = new Class1104(inputStream);
		class1103_0 = interface36_0.imethod_0();
		class1101_0 = interface36_0.imethod_4();
		class1109_0 = new Class1109();
		int num = class1109_0.method_11(interface36_0);
		if (num != -2 && class1103_0.method_22() != -2)
		{
			class1102_0 = new Class1102(class1103_0.method_14());
			class1102_0.method_3(class1103_0.method_22(), class1101_0, interface36_0);
			method_0(num);
		}
		class1109_0.method_0(interface36_0);
		List<Class1105> list = class1109_0.method_5();
		for (int i = 0; i < list.Count; i++)
		{
			Class1105 @class = list[i];
			if (@class is Class1106)
			{
				Class1106 class2 = (Class1106)@class;
				if (class2.Size >= class1103_0.method_20())
				{
					class2.method_5(class2.SId, class1101_0, interface36_0);
				}
				else
				{
					class2.method_6(class2.SId, class1102_0, list_0);
				}
			}
		}
		interface36_0 = null;
		list_0 = null;
	}

	private void method_0(int sid)
	{
		Class1106 @class = new Class1106(sid, class1101_0, interface36_0);
		list_0 = new List<Class1111>();
		int num = class1103_0.method_14();
		for (int i = 0; i < @class.method_7().Length; i += num)
		{
			byte[] array = new byte[num];
			Array.Copy(@class.method_7(), i, array, 0, num);
			Class1111 item = new Class1111(array);
			list_0.Add(item);
		}
	}

	public void Write(Stream output)
	{
		method_12();
		method_11();
		method_10();
		method_9();
		List<Class1105> entries = class1109_0.method_5();
		Class1106 shortContainer = method_8(entries);
		Class1106 directoryStream = class1109_0.method_7();
		method_7(directoryStream);
		class1103_0.method_17(class1101_0.imethod_0(class1103_0.method_11()));
		class1103_0.method_25(class1102_0.imethod_0(class1103_0.method_11()));
		class1103_0.method_29(class1100_0.method_4());
		class1103_0.method_27(class1100_0.imethod_0(class1103_0.method_11()));
		class1103_0.Write(output);
		SortedList<int, Class1111> sortedList = new SortedList<int, Class1111>();
		method_6(output, sortedList);
		method_5(sortedList);
		method_4(sortedList);
		method_3(shortContainer, sortedList);
		method_2(directoryStream, sortedList);
		method_1(entries, sortedList);
		foreach (Class1111 value in sortedList.Values)
		{
			output.Write(value.method_0(), 0, value.method_0().Length);
		}
	}

	private void method_1(List<Class1105> entries, SortedList<int, Class1111> sectorsMap)
	{
		for (int i = 0; i < entries.Count; i++)
		{
			if (!(entries[i] is Class1106))
			{
				continue;
			}
			Class1106 @class = (Class1106)entries[i];
			if (@class.Size >= class1103_0.method_20())
			{
				List<Class1111> list = @class.imethod_1(class1103_0.method_11());
				int[] array = class1101_0.method_1(@class.SId);
				for (int j = 0; j < list.Count; j++)
				{
					sectorsMap.Add(array[j], list[j]);
				}
			}
		}
	}

	private void method_2(Class1106 directoryStream, SortedList<int, Class1111> sectorsMap)
	{
		List<Class1111> list = directoryStream.imethod_1(class1103_0.method_11());
		int[] array = class1101_0.method_1(directoryStream.SId);
		for (int i = 0; i < list.Count; i++)
		{
			sectorsMap.Add(array[i], list[i]);
		}
	}

	private void method_3(Class1106 shortContainer, SortedList<int, Class1111> sectorsMap)
	{
		List<Class1111> list = shortContainer.imethod_1(class1103_0.method_11());
		int[] array = class1101_0.method_1(class1109_0.RootFolder.SId);
		for (int i = 0; i < list.Count; i++)
		{
			sectorsMap.Add(array[i], list[i]);
		}
	}

	private void method_4(SortedList<int, Class1111> sectorsMap)
	{
		List<Class1111> list = class1102_0.imethod_1(class1103_0.method_11());
		int[] array = class1101_0.method_1(class1103_0.method_22());
		for (int i = 0; i < array.Length; i++)
		{
			sectorsMap.Add(array[i], list[i]);
		}
	}

	private void method_5(SortedList<int, Class1111> sectorsMap)
	{
		int[] array = class1100_0.vmethod_0();
		List<Class1111> list = class1101_0.imethod_1(class1103_0.method_11());
		for (int i = 0; i < list.Count; i++)
		{
			sectorsMap.Add(array[i], list[i]);
		}
	}

	private void method_6(Stream output, SortedList<int, Class1111> sectorsMap)
	{
		output.Write(class1100_0.method_11(), 0, class1100_0.method_11().Length);
		List<Class1111> list = class1100_0.imethod_1(class1103_0.method_11());
		int[] array = class1101_0.method_9();
		if (list.Count > 0)
		{
			Class1111 @class = list[0];
			sectorsMap.Add(array[0], list[0]);
			int num = class1103_0.method_11();
			for (int i = 1; i < list.Count; i++)
			{
				sectorsMap.Add(array[i], list[i]);
				@class = list[i];
			}
			@class.method_0()[num - 4] = 254;
			@class.method_0()[num - 3] = byte.MaxValue;
			@class.method_0()[num - 2] = byte.MaxValue;
			@class.method_0()[num - 1] = byte.MaxValue;
		}
	}

	private void method_7(Class1106 directoryStream)
	{
		int num = class1101_0.method_5(directoryStream.imethod_0(class1103_0.method_11()));
		class1103_0.method_19(num);
		directoryStream.SId = num;
	}

	private Class1106 method_8(List<Class1105> entries)
	{
		List<Class1106> list = new List<Class1106>();
		for (int i = 0; i < entries.Count; i++)
		{
			if (entries[i] is Class1106)
			{
				Class1106 @class = (Class1106)entries[i];
				if (@class.Size < class1103_0.method_20())
				{
					list.Add(@class);
				}
			}
		}
		Class1106 class2 = method_13(list, class1102_0, class1103_0);
		int sId = class1101_0.method_5(class2.imethod_0(class1103_0.method_11()));
		class1109_0.RootFolder.SId = sId;
		class1109_0.RootFolder.Size = class2.Size;
		return class2;
	}

	private void method_9()
	{
		int firstSIDOfShortSAT = class1101_0.method_5(class1102_0.imethod_0(class1103_0.method_11()));
		class1103_0.method_23(firstSIDOfShortSAT);
	}

	private void method_10()
	{
		List<Class1105> list = class1109_0.method_5();
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] is Class1106)
			{
				Class1106 @class = (Class1106)list[i];
				if (@class.Size >= class1103_0.method_20())
				{
					int sId = class1101_0.method_5(@class.imethod_0(class1103_0.method_11()));
					@class.SId = sId;
				}
				else
				{
					int sId = class1102_0.method_6(@class.imethod_0(class1103_0.method_14()));
					@class.SId = sId;
				}
			}
		}
	}

	private void method_11()
	{
		class1101_0 = new Class1101(class1103_0.method_11());
		class1100_0 = new Class1100(class1103_0.method_11());
		class1102_0 = new Class1102(class1103_0.method_14());
		class1101_0.method_8(class1100_0);
		class1100_0.method_3(class1101_0);
	}

	private void method_12()
	{
		class1103_0 = new Class1103();
		class1103_0.method_10(-2);
		class1103_0.method_21(4096);
		class1103_0.method_13(512);
		class1103_0.method_15(64);
	}

	private Class1106 method_13(List<Class1106> shortStreams, Class1102 ssat, Class1103 docheader)
	{
		Class1106 @class = new Class1106();
		SortedList<int, Class1111> sortedList = new SortedList<int, Class1111>();
		for (int i = 0; i < shortStreams.Count; i++)
		{
			Class1106 class2 = shortStreams[i];
			List<Class1111> list = class2.imethod_1(docheader.method_14());
			int[] array = ssat.method_1(class2.SId);
			for (int j = 0; j < list.Count; j++)
			{
				sortedList.Add(array[j], list[j]);
			}
		}
		foreach (Class1111 value in sortedList.Values)
		{
			@class.method_1(value.method_0());
		}
		return @class;
	}
}
