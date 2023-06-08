using System;
using Aspose.Cells.Pivot;
using ns2;
using ns27;
using ns45;

namespace ns28;

internal class Class575 : Class538
{
	internal Class575(Class1176 class1176_0)
	{
		method_2(2064);
		method_0(16);
		string string_ = class1176_0.string_0;
		if (string_ != null)
		{
			method_0((short)(base.Length + (short)Class1677.smethod_29(string_)));
		}
		byte_0 = new byte[base.Length];
		byte_0[0] = 16;
		byte_0[1] = 8;
		int int_ = class1176_0.int_0;
		Array.Copy(BitConverter.GetBytes(int_), 0, byte_0, 8, 4);
		Array.Copy(BitConverter.GetBytes(smethod_0(class1176_0.AutoFormatType)), 0, byte_0, 12, 2);
		if (string_ != null)
		{
			Array.Copy(BitConverter.GetBytes(string_.Length), 0, byte_0, 14, 2);
			Class937.smethod_4(byte_0, 16, string_);
		}
	}

	private static int smethod_0(PivotTableAutoFormatType pivotTableAutoFormatType_0)
	{
		return pivotTableAutoFormatType_0 switch
		{
			PivotTableAutoFormatType.None => 4117, 
			PivotTableAutoFormatType.Classic => 1, 
			PivotTableAutoFormatType.Report1 => 4096, 
			PivotTableAutoFormatType.Report2 => 4097, 
			PivotTableAutoFormatType.Report3 => 4098, 
			PivotTableAutoFormatType.Report4 => 4099, 
			PivotTableAutoFormatType.Report5 => 4100, 
			PivotTableAutoFormatType.Report6 => 4101, 
			PivotTableAutoFormatType.Report7 => 4102, 
			PivotTableAutoFormatType.Report8 => 4103, 
			PivotTableAutoFormatType.Report9 => 4104, 
			PivotTableAutoFormatType.Report10 => 4105, 
			PivotTableAutoFormatType.Table1 => 4106, 
			PivotTableAutoFormatType.Table2 => 4107, 
			PivotTableAutoFormatType.Table3 => 4108, 
			PivotTableAutoFormatType.Table4 => 4109, 
			PivotTableAutoFormatType.Table5 => 4110, 
			PivotTableAutoFormatType.Table6 => 4111, 
			PivotTableAutoFormatType.Table7 => 4112, 
			PivotTableAutoFormatType.Table8 => 4113, 
			PivotTableAutoFormatType.Table9 => 4114, 
			PivotTableAutoFormatType.Table10 => 4115, 
			_ => 1, 
		};
	}
}
