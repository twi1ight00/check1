using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FREngine;

[ComImport]
[CompilerGenerated]
[Guid("11001000-0000-1056-976E-008048D53AE3")]
[TypeIdentifier]
public interface IEngine
{
	void _VtblGap1_13();

	[DispId(10)]
	[return: MarshalAs(UnmanagedType.Interface)]
	DocumentProcessingParams CreateDocumentProcessingParams();

	void _VtblGap2_1();

	[DispId(12)]
	[return: MarshalAs(UnmanagedType.Interface)]
	PagePreprocessingParams CreatePagePreprocessingParams();

	void _VtblGap3_2();

	[DispId(15)]
	[return: MarshalAs(UnmanagedType.Interface)]
	RecognizerParams CreateRecognizerParams();

	void _VtblGap4_5();

	[DispId(21)]
	[return: MarshalAs(UnmanagedType.Interface)]
	OrientationDetectionParams CreateOrientationDetectionParams();

	void _VtblGap5_14();

	[DispId(38)]
	[return: MarshalAs(UnmanagedType.Interface)]
	RTFExportParams CreateRTFExportParams();

	void _VtblGap6_13();

	[DispId(52)]
	[return: MarshalAs(UnmanagedType.Interface)]
	FRDocument CreateFRDocument();

	void _VtblGap7_35();

	[DispId(97)]
	void LoadPredefinedProfile([In][MarshalAs(UnmanagedType.BStr)] string ProfileName);

	void _VtblGap8_1();

	ILicense CurrentLicense
	{
		[DispId(101)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}
}
