using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using stdole;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[DefaultMember("Name")]
[Guid("00021A21-0000-0000-C000-000000000046")]
[ClassInterface(0)]
[ComSourceInterfaces("Microsoft.Office.Interop.Visio.EDocument\0\0")]
public class DocumentClass : IVDocument, Document, EDocument_Event
{
	[DispId(1)]
	public virtual extern Application Application
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(2)]
	public virtual extern short Stat
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2)]
		get;
	}

	[DispId(3)]
	public virtual extern short ObjectType
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3)]
		get;
	}

	[DispId(5)]
	public virtual extern short InPlace
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5)]
		get;
	}

	[DispId(6)]
	public virtual extern Masters Masters
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(6)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(7)]
	public virtual extern Pages Pages
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(7)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(8)]
	public virtual extern Styles Styles
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(8)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(0)]
	public virtual extern string Name
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(0)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(20)]
	public virtual extern string Path
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(20)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(21)]
	public virtual extern string FullName
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(21)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(4)]
	public virtual extern short Index
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(4)]
		get;
	}

	[DispId(10)]
	public virtual extern short old_Saved
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10)]
		[TypeLibFunc(64)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10)]
		[TypeLibFunc(64)]
		[param: In]
		set;
	}

	[DispId(11)]
	public virtual extern short ReadOnly
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(11)]
		get;
	}

	[DispId(14)]
	public virtual extern int old_Version
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(14)]
		[TypeLibFunc(64)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(14)]
		[TypeLibFunc(64)]
		[param: In]
		set;
	}

	[DispId(15)]
	public virtual extern string Title
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(15)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(15)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(16)]
	public virtual extern string Subject
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(16)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(16)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(17)]
	public virtual extern string Creator
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(17)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(17)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(18)]
	public virtual extern string Keywords
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(18)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(18)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(19)]
	public virtual extern string Description
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(19)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(19)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(24)]
	public virtual extern UIObject CustomMenus
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(24)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(26)]
	public virtual extern string CustomMenusFile
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(26)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(26)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(28)]
	public virtual extern UIObject CustomToolbars
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(28)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(30)]
	public virtual extern string CustomToolbarsFile
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(30)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(30)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(32)]
	public virtual extern Fonts Fonts
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(32)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(33)]
	public virtual extern Colors Colors
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(33)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(34)]
	public virtual extern EventList EventList
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(34)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(35)]
	public virtual extern string Template
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(35)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(37)]
	public virtual extern short old_SavePreviewMode
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[DispId(37)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[DispId(37)]
		[param: In]
		set;
	}

	[DispId(40)]
	public virtual extern double LeftMargin
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(40)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(40)]
		[param: In]
		set;
	}

	[DispId(41)]
	public virtual extern double RightMargin
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(41)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(41)]
		[param: In]
		set;
	}

	[DispId(42)]
	public virtual extern double TopMargin
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(42)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(42)]
		[param: In]
		set;
	}

	[DispId(43)]
	public virtual extern double BottomMargin
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(43)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(43)]
		[param: In]
		set;
	}

	[DispId(44)]
	public virtual extern short old_PrintLandscape
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(44)]
		[TypeLibFunc(64)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[DispId(44)]
		[param: In]
		set;
	}

	[DispId(45)]
	public virtual extern short old_PrintCenteredH
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(45)]
		[TypeLibFunc(64)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[DispId(45)]
		[param: In]
		set;
	}

	[DispId(46)]
	public virtual extern short old_PrintCenteredV
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(46)]
		[TypeLibFunc(64)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(46)]
		[TypeLibFunc(64)]
		[param: In]
		set;
	}

	[DispId(47)]
	public virtual extern double PrintScale
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(47)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(47)]
		[param: In]
		set;
	}

	[DispId(48)]
	public virtual extern short old_PrintFitOnPages
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[DispId(48)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(48)]
		[TypeLibFunc(64)]
		[param: In]
		set;
	}

	[DispId(49)]
	public virtual extern short PrintPagesAcross
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(49)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(49)]
		[param: In]
		set;
	}

	[DispId(50)]
	public virtual extern short PrintPagesDown
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(50)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(50)]
		[param: In]
		set;
	}

	[DispId(51)]
	public virtual extern string DefaultStyle
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(51)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(51)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(52)]
	public virtual extern string DefaultLineStyle
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(52)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(52)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(53)]
	public virtual extern string DefaultFillStyle
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(53)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(53)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(54)]
	public virtual extern string DefaultTextStyle
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(54)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(54)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(55)]
	public virtual extern short PersistsEvents
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(55)]
		get;
	}

	[DispId(59)]
	public virtual extern object VBProject
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(59)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		get;
	}

	[DispId(60)]
	public virtual extern double PaperWidth
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(60)]
		get;
	}

	[DispId(61)]
	public virtual extern double PaperHeight
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(61)]
		get;
	}

	[DispId(62)]
	public virtual extern short old_PaperSize
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[DispId(62)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[DispId(62)]
		[param: In]
		set;
	}

	[DispId(-2147418112)]
	public virtual extern string CodeName
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[DispId(-2147418112)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(64)]
	public virtual extern short old_Mode
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(64)]
		[TypeLibFunc(64)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[DispId(64)]
		[param: In]
		set;
	}

	[DispId(65)]
	public virtual extern OLEObjects OLEObjects
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(65)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(67)]
	public virtual extern string Manager
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(67)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(67)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(68)]
	public virtual extern string Company
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(68)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(68)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(69)]
	public virtual extern string Category
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(69)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(69)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(70)]
	public virtual extern string HyperlinkBase
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(70)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(70)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(71)]
	public virtual extern Shape DocumentSheet
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(71)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(72)]
	public virtual extern object Container
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(72)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		get;
	}

	[DispId(73)]
	public virtual extern string ClassID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(73)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(74)]
	public virtual extern string ProgID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(74)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(75)]
	public virtual extern MasterShortcuts MasterShortcuts
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(75)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(76)]
	public virtual extern string AlternateNames
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(76)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(76)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(77)]
	public virtual extern Shape GestureFormatSheet
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(77)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(79)]
	public virtual extern bool AutoRecover
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(79)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(79)]
		[param: In]
		set;
	}

	[DispId(1610743922)]
	public virtual extern bool Saved
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743922)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743922)]
		[param: In]
		set;
	}

	[DispId(1610743924)]
	public virtual extern VisDocVersions Version
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743924)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743924)]
		[param: In]
		set;
	}

	[DispId(1610743926)]
	public virtual extern VisSavePreviewMode SavePreviewMode
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743926)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743926)]
		[param: In]
		set;
	}

	[DispId(1610743928)]
	public virtual extern bool PrintLandscape
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743928)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743928)]
		[param: In]
		set;
	}

	[DispId(1610743930)]
	public virtual extern bool PrintCenteredH
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743930)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743930)]
		[param: In]
		set;
	}

	[DispId(1610743932)]
	public virtual extern bool PrintCenteredV
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743932)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743932)]
		[param: In]
		set;
	}

	[DispId(1610743934)]
	public virtual extern bool PrintFitOnPages
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743934)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743934)]
		[param: In]
		set;
	}

	[DispId(1610743936)]
	public virtual extern VisPaperSizes PaperSize
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743936)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743936)]
		[param: In]
		set;
	}

	[DispId(1610743938)]
	public virtual extern VisDocModeArgs Mode
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743938)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743938)]
		[param: In]
		set;
	}

	[DispId(1610743940)]
	public virtual extern bool SnapEnabled
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743940)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743940)]
		[param: In]
		set;
	}

	[DispId(1610743942)]
	public virtual extern VisSnapSettings SnapSettings
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743942)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743942)]
		[param: In]
		set;
	}

	[DispId(1610743944)]
	public virtual extern VisSnapExtensions SnapExtensions
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743944)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743944)]
		[param: In]
		set;
	}

	[DispId(1610743946)]
	public virtual extern Array SnapAngles
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743946)]
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743946)]
		[param: In]
		[param: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)]
		set;
	}

	[DispId(1610743948)]
	public virtual extern bool GlueEnabled
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743948)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743948)]
		[param: In]
		set;
	}

	[DispId(1610743950)]
	public virtual extern VisGlueSettings GlueSettings
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743950)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743950)]
		[param: In]
		set;
	}

	[DispId(1610743952)]
	public virtual extern bool DynamicGridEnabled
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743952)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743952)]
		[param: In]
		set;
	}

	[DispId(1610743954)]
	public virtual extern string DefaultGuideStyle
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743954)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743954)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(1610743956)]
	public virtual extern VisProtection Protection
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743956)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743956)]
		[param: In]
		set;
	}

	[DispId(1610743958)]
	public virtual extern string Printer
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743958)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743958)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(1610743960)]
	public virtual extern int PrintCopies
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743960)]
		[TypeLibFunc(64)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[DispId(1610743960)]
		[param: In]
		set;
	}

	[DispId(1610743962)]
	public virtual extern string HeaderLeft
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743962)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743962)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(1610743964)]
	public virtual extern string HeaderCenter
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743964)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743964)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(1610743966)]
	public virtual extern string HeaderRight
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743966)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743966)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(1610743968)]
	public virtual extern double HeaderMargin
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743968)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743968)]
		[param: In]
		set;
	}

	[DispId(1610743970)]
	public virtual extern string FooterLeft
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743970)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743970)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(1610743972)]
	public virtual extern string FooterCenter
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743972)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743972)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(1610743974)]
	public virtual extern string FooterRight
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743974)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743974)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(1610743976)]
	public virtual extern double FooterMargin
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743976)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743976)]
		[param: In]
		set;
	}

	[DispId(1610743978)]
	[ComAliasName("stdole.IFontDisp")]
	public virtual extern IFontDisp HeaderFooterFont
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743978)]
		[return: MarshalAs(UnmanagedType.Interface)]
		[return: ComAliasName("stdole.IFontDisp")]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743978)]
		[param: In]
		[param: ComAliasName("stdole.IFontDisp")]
		[param: MarshalAs(UnmanagedType.Interface)]
		set;
	}

	[ComAliasName("stdole.OLE_COLOR")]
	[DispId(1610743980)]
	public virtual extern uint HeaderFooterColor
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743980)]
		[return: ComAliasName("stdole.OLE_COLOR")]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743980)]
		[param: In]
		[param: ComAliasName("stdole.OLE_COLOR")]
		set;
	}

	[DispId(1610743982)]
	public virtual extern string Password
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743982)]
		[TypeLibFunc(64)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[ComAliasName("stdole.IPictureDisp")]
	[DispId(1610743983)]
	public virtual extern IPictureDisp PreviewPicture
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743983)]
		[return: MarshalAs(UnmanagedType.Interface)]
		[return: ComAliasName("stdole.IPictureDisp")]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743983)]
		[param: In]
		[param: ComAliasName("stdole.IPictureDisp")]
		[param: MarshalAs(UnmanagedType.Interface)]
		set;
	}

	[DispId(1610743986)]
	public virtual extern int BuildNumberCreated
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743986)]
		get;
	}

	[DispId(1610743987)]
	public virtual extern int BuildNumberEdited
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743987)]
		get;
	}

	[DispId(1610743988)]
	public virtual extern DateTime TimeCreated
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743988)]
		get;
	}

	[DispId(1610743989)]
	public virtual extern DateTime Time
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743989)]
		get;
	}

	[DispId(1610743990)]
	public virtual extern DateTime TimeEdited
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743990)]
		get;
	}

	[DispId(1610743991)]
	public virtual extern DateTime TimePrinted
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743991)]
		get;
	}

	[DispId(1610743992)]
	public virtual extern DateTime TimeSaved
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743992)]
		get;
	}

	[DispId(1610743994)]
	public virtual extern bool ContainsWorkspace
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743994)]
		[TypeLibFunc(64)]
		get;
	}

	[DispId(1610743995)]
	public virtual extern Array EmailRoutingData
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743995)]
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)]
		get;
	}

	[DispId(1610743996)]
	public virtual extern Array VBProjectData
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743996)]
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)]
		get;
	}

	[DispId(1610743997)]
	public virtual extern int SolutionXMLElementCount
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743997)]
		get;
	}

	[DispId(1610743998)]
	public virtual extern string SolutionXMLElementName
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743998)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(1610743999)]
	public virtual extern bool SolutionXMLElementExists
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743999)]
		get;
	}

	[DispId(1610744000)]
	public virtual extern string SolutionXMLElement
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744000)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744000)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(1610744003)]
	public virtual extern int FullBuildNumberCreated
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744003)]
		get;
	}

	[DispId(1610744004)]
	public virtual extern int FullBuildNumberEdited
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744004)]
		get;
	}

	[DispId(1610744005)]
	public virtual extern int ID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744005)]
		get;
	}

	[DispId(1610744006)]
	public virtual extern bool MacrosEnabled
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744006)]
		get;
	}

	[DispId(1610744007)]
	public virtual extern VisZoomBehavior ZoomBehavior
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744007)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744007)]
		[param: In]
		set;
	}

	[DispId(1610744011)]
	public virtual extern VisDocumentTypes Type
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744011)]
		get;
	}

	[DispId(1610744012)]
	public virtual extern int Language
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744012)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744012)]
		[TypeLibFunc(64)]
		[param: In]
		set;
	}

	[DispId(1610744014)]
	public virtual extern bool RemovePersonalInformation
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744014)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744014)]
		[param: In]
		set;
	}

	[DispId(1610744021)]
	public virtual extern bool UndoEnabled
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744021)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744021)]
		[param: In]
		set;
	}

	[DispId(1610744024)]
	public virtual extern object SharedWorkspace
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744024)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		get;
	}

	[DispId(1610744025)]
	public virtual extern object Sync
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744025)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		get;
	}

	[DispId(1610744027)]
	public virtual extern DataRecordsets DataRecordsets
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744027)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1610744032)]
	public virtual extern bool ContainsWorkspaceEx
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744032)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744032)]
		[param: In]
		set;
	}

	[DispId(1610744035)]
	public virtual extern string DefaultSavePath
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744035)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744035)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(1610744037)]
	public virtual extern string CustomUI
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744037)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744037)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(1610744039)]
	public virtual extern string UserCustomUI
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744039)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744039)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(1610744041)]
	public virtual extern ServerPublishOptions ServerPublishOptions
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744041)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1610744042)]
	public virtual extern Validation Validation
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744042)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1610744043)]
	public virtual extern int DiagramServicesEnabled
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744043)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744043)]
		[param: In]
		set;
	}

	[DispId(1610744045)]
	public virtual extern bool CompatibilityMode
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744045)]
		get;
	}

	[DispId(1610744046)]
	public virtual extern Comments Comments
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744046)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1610744047)]
	public virtual extern int EditorCount
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744047)]
		get;
	}

	public virtual extern event EDocument_DocumentOpenedEventHandler DocumentOpened;

	public virtual extern event EDocument_DocumentCreatedEventHandler DocumentCreated;

	public virtual extern event EDocument_DocumentSavedEventHandler DocumentSaved;

	public virtual extern event EDocument_DocumentSavedAsEventHandler DocumentSavedAs;

	public virtual extern event EDocument_DocumentChangedEventHandler DocumentChanged;

	public virtual extern event EDocument_BeforeDocumentCloseEventHandler BeforeDocumentClose;

	public virtual extern event EDocument_StyleAddedEventHandler StyleAdded;

	public virtual extern event EDocument_StyleChangedEventHandler StyleChanged;

	public virtual extern event EDocument_BeforeStyleDeleteEventHandler BeforeStyleDelete;

	public virtual extern event EDocument_MasterAddedEventHandler MasterAdded;

	public virtual extern event EDocument_MasterChangedEventHandler MasterChanged;

	public virtual extern event EDocument_BeforeMasterDeleteEventHandler BeforeMasterDelete;

	public virtual extern event EDocument_PageAddedEventHandler PageAdded;

	public virtual extern event EDocument_PageChangedEventHandler PageChanged;

	public virtual extern event EDocument_BeforePageDeleteEventHandler BeforePageDelete;

	public virtual extern event EDocument_ShapeAddedEventHandler ShapeAdded;

	public virtual extern event EDocument_BeforeSelectionDeleteEventHandler BeforeSelectionDelete;

	public virtual extern event EDocument_RunModeEnteredEventHandler RunModeEntered;

	public virtual extern event EDocument_DesignModeEnteredEventHandler DesignModeEntered;

	public virtual extern event EDocument_BeforeDocumentSaveEventHandler BeforeDocumentSave;

	public virtual extern event EDocument_BeforeDocumentSaveAsEventHandler BeforeDocumentSaveAs;

	public virtual extern event EDocument_QueryCancelDocumentCloseEventHandler QueryCancelDocumentClose;

	public virtual extern event EDocument_DocumentCloseCanceledEventHandler DocumentCloseCanceled;

	public virtual extern event EDocument_QueryCancelStyleDeleteEventHandler QueryCancelStyleDelete;

	public virtual extern event EDocument_StyleDeleteCanceledEventHandler StyleDeleteCanceled;

	public virtual extern event EDocument_QueryCancelMasterDeleteEventHandler QueryCancelMasterDelete;

	public virtual extern event EDocument_MasterDeleteCanceledEventHandler MasterDeleteCanceled;

	public virtual extern event EDocument_QueryCancelPageDeleteEventHandler QueryCancelPageDelete;

	public virtual extern event EDocument_PageDeleteCanceledEventHandler PageDeleteCanceled;

	public virtual extern event EDocument_ShapeParentChangedEventHandler ShapeParentChanged;

	public virtual extern event EDocument_BeforeShapeTextEditEventHandler BeforeShapeTextEdit;

	public virtual extern event EDocument_ShapeExitedTextEditEventHandler ShapeExitedTextEdit;

	public virtual extern event EDocument_QueryCancelSelectionDeleteEventHandler QueryCancelSelectionDelete;

	public virtual extern event EDocument_SelectionDeleteCanceledEventHandler SelectionDeleteCanceled;

	public virtual extern event EDocument_QueryCancelUngroupEventHandler QueryCancelUngroup;

	public virtual extern event EDocument_UngroupCanceledEventHandler UngroupCanceled;

	public virtual extern event EDocument_QueryCancelConvertToGroupEventHandler QueryCancelConvertToGroup;

	public virtual extern event EDocument_ConvertToGroupCanceledEventHandler ConvertToGroupCanceled;

	public virtual extern event EDocument_QueryCancelGroupEventHandler QueryCancelGroup;

	public virtual extern event EDocument_GroupCanceledEventHandler GroupCanceled;

	public virtual extern event EDocument_ShapeDataGraphicChangedEventHandler ShapeDataGraphicChanged;

	public virtual extern event EDocument_BeforeDataRecordsetDeleteEventHandler BeforeDataRecordsetDelete;

	public virtual extern event EDocument_DataRecordsetAddedEventHandler DataRecordsetAdded;

	public virtual extern event EDocument_AfterRemoveHiddenInformationEventHandler AfterRemoveHiddenInformation;

	public virtual extern event EDocument_RuleSetValidatedEventHandler RuleSetValidated;

	public virtual extern event EDocument_AfterDocumentMergeEventHandler AfterDocumentMerge;

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(9)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Master Drop([In][MarshalAs(UnmanagedType.IUnknown)] object ObjectToDrop, [In] short xPos, [In] short yPos);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(12)]
	public virtual extern short Save();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(13)]
	public virtual extern short SaveAs([In][MarshalAs(UnmanagedType.BStr)] string FileName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(22)]
	public virtual extern void Print();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(23)]
	public virtual extern void Close();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(25)]
	public virtual extern void SetCustomMenus([In][MarshalAs(UnmanagedType.Interface)] UIObject MenusObject);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(27)]
	public virtual extern void ClearCustomMenus();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(29)]
	public virtual extern void SetCustomToolbars([In][MarshalAs(UnmanagedType.Interface)] UIObject ToolbarsObject);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(31)]
	public virtual extern void ClearCustomToolbars();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(36)]
	public virtual extern void SaveAsEx([In][MarshalAs(UnmanagedType.BStr)] string FileName, [In] short SaveFlags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[TypeLibFunc(64)]
	[DispId(38)]
	public virtual extern void GetIcon([In] short ID, [In][MarshalAs(UnmanagedType.BStr)] string FileName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[TypeLibFunc(64)]
	[DispId(39)]
	public virtual extern void SetIcon([In] short ID, [In] short Index, [In][MarshalAs(UnmanagedType.BStr)] string FileName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(56)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Window OpenStencilWindow();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(57)]
	public virtual extern void ParseLine([In][MarshalAs(UnmanagedType.BStr)] string Line);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(58)]
	public virtual extern void ExecuteLine([In][MarshalAs(UnmanagedType.BStr)] string Line);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[TypeLibFunc(64)]
	[DispId(63)]
	public virtual extern void FollowHyperlink45([In][MarshalAs(UnmanagedType.BStr)] string Target, [In][MarshalAs(UnmanagedType.BStr)] string Location);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(66)]
	public virtual extern void FollowHyperlink([In][MarshalAs(UnmanagedType.BStr)] string Address, [In][MarshalAs(UnmanagedType.BStr)] string SubAddress, [Optional][In][MarshalAs(UnmanagedType.Struct)] object ExtraInfo, [Optional][In][MarshalAs(UnmanagedType.Struct)] object Frame, [Optional][In][MarshalAs(UnmanagedType.Struct)] object NewWindow, [Optional][In][MarshalAs(UnmanagedType.Struct)] object res1, [Optional][In][MarshalAs(UnmanagedType.Struct)] object res2, [Optional][In][MarshalAs(UnmanagedType.Struct)] object res3);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(78)]
	public virtual extern void ClearGestureFormatSheet();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743985)]
	public virtual extern void Clean([Optional][In][MarshalAs(UnmanagedType.Struct)] object nTargets, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nActions, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nAlerts, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nFixes, [Optional][In][MarshalAs(UnmanagedType.Struct)] object bStopOnError, [Optional][In][MarshalAs(UnmanagedType.Struct)] object bLogFileName, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nReserved);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743993)]
	public virtual extern void CopyPreviewPicture([In][MarshalAs(UnmanagedType.Interface)] Document pSourceDoc);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610744002)]
	public virtual extern void DeleteSolutionXMLElement([In][MarshalAs(UnmanagedType.BStr)] string ElementName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610744009)]
	public virtual extern bool CanCheckIn();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610744010)]
	public virtual extern void CheckIn([In] bool SaveChanges = true, [Optional][In][MarshalAs(UnmanagedType.Struct)] ref object Comments, [In] bool MakePublic = false);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610744016)]
	public virtual extern void PrintOut([In] VisPrintOutRange PrintRange, [In] int FromPage = 1, [In] int ToPage = -1, [In] bool ScaleCurrentViewToPaper = false, [In][MarshalAs(UnmanagedType.BStr)] string PrinterName = "", [In] bool PrintToFile = false, [In][MarshalAs(UnmanagedType.BStr)] string OutputFileName = "", [In] int Copies = 1, [In] bool Collate = false, [In] bool ColorAsBlack = false);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610744017)]
	public virtual extern int BeginUndoScope([In][MarshalAs(UnmanagedType.BStr)] string bstrUndoScopeName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610744018)]
	public virtual extern void EndUndoScope([In] int nScopeID, [In] bool bCommit);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610744019)]
	public virtual extern void AddUndoUnit([In][MarshalAs(UnmanagedType.IUnknown)] object pUndoUnit);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610744020)]
	public virtual extern void PurgeUndo();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610744023)]
	public virtual extern void RenameCurrentScope([In][MarshalAs(UnmanagedType.BStr)] string bstrScopeName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610744026)]
	public virtual extern void RemoveHiddenInformation([In] int RemoveHiddenInfoItems);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610744028)]
	public virtual extern void GetThemeNames([In] VisThemeTypes eType, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] out Array NameArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610744029)]
	public virtual extern void GetThemeNamesU([In] VisThemeTypes eType, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] out Array NameArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610744030)]
	public virtual extern bool CanUndoCheckOut();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610744031)]
	public virtual extern void UndoCheckOut();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610744034)]
	public virtual extern void ExportAsFixedFormat([In] VisFixedFormatTypes FixedFormat, [In][MarshalAs(UnmanagedType.BStr)] string OutputFileName, [In] VisDocExIntent Intent, [In] VisPrintOutRange PrintRange, [In] int FromPage = 1, [In] int ToPage = -1, [In] bool ColorAsBlack = false, [In] bool IncludeBackground = true, [In] bool IncludeDocumentProperties = true, [In] bool IncludeStructureTags = true, [In] bool UseISO19005_1 = false, [Optional][In][MarshalAs(UnmanagedType.Struct)] object FixedFormatExtClass);
}
