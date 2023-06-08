using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("07163211-E4CA-49D2-9D91-299D123616C3")]
[ComVisible(true)]
public interface IFontsManager
{
	IFontSubstRuleCollection FontSubstRuleList { get; set; }

	IFontData[] GetFonts();

	void ReplaceFont(IFontData sourceFont, IFontData destFont);

	void ReplaceFont(IFontSubstRule substRule);

	void ReplaceFont(IFontSubstRuleCollection substRules);
}
