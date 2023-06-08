using System.IO;
using ns100;
using ns101;
using ns102;
using ns103;

namespace ns99;

internal abstract class Class4474
{
	protected Class4408 class4408_0;

	protected Stream stream_0;

	public static Class4474 smethod_0(Class4408 font, Stream stream)
	{
		Class4474 @class = null;
		if (font is Class4412)
		{
			@class = new Class4477();
		}
		else if (font is Class4411)
		{
			@class = new Class4476();
		}
		else if (font is Class4413)
		{
			@class = new Class4478();
		}
		else
		{
			if (!(font is Class4409))
			{
				throw new Exception35("Font saving error. Saving of requested font type is not supported.");
			}
			@class = new Class4475();
		}
		@class.class4408_0 = font;
		@class.stream_0 = stream;
		return @class;
	}

	public abstract void Save();
}
