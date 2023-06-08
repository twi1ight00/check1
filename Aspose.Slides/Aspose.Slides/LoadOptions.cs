using System.Runtime.InteropServices;
using Aspose.Slides.Warnings;
using ns49;

namespace Aspose.Slides;

[Guid("7CC1885F-A947-4BBB-B053-7818503E4F02")]
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
public class LoadOptions : ILoadOptions
{
	private LoadFormat loadFormat_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private bool bool_0;

	private IWarningCallback iwarningCallback_0;

	public LoadFormat LoadFormat
	{
		get
		{
			return loadFormat_0;
		}
		set
		{
			loadFormat_0 = value;
		}
	}

	public string DefaultRegularFont
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

	public string DefaultSymbolFont
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

	public string DefaultAsianFont
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

	public string Password
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

	public bool OnlyLoadDocumentProperties
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public IWarningCallback WarningCallback
	{
		get
		{
			return iwarningCallback_0;
		}
		set
		{
			iwarningCallback_0 = value;
		}
	}

	public LoadOptions()
		: this(LoadFormat.Auto)
	{
	}

	public LoadOptions(LoadFormat loadFormat)
	{
		loadFormat_0 = loadFormat;
	}

	internal void method_0()
	{
		if (WarningCallback != null)
		{
			Class1175 @class = new Class1175();
			@class.SendWarning(WarningCallback);
		}
	}

	internal void method_1(string description, WarningType warningType)
	{
		if (WarningCallback != null)
		{
			Class1176 @class = new Class1176(description, warningType);
			@class.SendWarning(WarningCallback);
		}
	}
}
