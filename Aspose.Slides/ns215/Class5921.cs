using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.XfaConverter.Elements;
using ns216;

namespace ns215;

internal class Class5921 : Class5916
{
	private struct Struct189
	{
		internal int int_0;

		internal float float_0;

		internal int int_1;
	}

	private float[] float_2;

	public Class5921(Interface249 nativeObj)
		: base(nativeObj)
	{
		if (nativeObj is Class5848)
		{
			float_2 = ((Class5848)nativeObj).ColumnWidths;
		}
	}

	private float method_7(ref int column, int colSpan)
	{
		if (float_2 != null && float_2.Length - 1 >= column)
		{
			float num = 0f;
			if (colSpan == -1)
			{
				colSpan = float_2.Length - column;
			}
			while (column < float_2.Length && colSpan-- > 0)
			{
				num += float_2[column];
				column++;
			}
			return num;
		}
		return -1f;
	}

	internal override void vmethod_3()
	{
		List<Class5916> list = new List<Class5916>();
		List<List<Struct189>> list2 = new List<List<Struct189>>();
		int num = 0;
		float val = 0f;
		bool flag = false;
		List<float> list3 = new List<float>();
		foreach (Class5914 item2 in arrayList_0)
		{
			if (!(item2.NativeObj is Interface249 @interface) || @interface.LayoutType != XfaEnums.Enum706.const_3)
			{
				return;
			}
			if (item2 is Class5916 class2 && class2.Type == XfaEnums.Enum706.const_3)
			{
				float num2 = 0f;
				foreach (Class5914 item3 in class2.arrayList_0)
				{
					if (item2 is Class5916)
					{
						((Class5916)item2).vmethod_3();
					}
					num2 = Math.Max(item3.Size.Height, num2);
				}
				list3.Add(num2);
				List<Struct189> list4 = new List<Struct189>();
				int column = 0;
				float num3 = 0f;
				foreach (Class5914 item4 in class2.arrayList_0)
				{
					if (item4 is Class5916)
					{
						((Class5916)item4).vmethod_3();
					}
					Struct189 item = default(Struct189);
					item.int_0 = item4.NativeObj.ColSpan;
					if (!flag && item.int_0 != 0 && item.int_0 != 1)
					{
						flag = true;
					}
					item.float_0 = method_7(ref column, (item.int_0 == 0) ? 1 : item.int_0);
					num3 += item.float_0;
					item.int_1 = class2.arrayList_0.IndexOf(item4);
					list4.Add(item);
				}
				val = Math.Max(val, num3);
				float_1 += num2;
				list.Add(class2);
				list2.Add(list4);
				num = Math.Max(num, list4.Count);
				continue;
			}
			throw new ArgumentException();
		}
		if (list.Count == 0)
		{
			return;
		}
		if (flag)
		{
			float_0 = val;
		}
		float[] array = new float[list2.Count];
		for (int i = 0; i < num; i++)
		{
			float num4 = 0f;
			if (!flag)
			{
				foreach (List<Struct189> item5 in list2)
				{
					if (item5.Count > 0 && i < item5.Count)
					{
						Struct189 @struct = item5[i];
						if (@struct.int_0 == 1)
						{
							num4 = Math.Max(@struct.float_0, num4);
						}
					}
				}
				float_0 += num4;
			}
			float num5 = 0f;
			for (int j = 0; j < list2.Count; j++)
			{
				List<Struct189> list5 = list2[j];
				if (list5.Count > 0 && i < list5.Count)
				{
					Struct189 struct2 = list5[i];
					Class5914 class5 = list[j].arrayList_0[struct2.int_1] as Class5914;
					if (!flag)
					{
						struct2.float_0 = num4;
					}
					class5.Size = new SizeF(struct2.float_0, class5.Size.Height);
					class5.NativeObj.imethod_3(class5.Size);
					class5.Pos = new PointF(array[j], num5);
					array[j] += struct2.float_0;
				}
				num5 += list3[j];
			}
		}
		method_0();
	}
}
