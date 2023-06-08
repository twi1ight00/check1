using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Xml;
using Aspose.Slides.Export;
using Aspose.Slides.Theme;
using Aspose.Slides.Vba;
using ns12;
using ns13;
using ns15;
using ns16;
using ns22;
using ns24;
using ns276;
using ns28;
using ns33;
using ns4;
using ns44;
using ns45;
using ns47;
using ns49;
using ns59;
using ns60;
using ns63;
using ns71;

namespace Aspose.Slides;

[ClassInterface(ClassInterfaceType.None)]
[Guid("43247d92-4bb9-4883-b807-4b77b186c741")]
[ComVisible(true)]
public sealed class Presentation : IDisposable, IPresentationComponent, IPresentation
{
	internal const string string_0 = "Aspose.Slides.DOM.resources.";

	private const string string_1 = ".odp";

	internal SourceFormat sourceFormat_0 = SourceFormat.Pptx;

	private ProtectionManager protectionManager_0;

	private readonly SlideCollection slideCollection_0;

	private readonly GlobalLayoutSlideCollection globalLayoutSlideCollection_0;

	private readonly MasterSlideCollection masterSlideCollection_0;

	private FontsManager fontsManager_0;

	private readonly Class54 class54_0;

	private readonly Class53 class53_0;

	private Class1072 class1072_0;

	private Class1071 class1071_0;

	private ImageCollection imageCollection_0;

	private AudioCollection audioCollection_0;

	private IVideoCollection ivideoCollection_0;

	private SlideSize slideSize_0 = new SlideSize();

	private CustomData customData_0;

	internal TextStyle textStyle_0;

	private MasterTheme masterTheme_0;

	internal CommentAuthorCollection commentAuthorCollection_0;

	private HeaderFooterManager headerFooterManager_0;

	private DocumentProperties documentProperties_0;

	private uint uint_0;

	private ulong ulong_0;

	internal Dictionary<ulong, WeakReference> dictionary_0 = new Dictionary<ulong, WeakReference>();

	internal static readonly IParagraphFormat iparagraphFormat_0;

	private bool bool_0;

	private LoadOptions loadOptions_0;

	private DateTime dateTime_0 = DateTime.Now;

	private bool bool_1 = true;

	private bool bool_2;

	private uint uint_1;

	private HyperlinkQueries hyperlinkQueries_0;

	private ViewProperties viewProperties_0;

	private Class350 class350_0 = new Class350();

	private Class277 class277_0 = new Class277();

	private IVbaProject ivbaProject_0;

	private Class3542 class3542_0;

	private int int_0 = -1;

	private readonly Dictionary<uint, object> dictionary_1 = new Dictionary<uint, object>();

	internal Class476 class476_0;

	private static readonly char[] char_0;

	private static uint[] uint_2;

	internal Class3542 VbaProjectRootStorage
	{
		get
		{
			return class3542_0;
		}
		set
		{
			class3542_0 = value;
		}
	}

	internal LoadOptions LoadOptions => loadOptions_0;

	public DateTime CurrentDateTime
	{
		get
		{
			return dateTime_0;
		}
		set
		{
			if (dateTime_0 != value)
			{
				method_21();
			}
			dateTime_0 = value;
		}
	}

	public bool UpdateSlideNumberFields
	{
		get
		{
			return bool_1;
		}
		set
		{
			if (bool_1 != value)
			{
				method_21();
			}
			bool_1 = value;
		}
	}

	public bool UpdateDateTimeFields
	{
		get
		{
			return bool_2;
		}
		set
		{
			if (bool_2 != value)
			{
				method_21();
			}
			bool_2 = value;
		}
	}

	internal uint Version_OldMode => uint_1;

	internal bool IsParsingInProgress => bool_0;

	public IHeaderFooterManager HeaderFooterManager
	{
		get
		{
			if (headerFooterManager_0 == null)
			{
				headerFooterManager_0 = new HeaderFooterManager(this);
				headerFooterManager_0.Initialize();
			}
			return headerFooterManager_0;
		}
	}

	internal Class350 PPTXUnsupportedProps => class350_0;

	internal Class277 PPTUnsupportedProps => class277_0;

	internal Class54 FontsManagerInternal => class54_0;

	internal Class53 FontsListManager => class53_0;

	private bool IsPresentationTreatedAsEncrypted
	{
		get
		{
			if (!loadOptions_0.OnlyLoadDocumentProperties)
			{
				return loadOptions_0.Password != null;
			}
			return false;
		}
	}

	public IProtectionManager ProtectionManager => protectionManager_0;

	[Obsolete("Use ProtectionManager.EncryptDocumentProperties property instead. Property will be removed after 01.09.2013.")]
	public bool EncryptDocumentProperties
	{
		get
		{
			return protectionManager_0.EncryptDocumentProperties;
		}
		set
		{
			protectionManager_0.EncryptDocumentProperties = value;
		}
	}

	[Obsolete("Use ProtectionManager.IsEncrypted property instead. Property will be removed after 01.09.2013.")]
	public bool IsEncrypted => protectionManager_0.IsEncrypted;

	[Obsolete("Use ProtectionManager.IsOnlyDocumentPropertiesLoaded property instead. Property will be removed after 01.09.2013.")]
	public bool IsOnlyDocumentPropertiesLoaded => protectionManager_0.IsOnlyDocumentPropertiesLoaded;

	[Obsolete("Use ProtectionManager.IsWriteProtected property instead. Property will be removed after 01.09.2013.")]
	public bool IsWriteProtected => protectionManager_0.IsWriteProtected;

