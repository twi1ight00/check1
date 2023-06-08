using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[Guid("B960E21D-82F9-4B23-8C4B-280D913D39E2")]
[ComVisible(true)]
public interface IPropertyEffect : IBehavior
{
	string From { get; set; }

	string To { get; set; }

	string By { get; set; }

	PropertyValueType ValueType { get; set; }

	PropertyCalcModeType CalcMode { get; set; }

	IPointCollection Points { get; set; }

	IBehavior AsIBehavior { get; }
}
