using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FREngine;

[ComImport]
[Guid("11001080-0000-1056-976E-008048D53AE3")]
[CompilerGenerated]
[TypeIdentifier]
public interface IFRDocument
{
	void _VtblGap1_1();

	[DispId(2)]
	void Process([In][MarshalAs(UnmanagedType.Interface)] DocumentProcessingParams DocumentProcessingParams = null);

	void _VtblGap2_1();

	[DispId(4)]
	void Preprocess([In][MarshalAs(UnmanagedType.Interface)] PagePreprocessingParams PreprocessingParams = null, [In][MarshalAs(UnmanagedType.Interface)] ObjectsExtractionParams ExtractionParams = null, [In][MarshalAs(UnmanagedType.Interface)] RecognizerParams RecognizerParams = null, [In][MarshalAs(UnmanagedType.Interface)] PageSplittingParams SplittingParams = null);

	void _VtblGap3_9();

	[DispId(14)]
	void AddImageFile([In][MarshalAs(UnmanagedType.BStr)] string ImageFileName, [In][MarshalAs(UnmanagedType.Interface)] PrepareImageMode PrepareMode = null, [In][MarshalAs(UnmanagedType.Interface)] IntsCollection PageIndices = null);

	void _VtblGap4_4();

	FRPages Pages
	{
		[DispId(20)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	void _VtblGap5_8();

	[DispId(27)]
	void Close();
}
