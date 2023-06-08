using Aspose.Slides.Export;
using Aspose.Slides.Warnings;
using ns235;
using ns49;

namespace ns12;

internal class Class183 : Interface317
{
	private readonly ISaveOptions isaveOptions_0;

	public Class183(ISaveOptions saveOptions)
	{
		isaveOptions_0 = saveOptions;
	}

	public bool imethod_0(Exception57 error)
	{
		if (error is Exception59 && isaveOptions_0 != null && isaveOptions_0.WarningCallback != null)
		{
			Class1176 @class = new Class1176("Brush data cannot be rendered", WarningType.DataLoss);
			@class.SendWarning(isaveOptions_0.WarningCallback);
		}
		return true;
	}
}
