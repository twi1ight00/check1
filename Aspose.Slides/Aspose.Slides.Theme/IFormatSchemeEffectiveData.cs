using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[ComVisible(true)]
[Guid("edb668ff-a9a7-4e26-9b7f-1a51c47f22e2")]
public interface IFormatSchemeEffectiveData
{
	IFillFormatCollectionEffectiveData GetFillStyles(Color styleColor);

	ILineFormatCollectionEffectiveData GetLineStyles(Color styleColor);

	IEffectStyleCollectionEffectiveData GetEffectStyles(Color styleColor);

	IFillFormatCollectionEffectiveData GetBackgroundFillStyles(Color styleColor);
}
