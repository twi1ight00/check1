using Aspose.Cells.Pivot;

namespace ns45;

internal class Class1152
{
	internal static PivotTableAutoFormatType smethod_0(ushort ushort_0)
	{
		return ushort_0 switch
		{
			4096 => PivotTableAutoFormatType.Report1, 
			4097 => PivotTableAutoFormatType.Report2, 
			4098 => PivotTableAutoFormatType.Report3, 
			4099 => PivotTableAutoFormatType.Report4, 
			4100 => PivotTableAutoFormatType.Report5, 
			4101 => PivotTableAutoFormatType.Report6, 
			4102 => PivotTableAutoFormatType.Report7, 
			4103 => PivotTableAutoFormatType.Report8, 
			4104 => PivotTableAutoFormatType.Report9, 
			4105 => PivotTableAutoFormatType.Report10, 
			4106 => PivotTableAutoFormatType.Table1, 
			4107 => PivotTableAutoFormatType.Table2, 
			4108 => PivotTableAutoFormatType.Table3, 
			4109 => PivotTableAutoFormatType.Table4, 
			4110 => PivotTableAutoFormatType.Table5, 
			4111 => PivotTableAutoFormatType.Table6, 
			4112 => PivotTableAutoFormatType.Table7, 
			4113 => PivotTableAutoFormatType.Table8, 
			4114 => PivotTableAutoFormatType.Table9, 
			4115 => PivotTableAutoFormatType.Table10, 
			4116 => PivotTableAutoFormatType.Classic, 
			4117 => PivotTableAutoFormatType.None, 
			_ => PivotTableAutoFormatType.Classic, 
		};
	}
}
