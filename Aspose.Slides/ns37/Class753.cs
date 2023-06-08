using System.Drawing;
using Aspose.Slides;
using ns36;

namespace ns37;

internal class Class753 : Interface16
{
	private Class741 class741_0;

	private Class755 class755_0;

	internal Class755 BorderInternal => class755_0;

	public Interface18 Border => class755_0;

	internal Class741 AreaInternal => class741_0;

	public Interface6 Area => class741_0;

	internal Class753(Class740 chart)
	{
		class755_0 = new Class755(chart, Enum145.const_5);
		class741_0 = new Class741(chart, this, Enum140.const_3);
		class741_0.Formatting = FillType.NotDefined;
		class741_0.ForegroundColor = Color.Empty;
		class755_0.Formatting = FillType.NotDefined;
		class755_0.Color = Color.Empty;
	}
}
