using System;
using System.Collections;
using Aspose.Cells;

namespace ns27;

internal class Class593 : Class538
{
	internal Class593()
	{
		method_2(4176);
	}

	internal int method_4(int int_0, int int_1, ArrayList arrayList_0)
	{
		arrayList_0.Sort(new Class1189());
		ArrayList arrayList = new ArrayList();
		arrayList_0.Sort(new Class1189());
		int num = 0;
		Struct85 @struct;
		foreach (FontSetting item in arrayList_0)
		{
			if (item.StartIndex < num)
			{
				if (item.StartIndex + item.Length <= num)
				{
					continue;
				}
				@struct = default(Struct85);
				@struct.int_0 = num;
				@struct.int_1 = int_1;
				arrayList.Add(@struct);
			}
			else
			{
				if (item.StartIndex > num)
				{
					@struct = default(Struct85);
					@struct.int_0 = num;
					@struct.int_1 = int_1;
					arrayList.Add(@struct);
				}
				@struct = default(Struct85);
				@struct.int_0 = item.StartIndex;
				if (item.method_2() == null)
				{
					@struct.int_1 = int_1;
				}
				else
				{
					@struct.int_1 = item.Font.method_21();
				}
				arrayList.Add(@struct);
			}
			num = item.StartIndex + item.Length;
		}
		if (num < int_0)
		{
			@struct = default(Struct85);
			@struct.int_0 = num;
			@struct.int_1 = int_1;
			arrayList.Add(@struct);
		}
		@struct = default(Struct85);
		@struct.int_0 = int_0;
		@struct.int_1 = int_1;
		arrayList.Add(@struct);
		int count = arrayList.Count;
		if (count == 2)
		{
			return ((Struct85)arrayList[0]).int_1;
		}
		method_0((short)(2 + 4 * count));
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes((short)count), 0, byte_0, 0, 2);
		int num2 = 2;
		foreach (Struct85 item2 in arrayList)
		{
			Array.Copy(BitConverter.GetBytes((short)item2.int_0), 0, byte_0, num2, 2);
			Array.Copy(BitConverter.GetBytes((short)item2.int_1), 0, byte_0, num2 + 2, 2);
			num2 += 4;
		}
		return -1;
	}
}