	internal string FileExtension
	{
		get
		{
			return Class889.smethod_3(PPTXUnsupportedProps.PresentationType);
		}
		set
		{
			string text = ".";
			string text2 = ((!value.StartsWith(text)) ? (text + value) : value);
			PPTXUnsupportedProps.PresentationType = Class889.smethod_2(text2.ToLower(), Enum165.const_0);
		}
	}

	public ISlideCollection Slides => slideCollection_0;

	public ISlideSize SlideSize => slideSize_0;

	internal SizeF NotesSize => PPTXUnsupportedProps.NotesSize;

	public IGlobalLayoutSlideCollection LayoutSlides => globalLayoutSlideCollection_0;

	public IMasterSlideCollection Masters => masterSlideCollection_0;

	public IMasterNotesSlideManager MasterNotesSlideManager => class1072_0;

	public IMasterHandoutSlideManager MasterHandoutSlideManager => class1071_0;

	public IFontsManager FontsManager => fontsManager_0;

	public ITextStyle DefaultTextStyle => textStyle_0;

	public ICommentAuthorCollection CommentAuthors => commentAuthorCollection_0;

	public IDocumentProperties DocumentProperties => documentProperties_0;

	public IImageCollection Images => imageCollection_0;

	public IAudioCollection Audios => audioCollection_0;

	public IVideoCollection Videos => ivideoCollection_0;

	[Obsolete("Use CustomData.Tags instead. Will be removed after 01.09.2014.")]
	public ITagCollection Tags => customData_0.Tags;

	public ICustomData CustomData => customData_0;

	public IVbaProject VbaProject
	{
		get
		{
			return ivbaProject_0;
		}
		set
		{
			ivbaProject_0 = value;
			if (ivbaProject_0 != null)
			{
				class3542_0 = ((VbaProject)ivbaProject_0).VbaProjectRootStorage;
			}
			else
			{
				class3542_0 = null;
			}
		}
	}

	public IHyperlinkQueries HyperlinkQueries
	{
		get
		{
			if (hyperlinkQueries_0 == null)
			{
				hyperlinkQueries_0 = new HyperlinkQueries(this);
			}
			return hyperlinkQueries_0;
		}
	}

	public IViewProperties ViewProperties
	{
		get
		{
			if (viewProperties_0 == null)
			{
				viewProperties_0 = new ViewProperties(this);
			}
			return viewProperties_0;
		}
	}

	public SourceFormat SourceFormat => sourceFormat_0;

	internal Class146 TableStyles => PPTXUnsupportedProps.TableStyles;

	public IMasterTheme MasterTheme => masterTheme_0;

	IDisposable IPresentation.AsIDisposable => this;

	IPresentationComponent IPresentation.AsIPresentationComponent => this;

	IPresentation IPresentationComponent.Presentation => this;

	internal bool method_0()
	{
		return int_0 != -1;
	}

	internal uint method_1()
	{
		dictionary_1.Add((uint)(++int_0), null);
		return (uint)int_0;
	}

	internal uint method_2(uint value)
	{
		if (value > int_0)
		{
			int_0 = (int)value;
			return value;
		}
		if (dictionary_1.ContainsKey(value))
		{
			return method_1();
		}
		return value;
	}

	static Presentation()
	{
		iparagraphFormat_0 = new ParagraphFormat(null);
		char_0 = new char[2] { '/', '.' };
		uint[] array = new uint[1];
		uint_2 = array;
		smethod_0();
	}

	private static void smethod_0()
	{
		Class53.DefaultFontsList.Clear();
		IParagraphFormat paragraphFormat = iparagraphFormat_0;
		IParagraphFormat paragraphFormat2 = iparagraphFormat_0;
		IParagraphFormat paragraphFormat3 = iparagraphFormat_0;
		float marginRight = 0f;
		paragraphFormat3.Indent = 0f;
		float marginLeft = 0f;
		paragraphFormat2.MarginRight = marginRight;
		paragraphFormat.MarginLeft = marginLeft;
		iparagraphFormat_0.Bullet.Height = 100f;
		iparagraphFormat_0.Bullet.NumberedBulletStartWith = 1;
		iparagraphFormat_0.Alignment = TextAlignment.Left;
		iparagraphFormat_0.Bullet.Type = BulletType.None;
		iparagraphFormat_0.DefaultTabSize = 72f;
		iparagraphFormat_0.EastAsianLineBreak = NullableBool.False;
		iparagraphFormat_0.FontAlignment = FontAlignment.Automatic;
		iparagraphFormat_0.HangingPunctuation = NullableBool.True;
		iparagraphFormat_0.Bullet.IsBulletHardColor = NullableBool.False;
		iparagraphFormat_0.Bullet.IsBulletHardFont = NullableBool.False;
		iparagraphFormat_0.LatinLineBreak = NullableBool.False;
		iparagraphFormat_0.RightToLeft = NullableBool.False;
		iparagraphFormat_0.SpaceAfter = 0f;
		iparagraphFormat_0.SpaceBefore = 0f;
		iparagraphFormat_0.SpaceWithin = 100f;
		iparagraphFormat_0.DefaultPortionFormat.FontHeight = 18f;
		iparagraphFormat_0.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
		iparagraphFormat_0.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.StyleColor;
		iparagraphFormat_0.DefaultPortionFormat.Escapement = 0f;
		iparagraphFormat_0.DefaultPortionFormat.KerningMinimalSize = 12f;
		IPortionFormat defaultPortionFormat = iparagraphFormat_0.DefaultPortionFormat;
		IPortionFormat defaultPortionFormat2 = iparagraphFormat_0.DefaultPortionFormat;
		IFontData fontData2 = (iparagraphFormat_0.DefaultPortionFormat.LatinFont = new FontData("Arial"));
		IFontData complexScriptFont = (defaultPortionFormat2.EastAsianFont = fontData2);
		defaultPortionFormat.ComplexScriptFont = complexScriptFont;
		iparagraphFormat_0.DefaultPortionFormat.SymbolFont = new FontData("Wingdings");
		iparagraphFormat_0.DefaultPortionFormat.FontBold = NullableBool.False;
		iparagraphFormat_0.DefaultPortionFormat.FontItalic = NullableBool.False;
		iparagraphFormat_0.DefaultPortionFormat.FontUnderline = TextUnderlineType.None;
		iparagraphFormat_0.DefaultPortionFormat.IsHardUnderlineFill = NullableBool.False;
		iparagraphFormat_0.DefaultPortionFormat.IsHardUnderlineLine = NullableBool.False;
		iparagraphFormat_0.DefaultPortionFormat.Kumimoji = NullableBool.False;
		iparagraphFormat_0.DefaultPortionFormat.ProofDisabled = NullableBool.False;
		iparagraphFormat_0.DefaultPortionFormat.NormaliseHeight = NullableBool.False;
		iparagraphFormat_0.DefaultPortionFormat.StrikethroughType = TextStrikethroughType.None;
		iparagraphFormat_0.DefaultPortionFormat.TextCapType = TextCapType.None;
		iparagraphFormat_0.DefaultPortionFormat.Spacing = 0f;
	}

