using System.Runtime.InteropServices;

namespace Aspose.Slides.Export;

[Guid("1E619FD4-CE04-4BF1-BDBE-249AEB11C02E")]
[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
public class PptOptions : SaveOptions, ISaveOptions, IPptOptions
{
	ISaveOptions IPptOptions.AsISaveOptions => this;

	internal IPptOptions Clone()
	{
		return (PptOptions)MemberwiseClone();
	}
}
