using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("c86306e1-e3ec-4405-9229-59e688a36306")]
[ComVisible(true)]
public interface IShapeStyle
{
	IColorFormat LineColor { get; }

	ushort LineStyleIndex { get; set; }

	IColorFormat FillColor { get; }

	short FillStyleIndex { get; set; }

	IColorFormat EffectColor { get; }

	uint EffectStyleIndex { get; set; }

	IColorFormat FontColor { get; }

	FontCollectionIndex FontCollectionIndex { get; set; }
}
