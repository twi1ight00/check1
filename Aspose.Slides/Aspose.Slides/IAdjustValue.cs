using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("49a49ea8-5a30-49dd-910c-87820df1e49d")]
[ComVisible(true)]
public interface IAdjustValue
{
	long RawValue { get; set; }

	float AngleValue { get; set; }

	string Name { get; }
}
