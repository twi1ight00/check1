using ns252;

namespace ns258;

internal class Class6396
{
	private Class6329 class6329_0 = new Class6329(0.0);

	private Class6329 class6329_1 = new Class6329(0.0);

	public Class6329 DashLength
	{
		get
		{
			return class6329_0;
		}
		set
		{
			class6329_0 = value;
		}
	}

	public Class6329 SpaceLength
	{
		get
		{
			return class6329_1;
		}
		set
		{
			class6329_1 = value;
		}
	}

	public Class6396 Clone()
	{
		Class6396 @class = new Class6396();
		@class.SpaceLength = SpaceLength;
		@class.DashLength = DashLength;
		return @class;
	}
}
