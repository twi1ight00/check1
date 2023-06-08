using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("e2f4e958-4b82-4510-8437-967fb948e1e8")]
public interface IBulletFormat
{
	BulletType Type { get; set; }

	char Char { get; set; }

	IFontData Font { get; set; }

	float Height { get; set; }

	IColorFormat Color { get; }

	short NumberedBulletStartWith { get; set; }

	NumberedBulletStyle NumberedBulletStyle { get; set; }

	NullableBool IsBulletHardColor { get; set; }

	NullableBool IsBulletHardFont { get; set; }
}
