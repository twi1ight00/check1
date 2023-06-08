using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("22455686-05fd-47d4-acac-dd583b84d55c")]
public interface IBulletFormatEffectiveData
{
	BulletType Type { get; }

	char Char { get; }

	IFontData Font { get; }

	float Height { get; }

	short NumberedBulletStartWith { get; }

	NumberedBulletStyle NumberedBulletStyle { get; }

	Color Color { get; }
}
