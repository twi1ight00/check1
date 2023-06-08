using System.Runtime.CompilerServices;
using Aspose.Cells;
using ns12;
using ns38;
using ns51;

namespace ns2;

internal class Class1658
{
	private Workbook workbook_0;

	private Class1264 class1264_0;

	private Class1277 class1277_0;

	internal Class1658(Workbook workbook_1)
	{
		workbook_0 = workbook_1;
		if (workbook_0.method_24())
		{
			class1277_0 = new Class1277(workbook_0);
		}
		else
		{
			class1264_0 = new Class1264(workbook_0);
		}
	}

	[SpecialName]
	internal void method_0(Enum47 enum47_0)
	{
		if (workbook_0.method_24())
		{
			class1277_0.enum47_0 = enum47_0;
		}
		else
		{
			class1264_0.enum47_0 = enum47_0;
		}
	}

	internal void Clear()
	{
		if (workbook_0.method_24())
		{
			class1277_0.Clear();
		}
		else
		{
			class1264_0.Clear();
		}
	}

	internal void method_1(bool bool_0)
	{
		if (workbook_0.method_24())
		{
			class1277_0.bool_0 = bool_0;
		}
	}

	internal object method_2(Class1661 class1661_0, Cell cell_0)
	{
		if (workbook_0.method_24())
		{
			return class1277_0.method_5(class1661_0, cell_0);
		}
		return class1264_0.method_4(class1661_0, cell_0);
	}

	internal object method_3(Cell cell_0)
	{
		if (workbook_0.method_24())
		{
			return class1277_0.method_211(cell_0);
		}
		return class1264_0.method_207(cell_0);
	}

	internal void method_4()
	{
		if (!workbook_0.method_24())
		{
			class1264_0.method_209();
		}
	}

	internal void method_5(bool bool_0, ICustomFunction icustomFunction_0)
	{
		if (workbook_0.method_24())
		{
			class1277_0.method_0(bool_0, icustomFunction_0);
		}
		else
		{
			class1264_0.method_0(bool_0, icustomFunction_0);
		}
	}
}
