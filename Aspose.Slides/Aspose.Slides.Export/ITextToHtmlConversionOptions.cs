using System.Runtime.InteropServices;

namespace Aspose.Slides.Export;

[Guid("df3d9583-a0ea-45c0-ac0b-86f806531ab6")]
[ComVisible(true)]
public interface ITextToHtmlConversionOptions
{
	bool AddClipboardFragmentHeader { get; set; }

	TextInheritanceLimit TextInheritanceLimit { get; set; }

	ILinkEmbedController LinkEmbedController { get; set; }

	string EncodingName { get; set; }
}
