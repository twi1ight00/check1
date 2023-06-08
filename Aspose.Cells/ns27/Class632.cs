using System.Collections;
using Aspose.Cells;
using ns59;

namespace ns27;

internal class Class632 : Class538
{
	internal ArrayList arrayList_0;

	internal Class632(FileFormatType fileFormatType_1)
	{
		fileFormatType_0 = fileFormatType_1;
		method_2(23);
		method_0(2);
		arrayList_0 = new ArrayList();
	}

	internal override void vmethod_0(Class1725 class1725_0)
	{
		method_0((short)(2 + arrayList_0.Count * 2));
		if (arrayList_0.Count < 4107)
		{
			class1725_0.method_7(method_1());
			class1725_0.method_7(base.Length);
			class1725_0.method_6((ushort)(arrayList_0.Count / 3));
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				class1725_0.method_6((ushort)arrayList_0[i]);
			}
			return;
		}
		class1725_0.method_7(method_1());
		class1725_0.method_7(8210);
		class1725_0.method_6((ushort)(arrayList_0.Count / 3));
		for (int j = 0; j < 4104; j++)
		{
			class1725_0.method_6((ushort)arrayList_0[j]);
		}
		int num = 4104;
		int num2 = arrayList_0.Count - 4104;
		while (true)
		{
			class1725_0.method_8(60);
			if (num2 <= 4110)
			{
				break;
			}
			class1725_0.method_7(8220);
			for (int k = 0; k < 4110; k++)
			{
				class1725_0.method_6((ushort)arrayList_0[num + k]);
			}
			num += 4110;
			num2 = arrayList_0.Count - num;
		}
		class1725_0.method_7((short)(num2 * 2));
		for (int l = 0; l < num2; l++)
		{
			class1725_0.method_6((ushort)arrayList_0[num + l]);
		}
	}
}
