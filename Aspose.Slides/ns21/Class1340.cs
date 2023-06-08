using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Theme;
using Aspose.Slides.Warnings;
using ns16;
using ns49;
using ns53;
using ns54;

namespace ns21;

internal class Class1340 : Class1339
{
	private ChartDataWorkbook chartDataWorkbook_0;

	private Enum168 enum168_0;

	private readonly Dictionary<Class1342, IPPImage> dictionary_0;

	private readonly Dictionary<Class1342, IAudio> dictionary_1;

	private readonly Dictionary<Class1342, IVideo> dictionary_2;

	private readonly Dictionary<Class1342, ITheme> dictionary_3;

	private readonly Dictionary<string, List<IHyperlink>> dictionary_4;

	private readonly Dictionary<uint, ICommentAuthor> dictionary_5;

	private readonly Dictionary<string, IChartDataWorksheet> dictionary_6;

	private readonly List<IShape> list_0 = new List<IShape>();

	private readonly SortedList<string, SortedList<string, Class1342>> sortedList_0;

	internal Enum168 Mode
	{
		get
		{
			return enum168_0;
		}
		set
		{
			enum168_0 = value;
		}
	}

	internal Dictionary<string, List<IHyperlink>> SlidePartPathToUnresolvedHyperinks => dictionary_4;

	internal Dictionary<uint, ICommentAuthor> CommentAuthorXmlIdToCommentAuthor => dictionary_5;

	internal Dictionary<string, IChartDataWorksheet> SheetPartPathToSheet => dictionary_6;

	internal List<IShape> Shapes => list_0;

	internal SortedList<string, SortedList<string, Class1342>> MasterSlidePartPathToBackLinksFromLayouts => sortedList_0;

	internal Dictionary<Class1342, ITheme> ThemePartToTheme => dictionary_3;

	internal ChartDataWorkbook Workbook => chartDataWorkbook_0;

	public Class1340(IChartDataWorkbook workbook)
	{
		chartDataWorkbook_0 = (ChartDataWorkbook)workbook;
		dictionary_0 = new Dictionary<Class1342, IPPImage>();
		dictionary_1 = new Dictionary<Class1342, IAudio>();
		dictionary_2 = new Dictionary<Class1342, IVideo>();
		dictionary_3 = new Dictionary<Class1342, ITheme>();
		dictionary_4 = new Dictionary<string, List<IHyperlink>>();
		dictionary_5 = new Dictionary<uint, ICommentAuthor>();
		dictionary_6 = new Dictionary<string, IChartDataWorksheet>();
		sortedList_0 = new SortedList<string, SortedList<string, Class1342>>();
	}

	internal void method_0(string description, WarningType warningType)
	{
		if (Workbook.LoadOptions != null && Workbook.LoadOptions.WarningCallback != null)
		{
			Class1176 @class = new Class1176(description, warningType);
			@class.SendWarning(Workbook.LoadOptions.WarningCallback);
		}
	}
}
