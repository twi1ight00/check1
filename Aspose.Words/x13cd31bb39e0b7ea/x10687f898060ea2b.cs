using System;
using System.Collections;
using Aspose.Words.Drawing;
using x38d3ef1c1d247e82;
using x5f3520a4b31ea90f;

namespace x13cd31bb39e0b7ea;

internal class x10687f898060ea2b
{
	private readonly x94c83b1ca7961561 x2f36d530d72e2c86 = new x94c83b1ca7961561();

	private readonly Hashtable x365a076ab13b6a8f = new Hashtable();

	internal void x1b7f35899f1c1f42(ShapeBase x5770cdefd8931aa9)
	{
		x4085004b0e262e95(x5770cdefd8931aa9, 4102);
		x4085004b0e262e95(x5770cdefd8931aa9, 4111);
		x4085004b0e262e95(x5770cdefd8931aa9, 4110);
	}

	private void x4085004b0e262e95(ShapeBase x5770cdefd8931aa9, int x423578f1dd2f31d1)
	{
		byte[] array = (byte[])x5770cdefd8931aa9.xf7125312c7ee115c.xf7866f89640a29a3(x423578f1dd2f31d1);
		if (array != null && !x2f36d530d72e2c86.x263d579af1d0d43f(array))
		{
			Guid guid = x66cdafe77e7aa42b.x8341ba999ffebb91(array);
			if (x365a076ab13b6a8f.ContainsKey(guid))
			{
				x5770cdefd8931aa9.xf7125312c7ee115c.xae20093bed1e48a8(x423578f1dd2f31d1, x365a076ab13b6a8f[guid]);
				return;
			}
			x2f36d530d72e2c86.xd6b6ed77479ef68c(array);
			x365a076ab13b6a8f[guid] = array;
		}
	}
}
