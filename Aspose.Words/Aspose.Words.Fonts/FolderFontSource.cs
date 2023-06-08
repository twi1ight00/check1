using xeb665d1aeef09d64;

namespace Aspose.Words.Fonts;

public class FolderFontSource : FontSourceBase
{
	private readonly string xb623bfc824f99feb;

	private readonly bool xfd125918fb7778b4;

	public string FolderPath => xb623bfc824f99feb;

	public bool ScanSubfolders => xfd125918fb7778b4;

	public override FontSourceType Type => FontSourceType.FontsFolder;

	public FolderFontSource(string folderPath, bool scanSubfolders)
	{
		xb623bfc824f99feb = folderPath;
		xfd125918fb7778b4 = scanSubfolders;
	}

	internal override x551d3b1862a114b1 x5eff1f3a09faac7e()
	{
		return new xcd3dbac2a50827fa(xb623bfc824f99feb, xfd125918fb7778b4);
	}
}
