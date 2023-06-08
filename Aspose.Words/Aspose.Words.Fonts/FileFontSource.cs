using xeb665d1aeef09d64;

namespace Aspose.Words.Fonts;

public class FileFontSource : FontSourceBase
{
	private readonly string xd42b91a65c54013d;

	public string FilePath => xd42b91a65c54013d;

	public override FontSourceType Type => FontSourceType.FontFile;

	public FileFontSource(string filePath)
	{
		xd42b91a65c54013d = filePath;
	}

	internal override x551d3b1862a114b1 x5eff1f3a09faac7e()
	{
		return new xb3852af4ba803ccd(xd42b91a65c54013d);
	}
}
