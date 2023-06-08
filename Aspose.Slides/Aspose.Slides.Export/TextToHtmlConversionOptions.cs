using System.Runtime.InteropServices;

namespace Aspose.Slides.Export;

[ClassInterface(ClassInterfaceType.None)]
[Guid("9b66da7e-b5d1-44a9-b508-b7988e85be1e")]
[ComVisible(true)]
public sealed class TextToHtmlConversionOptions : ITextToHtmlConversionOptions
{
	private bool bool_0;

	private TextInheritanceLimit textInheritanceLimit_0;

	private ILinkEmbedController ilinkEmbedController_0;

	private string string_0 = "utf-8";

	public bool AddClipboardFragmentHeader
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public TextInheritanceLimit TextInheritanceLimit
	{
		get
		{
			return textInheritanceLimit_0;
		}
		set
		{
			textInheritanceLimit_0 = value;
		}
	}

	public ILinkEmbedController LinkEmbedController
	{
		get
		{
			return ilinkEmbedController_0;
		}
		set
		{
			ilinkEmbedController_0 = value;
		}
	}

	public string EncodingName
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}
}