	internal void method_3(FontsManager fontsManager)
	{
		fontsManager_0 = fontsManager;
	}

	private void method_4()
	{
		Tags.Remove("AS_TITLE");
		Tags.Add("AS_TITLE", "Aspose.Slides for .NET 4.0");
		Tags.Remove("AS_VERSION");
		Tags.Add("AS_VERSION", "15.1.0.0");
		Tags.Remove("AS_RELEASE_DATE");
		Tags.Add("AS_RELEASE_DATE", "2015.01.30");
		Tags.Remove("AS_OS");
		Tags.Add("AS_OS", Environment.OSVersion.ToString());
		Tags.Remove("AS_NET");
		Tags.Add("AS_NET", Environment.Version.ToString());
	}

	public Presentation()
		: this(new LoadOptions())
	{
	}

	public Presentation(LoadOptions loadOptions)
		: this(loadOptions, 1)
	{
		Class1078.smethod_0(this);
		method_4();
	}

	private Presentation(LoadOptions loadOptions, int dummy)
	{
		if (loadOptions == null)
		{
			loadOptions = new LoadOptions();
		}
		loadOptions_0 = loadOptions;
		Class53.DefaultFontsList.method_8();
		Class53.DefaultFontsList.method_9(isLocal: false);
		class54_0 = new Class54(loadOptions);
		class53_0 = new Class53();
		method_5();
		method_3(new FontsManager(class54_0, class53_0.FontsList));
		customData_0 = new CustomData();
		imageCollection_0 = new ImageCollection(this);
		audioCollection_0 = new AudioCollection(this);
		ivideoCollection_0 = new VideoCollection(this);
		slideCollection_0 = new SlideCollection(this);
		globalLayoutSlideCollection_0 = new GlobalLayoutSlideCollection(this);
		masterSlideCollection_0 = new MasterSlideCollection(this);
		commentAuthorCollection_0 = new CommentAuthorCollection(this);
		class1072_0 = new Class1072(this);
		class1071_0 = new Class1071(this);
		lock (uint_2.SyncRoot)
		{
			uint_0 = uint_2[0]++;
			ulong_0 = (ulong)uint_0 << 32;
		}
		textStyle_0 = new TextStyle(this);
		documentProperties_0 = new DocumentProperties();
		PPTXUnsupportedProps.TableStyles = new Class146(this);
		masterTheme_0 = new MasterTheme(this);
		protectionManager_0 = new ProtectionManager(this);
	}

	private void method_5()
	{
		class53_0.FontsList.CopyFrom(Class53.DefaultFontsList);
	}

	public Presentation(Stream stream)
		: this(stream, new LoadOptions())
	{
	}

	public Presentation(Stream stream, LoadOptions loadOptions)
		: this(loadOptions, 1)
	{
		try
		{
			method_6(stream);
		}
		catch (Exception2 exception)
		{
			throw new PptxReadException("Presentation reading aborted.", exception);
		}
	}

	public Presentation(string file)
		: this(file, new LoadOptions())
	{
	}

	public Presentation(string file, LoadOptions loadOptions)
		: this(loadOptions, 1)
	{
		using Stream stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
		try
		{
			fontsManager_0.FontsList.LocalPresentationContext = true;
			Class53.DefaultFontsList.LocalPresentationContext = true;
			method_6(stream);
		}
		catch (Exception2 exception)
		{
			throw new PptxReadException("Presentation reading aborted.", exception);
		}
		finally
		{
			fontsManager_0.FontsList.LocalPresentationContext = false;
			Class53.DefaultFontsList.LocalPresentationContext = false;
		}
	}

