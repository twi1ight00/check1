using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells;
using ns13;

namespace ns2;

internal class Class1301
{
	private Hashtable hashtable_0;

	internal Class1719[] class1719_0;

	private Class933 class933_0;

	private int int_0;

	[SpecialName]
	internal Hashtable method_0()
	{
		return hashtable_0;
	}

	internal Class1301()
	{
		int_0 = 0;
		hashtable_0 = new Hashtable();
		class1719_0 = new Class1719[16];
		class933_0 = new Class933();
	}

	internal int[] method_1(WorksheetCollection worksheetCollection_0)
	{
		for (int i = 0; i < class1719_0.Length; i++)
		{
			if (class1719_0[i] != null && class1719_0[i] is Class1720)
			{
				Class1720 @class = (Class1720)class1719_0[i];
				if (!@class.method_6())
				{
					method_13(@class, 0, worksheetCollection_0);
				}
			}
		}
		if (class933_0.Count == 0)
		{
			return null;
		}
		class933_0.Clear();
		int num = 0;
		int num2 = 0;
		int[] array = new int[class1719_0.Length];
		for (int j = 0; j < class1719_0.Length; j++)
		{
			if (class1719_0[j] == null)
			{
				num++;
			}
			else if (num != 0)
			{
				num2 = (array[j] = j - num);
				class1719_0[j].int_1 = num2;
				class1719_0[num2] = class1719_0[j];
				class1719_0[j] = null;
			}
			else
			{
				array[j] = j;
			}
		}
		if (num == 0)
		{
			return null;
		}
		return array;
	}

	[SpecialName]
	internal uint method_2()
	{
		uint num = 0u;
		for (int i = 0; i < class1719_0.Length; i++)
		{
			if (class1719_0[i] != null)
			{
				num += (uint)class1719_0[i].int_0;
			}
		}
		return num;
	}

	[SpecialName]
	internal int method_3()
	{
		return int_0;
	}

	private void method_4(int int_1)
	{
		if (int_0 + int_1 >= class1719_0.Length)
		{
			Class1719[] array = new Class1719[class1719_0.Length * 2];
			for (int i = 0; i < class1719_0.Length; i++)
			{
				array[i] = class1719_0[i];
			}
			class1719_0 = array;
		}
	}

	internal void method_5(Cell cell_0, int int_1)
	{
		class1719_0[int_1].int_0++;
		cell_0.method_64(class1719_0[int_1]);
	}

	internal void method_6(Class1719 class1719_1, int int_1)
	{
		if (class1719_0[int_1] != null)
		{
			class1719_0[int_1].int_0++;
			return;
		}
		method_4(1);
		hashtable_0[class1719_1.string_0] = class1719_1;
		class1719_0[int_1] = class1719_1;
		class1719_1.int_1 = int_1;
		int_0++;
	}

	internal void method_7(string string_0, int int_1, byte[] byte_0)
	{
		method_4(1);
		Class1719 @class = new Class1720(string_0, byte_0, 0);
		class1719_0[int_1] = @class;
		@class.int_1 = int_1;
		int_0++;
	}

	internal void method_8(string string_0, Cell cell_0)
	{
		cell_0.method_64(method_9(string_0));
	}

	internal Class1719 method_9(string string_0)
	{
		Class1719 @class = (Class1719)hashtable_0[string_0];
		if (@class != null)
		{
			@class.int_0++;
		}
		else
		{
			@class = new Class1719(string_0, 1);
			hashtable_0[string_0] = @class;
			if (class933_0.Count != 0)
			{
				int num = class933_0.method_0();
				class1719_0[num] = @class;
				@class.int_1 = num;
			}
			else if (int_0 < class1719_0.Length)
			{
				class1719_0[int_0] = @class;
				@class.int_1 = int_0;
			}
			else
			{
				method_4(1);
				class1719_0[int_0] = @class;
				@class.int_1 = int_0;
			}
			int_0++;
		}
		return @class;
	}

	internal void method_10(object object_0, Cell cell_0)
	{
		if (object_0 == null)
		{
			return;
		}
		Class1719 @class = (Class1719)object_0;
		@class.int_0--;
		if (@class.int_0 <= 0)
		{
			class1719_0[@class.int_1] = null;
			if (@class.method_0())
			{
				hashtable_0.Remove(@class.string_0);
			}
			int_0--;
			class933_0.Add(@class.int_1);
		}
	}

	internal void Clear()
	{
	}

	internal void method_11(Class1720 class1720_0)
	{
		if (class933_0.Count == 0)
		{
			method_4(1);
			class1719_0[int_0] = class1720_0;
			class1720_0.int_1 = int_0++;
		}
		else
		{
			int num = class933_0.method_0();
			class1719_0[num] = class1720_0;
			class1720_0.int_1 = num;
			int_0++;
		}
	}

	internal Class1719 method_12(string string_0, byte[] byte_0)
	{
		Class1719 @class = null;
		int num = 0;
		while (true)
		{
			if (num < class1719_0.Length)
			{
				@class = class1719_0[num];
				if (@class != null && @class.method_1() && ((Class1720)@class).method_10(string_0, byte_0))
				{
					break;
				}
				num++;
				continue;
			}
			@class = new Class1720(string_0, byte_0, 1);
			if (class933_0.Count == 0)
			{
				method_4(1);
				class1719_0[int_0] = @class;
				@class.int_1 = int_0++;
			}
			else
			{
				int num2 = class933_0.method_0();
				class1719_0[num2] = @class;
				@class.int_1 = num2;
				int_0++;
			}
			return @class;
		}
		@class.int_0++;
		return @class;
	}

	internal int method_13(Class1720 class1720_0, int int_1, WorksheetCollection worksheetCollection_0)
	{
		Class1131.smethod_1(class1720_0.method_4(), class1720_0.string_0.Length, worksheetCollection_0.method_54(int_1), bool_0: false);
		FontSetting[] array = new FontSetting[class1720_0.method_4().Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (FontSetting)class1720_0.method_4()[i];
		}
		string string_ = class1720_0.string_0;
		byte[] array2 = Class1131.smethod_0(int_1, string_, array, worksheetCollection_0);
		if (array2 == null)
		{
			return -1;
		}
		Class1719 @class = null;
		int num = 0;
		while (true)
		{
			if (num < class1719_0.Length)
			{
				@class = class1719_0[num];
				if (@class != null && @class.method_1() && ((Class1720)@class).method_10(string_, array2))
				{
					break;
				}
				num++;
				continue;
			}
			class1720_0.method_3(array2);
			class1720_0.method_5(null);
			return class1720_0.int_1;
		}
		@class.int_0++;
		int int_2 = class1720_0.int_1;
		class933_0.Add(int_2);
		class1719_0[int_2] = null;
		int_0--;
		return num;
	}

	internal string[] GetSmartMarkers()
	{
		SortedList sortedList = new SortedList();
		for (int i = 0; i < class1719_0.Length; i++)
		{
			if (class1719_0[i] != null && class1719_0[i].string_0.StartsWith("&="))
			{
				sortedList[class1719_0[i].string_0] = true;
			}
		}
		string[] array = new string[sortedList.Count];
		sortedList.Keys.CopyTo(array, 0);
		return array;
	}
}
