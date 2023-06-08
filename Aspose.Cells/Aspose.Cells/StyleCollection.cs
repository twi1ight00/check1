using System.Collections;
using ns44;

namespace Aspose.Cells;

/// <summary>
///       Encapsulates a collection of <see cref="T:Aspose.Cells.Style" /> objects.
///       </summary>
/// <example>
///   <code>
///       [C#]
///
///       Workbook workbook = new Workbook();
///       StyleCollection styles = workbook.Styles;
///       int styleIndex = styles.Add();
///       Style style = excel.Styles[styleIndex];
///
///       [Visual Basic]
///
///       Dim workbook as Workbook = new Workbook()
///       Dim styles as StyleCollection = excel.Styles
///       Dim styleIndex as Integer = styles.Add()
///       Dim style as Style = excel.Styles(styleIndex)
///       </code>
/// </example>
public class StyleCollection
{
	private WorksheetCollection worksheetCollection_0;

	private ArrayList arrayList_0;

	/// <summary>
	///        Gets the <see cref="T:Aspose.Cells.Style" /> element at the specified index.
	///        </summary>
	/// <param name="index">The zero based index of the element.</param>
	/// <returns>The element at the specified index.</returns>
	/// <example>
	///   <code>
	///
	///       [C#]
	///
	///       Styles styles = excel.Styles;
	///       int styleIndex = styles.Add();
	///       Style style = styles[styleIndex];
	///
	///       [Visual Basic]
	///
	///       Dim styles As Styles =  excel.Styles 
	///       Dim styleIndex As Integer =  styles.Add() 
	///       Dim style As Style =  styles(styleIndex)
	///       </code>
	/// </example>
	public Style this[int index] => (Style)arrayList_0[index];

	/// <summary>
	///        Gets the <see cref="T:Aspose.Cells.Style" /> element at the specified name.
	///        </summary>
	/// <param name="name">Style name</param>
	/// <returns>The element at the specified name.</returns>
	/// <example>
	///   <code>
	///        [C#]
	///
	///        Styles styles = excel.Styles;
	///        int styleIndex = styles.Add();
	///        Style style = styles[styleIndex];
	///        style.Name = "MyStyle";
	///        //.....................
	///        Style newStyle = styles["MyStyle"];
	///
	///        [Visual Basic]
	///
	///        Dim styles As Styles =  excel.Styles 
	///        Dim styleIndex As Integer =  styles.Add() 
	///        Dim style As Style =  styles(styleIndex) 
	///        style.Name = "MyStyle"
	///        Dim NewStyle As Style =  styles("MyStyle")
	///       </code>
	/// </example>
	public Style this[string name]
	{
		get
		{
			int num = 0;
			Style style;
			while (true)
			{
				if (num < Count)
				{
					style = this[num];
					if (style.Name == name)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return style;
		}
	}

	/// <summary>
	///       Gets the count of elements in the collection.
	///       </summary>
	public int Count => arrayList_0.Count;

	internal StyleCollection(WorksheetCollection worksheetCollection_1)
	{
		arrayList_0 = new ArrayList();
		worksheetCollection_0 = worksheetCollection_1;
	}

	/// <summary>
	///       Gets the theme style.
	///       </summary>
	/// <param name="themeColorType">The theme color type.</param>
	/// <param name="tint">The tint value.</param>
	/// <returns>
	/// </returns>
	public Style GetThemeStyle(ThemeColorType themeColorType, double tint)
	{
		Style style = new Style(worksheetCollection_0);
		style.Font.method_14(worksheetCollection_0.DefaultFont.Name, worksheetCollection_0.DefaultFont.method_23());
		style.Font.Size = worksheetCollection_0.DefaultFont.Size;
		style.Font.InternalColor.method_19(worksheetCollection_0.DefaultFont.InternalColor);
		style.method_36(StyleModifyFlag.FontColor);
		style.Pattern = BackgroundType.Solid;
		style.method_36(StyleModifyFlag.ForegroundColor);
		style.ForeInternalColor.SetColor(ColorType.Theme, (int)themeColorType);
		style.ForeInternalColor.Tint = tint;
		return style;
	}

	/// <summary>
	/// </summary>
	/// <param name="type">
	/// </param>
	/// <returns>
	/// </returns>
	public Style CreateBuiltinStyle(BuiltinStyleType type)
	{
		return Class1682.smethod_1(type, worksheetCollection_0);
	}

	/// <summary>
	///       Adds a <see cref="T:Aspose.Cells.Style" /> to the collection.
	///       </summary>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Style" /> object index.</returns>
	/// <remarks>
	///       If using this method to create a new style and the style name is set, 
	///       a new style will be added to the style dialog of MS Excel.
	///       To avoid this, you can leave the style name blank. 
	///       </remarks>
	public int Add()
	{
		int count = arrayList_0.Count;
		Style style = new Style(worksheetCollection_0);
		style.GetStyle(worksheetCollection_0, 15);
		arrayList_0.Add(style);
		count++;
		return count - 1;
	}

	internal int Add(Style style_0)
	{
		arrayList_0.Add(style_0);
		return arrayList_0.Count - 1;
	}

	internal void method_0(Style style_0)
	{
		arrayList_0.Add(style_0);
	}

	internal void Clear()
	{
		arrayList_0.Clear();
	}

	internal void Copy(StyleCollection styleCollection_0)
	{
		for (int i = 0; i < styleCollection_0.arrayList_0.Count; i++)
		{
			Style style = (Style)styleCollection_0.arrayList_0[i];
			Style style2 = new Style(worksheetCollection_0);
			style2.Copy(style);
			if (style.Name != null)
			{
				style2.method_3(style.Name);
			}
			arrayList_0.Add(style2);
		}
	}
}