	private void method_6(Stream stream)
	{
		Stream stream2 = Class1161.smethod_0(stream);
		bool flag = smethod_1(stream2);
		if (IsPresentationTreatedAsEncrypted)
		{
			if (flag)
			{
				method_7(stream2);
				return;
			}
			Class1110 @class = Class890.smethod_2(stream);
			if (@class.RootFolder.method_1("PowerPoint Document"))
			{
				method_9(method_11(@class));
			}
			else
			{
				method_7(stream2);
			}
		}
		else if (flag)
		{
			method_8(stream2);
		}
		else
		{
			Class1110 fileSystem = Class890.smethod_2(stream);
			method_9(fileSystem);
		}
	}

	private void method_7(Stream seekableStream)
	{
		using MemoryStream seekableStream2 = method_10(seekableStream);
		method_8(seekableStream2);
	}

	private void method_8(Stream seekableStream)
	{
		if (seekableStream == null)
		{
			throw new ArgumentNullException("seekableStream");
		}
		if (!seekableStream.CanSeek)
		{
			throw new InvalidOperationException();
		}
		try
		{
			bool_0 = true;
			if (!Class476.smethod_1(seekableStream))
			{
				seekableStream.Position = 0L;
				Class1027 @class = new Class1027();
				@class.method_0(this, seekableStream);
				method_12();
			}
			else
			{
				seekableStream.Position = 0L;
				Class1078.smethod_0(this);
				method_14(new Class476(seekableStream));
				method_4();
			}
			method_4();
		}
		finally
		{
			bool_0 = false;
			((HeaderFooterManager)HeaderFooterManager).method_1();
		}
	}

	private void method_9(Class1110 fileSystem)
	{
		if (fileSystem == null)
		{
			throw new ArgumentNullException("fileSystem");
		}
		try
		{
			bool_0 = true;
			Class890 @class = new Class890(this);
			@class.method_1(fileSystem);
			method_12();
			method_4();
		}
		finally
		{
			bool_0 = false;
			((HeaderFooterManager)HeaderFooterManager).method_1();
		}
	}

	private MemoryStream method_10(Stream stream)
	{
		protectionManager_0.Encrypt(loadOptions_0.Password);
		protectionManager_0.method_0(stream);
		MemoryStream memoryStream = Class188.smethod_0(stream, loadOptions_0.Password);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		return memoryStream;
	}

	private Class1110 method_11(Class1110 fileSystem)
	{
		using Stream stream = new MemoryStream(((Class1106)fileSystem.RootFolder.method_2("PowerPoint Document")).method_7());
		Class2844 @class = Class2844.smethod_0(fileSystem);
		Class2895 class2 = (Class2895)Class2985.smethod_3((MemoryStream)stream, @class.OffsetToCurrentEdit, null);
		Class2887 mainPersistBlock = (Class2887)Class2985.smethod_3((MemoryStream)stream, class2.OffsetPersistDirectory, null);
		bool encryptDocumentProperties;
		return Class2614.smethod_3(fileSystem, class2, mainPersistBlock, loadOptions_0.Password, LoadOptions.OnlyLoadDocumentProperties, out encryptDocumentProperties);
	}

	internal static bool smethod_1(Stream stream)
	{
		byte b = (byte)stream.ReadByte();
		stream.Seek(-1L, SeekOrigin.Current);
		if (b == 80)
		{
			return true;
		}
		return false;
	}

	private void method_12()
	{
		foreach (CommentAuthor item in commentAuthorCollection_0)
		{
			((CommentCollection)item.Comments).method_1();
		}
	}

	internal void method_13(Class1110 fs)
	{
		Class1146 sumProps = null;
		Class1146 docProps = null;
		try
		{
			Stream stream;
			using (stream = new MemoryStream(((Class1106)fs.RootFolder.method_2("\u0005SummaryInformation")).method_7()))
			{
				sumProps = new Class1146(stream);
				stream.Close();
			}
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
		}
		try
		{
			Stream stream;
			using (stream = new MemoryStream(((Class1106)fs.RootFolder.method_2("\u0005DocumentSummaryInformation")).method_7()))
			{
				docProps = new Class1146(stream);
			}
		}
		catch (Exception ex2)
		{
			Class1165.smethod_28(ex2);
		}
		Class60 @class = new Class60(docProps, sumProps);
		documentProperties_0 = new DocumentProperties();
		documentProperties_0.Author = @class.Author;
		documentProperties_0.Category = @class.Category;
		documentProperties_0.Comments = @class.Comments;
		documentProperties_0.Company = @class.Company;
		documentProperties_0.CreatedTime = @class.CreatedTime;
		documentProperties_0.Keywords = @class.Keywords;
		documentProperties_0.LastPrinted = @class.LastPrinted;
		documentProperties_0.LastSavedBy = @class.LastSavedBy;
		documentProperties_0.LastSavedTime = @class.LastSavedTime;
		documentProperties_0.Manager = @class.Manager;
		documentProperties_0.NameOfApplication = @class.NameOfApplication;
		documentProperties_0.RevisionNumber = @class.RevisionNumber;
		documentProperties_0.Subject = @class.Subject;
		documentProperties_0.ApplicationTemplate = @class.Template;
		documentProperties_0.Title = @class.Title;
		documentProperties_0.TotalEditingTime = @class.TotalEditingTime;
		documentProperties_0.HyperlinkBase = @class.HyperlinkBase;
	}

