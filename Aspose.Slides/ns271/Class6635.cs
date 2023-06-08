using System;
using ns218;

namespace ns271;

internal class Class6635 : Class6634
{
	private Class6642 class6642_0;

	private readonly Class6641 class6641_0;

	private readonly Class6643 class6643_0;

	internal Class6635(Class5950 reader)
	{
		class6642_0 = new Class6642(reader);
		method_2();
		class6642_0.method_4();
		class6641_0 = class6642_0.method_4();
		Class6640 @class = new Class6640(class6641_0.DataArray);
		class6643_0 = new Class6643(@class.method_0());
	}

	internal bool method_1()
	{
		return class6643_0.Ros != null;
	}

	private void method_2()
	{
		class6642_0.method_0();
		class6642_0.method_0();
		class6642_0.method_0();
		class6642_0.method_2();
	}

	internal override void Write(Class5951 writer)
	{
		throw new NotImplementedException("Not supposed to write CFF yet because no subsetting for CFF is implemented.");
	}
}
