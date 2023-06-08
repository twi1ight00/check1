using System.IO;
using ns226;

namespace ns229;

internal abstract class Class6057 : Class6056
{
	protected Class6057(Class6110 header, Class6017 data)
		: base(header, data)
	{
	}

	protected Class6057(Class6110 header, Class6016 data)
		: base(header, data)
	{
	}

	public int method_18(int index)
	{
		Class6016 @class = method_6();
		if (@class == null)
		{
			throw new IOException("No font data for the table.");
		}
		return @class.ReadByte(index);
	}

	public void method_19(int index, byte b)
	{
		Class6017 @class = method_7();
		if (@class == null)
		{
			throw new IOException("No font data for the table.");
		}
		@class.WriteByte(index, b);
	}

	public int method_20()
	{
		Class6016 @class = method_6();
		if (@class == null)
		{
			throw new IOException("No font data for the table.");
		}
		return @class.method_2();
	}
}