	internal void method_14(Class476 package)
	{
		sourceFormat_0 = SourceFormat.Odp;
		class476_0 = package;
		PPTXUnsupportedProps.PresentationType = Enum165.const_0;
		if (package.class463_0.class412_0 != null)
		{
			DocumentProperties.NameOfApplication = package.class463_0.class412_0.InnerText;
		}
		if (package.class463_0.class412_8 != null)
		{
			DocumentProperties.CreatedTime = package.class463_0.DateTimeCreated;
		}
		if (package.class463_0.class412_5 != null)
		{
			DocumentProperties.Author = package.class463_0.class412_5.InnerText;
		}
		if (package.class463_0.class412_2 != null)
		{
			DocumentProperties.Comments = package.class463_0.class412_2.InnerText;
		}
		if (package.class463_0.class412_4 != null)
		{
			DocumentProperties.Keywords = package.class463_0.class412_4.InnerText;
		}
		if (package.class463_0.class412_6 != null)
		{
			DocumentProperties.LastSavedBy = package.class463_0.class412_6.InnerText;
		}
		if (package.class463_0.class412_9 != null)
		{
			DocumentProperties.LastSavedTime = package.class463_0.DateTimeModified;
		}
		if (package.class463_0.class412_10 != null)
		{
			DocumentProperties.LastPrinted = package.class463_0.DateTimePrinted;
		}
		if (package.class463_0.class412_11 != null)
		{
			try
			{
				DocumentProperties.RevisionNumber = int.Parse(package.class463_0.class412_11.InnerText);
			}
			catch (Exception ex)
			{
				Class1165.smethod_28(ex);
			}
		}
		if (package.class463_0.class412_3 != null)
		{
			DocumentProperties.Subject = package.class463_0.class412_3.InnerText;
		}
		if (package.class463_0.class412_1 != null)
		{
			DocumentProperties.Title = package.class463_0.class412_1.InnerText;
		}
		if (package.class463_0.class412_12 != null)
		{
			DocumentProperties.TotalEditingTime = package.class463_0.DateTimeTotalTime;
		}
		slideSize_0.Size = new SizeF(package.class465_0.SlideSize[0], package.class465_0.SlideSize[1]);
		slideSize_0.Orientation = ((package.class465_0.SlideSize[2] != 0f) ? SlideOrienation.Portrait : SlideOrienation.Landscape);
		foreach (Class472 item in package.list_1)
		{
			imageCollection_0.method_2(new Class472(item.class480_0, package));
		}
		if (package.class465_0.MasterPages.Length > 1)
		{
			for (int i = 1; i < package.class465_0.MasterPages.Length; i++)
			{
				masterSlideCollection_0.AddClone(masterSlideCollection_0[0]);
			}
		}
		for (int j = 0; j < package.class465_0.MasterPages.Length; j++)
		{
			((MasterSlide)masterSlideCollection_0[j]).method_15(package.class465_0.MasterPages[j], package);
		}
		if (package.class462_0.Pages.Length > 1)
		{
			for (int k = 1; k < package.class462_0.Pages.Length; k++)
			{
				slideCollection_0.AddClone(slideCollection_0[0]);
			}
		}
		for (int l = 0; l < package.class462_0.Pages.Length; l++)
		{
			((Slide)slideCollection_0[l]).method_19(package.class462_0.Pages[l], package);
		}
	}

	internal void method_15(Class6752 zipFile)
	{
		Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Aspose.Slides.DOM.resources.template.odp");
		Class476 @class = new Class476(manifestResourceStream);
		@class.class463_0.method_2(Class463.Enum61.const_0, "Aspose.Slides");
		@class.class463_0.method_2(Class463.Enum61.const_8, DocumentProperties.CreatedTime);
		@class.class463_0.method_2(Class463.Enum61.const_5, DocumentProperties.Author);
		@class.class463_0.method_2(Class463.Enum61.const_2, DocumentProperties.Comments);
		@class.class463_0.method_2(Class463.Enum61.const_4, DocumentProperties.Keywords);
		@class.class463_0.method_2(Class463.Enum61.const_6, DocumentProperties.LastSavedBy);
		@class.class463_0.method_2(Class463.Enum61.const_9, DocumentProperties.LastSavedTime);
		@class.class463_0.method_2(Class463.Enum61.const_10, DocumentProperties.LastPrinted);
		@class.class463_0.method_2(Class463.Enum61.const_11, DocumentProperties.RevisionNumber);
		@class.class463_0.method_2(Class463.Enum61.const_3, DocumentProperties.Subject);
		@class.class463_0.method_2(Class463.Enum61.const_1, DocumentProperties.Title);
		@class.class463_0.method_2(Class463.Enum61.const_12, DocumentProperties.TotalEditingTime);
		@class.class465_0.method_14(SlideSize.Size.Width, SlideSize.Size.Height, (SlideSize.Orientation != 0) ? 1 : 0);
		foreach (MasterSlide master in Masters)
		{
			master.method_16(@class);
		}
		foreach (Slide slide in Slides)
		{
			slide.method_20(@class);
		}
		@class.method_8();
		Dictionary<string, Class480> dictionary = new Dictionary<string, Class480>(@class.sortedList_0.Count);
		foreach (Class480 value2 in @class.sortedList_0.Values)
		{
			string text = value2.string_0;
			if (text != null)
			{
				dictionary.Add(text, value2);
			}
		}
		foreach (KeyValuePair<string, Class480> item in dictionary)
		{
			string key = item.Key;
			Class480 value = item.Value;
			if (value.class461_0 != null)
			{
				value.class461_0.vmethod_1();
				using MemoryStream memoryStream = new MemoryStream();
				XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
				xmlTextWriter.Formatting = Formatting.None;
				value.class461_0.WriteTo(xmlTextWriter);
				xmlTextWriter.Flush();
				zipFile.method_30(key, null, memoryStream.ToArray());
			}
			else if (value.string_0.IndexOf("manifest") > -1)
			{
				using MemoryStream memoryStream2 = new MemoryStream();
				XmlTextWriter xmlTextWriter2 = new XmlTextWriter(memoryStream2, Encoding.UTF8);
				xmlTextWriter2.Formatting = Formatting.Indented;
				@class.class475_0.WriteTo(xmlTextWriter2);
				xmlTextWriter2.Flush();
				zipFile.method_30(key, null, memoryStream2.ToArray());
			}
			else if (value.byte_0 != null)
			{
				zipFile.method_30(key, null, value.byte_0);
			}
			else
			{
				if (value.class6751_0 == null)
				{
					continue;
				}
				using Stream stream = value.class6751_0.method_19();
				using MemoryStream memoryStream3 = new MemoryStream();
				byte[] array = new byte[4096];
				int count;
				while ((count = stream.Read(array, 0, array.Length)) > 0)
				{
					memoryStream3.Write(array, 0, count);
				}
				zipFile.method_30(key, null, memoryStream3.ToArray());
			}
		}
	}

