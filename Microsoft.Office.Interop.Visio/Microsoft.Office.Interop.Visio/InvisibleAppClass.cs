using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using stdole;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[Guid("000D0A26-0000-0000-C000-000000000046")]
[DefaultMember("ActiveDocument")]
[ComSourceInterfaces("Microsoft.Office.Interop.Visio.EApplication\0\0")]
[ClassInterface(0)]
[TypeLibType(2)]
public class InvisibleAppClass : IVInvisibleApp, InvisibleApp, EApplication_Event
{
	[DispId(0)]
	public virtual extern Document ActiveDocument
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1)]
	public virtual extern Page ActivePage
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(2)]
	public virtual extern Window ActiveWindow
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(3)]
	public virtual extern Application Application
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(4)]
	public virtual extern Documents Documents
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(5)]
	public virtual extern short ObjectType
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
	}

	[DispId(6)]
	public virtual extern int OnDataChangeDelay
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		set;
	}

	[DispId(7)]
	public virtual extern int ProcessID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
	}

	[DispId(11)]
	public virtual extern short ScreenUpdating
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		set;
	}

	[DispId(12)]
	public virtual extern short Stat
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
	}

	[DispId(14)]
	public virtual extern string Version
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(15)]
	public virtual extern short WindowHandle
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		get;
	}

	[DispId(16)]
	public virtual extern Windows Windows
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(8)]
	public virtual extern int Language
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
	}

	[DispId(17)]
	public virtual extern short IsVisio16
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		get;
	}

	[DispId(18)]
	public virtual extern short IsVisio32
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
	}

	[DispId(19)]
	public virtual extern int WindowHandle32
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
	}

	[DispId(20)]
	public virtual extern short InstanceHandle
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		get;
	}

	[DispId(21)]
	public virtual extern int InstanceHandle32
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
	}

	[DispId(22)]
	public virtual extern UIObject BuiltInMenus
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(23)]
	public virtual extern UIObject BuiltInToolbars
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(24)]
	public virtual extern UIObject CustomMenus
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(26)]
	public virtual extern string CustomMenusFile
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(28)]
	public virtual extern UIObject CustomToolbars
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(30)]
	public virtual extern string CustomToolbarsFile
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(32)]
	public virtual extern string AddonPaths
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(33)]
	public virtual extern string DrawingPaths
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(34)]
	public virtual extern string FilterPaths
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(35)]
	public virtual extern string HelpPaths
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(36)]
	public virtual extern string StartupPaths
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(37)]
	public virtual extern string StencilPaths
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(38)]
	public virtual extern string TemplatePaths
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(39)]
	public virtual extern string UserName
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(40)]
	public virtual extern short PromptForSummary
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		set;
	}

	[DispId(41)]
	public virtual extern Addons Addons
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(44)]
	public virtual extern string ProfileName
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(45)]
	public virtual extern string EventInfo
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(46)]
	public virtual extern EventList EventList
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(47)]
	public virtual extern short PersistsEvents
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
	}

	[DispId(48)]
	public virtual extern short Active
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
	}

	[DispId(49)]
	public virtual extern short DeferRecalc
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		set;
	}

	[DispId(50)]
	public virtual extern short AlertResponse
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		set;
	}

	[DispId(51)]
	public virtual extern short ShowProgress
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		set;
	}

	[DispId(52)]
	public virtual extern object Vbe
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		get;
	}

	[DispId(53)]
	public virtual extern short ShowMenus
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[param: In]
		set;
	}

	[DispId(54)]
	public virtual extern short ToolbarStyle
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[param: In]
		set;
	}

	[DispId(55)]
	public virtual extern short ShowStatusBar
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		set;
	}

	[DispId(56)]
	public virtual extern short EventsEnabled
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		set;
	}

	[DispId(59)]
	public virtual extern string Path
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(61)]
	public virtual extern int TraceFlags
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		set;
	}

	[DispId(64)]
	public virtual extern short ShowToolbar
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		set;
	}

	[DispId(65)]
	public virtual extern bool LiveDynamics
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		set;
	}

	[DispId(66)]
	public virtual extern bool AutoLayout
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		set;
	}

	[DispId(67)]
	public virtual extern bool Visible
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		set;
	}

	[DispId(71)]
	public virtual extern string CommandLine
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(72)]
	public virtual extern bool IsUndoingOrRedoing
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
	}

	[DispId(73)]
	public virtual extern int CurrentScope
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
	}

	[DispId(74)]
	public virtual extern bool IsInScope
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
	}

	[DispId(75)]
	public virtual extern object old_Addins
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		get;
	}

	[DispId(76)]
	public virtual extern string ProductName
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(77)]
	public virtual extern bool UndoEnabled
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		set;
	}

	[DispId(78)]
	public virtual extern bool ShowChanges
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		set;
	}

	[DispId(79)]
	public virtual extern short TypelibMajorVersion
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
	}

	[DispId(80)]
	public virtual extern short TypelibMinorVersion
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
	}

	[DispId(81)]
	public virtual extern short AutoRecoverInterval
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		set;
	}

	[DispId(1610743918)]
	public virtual extern bool InhibitSelectChange
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		set;
	}

	[DispId(1610743920)]
	public virtual extern string ActivePrinter
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(1610743922)]
	public virtual extern Array AvailablePrinters
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)]
		get;
	}

	[DispId(1610743925)]
	public virtual extern object CommandBars
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		get;
	}

	[DispId(1610743926)]
	public virtual extern int Build
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
	}

	[DispId(1610743927)]
	public virtual extern object COMAddIns
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		get;
	}

	[DispId(1610743928)]
	public virtual extern object DefaultPageUnits
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[return: MarshalAs(UnmanagedType.Struct)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[param: In]
		[param: MarshalAs(UnmanagedType.Struct)]
		set;
	}

	[DispId(1610743930)]
	public virtual extern object DefaultTextUnits
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.Struct)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		[param: MarshalAs(UnmanagedType.Struct)]
		set;
	}

	[DispId(1610743932)]
	public virtual extern object DefaultAngleUnits
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.Struct)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		[param: MarshalAs(UnmanagedType.Struct)]
		set;
	}

	[DispId(1610743934)]
	public virtual extern object DefaultDurationUnits
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.Struct)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		[param: MarshalAs(UnmanagedType.Struct)]
		set;
	}

	[DispId(1610743936)]
	public virtual extern int FullBuild
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
	}

	[DispId(1610743938)]
	public virtual extern bool VBAEnabled
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
	}

	[DispId(1610743939)]
	public virtual extern VisZoomBehavior DefaultZoomBehavior
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		set;
	}

	[DispId(1610743942)]
	[ComAliasName("stdole.IFontDisp")]
	public virtual extern IFontDisp DialogFont
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.Interface)]
		[return: ComAliasName("stdole.IFontDisp")]
		get;
	}

	[DispId(1610743943)]
	public virtual extern int LanguageHelp
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
	}

	[DispId(1610743944)]
	public virtual extern Window Window
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1610743945)]
	public virtual extern string Name
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(1610743946)]
	public virtual extern object ConnectorToolDataObject
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.IUnknown)]
		get;
	}

	[DispId(1610743947)]
	public virtual extern ApplicationSettings Settings
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1610743949)]
	public virtual extern object SaveAsWebObject
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		get;
	}

	[DispId(1610743950)]
	public virtual extern object MsoDebugOptions
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		get;
	}

	[DispId(1610743951)]
	public virtual extern string MyShapesPath
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(1610743953)]
	public virtual extern object DefaultRectangleDataObject
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.IUnknown)]
		get;
	}

	[DispId(1610743954)]
	public virtual extern bool DataFeaturesEnabled
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
	}

	[DispId(1610743955)]
	public virtual extern object LanguageSettings
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		get;
	}

	[DispId(1610743956)]
	public virtual extern object Assistance
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		get;
	}

	[DispId(1610743963)]
	public virtual extern bool DeferRelationshipRecalc
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[param: In]
		set;
	}

	[DispId(1610743965)]
	public virtual extern VisEdition CurrentEdition
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
	}

	[DispId(1610743966)]
	public virtual extern long InstanceHandle64
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
	}

	public virtual extern event EApplication_AppActivatedEventHandler AppActivated;

	public virtual extern event EApplication_AppDeactivatedEventHandler AppDeactivated;

	public virtual extern event EApplication_AppObjActivatedEventHandler AppObjActivated;

	public virtual extern event EApplication_AppObjDeactivatedEventHandler AppObjDeactivated;

	public virtual extern event EApplication_BeforeQuitEventHandler BeforeQuit;

	public virtual extern event EApplication_BeforeModalEventHandler BeforeModal;

	public virtual extern event EApplication_AfterModalEventHandler AfterModal;

	public virtual extern event EApplication_WindowOpenedEventHandler WindowOpened;

	public virtual extern event EApplication_SelectionChangedEventHandler SelectionChanged;

	public virtual extern event EApplication_BeforeWindowClosedEventHandler BeforeWindowClosed;

	public virtual extern event EApplication_WindowActivatedEventHandler WindowActivated;

	public virtual extern event EApplication_BeforeWindowSelDeleteEventHandler BeforeWindowSelDelete;

	public virtual extern event EApplication_BeforeWindowPageTurnEventHandler BeforeWindowPageTurn;

	public virtual extern event EApplication_WindowTurnedToPageEventHandler WindowTurnedToPage;

	public virtual extern event EApplication_DocumentOpenedEventHandler DocumentOpened;

	public virtual extern event EApplication_DocumentCreatedEventHandler DocumentCreated;

	public virtual extern event EApplication_DocumentSavedEventHandler DocumentSaved;

	public virtual extern event EApplication_DocumentSavedAsEventHandler DocumentSavedAs;

	public virtual extern event EApplication_DocumentChangedEventHandler DocumentChanged;

	public virtual extern event EApplication_BeforeDocumentCloseEventHandler BeforeDocumentClose;

	public virtual extern event EApplication_StyleAddedEventHandler StyleAdded;

	public virtual extern event EApplication_StyleChangedEventHandler StyleChanged;

	public virtual extern event EApplication_BeforeStyleDeleteEventHandler BeforeStyleDelete;

	public virtual extern event EApplication_MasterAddedEventHandler MasterAdded;

	public virtual extern event EApplication_MasterChangedEventHandler MasterChanged;

	public virtual extern event EApplication_BeforeMasterDeleteEventHandler BeforeMasterDelete;

	public virtual extern event EApplication_PageAddedEventHandler PageAdded;

	public virtual extern event EApplication_PageChangedEventHandler PageChanged;

	public virtual extern event EApplication_BeforePageDeleteEventHandler BeforePageDelete;

	public virtual extern event EApplication_ShapeAddedEventHandler ShapeAdded;

	public virtual extern event EApplication_BeforeSelectionDeleteEventHandler BeforeSelectionDelete;

	public virtual extern event EApplication_ShapeChangedEventHandler ShapeChanged;

	public virtual extern event EApplication_SelectionAddedEventHandler SelectionAdded;

	public virtual extern event EApplication_BeforeShapeDeleteEventHandler BeforeShapeDelete;

	public virtual extern event EApplication_TextChangedEventHandler TextChanged;

	public virtual extern event EApplication_CellChangedEventHandler CellChanged;

	public virtual extern event EApplication_MarkerEventEventHandler MarkerEvent;

	public virtual extern event EApplication_NoEventsPendingEventHandler NoEventsPending;

	public virtual extern event EApplication_VisioIsIdleEventHandler VisioIsIdle;

	public virtual extern event EApplication_MustFlushScopeBeginningEventHandler MustFlushScopeBeginning;

	public virtual extern event EApplication_MustFlushScopeEndedEventHandler MustFlushScopeEnded;

	public virtual extern event EApplication_RunModeEnteredEventHandler RunModeEntered;

	public virtual extern event EApplication_DesignModeEnteredEventHandler DesignModeEntered;

	public virtual extern event EApplication_BeforeDocumentSaveEventHandler BeforeDocumentSave;

	public virtual extern event EApplication_BeforeDocumentSaveAsEventHandler BeforeDocumentSaveAs;

	public virtual extern event EApplication_FormulaChangedEventHandler FormulaChanged;

	public virtual extern event EApplication_ConnectionsAddedEventHandler ConnectionsAdded;

	public virtual extern event EApplication_ConnectionsDeletedEventHandler ConnectionsDeleted;

	public virtual extern event EApplication_EnterScopeEventHandler EnterScope;

	public virtual extern event EApplication_ExitScopeEventHandler ExitScope;

	public virtual extern event EApplication_QueryCancelQuitEventHandler QueryCancelQuit;

	public virtual extern event EApplication_QuitCanceledEventHandler QuitCanceled;

	public virtual extern event EApplication_WindowChangedEventHandler WindowChanged;

	public virtual extern event EApplication_ViewChangedEventHandler ViewChanged;

	public virtual extern event EApplication_QueryCancelWindowCloseEventHandler QueryCancelWindowClose;

	public virtual extern event EApplication_WindowCloseCanceledEventHandler WindowCloseCanceled;

	public virtual extern event EApplication_QueryCancelDocumentCloseEventHandler QueryCancelDocumentClose;

	public virtual extern event EApplication_DocumentCloseCanceledEventHandler DocumentCloseCanceled;

	public virtual extern event EApplication_QueryCancelStyleDeleteEventHandler QueryCancelStyleDelete;

	public virtual extern event EApplication_StyleDeleteCanceledEventHandler StyleDeleteCanceled;

	public virtual extern event EApplication_QueryCancelMasterDeleteEventHandler QueryCancelMasterDelete;

	public virtual extern event EApplication_MasterDeleteCanceledEventHandler MasterDeleteCanceled;

	public virtual extern event EApplication_QueryCancelPageDeleteEventHandler QueryCancelPageDelete;

	public virtual extern event EApplication_PageDeleteCanceledEventHandler PageDeleteCanceled;

	public virtual extern event EApplication_ShapeParentChangedEventHandler ShapeParentChanged;

	public virtual extern event EApplication_BeforeShapeTextEditEventHandler BeforeShapeTextEdit;

	public virtual extern event EApplication_ShapeExitedTextEditEventHandler ShapeExitedTextEdit;

	public virtual extern event EApplication_QueryCancelSelectionDeleteEventHandler QueryCancelSelectionDelete;

	public virtual extern event EApplication_SelectionDeleteCanceledEventHandler SelectionDeleteCanceled;

	public virtual extern event EApplication_QueryCancelUngroupEventHandler QueryCancelUngroup;

	public virtual extern event EApplication_UngroupCanceledEventHandler UngroupCanceled;

	public virtual extern event EApplication_QueryCancelConvertToGroupEventHandler QueryCancelConvertToGroup;

	public virtual extern event EApplication_ConvertToGroupCanceledEventHandler ConvertToGroupCanceled;

	public virtual extern event EApplication_QueryCancelSuspendEventHandler QueryCancelSuspend;

	public virtual extern event EApplication_SuspendCanceledEventHandler SuspendCanceled;

	public virtual extern event EApplication_BeforeSuspendEventHandler BeforeSuspend;

	public virtual extern event EApplication_AfterResumeEventHandler AfterResume;

	public virtual extern event EApplication_OnKeystrokeMessageForAddonEventHandler OnKeystrokeMessageForAddon;

	public virtual extern event EApplication_MouseDownEventHandler MouseDown;

	public virtual extern event EApplication_MouseMoveEventHandler MouseMove;

	public virtual extern event EApplication_MouseUpEventHandler MouseUp;

	public virtual extern event EApplication_KeyDownEventHandler KeyDown;

	public virtual extern event EApplication_KeyPressEventHandler KeyPress;

	public virtual extern event EApplication_KeyUpEventHandler KeyUp;

	public virtual extern event EApplication_QueryCancelSuspendEventsEventHandler QueryCancelSuspendEvents;

	public virtual extern event EApplication_SuspendEventsCanceledEventHandler SuspendEventsCanceled;

	public virtual extern event EApplication_BeforeSuspendEventsEventHandler BeforeSuspendEvents;

	public virtual extern event EApplication_AfterResumeEventsEventHandler AfterResumeEvents;

	public virtual extern event EApplication_QueryCancelGroupEventHandler QueryCancelGroup;

	public virtual extern event EApplication_GroupCanceledEventHandler GroupCanceled;

	public virtual extern event EApplication_ShapeDataGraphicChangedEventHandler ShapeDataGraphicChanged;

	public virtual extern event EApplication_BeforeDataRecordsetDeleteEventHandler BeforeDataRecordsetDelete;

	public virtual extern event EApplication_DataRecordsetChangedEventHandler DataRecordsetChanged;

	public virtual extern event EApplication_DataRecordsetAddedEventHandler DataRecordsetAdded;

	public virtual extern event EApplication_ShapeLinkAddedEventHandler ShapeLinkAdded;

	public virtual extern event EApplication_ShapeLinkDeletedEventHandler ShapeLinkDeleted;

	public virtual extern event EApplication_AfterRemoveHiddenInformationEventHandler AfterRemoveHiddenInformation;

	public virtual extern event EApplication_ContainerRelationshipAddedEventHandler ContainerRelationshipAdded;

	public virtual extern event EApplication_ContainerRelationshipDeletedEventHandler ContainerRelationshipDeleted;

	public virtual extern event EApplication_CalloutRelationshipAddedEventHandler CalloutRelationshipAdded;

	public virtual extern event EApplication_CalloutRelationshipDeletedEventHandler CalloutRelationshipDeleted;

	public virtual extern event EApplication_RuleSetValidatedEventHandler RuleSetValidated;

	public virtual extern event EApplication_QueryCancelReplaceShapesEventHandler QueryCancelReplaceShapes;

	public virtual extern event EApplication_ReplaceShapesCanceledEventHandler ReplaceShapesCanceled;

	public virtual extern event EApplication_BeforeReplaceShapesEventHandler BeforeReplaceShapes;

	public virtual extern event EApplication_AfterReplaceShapesEventHandler AfterReplaceShapes;

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void Quit();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void Redo();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void Undo();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetCustomMenus([In][MarshalAs(UnmanagedType.Interface)] UIObject MenusObject);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void ClearCustomMenus();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetCustomToolbars([In][MarshalAs(UnmanagedType.Interface)] UIObject ToolbarsObject);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void ClearCustomToolbars();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[TypeLibFunc(64)]
	public virtual extern void SaveWorkspaceAs([In][MarshalAs(UnmanagedType.BStr)] string FileName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void DoCmd([In] short CommandID);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[return: MarshalAs(UnmanagedType.BStr)]
	public virtual extern string FormatResult([In][MarshalAs(UnmanagedType.Struct)] object StringOrNumber, [In][MarshalAs(UnmanagedType.Struct)] object UnitsIn, [In][MarshalAs(UnmanagedType.Struct)] object UnitsOut, [In][MarshalAs(UnmanagedType.BStr)] string Format);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern double ConvertResult([In][MarshalAs(UnmanagedType.Struct)] object StringOrNumber, [In][MarshalAs(UnmanagedType.Struct)] object UnitsIn, [In][MarshalAs(UnmanagedType.Struct)] object UnitsOut);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void EnumDirectories([In][MarshalAs(UnmanagedType.BStr)] string PathsString, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] out Array NameArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void PurgeUndo();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern int QueueMarkerEvent([In][MarshalAs(UnmanagedType.BStr)] string ContextString);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern int BeginUndoScope([In][MarshalAs(UnmanagedType.BStr)] string bstrUndoScopeName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void EndUndoScope([In] int nScopeID, [In] bool bCommit);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void AddUndoUnit([In][MarshalAs(UnmanagedType.IUnknown)] object pUndoUnit);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void RenameCurrentScope([In][MarshalAs(UnmanagedType.BStr)] string bstrScopeName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void InvokeHelp([In][MarshalAs(UnmanagedType.BStr)] string bstrHelpFileName, [In] int Command, [In] int Data);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void OnComponentEnterState([In] VisOnComponentEnterCodes uStateID, [In] bool bEnter);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[TypeLibFunc(64)]
	[return: MarshalAs(UnmanagedType.Struct)]
	public virtual extern object GetUsageStatistic([In] int nWhichStatistic);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[return: MarshalAs(UnmanagedType.BStr)]
	public virtual extern string FormatResultEx([In][MarshalAs(UnmanagedType.Struct)] object StringOrNumber, [In][MarshalAs(UnmanagedType.Struct)] object UnitsIn, [In][MarshalAs(UnmanagedType.Struct)] object UnitsOut, [In][MarshalAs(UnmanagedType.BStr)] string Format, [In] int LangID = 0, [In] int CalendarID = -1);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void RegisterRibbonX([In][MarshalAs(UnmanagedType.IUnknown)] object SourceAddOn, [In][MarshalAs(UnmanagedType.Interface)] Document TargetDocument, [In] VisRibbonXModes TargetModes, [In][MarshalAs(UnmanagedType.BStr)] string FriendlyName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void UnregisterRibbonX([In][MarshalAs(UnmanagedType.IUnknown)] object SourceAddOn, [In][MarshalAs(UnmanagedType.Interface)] Document TargetDocument);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern bool GetPreviewEnabled([In][MarshalAs(UnmanagedType.BStr)] string GalleryName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetPreviewEnabled([In][MarshalAs(UnmanagedType.BStr)] string GalleryName, bool OnOrOff);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[return: MarshalAs(UnmanagedType.BStr)]
	public virtual extern string GetBuiltInStencilFile([In] VisBuiltInStencilTypes StencilType, [In] VisMeasurementSystem MeasurementSystem);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[return: MarshalAs(UnmanagedType.BStr)]
	public virtual extern string GetCustomStencilFile([In] VisBuiltInStencilTypes StencilType);
}
