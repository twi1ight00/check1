using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells;
using Aspose.Cells.Drawing;

namespace ns21;

internal class Class1113
{
	private object object_0;

	private Bevel bevel_0;

	private Bevel bevel_1;

	private PresetMaterialType presetMaterialType_0;

	private CellsColor cellsColor_0;

	private CellsColor cellsColor_1;

	internal int int_0;

	internal int int_1;

	private ArrayList arrayList_0;

	internal int int_2;

	internal Bevel TopBevel
	{
		get
		{
			if (bevel_1 == null)
			{
				bevel_1 = new Bevel();
			}
			return bevel_1;
		}
	}

	internal Class1113(object object_1)
	{
		object_0 = object_1;
		presetMaterialType_0 = PresetMaterialType.WarmMatte;
	}

	[SpecialName]
	internal Worksheet method_0()
	{
		if (object_0 is Area)
		{
			return ((Area)object_0).Chart.Charts.method_0();
		}
		if (object_0 is Shape)
		{
			Shape shape = (Shape)object_0;
			return shape.method_26();
		}
		return null;
	}

	internal Bevel method_1()
	{
		return bevel_0;
	}

	[SpecialName]
	public Bevel method_2()
	{
		if (bevel_0 == null)
		{
			bevel_0 = new Bevel();
		}
		return bevel_0;
	}

	internal Bevel method_3()
	{
		return bevel_1;
	}

	[SpecialName]
	public PresetMaterialType method_4()
	{
		return presetMaterialType_0;
	}

	[SpecialName]
	public void method_5(PresetMaterialType presetMaterialType_1)
	{
		presetMaterialType_0 = presetMaterialType_1;
	}

	internal CellsColor method_6()
	{
		return cellsColor_0;
	}

	internal void method_7(CellsColor cellsColor_2)
	{
		cellsColor_0 = cellsColor_2;
	}

	internal CellsColor method_8()
	{
		return cellsColor_1;
	}

	internal void method_9(CellsColor cellsColor_2)
	{
		cellsColor_1 = cellsColor_2;
	}

	internal void Copy(Class1113 class1113_0)
	{
		int_2 = class1113_0.int_2;
		if (class1113_0.arrayList_0 != null)
		{
			arrayList_0 = new ArrayList();
			arrayList_0.AddRange(class1113_0.arrayList_0);
		}
		int_0 = class1113_0.int_0;
		int_1 = class1113_0.int_1;
		if (class1113_0.cellsColor_0 != null)
		{
			cellsColor_0 = new CellsColor(method_0().method_2().Workbook);
			cellsColor_0.internalColor_0.method_19(class1113_0.cellsColor_0.internalColor_0);
		}
		if (class1113_0.cellsColor_1 != null)
		{
			cellsColor_1 = new CellsColor(method_0().method_2().Workbook);
			cellsColor_1.internalColor_0.method_19(class1113_0.cellsColor_1.internalColor_0);
		}
		presetMaterialType_0 = class1113_0.presetMaterialType_0;
		if (class1113_0.bevel_1 != null)
		{
			bevel_1 = new Bevel();
			bevel_1.Copy(class1113_0.bevel_1);
		}
		if (class1113_0.bevel_0 != null)
		{
			bevel_0 = new Bevel();
			bevel_0.Copy(class1113_0.bevel_0);
		}
	}
}