	internal void Write(Stream stream, Enum165 type, IPptxOptions options)
	{
		method_22();
		if (protectionManager_0.IsOnlyDocumentPropertiesLoaded)
		{
			throw new PptxException("If PPTX presentation is loaded with LoadOptions.OnlyLoadDocumentProperties then saving this peresentation with modified document properties make no sense because public document properties of a encrypted PPTX presentation are a secondary copy of a base encrypted document properties. And we cannot modify encrypted document properties without valid password.");
		}
		if (!protectionManager_0.IsEncrypted)
		{
			using (Class6752 class2 = new Class6752())
			{
				Class1028 @class = new Class1028();
				@class.method_0(this, class2, type, options);
				class2.Save(stream);
				return;
			}
		}
		using MemoryStream memoryStream = new MemoryStream();
		using Class6752 class4 = new Class6752();
		Class1028 class3 = new Class1028();
		class3.method_0(this, class4, type, options);
		class4.Save(memoryStream);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		Class60 customProps = null;
		if (!protectionManager_0.EncryptDocumentProperties)
		{
			customProps = method_16();
		}
		Class188.Encrypt(memoryStream, protectionManager_0.EncryptionPassword, stream, customProps);
	}

	private Class60 method_16()
	{
		Class60 @class = new Class60();
		if (!documentProperties_0.CreatedTime.Equals(DateTime.MinValue))
		{
			@class.CreatedTime = documentProperties_0.CreatedTime;
		}
		if (!documentProperties_0.LastPrinted.Equals(DateTime.MinValue))
		{
			@class.LastPrinted = documentProperties_0.LastPrinted;
		}
		if (!documentProperties_0.LastSavedTime.Equals(DateTime.MinValue))
		{
			@class.LastSavedTime = documentProperties_0.LastSavedTime;
		}
		if (!documentProperties_0.TotalEditingTime.Equals(default(TimeSpan)))
		{
			@class.TotalEditingTime = documentProperties_0.TotalEditingTime;
		}
		@class.Author = documentProperties_0.Author;
		@class.Category = documentProperties_0.Category;
		@class.Comments = documentProperties_0.Comments;
		@class.Company = documentProperties_0.Company;
		@class.Keywords = documentProperties_0.Keywords;
		@class.LastSavedBy = documentProperties_0.LastSavedBy;
		@class.Manager = documentProperties_0.Manager;
		@class.NameOfApplication = documentProperties_0.NameOfApplication;
		@class.RevisionNumber = documentProperties_0.RevisionNumber;
		@class.Subject = documentProperties_0.Subject;
		@class.Template = documentProperties_0.ApplicationTemplate;
		@class.Title = documentProperties_0.Title;
		@class.HyperlinkBase = documentProperties_0.HyperlinkBase;
		return @class;
	}

	private Enum165 method_17(Stream stream)
	{
		if (stream is FileStream)
		{
			FileStream fileStream = (FileStream)stream;
			string extension = Path.GetExtension(fileStream.Name).ToLower();
			return Class889.smethod_2(extension, PPTXUnsupportedProps.PresentationType);
		}
		return PPTXUnsupportedProps.PresentationType;
	}

	[Obsolete("Use ProtectionManager.Encrypt(..) method instead. Will be removed after 01.09.2013.")]
	public void Encrypt(string password)
	{
		protectionManager_0.Encrypt(password);
	}

	[Obsolete("Use ProtectionManager.RemoveEncryption() method instead. Will be removed after 01.09.2013.")]
	public void RemoveEncryption()
	{
		protectionManager_0.RemoveEncryption();
	}

	[Obsolete("Use ProtectionManager.SetWriteProtection(..) method instead. Will be removed after 01.09.2013.")]
	public void SetWriteProtection(string password)
	{
		protectionManager_0.SetWriteProtection(password);
	}

	[Obsolete("Use ProtectionManager.RemoveWriteProtection() method instead. Will be removed after 01.09.2013.")]
	public void RemoveWriteProtection()
	{
		protectionManager_0.RemoveWriteProtection();
	}

	internal ulong method_18()
	{
		lock (this)
		{
			return ulong_0++;
		}
	}

	internal Slide method_19()
	{
		Slide slide = Class1080.smethod_0(this);
		slide.PPTXUnsupportedProps.SlideId = PPTXUnsupportedProps.method_0();
		return slide;
	}

	internal void method_20(IMasterTheme masterTheme)
	{
		masterTheme_0 = (MasterTheme)masterTheme;
	}

