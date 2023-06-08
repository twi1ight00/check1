using System.Collections;
using ns45;

namespace Aspose.Cells.Pivot;

public class PivotFormatCondition
{
	internal PivotFormatConditionCollection pivotFormatConditionCollection_0;

	internal ArrayList arrayList_0;

	internal int int_0;

	internal PivotConditionFormatScopeType pivotConditionFormatScopeType_0;

	internal FormatConditionCollection formatConditionCollection_0;

	public PivotConditionFormatScopeType ScopeType
	{
		get
		{
			return pivotConditionFormatScopeType_0;
		}
		set
		{
			pivotConditionFormatScopeType_0 = value;
		}
	}

	public FormatConditionCollection FormatConditions => formatConditionCollection_0;

	internal PivotFormatCondition(PivotFormatConditionCollection pivotFormatConditionCollection_1)
	{
		pivotFormatConditionCollection_0 = pivotFormatConditionCollection_1;
		if (arrayList_0 == null)
		{
			arrayList_0 = new ArrayList();
		}
		Class1171 @class = new Class1171();
		@class.method_15(bool_1: false);
		Class1162 class2 = new Class1162();
		@class.arrayList_0.Add(class2);
		class2.method_2(65534);
		class2.method_6(bool_14: false);
		class2.arrayList_0 = new ArrayList();
		class2.arrayList_0.Add(0);
		arrayList_0.Add(@class);
		pivotConditionFormatScopeType_0 = PivotConditionFormatScopeType.selection;
		formatConditionCollection_0 = new FormatConditionCollection(pivotFormatConditionCollection_1.worksheet_0);
		formatConditionCollection_0.bool_1 = true;
	}

	internal PivotFormatCondition(PivotFormatConditionCollection pivotFormatConditionCollection_1, bool bool_0)
	{
		pivotFormatConditionCollection_0 = pivotFormatConditionCollection_1;
		if (arrayList_0 == null)
		{
			arrayList_0 = new ArrayList();
		}
		pivotConditionFormatScopeType_0 = PivotConditionFormatScopeType.selection;
		formatConditionCollection_0 = new FormatConditionCollection(pivotFormatConditionCollection_1.worksheet_0);
		formatConditionCollection_0.bool_1 = true;
	}
}
