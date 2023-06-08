using System.Drawing;
using System.Security;
using System.Windows.Forms;
using ns73;
using ns84;

namespace ns277;

internal class Class6952 : Interface355
{
	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private Class3677 class3677_0;

	public string BasePath
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public string ImgPath
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public string HtmlVersion
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public string CharSet
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public string SandboxOptions
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	public Class3677 Device
	{
		get
		{
			return class3677_0;
		}
		set
		{
			class3677_0 = value;
		}
	}

	public static Interface355 Default => new Class6952();

	public Class6952()
	{
		string_0 = string.Empty;
		string_1 = string.Empty;
		string_2 = string.Empty;
		string_4 = string.Empty;
		class3677_0 = smethod_0();
	}

	private static Class3677 smethod_0()
	{
		Class3677 @class = new Class3677();
		@class.MediaType = Enum599.const_7;
		try
		{
			@class.ScreenSize = Screen.PrimaryScreen.Bounds.Size;
		}
		catch (SecurityException)
		{
			@class.ScreenSize = new Size(1024, 768);
		}
		@class.WindowSize = @class.ScreenSize;
		@class.Orientation = ((@class.ScreenSize.Width >= @class.ScreenSize.Height) ? Enum510.const_1 : Enum510.const_0);
		return @class;
	}
}
