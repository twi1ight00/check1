using System.Collections;
using Aspose.Cells;
using ns52;

namespace ns21;

internal class Class1716 : ArrayList
{
	public new Class1715 this[int int_0] => (Class1715)base[int_0];

	internal static Class1715 GetPicture(Class1696 class1696_0)
	{
		Class1715 @class = new Class1715();
		@class.Type = class1696_0.ImageFormat;
		@class.Data = class1696_0.ImageData;
		@class.bool_0 = class1696_0.method_11() == 4;
		return @class;
	}

	internal void method_0(Class1697 class1697_0)
	{
		foreach (Class1696 item in class1697_0)
		{
			Class1715 picture = GetPicture(item);
			Add(picture);
		}
	}

	internal void method_1(WorksheetCollection worksheetCollection_0)
	{
		if (worksheetCollection_0.method_85() != null && worksheetCollection_0.method_85().method_1() != null && worksheetCollection_0.method_85().method_0().Count != 0)
		{
			Class1697 class1697_ = worksheetCollection_0.method_84().method_0();
			method_0(class1697_);
		}
	}

	internal void method_2(WorksheetCollection worksheetCollection_0)
	{
		if (worksheetCollection_0.method_88() != null && worksheetCollection_0.method_88().method_1() != null && worksheetCollection_0.method_88().method_0().Count != 0)
		{
			Class1697 class1697_ = worksheetCollection_0.method_87().method_0();
			method_0(class1697_);
		}
	}
}