	public void Save(string fname, SaveFormat format)
	{
		using FileStream stream = new FileStream(fname, FileMode.Create, FileAccess.Write);
		Save(stream, format, null);
	}

	public void Save(Stream stream, SaveFormat format)
	{
		Save(stream, format, null);
	}

	public void Save(string fname, SaveFormat format, ISaveOptions options)
	{
		using FileStream stream = new FileStream(fname, FileMode.Create, FileAccess.Write);
		Save(stream, format, options);
	}

	public void Save(Stream stream, SaveFormat format, ISaveOptions options)
	{
		try
		{
			switch (format)
			{
			case SaveFormat.Ppt:
			{
				Class891 class2 = new Class891(this);
				class2.method_0(stream, options);
				break;
			}
			case SaveFormat.Pdf:
			{
				method_22();
				PdfOptions pdfOptions = options as PdfOptions;
				if (pdfOptions == null)
				{
					pdfOptions = new PdfOptions();
				}
				fontsManager_0.UseFontsSubstitutionsList = true;
				Class197.smethod_1(this, stream, pdfOptions, options);
				break;
			}
			case SaveFormat.Xps:
			{
				method_22();
				XpsOptions xpsOptions = options as XpsOptions;
				if (xpsOptions == null)
				{
					xpsOptions = new XpsOptions();
				}
				Class197.smethod_3(this, stream, xpsOptions);
				break;
			}
			case SaveFormat.Pptx:
				Write(stream, Enum165.const_0, options as PptxOptions);
				break;
			case SaveFormat.Ppsx:
				Write(stream, Enum165.const_2, options as PptxOptions);
				break;
			case SaveFormat.Tiff:
			{
				method_22();
				TiffOptions tiffOptions2 = options as TiffOptions;
				if (tiffOptions2 == null)
				{
					tiffOptions2 = new TiffOptions();
					tiffOptions2.ImageSize = new Size((int)((double)SlideSize.Size.Width + 0.5), (int)((double)SlideSize.Size.Height + 0.5));
				}
				fontsManager_0.UseFontsSubstitutionsList = true;
				Class197.smethod_8(this, stream, tiffOptions2);
				break;
			}
			case SaveFormat.Odp:
			{
				method_22();
				using Class6752 @class = new Class6752();
				method_15(@class);
				@class.Save(stream);
				break;
			}
			case SaveFormat.Pptm:
				Write(stream, Enum165.const_1, options as PptxOptions);
				break;
			case SaveFormat.Ppsm:
				Write(stream, Enum165.const_3, options as PptxOptions);
				break;
			case SaveFormat.Potx:
				Write(stream, Enum165.const_4, options as PptxOptions);
				break;
			case SaveFormat.Potm:
				Write(stream, Enum165.const_5, options as PptxOptions);
				break;
			default:
				throw new PptxException("This export format is not implemented for PPTX yet.");
			case SaveFormat.Html:
				method_22();
				Class197.smethod_10(this, stream, options as HtmlOptions);
				break;
			case SaveFormat.TiffNotes:
			{
				method_22();
				TiffOptions tiffOptions = options as TiffOptions;
				if (tiffOptions == null)
				{
					tiffOptions = new TiffOptions();
					tiffOptions.ImageSize = new Size((int)((double)NotesSize.Width + 0.5), (int)((double)NotesSize.Height + 0.5));
				}
				Class197.smethod_5(this, stream, tiffOptions, withNotes: true);
				break;
			}
			}
		}
		catch (Exception2 exception)
		{
			throw new PptxException("Saving aborted.", exception);
		}
		finally
		{
			fontsManager_0.UseFontsSubstitutionsList = false;
		}
	}

	public void Save(string fname, int[] slides, SaveFormat format)
	{
		using FileStream stream = new FileStream(fname, FileMode.Create, FileAccess.Write);
		Save(stream, slides, format);
	}

	public void Save(string fname, int[] slides, SaveFormat format, ISaveOptions options)
	{
		using FileStream stream = new FileStream(fname, FileMode.Create, FileAccess.Write);
		Save(stream, slides, format, options);
	}

	public void Save(Stream stream, int[] slides, SaveFormat format)
	{
		Save(stream, slides, format, null);
	}

