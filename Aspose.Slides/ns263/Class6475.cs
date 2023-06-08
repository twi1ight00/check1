using System.Drawing.Drawing2D;
using ns224;

namespace ns263;

internal class Class6475
{
	private Class6002 class6002_0;

	private Class6002 class6002_1;

	public Class6002 ShapeTransformation
	{
		get
		{
			return class6002_1;
		}
		set
		{
			class6002_1 = value;
		}
	}

	public Class6002 ShapeOffset
	{
		get
		{
			return class6002_0;
		}
		set
		{
			class6002_0 = value;
		}
	}

	public Class6475(Class6002 shapeTransformation, Class6002 shapeOffset)
	{
		class6002_1 = shapeTransformation;
		class6002_0 = shapeOffset;
	}

	public Class6002 method_0()
	{
		Class6002 @class = class6002_1.Clone();
		@class.method_9(class6002_0, MatrixOrder.Append);
		return @class;
	}
}
