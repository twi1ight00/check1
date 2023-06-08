using System;
using System.IO;
using Aspose;
using x011d489fb9df7027;

namespace x5af3f327d745698a;

internal abstract class x320b28ae68e47317
{
	protected string x93168ed101bbb044;

	internal abstract x1ba6afab4f42a0ee xcfc06e7ce72a0f0b { get; }

	internal string x570858a97a5a2c4a => x93168ed101bbb044;

	internal static x320b28ae68e47317 x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75, int xc1690d3515e1ed6c)
	{
		xf0002907cfe93bb4 xf0002907cfe93bb5 = new xf0002907cfe93bb4(xe134235b3526fa75, xc1690d3515e1ed6c);
		return xf0002907cfe93bb5.x1ba6afab4f42a0ee switch
		{
			x1ba6afab4f42a0ee.x1891c445b78b044b => new x8844513eda0a5d2e(xf0002907cfe93bb5, xe134235b3526fa75), 
			x1ba6afab4f42a0ee.xc24de6454f8b0f37 => new xfa9b77033f6e5e27(xf0002907cfe93bb5, xe134235b3526fa75), 
			_ => throw new InvalidOperationException("Unexpected OleObjectType value."), 
		};
	}

	[JavaThrows(true)]
	internal abstract void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b);
}
