using System;
using System.Collections;
using System.Runtime.CompilerServices;
using ns2;
using ns59;

namespace ns45;

internal class Class1144
{
	internal ArrayList arrayList_0;

	internal bool[] bool_0;

	internal bool[] bool_1;

	internal Class1141 class1141_0;

	internal Class1144(Class1141 class1141_1)
	{
		class1141_0 = class1141_1;
	}

	internal Class1144(Class1141 class1141_1, int int_0, int int_1)
	{
		class1141_0 = class1141_1;
		arrayList_0 = new ArrayList(int_0);
		bool_0 = new bool[int_1];
		for (int i = 0; i < int_0; i++)
		{
			arrayList_0.Add(new object[int_1]);
		}
	}

	internal void method_0()
	{
		int num = Math.Min(class1141_0.int_3, class1141_0.int_4);
		arrayList_0 = new ArrayList(num);
		for (int i = 0; i < num; i++)
		{
			arrayList_0.Add(new object[class1141_0.int_1]);
		}
		bool_0 = new bool[class1141_0.int_1];
		bool_1 = new bool[class1141_0.int_1];
		for (int j = 0; j < class1141_0.arrayList_0.Count; j++)
		{
			Class1161 @class = (Class1161)class1141_0.arrayList_0[j];
			if (!@class.method_18() && j < bool_0.Length)
			{
				bool_0[j] = @class.method_2();
				bool_1[j] = @class.method_4();
			}
		}
	}

	internal void method_1(Class1161 class1161_0)
	{
		int[] array = new int[class1141_0.int_3];
		int index = class1161_0.Index;
		if (bool_0[index])
		{
			return;
		}
		ArrayList arrayList = new ArrayList();
		Hashtable hashtable = new Hashtable();
		int num = -1;
		int num2 = 0;
		bool isString = false;
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			object obj = ((object[])arrayList_0[i])[index];
			if (obj == null)
			{
				if (num == -1)
				{
					num = num2++;
					Class1158 @class = new Class1158();
					@class.object_0 = null;
					arrayList.Add(@class);
				}
				if (i < array.Length)
				{
					array[i] = num;
				}
				continue;
			}
			obj = Class1141.smethod_0(obj, class1161_0, out isString);
			if (obj == null)
			{
				if (num == -1)
				{
					num = num2++;
					Class1158 class2 = new Class1158();
					class2.object_0 = null;
					arrayList.Add(class2);
				}
				if (i < array.Length)
				{
					array[i] = num;
				}
				continue;
			}
			object obj2 = (isString ? hashtable[((string)obj).ToUpper()] : hashtable[obj]);
			if (obj2 == null)
			{
				if (i < array.Length)
				{
					array[i] = num2;
				}
				if (isString)
				{
					hashtable.Add(((string)obj).ToUpper(), num2++);
				}
				else
				{
					hashtable.Add(obj, num2++);
				}
				Class1158 class3 = new Class1158();
				class3.object_0 = obj;
				arrayList.Add(class3);
			}
			else if (i < array.Length)
			{
				array[i] = (int)obj2;
			}
		}
		if (arrayList.Count < 32767)
		{
			class1161_0.arrayList_0 = arrayList;
			class1161_0.method_3(bool_2: true);
			if (array.Length <= 0)
			{
				return;
			}
			bool_0[index] = true;
			for (int j = 0; j < arrayList_0.Count; j++)
			{
				if (j < array.Length)
				{
					((object[])arrayList_0[j])[index] = array[j];
				}
			}
		}
		else
		{
			class1161_0.method_28(bool_2: true);
			class1161_0.arrayList_0 = null;
		}
	}

	[SpecialName]
	internal int method_2()
	{
		int num = 0;
		for (int i = 0; i < bool_0.Length; i++)
		{
			if (bool_0[i])
			{
				num++;
			}
		}
		return num;
	}

	internal void Write(Class1725 class1725_0)
	{
		int num = method_2();
		bool flag;
		if (!(flag = num >= 256))
		{
			for (int i = 0; i < class1141_0.arrayList_0.Count; i++)
			{
				Class1161 @class = (Class1161)class1141_0.arrayList_0[i];
				if (@class.arrayList_0 != null && @class.arrayList_0.Count >= 256 && @class.sxRng_0 == null)
				{
					flag = true;
					break;
				}
			}
		}
		byte[] array = null;
		if (flag)
		{
			array = new byte[4 + num * 2];
			Array.Copy(BitConverter.GetBytes((ushort)(num * 2)), 0, array, 2, 2);
		}
		else
		{
			array = new byte[4 + num];
			array[2] = (byte)num;
		}
		array[0] = 200;
		byte[] array2 = null;
		int num2 = 0;
		int num3 = 0;
		for (int j = 0; j < arrayList_0.Count; j++)
		{
			object[] array3 = (object[])arrayList_0[j];
			num3 = 0;
			num2 = 0;
			for (int k = 0; k < array3.Length; k++)
			{
				if (bool_0[k])
				{
					if (array3[k] != null)
					{
						if (flag)
						{
							Array.Copy(BitConverter.GetBytes((ushort)(int)array3[k]), 0, array, 4 + num2 * 2, 2);
						}
						else
						{
							array[4 + num2] = (byte)(int)array3[k];
						}
						num2++;
					}
					continue;
				}
				if (array3[k] == null)
				{
					num3 += 4;
					continue;
				}
				Type type = array3[k].GetType();
				switch (Type.GetTypeCode(type))
				{
				case TypeCode.String:
					num3 += 6 + Class1677.smethod_29((string)array3[k]);
					break;
				case TypeCode.Int32:
				case TypeCode.Double:
				case TypeCode.DateTime:
					num3 += 12;
					break;
				case TypeCode.Boolean:
					num3 += 6;
					break;
				}
			}
			class1725_0.method_3(array);
			if (array2 == null || array2.Length < num3)
			{
				array2 = new byte[num3];
			}
			num2 = 0;
			for (int l = 0; l < array3.Length; l++)
			{
				if (bool_0[l])
				{
					continue;
				}
				if (array3[l] == null)
				{
					num2 += Class1161.smethod_1(array2, num2);
					continue;
				}
				Type type2 = array3[l].GetType();
				switch (Type.GetTypeCode(type2))
				{
				case TypeCode.Double:
					num2 += Class1161.smethod_3(array2, num2, (double)array3[l]);
					break;
				case TypeCode.DateTime:
					num2 += Class1161.smethod_6(array2, num2, (DateTime)array3[l]);
					break;
				case TypeCode.String:
					num2 += Class1161.smethod_2(array2, num2, (string)array3[l]);
					break;
				case TypeCode.Int32:
					num2 += Class1161.smethod_3(array2, num2, (int)array3[l]);
					break;
				case TypeCode.Boolean:
					num2 += Class1161.smethod_5(array2, num2, (bool)array3[l]);
					break;
				}
			}
			class1725_0.method_1(array2, num3);
		}
	}
}
