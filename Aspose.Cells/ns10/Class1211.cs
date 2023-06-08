using System.Collections;
using System.IO;
using Aspose.Cells;
using ns16;
using ns2;
using ns9;

namespace ns10;

internal class Class1211
{
	private Class1718 class1718_0;

	private MemoryStream memoryStream_0;

	private Class1229 class1229_0;

	internal Class1211(Class1229 class1229_1, Class1718 class1718_1)
	{
		class1229_0 = class1229_1;
		class1718_0 = class1718_1;
		memoryStream_0 = new MemoryStream();
	}

	internal void Write(string string_0, Stream6 stream6_0)
	{
		Write();
		Class1229.smethod_1(string_0, memoryStream_0, stream6_0);
		memoryStream_0.Close();
		memoryStream_0 = null;
	}

	private void Write()
	{
		Class335 @class = new Class335();
		@class.method_6(class1718_0);
		@class.method_0(memoryStream_0);
		if (class1718_0.method_4() != null)
		{
			Class385 class2 = new Class385(class1718_0);
			class2.method_0(memoryStream_0);
		}
		method_0();
		method_1();
		Class316 class3 = new Class316(588);
		class3.method_0(memoryStream_0);
	}

	private void method_0()
	{
		ArrayList arrayList = class1718_0.method_0();
		if (arrayList.Count == 0)
		{
			return;
		}
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class1653 @class = (Class1653)arrayList[i];
			Class384 class2 = new Class384(@class);
			class2.method_0(memoryStream_0);
			if (@class.method_12() != null)
			{
				Class383 class3 = new Class383(@class);
				class3.method_0(memoryStream_0);
			}
			Class382 class4 = new Class382(class1718_0, @class);
			class4.method_0(memoryStream_0);
			Class316 class5 = new Class316(587);
			class5.method_0(memoryStream_0);
		}
	}

	private void method_1()
	{
		string[] array = class1718_0.method_4();
		if (array == null || array.Length == 0)
		{
			return;
		}
		int num = array.Length;
		bool flag = false;
		for (int i = 0; i < num; i++)
		{
			Class1373 @class = class1718_0.method_11(array[i]);
			if (@class != null)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return;
		}
		for (int j = 0; j < num; j++)
		{
			Class1373 class2 = class1718_0.method_11(array[j]);
			if (class2 == null)
			{
				continue;
			}
			bool bool_ = false;
			object obj = class2.method_0().method_0(Enum129.const_2);
			if (obj != null && ((string)obj).Equals("true"))
			{
				bool_ = true;
			}
			Class363 class3 = new Class363(j, bool_);
			class3.method_0(memoryStream_0);
			if (class2.method_1())
			{
				ArrayList arrayList_ = class2.arrayList_0;
				int count = arrayList_.Count;
				for (int k = 0; k < count; k++)
				{
					Class1117 class4 = (Class1117)arrayList_[k];
					Class316 class5 = new Class316(366, class4.Index);
					class5.method_0(memoryStream_0);
					if (class4.method_3())
					{
						ArrayList arrayList = class4.method_7();
						int count2 = arrayList.Count;
						for (int l = 0; l < count2; l++)
						{
							Class1116 class1116_ = (Class1116)arrayList[l];
							method_2(class1116_);
						}
					}
				}
			}
			Class316 class6 = new Class316(364);
			class6.method_0(memoryStream_0);
		}
	}

	private void method_2(Class1116 class1116_0)
	{
		switch (class1116_0.Type)
		{
		case CellValueType.IsBool:
		{
			Class359 class4 = new Class359();
			class4.method_6(class1116_0);
			class4.method_0(memoryStream_0);
			break;
		}
		case CellValueType.IsError:
		{
			Class360 class3 = new Class360();
			class3.method_6(class1116_0);
			class3.method_0(memoryStream_0);
			break;
		}
		case CellValueType.IsNumeric:
		{
			Class361 class2 = new Class361();
			class2.method_6(class1116_0);
			class2.method_0(memoryStream_0);
			break;
		}
		case CellValueType.IsString:
		{
			Class362 @class = new Class362();
			@class.method_6(class1116_0);
			@class.method_0(memoryStream_0);
			break;
		}
		case CellValueType.IsDateTime:
		case CellValueType.IsNull:
			break;
		}
	}
}
