using System;
using Aspose.Cells;
using ns2;

namespace ns14;

internal class Class517
{
	private OperatorType operatorType_0;

	private double double_0;

	internal Class517(OperatorType operatorType_1, double double_1)
	{
		operatorType_0 = operatorType_1;
		double_0 = double_1;
	}

	internal bool method_0(double double_1)
	{
		return operatorType_0 switch
		{
			OperatorType.Equal => double_1 == double_0, 
			OperatorType.GreaterThan => double_1 > double_0, 
			OperatorType.GreaterOrEqual => double_1 >= double_0, 
			OperatorType.LessThan => double_1 < double_0, 
			OperatorType.LessOrEqual => double_1 <= double_0, 
			OperatorType.NotEqual => double_1 != double_0, 
			_ => false, 
		};
	}

	internal bool method_1(TypeCode typeCode_0, object object_0, bool bool_0)
	{
		switch (typeCode_0)
		{
		case TypeCode.Double:
			return method_0((double)object_0);
		case TypeCode.DateTime:
			return method_0(Class428.GetDoubleFromDateTime((DateTime)object_0, bool_0));
		default:
			return false;
		case TypeCode.Int32:
			return method_0((int)object_0);
		case TypeCode.Boolean:
		case TypeCode.String:
			return true;
		}
	}
}
