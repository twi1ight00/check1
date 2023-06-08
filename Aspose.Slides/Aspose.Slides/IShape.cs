using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("3623d9d6-a67b-41d1-b22c-dc335ceb9fc7")]
[ComVisible(true)]
public interface IShape : IPresentationComponent, ISlideComponent, IHyperlinkContainer
{
	bool IsTextHolder { get; }

	IPlaceholder Placeholder { get; }

	ICustomData CustomData { get; }

	IShapeFrame RawFrame { get; set; }

	IShapeFrame Frame { get; set; }

	ILineFormat LineFormat { get; }

	IThreeDFormat ThreeDFormat { get; }

	IEffectFormat EffectFormat { get; }

	IFillFormat FillFormat { get; }

	bool Hidden { get; set; }

	int ZOrderPosition { get; }

	float Rotation { get; set; }

	float X { get; set; }

	float Y { get; set; }

	float Width { get; set; }

	float Height { get; set; }

	string AlternativeText { get; set; }

	string Name { get; set; }

	IBaseShapeLock ShapeLock { get; }

	uint UniqueId { get; }

	bool IsGrouped { get; }

	IGroupShape ParentGroup { get; }

	IHyperlinkContainer AsIHyperlinkContainer { get; }

	ISlideComponent AsISlideComponent { get; }

	IPlaceholder AddPlaceholder(IPlaceholder placeholderToCopyFrom);

	void RemovePlaceholder();

	ILineFormatEffectiveData CreateLineFormatEffective();

	IFillFormatEffectiveData CreateFillFormatEffective();

	IEffectFormatEffectiveData CreateEffectFormatEffective();

	IThreeDFormatEffectiveData CreateThreeDFormatEffective();

	Bitmap GetThumbnail();

	Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY);
}