	public void Save(Stream stream, int[] slides, SaveFormat format, ISaveOptions options)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		if (slides == null)
		{
			throw new ArgumentNullException("slides");
		}
		if (slides.Length == 0)
		{
			throw new ArgumentException("'slides' array is empty", "slides");
		}
		int num = 0;
		while (true)
		{
			if (num < slides.Length)
			{
				if (slides[num] < 1 || slides[num] > Slides.Count)
				{
					break;
				}
				num++;
				continue;
			}
			try
			{
				switch (format)
				{
				case SaveFormat.Pdf:
				{
					method_22();
					PdfOptions pdfOptions = options as PdfOptions;
					if (pdfOptions == null)
					{
						pdfOptions = new PdfOptions();
					}
					fontsManager_0.UseFontsSubstitutionsList = true;
					Class197.smethod_2(this, stream, slides, pdfOptions, null);
					break;
				}
				case SaveFormat.Xps:
				{
					method_22();
					XpsOptions xpsOptions = options as XpsOptions;
					if (xpsOptions == null)
					{
						xpsOptions = new XpsOptions();
					}
					Class197.smethod_4(this, stream, slides, xpsOptions);
					break;
				}
				case SaveFormat.Tiff:
				{
					method_22();
					TiffOptions tiffOptions2 = options as TiffOptions;
					if (tiffOptions2 == null)
					{
						tiffOptions2 = new TiffOptions();
					}
					tiffOptions2.ImageSize = new Size((int)((double)SlideSize.Size.Width + 0.5), (int)((double)SlideSize.Size.Height + 0.5));
					fontsManager_0.UseFontsSubstitutionsList = true;
					Class197.smethod_9(this, stream, slides, tiffOptions2);
					break;
				}
				case SaveFormat.Ppt:
				case SaveFormat.Pptx:
				case SaveFormat.Ppsx:
				case SaveFormat.Odp:
				case SaveFormat.Pptm:
				case SaveFormat.Ppsm:
				case SaveFormat.Potx:
				case SaveFormat.Potm:
					throw new InvalidOperationException("Saving with specified slide positions is not possible for PPTX, PPTM, PPSX, PPSM, POTX, POTM, PPT, ODP formats. Use cloning for them.");
				default:
					throw new PptxException("This export format is not implemented for PPTX yet.");
				case SaveFormat.Html:
				{
					method_22();
					HtmlOptions htmlOptions = options as HtmlOptions;
					if (htmlOptions == null)
					{
						htmlOptions = new HtmlOptions();
					}
					Class197.smethod_11(this, stream, slides, htmlOptions);
					break;
				}
				case SaveFormat.TiffNotes:
				{
					method_22();
					TiffOptions tiffOptions = options as TiffOptions;
					if (tiffOptions == null)
					{
						tiffOptions = new TiffOptions();
					}
					tiffOptions.ImageSize = new Size((int)((double)NotesSize.Width + 0.5), (int)((double)NotesSize.Height + 0.5));
					fontsManager_0.UseFontsSubstitutionsList = true;
					Class197.smethod_6(this, stream, slides, tiffOptions, withNotes: true);
					break;
				}
				}
				return;
			}
			catch (Exception2 exception)
			{
				throw new PptxException("Saving aborted.", exception);
			}
			finally
			{
				fontsManager_0.UseFontsSubstitutionsList = false;
			}
		}
		throw new ArgumentOutOfRangeException("slides", $"'slides' array contains {slides[num]} slide position, which is not present in the presentaiton.");
	}

	public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline)
	{
		Save(fname, format, null, response, showInline);
	}

	public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline)
	{
		if (fname.IndexOf('\\') >= 0)
		{
			throw new ArgumentException("Wrong file name specified. The name should not contain path.");
		}
		if (response == null)
		{
			throw new ArgumentNullException("response");
		}
		response.ClearContent();
		if (showInline)
		{
			response.AddHeader("content-disposition", "inline; filename=" + fname);
		}
		else
		{
			response.AddHeader("content-disposition", "attachment; filename=" + fname);
		}
		switch (format)
		{
		case SaveFormat.Pdf:
			fontsManager_0.UseFontsSubstitutionsList = true;
			response.ContentType = "application/pdf";
			break;
		case SaveFormat.Xps:
			response.ContentType = "application/vnd.ms-xpsdocument";
			break;
		case SaveFormat.Pptx:
			response.ContentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
			break;
		default:
			throw new PptxException("This export format is not implemented for PPT yet.");
		case SaveFormat.Tiff:
			fontsManager_0.UseFontsSubstitutionsList = true;
			response.ContentType = "image/tiff";
			break;
		}
		MemoryStream memoryStream = new MemoryStream();
		try
		{
			Save(memoryStream, format, options);
		}
		finally
		{
			fontsManager_0.UseFontsSubstitutionsList = false;
		}
		response.OutputStream.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
	}

	public void Print()
	{
		Print(new PrinterSettings());
	}

	public void Print(PrinterSettings printerSettings)
	{
		if (printerSettings == null)
		{
			throw new ArgumentNullException("printerSettings");
		}
		Print(printerSettings, null);
	}

	public void Print(string printerName)
	{
		PrinterSettings printerSettings = new PrinterSettings();
		printerSettings.PrinterName = printerName;
		Print(printerSettings);
	}

	public void Print(PrinterSettings printerSettings, string presName)
	{
		if (printerSettings == null)
		{
			throw new ArgumentNullException("printerSettings");
		}
		Class198 @class = new Class198(this);
		if (presName != null)
		{
			@class.DocumentName = presName;
		}
		@class.PrinterSettings = printerSettings;
		@class.PrintController = new StandardPrintController();
		@class.Print();
	}

	public void JoinPortionsWithSameFormatting()
	{
		foreach (IMasterSlide master in Masters)
		{
			master.JoinPortionsWithSameFormatting();
		}
		if (MasterNotesSlideManager.MasterNotesSlide != null)
		{
			MasterNotesSlideManager.MasterNotesSlide.JoinPortionsWithSameFormatting();
		}
		if (MasterHandoutSlideManager.MasterHandoutSlide != null)
		{
			MasterHandoutSlideManager.MasterHandoutSlide.JoinPortionsWithSameFormatting();
		}
		foreach (ILayoutSlide layoutSlide in LayoutSlides)
		{
			layoutSlide.JoinPortionsWithSameFormatting();
		}
		foreach (ISlide slide in Slides)
		{
			slide.JoinPortionsWithSameFormatting();
		}
	}

	private void method_21()
	{
		uint_1++;
	}

	private void method_22()
	{
		((HeaderFooterManager)HeaderFooterManager).method_2();
	}

	~Presentation()
	{
		Dispose();
	}

	public void Dispose()
	{
	}
}
