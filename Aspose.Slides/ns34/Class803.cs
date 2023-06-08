using Aspose.Slides.Warnings;
using ns49;

namespace ns34;

internal class Class803
{
	private IWarningCallback iwarningCallback_0;

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

	internal void method_0()
	{
		if (WarningCallback != null)
		{
			Class1173 @class = new Class1173();
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
