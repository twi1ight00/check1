using System;
using Aspose.Cells;

namespace ns2;

internal class Class427
{
	internal static object GetDoubleValue(object object_0, bool bool_0)
	{
		if (object_0 is double)
		{
			return (double)object_0;
		}
		if (object_0 is int)
		{
			return (double)(int)object_0;
		}
		if (object_0 is DateTime)
		{
			return CellsHelper.GetDoubleFromDateTime((DateTime)object_0, bool_0);
		}
		return null;
	}
}
