using System;
using System.Runtime.CompilerServices;
using Aspose.Cells;
using Aspose.Cells.Properties;

namespace ns30;

internal class Class1634
{
	internal Enum218 enum218_0;

	internal int int_0;

	internal string string_0;

	internal PropertyType propertyType_0;

	internal Class1634(Enum218 enum218_1, int int_1, string string_1, PropertyType propertyType_1)
	{
		enum218_0 = enum218_1;
		int_0 = int_1;
		string_0 = string_1;
		propertyType_0 = propertyType_1;
	}

	[SpecialName]
	internal object method_0()
	{
		return propertyType_0 switch
		{
			PropertyType.Boolean => false, 
			PropertyType.DateTime => DateTime.MinValue, 
			PropertyType.Double => 0.0, 
			PropertyType.Number => 0, 
			PropertyType.String => string.Empty, 
			PropertyType.Blob => null, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Unknown property type."), 
		};
	}
}
